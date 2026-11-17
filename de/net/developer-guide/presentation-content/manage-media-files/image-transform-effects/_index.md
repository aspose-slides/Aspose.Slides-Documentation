---
title: "Verwalten von Bildtransformations‑Effekten in Präsentationen mit .NET"
linktitle: "Bildtransformations‑Effekte"
type: docs
weight: 11
url: /de/net/image-transform-effects/
keywords:
- Bildtransformation
- Bildeffekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Farbton
- HSL
- Farb‑Ersetzung
- Unschärfe
- Transparenz
- Alpha‑Effekt
- Effektkette
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Anwenden, verketten, prüfen, entfernen und verifizieren von Bildtransformations‑Effekten für Bildrahmen mit Aspose.Slides für .NET."
---
## **Übersicht**

Aspose.Slides repräsentiert Bildanpassungen als eine geordnete Sammlung von Bildtransformationsoperationen. Für einen Bildrahmen beginnen Sie mit dem Rahmen‑Objekt [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) und greifen auf [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/) zu. Die zurückgegebene [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Löschen von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Arbeitsablauf für Helligkeit und Kontrast, Farbtransformationen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, Entfernen und PPTX‑Rundreise‑Verifizierung.

## **Verstehen von Effekt‑Eigentum und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) speichert oder referenziert die von der Präsentation besessenen Quelldaten des Bildes.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformationssammlung speichert.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und andere Rahmen‑Formatierungen besitzt.

Daher modifizieren Bildtransformationsoperationen die Bytes in [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) nicht. Wenn das gleiche `IPPImage` mehr als einmal an [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `ISlidesPicture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht zu Graustufen, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Das gleiche `ISlidesPicture.ImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, z. B. einer Form oder einem Folienhintergrund. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden gültiger Parameterbereiche und Einheiten**

Die demonstrierten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden Bereichsverstoß ablehnt; das Ziel‑Präsentationsformat kann die Daten beim Speichern oder beim Öffnen durch PowerPoint normalisieren, weglassen oder ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Zwei Farben für dunkle und helle Pixel. RGB- und Alpha‑Kanäle in `System.Drawing.Color` verwenden `0` bis `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Farbton ist `0` (einschließlich) bis `360` (ausschließlich) in Grad; Betrag ist `-100` bis `100`, Prozent. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Farbton ist `0` (einschließlich) bis `360` (ausschließlich) in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius ist nicht negativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der bestimmt, ob unscharfer Inhalt außerhalb der ursprünglichen Grenzen erweitert werden darf. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nicht‑negative Prozentzahl. Verwenden Sie `0` bis `100` für normale Deckkraft‑Skalierung: `0` ist vollständig transparent und `100` erhält das vorhandene Alpha. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` bis `100`, Prozent Deckkraft. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` bis `100`, Prozent Alpha‑Schwellenwert. Werte darunter werden transparent; Werte darüber oder gleich werden undurchsichtig. |

Bei fester Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Zum Beispiel entspricht 35 % Transparenz einer Alpha‑Modulationsmenge von 65 %.

## **Helligkeit und Kontrast anwenden**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) gibt eine [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)‑Operation zurück. Ihre skalaren Einstellungen werden beim Erstellen der Operation übergeben. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) gibt berechnete schreibgeschützte Werte zurück, die inspiziert oder protokolliert werden können.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der standardmäßige DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einer PPTX‑Rundreise editierbar bleiben müssen, verwenden Sie [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) und verifizieren Sie das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt zu Formatbeschränkungen erläutert diesen Unterschied ausführlicher.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die eine Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Farbton, HSL‑Anpassung und Farb‑Ersetzung an.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) enthält zwei unabhängig editierbare Farbparameter: `Color1` ordnet dunklen Pixeln zu, während `Color2` hellen Pixeln zugeordnet wird. Das macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) ersetzt die Farbe jedes Pixels durch eine feste Farbe und bewahrt das Alpha. Es unterscheidet sich von [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), das eine Quellfarbe auf eine Ziel­farbe abbildet und beide Farbformate offenlegt.

### **Eine Luminanz‑Schwelle anwenden**

Eine Luminanz‑Schwelle kann schwache Markierungen auf einer gescannten Seite leichter vom Hintergrund unterscheiden. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) bewahrt Zwischen­graustufen. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) ordnet Luminanz Schwarz oder Weiß zu, während [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) einen Schwellenwert auf die Deckkraft anwendet.

Der Luminanz‑Schwellenwert reicht von 0 % bis 100 %, inklusiv. Pixel unter dem Schwellenwert werden schwarz. Pixel ab dem Schwellenwert werden weiß. Das Anheben des Schwellenwerts macht mehr Abstufungen schwarz, weil mehr davon unter den Grenzwert fallen.

Laden Sie [grayscale-swatches.png](grayscale-swatches.png) in das Arbeitsverzeichnis. Jede Beschriftung gibt den ursprünglichen Grauwert auf einer Skala von 0 bis 255 an. Das Beispiel platziert das Original neben zwei Kopien und speichert den Schwellenwert jeder Kopie in der Präsentation.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Öffnen Sie die erzeugte Präsentation in PowerPoint, um die drei Rahmen zu vergleichen. Das Farbmuster mit der Beschriftung 96 hat etwa 38 % Luminanz (96 von 255). Es wird bei einem Schwellenwert von 20 % weiß und bei 60 % schwarz.

![Originale Graustufen‑Muster neben den Schwarz‑Weiß‑Ergebnissen bei Luminanz‑Schwellen von 20 % und 60 %](luminance-threshold.png)

## **Unschärfe, Transparenz und Alpha‑Effekte hinzufügen**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) wirkt sich auf alle Farbkanäle aus, einschließlich Alpha. Setzen Sie `grow` auf `true`, wenn die unscharfe Kante über die ursprünglichen Bildgrenzen hinausreichen kann.

Für gleichmäßige Transparenz verwenden Sie [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Es multipliziert jeden vorhandenen Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) weist stattdessen allen Pixeln einen Alpha‑Wert zu. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) wandelt Alpha in zwei Stufen basierend auf einem Schwellenwert um.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Weitere parameterfreie Alpha‑Operationen umfassen [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), das jedes von Null verschiedene Alpha vollständig undurchsichtig macht; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), das jedes Alpha unter 100 % vollständig transparent macht; und [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), das Alpha zu `100% - alpha` ändert.

## **Eine geordnete Effektkette erstellen**

Jede `Add...Effect`‑Methode hängt eine neue Operation an das Ende der Sammlung an. Der Renderer verwendet die Sammlung als geordnete Pipeline: Der Ausgang von Operation 0 wird zum Eingang von Operation 1 usw. Folglich kann dieselbe Menge von Operationen in einer anderen Reihenfolge ein unterschiedliches Bild erzeugen.

Beispielsweise entfernt Graustufen gefolgt von Farbton zuerst chromatische Informationen und färbt das Luminanz‑Ergebnis anschließend neu. Farbton gefolgt von Graustufen entfernt den Farbton wieder. Ebenso kann Alpha‑Ersetzung Alpha‑Werte, die von früheren Operationen berechnet wurden, überschreiben, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette mit vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geöffnete Ergebnis:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Unschärfe‑Operationen auf getrennte Ketten beschränkt. Sie können kombiniert werden, aber Kombinationen sind nicht immer sinnvoll. Eine feste Farb‑Ersetzung entfernt die RGB‑Variation früherer Farbeffekte; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling, -Floor, -Replace oder -BiLevel‑Operationen können Alpha‑Detail, das zuvor erzeugt wurde, verwerfen. Bauen Sie die Kette nach der gewünschten Pixel‑Verarbeitungsreihenfolge auf, anstatt ihre Elemente als ungeordnete Formatierungs‑Flags zu behandeln.

<!-- visual-explanation:image-transform-effects:start -->
[![Das gleiche Bild läuft zuerst durch Graustufen und dann durch Farbton, und Farbton dann durch Graustufen. Die beiden endgültigen Graustufenbilder haben unterschiedliche Töne.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In dieser illustrativen Aspose.Slides for .NET 26.11‑Darstellung lässt ein 220°‑Farbton mit 25 % das Graustufenbild unverändert. Das Anwenden desselben Farbttons vor Graustufen erzeugt unterschiedliche Töne.*
<!-- visual-explanation:image-transform-effects:end -->

## **Editierbare und effektive Werte inspizieren**

Eine editierbare Operation ist das Objekt, das in `ISlidesPicture.ImageTransform` gespeichert ist. Abhängig vom Effekt kann es direkt beschreibbare Mitglieder offenlegen. Beispielsweise legt [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) `Radius` und `Grow` als beschreibbar fest, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) legt `Amount` als beschreibbar fest, und [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) legt `Threshold` als beschreibbar fest. Farbeffekte wie [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) geben mutierbare [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/)‑Objekte frei.

Einige Operations‑Schnittstellen, darunter [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/) und [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), geben ihre Erstellungs‑Skalare nicht als beschreibbare Eigenschaften frei. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `GetEffective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, stellen jedoch keine weitere Bearbeitungsoberfläche dar. Das folgende Beispiel enumeriert die Kette und inspiziert effektive Werte, wo die zugehörige API sie bereitstellt:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Parameterfreie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen weiterhin ein effektives Datenobjekt, jedoch gibt es keine skalaren Einstellungen zum Ausgeben. Ihre Präsenz und Position in der Sammlung sind die relevanten Informationen.

## **Bildtransformationen entfernen oder leeren**

Verwenden Sie [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/), um eine Operation nach Index zu entfernen. Da Indizes nach dem Entfernen verschoben werden, suchen Sie zuerst das Ziel und entfernen es nach dem Durchlaufen. Verwenden Sie `Clear()`, um die gesamte Kette zu entfernen.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Das Entfernen oder Leeren von Transformationen ändert nur die Bildformatierung. Es löscht, komprimiert nicht neu und verändert die wiederverwendete [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)‑Ressource nicht.

## **Berücksichtigen von Präsentationsformaten und Exportzielen**

Bildtransformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Auch bei PPTX hat nicht jede Operation dieselbe Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Farbton, HSL, Unschärfe und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Rundtrip zu überstehen. Öffnen Sie stets die erzeugte Datei erneut und prüfen Sie die Sammlung, wenn die Erhaltung ein Requirement ist.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und nicht die standardmäßige DrawingML‑Luminanz‑Operation. Sie kann für In‑Memory‑Rendering verwendet werden, ist jedoch nicht garantiert als editierbares [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) nach dem Speichern und erneuten Öffnen von PPTX erhalten zu bleiben. Bevorzugen Sie [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) für persistente Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist dem vollständigen DrawingML‑Effektmodell voraus. Das Speichern nach PPT kann nicht unterstützte Operationen weglassen, eine Kette auf ein unterstütztes Subset reduzieren oder das Aussehen approximieren. Verwenden Sie PPT nicht als Verifikationsformat für eine komplexe editierbare Kette.
- Das Rendern zu PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare `IImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑/Vektor‑Exporte speichern ihre eigene Renderdarstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Rundtrip als auch das endgültige Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion verwendet wird.

## **FAQ**

**Ändern Bildtransformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zu dem `ISlidesPicture`, das von der Bildfüllung verwendet wird. Die zugrundeliegenden `IPPImage`‑Bytes bleiben unverändert.

**Werden zwei Bildrahmen, die dasselbe Bild wiederverwenden, ihre Effekte teilen?**

Nein. Das Wiederverwenden eines `IPPImage` vermeidet doppelte Bilddaten, aber jeder Bildrahmen hat normalerweise ein separates `ISlidesPicture` und eine eigene Bildtransformations‑Sammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Beachten Sie, was jede Operation mit dem Ausgang der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Editieren Sie die in der Transformations‑Sammlung gespeicherte Operation, wo beschreibbare Mitglieder existieren; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformationskette zu erhalten?**

Verwenden Sie PPTX und verifizieren Sie die Datei, indem Sie sie erneut öffnen. Das alte PPT‑Format kann das vollständige DrawingML‑Effektmodell nicht darstellen, und gerenderte Exportformate erhalten nur das Erscheinungsbild, nicht editierbare Transformations‑Operationen.