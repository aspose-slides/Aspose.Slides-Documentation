---
title: Správa hlavních vzorů snímků v JavaScriptu
linktitle: Hlavní vzor snímku
type: docs
weight: 70
url: /cs/nodejs-java/slide-master/
keywords:
- hlavní vzor snímku
- hlavní snímek
- PPT hlavní snímek
- více hlavních snímků
- porovnání hlavních snímků
- pozadí
- zástupný objekt
- klonovat hlavní snímek
- kopírovat hlavní snímek
- duplikovat hlavní snímek
- nepoužívaný hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte hlavní vzory snímků v Aspose.Slides pro Node.js via Java: přístup, úprava, klonování, porovnání a odstraňování hlavních snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**master snímku** definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava hlavního vzoru obvyklým způsobem, jak udržet prezentaci konzistentní, aniž by se opakovalo stejné formátování na každém snímku.

Aspose.Slides for Node.js via Java podporuje stejný model. Prezentace může obsahovat jeden nebo více hlavních vzorů a každý hlavní vzor může obsahovat několik rozložení snímků. Běžné snímky obvykle neodkazují přímo na hlavní vzor. Místo toho běžný snímek používá rozložení snímku a toto rozložení patří k hlavnímu vzoru.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.  
1. **Layout slide** – definuje konkrétní uspořádání zástupných objektů a formátování na úrovni rozložení.  
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jedno rozložení snímku.

![Hierarchie hlavních vzorů, rozložení a běžných snímků](slide-master_2.jpg)

V Aspose.Slides je hlavní vzor reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) . Všechny hlavní vzory v prezentaci jsou dostupné přes kolekci `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}

Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud hlavní vzor i rozložení definují pozadí, snímky založené na tomto rozložení použijí pozadí rozložení. Další informace o rozloženích najdete v [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Přístup k hlavním vzorům**

V PowerPointu můžete otevřít zobrazení **Hlavní vzor** přes **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `getMasters()` k přístupu k hlavním vzorům:

```javascript
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

Můžete také získat hlavní vzor použité běžným snímkem prostřednictvím jeho rozložení:

```javascript
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

## **Co obsahuje hlavní vzor**

Hlavní vzor je objekt podobný snímku. Dědí běžné chování snímku z [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/), takže poskytuje mnoho stejných vlastností použivaných běžnými a rozloženími snímků. Členové specifické pro hlavní vzor jsou uvedeni na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) .

Běžně používaní členové hlavního vzoru zahrnují:

| Člen | Účel |
| --- | --- |
| `getBackground()` | Nastavuje pozadí snímku na úrovni hlavního vzoru. |
| `getShapes()` | Ukládá tvary umístěné na hlavním vzoru, jako jsou loga, rámečky obrázků a sdílený text. |
| `getLayoutSlides()` | Ukládá rozložení snímků, která patří k hlavnímu vzoru. |
| `getThemeManager()` | Poskytuje přístup k API motivu hlavního vzoru. |
| `getHeaderFooterManager()` | Řídí záhlaví, zápatí, data a čísla snímků pro hlavní vzor a jeho podřízená rozložení. |
| `getDependingSlides()` | Vrací běžné snímky, které závisí na hlavním vzoru prostřednictvím jejich rozložení. |

## **Přidání obrázku do hlavního vzoru**

Když přidáte obrázek do hlavního vzoru, objeví se na snímcích, které používají rozložení z tohoto vzoru. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidává logo do prvního hlavního vzoru:

```javascript
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

Další informace o rámečcích obrázků najdete v [Picture Frame](/nodejs-java/picture-frame/).

## **Práce se zástupnými objekty**

Zástupné objekty jsou obvykle definovány na rozložení snímků. Hlavní vzor poskytuje sdílený styl a motiv, který tyto rozložení dědí, zatímco každé rozložení rozhoduje, které zástupné objekty jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v režimu **Slide Master**.

![Příkaz Insert Placeholder v režimu Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných objektů s Aspose.Slides pracujte s rozložením, které patří k hlavnímu vzoru:

```javascript
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

Můžete také formátovat tvary zástupných objektů, které již na hlavním vzoru existují. Následující příklad najde zástupný objekt nadpisu a použije lineární gradientní výplň:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formátovaný nadpisový zástupný objekt zděděný běžnými snímky](slide-master_8.png)

Další možnosti formátování zástupných objektů a textu najdete v [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) a [Text Formatting](/nodejs-java/text-formatting/).

## **Změna pozadí hlavního vzoru**

Pozadí hlavního vzoru je zděděno rozloženími a snímky, které jej nepřepíší. Následující příklad nastaví jednotnou barvu pozadí pro první hlavní vzor:

```javascript
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

Související témata jsou [Presentation Background](/nodejs-java/presentation-background/) a [Presentation Theme](/nodejs-java/presentation-theme/).

## **Klonování hlavního vzoru do jiné prezentace**

Použijte `MasterSlideCollection.addClone` pro zkopírování hlavního vzoru do jiné prezentace. Zkopírovaný hlavní vzor pak může být použit rozloženími a snímky v cílové prezentaci.

```javascript
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

Pokud potřebujete klonovat běžné snímky společně s jejich hlavním vzorem, viz [Clone Slides](/nodejs-java/clone-slides/).

## **Přidání více hlavních vzorů**

Prezentace může obsahovat více hlavních vzorů. To je užitečné, když různé sekce vyžadují odlišnou značku, strukturu stránky nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu hlavních vzorů](slide-master_9.jpg)

Následující příklad klonuje výchozí hlavní vzor, dá klonu jiné pozadí, vytvoří rozložení pod tímto klonovaným hlavním vzorem a přidá nový snímek založený na tomto rozložení:

```javascript
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

## **Porovnání hlavních vzorů**

Hlavní vzory lze porovnat pomocí metody `equals` zděděné z [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, jako je aktuální datum.

```javascript
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

Další informace najdete v [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **Nastavení zobrazení hlavního vzoru jako výchozího zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/) pro nastavení výchozího zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v režimu Slide Master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Další nastavení zobrazení najdete v [Save Presentation](/nodejs-java/save-presentation/).

## **Odstranění nepoužívaných hlavních vzorů**

Prezentace někdy obsahují hlavní vzory, které již nejsou použity žádnými běžnými snímky. Odstranění nepoužívaných hlavních vzorů může zmenšit velikost souboru a usnadnit údržbu šablony.

Použijte `removeUnused` k odstranění nepoužívaných hlavních vzorů ze sbírky `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také použít low‑code metodu `Compress.removeUnusedMasterSlides`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním vzorem a rozložením snímku?**

Hlavní vzor definuje sdílená nastavení designu, jako je motiv, pozadí, společné tvary a styly textu. Rozložení snímku patří k hlavnímu vzoru a definuje konkrétní uspořádání zástupných objektů. Běžný snímek používá rozložení snímku, takže dědí jak z rozložení, tak z hlavního vzoru.

**Může jedna prezentace obsahovat několik hlavních vzorů?**

Ano. Prezentace může obsahovat několik hlavních vzorů. Používejte více hlavních vzorů, když různé sekce vyžadují odlišné vizuální systémy nebo značkování.

**Mám přidávat zástupné objekty do hlavního vzoru nebo do rozložení?**

Ve většině případů přidávejte zástupné objekty do rozložení. Sdílené vizuální prvky a společné formátování umístěte na hlavní vzor a obsahové zástupné objekty umístěte na rozložení, která budou používána běžnými snímky.

**Mohu smazat hlavní vzor, který je stále používán?**

Ne. Hlavní vzor, ke kterému existují závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesunte tyto snímky do rozložení pod jiným hlavním vzorem nebo použijte metodu pro úklid nepoužívaných hlavních vzorů, která odstraní pouze ty, které nejsou v žádném snímku použity.