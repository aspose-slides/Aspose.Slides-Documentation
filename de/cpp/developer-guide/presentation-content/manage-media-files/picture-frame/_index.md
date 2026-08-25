---
title: Bildrahmen in Präsentationen mit C++ verwalten
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/cpp/picture-frame/
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
- zugeschnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmen-Formatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren Sie Bildrahmen in Präsentationen mit Aspose.Slides für C++."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild darstellt. In Aspose.Slides sind die Bildressource und die Form, die sie anzeigt, separate Objekte: eine [Präsentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [Bildersammlung](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_images/), während ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) Position, Größe, Linienformatierung, Drehung, Zuschneiden, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehr als einmal angezeigt werden soll. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können auch auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl beeinflusst Portabilität, Dateigröße, Extraktion und Exportverhalten, sodass es sinnvoll ist, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Ein eingebettetes Bild hinzufügen und formatieren**

Für ein eingebettetes Bild fügen Sie die Bilddaten zur Präsentation hinzu und erstellen einen Bildrahmen mit [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapecollection/addpictureframe/). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbstständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen in den nativen Abmessungen des Bildes und wendet Linienformatierung sowie Drehung an:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmen‑Größe ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später zugeschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) bietet relative Breiten‑ und Höhenskalierung für den Rahmen. Ein Wert von `1.0` entspricht 100 % der ursprünglichen Bildgröße. Relative Skalierung ist nützlich, wenn ein Workflow eine Beziehung zur Ausgangsbildgröße beibehalten muss, anstatt die Endabmessungen manuell zu berechnen.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie resampelt oder komprimiert das eingebettete Bild nicht.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist damit die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert über den [ISlidesPicture](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/) Linkpfad einen externen Speicherort, anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die Menge an Bilddaten im PPTX reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, zugänglich bleiben. Ändert sich der Pfad, wird die Datei verschoben oder die Ressource ist nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail verschickt, archiviert oder in isolierten Umgebungen gerendert werden, sind eingebettete Bilder in der Regel zuverlässiger.

### **Ein verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich das Bild‑Linking; das Verknüpfen von Videos ist ein separater Medien‑Workflow und wird bewusst nicht mit diesem Beispiel vermischt.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Verwenden Sie Links, wenn das Management externer Dateien beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: ein kleiner PPTX mit defekten Bildabhängigkeiten ist meist weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob die Form tatsächlich ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Ein Rasterbild extrahieren**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) direkt. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Das Speichern über [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die im Präsentationspaket kodierten Bytes benötigen, verwenden Sie stattdessen die binären Daten der Bildressource.

### **Ein SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) ein [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, ohne das Bild zuerst zu rasterisieren.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

SVG‑Inhalte als SVG zu behalten bewahrt die Vektor‑Quelle innerhalb der Präsentation. Raster‑Exporte wie PNG oder JPEG rendern diesen Vektorinhalt zwangsläufig zu Pixeln. PDF‑ oder SVG‑Folienexporte sind ebenfalls Rendering‑Operationen, sodass die exportierten Grafiken nicht als exakte Kopie des ursprünglichen eingebetteten SVG behandelt werden sollten; verwenden Sie die eingebetteten [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Daten, wenn die originale Vektor‑Ressource benötigt wird.

## **Ein Bild zuschneiden**

Zuschneiden ändert, welcher Bildteil im Rahmen sichtbar ist. Die Zuschneidewerte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/) sind Prozentsätze der Quelle‑Bildabmessungen. Das Zuschneiden löscht die versteckten Pixel des eingebetteten Bildes nicht sofort; es ändert lediglich den sichtbaren Bereich.

Das folgende Beispiel findet sicher einen Bildrahmen und wendet Zuschneidewerte an:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Da die versteckten Bilddaten weiterhin vorhanden sind, kann das Zuschneiden später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Rückgängig‑Machbarkeit, können die zugeschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) entfernt Bilddaten außerhalb des aktuellen Zuschneide‑Rechtecks und gibt die resultierende Bildressource zurück. Dies kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nachdem die Präsentation gespeichert wurde, stehen die entfernten Pixel nicht mehr für ein späteres „Uncrop“ zur Verfügung.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

Die Methode kann eine neue Bildressource zur Präsentation hinzufügen. Wird das Originalbild zudem von anderen Bildrahmen verwendet, benötigen diese weiterhin ihre vorhandene Ressource, sodass das Löschen zugeschnittener Bereiche nicht zwangsläufig die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/compressimage/) reduziert die Auflösung eines Rasterbildes relativ zu der Größe, in der das Bild angezeigt wird. Es kann gleichzeitig zugeschnittene Bereiche entfernen. Die Methode gibt `true` zurück, wenn das Bild skaliert oder zugeschnitten wurde, und `false`, wenn keine Änderung erforderlich war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/picturescompression/)‑Wert, wenn eine Standard‑Zielauflösung ausreicht:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Ein benutzerdefinierter positiver DPI‑Wert kann anstelle eines Enum‑Werts übergeben werden, wenn ein spezielles Ziel erforderlich ist.

Kompression ist für Rasterbilder gedacht. SVG‑ und Metadatei‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie auch daran, dass niedrigere Auflösung und gelöschte zugeschnittene Bereiche aus der optimierten Präsentation nicht wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich angezeigt oder exportiert wird, anstatt global die niedrigste DPI anzuwenden.

## **Bildtransformations‑Effekte verwalten**

Für einen vollständigen Workflow zu Helligkeit, Kontrast, Farbtransformationen, Weichzeichnung, Alpha‑Effekten, geordneten Ketten, Inspektion, Entfernung und Rundreise‑Verifizierung siehe [Image Transform Effects](/slides/de/cpp/image-transform-effects/).

## **Geometrie des Bildrahmens sperren**

Die Einstellungen des [IPictureFrameLock](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframelock/) bestimmen, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert werden. Beispielsweise bewahrt das [Seitenverhältnis‑Sperren](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) die Proportionen der Form beim Skalieren.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die Sperre gilt für die Bildrahmen‑Form. Sie zwingt das Quell‑Bild nicht, neu gesampelt oder dauerhaft auf dasselbe Seitenverhältnis geändert zu werden.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüllmodus „Strecken“ ist, definieren die Stretch‑Offset‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Einzug von einer Kante, während negative Prozentsätze ein Herausstehen erzeugen.

Das ist anders als Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quell‑Bildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Kanten des Quell‑Bildes zu verbergen.

## **Speicher, Dateigröße und Export‑Überlegungen**

Die wichtigsten Kompromisse lassen sich leichter handhaben, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt betrachtet werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind die zuverlässigste Wahl für das Teilen und serverseitige Rendern, aber große Rasterbilder erhöhen die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, jedoch hängt die Präsentation von externen Dateien ab, die an den gespeicherten Pfaden oder Standorten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die versteckten Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern erheblich reduzieren, kostet jedoch Auflösung der Quelle. Sie sollte erst nach Festlegung der endgültigen Größe auf der Folie angewendet werden.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektor‑Erhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folien‑Exporte konvertieren die gerenderte Folie stets zu Pixeln.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Workflow zu laden.

Bei großen Präsentationen ist Bildoptimierung meist am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektor‑Inhalt behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, zugeschnittene Pixel nur entfernen, wenn nachträgliche Bearbeitung nicht nötig ist, und externe Links nur einsetzen, wenn das Abhängigkeits‑Management Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie sowie Formatierung wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern von Bilddateien aus dem PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Reduziert Zuschneiden die PPTX‑Dateigröße?**

Nicht von selbst. Normale Zuschneide‑Einstellungen verbergen Teile des Quell‑Bildes, behalten aber die zugrunde liegenden Pixel. Verwenden Sie [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) oder Bildkompression mit Entfernen zugeschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen zugeschnittener Bereiche verwirft Bilddaten. Bewahren Sie das ursprüngliche Quell‑Bild außerhalb der Präsentation auf, wenn später eine Bearbeitung in hoher Auflösung erforderlich sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalte als SVG, wenn die Vektor‑Treue wichtig ist. Das eingebettete [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Member verwenden. Testen Sie die Form mit [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) vor dem Anwenden eines Laufzeit‑Casts und weisen Sie das Cast‑Ergebnis einer lokalen Variable zu, bevor Sie bildrahmenspezifische Member ansprechen.