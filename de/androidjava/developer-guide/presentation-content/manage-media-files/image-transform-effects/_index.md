---
title: Verwalten von Bildtransformations‑Effekten in Präsentationen auf Android
linktitle: Bildtransformations‑Effekte
type: docs
weight: 11
url: /de/androidjava/image-transform-effects/
keywords:
- Bildtransformation
- Bild‑Effekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Farbton
- HSL
- Farbersetzung
- Unschärfe
- Transparenz
- Alpha‑Effekt
- Effektkette
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Anwenden, verketten, inspizieren, entfernen und überprüfen von Bildtransformations‑Effekten für Bildrahmen mit Aspose.Slides für Android über Java."
---
## **Übersicht**

Aspose.Slides repräsentiert Bildanpassungen als geordnete Sammlung von Bildtransformationsoperationen. Für einen Bildrahmen beginnen Sie mit dem Rahmen‑[ISlidesPicture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidespicture/) und greifen auf [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) zu. Die zurückgegebene [IImageTransformOperationCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Löschen von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Arbeitsablauf für Helligkeit und Kontrast, Farbumwandlungen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, Entfernen und PPTX‑Rundreise‑Verifizierung.

## **Verständnis von Effektbesitz und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) speichert oder referenziert die Quelldaten des Bildes, die zur Präsentation gehören.
- [ISlidesPicture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidespicture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während die Bildtransformationssammlung gespeichert wird.
- [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschneideeinstellungen und weitere rahmenbezogene Formatierungen besitzt.

Daher ändern Bildtransformationsoperationen nicht die Bytes in [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/). Wenn dasselbe `IPPImage` mehr als einmal an [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `ISlidesPicture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht zu Graustufen, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Dasselbe `ISlidesPicture.getImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, z. B. einer Form oder Folienhintergrund. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden Sie gültige Parameterbereiche und Einheiten**

Die gezeigten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie die Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden außerhalb liegenden Wert ablehnt; das Zielpräsentationsformat kann ungültige Daten beim Speichern normalisieren, weglassen oder ablehnen, bzw. PowerPoint kann die Datei beim Öffnen ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` belässt die Komponente unverändert. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [addDuotoneEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alphakanalwerte, die von `android.graphics.Color` verwendet werden, liegen zwischen `0` und `255`. |
| [addTintEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Farbton ist `0` inkl. bis `360` excl., in Grad; Betrag ist `-100` bis `100`, Prozent. |
| [addHSLEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Farbton ist `0` inkl. bis `360` excl., in Grad; Sättigung und Helligkeit sind `-100` bis `100`, Prozent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [addBlurEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius ist nicht negativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der steuert, ob verwischter Inhalt außerhalb der ursprünglichen Grenzen erweitert werden darf. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nicht negativer Prozentwert. Verwenden Sie `0` bis `100` für übliche Transparenzskalierung: `0` ist vollständig transparent und `100` erhält das bestehende Alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` bis `100`, Prozent‑Deckkraft. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwelle. Werte darunter werden transparent; Werte gleich oder darüber undurchsichtig. |

Für feste Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Zum Beispiel entspricht 35 % Transparenz einem Alpha‑Modulationswert von 65 %.

## **Helligkeit und Kontrast anwenden**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) gibt eine [IBrightnessContrast](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibrightnesscontrast/)‑Operation zurück. Ihre skalaren Einstellungen werden beim Erstellen der Operation übergeben. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) liefert berechnete Nur‑Lese‑Werte, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 % und rendert dann eine Vorschau, ohne das eingebettete Bild zu verändern:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

[BrightnessContrast](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der standardmäßige DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einer PPTX‑Rundreise bearbeitbar bleiben sollen, verwenden Sie [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) und prüfen das Ergebnis nach erneutem Öffnen der Datei. Der Abschnitt zu Formatbeschränkungen erläutert diesen Unterschied genauer.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig von verschiedenen Bildrahmen, die dieselbe Bildressource wiederverwenden, angewendet werden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Farbton, HSL‑Anpassung und Farb­ersetzung an.

[IDuotone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iduotone/) enthält zwei unabhängig bearbeitbare Farbparameter: `color1` ordnet dunkle Pixel zu, `color2` hellen Pixeln. Das macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) ersetzt jede Pixel‑Farbe durch eine feste Farbe, wobei Alpha erhalten bleibt. Es unterscheidet sich von [addColorChangeEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), das eine Quellfarbe zu einer Ziel­farbe mappt und beide Farbformate exponiert.

## **Unschärfe, Transparenz und Alpha‑Effekte hinzufügen**

[addBlurEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) wirkt auf alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `true`, wenn die unscharfe Kante über die ursprünglichen Bildgrenzen hinausreichen darf.

Für einheitliche Transparenz verwenden Sie [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Es multipliziert jeden bestehenden Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) weist allen Pixeln einen einheitlichen Alpha‑Wert zu. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) konvertiert Alpha in zwei Stufen basierend auf einer Schwelle.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

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

Weitere parameterfreie Alpha‑Operationen sind [addAlphaCeilingEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) (macht jedes nicht‑null Alpha vollständig undurchsichtig), [addAlphaFloorEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) (macht jedes Alpha unter 100 % vollständig transparent) und [addAlphaInverseEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) (setzt Alpha auf `100% - alpha`).

## **Eine geordnete Effektkette aufbauen**

Jede `add...Effect`‑Methode hängt eine neue Operation am Ende der Sammlung an. Der Renderer verwendet die Sammlung als geordnete Pipeline: Die Ausgabe von Operation 0 wird Eingabe von Operation 1 usw. Deshalb kann dieselbe Menge an Operationen in anderer Reihenfolge ein unterschiedliches Bild ergeben.

Beispielsweise entfernt Graustufen gefolgt von Farbton zuerst chromatische Informationen und färbt dann das Luminanz‑Ergebnis um. Farbton gefolgt von Graustufen entfernt den Farbton wieder. Ebenso kann Alpha‑Ersetzung Alpha‑Werte überschreiben, die von früheren Operationen berechnet wurden, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette mit vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geöffnete Ergebnis:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Unschärfe‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, doch Kombinationen sind nicht immer sinnvoll. Eine feste Farb­ersetzung entfernt RGB‑Variationen, die frühere Farbeffekte erzeugt haben; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling, Floor, Replacement oder BiLevel können Alpha‑Details, die vorher erzeugt wurden, verwerfen. Bauen Sie die Kette nach der gewünschten Pixel‑Verarbeitungsreihenfolge, nicht nach ungeordneten Formatierungs‑Flags.

## **Bearbeitbare und effektive Werte inspizieren**

Eine bearbeitbare Operation ist das Objekt, das in `ISlidesPicture.getImageTransform` gespeichert ist. Je nach Effekt kann sie schreibbare Member direkt exponieren. Beispielsweise exponiert [IBlur](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iblur/) die schreibbaren Werte `radius` und `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ialphamodulatefixed/) exponiert ein schreibbares `amount` und [IAlphaBiLevel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ialphabilevel/) ein schreibbares `threshold`. Farbeffekte wie [IDuotone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iduotone/) exponieren veränderbare [IColorFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorformat/)‑Objekte.

Einige Operations‑Interfaces, darunter [IBrightnessContrast](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itint/) und [IAlphaReplace](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ialphareplace/), exponieren ihre Erstellungs‑Skalare nicht als schreibbare Eigenschaften. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `getEffective()` zurückgegeben werden, sind berechnet und nur lesbar. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, aber sie stellen keine weitere Editier‑Oberfläche dar. Das folgende Beispiel durchläuft die Kette und inspiziert effektive Werte, sofern die zugehörige API sie bereitstellt:

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

Parameterfreie Effekte wie Graustufen, Alpha Ceiling und Alpha Inverse besitzen ebenfalls ein Effektiv‑Daten‑Objekt, jedoch gibt es keine skalaren Einstellungen zum Ausgeben. Ihre Anwesenheit und Position in der Sammlung sind die wichtigen Informationen.

## **Bild‑Transformationsoperationen entfernen oder löschen**

Verwenden Sie [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-), um eine Operation anhand ihres Indexes zu entfernen. Da Indizes nach dem Entfernen verschoben werden, suchen Sie zuerst das Ziel und entfernen Sie es nach dem Durchlaufen. Verwenden Sie [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--), um die gesamte Kette zu entfernen.

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

Das Entfernen oder Löschen von Transformationsoperationen ändert nur die Bildformatierung. Es löscht, recomprimiert oder verändert die wiederverwendete [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/)‑Ressource nicht.

## **Berücksichtigung von Präsentationsformaten und Exportzielen**

Bildtransformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX hat nicht jede Operation identische Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Farbton, HSL, Unschärfe und gängige Alpha‑Operationen haben die höchste Wahrscheinlichkeit, einen PPTX‑Rundreise‑Speicher zu überstehen. Öffnen Sie stets die erzeugte Datei erneut und prüfen Sie die Sammlung, wenn die Bewahrung erforderlich ist.
- [BrightnessContrast](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und nicht der standardmäßige DrawingML‑Luminanz‑Effekt. Sie kann für In‑Memory‑Renderings verwendet werden, ist jedoch nicht garantiert als bearbeitbares [IBrightnessContrast](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibrightnesscontrast/) nach dem Speichern und erneuten Öffnen von PPTX erhalten zu bleiben. Verwenden Sie lieber [addLuminanceEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) für dauerhafte Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effekt‑Modell. Beim Speichern nach PPT können nicht unterstützte Operationen weggelassen, die Kette auf einen unterstützten Teil reduziert oder das Aussehen approximiert werden. Verwenden Sie PPT nicht als Verifizierungsformat für eine komplexe editierbare Kette.
- Das Rendern zu PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare `IImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑/Vektor‑Exporte speichern ihre eigene Rendering‑Repräsentation.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Viewer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl die editierbare Rundreise als auch das finale Export‑Format mit derselben Aspose.Slides‑Version, die in Produktion verwendet wird.

## **FAQ**

**Modifizieren Bild‑Transformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zu dem `ISlidesPicture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `IPPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dasselbe Bild wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden eines `IPPImage` vermeidet doppelte Bilddaten, aber jeder Bildrahmen besitzt normalerweise ein separates `ISlidesPicture` und eine eigene Bildtransformationssammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte nur lesbar?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformationssammlung gespeicherte Operation, wo schreibbare Member existieren; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformationskette zu bewahren?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das Legacy‑PPT‑Format kann das vollständige DrawingML‑Effekt‑Modell nicht darstellen, und gerenderte Export‑Formate bewahren nur das Aussehen, nicht editierbare Transformations‑Operationen.