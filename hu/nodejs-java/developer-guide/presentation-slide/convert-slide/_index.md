---
title: Prezentációs diák képekké konvertálása JavaScriptben
linktitle: Dia képpé
type: docs
weight: 35
url: /hu/nodejs-java/convert-slide/
keywords:
- dia konvertálása
- dia exportálása
- dia képpé
- dia mentése képként
- dia EMF-be
- dia PNG-be
- dia JPEG-be
- dia bitmapként
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP prezentációk diáját PNG, JPEG, GIF, TIFF, EMF és egyéb képtípusokra JavaScriptben az Aspose.Slides segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java képes egyedi diák renderelésére PowerPoint és OpenDocument prezentációkból PNG, JPEG, GIF, TIFF és más képtípusok formájában.

A dia képbe történő konvertálásához kövesse az alábbi lépéseket:

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztállyal.
2. Válassza ki a renderelni kívánt diát.
3. Szükség esetén állítsa be a renderelést a [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztállyal.
4. Hívja meg a [Slide.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) metódust. Ez egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) objektumot ad vissza.
5. Hívja meg az [IImage.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/#save) metódust, és az [ImageFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imageformat/) értékkel adja meg a kimeneti formátumot.

## **Dia konvertálása PNG képpé**

A legegyszerűbb konvertálás az alapértelmezett renderelési beállításokat használja. A kapott [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) objektum feldolgozható memóriában vagy menthető fájlba.

Az alábbi JavaScript példa rendereli az első diát, és PNG képként menti:

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

## **Diák konvertálása képekké egyedi méretekkel**

Használja a [Slide.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) túlterhelést, amely egy `java.awt.Dimension` értéket fogad el, hogy a diát pontos képpontmérettel renderelje.

Az alábbi példa egy 1820 × 1040 JPEG képet hoz létre:

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

## **Diák konvertálása képekké megjegyzésekkel és kommentárokkal**

Alapértelmezés szerint a diaképek nem tartalmazzák a megjegyzéseket vagy a kommentárokat. Adjon át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/) objektumot a [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) metódusnak, hogy meghatározza, hol jelenjenek meg a jegyzetek és a kommentárok.

Az alábbi példa a csonkított jegyzeteket a dia alá, a kommentárokat pedig jobbra helyezi:

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

{{% alert title="Warning" color="warning" %}}
Dia-képre konvertálás során ne adja át a [BottomFull](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notespositions/) értéket a [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metódusnak. A jegyzetek több szöveget is tartalmazhatnak, mint amit a fix képméret befogad. Ehelyett használja a [BottomTruncated](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notespositions/) értéket.
{{% /alert %}}

## **Diák konvertálása képekké TIFF beállítások használatával**

A [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztály lehetővé teszi a renderelt TIFF kép méretének, felbontásának és egyéb jellemzőinek szabályozását.

Az alábbi példa az első diát 2160 × 2880 TIFF képként, 300 DPI felbontással rendereli:

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

{{% alert title="Warning" color="warning" %}}
A TIFF támogatás nem garantált a JDK 9-nél korábbi Java verziókban.
{{% /alert %}}

## **Az összes dia konvertálása képekké**

Iteráljon a diákkollekción a teljes prezentáció képsorozattá konvertálásához. A rejtett diák is belekerülnek, hacsak kifejezetten nem hagyja ki őket.

Az alábbi példa minden diát JPEG képként renderel, vízszintes és függőleges méretezési tényezőkkel 2-vel:

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

## **Enhanced Metafile kimenet létrehozása**

Az Enhanced Metafile (EMF) akkor hasznos, ha vektoralapú grafikákat kell cserélni a Microsoft Office-szal vagy más Windows-alkalmazásokkal, amelyek támogatják a Windows metafájlokat. A pixel alapú képtől eltérően egy EMF megőrizheti a vektoros rajzolási műveleteket, amelyek méretezve a tisztaságot nem veszíti el. Az EMF azonban elsősorban a Windows metafájlokat támogató alkalmazások kompatibilitási formátuma, nem univerzális csereformátum. Továbbá a komplex diáktartalom, például bitmap képek és egyes hatások, raszterelemként tárolhatók a vektoros metafájl konténerben.

### **Dia exportálása EMF-be**

A [Slide.writeAsEmf](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#writeAsEmf) metódus egy diát ír egy célnyújtóba EMF formátumban. Az alábbi példa betölt egy prezentációt, kiválasztja az első diát, és egy EMF fájl streambe írja:

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

A hívó sajátja a [Slide.writeAsEmf](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#writeAsEmf) metódusnak átadott streamet, és felelős a lezárásáért, ahogy fentebb látható.

### **SVG képet konvertálni EMF-be és hozzáadni egy prezentációhoz**

Használja a [SvgImage.writeAsEmf](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/#writeAsEmf) metódust az SVG tartalom EMF-be konvertálásához. A kapott bájtok hozzáadhatók a prezentációhoz a [ImageCollection.addImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagecollection/#addImage) segítségével, és egy diára helyezhetők a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) segítségével.

Az alábbi példa létrehoz egy [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) objektumot SVG markupból, memóriában EMF-re konvertálja, beilleszti a metafájlt az első diára, és menti a prezentációt:

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

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/#writeAsEmf) nem veszi át a cél stream tulajdonjogát. A `java.io.ByteArrayOutputStream` az összes előállított adatot memóriában tárolja, így a `toByteArray` hívása előtt nincs szükség a pozíció visszaállítására. A visszaadott bájt tömb érvényes marad a stream lezárása után.

Az EMF generálás elérhető az Aspose.Slides for Node.js via Java és a JDK beállítások által támogatott operációs rendszereken, de a renderelés platformonként eltérhet, ha betűtípusok vagy grafikus függőségek nem állnak rendelkezésre. Telepítse a forrás tartalom által használt betűtípusokat vagy állítson be megfelelő helyettesítéseket, kövesse a [platform követelményeket](/slides/hu/nodejs-java/system-requirements/) az Aspose.Slides for Node.js via Java számára, és ellenőrizze az eredményt a cél EMF-fogyasztó alkalmazásban. A Linux és macOS alkalmazások gyakran korlátozott vagy nem konzisztens támogatást nyújtanak a Windows metafájlok megjelenítésére és szerkesztésére.

## **Színes Emoji renderelés**

{{% alert title="Note" color="info" %}}
Ahhoz, hogy a színes emoji-k helyesen jelenjenek meg a prezentációs diák képpé konvertálásakor, a prezentációban használt emoji betűtípusoknak telepítve kell lenniük és elérhetőknek kell lenniük a konvertálást végző rendszerben. Például, ha a prezentáció **Segoe UI Emoji** betűtípust használ, és ez hiányzik, akkor az emoji-k monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **FAQ**

**Támogatja-e az Aspose.Slides az animációval rendelkező diák renderelését?**

Nem. A [Slide.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) metódus egy statikus képet renderel a diáról, és nem exportálja az animációkat.

**Exportálhatók-e a rejtett diák képek formájában?**

Igen. A rejtett diák úgy renderelhetők, mint a normál diák. Vegye fel őket a feldolgozási ciklusba, ahogy a fenti példában látható.

**Megmaradnak-e az árnyékok és egyéb hatások a diaképeken?**

Igen. Az Aspose.Slides árnyékokat, átlátszóságot és egyéb, a képekben támogatott grafikai hatásokat renderel.