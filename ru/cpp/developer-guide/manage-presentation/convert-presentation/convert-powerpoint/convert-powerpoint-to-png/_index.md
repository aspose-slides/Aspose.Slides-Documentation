---
title: Конвертация PowerPoint в PNG
type: docs
weight: 30
url: /ru/cpp/convert-powerpoint-to-png/
keywords: PowerPoint в PNG, PPT в PNG, PPTX в PNG, C++, Aspose.Slides для C++
description: Конвертируйте презентацию PowerPoint в PNG
---

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но все же очень распространен.

**Сценарий использования:** Когда у вас есть сложное изображение и размер не является проблемой, PNG - лучший формат изображения, чем JPEG.

{{% alert title="Совет" color="primary" %}} Вам может быть интересно попробовать бесплатные **конвертеры PowerPoint в PNG** от Aspose: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Они являются живой реализацией процесса, описанного на этой странице. {{% /alert %}}

## **Конвертировать PowerPoint в PNG**

Следуйте этим шагам:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите объект слайда из коллекции [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) через интерфейс [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide).
3. Используйте метод [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) для получения миниатюры каждого слайда.
4. Используйте метод [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) для сохранения миниатюры слайда в формате PNG.

Этот код на C++ показывает, как конвертировать презентацию PowerPoint в PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Если вы хотите получить файлы PNG с определенным масштабом, вы можете задать значения для `desiredX` и `desiredY`, которые определяют размеры результирующей миниатюры.

Этот код на C++ демонстрирует описанную операцию:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Конвертировать PowerPoint в PNG с заданным размером**

Если вы хотите получить файлы PNG определенного размера, вы можете передать желаемые аргументы `width` и `height` для `ImageSize`.

Этот код показывает, как конвертировать PowerPoint в PNG, указывая размер для изображений:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```