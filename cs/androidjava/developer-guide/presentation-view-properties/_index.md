---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace na Androidu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/androidjava/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit vertikální dělič
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte Aspose.Slides pro Android prostřednictvím Javy k nastavení rozvržení normálního zobrazení, přiblížení snímku a poznámek, rozestupu mřížky a viditelnosti komentářů v prezentacích PowerPoint."
---
## **Úvod**

V normálním zobrazení PowerPointu se snímek zobrazuje mezi bočním panelem pro náhledy nebo osnovu a pod ním umístěným panelem poznámek. Aspose.Slides pro Android prostřednictvím Javy zpřístupňuje uložená nastavení úprav prezentace prostřednictvím [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Tato zahrnují rozložení panelu, úrovně přiblížení, rozestup mřížky a viditelnost komentářů.

## **O INormalViewProperties**

Použijte [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) k získání rozhraní [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) řídí, zda se vedle názvů snímků v osnově zobrazují ikony. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) umožňuje, aby se boční panel přichytil k minimalizovanému stavu, když jej uživatel zmenší. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) udává přednost zobrazování jediného panelu v celém okně.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) řídí oddělovač mezi bočním panelem a snímkem. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) řídí oddělovač nad panelem poznámek. Oba přijímají hodnotu typu [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` nebo `Restored`.

## **O obnově INormalViewProperties**

Když je oddělovač obnoven, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) poskytuje uloženou velikost bočního panelu a [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) poskytuje uloženou velikost horní oblasti snímku. Oba vystavují rozhraní [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Jeho metoda [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) přijímá procento od 0 do 100 a [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) řídí, zda editor upravuje velikost při změně velikosti okna.

Tento příklad aktualizuje existující prezentaci. Obnoví horizontální oddělovač, nastaví velikost vrácenou metodou [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) na 80% s povoleným automatickým přizpůsobením a maximalizuje vertikální oddělovač. Také volá [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) , aby zobrazil ikony v zobrazení osnovy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit výchozí úroveň přiblížení**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) a [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) ukládají nezávislá nastavení přiblížení pro editor. Tato nastavení neovlivňují rozměry snímků, přehrávání prezentace nebo rozlišení exportu obrázků.

Tento příklad otevře existující prezentaci a volá [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-), aby přizpůsobil snímek editačnímu oknu. Pro stránku poznámek zakáže automatické škálování a volá [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-), aby nastavila pevné přiblížení 80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit rozestup mřížky**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) nastavuje vzdálenost mezi editovacími čarami mřížky v celé prezentaci. Přijímá kladnou hodnotu v bodech, přičemž 1 palec = 72 bodů. Tento příklad vypíše aktuální rozestup v existující prezentaci a uloží čtvrťpalcovou mřížku nastavením intervalu na 18 bodů.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mřížka se opakuje v pevně stanoveném intervalu. [Kreslicí vodítka](/slides/cs/androidjava/drawing-guides/) označují jednotlivé vodorovné nebo svislé pozice. Obě jsou pomůckami pro úpravy a zobrazují se pouze v editorech, které je podporují. Prezentace a exporty do PDF, obrázků nebo SVG je neobsahují.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) ukládá preferenci, kterou kompatibilní editory používají při otevírání prezentace. Pro existující prezentaci s komentáři tento příklad vypíše aktuální nastavení a uloží kopii se skrytými komentáři. Také volá [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) s [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView), aby se kopie otevřela v zobrazení snímku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skrývání komentářů zachovává jejich text, autory, pozice, odpovědi a stavy. Pro změnu samotných komentářů viz [Komentáře prezentace](/slides/cs/androidjava/presentation-comments/). Nastavení exportu řídí, zda se komentáře zobrazí v PDF, HTML, obrázcích, poznámkách nebo letácích.

## **Často kladené otázky**

**Proč je mřížka skryta, když prezentaci znovu otevřu?**

Prezentace ukládá interval mřížky. Pro zobrazení mřížky ji v editoru povolte.

**Mění vymazání kreslicích vodítek rozestup mřížky?**

Ne. Přidání, přesunutí nebo smazání vodítka nemění interval mřížky.

**Mohou různé sekce prezentace mít různá nastavení zobrazení?**

Ne. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) se vztahuje na celou prezentaci.

**Mohu uložit různá nastavení zobrazení pro různé uživatele?**

Soubor ukládá jeden soubor nastavení zobrazení pro všechny. Editor může také použít místní preference uživatele.

**Mohu uložit nastavení zobrazení v šabloně?**

Ano. Prezentace vytvořené ze šablony zdědí její uložená nastavení zobrazení.