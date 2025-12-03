---
title: Administrar marcadores de posición de presentación en Java
linktitle: Administrar marcadores de posición
type: docs
weight: 10
url: /es/java/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- texto de aviso
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Administre sin esfuerzo los marcadores de posición en Aspose.Slides para Java: reemplace texto, personalice avisos y establezca la transparencia de imágenes en PowerPoint y OpenDocument."
---

## **Cambiar texto en marcador de posición**
Usando [Aspose.Slides for Java](/slides/es/java/), puedes encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides permite realizar cambios en el texto de un marcador de posición.

**Requisito previo**: Necesitas una presentación que contenga un marcador de posición. Puedes crear dicha presentación en la aplicación estándar Microsoft PowerPoint.

Así es como utilizas Aspose.Slides para reemplazar el texto del marcador de posición en esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). y pasa la presentación como argumento.
2. Obtén una referencia a una diapositiva mediante su índice.
3. Itera a través de las formas para encontrar el marcador de posición.
4. Convierte la forma del marcador de posición a un [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) asociado al [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
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
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Guarda la presentación en disco
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer texto de aviso en marcador de posición**
Los diseños estándar y predefinidos contienen textos de aviso de marcador de posición como ***Haz clic para agregar un título*** o ***Haz clic para agregar un subtítulo***. Usando Aspose.Slides, puedes insertar tus textos de aviso preferidos en los diseños de marcadores de posición.

Este código Java muestra cómo establecer el texto de aviso en un marcador de posición:
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
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Agrega subtítulo
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


## **Establecer transparencia de imagen del marcador de posición**
Aspose.Slides permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen resalten (según los colores del texto y de la imagen).

Este código Java muestra cómo establecer la transparencia para el fondo de una imagen (dentro de una forma):
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

**¿Qué es un marcador de posición base y en qué se diferencia de una forma local en una diapositiva?**
Un marcador de posición base es la forma original en un diseño o maestro del que hereda la forma de la diapositiva; el tipo, la posición y parte del formato provienen de él. Una forma local es independiente; si no hay un marcador de posición base, la herencia no se aplica.

**¿Cómo puedo actualizar todos los títulos o pies de foto en una presentación sin iterar sobre cada diapositiva?**
Edita el marcador de posición correspondiente en el diseño o en el maestro. Las diapositivas basadas en esos diseños/maestro heredarán automáticamente el cambio.

**¿Cómo controlo los marcadores de posición estándar de encabezado/pie de página —fecha y hora, número de diapositiva y texto del pie de página?**
Utiliza los administradores HeaderFooter en el ámbito apropiado (diapositivas normales, diseños, maestro, notas/folletos) para activar o desactivar esos marcadores de posición y para establecer su contenido.