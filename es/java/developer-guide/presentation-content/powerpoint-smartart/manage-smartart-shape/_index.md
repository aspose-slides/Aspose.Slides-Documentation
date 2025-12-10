---
title: Administrar gráficos SmartArt en presentaciones usando Java
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /es/java/manage-smartart-shape/
keywords:
- Objeto SmartArt
- Gráfico SmartArt
- Estilo SmartArt
- Color SmartArt
- Crear SmartArt
- Agregar SmartArt
- Editar SmartArt
- Cambiar SmartArt
- Acceder SmartArt
- Tipo de diseño SmartArt
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Automatiza la creación, edición y estilo de SmartArt en PowerPoint con Java usando Aspose.Slides, con ejemplos de código concisos y orientación centrada en el rendimiento."
---

## **Crear una forma SmartArt**
Aspose.Slides for Java ha proporcionado una API para crear formas SmartArt. Para crear una forma SmartArt en una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva usando su índice.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) estableciendo su [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType).
1. Guarde la presentación modificada como un archivo PPTX.
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar forma SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Guardar la presentación
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt añadida a la diapositiva**|

## **Acceder a una forma SmartArt en una diapositiva**
El siguiente código se usará para acceder a las formas SmartArt añadidas en la diapositiva de la presentación. En el código de ejemplo recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Si la forma es de tipo SmartArt, la convertiremos a una instancia de [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).
```java
// Cargar la presentación deseada
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a una forma SmartArt con un tipo de diseño específico**
El siguiente código de muestra ayuda a acceder a la forma [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) con un LayoutType específico. Tenga en cuenta que no puede cambiar el LayoutType de SmartArt ya que es de solo lectura y se establece únicamente cuando se añade la forma [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si lo es.
1. Compruebe la forma SmartArt con el LayoutType específico y realice lo que sea necesario a continuación.
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Verificando el diseño de SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar el estilo de una forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo rápido de cualquier forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si lo es.
1. Encuentre la forma SmartArt con un estilo específico.
1. Establezca el nuevo estilo para la forma SmartArt.
1. Guarde la presentación.
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verificando el estilo de SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Cambiando el estilo de SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Guardando la presentación
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt con estilo cambiado**|

## **Cambiar el estilo de color de una forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color de cualquier forma SmartArt. En el siguiente código de muestra se accederá a la forma SmartArt con un estilo de color específico y se cambiará su estilo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si lo es.
1. Encuentre la forma SmartArt con un estilo de color específico.
1. Establezca el nuevo estilo de color para la forma SmartArt.
1. Guarde la presentación.
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verificando el tipo de color de SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Cambiando el tipo de color de SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Guardando la presentación
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt con estilo de color cambiado**|

## **FAQ**

**¿Puedo animar SmartArt como un solo objeto?**

Sí. SmartArt es una forma, por lo que puede aplicar [animaciones estándar](/slides/es/java/powerpoint-animation/) a través de la API de animaciones (entrada, salida, énfasis, rutas de movimiento) igual que con otras formas.

**¿Cómo puedo encontrar un SmartArt específico en una diapositiva si no conozco su ID interno?**

Establezca y use el Texto Alternativo (AltText) y busque la forma por ese valor; esta es una forma recomendada de localizar la forma objetivo.

**¿Puedo agrupar SmartArt con otras formas?**

Sí. Puede agrupar SmartArt con otras formas (imágenes, tablas, etc.) y luego [manipular el grupo](/slides/es/java/group/).

**¿Cómo obtengo una imagen de un SmartArt específico (p.ej., para una vista previa o informe)?**

Exporte una miniatura/imagen de la forma; la biblioteca puede [renderizar formas individuales](/slides/es/java/create-shape-thumbnails/) a archivos raster (PNG/JPG/TIFF).

**¿Se conservará la apariencia de SmartArt al convertir toda la presentación a PDF?**

Sí. El motor de renderizado apunta a alta fidelidad para la [exportación a PDF](/slides/es/java/convert-powerpoint-to-pdf/), con una variedad de opciones de calidad y compatibilidad.