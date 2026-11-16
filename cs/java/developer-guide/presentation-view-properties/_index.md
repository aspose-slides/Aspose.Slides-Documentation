---
title: Načtení a aktualizace vlastností zobrazení prezentace v Javě
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý oddělovač
- jedno zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Pomocí Aspose.Slides for Java nakonfigurujete rozvržení normálního zobrazení, přiblížení snímků a poznámek, rozestup mřížky a viditelnost komentářů v prezentacích PowerPoint."
---
## **Úvod**

V normálním zobrazení PowerPointu se snímek zobrazí mezi bočním panelem pro miniatury nebo osnovu a panelem poznámek pod ním. Aspose.Slides for Java zpřístupňuje uložená nastavení úprav prezentace prostřednictvím [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). Patří sem rozložení panelů, úrovně přiblížení, rozestup mřížky a viditelnost komentářů.

## **O INormalViewProperties**

Použijte [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) k přístupu k rozhraní [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) řídí, zda se vedle názvů snímků v osnově zobrazují ikony. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) umožňuje bočnímu panelu přichytit se do minimalizovaného stavu, když jej uživatel zúží. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) naznačuje preferenci zobrazovat jeden panel v celé obrazovce.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) řídí oddělovač mezi bočním panelem a snímkem. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) řídí oddělovač nad panelem poznámek. Oba přijímají hodnotu [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` nebo `Restored`.

## **O obnovení INormalViewProperties**

Když je oddělovač obnoven, [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) poskytuje uloženou velikost bočního panelu a [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) poskytuje uloženou velikost horní oblasti snímku. Oba vystavují [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/). Jeho metoda [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) přijímá procento od 0 do 100 a [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) řídí, zda editor upravuje velikost při změně velikosti okna.

Tento příklad aktualizuje existující prezentaci. Obnoví horizontální oddělovač, nastaví velikost vrácenou pomocí [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) na 80% s povoleným automatickým přizpůsobením a maximalizuje vertikální oddělovač. Také zavolá [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-), aby se v zobrazení osnovy zobrazovaly ikony.

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

## **Nastavení výchozí hodnoty přiblížení**

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) a [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) ukládají nezávislé nastavení přiblížení pro editor. Tato nastavení nemají vliv na rozměry snímku, přehrávání prezentace ani rozlišení exportovaných obrázků.

Tento příklad otevře existující prezentaci a zavolá [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-), aby přizpůsobil snímek oknu editoru. Pro stránku poznámek zakáže automatické škálování a zavolá [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-), aby nastavil pevné přiblížení 80%.

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

## **Nastavení rozestupu mřížky**

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) nastavuje vzdálenost mezi editovacími mřížkovými čarami v celé prezentaci. Přijímá kladnou hodnotu v bodech, přičemž 72 bodů odpovídá jednomu palci. Tento příklad vypíše aktuální rozestup v existující prezentaci a uloží mřížku o čtvrtinovém palci nastavením intervalu na 18 bodů.

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

Mřížka se opakuje v pevně definovaném intervalu. [Drawing guides](/slides/cs/java/drawing-guides/) označují jednotlivé vodorovné nebo svislé pozice. Obě slouží jako pomůcky při úpravách a objevují se jen v editorech, které je zobrazují. Prezentace a exporty do PDF, obrázků nebo SVG je neobsahují.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) ukládá předvolbu, kterou kompatibilní editory používají při otevírání prezentace. Pro existující prezentaci s komentáři tento příklad vypíše aktuální nastavení a uloží kopii se skrytými komentáři. Také volá [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) s [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView), aby se kopie otevřela v zobrazení snímku.

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

Skrytí komentářů zachovává jejich text, autory, pozice, odpovědi a stavy. Pro změnu samotných komentářů viz [Presentation Comments](/slides/cs/java/presentation-comments/). Nastavení exportu řídí, zda se komentáře objeví v PDF, HTML, obrázcích, poznámkách nebo podklady.

## **Často kladené otázky**

**Proč je mřížka skryta, když prezentaci znovu otevřu?**

Prezentace ukládá interval mřížky. Pro zobrazení mřížky ji v editoru povolte.

**Změní vymazání vodicích linek rozestup mřížky?**

Ne. Přidání, přesunutí nebo vymazání vodící linky nemění interval mřížky.

**Mohou různé sekce prezentace mít odlišná nastavení zobrazení?**

Ne. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) se vztahuje na celou prezentaci.

**Mohu uložit různá nastavení zobrazení pro různé uživatele?**

Soubor ukládá jeden soubor vlastností zobrazení pro všechny. Editor může také použít lokální předvolby uživatele.

**Mohu uložit nastavení zobrazení v šabloně?**

Ano. Prezentace vytvořené ze šablony zdědí její uložená nastavení zobrazení.