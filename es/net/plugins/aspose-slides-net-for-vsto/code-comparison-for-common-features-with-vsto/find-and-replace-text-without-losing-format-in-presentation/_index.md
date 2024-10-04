---
title: Encontrar y Reemplazar Texto sin Perder el Formato en Presentaciones
type: docs
weight: 100
url: /net/find-and-replace-text-without-losing-format-in-presentation/
---

Ambos métodos siguen estos pasos:

- Abrir una presentación.
- Buscar el texto.
- Reemplazar el texto.
- Guardar la presentación.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Abrir la presentación

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Recorrer las diapositivas

foreach (PowerPoint.Slide sld in pres.Slides)

	//Recorrer todas las formas en la diapositiva

	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Acceder al texto en la forma

		string str = shp.TextFrame.TextRange.Text;

		//Encontrar el texto a reemplazar

		if (str.Contains(strToFind))

		//Reemplazar el texto existente con el nuevo texto

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

	//Abrir la presentación

	Presentation pres = new Presentation("mytextone.ppt");

	//Obtener todos los cuadros de texto en la presentación

	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Encontrar el texto a ser reemplazado

				if (port.Text.Contains(strToFind))

				//Reemplazar el texto existente con el nuevo texto

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
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772952)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip)