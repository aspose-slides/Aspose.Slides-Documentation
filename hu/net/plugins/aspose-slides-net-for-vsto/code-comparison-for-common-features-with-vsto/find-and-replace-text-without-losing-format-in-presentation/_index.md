---
title: Formátum elvesztése nélkül történő szövegkeresés és csere a prezentációban
type: docs
weight: 100
url: /hu/net/find-and-replace-text-without-losing-format-in-presentation/
---
Mindkét módszer a következő lépéseket követi:

- Nyisson meg egy bemutatót.
- Keresse meg a szöveget.
- Cserélje le a szöveget.
- Mentse a bemutatót.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Nyissa meg a bemutatót
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Végigjárja a diákokat
foreach (PowerPoint.Slide sld in pres.Slides)

	//Végigjárja a dián lévő összes alakzatot
	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Hozzáférés a forma szövegéhez
		string str = shp.TextFrame.TextRange.Text;

		//Keresse meg a cserélendő szöveget
		if (str.Contains(strToFind))

		//Cserélje le a meglévő szöveget az új szövegre
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

    //Nyissa meg a prezentációt
    Presentation pres = new Presentation("mytextone.ppt");
    //A prezentáció összes szövegdobozának lekérése
    ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);
    for (int i = 0; i < tb.Length; i++)
        foreach (Paragraph para in tb[i].Paragraphs)
            foreach (Portion port in para.Portions)
                //Keresse meg a cserélendő szöveget
                if (port.Text.Contains(strToFind))
                //Cserélje le a meglévő szöveget az új szövegre
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
## **Mintakód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)