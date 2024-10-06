---
title: Trouver et remplacer du texte sans perdre le format dans la présentation
type: docs
weight: 100
url: /net/find-and-replace-text-without-losing-format-in-presentation/
---

Les deux méthodes suivent ces étapes :

- Ouvrir une présentation.
- Rechercher le texte.
- Remplacer le texte.
- Enregistrer la présentation.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Ouvrir la présentation

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Parcourir les diapositives

foreach (PowerPoint.Slide sld in pres.Slides)

	//Parcourir toutes les formes dans la diapositive

	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Accéder au texte dans la forme

		string str = shp.TextFrame.TextRange.Text;

		//Trouver le texte à remplacer

		if (str.Contains(strToFind))

		//Remplacer le texte existant par le nouveau texte

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

	//Ouvrir la présentation

	Presentation pres = new Presentation("mytextone.ppt");

	//Obtenir toutes les zones de texte dans la présentation

	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Trouver le texte à remplacer

				if (port.Text.Contains(strToFind))

				//Remplacer le texte existant par le nouveau texte

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
## **Télécharger le code source d'exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772952)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip)