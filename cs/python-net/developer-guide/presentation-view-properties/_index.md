---
title: Načtení a aktualizace vlastností zobrazení prezentace v Pythonu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/python-net/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý rozdělovač
- jednoduché zobrazení
- stav pruhu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Použijte Aspose.Slides pro Python prostřednictvím .NET k nastavení rozvržení normálního zobrazení, přiblížení snímků a poznámek, rozestupu mřížky a viditelnosti komentářů v prezentacích PowerPoint."
---
## **Úvod**

V normálním zobrazení PowerPointu se snímek zobrazí mezi postranním panelem pro náhledy nebo osnovu a pod ním panelem poznámek. Aspose.Slides pro Python prostřednictvím .NET zpřístupňuje uložené preference úprav prezentace prostřednictvím [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Patří sem rozvržení panelů, úrovně přiblížení, rozestupy mřížky a viditelnost komentářů.

## **O NormalViewProperties**

Použijte [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) k přístupu k objektu [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) řídí, zda se v osnově zobrazují ikony vedle názvů snímků. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) umožňuje postrannímu panelu přichytit se do svého minimalizovaného stavu, když jej uživatel zúží. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) vyjadřuje preferenci zobrazovat jeden panel v celém okně.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) řídí oddělovač mezi postranním panelem a snímkem. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) řídí oddělovač nad panelem poznámek. Oba přijímají hodnotu typu [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) `MINIMIZED`, `MAXIMIZED` nebo `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Konceptuální editor odděluje postranní panel, oblast snímku a spodní oblast s označenými svislými a vodorovnými rozdělovači.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*V normálním zobrazení řídí svislý oddělovač šířku postranního panelu. Vodorovný oddělovač řídí prostor nad panelem poznámek.*
<!-- visual-explanation:presentation-view-properties:end -->

## **O obnově NormalViewProperties**

Když je oddělovač obnoven, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) poskytuje uloženou velikost postranního panelu a [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) poskytuje uloženou velikost horní oblasti snímku. Oba vystavují [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Jeho vlastnost [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) přijímá procento od 0 do 100 a [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) řídí, zda editor upravuje velikost při změně velikosti okna.

Tento příklad aktualizuje existující prezentaci. Obnoví vodorovný oddělovač, nastaví [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) na 80 % s povoleným automatickým přizpůsobením a maximalizuje svislý oddělovač. Také povolí [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) pro zobrazení osnovy.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit výchozí hodnotu přiblížení**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) a [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) ukládají nezávislé nastavení přiblížení pro editor. Tato nastavení neovlivňují rozměry snímků, přehrávání prezentace ani rozlišení exportovaných obrázků.

Tento příklad otevře existující prezentaci a povolí [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) tak, aby se snímek přizpůsobil oknu editoru. Pro stránku poznámek zakáže automatické škálování a nastaví [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) na pevné přiblížení 80 %.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit rozestup mřížky**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) nastavuje vzdálenost mezi čarami editační mřížky v celé prezentaci. Přijímá kladnou hodnotu v bodech, přičemž 72 bodů představuje jeden palec. Tento příklad vypíše aktuální rozestup v existující prezentaci a uloží mřížku čtvrtinového palce nastavením intervalu na 18 bodů.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Mřížka se opakuje v pevně daném intervalu. [Drawing guides](/slides/cs/python-net/drawing-guides/) označují jednotlivé vodorovné nebo svislé pozice. Obě jsou pomocí při úpravách a zobrazují se jen v editorech, které je podporují. Při přehrávání prezentací a exportu do PDF, obrázků nebo SVG jsou vynechány.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) ukládá preferenci, kterou kompatibilní editory používají při otevírání prezentace. Pro existující prezentaci s komentáři tento příklad vytiskne aktuální nastavení a uloží kopii s komentáři skrytými. Také nastaví [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) na [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/), aby se kopie otevřela ve zobrazení snímku.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Skrytí komentářů zachovává jejich text, autory, pozice, odpovědi a stavy. Pro úpravu samotných komentářů viz [Presentation Comments](/slides/cs/python-net/presentation-comments/). Nastavení exportu řídí, zda se komentáře zobrazí v PDF, HTML, obrázcích, poznámkách nebo letácích.

## **Často kladené otázky**

**Proč je mřížka při opětovném otevření prezentace skrytá?**

Prezentace ukládá interval mřížky. Pro zobrazení mřížky ji v editoru povolte.

**Mění vymazání kreslicích vodítek rozestup mřížky?**

Ne. Přidání, přesunutí nebo vymazání vodítka nemění interval mřížky.

**Mohou různé sekce prezentace mít odlišná nastavení zobrazení?**

Ne. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) se vztahuje na celou prezentaci.

**Mohu uložit různá nastavení zobrazení pro různé uživatele?**

Soubor ukládá jeden soubor nastavení zobrazení pro všechny. Editor může také použít uživatelské místní preference.

**Mohu uložit nastavení zobrazení v šabloně?**

Ano. Prezentace vytvořené ze šablony zdědí její uložená nastavení zobrazení.