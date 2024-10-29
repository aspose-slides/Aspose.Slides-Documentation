---
title: Text suchen und ersetzen ohne Formatierung in der Präsentation zu verlieren
type: docs
weight: 100
url: /de/net/find-and-replace-text-without-losing-format-in-presentation/
---

Beide Methoden folgen diesen Schritten:

- Öffnen Sie eine Präsentation.
- Suchen Sie den Text.
- Ersetzen Sie den Text.
- Speichern Sie die Präsentation.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Präsentation öffnen

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Durchlaufen Sie die Folien

foreach (PowerPoint.Slide sld in pres.Slides)

	//Durchlaufen Sie alle Formen in der Folie

	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Zugriff auf den Text in der Form

		string str = shp.TextFrame.TextRange.Text;

		//Text finden, der ersetzt werden soll

		if (str.Contains(strToFind))

		//Vorhandenen Text mit dem neuen Text ersetzen

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

``` 
## **Aspose.Slides**
``` csharp

 private static void findReplaceText(string strToFind, string strToReplaceWith)

{

	//Präsentation öffnen

	Presentation pres = new Presentation("mytextone.ppt");

	//Alle Textfelder in der Präsentation abrufen

	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Text finden, der ersetzt werden soll

				if (port.Text.Contains(strToFind))

				//Vorhandenen Text mit dem neuen Text ersetzen

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
## **Beispielcode herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772952)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip)