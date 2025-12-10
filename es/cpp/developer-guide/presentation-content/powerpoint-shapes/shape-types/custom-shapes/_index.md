---
title: Personalizar formas de presentación en C++
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/cpp/custom-shape/
keywords:
- forma personalizada
- agregar forma
- crear forma
- cambiar forma
- geometría de forma
- ruta de geometría
- puntos de ruta
- puntos de edición
- agregar punto
- eliminar punto
- operación de edición
- esquina curva
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Crear y personalizar formas en presentaciones de PowerPoint con Aspose.Slides para C++: rutas de geometría, esquinas curvas, formas compuestas."
---

## **Cambiar una forma usando puntos de edición**
Considere un cuadrado. En PowerPoint, usando **puntos de edición**, puede 

* mover la esquina del cuadrado hacia adentro o hacia afuera
* especificar la curvatura de una esquina o punto
* añadir nuevos puntos al cuadrado
* manipular puntos del cuadrado, etc. 

Essencialmente, puede realizar las tareas descritas en cualquier forma. Usando puntos de edición, puede cambiar una forma o crear una nueva forma a partir de una forma existente. 

## **Consejos para editar formas**

![overview_image](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint mediante puntos de edición, quizá quiera considerar los siguientes aspectos sobre las formas:

* Una forma (o su trayectoria) puede ser cerrada o abierta.
* Cuando una forma es cerrada, no tiene punto de inicio ni de fin. Cuando una forma es abierta, tiene un comienzo y un final. 
* Todas las formas constan de al menos 2 puntos de anclaje vinculados entre sí por líneas.
* Una línea puede ser recta o curva. Los puntos de anclaje determinan la naturaleza de la línea. 
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde 2 líneas rectas se unen en un ángulo. 
  * Un punto suave es un punto donde 2 manejadores están en una línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los manejadores están separados del punto de anclaje a la misma distancia. 
  * Un punto recto es un punto donde 2 manejadores están en una línea recta y los segmentos de esa línea se unen en una curva suave. En este caso, los manejadores no tienen que estar separados del punto de anclaje a la misma distancia. 
* Al mover o editar los puntos de anclaje (lo que cambia el ángulo de las líneas), puede modificar la apariencia de la forma. 

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** ofrece la clase [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) representa una trayectoria geométrica del objeto [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape). 
* Para obtener el`GeometryPath` de la instancia `IGeometryShape`, puede usar el método [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* Para establecer el `GeometryPath` de una forma, puede usar estos métodos: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) para *formas sólidas* y [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) para *formas compuestas*.
* Para añadir segmentos, puede usar los métodos bajo [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 
* Usando los métodos [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) y [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), puede definir la apariencia de una trayectoria geométrica.
* Con el método [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), puede obtener la trayectoria geométrica de un `GeometryShape` como una matriz de segmentos de trayectoria. 
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puede convertir [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) a [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path).
* Use los métodos [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) y [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (de la clase [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)) para convertir [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) a [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) y viceversa. 

## **Operaciones de edición simples**

Este código C++ le muestra cómo

**Agregar una línea** al final de una trayectoria
``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**Agregar una línea** a una posición especificada en una trayectoria:
``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```

**Agregar una curva Bézier cúbica** al final de una trayectoria:
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Agregar una curva Bézier cúbica** a la posición especificada en una trayectoria:
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```

**Agregar una curva Bézier cuadrática** al final de una trayectoria:
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Agregar una curva Bézier cuadrática** a una posición especificada en una trayectoria:
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```

**Añadir un arco dado** a una trayectoria:
``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Cerrar la figura actual** de una trayectoria:
``` cpp
void CloseFigure();
```

**Establecer la posición para el siguiente punto**:
``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**Eliminar el segmento de trayectoria** en un índice dado:
``` cpp
void RemoveAt(int32_t index);
```

## **Añadir puntos personalizados a una forma**
1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) y establezca el tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Obtenga una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) a partir de la forma.  
3. Añada un nuevo punto entre los dos puntos superiores de la trayectoria.  
4. Añada un nuevo punto entre los dos puntos inferiores de la trayectoria.  
5. Aplique la trayectoria a la forma.  

Este código C++ muestra cómo añadir puntos personalizados a una forma:
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

## **Eliminar puntos de una forma**

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) y establezca el tipo [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Obtenga una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) a partir de la forma.  
3. Elimine el segmento de la trayectoria.  
4. Aplique la trayectoria a la forma.  

Este código C++ muestra cómo eliminar puntos de una forma:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```


![example2_image](custom_shape_2.png)

## **Crear una forma personalizada**

1. Calcule los puntos para la forma.  
2. Cree una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
3. Rellene la trayectoria con los puntos.  
4. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
5. Aplique la trayectoria a la forma.  

Este código C++ muestra cómo crear una forma personalizada:
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


## **Crear una forma compuesta personalizada**

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
2. Cree una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
3. Cree una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
4. Aplique las trayectorias a la forma.  

Este código C++ muestra cómo crear una forma compuesta personalizada:
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

## **Crear una forma personalizada con esquinas curvadas**

Este código C++ muestra cómo crear una forma personalizada con esquinas curvadas (hacia adentro);
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


## **Descubrir si la geometría de una forma está cerrada**

Una forma cerrada se define como aquella en la que todos sus lados se conectan, formando un único contorno sin huecos. Esa forma puede ser una figura geométrica simple o un contorno personalizado complejo. El siguiente ejemplo de código muestra cómo comprobar si la geometría de una forma está cerrada:
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


## **Convertir GeometryPath a GraphicsPath** 

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
2. Cree una instancia de la clase [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) del espacio de nombres [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).  
3. Convierta la instancia de [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) a la instancia de [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) usando [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).  
4. Aplique las trayectorias a la forma.  

Este código C++—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:
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

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo el contorno cambia. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Use la propiedad de [rotación](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) de la forma; la geometría rota con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada a una imagen para “bloquear” el resultado?**

Sí. Exporte el área de la [diapositiva](/slides/es/cpp/convert-powerpoint-to-png/) requerida o la propia [forma](/slides/es/cpp/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.