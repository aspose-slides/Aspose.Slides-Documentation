---
title: Trova e sostituisci testo senza perdere il formato nella presentazione
type: docs
weight: 100
url: /it/net/find-and-replace-text-without-losing-format-in-presentation/
---
Entrambi i metodi seguono questi passaggi:

- Apri una presentazione.
- Cerca il testo.
- Sostituisci il testo.
- Scrivi la presentazione.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Apri la presentazione
PowerPoint.Presentation pres = null;
pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",
						  Microsoft.Office.Core.MsoTriState.msoFalse,
						  Microsoft.Office.Core.MsoTriState.msoFalse,
						  Microsoft.Office.Core.MsoTriState.msoFalse);
//Scorri le diapositive
foreach (PowerPoint.Slide sld in pres.Slides)
	//Scorri tutte le forme nella diapositiva
	foreach (PowerPoint.Shape shp in sld.Shapes)
	{
		//Accedi al testo nella forma
		string str = shp.TextFrame.TextRange.Text;
		//Trova il testo da sostituire
		if (str.Contains(strToFind))
		//Sostituisci il testo esistente con il nuovo testo
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

	//Apri la presentazione
	Presentation pres = new Presentation("mytextone.ppt");

	//Ottieni tutte le caselle di testo nella presentazione
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)
		foreach (Paragraph para in tb[i].Paragraphs)
			foreach (Portion port in para.Portions)
				//Trova il testo da sostituire
				if (port.Text.Contains(strToFind))
				//Sostituisci il testo esistente con il nuovo testo
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
## **Scarica codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)