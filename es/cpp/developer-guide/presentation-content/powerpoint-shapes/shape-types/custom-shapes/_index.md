---
title: Forma Personalizada
type: docs
weight: 20
url: /cpp/custom-shape/
keywords: "forma de PowerPoint, forma personalizada, presentación de PowerPoint, C++, Aspose.Slides para C++"
description: "Añadir forma personalizada en presentación de PowerPoint en C++"
---

# Cambiar una Forma Usando Puntos de Edición
Considera un cuadrado. En PowerPoint, usando **puntos de edición**, puedes 

* mover la esquina del cuadrado hacia dentro o hacia afuera
* especificar la curvatura para una esquina o punto
* añadir nuevos puntos al cuadrado
* manipular puntos en el cuadrado, etc.

Esencialmente, puedes realizar las tareas descritas en cualquier forma. Usando puntos de edición, puedes cambiar una forma o crear una nueva forma a partir de una forma existente.

## **Consejos para la Edición de Formas**

![overview_image](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint a través de puntos de edición, puedes considerar estos puntos sobre las formas:

* Una forma (o su ruta) puede ser cerrada o abierta.
* Cuando una forma está cerrada, carece de un punto de inicio o final. Cuando una forma está abierta, tiene un inicio y un final. 
* Todas las formas constan de al menos 2 puntos de ancla conectados entre sí por líneas.
* Una línea es recta o curva. Los puntos de ancla determinan la naturaleza de la línea. 
* Los puntos de ancla existen como puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde 2 líneas rectas se unen en un ángulo. 
  * Un punto suave es un punto donde 2 mangos existen en línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los mangos están separados del punto de ancla por una distancia igual. 
  * Un punto recto es un punto donde 2 mangos existen en línea recta y los segmentos de esa línea se unen en una curva suave. En este caso, los mangos no tienen que estar separados del punto de ancla por una distancia igual. 
* Al mover o editar puntos de ancla (lo que cambia el ángulo de las líneas), puedes cambiar la apariencia de una forma.

Para editar formas de PowerPoint a través de puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path).

* Una [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) instancia representa una ruta de geometría del objeto [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape).
* Para recuperar el `GeometryPath` de la instancia `IGeometryShape`, puedes usar el método [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1).
* Para establecer el `GeometryPath` para una forma, puedes usar estos métodos: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) para *formas sólidas* y [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) para *formas compuestas*.
* Para añadir segmentos, puedes usar los métodos bajo [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path).
* Usando los métodos [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) y [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), puedes establecer la apariencia de una ruta de geometría.
* Usando el método [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), puedes recuperar la ruta de geometría de un `GeometryShape` como un array de segmentos de ruta. 
* Para acceder a opciones adicionales de personalización de geometría de formas, puedes convertir [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) a [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path).
* Utiliza [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) y [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (de la clase [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)) para convertir [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) a [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) y viceversa.

## **Operaciones de Edición Simples**

Este código C++ te muestra cómo

**Añadir una línea** al final de una ruta

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Añadir una línea** a una posición especificada en una ruta:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Añadir una curva Bezier cúbica** al final de una ruta:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Añadir una curva Bezier cúbica** a la posición especificada en una ruta:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Añadir una curva Bezier cuadrática** al final de una ruta:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Añadir una curva Bezier cuadrática** a una posición especificada en una ruta:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Añadir un arco dado** a una ruta:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Cerrar la figura actual** de una ruta:

``` cpp
void CloseFigure();
```
**Establecer la posición para el siguiente punto**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Eliminar el segmento de ruta** en un índice dado:

``` cpp
void RemoveAt(int32_t index);
```
## **Añadir Puntos Personalizados a una Forma**
1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) y establece el tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) de la forma.
3. Añade un nuevo punto entre los dos puntos superiores en la ruta.
4. Añade un nuevo punto entre los dos puntos inferiores en la ruta.
5. Aplica la ruta a la forma.

Este código C++ te muestra cómo añadir puntos personalizados a una forma:

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

##  Eliminar Puntos de una Forma

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) y establece el tipo [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5). 
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) de la forma.
3. Elimina el segmento de la ruta.
4. Aplica la ruta a la forma.

Este código C++ te muestra cómo eliminar puntos de una forma:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

##  **Crear Forma Personalizada**

1. Calcula los puntos para la forma.
2. Crea una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path). 
3. Llena la ruta con los puntos.
4. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape). 
5. Aplica la ruta a la forma.

Este código C++ te muestra cómo crear una forma personalizada:

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


## **Crear Forma Personalizada Compuesta**

  1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
  2. Crea una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
  3. Crea una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
  4. Aplica las rutas a la forma.

Este código C++ te muestra cómo crear una forma personalizada compuesta:

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

## **Crear Forma Personalizada con Esquinas Curvadas**

Este código C++ te muestra cómo crear una forma personalizada con esquinas curvadas (hacia adentro);

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

## **Convertir GeometryPath a GraphicsPath** 

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
2. Crea una instancia de la clase [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) del namespace [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).
3. Convierte la instancia [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) a la instancia [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) usando [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).
4. Aplica las rutas a la forma.

Este código C++—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Texto en forma", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)