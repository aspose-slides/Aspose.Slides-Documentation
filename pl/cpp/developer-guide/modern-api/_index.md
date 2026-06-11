---
title: Popraw przetwarzanie obrazów za pomocą nowoczesnego API
linktitle: Nowoczesne API
type: docs
weight: 280
url: /pl/cpp/modern-api/
keywords:
- System.Drawing
- nowoczesne API
- rysowanie
- miniatura slajdu
- slajd do obrazu
- miniatura kształtu
- kształt do obrazu
- miniatura prezentacji
- prezentacja do obrazów
- dodaj obraz
- dodaj zdjęcie
- C++
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów slajdów, zastępując przestarzałe API obrazowania nowoczesnym API C++ dla płynnej automatyzacji PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Obecnie biblioteka Aspose.Slides for C++ ma zależności w swoim publicznym API od następujących klas z System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/pl/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/pl/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/pl/cpp/system.drawing/bitmap/)

Od wersji 24.4 to publiczne API jest oznaczone jako przestarzałe.

Aby usunąć zależności od System::Drawing w publicznym API, dodaliśmy tak zwane „Modern API”. Metody przyjmujące [System::Drawing::Image](https://reference.aspose.com/slides/pl/cpp/system.drawing/image/) i [System::Drawing::Bitmap](https://reference.aspose.com/slides/pl/cpp/system.drawing/bitmap/) są oznaczone jako przestarzałe i powinny być zastąpione odpowiednimi metodami z Modern API. Metody przyjmujące [System::Drawing::Graphics](https://reference.aspose.com/slides/pl/cpp/system.drawing/graphics/) są oznaczone jako przestarzałe i nie mają bezpośredniego odpowiednika w Modern API.

W obecnych wersjach traktuj publiczne API zależne od typów System::Drawing jako przestarzałe/legacy. Używaj Modern API dla nowego kodu i przy migracji istniejących przepływów przetwarzania obrazów.

## **Nowoczesne API**

Dodano następujące klasy i wyliczenia do publicznego API:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) – reprezentuje obraz rastrowy lub wektorowy.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imageformat/) – reprezentuje format pliku obrazu.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/pl/cpp/aspose.slides/images/) – metody do tworzenia i pracy z interfejsem [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/).

Użyj `GetImage`, aby renderować pojedynczy slajd lub kształt. Użyj `GetImages`, aby renderować kilka slajdów prezentacji. Użyj metod z [Images](https://reference.aspose.com/slides/pl/cpp/aspose.slides/images/), aby wczytywać obrazy, `AddImage` z [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) do dodawania ich do prezentacji oraz `ReplaceImage` z [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) do aktualizacji istniejącego obrazu w prezentacji.

Typowy scenariusz użycia nowego API może wyglądać następująco:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// utwórz jednorazowy obiekt IImage z pliku na dysku.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// utwórz obraz PowerPoint, dodając instancję IImage do obrazów prezentacji.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// dodaj kształt obrazu na slajdzie #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// pobierz instancję IImage reprezentującą slajd #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// zapisz obraz na dysku.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Zastępowanie starego kodu przy użyciu Modern API**

Aby ułatwić przejście, interfejs nowego [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) powiela oddzielne sygnatury klas [System::Drawing::Image](https://reference.aspose.com/slides/pl/cpp/system.drawing/image/) i [System::Drawing::Bitmap](https://reference.aspose.com/slides/pl/cpp/system.drawing/bitmap/). W praktyce wystarczy zamienić wywołanie starej metody używającej System::Drawing na nową.

### **Pobieranie miniatury slajdu**

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

### **Pobieranie miniatury kształtu**

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

### **Pobieranie miniatury prezentacji**

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

### **Dodawanie obrazu do prezentacji**

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

## **Zdezaktualizowane metody/właściwości i ich zamienniki w Modern API**

### **Klasa Presentation**
|Podpis metody|Podpis metody zastępczej|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Klasa Slide**
|Podpis metody|Podpis metody zastępczej|
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

### **Klasa Shape**
|Podpis metody|Podpis metody zastępczej|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Klasa ImageCollection**
|Podpis metody|Podpis metody zastępczej|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Klasa PPImage**
|Podpis metody|Podpis metody zastępczej|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Klasa PatternFormat**
|Podpis metody|Podpis metody zastępczej|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Klasa IPatternFormatEffectiveData**
|Podpis metody|Podpis metody zastępczej|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Obsługa System::Drawing::Graphics w API**

Metody przyjmujące [System::Drawing::Graphics](https://reference.aspose.com/slides/pl/cpp/system.drawing/graphics/) są oznaczone jako przestarzałe i nie mają bezpośredniego zamiennika w Modern API.

Użyj metod renderowania obrazu z Modern API zamiast API renderującego do [System::Drawing::Graphics](https://reference.aspose.com/slides/pl/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Dlaczego [System::Drawing::Graphics](https://reference.aspose.com/slides/pl/cpp/system.drawing/graphics/) został pominięty?**

Obsługa [System::Drawing::Graphics](https://reference.aspose.com/slides/pl/cpp/system.drawing/graphics/) jest przestarzała w publicznym API, aby ujednolicić pracę z renderowaniem i obrazami, wyeliminować zależności od platformowo‑specyficznych komponentów oraz przejść na podejście wieloplatformowe z [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/). Użyj `GetImage` lub `GetImages` zamiast renderowania do [System::Drawing::Graphics](https://reference.aspose.com/slides/pl/cpp/system.drawing/graphics/).

**Jakie praktyczne korzyści daje [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) w porównaniu do [System::Drawing::Image](https://reference.aspose.com/slides/pl/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/pl/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) jednoczy pracę z obrazami rastrowymi i wektorowymi, upraszcza zapisywanie w różnych formatach poprzez [ImageFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imageformat/), zmniejsza zależność od `System::Drawing` i sprawia, że kod jest bardziej przenośny między środowiskami.

**Czy Modern API wpłynie na wydajność generowania miniatur?**

Przejście z `GetThumbnail` na `GetImage` nie pogarsza scenariuszy: nowe metody oferują te same możliwości tworzenia obrazów z opcjami i rozmiarami, jednocześnie zachowując wsparcie dla opcji renderowania. Konkretne zyski lub straty zależą od scenariusza, ale funkcjonalnie zamienniki są równoważne.