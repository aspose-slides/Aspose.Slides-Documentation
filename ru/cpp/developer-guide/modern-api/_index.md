---
title: Улучшите обработку изображений с Modern API
linktitle: Modern API
type: docs
weight: 280
url: /ru/cpp/modern-api/
keywords:
- System.Drawing
- Modern API
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
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на Modern API для C++, обеспечивая беспрепятственную автоматизацию PowerPoint и OpenDocument."
---

## **Введение**

В настоящее время библиотека Aspose.Slides для C++ имеет зависимости в публичном API от следующих классов из System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Чтобы избавиться от зависимостей от System::Drawing в публичном API, мы добавили так называемый «Modern API». Методы с System::Drawing::Image и System::Drawing::Bitmap объявлены устаревшими и будут заменены соответствующими методами из Modern API. Методы с System::Graphics объявлены устаревшими, и их поддержка будет удалена из публичного API.

Удаление устаревшего публичного API с зависимостями от System::Drawing произойдёт в выпуске 24.8.

## **Modern API**

В публичный API добавлены следующие классы и перечисления:

- Aspose::Slides::IImage — представляет растровое или векторное изображение.
- Aspose::Slides::ImageFormat — представляет формат файла изображения.
- Aspose::Slides::Images — методы для создания и работы с интерфейсом IImage.

Типичный сценарий использования нового API может выглядеть следующим образом:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// создать одноразовый экземпляр IImage из файла на диске.
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// создать изображение PowerPoint, добавив экземпляр IImage в изображения презентации.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// добавить форму изображения на слайд #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// получить экземпляр IImage, представляющий слайд #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// сохранить изображение на диске.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```


## **Замена старого кода на Modern API**

Для облегчения перехода интерфейс нового IImage повторяет отдельные сигнатуры классов Image и Bitmap. По сути, вам нужно лишь заменить вызов старого метода, использующего System::Drawing, на новый.

### **Получение миниатюры слайда**

Код с использованием устаревшего API:
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

Код с использованием устаревшего API:
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

Код с использованием устаревшего API:
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

Код с использованием устаревшего API:
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


## **Методы/Свойства, подлежащие удалению, и их замена в Modern API**

### **Класс Presentation**
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|Будет полностью удалено|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|Будет полностью удалено|

### **Класс Slide**
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|Будет полностью удалено|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|Будет полностью удалено|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|Будет полностью удалено|

### **Класс Shape**
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Класс ImageCollection**
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Класс PPImage**
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Класс PatternFormat**
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Класс IPatternFormatEffectiveData**
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Поддержка System::Drawing::Graphics будет прекращена**

Методы с [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/) объявлены устаревшими, и их поддержка будет удалена из публичного API.

Часть API, использующая их, будет удалена:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Почему был удалён System::Drawing::Graphics?**

Поддержка `Graphics` удаляется из публичного API для объединения работы с рендерингом и изображениями, устранения привязки к платформенно‑зависимым библиотекам и перехода к кросс‑платформенному подходу с использованием [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/). Все методы рендеринга в `Graphics` будут удалены.

**В чём практическая польза IImage по сравнению с Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями, упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), снижает зависимость от `System::Drawing` и делает код более переносимым между средами.

**Повлияет ли Modern API на производительность генерации миниатюр?**

Переход от `GetThumbnail` к `GetImage` не ухудшает сценарии: новые методы предоставляют те же возможности создания изображений с параметрами и размерами, сохраняя поддержку вариантов рендеринга. Конкретный прирост или падение зависят от сценария, но функционально замены эквивалентны.