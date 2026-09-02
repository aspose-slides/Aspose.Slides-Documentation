---
title: Spravovat master snímky prezentace v JavaScriptu
linktitle: Master snímku
type: docs
weight: 70
url: /cs/nodejs-java/slide-master/
keywords:
- master snímku
- master snímek
- PPT master snímek
- více master snímků
- porovnat master snímky
- pozadí
- zástupný objekt
- klonovat master snímek
- kopírovat master snímek
- duplikovat master snímek
- nepoužívaný master snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravovat master snímky v Aspose.Slides pro Node.js via Java: přístup, úpravy, klonování, porovnání a odstraňování master snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**slide master** definuje sdílená nastavení návrhu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž by se opakovalo stejné formátování na každém snímku.

Aspose.Slides for Node.js via Java podporuje stejný model. Prezentace může obsahovat jeden nebo více master snímků a každý master snímek může obsahovat několik layout snímků. Běžné snímky se obvykle nepřipojují přímo k master snímku. Místo toho běžný snímek používá layout snímek, který patří k master snímku.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.
1. **Layout slide** – definuje konkrétní uspořádání zástupných objektů a formátování na úrovni layoutu.
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden layout snímek.

![Hierarchie master snímků, layout snímků a běžných snímků](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/). Všechny master snímky v prezentaci jsou dostupné prostřednictvím kolekce `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud master snímek i layout snímek oba definují pozadí, snímky založené na tomto layoutu použijí pozadí layoutu. Další informace o layout snímcích najdete v [Použít nebo změnit rozložení snímků](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Přístup k master snímkům**

V PowerPointu můžete otevřít zobrazení Slide Master z **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `getMasters()` pro přístup k master snímkům:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Můžete také získat master snímek použité běžným snímkem prostřednictvím jeho layoutu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Co obsahuje slide master**

Master snímek je objekt podobný snímku. Dědí běžné chování snímku z [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/), takže vystavuje mnoho stejných vlastností snímku používaných běžnými a layout snímky. Členy specifické pro master jsou uvedeny na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/).

Běžně používané členy master snímku zahrnují:

| Člen | Účel |
| --- | --- |
| `getBackground()` | Nastavuje pozadí snímku na úrovni masteru. |
| `getShapes()` | Ukládá tvary umístěné na master, jako jsou loga, rámy obrázků a sdílený text. |
| `getLayoutSlides()` | Ukládá layout snímky, které patří k masteru. |
| `getThemeManager()` | Poskytuje přístup k API motivu masteru. |
| `getHeaderFooterManager()` | Řídí záhlaví, zápatí, data a čísla snímků pro master a jeho podřízené layouty. |
| `getDependingSlides()` | Vrací běžné snímky, které závisí na masteru přes jejich layouty. |

## **Přidání obrázku do slide masteru**

Když přidáte obrázek do master snímku, objeví se na snímcích, které používají layouty z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidává logo do prvního master snímku:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Další informace o rámech obrázků najdete v [Rámec obrázku](/nodejs-java/picture-frame/).

## **Práce se zástupnými objekty**

Zástupné objekty jsou normálně definovány na layout snímcích. Master snímek poskytuje sdílený styl a motiv, které layouty dědí, zatímco každý layout rozhoduje, které zástupné objekty jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v zobrazení Slide Master.

![Příkaz Vložit zástupný objekt v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných objektů s Aspose.Slides pracujte s layout snímkem, který patří k masteru:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také formátovat tvary zástupných objektů, které již na master snímku existují. Následující příklad najde zástupný objekt nadpisu a použije lineární gradientní výplň:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formátovaný zástupný objekt nadpisu zděděný běžnými snímky](slide-master_8.png)

Další možnosti formátování zástupných objektů a textu najdete v [Nastavit výzvu v zástupném objektu](/nodejs-java/manage-placeholder/) a [Formátování textu](/nodejs-java/text-formatting/).

## **Změna pozadí slide masteru**

Master pozadí je děděno layouty a snímky, které jej nepřepíší. Následující příklad nastaví jednotnou barvu pozadí pro první master snímek:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro související témata viz [Pozadí prezentace](/nodejs-java/presentation-background/) a [Motiv prezentace](/nodejs-java/presentation-theme/).

## **Klonování slide masteru do jiné prezentace**

Použijte `MasterSlideCollection.addClone` pro zkopírování master snímku do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Pokud potřebujete klonovat běžné snímky spolu s jejich masterem, viz [Klonovat snímky](/nodejs-java/clone-slides/).

## **Přidání více slide masterů**

Prezentace může obsahovat více master snímků. To je užitečné, když různé sekce vyžadují odlišnou značku, strukturu stránky nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu master snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí master, přiřadí klonu jiné pozadí, vytvoří layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Porovnání slide masterů**

Master snímky lze porovnat metodou `equals` zděděnou z [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, například aktuální datum.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Další informace najdete v [Porovnat snímky prezentace](/slides/cs/nodejs-java/compare-slides/).

## **Nastavení zobrazení Slide Master jako výchozího zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/) k řízení zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Další nastavení zobrazení viz [Uložit prezentaci](/slides/cs/nodejs-java/save-presentation/).

## **Odstranění nepoužívaných master snímků**

Prezentace někdy obsahují master snímky, které již nejsou použity žádnými běžnými snímky. Odstranění nepoužívaných masterů může zmenšit velikost souboru a zjednodušit údržbu šablon.

Použijte `removeUnused` pro odstranění nepoužívaných masterů z kolekce `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také použít low-code metodu `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

### Jaký je rozdíl mezi slide masterem a layout snímkem?

Slide master definuje sdílená nastavení návrhu, jako je motiv, pozadí, společné tvary a styly textu. Layout snímek patří k masteru a definuje konkrétní uspořádání zástupných objektů. Běžný snímek používá layout snímek, takže dědí jak z layoutu, tak z masteru.

### Může jedna prezentace obsahovat několik slide masterů?

Ano. Prezentace může obsahovat několik slide masterů. Použijte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo značku.

### Mám přidávat zástupné objekty do master snímku či do layout snímku?

Ve většině případů přidávejte zástupné objekty do layout snímků. Sdílené vizuální prvky a formátování umístěte na master snímek a obsahové zástupné objekty na layouty, které budou použity běžnými snímky.

### Můžu smazat master snímek, který je stále používán?

Ne. Master snímek, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky do layoutů pod jiný master nebo použijte metodu úklidu nepoužívaných masterů, která odstraní jen ty, které nejsou v použití.