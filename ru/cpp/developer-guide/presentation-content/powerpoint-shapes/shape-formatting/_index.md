---
title: Форматирование фигур PowerPoint на C++
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/cpp/shape-formatting/
keywords:
- формат фигуры
- формат линии
- эффект наброска
- линия фигуры в стиле наброска
- формат стиля соединения
- градиентная заливка
- заливка узором
- заливка изображением
- заливка текстурой
- сплошная заливка цветом
- прозрачность фигуры
- поворот фигуры
- 3D‑скос
- 3D‑поворот
- сброс форматирования
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на C++ с помощью Aspose.Slides — задавайте стили заполнения, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к их контуру. Кроме того, вы можете форматировать фигуры, задавая параметры, контролирующие заполнение их внутренней части.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ предоставляет интерфейсы и методы, которые позволяют форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги выполнения процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [стиль штриха](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольник `AutoShape`:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Задайте цвет заливки для прямоугольной фигуры.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Примените форматирование к линиям прямоугольника.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Задайте цвет линии прямоугольника.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Сохраните файл PPTX на диск.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов наброска к линиям фигур**

Эффект наброска делает линию фигуры выглядящей как нарисованную от руки. Используйте [IShape::get_LineFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_lineformat/) для доступа к настройкам линии, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilineformat/get_sketchformat/) для доступа к настройкам наброска и [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isketchformat/set_sketchtype/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linesketchtype/).

Следующий код C++ показывает, как применить эффект [LineSketchType::Curved](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linesketchtype/), прочитать явно назначенное значение и снять эффект с помощью [LineSketchType::None](https://reference.aspose.com/slides/ru/cpp/aspose.slides/linesketchtype/):

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

Значение, возвращаемое [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isketchformat/get_sketchtype/), представляет настройку, напрямую присвоенную фигуре. Если форматирование линии может быть унаследовано из темы, мастер‑слайда или макета слайда, используйте [ILineFormat::GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilineformat/geteffective/), доступ к [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) и чтение [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Эффективное значение отражает фактическое применённое форматирование после разрешения наследования:

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

По умолчанию PowerPoint при соединении двух линий под углом (например, в углу фигуры) использует настройку **Round**. Однако если вы рисуете фигуру с острыми углами, вы можете предпочесть вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код C++ демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Miter, Bevel и Round:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

// Задайте ширину линии.
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

// Задайте стиль соединения.
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить непрерывный переход цветов к фигуре. Например, вы можете задать две или более цветов так, чтобы один постепенно переходил в другой.

Как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) значение `Gradient`.
1. Добавьте два предпочтительных цвета с заданными позициями, используя методы `Add` коллекции градиентных остановок, предоставляемой интерфейсом [IGradientFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код C++ демонстрирует, как применить эффект градиентной заливки к эллипсу:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Примените градиентное форматирование к эллипсу.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Задайте направление градиента.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Добавьте две градиентные остановки.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Сохраните файл PPTX на диск.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить двухцветный рисунок (точки, полосы, перекрёстные штрихи или шахматы) к фигуре. Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального оформления презентаций. Даже после выбора предопределённого узора вы всё равно можете указать точные цвета, которые он будет использовать.

Как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) значение `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipatternformat/get_backcolor/) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipatternformat/get_forecolor/) узора.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код C++ демонстрирует, как применить заливку узором к прямоугольнику:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Задайте тип заливки Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Установите стиль узора.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Установите фоновые и передние цвета узора.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Сохраните файл PPTX на диск.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Прямоугольник с заливкой узором](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, фактически используя его как фон фигуры.

Как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) значение `Picture`.
1. Установите режим заливки изображением в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) из требуемого изображения.
1. Передайте изображение в метод `ISlidesPicture.set_Image`.
1. Сохраните изменённую презентацию в файл PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий код C++ демонстрирует, как заполнить фигуру изображением:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Задайте тип заливки Picture.
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

Результат:

![Фигура с заливкой изображением](picture-fill.png)

### **Tile Picture As Texture**

Если необходимо задать изображение в режиме мозаики в качестве текстуры и настроить поведение мозаики, можно использовать следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Устанавливает режим заливки изображением — `Tile` или `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Задает выравнивание мозаичных фрагментов внутри фигуры.
- [set_TileFlip](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Управляет тем, будет ли мозаика отражена по горизонтали, вертикали или обеим осям.
- [set_TileOffsetX](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Устанавливает горизонтальное смещение мозаики (в пунктах) от начала фигуры.
- [set_TileOffsetY](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Устанавливает вертикальное смещение мозаики (в пунктах) от начала фигуры.
- [set_TileScaleX](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Определяет горизонтальный масштаб мозаики в процентах.
- [set_TileScaleY](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Определяет вертикальный масштаб мозаики в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с заливкой изображением в виде мозаики и настроить параметры мозаики:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

Результат:

![Параметры мозаики](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, который заполняет фигуру одним ровным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) значение `Solid`.
1. Задайте желаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код C++ демонстрирует, как применить сплошную заливку цветом к прямоугольнику в слайде PowerPoint:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Установите тип заливки Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Задайте цвет заливки.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Сохраните файл PPTX на диск.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Фигура со сплошной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошную заливку, градиент, изображение или текстуру к фигурам, вы также можете задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более «прозрачной» выглядит фигура, позволяя частично увидеть фон или объекты под ней.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) в `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Следующий код C++ демонстрирует, как применить прозрачный цвет заливки к прямоугольнику:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте сплошную прямоугольную автофигуру.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Добавьте прозрачную прямоугольную автофигуру поверх сплошной фигуры.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Сохраните файл PPTX на диск.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

Следующий код C++ демонстрирует, как повернуть фигуру на 5 градусов:

```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

Результат:

![Поворот фигуры](shape-rotation.png)

## **Добавление 3D‑эффекта скоса**

Aspose.Slides позволяет применять 3D‑скос к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/threedformat/).

Чтобы добавить 3D‑скос к фигуре, выполните следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/threedformat/) фигуры для определения параметров скоса.
1. Сохраните презентацию.

Следующий код C++ показывает, как применить 3D‑скос к фигуре:

```cpp
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

Результат:

![Эффект 3D‑скоса](3D-bevel-effect.png)

## **Добавление 3D‑поворота**

Aspose.Slides позволяет применять 3D‑поворот к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/threedformat/).

Чтобы применить 3D‑поворот к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
1. Используйте [set_CameraType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icamera/set_cameratype/) и [set_LightType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilightrig/set_lighttype/) для определения 3D‑поворота.
1. Сохраните презентацию.

Следующий код C++ демонстрирует, как применить 3D‑поворот к фигуре:

```cpp
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

Результат:

![Эффект 3D‑поворота](3D-rotation-effect.png)

## **Сброс форматирования**

Следующий код C++ показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/layoutslide/) к их значениям по умолчанию:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Сбросить каждую фигуру на слайде, имеющую заполнитель в макете.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Влияет ли форматирование фигур на размер конечного файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть места, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер файла.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, рассматривайте их стили как идентичные и логически группируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблоне слайдов или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и примените их форматирование там, где требуется.