---
title: Gestionar Marcador de Posición
type: docs
weight: 10
url: /es/java/manage-placeholder/
description: Cambiar Texto en un Marcador de Posición en Diapositivas de PowerPoint utilizando Java. Establecer Texto de Sugerencia en un Marcador de Posición en Diapositivas de PowerPoint utilizando Java.
---

## **Cambiar Texto en el Marcador de Posición**
Usando [Aspose.Slides for Java](/slides/es/java/), puedes encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides te permite hacer cambios en el texto de un marcador de posición.

**Prerequisito**: Necesitas una presentación que contenga un marcador de posición. Puedes crear tal presentación en la aplicación estándar de Microsoft PowerPoint.

Así es como usas Aspose.Slides para reemplazar el texto en el marcador de posición en esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y pasa la presentación como un argumento.
2. Obtén una referencia de diapositiva a través de su índice.
3. Itera a través de las formas para encontrar el marcador de posición.
4. Convierte el marcador de posición en una forma [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) asociado con el [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Guarda la presentación modificada.

Este código Java muestra cómo cambiar el texto en un marcador de posición:

```java
// Instancia una clase Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Itera a través de las formas para encontrar el marcador de posición
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Cambia el texto en cada marcador de posición
            ((IAutoShape) shp).getTextFrame().setText("Este es un Marcador de Posición");
        }
    }

    // Guarda la presentación en el disco
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Texto de Sugerencia en el Marcador de Posición**
Los diseños estándar y predefinidos contienen textos de sugerencia para los marcadores de posición, como ***Clic para agregar un título*** o ***Clic para agregar un subtítulo***. Usando Aspose.Slides, puedes insertar tus textos de sugerencia preferidos en los diseños de marcadores de posición.

Este código Java te muestra cómo establecer el texto de sugerencia en un marcador de posición:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itera a través de la diapositiva
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint muestra "Clic para agregar título" 
            {
                text = "Agregar Título";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Agrega subtítulo
            {
                text = "Agregar Subtítulo";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Marcador de posición con texto: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Transparencia de Imagen en el Marcador de Posición**

Aspose.Slides te permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen se destaquen (dependiendo de los colores del texto y la imagen).

Este código Java te muestra cómo establecer la transparencia para una imagen de fondo (dentro de una forma):

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
        System.out.println("Valor actual de transparencia: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```