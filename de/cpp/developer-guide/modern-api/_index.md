---
title: Bildverarbeitung mit der Modernen API verbessern
linktitle: Moderne API
type: docs
weight: 280
url: /de/cpp/modern-api/
keywords:
- System.Drawing
- moderne API
- Zeichnen
- Folienvorschau
- Folie zu Bild
- Formvorschau
- Form zu Bild
- Präsentationsvorschau
- Präsentation zu Bildern
- Bild hinzufügen
- Grafik hinzufügen
- C++
- Aspose.Slides
description: "Modernisieren Sie die Folienbildverarbeitung, indem Sie veraltete Bild-APIs durch die C++ Moderne API ersetzen, um nahtlose PowerPoint- und OpenDocument-Automatisierung zu ermöglichen."
---
## **Einleitung**

Derzeit hat die Aspose.Slides für C++-Bibliothek Abhängigkeiten in ihrer öffentlichen API von den folgenden Klassen aus System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/de/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/de/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/de/cpp/system.drawing/bitmap/)

Ab Version 24.4 ist diese öffentliche API als veraltet markiert.

Um die Abhängigkeiten von System::Drawing in der öffentlichen API zu entfernen, haben wir die so genannte „Modern API“ hinzugefügt. Methoden mit [System::Drawing::Image](https://reference.aspose.com/slides/de/cpp/system.drawing/image/) und [System::Drawing::Bitmap](https://reference.aspose.com/slides/de/cpp/system.drawing/bitmap/) sind als veraltet gekennzeichnet und sollten durch die entsprechenden Methoden der Modern API ersetzt werden. Methoden mit [System::Drawing::Graphics](https://reference.aspose.com/slides/de/cpp/system.drawing/graphics/) sind ebenfalls veraltet und haben keinen direkten Ersatz in der Modern API.

In aktuellen Versionen sollte die öffentliche API, die von System::Drawing‑Typen abhängt, als Legacy/veraltet behandelt werden. Verwenden Sie die Modern API für neuen Code und beim Migrieren bestehender Bildverarbeitungs‑Workflows.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) – repräsentiert das Raster- oder Vektorbild.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/imageformat/) – repräsentiert das Dateiformat des Bildes.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/de/cpp/aspose.slides/images/) – Methoden zum Instanziieren und Arbeiten mit der [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)-Schnittstelle.

Verwenden Sie `GetImage`, um eine einzelne Folie oder ein Shape zu rendern. Verwenden Sie `GetImages`, um mehrere Folien einer Präsentation zu rendern. Nutzen Sie die Methoden von [Images](https://reference.aspose.com/slides/de/cpp/aspose.slides/images/), um Bilder zu laden, `AddImage` mit [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/), um sie zu einer Präsentation hinzuzufügen, und `ReplaceImage` mit [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/), um ein vorhandenes Präsentationsbild zu aktualisieren.

Ein typisches Szenario für die Verwendung der neuen API könnte wie folgt aussehen:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// Instanziieren Sie eine verwertbare Instanz von IImage aus der Datei auf der Festplatte.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// Erstellen Sie ein PowerPoint‑Bild, indem Sie eine IImage‑Instanz zu den Bildern der Präsentation hinzufügen.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// Fügen Sie ein Bild‑Shape auf Folie #1 hinzu
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// Holen Sie eine IImage‑Instanz, die Folie #1 darstellt.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// Speichern Sie das Bild auf der Festplatte.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Alten Code durch Moderne API ersetzen**

Damit der Umstieg erleichtert wird, wiederholt die Schnittstelle des neuen [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) die separaten Signaturen der Klassen [System::Drawing::Image](https://reference.aspose.com/slides/de/cpp/system.drawing/image/) und [System::Drawing::Bitmap](https://reference.aspose.com/slides/de/cpp/system.drawing/bitmap/). Im Allgemeinen müssen Sie nur den Aufruf der alten Methode, die System::Drawing verwendet, durch den neuen ersetzen.

### **Vorschaubild einer Folie**

Legacy-/veraltete API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Moderne API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Vorschaubild eines Shapes**

Legacy-/veraltete API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Moderne API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Vorschaubild einer Präsentation**

Legacy-/veraltete API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

Moderne API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Ein Bild zu einer Präsentation hinzufügen**

Legacy-/veraltete API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

Moderne API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Veraltete Methoden/Eigenschaften und deren Ersatz in der Modernen API**

### **Presentation-Klasse**
|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide-Klasse**
|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Shape-Klasse**
|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection-Klasse**
|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage-Klasse**
|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat-Klasse**
|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData-Klasse**
|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **API‑Unterstützung für System::Drawing::Graphics**

Methoden mit [System::Drawing::Graphics](https://reference.aspose.com/slides/de/cpp/system.drawing/graphics/) sind als veraltet gekennzeichnet und haben keinen direkten Ersatz in der Modern API.

Verwenden Sie stattdessen die Bild‑Render‑Methoden der Modern API statt der API, die nach [System::Drawing::Graphics](https://reference.aspose.com/slides/de/cpp/system.drawing/graphics/) rendert:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Warum wurde [System::Drawing::Graphics](https://reference.aspose.com/slides/de/cpp/system.drawing/graphics/) entfernt?**

Die Unterstützung für [System::Drawing::Graphics](https://reference.aspose.com/slides/de/cpp/system.drawing/graphics/) ist in der öffentlichen API veraltet, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, plattformspezifische Abhängigkeiten zu eliminieren und auf einen plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) umzusteigen. Verwenden Sie `GetImage` oder `GetImages` anstelle des Renderns nach [System::Drawing::Graphics](https://reference.aspose.com/slides/de/cpp/system.drawing/graphics/).

**Welchen praktischen Nutzen bietet [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) im Vergleich zu [System::Drawing::Image](https://reference.aspose.com/slides/de/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/de/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektor‑Bildern, vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/imageformat/), reduziert die Abhängigkeit von `System::Drawing` und macht den Code portabler über verschiedene Umgebungen hinweg.

**Wird die Moderne API die Performance bei der Erstellung von Thumbnails beeinflussen?**

Der Wechsel von `GetThumbnail` zu `GetImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten zur Erzeugung von Bildern mit Optionen und Größen, während sie weiterhin Rendering‑Optionen unterstützen. Der konkrete Gewinn oder Verlust hängt vom jeweiligen Szenario ab, funktional sind die Ersatzmethoden jedoch äquivalent.