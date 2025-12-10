---
title: Настройка фигур презентаций в C++
linktitle: Пользовательская фигура
type: docs
weight: 20
url: /ru/cpp/custom-shape/
keywords: 
- пользовательская фигура
- добавить фигуру
- создать фигуру
- изменить фигуру
- геометрия фигуры
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
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint с помощью Aspose.Slides для C++: геометрические пути, скруглённые углы, составные фигуры."
---

## **Изменение формы с помощью точек редактирования**
Рассмотрим квадрат. В PowerPoint, используя **теги редактирования**, вы можете

* перемещать угол квадрата внутрь или наружу
* задавать кривизну для угла или точки
* добавлять новые точки к квадрату
* манипулировать точками квадрата и т.д.

По сути, эти задачи можно выполнять с любой фигурой. С помощью точек редактирования вы можете изменить форму или создать новую форму из существующей.

## **Советы по редактированию фигур**

![overview_image](custom_shape_0.png)

Прежде чем начать редактировать фигуры PowerPoint с помощью точек редактирования, обратите внимание на следующее о фигурах:

* Фигура (или её путь) может быть как замкнутой, так и открытой.
* Когда фигура замкнута, у неё нет начальной или конечной точки. Когда фигура открыта, у неё есть начало и конец. 
* Все фигуры состоят минимум из 2‑х опорных точек, связанных между собой линиями.
* Линия может быть прямой или кривой. Опорные точки определяют тип линии. 
* Опорные точки бывают уголковыми, прямыми или сглаженными:
  * Уголковая точка — это точка, где соединяются 2 прямые линии под углом. 
  * Сглаженная точка — это точка, где 2‑х «ручки» находятся на одной прямой и сегменты линии соединяются плавной кривой. В этом случае обе «ручки» находятся на одинаковом расстоянии от опорной точки. 
  * Прямая точка — это точка, где 2‑х «ручки» находятся на одной прямой и сегменты линии соединяются плавной кривой. В этом случае расстояние «ручек» от опорной точки может различаться. 
* Перемещая или изменяя опорные точки (что меняет угол линий), вы меняете внешний вид фигуры. 

Для редактирования фигур PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) представляет геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape). 
* Чтобы получить `GeometryPath` из экземпляра `IGeometryShape`, используйте метод [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* Чтобы установить `GeometryPath` для фигуры, используйте методы: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) для *сплошных фигур* и [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) для *составных фигур*.
* Чтобы добавить сегменты, используйте методы из [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 
* С помощью методов [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) и [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) можно задать внешний вид геометрического пути.
* С помощью метода [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) можно получить геометрический путь `GeometryShape` в виде массива сегментов пути. 
* Для доступа к дополнительным параметрам настройки геометрии фигуры можно преобразовать [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) в [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path).
* Используйте методы [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) и [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (из класса [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)) для взаимного преобразования [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) и [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path).

## **Простые операции редактирования**

Этот C++‑код демонстрирует, как

**Добавить линию** в конец пути
``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**Добавить линию** в указанную позицию пути:
``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```

**Добавить кубическую кривую Безье** в конец пути:
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Добавить кубическую кривую Безье** в указанную позицию пути:
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```

**Добавить квадратичную кривую Безье** в конец пути:
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Добавить квадратичную кривую Безье** в указанную позицию пути:
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```

**Добавить заданную дугу** к пути:
``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Замкнуть текущую фигуру** пути:
``` cpp
void CloseFigure();
```

**Установить позицию для следующей точки**:
``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**Удалить сегмент пути** по указанному индексу:
``` cpp
void RemoveAt(int32_t index);
```


## **Добавление пользовательских точек к фигуре**
1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) и задайте тип [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) из фигуры.  
3. Добавьте новую точку между двумя верхними точками пути.  
4. Добавьте новую точку между двумя нижними точками пути.  
5. Примените путь к фигуре.

Этот C++‑код показывает, как добавить пользовательские точки к фигуре:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```


![example1_image](custom_shape_1.png)

## **Удаление точек из фигуры**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) и задайте тип [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) из фигуры.  
3. Удалите сегмент пути.  
4. Примените путь к фигуре.

Этот C++‑код показывает, как удалить точки из фигуры:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```

![example2_image](custom_shape_2.png)

## **Создание пользовательской фигуры**

1. Вычислите точки фигуры.  
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
3. Заполните путь точками.  
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
5. Примените путь к фигуре.

Этот C++‑код показывает, как создать пользовательскую фигуру:
``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```

![example3_image](custom_shape_3.png)

## **Создание составной пользовательской фигуры**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
4. Примените пути к фигуре.

Этот C++‑код демонстрирует создание составной пользовательской фигуры:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```

![example4_image](custom_shape_4.png)

## **Создание пользовательской фигуры со скруглёнными углами**

Этот C++‑код показывает, как создать пользовательскую фигуру со скруглёнными (внутренними) углами:
```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Определение, является ли геометрия фигуры замкнутой**

Замкнутая фигура определяется как такая, у которой все стороны соединены, образуя единую границу без разрывов. Такая фигура может быть простой геометрической формой или сложным пользовательским контуром. Ниже приведён пример кода, показывающий, как проверить, является ли геометрия фигуры замкнутой:
```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```


## **Преобразование GeometryPath в GraphicsPath**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
2. Создайте экземпляр класса [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) из пространства имён [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).  
3. Преобразуйте экземпляр [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) в экземпляр [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) с помощью [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).  
4. Примените пути к фигуре.

Этот C++‑код, реализующий описанные шаги, демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и контуром после замены геометрии?**

Стиль остаётся привязанным к фигуре; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую фигуру вместе с её геометрией?**

Используйте свойство [rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) фигуры; геометрия поворачивается вместе с фигурой, поскольку она привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую фигуру в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте нужную [slide](/slides/ru/cpp/convert-powerpoint-to-png/) или саму [shape](/slides/ru/cpp/create-shape-thumbnails/) в растровый формат; это упростит дальнейшую работу с тяжёлыми геометриями.