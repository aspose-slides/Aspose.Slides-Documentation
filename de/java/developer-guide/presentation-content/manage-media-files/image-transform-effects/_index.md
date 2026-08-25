---
title: Verwalten von Bildtransformations‑Effekten in Präsentationen mit Java
linktitle: Bildtransformations‑Effekte
type: docs
weight: 11
url: /de/java/image-transform-effects/
keywords:
- Bildtransformation
- Bildeffekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Farbton
- HSL
- Farbersatz
- Unschärfe
- Transparenz
- Alpha‑Effekt
- Effektkette
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Bildtransformations‑Effekte für Bildrahmen mit Aspose.Slides für Java anwenden, verketten, inspizieren, entfernen und überprüfen."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformationsoperationen dar. Für einen Bildrahmen beginnen Sie mit dem [ISlidesPicture](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidespicture/) und greifen über [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidespicture/#getImageTransform--) zu. Die zurückgegebene [IImageTransformOperationCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Leeren von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen kompletten Arbeitsablauf für Helligkeit und Kontrast, Farbumwandlungen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, Entfernen und die PPTX‑Rundreise‑Verifizierung.

## **Verstehen Sie den Effektbesitz und die Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) speichert oder referenziert die Quellbilddaten, die der Präsentation gehören.
- [ISlidesPicture](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidespicture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformationssammlung speichert.
- [IPictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und weitere Rahmen‑Formatierungen besitzt.

Daher ändern Bildtransformationsoperationen nicht die Bytes in [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/). Wenn dasselbe `IPPImage` mehr als einmal an [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `ISlidesPicture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht graustufig, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Das gleiche `ISlidesPicture.getImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, beispielsweise von einer Form‑ oder Folienhintergrund‑Füllung. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden Sie gültige Parameterbereiche und Einheiten**

Die gezeigten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden ungültigen Wert ablehnt; das Ziel‑Präsentationsformat kann bei Speicherung oder beim Öffnen in PowerPoint normalisieren, weglassen oder ungültige Daten ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [addDuotoneEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle in `java.awt.Color` verwenden Werte von `0` bis `255`. |
| [addTintEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Farbton ist `0` inkl. bis `360` excl., in Grad; Menge ist `-100` bis `100`, Prozent. |
| [addHSLEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Farbton ist `0` inkl. bis `360` excl., in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [addBlurEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius ist nicht‑negativ und wird in Punkten gemessen; `grow` ist ein Boolean, der steuert, ob verwischter Inhalt außerhalb der ursprünglichen Begrenzungen ausdehnen darf. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nicht‑negatives Prozent. Verwenden Sie `0` bis `100` für gewöhnliche Deckkraftskalierung: `0` ist vollständig transparent und `100` erhält das bestehende Alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` bis `100`, Prozent‑Deckkraft. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwellwert. Werte darunter werden transparent; Werte gleich oder darüber werden undurchsichtig. |

Für feste Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Beispiel: 35 % Transparenz entsprechen einem Alpha‑Modulationswert von 65 %.

## **Helligkeit und Kontrast anwenden**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) liefert eine [IBrightnessContrast](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibrightnesscontrast/)‑Operation. Ihre skalaren Einstellungen werden beim Erzeugen der Operation übergeben. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) gibt berechnete, schreibgeschützte Werte zurück, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 % und rendert anschließend eine Vorschau, ohne das eingebettete Bild zu verändern:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/de/java/com.aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Bildeffekt‑Erweiterung und weniger portabel als der standardmäßige DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einem PPTX‑Rundtrip editierbar bleiben sollen, verwenden Sie [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) und prüfen Sie das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt zu Formatbeschränkungen erklärt diesen Unterschied genauer.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig voneinander auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erzeugt fünf Rahmen und wendet Graustufen, Duotone, Farbton, HSL‑Anpassung und Farbersatz an.

[IDuotone](https://reference.aspose.com/slides/de/java/com.aspose.slides/iduotone/) enthält zwei unabhängig editierbare Farbparameter: `color1` mappt dunkle Pixel, während `color2` helle Pixel mappt. Das macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) ersetzt die Farbe jedes Pixels durch eine feste Farbe und bewahrt dabei den Alpha‑Wert. Es unterscheidet sich von [addColorChangeEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), das eine Quellfarbe auf eine Ziel­farbe abbildet und sowohl Quell‑ als auch Ziel­farbformate offenlegt.

## **Unschärfe, Transparenz und Alpha‑Effekte hinzufügen**

[addBlurEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) beeinflusst alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `true`, wenn die verwischte Kante über die ursprünglichen Bildgrenzen hinausgehen kann.

Für einheitliche Transparenz verwenden Sie [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Es multipliziert jeden vorhandenen Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) weist hingegen allen Pixeln einen einheitlichen Alpha‑Wert zu. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) konvertiert Alpha in zwei Stufen basierend auf einem Schwellenwert.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere parameter‑freie Alpha‑Operationen umfassen [addAlphaCeilingEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) (macht jedes nicht‑null Alpha vollständig undurchsichtig), [addAlphaFloorEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) (macht jedes Alpha unter 100 % vollständig transparent) und [addAlphaInverseEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) (setzt Alpha zu `100% - alpha`).

## **Eine geordnete Effektkette aufbauen**

Jede `add...Effect`‑Methode fügt eine neue Operation am Ende der Sammlung hinzu. Der Renderer verwendet die Sammlung als geordnete Pipeline: Der Ausgang von Operation 0 wird zum Eingang von Operation 1 usw. Daher kann dieselbe Menge von Operationen in anderer Reihenfolge ein unterschiedliches Bild erzeugen.

Beispiel: Graustufen gefolgt von Farbton entfernen zuerst chromatische Informationen und färben dann das Luminanz‑Ergebnis ein. Farbton gefolgt von Graustufen entfernt den Farbton wieder. Ebenso kann Alpha‑Ersetzen Alpha‑Werte überschreiben, die durch frühere Operationen berechnet wurden, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geöffnete Ergebnis:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Far‑, Alpha‑ und Unschärfe‑Operationen auf getrennte Ketten beschränkt. Sie können kombiniert werden, aber Kombinationen sind nicht immer sinnvoll. Ein fester Farbersatz entfernt RGB‑Variationen, die durch frühere Farbeffekte erzeugt wurden; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling,‑Floor,‑Replace oder‑BiLevel können Alpha‑Details verwerfen, die zuvor erzeugt wurden. Bauen Sie die Kette nach der gewünschten Pixel‑Verarbeitungsreihenfolge auf, nicht nach ungeordneten Formatierungs‑Flags.

## **Editierbare und effektive Werte inspizieren**

Eine editierbare Operation ist das Objekt, das in `ISlidesPicture.getImageTransform` gespeichert ist. Je nach Effekt kann es direkt beschreibbare Mitglieder offenlegen. Beispielsweise offenlegt [IBlur](https://reference.aspose.com/slides/de/java/com.aspose.slides/iblur/) die beschreibbaren `radius`‑ und `grow`‑Werte, [IAlphaModulateFixed](https://reference.aspose.com/slides/de/java/com.aspose.slides/ialphamodulatefixed/) einen beschreibbaren `amount` und [IAlphaBiLevel](https://reference.aspose.com/slides/de/java/com.aspose.slides/ialphabilevel/) einen beschreibbaren `threshold`. Farbeffekte wie [IDuotone](https://reference.aspose.com/slides/de/java/com.aspose.slides/iduotone/) geben veränderbare [IColorFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorformat/)‑Objekte zurück.

Einige Operations‑Interfaces, darunter [IBrightnessContrast](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/de/java/com.aspose.slides/itint/) und [IAlphaReplace](https://reference.aspose.com/slides/de/java/com.aspose.slides/ialphareplace/), stellen ihre Erstellungs‑Skalarwerte nicht als beschreibbare Eigenschaften bereit. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation ein.

Effektive Daten, die von `getEffective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um thema‑abhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, bilden jedoch keine weitere Bearbeitungsoberfläche. Das folgende Beispiel enumeriert die Kette und inspiziert effektive Werte, sofern die zugehörige API sie bereitstellt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Parameter‑freie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein Effektiv‑Daten‑Objekt, jedoch gibt es keine skalaren Einstellungen zum Ausgeben. Ihre Präsenz und Position in der Sammlung sind die relevanten Informationen.

## **Bildtransformationen entfernen oder leeren**

Verwenden Sie [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-), um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach einem Entfernen verschieben, suchen Sie zuerst das Ziel und entfernen Sie es anschließend nach dem Durchlaufen der Sammlung. Mit [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/imagetransformoperationcollection/#clear--) lassen Sie die gesamte Kette entfernen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Das Entfernen oder Leeren von Transformationen ändert nur die Bildformatierung. Es löscht, komprimiert oder verändert nicht die wiederverwendete [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/)‑Ressource.

## **Präsentationsformate und Exportziele berücksichtigen**

Bildtransformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX hat nicht jede Operation dieselbe Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Farbton, HSL, Unschärfe und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Rundtrip zu überstehen. Öffnen Sie die erzeugte Datei stets erneut und prüfen Sie die Sammlung, wenn die Persistenz ein Requirement ist.
- [BrightnessContrast](https://reference.aspose.com/slides/de/java/com.aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und nicht die standardmäßige DrawingML‑Luminanz‑Operation. Sie kann für In‑Memory‑Renderings verwendet werden, ist jedoch nicht garantiert als editierbares [IBrightnessContrast](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibrightnesscontrast/) nach dem Speichern und erneuten Öffnen von PPTX erhalten zu bleiben. Verwenden Sie lieber [addLuminanceEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) für dauerhafte Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format predatiert das vollständige DrawingML‑Effekt‑Modell. Beim Speichern nach PPT können nicht unterstützte Operationen weggelassen, die Kette auf ein unterstütztes Subset reduziert oder das Erscheinungsbild approximiert werden. Verwenden Sie PPT nicht als Verifikationsformat für komplexe editierbare Ketten.
- Das Rendern nach PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Aussehen an. Diese Ausgaben enthalten keine editierbare `IImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑/Vektor‑Exporte speichern ihre eigene Rendering‑Repräsentation.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes ist weiterhin von der Verfügbarkeit der verknüpften Ressource beim Laden der Präsentation abhängig.

Verschiedene Präsentations‑Viewer können Randfälle unterschiedlich rendern, besonders wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Rundtrip als auch das endgültige Export‑Format mit derselben Aspose.Slides‑Version, die in der Produktion eingesetzt wird.

## **FAQ**

**Verändern Bildtransformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zum `ISlidesPicture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `IPPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dieselbe Bild‑Ressource wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden eines `IPPImage` reduziert doppelte Bilddaten, aber jeder Bildrahmen besitzt normalerweise ein separates `ISlidesPicture` und eine eigene Transformationssammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Beachten Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten stellen berechnete Werte dar, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformationssammlung gespeicherte Operation, wo beschreibbare Mitglieder existieren; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformationskette zu erhalten?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das alte PPT‑Format kann das komplette DrawingML‑Effekt‑Modell nicht darstellen, und gerenderte Export‑Formate bewahren nur das Aussehen, nicht die editierbaren Transformations‑Operationen.