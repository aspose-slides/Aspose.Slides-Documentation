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
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Rasterbild
- Vektorbild
- Bild zuschneiden
- Zuschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmenformatierung
- Bildrahmeneigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ hinzu. Optimieren Sie Ihren Workflow und verbessern Sie das Design Ihrer Folien."
---
## **Einleitung**

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen.

Sie können einem Folie über einen Bildrahmen ein Bild hinzufügen. Auf diese Weise formatieren Sie das Bild, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="primary" %}} 
Aspose bietet kostenlose Konverter – [JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt) – die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 
{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation).
2. Holen Sie sich eine Folienreferenz über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_p_p_image)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_image_collection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie über die Methode `AddPictureFrame` des Formobjekts, das mit der referenzierten Folie verknüpft ist, ein [PictureFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_frame) basierend auf Breite und Höhe des Bildes.
6. Fügen Sie einen Bildrahmen (der das Bild enthält) zur Folie hinzu.
7. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C++‑Code zeigt, wie Sie einen Bildrahmen erstellen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lädt das Bild, das der Bildsammlung der Präsentation hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bildrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierungsbreite und -höhe
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Wendet einige Formatierungen auf den Bildrahmen an
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Bildrahmen ermöglichen es, schnell Präsentationsfolien auf Basis von Bildern zu erstellen. Kombiniert man Bildrahmen mit den Speicheroptionen von Aspose.Slides, kann man Ein- und Ausgabevorgänge manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Möglicherweise möchten Sie diese Seiten ansehen: Bild zu [JPG konvertieren](https://products.aspose.com/slides/de/cpp/conversion/image-to-jpg/); [JPG zu Bild konvertieren](https://products.aspose.com/slides/de/cpp/conversion/jpg-to-image/); [JPG zu PNG konvertieren](https://products.aspose.com/slides/de/cpp/conversion/jpg-to-png/), [PNG zu JPG konvertieren](https://products.aspose.com/slides/de/cpp/conversion/png-to-jpg/); [PNG zu SVG konvertieren](https://products.aspose.com/slides/de/cpp/conversion/png-to-svg/), [SVG zu PNG konvertieren](https://products.aspose.com/slides/de/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erzeugen. 

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation).
2. Holen Sie sich eine Folienreferenz über ihren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_p_p_image)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_image_collection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C++‑Code zeigt, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lädt das Bild, das der Bildsammlung der Präsentation hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bildrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierungsbreite und -höhe
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_frame)-Objekten extrahieren und sie im PNG-, JPG- und anderen Formaten speichern. Das nachfolgende Codebeispiel demonstriert, wie man ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG-Format speichert.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **SVG‑Bilder aus Bildrahmen extrahieren**

Enthält eine Präsentation SVG‑Grafiken, die innerhalb von [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für C++ das Abrufen der originalen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung einer Folie können Sie jedes [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrundeliegende [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) SVG‑Inhalt enthält, und das Bild dann im nativen SVG-Format auf Festplatte oder in einen Stream speichern.

Das folgende Codebeispiel zeigt, wie ein SVG‑Bild aus einem Bildrahmen extrahiert wird:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Transparenz eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Dieser C++‑Code demonstriert den Vorgang:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
Alle auf Bilder angewendeten Effekte finden Sie in [Aspose::Slides::Effects](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Helligkeit und Kontrast eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen von Helligkeits‑ und Kontrasteffekten, die auf ein Bild angewendet wurden. Das Interface [ILuminance](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iluminance/) repräsentiert diesen Bildtransformations‑Effekt.

Dieser C++‑Code zeigt, wie die Helligkeits‑ und Kontrasteinstellungen eines Bildrahmens abgerufen werden:

```c++
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Bildrahmen formatieren**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen an spezifische Anforderungen anpassen.

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation).
2. Holen Sie sich eine Folienreferenz über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_p_p_image)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_image_collection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie über die Methode [AddPictureFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) ein `PictureFrame` basierend auf Breite und Höhe des Bildes, das vom [IShapes](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_shape_collection)-Objekt der referenzierten Folie bereitgestellt wird.
6. Fügen Sie den Bildrahmen (der das Bild enthält) zur Folie hinzu.
7. Setzen Sie die Linienfarbe des Bildrahmens.
8. Setzen Sie die Linienbreite des Bildrahmens.
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bildrahmen (der das Bild enthält) erneut zur Folie hinzu.
11. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C++‑Code demonstriert den Bildrahmen‑Formatierungsprozess:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Lädt das Bild, das der Bildsammlung der Präsentation hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bildrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierungsbreite und -höhe
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}
Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/de/collage) entwickelt. Wenn Sie jemals [JPG/JPEG zusammenführen](https://products.aspose.app/slides/de/collage/jpg) oder PNG‑Bilder [zu Gittern aus Fotos erstellen](https://products.aspose.app/slides/de/collage/photo-grid) müssen, können Sie diesen Service nutzen. 
{{% /alert %}}

## **Ein Bild als Link hinzufügen**

Um die Dateigröße von Präsentationen zu reduzieren, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentation einzubetten. Dieser C++‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bilder zuschneiden**

Dieser C++‑Code zeigt, wie ein vorhandenes Bild auf einer Folie zugeschnitten wird: 

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Erstellt ein neues Bildobjekt
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Fügt einer Folie einen Bildrahmen hinzu
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Zuschneiden des Bildes (Prozentwerte)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Speichert das Ergebnis
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Zugeschnittene Bereiche eines Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes entfernen möchten, können Sie die Methode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Originalbild zurück, falls kein Zuschnitt erforderlich ist.

Dieser C++‑Code demonstriert den Vorgang: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Holt den Bildrahmen von der ersten Folie
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Löscht zugeschnittene Bereiche des Bildrahmen‑Bildes und gibt das zugeschnittene Bild zurück
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Speichert das Ergebnis
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
Die Methode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) fügt das zugeschnittene Bild der Bildsammlung der Präsentation hinzu. Wird das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) verwendet, kann diese Einstellung die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF‑Metadateien während des Zuschnittvorgangs in Raster‑PNG‑Bilder. 
{{% /alert %}}

## **Bilder komprimieren**

Sie können ein Bild in einer Präsentation mit der Methode [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/compressimage/) komprimieren.
Diese Methode komprimiert ein Bild, indem sie seine Größe basierend auf der Formgröße und der angegebenen Auflösung reduziert, mit der Option, zugeschnittene Bereiche zu löschen.

Sie passt die Bildgröße und Auflösung ähnlich der PowerPoint‑Funktion **Bildformat -> Bilder komprimieren -> Auflösung** an.

Die folgenden C++‑Beispiele zeigen, wie Sie ein Bild in einer Präsentation komprimieren, indem Sie eine Zielauflösung angeben und optional zugeschnittene Bereiche entfernen:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Bild mit einer Zielauflösung von 150 DPI (Web-Auflösung) komprimieren und zugeschnittene Bereiche entfernen.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Ergebnis der Komprimierung prüfen.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Oder direkt einen benutzerdefinierten DPI‑Wert verwenden:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Bild auf 150 DPI (Web-Auflösung) komprimieren, zugeschnittene Bereiche entfernen.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Die Methode konvertiert das Bild zu einer niedrigeren Auflösung basierend auf der Größe der Form und dem angegebenen DPI. Zuschneiderte Regionen können ebenfalls gelöscht werden, um die Dateigröße zu optimieren.
Falls das Bild ein Metafile (WMF/EMF) oder SVG ist, wird keine Komprimierung angewendet. Ebenso wird die JPEG‑Qualität je nach Auflösung erhalten oder leicht reduziert, ähnlich wie PowerPoint bei hochauflösenden JPEGs.
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, auch wenn Sie die Bildabmessungen ändern, können Sie die Methode [set_AspectRatioLocked()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) verwenden, um die Einstellung *Lock Aspect Ratio* zu setzen. 

Dieser C++‑Code zeigt, wie Sie das Seitenverhältnis einer Form sperren:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
Diese *Lock Aspect Ratio*-Einstellung bewahrt nur das Seitenverhältnis der Form und nicht das des darin enthaltenen Bildes.
{{% /alert %}}

## **Verwenden der StretchOff‑Eigenschaft**

Durch die Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) und [StretchOffsetBottom](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) aus dem Interface [IPictureFillFormat](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_picture_fill_format) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format) können Sie ein Füllrechteck angeben. 

Wenn das Strecken eines Bildes angegeben ist, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz gibt ein Inset an. Ein negativer Prozentsatz gibt ein Outset an.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation)‑Klasse.
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erstellen Sie ein Bild.
5. Setzen Sie den Fülltyp der Form.
6. Setten Sie den Bildfüllmodus der Form.
7. Fügen Sie ein Bild zum Füllen der Form hinzu.
8. Geben Sie Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an
9. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C++‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und -Leistung aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße gering, erfordert jedoch, dass die externen Dateien zugänglich bleiben. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [shape locks](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/get_pictureframelock/) für ein [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) (z. B. das Verschieben oder die Größenänderung deaktivieren). Der Sperrmechanismus wird in einem separaten [Schutz‑Artikel](/slides/de/cpp/applying-protection-to-presentation/) beschrieben und für verschiedene Formtypen unterstützt, einschließlich [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/).

**Wird die Vektor‑Treue von SVG beim Exportieren einer Präsentation in PDF/Bilder beibehalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Exportieren zu PDF](/slides/de/cpp/convert-powerpoint-to-pdf/) oder zu [Rasterformaten](/slides/de/cpp/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; das Vorhandensein des ursprünglichen SVG als Vektor wird durch das Extraktionsverhalten bestätigt.