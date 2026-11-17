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
- Tönung
- HSL
- Farbersetzung
- Unschärfe
- Transparenz
- Alpha‑Effekt
- Effektkette
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Anwenden, verketten, untersuchen, entfernen und verifizieren von Bildtransformations‑Effekten für Bildrahmen mit Aspose.Slides für Java."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformations‑Operationen dar. Für einen Bildrahmen beginnen Sie mit dem Rahmen‑[ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) und greifen auf [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--) zu. Die zurückgegebene [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Untersuchen, Entfernen und Löschen von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Workflow für Helligkeit und Kontrast, Farbtransformationen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, das Entfernen und die PPTX‑Rundreise‑Verifizierung.

## **Verständnis von Effektzugehörigkeit und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) speichert oder referenziert die Quellbilddaten, die zur Präsentation gehören.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformations‑Sammlung speichert.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschneideeinstellungen und andere formatierungsbezogene Eigenschaften des Rahmens besitzt.

Daher verändern Bildtransformations‑Operationen nicht die Bytes in [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). Wenn dieselbe `IPPImage` mehr als einmal an [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `ISlidesPicture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht grau, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Das gleiche `ISlidesPicture.getImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, z. B. einer Form oder Folienhintergrund. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden Sie gültige Parameterbereiche und Einheiten**

Die demonstrierten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden außerhalb des Bereichs liegenden Wert ablehnt; das Ziel‑Präsentationsformat kann Daten beim Speichern normalisieren, weglassen oder ungültige Daten ablehnen, wenn PowerPoint die Datei öffnet.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Zwei Farben für dunkle und helle Pixel. RGB- und Alpha‑Kanäle in `java.awt.Color` verwenden `0` bis `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Farbton ist von `0` (inklusive) bis `360` (exklusiv) Grad; Betrag ist `-100` bis `100`, Prozent. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Farbton ist von `0` (inklusive) bis `360` (exklusiv) Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius ist nicht negativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der steuert, ob unscharfer Inhalt über die ursprünglichen Grenzen hinausgehen darf. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nicht negativer Prozentsatz. Verwenden Sie `0` bis `100` für normale Deckkraftskalierung: `0` ist vollständig transparent und `100` erhält das vorhandene Alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` bis `100`, Prozent Deckkraft. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` bis `100`, Prozent Alpha‑Schwelle. Werte darunter werden transparent; Werte gleich oder darüber undurchsichtig. |

Bei fester Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Beispielsweise entspricht 35 % Transparenz einem Alpha‑Modulationswert von 65 %.

## **Helligkeit und Kontrast anwenden**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) gibt eine [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)‑Operation zurück. Ihre Skalareinstellungen werden beim Erstellen der Operation übergeben. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) liefert berechnete schreibgeschützte Werte, die geprüft oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 %, dann rendert es eine Vorschau, ohne das eingebettete Bild zu ändern:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) ist eine Office 2010‑Bildeffekt‑Erweiterung und weniger portabel als der Standard‑DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einer PPTX‑Rundreise editierbar bleiben müssen, verwenden Sie [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) und prüfen Sie das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt zu Formatbeschränkungen erklärt diesen Unterschied genauer.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Tönung, HSL‑Anpassung und Farbersetzung an.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) enthält zwei unabhängig editierbare Farbparameter: `color1` ordnet dunklen Pixeln zu, während `color2` hellen Pixeln zuordnet. Das macht es zu einem sinnvollen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) ersetzt die Farbe jedes Pixels durch eine feste Farbe und behält das Alpha bei. Es unterscheidet sich von [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), das eine Quellfarbe zu einer anderen abbildet und sowohl Quell‑ als auch Ziel‑Farbformate offenlegt.

### **Eine Luminanz‑Schwelle anwenden**

Eine Luminanz‑Schwelle kann schwache Markierungen auf einer gescannten Seite leichter vom Hintergrund unterscheiden. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) bewahrt Zwischen­graustufen. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) wandelt Luminanz in Schwarz oder Weiß um, während [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) einen Schwellenwert auf die Deckkraft anwendet.

Die Luminanz‑Schwelle reicht von 0 % bis 100 %, inklusiv. Pixel unterhalb der Schwelle werden schwarz. Pixel gleich oder oberhalb der Schwelle werden weiß. Ein Anheben der Schwelle macht mehr Graustufen schwarz, weil mehr davon unter den Grenzwert fallen.

Laden Sie [grayscale-swatches.png](grayscale-swatches.png) in das Arbeitsverzeichnis herunter. Jede Beschriftung gibt den ursprünglichen Grauwert auf einer Skala von 0 bis 255 an. Das Beispiel stellt das Original neben zwei Kopien und speichert die Schwelle jeder Kopie in der Präsentation.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);
    
    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Öffnen Sie die Ausgabepresentation in PowerPoint, um die drei Rahmen zu vergleichen. Das Farbfeld mit der Bezeichnung 96 hat etwa 38 % Luminanz (96 von 255). Es wird bei einer Schwelle von 20 % weiß und bei 60 % schwarz.

![Originale Graustufenfarbfelder neben den Schwarz‑Weiß‑Ergebnissen bei Luminanz‑Schwellen von 20 % und 60 %](luminance-threshold.png)

## **Unscharfe, Transparenz‑ und Alpha‑Effekte hinzufügen**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) wirkt sich auf alle Farbkanäle einschließlich Alpha aus. Setzen Sie `grow` auf `true`, wenn die unscharfe Kante über die ursprünglichen Bildgrenzen hinausreichen kann.

Für einheitliche Transparenz verwenden Sie [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Es multipliziert jeden vorhandenen Alphawert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) weist stattdessen allen Pixeln einen einzigen Alphawert zu. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) konvertiert Alpha in zwei Stufen basierend auf einem Schwellenwert.

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

Weitere parameterlose Alpha‑Operationen umfassen [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), die jedes von Null verschiedene Alpha vollständig undurchsichtig macht; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), die jedes Alpha unter 100 % vollständig transparent macht; und [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), die Alpha zu `100% - alpha` ändert.

## **Eine geordnete Effektkette aufbauen**

Jede `add...Effect`‑Methode fügt am Ende der Sammlung eine neue Operation hinzu. Der Renderer verwendet die Sammlung als geordnete Pipeline: die Ausgabe von Operation 0 wird zur Eingabe von Operation 1 usw. Folglich kann dieselben Operationen in anderer Reihenfolge ein unterschiedliches Bild erzeugen.

Beispielsweise entfernt Graustufen, gefolgt von Tönung, zuerst chromatische Informationen und färbt dann das Luminanz‑Ergebnis neu. Tönung, gefolgt von Graustufen, entfernt die Tönung wieder. Ebenso kann Alpha‑Ersetzung Alpha‑Werte, die durch frühere Operationen berechnet wurden, überschreiben, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel erstellt eine Kette von vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geöffnete Ergebnis:

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

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Unschärfe‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, aber Kombinationen sind nicht immer sinnvoll. Eine feste Farb‑Ersetzung entfernt RGB‑Variationen, die durch frühere Farbeffekte erzeugt wurden; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling-, Floor-, Replacement- oder Bi‑Level‑Operationen können Alpha‑Details, die zuvor erstellt wurden, verwerfen. Bauen Sie die Kette gemäß der gewünschten Pixel‑Verarbeitungssequenz auf, anstatt ihre Elemente als ungeordnete Formatierungs‑Flags zu behandeln.

<!-- visual-explanation:image-transform-effects:start -->
[![Dasselbe Bild durchläuft zuerst Graustufen und dann Tönung, bzw. Tönung und dann Graustufen. Die beiden endgültigen Graustufenbilder haben unterschiedliche Töne.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In dieser illustrativen Aspose.Slides for .NET 26.11‑Darstellung lässt eine 220°‑Tönung bei 25 % das Graustufenbild unverändert. Das Anwenden derselben Tönung vor Graustufen erzeugt unterschiedliche Töne.*
<!-- visual-explanation:image-transform-effects:end -->

## **Editierbare und effektive Werte untersuchen**

Eine editierbare Operation ist das Objekt, das in `ISlidesPicture.getImageTransform` gespeichert wird. Je nach Effekt kann es direkt schreibbare Member offenlegen. Zum Beispiel legt [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) schreibbare `radius`‑ und `grow`‑Werte offen, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) legt ein schreibbares `amount`‑Feld offen und [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) legt einen schreibbaren `threshold`‑Wert offen. Farbeffekte wie [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) legen veränderbare [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/)‑Objekte off.

Einige Operations‑Schnittstellen, einschließlich [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), und [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), geben ihre Erstellungs‑Skalare nicht als schreibbare Eigenschaften frei. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position einen Ersatz hinzu.

Durch `getEffective()` zurückgegebene effektive Daten sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, stellen jedoch keine weitere Bearbeitungsoberfläche dar. Das folgende Beispiel enumeriert die Kette und prüft effektive Werte, wo die entsprechende API sie bereitstellt:

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

Parameterlose Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen weiterhin ein effektives Datenobjekt, jedoch gibt es keine skalaren Einstellungen zum Ausgeben. Deren Vorhandensein und Position in der Sammlung sind die wichtigen Informationen.

## **Bildtransformationen entfernen oder löschen**

Verwenden Sie [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-), um eine Operation nach Index zu entfernen. Da Indizes nach einer Entfernung verschoben werden, suchen Sie zuerst das Ziel und entfernen es nach der Aufzählung. Verwenden Sie [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) , um die gesamte Kette zu entfernen.

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

Das Entfernen oder Löschen von Transformationen ändert nur die Bildformatierung. Es löscht, komprimiert nicht neu oder verändert die wiederverwendete [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)‑Ressource nicht.

## **Berücksichtigen Sie Präsentationsformate und Exportziele**

Bildtransformationen entstehen in DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Auch bei PPTX hat nicht jede Operation dieselbe Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Tönung, HSL, Unschärfe und gängige Alpha‑Operationen haben die beste Chance, einen PPTX‑Rundreise‑Durchlauf zu überstehen. Öffnen Sie die erzeugte Datei immer wieder und prüfen Sie die Sammlung, wenn die Erhaltung erforderlich ist.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) ist eine Office 2010‑Erweiterung und nicht die standardmäßige DrawingML‑Luminanz‑Operation. Sie kann für In‑Memory‑Rendering verwendet werden, ist jedoch nicht garantiert, nach dem Speichern und erneuten Öffnen der PPTX als editierbare [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) bestehen zu bleiben. Bevorzugen Sie [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) für dauerhafte Helligkeits‑ und Kontrasteinstellungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effektmodell. Das Speichern nach PPT kann nicht unterstützte Operationen weglassen, eine Kette auf ein unterstütztes Subset reduzieren oder das Aussehen approximieren. Verwenden Sie PPT nicht als Verifikationsformat für eine komplexe editierbare Kette.
- Das Rendern nach PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten kein editierbares `IImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑/Vektor‑Exports speichern ihre eigene Rendering‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Rundreise‑Durchlauf als auch das endgültige Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion verwendet wird.

## **FAQ**

**Ändern Bildtransformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zu dem `ISlidesPicture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `IPPImage`‑Bytes bleiben unverändert.

**Werden zwei Bildrahmen, die dasselbe Bild wiederverwenden, ihre Effekte teilen?**

Nein. Die Wiederverwendung einer `IPPImage` vermeidet doppelte Bilddaten, aber jeder Bildrahmen hat normalerweise ein separates `ISlidesPicture` und eine eigene Bildtransformations‑Sammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer einzigen geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellenwert‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Editieren Sie die in der Transformationssammlung gespeicherte Operation, wenn schreibbare Member vorhanden sind; andernfalls entfernen Sie sie und fügen Sie einen Ersatz mit neuen Erstellungsparametern hinzu.

**Welches Format sollte ich zur Bewahrung einer Transformationskette verwenden?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das alte PPT‑Format kann das vollständige DrawingML‑Effektmodell nicht darstellen, und gerenderte Exportformate bewahren das Aussehen, nicht jedoch editierbare Transformations‑Operationen.