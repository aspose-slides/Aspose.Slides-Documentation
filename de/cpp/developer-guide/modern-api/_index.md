---
title: Bildverarbeitung mit der Modernen API verbessern
linktitle: Moderne API
type: docs
weight: 280
url: /de/cpp/modern-api/
keywords:
- System.Drawing
- moderne API
- Zeichnung
- Folien-Vorschaubild
- Folien zu Bild
- Form-Vorschaubild
- Form zu Bild
- Präsentations-Vorschaubild
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- C++
- Aspose.Slides
description: "Modernisieren Sie die Folien‑Bildverarbeitung, indem Sie veraltete Bild‑APIs durch die C++ Modern API für nahtlose PowerPoint‑ und OpenDocument‑Automatisierung ersetzen."
---

## **Einführung**

Derzeit besitzt die Aspose.Slides for C++‑Bibliothek öffentliche API‑Abhängigkeiten von den folgenden Klassen aus System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/)

Ab Version 24.4 wird diese öffentliche API als veraltet markiert.

Um die Abhängigkeiten von System::Drawing in der öffentlichen API zu entfernen, haben wir die sogenannte „Modern API“ eingeführt. Methoden mit System::Drawing::Image und System::Drawing::Bitmap werden als veraltet gekennzeichnet und durch die entsprechenden Methoden der Modern API ersetzt. Methoden mit System::Graphics werden als veraltet markiert und ihr Support wird aus der öffentlichen API entfernt.

Die Entfernung der veralteten öffentlichen API mit Abhängigkeiten zu System::Drawing erfolgt in Release 24.8.

## **Modern API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- Aspose::Slides::IImage – repräsentiert das Raster‑ oder Vektorbild.
- Aspose::Slides::ImageFormat – repräsentiert das Dateiformat des Bildes.
- Aspose::Slides::Images – Methoden zum Instanziieren und Arbeiten mit dem IImage‑Interface.

Ein typisches Anwendungsszenario der neuen API könnte wie folgt aussehen:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// Instanziieren einer verwertbaren Instanz von IImage aus der Datei auf dem Datenträger.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// Erstellen eines PowerPoint-Bildes, indem eine IImage-Instanz zu den Bildern der Präsentation hinzugefügt wird.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// Bildform auf Folie #1 hinzufügen
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// Eine Instanz von IImage erhalten, die Folie #1 darstellt.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// Das Bild auf dem Datenträger speichern.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```


## **Ersetzen alten Codes durch die Modern API**

Zur Erleichterung der Migration wiederholt das Interface des neuen IImage die separaten Signaturen der Klassen Image und Bitmap. Im Allgemeinen müssen Sie lediglich den Aufruf der alten Methode, die System::Drawing verwendet, durch den neuen ersetzen.

### **Erzeugen einer Folien‑Thumbnail**

Code mit veralteter API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```


Modern API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```


### **Erzeugen einer Form‑Thumbnail**

Code mit veralteter API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```


Modern API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```


### **Erzeugen einer Präsentations‑Thumbnail**

Code mit veralteter API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```


Modern API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```


### **Hinzufügen eines Bildes zu einer Präsentation**

Code mit veralteter API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


Modern API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


## **Entfernte Methoden/Eigenschaften und deren Ersatz in der Modern API**

### **Präsentationsklasse**
|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|Wird vollständig entfernt|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|Wird vollständig entfernt|

### **Foliaklasse**
|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|Wird vollständig entfernt|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|Wird vollständig entfernt|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|Wird vollständig entfernt|

### **Formklasse**
|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection‑Klasse**
|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage‑Klasse**
|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat‑Klasse**
|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData‑Klasse**
|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Unterstützung für System::Drawing::Graphics wird eingestellt**

Methoden mit [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/) sind als veraltet markiert und ihr Support wird aus der öffentlichen API entfernt.

Der betreffende API‑Teil wird entfernt:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Warum wurde System::Drawing::Graphics entfernt?**

Der Support für `Graphics` wird aus der öffentlichen API entfernt, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, plattformspezifische Abhängigkeiten zu eliminieren und auf einen plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) umzusteigen. Alle Rendering‑Methoden für `Graphics` werden entfernt.

**Welchen praktischen Nutzen bietet IImage gegenüber Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektorbildern, vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), reduziert die Abhängigkeit von `System::Drawing` und macht den Code in unterschiedlichen Umgebungen portabler.

**Beeinflusst die Modern API die Performance bei der Erstellung von Thumbnails?**

Der Wechsel von `GetThumbnail` zu `GetImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten zur Bildgenerierung mit Optionen und Größen und behalten die Unterstützung von Rendering‑Optionen bei. Der konkrete Gewinn oder Verlust hängt vom Einzelfall ab, funktional sind die Ersatzmethoden jedoch gleichwertig.