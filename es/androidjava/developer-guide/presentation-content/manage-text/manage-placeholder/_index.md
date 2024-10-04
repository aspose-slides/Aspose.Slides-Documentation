---
title: Administrar Marcador
type: docs
weight: 10
url: /androidjava/manage-placeholder/
description: Cambiar texto en un marcador en diapositivas de PowerPoint usando Java. Establecer texto de indicación en un marcador en diapositivas de PowerPoint usando Java.
---

## **Cambiar texto en marcador**
Usando [Aspose.Slides para Android a través de Java](/slides/androidjava/), puedes encontrar y modificar marcadores en diapositivas de presentaciones. Aspose.Slides te permite hacer cambios en el texto de un marcador.

**Requisito previo**: Necesitas una presentación que contenga un marcador. Puedes crear una presentación así en la aplicación estándar de Microsoft PowerPoint.

Así es como utilizas Aspose.Slides para reemplazar el texto en el marcador de esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) y pasa la presentación como un argumento.
2. Obtén una referencia de diapositiva a través de su índice.
3. Itera a través de las formas para encontrar el marcador.
4. Convierte el marcador en una forma de tipo [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) asociado con el [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Guarda la presentación modificada.

Este código Java muestra cómo cambiar el texto en un marcador:

```java
// Instancia una clase Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Itera a través de las formas para encontrar el marcador
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Cambia el texto en cada marcador
            ((IAutoShape) shp).getTextFrame().setText("Este es el Marcador");
        }
    }

    // Guarda la presentación en el disco
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer texto de indicación en el marcador**
Los diseños estándar y predefinidos contienen textos de indicación de marcador como ***Haz clic para añadir un título*** o ***Haz clic para añadir un subtítulo***. Usando Aspose.Slides, puedes insertar tus textos de indicación preferidos en los diseños de marcadores.

Este código Java te muestra cómo establecer el texto de indicación en un marcador:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itera a través de la diapositiva
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint muestra "Haz clic para añadir título" 
            {
                text = "Añadir Título";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Añade subtítulo
            {
                text = "Añadir Subtítulo";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Marcador con texto: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer transparencia de imagen en el marcador**

Aspose.Slides te permite establecer la transparencia de la imagen de fondo en un marcador de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen resalten (dependiendo de los colores del texto y de la imagen).

Este código Java te muestra cómo establecer la transparencia para un fondo de imagen (dentro de una forma):

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