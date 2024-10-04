---
title: Administrar Placeholder
type: docs
weight: 10
url: /net/manage-placeholder/
keywords: "Placeholder, Texto del placeholder, Texto de aviso, Presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Cambiar el texto del placeholder y el texto de aviso en presentaciones de PowerPoint en C# o .NET"
---

## **Cambiar Texto en Placeholder**
Usando [Aspose.Slides para .NET](/slides/net/), puedes encontrar y modificar placeholders en las diapositivas de presentaciones. Aspose.Slides te permite realizar cambios en el texto de un placeholder.

**Prerequisito**: Necesitas una presentación que contenga un placeholder. Puedes crear una presentación así en la aplicación estándar de Microsoft PowerPoint.

Así es como usas Aspose.Slides para reemplazar el texto en el placeholder en esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) y pasa la presentación como argumento.
2. Obtén una referencia a la diapositiva a través de su índice.
3. Itera a través de las formas para encontrar el placeholder.
4. Convierte el shape del placeholder a un [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) asociado con el [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. Guarda la presentación modificada.

Este código en C# muestra cómo cambiar el texto en un placeholder:

```c#
// Instancia una clase Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Accede a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Itera a través de las formas para encontrar el placeholder
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Cambia el texto en cada placeholder
            ((IAutoShape)shp).TextFrame.Text = "Este es un Placeholder";
        }

    // Guarda la presentación en disco
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Establecer Texto de Aviso en Placeholder**
Las disposiciones estándar y predefinidas contienen textos de aviso de placeholder como ***Haz clic para agregar un título*** o ***Haz clic para agregar un subtítulo***. Usando Aspose.Slides, puedes insertar tus textos de aviso preferidos en disposiciones de placeholder.

Este código en C# te muestra cómo establecer el texto de aviso en un placeholder:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Itera a través de la diapositiva
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint muestra "Haz clic para agregar título"
            {
                text = "Agregar Título";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Agrega subtítulo
            {
                text = "Agregar Subtítulo";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder con texto: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Establecer Transparencia de Imagen de Placeholder**

Aspose.Slides te permite establecer la transparencia de la imagen de fondo en un placeholder de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen resalten (dependiendo de los colores del texto y de la imagen).

Este código en C# te muestra cómo establecer la transparencia para un fondo de imagen (dentro de una forma):

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