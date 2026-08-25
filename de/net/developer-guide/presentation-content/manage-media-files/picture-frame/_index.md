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
- SVG-Bild
- Bild zuschneiden
- Zuschneidebereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmen-Formatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren von Bildrahmen in Präsentationen mit Aspose.Slides für .NET."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die das Bild darstellt, separate Objekte: Eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [Images](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/images/)‑Sammlung, während ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) die Position, Größe, Linienformatierung, Drehung, Zuschneiden, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehrmals angezeigt werden soll. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) und verwenden Sie diese Bildressource beim Erzeugen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können auch auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Einbetten und Formatieren eines Bildes**

Für ein eingebettetes Bild fügen Sie die Bilddaten der Präsentation hinzu und erstellen einen Bildrahmen mit [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addpictureframe/). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbst‑enthaltend bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen mit den nativen Abmessungen des Bildes und wendet Linienformatierung und Drehung an:

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

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmen­größe ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später zugeschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) stellt relative Breiten‑ und Höhen­skalierung für den Rahmen bereit. Ein Wert von `1.0` entspricht 100 % der Originalbildgröße. Relative Skalierung ist nützlich, wenn ein Workflow die Beziehung zur Quellbildgröße erhalten muss, anstatt die endgültigen Abmessungen manuell zu berechnen.

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

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie resampelt oder komprimiert das eingebettete Bild nicht.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert über den [ISlidesPicture](https://reference.aspose.com/slides/de/net/aspose.slides/islidespicture/)‑Linkpfad einen externen Speicherort, anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die Menge an Bilddaten im PPTX reduzieren, führen jedoch zu einer externen Abhängigkeit. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, zugänglich bleiben. Ändert sich der Pfad, wird die Datei verschoben oder ist die Ressource nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail versendet, archiviert oder in isolierten Umgebungen gerendert werden müssen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich das Bild‑Linking; das Verlinken von Videos ist ein separater Medien‑Workflow und wird in diesem Beispiel bewusst nicht vermischt.

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

Verwenden Sie Links, wenn ein externes Dateimanagement beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: ein kleiner PPTX mit defekten Bild‑Abhängigkeiten ist meist weniger nützlich als eine größere, selbst‑enthaltende Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob eine Form tatsächlich ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) ist und ob sie ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Rasterbild extrahieren**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) direkt und erfordert nicht mehr den älteren System‑Image‑Wrapper. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

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

Das Speichern über [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) konvertiert das extrahierte Bild in das angeforderte Ausgabeformat. Wenn Sie die im Präsentations‑Blob gespeicherten codierten Bytes benötigen statt einer konvertierten Rasterdatei, verwenden Sie stattdessen die Binärdaten der Bildressource.

### **SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) ein [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

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

SVG‑Inhalte als SVG zu behalten bewahrt die Vektorquelle innerhalb der Präsentation. Rasterexporte wie PNG oder JPEG rendern diesen Vektorinhalt zwingend in Pixel. PDF‑ oder SVG‑Folienexporte sind ebenfalls Rendering‑Operationen, daher sollten die exportierten Grafiken nicht als exakte Kopie des eingebetteten SVG angesehen werden; verwenden Sie die eingebetteten [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)‑Daten, wenn die originale Vektorressource selbst benötigt wird.

## **Ein Bild zuschneiden**

Zuschneiden ändert, welcher Bildteil innerhalb des Rahmens sichtbar ist. Die Zuschneidewerte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/) sind Prozentsätze der Quellbildabmessungen. Zuschneiden löscht die verborgenen Pixel des eingebetteten Bildes nicht sofort; es ändert nur den sichtbaren Bereich.

Das folgende Beispiel findet sicher einen Bildrahmen und wendet Zuschneidewerte an:

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

Da die verborgenen Bilddaten weiterhin vorhanden sind, kann der Zuschnitt später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Rückgängig­machbarkeit, können die zugeschnittenen Regionen wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) entfernt Bilddaten außerhalb des aktuellen Zuschneide‑Rechtecks und liefert die resultierende Bildressource zurück. Das kann die Dateigröße verringern, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel nicht mehr für ein späteres „Un‑Crop“ zur Verfügung.

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

Die Methode kann der Präsentation eine neue Bildressource hinzufügen. Wird das Originalbild auch von anderen Bildrahmen verwendet, benötigen diese weiterhin ihre bestehende Ressource, sodass das Löschen zugeschnittener Bereiche nicht zwingend die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das zugeschnittene Ergebnis in PNG.

## **Rasterbilder komprimieren**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/compressimage/) reduziert die Auflösung von Rasterbildern relativ zu der Größe, in der das Bild angezeigt wird. Es kann gleichzeitig zugeschnittene Regionen entfernen. Die Methode gibt `true` zurück, wenn das Bild skaliert oder zugeschnitten wurde, und `false`, wenn keine Änderung nötig war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/net/aspose.slides.export/picturescompression/)‑Wert, wenn eine standardisierte Zielauflösung ausreichend ist:

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

Ein benutzerdefinierter positiver DPI‑Wert kann anstelle eines Enum‑Werts übergeben werden, wenn ein spezifisches Ziel benötigt wird.

Kompression ist für Rasterbilder gedacht. SVG‑ und Metafile‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie zudem daran, dass niedrigere Auflösung und gelöschte zugeschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie die Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich betrachtet oder exportiert wird, anstatt global die niedrigste DPI anzuwenden.

## **Bild‑Transformations‑Effekte verwalten**

Für einen vollständigen Workflow, der Helligkeit, Kontrast, Farb‑Transformationen, Weichzeichnung, Alpha‑Effekte, geordnete Ketten, Inspektion, Entfernung und Round‑Trip‑Verifikation abdeckt, siehe [Image Transform Effects](/slides/de/net/image-transform-effects/).

## **Bildrahmengeometrie sperren**

Die [IPictureFrameLock](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframelock/)‑Einstellungen steuern, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Zum Beispiel bewahrt die Sperre des Seitenverhältnisses die Proportionen der Form beim Skalieren.

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

Die Sperre gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht dazu, neu zu sampeln oder dauerhaft auf dasselbe Seitenverhältnis geändert zu werden.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüllmodus „stretch“ ist, definieren die Stretch‑Offset‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Einzug von einer Kante, während negative Prozentsätze ein Herausstehen erzeugen.

Das ist anders als Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets verändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

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

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneideeigenschaften, wenn das Ziel ist, Bildkanten zu verbergen.

## **Speicher, Dateigröße und Exportüberlegungen**

Die wichtigsten Kompromisse lassen sich besser verwalten, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt behandelt werden:

- **Eingebettete Bilder** machen die Präsentation selbst‑enthaltend und sind am zuverlässigsten für das Teilen und serverseitige Rendern, jedoch erhöhen große Rasterbilder die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, aber die Präsentation ist auf externe Dateien angewiesen, die an den gespeicherten Pfaden oder Standorten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die verborgenen Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder beim Komprimieren entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern erheblich reduzieren, kostet jedoch die Quellauflösung. Sie sollte erst angewendet werden, wenn die beabsichtigte Größe auf der Folie bekannt ist.
- **SVG‑Bilder** sollten als SVG bleiben, wenn die Vektorpreservation wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektorressource selbst benötigen. Raster‑Folienexporte konvertieren stets die gerenderte Folie in Pixel.
- **Wiederholte Bilder** sollten nach Möglichkeit eine bestehende [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Präsentations‑Workflow zu laden.

Bei großen Präsentationen ist Bildoptimierung meist am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektor‑Inhalt behalten, Fotos nach ihrer tatsächlichen Anzeigengröße komprimieren, zugeschnittene Pixel nur entfernen, wenn späteres Bearbeiten nicht nötig ist, und externe Links vermeiden, sofern das Abhängigkeits‑Management nicht Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie sowie Formatierung wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Soll ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern der Bilddateien außerhalb des PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Verringert Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneideeinstellungen verbergen Bildteile, behalten jedoch die zugrundeliegenden Pixel bei. Verwenden Sie [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) oder Bildkompression mit Entfernung zugeschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach einer Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen zugeschnittener Regionen verwirft Bilddaten. Bewahren Sie das originale Quellbild außerhalb der Präsentation auf, falls später eine hochauflösende Bearbeitung nötig sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Bewahren Sie SVG‑Inhalte als SVG, wenn die Vektor‑Integrität wichtig ist. Das eingebettete [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie vermeide ich unsichere Casts beim Lesen vorhandener Folien?**

Prüfen Sie den Formtyp, bevor Sie bild‑rahmen‑spezifische Mitglieder verwenden. Ein Pattern‑Matching mit [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) oder das Filtern der Form‑Sammlung nach diesem Interface verhindert ungültige Casts und ermöglicht dem Code, Folien ohne Bildrahmen korrekt zu verarbeiten.