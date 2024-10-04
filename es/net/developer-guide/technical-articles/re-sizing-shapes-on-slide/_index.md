---
title: Redimensionando Formas en Diapositiva
type: docs
weight: 130
url: /es/net/re-sizing-shapes-on-slide/
---

## **Redimensionando Formas en Diapositiva**
Una de las preguntas más frecuentes que hacen los clientes de Aspose.Slides para .NET es cómo redimensionar formas para que cuando se cambie el tamaño de la diapositiva, los datos no se corten. Este breve consejo técnico muestra cómo lograrlo.

Para evitar la desorientación de las formas, cada forma en la diapositiva debe actualizarse de acuerdo al nuevo tamaño de la diapositiva.

```c#
 //Cargar una presentación
Presentation presentation = new Presentation(@"D:\TestResize.ppt");

//Tamaño de diapositiva antiguo
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Cambiando el tamaño de la diapositiva
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

//Nuevo tamaño de diapositiva
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (ISlide slide in presentation.Slides)
{
	foreach (IShape shape in slide.Shapes)
	{
		//Redimensionar posición
		shape.Height = shape.Height * ratioHeight;
		shape.Width = shape.Width * ratioWidth;

		//Redimensionar tamaño de la forma si es necesario 
		shape.Y = shape.Y * ratioHeight;
		shape.X = shape.X * ratioWidth;

	}
}

presentation.Save("Resize.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Si hay alguna tabla en la diapositiva, entonces el código anterior no funcionará perfectamente. En ese caso, cada celda de la tabla necesita ser redimensionada.

{{% /alert %}} 

Necesitas usar el siguiente código en tu parte si necesitas redimensionar las diapositivas con tablas. Establecer el ancho o la altura de la tabla es un caso especial en las formas donde necesitas alterar la altura de cada fila y el ancho de cada columna para alterar la altura y el ancho de la tabla.

```c#
Presentation presentation = new Presentation("D:\\Test.pptx");
//Tamaño de diapositiva antiguo
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Cambiando el tamaño de la diapositiva
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

//Nuevo tamaño de diapositiva
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (IMasterSlide master in presentation.Masters)
{
    foreach (IShape shape in master.Shapes)
    {
        //Redimensionar posición
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Redimensionar tamaño de la forma si es necesario 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;

    }

    foreach (ILayoutSlide layoutslide in master.LayoutSlides)
    {
        foreach (IShape shape in layoutslide.Shapes)
        {
            //Redimensionar posición
            shape.Height = shape.Height * ratioHeight;
            shape.Width = shape.Width * ratioWidth;

            //Redimensionar tamaño de la forma si es necesario 
            shape.Y = shape.Y * ratioHeight;
            shape.X = shape.X * ratioWidth;

        }

    }
}

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in slide.Shapes)
    {
        //Redimensionar posición
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Redimensionar tamaño de la forma si es necesario 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;
        if (shape is ITable)
        {
            ITable table = (ITable)shape;
            foreach (IRow row in table.Rows)
            {
                row.MinimalHeight = row.MinimalHeight * ratioHeight;
                //   row.Height = row.Height * ratioHeight;
            }
            foreach (IColumn col in table.Columns)
            {
                col.Width = col.Width * ratioWidth;

            }
        }

    }
}

presentation.Save("D:\\Resize.pptx", SaveFormat.Pptx);
```