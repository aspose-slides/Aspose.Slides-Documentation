---
title: Znajdź i zamień tekst bez utraty formatu w prezentacji
type: docs
weight: 100
url: /pl/net/find-and-replace-text-without-losing-format-in-presentation/
---
Obie metody wykonują następujące kroki:

- Otwórz prezentację.
- Wyszukaj tekst.
- Zastąp tekst.
- Zapisz prezentację.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Otwórz prezentację

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Iteruj przez slajdy

foreach (PowerPoint.Slide sld in pres.Slides)

	//Iteruj przez wszystkie kształty na slajdzie

	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Uzyskaj dostęp do tekstu w kształcie

		string str = shp.TextFrame.TextRange.Text;

		//Znajdź tekst do zamiany

		if (str.Contains(strToFind))

		//Zastąp istniejący tekst nowym tekstem

		{

			int idx = str.IndexOf(strToFind);
``` 
## **Aspose.Slides**
``` csharp

 private static void findReplaceText(string strToFind, string strToReplaceWith)

{

	//Otwórz prezentację
	Presentation pres = new Presentation("mytextone.ppt");
	//Pobierz wszystkie pola tekstowe w prezentacji
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);
	for (int i = 0; i < tb.Length; i++)
		foreach (Paragraph para in tb[i].Paragraphs)
			foreach (Portion port in para.Portions)
				//Znajdź tekst do zamiany
				if (port.Text.Contains(strToFind))
				//Zastąp istniejący tekst nowym tekstem
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
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)