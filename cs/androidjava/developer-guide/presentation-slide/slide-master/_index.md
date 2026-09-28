---
title: Správa slide masterů prezentace na Androidu
linktitle: Slide Master
type: docs
weight: 70
url: /cs/androidjava/slide-master/
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
- Android
- Java
- Aspose.Slides
description: "Spravujte slide mastery v Aspose.Slides pro Android přes Java: přístup, úprava, klonování, porovnání a odstranění master snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**slide master** určuje sdílená nastavení designu pro skupinu snímků. Může obsahovat běžné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní bez opakování stejného formátování na každém snímku.

Aspose.Slides pro Android přes Java podporuje stejný model. Prezentace může obsahovat jeden nebo více master slidů a každý master slide může obsahovat několik layout slidů. Normální slidy obvykle neodkazují přímo na master slide. Místo toho normální slide používá layout slide a tento layout slide patří k master slide.

Hierarchie je:

1. **Slide master** – určuje sdílený design a motiv.
1. **Layout slide** – určuje konkrétní uspořádání zástupných objektů a formátování na úrovni rozvržení.
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden layout slide.

![Hierarchie master slidů, layout slidů a normálních slidů](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován rozhraním [IMasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/). Všechny master slide v prezentaci jsou dostupné prostřednictvím kolekce [Presentation.getMasters](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getMasters--) , která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/). Pro úplný přehled Android via Java API se podívejte na [com.aspose.slides API reference](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud master slide i layout slide oba definují pozadí, snímky založené na tomto rozvržení použijí pozadí rozvržení. Pro více informací o layout slidech viz [Použití nebo změna rozložení snímků](/slides/cs/androidjava/slide-layout/).
{{% /alert %}}

## **Přístup k Slide Masterům**

V PowerPointu můžete otevřít zobrazení Slide Master z **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `getMasters()` pro přístup k master slideům:

```java
import com.aspose.slides.*;

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

Můžete také získat master slide používaný normálním snímkem prostřednictvím jeho rozvržení:

```java
import com.aspose.slides.*;

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

Master slide je objekt podobný snímku. Implementuje rozhraní [IBaseSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/), takže poskytuje mnoho stejných vlastností snímků, které používají normální a layout slide.

Často používané členy master slide zahrnují:

| Člen | Účel |
| --- | --- |
| `getBackground()` | Nastavuje pozadí snímku na úrovni masteru. |
| `getShapes()` | Uchovává tvary umístěné na masteru, jako jsou loga, rámečky obrázků a sdílený text. |
| `getLayoutSlides()` | Uchovává layout slide, které patří k masteru. |
| `getThemeManager()` | Poskytuje přístup k API master tématu. |
| `getHeaderFooterManager()` | Řídí záhlaví, zápatí, data a čísla snímků pro master a jeho podřízené layouty. |
| `getDependingSlides()` | Vrací normální snímky, které závisí na masteru skrze jejich layouty. |

## **Přidání obrázku do Slide Masteru**

Když přidáte obrázek do master slide, objeví se na snímcích, které používají rozvržení z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidává logo na první master slide:

```java
import com.aspose.slides.*;

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

Pro více informací o obrázkových rámečcích viz [Obrázkový rám](/slides/cs/androidjava/picture-frame/).

## **Řízení viditelnosti grafiky masteru**

Použijte [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) k skrytí zdědéné grafiky masteru, jako jsou loga nebo dekorativní tvary, aniž byste je mazali z masteru. Předejte `false` metodě [Slide.setShowMasterShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) na snímku, který by měl tyto grafiky vynechat, a ponechte `true` na snímcích, které je mají zobrazovat.

Následující samostatný příklad vytvoří modrý dekorativní pás na masteru a dvou snímcích, které používají stejné prázdné rozvržení. Pás je viditelný na prvním snímku a skrytý na druhém. Není vyžadována žádná vstupní prezentace ani obrázek.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Příklad používá rozvržení **Blank** dodané s novou prezentací a odstraňuje vlastní zástupné objekty počátečního snímku.

### **Zvolte rozsah nastavení**

Normální snímek používá svého mastera přes [ISlide.getLayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getLayoutSlide--) a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Nastavení vlastnosti na jednotlivém snímku ovlivní pouze tento snímek. Předání `false` metodě [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) skryje grafiku masteru pro snímky, které používají toto sdílené rozvržení, i když jejich vlastní nastavení je `true`. Pro skrytí grafiky jen na jednom snímku změňte vlastnost snímku a ponechte sdílené rozvržení beze změny.

Nastavení není podporováno jako řízení viditelnosti přímo na master slide. Na masteru [getShowMasterShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) vždy vrací `false` a předání `true` metodě [setShowMasterShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) vyvolá výjimku. Použijte jej na normální snímek nebo na layout.

### **Rozlište grafiku od pozadí**

| Operace | Efekt |
| --- | --- |
| Skrýt grafiku masteru | Řídí viditelnost zděděných tvarů masteru bez jejich mazání nebo změny tvarů snímku. |
| Změnit výplň pozadí snímku | Mění barvu, gradient nebo obrázek pozadí. Grafika masteru jsou samostatné tvary a mohou zůstávat viditelné nad tímto pozadím. Viz [Pozadí prezentace](/slides/cs/androidjava/presentation-background/). |
| Smazat tvar z masteru | Odstraní sdílený zdrojový tvar, takže již není k dispozici žádnému snímku, který používá tento master. |

## **Práce se zástupnými objekty**

Zástupné objekty jsou obvykle definovány na layout slidech. Master slide poskytuje sdílený styl a motiv, který tyto layouty dědí, zatímco každý layout rozhoduje, které zástupné objekty jsou dostupné a kde jsou umístěny.

V PowerPointu jsou příkazy zástupných objektů k dispozici v zobrazení Slide Master.

![Příkaz Vložit zástupný objekt v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných objektů pomocí Aspose.Slides pracujte s layout slide, který patří k masteru:

```java
import com.aspose.slides.*;

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

Můžete také formátovat tvary zástupných objektů, které již na master slide existují. Následující příklad najde zástupný objekt title a použije lineární gradientní výplň:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formátovaný zástupný objekt title zděděný normálními snímky](slide-master_8.png)

Pro více možností formátování zástupných objektů a textu viz [Nastavit výzvu textu v zástupném objektu](/slides/cs/androidjava/manage-placeholder/) a [Formátování textu](/slides/cs/androidjava/text-formatting/).

## **Změna pozadí Slide Masteru**

Pozadí masteru je děděno layouty a snímky, které jej nepřepisují. Následující příklad nastaví jednotnou barvu pozadí pro první master slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Pro související témata viz [Pozadí prezentace](/slides/cs/androidjava/presentation-background/) a [Motiv prezentace](/slides/cs/androidjava/presentation-theme/).

## **Klonování Slide Masteru do jiné prezentace**

Použijte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) k zkopírování master slide do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

```java
import com.aspose.slides.*;

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

Pokud potřebujete klonovat normální snímky spolu s jejich masterem, viz [Klonovat snímky](/slides/cs/androidjava/clone-slides/).

## **Přidání více Slide Masterů**

Prezentace může obsahovat více master slide. To je užitečné, když různé sekce vyžadují odlišné značení, strukturu stránky nebo nastavení motivu.

![Příkazy PowerPointu pro vložení a správu master slide](slide-master_9.jpg)

Následující příklad klonuje výchozí master, přiřadí klonu jiné pozadí, vytvoří layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

Master slide lze porovnat pomocí metody `equals` zděděné z [IBaseSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, například aktuální datum.

```java
import com.aspose.slides.*;

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

Pro více informací viz [Porovnat snímky v prezentaci](/slides/cs/androidjava/compare-slides/).

## **Nastavit zobrazení Slide Master jako výchozí zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/) pro ovládání zobrazení, které PowerPoint otevře jako první. Následující příklad otevírá prezentaci v zobrazení Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro více nastavení zobrazení viz [Uložit prezentaci](/slides/cs/androidjava/save-presentation/).

## **Odstranění nepoužívaných Master Slide**

Prezentace někdy obsahují master slide, které již nejsou používány žádnými normálními snímky. Odstranění nepoužívaných master slide může snížit velikost souboru a zjednodušit údržbu šablon.

Použijte `removeUnused` k odstranění nepoužívaných masterů z kolekce `getMasters()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také použít low-code metodu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

```java
import com.aspose.slides.*;

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

Slide master určuje sdílená nastavení designu, jako jsou motiv, pozadí, společné tvary a styly textu. Layout slide patří k slide master a určuje konkrétní uspořádání zástupných objektů. Normální slide používá layout slide, takže dědí jak z layoutu, tak z masteru.

**Může jedna prezentace obsahovat několik slide masterů?**

Ano. Prezentace může obsahovat několik slide masterů. Používejte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo značku.

**Mám přidávat zástupné objekty na master slide nebo na layout slide?**

Ve většině případů přidávejte zástupné objekty na layout slide. Umístěte sdílené vizuální prvky a sdílené formátování na master slide, a poté umístěte obsahové zástupné objekty na layouty, které budou používány normálními snímky.

**Mohu smazat master slide, který je stále používán?**

Ne. Master slide, který má závislé snímky, nelze bezpečně přímo odstranit. Nejprve přesuňte tyto snímky na layouty pod jiný master, nebo použijte metodu úklidu nepoužívaných masterů, která odstraňuje pouze master slide, které nejsou používány.