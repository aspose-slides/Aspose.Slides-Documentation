---
title: Verwalten von Bildrahmen in Präsentationen in .NET
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/net/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- eingebettetes Bild
- verknüpftes Bild
- Bild extrahieren
- Rasterbild
- SVG‑Bild
- Bild zuschneiden
- zugeschnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmenformatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren Sie Bildrahmen in Präsentationen mit Aspose.Slides für .NET."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die sie anzeigt, separate Objekte: Eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [Images](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/images/)‑Sammlung, während ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) die Position, Größe, Linienformatierung, Drehung, Zuschneiden, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehrmals angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/), und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können außerdem auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Einbetten und Formatieren eines eingebetteten Bildes**

Für ein eingebettetes Bild fügen Sie die Bilddaten zur Präsentation hinzu und erstellen einen Bildrahmen mit [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addpictureframe/). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation beim Verschieben auf einen anderen Computer eigenständig bleibt.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen in den nativen Abmessungen des Bildes und wendet Linienformatierung und Drehung an:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmen‑Größe ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn später ein Bild zugeschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) stellt relative Breiten‑ und Höhen‑Skalierung für den Rahmen bereit. Ein Wert von `1.0` entspricht 100 % der Originalgröße des Bildes. Relative Skalierung ist nützlich, wenn ein Workflow das Verhältnis zur Quellbildgröße erhalten muss, anstatt die endgültigen Abmessungen manuell zu berechnen.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie nimmt weder ein Resampling noch eine Kompression des eingebetteten Bildes vor.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert einen externen Pfad über den [ISlidesPicture](https://reference.aspose.com/slides/de/net/aspose.slides/islidespicture/)‑Link, anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die im PPTX gespeicherten Bilddaten reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, zugänglich bleiben. Ändert sich der Pfad, wird die Datei verschoben oder ist die Ressource nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail versendet, archiviert oder in isolierten Umgebungen gerendert werden sollen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich Bild‑Verknüpfungen; das Verknüpfen von Videos ist ein separater Medientworkflow und wird bewusst nicht in dieses Beispiel gemischt.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Verwenden Sie Verknüpfungen, wenn das externe Dateimanagement beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: ein kleiner PPTX mit defekten Bildabhängigkeiten ist in der Regel weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer vorhandenen Präsentation extrahieren, prüfen Sie, ob eine Form tatsächlich ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bild‑Bytes, die auf dieselbe Weise extrahiert werden können.

### **Rasterbild extrahieren**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) direkt und erfordert nicht den älteren System‑Image‑Wrapper. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Das Speichern über [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die codierten Bytes benötigen, die in der Präsentation gespeichert sind, anstatt einer konvertierten Rasterdatei, verwenden Sie stattdessen die Binärdaten der Bildressource.

### **SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) ein [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, ohne das Bild zuerst zu rasterisieren.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Das Beibehalten von SVG‑Inhalten als SVG bewahrt die Vektor‑Quelle innerhalb der Präsentation. Raster‑Exporte wie PNG oder JPEG müssen diesen Vektorinhalt in Pixel rendern. PDF‑ oder SVG‑Folienexport ist ebenfalls ein Rendering‑Vorgang, sodass die exportierten Grafiken nicht als exakte Kopie des ursprünglichen eingebetteten SVG betrachtet werden sollten; verwenden Sie die eingebetteten [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)‑Daten, wenn die originale Vektor‑Ressource selbst benötigt wird.

## **Bild zuschneiden**

Zuschneiden ändert, welcher Teil eines Bildes im Rahmen sichtbar ist. Die Zuschneide‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/) sind Prozentsätze der Quellbildabmessungen. Das Zuschneiden löscht die verborgenen Pixel nicht sofort aus dem eingebetteten Bild; es ändert nur den sichtbaren Bereich.

Das folgende Beispiel findet sicher einen Bildrahmen und wendet Zuschneide‑Werte an:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Da die verborgenen Bilddaten weiterhin vorhanden sind, kann das Zuschneiden später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Wiederherstellbarkeit, können die zugeschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) entfernt Bilddaten außerhalb des aktuellen Zuschneide‑Rechtecks und gibt die resultierende Bildressource zurück. Das kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel nicht mehr für ein späteres Entzuschneiden zur Verfügung.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Die Methode kann der Präsentation eine neue Bildressource hinzufügen. Wenn das ursprüngliche Bild ebenfalls von anderen Bildrahmen verwendet wird, benötigen diese Rahmen weiterhin ihre bestehende Ressource, sodass das Löschen zugeschnittener Bereiche nicht zwangsläufig die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das zugeschnittene Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/compressimage/) reduziert die Auflösung von Rasterbildern relativ zu der Größe, in der das Bild angezeigt wird. Es kann gleichzeitig zugeschnittene Bereiche entfernen. Die Methode gibt `true` zurück, wenn das Bild verkleinert oder zugeschnitten wurde, und `false`, wenn keine Änderung erforderlich war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/net/aspose.slides.export/picturescompression/)‑Wert, wenn eine standardmäßige Zielauflösung ausreicht:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Statt eines Enum‑Werts kann ein benutzerdefinierter positiver DPI‑Wert übergeben werden, wenn ein spezifisches Ziel erforderlich ist.

Kompression ist für Rasterbilder vorgesehen. SVG‑ und Metadatei‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie auch daran, dass niedrigere Auflösung und gelöschte zugeschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich angezeigt oder exportiert wird, anstatt global die niedrigste DPI anzuwenden.

## **Bildeffekte untersuchen**

Bildeffekte werden am Bild gespeichert, das vom Rahmen verwendet wird. Die Bildtransformations‑Sammlung kann Effekte wie feste Alpha‑Modulation für Transparenz und Luminanz für Helligkeit und Kontrast enthalten. Das folgende Beispiel liest beide Arten von Effekten sicher aus dem ersten Bildrahmen einer Folie:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Diese Effekte ändern, wie das Bild im Rahmen gerendert wird; sie überschreiben nicht die originalen eingebetteten Bild‑Bytes.

## **Geometrie des Bildrahmens sperren**

Die [IPictureFrameLock](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframelock/)‑Einstellungen steuern, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Beispielsweise bewahrt die Sperre des Seitenverhältnisses die Proportionen der Form, während sie skaliert wird.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Die Sperre gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht zu resampeln oder dauerhaft auf dasselbe Seitenverhältnis zu ändern.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüllmodus „stretch“ ist, definieren die stretch‑offset‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Einrückungs‑Abstand von einer Kante, während negative Prozentsätze einen Ausbuchtungs‑Abstand erzeugen.

Dies unterscheidet sich vom Zuschneiden. Zuschneide‑Werte bestimmen, welcher Teil des Quellbildes sichtbar ist; stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Verwenden Sie stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Kanten des Quellbildes zu verbergen.

## **Speicher, Dateigröße und Exportüberlegungen**

Die wichtigsten Kompromisse lassen sich leichter verwalten, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt behandelt werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, jedoch erhöhen große Rasterbilder die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, aber die Präsentation ist von externen Dateien abhängig, die an den gespeicherten Pfaden oder Speicherorten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die verborgenen Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern erheblich reduzieren, geht jedoch zulasten der Quellauflösung. Sie sollte erst angewendet werden, wenn die beabsichtigte Größe auf der Folie bekannt ist.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektor‑Erhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folienexporte konvertieren die gerenderte Folie immer in Pixel.
- **Wiederholte Bilder** sollten nach Möglichkeit eine bereits vorhandene [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Workflow zu laden.

Bei großen Präsentationen ist Bildoptimierung in der Regel am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektor‑Inhalte behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, zugeschnittene Pixel nur entfernen, wenn spätere Bearbeitung nicht erforderlich ist, und externe Links vermeiden, sofern das Abhängigkeits‑Management nicht Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie sowie Formatierungen wie Größe, Drehung, Zuschneide‑Werte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern von Bilddateien aus der PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Reduziert das Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneide‑Einstellungen verbergen Teile des Quellbildes, lassen aber die zugrunde liegenden Pixel erhalten. Verwenden Sie [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) oder Bildkompression mit dem Entfernen zugeschnittener Bereiche, wenn diese Pixel dauerhaft gelöscht werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen zugeschnittener Bereiche verwirft Bilddaten. Bewahren Sie das ursprüngliche Quellbild außerhalb der Präsentation auf, falls später eine Bearbeitung in hoher Auflösung erforderlich sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalte als SVG, wenn die Vektor‑Treue wichtig ist. Das eingebettete [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rastert das SVG als Teil des Folienbildes.

**Wie vermeide ich unsichere Casts beim Lesen vorhandener Folien?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Mitglieder verwenden. Das Muster‑Matching mit [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) oder das Filtern der Form‑Sammlung nach diesem Interface verhindert ungültige Casts und ermöglicht es dem Code, Folien zu verarbeiten, die keine Bildrahmen enthalten.