---
title: Verwalten von Präsentationshintergründen in JavaScript
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/nodejs-java/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- Einfarbige Farbe
- Verlaufsfarbe
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Node.js festlegen, inklusive Code‑Tipps zur Verbesserung Ihrer Präsentationen."
---

## **Übersicht**

Einfarbige Hintergründe, Farbverläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Master‑Folie** (gilt gleichzeitig für mehrere Folien) festlegen.

![PowerPoint‑Hintergrund](powerpoint-background.png)

## **Festlegen eines einfarbigen Hintergrunds für eine normale Folie**

Aspose.Slides ermöglicht es Ihnen, einer bestimmten Folie einer Präsentation einen einfarbigen Hintergrund zuzuweisen – selbst wenn die Präsentation eine Master‑Folie verwendet. Die Änderung wirkt nur auf die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.  
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.  
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) des Folienhintergrunds auf `Solid`.  
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) auf [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe festzulegen.  
5. Speichern Sie die geänderte Präsentation.

Das folgende JavaScript‑Beispiel zeigt, wie Sie für eine normale Folie einen blauen einfarbigen Hintergrund festlegen:
```js
// Erstellen Sie eine Instanz der Presentation-Klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Setzen Sie die Hintergrundfarbe der Folie auf Blau.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Festlegen eines einfarbigen Hintergrunds für die Master‑Folie**

Aspose.Slides ermöglicht es Ihnen, der Master‑Folie einer Präsentation einen einfarbigen Hintergrund zuzuweisen. Die Master‑Folie dient als Vorlage, die die Formatierung aller Folien steuert; wenn Sie also einen einfarbigen Hintergrund für die Master‑Folie wählen, wird er auf jede Folie angewendet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.  
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) der Master‑Folie (via `getMasters`) auf `OwnBackground`.  
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) des Master‑Folienhintergrunds auf `Solid`.  
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) , um die einfarbige Hintergrundfarbe festzulegen.  
5. Speichern Sie die geänderte Präsentation.

Das folgende JavaScript‑Beispiel zeigt, wie Sie für die Master‑Folie eine einfarbige (grüne) Hintergrundfarbe festlegen:
```js
// Eine Instanz der Presentation-Klasse erstellen.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Hintergrundfarbe der Master-Folie auf Waldgrün setzen.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Präsentation auf dem Datenträger speichern.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Festlegen eines Farbverlaufs‑Hintergrunds für eine Folie**

Ein Farbverlauf ist ein grafischer Effekt, der durch einen schrittweisen Farbwechsel entsteht. Als Folienhintergrund können Farbverläufe Präsentationen ein kunstvolles und professionelles Aussehen verleihen. Aspose.Slides ermöglicht es Ihnen, einen Farbverlauf als Hintergrund für Folien zu setzen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.  
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.  
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) des Folienhintergrunds auf `Gradient`.  
4. Verwenden Sie die Methode [getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) auf [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/), um Ihre bevorzugten Verlaufseinstellungen zu konfigurieren.  
5. Speichern Sie die geänderte Präsentation.

Das folgende JavaScript‑Beispiel zeigt, wie Sie für eine Folie einen Farbverlauf‑Hintergrund festlegen:
```js
// Erstellen Sie eine Instanz der Presentation-Klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Wenden Sie einen Farbverlaufseffekt auf den Hintergrund an.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Ein Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlauf‑Füllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergrund.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.  
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.  
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) des Folienhintergrunds auf `Picture`.  
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.  
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.  
6. Verwenden Sie die Methode [getPictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) auf [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.  
7. Speichern Sie die geänderte Präsentation.

Das folgende JavaScript‑Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:
```js
// Erstellen Sie eine Instanz der Presentation-Klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Hintergrundbild-Eigenschaften festlegen.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Bild laden.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Bild zur Bildsammlung der Präsentation hinzufügen.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Präsentation auf dem Datenträger speichern.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Der folgende Code‑Auszug demonstriert, wie Sie den Hintergrund‑Fülltyp auf ein gekacheltes Bild setzen und die Kachel‑Eigenschaften ändern:
```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Legen Sie das Bild fest, das für die Hintergrundfüllung verwendet wird.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Stellen Sie den Bildfüllmodus auf Kachel ein und passen Sie die Kacheleigenschaften an.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}

Mehr erfahren: [**Tile Picture As Texture**](/slides/de/nodejs-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, damit der Inhalt der Folie besser hervorsticht. Der folgende JavaScript‑Code zeigt, wie Sie die Transparenz eines Folien‑Hintergrundbildes ändern:
```js
var transparencyValue = 30; // Zum Beispiel.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **Den Hintergrundwert der Folie abrufen**

Aspose.Slides stellt die Klasse `BackgroundEffectiveData` zur Verfügung, um die effektiven Hintergrundwerte einer Folie abzurufen. Diese Klasse gibt das effektive [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) und [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) zurück.

Über die Methode `getBackground` der Klasse [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende JavaScript‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie abrufen:
```js
// Erstellen Sie eine Instanz der Presentation-Klasse.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Den effektiven Hintergrund abrufen, wobei Master, Layout und Theme berücksichtigt werden.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme‑/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom entsprechenden [Layout](/slides/de/nodejs-java/slide-layout/)/[Master](/slides/de/nodejs-java/slide-master/) (also dem [Theme‑Hintergrund](/slides/de/nodejs-java/presentation-theme/)) übernommen.

**Was passiert mit dem Hintergrund, wenn ich später das Theme der Präsentation ändere?**

Hat eine Folie ihre eigene Füllung, bleibt diese unverändert. Wird der Hintergrund vom [Layout](/slides/de/nodejs-java/slide-layout/)/[Master](/slides/de/nodejs-java/slide-master/) geerbt, wird er an das [neue Theme](/slides/de/nodejs-java/presentation-theme/) angepasst.