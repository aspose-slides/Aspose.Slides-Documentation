---
title: Administrar la forma SmartArt
type: docs
weight: 20
url: /java/manage-smartart-shape/
---


## **Crear forma SmartArt**
Aspose.Slides para Java ha proporcionado una API para crear formas SmartArt. Para crear una forma SmartArt en una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. [Agregue una forma SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) configurándola con [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType).
1. Guarde la presentación modificada como un archivo PPTX.

```java
// Instanciar clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar forma SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Guardar presentación
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt añadida a la diapositiva**|

## **Acceder a la forma SmartArt en la diapositiva**
El siguiente código se utilizará para acceder a las formas SmartArt añadidas en la diapositiva de la presentación. En el código de muestra, recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Si la forma es del tipo SmartArt, la convertiremos a una instancia de [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

```java
// Cargar la presentación deseada
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Nombre de la forma:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a la forma SmartArt con un tipo de diseño particular**
El siguiente código de muestra ayudará a acceder a la forma [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) con un tipo de `LayoutType` particular. Tenga en cuenta que no puede cambiar el `LayoutType` del SmartArt ya que es de solo lectura y se establece solo cuando se añade la forma [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva utilizando su índice.
1. Recorra cada forma en la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si es SmartArt.
1. Verifique la forma SmartArt con el `LayoutType` particular y realice lo que sea necesario después.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Verificando el diseño del SmartArt
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

## **Cambiar el estilo de la forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo rápido de cualquier forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva utilizando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si es SmartArt.
1. Encuentre la forma SmartArt con un estilo particular.
1. Establezca el nuevo estilo para la forma SmartArt.
1. Guarde la presentación.

```java
// Instanciar clase Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verificando el estilo SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Cambiando el estilo SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Guardar presentación
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt con estilo cambiado**|

## **Cambiar el estilo de color de la forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color de cualquier forma SmartArt. En el siguiente código de muestra, se accederá a la forma SmartArt con un estilo de color particular y se cambiará su estilo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva utilizando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si es SmartArt.
1. Encuentre la forma SmartArt con un estilo de color particular.
1. Establezca el nuevo estilo de color para la forma SmartArt.
1. Guarde la presentación.

```java
// Instanciar clase Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verificando el tipo de color SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Cambiando el tipo de color SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Guardar presentación
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt con estilo de color cambiado**|