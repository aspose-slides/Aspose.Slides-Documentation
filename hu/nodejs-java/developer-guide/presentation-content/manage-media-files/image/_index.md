---
title: Képek kezelésének optimalizálása a bemutatókban JavaScript használatával
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/nodejs-java/image/
keywords:
  - kép hozzáadása
  - kép hozzáadása
  - bitmap hozzáadása
  - kép cseréje
  - kép cseréje
  - webről
  - háttér
  - PNG hozzáadása
  - JPG hozzáadása
  - SVG hozzáadása
  - EMF hozzáadása
  - WMF hozzáadása
  - TIFF hozzáadása
  - PowerPoint
  - OpenDocument
  - bemutató
  - EMF
  - SVG
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Hatékonyítsa a képek kezelését PowerPointban és OpenDocumentben JavaScript és az Aspose.Slides for Node.js segítségével, optimalizálva a teljesítményt és automatizálva a munkafolyamatot."
---
## **Bevezetés**

A képek érdekesebbé és lebilincselőbbé teszik a bemutatókat. A Microsoft PowerPointban képeket illeszthetsz be egy fájlból, az internetről vagy más helyekről a diákra. Hasonlóan, az Aspose.Slides lehetővé teszi képek hozzáadását a bemutatók diáihoz különböző eljárásokon keresztül. 

{{% alert  title="Tipp" color="primary" %}} 

Az Aspose ingyenes konvertereket biztosít—[JPEG PowerPointba](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG PowerPointba](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik a felhasználók számára, hogy gyorsan készítsenek bemutatókat képekből. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Ha képet szeretnél keretobjektumként hozzáadni – különösen, ha szabványos formázási lehetőségeket szeretnél használni a méretének módosításához, effektek hozzáadásához stb. – lásd a [Képkeret](https://docs.aspose.com/slides/hu/nodejs-java/picture-frame/). 

{{% /alert %}} 

Az Aspose.Slides támogatja a képekkel végzett műveleteket ezekben a népszerű formátumokban: JPEG, PNG, GIF és egyebek. 

## **Helyi módon tárolt képek hozzáadása a diákhoz**

A számítógépeden található egy vagy több képet hozzáadhatod a bemutató egy diájához. Ez a JavaScript példakód bemutatja, hogyan lehet képet hozzáadni egy diához:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Képek hozzáadása az adatfolyamról a diákhoz**

Ha a diára felvenni kívánt kép nem érhető el a számítógépeden, közvetlenül a webből adhatod hozzá.

Ez a példakód megmutatja, hogyan lehet képet a webről egy diára hozzáadni JavaScriptben:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Betölti az Excel fájlt adatfolyamra
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Létrehozza a beágyazáshoz szükséges adatobjektumot
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Ole objektumkeret alakzatot ad hozzá
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // A PPTX fájlt lemezre írja
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Képek hozzáadása a diamesterekhez**

A diamester a felső dia, amely tárolja és szabályozza az alatta lévő összes dia (téma, elrendezés stb.) információit. Így ha képet adsz hozzá egy diamesterhez, az a kép megjelenik minden alatta lévő dián.

Ez a JavaScript példakód bemutatja, hogyan lehet képet hozzáadni egy diamesterhez:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Képek hozzáadása diák háttérként**

Előfordulhat, hogy egy vagy több dia háttérként egy képet szeretnél használni. Ebben az esetben lásd a *[Képek beállítása diák háttérképeként](https://docs.aspose.com/slides/hu/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG hozzáadása a bemutatókhoz**

Bármilyen képet hozzáadhatsz vagy beilleszthetsz egy bemutatóba a [addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) metódus használatával, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) osztályhoz tartozik.

Egy SVG kép alapján képtárgyat a következő módon hozhatsz létre:

1. Hozz létre SvgImage objektumot, hogy beszúrhasd az ImageShapeCollection-be
2. Hozz létre PPImage objektumot az ISvgImage-ből
3. Hozz létre PictureFrame objektumot a PPImage osztály használatával

Ez a példakód bemutatja, hogyan valósíthatod meg a fenti lépéseket egy SVG kép bemutatóba való hozzáadásához:
```javascript
// PPTX fájlt képviselő Presentation osztály példányosítása
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SVG konvertálása alakzatkészletre**

Az Aspose.Slides SVG‑t alakzatkészletre konvertáló funkciója hasonló a PowerPoint SVG‑képekkel való munkához:

![PowerPoint Popup Menu](img_01_01.png)

A funkciót a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) osztály [addGroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) metódusának egyik túlterhelése biztosítja, amely az első argumentumként egy [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SvgImage) objektumot várja.

Ez a példakód megmutatja, hogyan használhatod a leírt metódust egy SVG fájl alakzatkészletté konvertálásához:

```javascript
    // Új bemutató létrehozása
    var presentation = new aspose.slides.Presentation();
    try {
        // SVG fájl tartalmának beolvasása
        var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
        // SvgImage objektum létrehozása
        var svgImage = new aspose.slides.SvgImage(svgContent);
        // Dia méretének lekérése
        var slideSize = presentation.getSlideSize().getSize();
        // SVG képet alakzategységgé konvertálás a dia méretére méretezve
        presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
        // Bemutató mentése PPTX formátumban
        presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (e) {console.log(e);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```

## **Képek hozzáadása EMF‑ként a diákba**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy Excel munkalapokból EMF képeket generálj, és azokat EMF‑ként a diákba add az Aspose.Cells segítségével. 

Ez a példakód megmutatja, hogyan hajtható végre a leírt feladat:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// A munkafüzet mentése adatfolyamra
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Képek cseréje a képgyűjteményben**

Az Aspose.Slides lehetővé teszi a bemutató képgyűjteményében (beleértve a diaalakzatok által használtakat) tárolt képek cseréjét. Ez a szakasz több megközelítést mutat be a gyűjtemény képeinek frissítéséhez. Az API egyszerű módszereket biztosít egy kép cseréjére nyers bájt adatok, egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) példány vagy egy már meglévő kép használatával.

1. Töltsd be a képeket tartalmazó bemutatófájlt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály segítségével.
2. Tölts be egy új képet egy fájlból egy bájt tömbbe.
3. Cseréld le a célképet az új képre a bájt tömb használatával.
4. A második megközelítésben töltsd be a képet egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) objektumba, és cseréld le a célképet ezzel az objektummal.
5. A harmadik megközelítésben cseréld le a célképet egy olyan képre, amely már létezik a bemutató képgyűjteményében.
6. Írd ki a módosított bemutatót PPTX fájlként.

```js
// A Presentation osztály példányosítása, amely egy bemutató fájlt képvisel.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Az első mód.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // A második mód.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // A harmadik mód.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // A bemutató mentése fájlba.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Az Aspose INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterrel könnyedén animálhatsz szövegeket, GIF‑eket hozhatsz létre szövegekből stb. 

{{% /alert %}}

## **Gyakran ismételt kérdések**

**Megmarad az eredeti kép felbontása a beszúrás után?**

Igen. A forrás pixeljei megmaradnak, de a végső megjelenés attól függ, hogy a [picture](/slides/hu/nodejs-java/picture-frame/) hogyan van méretezve a dián és milyen tömörítés van alkalmazva mentéskor.

**Mi a legjobb módja annak, hogy egyszerre cseréljünk ki egy logót több tucat dián?**

Helyezd el a logót a mesterdiára vagy egy elrendezésre, és cseréld ki a bemutató képgyűjteményében – a frissítések minden olyan elemre átterjednek, amely ezt az erőforrást használja.

**Átalakítható-e a beillesztett SVG szerkeszthető alakzatokká?**

Igen. Az SVG-t átalakíthatod egy alakzategységgé, amelynek egyes részei ezután a szokásos alakzattulajdonságokkal szerkeszthetők.

**Hogyan állíthatok be egy képet egyszerre több dia háttérképeként?**

[Állítsd be a képet háttérként](/slides/hu/nodejs-java/presentation-background/) a mesterdián vagy a megfelelő elrendezésen – minden, az adott mester/ elrendezés használó dia örökölni fogja a hátteret.

**Hogyan előzhetem meg, hogy a bemutató a sok kép miatt „felrobbanjon” méretben?**

Használj egyetlen képforrást duplikátumok helyett, válassz ésszerű felbontásokat, alkalmazz tömörítést mentéskor, és a gyakran előforduló grafikákat a mesterben tartsd, ahol szükséges.