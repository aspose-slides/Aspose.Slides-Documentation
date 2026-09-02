---
title: Správa zástupných prvků prezentace v Androidu
linktitle: Správa zástupných prvků
type: docs
weight: 10
url: /cs/androidjava/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrázkový zástupný prvek
- grafický zástupný prvek
- obsahový zástupný prvek
- výzva
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak prozkoumat a upravit textové, obrázkové, grafické a obsahové zástupné prvky a pochopit dědičnost zástupných prvků pomocí Aspose.Slides pro Android v Javě."
---
## **Přehled**

Zástupný prvek (placeholder) je tvar, který vyhrazuje místo pro určitý typ obsahu v šabloně prezentace. Běžnými příklady jsou zástupci pro nadpis, tělo, obrázek, graf a obecné účely obsahu. Na rozdíl od běžného tvaru může zástupný prvek dědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides zpřístupňuje informace o zástupných prvcích prostřednictvím metody [IShape.getPlaceholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/). Tato metoda vrací objekt [IPlaceholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholder/) nebo `null` pro normální tvar. Pomocí [IPlaceholder.getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholder/) zjistíte, jaký obsah je zástupný prvek určen.

Rozhraní tvaru má stále význam i poté, co znáte typ zástupného prvku:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný prvek je obvykle reprezentován pomocí [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
- Vyplněný obrázkový zástupný prvek může být reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/).
- Vyplněný grafický zástupný prvek může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/).
- Obsahový zástupný prvek může obsahovat několik druhů obsahu. Zkontrolujte jak [IPlaceholder.getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholder/), tak rozhraní tvaru za běhu, místo abyste předpokládali, že každý zástupný prvek je [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholder/) popisuje roli zástupného prvku; nezaručuje typ tvaru za běhu. Vždy použijte kontrolu typu před přístupem k textu, obrázku, grafu, tabulce nebo mediálním členům.
{{% /alert %}}

## **Pochopení dědičnosti zástupných prvků**

Zástupné prvky tvoří hierarchii:

1. Hlavní snímek (master slide) definuje znovupoužitelné styly a v některých případech zástupné prvky na úrovni hlavního snímku.
2. Rozložení snímku (layout slide) určuje uspořádání použité jedním nebo více normálními snímky a může dědit z hlavního snímku.
3. Normální snímek obsahuje zástupné prvky pro tento snímek a může dědit z jeho rozložení.

Pro posun o úroveň výše v hierarchii zavolejte [IShape.getBasePlaceholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/). Zástupný prvek snímku obvykle vrací svůj zástupný prvek rozložení; zástupný prvek rozložení může vracet svůj zástupný prvek hlavního snímku. Metoda vrací `null`, když tvar nemá základní zástupný prvek.

Následující příklad vypisuje zástupné prvky na prvním snímku a uvádí jejich základní zástupné prvky:

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

Úprava zástupného prvku na normálním snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozložení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální běžný tvar nemá žádný základní zástupný prvek a nezačne dědit jen proto, že zabírá stejné souřadnice.

## **Změna textu ve zástupném prvku**

Zástupné prvky typu nadpis, centrovaný nadpis, podnadpis, tělo a text obvykle podporují text. Před použitím metody [getTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) zkontrolujte, zda se jedná o [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).

Tento příklad aktualizuje první zástupný prvek nadpisu na prvním snímku a uloží výsledek:

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

Tento vzor zabraňuje přetypování obrázkových, grafických, tabulkových nebo mediálních zástupných prvků na [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/). Také identifikuje zástupný prvek podle účelu místo spoléhání na křehký index tvaru.

## **Nastavení textu výzvy na rozložení**

Text výzvy je návrhový pokyn zobrazený v prázdném zástupném prvku, například *Click to add title*. Vlastní text výzvy nastavte na zástupný prvek rozložení místo pokusu o dosažení přes kolekci tvarů normálního snímku. Přístup k rozložení získáte pomocí [ISlide.getLayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) a iterujte přes kolekci vrácenou metodou [ILayoutSlide.getShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/).

Následující příklad mění výzvy nadpisu a podnadpisu v rozložení použitém prvním snímkem:

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

Text výzvy není běžný obsah snímku. Je určen pro prázdné zástupné prvky v editovacích aplikacích, jako je PowerPoint. Jakmile uživatel nebo program dodá skutečný obsah, výzva se již nezobrazuje. Změna výzvy také neprobíhá nahrazením existujícího textu na snímcích, které rozložení používají.

## **Aktualizace obrázkového zástupného prvku**

Existují dva případy, které je třeba ošetřit:

- Pokud je obrázkový zástupný prvek již vyplněn a reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/), nahraďte obrázek pomocí [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) a [ISlidesPicture.setImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidespicture/).
- Pokud je stále prázdným zástupným prvkem, přidejte obrázkový rámec na souřadnice zástupného prvku pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/) a odeberte prázdný zástupný prvek.

Další příklad podporuje oba případy a uloží prezentaci:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

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

Náhrada vytvořená pro prázdný zástupný prvek je lokální obrázkový rámec, nikoli nový zástupný prvek, protože [IShape.getPlaceholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) neposkytuje nastavitelnou metodu. Uchovává vyhrazenou pozici, ale již nedědí chování specifické pro zástupné prvky. Pokud je zachování vztahu k zástupnému prvku podstatné, připravte a vyplňte zástupný prvek nejprve v PowerPointu a pak aktualizujte vzniklý [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrazu, ořez a další efekty specifické pro obrázek viz [Spravovat obrázkové rámy](/slides/cs/androidjava/picture-frame/). Tyto operace patří k obrázkovému rámečku nebo výplni obrázku, nikoli k metadatům zástupného prvku.

## **Práce s grafickými a obsahovými zástupnými prvky**

Vyplněný grafický zástupný prvek může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/). Tento příklad najde takový graf podle typu zástupného prvku i rozhraní za běhu, změní jeho nadpis a uloží soubor:

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

Obecný obsahový zástupný prvek má obvykle [PlaceholderType.Object](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění prozkoumejte skutečné rozhraní tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také vystavovat [PlaceholderType.Chart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholdertype/), nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides nepřevádí prázdný [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) zástupný prvek na [IChart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/) pouhým změněním [IPlaceholder.getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholder/); typ nelze změnit přes rozhraní. Pro programové naplnění prázdného grafu nebo obsazení oblasti obsahem přidejte požadovaný objekt na souřadnice zástupného prvku a potom odeberte prázdný zástupný prvek. Následující příklad to provádí pro graf:

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

Přidaný graf je obyčejný lokální graf. Zaujímá oblast zástupného prvku, ale nedědí z grafu rozložení. Použijte věnované [články o správě grafů](/slides/cs/androidjava/powerpoint-charts/), pokud potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textu nebo obrázkového obsahu**

Následující end-to-end příklad otevře šablonu, prohledá první snímek, zda obsahuje nadpis nebo obrázkový zástupný prvek, zkontroluje typy zástupného prvku a tvaru, aktualizuje odpovídající obsah a uloží výstup. Příklad úmyslně nekončí předpokladem o indexu tvaru ani nepřetypovává každý zástupný prvek na stejné rozhraní.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

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

**Co je základní zástupný prvek?**

Základní zástupný prvek je odpovídající tvar na rozložení nebo hlavním snímku, ze kterého jiný zástupný prvek dědí. Použijte [IShape.getBasePlaceholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) pro jeho získání. Běžný lokální tvar vrací `null`, protože není součástí hierarchie zástupných prvků.

**Mohu změnit všechny názvy snímků úpravou zástupného prvku v rozložení?**

Můžete změnit děděné formátování nebo text výzvy pomocí rozložení, ale existující text nadpisu je uložen na normálních snímcích. Pro nahrazení skutečného textu nadpisu v celém dokumentu iterujte přes snímky a aktualizujte každý zástupný prvek nadpisu.

**Jak spravovat zástupné prvky data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na úrovni konkrétního snímku, rozložení, hlavního snímku, poznámek nebo předložek. Viz [Spravovat záhlaví a zápatí prezentace](/slides/cs/androidjava/presentation-header-and-footer/) pro kompletní příklady.