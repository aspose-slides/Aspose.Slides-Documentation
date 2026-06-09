---
title: Sunumda Biçim Kaybetmeden Metin Bul ve Değiştir
type: docs
weight: 100
url: /tr/net/find-and-replace-text-without-losing-format-in-presentation/
---
Her iki yöntem de şu adımları izler:

- Sunumu açın.
- Metni arayın.
- Metni değiştirin.
- Sunumu kaydedin.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Sunumu aç

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

                          Microsoft.Office.Core.MsoTriState.msoFalse,

                          Microsoft.Office.Core.MsoTriState.msoFalse,

                          Microsoft.Office.Core.MsoTriState.msoFalse);

//Slaytlar üzerinde döngü

foreach (PowerPoint.Slide sld in pres.Slides)

    //Slayttaki tüm şekillerde döngü

    foreach (PowerPoint.Shape shp in sld.Shapes)

    {

        //Şeklin içindeki metne eriş

        string str = shp.TextFrame.TextRange.Text;

        //Değiştirilecek metni bul

        if (str.Contains(strToFind))

        //Mevcut metni yeni metinle değiştir

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

	//Sunumu aç

	Presentation pres = new Presentation("mytextone.ppt");

	//Sunumdaki tüm metin kutularını al

	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Değiştirilecek metni bul

				if (port.Text.Contains(strToFind))

				//Mevcut metni yeni metinle değiştir

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
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)