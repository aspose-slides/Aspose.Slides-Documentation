---
title: Najít a nahradit text bez ztráty formátování v prezentaci
type: docs
weight: 100
url: /cs/net/find-and-replace-text-without-losing-format-in-presentation/
---
Obě metody postupují podle následujících kroků:

- Otevřete prezentaci.
- Vyhledejte text.
- Nahraďte text.
- Uložte prezentaci.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Otevřít prezentaci
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Procházet snímky
foreach (PowerPoint.Slide sld in pres.Slides)

	//Procházet všechny tvary na snímku
	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Přístup k textu ve tvaru
		string str = shp.TextFrame.TextRange.Text;

		//Najít text k nahrazení
		if (str.Contains(strToFind))

		//Nahradit existující text novým textem
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

	//Otevřít prezentaci
	Presentation pres = new Presentation("mytextone.ppt");

	//Získat všechna textová pole v prezentaci
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Najít text, který má být nahrazen
				if (port.Text.Contains(strToFind))

				//Nahradit existující text novým textem
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
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)