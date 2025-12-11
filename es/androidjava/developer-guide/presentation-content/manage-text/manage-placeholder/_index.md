---
title: Administrar marcadores de posición de presentación en Android
linktitle: Administrar marcadores de posición
type: docs
weight: 10
url: /es/androidjava/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- texto de sugerencia
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Administre fácilmente los marcadores de posición en Aspose.Slides para Android mediante Java: reemplace texto, personalice las sugerencias y ajuste la transparencia de imágenes en PowerPoint y OpenDocument."
---

## **Cambiar texto en un marcador de posición**
Usando [Aspose.Slides para Android mediante Java](/slides/es/androidjava/), puede encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides le permite realizar cambios en el texto de un marcador de posición.

**Prerequisite**: Necesita una presentación que contenga un marcador de posición. Puede crear esa presentación en la aplicación estándar Microsoft PowerPoint.

Así es como usa Aspose.Slides para reemplazar el texto en el marcador de posición de esa presentación:

1. Instanciar la clase [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) y pasar la presentación como argumento.
2. Obtener una referencia a la diapositiva mediante su índice.
3. Iterar a través de las formas para encontrar el marcador de posición.
4. Convertir la forma del marcador de posición a un [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) y cambiar el texto usando el [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) asociado con el [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Guardar la presentación modificada.

Este código Java muestra cómo cambiar el texto en un marcador de posición:
```java
// Instancia una clase Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Recorre las formas para encontrar el marcador de posición
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Cambia el texto en cada marcador de posición
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Guarda la presentación en disco
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer texto de sugerencia en un marcador de posición**
Los diseños estándar y predefinidos contienen textos de sugerencia de marcador de posición como ***Haga clic para agregar un título*** o ***Haga clic para agregar un subtítulo***. Usando Aspose.Slides, puede insertar sus textos de sugerencia preferidos en los diseños de marcadores de posición.

Este código Java le muestra cómo establecer el texto de sugerencia en un marcador de posición:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itera a través de la diapositiva
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint muestra "Haga clic para agregar un título"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Añade subtítulo
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer transparencia de imagen en marcador de posición**

Aspose.Slides le permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen en dicho marco, puede resaltar el texto o la imagen (según los colores del texto y la imagen).

Este código Java le muestra cómo establecer la transparencia para el fondo de una imagen (dentro de una forma):
```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**What is a base placeholder, and how is it different from a local shape on a slide?**

¿Qué es un marcador de posición base y en qué se diferencia de una forma local en una diapositiva?

Un marcador de posición base es la forma original en un diseño o maestro del que hereda la forma de la diapositiva—tipo, posición y parte del formato provienen de él. Una forma local es independiente; si no hay un marcador de posición base, la herencia no se aplica.

**How can I update all titles or captions across a presentation without iterating over every slide?**

¿Cómo puedo actualizar todos los títulos o subtítulos en una presentación sin iterar por cada diapositiva?

Edite el marcador de posición correspondiente en el diseño o en la diapositiva maestra. Las diapositivas basadas en esos diseños/maestra heredarán automáticamente el cambio.

**How do I control the standard header/footer placeholders—date & time, slide number, and footer text?**

¿Cómo controlo los marcadores de posición estándar de encabezado/pie de página—fecha y hora, número de diapositiva y texto del pie de página?

Utilice los administradores HeaderFooter en el ámbito apropiado (diapositivas normales, diseños, maestra, notas/folletos) para activar o desactivar esos marcadores de posición y establecer su contenido.