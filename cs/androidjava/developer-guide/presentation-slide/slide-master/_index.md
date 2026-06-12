---
title: Správa hlavních snímků prezentace na Androidu
linktitle: Hlavní snímek
type: docs
weight: 70
url: /cs/androidjava/slide-master/
keywords:
- hlavní snímek
- hlavní snímek
- PPT hlavní snímek
- více hlavních snímků
- porovnat hlavní snímky
- pozadí
- zástupný objekt
- klonovat hlavní snímek
- kopírovat hlavní snímek
- duplikovat hlavní snímek
- nepoužívaný hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte hlavní snímky v Aspose.Slides pro Android přes Java: přístup, úpravy, klonování, porovnání a odstraňování hlavních snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**slide master** definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides for Android via Java podporuje stejný model. Prezentace může obsahovat jeden nebo více hlavních snímků a každý hlavní snímek může obsahovat několik rozvrhových snímků. Normální snímky obvykle neodkazují přímo na hlavní snímek. Místo toho normální snímek používá rozvrhový snímek, který patří k hlavnímu snímku.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.  
2. **Layout slide** – definuje konkrétní uspořádání zástupných objektů a formátování úrovně rozvržení.  
3. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden rozvrhový snímek.

![Hierarchie hlavních snímků, rozvrhových snímků a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován rozhraním [IMasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/). Všechny hlavní snímky v prezentaci jsou k dispozici prostřednictvím kolekce [Presentation.getMasters](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getMasters--) , která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/). Pro kompletní rozhraní Android via Java API viz [com.aspose.slides API reference](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud hlavní snímek i rozvrhový snímek definují pozadí, snímky založené na tomto rozvržení použijí pozadí rozvrhu. Pro více informací o rozvrhových snímcích viz [Apply or Change Slide Layouts](/slides/cs/androidjava/slide-layout/).
{{% /alert %}}

## **Přístup k hlavním snímkům**

V PowerPointu můžete otevřít zobrazení Slide Master přes **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `getMasters()` k přístupu k hlavním snímkům:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Můžete také získat hlavní snímek použité normálním snímkem prostřednictvím jeho rozvržení:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Co obsahuje Slide Master**

Master slide je objekt podobný snímku. Implementuje [IBaseSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/), takže vystavuje mnoho stejných vlastností snímků, které jsou používány normálními a rozvrhovými snímky.

Běžně používané členy master slide zahrnují:

| Člen | Účel |
| --- | --- |
| `getBackground()` | Nastavuje pozadí na úrovni hlavního snímku. |
| `getShapes()` | Ukládá tvary umístěné na hlavním snímku, jako jsou loga, rámečky obrázků a sdílený text. |
| `getLayoutSlides()` | Uchovává rozvrhové snímky, které patří k hlavnímu snímku. |
| `getThemeManager()` | Poskytuje přístup k API motivu hlavního snímku. |
| `getHeaderFooterManager()` | Řídí záhlaví, zápatí, data a čísla snímků pro hlavní snímek a jeho podřízené rozvrhy. |
| `getDependingSlides()` | Vrací normální snímky, které jsou závislé na hlavním snímku prostřednictvím svých rozvrhů. |

## **Přidání obrázku do Slide Masteru**

Když přidáte obrázek do hlavního snímku, objeví se na snímcích, které používají rozvrhy z tohoto hlavního snímku. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidá logo na první hlavní snímek:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro více informací o rámečcích obrázků viz [Picture Frame](/slides/cs/androidjava/picture-frame/).

## **Práce se zástupnými objekty**

Zástupné objekty jsou obvykle definovány na rozvrhových snímcích. Hlavní snímek poskytuje sdílený styl a motiv, který tyto rozvrhy dědí, zatímco každý rozvrh rozhoduje, které zástupné objekty jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty k dispozici v zobrazení Slide Master.

![Příkaz Insert Placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných objektů pomocí Aspose.Slides pracujte s rozvrhovým snímkem, který patří k hlavnímu snímku:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také formátovat tvary zástupných objektů, které již na hlavním snímku existují. Následující příklad najde zástupný objekt titulku a použije lineární gradientní výplň:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formátovaný zástupný objekt titulu zděděný normálními snímky](slide-master_8.png)

Pro více možností formátování zástupných objektů a textu viz [Set Prompt Text in Placeholder](/slides/cs/androidjava/manage-placeholder/) a [Text Formatting](/slides/cs/androidjava/text-formatting/).

## **Změna pozadí Slide Masteru**

Pozadí hlavního snímku je děděno rozvrhy a snímky, které ho nepřepíší. Následující příklad nastaví jednotnou barvu pozadí pro první hlavní snímek:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro související témata viz [Presentation Background](/slides/cs/androidjava/presentation-background/) a [Presentation Theme](/slides/cs/androidjava/presentation-theme/).

## **Klonování Slide Masteru do jiné prezentace**

Použijte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) k zkopírování hlavního snímku do jiné prezentace. Zkopírovaný hlavní snímek pak může být použit rozvrhy a snímky v cílové prezentaci.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Pokud potřebujete klonovat normální snímky spolu s jejich hlavním snímkem, viz [Clone Slides](/slides/cs/androidjava/clone-slides/).

## **Přidání více Slide Masterů**

Prezentace může obsahovat více hlavních snímků. To je užitečné, když různé sekce vyžadují odlišné značkování, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu hlavních snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí hlavní snímek, dá klonu jiné pozadí, vytvoří rozvrh pod tímto klonovaným hlavním snímkem a přidá nový snímek založený na tomto rozvrhu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Porovnání Slide Masterů**

Hlavní snímky lze porovnat metodou `equals` zděděnou z [IBaseSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, nebo dynamické hodnoty zástupných objektů, jako je aktuální datum.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Pro více informací viz [Compare Presentation Slides](/slides/cs/androidjava/compare-slides/).

## **Nastavení zobrazení Slide Master jako výchozího zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/) k řízení zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro více nastavení zobrazení viz [Save Presentation](/slides/cs/androidjava/save-presentation/).

## **Odstranění nepoužívaných hlavních snímků**

Prezentace někdy obsahují hlavní snímky, které již nejsou používány žádnými normálními snímky. Odstranění nepoužívaných hlavních snímků může snížit velikost souboru a zjednodušit údržbu šablon.

Použijte `removeUnused` k odstranění nepoužívaných hlavních snímků z kolekce `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také použít low-code metodu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jaký je rozdíl mezi slide master a layout slide?**

Slide master definuje sdílená nastavení designu, jako je motiv, pozadí, společné tvary a styly textu. Layout slide patří k slide masteru a definuje konkrétní uspořádání zástupných objektů. Normální snímek používá layout slide, takže dědí jak z rozvrhu, tak z hlavního snímku.

**Může jedna prezentace obsahovat několik slide masterů?**

Ano. Prezentace může obsahovat několik slide masterů. Používejte více hlavních snímků, když různé sekce potřebují odlišné vizuální systémy nebo značkování.

**Mám přidávat zástupné objekty do hlavního snímku nebo do layout slide?**

Ve většině případů přidávejte zástupné objekty do layout slidů. Na hlavní snímek umístěte sdílené vizuální prvky a formátování, poté na rozvrhy vložte zástupné objekty pro obsah, které budou používat normální snímky.

**Mohu smazat hlavní snímek, který je stále používán?**

Ne. Hlavní snímek, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky do rozvrhů pod jiným hlavním snímkem, nebo použijte metodu pro úklid nepoužívaných hlavních snímků, která odstraňuje jen ty, které nejsou použity.