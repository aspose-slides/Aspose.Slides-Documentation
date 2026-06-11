---
title: Förbättra bildbehandling med Modern API
linktitle: Modern API
type: docs
weight: 280
url: /sv/cpp/modern-api/
keywords:
- System.Drawing
- modernt API
- ritning
- bildspelsminiatyr
- bildspel till bild
- formminiatyr
- form till bild
- presentationsminiatyr
- presentation till bilder
- lägg till bild
- lägg till bild
- C++
- Aspose.Slides
description: "Modernisera bildspels-bildbehandling genom att ersätta föråldrade bild-API:er med C++ Modern API för sömlös PowerPoint- och OpenDocument-automation."
---
## **Introduktion**

För närvarande har Aspose.Slides för C++-biblioteket beroenden i sitt offentliga API på följande klasser från System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/sv/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/sv/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/sv/cpp/system.drawing/bitmap/)

Från och med version 24.4 har detta offentliga API deklarerats som föråldrat.

För att bli av med beroenden på System::Drawing i det offentliga API:t lade vi till det så kallade "Modern API". Metoder med [System::Drawing::Image](https://reference.aspose.com/slides/sv/cpp/system.drawing/image/) och [System::Drawing::Bitmap](https://reference.aspose.com/slides/sv/cpp/system.drawing/bitmap/) har förklarats som föråldrade och bör ersättas med motsvarande metoder från Modern API. Metoder med [System::Drawing::Graphics](https://reference.aspose.com/slides/sv/cpp/system.drawing/graphics/) har förklarats som föråldrade och har ingen direkt Modern API‑ersättning.

I de aktuella versionerna bör du betrakta det offentliga API som är beroende av System::Drawing-typer som legacy/föråldrat. Använd Modern API för ny kod och när du migrerar befintliga bildbehandlingsarbetsflöden.

## **Modern API**

Följande klasser och uppräkningar har lagts till i det offentliga API:t:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) - representerar raster- eller vektorbilden.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imageformat/) - representerar bildens filformat.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/sv/cpp/aspose.slides/images/) - metoder för att skapa och arbeta med [IImage]-gränssnittet.

Använd `GetImage` för att rendera en enda bild eller form. Använd `GetImages` för att rendera flera bildspelssidor. Använd [Images]-metoder för att läsa in bilder, `AddImage` med [IImage] för att lägga till dem i en presentation och `ReplaceImage` med [IImage] för att uppdatera en befintlig bild i presentationen.

Ett typiskt scenario för att använda det nya API:et kan se ut som följer:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// instansiera en engångsinstans av IImage från filen på disk.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// skapa en PowerPoint-bild genom att lägga till en IImage-instans till presentationens bilder.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// lägg till en bildform på bildspel #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// hämta en instans av IImage som representerar bildspel #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// spara bilden på disk.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Ersätta gammal kod med Modern API**

För att underlätta övergången upprepar gränssnittet för den nya [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) de separata signaturerna för klasserna [System::Drawing::Image](https://reference.aspose.com/slides/sv/cpp/system.drawing/image/) och [System::Drawing::Bitmap](https://reference.aspose.com/slides/sv/cpp/system.drawing/bitmap/). I allmänhet behöver du bara ersätta anropet till den gamla metoden som använder System::Drawing med den nya.

### **Hämta en bilds miniatyr**

Legacy/deprecated API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Hämta en miniatyr för en form**

Legacy/deprecated API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Hämta en miniatyr för en presentation**

Legacy/deprecated API:

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

### **Lägga till en bild i en presentation**

Legacy/deprecated API:

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

## **Föråldrande metoder/egenskaper och deras ersättning i Modern API**

### **Presentation Class**
|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide Class**
|Metodsignatur|Ersättningsmetodsignatur|
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

### **Shape Class**
|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection Class**
|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage Class**
|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat Class**
|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData Class**
|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **API-stöd för System::Drawing::Graphics**

Metoder med [System::Drawing::Graphics](https://reference.aspose.com/slides/sv/cpp/system.drawing/graphics/) är förklarade som föråldrade och har ingen direkt Modern API‑ersättning.

Använd Modern API:s bildrenderingsmetoder istället för API:t som renderar till [System::Drawing::Graphics](https://reference.aspose.com/slides/sv/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Varför togs [System::Drawing::Graphics](https://reference.aspose.com/slides/sv/cpp/system.drawing/graphics/) bort?**

Stödet för [System::Drawing::Graphics](https://reference.aspose.com/slides/sv/cpp/system.drawing/graphics/) är föråldrat i det offentliga API:t för att förena arbete med rendering och bilder, eliminera beroenden på plattforms‑specifika komponenter och gå över till ett plattformsoberoende tillvägagångssätt med [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/). Använd `GetImage` eller `GetImages` i stället för att rendera till [System::Drawing::Graphics](https://reference.aspose.com/slides/sv/cpp/system.drawing/graphics/).

**Vilken praktisk fördel har [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) jämfört med [System::Drawing::Image](https://reference.aspose.com/slides/sv/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/sv/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) förenar arbete med både raster- och vektorbilder, förenklar sparande i olika format via [ImageFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imageformat/), minskar beroendet av `System::Drawing` och gör koden mer portabel över olika miljöer.

**Kommer Modern API att påverka prestandan vid generering av miniatyrbilder?**

Att byta från `GetThumbnail` till `GetImage` försämrar inte scenarierna: de nya metoderna erbjuder samma möjligheter att producera bilder med alternativ och storlekar, samtidigt som stöd för renderingsalternativ bevaras. Den specifika vinsten eller förlusten beror på scenariot, men funktionellt är ersättningarna likvärdiga.