---
title: Správa placeholderů prezentace v JavaScriptu
linktitle: Spravovat placeholdery
type: docs
weight: 10
url: /cs/nodejs-java/manage-placeholder/
keywords:
- placeholder
- textový placeholder
- obrázkový placeholder
- placeholder grafu
- placeholder obsahu
- text výzvy
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak zkontrolovat a upravit textové, obrázkové, grafové a obsahové placeholdery a pochopit dědičnost placeholderů s Aspose.Slides pro Node.js pomocí Javy."
---
## **Přehled**

Placeholder je tvar, který rezervuje pozici pro konkrétní typ obsahu v šabloně prezentace. Běžnými příklady jsou nadpis, tělo, obrázek, graf a obecné placeholdery pro obsah. Na rozdíl od běžného tvaru může placeholder dědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides zpřístupňuje informace o placeholderu pomocí metody [Shape.getPlaceholder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getPlaceholder). Metoda vrací objekt [Placeholder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholder/) nebo `null` pro běžný tvar. K určení, co je placeholder určen k obsahu, použijte [Placeholder.getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholder/#getType).

Třída tvaru má i po zjištění typu placeholderu význam:

- Prázdný textový, obrázkový, grafový nebo obsahový placeholder je běžně reprezentován pomocí [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).
- Vyplněný obrázkový placeholder může být reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/).
- Vyplněný grafový placeholder může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/).
- Obsahový placeholder může obsahovat několik typů obsahu. Zkontrolujte jak [Placeholder.getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholder/#getType), tak runtime třídu tvaru místo předpokladu, že každý placeholder je [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholder/#getType) popisuje roli placeholderu; nezaručuje runtime typ tvaru. Vždy proveďte kontrolu typu před přístupem k textovým, obrázkovým, grafovým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Pochopení dědičnosti placeholderů**

Placeholdery tvoří hierarchii:

1. Hlavní snímek (master slide) definuje znovupoužitelné styly a v některých případech placeholdery na úrovni master.
2. Rozložení snímku (layout slide) určuje uspořádání použité jedním nebo více normálními snímky a může dědit z hlavního snímku.
3. Normální snímek obsahuje placeholdery pro daný snímek a může dědit ze svého rozložení.

Pro posun o úroveň výš v hierarchii zavolejte [Shape.getBasePlaceholder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getBasePlaceholder). Placeholder snímku obvykle vrací svůj placeholder rozložení; placeholder rozložení může vrátit svůj master placeholder. Metoda vrací `null`, pokud tvar nemá základní placeholder.

Následující příklad vypíše placeholdery na prvním snímku a zobrazí jejich základní placeholdery:

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

Úprava placeholderu na normálním snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozložení nebo masteru může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální běžný tvar nemá základní placeholder a nezačne dědit jen proto, že sdílí stejné souřadnice.

## **Změna textu v placeholderu**

Nadpis, střední nadpis, podtitul, tělo a textové placeholdery běžně podporují text. Před použitím metody [getTextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/#getTextFrame) ověřte, že se jedná o [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).

Tento příklad aktualizuje první placeholder nadpisu na prvním snímku a uloží výsledek:

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

Tento vzor se vyhýbá zacházení s obrázkovými, grafovými, tabulkovými nebo mediálními placeholdery jako s objekty [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/). Identifikuje placeholder podle účelu místo spolehnutí se na křehký index tvaru.

## **Nastavení výzvy (prompt) na rozložení**

Výzva (prompt) je instrukce zobrazená v prázdném placeholderu během návrhu, např. *Click to add title*. Nastavte vlastní výzvu na placeholderu rozložení místo pokusu o dosažení přes kolekci tvarů normálního snímku. Přístup k rozložení získáte pomocí [Slide.getLayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getLayoutSlide) a iterujte přes kolekci vrácenou metodou [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getShapes).

Následující příklad mění výzvy nadpisu a podtitulku na rozložení použitém prvním snímkem:

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

Výzva není obvyklý obsah snímku. Je určena pro prázdné placeholdery v editovacích aplikacích, jako je PowerPoint. Jakmile uživatel nebo program poskytne skutečný obsah, výzva už není zobrazena. Změna výzvy také nevymazává existující text na snímcích, které rozložení používají.

## **Aktualizace obrázkového placeholderu**

Existují dva scénáře:

- Pokud je obrázkový placeholder již vyplněn a reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/), nahraďte obrázek pomocí [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#getPicture) a [Picture.setImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/#setImage).
- Pokud je stále prázdný placeholder, přidejte obrázkový rám na souřadnice placeholderu pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) a odstraňte prázdný placeholder.

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

Nahrazení vytvořené pro prázdný placeholder je lokální obrázkový rám, ne nový placeholder, protože [Shape.getPlaceholder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getPlaceholder) neposkytuje setter. Zachovává rezervovanou pozici, ale již nedědí chování specifické pro placeholder. Pokud je udržení vztahu placeholderu podstatné, připravte a naplňte placeholder v PowerPointu nejprve, pak aktualizujte vzniklý [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) pomocí Aspose.Slides.

Pro průhlednost, ořez a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/nodejs-java/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, ne k metadatům placeholderu.

## **Práce s grafovými a obsahovými placeholdery**

Vyplněný grafový placeholder může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/). Tento příklad najde takový graf podle typu placeholderu i runtime třídy, změní jeho nadpis a uloží soubor:

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

Obecný obsahový placeholder obvykle má [PlaceholderType.Object](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholdertype/#Object). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po naplnění zkontrolujte skutečnou třídu tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také vystavovat [PlaceholderType.Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholdertype/#Media) nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides nepřevádí prázdný placeholder [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/) pouhým změněním [Placeholder.getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholder/#getType); typ nelze změnit přes objekt. Pro naplnění prázdné oblasti grafu nebo obsahu programově přidejte požadovaný objekt na souřadnice placeholderu a poté odstraňte prázdný placeholder. Následující příklad to provádí pro graf:

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

Přidaný graf je obyčejný lokální graf. Zabírá oblast placeholderu, ale nedědí z placeholderu rozložení. Použijte věnované [články o správě grafů](/slides/cs/nodejs-java/powerpoint-charts/), když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textového nebo obrázkového obsahu**

Následující end‑to‑end příklad otevře šablonu, vyhledá na prvním snímku buď nadpisový, nebo obrázkový placeholder, zkontroluje typy placeholderu a tvaru, aktualizuje příslušný obsah a uloží výstup. Příklad úmyslně nepředpokládá index tvaru ani nezpracovává každý placeholder jako stejnou třídu.

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

**Co je základní (base) placeholder?**

Základní placeholder je odpovídající tvar na rozložení nebo masteru, ze kterého jiný placeholder dědí. K jeho získání použijte [Shape.getBasePlaceholder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getBasePlaceholder). Běžný lokální tvar vrací `null`, protože není součástí hierarchie placeholderů.

**Mohu změnit všechny nadpisy snímků úpravou placeholderu v rozložení?**

Můžete změnit děděné formátování nebo text výzvy přes rozložení, ale existující obsah nadpisu je uložen na normálních snímcích. Pro nahrazení skutečného textu nadpisu napříč prezentací iterujte přes snímky a aktualizujte každý nadpisový placeholder.

**Jak spravovat placeholdery pro datum, číslo snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí v příslušném rozsahu – snímek, rozložení, master, poznámky nebo podklady. Viz [Manage Presentation Header and Footer](/slides/cs/nodejs-java/presentation-header-and-footer/) pro kompletní příklady.