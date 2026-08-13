---
title: Redimensionar formas en diapositivas de presentación en .NET
type: docs
weight: 130
url: /es/net/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Redimensione fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para .NET—automatice los ajustes del diseño de diapositivas y mejore la productividad."
---
## **Visión general**

Una de las preguntas más frecuentes de los clientes de Aspose.Slides para .NET es cómo redimensionar las formas de modo que, al cambiar el tamaño de la diapositiva, los datos no se recorten. Este breve artículo técnico muestra cómo hacerlo.

## **Redimensionar formas**

Para evitar que las formas se desalineen cuando cambia el tamaño de la diapositiva, actualice la posición y las dimensiones de cada forma para que se ajusten al nuevo diseño de la diapositiva.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Cargar el archivo de presentación.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obtener el tamaño original de la diapositiva.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Obtener el nuevo tamaño de la diapositiva.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Redimensionar y recolocar las formas en cada diapositiva.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Escalar el tamaño de la forma.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Escalar la posición de la forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Si una diapositiva contiene una tabla, el código anterior no funcionará correctamente. En ese caso, cada celda de la tabla debe redimensionarse.
{{% /alert %}}

Utilice el siguiente código para redimensionar diapositivas que contienen tablas. En el caso de las tablas, escale la altura de las filas y el ancho de las columnas de forma individual en lugar de la anchura y altura de la forma—aplicar ambos escalados duplicaría la escala de la tabla y la desplazaría fuera de la diapositiva.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obtener el tamaño original de la diapositiva.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Obtener el nuevo tamaño de la diapositiva.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Escalar el tamaño de la forma.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Escalar la posición de la forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Escalar el tamaño de la forma.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Escalar la posición de la forma.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // Escalar el tamaño de la tabla a través de sus filas y columnas.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // Escalar el tamaño de la forma.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Escalar la posición de la forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### ¿Por qué las formas se distorsionan o se recortan después de redimensionar una diapositiva?

Al redimensionar una diapositiva, las formas conservan su posición y tamaño originales a menos que se modifique explícitamente la escala. Esto puede provocar que el contenido se recorte o que las formas queden desalineadas.

### ¿El código proporcionado funciona para todos los tipos de forma?

El ejemplo básico funciona para la mayoría de los tipos de forma (cuadros de texto, imágenes, gráficos, etc.). Sin embargo, para las tablas es necesario gestionar filas y columnas por separado, ya que la altura y el ancho de una tabla están determinados por las dimensiones de las celdas individuales.

### ¿Cómo redimensiono tablas al redimensionar una diapositiva?

Debe iterar todas las filas y columnas de la tabla y redimensionar su altura y ancho proporcionalmente, como se muestra en el segundo ejemplo de código.

### ¿Funcionará este redimensionado en diapositivas maestras y diapositivas de diseño?

Sí, pero también debe iterar sobre [Masters](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/masters/) y [LayoutSlides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/layoutslides/) y aplicar la misma lógica de escalado a sus formas para garantizar la coherencia en toda la presentación.

### ¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?

Sí. Puede establecer [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/es/net/aspose.slides/islidesize/orientation/) para modificar la orientación. Asegúrese de adaptar la lógica de escalado en consecuencia para preservar el diseño.

### ¿Existe un límite para el tamaño de diapositiva que puedo establecer?

Aspose.Slides admite tamaños personalizados, pero tamaños muy grandes pueden afectar el rendimiento o la compatibilidad con algunas versiones de PowerPoint.

### ¿Cómo evitar que las formas con relación de aspecto fija se distorsionen?

Puede comprobar la propiedad `AspectRatioLocked` de la forma antes de escalar. Si está bloqueada, ajuste la anchura o la altura proporcionalmente en lugar de escalar cada una de forma independiente.