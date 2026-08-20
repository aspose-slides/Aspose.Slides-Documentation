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
- Beschnittene Bereiche löschen
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
description: "Bildrahmen in Präsentationen mit Aspose.Slides für C++ erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren."
---
## **Übersicht**

Ein Bildrahmen ist ein Folienobjekt, das ein Bild anzeigt. In Aspose.Slides sind die Bildressource und das Objekt, das sie anzeigt, getrennte Objekte: eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [image collection](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_images/), während ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) die Position, Größe, Linienformatierung, Drehung, Zuschneiden, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehr als einmal angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können sich auch auf verknüpfte Bilder beziehen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl beeinflusst Portabilität, Dateigröße, Extraktion und Exportverhalten, sodass es sinnvoll ist, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Ein eingebettetes Bild hinzufügen und formatieren**

Für ein eingebettetes Bild fügen Sie die Bilddaten zur Präsentation hinzu und erstellen einen Bildrahmen mit [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapecollection/addpictureframe/). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das nachfolgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen in den nativen Abmessungen des Bildes und wendet Linienformatierung sowie Drehung an:

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

Der Bildrahmen steuert die dargestellte Geometrie; das Ändern der Rahmengröße ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später beschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) bietet relative Breiten‑ und Höhen‑skalierung für den Rahmen. Ein Wert von `1.0` entspricht 100 % der ursprünglichen Bildgröße. Relative Skalierung ist nützlich, wenn ein Workflow ein Verhältnis zur Originalbildgröße beibehalten muss, anstatt die endgültigen Abmessungen manuell zu berechnen.

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

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert den externen Speicherort über den [ISlidesPicture](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/)‑Linkpfad, anstatt die Bilddaten auf dieselbe Weise einzubetten.

Verknüpfte Bilder können die Menge der in der PPTX gespeicherten Bilddaten verringern, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, zugänglich bleiben. Ändert sich der Pfad, wird die Datei verschoben oder ist die Ressource nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail versendet, archiviert oder in isolierten Umgebungen gerendert werden müssen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Ein verknüpftes Bild hinzufügen**

Das nachfolgende Beispiel erstellt einen Bildrahmen und verweist ihn auf eine lokale Bilddatei. Es befasst sich ausschließlich mit Bildverknüpfungen; Video‑Verknüpfungen sind ein separater Medien‑Workflow und werden bewusst nicht in dieses Beispiel gemischt.

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

Verwenden Sie Verknüpfungen, wenn die Verwaltung externer Dateien beabsichtigt ist. Verwenden Sie sie nicht nur als Ersatz für Kompression: Eine kleine PPTX mit defekten Bildabhängigkeiten ist in der Regel weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob ein Objekt tatsächlich ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Ein Rasterbild extrahieren**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) direkt. Das nachfolgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

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

Das Speichern über [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) konvertiert das extrahierte Bild in das angeforderte Ausgabeformat. Wenn Sie die codierten Bytes benötigen, die in der Präsentation gespeichert sind, anstatt einer konvertierten Rasterdatei, verwenden Sie stattdessen die Binärdaten der Bildressource.

### **Ein SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) ein [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

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

Das Beibehalten von SVG‑Inhalten als SVG bewahrt die Vektorquelle innerhalb der Präsentation. Rasterexporte wie PNG oder JPEG rendern diesen Vektorinhalt notwendigerweise in Pixel. Der PDF‑ oder SVG‑Folienexport ist ebenfalls ein Rendering‑Vorgang, sodass die exportierten Grafiken nicht als exakte Kopie des original eingebetteten SVG behandelt werden sollten; verwenden Sie die eingebetteten [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Daten, wenn die ursprüngliche Vektorressource selbst benötigt wird.

## **Ein Bild zuschneiden**

Das Zuschneiden ändert, welcher Teil eines Bildes im Rahmen sichtbar ist. Die Zuschneide‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/) sind Prozentsätze der Abmessungen des Quellbildes. Das Zuschneiden löscht die verborgenen Pixel nicht sofort aus dem eingebetteten Bild; es ändert nur den sichtbaren Bereich.

Das nachfolgende Beispiel findet sicher einen Bildrahmen und wendet Zuschneide‑Werte an:

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

Da die verborgenen Bilddaten weiterhin vorhanden sind, kann der Zuschnitt später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Rückgängig‑Machbarkeit, können die zugeschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) entfernt Bilddaten außerhalb des aktuellen Zuschnittsrechtecks und gibt die resultierende Bildressource zurück. Dies kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel nicht mehr für einen späteren Entzuschneide‑Vorgang zur Verfügung.

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

Die Methode kann der Präsentation eine neue Bildressource hinzufügen. Wenn das Originalbild auch von anderen Bildrahmen verwendet wird, benötigen diese Rahmen weiterhin ihre vorhandene Ressource, sodass das Löschen zugeschnittener Bereiche nicht unbedingt die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das zugeschnittene Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/compressimage/) reduziert die Auflösung von Rasterbildern relativ zu der Größe, in der das Bild angezeigt wird. Es kann gleichzeitig zugeschnittene Bereiche entfernen. Die Methode gibt `true` zurück, wenn das Bild skaliert oder zugeschnitten wurde, und `false`, wenn keine Änderung erforderlich war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/picturescompression/)‑Wert, wenn eine standardisierte Zielauflösung ausreichend ist:

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

Ein individuell positives DPI kann anstelle eines Aufzählungswerts übergeben werden, wenn ein spezifisches Ziel erforderlich ist.

Kompression ist für Rasterbilder gedacht. SVG‑ und Metadatei‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie auch daran, dass niedrigere Auflösung und gelöschte zugeschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich angezeigt oder exportiert wird, anstatt global die niedrigste DPI zu verwenden.

## **Bildeffekte untersuchen**

Bildeffekte werden auf dem vom Rahmen verwendeten Bild gespeichert. Die Bild‑Transformations‑Sammlung kann Effekte wie feste Alpha‑Modulation für Transparenz und Luminanz für Helligkeit und Kontrast enthalten. Das folgende Beispiel liest sicher beide Arten von Effekten aus dem ersten Bildrahmen einer Folie:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
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
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

Diese Effekte ändern, wie das Bild im Rahmen gerendert wird; sie überschreiben nicht die originalen eingebetteten Bildbytes.

## **Geometrie des Bildrahmens sperren**

Die [IPictureFrameLock](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframelock/)‑Einstellungen steuern, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Zum Beispiel bewahrt die [aspect‑ratio lock](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) die Proportionen der Form, während sie skaliert wird.

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

Die Sperre gilt für das Bildrahmen‑Shape. Sie zwingt das Quellbild nicht, neu gesampelt zu werden oder dauerhaft das gleiche Seitenverhältnis anzunehmen.

## **StretchOffset‑Werte anpassen**

Wenn der Bild‑Füllmodus „stretch“ ist, definieren die Stretch‑Offset‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Einzug von einer Kante, während negative Prozentsätze ein Herausstehen erzeugen.

Dies unterscheidet sich vom Zuschneiden. Zuschneide‑Werte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

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

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Kanten des Quellbildes zu verbergen.

## **Speicher, Dateigröße und Export‑Überlegungen**

Die wichtigsten Kompromisse lassen sich leichter handhaben, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt betrachtet werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, aber große Rasterbilder erhöhen die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, aber die Präsentation ist von externen Dateien abhängig, die an den gespeicherten Pfaden oder Orten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die versteckten Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern erheblich reduzieren, kostet jedoch die Quellauflösung. Sie sollte nach Bekanntwerden der endgültigen Größe auf der Folie angewendet werden.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektorpreservation wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektorressource selbst benötigen. Raster‑Folien‑Exporte konvertieren stets die gerenderte Folie in Pixel.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei wiederholt in den Präsentations‑Workflow zu laden.

Für große Präsentationen ist Bildoptimierung meist am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektorinhalt behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, zugeschnittene Pixel nur entfernen, wenn eine spätere Bearbeitung nicht erforderlich ist, und externe Verknüpfungen vermeiden, sofern das Abhängigkeits‑Management nicht Teil des Bereitstellungsdesigns ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) ist ein Shape auf einer Folie, das ein Bild anzeigt und rahmenbezogene Geometrie und Formatierungen wie Größe, Drehung, Zuschneide‑Werte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Halten von Bilddateien außerhalb der PPTX beabsichtigt ist und die externen Orte zuverlässig verwaltet werden können.

**Reduziert Zuschneiden die PPTX‑Dateigröße?**

Nicht von selbst. Normale Zuschneide‑Einstellungen verbergen Teile des Quellbildes, behalten aber die zugrunde liegenden Pixel. Verwenden Sie [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) oder Bildkompression mit Entfernen zugeschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung verringern, und das Entfernen zugeschnittener Bereiche verwirft Bilddaten. Bewahren Sie das originale Quellbild außerhalb der Präsentation auf, wenn später eine hochauflösende Bearbeitung erforderlich sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Bewahren Sie SVG‑Inhalte als SVG auf, wenn Vektor‑Treue wichtig ist. Das eingebettete [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Shape‑Typ, bevor Sie bildrahmenspezifische Member verwenden. Testen Sie das Shape mit [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) vor dem Anwenden eines Laufzeit‑Casts und weisen Sie das Cast‑Ergebnis einer lokalen Variable zu, bevor Sie bildrahmenspezifische Member ansprechen.