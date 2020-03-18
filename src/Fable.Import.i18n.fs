// ts2fable 0.6.1
module Fable.Import.i18n
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.React
open Fable.Core.JsInterop
open Fable
open Fable.Core


let inline rtEl<'P when 'P :> IHTMLProp> (a:ComponentClass<'P>) (b:IHTMLProp list) c = 
    Fable.Helpers.React.from a (keyValueList CaseRules.LowerFirst b |> unbox) c

type IntlProviderProps =
    | Locale of string
    interface IHTMLProp

type FormattedMessageProps =
    | Id of string
    | DefaultMessage of string
    | Values of obj
    interface IHTMLProp

let IntlProvider = importMember<ComponentClass<IHTMLProp>> "react-intl"
let FormattedMessage = importMember<ComponentClass<IHTMLProp>> "react-intl"
let inline intlProvider props c = rtEl IntlProvider props c 
let inline formattedMessage props c = rtEl FormattedMessage props c


type i18n =
    [<Emit "$0.use($1)">] abstract  Use : obj -> unit
    abstract t : U2<string [],string> -> string
    abstract init :  obj * (obj -> string) -> unit
    abstract init :  (obj -> string) -> unit
    abstract exists : string * ?optons : obj -> bool
    abstract getFixedT : string * ?ns :string -> (string -> string)
    abstract changeLanguage : string * (obj * (string -> string) -> unit) -> unit
    abstract langauge : string with get 
    abstract languages : string [] with get
    abstract loadNamespaces : string * (obj * (string -> string) -> unit) -> unit
    abstract loadNamespaces : string [] * (obj * (string -> string) -> unit) -> unit
    abstract loadLanguages : string * (obj * (string -> string) -> unit) -> unit
    abstract loadLanguages : string [] * (obj * (string -> string) -> unit) -> unit
    abstract reloadResources : string [] * string [] * (unit -> obj) -> unit
    abstract setDefaultNamespace : string -> unit
    abstract dir : string -> unit
    abstract format : obj * string * string -> string
    abstract createInstance : obj * (obj -> string) -> obj
    abstract cloneInstance : obj -> obj
    abstract on : string * (obj -> unit)
    abstract getResource : string * string * string * obj -> obj
    abstract addResource : string * string * string * obj * obj -> unit
    abstract addResources : string * string * obj -> unit
    abstract addResourceBundle : string * string * obj * bool * bool -> unit
    abstract hasResourceBundle : string * string -> bool
    abstract getResourceBundle : string * string -> obj
    abstract removeResourceBundle : string * string -> unit 


[<Import("i18n", from="i18next")>]
let i18n :i18n = jsNative
    



