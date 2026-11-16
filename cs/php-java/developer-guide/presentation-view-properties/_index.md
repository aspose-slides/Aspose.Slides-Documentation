---
title: Načtení a aktualizace vlastností zobrazení prezentace v PHP
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/php-java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit vertikální rozdělovač
- jediné zobrazení
- stav panelu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Použijte Aspose.Slides pro PHP přes Java k nastavení rozvržení normálního zobrazení, přiblížení snímků a poznámek, rozestupu mřížky a viditelnosti komentářů v prezentacích PowerPoint."
---
## **Úvod**

V normálním zobrazení PowerPointu se snímek zobrazuje mezi postranním panelem s náhledy nebo osnovou a pod panelem s poznámkami. Aspose.Slides pro PHP přes Java zpřístupňuje uložená nastavení úprav prezentace prostřednictvím [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Tyto zahrnují rozvržení panelů, úrovně přiblížení, rozestupy mřížky a viditelnost komentářů.

## **O NormalViewProperties**

Použijte [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) k přístupu ke třídě [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) ovládá, zda se vedle titulů snímků v osnově zobrazují ikony. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) umožňuje postrannímu panelu přichytit se do zmenšeného stavu, když jej uživatel zmenší. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) označuje preferenci zobrazit jeden panel v celém okně.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) řídí oddělovač mezi postranním panelem a snímkem. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) řídí oddělovač nad panelem s poznámkami. Obě přijímají hodnotu [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` nebo `Restored`.

## **O obnovení NormalViewProperties**

Když je oddělovač obnoven, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) poskytuje uloženou velikost postranního panelu a [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) poskytuje uloženou velikost horní části snímku. Obě vystavují [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Jeho metoda [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) přijímá procento od 0 do 100 a [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) určuje, zda editor upravuje velikost při změně velikosti okna.

Tento příklad aktualizuje existující prezentaci. Obnoví horizontální oddělovač, nastaví velikost vrácenou metodou [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) na 80 % s povoleným automatickým přizpůsobením a maximalizuje vertikální oddělovač. Také zavolá [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/), aby zobrazil ikony ve výhledu osnovy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení výchozí hodnoty přiblížení**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) a [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) ukládají nezávislá nastavení přiblížení pro editor. Tato nastavení neovlivňují rozměry snímků, přehrávání prezentace ani rozlišení exportu obrázků.

Tento příklad otevře existující prezentaci a zavolá [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/), aby přizpůsobil snímek oknu editoru. Pro stránku poznámek zakáže automatické škálování a zavolá [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/), aby nastavil pevné přiblížení 80 %.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení rozestupu mřížky**

Metoda `setGridSpacing` třídy [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) nastavuje vzdálenost mezi čarami úpravové mřížky v celé prezentaci. Přijímá kladnou hodnotu v bodech, přičemž 72 bodů představuje jeden palec. Tento příklad vytiskne aktuální rozestup v existující prezentaci a uloží mřížku o čtvrt palce nastavením intervalu na 18 bodů.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mřížka se opakuje v pevném intervalu. [Drawing guides](/slides/cs/php-java/drawing-guides/) označují jednotlivé horizontální nebo vertikální pozice. Oba jsou pomůckami při úpravách a zobrazují se jen v editorech, které je podporují. Prezentace a exporty do PDF, obrázků nebo SVG je vynechají.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) ukládá preferenci, kterou kompatibilní editory použijí při otevírání prezentace. Pro existující prezentaci s komentáři tento příklad vytiskne aktuální nastavení a uloží kopii s komentáři skrytými. Také zavolá [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) s [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView), aby se kopie otevřela ve zobrazení snímku.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Skrytí komentářů zachovává jejich text, autory, pozice, odpovědi a stavy. Pro změnu samotných komentářů viz [Presentation Comments](/slides/cs/php-java/presentation-comments/). Nastavení exportu řídí, zda se komentáře zobrazí v PDF, HTML, obrázcích, poznámkách nebo letácích.

## **Často kladené otázky**

**Proč je mřížka skryta, když znovu otevřu prezentaci?**

Prezentace ukládá interval mřížky. Chcete‑li mřížku vidět, povolte její viditelnost v editoru.

**Změní vymazání výkresových vodicích čar rozestup mřížky?**

Ne. Přidání, přesunutí nebo vymazání vodítka nemění interval mřížky.

**Mohou různé sekce prezentace mít různá zobrazení nastavení?**

Ne. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) se vztahuje na celou prezentaci.

**Mohu uložit různá nastavení zobrazení pro různé uživatele?**

Soubor ukládá jedno sadu vlastností zobrazení pro všechny. Editor může také použít místní preference uživatele.

**Mohu uložit nastavení zobrazení v šabloně?**

Ano. Prezentace vytvořené ze šablony zdědí její uložená nastavení zobrazení.