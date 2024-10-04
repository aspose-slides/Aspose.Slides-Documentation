---
title: Gestionar Forma SmartArt
type: docs
weight: 20
url: /androidjava/manage-smartart-shape/
---


## **Crear Forma SmartArt**
Aspose.Slides para Android vía Java ha proporcionado una API para crear formas SmartArt. Para crear una forma SmartArt en una diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva utilizando su índice.
1. [Agregar una forma SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) configurando su [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Guardar la presentación modificada como un archivo PPTX.

```java
// Instanciar la Clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar Forma Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Guardando la presentación
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt agregada a la diapositiva**|

## **Acceder a la Forma SmartArt en la Diapositiva**
El siguiente código se utilizará para acceder a las formas SmartArt agregadas en la diapositiva de la presentación. En el código de muestra, recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). Si la forma es de tipo SmartArt, la convertiremos a una instancia de [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).

```java
// Cargar la presentación deseada
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Nombre de la Forma:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a la Forma SmartArt con un Tipo de Diseño Particular**
El siguiente código de muestra ayudará a acceder a la forma [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) con un LayoutType particular. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt, ya que es de solo lectura y se establece solo cuando se agrega la forma [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) y convertir la forma seleccionada a SmartArt si es SmartArt.
1. Verificar la forma SmartArt con un LayoutType particular y realizar lo que se necesite hacer posteriormente.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Verificando el Layout de SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Hacer algo aquí....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cambiar el Estilo de la Forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo rápido de cualquier forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) y convertir la forma seleccionada a SmartArt si es SmartArt.
1. Encontrar la forma SmartArt con un estilo particular.
1. Establecer el nuevo estilo para la forma SmartArt.
1. Guardar la presentación.

```java
// Instanciar la Clase Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es de tipo SmartArt
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

## **Cambiar el Estilo de Color de la Forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color para cualquier forma SmartArt. En el siguiente código de muestra, accederemos a la forma SmartArt con un estilo de color particular y cambiaremos su estilo.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) y convertir la forma seleccionada a SmartArt si es SmartArt.
1. Encontrar la forma SmartArt con un estilo de color particular.
1. Establecer el nuevo estilo de color para la forma SmartArt.
1. Guardar la presentación.

```java
// Instanciar la Clase Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es de tipo SmartArt
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