---
title: Bilderrahmen
type: docs
weight: 10
url: /cpp/picture-frame/
keywords: "Bilderrahmen hinzufügen, Bilderrahmen erstellen, Bild hinzufügen, Bild erstellen, Bild extrahieren, StretchOff-Eigenschaft, Bilderrahmenformatierung, Bilderrahmeneigenschaften, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Fügen Sie einen Bilderrahmen zu einer PowerPoint-Präsentation in C++ hinzu."
---

Ein Bilderrahmen ist eine Form, die ein Bild enthält - es ist wie ein Bild in einem Rahmen.

Sie können ein Bild über einen Bilderrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bilderrahmen formatieren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es den Nutzern ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

## **Bilderrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation-Klasse](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Holen Sie sich eine Referenz auf eine Folie durch ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) hinzufügen, die mit dem Präsentationsobjekt verbunden ist, das zur Füllung der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen [Bilderrahmen](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) basierend auf der Breite und Höhe des Bildes über die Methode `AddPictureFrame`, die vom Formobjekt, das mit der referenzierten Folie verbunden ist, bereitgestellt wird.
6. Fügen Sie der Folie einen Bilderrahmen (der das Bild enthält) hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man einen Bilderrahmen erstellt:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lädt das Bild, das in die Präsentation Bildsammlung hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bilderrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierung Breite und Höhe
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Wendet einige Formatierungen auf den Bilderrahmen an
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Bilderrahmen ermöglichen es Ihnen, schnell Präsentationsfolien basierend auf Bildern zu erstellen. Wenn Sie den Bilderrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Eingabe-/Ausgabeoperationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Sie sollten sich diese Seiten ansehen: konvertieren [Bild zu JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Bilderrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplizierteren Bilderrahmen erstellen. 

1. Erstellen Sie eine Instanz der [Presentation-Klasse](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Holen Sie sich eine Referenz auf eine Folie durch ihren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) hinzufügen, die mit dem Präsentationsobjekt verbunden ist, das zur Füllung der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bilderrahmen an.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man einen Bilderrahmen mit relativer Skalierung erstellt:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lädt das Bild, das in die Präsentation Bildsammlung hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bilderrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierung Breite und Höhe
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bild aus dem Bilderrahmen extrahieren**

Sie können Bilder aus [Bilderrahmen](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Das folgende Codebeispiel zeigt, wie man ein Bild aus dem Dokument "sample.pptx" extrahiert und im PNG-Format speichert.

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

## **Transparenz des Bildes erhalten**

Aspose.Slides ermöglicht es Ihnen, die Transparenz eines Bildes zu erhalten. Dieser C++-Code demonstriert den Vorgang:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Bildtransparenz: ") + transparencyValue);
    }
}
```

## **Bilderrahmenformatierung**

Aspose.Slides bietet viele Formatierungsoptionen, die auf einen Bilderrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bilderrahmen ändern, um ihn an spezifische Anforderungen anzupassen.

1. Erstellen Sie eine Instanz der [Presentation-Klasse](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Holen Sie sich eine Referenz auf eine Folie durch ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) hinzufügen, die mit dem Präsentationsobjekt verbunden ist, das zur Füllung der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen `Bilderrahmen` basierend auf der Breite und Höhe des Bildes über die [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) Methode, die vom [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) Objekt bereitgestellt wird, das mit der referenzierten Folie verbunden ist.
6. Fügen Sie der Folie den Bilderrahmen (der das Bild enthält) hinzu.
7. Setzen Sie die Linienfarbe des Bilderrahmens.
8. Setzen Sie die Linienbreite des Bilderrahmens.
9. Drehen Sie den Bilderrahmen, indem Sie einen positiven oder negativen Wert angeben.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie der Folie den Bilderrahmen (der das Bild enthält) hinzu.
11. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code demonstriert den Prozess der Bilderrahmenformatierung:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Lädt das Bild, das in die Präsentation Bildsammlung hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bilderrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierung Breite und Höhe
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tipp" color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG-Bilder zusammenführen oder [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) müssen, können Sie diesen Dienst nutzen. 

{{% /alert %}}

## **Bild als Link hinzufügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentationen einzufügen. Dieser C++-Code zeigt Ihnen, wie man ein Bild und ein Video in einen Platzhalter einfügt:

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

## **Bild zuschneiden**

Dieser C++-Code zeigt Ihnen, wie man ein vorhandenes Bild auf einer Folie zuschneidet: 

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Erstellt ein neues Bildobjekt
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Fügt einen Bilderrahmen zu einer Folie hinzu
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Schneidet das Bild (Prozentwerte)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Speichert das Ergebnis
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## Entfernen der zugeschnittenen Bereiche des Bildes

Wenn Sie die zugeschnittenen Bereiche eines Bildes, das in einem Rahmen enthalten ist, löschen möchten, können Sie die Methode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Ursprungsbild zurück, wenn das Zuschneiden nicht erforderlich ist.

Dieser C++-Code demonstriert den Vorgang: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Holt den Bilderrahmen von der ersten Folie
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Löscht die zugeschnittenen Bereiche des Bilderrahmenbildes und gibt das zugeschnittene Bild zurück
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Speichert das Ergebnis
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="HINWEIS" color="warning" %}} 

Die Methode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wenn das Bild nur im bearbeiteten [Bilderrahmen](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) verwendet wird, kann diese Einstellung die Präsentationsgröße verringern. Andernfalls wird die Anzahl der Bilder in der resultierenden Präsentation erhöht.

Diese Methode konvertiert WMF/EMF-Metadaten in ein raster PNG-Bild während des Zuschneidevorgangs. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, auch wenn Sie die Bilddimensionen ändern, können Sie die Methode [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) verwenden, um die Einstellung *Seitenverhältnis sperren* festzulegen. 

Dieser C++-Code zeigt Ihnen, wie man das Seitenverhältnis einer Form sperrt:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// Setzt die Form, um das Seitenverhältnis beim Ändern der Größe beizubehalten
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="HINWEIS" color="warning" %}} 

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form und nicht das Bild, das sie enthält.

{{% /alert %}}

## **Strecken-Eigenschaft verwenden**

Mit den Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) und [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) aus der [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) Schnittstelle und der [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format) Klasse können Sie ein Füllrechteck angeben. 

Wenn das Strecken eines Bildes festgelegt ist, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Offset von der entsprechenden Kante des Begrenzungsrahmens der Form definiert. Ein positiver Prozentsatz gibt einen Innenabstand an. Ein negativer Prozentsatz gibt einen Außenabstand an.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie durch ihren Index.
3. Fügen Sie eine Rechteck-`AutoShape` hinzu. 
4. Erstellen Sie ein Bild.
5. Legen Sie den Fülltyp der Form fest.
6. Legen Sie den Bildfüllmodus der Form fest.
7. Fügen Sie ein festgelegtes Bild hinzu, um die Form auszufüllen.
8. Geben Sie die Bildversätze von der entsprechenden Kante des Begrenzungsrahmens der Form an.
9. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code demonstriert einen Prozess, bei dem eine Strecken-Eigenschaft verwendet wird:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Setzt das Bild, das von jeder Seite des Formkörpers gestreckt wird
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```