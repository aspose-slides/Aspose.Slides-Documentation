---
title: Präsentationshintergründe in Java verwalten
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/java/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- einfarbige Farbe
- Verlaufsfarbe
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Java festlegen, inklusive Code-Tipps zur Optimierung Ihrer Präsentationen."
---
## **Einleitung**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Feste Farbfüllung für eine normale Folie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Hintergrundfarbe für eine bestimmte Folie in einer Präsentation – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung wirkt nur auf die ausgewählte Folie.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/java/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) auf `Solid` .
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/#getSolidFillColor--) von [FillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/) , um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende Java-Beispiel zeigt, wie Sie eine blaue einfarbige Hintergrundfarbe für eine normale Folie festlegen:

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
    
    // Speichere die Präsentation auf dem Laufwerk.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Feste Farbfüllung für eine Masterfolie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Hintergrundfarbe für die Masterfolie in einer Präsentation. Die Masterfolie dient als Vorlage, die die Formatierung aller Folien steuert, sodass beim Auswählen einer einfarbigen Hintergrundfarbe für die Masterfolie diese auf jede Folie angewendet wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/java/com.aspose.slides/backgroundtype/) der Masterfolie (via `getMasters`) auf `OwnBackground` .
3. Setzen Sie den Masterfolien-Hintergrund [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) auf `Solid` .
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/#getSolidFillColor--) , um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende Java-Beispiel zeigt, wie Sie eine einfarbige (grüne) Hintergrundfarbe für eine Masterfolie festlegen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Setze die Hintergrundfarbe der Masterfolie auf Grün.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Speichere die Präsentation auf dem Laufwerk.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verlaufshintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch einen allmählichen Farbwechsel entsteht. Als Folienhintergrund können Verläufe Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht das Festlegen einer Verlauffarbe als Hintergrund für Folien.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/java/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) auf `Gradient` .
4. Verwenden Sie die Methode [getGradientFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/#getGradientFormat--) von [FillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/) , um Ihre bevorzugten Verlaufeinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende Java-Beispiel zeigt, wie Sie eine Verlauffarbe als Hintergrund für eine Folie festlegen:

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

    // Füge die Verlauffarben hinzu. Ohne Verlaufspunkte fällt der Hintergrund auf eine standardmäßige Schwarz-zu-Weiß-Stufe zurück.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Speichere die Präsentation auf dem Laufwerk.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und verlaufenden Füllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergründe.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/java/com.aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) auf `Picture` .
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Methode [getPictureFillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/#getPictureFillFormat--) von [FillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/) , um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende Java-Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```java
import com.aspose.slides.*;

// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hintergrundbild-Eigenschaften festlegen.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Bild laden.
    IImage image = Images.fromFile("Tulips.jpg");
    // Bild zur Bildsammlung der Präsentation hinzufügen.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Präsentation auf dem Laufwerk speichern.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das folgende Codebeispiel zeigt, wie Sie den Hintergrundfülltyp auf ein gekacheltes Bild setzen und die Kachel‑Eigenschaften ändern:

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

    // Das Bild festlegen, das für die Hintergrundfüllung verwendet wird.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Bildfüllmodus auf Kachel setzen und die Kachel‑Eigenschaften anpassen.
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
Mehr erfahren: [**Kachelbild als Textur**](/slides/de/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, um den Inhalt der Folie stärker hervorzuheben. Der folgende Java‑Code zeigt, wie Sie die Transparenz für ein Folien‑Hintergrundbild ändern:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Zum Beispiel.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Erhalte die Sammlung der Bild-Transformationsoperationen.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Finde einen vorhandenen Transparenzeffekt mit festem Prozentsatz.
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hintergrundwert der Folie abrufen**

Aspose.Slides stellt das Interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibackgroundeffectivedata/) zum Abrufen der effektiven Hintergrundwerte einer Folie bereit. Dieses Interface stellt das effektive [FillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) und [EffectFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) zur Verfügung.

Mit der `getBackground`‑Methode der Klasse [BaseSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende Java‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie abfragen:

```java
import com.aspose.slides.*;

// Erstelle eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rufe den effektiven Hintergrund ab, wobei Master-, Layout- und Theme-Informationen berücksichtigt werden.
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

### Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme‑/Layout‑Hintergrund wiederherstellen?

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom zugehörigen [Layout](/slides/de/java/slide-layout/)/[Master](/slides/de/java/slide-master/) übernommen (d. h. vom [Theme‑Hintergrund](/slides/de/java/presentation-theme/)).

### Was passiert mit dem Hintergrund, wenn ich später das Theme der Präsentation ändere?

Hat eine Folie ihre eigene Füllung, bleibt diese unverändert. Wird der Hintergrund vom [Layout](/slides/de/java/slide-layout/)/[Master](/slides/de/java/slide-master/) geerbt, wird er an das neue Theme angepasst.