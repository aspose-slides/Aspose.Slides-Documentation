---
title: Personalizar formas de presentación en C++
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/cpp/custom-shape/
keywords:
- forma personalizada
- añadir forma
- crear forma
- cambiar forma
- geometría de forma
- ruta de geometría
- puntos de ruta
- puntos de edición
- añadir punto
- eliminar punto
- operación de edición
- esquina curvada
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Crear y personalizar formas en presentaciones de PowerPoint con Aspose.Slides para C++: rutas de geometría, esquinas curvadas, formas compuestas."
---
## **Descripción general**

Este artículo explica cómo personalizar las formas de presentación en Aspose.Slides editando la geometría de la forma mediante puntos de edición y rutas de geometría. Muestra cómo trabajar con [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) para modificar formas existentes, realizar operaciones básicas de edición de rutas, añadir o eliminar puntos y aplicar la geometría actualizada a una forma.

También demuestra cómo crear formas personalizadas y compuestas, construir formas con esquinas curvadas y determinar si la geometría de una forma está cerrada.

## **Cambiar una forma usando puntos de edición**

En PowerPoint, puedes usar **Edit Points** para modificar un cuadrado:

* Mover una esquina hacia dentro o hacia fuera.
* Ajustar la curvatura en un punto.
* Añadir nuevos puntos.

Editar puntos le permite modificar el contorno de una forma o usar una forma existente como base para una nueva.

## **Consejos para editar formas**

![overview_image](custom_shape_0.png)

Al editar formas de PowerPoint, ten en cuenta estos conceptos:

* Una forma (o su ruta) puede ser cerrada o abierta.
* La ruta de una forma está compuesta por puntos de anclaje conectados por segmentos.
* Un segmento puede ser recto o curvo. Los puntos de anclaje y los tiradores de control determinan su forma.
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:
  * En un punto de esquina, los segmentos contiguos pueden encontrarse en un ángulo.
  * En un punto suave, los dos tiradores de control están alineados y a la misma distancia del punto de anclaje.
  * En un punto recto, los dos tiradores de control están alineados pero pueden estar a distintas distancias del punto de anclaje.
* Mover los puntos de anclaje o ajustar sus tiradores cambia el contorno de la forma.

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) y la interfaz [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) representa la ruta de geometría del objeto [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Para obtener el [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) del objeto [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), puedes usar el método [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Para establecer el [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) de una forma, puedes usar estos métodos: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) para formas con una única ruta y [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) para formas con rutas múltiples.
* Para añadir segmentos, puedes usar los métodos de [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Con los métodos [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) y [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), puedes definir la apariencia de una ruta de geometría.
* Con el método [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), puedes obtener la ruta de geometría de un [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) como una matriz de segmentos de ruta.

## **Operaciones de edición simples**

Utiliza los siguientes métodos para editar una ruta de geometría. Las sobrecargas que aceptan un índice insertan un segmento en esa posición basada en cero dentro de la matriz de segmentos de la ruta.

| Operación | Método |
| --- | --- |
| Añadir o insertar una línea recta. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Añadir o insertar una curva Bézier cúbica con dos puntos de control y un punto final. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Añadir o insertar una curva Bézier cuadrática con un punto de control y un punto final. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Añadir un arco elíptico con las dimensiones y ángulos especificados en grados. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Cerrar la figura actual conectando su punto final con su punto de inicio. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Establecer el punto de inicio de una figura. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Eliminar un segmento en un índice basado en cero. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Añadir puntos personalizados a una forma**

Este ejemplo inserta dos puntos en una forma rectangular usando [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) y aplica la ruta editada con [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Las coordenadas son locales a la forma: ambos puntos nuevos están en su centro, a 100 puntos del borde izquierdo y 50 puntos del borde superior. Los índices de segmento 1 y 4 los colocan en los bordes superior e inferior, tirando de esos bordes hacia dentro.

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

## **Eliminar puntos de una forma**

Este ejemplo modifica el contorno de una forma en forma de corazón eliminando el segmento en el índice basado en cero 2 con [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Aplicar la ruta modificada con [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) actualiza el contorno de la forma.

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

## **Crear una forma personalizada**

Este ejemplo construye una estrella de cinco puntas con [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Los radios externos e internos alternados de 100 y 50 puntos definen las puntas y las hendiduras; un paso de 72 grados separa uniformemente las cinco puntas. La ruta se cierra con [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) y se aplica a una forma rectangular mediante [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), sustituyendo su contorno.

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

## **Crear una forma compuesta personalizada**

Este ejemplo define dos [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) cerrados para el tercio superior y el tercio inferior de una forma. Aplicar ambas rutas con [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) crea una única forma compuesta con una abertura en su tercio medio.

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

## **Crear una forma personalizada con esquinas curvadas**

Este ejemplo combina segmentos rectos con [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) para crear una forma con esquinas curvadas hacia dentro. Cada tamaño de esquina define el ancho y la altura del arco en puntos, y el barrido de -90 grados dibuja un cuarto de elipse en sentido antihorario. La ruta completada se aplica con [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), y la presentación se guarda en formato PPTX.

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

## **Descubrir si la geometría de una forma está cerrada**

El siguiente asistente verifica si cada ruta de geometría no vacía termina con un segmento de cierre. Lee [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) y compara el [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) final con [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Devuelve false cuando no existen rutas no vacías. Esta comprobación solo considera el comando final de cada ruta; no inspecciona cada subfigura dentro de una ruta. El ejemplo muestra `True` para un rectángulo.

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

## **Inspeccionar comandos de ruta de geometría**

Descarga [contour.pptx](contour.pptx) y colócalo en el directorio de trabajo de la aplicación. La primera forma de la primera diapositiva tiene un borde superior recto, una curva Bézier cúbica y un borde de cierre recto. Usa [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) para leer sus rutas. Para cada ruta, [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) devuelve los segmentos en orden de dibujo. El comando devuelto por [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) determina cómo interpretar los valores devueltos por [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

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

La forma está situada en (200, 100) puntos en la diapositiva. Los puntos informados son locales a la forma, con (0, 0) en su esquina superior izquierda, x aumentando hacia la derecha e y aumentando hacia abajo. El segmento de cierre vuelve al punto inicial sin coordenadas adicionales.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Extraer e inspeccionar elementos de forma**

Usa [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) para inspeccionar una forma existente como elementos que contienen puntos de ruta y tipos de punto. Convierte cada [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) devuelto a [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) para leer las matrices devueltas por [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) y [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Esta representación es útil para análisis de contorno o para pasar la geometría a herramientas de dibujo personalizadas.

El ejemplo abre una presentación, encuentra la primera forma de geometría directamente en la primera diapositiva e imprime sus segmentos de ruta. Usa una presentación que contenga una forma con segmentos rectos y curvos para ver ambos tipos de salida. No busca dentro de grupos.

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
        auto pointType = types[i] & 0x07; // Mantener el tipo de segmento, excluyendo banderas.
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
                i += 2; // Consumir ambos puntos de control y el punto final.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Las matrices se corresponden por índice: `points[i]` es un punto y `types[i]` describe su función. El tipo `0` inicia una figura, y el tipo `1` dibuja una línea desde el punto anterior al punto actual. Un segmento Bézier cúbico comienza en el punto final anterior y utiliza tres entradas consecutivas de tipo `3`: dos puntos de control seguidos del nuevo punto final. El bucle consume esas tres entradas juntas y verifica el punto final para detectar el cierre.

Los tipos de punto también contienen banderas. Aplica una máscara `0x07` para identificar el tipo de segmento y prueba `0x80` por separado para detectar un sub‑trayecto cerrado. Por ejemplo, `129` (`0x81`) significa un punto final de línea que cierra un sub‑trayecto, y `131` (`0x83`) indica un punto final Bézier que lo cierra. Comparar el valor bruto solo con `1` o `3` perdería estos casos. Otras banderas, como guión (`0x10`) y marcador (`0x20`), no alteran el tipo base del segmento.

**Coordenadas y transformaciones.** Los puntos se miden en points (1/72 de pulgada), con X aumentando a la derecha e Y aumentando hacia abajo. Para una forma sin agrupar, las coordenadas extraídas ya incluyen la posición devuelta por [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) y [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) y reflejan su ancho y alto actuales. Por ejemplo, un rectángulo sin rotar en `(100, 200)` con tamaño `120 × 80` tiene límites de contorno `(100, 200)`–`(220, 280)`. No vuelvas a añadir la posición de la forma. Resta su X e Y para obtener coordenadas relativas a su marco sin rotar.

Los puntos extraídos no aplican la rotación establecida mediante [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ni los reflejos horizontal y vertical. Para reproducir el contorno mostrado, aplica esas transformaciones alrededor del centro de la forma. Para formas agrupadas, también ten en cuenta el mapeo de coordenadas y transformaciones del grupo; no asumas que los puntos extraídos son las coordenadas finales renderizadas en la diapositiva ni apliques una traslación o escala dos veces si ya están reflejadas en el marco del hijo.

**Inspección frente a edición.** Las matrices extraídas describen el contorno; modificarlas no actualiza la forma original. Elige este método cuando tu análisis o código de dibujo necesite matrices de punto/tipo. Usa [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) cuando necesites comandos de geometría en el sistema de coordenadas local de la forma o quieras editar su geometría. Aplica rutas editadas mediante [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) o [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Convertir GeometryPath a GraphicsPath**

La API pública actual de Aspose.Slides para C++ no expone conversiones entre rutas de geometría y rutas gráficas. Para inspeccionar un contorno, usa los elementos de forma como se describió anteriormente. Para editar una forma, usa rutas de geometría y aplica las rutas actualizadas a la forma.

## **FAQ**

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece asociado a la forma; solo el contorno cambia. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utiliza el método [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) de la forma; la geometría gira con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada a una imagen para "bloquear" el resultado?**

Sí. Exporta el área de la [diapositiva](/slides/es/cpp/convert-powerpoint-to-png/) o la propia [forma](/slides/es/cpp/shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.