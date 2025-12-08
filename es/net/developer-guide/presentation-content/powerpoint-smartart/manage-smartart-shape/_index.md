---
title: Administrar forma SmartArt
type: docs
weight: 20
url: /es/net/manage-smartart-shape/
keywords: "forma SmartArt, estilo de forma SmartArt, estilo de color de forma SmartArt, presentación PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Administrar SmartArt en presentaciones PowerPoint en C# o .NET"
---

## **Crear forma SmartArt**
Aspose.Slides for .NET ahora facilita la adición de formas SmartArt personalizadas en sus diapositivas desde cero. Aspose.Slides for .NET ha proporcionado la API más simple para crear formas SmartArt de la manera más fácil. Para crear una forma SmartArt en una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada una forma SmartArt estableciendo su LayoutType.
- Guarde la presentación modificada como un archivo PPTX.
```c#
 // Instanciar la presentación
 using (Presentation pres = new Presentation())
 {
 
     // Acceder a la diapositiva de la presentación
     ISlide slide = pres.Slides[0];
 
     // Añadir forma SmartArt
     ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
 
     // Guardar la presentación
     pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **Acceder a la forma SmartArt en la diapositiva**
El siguiente código se utilizará para acceder a las formas SmartArt añadidas en la diapositiva de la presentación. En el código de ejemplo recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma SmartArt. Si la forma es de tipo SmartArt, la convertiremos a una instancia de SmartArt.
```c#
// Cargar la presentación deseada
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir tipo de forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **Acceder a la forma SmartArt con un tipo de diseño específico**
El siguiente código de ejemplo ayudará a acceder a la forma SmartArt con un LayoutType específico. Tenga en cuenta que no puede cambiar el LayoutType de SmartArt ya que es de solo lectura y se establece únicamente cuando se agrega la forma SmartArt.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArt si lo es.
- Compruebe la forma SmartArt con el LayoutType específico y realice lo que sea necesario a continuación.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Comprobando el diseño de SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```


## **Cambiar el estilo de la forma SmartArt**
El siguiente código de ejemplo ayudará a acceder a la forma SmartArt con un LayoutType específico.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArt si lo es.
- Encuentre la forma SmartArt con un estilo específico.
- Establezca el nuevo estilo para la forma SmartArt.
- Guarde la presentación.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Comprobando el estilo de SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Cambiando el estilo de SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Guardando la presentación
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```


## **Cambiar el estilo de color de la forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color de cualquier forma SmartArt. En el siguiente código de ejemplo se accederá a la forma SmartArt con un estilo de color específico y se cambiará su estilo.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArt si lo es.
- Encuentre la forma SmartArt con un estilo de color específico.
- Establezca el nuevo estilo de color para la forma SmartArt.
- Guarde la presentación.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Comprobando el tipo de color de SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Cambiando el tipo de color de SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Guardando la presentación
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Puedo animar SmartArt como un solo objeto?**

Sí. SmartArt es una forma, por lo que puede aplicar [animaciones estándar](/slides/es/net/powerpoint-animation/) mediante la API de animaciones (entrada, salida, énfasis, rutas de movimiento) al igual que con otras formas.

**¿Cómo puedo encontrar un SmartArt específico en una diapositiva si no conozco su ID interno?**

Establezca y use el Texto alternativo (AltText) y busque la forma por ese valor; esta es una forma recomendada de localizar la forma objetivo.

**¿Puedo agrupar SmartArt con otras formas?**

Sí. Puede agrupar SmartArt con otras formas (imágenes, tablas, etc.) y luego [manipular el grupo](/slides/es/net/group/).

**¿Cómo obtengo una imagen de un SmartArt específico (por ejemplo, para una vista previa o informe)?**

Exporta una miniatura/imagen de la forma; la biblioteca puede [renderizar formas individuales](/slides/es/net/create-shape-thumbnails/) a archivos raster (PNG/JPG/TIFF).

**¿Se conservará la apariencia de SmartArt al convertir toda la presentación a PDF?**

Sí. El motor de renderizado apunta a alta fidelidad para la [exportación a PDF](/slides/es/net/convert-powerpoint-to-pdf/), con una variedad de opciones de calidad y compatibilidad.