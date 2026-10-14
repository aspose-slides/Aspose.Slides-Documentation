---
title: Форматирование фигур PowerPoint на C++
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/cpp/shape-formatting/
keywords:
- формат фигуры
- формат линии
- эффект эскиза
- эскиз линии фигуры
- стиль соединения
- градиентная заливка
- узорная заливка
- заполнение изображением
- текстурная заливка
- сплошная заливка цветом
- прозрачность фигуры
- чёрно-белая отрисовка фигуры
- оттенки серого в отрисовке фигуры
- вращение фигуры
- 3D-эффект фаски
- 3D-эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на C++ с помощью Aspose.Slides — задавайте стили заполнения, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Introduction**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контурам. Кроме того, вы можете форматировать фигуры, задавая параметры, контролирующие заполнение их внутренностей.

![форматирование-формы-в-PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ предоставляет интерфейсы и методы, позволяющие форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете указать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Установите [стиль линии](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) фигуры.
5. Установите ширину линии.
6. Установите [стиль штрихов](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) линии.
7. Установите цвет линии для фигуры.
8. Сохраните изменённую презентацию в файл PPTX.

Следующий код демонстрирует, как форматировать прямоугольный `AutoShape`:

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

// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Установите цвет заливки для прямоугольной фигуры.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Примените форматирование к линиям прямоугольника.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Задайте цвет линии прямоугольника.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the PPTX file to disk.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов эскиза к линиям фигур**

Эффект эскиза делает линию фигуры выглядящей как нарисованную от руки. Используйте [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) для доступа к настройкам линии, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) для доступа к настройкам эскиза и [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

Следующий код C++ показывает, как применить эффект [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) , прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

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

Значение, возвращаемое [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться от темы, шаблона или макета, используйте [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), обратитесь к [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) и прочитайте [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Эффективное значение отражает фактическое форматирование после разрешения наследования:

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

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Округление
* Срез
* Фаска

По умолчанию PowerPoint соединяет две линии под углом (например, в углу фигуры), используя настройку **Округление**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Срез**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код C++ демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Срез, Фаска и Округление:

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

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте три автофигуры типа Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Установите цвет заливки для каждой прямоугольной фигуры.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Установите ширину линии.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Установите цвет линии для каждого прямоугольника.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Установите стиль соединения.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Добавьте текст к каждому прямоугольнику.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Сохраните файл PPTX на диск.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применять к фигуре непрерывный переход цветов. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Для применения градиентной заливки к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) фигуры в `Gradient`.
5. Добавьте два желаемых цвета с определёнными позициями, используя методы `Add` коллекции остановок градиента, доступные через интерфейс [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
6. Сохраните изменённую презентацию в файл PPTX.

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

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Примените градиентное форматирование к эллипсу.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Установите направление градиента.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Добавьте две остановки градиента.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Сохраните файл PPTX на диск.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Выбрать стиль рендеринга градиента](/slides/ru/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга без изменения градиентной заливки, хранящейся в презентации.

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр форматирования, позволяющий применить к фигуре двухцветный дизайн (точки, полосы, перекрестные штрихи или клетки). Можно задать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применить к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого узора можно указать точные цвета, которые он должен использовать.

Для применения узорчатой заливки к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) фигуры в `Pattern`.
5. Выберите стиль узора из предопределённых вариантов.
6. Установите [Цвет фона](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) узора.
7. Установите [Цвет переднего плана](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) узора.
8. Сохраните изменённую презентацию в файл PPTX.

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

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Установите тип заливки в Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Установите стиль узора.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Установите цвета фона и переднего плана узора.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Сохраните файл PPTX на диск.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Прямоугольник с узорчатой заливкой](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, по сути используя его как фон фигуры.

Как применить заполнение изображением к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) фигуры в `Picture`.
5. Установите режим заполнения изображения в `Tile` (или другой предпочтительный режим).
6. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) из требуемого изображения.
7. Передайте изображение методу `ISlidesPicture.set_Image`.
8. Сохраните изменённую презентацию в файл PPTX.

![Изображение лотоса](lotus.png)

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

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Установите тип заливки в Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Задайте режим заливки изображением.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Загрузите изображение и добавьте его в ресурсы презентации.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Установите изображение.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Сохраните файл PPTX на диск.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Фигура с заполнением изображением](picture-fill.png)

### **Плитка изображения в качестве текстуры**

Если необходимо установить изображение в виде текстурных плиток и настроить их поведение, используйте следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Задаёт режим заполнения изображением — `Tile` или `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Определяет выравнивание плиток внутри фигуры.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Определяет горизонтальный масштаб плитки в процентах.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Определяет вертикальный масштаб плитки в процентах.

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

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto firstSlide = presentation->get_Slide(0);

// Добавьте автофигуру прямоугольника.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Установите тип заливки фигуры в Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Загрузите изображение и добавьте его в ресурсы презентации.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Назначьте изображение фигуре.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Настройте режим заливки изображением и свойства мозаики.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Сохраните файл PPTX на диск.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Параметры плитки](tile-options.png)

## **Заполнение сплошным цветом**

В PowerPoint заполнение сплошным цветом — это параметр форматирования, который заполняет фигуру одним равномерным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) фигуры в `Solid`.
5. Назначьте желаемый цвет заливки фигуре.
6. Сохраните изменённую презентацию в файл PPTX.

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

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Установите тип заливки в Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Установите цвет заливки.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Сохраните файл PPTX на диск.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Фигура со сплошной заливкой](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении сплошной, градиентной, изображением или текстурой заливки к фигурам можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более «прозрачной» становится фигура, позволяя видеть фон или нижележащие объекты.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) в `Solid`.
5. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
6. Сохраните презентацию.

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

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте сплошную автоматическую фигуру прямоугольника.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Добавьте прозрачную автоматическую фигуру прямоугольника поверх сплошной фигуры.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Сохраните файл PPTX на диск.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при расположении визуальных элементов с определённым выравниванием или дизайном.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Установите свойство вращения фигуры в требуемый угол.
5. Сохраните презентацию.

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

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Поверните фигуру на 5 градусов.
shape->set_Rotation(5);

// Сохраните файл PPTX на диск.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D фаски**

Aspose.Slides позволяет добавить к фигурам 3D‑фаски, настроив их свойства [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Чтобы добавить 3D‑фаски к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) фигуры для определения параметров фаски.
5. Сохраните презентацию.

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

// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Добавьте фигуру на слайд.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Установите свойства ThreeDFormat фигуры.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Сохраните презентацию в файл PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Эффект 3D фаски](3D-bevel-effect.png)

## **Добавление 3D вращения**

Aspose.Slides позволяет применить к фигурам 3D‑вращение, настроив их свойства [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Используйте методы [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) и [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) для определения 3D‑вращения.
5. Сохраните презентацию.

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

// Создайте экземпляр класса Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Сохраните презентацию в файл PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Эффект 3D вращения](3D-rotation-effect.png)

## **Управление чёрно‑белой отрисовкой фигур**

Метод [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) задаёт, как отдельная фигура будет отрисовываться, когда презентация просматривается или обрабатывается в чёрно‑белом режиме. Он не включает чёрно‑белый режим сам по себе и не меняет заливку, линию или другие параметры фигур в обычном цветном режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению‑отображателю выбрать способ конвертации, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` — только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру из чёрно‑белого отображения. `NotDefined` означает, что режим не задан на уровне фигуры.

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

// Сохраните оранжевую заливку в цветном режиме, но отобразите фигуру с серой окраской в черно-белом режиме.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

В обычном цветном режиме прямоугольник сохраняет оранжевую заливку. При работе в чёрно‑белом режиме он будет отображаться серым, поскольку его режим установлен в `Gray`. Это позволяет сохранять полноцветные слайды, одновременно задавая отдельный вид для печати, предпросмотра или других процессов, учитывающих настройки чёрно‑белого отображения презентации.

## **Сброс форматирования**

Следующий код C++ демонстрирует, как сбросить форматирование слайда и вернуть положение, размер и параметры всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) к их значениям по умолчанию:

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

**Влияет ли форматирование фигур на окончательный размер файла презентации?**

Практически не влияет. Основную часть объёма занимают встроенные изображения и медиа, тогда как параметры фигур — цвета, эффекты, градиенты — хранятся как метаданные и почти не увеличивают размер файла.

**Как определить фигуры на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффектов. Если все соответствующие значения совпадают, их стили считаются одинаковыми и их можно логически сгруппировать, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонном наборе слайдов или в файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.