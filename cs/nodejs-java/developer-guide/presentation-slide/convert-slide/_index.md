---
title: Převod prezentace snímků na obrázky v JavaScriptu
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/nodejs-java/convert-slide/
keywords:
- převést snímek
- exportovat snímek
- snímek na obrázek
- uložit snímek jako obrázek
- snímek na EMF
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- snímek na TIFF
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte snímky z prezentací PPT, PPTX a ODP do PNG, JPEG, GIF, TIFF, EMF a dalších formátů obrázků v JavaScriptu pomocí Aspose.Slides."
---
## **Úvod**

Aspose.Slides pro Node.js přes Java dokáže vykreslovat jednotlivé snímky z prezentací PowerPoint a OpenDocument jako PNG, JPEG, GIF, TIFF a další formáty obrázků.

Pro převod snímku na obrázek postupujte podle následujících kroků:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Vyberte snímek, který chcete vykreslit.
3. V případě potřeby nakonfigurujte vykreslování pomocí třídy [RenderingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/).
4. Zavolejte metodu [Slide.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage). Vrátí objekt typu [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/).
5. Zavolejte metodu [IImage.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/#save) a určete výstupní formát pomocí hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imageformat/).

## **Převod snímku na PNG obrázek**

Nejjednodušší převod používá výchozí nastavení vykreslování. Výsledný objekt [IImage] lze zpracovat v paměti nebo uložit do souboru.

Následující JavaScriptový příklad vykreslí první snímek a uloží jej jako PNG obrázek:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Převod snímků na obrázky s vlastními rozměry**

Použijte přetíženou metodu [Slide.getImage], která akceptuje hodnotu `java.awt.Dimension`, pro vykreslení snímku s přesnými rozměry v pixelech.

Následující příklad vytvoří JPEG obrázek 1820 × 1040 pixelů:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Ve výchozím nastavení obrázky snímků neobsahují poznámky ani komentáře. Předávejte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/) metodě [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), abyste určili, kde se poznámky a komentáře zobrazí.

Následující příklad umístí zkrácené poznámky pod snímek a komentáře vpravo od něj:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Varování" color="warning" %}}
Při převodu snímků na obrázky nepředávejte [BottomFull](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notespositions/) metodě [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Poznámky mohou obsahovat více textu, než je možné zobrazit v pevně dané velikosti obrázku. Použijte místo toho [BottomTruncated](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notespositions/).
{{% /alert %}}

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) umožňuje řídit velikost, rozlišení a další vlastnosti vykresleného TIFF obrázku.

Následující příklad vykreslí první snímek jako TIFF obrázek 2160 × 2880 pixelů při 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Varování" color="warning" %}}
Podpora TIFF není zaručena ve verzích Javy starších než JDK 9.
{{% /alert %}}

## **Převod všech snímků na obrázky**

Procházejte kolekci snímků a převádějte celou prezentaci na řadu obrázků. Skryté snímky jsou zahrnuty, pokud je explicitně nevynecháte.

Následující příklad vykreslí každý snímek jako JPEG obrázek se horizontálním a vertikálním měřítkem 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Vytvoření výstupu Enhanced Metafile**

Enhanced Metafile (EMF) je užitečný, když je potřeba vyměňovat vektorovou grafiku s Microsoft Office nebo jinými Windows aplikacemi podporujícími Windows metafily. Na rozdíl od rastrového obrázku může EMF zachovat vektorové kreslicí operace, které se škálují bez ztráty ostrosti. EMF však slouží především jako formát kompatibility pro aplikace s podporou Windows metafilů, nikoli jako univerzální výměnný formát. Navíc složitý obsah snímku, jako jsou bitmapové obrázky a některé efekty, může být uložen jako rasterizované prvky uvnitř vektorového kontejneru.

### **Exportovat snímek do EMF**

Metoda [Slide.writeAsEmf](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#writeAsEmf) zapíše snímek do cílového proudu ve formátu EMF. Následující příklad načte prezentaci, vybere první snímek a zapíše jej do EMF souborového proudu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Volající vlastní proud předaný metodě [Slide.writeAsEmf](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#writeAsEmf) a je zodpovědný za jeho uzavření, jak je ukázáno výše.

### **Převést SVG obrázek do EMF a přidat jej do prezentace**

Použijte [SvgImage.writeAsEmf](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/#writeAsEmf) k převodu SVG obsahu do EMF. Výsledná bajtová data lze přidat do prezentace pomocí [ImageCollection.addImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/#addImage) a umístit na snímek pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

Následující příklad vytvoří [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/) ze SVG značkování, převádí jej do paměťového EMF, vloží metafil na první snímek a uloží prezentaci:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/#writeAsEmf) nepřebírá vlastnictví cílového proudu. `java.io.ByteArrayOutputStream` ukládá veškerá generovaná data v paměti, takže před voláním `toByteArray` není nutné resetovat pozici. Vrácené pole bajtů zůstává platné i po uzavření proudu.

Generování EMF je k dispozici na operačních systémech podporovaných vybranou verzí Aspose.Slides pro Node.js přes Java a konfigurací JDK, avšak vykreslování může mezi platformami lišit, pokud chybí písma nebo grafické závislosti. Nainstalujte písma používaná ve zdrojovém obsahu nebo nakonfigurujte vhodné náhrady, řiďte se [požadavky na platformu](/slides/cs/nodejs-java/system-requirements/) pro Aspose.Slides pro Node.js přes Java a ověřte výsledek v cílové aplikaci konzumující EMF. Linuxové a macOS aplikace často mají omezenou nebo nekonzistentní podporu pro zobrazování a úpravu Windows metafilů.

## **Vykreslování barevných emoji**

{{% alert title="Poznámka" color="info" %}}
Aby se při převodu snímků prezentace na obrázky správně vykreslily barevné emoji, musí být nainstalována a dostupná emoji písma použité v prezentaci na systému, který převod provádí. Například pokud prezentace používá **Segoe UI Emoji** a toto písmo chybí, mohou se emoji ve výstupních obrázcích zobrazit černobíle.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne. Metoda [Slide.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage) vykresluje statický obrázek snímku a neexportuje animace.

**Lze skryté snímky exportovat jako obrázky?**

Ano. Skryté snímky lze vykreslit stejně jako běžné snímky. Zahrňte je do zpracovatelského cyklu, jak je ukázáno v předchozím příkladu.

**Zachovají se stíny a další efekty v obrázcích snímků?**

Ano. Aspose.Slides vykresluje stíny, průhlednost a další podporované grafické efekty v obrázcích snímků.