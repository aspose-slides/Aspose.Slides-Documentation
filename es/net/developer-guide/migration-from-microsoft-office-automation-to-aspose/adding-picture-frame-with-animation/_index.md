---
title: Añadiendo Marcos de Imagen con Animación Usando VSTO y Aspose.Slides para .NET
linktitle: Marcos de Imagen con Animación
type: docs
weight: 60
url: /es/net/adding-picture-frame-with-animation/
keywords:
- marco de imagen
- agregar imagen
- agregar foto
- imagen con animación
- foto con animación
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Migrar de la automatización de Microsoft Office a Aspose.Slides para .NET y animar marcos de imagen en diapositivas PowerPoint (PPT, PPTX) con código C# limpio."
---

{{% alert color="primary" %}} 
Los marcos de imagen se aplican a formas o imágenes en Microsoft PowerPoint para encuadrar imágenes en una presentación. Este artículo muestra cómo crear un marco de imagen y aplicar animación en él de forma programática usando primero [VSTO 2008](/slides/es/net/adding-picture-frame-with-animation/) y luego [Aspose.Slides for .NET](/slides/es/net/adding-picture-frame-with-animation/). Primero, le mostramos cómo aplicar un marco y animación usando VSTO 2008. Luego le mostramos cómo realizar los mismos pasos usando Aspose.Slides for .NET.
{{% /alert %}} 
## **Agregar marcos de imagen con animación**
Los ejemplos de código a continuación crean una presentación con una diapositiva, añaden una imagen con un marco de imagen y le aplican animación.
### **Ejemplo VSTO 2008**
Usando VSTO 2008, siga los siguientes pasos:

1. Crear una presentación.
1. Agregar una diapositiva en blanco.
1. Añadir una forma de imagen a la diapositiva.
1. Aplicar animación a la imagen.
1. Guardar la presentación en disco.

**La presentación resultante, creada con VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)
```c#
//Crear presentación vacía
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Agregar una diapositiva en blanco
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Agregar marco de imagen
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Aplicar animación al marco de imagen
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Guardar presentación
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Ejemplo Aspose.Slides for .NET**
Usando Aspose.Slides for .NET, realice los siguientes pasos:

1. Crear una presentación.
1. Acceder a la primera diapositiva.
1. Agregar una imagen a una colección de imágenes.
1. Añadir una forma de imagen a la diapositiva.
1. Aplicar animación a la imagen.
1. Guardar la presentación en disco.

**La presentación resultante, creada con Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)
```c#
// Crear una presentación vacía
using (Presentation pres = new Presentation())
{
    // Acceder a la primera diapositiva
    ISlide slide = pres.Slides[0];

    // Añadir una imagen a la colección de imágenes de la presentación
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Añadir un marco de imagen cuya altura y anchura coincidan con la altura y anchura de la imagen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Obtener la secuencia principal de animación de la diapositiva
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Añadir el efecto de animación Volar desde la izquierda al marco de imagen
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Guardar la presentación
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```
