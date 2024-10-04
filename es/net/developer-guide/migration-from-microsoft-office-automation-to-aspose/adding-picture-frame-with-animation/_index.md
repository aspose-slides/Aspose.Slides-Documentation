---
title: Agregar marco de imagen con animación
type: docs
weight: 60
url: /net/adding-picture-frame-with-animation/
---

{{% alert color="primary" %}} 

Los marcos de imagen se aplican a formas o imágenes en Microsoft PowerPoint para enmarcar imágenes en una presentación. Este artículo muestra cómo crear un marco de imagen y aplicar animación a él programáticamente utilizando primero [VSTO 2008](/slides/net/adding-picture-frame-with-animation/) y luego [Aspose.Slides for .NET](/slides/net/adding-picture-frame-with-animation/). Primero, te mostramos cómo aplicar un marco y animación utilizando VSTO 2008. Luego te mostramos cómo realizar los mismos pasos utilizando Aspose.Slides for .NET.

{{% /alert %}} 
## **Agregar marcos de imagen con animación**
Los ejemplos de código a continuación crean una presentación con una diapositiva, añaden una imagen con un marco de imagen y aplican animación a ella.
### **Ejemplo de VSTO 2008**
Usando VSTO 2008, sigue los siguientes pasos:

1. Crea una presentación.
1. Añade una diapositiva en blanco.
1. Añade una forma de imagen a la diapositiva.
1. Aplica animación a la imagen.
1. Escribe la presentación en disco.

**La presentación de salida, creada con VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Creando presentación vacía
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Añadir una diapositiva en blanco
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Añadir marco de imagen
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Aplicando animación en el marco de imagen
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Guardando la presentación
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Ejemplo de Aspose.Slides for .NET**
Usando Aspose.Slides for .NET, realiza los siguientes pasos:

1. Crea una presentación.
1. Accede a la primera diapositiva.
1. Añade una imagen a la colección de imágenes.
1. Añade una forma de imagen a la diapositiva.
1. Aplica animación a la imagen.
1. Escribe la presentación en disco.

**La presentación de salida, creada con Aspose.Slides** 

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

    // Añadir un marco de imagen cuya altura y ancho coincidan con la altura y ancho de la imagen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Obtener la secuencia de animación principal de la diapositiva
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Añadir el efecto de animación Volar desde la izquierda al marco de imagen
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Guardar la presentación
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```