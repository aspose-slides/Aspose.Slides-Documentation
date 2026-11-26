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
- путь геометрии
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
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для C++: пути геометрии, скруглённые углы, составные формы."
---
## **Обзор**

В этой статье объясняется, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и путей геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) и [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) для изменения существующих форм, выполнения основных операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к форме.

Также демонстрируется, как создавать пользовательские и составные формы, строить формы со скруглёнными углами и определять, является ли геометрия формы замкнутой.

## **Изменение формы с помощью точек редактирования**

В PowerPoint можно использовать **Edit Points**, чтобы изменить квадрат:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур формы или использовать существующую форму в качестве основы для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из точек привязки, соединённых сегментами.
* Сегмент может быть прямым или кривым. Точки привязки и управляющие ручки определяют его форму.
* Точки привязки бывают угловыми, прямыми или сглаженными:
  * В угловой точке соединяющие сегменты могут встречаться под углом.
  * В сглаженной точке две управляющие ручки выровнены и находятся на одинаковом расстоянии от точки привязки.
  * В прямой точке две управляющие ручки выровнены, но могут находиться на разном расстоянии от точки привязки.
* Перемещение точек привязки или корректировка их ручек меняет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) и интерфейс [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) представляет путь геометрии объекта [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) из экземпляра [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), используйте метод [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Чтобы установить [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) для формы, используйте методы: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) для форм с одним путём и [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) для форм с несколькими путями.
* Для добавления сегментов используйте методы из [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* С помощью методов [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) и [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) можно задать внешний вид пути геометрии.
* С помощью метода [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) в виде массива сегментов пути.

## **Простые операции редактирования**

Используйте перечисленные методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в указанную позицию (нумерация с нуля) в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Добавить или вставить кубическую кривую Безье с двумя контрольными точками и конечной точкой. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Добавить или вставить квадратичную кривую Безье с одной контрольной точкой и конечной точкой. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Задать начальную точку фигуры. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Удалить сегмент по индексу (нумерация с нуля). | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Добавление пользовательских точек к форме**

В этом примере два новых пункта вставляются в прямоугольную форму с помощью [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) и применяются к форме через [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Координаты задаются локально относительно формы: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхней и нижней гранях, притягивая эти грани внутрь.

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

В этом примере контур в виде сердца изменяется удалением сегмента с индексом 2 (нумерация с нуля) с помощью [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Применив изменённый путь через [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), контур формы обновляется.

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

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют кончики и впадины; шаг 72 градуса равномерно распределяет пять кончиков. Путь замыкается методом [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) и применяется к прямоугольной форме через [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), заменяя её контур.

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

В этом примере определены два закрытых объекта [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) для верхней и нижней трети формы. Применив оба пути через [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/), создаётся единая составная форма с разрывом посередине её третьей части.

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

В этом примере прямые сегменты комбинируются с [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) для создания формы с внутрь‑изогнутыми углами. Каждый параметр угла задаёт ширину и высоту дуги в пунктах, а разворот –90° рисует против часовой стрелки четверть эллипса. Завершённый путь применяется через [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), после чего презентация сохраняется в формате PPTX.

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

## **Проверка, является ли геометрия формы замкнутой**

Следующая вспомогательная функция проверяет, заканчивается ли каждый непустой путь геометрии закрывающим сегментом. Она читает [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) и сравнивает команду последнего сегмента [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) с [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Возвращает false, если нет непустых путей. Функция проверяет только последнюю команду каждого пути, не анализируя каждую подфигуру внутри пути. Пример выводит `True` для прямоугольника.

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

## **Анализ команд пути геометрии**

Скачайте файл [contour.pptx](contour.pptx) и разместите его в рабочем каталоге приложения. Первая форма на первом слайде имеет прямой верхний край, кубическую кривую Безье и прямой закрывающий край. Используйте [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) для чтения её путей. Для каждого пути метод [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) возвращает сегменты в порядке рисования. Команда, возвращённая методом [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/), определяет, как интерпретировать значения, полученные от [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

Форма располагается в точке (200, 100) пунктов на слайде. Сообщаемые координаты локальны для формы, с (0, 0) в её верхнем левом углу, ось X направлена вправо, ось Y — вниз. Замыкающий сегмент возвращается к начальной точке без дополнительных координат.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Извлечение и анализ элементов формы**

Используйте [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) для получения представления существующей формы в виде элементов, содержащих точки пути и типы точек. Приведите каждый полученный [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) к типу [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) и прочитайте массивы, возвращаемые методами [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) и [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Такое представление удобно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

В примере открывается презентация, находится первая геометрическая форма непосредственно на первом слайде и выводятся её сегменты пути. Используйте презентацию, содержащую форму с прямыми и кривыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не выполняется.

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

Массивы коррелируют по индексу: `points[i]` — точка, а `types[i]` — её роль. Тип `0` начинает фигуру, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается от предыдущей конечной точки и использует три последовательных элемента типа `3`: две контрольные точки и новую конечную точку. Цикл обрабатывает эти три записи вместе и проверяет конечную точку на замыкание.

Типы точек также могут содержать флаги. Маска `0x07` позволяет определить тип сегмента, а проверка `0x80` отдельно выявляет закрытый под‑путь. Например, значение `129` (`0x81`) означает конечную точку линии, закрывающую под‑путь, а `131` (`0x83`) — конечную точку Безье, закрывающую под‑путь. Сравнение только с `1` или `3` упустит такие случаи. Другие флаги, такие как пунктир (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Координаты измеряются в пунктах (1/72 дюйма), при этом X растёт вправо, а Y — вниз. Для незагруппированной формы извлечённые координаты уже включают позицию, возвращаемую методами [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) и [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/), и отражают её текущую ширину и высоту. Например, несrotированный прямоугольник с левым верхним углом `(100, 200)` и размерами `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её несrotированного фрейма.

Извлечённые точки не учитывают вращение, установленное через [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/), а также горизонтальные и вертикальные отражения. Чтобы воспроизвести отображаемый контур, примените эти преобразования относительно центра формы. Для сгруппированных форм также учитывайте преобразования и сопоставление координат группы; не предполагайте, что извлечённые точки уже являются окончательными координатами слайда, и не применяйте трансляцию или масштаб дважды, если они уже отражены в фрейме дочернего элемента.

**Инспекция vs. редактирование.** Извлечённые массивы описывают контур; их изменение не обновляет оригинальную форму. Используйте такой подход, когда ваш анализ или код рисования требуют массивов точек/типов. Применяйте [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/), когда необходимы команды геометрии в локальной системе координат формы или когда требуется редактировать её геометрию. Обновлённые пути применяются через [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) или [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Преобразование GeometryPath в GraphicsPath**

Текущий публичный API Aspose.Slides для C++ не предоставляет конвертаций между путями геометрии и графическими путями. Для инспекции контура используйте элементы формы, как описано выше. Для редактирования формы используйте пути геометрии и применяйте обновлённые пути к форме.

## **FAQ**

**Что произойдёт с заливкой и контуром после замены геометрии?**

Стиль остаётся привязанным к форме; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую форму вместе с её геометрией?**

Вызовите метод формы [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/); геометрия вращается вместе с формой, так как привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте требуемую [slide](/slides/ru/cpp/convert-powerpoint-to-png/) или саму [shape](/slides/ru/cpp/shape-thumbnails/) в растровый формат; это упростит дальнейшую работу со сложной геометрией.