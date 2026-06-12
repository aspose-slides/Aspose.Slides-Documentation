---
title: Cari dan Ganti Teks Tanpa Kehilangan Format dalam Presentasi
type: docs
weight: 100
url: /id/net/find-and-replace-text-without-losing-format-in-presentation/
---
Kedua metode mengikuti langkah-langkah berikut:

- Buka presentasi.
- Cari teks.
- Ganti teks.
- Tulis presentasi.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Buka presentasi
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Loop melalui slide
foreach (PowerPoint.Slide sld in pres.Slides)

	//Loop melalui semua shape di slide
	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Akses teks di shape
		string str = shp.TextFrame.TextRange.Text;

		//Cari teks yang akan diganti
		if (str.Contains(strToFind))

		//Ganti teks yang ada dengan teks baru
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

	//Buka presentasi
	Presentation pres = new Presentation("mytextone.ppt");

	//Dapatkan semua kotak teks dalam presentasi
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Cari teks yang akan diganti
				if (port.Text.Contains(strToFind))

				//Ganti teks yang ada dengan teks baru
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
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)