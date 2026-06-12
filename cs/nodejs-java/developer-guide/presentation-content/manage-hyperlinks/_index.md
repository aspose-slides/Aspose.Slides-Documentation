---
title: Správa hypertextových odkazů v prezentacích v JavaScriptu
linktitle: Správa hypertextového odkazu
type: docs
weight: 20
url: /cs/nodejs-java/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odebrat hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše spravujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js – zvyšte interaktivitu a efektivitu práce během několika minut."
---
## **Úvod**

Hyperlink je odkaz na objekt, data nebo místo v něčem. Toto jsou běžné hyperlinky v prezentacích PowerPoint:

* Odkazy na webové stránky v textech, tvarech nebo médiích
* Odkazy na snímky

Aspose.Slides pro Node.js prostřednictvím Java vám umožňuje provádět řadu úkolů souvisejících s hypertextovými odkazy v prezentacích.

{{% alert color="primary" %}} 
Možná chcete vyzkoušet jednoduchý, [bezplatný online editor PowerPointu.](https://products.aspose.app/slides/cs/editor)
{{% /alert %}} 

## **Přidávání URL hypertextových odkazů**

### **Přidávání URL hypertextových odkazů do textů**

Tento JavaScriptový kód ukazuje, jak přidat odkaz na webovou stránku do textu:

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

### **Přidávání URL hypertextových odkazů do tvarů nebo rámců**

Tento ukázkový kód v JavaScriptu ukazuje, jak přidat odkaz na webovou stránku do tvaru:

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

### **Přidávání URL hypertextových odkazů do multimédií**

Aspose.Slides vám umožňuje přidávat hypertextové odkazy na obrázky, audio a video soubory. 

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **obrázek**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá obrázek do prezentace
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Vytvoří rám obrazu na snímku 1 na základě dříve přidaného obrázku
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

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **audio soubor**:

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

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **video**:

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
Možná chcete vidět *[Správa OLE](/slides/cs/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Použití hypertextových odkazů k vytvoření obsahu**

Protože hypertextové odkazy vám umožňují přidávat odkazy na objekty nebo místa, můžete je použít k vytvoření obsahu.

Tento ukázkový kód ukazuje, jak vytvořit obsah s hypertextovými odkazy:

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

## **Formátování hypertextových odkazů**

### **Barva**

Pomocí metody [setColorSource](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) ve třídě [Hyperlink](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink) můžete nastavit barvu hypertextových odkazů a také získat informace o barvě z odkazů. Tato funkce byla poprvé představena v PowerPointu 2019, takže změny týkající se této vlastnosti se nevztahují na starší verze PowerPointu.

Tento ukázkový kód demonstruje operaci, při které byly do stejného snímku přidány hypertextové odkazy s různými barvami:

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

## **Odstraňování hypertextových odkazů v prezentacích**

### **Odstraňování hypertextových odkazů z textů**

Tento JavaScriptový kód ukazuje, jak odstranit hypertextový odkaz z textu na snímku prezentace:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Kontroluje, zda tvar podporuje textový rám (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Prochází odstavce v textovém rámci
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Prochází každou část v odstavci
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Mění text
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Mění formátování
                    }
                }
            }
        }
    }
    // Uloží upravenou prezentaci
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Odstraňování hypertextových odkazů z tvarů nebo rámců**

Tento JavaScriptový kód ukazuje, jak odstranit hypertextový odkaz z tvaru na snímku prezentace:

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

## **Měnný hypertextový odkaz**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink) je měnná. Pomocí této třídy můžete měnit hodnoty následujících vlastností:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Ukázkový kód ukazuje, jak přidat hypertextový odkaz na snímek a později upravit jeho popisek:

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

## **Podporované vlastnosti v IHyperlinkQueries**

Můžete získat přístup k [HyperlinkQueries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries) z prezentace, snímku nebo textu, pro který je hypertextový odkaz definován.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

Třída [HyperlinkQueries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries) podporuje následující metody a vlastnosti:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **Často kladené otázky**

**Jak mohu vytvořit interní navigaci nejen na snímek, ale i na „sekci“ nebo první snímek sekce?**

Sekce v PowerPointu jsou seskupení snímků; navigace technicky cílí na konkrétní snímek. Pro „přechod do sekce“ obvykle odkazujete na její první snímek.

**Mohu připojit hypertextový odkaz k prvkům hlavního snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního (master) snímku a rozložení podporují hypertextové odkazy. Tyto odkazy se zobrazí na podřízených snímcích a jsou klikatelné během prezentace.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

V [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/) ano — odkazy se obecně zachovají. Při exportu do [obrázků](/slides/cs/nodejs-java/convert-powerpoint-to-png/) a [videí](/slides/cs/nodejs-java/convert-powerpoint-to-video/) klikatelnost nepřetrvá kvůli povaze těchto formátů (rasterové snímky/video nepodporují hypertextové odkazy).