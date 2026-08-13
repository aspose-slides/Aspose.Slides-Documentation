---
title: Управление фонами презентаций в C++
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/cpp/presentation-background/
keywords:
- фон презентации
- фон слайда
- сплошной цвет
- градиентный цвет
- фон изображения
- прозрачность фона
- свойства фона
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для C++, а также получите советы по коду для улучшения ваших презентаций."
---
## **Введение**

Сплошные цвета, градиенты и изображения обычно используются в качестве фона слайдов. Вы можете установить фон для **обычного слайда** (одного слайда) или **мастер-слайда** (применяется сразу к нескольким слайдам).

![Фон PowerPoint](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует мастер‑слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Установите для слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/backgroundtype/) в `OwnBackground`.
3. Установите тип заполнения фона слайда [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) в `Solid`.
4. Вызовите метод [get_SolidFillColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/get_solidfillcolor/) у [FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/), чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример на C++ показывает, как установить синий сплошной цвет в качестве фона обычного слайда:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Установите цвет фона слайда в синий.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Сохраните презентацию на диск.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установить сплошной цвет фона для мастер-слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для мастер‑слайда в презентации. Мастер‑слайд выступает в роли шаблона, который задаёт форматирование для всех слайдов, поэтому выбор сплошного цвета фона мастер‑слайда применяется ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Установите для мастер-слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/backgroundtype/) (через `get_Masters`) в `OwnBackground`.
3. Установите тип заполнения фона мастер‑слайда [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) в `Solid`.
4. Вызовите метод [get_SolidFillColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/get_solidfillcolor/), чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример на C++ показывает, как установить сплошной цвет (лесной зелёный) в качестве фона мастер‑слайда:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Установите цвет фона мастер‑слайда в лесной зелёный.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Сохраните презентацию на диск.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установить градиентный фон для слайда**

Градиент — это графический эффект, создаваемый постепенным изменением цвета. При использовании в качестве фона слайда градиенты делают презентацию более художественной и профессиональной. Aspose.Slides позволяет установить градиентный цвет в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Установите для слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/backgroundtype/) в `OwnBackground`.
3. Установите тип заполнения фона слайда [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) в `Gradient`.
4. Вызовите метод [get_GradientFormat] у [FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/), чтобы настроить требуемые параметры градиента.
5. Сохраните изменённую презентацию.

Следующий пример на C++ показывает, как установить градиентный цвет в качестве фона слайда:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Примените градиентный эффект к фону.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Сохраните презентацию на диск.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установить изображение в качестве фона слайда**

Помимо сплошных и градиентных заполнений, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Установите для слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/backgroundtype/) в `OwnBackground`.
3. Установите тип заполнения фона слайда [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) в `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Вызовите метод [get_PictureFillFormat] у [FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/), чтобы назначить изображение в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример на C++ показывает, как установить изображение в качестве фона слайда:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Установите свойства фонового изображения.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Загрузите изображение.
auto image = Images::FromFile(u"Tulips.jpg");
// Добавьте изображение в коллекцию изображений презентации.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Сохраните презентацию на диск.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Следующий образец кода показывает, как установить тип заполнения фона в виде мозаичного изображения и изменить свойства мозаики:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}

Подробнее: [**Мозаичное изображение как текстура**](/slides/ru/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам понадобится отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код на C++ показывает, как изменить прозрачность фонового изображения слайда:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Например.

// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Получите коллекцию операций трансформации изображения.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Найдите существующий эффект фиксированной процента прозрачности.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Установите новое значение прозрачности.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Сохраните презентацию на диск.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) и [EffectFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

С помощью метода `get_Background` класса [BaseSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseslide/) можно получить эффективный фон слайда.

Следующий пример на C++ показывает, как получить эффективное значение фона слайда:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

### Можно ли сбросить пользовательский фон и восстановить фон темы/разметки?

Да. Удалите пользовательское заполнение слайда, и фон будет снова унаследован от соответствующего слайда [layout](/slides/ru/cpp/slide-layout/)/[master](/slides/ru/cpp/slide-master/) (то есть от [theme background](/slides/ru/cpp/presentation-theme/)).

### Что происходит с фоном, если я позже изменю тему презентации?

Если у слайда есть собственное заполнение, оно останется без изменений. Если фон унаследован от [layout](/slides/ru/cpp/slide-layout/)/[master](/slides/ru/cpp/slide-master/), он будет обновлен в соответствии с [new theme](/slides/ru/cpp/presentation-theme/).