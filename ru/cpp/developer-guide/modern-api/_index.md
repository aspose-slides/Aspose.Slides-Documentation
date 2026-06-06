---
title: Улучшить обработку изображений с Modern API
linktitle: Modern API
type: docs
weight: 280
url: /ru/cpp/modern-api/
keywords:
- System.Drawing
- modern API
- рисование
- миниатюра слайда
- слайд в изображение
- миниатюра фигуры
- фигура в изображение
- миниатюра презентации
- презентация в изображения
- добавить изображение
- добавить картинку
- C++
- Aspose.Slides
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на Modern API на C++ для бесшовной автоматизации PowerPoint и OpenDocument."
---
## **Введение**

В настоящее время библиотека Aspose.Slides for C++ имеет зависимости в своем публичном API от следующих классов из System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/ru/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/ru/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/ru/cpp/system.drawing/bitmap/)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Чтобы избавиться от зависимостей от System::Drawing в публичном API, мы добавили так называемый «Modern API». Методы с [System::Drawing::Image](https://reference.aspose.com/slides/ru/cpp/system.drawing/image/) и [System::Drawing::Bitmap](https://reference.aspose.com/slides/ru/cpp/system.drawing/bitmap/) объявлены устаревшими и должны быть заменены соответствующими методами Modern API. Методы с [System::Drawing::Graphics](https://reference.aspose.com/slides/ru/cpp/system.drawing/graphics/) объявлены устаревшими и не имеют прямой замены в Modern API.

В текущих версиях рассматривайте публичный API, зависящий от типов System::Drawing, как устаревший/наследуемый. Используйте Modern API для нового кода и при переносе существующих рабочих процессов обработки изображений.

## **Modern API**

Добавлены следующие классы и перечисления в публичный API:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) — представляет растровое или векторное изображение.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imageformat/) — представляет файловый формат изображения.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/ru/cpp/aspose.slides/images/) — методы для создания экземпляров и работы с интерфейсом [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/).

Используйте `GetImage` для рендеринга одного слайда или фигуры. Используйте `GetImages` для рендеринга нескольких слайдов презентации. Используйте методы [Images](https://reference.aspose.com/slides/ru/cpp/aspose.slides/images/) для загрузки изображений, `AddImage` с [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) для добавления их в презентацию и `ReplaceImage` с [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) для обновления существующего изображения презентации.

Типичный сценарий использования нового API может выглядеть следующим образом:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// создать временный экземпляр IImage из файла на диске.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// создать изображение PowerPoint, добавив экземпляр IImage в изображения презентации.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// добавить форму изображения на слайд #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// получить экземпляр IImage, представляющий слайд #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// сохранить изображение на диск.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Замена старого кода с Modern API**

Для облегчения перехода интерфейс нового [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) повторяет отдельные сигнатуры классов [System::Drawing::Image](https://reference.aspose.com/slides/ru/cpp/system.drawing/image/) и [System::Drawing::Bitmap](https://reference.aspose.com/slides/ru/cpp/system.drawing/bitmap/). Как правило, вам нужно лишь заменить вызов старого метода, использующего System::Drawing, на новый.

### **Получение миниатюры слайда**

Устаревший/депрецированный API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Получение миниатюры фигуры**

Устаревший/депрецированный API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Получение миниатюры презентации**

Устаревший/депрецированный API:

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

### **Добавление изображения в презентацию**

Устаревший/депрецированный API:

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

## **Устаревшие методы/свойства и их замена в Modern API**

### **Класс Presentation**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Класс Slide**
|Method Signature|Replacement Method Signature|
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

### **Класс Shape**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Класс ImageCollection**
|Method Signature|Replacement Method Signature|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Класс PPImage**
|Method Signature|Replacement Method Signature|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Класс PatternFormat**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Класс IPatternFormatEffectiveData**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Поддержка API для System::Drawing::Graphics**

Методы с [System::Drawing::Graphics](https://reference.aspose.com/slides/ru/cpp/system.drawing/graphics/) объявлены устаревшими и не имеют прямой замены в Modern API.

Используйте методы Modern API для рендеринга изображений вместо API, который рендерит в [System::Drawing::Graphics](https://reference.aspose.com/slides/ru/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Почему был удалён [System::Drawing::Graphics](https://reference.aspose.com/slides/ru/cpp/system.drawing/graphics/)?**

Поддержка [System::Drawing::Graphics](https://reference.aspose.com/slides/ru/cpp/system.drawing/graphics/) объявлена устаревшей в публичном API для унификации работы с рендерингом и изображениями, устранения привязки к платформо-зависимым компонентам и перехода к кроссплатформенному подходу с использованием [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/). Используйте `GetImage` или `GetImages` вместо рендеринга в [System::Drawing::Graphics](https://reference.aspose.com/slides/ru/cpp/system.drawing/graphics/).

**В чём практическое преимущество [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) по сравнению с [System::Drawing::Image](https://reference.aspose.com/slides/ru/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/ru/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями, упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imageformat/), уменьшает зависимость от `System::Drawing` и делает код более переносимым между окружениями.

**Повлияет ли Modern API на производительность генерации миниатюр?**

Переход от `GetThumbnail` к `GetImage` не ухудшает сценарии: новые методы предоставляют те же возможности по созданию изображений с опциями и размерами, сохраняя поддержку параметров рендеринга. Конкретный прирост или падение зависит от сценария, но функционально замены эквивалентны.