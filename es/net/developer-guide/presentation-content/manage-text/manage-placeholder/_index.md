---
title: Gestionar marcadores de presentación en .NET
linktitle: Gestionar marcadores de posición
type: docs
weight: 10
url: /es/net/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- texto de sugerencia
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestione sin esfuerzo los marcadores de posición en Aspose.Slides para .NET: reemplace texto, personalice sugerencias y establezca la transparencia de imágenes en PowerPoint y OpenDocument."
---

## **Cambiar texto en un marcador de posición**
Usando [Aspose.Slides for .NET](/slides/es/net/), puedes encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides permite realizar cambios en el texto de un marcador de posición.

**Requisito previo**: Necesitas una presentación que contenga un marcador de posición. Puedes crear dicha presentación en la aplicación estándar Microsoft PowerPoint.

Así es como utilizas Aspose.Slides para reemplazar el texto en el marcador de posición de esa presentación:

1. Instancia la clase `Presentation` y pasa la presentación como argumento.
2. Obtén una referencia a la diapositiva mediante su índice.
3. Itera a través de las formas para encontrar el marcador de posición.
4. Convierte el tipo de la forma del marcador de posición a `AutoShape` y cambia el texto usando el `TextFrame` asociado al `AutoShape`.
5. Guarda la presentación modificada.

Este código C# muestra cómo cambiar el texto en un marcador de posición:
```c#
// Instancia una clase Presentation
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


## **Establecer texto de sugerencia en un marcador de posición**
Los diseños estándar y preconstruidos contienen textos de sugerencia de marcador de posición como ***Haga clic para agregar un título*** o ***Haga clic para agregar un subtítulo***. Usando Aspose.Slides, puedes insertar tus textos de sugerencia preferidos en los diseños de marcadores de posición.

Este código C# te muestra cómo establecer el texto de sugerencia en un marcador de posición:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Itera a través de la diapositiva
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint muestra "Haga clic para agregar un título"
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

Aspose.Slides permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen resalten (dependiendo de los colores del texto y la imagen).

Este código C# muestra cómo establecer la transparencia para una imagen de fondo (dentro de una forma):
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

Un marcador de posición base es la forma original en un diseño o patrón del que hereda la forma de la diapositiva—tipo, posición y parte del formato provienen de él. Una forma local es independiente; si no hay un marcador de posición base, la herencia no se aplica.

**¿Cómo puedo actualizar todos los títulos o subtítulos en una presentación sin iterar por cada diapositiva?**

Edita el marcador de posición correspondiente en el diseño o en el patrón. Las diapositivas basadas en esos diseños/patrón heredarán automáticamente el cambio.

**¿Cómo controlo los marcadores de posición estándar de encabezado/pie de página —fecha y hora, número de diapositiva y texto del pie?**

Utiliza los administradores HeaderFooter en el ámbito correspondiente (diapositivas normales, diseños, patrón, notas/hojas de mano) para activar o desactivar esos marcadores de posición y establecer su contenido.