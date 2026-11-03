---
title: Správa zástupných prvků prezentace v JavaScriptu
linktitle: Správa zástupných prvků
type: docs
weight: 10
url: /cs/nodejs-java/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrázkový zástupný prvek
- grafický zástupný prvek
- obsahový zástupný prvek
- výzva textu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak prohlížet a upravovat textové, obrázkové, grafické a obsahové zástupné prvky a pochopit dědění zástupných prvků pomocí Aspose.Slides pro Node.js v Java."
---
## **Přehled**

Zástupný prvek je tvar, který vyhrazuje pozici pro určitý typ obsahu v šabloně prezentace. Běžnými příklady jsou titul, tělo, obrázek, graf a obecné zástupné prvky obsahu. Na rozdíl od běžného tvaru může zástupný prvek zdědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo z hlavního snímku.

Aspose.Slides poskytuje informace o zástupném prvku prostřednictvím metody [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). Metoda vrací objekt [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) nebo `null` pro běžný tvar. Použijte [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) k určení, co má zástupný prvek obsahovat.

Třída tvaru je stále důležitá po zjištění typu zástupného prvku:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný prvek je běžně zastoupen pomocí [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Vyplněný obrázkový zástupný prvek může být reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Vyplněný grafický zástupný prvek může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Obsahový zástupný prvek může obsahovat několik druhů obsahu. Zkontrolujte jak [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType), tak runtime třídu tvaru, místo abyste předpokládali, že každý zástupný prvek je [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) popisuje roli zástupného prvku; nezaručuje runtime typ tvaru. Vždy použijte kontrolu typu před přístupem k textu, obrázku, grafu, tabulce nebo mediálním členům.
{{% /alert %}}

## **Porozumět dědění zástupných prvků**

Zástupné prvky tvoří hierarchii:

1. Hlavní snímek definuje opakovaně použitelné styly a v některých případech i zástupné prvky na úrovni hlavního snímku.
2. Rozložení snímku definuje uspořádání použité jedním nebo více běžnými snímky a může dědit z hlavního snímku.
3. Běžný snímek obsahuje zástupné prvky pro tento snímek a může dědit ze svého rozložení.

Voláním [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) se posunete o úroveň výše v této hierarchii. Zástupný prvek snímku normálně vrací svůj zástupný prvek rozložení; zástupný prvek rozložení může vracet svůj zástupný prvek hlavního snímku. Metoda vrací `null`, pokud tvar nemá základní zástupný prvek.

Následující příklad vypisuje zástupné prvky na prvním snímku a uvádí jejich základní zástupné prvky:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Úprava zástupného prvku na běžném snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozložení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální běžný tvar nemá základní zástupný prvek a nezačne dědit jen proto, že zabírá stejné souřadnice.

## **Odstranit stav zástupného prvku**

Při úpravě šablony použijte [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder), abyste zachovali existující objekt jako běžný tvar. Jeho metoda [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) vrátí `null`, ale tvar zůstane ve sbírce snímku. Na rozdíl od toho [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) smaže tvar z této sbírky.

Následující příklad vyžaduje soubor `template.pptx` s alespoň jedním snímkem a neprázdným textovým zástupným prvkem na prvním snímku. Použijte zástupný prvek s formátováním zděděným z jeho rozložení nebo hlavního snímku, abyste viděli efekt odstranění vztahu. Příklad kontroluje, že stejný tvar zůstává, znovu volá metodu na nyní běžném tvaru a výsledek uloží.

{{% alert color="warning" title="Warning" %}}
Odstranění stavu zástupného prvku automaticky neuchovává zděděná nastavení vzhledu. Níže uvedený příklad úmyslně zachovává tato nastavení nezměněná, takže výstup může vypadat odlišně. Tvar, jehož pozice a velikost jsou zcela zděděny, může po volání mít nulové souřadnice a rozměry a stát se neviditelným, i když zůstane ve sbírce.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Volání metody na běžném tvaru nemá žádný efekt.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Pro odpovídající zástupný prvek všechny tři kontroly vrátí `true`. Text zůstane, ale zděděná pozice, velikost, rotace, font, zarovnání odstavců, okraje textového rámečku, vertikální ukotvení, výplň a nastavení čáry se mohou změnit, když je vztah zástupného prvku odstraněn. Například zděděné formátování nadpisu může přejít na běžné formátování textu. Viz [Slide Layout](/slides/cs/nodejs-java/slide-layout/) pro více informací o rozloženích.

Pro zachování požadovaného vzhledu zachyťte vypočítanou pozici, velikost a rotaci před voláním a zkopírujte požadované efektivní hodnoty formátování do samostatných proměnných. Tyto hodnoty získáte pomocí [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) a [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Nespoléhejte se pouze na objekty efektivního formátu, protože jejich hodnoty textového formátování se po odstranění vztahu mohou změnit. Poté explicitně přiřaďte zachycené hodnoty běžnému tvaru, včetně rodiny fontu, velikosti, stylu, barvy, nastavení odstavců, nastavení textového rámečku, výplně a čáry použité ve vaší šabloně.

Zděděná geometrie tvaru může také vyžadovat explicitní nastavení pomocí [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). Pro obdélníkový textový zástupný prvek to znamená přiřadit [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); obnovování pouhé výplně a čáry nemusí obnovit viditelný obdélník. Šablony s dalšími efekty nebo složitějším formátováním vyžadují, aby tato nastavení byla také zpracována.

## **Změna textu ve zástupném prvku**

Titulek, centrovaný titulek, podtitul, tělo a textové zástupné prvky obvykle podporují text. Před použitím metody [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) zkontrolujte, zda se jedná o [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

Tento příklad aktualizuje první titulekový zástupný prvek na prvním snímku a uloží výsledek:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tento postup zabraňuje zacházení s obrázkovými, grafovými, tabulkovými nebo mediálními zástupci jako s objekty [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/). také identifikuje zástupný prvek podle účelu místo spoléhat na křehký index tvaru.

## **Nastavit výzvu textu v rozložení**

Výzva textu je návrhová instrukce zobrazovaná v prázdném zástupném prvku, například *Klikněte pro přidání názvu*. Nastavte vlastní výzvu v zástupném prvku rozložení místo toho, abyste se snažili dosáhnout na něj přes kolekci tvarů běžného snímku. Přistupte k rozložení pomocí [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) a iterujte přes kolekci vrácenou metodou [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

Následující příklad mění výzvy pro titulek a podtitul v rozložení použitém na prvním snímku:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výzva textu není běžný obsah snímku. Je určena pro prázdné zástupné prvky v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program poskytne skutečný obsah, výzva již není zobrazena. Změna výzvy také neprovede nahrazení existujícího textu na snímcích, které rozložení používají.

## **Aktualizovat obrázkový zástupný prvek**

Existují dva případy, které je třeba ošetřit:

- Pokud je obrázkový zástupný prvek již vyplněn a je reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), nahraďte obrázek pomocí [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) a [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Pokud je stále prázdným zástupným prvkem, přidejte obrázkový rámec na souřadnice zástupného prvku pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) a odstraňte prázdný zástupný prvek.

Další příklad podporuje oba případy a uloží prezentaci:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nahrazení vytvořené pro prázdný zástupný prvek je lokální obrázkový rámec, ne nový zástupný prvek, protože [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) nemá setter. Zachovává vyhrazenou pozici, ale již nezdědí chování specifické pro zástupný prvek. Pokud je zachování vztahu zástupného prvku podstatné, připravte a vyplňte zástupný prvek v PowerPointu nejprve, poté aktualizujte vzniklý [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořez a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/nodejs-java/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, nikoli k metadatům zástupného prvku.

## **Práce s grafovými a obsahovými zástupnými prvky**

Vyplněný grafový zástupný prvek může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Tento příklad najde takový graf podle typu zástupného prvku i runtime třídy, změní jeho titulek a uloží soubor:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obecný obsahový zástupný prvek obvykle má typ [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění prozkoumejte skutečnou třídu tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také vystavit typy [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides nepřevádí prázdný [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) zástupný prvek na [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) pouhým změněním [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); typ nelze změnit skrze objekt. Pro naplnění prázdného grafu nebo obsahové oblasti programově přidejte požadovaný objekt na souřadnice zástupného prvku a poté odstraňte prázdný zástupný prvek. Následující příklad to provádí pro graf:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přidaný graf je běžný lokální graf. Zaujímá oblast zástupného prvku, ale nezdědí z rozložení. Použijte specializované články o správě grafů [chart management articles](/slides/cs/nodejs-java/powerpoint-charts/), když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizovat text nebo obsah obrázku**

Následující end‑to‑end příklad otevře šablonu, vyhledá na prvním snímku buď titulekový, nebo obrázkový zástupný prvek, zkontroluje typy zástupného prvku i tvaru, aktualizuje příslušný obsah a uloží výstup. Příklad úmyslně nepředpokládá index tvaru ani nezhodnocuje každý zástupný prvek jako stejnou třídu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Co je základní zástupný prvek?**

Základní zástupný prvek je odpovídající tvar v rozložení nebo hlavním snímku, ze kterého jiný zástupný prvek dědí. Použijte [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) k jeho získání. Běžný lokální tvar vrací `null`, protože není součástí hierarchie zástupných prvků.

**Mohu změnit všechny titulky snímků úpravou zástupného prvku v rozložení?**

Můžete změnit zděděné formátování nebo výzvu textu přes rozložení, ale existující titulek je uložen na běžných snímcích. Pro nahrazení skutečného textu titulku v celé prezentaci iterujte přes snímky a aktualizujte každý titulekový zástupný prvek.

**Jak spravovat zástupné prvky data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na příslušné úrovni snímku, rozložení, hlavního snímku, poznámek nebo výstřižků. Viz [Manage Presentation Header and Footer](/slides/cs/nodejs-java/presentation-header-and-footer/) pro úplné příklady.