---
title: Изображение
type: docs
weight: 50
url: /ru/cpp/examples/elements/picture/
keywords:
- пример кода
- изображение
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Работа с изображениями в Aspose.Slides for C++: вставка, обрезка, сжатие, изменение цвета и экспорт изображений с примерами на C++ для презентаций PPT, PPTX и ODP."
---
В этой статье показано, как вставлять и получать доступ к изображениям из памяти, используя **Aspose.Slides for C++**. Приведённые ниже примеры создают изображение в памяти, размещают его на слайде и затем извлекают его.

## **Добавить изображение**

Этот код генерирует небольшой битмап, преобразует его в поток и вставляет как кадр изображения на первый слайд.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Создать простое изображение в памяти.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Преобразовать битмап в массив байтов.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Добавить изображение в презентацию.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Вставить кадр изображения, отображающий картинку на первом слайде.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Получить изображение**

В этом примере проверяется, содержит ли слайд кадр изображения, и затем доступается первый найденный кадр.

```cpp
static void AccessPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto bitmap = MakeObject<Bitmap>(40, 40, PixelFormat::Format32bppArgb);
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0, 0, 40, 40, image);

    auto pictureFrame = SharedPtr<IPictureFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            pictureFrame = ExplicitCast<IPictureFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```