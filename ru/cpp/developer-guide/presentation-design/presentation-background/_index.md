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
- фоновое изображение
- прозрачность фона
- свойства фона
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для C++, а также получите советы по коду для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используют в качестве фона слайда. Вы можете задать фон для **обычного слайда** (одного слайда) или **макетного слайда** (применяется к нескольким слайдам одновременно).

![Фоновый рисунок PowerPoint](powerpoint-background.png)

## **Задать сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует макетный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Задайте свойству слайда [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) значение `OwnBackground`.
3. Задайте свойству фона слайда [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) значение `Solid`.
4. Вызовите метод [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) у [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) и укажите сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример на C++ показывает, как задать синий сплошной цвет в качестве фона обычного слайда:
```cpp
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


## **Задать сплошной цвет фона для макетного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для макетного слайда в презентации. Макетный слайд выступает шаблоном, который управляет форматированием всех слайдов, поэтому при выборе сплошного цвета для фона макетного слайда он применяется к каждому слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Задайте свойству макетного слайда [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) (через `get_Masters`) значение `OwnBackground`.
3. Задайте свойству фона макетного слайда [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) значение `Solid`.
4. Вызовите метод [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) и укажите сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример на C++ показывает, как задать сплошной цвет (лесной зелёный) в качестве фона макетного слайда:
```cpp
// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Установите цвет фона для мастер‑слайда в лесной зелёный.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Сохраните презентацию на диск.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Задать градиентный фон для слайда**

Градиент — это графический эффект, создаваемый постепённым изменением цвета. При использовании в качестве фона слайда градиенты могут сделать презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона для слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Задайте свойству слайда [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) значение `OwnBackground`.
3. Задайте свойству фона слайда [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) значение `Gradient`.
4. Вызовите метод [get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_gradientformat/) у [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) и настройте желаемые параметры градиента.
5. Сохраните изменённую презентацию.

Следующий пример на C++ показывает, как задать градиентный цвет в качестве фона слайда:
```cpp
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


## **Задать изображение в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Задайте свойству слайда [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) значение `OwnBackground`.
3. Задайте свойству фона слайда [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) значение `Picture`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Вызовите метод [get_PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_picturefillformat/) у [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) и присвойте изображение в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример на C++ показывает, как задать изображение в качестве фона слайда:
```cpp
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

// Save the presentation to disk.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Следующий образец кода показывает, как задать тип заливки фона в виде мозаичного изображения и изменить свойства мозаики:
```cpp
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


{{% alert color="primary" %}}

Узнайте больше: [**Текстурировать мозаичным изображением**](/slides/ru/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам понадобится отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код на C++ показывает, как изменить прозрачность фонового изображения слайда:
```cpp
auto transparencyValue = 30; // Например.

// Получить коллекцию операций трансформации изображения.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Найти существующий эффект прозрачности с фиксированным процентом.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Установить новое значение прозрачности.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```


## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс раскрывает эффективный [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) и [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

С помощью метода `get_Background` класса [BaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/) вы можете получить эффективный фон для слайда.

Следующий пример на C++ показывает, как получить эффективное значение фона слайда:
```cpp
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

**Можно ли сбросить пользовательский фон и восстановить фон из темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон будет вновь получен от соответствующего [layout](/slides/ru/cpp/slide-layout/)/[master](/slides/ru/cpp/slide-master/) слайда (то есть от [theme background](/slides/ru/cpp/presentation-theme/)).

**Что произойдёт с фоном, если я позже изменю тему презентации?**

Если у слайда есть собственная заливка, она останется неизменной. Если фон наследуется от [layout](/slides/ru/cpp/slide-layout/)/[master](/slides/ru/cpp/slide-master/), он обновится в соответствии с [new theme](/slides/ru/cpp/presentation-theme/).