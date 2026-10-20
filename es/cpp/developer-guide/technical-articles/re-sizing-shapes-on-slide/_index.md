---
title: Redimensionar formas en diapositivas de presentación en C++
type: docs
weight: 130
url: /es/cpp/resizing-shapes-on-slide/
aliases:
  - /es/cpp/re-sizing-shapes-on-slide/
  /cpp/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Redimensiona fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para C++ — automatiza ajustes de diseño de diapositivas y aumenta la productividad."
---
## **Visión general**

Cuando cambias el tamaño de la diapositiva de una presentación, también puede ser necesario redimensionar y reposicionar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar formas manualmente y cómo manejar tablas en diapositivas, maestros y diseños.

## **Redimensionar formas**

Para conservar la posición y el tamaño relativos de cada forma, multiplica sus coordenadas horizontales y su ancho por la relación entre el nuevo ancho de la diapositiva y el ancho original. Aplica la relación de altura correspondiente a sus coordenadas verticales y su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) con [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) de modo que el bucle posterior controle el escalado. Las relaciones son adimensionales; las posiciones y dimensiones de las formas se miden en puntos. Relaciones diferentes de ancho y alto pueden deformar las formas, y cambiar las dimensiones de una forma no escala sus tamaños de fuente.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Las tablas requieren un manejo separado: escalar sus anchos de columna y alturas de fila en lugar de asignar el ancho y alto globales de la tabla. Las alturas de fila pueden permanecer mayores que lo solicitado si el contenido de la celda necesita más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa formas en maestros y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente maneja cada [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) escalando [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) y [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). Luego escala la posición de la tabla sin escalar por separado sus dimensiones globales.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calcular factores de escala horizontales y verticales independientes.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // Las dimensiones de la tabla se controlan mediante los anchos de columna y las alturas de fila.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// Redimensionar formas definidas en maestros y diseños, así como en diapositivas individuales.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Por qué las formas se deforman o se recortan después de redimensionar una diapositiva?**

Si cambias el tamaño de la diapositiva sin escalar las formas, mantienen sus posiciones y dimensiones originales y pueden extenderse más allá de la diapositiva. Escalar el ancho y la altura con relaciones diferentes también puede deformar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo cambia los límites de la forma directamente y está pensado para diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Verifica el diseño resultante, particularmente el texto y las tablas, porque estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede restringir las alturas de fila.

**¿Cómo redimensiono tablas al redimensionar una diapositiva?**

Escala los anchos de columna con la relación de ancho y las alturas mínimas de fila con la relación de altura, luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Este redimensionado funciona para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo itera a través de [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) y de cada maestro su [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Establece [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de la diapositiva que puedo establecer?**

Puedes especificar dimensiones de diapositiva personalizadas con [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo evitar que las formas con una relación de aspecto fija se deformen?**

Utiliza el mismo factor de escala para ancho y altura. Para ajustar el diseño original dentro de las nuevas dimensiones de la diapositiva, usa la menor de las relaciones de ancho y altura para ambas dimensiones y posiciones. Esto conserva las proporciones pero puede dejar espacio sin usar a lo largo de un borde.