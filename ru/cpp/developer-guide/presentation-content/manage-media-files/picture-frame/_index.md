---
title: Управление рамками изображений в презентациях с использованием C++
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/cpp/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- добавить изображение
- создать изображение
- извлечь изображение
- растровое изображение
- векторное изображение
- обрезать изображение
- обрезанная область
- свойство StretchOff
- форматирование рамки изображения
- свойства рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- прозрачность изображения
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Оптимизируйте рабочий процесс и улучшите дизайн слайдов."
---
## **Введение**

Рамка изображения — это фигура, содержащая изображение, она похожа на картинку в рамке.  

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку.

{{% alert  title="Tip" color="info" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_image_collection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.  
4. Укажите ширину и высоту изображения.  
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.picture_frame) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, предоставленного объектом формы, связанным с выбранным слайдом.  
6. Добавьте рамку изображения (содержащую картинку) на слайд.  
7. Сохраните изменённую презентацию в файл PPTX.  

Этот C++ код показывает, как создать рамку изображения:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Путь к каталогу документов.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загружает желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает картинку
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительные масштабные ширину и высоту
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Применяет некоторое форматирование к рамке изображения
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Записывает файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. Комбинируя рамку изображения с параметрами сохранения Aspose.Slides, вы можете управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вас заинтересуют следующие страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/ru/cpp/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/ru/cpp/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/ru/cpp/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/ru/cpp/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/ru/cpp/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/ru/cpp/conversion/svg-to-png/). 

{{% /alert %}}

## **Создание рамки изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку изображения.  

1. Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте изображение в коллекцию изображений презентации.  
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_image_collection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.  
5. Укажите относительные ширину и высоту изображения в рамке.  
6. Сохраните изменённую презентацию в файл PPTX.  

Этот C++ код показывает, как создать рамку изображения с относительным масштабом:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Путь к каталогу документов.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загружает нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает картинку
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительные масштабные ширину и высоту
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Извлечение растровых изображений из рамок изображения**

Вы можете извлечь растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.picture_frame) и сохранить их в PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **Извлечение SVG‑изображений из рамок изображения**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/), Aspose.Slides для C++ позволяет получить оригинальные векторные изображения с полной точностью. Путём обхода коллекции фигур слайда вы можете определить каждый [PictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/), проверить, содержит ли соответствующий [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) SVG‑содержимое, и затем сохранить это изображение на диск или в поток в его нативном формате SVG.

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из рамки:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Получение прозрачности изображения**

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот C++ код демонстрирует операцию:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
Все эффекты, применяемые к изображениям, можно найти в [Aspose::Slides::Effects](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/). 
{{% /alert %}}

## **Получение яркости и контраста изображения**

Aspose.Slides позволяет получить эффекты яркости и контраста, применённые к изображению. Интерфейс [ILuminance](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iluminance/) представляет этот трансформационный эффект изображения.

Этот C++ код демонстрирует, как получить настройки яркости и контраста из рамки изображения:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. Используя эти параметры, вы можете изменить рамку так, чтобы она соответствовала конкретным требованиям.

1. Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_image_collection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.  
4. Укажите ширину и высоту изображения.  
5. Создайте `PictureFrame` на основе ширины и высоты изображения с помощью метода [AddPictureFrame](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), предоставленного объектом [IShapes](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_shape_collection), связанным с выбранным слайдом.  
6. Добавьте рамку изображения (содержащую картинку) на слайд.  
7. Установите цвет линии рамки изображения.  
8. Установите толщину линии рамки изображения.  
9. Поверните рамку изображения, задав положительное или отрицательное значение.  
   * Положительное значение вращает изображение по часовой стрелке.  
   * Отрицательное значение вращает изображение против часовой стрелки.  
10. Добавьте рамку изображения (содержащую картинку) на слайд.  
11. Сохраните изменённую презентацию в файл PPTX.  

Этот C++ код демонстрирует процесс форматирования рамки изображения:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Путь к каталогу документов.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загружает нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает картинку
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительные масштабные ширину и высоту
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Записывает файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}

Aspose недавно разработал бесплатный сервис [Collage Maker](https://products.aspose.app/slides/ru/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/ru/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/ru/collage/photo-grid), вы можете воспользоваться этим сервисом. 

{{% /alert %}}

## **Добавление изображения в виде ссылки**

Чтобы избежать больших размеров презентаций, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов непосредственно в презентацию. Этот C++ код показывает, как добавить изображение и видео в заполнитель:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Обрезка изображений**

Этот C++ код показывает, как обрезать существующее изображение на слайде: 

``` CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Создает новый объект изображения
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Добавляет PictureFrame на слайд
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Обрезает изображение (значения в процентах)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Сохраняет результат
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Удаление обрезанных областей рамки изображения**

Если необходимо удалить обрезанные области изображения, содержащегося в рамке, можно использовать метод [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Этот метод возвращает обрезанное изображение или оригинальное, если обрезка не требуется.

Этот C++ код демонстрирует операцию: 

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Получает рамку изображения с первого слайда
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Удаляет обрезанные области изображения в рамке и возвращает обрезанное изображение
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Сохраняет результат
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

Метод [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [PictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в полученной презентации увеличится.

Метод конвертирует метафайлы WMF/EMF в растр PNG во время операции обрезки. 

{{% /alert %}}

## **Сжатие изображений**

Вы можете сжать изображение в презентации, используя метод [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/compressimage/). Этот метод сжимает изображение, уменьшая его размер в зависимости от размеров фигуры и указанного разрешения, с возможностью удаления обрезанных областей.

Он изменяет размер и разрешение изображения аналогично функции PowerPoint **Формат рисунка → Сжать рисунки → Разрешение**.

Ниже приведены примеры C++ кода, показывающие, как сжать изображение в презентации, задав целевое разрешение и, при необходимости, удалив обрезанные области:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Сжать изображение с целевым разрешением 150 DPI (веб‑разрешение) и удалить обрезанные области.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Проверить результат сжатия.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Или напрямую с пользовательским значением DPI:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Сжать изображение до 150 DPI (web resolution), удаляя обрезанные области.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

Метод конвертирует изображение в более низкое разрешение, исходя из размеров фигуры и заданного DPI. Обрезанные регионы также могут быть удалены для оптимизации размера файла.  
Если изображение является метафайлом (WMF/EMF) или SVG, сжатие не будет применено. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично тому, как PowerPoint обрабатывает JPEG высокого разрешения. 

{{% /alert %}}

## **Блокировка соотношения сторон**

Если вы хотите, чтобы фигура, содержащая изображение, сохраняла своё соотношение сторон даже после изменения размеров изображения, используйте метод [set_AspectRatioLocked()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) для установки параметра *Lock Aspect Ratio*. 

Этот C++ код показывает, как заблокировать соотношение сторон фигуры:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// установить форму, чтобы сохранять соотношение сторон при изменении размеров
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

Параметр *Lock Aspect Ratio* сохраняет только соотношение сторон самой фигуры, а не изображения, которое она содержит. 

{{% /alert %}}

## **Использование свойства StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) и [StretchOffsetBottom](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) из интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_picture_fill_format) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.picture_fill_format) вы можете задать прямоугольник заполнения. 

Когда указывается растягивание изображения, исходный прямоугольник масштабируется, чтобы вписаться в указанный прямоугольник заполнения. Каждая грань прямоугольника заполнения задаётся процентным смещением от соответствующей грани ограничивающего прямоугольника фигуры. Положительный процент указывает на вложение, отрицательный — на выступ.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте прямоугольник `AutoShape`.  
4. Создайте изображение.  
5. Установите тип заливки фигуры.  
6. Установите режим заливки изображения.  
7. Добавьте изображение для заполнения фигуры.  
8. Укажите смещения изображения от соответствующей грани ограничивающего прямоугольника фигуры.  
9. Сохраните изменённую презентацию в файл PPTX.  

Этот C++ код демонстрирует процесс использования свойства StretchOff:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Устанавливает растягивание изображения со всех сторон тела фигуры
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Как узнать, какие форматы изображений поддерживаются для PictureFrame?

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, присвоенный [PictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/). Список поддерживаемых форматов, как правило, совпадает с возможностями движка конвертации слайдов и изображений.

### Как добавление десятков больших изображений повлияет на размер и производительность PPTX?

Встраивание больших изображений увеличивает размер файла и потребление памяти; привязка изображений по ссылкам помогает уменьшить размер презентации, но требует постоянного доступа к внешним файлам. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для снижения размеров файлов.

### Как заблокировать объект изображения от случайного перемещения/изменения размеров?

Используйте [блокировки фигур](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/get_pictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размеров). Механизм блокировки описан в отдельной [статье о защите](/slides/ru/cpp/applying-protection-to-presentation/) и поддерживается для различных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/).

### Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?

Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/cpp/convert-powerpoint-to-png/) результат может быть растровым в зависимости от параметров экспорта; факт того, что оригинальный SVG сохраняется как вектор, подтверждается поведением извлечения.