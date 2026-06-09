---
title: Criar uma Nova Apresentação no VSTO e no Aspose.Slides
type: docs
weight: 80
url: /pt/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
A seguir, são dois exemplos de código que ilustram como o VSTO e o Aspose.Slides para .NET podem ser usados para alcançar o mesmo objetivo.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obter o layout do slide de título

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Adicionar um slide de título.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Definir o texto do título

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Definir o texto do subtítulo

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Gravar a saída no disco

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Criar uma apresentação

	Presentation pres = new Presentation();

	//Adicionar o slide de título

	Slide slide = pres.AddTitleSlide();

	//Definir o texto do título

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Definir o texto do subtítulo

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Gravar a saída no disco

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)