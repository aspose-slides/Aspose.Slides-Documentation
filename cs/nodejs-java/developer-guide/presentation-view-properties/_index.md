---
title: "Načíst a aktualizovat vlastnosti zobrazení prezentace v JavaScriptu"
linktitle: "Vlastnosti zobrazení"
type: docs
weight: 80
url: /cs/nodejs-java/presentation-view-properties/
keywords:
- "vlastnosti zobrazení"
- "normální zobrazení"
- "obsah osnovy"
- "ikony osnovy"
- "přichytit svislý rozdělovač"
- "jedno zobrazení"
- "stav lišty"
- "velikost rozměru"
- "automatické přizpůsobení"
- "výchozí přiblížení"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Pomocí Aspose.Slides pro Node.js přes Java nakonfigurujete rozložení normálního zobrazení, přiblížení snímků a poznámek, rozestup mřížky a viditelnost komentářů v prezentacích PowerPoint."
---
## **Úvod**

V normálním pohledu PowerPointu se snímek zobrazuje mezi postranním panelem s náhledy nebo osnovou a panelem s poznámkami pod ním. Aspose.Slides pro Node.js přes Java zpřístupňuje uložené preference úprav prezentace prostřednictvím [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Ty zahrnují rozvržení panelů, úrovně přiblížení, rozestupy mřížky a viditelnost komentářů.

## **O NormalViewProperties**

Použijte [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) k získání přístupu ke třídě [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) určuje, zda se ikony zobrazují vedle názvů snímků v osnově. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) umožňuje postrannímu panelu přichytit se do svého minimalizovaného stavu, když jej uživatel zmenší. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) naznačuje preferenci zobrazit jeden panel v celém okně.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) řídí oddělovač mezi postranním panelem a snímkem. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) řídí oddělovač nad panelem s poznámkami. Oba přijímají hodnotu [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` nebo `Restored`.

## **O obnovení NormalViewProperties**

Když je oddělovač obnoven, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) poskytuje uloženou šířku postranního panelu a [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) poskytuje uloženou velikost horní oblasti snímku. Oba vystavují [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Jeho metoda [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) přijímá procento od 0 do 100 a [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) řídí, zda editor upravuje velikost při změně velikosti okna.

Tento příklad aktualizuje existující prezentaci. Obnoví vodorovný oddělovač, nastaví velikost vrácenou metodou [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) na 80 % s povoleným automatickým přizpůsobením a maximalizuje svislý oddělovač. Také zavolá [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons), aby se v zobrazení osnovy zobrazily ikony.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit výchozí hodnotu přiblížení**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) a [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) ukládají nezávislé nastavení přiblížení pro editor. Tato nastavení neovlivňují rozměry snímku, přehrávání prezentace ani rozlišení exportovaných obrázků.

Tento příklad otevře existující prezentaci a zavolá [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale), aby přizpůsobil snímek velikosti editačního okna. Pro stránku poznámek vypne automatické škálování a zavolá [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) pro nastavení pevného přiblížení 80 %.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit rozestup mřížky**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) nastavuje vzdálenost mezi čarami editační mřížky v celé prezentaci. Přijímá kladnou hodnotu v bodech, přičemž 72 bodů představuje jeden palec. Tento příklad vytiskne aktuální rozestup v existující prezentaci a uloží mřížku čtvrtinového palce nastavením intervalu na 18 bodů.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mřížka se opakuje v pevném intervalu. [Kreslicí vodítka](/slides/cs/nodejs-java/drawing-guides/) označují jednotlivé vodorovné nebo svislé pozice. Obě jsou pomůckami při úpravách a zobrazují se jen v editorech, které je podporují. Přehrávání prezentace a export do PDF, obrázků nebo SVG je vynechává.

## **Zobrazit nebo skrýt komentáře při otevření prezentace**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) ukládá preferenci, kterou kompatibilní editory používají při otevírání prezentace. Pro existující prezentaci s komentáři tento příklad vytiskne aktuální nastavení a uloží kopii s komentáři skrytými. Také zavolá [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) s [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView), aby se kopie otevřela v zobrazení snímku.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skrývání komentářů zachovává jejich text, autory, pozice, odpovědi a stavy. Pro změnu samotných komentářů viz [Komentáře k prezentaci](/slides/cs/nodejs-java/presentation-comments/). Nastavení exportu řídí, zda se komentáře objeví v PDF, HTML, obrázcích, poznámkách nebo podklady.

## **Často kladené otázky**

**Proč je mřížka skryta, když znovu otevřu prezentaci?**  
Prezentace ukládá interval mřížky. Pro zobrazení mřížky ji v editoru povolte.

**Mění vymazání kreslicích vodítek rozestup mřížky?**  
Ne. Přidání, přesunutí nebo vymazání vodítka nemění interval mřížky.

**Mohou různé sekce prezentace mít různé nastavení zobrazení?**  
Ne. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) platí pro celou prezentaci.

**Mohu uložit různá nastavení zobrazení pro různé uživatele?**  
Soubor ukládá jeden soubor nastavení zobrazení pro všechny. Editor může také použít lokální preference uživatele.

**Mohu uložit nastavení zobrazení v šabloně?**  
Ano. Prezentace vytvořené ze šablony zdědí její uložená nastavení zobrazení.