---
title: "Spravovat master slidy prezentace v JavaScriptu"
linktitle: "Master snímku"
type: docs
weight: 70
url: /cs/nodejs-java/slide-master/
keywords:
- "master snímku"
- "master snímek"
- "PPT master snímek"
- "více master snímků"
- "porovnání master snímků"
- "pozadí"
- "zástupný objekt"
- "klonovat master snímek"
- "kopírovat master snímek"
- "duplikovat master snímek"
- "nepoužitý master snímek"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Spravovat master slidy v Aspose.Slides pro Node.js přes Java: přístup, úprava, klonování, porovnávání a odstraňování master slidů v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Slide master definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat běžné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž by bylo třeba opakovat stejný formát na každém snímku.

Aspose.Slides pro Node.js via Java podporuje stejný model. Prezentace může obsahovat jeden nebo více master slidů a každý master slide může obsahovat několik layout slidů. Normální snímky obvykle neodkazují přímo na master slide. Místo toho normální snímek používá layout slide a tento layout slide patří do master slide.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.  
1. **Layout slide** – definuje konkrétní uspořádání zástupných objektů a formátování úrovně rozvržení.  
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden layout slide.

![Hierarchie master slidů, layout slidů a normálních slidů](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/). Všechny master slidy v prezentaci jsou dostupné prostřednictvím kolekce `Presentation.getMasters()`.

{{% alert color="info" title="Dědičnost" %}}
Když je stejná vlastnost definována na více úrovních, vítězí konkrétnější úroveň. Například pokud master slide i layout slide oba definují pozadí, snímky založené na tomto rozvržení použijí pozadí layoutu. Další informace o layout slidech najdete v [Použít nebo změnit rozvržení snímku](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Přístup k slide masterům**

V PowerPointu můžete otevřít zobrazení Slide Master z **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `getMasters()` pro přístup k master slidům:

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

Můžete také získat master slide použitý normálním snímkem přes jeho layout:

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

Master slide je objekt podobný snímku. Dědí běžné chování snímku z [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/), takže poskytuje mnoho stejných vlastností snímku používaných normálními a layout snímky. Členy specifické pro master jsou uvedeny na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/).

Často používané členy master slide zahrnují:

| Člen | Účel |
| --- | --- |
| `getBackground()` | Nastavuje pozadí snímku na úrovni masteru. |
| `getShapes()` | Ukládá tvary umístěné na masteru, jako jsou loga, rámy obrázků a sdílený text. |
| `getLayoutSlides()` | Ukládá layout slidy, které patří k masteru. |
| `getThemeManager()` | Poskytuje přístup k API master motivu. |
| `getHeaderFooterManager()` | Ovládá záhlaví, zápatí, data a čísla snímků pro master a jeho podřízené layouty. |
| `getDependingSlides()` | Vrací normální snímky, které závisí na masteru prostřednictvím jejich layoutů. |

## **Přidání obrázku do slide masteru**

Když přidáte obrázek do master slide, zobrazí se na snímcích, které používají layouty z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální elementy.

V následujícím příkladu se přidává logo do prvního master slide:

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

Další informace o rámech obrázků najdete v [Rám obrazu](/nodejs-java/picture-frame/).

## **Ovládání viditelnosti grafiky masteru**

Použijte [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) k skrytí zděděné grafiky masteru, jako jsou loga nebo dekorativní tvary, aniž byste je mazali z masteru. Předávejte `false` do [Slide.setShowMasterShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#setShowMasterShapes) na snímku, který má tyto grafiky vynechat, a ponechte `true` na snímcích, které je mají zobrazovat.

Následující samostatný příklad vytvoří modrý dekorativní pás na masteru a dvou snímcích, které používají stejný prázdný layout. Pás je viditelný na prvním snímku a skrytý na druhém. Není vyžadována žádná vstupní prezentace ani obrázek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Příklad používá layout **Blank** dodaný s novou prezentací a odstraňuje vlastní zástupné objekty počátečního snímku.

### **Vyberte rozsah nastavení**

Normální snímek používá svého mastera prostřednictvím [Slide.getLayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getLayoutSlide) a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Nastavení vlastnosti na individuálním snímku ovlivní pouze tento snímek. Předáním `false` do [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) se skryje grafika masteru pro snímky, které používají tento sdílený layout, i když jejich vlastní nastavení je `true`. Pro skrytí grafiky jen na jednom snímku změňte vlastnost snímku a ponechte sdílený layout beze změny.

Nastavení není podporováno jako řízení viditelnosti přímo na master slide. Na masteru [getShowMasterShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) vždy vrací `false` a předání `true` do [setShowMasterShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) vyvolá výjimku. Použijte jej místo toho na normální snímek nebo na layout.

### **Rozlište grafiku od pozadí**

| Operace | Efekt |
| --- | --- |
| Skrytí grafiky masteru | Ovládá viditelnost zděděných tvarů masteru bez jejich mazání nebo změny vlastních tvarů snímku. |
| Změna výplně pozadí snímku | Mění barvu, gradient nebo obrázek pozadí. Grafika masteru jsou samostatné tvary a mohou zůstat viditelné nad tímto pozadím. Viz [Presentation Background](/slides/cs/nodejs-java/presentation-background/). |
| Smazání tvaru z masteru | Odstraní sdílený výchozí tvar, takže už není dostupný žádnému snímku používajícímu tento master. |

## **Práce se zástupnými objekty**

Zástupné objekty jsou obvykle definovány na layout slidech. Master slide poskytuje sdílený styl a motiv, které tyto layouty dědí, zatímco každý layout rozhoduje, které zástupné objekty jsou dostupné a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty k dispozici v zobrazení Slide Master.

![Příkaz Vložit zástupný objekt v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Aby bylo možné přidat nové zástupné objekty pomocí Aspose.Slides, pracujte s layout slide, který patří k masteru:

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

Můžete také formátovat tvary zástupných objektů, které již existují na master slide. Následující příklad najde zástupný objekt titulku a aplikuje lineární gradientní výplň:

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

![Formátovaný zástupný objekt titulku zděděný normálními snímky](slide-master_8.png)

Pro více možností formátování zástupných objektů a textu, viz [Nastavit výzvu textu v zástupném objektu](/nodejs-java/manage-placeholder/) a [Formátování textu](/nodejs-java/text-formatting/).

## **Změna pozadí slide masteru**

Pozadí masteru je zděděno layouty a snímky, které jej nepřepíšou. Následující příklad nastaví jednotnou barvu pozadí pro první master slide:

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

Použijte `MasterSlideCollection.addClone` k kopírování master slide do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

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

Pokud potřebujete klonovat normální snímky spolu s jejich masterem, viz [Klonování snímků](/nodejs-java/clone-slides/).

## **Přidání více slide masterů**

Prezentace může obsahovat více master slidů. To je užitečné, když různé sekce vyžadují odlišné značky, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu master slidů](slide-master_9.jpg)

Následující příklad klonuje výchozí master, dá klonu jiné pozadí, vytvoří layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

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

Master slidy lze porovnat pomocí metody `equals` zděděné z [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, jako je aktuální datum.

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

Další informace najdete v [Porovnání snímků prezentace](/slides/cs/nodejs-java/compare-slides/).

## **Nastavení zobrazení Slide Master jako výchozího zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/) pro kontrolu zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

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

Pro další nastavení zobrazení viz [Uložení prezentace](/slides/cs/nodejs-java/save-presentation/).

## **Odstranění nepoužívaných master slidů**

Prezentace někdy obsahují master slidy, které již nejsou použity žádnými normálními snímky. Odstranění nepoužívaných masterů může snížit velikost souboru a zjednodušit údržbu šablony.

Použijte `removeUnused` k odstranění nepoužívaných masterů z kolekce `getMasters()`:

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

## **FAQ**

**Jaký je rozdíl mezi slide master a layout slidem?**

Slide master definuje sdílená nastavení designu, jako je motiv, pozadí, společné tvary a styly textu. Layout slide patří k slide masteru a definuje konkrétní uspořádání zástupných objektů. Normální snímek používá layout slide, takže dědí jak z layoutu, tak z masteru.

**Může jedna prezentace obsahovat několik slide masterů?**

Ano. Prezentace může obsahovat několik slide masterů. Použijte více masterů, když různé sekce vyžadují odlišné vizuální systémy nebo značkování.

**Mám přidávat zástupné objekty do master slide nebo do layout slide?**

Ve většině případů přidávejte zástupné objekty do layout slidů. Sdílené vizuální prvky a formátování umístěte na master slide a obsahové zástupné objekty na layouty, které budou používat normální snímky.

**Mohu smazat master slide, který je stále používán?**

Ne. Master slide, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesunte tyto snímky na layouty pod jiný master, nebo použijte metodu pro úklid nepoužívaných masterů, která odstraňuje jen ty mastery, které nejsou používány.