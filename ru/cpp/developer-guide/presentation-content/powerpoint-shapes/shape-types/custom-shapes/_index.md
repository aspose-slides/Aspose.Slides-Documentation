---
title: Пользовательская Фигура
type: docs
weight: 20
url: /ru/cpp/custom-shape/
keywords: "Фигура PowerPoint, пользовательская фигура, презентация PowerPoint, C++, Aspose.Slides для C++"
description: "Добавьте пользовательскую фигуру в презентацию PowerPoint на C++"
---

# Изменение Фигуры С Использованием Точек Редактирования
Рассмотрим квадрат. В PowerPoint с помощью **точек редактирования** вы можете 

* перемещать угол квадрата внутрь или наружу
* задавать кривизну для угла или точки
* добавлять новые точки к квадрату
* манипулировать точками на квадрате и т.д. 

По сути, вы можете выполнять описанные задачи с любой фигурой. Используя точки редактирования, вы можете изменять фигуру или создавать новую фигуру на основе существующей.

## **Советы по Редактированию Форм**

![overview_image](custom_shape_0.png)

Прежде чем начать редактировать фигуры PowerPoint с помощью точек редактирования, вам стоит учесть следующие моменты о фигурах:

* Фигура (или ее контур) может быть либо замкнутой, либо открытой.
* Когда фигура замкнута, у нее нет начальной или конечной точки. Когда фигура открыта, у нее есть начало и конец.
* Все фигуры состоят как минимум из 2 якорных точек, связанных между собой линиями.
* Линия может быть прямой или изогнутой. Якорные точки определяют характер линии.
* Якорные точки могут быть угловыми, прямыми или гладкими:
  * Угловая точка — это точка, где соединяются 2 прямые линии под углом.
  * Гладкая точка — это точка, где 2 ручки находятся в прямой линии, и сегменты линии соединяются в гладкой кривой. В этом случае все ручки расположены на равном расстоянии от якорной точки.
  * Прямая точка — это точка, где 2 ручки находятся в прямой линии, и сегменты этой линии соединяются в гладкой кривой. В этом случае ручки не обязательно должны находиться на равном расстоянии от якорной точки.
* Перемещая или редактируя якорные точки (что изменяет угол линий), вы можете изменить внешний вид фигуры.

Чтобы редактировать фигуры PowerPoint с помощью точек редактирования, **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) представляет собой геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape). 
* Чтобы получить `GeometryPath` из экземпляра `IGeometryShape`, вы можете использовать метод [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* Чтобы задать `GeometryPath` для фигуры, вы можете использовать эти методы: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) для *замкнутых фигур* и [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) для *составных фигур*.
* Чтобы добавить сегменты, вы можете использовать методы из [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 
* Используя методы [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) и [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), вы можете задать внешний вид для геометрического пути.
* Используя метод [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), вы можете получить геометрический путь `GeometryShape` в виде массива сегментов пути. 
* Чтобы получить доступ к дополнительным параметрам настройки геометрии фигуры, вы можете преобразовать [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) в [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path)
* Используйте методы [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) и [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (из класса [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)) для преобразования [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) в [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) и обратно. 

## **Простые Операции Редактирования**

Этот код на C++ показывает, как

**Добавить линию** к концу пути

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Добавить линию** в указанную позицию на пути:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Добавить кубическую кривую Безье** в конце пути:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Добавить кубическую кривую Безье** в указанную позицию на пути:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Добавить квадратичную кривую Безье** в конце пути:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Добавить квадратичную кривую Безье** в указанную позицию на пути:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Добавить заданный дугу** к пути:

``` cpp
void ArcTo(float width, float height, float startAngle, float sweepAngle);
```
**Закрыть текущую фигуру** на пути:

``` cpp
void CloseFigure();
```
**Установить позицию для следующей точки**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Удалить сегмент пути** по заданному индексу:

``` cpp
void RemoveAt(int32_t index);
```
## **Добавление Пользовательских Точек к Фигуре**
1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) и задайте тип [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) из фигуры.
3. Добавьте новую точку между двумя верхними точками на пути.
4. Добавьте новую точку между двумя нижними точками на пути.
5. Примените путь к фигуре.

Этот код на C++ показывает, как добавить пользовательские точки к фигуре:

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

##  Удаление Точек Из Фигуры

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) и задайте тип [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5). 
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) из фигуры.
3. Удалите сегмент пути.
4. Примените путь к фигуре.

Этот код на C++ показывает, как удалить точки из фигуры:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

##  **Создание Пользовательской Формы**

1. Рассчитайте точки для фигуры.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path). 
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape). 
5. Примените путь к фигуре.

Этот код на C++ показывает, как создать пользовательскую фигуру:

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


## **Создание Составной Пользовательской Формы**

  1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
  2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
  3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
  4. Примените пути к фигуре.

Этот код на C++ показывает, как создать составную пользовательскую фигуру:

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

## **Создание Пользовательской Формы С Закругленными Углами**

Этот код на C++ показывает, как создать пользовательскую фигуру с закругленными углами (внутрь);

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

## **Преобразование GeometryPath в GraphicsPath** 

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
2. Создайте экземпляр класса [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) из пространства имен [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).
3. Преобразуйте экземпляр [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) в экземпляр [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) с использованием [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).
4. Примените пути к фигуре.

Этот код на C++—реализация вышеописанных шагов—демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Текст в фигуре", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)