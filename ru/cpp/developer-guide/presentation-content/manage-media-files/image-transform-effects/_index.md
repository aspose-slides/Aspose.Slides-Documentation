---
title: Управляйте эффектами преобразования изображений в презентациях с C++
linktitle: Эффекты преобразования изображений
type: docs
weight: 11
url: /ru/cpp/image-transform-effects/
keywords:
- преобразование изображения
- эффект изображения
- яркость
- контраст
- градация серого
- дутон
- оттенок
- HSL
- замена цвета
- размытие
- прозрачность
- альфа-эффект
- цепочка эффектов
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Применяйте, комбинируйте, проверяйте, удаляйте и подтверждайте эффекты преобразования изображений для рамок картинок с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides представляет корректировки изображения как упорядоченную коллекцию операций преобразования изображений. Для рамки изображения начните с рамки [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) и получите доступ к [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). Возвращаемая [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) позволяет добавлять, перечислять, проверять, удалять и очищать эффекты без переписывания исходных байтов изображения.

Эта статья демонстрирует полный рабочий процесс для яркости и контрастности, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки обратного пути PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и изображение, которое его отображает, — это разные объекты:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) принадлежит заполнению картинки и ссылается на ресурс изображения, одновременно храня коллекцию преобразований изображения.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) — это форма слайда, которая владеет соответствующим заполнением картинки, геометрией, настройками обрезки и другими параметрами уровня рамки.

Поэтому операции преобразования изображения не изменяют байты в [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). Когда один и тот же `IPPImage` передаётся в [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) более одного раза, каждая новая рамка изображения получает собственный `ISlidesPicture` и собственную коллекцию преобразований. Применение градации серого к одной рамке не делает остальные рамки градацией серого, хотя все они используют один и тот же встроенный ресурс изображения.

Та же модель `ISlidesPicture::get_ImageTransform` используется и другими заполнениями изображений, например фигурой или фоном слайда. Примеры ниже сосредоточены на рамках изображений.

## **Использование допустимых диапазонов параметров и единиц измерения**

Продемонстрированные методы используют следующие смысловые диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое значение сразу; целевой формат презентации может нормализовать, опустить или отвергнуть недопустимые данные при сохранении или при открытии файла в PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` … `100`, процентов; `0` оставляет компонент без изменений. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Нет | Нет числовых параметров. Альфа остаётся без изменений. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `System::Drawing::Color` используют значения от `0` до `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Оттенок `0` включительно … `360` исключая, в градусах; количество `-100` … `100`, процентов. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Оттенок `0` включительно … `360` исключая, в градусах; насыщенность и яркость `-100` … `100`, процентов. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Заменяющий цвет использует каналы от `0` до `255`. Существующие значения альфа остаются без изменений. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Радиус неотрицательный и измеряется в пунктах; `grow` управляет тем, может ли размытый контент выходить за пределы исходных границ. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Неотрицательные проценты. Используйте `0` … `100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` сохраняет существующую альфу. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` … `100`, процентов непрозрачности. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` … `100`, процентов порога альфа. Значения ниже становятся прозрачными; значения, равные или выше порога, становятся непрозрачными. |

Для фиксированной модуляции альфа, прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует значению модуляции альфа 65 %.

## **Применение яркости и контрастности**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) возвращает операцию [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). Ее скалярные настройки передаются при создании операции. Метод `IBrightnessContrast::GetEffective` возвращает вычисленные только для чтения значения, которые можно проанализировать или записать в журнал.

В следующем примере яркость увеличивается на 15 %, контраст — на 20 %, затем создаётся превью без изменения встроенного изображения:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) — это расширение эффекта картинок Office 2010 и менее переносимо, чем стандартный эффект яркости DrawingML. Когда яркость и контрастность должны оставаться редактируемыми после обратного пути PPTX, используйте [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) и проверьте результат после повторного открытия файла. Раздел «ограничения формата» объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к разным рамкам, использующим один ресурс изображения. В следующем примере создаётся пять рамок и применяются градация серого, дутон, оттенок, коррекция HSL и замена цвета.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) содержит два независимо редактируемых параметра цвета: `get_Color1` задаёт тёмные пиксели, а `get_Color2` — светлые. Это делает его полезным примером эффекта с более сложными настройками, чем одиночное скалярное значение.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) заменяет цвет каждого пикселя на один фиксированный цвет, сохраняя альфа‑канал. Это отличается от [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), который отображает один исходный цвет в другой и раскрывает форматы как исходного, так и целевого цвета.

### **Применение порога яркости**

Порог яркости может облегчить различие слабых меток на отсканированной странице от фона. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) сохраняет промежуточные оттенки серого. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) преобразует яркость в чёрный или белый, тогда как [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) применяет порог к непрозрачности.

Порог яркости варьируется от 0 % до 100 %, включительно. Пиксели ниже порога становятся чёрными. Пиксели, равные или выше порога, становятся белыми. Увеличение порога делает больше оттенков чёрными, поскольку больше их попадает ниже отсечения.

Скачайте [grayscale-swatches.png](grayscale-swatches.png) в рабочий каталог. Каждая подпись указывает исходный уровень серого по шкале от 0 до 255. Пример размещает оригинал рядом с двумя копиями и сохраняет порог каждой копии в презентации.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Откройте получившуюся презентацию в PowerPoint, чтобы сравнить три рамки. Образец с меткой 96 имеет около 38 % яркости (96 из 255). Он становится белым при пороге 20 % и чёрным при пороге 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Добавление размытия, прозрачности и альфа‑эффектов**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) затрагивает все цветовые каналы, включая альфа. Установите `grow` в `true`, когда размазанный край может выйти за пределы исходных границ изображения.

Для равномерной прозрачности используйте [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют относительные различия. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) вместо этого присваивает одно значение альфа всем пикселям. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) переводит альфа в два уровня по заданному порогу.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Другие операции альфа без параметров включают [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), который делает каждый ненулевой альфа полностью непрозрачным; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), который делает каждый альфа ниже 100 % полностью прозрачным; и [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), который меняет альфа на `100% - alpha`.

## **Построение упорядоченной цепочки эффектов**

Каждый метод `Add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и т.д. Следовательно, одинаковые операции в разном порядке могут дать разные изображения.

Например, градация серого, а затем оттенок сначала удаляют хроматическую информацию, а затем перекрашивают результат яркости. Оттенок, а затем градация серого снова удаляют оттенок. Аналогично, замена альфа может переопределить значения альфа, рассчитанные ранее, тогда как модуляция альфа сохраняет их относительные различия.

В следующем примере создаётся цепочка из четырёх операций, сохраняется как PPTX, файл переоткрывается, проверяются типы операций и их порядок, и выводится переоткрытый результат:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размытие операции отдельными цепочками. Их можно комбинировать, но не все комбинации полезны. Фиксированная замена цвета удаляет вариацию RGB, созданную предыдущими цветовыми эффектами; градация серого после дутон удаляет два выбранных цвета; операции альфа‑потолок, пол, замена или би‑уровень могут отбросить детали альфа, созданные ранее. Формируйте цепочку в соответствии с желаемой последовательностью обработки пикселей, а не как набор несвязанных флагов форматирования.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Проверка редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в `ISlidesPicture::get_ImageTransform`. В зависимости от эффекта она может напрямую раскрывать записываемые члены. Например, [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) раскрывает `set_Radius` и `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) раскрывает `set_Amount`, а [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) раскрывает `set_Threshold`. Цветовые эффекты, такие как [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/), раскрывают изменяемые объекты [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/).

Некоторые интерфейсы операций, включая [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), и [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), не раскрывают скаляры создания как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в требуемой позиции.

Эффективные данные, возвращаемые `GetEffective()`, вычисляются и являются только для чтения. Они полезны для разрешения зависящих от темы цветов и чтения нормализованных значений, которые использует рендерер, но не являются отдельной поверхностью редактирования. В следующем примере перечисляется цепочка и проверяются эффективные значения для нескольких распространённых операций:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Эффекты без параметров, такие как градация серого, альфа‑потолок и альфа‑обратный, также имеют объект эффективных данных, но нет скалярных настроек для вывода. Их присутствие и позиция в коллекции — важная информация.

## **Удаление или очистка преобразований изображения**

Используйте [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) для удаления одной операции по индексу. Поскольку индексы сдвигаются после удаления, сначала найдите цель, затем удалите её после перебора. Используйте `Clear()` для удаления всей цепочки.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Удаление или очистка преобразований меняет только форматирование картинки. Это не удаляет, не перепаковывает и не меняет повторно используемый ресурс [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).

## **Учёт форматов презентаций и целевых экспортов**

Преобразования изображений происходят в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже в PPTX не каждый эффект обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как яркость, градация серого, дутон, оттенок, HSL, размытие и общие альфа‑операции, имеют наибольшие шансы сохраниться после обратного пути PPTX. Всегда переоткрывайте созданный файл и проверяйте коллекцию, когда требуется сохранение.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) — расширение Office 2010, а не стандартная операция яркости DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и переоткрытия PPTX он останется редактируемым [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). Предпочтительно использовать [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) для постоянных коррекций яркости и контрастности.
- Бинарный формат PPT предшествовал полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно отобразить внешний вид. Не используйте PPT как формат проверки для сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к отображаемому результату. Эти выводы не содержат редактируемой `IImageTransformOperationCollection`; растровые форматы уплощают результат в пиксели, а документные или векторные экспорты хранят собственное представление рендеринга.
- Эффекты не делают связанное изображение автономным. Рендеринг связанной картинки всё равно требует наличия связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному отображать граничные случаи, особенно когда комбинируются несколько альфа‑или цветоквантовых операций. Для критических результатов протестируйте как редактируемый обратный путь, так и финальный экспортный формат с той же версией Aspose.Slides, что используется в продакшене.

## **FAQ**

**Изменяют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции принадлежат `ISlidesPicture`, используемому для заполнения картинки. Базовые байты `IPPImage` остаются без изменений.

**Будут ли две рамки, использующие одно и то же изображение, делить свои эффекты?**

Нет. Повторное использование `IPPImage` избавляет от дублирования данных изображения, но каждая рамка обычно имеет отдельный `ISlidesPicture` и собственную коллекцию преобразований изображения.

**Можно ли комбинировать цветовые, размывающие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция влияет на результат предыдущей, потому что операции замены и пороговые могут отбрасывать ранее созданные цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые при рендеринге, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции преобразований, где есть записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат использовать для сохранения цепочки преобразований?**

Используйте PPTX и проверьте файл, переоткрыв его. Устаревший PPT не может представить полную модель эффектов DrawingML, а экспортные форматы сохраняют только внешний вид, а не редактируемые операции преобразования.