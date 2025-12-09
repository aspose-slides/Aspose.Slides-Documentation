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
description: "Redimensione fácilmente formas en diapositivas PowerPoint y OpenDocument con Aspose.Slides para .NET—automatice los ajustes de diseño de diapositivas y aumente la productividad."
---

## **Visión general**

Una de las preguntas más comunes de los clientes de Aspose.Slides para .NET es cómo cambiar el tamaño de las formas de modo que, cuando el tamaño de la diapositiva cambie, los datos no se recorten. Este breve artículo técnico muestra cómo hacerlo.

## **Redimensionar formas**

Para evitar que las formas se desalineen cuando cambia el tamaño de la diapositiva, actualice la posición y las dimensiones de cada forma para que se ajusten al nuevo diseño de la diapositiva.
```c#
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

    // Redimensionar y reposicionar las formas en cada diapositiva.
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


{{% alert color="primary" %}}
Si una diapositiva contiene una tabla, el código anterior no funcionará correctamente. En ese caso, cada celda de la tabla debe redimensionarse.
{{% /alert %}}

Utilice el siguiente código en su lado para redimensionar diapositivas que contienen tablas. Para las tablas, establecer el ancho o la altura es un caso especial: debe ajustar las alturas de filas individuales y los anchos de columnas para cambiar el tamaño general de la tabla.
```c#
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
            // Escalar el tamaño de la forma.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Escalar la posición de la forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Por qué las formas se distorsionan o se recortan después de cambiar el tamaño de una diapositiva?**

Al cambiar el tamaño de una diapositiva, las formas conservan su posición y tamaño originales a menos que la escala se modifique explícitamente. Esto puede provocar que el contenido se recorte o que las formas se desalineen.

**¿El código proporcionado funciona con todos los tipos de forma?**

El ejemplo básico funciona con la mayoría de los tipos de forma (cuadros de texto, imágenes, gráficos, etc.). Sin embargo, para las tablas, debe manejar filas y columnas por separado, ya que la altura y el ancho de una tabla se determinan por las dimensiones de las celdas individuales.

**¿Cómo redimensiono las tablas al cambiar el tamaño de una diapositiva?**

Debe recorrer todas las filas y columnas de la tabla y redimensionar su altura y ancho proporcionalmente, como se muestra en el segundo ejemplo de código.

**¿Funcionará este redimensionamiento para diapositivas maestras y diapositivas de diseño?**

Sí, pero también debe recorrer [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) y [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) y aplicar la misma lógica de escalado a sus formas para garantizar la consistencia en toda la presentación.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionamiento?**

Sí. Puede establecer [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) para cambiar la orientación. Asegúrese de ajustar la lógica de escalado en consecuencia para preservar el diseño.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Aspose.Slides admite tamaños personalizados, pero los tamaños muy grandes pueden afectar el rendimiento o la compatibilidad con algunas versiones de PowerPoint.

**¿Cómo puedo evitar que las formas con relación de aspecto fija se distorsionen?**

Puede comprobar la propiedad `AspectRatioLocked` de la forma antes de escalar. Si está bloqueada, ajuste el ancho o la altura proporcionalmente en lugar de escalarlos individualmente.