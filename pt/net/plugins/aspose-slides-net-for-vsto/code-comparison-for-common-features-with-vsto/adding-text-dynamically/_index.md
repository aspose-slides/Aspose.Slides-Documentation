---
title: Adicionando Texto Dinamicamente
type: docs
weight: 40
url: /pt/net/adding-text-dynamically/
---
Ambos os métodos seguem estas etapas:

- Criar uma apresentação.
- Adicionar um slide em branco.
- Adicionar uma caixa de texto.
- Definir algum texto.
- Salvar a apresentação.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Criar uma apresentação
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application
		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Obter o layout do slide em branco
	PowerPoint.CustomLayout layout = pres.SlideMaster.
		CustomLayouts[7];

	//Adicionar um slide em branco
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Adicionar texto
	PowerPoint.Shape shp =sld.Shapes.AddTextbox
	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Definir um texto
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
	txtRange.Text = "Text added dynamically";
	txtRange.Font.Name = "Arial";
	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
	txtRange.Font.Size = 32;

	//Gravar a saída no disco
	pres.SaveAs("outVSTOAddingText.ppt",
		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
		Microsoft.Office.Core.MsoTriState.msoFalse);
}
``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()
{
	//Criar uma apresentação
	Presentation pres = new Presentation();
	//O slide em branco é adicionado por padrão, quando você cria
	//uma apresentação a partir do construtor padrão
	//Portanto, não precisamos adicionar nenhum slide em branco
	Slide sld = pres.GetSlideByPosition(1);
	//Obter o índice da fonte para Arial
	//Sempre é 0 se você criar a apresentação a partir do
	//construtor padrão
	int arialFontIndex = 0;
	//Adicionar uma caixa de texto
	//Para adicioná-la, primeiro adicionaremos um retângulo
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);
	//Ocultar sua linha
	shp.LineFormat.ShowLines = false;
	//Em seguida, adicionar um quadro de texto dentro dele
	TextFrame tf = shp.AddTextFrame("");
	//Definir um texto
	tf.Text = "Text added dynamically";
	Portion port = tf.Paragraphs[0].Portions[0];
	port.FontIndex = arialFontIndex;
	port.FontBold = true;
	port.FontHeight = 32;
	//Gravar a saída no disco
	pres.Write("outAspose.ppt");
}
``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)