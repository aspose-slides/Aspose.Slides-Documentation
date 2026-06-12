---
title: Menambahkan Teks Secara Dinamis
type: docs
weight: 40
url: /id/net/adding-text-dynamically/
---
Kedua metode mengikuti langkah-langkah berikut:

- Buat presentasi.
- Tambahkan slide kosong.
- Tambahkan kotak teks.
- Atur beberapa teks.
- Tulis presentasi.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Buat presentasi

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Dapatkan tata letak slide kosong

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Tambahkan slide kosong

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Tambahkan teks

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Atur teks

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Simpan output ke disk

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Buat presentasi

	Presentation pres = new Presentation();

	//Slide kosong ditambahkan secara default, ketika Anda membuat

	//presentasi dari konstruktor default

	//Jadi, kita tidak perlu menambahkan slide kosong apa pun

	Slide sld = pres.GetSlideByPosition(1);

	//Dapatkan indeks font untuk Arial

	//Ini selalu 0 jika Anda membuat presentasi dari

	//konstruktor default

	int arialFontIndex = 0;

	//Tambahkan kotak teks

	//Untuk menambahkannya, kita akan pertama menambahkan sebuah persegi panjang

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Sembunyikan garisnya

	shp.LineFormat.ShowLines = false;

	//Kemudian tambahkan bingkai teks di dalamnya

	TextFrame tf = shp.AddTextFrame("");

	//Atur teks

	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Simpan output ke disk

	pres.Write("outAspose.ppt");

}

``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)