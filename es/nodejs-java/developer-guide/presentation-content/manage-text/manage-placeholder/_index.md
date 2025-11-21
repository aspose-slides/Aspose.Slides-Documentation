---
title: Gestionar marcador de posición
type: docs
weight: 10
url: /es/nodejs-java/manage-placeholder/
description: Cambiar texto en un marcador de posición en diapositivas PowerPoint usando JavaScript. Establecer texto de sugerencia en un marcador de posición en diapositivas PowerPoint usando JavaScript.
---

## **Cambiar texto en marcador de posición**

Usando [Aspose.Slides for Node.js via Java](/slides/es/nodejs-java/), puedes encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides te permite realizar cambios en el texto de un marcador de posición.

**Requisito previo**: Necesitas una presentación que contenga un marcador de posición. Puedes crear dicha presentación en la aplicación estándar Microsoft PowerPoint.

Así es como utilizas Aspose.Slides para reemplazar el texto del marcador de posición en esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) y pasa la presentación como argumento.
2. Obtén una referencia a la diapositiva mediante su índice.
3. Recorre las formas para encontrar el marcador de posición.
4. Convierte la forma del marcador de posición a un [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) asociado al [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Guarda la presentación modificada.

Este código JavaScript muestra cómo cambiar el texto en un marcador de posición:
```javascript
// Instancia una clase Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Recorre las formas para encontrar el marcador de posición
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Cambia el texto en cada marcador de posición
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Guarda la presentación en disco
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer texto de sugerencia en el marcador de posición**

Los diseños estándar y predefinidos contienen textos de sugerencia de marcadores de posición como ***Haga clic para agregar un título*** o ***Haga clic para agregar un subtítulo***. Con Aspose.Slides, puedes insertar tus textos de sugerencia preferidos en los diseños de marcadores de posición.

Este código JavaScript muestra cómo establecer el texto de sugerencia en un marcador de posición:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Recorre la diapositiva
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint muestra "Haz clic para agregar título"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Agrega subtítulo
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer la transparencia de la imagen del marcador de posición**

Aspose.Slides te permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen en ese marco, puedes hacer que el texto o la imagen resalten (según los colores del texto y de la imagen).

Este código JavaScript muestra cómo establecer la transparencia para el fondo de una imagen (dentro de una forma):
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Qué es un marcador de posición base y en qué se diferencia de una forma local en una diapositiva?**

Un marcador de posición base es la forma original en un diseño o maestro del cual la forma de la diapositiva hereda—el tipo, la posición y parte del formato provienen de él. Una forma local es independiente; si no hay un marcador de posición base, la herencia no se aplica.

**¿Cómo puedo actualizar todos los títulos o leyendas en una presentación sin iterar por cada diapositiva?**

Edita el marcador de posición correspondiente en el diseño o en el maestro. Las diapositivas basadas en esos diseños/ese maestro heredarán automáticamente el cambio.

**¿Cómo controlo los marcadores de posición estándar de encabezado/pie de página (fecha y hora, número de diapositiva y texto del pie)?**

Utiliza los administradores HeaderFooter en el alcance apropiado (diapositivas normales, diseños, maestro, notas/folletos) para activar o desactivar esos marcadores de posición y establecer su contenido.