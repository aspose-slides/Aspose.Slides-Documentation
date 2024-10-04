---
title: Administrar forma de SmartArt
type: docs
weight: 20
url: /net/manage-smartart-shape/
keywords: "forma de SmartArt, estilo de forma de SmartArt, estilo de color de forma de SmartArt, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Administrar SmartArt en presentaciones de PowerPoint en C# o .NET"
---

## **Crear forma de SmartArt**
Aspose.Slides para .NET ahora facilita agregar formas de SmartArt personalizadas en sus diapositivas desde cero. Aspose.Slides para .NET ha proporcionado la API más simple para crear formas de SmartArt de la manera más fácil. Para crear una forma de SmartArt en una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una forma de SmartArt configurando su LayoutType.
- Escriba la presentación modificada como un archivo PPTX.

```c#
// Instanciar la presentación
using (Presentation pres = new Presentation())
{

    // Acceder a la diapositiva de la presentación
    ISlide slide = pres.Slides[0];

    // Agregar forma de Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Guardar presentación
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Acceder a la forma de SmartArt en la diapositiva**
El siguiente código se usará para acceder a las formas de SmartArt agregadas en la diapositiva de la presentación. En el código de muestra, recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma de SmartArt. Si la forma es del tipo SmartArt, la convertiremos a una instancia de SmartArt.

```c#
// Cargar la presentación deseada
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Nombre de la forma:" + smart.Name);

        }
    }
}
```



## **Acceder a la forma de SmartArt con un tipo de diseño particular**
El siguiente código de muestra ayudará a acceder a la forma de SmartArt con un LayoutType particular. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece solo cuando se agrega la forma de SmartArt.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva utilizando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Verifique la forma de SmartArt con un LayoutType particular y realice lo que se requiera hacer a continuación.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Verificando el diseño de SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Hacer algo aquí....");
            }
        }
    }
}
```



## **Cambiar el estilo de forma de SmartArt**
El siguiente código de muestra ayudará a acceder a la forma de SmartArt con un LayoutType particular.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva utilizando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Encuentre la forma de SmartArt con un estilo particular.
- Establezca el nuevo estilo para la forma de SmartArt.
- Guarde la presentación.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Verificando el estilo de SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Cambiando el estilo de SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Guardar presentación
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **Cambiar el estilo de color de la forma de SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color para cualquier forma de SmartArt. En el siguiente código de muestra, accederemos a la forma de SmartArt con un estilo de color particular y cambiaremos su estilo.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva utilizando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Encuentre la forma de SmartArt con un estilo de color particular.
- Establezca el nuevo estilo de color para la forma de SmartArt.
- Guarde la presentación.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Verificando el tipo de color de SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Cambiando el tipo de color de SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Guardar presentación
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```