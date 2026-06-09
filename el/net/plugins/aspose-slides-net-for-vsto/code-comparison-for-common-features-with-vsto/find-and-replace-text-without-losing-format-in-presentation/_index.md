---
title: Εύρεση και αντικατάσταση κειμένου χωρίς απώλεια μορφοποίησης σε παρουσίαση
type: docs
weight: 100
url: /el/net/find-and-replace-text-withwithout-losing-format-in-presentation/
---
Και οι δύο μέθοδοι ακολουθούν τα παρακάτω βήματα:

- Ανοίξτε μια παρουσίαση.
- Αναζητήστε το κείμενο.
- Αντικαταστήστε το κείμενο.
- Αποθηκεύστε την παρουσίαση.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Άνοιγμα της παρουσίασης
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Διάσχιση των διαφανειών
foreach (PowerPoint.Slide sld in pres.Slides)
	//Διάσχιση όλων των σχημάτων στη διαφάνεια
	foreach (PowerPoint.Shape shp in sld.Shapes)
	{
		//Πρόσβαση στο κείμενο του σχήματος
		string str = shp.TextFrame.TextRange.Text;
		//Εύρεση κειμένου προς αντικατάσταση
		if (str.Contains(strToFind))
		//Αντικατάσταση υπάρχοντος κειμένου με το νέο κείμενο
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

	//Άνοιγμα της παρουσίασης
	Presentation pres = new Presentation("mytextone.ppt");

	//Ανάκτηση όλων των πλαισίων κειμένου στην παρουσίαση
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Εύρεση κειμένου προς αντικατάσταση
				if (port.Text.Contains(strToFind))

				//Αντικατάσταση υπάρχοντος κειμένου με το νέο κείμενο
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
## **Λήψη δείγματος κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)