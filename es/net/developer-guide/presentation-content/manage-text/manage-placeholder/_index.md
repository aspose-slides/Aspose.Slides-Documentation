---
title: Administrar marcador de posición
type: docs
weight: 10
url: /es/net/manage-placeholder/
keywords: "Marcador de posición, Texto del marcador de posición, Texto de sugerencia, Presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Cambiar el texto del marcador de posición y el texto de sugerencia en presentaciones de PowerPoint en C# o .NET"
---

## **Cambiar texto en marcador de posición**
Usando [Aspose.Slides for .NET](/slides/es/net/), puede encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides le permite hacer cambios en el texto de un marcador de posición.

**Prerequisito**: necesita una presentación que contenga un marcador de posición. Puede crear dicha presentación en la aplicación estándar Microsoft PowerPoint.

Así es como usa Aspose.Slides para reemplazar el texto en el marcador de posición de esa presentación:

1. Instanciar la clase [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) y pasar la presentación como argumento.
2. Obtener una referencia a la diapositiva mediante su índice.
3. Recorrer las formas para encontrar el marcador de posición.
4. Convertir el tipo de la forma del marcador de posición a un [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) y cambiar el texto usando el [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) asociado al [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. Guardar la presentación modificada.

Este código C# muestra cómo cambiar el texto en un marcador de posición:
```c#
// Instancia la clase Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Accede a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Itera a través de las formas para encontrar el marcador de posición
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Cambia el texto en cada marcador de posición
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Guarda la presentación en disco
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Establecer texto de sugerencia en marcador de posición**
Los diseños estándar y preconstruidos contienen textos de sugerencia de marcador de posición como ***Haga clic para agregar un título*** o ***Haga clic para agregar un subtítulo***. Usando Aspose.Slides, puede insertar sus textos de sugerencia preferidos en los diseños de marcadores de posición.

Este código C# le muestra cómo establecer el texto de sugerencia en un marcador de posición:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Itera a través de la diapositiva
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint muestra "Haga clic para agregar título"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Agrega subtítulo
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```


## **Establecer transparencia de imagen en marcador de posición**

Aspose.Slides le permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Ajustando la transparencia de la imagen en dicho marco, puede hacer que el texto o la imagen resalten (según los colores del texto y de la imagen).

Este código C# le muestra cómo establecer la transparencia para el fondo de una imagen (dentro de una forma):
```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```


## **Preguntas frecuentes**

**¿Qué es un marcador de posición base y en qué se diferencia de una forma local en una diapositiva?**

Un marcador de posición base es la forma original en un diseño o maestro del que la forma de la diapositiva hereda—el tipo, la posición y parte del formato provienen de él. Una forma local es independiente; si no hay un marcador de posición base, la herencia no se aplica.

**¿Cómo puedo actualizar todos los títulos o subtítulos en una presentación sin iterar sobre cada diapositiva?**

Edite el marcador de posición correspondiente en el diseño o el maestro. Las diapositivas basadas en esos diseños/maestro heredarán automáticamente el cambio.

**¿Cómo controlo los marcadores de posición estándar de encabezado/pie de página—fecha y hora, número de diapositiva y texto del pie?**

Utilice los administradores HeaderFooter en el ámbito apropiado (diapositivas normales, diseños, maestro, notas/folletos) para activar o desactivar esos marcadores de posición y establecer su contenido.