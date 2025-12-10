---
title: Verwalten von Bildrahmen in Präsentationen mit C++
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
- Zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmen-Formatierung
- Bildrahmen-Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design von Folien."
---

Ein Bildrahmen ist eine Form, die ein Bild enthält – es ist wie ein Bild in einem Rahmen. 

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—an, mit denen man schnell Präsentationen aus Bildern erstellen kann. 

{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage]‑Objekt, indem Sie ein Bild zur [IImagescollection] hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein [PictureFrame] basierend auf Breite und Höhe des Bildes über die Methode `AddPictureFrame`, die vom Form‑Objekt bereitgestellt wird, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie einen Bildrahmen (der das Bild enthält) zur Folie hinzu.
7. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lädt das Bild, das zur Bildsammlung der Präsentation hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildersammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt einen Bildrahmen zur Folie hinzu
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

Bildrahmen ermöglichen es Ihnen, schnell Präsentationsfolien auf Basis von Bildern zu erstellen. Wenn Sie Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Ein‑/Ausgabe‑Operationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Sie können diese Seiten ansehen: Bild zu JPG konvertieren [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); JPG zu Bild konvertieren [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); JPG zu PNG konvertieren [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), PNG zu JPG konvertieren [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); PNG zu SVG konvertieren [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), SVG zu PNG konvertieren [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erstellen. 

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [IPPImage]‑Objekt, indem Sie ein Bild zur [IImagescollection] hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lädt das Bild, das zur Bildsammlung der Präsentation hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildersammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt einen Bildrahmen zur Folie hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierungsbreite und -höhe
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame]-Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Das nachstehende Codebeispiel zeigt, wie ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.
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

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame]-Formen platziert sind, ermöglicht Aspose.Slides für C++ das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung der Folie können Sie jedes [PictureFrame] identifizieren, prüfen, ob das zugrunde liegende [IPPImage] SVG‑Inhalt enthält, und das Bild dann auf Festplatte oder in einem Stream im nativen SVG‑Format speichern.

Der folgende Code demonstriert, wie ein SVG‑Bild aus einem Bildrahmen extrahiert wird:
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


## **Transparenz eines Bildes ermitteln**

Aspose.Slides ermöglicht es Ihnen, den auf ein Bild angewendeten Transparenzeffekt zu erhalten. Dieser C++‑Code demonstriert die Operation:
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
Alle auf Bilder angewendeten Effekte finden Sie in [Aspose::Slides::Effects](https://reference.aspose.com/slides/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Bildrahmen-Formatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen anpassen, um spezifischen Anforderungen zu entsprechen.

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage]‑Objekt, indem Sie ein Bild zur [IImagescollection] hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein `PictureFrame` basierend auf Breite und Höhe des Bildes über die [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9)‑Methode, die vom [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection)‑Objekt bereitgestellt wird, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie den Bildrahmen (der das Bild enthält) zur Folie hinzu.
7. Legen Sie die Linienfarbe des Bildrahmens fest.
8. Legen Sie die Linienstärke des Bildrahmens fest.
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.  
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bildrahmen (der das Bild enthält) zur Folie hinzu.
11. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Lädt das Bild, das zur Bildsammlung der Präsentation hinzugefügt werden soll
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildersammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt einen Bildrahmen zur Folie hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierungsbreite und -höhe
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert title="Tip" color="primary" %}}

Aspose hat kürzlich einen kostenlosen Collage Maker entwickelt. Wenn Sie jemals JPG/JPEG‑ oder PNG‑Bilder zusammenführen, Raster‑Collagen erstellen möchten, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Ein Bild als Link hinzufügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentation einzubetten. Dieser C++‑Code zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:
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

// Fügt der Folie einen Bildrahmen hinzu
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Beschneidet das Bild (Prozentwerte)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Speichert das Ergebnis
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Zugeschnittene Bereiche eines Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes löschen möchten, können Sie die Methode [IPictureFillFormat::DeletePictureCroppedAreas()] verwenden. Diese Methode gibt das zugeschnittene Bild zurück oder das Originalbild, wenn ein Zuschneiden nicht nötig ist.

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```


{{% alert title="NOTE" color="warning" %}} 

Die Methode [IPictureFillFormat::DeletePictureCroppedAreas()] fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame] verwendet wird, kann diese Vorgehensweise die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF‑Metadateien während des Zuschneidens in ein Raster‑PNG‑Bild. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [set_AspectRatioLocked()] verwenden, um die Einstellung *Seitenverhältnis sperren* festzulegen. 

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

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das darin enthaltene Bild. 

{{% /alert %}}

## **Die StretchOff‑Eigenschaft verwenden**

Mit den Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) und [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) des [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format)-Interfaces und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format) können Sie ein Füllrechteck angeben. 

Wenn ein Bild gestreckt werden soll, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz gibt ein Inset an. Ein negativer Prozentsatz gibt ein Outset an.

1. Erstellen Sie eine Instanz der [Presentation]-Klasse. 
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erstellen Sie ein Bild. 
5. Legen Sie den Fülltyp der Form fest. 
6. Legen Sie den Bildfüllmodus der Form fest. 
7. Fügen Sie ein Bild hinzu, um die Form zu füllen. 
8. Geben Sie Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an. 
9. Speichern Sie die modifizierte Präsentation als PPTX‑Datei. 

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Setzt das Bild von jeder Seite im Shape‑Körper gestreckt
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

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame] zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Möglichkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und Performance aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hilft, die Präsentationsgröße zu reduzieren, erfordert jedoch, dass die externen Dateien weiterhin zugänglich sind. Aspose.Slides ermöglicht das Hinzufügen von Bildern per Link, um die Dateigröße zu verringern.

**Wie kann ich ein Bildobjekt vor unbeabsichtigtem Verschieben/Größenändern schützen?**

Verwenden Sie [shape locks] für einen [PictureFrame] (z. B. Deaktivieren des Verschiebens oder Größens änderns). Der Sperrmechanismus wird für Formen in einem separaten [Schutzartikel](/slides/de/cpp/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen unterstützt, einschließlich [PictureFrame].

**Wird die Vektor‑Treue von SVG beim Export einer Präsentation zu PDF/Bildern erhalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame] als Originalvektor. Beim Export zu PDF oder Rasterformaten kann das Ergebnis je nach Exporteinstellungen gerastert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.