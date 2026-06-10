---
title: PowerPoint-diák konvertálása PNG-re JavaScript-ben
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-re
- PPTX exportálása PNG-re
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PowerPoint-prezentációkat magas minőségű PNG képekké JavaScript-ben gyorsan az Aspose.Slides for Node.js használatával, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint-prezentációkat PNG-képekké konvertálni az Aspose.Slides használatával. Megmutatja, hogyan lehet PPT, PPTX és ODP formátumú prezentációfájlokat betölteni, a diák képként megjeleníteni, és az eredményeket PNG formátumban menteni.  
A cikk azt is bemutatja, hogyan lehet testre szabni a generált PNG-képeket skálázási értékek beállításával vagy a kívánt szélesség és magasság megadásával.

## **PowerPoint konvertálása PNG-be**

Kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályt.
2. Szerezze be a diaobjektumot a [Presentation.getSlides()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) metódus által visszaadott gyűjteményből a [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Slide) osztály alatt.
3. Használja a [Slide.getImage()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Slide) metódust az egyes diák bélyegképének lekéréséhez.
4. Használja a [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/#save) metódust a dia bélyegképének PNG formátumban történő mentéséhez.

Ez a JavaScript-kód megmutatja, hogyan lehet egy PowerPoint-prezentációt PNG-be konvertálni:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint konvertálása PNG-be egyéni méretekkel**

Ha egy meghatározott méretarány körüli PNG-fájlokat szeretne, beállíthatja a `desiredX` és `desiredY` értékeket, amelyek meghatározzák a keletkező bélyegkép méreteit.  

Ez a JavaScript-kód bemutatja a leírt műveletet:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint konvertálása PNG-be egyéni mérettel**

Ha egy meghatározott méret körüli PNG-fájlokat szeretne, átadhatja a kívánt `width` és `height` argumentumokat a `ImageSize` számára.  

Ez a kód megmutatja, hogyan lehet egy PowerPoint-ot PNG-be konvertálni, miközben megadja a képek méretét:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Hogyan exportálhatok csak egy adott alakzatot (például diagramot vagy képet) a teljes dia helyett?**  
Az Aspose.Slides támogatja az [egyedi alakzatok bélyegképeinek generálását](/slides/hu/nodejs-java/create-shape-thumbnails/); egy alakzatot PNG-képbe renderelhet.

**Támogatott a párhuzamos konvertálás a szerveren?**  
Igen, de [ne ossza meg](/slides/hu/nodejs-java/multithreading/) egyetlen prezentációpéldányt a szálak között. Használjon külön példányt szálanként vagy folyamatként.

**Mik a próbaverzió korlátozásai PNG-exportálás esetén?**  
A kiértékelési módban vízjelet helyeznek el a kimeneti képeken, és [egyéb korlátozásokat](/slides/hu/nodejs-java/licensing/) alkalmaznak, amíg licencet nem adnak meg.