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
- description: "Aspose.Slides ile .NET'te hem eski hem de modern API'ları kullanarak bir Hello World PowerPoint PPT, PPTX ve ODP sunumu oluşturun, tek bir basit rehberde."
---
{{% alert color="info" %}}

Yeni bir [Aspose.Slides for .NET API](/slides/tr/net/) yayınlandı ve artık bu tek ürün, sıfırdan PowerPoint belgeleri oluşturma ve mevcut belgeleri düzenleme yeteneğini destekliyor.

{{% /alert %}}
## **Eski Kod Desteği**
Aspose.Slides for .NET'in 13.x öncesi sürümleriyle geliştirilmiş eski kodu kullanmak için kodunuzda bazı küçük değişiklikler yapmanız gerekir ve kod önceki gibi çalışacaktır. Eski Aspose.Slides for .NET'te Aspose.Slide ve Aspose.Slides.Pptx ad alanları altında bulunan tüm sınıflar artık tek bir Aspose.Slides ad alanında birleştirildi. Aşağıdaki basit kod snippet'ine bakarak eski Aspose.Slides API'sinde bir Hello World Sunum belgesi oluşturun ve yeni birleştirilmiş API'ye nasıl geçileceğini açıklayan adımları izleyin.
## **Eski Aspose.Slides for .NET Yaklaşımı**
```c#
using System.Drawing;
using Aspose.Slides;

//Bir PPT dosyasını temsil eden Presentation nesnesi oluşturun
Presentation pres = new Presentation();

//Bir License nesnesi oluşturun
License license = new License();

//Değerlendirme sınırlamalarını önlemek için Aspose.Slides for .NET lisansını ayarlayın
license.SetLicense("Aspose.Slides.lic");

//Sunuma boş bir slayt ekleyerek referansını alıyor
//bu boş slaytı
Slide slide = pres.AddEmptySlide();

//Slayta bir dikdörtgen ekliyor (X=2400, Y=1800, Genişlik=1000 & Yükseklik=500)
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Dikdörtgenin çizgilerini gizliyor
rect.LineFormat.ShowLines = false;

//Dikdörtgene "Hello World" varsayılan metniyle bir metin çerçevesi ekliyor
rect.AddTextFrame("Hello World");

//Sunumun ilk slaytını kaldırıyor; bu slayt her zaman
//Aspose.Slides for .NET tarafından sunum oluşturulurken varsayılan olarak eklenir
pres.Slides.RemoveAt(0);

//Sunumu bir PPT dosyası olarak kaydediyor
pres.Write("C:\\hello.ppt");
```



## **Yeni Aspose.Slides for .NET 13.x Yaklaşımı**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation örneği oluşturun
Presentation pres = new Presentation();

// İlk slaytı al
ISlide sld = (ISlide)pres.Slides[0];

// Dikdörtgen tipinde bir AutoShape ekle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Dikdörtgene ITextFrame ekle
ashp.AddTextFrame("Hello World");

// Metin rengini Siyah'a değiştir (varsayılan olarak Beyazdır)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Dikdörtgenin çizgi rengini Beyaz yap
ashp.ShapeStyle.LineColor.Color = Color.White;

// Şeklin doldurma formatını kaldır
ashp.FillFormat.FillType = FillType.NoFill;

// Sunumu diske kaydet
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```