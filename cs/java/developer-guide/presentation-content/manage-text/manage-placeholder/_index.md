---
title: Správa zástupných objektů prezentace v Java
linktitle: Správa zástupných objektů
type: docs
weight: 10
url: /cs/java/manage-placeholder/
keywords:
- zástupný objekt
- zástupný objekt textu
- zástupný objekt obrázku
- zástupný objekt grafu
- zástupný objekt obsahu
- nápovědní text
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak prohlížet a upravovat zástupné objekty textu, obrázku, grafu a obsahu a pochopit dědičnost zástupných objektů pomocí Aspose.Slides pro Java."
---
## **Přehled**

Zástupný objekt je tvar, který vyhrazuje pozici pro konkrétní typ obsahu v šabloně prezentace. Běžnými příklady jsou zástupné objekty pro název, tělo, obrázek, graf a obecné obsahové zástupné objekty. Na rozdíl od obyčejného tvaru může zástupný objekt dědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides zpřístupňuje informace o zástupných objektech pomocí metody [IShape.getPlaceholder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/). Tato metoda vrací objekt [IPlaceholder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholder/) nebo `null` pro běžný tvar. Použijte [IPlaceholder.getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholder/) k určení, co má zástupný objekt obsahovat.

Rozhraní tvaru je i po zjištění typu zástupného objektu stále důležité:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný objekt je obvykle reprezentován pomocí [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
- Vyplněný zástupný objekt obrázku může být reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/).
- Vyplněný zástupný objekt grafu může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/).
- Obsahový zástupný objekt může obsahovat několik typů obsahu. Zkontrolujte jak [IPlaceholder.getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholder/), tak rozhraní tvaru za běhu, místo aby se předpokládalo, že každý zástupný objekt je [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholder/) popisuje roli zástupného objektu; nezaručuje runtime typ tvaru. Vždy použijte kontrolu typu před přístupem k textovým, obrázkovým, grafovým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Pochopit dědičnost zástupných objektů**

Zástupné objekty tvoří hierarchii:

1. Hlavní snímek (master slide) definuje znovupoužitelné styly a v některých případech i zástupné objekty na úrovni masteru.
2. Rozložení snímku (layout slide) určuje uspořádání použité jedním nebo více normálními snímky a může dědit z hlavního snímku.
3. Normální snímek obsahuje zástupné objekty pro tento snímek a může dědit z jeho rozložení.

Metodou [IShape.getBasePlaceholder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) můžete posunout o jednu úroveň výš v této hierarchii. Zástupný objekt snímku obvykle vrací svůj zástupný objekt rozložení; zástupný objekt rozložení může vrátit svůj master zástupný objekt. Metoda vrací `null`, pokud tvar nemá základní zástupný objekt.

Následující příklad vypíše zástupné objekty na prvním snímku a zobrazí jejich základní zástupné objekty:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Úprava zástupného objektu na normálním snímku vytvoří nebo změní lokální přepis pro tento snímek. Úprava souvisejícího rozložení nebo masteru může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální obyčejný tvar nemá základní zástupný objekt a nezačíná dědit jen proto, že zabírá stejné souřadnice.

## **Změnit text v zástupném objektu**

Zástupné objekty pro název, centrální název, podnázev, tělo a text obvykle podporují text. Před použitím metody [getTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) zkontrolujte, zda jde o [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).

Tento příklad aktualizuje první zástupný objekt názvu na prvním snímku a uloží výsledek:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tento vzor zabraňuje přetypování obrázkových, grafových, tabulkových nebo mediálních zástupných objektů na [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/). Také identifikuje zástupný objekt podle účelu místo spolehnutí se na křehký index tvaru.

## **Nastavit nápovědní text v rozvržení**

Nápovědní text je instrukce během návrhu zobrazovaná v prázdném zástupném objektu, např. *Klikněte pro přidání názvu*. Nastavte vlastní nápovědní text na zástupném objektu rozložení místo pokusu o přístup přes kolekci tvarů normálního snímku. Přístup k rozložení získáte pomocí [ISlide.getLayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/) a iterujte přes kolekci vrácenou metodou [ILayoutSlide.getShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/).

Následující příklad mění nápovědy názvu a podnázvu v rozložení použitém pro první snímek:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nápovědní text není běžný obsah snímku. Je určen pro prázdné zástupné objekty v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program zadá skutečný obsah, nápověda se již nezobrazuje. Změna nápovědy také nevyřadí existující text na snímcích, které používají dané rozložení.

## **Aktualizovat zástupný objekt obrázku**

Existují dva případy, které je třeba ošetřit:

- Pokud je zástupný objekt obrázku již vyplněn a reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/), nahraďte obrázek pomocí [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/) a [ISlidesPicture.setImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidespicture/).
- Pokud je stále prázdný zástupný objekt, přidejte obrázkový rám na souřadnice zástupného objektu pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/) a odstraňte prázdný zástupný objekt.

Následující příklad podporuje oba případy a uloží prezentaci:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Náhrada vytvořená pro prázdný zástupný objekt je lokální obrázkový rám, ne nový zástupný objekt, protože [IShape.getPlaceholder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) neposkytuje setter. Zachová vyhrazenou pozici, ale již nezdědí chování specifické pro zástupný objekt. Pokud je zachování vztahu zástupného objektu podstatné, připravte a vyplňte zástupný objekt nejprve v PowerPointu a poté aktualizujte výsledný [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořezávání a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/java/picture-frame/). Tyto operace patří k obrázkovému rámu nebo výplni obrázku, nikoli k metadatům zástupného objektu.

## **Práce s grafy a obsahovými zástupnými objekty**

Vyplněný zástupný objekt grafu může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/). Tento příklad najde takový graf jak podle typu zástupného objektu, tak podle rozhraní za běhu, změní jeho název a uloží soubor:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obecný obsahový zástupný objekt má obvykle typ [PlaceholderType.Object](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po vyplnění prozkoumejte skutečné rozhraní tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také poskytovat typy [PlaceholderType.Chart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholdertype/), nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholdertype/).

Aspose.Slides nepřetvoří prázdný zástupný objekt [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na [IChart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/) pouhým změněním [IPlaceholder.getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholder/); typ nelze změnit přes rozhraní. Pro naplnění prázdné oblasti grafu nebo obsahu programově přidejte požadovaný objekt na souřadnice zástupného objektu a poté odstraňte prázdný zástupný objekt. Následující příklad to provádí pro graf:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přidaný graf je obyčejný lokální graf. Zaujímá oblast zástupného objektu, ale nedědí z rozložení zástupného objektu. Použijte specializované [chart management articles](/slides/cs/java/powerpoint-charts/), když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizovat text nebo obrázkový obsah**

Následující kompletní příklad otevře šablonu, prohledá první snímek buď na zástupný objekt názvu nebo obrázku, zkontroluje typy zástupného objektu a tvaru, aktualizuje příslušný obsah a uloží výstup. Příklad úmyslně nevyužívá předpokladu o indexu tvaru ani nepřetypovává každý zástupný objekt na stejné rozhraní.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Co je základní zástupný objekt?**

Základní zástupný objekt je odpovídající tvar na rozložení nebo masteru, ze kterého další zástupný objekt dědí. Použijte [IShape.getBasePlaceholder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) k jeho získání. Běžný lokální tvar vrací `null`, protože není součástí hierarchie zástupných objektů.

**Mohu změnit všechny názvy snímků úpravou zástupného objektu v rozložení?**

Můžete změnit zděděné formátování nebo nápovědní text pomocí rozložení, ale existující obsah názvu je uložen na normálních snímcích. Pro nahrazení skutečného textu názvu v celé prezentaci iterujte přes snímky a aktualizujte každý zástupný objekt názvu.

**Jak spravovat zástupné objekty data, čísla snímku, hlavičky a patičky?**

Použijte správce hlaviček a patiček na příslušném úrovni snímku, rozložení, masteru, poznámek nebo podkladů. Viz [Manage Presentation Header and Footer](/slides/cs/java/presentation-header-and-footer/) pro kompletní příklady.