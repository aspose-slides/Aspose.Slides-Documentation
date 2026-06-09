---
title: Criar Novas Apresentações Usando VSTO e Aspose.Slides para .NET
linktitle: Criar Nova Apresentação
type: docs
weight: 10
url: /pt/net/create-a-new-presentation/
keywords:
- criar apresentação
- nova apresentação
- migração
- VSTO
- automação Office
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Migre da automação Microsoft Office para Aspose.Slides para .NET e crie novas apresentações PowerPoint (PPT, PPTX) em C# com código limpo e confiável."
---
{{% alert color="primary" %}} 

VSTO foi desenvolvido para permitir que desenvolvedores criem aplicativos que possam ser executados dentro do Microsoft Office. VSTO é baseado em COM, mas está encapsulado em um objeto .NET para que possa ser usado em aplicações .NET. VSTO precisa de suporte ao .NET framework, bem como do runtime baseado em CLR do Microsoft Office. Embora possa ser usado para criar complementos do Microsoft Office, é quase impossível utilizá‑lo como um componente de servidor. Também apresenta sérios problemas de implantação.

Aspose.Slides for .NET é um componente que pode ser usado para manipular apresentações do Microsoft PowerPoint, assim como o VSTO, mas possui várias vantagens:

- Aspose.Slides contém apenas código gerenciado e não requer que o runtime do Microsoft Office esteja instalado.
- Pode ser usado como um componente cliente ou como um componente servidor.
- A implantação é fácil, pois o Aspose.Slides está contido em um único DLL.

{{% /alert %}} 
## **Criando uma Apresentação**
Abaixo estão dois exemplos de código que ilustram como VSTO e Aspose.Slides for .NET podem ser usados para alcançar o mesmo objetivo. O primeiro exemplo é [VSTO](/slides/pt/net/create-a-new-presentation/); [o segundo exemplo](/slides/pt/net/create-a-new-presentation/) usa o Aspose.Slides.
### **Exemplo VSTO**
**A saída VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Nota: PowerPoint é um namespace que foi definido acima assim
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Exemplo Aspose.Slides for .NET**
**A saída do Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Criar uma apresentação
Presentation pres = new Presentation();

//Adicionar o slide de título
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Definir o texto do título
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Definir o texto do subtítulo
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Gravar a saída no disco
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```