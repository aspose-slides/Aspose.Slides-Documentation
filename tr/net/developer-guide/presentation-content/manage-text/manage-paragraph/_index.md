---
title: PowerPoint Metin Paragraflarını .NET'te Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- askıya alınmış girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'ye
- paragrafı HTML'ye
- paragrafı resme
- metni resme
- paragrafı dışa aktar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf resimleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) bir şeklin metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) bir metin çerçevesindeki tek bir paragrafı temsil eder ve bölümler ile paragraf‑düzeyi biçimlendirmeye erişim sağlar.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) bir paragraftaki metin koşusunu temsil eder. Her bölüm kendi metnine ve karakter‑düzeyi biçimlendirmeye sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanılarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içerebilir.

## **Paragraf Oluşturma ve Biçimlendirme**

Parçaların içinde paragraflar oluşturun ve bölümleri kullanarak tek tek metin koşularını biçimlendirin. Bu bölüm, her paragrafta birden çok bölümü birleştirerek farklı renkler, yazı tipi boyutları ve stiller uygulamayı gösterir.

### **Birden Çok Bölüm ile Paragraflar Oluşturma**

Aşağıdaki C# örneği, her biri [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) koleksiyonunda üç metin koşusu içeren üç paragraf oluşturur. Varsayılan paragrafı ve boş bölümünü yeniden kullanır, ardından kalan paragrafları ve bölümleri ekler. Biçimlendirme [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) üzerinden uygulanır: her paragraftaki ilk bölüm kırmızı, kalın ve 15 puan; ikinci bölüm mavi, italik ve 18 puan. Üçüncü bölüm varsayılan biçimlendirmesini korur:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Numaralı ve Madde İşaretli Listeler Oluşturma**

Paragraf metnini semboller, sayılar veya özel görseller içeren listelere dönüştürün. Bu bölümde madde işareti biçimlendirme, çok seviyeli listeler ve özel başlangıç sayıları ele alınmıştır.

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralar, ilgili öğelerin daha kolay taranmasını sağlar. Aspose.Slides içinde liste ayarları [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) aracılığıyla tanımlanır.

Bu C# örneği aynı metin çerçevesine bir sembol madde işareti ve bir numaralı öğe ekler. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) madde işareti türünü seçerken, [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) sembolü sağlar ve [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) numaralandırma stilini seçer. Her iki öğe de yüzde 100 yüksekliğinde siyah madde işaretleri ve 25 puan paragraf girintisi kullanır:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Resimli Madde İşaretleri Kullanma**

Resimli madde işaretleri, bir sembol veya sayı yerine özel bir görsel kullanmanıza olanak tanır.

Bu C# örneği, sunumun görsel koleksiyonuna bir [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) olarak bir görsel ekler ve bunu paragraf madde işareti olarak kullanır. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) özelliğini resimli madde işareti olarak ayarlar ve görseli [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) üzerinden atar. [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) yüzde 100 olarak ayarlanır, böylece madde işareti paragraf metnine göre boyutlandırılır:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Çok Seviyeli Liste Oluşturma**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) özelliğini ayarlayarak paragrafları bir listenin farklı seviyelerinde konumlandırabilirsiniz. Üst seviye derinliği `0` dır.

Bu C# örneği, dört paragraf için [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) değerlerini 0’dan 3’e kadar atar ve tek bir metin çerçevesinde bir hiyerarşi oluşturur. Her paragraf bir sembol madde işareti kullanır; [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) yuvarlak madde işareti ile tire arasında geçiş yaparak yan yana seviyeleri ayırt eder:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Numaralı Liste Öğelerini Özel Değerlerle Başlatma**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) özelliğini kullanarak bir numaralı paragrafın ilk gösterilen sayısını ayarlayabilirsiniz.

Bu C# örneği, üç paragraf için [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) özelliğini numaralandırma olarak ayarlar ve [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) değerlerini sırasıyla 2, 3 ve 7 olarak atar. Başlangıç değeri her paragraf için ayrı ayrı yapılandırılır, böylece gösterilen sayılar atlanabilir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Paragraf Düzeni ve Bitiş Özelliklerini Kontrol Etme**

Paragraf kenar boşlukları ve girintilerini ayarlayarak ilk satır ve satır içi kırılmaların konumunu kontrol edin. Paragraf son işaretini görünür metin bölümlerinden ayrı olarak biçimlendirebilirsiniz.

### **İlk Satır Girintisi Ayarlama**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) özelliğini kullanarak bir paragrafın ilk satır girintisini kontrol edin. Bu özellik yalnızca paragrafın sol kenar boşluğuna göre ilk satırı kaydırır. Pozitif bir değer ilk satırı sağa, geri kalan satırlar ise paragraf gövdesine hizalı kalır.

Tam paragrafı taşımak gerektiğinde [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) kullanın. Sadece ilk satırı taşımak istediğinizde ise [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) kullanın.

Aşağıdaki örnek, üç paragrafın aynı [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) değeri 20 puan ve [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) değerlerini 0, 20 ve 40 puan olarak ayarlar. İlk satırlar giderek daha büyük ofsetlerde başlarken, satır içi kırılan satırlar aynı sol kenar boşluğunu korur:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

### **Askıya Alınmış Girinti Ayarlama**

Askıya alınmış girinti, ilk satırın geri kalan satırların soluna başlayacağı bir paragraf düzenidir. Aspose.Slides içinde bu etkiyi [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) özelliği ile oluşturursunuz. `Indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırırsınız.

Pratikte, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) paragraf gövdesinin sol konumunu, [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ise ilk satırın bu kenar boşluğuna göre konumunu belirler. Askıya alınmış bir girinti oluşturmak için pozitif bir `MarginLeft` ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografyalar, referanslar, sözlük girişleri ve satır içi kırılan satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için kullanışlıdır.

Aşağıdaki C# örneği, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) değerlerini 40 ve 60 puan, [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) değerlerini ise -20 ve -30 puan olarak eşleştirir. Her paragrafta ilk satır, satır içi kırılan satırların soluna başlar; ikinci paragraf daha derin bir askıya alınmış girinti gösterir:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Sonuç:

![Paragrafların askıya alınmış girintisi](hanging_indent.png)

### **Paragraf Sonu Koşul Özelliklerini Ayarlama**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) özelliği, paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek, [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) 48 puan ve [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) Times New Roman olarak ayarlanmış bir [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) oluşturur. Bu format ikinci paragrafın son işaretine atanır, görünür metin bölümleri değişmeden kalır:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Render Edilen Satır Sayısını Sayma**

Satır sonlarındaki otomatik kaydırma ve noktalama kurallarını görmek için [Satır Kesme Kontrolü](/slides/tr/net/text-formatting/#control-line-breaking) ve [Asılı Noktalama Kontrolü](/slides/tr/net/text-formatting/#control-hanging-punctuation) bölümlerine bakın.

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) metodunu, metin yerleşiminden sonra bir paragrafın kapladığı satır sayısını saymak için kullanın; otomatik kaydırma da dahildir. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken faydalıdır.

Bir paragraf, [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) koleksiyonundaki bir öğedir ve birden çok render edilmiş satır kaplayabilir. Paragraf içinde açık bir satır sonu, başka bir paragraf oluşturmadan yeni bir satır başlatır. Otomatik kaydırma, metnin içine açık satır sonu eklemeden mevcut genişliğe göre satırlar oluşturur. Bu yüzden paragraf sayısını veya satır sonu karakterlerini saymak, render edilmiş satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dize ile değiştirir. Örnek, [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) etkinleştirir ve [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) devre dışı bırakır; böylece şekil genişliği, metni otomatik olarak küçültmeden kaydırmayı kontrol eder. Her ölçüm, [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) kullanılarak yapılır. Şekil boyutları puan cinsindendir. Son olarak örnek, bir paragraf daha ekler ve metin çerçevesi boyunca satır sayılarını toplar.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Bu metin ve bu boyutlarla şeklin daraltılması satır sayısını artırırken, kısa dizeyle değiştirilmesi azaltır. Kesin sayılar yazı tipi bulunabilirliği, yer değişimi, yazı tipi boyutu, kenar boşlukları, girinti, kaydırma ve otomatik sığdırma ayarlarına göre değişebilir. Şablonları kontrol ederken hedef ortam için tasarlanan yazı tiplerini ve yerleşim ayarlarını kullanın.

Satır sayısı tek başına metnin kapsayıcısını aşıp aşmadığını belirlemez. Kullanılabilir yükseklik, satır yüksekliği, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; kaydırma devre dışı olduğunda tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçe/Dışa Aktarma**

HTML kullanarak metni bir sunuma getirebilir veya mevcut paragrafları dışarı aktarıp başka bir yerde kullanabilirsiniz. Bu bölüm ayrıca, tablo hücrelerindeki paragraflar dahil, bireysel paragrafları resim olarak render etmeyi gösterir.

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metodunu kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürebilirsiniz.

Bu C# örneği, bir dosyadan HTML okur ve işaretlemeyi [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metoduna geçirir. Metin çerçevesinin varsayılan paragrafını temizler, böylece çerçeve yalnızca içe aktarılan içeriği taşır. Dikdörtgen şekil, slaytın her iki kenarında 10 puanlık bir kenar boşluğu bırakır:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Paragraf Metnini HTML’ye Dışa Aktarma**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) metodunu kullanarak seçili bir paragraf aralığını HTML olarak dışa aktarabilirsiniz. Sunum metnini bir web sitesinde yeniden kullanırken, sunumun yazı tipi, boyutu veya metin kutusu stillerini taşımadan yerel vurguyu korumak isteyebilirsiniz. [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) ayarı, dışa aktarıcının biçimlendirme mirasını ne kadar takip edeceğini kontrol eder.

[örnek sunumu](text-inheritance.pptx) indirin ve uygulamanın çalışma dizinine koyun. İlk slayt, “Inherited text; explicit red 18pt” metnini içeren bir metin şekli barındırır. Girdi kasıtlı olarak birkaç biçimlendirme seviyesini kullanır:

- Sunumun varsayılan metin stili Calibri ve 28 pt boyutunu sağlar.
- Metin çerçevesinin birinci seviye stili mavi metin ve italik sağlar.
- Paragraf açıkça kalın metin ayarlar.
- İkinci bölüm “explicit red 18pt”, kırmızı metin ve 18 pt boyutunu açıkça ayarlar.

Aşağıdaki tam örnek aynı paragrafları üç kez dışa aktarır. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) nesnesi dışa aktarma metoduna geçirilir ve her sonuç ayrı bir UTF‑8 HTML dosyası olarak yazılır:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

Oluşturulan HTML, ilk bölüm “Inherited text; ” için aşağıdaki CSS’i içerir. Tablo ilgili bildirimleri listeler; diğer oluşturulan özellikler açıklık sağlamak amacıyla çıkarılmıştır.

| Çıktı | İlk bölüm için ilgili CSS | Görünüm |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri mevcutsa mavi, kalın, italik metin 28 pt. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Mavi, kalın, italik metin; sayfa veya tarayıcı yazı tipi ve boyutunu sağlar. |
| `ParagraphOnly.html` | `font-weight:bold` | Kalın metin; sayfa veya tarayıcı yazı tipi, boyut, renk ve italik stilini sağlar. |

İkinci bölüm, üç çıktının tamamında `color:#ff0000`, `font-size:18pt` ve `font-weight:bold` değerlerini korur. `All` ve `TextBox` çıktılarında italik korunur, `ParagraphOnly` çıktısında korunmaz. Mirası sınırlamak, bir paragraf veya bölüme açıkça atanmış biçimlendirmeyi kaldırmaz.

Dosyaları aynı tarayıcıda açarak karşılaştırın. İki sınırlı modda, atlanan CSS özellikleri hedef sayfanın stilleri veya tarayıcı varsayılanları tarafından çözülür; bu nedenle ortaya çıkan görünüm HTML’nin kullanıldığı yere bağlıdır.

### **HTML Pano Parçası Oluşturma**

[AddClipboardFragmentHeader](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/addclipboardfragmentheader/) özelliğini `false` yaparak normal HTML, `true` yaparak pano başlığı ekleyerek alabilirsiniz. Her iki çağrı da bir dize döndürür. Başlık, çevre HTML’nin (`StartHTML` ve `EndHTML`) ve yapıştırılacak içeriğin (`StartFragment` ve `EndFragment`) UTF‑8 bayt ofsetlerini verir.

Bu örnek, iki biçimlendirilmiş paragrafı normal HTML (`html`) ve HTML pano parçası (`clipboardHtml`) olarak dışa aktarır. Parçayı sistem panosuna yazmak ayrı bir uygulama adımıdır. Ham HTML pano baytlarını kabul eden bir pano API’si, BOM olmadan UTF‑8 gerektirir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
var paragraphs = shape.TextFrame.Paragraphs;
paragraphs.Clear();
paragraphs.AddFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

var options = new TextToHtmlConversionOptions { AddClipboardFragmentHeader = false };
var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

options.AddClipboardFragmentHeader = true;
var clipboardHtml = paragraphs.ExportToHtml(0, paragraphs.Count, options);
```

### **Paragrafı Resim Olarak Render Etme**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) tek bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) döndürür. Sonucu bir dosyaya veya akıma [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) ile kaydedebilirsiniz. İçeren şekli render etmenize veya bitmap’i elle kırpmanıza gerek yoktur.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) paragraf bulunamazsa, geçerli bir render sınırı yoksa veya render edilemezse `null` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve kullanılan resmi işlem bitiminde serbest bırakın.

#### **Varsayılan Ölçekte Paragraf Render Etme**

Örnek, ilk şekli üç paragraf içeren bir metin kutusu olan tek bir slaytlı bir sunum kullanır.

![Üç paragrafı içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, indeks 1’deki ikinci paragrafı seçer ve ölçek parametresi olmadan [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) metodunu çağırır. Şeklin gerekli paragrafı içerdiğini ve render sonucunun bir resim olduğunu kontrol eder, ardından resmi PNG formatında kaydetmek için [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) metodunu kullanır. `using` bildirimi, kullanım sonrası resmi serbest bırakır.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Sonuç:

![Paragraf resmi](paragraph_to_image_output.png)

#### **Tablo Hücresinde Ölçekli Paragraf Render Etme**

`float scaleX` ve `float scaleY` parametrelerini kabul eden [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) aşırı yüklemesini kullanın; bu, yatay ve düşey ölçek faktörlerini ayarlar. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğin ve yüksekliğin iki katı olarak render eder ve sonucu PNG resmi olarak kaydeder.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

`1` ölçek faktörü, ilgili ekseni varsayılan piksel boyutunda tutar. Örneğin, iki faktör için `2` değeri, genişlik ve yükseklik yaklaşık iki katına, piksel sayısı dört katına çıkarır. Daha büyük faktörler, yakınlaştırma veya yüksek çözünürlükte daha keskin metin üretir, ancak bellek kullanımını ve dosya boyutunu artırır. `1`’in altındaki faktörler, daha az detaylı daha küçük resimler üretir. En boy oranını korumak için eşit faktörler kullanın; farklı yatay ve düşey faktörler çıktıyı bağımsız olarak uzatır.

Tam bir şeklin render edilmesi için [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) hâlâ yararlıdır; bu, şeklin doldurulması, kenarlığı veya diğer görsel bağlamını da içerir. Yalnızca paragraf resmi için [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) kullanın.

## **SSS**

**Bir metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) özelliğini `false` yaparak kaydırmayı devre dışı bırakabilir, böylece satırlar metin çerçevesinin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki kesin sınırlamalarını nasıl alabilirim?**

[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) metodunu kullanarak paragrafın sınırlayıcı dikdörtgenini alabilirsiniz. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) ise tek bir bölümün sınırlamalarını verir.

**Paragraf hizalaması (sol, sağ, ortalanmış veya iki yana yaslanmış) nerede kontrol edilir?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) bir paragraf‑düzeyi ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafa uygulanır.

Her satır içinde farklı yazı tipi boyutlarına sahip bölümleri dikey olarak hizalamak için [Satır İçinde Yazı Tiplerini Hizalama](/slides/tr/net/text-formatting/#align-fonts-within-a-line) bölümüne bakın.

**Paragrafın bir kısmı için düzeltme dili ayarlanabilir mi?**

Evet. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) özelliğini tek tek bölümlerde ayarlayarak bir paragrafın içinde birden çok dilde metin bulunabilir.