---
title: .NET'te Hello World Sunumları Nasıl Oluşturulur
linktitle: Hello World Sunumu
type: docs
weight: 10
url: /tr/net/how-to-create-hello-world-presentation-document/
keywords:
- geçiş
- merhaba dünya
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
- description: ".NET ile Aspose.Slides kullanarak hem eski hem modern API'leriyle bir Hello World PowerPoint PPT, PPTX ve ODP sunumu oluşturun, tek bir basit rehberde."
---
{{% alert color="primary" %}} 

Yeni bir [Aspose.Slides for .NET API](/slides/tr/net/) yayınlandı ve artık bu tek ürün, sıfırdan PowerPoint belgeleri oluşturma ve mevcut belgeleri düzenleme yeteneğini destekliyor.

{{% /alert %}} 
## **Eski Kod Desteği**
Aspose.Slides for .NET 13.x öncesi sürümlerle geliştirilmiş eski kodu kullanmak için kodunuzda birkaç küçük değişiklik yapmanız gerekir ve kod önceki gibi çalışacaktır. Eski Aspose.Slides for .NET'te Aspose.Slide ve Aspose.Slides.Pptx ad alanları altında bulunulan tüm sınıflar artık tek bir Aspose.Slides ad alanında birleştirildi. Aşağıdaki basit kod parçacığına bakarak eski Aspose.Slides API'sinde bir Hello World Sunum belgesi oluşturabilir ve yeni birleştirilmiş API'ye nasıl geçileceğini açıklayan adımları izleyebilirsiniz.
## **Eski Aspose.Slides for .NET Yaklaşımı**
```c#
//Bir PPT dosyasını temsil eden Presentation nesnesi oluşturun
Presentation pres = new Presentation();

//Bir License nesnesi oluşturun
License license = new License();

//Değerlendirme sınırlamalarından kaçınmak için Aspose.Slides for .NET lisansını ayarlayın
license.SetLicense("Aspose.Slides.lic");

//Sunuma boş bir slayt ekleyip referansını alarak
//bu boş slaytı
Slide slide = pres.AddEmptySlide();

//Slayta bir dikdörtgen (X=2400, Y=1800, Genişlik=1000 & Yükseklik=500) ekleyerek
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Dikdörtgenin kenar çizgilerini gizleyerek
rect.LineFormat.ShowLines = false;

//Dikdörtgene "Hello World" varsayılan metniyle bir metin çerçevesi ekleyerek
rect.AddTextFrame("Hello World");

//Sunumun her zaman eklendiği ilk slaytı kaldırarak
//Aspose.Slides for .NET tarafından varsayılan olarak sunum oluşturulurken
pres.Slides.RemoveAt(0);

//Sunumu bir PPT dosyası olarak yazarak
pres.Write("C:\\hello.ppt");
```



## **Yeni Aspose.Slides for .NET 13.x Yaklaşımı**
```c#
// Presentation nesnesi oluştur
Presentation pres = new Presentation();

// İlk slaytı al
ISlide sld = (ISlide)pres.Slides[0];

// Rectangle tipinde bir AutoShape ekle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Rectangle'a ITextFrame ekle
ashp.AddTextFrame("Hello World");

// Metin rengini Siyah olarak değiştir (varsayılan olarak Beyazdır)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Dikdörtgenin çizgi rengini Beyaz olarak değiştir
ashp.ShapeStyle.LineColor.Color = Color.White;

// Şeklin dolgu biçimlendirmesini kaldır
ashp.FillFormat.FillType = FillType.NoFill;

// Sunumu diske kaydet
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```