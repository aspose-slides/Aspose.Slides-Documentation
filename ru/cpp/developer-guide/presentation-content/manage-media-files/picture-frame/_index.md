---
title: Управление кадрами изображений в презентациях с использованием C++
linktitle: Кадр изображения
type: docs
weight: 10
url: /ru/cpp/picture-frame/
keywords:
- кадр изображения
- добавить кадр изображения
- создать кадр изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG‑изображение
- обрезать изображение
- удалить обрезанные области
- сжать изображение
- StretchOffset
- форматирование кадра изображения
- относительное масштабирование
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте кадры изображений в презентациях с помощью Aspose.Slides для C++."
---
## **Обзор**

Кадр изображения — это форма слайда, отображающая изображение. В Aspose.Slides ресурс изображения и форма, его отображающая, являются отдельными объектами: объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою [коллекцию изображений](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_images/), тогда как [IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/) управляет положением изображения, размером, форматированием линий, вращением, обрезкой, эффектами изображения и другими настройками уровня кадра.

Это разделение полезно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращённый объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/), и используйте этот ресурс изображения при создании кадров.

Кадры изображений могут содержать растровые изображения, такие как PNG или JPEG, и векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как будет храниться изображение, до применения форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте кадр изображения с помощью [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapecollection/addpictureframe/). Изображение становится частью пакета презентации, поэтому презентация остаётся самодостаточной при перемещении на другой компьютер.

В следующем примере добавляется JPEG‑изображение, создаётся кадр в оригинальных размерах изображения и применяются форматирование линии и вращение:

```cpp
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
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Кадр изображения управляет отображаемой геометрией; изменение размера кадра не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштабирования**

[IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/) предоставляет относительное масштабирование ширины и высоты кадра. Значение `1.0` соответствует 100 % оригинального размера изображения. Относительное масштабирование полезно, когда требуется сохранять соотношение с исходным размером изображения вместо ручного вычисления конечных размеров.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Относительное масштабирование изменяет настройки масштаба кадра; оно не приводит к ресэмплингу или сжатию встроенного изображения.

## **Встроенные и связанные изображения**

Встроенный кадр хранит данные изображения внутри презентации и поэтому является самым надёжным выбором для переносимости и предсказуемого отображения. Связанный кадр хранит внешний путь через свойство ссылки [ISlidesPicture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidespicture/) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменяется, файл перемещён или ресурс недоступен, связанный кадр может не отобразиться как ожидалось. Для презентаций, которые должны отправляться по электронной почте, архивироваться или рендериться в изолированных средах, встроенные изображения обычно надёжнее.

### **Добавление связанного изображения**

В следующем примере создаётся кадр изображения и указывается локальный файл изображения. Пример охватывает только привязку изображения; привязка видео — отдельный медиапроцесс и намеренно не смешана в этом примере.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Используйте ссылки, когда управление внешними файлами намеренно. Не используйте их просто как замену сжатию: небольшая PPTX с нарушенными зависимостями изображений обычно менее полезна, чем более крупная самодостаточная презентация.

## **Извлечение изображений из кадров**

Перед извлечением изображения из существующей презентации проверьте, что объект действительно является [IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/) и что он содержит встроенное изображение. Связанные кадры могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображений работает напрямую с [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/). В следующем примере находится первое встроенное растровое изображение на слайде и сохраняется как PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Сохранение через [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) преобразует извлечённое изображение в требуемый формат вывода. Если нужны закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑изображения объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) предоставляет объект [ISvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/). Это позволяет получить SVG‑данные напрямую, не растрируя изображение сначала.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
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

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Сохранение содержимого SVG как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, неизбежно рендерит векторное содержимое в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированную графику нельзя рассматривать как побайтную копию оригинального встроенного SVG; используйте встроенные данные [ISvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/), когда требуется сам векторный ресурс.

## **Обрезка изображения**

Обрезка изменяет ту часть изображения, которая видна внутри кадра. Значения обрезки в [IPictureFillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она лишь изменяет видимую область.

В следующем примере надёжно находится кадр изображения и применяются значения обрезки:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удаление обрезанных данных изображения**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для последующей операции «разобрезки».

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими кадрами, эти кадры всё равно нуждаются в своём существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка содержимого WMF или EMF этим методом растрирует полученный результат в PNG.

## **Сжатие растровых изображений**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/compressimage/) уменьшает разрешение растрового изображения относительно размера, в котором изображение отображается. Он также может удалять обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено размером или обрезано, и `false`, когда изменения не требовались.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/picturescompression/), когда достаточно стандартного целевого разрешения:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Вместо значения перечисления можно передать пользовательское положительное значение DPI, когда требуется конкретная цель.

Сжатие предназначено для растровых изображений. Содержание SVG и метафайлов не уменьшается этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные регионы нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из наибольшего размера, при котором изображение действительно будет просматриваться или экспортироваться, а не применяя самое низкое DPI глобально.

## **Управление эффектами преобразования изображения**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые преобразования, размытие, альфа‑эффекты, упорядоченные цепочки, проверку, удаление и проверку обратного перехода, смотрите [Image Transform Effects](/slides/ru/cpp/image-transform-effects/).

## **Блокировка геометрии кадра изображения**

Настройки [IPictureFrameLock](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframelock/) управляют тем, какие операции редактирования отключены для кадра изображения. Например, [блокировка соотношения сторон](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) сохраняет пропорции формы при её изменении размера.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Блокировка применяется к форме кадра изображения. Она не заставляет исходное изображение ресэмплироваться или постоянно менять соотношение сторон.

## **Настройка значений StretchOffset**

Когда режим заполнения изображения — растягивание, значения stretch‑offset в [IPictureFillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/) определяют прямоугольник заполнения относительно ограничивающего блока кадра. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Параметры обрезки выбирают, какая часть исходного изображения видна; stretch‑offset изменяет прямоугольник, в который растягивается видимая заливка изображения.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Используйте stretch‑offset для размещения заливки. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения экспорта**

Основные компромиссы проще управлять, когда хранение изображений и форматирование кадров рассматриваются отдельно:

- **Встроенные изображения** делают презентацию самодостаточной и являются самым надёжным вариантом для совместного использования и серверного рендеринга, однако большие растрированные изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** могут уменьшить размер пакета, но презентация зависит от доступности внешних файлов по сохранённым путям или местоположениям.
- **Обрезка** изначально не разрушительна. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удалены или не удалены во время сжатия.
- **Сжатие** может существенно уменьшить размер файла для переразмеренных растровых изображений, но теряется исходное разрешение. Применяйте его после того, как известен предполагаемый размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна сохранность вектора. Извлекайте встроенный SVG напрямую, когда требуется сам векторный ресурс. Экспорт слайдов в растровый формат всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [IPPImage], когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для крупных презентаций оптимизация изображений обычно наиболее эффективна при выборе: храните логотипы и схемы как векторный контент, сжимайте фотографии согласно их реальному размеру отображения, удаляйте обрезанные пиксели только тогда, когда последующее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью стратегии развертывания.

## **FAQ**

**В чём разница между кадром изображения и ресурсом изображения?**

[IPPImage] представляет ресурс изображения, связанный с презентацией. [IPictureFrame] — это форма на слайде, которая отображает изображение и хранит геометрию и форматирование уровня кадра, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно хранить файлы изображений вне PPTX и внешние расположения можно надёжно поддерживать.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют пиксели. Используйте [IPictureFillFormat::DeletePictureCroppedAreas] или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно удалить навсегда.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных регионов отбрасывает данные изображения. Сохраняйте оригинальное изображение вне презентации, если впоследствии может потребоваться редактирование в высоком разрешении.

**Как обращаться с SVG‑изображениями?**

Сохраняйте SVG‑содержание как SVG, когда важна точность вектора. Встроенный [ISvgImage] можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растрабилизует SVG как часть изображения слайда.

**Как избежать небезопасных приведения типов при чтении существующих слайдов?**

Проверьте тип формы перед использованием членов, специфичных для кадра изображения. Тестируйте форму с помощью [IPictureFrame] перед выполнением приведения типа во время выполнения и присваивайте результат приведения локальной переменной перед доступом к членам кадра изображения.