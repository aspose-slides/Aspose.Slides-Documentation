---
title: Agregar marco de imagen con animación en VSTO y Aspose.Slides
type: docs
weight: 20
url: /es/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---

Los ejemplos de código a continuación crean una presentación con una diapositiva, agregan una imagen con un marco de imagen y aplican animación a ella.
## **VSTO**
Usando VSTO, sigue los siguientes pasos:

1. Crea una presentación.
1. Agrega una diapositiva vacía.
1. Agrega una forma de imagen a la diapositiva.
1. Aplica animación a la imagen.
1. Escribe la presentación en el disco.

``` csharp

 //Creando presentación vacía

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Agregar una diapositiva en blanco

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Agregar marco de imagen

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Aplicando animación en el marco de imagen

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Guardando presentación

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Usando Aspose.Slides para .NET, realiza los siguientes pasos:

1. Crea una presentación.
1. Accede a la primera diapositiva.
1. Agrega una imagen a una colección de imágenes.
1. Agrega una forma de imagen a la diapositiva.
1. Aplica animación a la imagen.
1. Escribe la presentación en el disco.

``` csharp

 //Creando presentación vacía

Presentation pres = new Presentation();

//Accediendo a la primera diapositiva

Slide slide = pres.GetSlideByPosition(1);

//Agregando el objeto imagen a la colección de imágenes de la presentación

Picture pic = new Picture(pres, "pic.jpeg");

//Después de agregar el objeto imagen, se le da un ID de imagen único

int picId = pres.Pictures.Add(pic);

//Agregando marco de imagen

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Aplicando animación en el marco de imagen

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Guardando presentación

pres.Write("AsposeAnim.ppt");

``` 
## **Descargar código de ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772946)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip)