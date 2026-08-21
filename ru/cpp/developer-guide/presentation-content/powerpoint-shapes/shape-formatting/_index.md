---
title: Форматировать фигуры PowerPoint на C++
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/cpp/shape-formatting/
keywords:
- форматировать фигуру
- форматировать линию
- эффект наброска
- линия фигуры наброска
- форматировать стиль соединения
- градиентная заливка
- заполнение узором
- заполнение изображением
- текстурная заливка
- сплошная заливка цветом
- прозрачность фигуры
- чёрно‑белое отображение фигуры
- отображение фигуры в градациях серого
- вращение фигуры
- 3D‑эффект фаски
- 3D‑эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на C++ с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, фигуры можно форматировать, указывая настройки, которые управляют заполнением их внутренних областей.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ предоставляет интерфейсы и методы, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже приведена последовательность действий:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linestyle/).
1. Установите ширину линии.
1. Установите [стиль штриха](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linedashstyle/).
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файле PPTX.

Следующий код демонстрирует, как отформатировать прямоугольник `AutoShape`:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto slide = presentation->get_Slide(0);

// Добавить автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Установить цвет заливки для прямоугольной фигуры.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Применить форматирование к линиям прямоугольника.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Установить цвет линии прямоугольника.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Сохранить файл PPTX на диск.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов наброска к линиям фигур**

Эффект наброска делает линию фигуры выглядеть нарисованной от руки. Используйте [IShape::get_LineFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_lineformat/) для доступа к настройкам линии, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilineformat/get_sketchformat/) для доступа к настройкам наброска и [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isketchformat/set_sketchtype/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linesketchtype/).

Следующий код C++ показывает, как применить эффект [LineSketchType::Curved](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType::None](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Значение, возвращаемое [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isketchformat/get_sketchtype/), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться из темы, дочернего или макетного слайда, используйте [ILineFormat::GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilineformat/geteffective/), затем доступ к [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) и читайте [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Эффективное значение отражает фактически применённое форматирование после разрешения наследования:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Форматирование стилей соединения**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется настройка **Round**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код C++ демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с настройками соединения Miter, Bevel и Round:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto slide = presentation->get_Slide(0);

// Добавить три автофигуры типа Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Установить цвет заливки для каждой прямоугольной фигуры.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Установить ширину линии.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Установить цвет линии для каждого прямоугольника.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Установить стиль соединения.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Добавить текст к каждому прямоугольнику.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Сохранить файл PPTX на диск.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить к фигуре плавный переход нескольких цветов. Например, можно задать два или более цветов так, чтобы один постепенно переходил в другой.

Ниже показано, как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) фигуры в значение `Gradient`.
1. Добавьте два желаемых цвета с заданными позициями, используя методы `Add` коллекции градиентных остановок, доступной через интерфейс [IGradientFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию в файле PPTX.

Следующий код C++ демонстрирует, как применить градиентный эффект к эллипсу:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto slide = presentation->get_Slide(0);

// Добавить автофигуру типа Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Применить градиентное форматирование к эллипсу.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Установить направление градиента.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Добавить два градиентных перехода.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Сохранить файл PPTX на диск.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить к фигуре двухцветный узор (точки, полосы, шахматы и т.п.). Вы можете задать собственные цвета для переднего и фонового плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого узора вы всё равно можете указать точные цвета, которые он будет использовать.

Ниже показано, как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) фигуры в значение `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipatternformat/get_backcolor/) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipatternformat/get_forecolor/) узора.
1. Сохраните изменённую презентацию в файле PPTX.

Следующий код C++ демонстрирует, как применить заливку узором к прямоугольнику:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto slide = presentation->get_Slide(0);

// Добавить автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Установить тип заливки в Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Установить стиль узора.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Установить фоновые и передние цвета узора.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Сохранить файл PPTX на диск.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Прямоугольник с узорной заливкой](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, фактически используя его в качестве фона фигуры.

Ниже показано, как с помощью Aspose.Slides применить заливку изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) фигуры в значение `Picture`.
1. Установите режим заливки изображения в `Tile` (или другой предпочитаемый режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Передайте изображение в метод `ISlidesPicture.set_Image`.
1. Сохраните изменённую презентацию в файле PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий код C++ демонстрирует, как залить фигуру изображением:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto slide = presentation->get_Slide(0);

// Добавить автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Установить тип заливки в Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Установить режим заливки изображением.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Загрузить изображение и добавить его в ресурсы презентации.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Установить изображение.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Сохранить файл PPTX на диск.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Фигура с заливкой изображением](picture-fill.png)

### **Повтор изображения в качестве текстуры**

Если нужно задать повторяющееся изображение как текстуру и настроить поведение повторения, используйте следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): задаёт режим заливки изображения — `Tile` или `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): определяет выравнивание плиток внутри фигуры.
- [set_TileFlip](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tileflip/): управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [set_TileOffsetX](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [set_TileOffsetY](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [set_TileScaleX](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): определяет горизонтальное масштабирование плитки в процентах.
- [set_TileScaleY](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): определяет вертикальное масштабирование плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольник с повторяющейся заливкой изображением и настроить параметры плитки:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto firstSlide = presentation->get_Slide(0);

// Добавить автофигуру прямоугольника.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Установить тип заливки фигуры в Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Загрузить изображение и добавить его в ресурсы презентации.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Назначить изображение фигуре.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Настроить режим заливки изображением и свойства повторения.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Сохранить файл PPTX на диск.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Параметры плитки](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, который заполняет фигуру одним ровным цветом. Этот однотонный фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) фигуры в значение `Solid`.
1. Задайте желаемый цвет заливки для фигуры.
1. Сохраните изменённую презентацию в файле PPTX.

Следующий код C++ демонстрирует, как применить сплошную заливку цветом к прямоугольнику в слайде PowerPoint:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto slide = presentation->get_Slide(0);

// Добавить автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Установить тип заливки в Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Установить цвет заливки.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Сохранить файл PPTX на диск.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Фигура со сплошной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошную, градиентную, картинную или текстурную заливку к фигурам, можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокое значение прозрачности делает фигуру более полупрозрачной, позволяя частично видеть фон или вложенные объекты.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) в значение `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Следующий код C++ демонстрирует, как применить прозрачный цвет заливки к прямоугольнику:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto slide = presentation->get_Slide(0);

// Добавить сплошную прямоугольную автофигуру.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Добавить прозрачную прямоугольную автофигуру поверх сплошной фигуры.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Сохранить файл PPTX на диск.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы вращать фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

Следующий код C++ демонстрирует, как вращать фигуру на 5 градусов:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>();

// Получить первый слайд.
auto slide = presentation->get_Slide(0);

// Добавить автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Повернуть фигуру на 5 градусов.
shape->set_Rotation(5);

// Сохранить файл PPTX на диск.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D-эффектов фаски**

Aspose.Slides позволяет применять к фигурам 3D‑эффекты фаски, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/threedformat/).

Чтобы добавить 3D‑эффекты фаски к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/threedformat/) фигуры, определив параметры фаски.
1. Сохраните презентацию.

Следующий код C++ показывает, как применить 3D‑эффекты фаски к фигуре:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Создать экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Добавить фигуру на слайд.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Установить свойства ThreeDFormat фигуры.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Сохранить презентацию в файл PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![3D‑эффект фаски](3D-bevel-effect.png)

## **Добавление 3D‑эффектов вращения**

Aspose.Slides позволяет применять к фигурам 3D‑эффекты вращения, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Используйте методы [set_CameraType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icamera/set_cameratype/) и [set_LightType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilightrig/set_lighttype/) для определения 3D‑вращения.
1. Сохраните презентацию.

Следующий код C++ демонстрирует, как применить 3D‑влияния вращения к фигуре:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создать экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Сохранить презентацию в файл PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![3D‑влияние вращения](3D-rotation-effect.png)

## **Управление чёрно‑белым отображением фигур**

Метод [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_blackwhitemode/) задаёт, как отдельная фигура будет отображаться при просмотре или обработке презентации в чёрно‑белом режиме. Он не включает чёрно‑белый режим сам по себе и не меняет заливку, контур или другие параметры форматирования фигуры в обычном цветном режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению‑отрисовщику выбрать способ преобразования, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` — только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в чёрно‑белом режиме. `NotDefined` означает, что режим для фигуры не задан.

Следующий код C++ создаёт цветную фигуру и делает её серой в чёрно‑белом режиме отображения:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

В обычном цветном режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе чёрно‑белого отображения он будет отображаться серым, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, одновременно задавая особый вид для печати, предварительного просмотра или иных процессов, учитывающих настройки чёрно‑белого отображения презентации.

## **Сброс форматирования**

Следующий код C++ показывает, как сбросить форматирование слайда и вернуть позицию, размеры и параметры всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/layoutslide/) к их значениям по умолчанию:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Сбросить каждую фигуру на слайде, у которой есть заполнитель в макете.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Большую часть объёма занимают встроенные изображения и мультимедиа, тогда как параметры фигур — цвета, эффекты, градиенты — сохраняются как метаданные и почти не увеличивают размер файла.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — заполнение, контур и настройки эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как идентичные и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблоне презентации или файле шаблона `.POTX`. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.