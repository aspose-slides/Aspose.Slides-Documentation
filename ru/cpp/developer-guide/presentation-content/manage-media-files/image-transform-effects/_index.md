---
title: Управление эффектами трансформации изображений в презентациях на C++
linktitle: Эффекты трансформации изображения
type: docs
weight: 11
url: /ru/cpp/image-transform-effects/
keywords:
- трансформация изображения
- эффект рисунка
- яркость
- контраст
- градация серого
- дуотон
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
description: "Применяйте, комбинируйте, проверяйте, удаляйте и проверяйте эффекты трансформации изображений для кадров рисунков с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides представляет настройки изображения как упорядоченную коллекцию операций трансформации изображения. Для кадра рисунка начните с [ISlidesPicture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidespicture/) кадра и обратитесь к [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidespicture/get_imagetransform/). Возвращаемый [IImageTransformOperationCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/) позволяет добавлять, перечислять, проверять, удалять и очищать эффекты без перезаписи оригинальных байтов изображения.

В этой статье показан полный рабочий процесс для яркости и контраста, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки сквозного прохода PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и картинка, его отображающая, — разные объекты:

- [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [ISlidesPicture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidespicture/) принадлежит заполнению рисунка и ссылается на ресурс изображения, одновременно храня коллекцию трансформаций изображения.
- [IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/) — элемент слайда, владеющий соответствующим заполнением рисунка, геометрией, настройками обрезки и другими параметрами уровня кадра.

Поэтому операции трансформации изображения не изменяют байты в [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/). Когда один и тот же `IPPImage` передаётся в [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addpictureframe/) более одного раза, каждый новый кадр получает собственный `ISlidesPicture` и собственную коллекцию трансформаций. Применение градации серого к одному кадру не делает остальные кадры градацией серого, хотя все они используют один и тот же встроенный ресурс изображения.

Та же модель `ISlidesPicture::get_ImageTransform` используется и другими заполнениями рисунка, например фигурой или фоном слайда. Примеры ниже сосредоточены на кадрах рисунков.

## **Использование допустимых диапазонов параметров и единиц измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждый недопустимый параметр сразу; целевой формат презентации может нормализовать, опустить или отклонить неверные данные при сохранении или при открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` до `100`, процент; `0` оставляет компонент без изменений. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Нет числовых параметров. Альфа остаётся неизменной. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `System::Drawing::Color` используют значения от `0` до `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Оттенок от `0` включительно до `360` исключительно, в градусах; количество от `-100` до `100`, процент. |
| [AddHSLEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Оттенок от `0` включительно до `360` исключительно, в градусах; насыщенность и светлота от `-100` до `100`, процент. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Заменяющий цвет использует значения каналов от `0` до `255`. Существующие значения альфа сохраняются. |
| [AddBlurEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Радиус неотрицательный и измеряется в пунктах; `grow` определяет, может ли размытие выйти за пределы исходных границ. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Неотрицательный процент. Используйте `0`‑`100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` сохраняет исходную альфу. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑`100`, процент непрозрачности. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑`100`, процентный порог альфа. Значения ниже порога становятся прозрачными; значения, равные или превышающие порог, становятся непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствуют модуляции альфа = 65 %.

## **Применение яркости и контраста**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) возвращает операцию [IBrightnessContrast](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/ibrightnesscontrast/). Его скалярные настройки задаются при создании операции. Метод `IBrightnessContrast::GetEffective` возвращает вычисленные только для чтения значения, которые можно просмотреть или записать в журнал.

В следующем примере яркость увеличивается на 15 %, контраст — на 20 %, после чего отображается предварительный просмотр без изменения встроенного изображения:

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

[BrightnessContrast](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/brightnesscontrast/) — расширение эффекта изображения Office 2010 и менее переносимо, чем стандартный эффект luminance DrawingML. Когда яркость и контраст должны оставаться редактируемыми после сквозного прохода PPTX, используйте [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) и проверьте результат после повторного открытия файла. Раздел ограничений формата объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к различным кадрам, переиспользующим один ресурс изображения. В следующем примере создаётся пять кадров и применяются градация серого, дуотон, оттенок, корректировка HSL и замена цвета.

[IDuotone](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iduotone/) содержит два независимых редактируемых цветовых параметра: `get_Color1` сопоставляет тёмные пиксели, а `get_Color2` — светлые. Это делает его полезным примером эффекта, настройки которого сложнее одной скалярной величины.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) заменяет каждый пиксель фиксированным цветом, сохраняя альфу. Это отличается от [AddColorChangeEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), который сопоставляет один исходный цвет другому и раскрывает форматы исходного и целевого цвета.

## **Добавление размытия, прозрачности и альфа‑эффектов**

[AddBlurEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) воздействует на все цветовые каналы, включая альфу. Установите `grow` в `true`, когда размытие может выйти за пределы исходных границ рисунка.

Для равномерной прозрачности используйте [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют пропорциональные различия. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) вместо этого задаёт одно значение альфа для всех пикселей. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) переводит альфу в два уровня на основе порога.

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

Другие альфа‑операции без параметров включают [AddAlphaCeilingEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), который делает любую ненулевую альфу полностью непрозрачной; [AddAlphaFloorEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), который делает любую альфу ниже 100 % полностью прозрачной; и [AddAlphaInverseEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), который меняет альфу на `100% - alpha`.

## **Построение упорядоченной цепочки эффектов**

Каждый метод `Add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится входом операции 1 и т.д. Следовательно, одинаковый набор операций в разном порядке может дать другое изображение.

Например, градация серого, а затем оттенок сначала удаляют хроматическую информацию, а затем перекрашивают полученную светлость. Оттенок, а затем градация серого снова убирает оттенок. Аналогично, замена альфа может переопределить значения, рассчитанные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

В следующем примере создаётся цепочка из четырёх операций, сохраняется как PPTX, презентация открывается вновь, проверяются типы операций и их порядок, после чего отображается результат повторного открытия:

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

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа и размытие отдельными цепочками. Их можно комбинировать, но не все комбинации полезны. Фиксированная замена цвета убирает вариации RGB, созданные предыдущими цветовыми эффектами; градация серого после дуотона удаляет два выбранных цвета; а операции альфа‑потолка, пола, замены или би‑уровня могут отбрасывать детали альфа, созданные ранее. Формируйте цепочку согласно желаемой последовательности обработки пикселей, а не как набор несортированных флагов форматирования.

## **Проверка редактируемых и эффективных значений**

Редактируемая операция — объект, хранящийся в `ISlidesPicture::get_ImageTransform`. В зависимости от эффекта он может напрямую раскрывать записываемые члены. Например, [IBlur](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iblur/) раскрывает `set_Radius` и `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/ialphamodulatefixed/) раскрывает `set_Amount`, а [IAlphaBiLevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/ialphabilevel/) раскрывает `set_Threshold`. Цветовые эффекты, такие как [IDuotone](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iduotone/), раскрывают изменяемые объекты [IColorFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icolorformat/).

Некоторые интерфейсы операций, включая [IBrightnessContrast](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/itint/) и [IAlphaReplace](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/ialphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить такие настройки, удалите операцию и добавьте замену в требуемой позиции.

Эффективные данные, возвращаемые `GetEffective()`, вычисляются и доступны только для чтения. Они полезны для разрешения цветов, зависящих от темы, и чтения нормализованных значений, используемых рендерером, но не являются отдельной поверхностью редактирования. В следующем примере перечисляется цепочка и проверяются эффективные значения нескольких распространённых операций:

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

Эффекты без параметров, такие как градация серого, альфа‑потолок и альфа‑инверсия, всё‑равно имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции — важная информация.

## **Удаление или очистка трансформаций изображения**

Используйте [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) для удаления одной операции по индексу. Поскольку индексы сдвигаются после удаления, сначала найдите нужный элемент, а затем удалите его после перебора. Для удаления всей цепочки используйте `Clear()`.

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

Удаление или очистка трансформаций изменяет только оформление рисунка. Это не удаляет, не пересжимает и не изменяет переиспользуемый ресурс [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/).

## **Учет форматов презентаций и целевых экспортов**

Трансформации изображения происходят в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже в PPTX не каждый эффект обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и распространённые альфа‑операции, имеют наибольшие шансы сохраниться после сквозного прохода PPTX. Всегда повторно открывайте сгенерированный файл и проверяйте коллекцию, когда требуется сохранность.
- [BrightnessContrast](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/brightnesscontrast/) — расширение Office 2010, а не стандартная операция DrawingML luminance. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемым [IBrightnessContrast](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/ibrightnesscontrast/). Предпочтительно использовать [AddLuminanceEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) для постоянных настроек яркости и контраста.
- Бинарный формат PPT предшествовал полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизить внешний вид. Не используйте PPT для проверки сложных редактируемых цепочек.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к полученному изображению. Эти выводы не содержат редактируемой `IImageTransformOperationCollection`; растровые форматы фиксируют результат в пикселях, а документные или векторные экспорты хранят собственные представления рендеринга.
- Эффекты не делают связанное изображение автономным. При рендеринге связанной картинки всё равно требуется наличие связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному обрабатывать граничные случаи, особенно когда комбинируются несколько альфа‑ или цветоквантизационных операций. Для критически важного вывода тестируйте и редактируемый сквозной проход, и финальный экспортный формат той же версии Aspose.Slides, что используется в продакшене.

## **FAQ**

**Изменяют ли эффекты трансформации изображения встроенные данные изображения?**

Нет. Операции принадлежат `ISlidesPicture`, использованному в заполнении рисунка. Байт‑массив `IPPImage` остаётся неизменным.

**Будут ли два кадра, использующие один и тот же ресурс изображения, делить свои эффекты?**

Нет. Переиспользование `IPPImage` избавляет от дублирования данных изображения, но каждый кадр обычно имеет отдельный `ISlidesPicture` и отдельную коллекцию трансформаций.

**Можно ли комбинировать цветовые, размывающие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция влияет на результат предыдущей, поскольку операции замены и порога могут отбрасывать ранее созданные детали цвета или альфа.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые для рендеринга, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции трансформаций, где существуют записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат следует использовать для сохранения цепочки трансформаций?**

Используйте PPTX и проверьте файл, повторно открыв его. Устаревший PPT не может полностью представить модель эффектов DrawingML, а форматы экспортов сохраняют лишь внешний вид, а не редактируемые операции трансформации.