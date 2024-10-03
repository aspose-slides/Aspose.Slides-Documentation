---
title: Преобразование Powerpoint PPT в JPG
type: docs
weight: 60
url: /ru/cpp/convert-powerpoint-to-jpg/
keywords: "Преобразовать PowerPoint в JPG"
description: "Преобразовать PowerPoint в JPG: PPT в JPG, PPTX в JPG на C++"
---

## **Преобразование презентации в набор изображений**

В некоторых случаях необходимо преобразовать всю презентацию в набор изображений, как это позволяет делать PowerPoint. Код на C++ показывает, как преобразовать презентацию в JPG изображения:

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& sld : pres->get_Slides())
{
    // Создает изображение в полном размере
    System::SharedPtr<IImage> image = sld->GetImage(1.0f, 1.0f);

    // Сохраняет изображение на диск в формате JPEG
    image->Save(System::String::Format(u"Slide_{0}.jpg", sld->get_SlideNumber()),
                ImageFormat::Jpeg);
}
```

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides преобразует PowerPoint в JPG изображения, вы можете попробовать эти бесплатные онлайн конвертеры: PowerPoint [PPTX в JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT в JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

## Преобразование PowerPoint PPT/PPTX в JPG с настроенными размерами**

Чтобы изменить размеры получаемого миниатюры и JPG изображения, вы можете установить значения *ScaleX* и *ScaleY*, передав их в `float scaleX, float Y` метода [**ISlide::GetImage()**](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagefloat-float-method):

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

// Определяет размеры
int32_t desiredX = 1200, desiredY = 800;
// Получает масштабированные значения X и Y
float ScaleX = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Width()) * desiredX;
float ScaleY = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Height()) * desiredY;

for (auto&& sld : pres->get_Slides())
{
    // Создает изображение в полном размере
    System::SharedPtr<IImage> image = sld->GetImage(ScaleX, ScaleY);

    // Сохраняет изображение на диск в формате JPEG
    image->Save(System::String::Format(u"Slide_{0}.jpg", sld->get_SlideNumber()),
                ImageFormat::Jpeg);
}
```

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение коллажа](https://products.aspose.app/slides/collage). Используя этот онлайн-сервис, вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG изображения, создавать [фото сетки](https://products.aspose.app/slides/collage/photo-grid) и так далее. 

Используя те же принципы, описанные в данной статье, вы можете преобразовать изображения из одного формата в другой. Для получения дополнительной информации смотрите эти страницы: преобразование [изображения в JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); преобразование [JPG в изображение](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); преобразование [JPG в PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), преобразование [PNG в JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); преобразование [PNG в SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), преобразование [SVG в PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **См. также**

Смотрите другие варианты преобразования PPT/PPTX в изображение, такие как:

- [Преобразование PPT/PPTX в SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/)