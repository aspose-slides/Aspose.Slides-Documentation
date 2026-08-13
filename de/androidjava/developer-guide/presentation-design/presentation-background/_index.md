---
title: Präsentationshintergründe auf Android verwalten
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
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Android über Java festlegen, mit Code‑Tipps zur Verbesserung Ihrer Präsentationen."
---
## **Einführung**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung wirkt nur auf die ausgewählte Folie.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/filltype/) auf `Solid`.
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) von [FillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/) , um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende Java‑Beispiel zeigt, wie man eine blaue einfarbige Farbe als Hintergrund für eine normale Folie festlegt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Setze die Hintergrundfarbe der Folie auf Blau.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Speichere die Präsentation auf der Festplatte.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Einfarbigen Hintergrund für eine Masterfolie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Farbe als Hintergrund für die Masterfolie in einer Präsentation. Die Masterfolie dient als Vorlage, die die Formatierung für alle Folien steuert, sodass beim Auswählen einer einfarbigen Hintergrundfarbe für die Masterfolie dieser Hintergrund auf jeder Folie angewendet wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/backgroundtype/) der Masterfolie (über `getMasters`) auf `OwnBackground`.
3. Setzen Sie den Hintergrund-[FillType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/filltype/) der Masterfolie auf `Solid`.
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) , um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende Java‑Beispiel zeigt, wie man eine einfarbige (grüne) Farbe als Hintergrund für eine Masterfolie festlegt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Setze die Hintergrundfarbe für die Masterfolie auf Grün.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Speichere die Präsentation auf der Festplatte.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verlaufs‑Hintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch einen allmählichen Farbwechsel entsteht. Als Folienhintergrund eingesetzt, können Verläufe Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht das Festlegen einer Verlaufsfarbe als Hintergrund für Folien.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/filltype/) auf `Gradient`.
4. Verwenden Sie die Methode [getGradientFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) von [FillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/) , um Ihre bevorzugten Verlaufs‑Einstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende Java‑Beispiel zeigt, wie man eine Verlauffarbe als Hintergrund für eine Folie festlegt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Wende einen Verlaufseffekt auf den Hintergrund an.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Füge die Verlaufsfarben hinzu. Ohne Verlaufsstopps fällt der Hintergrund auf eine Standard-Schwarz-zu-weiß-Rampe zurück.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Speichere die Präsentation auf der Festplatte.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlauf‑Füllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergründe.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/filltype/) auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Methode [getPictureFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) von [FillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/) , um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende Java‑Beispiel zeigt, wie man ein Bild als Hintergrund für eine Folie festlegt:

```java
import com.aspose.slides.*;

// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Setze Bildhintergrund-Eigenschaften.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Lade das Bild.
    IImage image = Images.fromFile("Tulips.jpg");
    // Füge das Bild zur Bildsammlung der Präsentation hinzu.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Speichere die Präsentation auf der Festplatte.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das folgende Code‑Beispiel zeigt, wie man den Hintergrund‑Fülltyp auf ein gekacheltes Bild setzt und die Kachel‑Eigenschaften anpasst:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Setze das für die Hintergrundfüllung verwendete Bild.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Setze den Bildfüllmodus auf Kachel und passe die Kacheleigenschaften an.
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

{{% alert color="info" %}}
Mehr lesen: [**Kachelbild als Textur**](/slides/de/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Vielleicht möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, damit der Inhalt der Folie besser hervorsticht. Der folgende Java‑Code zeigt, wie Sie die Transparenz eines Folien‑Hintergrundbildes ändern können:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Zum Beispiel.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hole die Sammlung von Bild-Transformationsoperationen.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Finde einen vorhandenen Transparenzeffekt mit fester Prozentzahl.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Setze den neuen Transparenzwert.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wert des Folienhintergrunds abrufen**

Aspose.Slides stellt das Interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibackgroundeffectivedata/) zur Verfügung, um die effektiven Hintergrundwerte einer Folie abzurufen. Dieses Interface gibt das effektive [FillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) und [EffectFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) frei.

Mit der `getBackground`‑Methode der Klasse [BaseSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende Java‑Beispiel zeigt, wie man den effektiven Hintergrundwert einer Folie abruft:

```java
import com.aspose.slides.*;

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

### Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme-/Layout‑Hintergrund wiederherstellen?

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom entsprechenden [Layout](/slides/de/androidjava/slide-layout/)/[Master](/slides/de/androidjava/slide-master/) (d. h. dem [Theme‑Hintergrund](/slides/de/androidjava/presentation-theme/)) übernommen.

### Was passiert mit dem Hintergrund, wenn ich das Theme der Präsentation später ändere?

Wenn eine Folie ihre eigene Füllung hat, bleibt sie unverändert. Wenn der Hintergrund vom [Layout](/slides/de/androidjava/slide-layout/)/[Master](/slides/de/androidjava/slide-master/) geerbt wird, wird er aktualisiert, um dem [neuen Theme](/slides/de/androidjava/presentation-theme/) zu entsprechen.