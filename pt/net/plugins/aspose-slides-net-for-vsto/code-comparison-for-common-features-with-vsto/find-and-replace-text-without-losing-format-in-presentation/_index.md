---
title: Encontrar e Substituir Texto sem Perder Formatação na Apresentação
type: docs
weight: 100
url: /pt/net/find-and-replace-text-without-losing-format-in-presentation/
---
Ambos os métodos seguem estas etapas:

- Abrir uma apresentação.
- Localizar o texto.
- Substituir o texto.
- Gravar a apresentação.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Abrir a apresentação
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Percorrer os slides
foreach (PowerPoint.Slide sld in pres.Slides)

	//Percorrer todas as formas no slide
	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Acessar o texto na forma
		string str = shp.TextFrame.TextRange.Text;

		//Encontrar o texto a substituir
		if (str.Contains(strToFind))

		//Substituir o texto existente pelo novo texto
		{

			int idx = str.IndexOf(strToFind);

			string strStartText = str.Substring(0, idx);

			string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

			shp.TextFrame.TextRange.Text = strStartText + strToReplaceWith + strEndText;

		}

		pres.SaveAs("MyTextOne___.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

	}

}
``` 
## **Aspose.Slides**
``` csharp

 private static void findReplaceText(string strToFind, string strToReplaceWith)

{

	//Abrir a apresentação
	Presentation pres = new Presentation("mytextone.ppt");

	//Obter todas as caixas de texto na apresentação
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Encontrar o texto a ser substituído
				if (port.Text.Contains(strToFind))

				//Substituir o texto existente pelo novo texto
				{

					string str = port.Text;

					int idx = str.IndexOf(strToFind);

					string strStartText = str.Substring(0, idx);

					string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

					port.Text = strStartText + strToReplaceWith + strEndText;

				}

	pres.Write("myTextOneAspose.ppt");

}
``` 
## **Baixar código de exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)