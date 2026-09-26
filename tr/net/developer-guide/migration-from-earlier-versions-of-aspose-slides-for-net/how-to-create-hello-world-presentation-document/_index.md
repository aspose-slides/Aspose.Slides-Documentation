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
description: ".NET'te Aspose.Slides kullanarak hem eski hem de modern API'larıyla bir Hello World PowerPoint PPT, PPTX ve ODP sunumu oluşturun; tek bir basit rehberde."
---
{{% alert color="info" %}}

Aspose.Slides for .NET API'sinin yeni bir sürümü yayınlandı ve artık bu tek ürün, PowerPoint belgelerini sıfırdan oluşturma ve mevcut belgeleri düzenleme yeteneğini destekliyor.

{{% /alert %}}

## **Eski Kod Desteği**

13.x sürümünden önceki Aspose.Slides for .NET sürümleriyle geliştirilen eski kodu kullanmak için kodunuzda birkaç küçük değişiklik yapmanız gerekir ve kod eski gibi çalışacaktır. Eski Aspose.Slides for .NET'te Aspose.Slide ve Aspose.Slides.Pptx ad alanları altında bulunan tüm sınıflar artık tek bir Aspose.Slides ad alanında birleştirilmiştir. Aşağıdaki basit kod örneğine bir göz atın; bu örnek, eski Aspose.Slides API'sinde Hello World sunum belgesi oluşturmayı gösterir ve yeni birleştirilmiş API'ye nasıl geçileceğini anlatan adımları izleyin.

## **Eski Aspose.Slides for .NET Yaklaşımı**
```c#
using System.Drawing;
using Aspose.Slides;

//Bir PPT dosyasını temsil eden Presentation nesnesi oluşturma
Presentation pres = new Presentation();

//License nesnesi oluşturma
License license = new License();

//Değerlendirme sınırlamalarını önlemek için Aspose.Slides for .NET lisansını ayarlama
license.SetLicense("Aspose.Slides.lic");

//Sunuma boş bir slayt ekleme ve referansını alma
//bu boş slaytı
Slide slide = pres.AddEmptySlide();

//Slayta bir dikdörtgen (X=2400, Y=1800, Genişlik=1000 & Yükseklik=500) ekleme
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Dikdörtgenin çizgilerini gizleme
rect.LineFormat.ShowLines = false;

//Dikdörtgene varsayılan metin olarak "Hello World" ile bir metin çerçevesi ekleme
rect.AddTextFrame("Hello World");

//Sunumun her zaman eklenen ilk slaytını kaldırma
//Aspose.Slides for .NET tarafından varsayılan olarak sunum oluşturulurken
pres.Slides.RemoveAt(0);

//Sunumu PPT dosyası olarak yazma
pres.Write("C:\\hello.ppt");
```

## **Yeni Aspose.Slides for .NET 13.x Yaklaşımı**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation'ı Başlat
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```