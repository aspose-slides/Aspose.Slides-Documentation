---
title: Verbeter beeldverwerking met de Moderne API
linktitle: Moderne API
type: docs
weight: 280
url: /nl/cpp/modern-api/
keywords:
- System.Drawing
- moderne API
- tekenen
- dia-miniatuur
- dia naar afbeelding
- vorm-miniatuur
- vorm naar afbeelding
- presentatie-miniatuur
- presentatie naar afbeeldingen
- afbeelding toevoegen
- foto toevoegen
- C++
- Aspose.Slides
description: "Moderniseer de verwerking van dia-afbeeldingen door verouderde beeld‑API's te vervangen door de C++ Moderne API voor naadloze automatisering van PowerPoint en OpenDocument."
---
## **Introductie**

Momenteel heeft de Aspose.Slides for C++-bibliotheek afhankelijkheden in haar publieke API van de volgende klassen uit System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/nl/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/nl/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/nl/cpp/system.drawing/bitmap/)

Vanaf versie 24.4 wordt deze publieke API als verouderd gemarkeerd.

Om de afhankelijkheden van System::Drawing in de publieke API te verwijderen, hebben we de zogenoemde “Modern API” toegevoegd. Methoden met [System::Drawing::Image](https://reference.aspose.com/slides/nl/cpp/system.drawing/image/) en [System::Drawing::Bitmap](https://reference.aspose.com/slides/nl/cpp/system.drawing/bitmap/) zijn gemarkeerd als verouderd en moeten worden vervangen door de overeenkomstige methoden uit de Modern API. Methoden met [System::Drawing::Graphics](https://reference.aspose.com/slides/nl/cpp/system.drawing/graphics/) zijn gemarkeerd als verouderd en hebben geen directe Modern API‑vervanging.

In de huidige versies moet je de publieke API die afhankelijk is van System::Drawing‑typen beschouwen als legacy/verouderd. Gebruik de Modern API voor nieuwe code en bij het migreren van bestaande beeldverwerkingsworkflows.

## **Modern API**

De volgende klassen en enum‑s zijn toegevoegd aan de publieke API:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) – vertegenwoordigt de raster‑ of vectorafbeelding.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imageformat/) – vertegenwoordigt het bestandsformaat van de afbeelding.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/nl/cpp/aspose.slides/images/) – methoden om een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)-interface te instantieren en ermee te werken.

Gebruik `GetImage` om één dia of vorm te renderen. Gebruik `GetImages` om meerdere presentatiedia’s te renderen. Gebruik de [Images](https://reference.aspose.com/slides/nl/cpp/aspose.slides/images/)-methoden om afbeeldingen te laden, `AddImage` met [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) om ze aan een presentatie toe te voegen, en `ReplaceImage` met [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) om een bestaande presentatiefoto bij te werken.

Een typisch scenario voor het gebruik van de nieuwe API kan er als volgt uitzien:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// instantieer een tijdelijke instantie van IImage vanaf het bestand op de schijf.
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// maak een PowerPoint‑afbeelding door een IImage‑instantie toe te voegen aan de afbeeldingen van de presentatie.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// voeg een afbeelding‑vorm toe aan dia #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// verkrijg een IImage‑instantie die dia #1 weergeeft.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// sla de afbeelding op de schijf op.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Oude code vervangen door Modern API**

Om de overgang te vergemakkelijken, herhaalt de interface van de nieuwe [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) de afzonderlijke handtekeningen van de [System::Drawing::Image](https://reference.aspose.com/slides/nl/cpp/system.drawing/image/)‑ en [System::Drawing::Bitmap](https://reference.aspose.com/slides/nl/cpp/system.drawing/bitmap/)‑klassen. In het algemeen hoef je alleen de aanroep van de oude methode die System::Drawing gebruikt te vervangen door de nieuwe.

### **Een dia‑miniatuur ophalen**

Legacy/verouderde API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Een vorm‑miniatuur ophalen**

Legacy/verouderde API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Een presentatieminiatuur ophalen**

Legacy/verouderde API:

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

### **Een afbeelding aan een presentatie toevoegen**

Legacy(verouderde) API:

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

## **Verouderde methoden/eigenschappen en hun vervanging in Modern API**

### **Presentation‑klasse**
|Methodehandtekening|Vervangende methodehandtekening|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide‑klasse**
|Methodehandtekening|Vervangende methodehandtekening|
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

### **Shape‑klasse**
|Methodehandtekening|Vervangende methodehandtekening|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection‑klasse**
|Methodehandtekening|Vervangende methodehandtekening|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage‑klasse**
|Methodehandtekening|Vervangende methodehandtekening|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat‑klasse**
|Methodehandtekening|Vervangende methodehandtekening|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData‑klasse**
|Methodehandtekening|Vervangende methodehandtekening|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **API‑ondersteuning voor System::Drawing::Graphics**

Methoden met [System::Drawing::Graphics](https://reference.aspose.com/slides/nl/cpp/system.drawing/graphics/) zijn gemarkeerd als verouderd en hebben geen directe Modern API‑vervanging.

Gebruik de Modern API‑beeldrenderingsmethoden in plaats van de API die rendert naar [System::Drawing::Graphics](https://reference.aspose.com/slides/nl/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Waarom is [System::Drawing::Graphics](https://reference.aspose.com/slides/nl/cpp/system.drawing/graphics/) verwijderd?**

Ondersteuning voor [System::Drawing::Graphics](https://reference.aspose.com/slides/nl/cpp/system.drawing/graphics/) is verouderd in de publieke API om het werk met renderen en afbeeldingen te uniformiseren, platform‑specifieke afhankelijkheden te elimineren en over te stappen naar een cross‑platform aanpak met [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/). Gebruik `GetImage` of `GetImages` in plaats van renderen naar [System::Drawing::Graphics](https://reference.aspose.com/slides/nl/cpp/system.drawing/graphics/).

**Wat is het praktische voordeel van [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) ten opzichte van [System::Drawing::Image](https://reference.aspose.com/slides/nl/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/nl/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) verenigt het werken met zowel raster‑ als vectorafbeeldingen, vereenvoudigt het opslaan naar verschillende formaten via [ImageFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imageformat/), vermindert de afhankelijkheid van `System::Drawing` en maakt de code draagbaarder over verschillende omgevingen.

**Zal de Modern API de prestaties van het genereren van miniaturen beïnvloeden?**

Overstappen van `GetThumbnail` naar `GetImage` verslechtert de scenario’s niet: de nieuwe methoden bieden dezelfde mogelijkheden om beelden met opties en afmetingen te produceren, terwijl ze de ondersteuning voor renderopties behouden. De konkrete winst of daling hangt af van het scenario, maar functioneel zijn de vervangingen gelijkwaardig.