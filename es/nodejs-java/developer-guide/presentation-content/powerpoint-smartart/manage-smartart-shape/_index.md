---
title: Administrar forma SmartArt
type: docs
weight: 20
url: /es/nodejs-java/manage-smartart-shape/
---

## **Crear forma SmartArt**
Aspose.Slides para Node.js a través de Java ha proporcionado una API para crear formas SmartArt. Para crear una forma SmartArt en una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva usando su Índice.
3. [Añadir una forma SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) configurando su [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType).
4. Guarde la presentación modificada como un archivo PPTX.
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Agregar forma Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Guardando la presentación
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: forma SmartArt añadida a la diapositiva**|

## **Acceder a la forma SmartArt en la diapositiva**
El siguiente código se usará para acceder a las formas SmartArt añadidas en la diapositiva de la presentación. En el código de ejemplo recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Si la forma es de tipo SmartArt, la convertiremos al tipo [**SmartArt**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) instancia.
```javascript
// Cargar la presentación deseada
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar si la forma es de tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forma a SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Acceder a la forma SmartArt con un tipo de Layout específico**
El siguiente código de ejemplo ayuda a acceder a la forma [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) con un LayoutType específico. Tenga en cuenta que no puede cambiar el LayoutType de SmartArt, ya que es de solo lectura y se establece únicamente cuando se añade la forma [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt).

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la primera diapositiva usando su Índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si lo es.
5. Compruebe la forma SmartArt con el LayoutType específico y realice lo que sea necesario a continuación.
```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar si la forma es de tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forma a SmartArtEx
            var smart = shape;
            // Comprobando el Layout de SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cambiar el estilo de la forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo rápido de cualquier forma SmartArt.

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la primera diapositiva usando su Índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si lo es.
5. Encuentre la forma SmartArt con un Estilo específico.
6. Establezca el nuevo Estilo para la forma SmartArt.
7. Guarde la Presentación.
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verificar si la forma es de tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forma a SmartArtEx
            var smart = shape;
            // Comprobando el estilo de SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Cambiando el estilo de SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Guardando la presentación
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: forma SmartArt con estilo cambiado**|

## **Cambiar el estilo de color de la forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color de cualquier forma SmartArt. En el siguiente código de ejemplo se accederá a la forma SmartArt con un estilo de color específico y se cambiará su estilo.

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la primera diapositiva usando su Índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si lo es.
5. Encuentre la forma SmartArt con un Estilo de Color específico.
6. Establezca el nuevo Estilo de Color para la forma SmartArt.
7. Guarde la Presentación.
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verificar si la forma es de tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forma a SmartArtEx
            var smart = shape;
            // Comprobando el tipo de color de SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Cambiando el tipo de color de SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Guardar la presentación
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: forma SmartArt con estilo de color cambiado**|

## **Preguntas frecuentes**

**¿Puedo animar SmartArt como un solo objeto?**

Sí. SmartArt es una forma, por lo que puede aplicar [animaciones estándar](/slides/es/nodejs-java/powerpoint-animation/) a través de la API de animaciones (entrada, salida, énfasis, rutas de movimiento) al igual que con otras formas.

**¿Cómo puedo encontrar un SmartArt específico en una diapositiva si no conozco su ID interno?**

Establezca y utilice el Texto alternativo (AltText) y busque la forma por ese valor; este es un método recomendado para localizar la forma objetivo.

**¿Puedo agrupar SmartArt con otras formas?**

Sí. Puede agrupar SmartArt con otras formas (imágenes, tablas, etc.) y luego [manipular el grupo](/slides/es/nodejs-java/group/).

**¿Cómo obtengo una imagen de un SmartArt específico (p. ej., para una vista previa o informe)?**

Exporta una miniatura/imagen de la forma; la biblioteca puede [renderizar formas individuales](/slides/es/nodejs-java/create-shape-thumbnails/) a archivos ráster (PNG/JPG/TIFF).

**¿Se conservará la apariencia de SmartArt al convertir toda la presentación a PDF?**

Sí. El motor de renderizado apunta a alta fidelidad para la [exportación a PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), con una variedad de opciones de calidad y compatibilidad.