---
title: Získání a aktualizace vlastností zobrazení prezentace v .NET
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/net/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý oddělovač
- jediné zobrazení
- stav panelu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte Aspose.Slides pro .NET k nastavení rozložení normálního zobrazení, přiblížení snímku a poznámek, rozestupu mřížky a viditelnosti komentářů v prezentacích PowerPoint."
---
## **Úvod**

V normálním zobrazení PowerPointu se snímek zobrazuje mezi postranním panelem pro miniatury nebo osnovu a panelem poznámek pod ním. Aspose.Slides pro .NET zpřístupňuje uložené preference úprav prezentace prostřednictvím [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Patří sem rozložení panelů, úrovně přiblížení, rozestupy mřížky a viditelnost komentářů.

## **O INormalViewProperties**

Použijte [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) k přístupu k rozhraní [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) řídí, zda se ikony zobrazují vedle názvů snímků v osnově. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) umožňuje, aby se postranní panel při zúžení uživatelem přichytl k minimalizovanému stavu. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) označuje preferenci zobrazovat jeden panel v celé obrazovce.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) řídí oddělovač mezi postranním panelem a snímkem. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) řídí oddělovač nad panelem poznámek. Oba přijímají hodnotu [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` nebo `Restored`.

## **O obnovení INormalViewProperties**

Když je oddělovač obnoven, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) poskytuje uloženou velikost postranního panelu a [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) poskytuje uloženou velikost horní oblasti snímku. Oba vystavují [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Jeho vlastnost [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) přijímá procento od 0 do 100 a [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) řídí, zda editor upraví velikost při změně velikosti okna.

Tento příklad aktualizuje existující prezentaci. Obnoví vodorovný oddělovač, nastaví [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) na 80% s povoleným automatickým přizpůsobením a maximalizuje svislý oddělovač. Také povolí [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) pro zobrazení osnovy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Nastavení výchozí hodnoty přiblížení**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) a [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) ukládají nezávislé nastavení přiblížení pro editor. Tato nastavení neovlivňují rozměry snímků, přehrávání prezentace ani rozlišení exportu obrázků.

Tento příklad otevře existující prezentaci a povolí [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) aby se snímek přizpůsobil oknu editoru. Pro stránku poznámek zakáže automatické škálování a nastaví [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) na pevné 80% přiblížení.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Nastavení rozestupu mřížky**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) nastavuje vzdálenost mezi čarami editační mřížky v celé prezentaci. Přijímá kladnou hodnotu v bodech, přičemž 72 bodů představuje jeden palec. Tento příklad vypíše aktuální rozestup v existující prezentaci a uloží čtvrttpalcovou mřížku nastavením intervalu na 18 bodů.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Mřížka se opakuje v pevném intervalu. [Kreslicí vodítka](/slides/cs/net/drawing-guides/) označují jednotlivé vodorovné nebo svislé pozice. Obě jsou pomůckami při úpravách a zobrazují se jen v editorech, které je podporují. Prezentace a exporty do PDF, obrázků nebo SVG je vynechají.

## **Zobrazit nebo skrýt komentáře při otevření prezentace**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) ukládá preferenci, kterou kompatibilní editory používají při otevírání prezentace. Pro existující prezentaci s komentáři tento příklad vypíše aktuální nastavení a uloží kopii s komentáři skrytými. Také nastaví [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) na [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) aby se kopie otevřela ve zobrazení snímků.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Skrytí komentářů zachovává jejich text, autory, umístění, odpovědi a stavy. Pro změnu samotných komentářů viz [Komentáře k prezentaci](/slides/cs/net/presentation-comments/). Nastavení exportu řídí, zda se komentáře zobrazí v PDF, HTML, obrázcích, poznámkách nebo podkladech.

## **Často kladené otázky**

**Proč je mřížka skryta, když znovu otevřu prezentaci?**  
Prezentace ukládá interval mřížky. Chcete‑li mřížku vidět, povolte její viditelnost v editoru.

**Mění vymazání kreslicích vodítek rozestup mřížky?**  
Ne. Přidání, přesunutí nebo vymazání vodítka nezmění interval mřížky.

**Může mít různá oddíly prezentace různá nastavení zobrazení?**  
Ne. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) se vztahuje na celou prezentaci.

**Mohu uložit různá nastavení zobrazení pro různé uživatele?**  
Soubor ukládá jeden soubor vlastností zobrazení pro všechny. Editor může také použít místní preference uživatele.

**Mohu uložit nastavení zobrazení v šabloně?**  
Ano. Prezentace vytvořené ze šablony zdědí její uložená nastavení zobrazení.