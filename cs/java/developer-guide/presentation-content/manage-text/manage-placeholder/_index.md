---
title: Spravovat zástupné prvky prezentace v Java
linktitle: Spravovat zástupné prvky
type: docs
weight: 10
url: /cs/java/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrázkový zástupný prvek
- grafický zástupný prvek
- obsahový zástupný prvek
- výzva
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak prozkoumat a upravit textové, obrázkové, grafické a obsahové zástupné prvky a pochopit dědičnost zástupných prvků pomocí Aspose.Slides pro Java."
---
## **Přehled**

Zástupný prvek je tvar, který rezervuje místo pro určitý typ obsahu v šabloně prezentace. Běžnými příklady jsou zástupné prvky pro nadpis, tělo, obrázek, graf a obecný obsah. Na rozdíl od běžného tvaru může zástupný prvek dědit svou polohu, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides zpřístupňuje informace o zástupných prvcích prostřednictvím metody [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/). Metoda vrací objekt [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) nebo `null` pro běžný tvar. Použijte [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) k určení, co má zástupný prvek obsahovat.

Rozhraní tvaru má stále význam poté, co znáte typ zástupného prvku:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný prvek je obvykle reprezentován pomocí [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
- Vyplněný obrázkový zástupný prvek může být reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/).
- Vyplněný grafický zástupný prvek může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/).
- Obsahový zástupný prvek může obsahovat několik typů obsahu. Zkontrolujte jak [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/), tak runtime rozhraní tvaru, místo abyste předpokládali, že každý zástupný prvek je [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) popisuje roli zástupného prvku; nezaručuje runtime typ tvaru. Vždy proveďte kontrolu typu před přístupem k textovým, obrázkovým, grafickým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Pochopení dědičnosti zástupných prvků**

Zástupné prvky tvoří hierarchii:

1. Hlavní snímek (master slide) definuje opakovaně použitelné styly a v některých případech i zástupné prvky na úrovni hlavního snímku.
2. Rozložení snímku (layout slide) určuje uspořádání použité jedním nebo více běžnými snímky a může dědit z hlavního snímku.
3. Běžný snímek obsahuje zástupné prvky pro tento snímek a může dědit z jeho rozložení.

Zavolejte [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) pro přesun o jednu úroveň výše v této hierarchii. Zástupný prvek snímku obvykle vrací svůj zástupný prvek rozložení; zástupný prvek rozložení může vracet svůj hlavní zástupný prvek. Metoda vrací `null`, když tvar nemá základní zástupný prvek.

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

Úprava zástupného prvku na běžném snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozložení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Běžný tvar nemá žádný základní zástupný prvek a nezačne dědit jen proto, že zabírá stejné souřadnice.

## **Odstranění stavu zástupného prvku**

Při úpravě šablony použijte [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) k zachování existujícího objektu jako běžného tvaru. Jeho metoda [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) vrací `null`, ale tvar zůstává v kolekci snímku. Naproti tomu [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) smaže tvar z této kolekce.

Následující příklad vyžaduje soubor `template.pptx` s alespoň jedním snímkem a neprázdným textovým zástupným prvkem na prvním snímku. Použijte zástupný prvek s formátováním zděděným z jeho rozložení nebo hlavního snímku, aby bylo patrné, jaký má efekt odstranění tohoto vztahu. Příklad kontroluje, že stejný tvar zůstává, znovu zavolá metodu na nyní běžném tvaru a uloží výsledek.

{{% alert color="warning" title="Warning" %}}
Odstranění stavu zástupného prvku automaticky neuchovává zděděná nastavení vzhledu. Níže uvedený příklad úmyslně nechává tato nastavení beze změny, takže výstup může vypadat odlišně. Tvar, jehož pozice a velikost jsou zcela zděděny, může po volání mít nulové souřadnice a rozměry a stát se neviditelným, i když zůstává v kolekci.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || 
            textFrame == null || 
            textFrame.getText() == null || 
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Volání metody na běžném tvaru nemá žádný efekt.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Pro odpovídající zástupný prvek všechny tři kontroly vrátí `true`. Text zůstane, ale zděděná pozice, velikost, rotace, písmo, zarovnání odstavce, okraje textového rámce, vertikální kotvení, výplň a nastavení čáry se mohou změnit, když je vztah zástupného prvku odstraněn. Například zděděné formátování nadpisu může přejít na běžné formátování textu. Více o rozloženích najdete v článku [Slide Layout](/slides/cs/java/slide-layout/).

Pro zachování zamýšleného vzhledu zachyťte vypočtenou pozici, velikost a rotaci před voláním a zkopírujte požadované účinné formátovací hodnoty do samostatných proměnných. Tyto hodnoty načtěte pomocí [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), a [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--). Nespoléhejte se jen na objekty s účinným formátem, protože jejich hodnoty textového formátování se mohou po odstranění vztahu změnit. Výslovně aplikujte zachycené hodnoty na běžný tvar následně, včetně rodiny písma, velikosti, stylu, barvy, nastavení odstavce, nastavení textového rámce, výplně a čáry použité v šabloně.

Zděděná geometrie tvaru může také vyžadovat explicitní přiřazení pomocí [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-). Pro obdélníkový textový zástupný prvek to znamená přiřadit [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle); obnovení pouze výplně a čáry nemusí obnovit viditelný obdélník. Šablony s dalšími efekty nebo složitějším formátováním vyžadují, aby byla tato nastavení také ošetřena.

## **Změna textu ve zástupném prvku**

Nadpis, centrovaný nadpis, podnadpis, tělo a textové zástupné prvky obvykle podporují text. Před použitím metody [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) zkontrolujte, zda se jedná o [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

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

Tento vzor zabraňuje přetypování obrázkových, grafických, tabulkových nebo mediálních zástupných prvků na [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Také identifikuje zástupný prvek podle účelu místo spoléhat na křehký index tvaru.

## **Nastavení výzvy (prompt) textu v rozložení**

Výzva (prompt) text je návrhová instrukce zobrazovaná v prázdném zástupném prvku, například *Klikněte pro přidání nadpisu*. Nastavte vlastní výzvu v zástupném prvku rozložení místo toho, abyste se snažili dosáhnout na něj přes kolekci tvarů běžného snímku. Přístup k rozložení získáte pomocí [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) a iterujete přes kolekci vrácenou metodou [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/).

Následující příklad mění výzvu nadpisu a podnadpisu v rozložení použitém na prvním snímku:

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

Výzva není běžný obsah snímku. Je určena pro prázdné zástupné prvky v editovacích aplikacích, jako je PowerPoint. Jakmile uživatel nebo program dodá skutečný obsah, výzva již není zobrazena. Změna výzvy také neodstraní existující text na snímcích, které používají dané rozložení.

## **Aktualizace obrázkového zástupného prvku**

Existují dva případy:

- Pokud je obrázkový zástupný prvek již vyplněn a je reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), nahraďte obrázek pomocí [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) a [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/).
- Pokud je stále prázdný zástupný prvek, přidejte obrázkový rámec na souřadnice zástupného prvku pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) a odstraňte prázdný zástupný prvek.

Další příklad podporuje oba případy a ukládá prezentaci:

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

Náhrada vytvořená pro prázdný zástupný prvek je lokální obrázkový rámec, nikoli nový zástupný prvek, protože [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) neposkytuje setter. Uchovává vyhrazenou polohu, ale již nedědí chování specifické pro zástupné prvky. Pokud je zachování vztahu zástupného prvku podstatné, připravte a vyplňte zástupný prvek v PowerPointu nejprve, pak aktualizujte vzniklý [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořez a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/java/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, nikoli k metadatům zástupného prvku.

## **Práce s grafickými a obsahovými zástupnými prvky**

Vyplněný grafický zástupný prvek může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/). Tento příklad najde takový graf podle typu zástupného prvku i runtime rozhraní, změní jeho nadpis a uloží soubor:

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

Obecný obsahový zástupný prvek má obvykle [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění prozkoumejte skutečné rozhraní tvaru, abyste zjistili, co obsahuje. Speciální rozložení mohou také vystavit [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/).

Aspose.Slides nepřevádí prázdný [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) zástupný prvek na [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) pouhým změněním [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/); typ nelze změnit přes rozhraní. Pro naplnění prázdného grafu nebo obsahu programově přidejte požadovaný objekt na souřadnice zástupného prvku a poté odstraňte prázdný zástupný prvek. Následující příklad to dělá pro graf:

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

Přidaný graf je běžný lokální graf. Zabírá oblast zástupného prvku, ale nedědí z rozložení. Používejte specializované články o správě grafů [chart management articles](/slides/cs/java/powerpoint-charts/), když potřebujete nahradit kategorie, řady nebo data sešitu.

## **Úplný příklad: Aktualizace textu nebo obrázku**

Následující end-to-end příklad otevře šablonu, vyhledá na prvním snímku buď zástupný prvek nadpisu nebo obrázku, zkontroluje typy zástupného prvku i tvaru, aktualizuje odpovídající obsah a uloží výstup. Příklad úmyslně nepředpokládá index tvaru ani nepřetypovává každý zástupný prvek na stejné rozhraní.

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

**Co je základní (base) zástupný prvek?**

Základní zástupný prvek je odpovídající tvar v rozložení nebo hlavním snímku, ze kterého jiný zástupný prvek dědí. Použijte [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) k jeho získání. Běžný lokální tvar vrací `null`, protože není součástí hierarchie zástupných prvků.

**Mohu změnit všechny nadpisy snímků úpravou zástupného prvku v rozložení?**

Můžete změnit zděděné formátování nebo výzvu pomocí rozložení, ale existující text nadpisu je uložen na běžných snímcích. Pro nahrazení skutečného textu nadpisu v celé prezentaci iterujte přes snímky a aktualizujte každý zástupný prvek nadpisu.

**Jak spravovat zástupné prvky data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí v odpovídajícím rozsahu – snímek, rozložení, hlavní snímek, poznámky nebo výstřižky. Viz [Manage Presentation Header and Footer](/slides/cs/java/presentation-header-and-footer/) pro kompletní příklady.