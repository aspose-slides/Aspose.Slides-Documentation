---
title: Gestisci i collegamenti ipertestuali della presentazione in JavaScript
linktitle: Gestisci collegamento ipertestuale
type: docs
weight: 20
url: /it/nodejs-java/manage-hyperlinks/
keywords:
- aggiungi URL
- aggiungi collegamento ipertestuale
- crea collegamento ipertestuale
- formatta collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- collegamento ipertestuale nel testo
- collegamento ipertestuale alla diapositiva
- collegamento ipertestuale alla forma
- collegamento ipertestuale all'immagine
- collegamento ipertestuale al video
- collegamento ipertestuale mutabile
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci facilmente i collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js—migliora l'interattività e il flusso di lavoro in pochi minuti."
---
## **Introduzione**

Un collegamento ipertestuale è un riferimento a un oggetto, a dati o a un luogo in qualcosa. Questi sono collegamenti ipertestuali comuni nelle presentazioni PowerPoint:

* Collegamenti a siti web all'interno di testi, forme o media
* Collegamenti a diapositive

Aspose.Slides per Node.js via Java consente di eseguire molte operazioni relative ai collegamenti ipertestuali nelle presentazioni.

{{% alert color="primary" %}} 
Potresti voler provare il semplice editor online gratuito di Aspose, [editor PowerPoint online gratuito.](https://products.aspose.app/slides/it/editor)
{{% /alert %}} 

## **Aggiungere collegamenti ipertestuali URL**

### **Aggiungere collegamenti ipertestuali URL a testi**

Questo codice JavaScript mostra come aggiungere un collegamento ipertestuale a un sito web a un testo:
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

### **Aggiungere collegamenti ipertestuali URL a forme o riquadri**

Questo esempio di codice in JavaScript mostra come aggiungere un collegamento ipertestuale a un sito web a una forma:
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

### **Aggiungere collegamenti ipertestuali URL a media**

Aspose.Slides consente di aggiungere collegamenti ipertestuali a immagini, audio e file video. 

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un **immagine**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Aggiunge immagine alla presentazione
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Crea un frame immagine sulla diapositiva 1 basato sull'immagine precedentemente aggiunta
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

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un **file audio**:
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

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un **video**:
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
Potresti voler vedere *[Gestisci OLE](/slides/it/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Utilizzare i collegamenti ipertestuali per creare un indice**

Poiché i collegamenti ipertestuali consentono di aggiungere riferimenti a oggetti o luoghi, è possibile usarli per creare un indice. 

Questo esempio di codice mostra come creare un indice con collegamenti ipertestuali:
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

## **Formattazione dei collegamenti ipertestuali**

### **Colore**

Con il metodo [setColorSource](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) nella classe [Hyperlink](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Hyperlink), è possibile impostare il colore per i collegamenti ipertestuali e anche ottenere le informazioni sul colore dai collegamenti ipertestuali. La funzionalità è stata introdotta per la prima volta in PowerPoint 2019, quindi le modifiche relative alla proprietà non si applicano alle versioni più vecchie di PowerPoint.

Questo esempio di codice dimostra un'operazione in cui sono stati aggiunti collegamenti ipertestuali con colori diversi alla stessa diapositiva:
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

## **Rimozione dei collegamenti ipertestuali nelle presentazioni**

### **Rimuovere i collegamenti ipertestuali dai testi**

Questo codice JavaScript mostra come rimuovere il collegamento ipertestuale da un testo in una diapositiva della presentazione:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Verifica se la forma supporta il frame di testo (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Itera attraverso i paragrafi nel frame di testo
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Itera attraverso ogni porzione nel paragrafo
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Modifica il testo
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Modifica la formattazione
                    }
                }
            }
        }
    }
    // Salva la presentazione modificata
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Rimuovere i collegamenti ipertestuali da forme o riquadri**

Questo codice JavaScript mostra come rimuovere il collegamento ipertestuale da una forma in una diapositiva della presentazione:
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

## **Collegamento ipertestuale mutabile**

La classe [Hyperlink](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Hyperlink) è mutabile. Con questa classe è possibile modificare i valori di queste proprietà:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Questo frammento di codice mostra come aggiungere un collegamento ipertestuale a una diapositiva e modificare in seguito il suo suggerimento:
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

## **Proprietà supportate in IHyperlinkQueries**

È possibile accedere a [HyperlinkQueries](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/HyperlinkQueries) da una presentazione, diapositiva o testo per cui è definito il collegamento ipertestuale.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

La classe [HyperlinkQueries](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/HyperlinkQueries) supporta questi metodi e proprietà:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Come posso creare una navigazione interna non solo a una diapositiva, ma a una "sezione" o alla prima diapositiva di una sezione?**

Le sezioni in PowerPoint sono raggruppamenti di diapositive; la navigazione tecnicamente punta a una diapositiva specifica. Per "navigare a una sezione", di solito si collega alla sua prima diapositiva.

**Posso collegare un collegamento ipertestuale agli elementi del master slide in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi della diapositiva master e del layout supportano i collegamenti ipertestuali. Questi collegamenti appaiono sulle diapositive figlie e sono cliccabili durante la presentazione.

**I collegamenti ipertestuali verranno preservati durante l'esportazione in PDF, HTML, immagini o video?**

Nelle [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/) e [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/), sì—i collegamenti sono generalmente preservati. Quando si esporta in [immagini](/slides/it/nodejs-java/convert-powerpoint-to-png/) e [video](/slides/it/nodejs-java/convert-powerpoint-to-video/), la capacità di fare clic non verrà mantenuta a causa della natura di quei formati (i fotogrammi raster/video non supportano collegamenti ipertestuali).