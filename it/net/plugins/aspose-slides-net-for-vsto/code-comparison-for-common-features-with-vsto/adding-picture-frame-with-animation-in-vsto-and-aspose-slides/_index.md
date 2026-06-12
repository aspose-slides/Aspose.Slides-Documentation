---
title: Aggiungere una cornice immagine con animazione in VSTO e Aspose.Slides
type: docs
weight: 20
url: /it/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Gli esempi di codice seguenti creano una presentazione con una diapositiva, aggiungono un'immagine con una cornice e applicano un'animazione.
## **VSTO**
Utilizzando VSTO, eseguire i seguenti passaggi:

1. Creare una presentazione.
1. Aggiungere una diapositiva vuota.
1. Aggiungere una forma immagine alla diapositiva.
1. Applicare l'animazione all'immagine.
1. Scrivere la presentazione su disco.

``` csharp

 //Creazione di una presentazione vuota

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Aggiungere una diapositiva vuota

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Aggiungere una cornice immagine

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applicare animazione alla cornice immagine

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Salvataggio della presentazione

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **Aspose.Slides**
Utilizzando Aspose.Slides per .NET, eseguire i seguenti passaggi:

1. Creare una presentazione.
1. Accedere alla prima diapositiva.
1. Aggiungere un'immagine a una raccolta di immagini.
1. Aggiungere una forma immagine alla diapositiva.
1. Applicare l'animazione all'immagine.
1. Scrivere la presentazione su disco.

``` csharp

 //Creazione di una presentazione vuota

Presentation pres = new Presentation();

//Accesso alla prima diapositiva

Slide slide = pres.GetSlideByPosition(1);

//Aggiunta dell'oggetto immagine alla raccolta di immagini della presentazione

Picture pic = new Picture(pres, "pic.jpeg");

//Dopo che l'oggetto immagine è stato aggiunto, l'immagine riceve un ID immagine unico

int picId = pres.Pictures.Add(pic);

//Aggiunta di una cornice immagine

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Applicazione dell'animazione alla cornice immagine

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Salvataggio della presentazione

pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)