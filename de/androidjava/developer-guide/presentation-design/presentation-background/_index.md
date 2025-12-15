---
title: Verwalten von Präsentationshintergründen auf Android
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/androidjava/presentation-background/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mithilfe von Aspose.Slides für Android in Java festlegen, mit Code-Tipps zur Verbesserung Ihrer Präsentationen."
---

## **Übersicht**

Einfarbige Farben, Farbverläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt gleichzeitig für mehrere Folien) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung wirkt sich nur auf die ausgewählte Folie aus.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) auf `Solid`.
4. Verwenden Sie die [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) Methode auf [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

```java
// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Setze die Hintergrundfarbe der Folie auf Blau.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Speichere die Präsentation auf dem Datenträger.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Einfarbigen Hintergrund für eine Masterfolie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für die Masterfolie in einer Präsentation festzulegen. Die Masterfolie fungiert als Vorlage, die die Formatierung aller Folien steuert. Wenn Sie also eine einfarbige Hintergrundfarbe für die Masterfolie wählen, wird sie auf jede Folie angewendet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) der Masterfolie (via `getMasters`) auf `OwnBackground`.
3. Setzen Sie den Masterfolienhintergrund [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) auf `Solid`.
4. Verwenden Sie die [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) Methode, um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

```java
// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Setze die Hintergrundfarbe der Masterfolie auf Waldgrün.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Speichere die Präsentation auf dem Datenträger.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Farbverlauf‑Hintergrund für eine Folie festlegen**

Ein Farbverlauf ist ein grafischer Effekt, der durch einen allmählichen Farbwechsel entsteht. Als Folienhintergrund eingesetzt, können Farbverläufe Präsentationen künstlerischer und professioneller erscheinen lassen. Aspose.Slides ermöglicht es Ihnen, eine Verlauf‑Farbe als Hintergrund für Folien festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) auf `Gradient`.
4. Verwenden Sie die [getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) Methode auf [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/), um Ihre gewünschten Verlaufseinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

```java
// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Wende einen Verlaufseffekt auf den Hintergrund an.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Speichere die Präsentation auf dem Datenträger.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Ein Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlauf‑Füllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergründe.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die [getPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) Methode auf [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

```java
// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Setze die Hintergrundbild-Eigenschaften.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Lade das Bild.
    IImage image = Images.fromFile("Tulips.jpg");
    // Füge das Bild zur Bildsammlung der Präsentation hinzu.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Speichere die Präsentation auf dem Datenträger.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Das für die Hintergrundfüllung verwendete Bild festlegen.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Bildfüllmodus auf Kachel setzen und die Kacheleigenschaften anpassen.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
Mehr erfahren: [**Kachelbild als Textur**](/slides/de/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Sie möchten eventuell die Transparenz des Hintergrundbildes einer Folie anpassen, damit der Inhalt der Folie besser hervorsticht. Der folgende Java‑Code zeigt, wie Sie die Transparenz eines Folienhintergrundbildes ändern können:
```java
int transparencyValue = 30; // Zum Beispiel.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **Wert des Folienhintergrunds abrufen**

Aspose.Slides stellt das Interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/) zur Verfügung, um die effektiven Hintergrundwerte einer Folie abzurufen. Dieses Interface gibt den effektiven [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) und [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) zurück.

Verwenden Sie die `getBackground`‑Methode der Klasse [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/), um den effektiven Hintergrund einer Folie zu erhalten.

```java
// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rufe den effektiven Hintergrund ab, wobei Master, Layout und Theme berücksichtigt werden.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme-/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom zugehörigen [Layout](/slides/de/androidjava/slide-layout/)/[Master](/slides/de/androidjava/slide-master/) übernommen (also vom [Theme‑Hintergrund](/slides/de/androidjava/presentation-theme/)).

**Was passiert mit dem Hintergrund, wenn ich das Theme der Präsentation später ändere?**

Hat eine Folie ihre eigene Füllung, bleibt diese unverändert. Wird der Hintergrund vom [Layout](/slides/de/androidjava/slide-layout/)/[Master](/slides/de/androidjava/slide-master/) geerbt, wird er an das neue Theme angepasst.