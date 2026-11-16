---
title: Získání a aktualizace vlastností zobrazení prezentace v Pythonu přes Java
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/python-java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý rozdělovač
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte Aspose.Slides pro Python přes Java k nastavení rozvržení normálního zobrazení, přiblížení snímků a poznámek, rozestupu mřížky a viditelnosti komentářů v prezentacích PowerPoint."
---
## **Úvod**

V normálním zobrazení PowerPointu se snímek zobrazuje mezi bočním panelem s miniaturami nebo osnovou a panelem poznámek pod ním. Aspose.Slides pro Python přes Java poskytuje uložené preference úprav prezentace prostřednictvím [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Patří mezi ně rozvržení panelů, úrovně přiblížení, rozestup mřížky a viditelnost komentářů.

## **O NormalViewProperties**

Použijte [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) pro přístup ke třídě [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) určuje, zda se vedle názvů snímků v osnově zobrazují ikony. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) umožňuje, aby se boční panel při zúžení uživatelem přichytila do minimalizovaného stavu. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) vyjadřuje preferenci zobrazit v plném okně jeden panel.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) řídí oddělovač mezi bočním panelem a snímkem. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) řídí oddělovač nad panelem poznámek. Obě přijímají hodnotu typu [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` nebo `Restored`.

## **O obnovení NormalViewProperties**

Když je oddělovač obnoven, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) poskytuje uloženou velikost bočního panelu a [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) poskytuje uloženou velikost horní části snímku. Oba vrací instanci třídy [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Její metoda [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) přijímá procento v rozmezí 0 až 100 a [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) určuje, zda editor upravuje velikost při změně velikosti okna.

Tento příklad aktualizuje existující prezentaci. Obnoví vodorovný oddělovač, nastaví velikost vrácenou metodou [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) na 80% s povoleným automatickým upravením a maximalizuje svislý oddělovač. Také volá [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) pro zobrazení ikon v zobrazení osnovy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavte výchozí hodnotu přiblížení**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) a [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) ukládají nezávislé nastavení přiblížení pro editor. Tato nastavení neovlivňují rozměry snímků, přehrávání prezentace ani rozlišení exportovaných obrázků.

Tento příklad otevře existující prezentaci a zavolá [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale), aby přizpůsobil snímek oknu editoru. Pro stránku poznámek zakáže automatické škálování a zavolá [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale), aby nastavil pevné přiblížení 80%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavte rozestup mřížky**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) nastavuje vzdálenost mezi čarami editační mřížky v celé prezentaci. Přijímá kladnou hodnotu v bodech, kde 72 bodů odpovídá jednomu palci. Tento příklad vypíše aktuální rozestup v existující prezentaci a uloží čtvrtinový palcový mřížkový rozestup nastavením intervalu na 18 bodů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mřížka se opakuje v pevném intervalu. [Kreslicí vodítka](/slides/cs/python-java/drawing-guides/) označují jednotlivé horizontální nebo vertikální pozice. Obě jsou pomůckami při úpravách a zobrazují se jen v editorech, které je podporují. Prezentace a exporty do PDF, obrázků nebo SVG je vypouštějí.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) ukládá preferenci, kterou kompatibilní editory použijí při otevírání prezentace. Pro existující prezentaci s komentáři tento příklad vypíše aktuální nastavení a uloží kopii se skrytými komentáři. Také volá [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) s [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView), aby se kopie otevřela v zobrazení snímků.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Skrytí komentářů zachová jejich text, autory, pozice, odpovědi a stavy. Pro úpravu samotných komentářů viz [Komentáře k prezentaci](/slides/cs/python-java/presentation-comments/). Nastavení exportu řídí, zda se komentáře zobrazí v PDF, HTML, obrázcích, poznámkách nebo podkladech.

## **Často kladené otázky**

**Proč je mřížka skryta, když znovu otevřu prezentaci?**  
Prezentace ukládá interval mřížky. Pro zobrazení mřížky ji povolte v editoru.

**Mění smazání vodicích čar rozestup mřížky?**  
Ne. Přidání, přesunutí nebo smazání vodící čáry nemění interval mřížky.

**Může mít různá oddíly prezentace odlišná nastavení zobrazení?**  
Ne. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) se vztahuje na celou prezentaci.

**Mohu uložit odlišná nastavení zobrazení pro různé uživatele?**  
Soubor ukládá jednu sadu vlastností zobrazení pro všechny. Editor může také použít lokální preference uživatele.

**Mohu uložit nastavení zobrazení v šabloně?**  
Ano. Prezentace vytvořené ze šablony převzetí její uložená nastavení zobrazení.