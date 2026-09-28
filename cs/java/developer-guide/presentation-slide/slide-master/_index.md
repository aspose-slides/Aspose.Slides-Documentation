---
title: Správa hlavních návrhů snímků v Java
linktitle: Hlavní návrh snímku
type: docs
weight: 70
url: /cs/java/slide-master/
keywords:
- hlavní návrh snímku
- hlavní snímek
- PPT hlavní snímek
- více hlavních návrhů snímků
- porovnání hlavních snímků
- pozadí
- zástupce
- klonovat hlavní snímek
- kopírovat hlavní snímek
- duplikovat hlavní snímek
- nepoužitý hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Spravujte hlavní návrhy snímků v Aspose.Slides pro Java: přístup, úprava, klonování, porovnání a odstraňování hlavních snímků v prezentacích PowerPoint i OpenDocument."
---
## **Přehled**

**hlavní návrh snímku** definuje sdílená nastavení návrhu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava hlavního návrhu snímku obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides for Java podporuje stejný model. Prezentace může obsahovat jeden nebo více hlavních návrhů snímků a každý hlavní návrh snímku může obsahovat několik návrhů rozložení. Normální snímky se obvykle nepřistupují přímo k hlavnímu návrhu snímku. Místo toho normální snímek používá návrh rozložení, který patří k hlavnímu návrhu snímku.

Hierarchie je:

1. **Hlavní návrh snímku** – definuje sdílený návrh a motiv.
1. **Návrh rozložení** – definuje konkrétní uspořádání zástupců a formátování na úrovni rozložení.
1. **Normální snímek** – obsahuje skutečný obsah prezentace a používá jeden návrh rozložení.

![Hierarchie hlavních návrhů snímků, návrhů rozložení a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je hlavní návrh snímku reprezentován rozhraním [IMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/). Všechny hlavní návrhy snímků v prezentaci jsou dostupné přes kolekci [Presentation.getMasters](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getMasters--) , která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud hlavní návrh snímku a návrh rozložení oba definují pozadí, snímky založené na tomto rozložení použijí pozadí rozložení. Další informace o návrzích rozložení najdete v [Apply or Change Slide Layouts](/slides/cs/java/slide-layout/).

{{% /alert %}}

## **Přístup k hlavním návrhům snímků**

V PowerPointu můžete otevřít zobrazení Hlavní návrh snímku přes **Zobrazení** > **Hlavní návrh snímku**.

![Příkaz Hlavní návrh snímku na kartě Zobrazení v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `getMasters()` k přístupu k hlavním návrhům snímků:

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

Můžete také získat hlavní návrh snímku použitý normálním snímkem přes jeho rozložení:

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

## **Co hlavní návrh snímku obsahuje**

Hlavní návrh snímku je objekt podobný snímku. Implementuje [IBaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/), takže vystavuje mnoho stejných vlastností snímku používaných normálními a rozloženími snímků. Členy specifické pro hlavní návrh jsou uvedeny na stránce API [IMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/).

Mezi často používané členy hlavního návrhu patří:

| Člen | Účel |
| --- | --- |
| `getBackground()` | Nastavuje pozadí na úrovni hlavního návrhu snímku. |
| `getShapes()` | Uchovává tvary umístěné na hlavním návrhu, např. loga, rámy obrázků a sdílený text. |
| `getLayoutSlides()` | Uchovává návrhy rozložení, které patří k hlavnímu návrhu. |
| `getThemeManager()` | Poskytuje přístup k API motivu hlavního návrhu. |
| `getHeaderFooterManager()` | Řídí záhlaví, zápatí, datum a čísla snímků pro hlavní návrh a jeho podřízená rozložení. |
| `getDependingSlides()` | Vrací normální snímky, které jsou na hlavním návrhu závislé přes svá rozložení. |

## **Přidání obrázku do hlavního návrhu snímku**

Když přidáte obrázek do hlavního návrhu snímku, objeví se na snímcích, které používají rozložení z tohoto hlavního návrhu. To je užitečné pro loga, vodotisky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidává logo na první hlavní návrh snímku:

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

Další informace o rámech obrázků najdete v [Picture Frame](/slides/cs/java/picture-frame/).

## **Řízení viditelnosti grafiky hlavního návrhu**

Použijte [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) k skrytí zděděné grafiky hlavního návrhu, jako jsou loga nebo dekorativní tvary, aniž byste je mazali z hlavního návrhu. Na snímku, který má grafiku vynechat, předáte `false` metodě [Slide.setShowMasterShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-). Na snímcích, kde má být grafika zobrazena, ponechte `true`.

Následující samostatný příklad vytvoří modrý dekorativní pás na hlavním návrhu a dvou snímcích, které používají stejné prázdné rozložení. Pás je viditelný na prvním snímku a skrytý na druhém. Nepotřebujete žádnou vstupní prezentaci ani obrázek.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
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

Příklad používá rozložení **Blank** dodávané s novou prezentací a odstraňuje počáteční zástupce snímku.

### **Zvolte rozsah nastavení**

Normální snímek používá svého hlavního návrhu přes [ISlide.getLayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getLayoutSlide--) a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Nastavení vlastnosti na jednotlivém snímku ovlivní jen tento snímek. Předáním `false` metodě [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) skryjete grafiku hlavního návrhu pro snímky, které používají toto sdílené rozložení, i když jejich vlastní nastavení je `true`. Pro skrytí grafiky jen na jednom snímku změňte vlastnost snímku a nechte sdílené rozložení nezměněné.

Nastavení není podporováno jako řízení viditelnosti přímo na hlavním návrhu snímku. Na hlavním návrhu metoda [getShowMasterShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterslide/#getShowMasterShapes--) vždy vrací `false` a předání `true` metodě [setShowMasterShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) vyvolá výjimku. Použijte ji na normálním snímku nebo na rozložení.

### **Rozlišujte grafiku od pozadí**

| Operace | Efekt |
| --- | --- |
| Skrýt grafiku hlavního návrhu | Řídí viditelnost zděděných tvarů hlavního návrhu, aniž byste je mazali nebo měnili vlastní tvary snímku. |
| Změnit výplň pozadí snímku | Změní barvu, gradient nebo obrázek pozadí. Grafika hlavního návrhu jsou samostatné tvary a mohou zůstat viditelné nad tímto pozadím. Viz [Presentation Background](/slides/cs/java/presentation-background/). |
| Smazat tvar z hlavního návrhu | Odstraní sdílený zdrojový tvar, takže již není k dispozici žádnému snímku používajícímu tento hlavní návrh. |

## **Práce se zástupci**

Zástupci jsou obvykle definováni na návrzích rozložení. Hlavní návrh snímku poskytuje sdílený styl a motiv, které tyto rozložení zdědí, zatímco každé rozložení rozhoduje, kteří zástupci jsou k dispozici a kde jsou umístěni.

V PowerPointu jsou příkazy pro zástupce dostupné v zobrazení Hlavní návrh snímku.

![Příkaz Vložit zástupce v zobrazení Hlavní návrh snímku v PowerPointu](slide-master_5.png)

Pro přidání nových zástupců s Aspose.Slides pracujte s návrhem rozložení, který patří k hlavnímu návrhu:

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

Můžete také formátovat tvary zástupců, které již na hlavním návrhu existují. Následující příklad najde zástupce nadpisu a použije lineární gradientní výplň:

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

![Formátovaný nadpisový zástupce zděděný normálními snímky](slide-master_8.png)

Další možnosti formátování zástupců a textu najdete v [Set Prompt Text in Placeholder](/slides/cs/java/manage-placeholder/) a [Text Formatting](/slides/cs/java/text-formatting/).

## **Změna pozadí hlavního návrhu snímku**

Pozadí hlavního návrhu je zděděno rozloženími a snímky, které jej nepřepíší. Následující příklad nastaví jednotnou barvu pozadí pro první hlavní návrh snímku:

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

Související témata najdete v [Presentation Background](/slides/cs/java/presentation-background/) a [Presentation Theme](/slides/cs/java/presentation-theme/).

## **Klonování hlavního návrhu snímku do jiné prezentace**

Použijte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) k zkopírování hlavního návrhu snímku do jiné prezentace. Zkopírovaný hlavní návrh může být následně použit rozloženími a snímky v cílové prezentaci.

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

Pokud potřebujete klonovat normální snímky spolu s jejich hlavním návrhem, podívejte se na [Clone Slides](/slides/cs/java/clone-slides/).

## **Přidání více hlavních návrhů snímků**

Prezentace může obsahovat více hlavních návrhů snímků. To je užitečné, když různé sekce vyžadují odlišné značkování, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu hlavních návrhů snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí hlavní návrh, dá klonu jiné pozadí, vytvoří rozložení pod tímto klonovaným hlavním návrhem a přidá nový snímek založený na tomto rozložení:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Porovnání hlavních návrhů snímků**

Hlavní návrhy snímků lze porovnat metodou `equals`, která je zděděna z [IBaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Neporovnává jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupců, jako je aktuální datum.

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

Další informace najdete v [Compare Presentation Slides](/slides/cs/java/compare-slides/).

## **Nastavení zobrazení Hlavní návrh snímku jako výchozího zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/) k řízení zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Hlavní návrh snímku:

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

Další nastavení zobrazení najdete v [Save Presentation](/slides/cs/java/save-presentation/).

## **Odstranění nepoužívaných hlavních návrhů snímků**

Někdy prezentace obsahují hlavní návrhy snímků, které již žádný normální snímek nepoužívá. Odstranění nepoužívaných hlavních návrhů může zmenšit velikost souboru a usnadnit údržbu šablon.

Použijte `removeUnused` k odstranění nepoužívaných hlavních návrhů z kolekce `getMasters()`:

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

Můžete také použít low‑code metodu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

**Jaký je rozdíl mezi hlavním návrhem snímku a návrhem rozložení?**

Hlavní návrh snímku definuje sdílená nastavení návrhu, jako je motiv, pozadí, společné tvary a styly textu. Návrh rozložení patří k hlavnímu návrhu snímku a definuje konkrétní uspořádání zástupců. Normální snímek používá návrh rozložení, takže dědí jak z rozložení, tak z hlavního návrhu.

**Může jedna prezentace obsahovat několik hlavních návrhů snímků?**

Ano. Prezentace může obsahovat několik hlavních návrhů snímků. Používejte více hlavních návrhů, když různé sekce potřebují odlišné vizuální systémy nebo značkování.

**Mám přidávat zástupce do hlavního návrhu snímku nebo do návrhu rozložení?**

Ve většině případů přidávejte zástupce do návrhů rozložení. Sdílené vizuální prvky a sdílené formátování umístěte na hlavní návrh snímku a obsahové zástupce pak na rozložení, která normální snímky použijí.

**Mohu smazat hlavní návrh snímku, který je ještě používán?**

Ne. Hlavní návrh snímku, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky do rozložení pod jiný hlavní návrh nebo použijte metodu pro úklid nepoužívaných hlavních návrhů, která odstraňuje jen ty, které nejsou v použití.