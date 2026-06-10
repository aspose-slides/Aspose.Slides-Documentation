---
title: "JavaScript-ben a prezentáció hiperhivatkozásainak kezelése"
linktitle: "Hiperhivatkozás kezelése"
type: docs
weight: 20
url: /hu/nodejs-java/manage-hyperlinks/
keywords:
- "URL hozzáadása"
- "hiperhivatkozás hozzáadása"
- "hiperhivatkozás létrehozása"
- "hiperhivatkozás formázása"
- "hiperhivatkozás eltávolítása"
- "hiperhivatkozás frissítése"
- "szöveges hiperhivatkozás"
- "dia hiperhivatkozás"
- "alakzat hiperhivatkozás"
- "kép hiperhivatkozás"
- "videó hiperhivatkozás"
- "módosítható hiperhivatkozás"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Könnyedén kezelheti a hiperhivatkozásokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js segítségével — fokozza az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy hivatkozás egy objektumra, adatra vagy egy helyre valamiben. Ezek a gyakori hiperhivatkozások PowerPoint prezentációkban:

* Weboldalakra mutató hivatkozások szövegekben, alakzatokban vagy médiában
* Diahivatkozások

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy számos, a hiperhivatkozásokkal kapcsolatos feladatot végezzen a prezentációkban.

{{% alert color="primary" %}} 
Érdemes megnézni az Aspose egyszerű, [ingyenes online PowerPoint szerkesztőt.](https://products.aspose.app/slides/hu/editor)
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

### **URL hiperhivatkozások hozzáadása szövegekhez**

Ez a JavaScript kód megmutatja, hogyan lehet egy weboldal hiperhivatkozást hozzáadni egy szöveghez:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **URL hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a JavaScript minta-kód megmutatja, hogyan lehet egy weboldal hiperhivatkozást hozzáadni egy alakzathoz:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **URL hiperhivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi hiperhivatkozások hozzáadását képekhez, hangfájlokhoz és videófájlokhoz. 

Ez a minta-kód megmutatja, hogyan lehet hiperhivatkozást hozzáadni egy **képre**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Képet ad a prezentációhoz
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Képkeret létrehozása az 1. dián a korábban hozzáadott kép alapján
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ez a minta-kód megmutatja, hogyan lehet hiperhivatkozást hozzáadni egy **hangfájlhoz**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ez a minta-kód megmutatja, hogyan lehet hiperhivatkozást hozzáadni egy **videóhoz**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
Érdemes megnézni a *[OLE kezelése](/slides/hu/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik objektumokra vagy helyekre való hivatkozás hozzáadását, használhatók tartalomjegyzék létrehozására. 

Ez a minta-kód megmutatja, hogyan lehet hiperhivatkozásokkal tartalomjegyzéket létrehozni:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hiperhivatkozások formázása**

### **Szín**

A [setColorSource](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) metódussal a [Hyperlink](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink) osztályban beállíthatja a hiperhivatkozások színét, és lekérheti a színinformációt a hiperhivatkozásokból is. Ez a funkció először a PowerPoint 2019-ben került bevezetésre, így a tulajdonság változásai nem vonatkoznak a régebbi PowerPoint verziókra.

Ez a minta-kód egy olyan műveletet mutat be, ahol különböző színű hiperhivatkozásokat adtak hozzá ugyanahhoz a diához:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hiperhivatkozások eltávolítása prezentációkban**

### **Hiperhivatkozások eltávolítása szövegekből**

Ez a JavaScript kód megmutatja, hogyan lehet eltávolítani a hiperhivatkozást egy szövegből egy prezentációs dián:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Ellenőrzi, hogy a forma támogatja-e a szövegkeretet (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Átiterál a szövegkeret bekezdésein
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Átiterál a bekezdés minden részletén
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Módosítja a szöveget
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Módosítja a formázást
                    }
                }
            }
        }
    }
    // Mentés a módosított prezentáció
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Ez a JavaScript kód megmutatja, hogyan lehet eltávolítani a hiperhivatkozást egy alakzatról egy prezentációs dián:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Módosítható hiperhivatkozás**

A [Hyperlink](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink) osztály módosítható. Ezzel az osztállyal megváltoztathatja az alábbi tulajdonságok értéit:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Ez a kódrészlet megmutatja, hogyan lehet hiperhivatkozást hozzáadni egy diához, majd később szerkeszteni a tooltipjét:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Támogatott tulajdonságok az IHyperlinkQueries-ben**

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries) objektumot elérheti egy prezentációból, diáiból vagy szövegből, amelyhez a hiperhivatkozás van definiálva.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries) osztály támogatja az alábbi metódusokat és tulajdonságokat:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy „szekcióra” vagy egy szekció első diájára?**

A PowerPoint szekciók a diák csoportosításai; a navigáció technikailag egy konkrét diára mutat. A „szekcióra navigáláshoz” általában az első diájára kell hivatkozni.

**Csatolhatok-e hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezési elemek támogatják a hiperhivatkozásokat. Az ilyen hivatkozások megjelennek a gyerek diákon, és a diavetítés során kattinthatóak.

**Megmaradnak-e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) és a [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/) esetében igen – a hivatkozások általában megmaradnak. A [képek](/slides/hu/nodejs-java/convert-powerpoint-to-png/) és a [videó](/slides/hu/nodejs-java/convert-powerpoint-to-video/) exportálásakor a kattinthatóság nem marad meg a formátumok jellegéből adódóan (a raszteres képkockák/videó nem támogatja a hiperhivatkozásokat).