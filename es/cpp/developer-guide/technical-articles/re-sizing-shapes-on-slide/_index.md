---
title: Redimensionar formas en diapositivas de presentación
type: docs
weight: 100
url: /es/cpp/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Redimensione fácilmente las formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para C++ — automatice los ajustes del diseño de diapositivas y aumente la productividad."
---
## **Descripción general**

Una de las preguntas más frecuentes de los clientes de Aspose.Slides para C++ es cómo cambiar el tamaño de las formas de modo que, cuando el tamaño de la diapositiva cambie, los datos no se recorten. Este breve artículo técnico muestra cómo hacerlo.

## **Redimensionar formas**

Para evitar que las formas se desalineen cuando cambia el tamaño de la diapositiva, actualice la posición y las dimensiones de cada forma para que se ajusten al nuevo diseño de la diapositiva.

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

// Cargar el archivo de presentación.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Obtener el tamaño original de la diapositiva.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Obtener el nuevo tamaño de la diapositiva.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Redimensionar y reposicionar las formas en cada diapositiva.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Escalar el tamaño de la forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Escalar la posición de la forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Si una diapositiva contiene una tabla, el código anterior no funcionará correctamente. En ese caso, cada celda de la tabla debe redimensionarse.
{{% /alert %}} 

Utilice el siguiente código para redimensionar diapositivas que contengan tablas. Para las tablas, establecer el ancho o la altura es un caso especial: debe ajustar la altura de cada fila y el ancho de cada columna para cambiar el tamaño general de la tabla.

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Obtener el tamaño original de la diapositiva.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Obtener el nuevo tamaño de la diapositiva.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Escalar el tamaño de la forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Escalar la posición de la forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Escalar el tamaño de la forma.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Escalar la posición de la forma.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Escalar el tamaño de la forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Escalar la posición de la forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

### ¿Por qué las formas se distorsionan o recortan después de redimensionar una diapositiva?

Al redimensionar una diapositiva, las formas conservan su posición y tamaño originales a menos que la escala se modifique explícitamente. Esto puede provocar que el contenido se recorte o que las formas queden desalineadas.

### ¿El código proporcionado funciona para todos los tipos de forma?

El ejemplo básico funciona para la mayoría de los tipos de forma (cuadros de texto, imágenes, gráficos, etc.). Sin embargo, para las tablas es necesario manejar filas y columnas por separado, ya que la altura y el ancho de una tabla se determinan por las dimensiones de sus celdas individuales.

### ¿Cómo redimensiono las tablas al redimensionar una diapositiva?

Debe recorrer todas las filas y columnas de la tabla y redimensionar su altura y ancho de forma proporcional, como se muestra en el segundo ejemplo de código.

### ¿Funcionará este redimensionamiento para diapositivas maestras y diapositivas de diseño?

Sí, pero también debe recorrer las [Maestras](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_masters/) y las [Diapositivas de diseño](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_layoutslides/) y aplicar la misma lógica de escalado a sus formas para garantizar la consistencia en toda la presentación.

### ¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionamiento?

Sí. Puede utilizar [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidesize/set_orientation/) para cambiar la orientación. Asegúrese de ajustar la lógica de escalado de manera adecuada para conservar el diseño.

### ¿Existe un límite para el tamaño de diapositiva que puedo establecer?

Aspose.Slides admite tamaños personalizados, pero los tamaños muy grandes pueden afectar el rendimiento o la compatibilidad con algunas versiones de PowerPoint.

### ¿Cómo puedo evitar que las formas con relación de aspecto fija se distorsionen?

Puede comprobar el método `get_AspectRatioLocked` de la forma antes de escalar. Si está bloqueado, ajuste el ancho o la altura de forma proporcional en lugar de escalarlos individualmente.