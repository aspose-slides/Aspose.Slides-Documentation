---
title: Настройка форм презентаций в C++
linktitle: Пользовательская форма
type: docs
weight: 20
url: /ru/cpp/custom-shape/
keywords:
- пользовательская форма
- добавить форму
- создать форму
- изменить форму
- геометрия формы
- геометрический путь
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- скруглённый угол
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для C++: геометрические пути, скруглённые углы, составные формы."
---
## **Обзор**

Эта статья объясняет, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и геометрических путей. Она показывает, как работать с [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) и [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к форме.

Она также демонстрирует, как создавать пользовательские и составные формы, строить формы со скруглёнными углами и определять, является ли геометрия формы замкнутой.

## **Изменение формы с помощью точек редактирования**

В PowerPoint вы можете использовать **Edit Points** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур формы или использовать существующую форму в качестве основы для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из опорных точек, соединённых отрезками.
* Отрезок может быть прямым или изогнутым. Опорные точки и контрольные рычаги определяют его форму.
* Опорные точки могут быть угловыми, прямыми или сглаженными:
  * В угловой точке соседние отрезки могут соединяться под углом.
  * В сглаженной точке два контрольных рычага выровнены и находятся на одинаковом расстоянии от опорной точки.
  * В прямой точке два контрольных рычага выровнены, но могут находиться на разном расстоянии от опорной точки.
* Перемещение опорных точек или корректировка их рычагов изменяет контур формы.

Для редактирования форм PowerPoint с помощью точек редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) и интерфейс [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) представляет геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) из экземпляра [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), можно использовать метод [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) для формы, можно использовать следующие методы: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) для форм с одним путем и [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) для форм с несколькими путями.
* Чтобы добавить отрезки, можно использовать методы в [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* С помощью методов [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) и [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) можно задать отображение геометрического пути.
* С помощью метода [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) можно получить геометрический путь [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) в виде массива отрезков пути.

## **Простые операции редактирования**

Используйте следующие методы для редактирования геометрического пути. Перегрузки, принимающие индекс, вставляют отрезок в указанную позицию (нумерация с нуля) массива отрезков пути.

| Operation | Method |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Добавить или вставить кубическую кривую Безье с двумя контрольными точками и конечной точкой. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Добавить или вставить квадратичную кривую Безье с одной контрольной точкой и конечной точкой. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Задать начальную точку фигуры. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Удалить отрезок по индексу, начинающемуся с нуля. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Добавление пользовательских точек в форму**

В этом примере вставляются две точки в прямоугольную форму с помощью [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) и применяется отредактированный путь через [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Координаты локальны для формы: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы отрезков 1 и 4 размещают их на верхнем и нижнем краях, притягивая эти края внутрь.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Удаление точек из формы**

В этом примере меняется контур в виде сердца, удаляя отрезок по индексу 2 (нумерация с нуля) с помощью [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Применение изменённого пути через [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) обновляет контур формы.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```

![example2_image](custom_shape_2.png)

## **Создание пользовательской формы**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют вершины и впадины; шаг в 72 градуса равномерно распределяет пять вершин. Путь замыкается с помощью [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) и применяется к прямоугольной форме через [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), заменяя её контур.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```

![example3_image](custom_shape_3.png)

## **Создание составной пользовательской формы**

В этом примере определяются два замкнутых объекта [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей через [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) создаёт одну составную форму с разрывом в её средней трети.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```

![example4_image](custom_shape_4.png)

## **Создание пользовательской формы со скруглёнными углами**

В этом примере комбинируются прямые отрезки с [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) для создания формы со скруглёнными внутрь углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а sweep -90 градусов рисует эллипс четвертью против часовой стрелки. Завершённый путь применяется через [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), и презентация сохраняется в формате PPTX.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Определение, является ли геометрия формы замкнутой**

Следующий вспомогательный метод проверяет, заканчивается ли каждый непустой геометрический путь замыкающим отрезком. Он читает [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) и сравнивает команду последнего отрезка [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) с [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). При отсутствии непустых путей возвращает false. Проверяется только конечная команда каждого пути; отдельные подфигуры внутри пути не анализируются. В примере выводится `True` для прямоугольника.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Извлечение и проверка элементов формы**

Используйте [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) для изучения существующей формы как элементов, содержащих точки пути и типы точек. Преобразуйте каждый возвращенный [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) к [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/), чтобы прочитать массивы, возвращаемые методами [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) и [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Такое представление полезно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

В примере открывается презентация, находится первая геометрическая форма на первом слайде и выводятся её отрезки пути. Используйте презентацию, содержащую форму с прямыми и изогнутыми отрезками, чтобы увидеть оба типа вывода. Поиск внутри групп не производится.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Сохранить тип сегмента, исключая флаги.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Использовать обе контрольные точки и конечную точку.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Массивы соответствуют друг другу по индексу: `points[i]` — точка, а `types[i]` описывает её роль. Тип `0` начинается фигуру, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается от предыдущей конечной точки и использует три последовательных элемента типа `3`: две контрольные точки и новую конечную точку. Цикл обрабатывает эти три элемента вместе и проверяет конечную точку на замкнутость.

Типы точек также содержат флаги. Применяйте маску `0x07`, чтобы определить тип сегмента, и проверяйте `0x80` отдельно, чтобы обнаружить закрытый подпуть. Например, `129` (`0x81`) означает конечную точку линии, закрывающую подпуть, а `131` (`0x83`) — конечную точку Безье, закрывающую его. Сравнение сырого значения только с `1` или `3` упустит такие случаи. Другие флаги, например тире (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), при этом X увеличивается вправо, а Y — вниз. Для не сгруппированной формы извлечённые координаты уже включают позицию, возвращаемую методами [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) и [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/), и отражают её текущие ширину и высоту. Например, незавёрнутый прямоугольник в `(100, 200)` размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её необращённого кадра.

Извлечённые точки не учитывают вращение, установленное через [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) , или горизонтальное и вертикальное отражения. Чтобы восстановить отображаемый контур, примените эти преобразования вокруг центра формы. Для сгруппированных форм также учитывайте отображение координат группы и её преобразования; не следует полагать, что извлечённые точки являются конечными координатами слайда, и не применяйте трансляцию или масштабирование дважды, если они уже учтены в кадре дочернего объекта.

**Проверка против редактирования.** Извлечённые массивы описывают контур; их изменение не обновляет исходную форму. Выбирайте этот подход, когда ваш код анализа или рисования нуждается в массивах точек/типов. Используйте [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) , если нужны команды геометрии в локальной системе координат формы или требуется редактировать её геометрию. Применяйте отредактированные пути через [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) или [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) .

## **Преобразование GeometryPath в GraphicsPath**

Текущий публичный API Aspose.Slides для C++ не предоставляет преобразований между геометрическими путями и графическими путями. Для проверки контура используйте элементы формы, как описано выше. Для редактирования формы используйте геометрические пути и применяйте обновлённые пути к форме.

## **FAQ**

**Что произойдёт с заливкой и контуром после замены геометрии?**

Стиль остаётся привязанным к форме; изменяется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую форму вместе с её геометрией?**

Используйте метод формы [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ; геометрия вращается вместе с формой, поскольку она привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы “зафиксировать” результат?**

Да. Экспортируйте нужную область [слайд](/slides/ru/cpp/convert-powerpoint-to-png/) или саму [форму](/slides/ru/cpp/shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.