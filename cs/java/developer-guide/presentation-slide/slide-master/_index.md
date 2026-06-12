---
title: Správa hlavních snímků prezentace v Javě
linktitle: Hlavní snímek
type: docs
weight: 70
url: /cs/java/slide-master/
keywords:
- hlavní snímek
- master snímek
- PPT hlavní snímek
- více hlavních snímků
- porovnání hlavních snímků
- pozadí
- zástupný symbol
- klonování hlavního snímku
- kopírování hlavního snímku
- duplikování hlavního snímku
- nepoužívaný hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Spravujte hlavní snímky v Aspose.Slides pro Javu: přístup, úprava, klonování, porovnání a odstranění hlavních snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Slide Master definuje společná nastavení designu pro skupinu snímků. Může obsahovat běžné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava Slide Masteru obvyklý způsob, jak zachovat konzistenci prezentace, aniž byste museli opakovat stejné formátování na každém snímku.

Aspose.Slides for Java podporuje stejný model. Prezentace může obsahovat jeden nebo více master snímků a každý master snímek může obsahovat několik layout snímků. Normální snímky obvykle neodkazují přímo na master snímek. Místo toho normální snímek používá layout snímek a ten patří k master snímku.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.
1. **Layout slide** – definuje konkrétní uspořádání zástupných symbolů a formátování na úrovni rozvržení.
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden layout slide.

![Hierarchie hlavních snímků, rozvržení snímků a běžných snímků](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován rozhraním [IMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/). Všechny master snímky v prezentaci jsou dostupné přes kolekci [Presentation.getMasters](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getMasters--) , která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává specifikovanější úroveň. Například pokud master snímek i layout snímek oba definují pozadí, snímky založené na tomto layoutu použijí pozadí layoutu. Další informace o layout snímcích najdete v [Apply or Change Slide Layouts](/slides/cs/java/slide-layout/).
{{% /alert %}}

## **Přístup k Slide Masterům**

V PowerPointu můžete otevřít zobrazení Slide Masteru přes **View** > **Slide Master**.

![Příkaz Slide Master na kartě Zobrazení v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `getMasters()` k přístupu k master snímkům:

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

Můžete také získat master snímek použité normálním snímkem prostřednictvím jeho layoutu:

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

## **Co Slide Master obsahuje**

Master snímek je objekt podobný snímku. Implementuje [IBaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/), takže vystavuje mnoho stejných vlastností snímků používaných normálními a layout snímky. Členy specifické pro master jsou uvedeny na stránce API [IMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/).

Běžně používané členy master snímku zahrnují:

| Member | Účel |
| --- | --- |
| `getBackground()` | Nastavuje pozadí snímku na úrovni masteru. |
| `getShapes()` | Ukládá tvary umístěné na masteru, jako jsou loga, rámečky obrázků a sdílený text. |
| `getLayoutSlides()` | Ukládá layout snímky, které patří k masteru. |
| `getThemeManager()` | Poskytuje přístup k API motivu masteru. |
| `getHeaderFooterManager()` | Řídí záhlaví, zápatí, data a čísla snímků pro master a jeho podřazené layouty. |
| `getDependingSlides()` | Vrací běžné snímky, které závisí na masteru skrze jejich layouty. |

## **Přidání obrázku do Slide Masteru**

Když přidáte obrázek do master snímku, objeví se na snímcích, které používají layouty z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidává logo do prvního master snímku:

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

Další informace o rámečcích obrázků najdete v [Picture Frame](/slides/cs/java/picture-frame/).

## **Práce se zástupnými symboly**

Zástupné symboly jsou obvykle definovány na layout snímcích. Master snímek poskytuje sdílený styl a motiv, který tyto layouty dědí, zatímco každý layout rozhoduje, které zástupné symboly jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné symboly dostupné v zobrazení Slide Master.

![Příkaz Vložit zástupný symbol v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných symbolů pomocí Aspose.Slides pracujte s layout snímkem, který patří k masteru:

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

Můžete také formátovat tvary zástupných symbolů, které již existují na master snímku. Následující příklad najde zástupný symbol titulu a použije lineární gradientní výplň:

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formátovaný zástupný symbol titulu děděný běžnými snímky](slide-master_8.png)

Další možnosti formátování zástupných symbolů a textu najdete v [Set Prompt Text in Placeholder](/slides/cs/java/manage-placeholder/) a [Text Formatting](/slides/cs/java/text-formatting/).

## **Změna pozadí Slide Masteru**

Master pozadí je děděno layouty a snímky, které jej nepřepíšou. Následující příklad nastavuje jednotnou barvu pozadí pro první master snímek:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro související témata viz [Presentation Background](/slides/cs/java/presentation-background/) a [Presentation Theme](/slides/cs/java/presentation-theme/).

## **Klonování Slide Masteru do jiné prezentace**

Použijte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) k zkopírování master snímku do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

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

Pokud potřebujete klonovat normální snímky společně s jejich masterem, viz [Clone Slides](/slides/cs/java/clone-slides/).

## **Přidání více Slide Masterů**

Prezentace může obsahovat více master snímků. To je užitečné, když různé sekce vyžadují odlišné brandování, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu master snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí master, nastaví klonu jiné pozadí, vytvoří layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

Master snímky lze porovnat metodou `equals` zděděnou z [IBaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných symbolů, jako je aktuální datum.

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

Další informace viz [Compare Presentation Slides](/slides/cs/java/compare-slides/).

## **Nastavení zobrazení Slide Master jako výchozího zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/), abyste řídili, které zobrazení PowerPoint otevře jako první. Následující příklad otevírá prezentaci ve zobrazení Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Další nastavení zobrazení najdete v [Save Presentation](/slides/cs/java/save-presentation/).

## **Odstranění nepoužívaných master snímků**

Prezentace někdy obsahují master snímky, které již nejsou použity žádnými normálními snímky. Odstranění nepoužívaných masterů může snížit velikost souboru a zjednodušit údržbu šablony.

Použijte `removeUnused` k odstranění nepoužívaných masterů z kolekce `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také použít low‑code metodu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

**Jaký je rozdíl mezi Slide Masterem a Layout snímkem?**

Slide Master definuje společná nastavení designu, jako jsou motiv, pozadí, společné tvary a styly textu. Layout snímek patří k Slide Masteru a určuje konkrétní uspořádání zástupných symbolů. Normální snímek používá layout snímek, takže dědí jak z layoutu, tak z masteru.

**Může jedna prezentace obsahovat několik Slide Masterů?**

Ano. Prezentace může obsahovat několik Slide Masterů. Používejte více masterů, když různé sekce vyžadují odlišné vizuální systémy nebo brandování.

**Mám přidávat zástupné symboly do Slide Masteru nebo do Layout snímku?**

Ve většině případů přidávejte zástupné symboly do layout snímků. Sdílené vizuální prvky a formátování umístěte na Slide Master, potom vložte obsahové zástupné symboly na layouty, které budou použity normálními snímky.

**Mohu smazat Slide Master, který je stále používán?**

Ne. Slide Master, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky na layouty pod jiný master nebo použijte metoda pro úklid nepoužívaných masterů, která odstraní jen ty mastery, které nejsou v použití.