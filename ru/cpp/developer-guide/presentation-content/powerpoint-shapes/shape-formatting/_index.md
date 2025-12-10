---
title: Форматирование фигур PowerPoint на C++
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/cpp/shape-formatting/
keywords:
- форматировать фигуру
- форматировать линию
- форматировать стиль соединения
- градиентная заливка
- заливка паттерном
- заливка изображением
- заливка текстурой
- сплошная заливка цветом
- прозрачность фигуры
- поворот фигуры
- 3d эффект фаски
- 3d эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на C++ с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---

## **Обзор**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к их контурам. Кроме того, вы можете форматировать фигуры, указывая параметры, контролирующие заливку их внутренней части.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ предоставляет интерфейсы и методы, позволяющие форматировать фигуры с теми же параметрами, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) фигуры.
1. Установите толщину линии.
1. Установите [стиль штриха](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

В следующем примере показано, как форматировать прямоугольный `AutoShape`:
```cpp
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

// Установите цвет линии прямоугольника.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Сохраните файл PPTX на диск.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```



Результат:

![The formatted lines in the presentation](formatted-lines.png)

## **Форматирование стилей соединения**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию PowerPoint использует настройку **Round**, когда соединяет две линии под углом (например, в углу фигуры). Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

В следующем примере кода на C++ показано, как были созданы три прямоугольника (как на изображении выше) с использованием настроек соединения Miter, Bevel и Round:
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

// Установите толщину линии.
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применять плавный переход цветов к фигуре. Например, можно задать два и более цветов, где один постепенно переходит в другой.

Как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) фигуры в значение `Gradient`.
1. Добавьте два желаемых цвета с определёнными позициями, используя методы `Add` из коллекции остановок градиента, доступной через интерфейс [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) .
1. Сохраните изменённую презентацию как файл PPTX.

В следующем примере кода на C++ показано, как применить градиентный эффект к эллипсу:
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

// Установите направление градиента.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Добавьте две градиентные остановки.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Сохраните файл PPTX на диск.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Результат:

![The ellipse with gradient fill](gradient-fill.png)

## **Заливка паттерном**

В PowerPoint заливка паттерном — это параметр, позволяющий применить двухцветный дизайн (точки, полосы, перекрёстные штрихи или шахматы) к фигуре. Вы можете задать собственные цвета переднего и заднего плана паттерна.

Aspose.Slides предоставляет более 45 предопределённых стилей паттернов, которые можно применить к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого паттерна вы можете указать точные цвета, которые он будет использовать.

Как применить заливку паттерном к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) фигуры в значение `Pattern`.
1. Выберите стиль паттерна из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) паттерна.
1. Установите [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) паттерна.
1. Сохраните изменённую презентацию как файл PPTX.

В следующем примере кода на C++ показано, как применить заливку паттерном к прямоугольнику:
```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Установите тип заливки в Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Установите стиль паттерна.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Установите фон и передний цвет паттерна.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Сохраните файл PPTX на диск.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Результат:

![The rectangle with pattern fill](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр, позволяющий вставить изображение внутрь фигуры, сделав его фоном фигуры.

Как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) фигуры в значение `Picture`.
1. Установите режим заливки изображения в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Передайте изображение методу `ISlidesPicture.set_Image`.
1. Сохраните изменённую презентацию как файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующим изображением:

![The lotus picture](lotus.png)

В следующем примере кода на C++ показано, как заполнить фигуру изображением:
```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру типа Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Установите тип заливки в Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Установите режим заливки изображением.
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

![The shape with picture fill](picture-fill.png)

### **Мозаика изображения в качестве текстуры**

Если нужно задать мозаичное изображение в качестве текстуры и настроить её параметры, используйте следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) — задаёт режим заливки изображения: `Tile` или `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/) — определяет выравнивание плиток внутри фигуры.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/) — управляет зеркалированием плитки по горизонтали, вертикали или обоим направлениям.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/) — задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/) — задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/) — определяет горизонтальный масштаб плитки в процентах.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/) — определяет вертикальный масштаб плитки в процентах.

В следующем примере кода показано, как добавить прямоугольник с мозаичной заливкой изображением и настроить параметры плитки:
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

// Присвойте изображение фигуре.
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

![The tile options](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — параметр, который заполняет фигуру одним однородным цветом без градиентов, текстур или паттернов.

Чтобы применить сплошную заливку к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) фигуры в значение `Solid`.
1. Укажите желаемый цвет заливки.
1. Сохраните изменённую презентацию как файл PPTX.

В следующем примере кода на C++ показано, как применить сплошную заливку к прямоугольнику на слайде PowerPoint:
```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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


Результат:

![The shape with solid color fill](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, применяя сплошную, градиентную, картинную или текстурную заливку к фигурам, можно задать уровень прозрачности, контролирующий степень непрозрачности заливки. Чем выше значение прозрачности, тем более «прозрачной» будет фигура, позволяя видеть фон или объекты за ней.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) в `Solid`.
1. Используйте `Color`, задав цвет с необходимой прозрачностью (компонент `alpha` контролирует прозрачность).
1. Сохраните презентацию.

В следующем примере кода на C++ показано, как задать прозрачный цвет заливки для прямоугольника:
```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Получите первый слайд.
auto slide = presentation->get_Slide(0);

// Добавьте автофигуру прямоугольника (сплошную).
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Добавьте автофигуру прямоугольника с прозрачностью поверх сплошной фигуры.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Сохраните файл PPTX на диск.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Результат:

![The transparent shape](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет поворачивать фигуры в презентациях PowerPoint. Это может быть полезно при расположении визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Установите свойство поворота фигуры на требуемый угол.
1. Сохраните презентацию.

В следующем примере кода на C++ показано, как повернуть фигуру на 5 градусов:
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

![The shape rotation](shape-rotation.png)

## **Добавление 3D‑эффектов фаски**

Aspose.Slides позволяет применять к фигурам 3D‑эффекты фаски, настроив их свойства [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) .

Чтобы добавить 3D‑эффекты фаски к фигуре, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) фигуры, задав параметры фаски.
1. Сохраните презентацию.

В следующем примере кода на C++ показано, как применить 3D‑эффекты фаски к фигуре:
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

// Set the shape's ThreeDFormat properties.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **Добавление 3D‑поворотов**

Aspose.Slides позволяет применять к фигурам 3D‑повороты, настроив их свойства [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) .

Чтобы применить 3D‑поворот к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Используйте методы [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) и [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) для определения 3D‑поворота.
1. Сохраните презентацию.

В следующем примере кода на C++ показано, как применить 3D‑повороты к фигуре:
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

![The 3D rotation effect](3D-rotation-effect.png)

## **Сброс форматирования**

В следующем примере кода на C++ показано, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) к их значениям по умолчанию:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Сбросьте каждую фигуру на слайде, имеющую заполнитель в макете.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Практически не влияет. Большую часть объёма занимают встроенные изображения и медиа, тогда как параметры фигур (цвета, эффекты, градиенты) сохраняются как метаданные и почти не увеличивают размер файла.

**Как определить фигуры на слайде с одинаковым форматированием, чтобы их сгруппировать?**

Сравните ключевые параметры форматирования каждой фигуры — параметры заливки, линий и эффектов. Если все соответствующие значения совпадают, считайте их стили идентичными и логически группируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с требуемыми стилями в шаблоне презентации или файле‑шаблоне *.POTX*. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и применяйте их форматирование где необходимо.