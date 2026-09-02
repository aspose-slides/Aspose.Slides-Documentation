---
title: Verwalten von Bildtransformations‑Effekten in Präsentationen mit .NET
linktitle: Bildtransformations‑Effekte
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
- Weichzeichnung
- Transparenz
- Alpha‑Effekt
- Effektkette
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Anwenden, Kettenbildung, Inspektion, Entfernen und Verifizieren von Bildtransformations‑Effekten für Bildrahmen mit Aspose.Slides für .NET."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformationsoperationen dar. Für einen Bildrahmen beginnen Sie mit dem Rahmen‑[ISlidesPicture](https://reference.aspose.com/slides/de/net/aspose.slides/islidespicture/) und greifen auf [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/de/net/aspose.slides/islidespicture/imagetransform/) zu. Die zurückgegebene [IImageTransformOperationCollection](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Löschen von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Arbeitsablauf für Helligkeit und Kontrast, Farbtransformationen, Weichzeichnung, Transparenz, geordnete Effektketten, effektive Werte, Entfernung und PPTX‑Rundreise‑Verifikation.

## **Verstehen von Effekt‑Eigentümerschaft und Bild‑Wiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) speichert oder referenziert die von der Präsentation besessenen Quelldaten.
- [ISlidesPicture](https://reference.aspose.com/slides/de/net/aspose.slides/islidespicture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformationssammlung speichert.
- [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) ist die Folien‑Shape, die die zugehörige Bildfüllung, Geometrie, Beschnitt‑Einstellungen und weitere Rahmen‑Formatierungen besitzt.

Daher ändern Bildtransformationsoperationen die Bytes in [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) nicht. Wenn dieselbe `IPPImage` mehrfach an [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addpictureframe/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `ISlidesPicture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht grau, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Dasselbe `ISlidesPicture.ImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, etwa von einer Shape‑ oder Folien‑Hintergrundfüllung. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden gültiger Parameterbereiche und Einheiten**

Die gezeigten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden ungültigen Wert ablehnt; das Ziel‑Präsentationsformat kann beim Speichern oder beim Öffnen der Datei durch PowerPoint Daten normalisieren, weglassen oder ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle in `System.Drawing.Color` verwenden `0` bis `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Farbton ist `0` (einschließlich) bis `360` (ausschließlich) Grad; Betrag ist `-100` bis `100` Prozent. |
| [AddHSLEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Farbton ist `0` (einschließlich) bis `360` (ausschließlich) Grad; Sättigung und Leuchtkraft sind `-100` bis `100` Prozent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Bestehende Alpha‑Werte bleiben unverändert. |
| [AddBlurEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius ist nicht‑negativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der steuert, ob verwischter Inhalt außerhalb der ursprünglichen Grenzen erweitert werden darf. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nicht‑negatives Prozent. Verwenden Sie `0` bis `100` für gewöhnliche Deckkraft‑Skalierung: `0` ist vollständig transparent und `100` erhält das vorhandene Alpha. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` bis `100` Prozent Deckkraft. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` bis `100` Prozent Alpha‑Schwelle. Werte darunter werden transparent, Werte gleich oder darüber undurchsichtig. |

Bei fester Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Beispiel: 35 % Transparenz entsprechen einer Alpha‑Modulations‑Amount von 65 %.

## **Anwenden von Helligkeit und Kontrast**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) liefert eine [IBrightnessContrast](https://reference.aspose.com/slides/de/net/aspose.slides.effects/ibrightnesscontrast/)‑Operation. Ihre skalaren Einstellungen werden beim Erzeugen der Operation übergeben. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides.effects/brightnesscontrast/geteffective/) gibt berechnete Nur‑Lese‑Werte zurück, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 %, rendert dann eine Vorschau, ohne das eingebettete Bild zu verändern:

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

[BrightnessContrast](https://reference.aspose.com/slides/de/net/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der Standard‑DrawingML‑Leuchtkraft‑Effekt. Wenn Helligkeit und Kontrast nach einer PPTX‑Rundreise editierbar bleiben sollen, verwenden Sie [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) und prüfen das Ergebnis nach erneutem Öffnen der Datei. Der Abschnitt zu Format‑Einschränkungen erklärt diesen Unterschied genauer.

## **Anwenden von Farbtransformationen**

Farbeffekte können unabhängig voneinander auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duoton, Tönung, HSL‑Anpassung und Farb‑Ersetzung an.

[IDuotone](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iduotone/) enthält zwei unabhängig editierbare Farb‑Parameter: `Color1` ordnet dunklen Pixeln zu, `Color2` ordnet hellen Pixeln zu. Das macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) ersetzt die Farbe jedes Pixels durch eine feste Farbe und behält das Alpha bei. Es unterscheidet sich von [AddColorChangeEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), das eine Quellfarbe auf eine Ziel­farbe abbildet und beide Farbformate offenlegt.

## **Hinzufügen von Weichzeichnung, Transparenz und Alpha‑Effekten**

[AddBlurEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) wirkt auf alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `true`, wenn die verwischte Kante über die ursprünglichen Bildgrenzen hinausgehen darf.

Für einheitliche Transparenz verwenden Sie [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Er multipliziert jeden vorhandenen Alpha‑Wert, sodass halbtransparente Pixel proportional unterschiedlich bleiben. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) weist allen Pixeln einen Alpha‑Wert zu. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) wandelt Alpha basierend auf einer Schwelle in zwei Stufen um.

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

Weitere parameterfreie Alpha‑Operationen umfassen [AddAlphaCeilingEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), das jedes von Null verschiedene Alpha vollständig undurchsichtig macht; [AddAlphaFloorEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), das jedes Alpha unter 100 % vollständig transparent macht; und [AddAlphaInverseEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), das Alpha zu `100% - alpha` ändert.

## **Erstellen einer geordneten Effektkette**

Jede `Add...Effect`‑Methode hängt eine neue Operation am Ende der Sammlung an. Der Renderer verwendet die Sammlung als geordnete Pipeline: Die Ausgabe von Operation 0 wird zum Eingang von Operation 1 usw. Daher kann dieselbe Menge an Operationen in anderer Reihenfolge ein anderes Bild erzeugen.

Beispiel: Graustufen gefolgt von Tönung entfernt zuerst chromatische Informationen und färbt dann das Leuchtkraft‑Ergebnis ein. Tönung gefolgt von Graustufen entfernt die Tönung wieder. Ähnlich kann Alpha‑Ersetzung Alpha‑Werte überschreiben, die durch frühere Operationen berechnet wurden, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geöffnete Ergebnis:

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

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Weichzeichnungs‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, jedoch sind nicht alle Kombinationen sinnvoll. Eine feste Farb‑Ersetzung entfernt RGB‑Variationen, die durch frühere Farbeffekte erzeugt wurden; Graustufen nach Duoton entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling, Floor, Replace oder BiLevel können Alpha‑Details verwerfen, die zuvor erzeugt wurden. Bauen Sie die Kette gemäß der gewünschten Pixel‑Verarbeitungsreihenfolge, anstatt ihre Elemente als ungeordnete Formatierungs‑Flags zu behandeln.

## **Untersuchen editierbarer und effektiver Werte**

Eine editierbare Operation ist das Objekt, das in `ISlidesPicture.ImageTransform` gespeichert ist. Je nach Effekt kann es schreibbare Mitglieder direkt offenlegen. Beispielsweise offenlegt [IBlur](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iblur/) die schreibbaren Eigenschaften `Radius` und `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/de/net/aspose.slides.effects/ialphamodulatefixed/) die Eigenschaft `Amount` und [IAlphaBiLevel](https://reference.aspose.com/slides/de/net/aspose.slides.effects/ialphabilevel/) die Eigenschaft `Threshold`. Farbeffekte wie [IDuotone](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iduotone/) geben veränderbare [IColorFormat](https://reference.aspose.com/slides/de/net/aspose.slides/icolorformat/)‑Objekte frei.

Einige Operations‑Schnittstellen, darunter [IBrightnessContrast](https://reference.aspose.com/slides/de/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/de/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/de/net/aspose.slides.effects/itint/) und [IAlphaReplace](https://reference.aspose.com/slides/de/net/aspose.slides.effects/ialphareplace/), stellen ihre Erstellungs‑Skalare nicht als schreibbare Eigenschaften bereit. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `GetEffective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, stellen jedoch keine weitere Bearbeitungsoberfläche dar. Das folgende Beispiel durchläuft die Kette und inspiziert effektive Werte, sofern die jeweilige API sie bereitstellt:

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

Parameterfreie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein Effektiv‑Daten‑Objekt, jedoch gibt es keine skalaren Einstellungen zum Ausdrucken. Ihr Vorhandensein und ihre Position in der Sammlung sind die relevanten Informationen.

## **Entfernen oder Leeren von Bildtransformen**

Verwenden Sie [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/), um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach einer Entfernung verschieben, suchen Sie zuerst das Ziel und entfernen es nach dem Durchlaufen. Mit `Clear()` entfernen Sie die gesamte Kette.

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

Das Entfernen oder Leeren von Transformen ändert nur die Bildformatierung. Es löscht, komprimiert oder ändert nicht die wiederverwendete [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)‑Ressource.

## **Berücksichtigen von Präsentationsformaten und Exportzielen**

Bildtransformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX hat nicht jede Operation dieselbe Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duoton, Tönung, HSL, Weichzeichnung und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Rundreise‑Durchlauf zu überstehen. Öffnen Sie die erzeugte Datei immer erneut und prüfen Sie die Sammlung, wenn die Bewahrung erforderlich ist.
- [BrightnessContrast](https://reference.aspose.com/slides/de/net/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und nicht garantiert nach dem Speichern und erneuten Öffnen von PPTX als editierbare [IBrightnessContrast](https://reference.aspose.com/slides/de/net/aspose.slides.effects/ibrightnesscontrast/) erhalten. Verwenden Sie stattdessen [AddLuminanceEffect](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) für dauerhafte Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effekt‑Modell. Beim Speichern nach PPT können nicht unterstützte Operationen weggelassen, die Kette auf ein unterstütztes Subset reduziert oder das Aussehen approximiert werden. Verwenden Sie PPT nicht als Verifikationsformat für eine komplexe editierbare Kette.
- Das Rendern zu PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare `IImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab und Dokument-/Vektorexporte speichern ihre eigene Rendering‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl die editierbare Rundreise als auch das endgültige Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion verwendet wird.

## **FAQ**

**Ändern Bild‑Transform‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zu dem `ISlidesPicture`, das von der Bildfüllung verwendet wird. Die zugrundeliegenden `IPPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dieselbe Bildressource wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden einer `IPPImage` verhindert doppelte Bilddaten, aber jeder Bildrahmen hat in der Regel ein separates `ISlidesPicture` und eine eigene Transformationssammlung.

**Können Farb‑, Weichzeichnungs‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Beachten Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformationssammlung gespeicherte Operation, wo schreibbare Mitglieder vorhanden sind; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformations‑Kette zu bewahren?**

Verwenden Sie PPTX und überprüfen Sie die Datei, indem Sie sie erneut öffnen. Das Legacy‑PPT‑Format kann das vollständige DrawingML‑Effekt‑Modell nicht darstellen, und gerenderte Exportformate erhalten das Aussehen, jedoch nicht editierbare Transformations‑Operationen.