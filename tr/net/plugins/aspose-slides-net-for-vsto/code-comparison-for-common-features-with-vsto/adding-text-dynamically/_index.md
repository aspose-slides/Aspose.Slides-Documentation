---
title: Metni Dinamik Olarak Ekleme
type: docs
weight: 40
url: /tr/net/adding-text-dynamically/
---
Her iki yöntem de şu adımları izler:

- Bir sunum oluşturun.
- Boş bir slayt ekleyin.
- Bir metin kutusu ekleyin.
- Metin ayarlayın.
- Sunumu yazın.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Bir sunum oluştur
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application
		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
	//Boş slayt düzenini al
	PowerPoint.CustomLayout layout = pres.SlideMaster.
		CustomLayouts[7];
	//Boş bir slayt ekle
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);
	//Metin ekle
	PowerPoint.Shape shp =sld.Shapes.AddTextbox
	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);
	//Metni ayarla
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
	txtRange.Text = "Text added dynamically";
	txtRange.Font.Name = "Arial";
	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
	txtRange.Font.Size = 32;
	//Çıktıyı diske kaydet
	pres.SaveAs("outVSTOAddingText.ppt",
		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
		Microsoft.Office.Core.MsoTriState.msoFalse);
}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Bir sunum oluştur
	Presentation pres = new Presentation();

	//Boş slayt varsayılan olarak eklenir, oluşturduğunuzda
	//varsayılan yapıcıdan sunum oluştururken
	//Bu nedenle, hiçbir boş slayt eklememize gerek yok
	Slide sld = pres.GetSlideByPosition(1);

	//Arial için font indeksini al
	//Sunumu varsayılan yapıcıdan oluşturursanız daima 0'dır
	//varsayılan yapıcı
	int arialFontIndex = 0;

	//Bir metin kutusu ekle
	//Bunu eklemek için önce bir dikdörtgen ekleyeceğiz
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Çizgisini gizle
	shp.LineFormat.ShowLines = false;

	//Sonra içinde bir metin çerçevesi ekle
	TextFrame tf = shp.AddTextFrame("");

	//Metni ayarla
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Çıktıyı diske kaydet
	pres.Write("outAspose.ppt");

}

``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)