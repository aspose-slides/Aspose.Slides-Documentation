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
- asılı girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metin HTML'ye
- paragraf HTML'ye
- paragraf görüntüye
- metin görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) şeklin içinde metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf‑düzeyinde biçimlendirmesine erişim sağlar.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) bir paragrafta bir metin yürütmesini temsil eder. Her bölüm kendi metnine ve karakter‑düzeyinde biçimlendirmesine sahip olabilir.

Bu nedenle bir paragraf, birden fazla bölüm kullanılarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metinler barındırabilir.

## **Paragrafları Oluşturma ve Biçimlendirme**

Bir şeklin metin çerçevesinde paragraflar oluşturun ve bölümleri kullanarak tek tek metin yürütmelerini biçimlendirin. Bu bölüm, her paragrafta birden çok bölümü birleştirerek farklı renkler, punto boyutları ve stiller uygulamayı gösterir.

### **Birden Çok Bölümle Paragraflar Oluşturma**

Aşağıdaki C# örneği, [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) koleksiyonunda üç metin yürütmesi içeren üç paragraf oluşturur. Varsayılan paragraf ve boş bölümü yeniden kullanır, ardından kalan paragrafları ve bölümleri ekler. Biçimlendirme, [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) üzerinden uygulanır: her paragraftaki ilk bölüm kırmızı, kalın ve 15 puan; ikinci bölüm mavi, italik ve 18 puan. Üçüncü bölüm varsayılan biçimini korur:

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

## **Madde İşaretli ve Numaralı Listeler Oluşturma**

Paragraf metnini semboller, sayılar veya özel görsellerle listelere düzenleyin. Bu bölümdeki örnekler madde işareti biçimlendirmesi, çok seviyeli listeler ve özel başlangıç sayıları konularını kapsar.

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralandırma, ilgili öğelerin daha kolay taranmasını sağlar. Aspose.Slides içinde liste ayarları, [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) aracılığıyla tanımlanır.

Bu C# örneği aynı metin çerçevesine bir sembol madde işareti ve bir numaralı öğe ekler. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) madde işareti türünü seçerken, [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) sembolü sağlar ve [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) numaralandırma stilini seçer. Her iki öğe de yüzde 100 yükseklikte siyah madde işaretleri ve 25 puan paragraf girintisi kullanır:

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

### **Resim Madde İşaretleri Kullanma**

Resim madde işaretleri, bir sembol veya sayı yerine özel bir görsel kullanmanıza olanak tanır.

Bu C# örneği, bir [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) olarak sunumun görüntü koleksiyonuna bir görsel ekler ve bunu paragraf madde işareti olarak kullanır. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) bir resim madde işareti kullanılacak şekilde ayarlanır ve görsel [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) aracılığıyla atanır. [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) yüzde 100 olarak ayarlanarak madde işareti paragraf metnine göre boyutlandırılır:

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

### **Çok Düzeyli Liste Oluşturma**

Paragrafları bir listenin farklı seviyelerinde konumlandırmak için [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) ayarlanır. Üst seviye derinliği `0` dır.

Bu C# örneği, dört paragraf için [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) değerlerini 0’dan 3’e kadar atayarak tek bir metin çerçevesinde bir hiyerarşi oluşturur. Her paragraf bir sembol madde işareti kullanır; [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) yuvarlak madde işareti ile tire arasında geçiş yaparak yan yana seviyeleri ayırt eder:

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

Numaralı bir paragraf için görüntülenen başlangıç numarasını ayarlamak üzere [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) kullanılır.

Bu C# örneği üç paragraf için [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) numaralandırma olarak ayarlar ve [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) değerlerini sırasıyla 2, 3 ve 7 olarak atar. Başlangıç değeri her paragraf için ayrı ayrı yapılandırılır, böylece görüntülenen sayılar atlanabilir:

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

Paragraf kenar boşluklarını ve girintilerini ayarlayarak ilk satır ve kaydırılmış satırların konumunu denetleyin. Görünür metin bölümlerinden ayrı olarak paragraf son işaretini de biçimlendirebilirsiniz.

### **İlk Satır Girintisi Ayarlama**

Paragrafın ilk satır girintisini denetlemek için [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) özelliği kullanılır. Bu özellik yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak gerektiğinde [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) kullanın. Sadece ilk satırı taşımak istediğinizde [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) kullanın.

Aşağıdaki örnek, üç paragrafın aynı [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) değeri 20 puan ve [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) değerlerini 0, 20 ve 40 puan olarak ayarlar. İlk satırlar giderek daha büyük ofsetlerde başlarken, kaydırılmış satırlar aynı sol kenar boşluğunu korur:

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

### **Asılı Girinti Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides içinde bu etkiyi [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) özelliğiyle oluşturursunuz. `Indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırın.

Pratikte, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) paragraf gövdesinin sol konumunu belirler, [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ise ilk satırın bu kenara göre konumunu tanımlar. Asılı bir girinti oluşturmak için pozitif bir `MarginLeft` değeri ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografiler, referanslar, sözlük girişleri ve kaydırılmış satırların paragraf gövdesinin altında hizalanması gereken diğer paragraflar için faydalıdır.

Aşağıdaki C# örneği, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) değerlerini 40 ve 60 puan, [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) değerlerini -20 ve -30 puan olarak eşleştirir. Her paragrafta ilk satır kaydırılmış satırların solunda başlar; ikinci paragrafta daha derin bir asılı girinti vardır:

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

![Paragrafların asılı girintisi](hanging_indent.png)

### **Paragraf Sonu Çalıştırma Özelliklerini Ayarlama**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) özelliği paragraf son işaretinin biçimlendirmesini denetler. Aşağıdaki örnek, [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) 48 puan ve [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) Times New Roman olan bir [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) oluşturur. Bu formatı ikinci paragrafın son işaretine atar; görünür metin bölümleri değişmeden kalır:

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

## **Görüntülenen Satırları Sayma**

Satır sonlarındaki otomatik sarma ve noktalama kurallarını etkileyen paragraf kuralları için [Control Line Breaking](/slides/tr/net/text-formatting/#control-line-breaking) ve [Control Hanging Punctuation](/slides/tr/net/text-formatting/#control-hanging-punctuation) bölümlerine bakın.

Paragrafın metin yerleşiminden sonra kaç satır kapladığını saymak için [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) kullanın. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken faydalıdır.

Bir paragraf, [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) içinde bir öğedir ve birden fazla görüntülenen satır kaplayabilir. Paragraf içinde açık bir satır sonu, başka bir paragraf oluşturmadan yeni bir satır başlatır. Otomatik sarmalama, metne açık satır sonları eklemeden kullanılabilir genişliğe göre satırlar oluşturur. Bu yüzden paragrafları ya da satır sonu karakterlerini saymak görüntülenen satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Örnek, [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) etkinleştirir ve [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) devre dışı bırakır; böylece şekil genişliği, metni otomatik sıkmadan sarma davranışını kontrol eder. Her ölçüm [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) ile yapılır. Şekil boyutları puan cinsindendir. Son olarak örnek bir paragraf daha ekler ve metin çerçevesi boyunca satır sayılarını toplar.

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

Bu metin ve bu boyutlarla şekli daraltmak satır sayısını artırırken, metni kısa dizeyle değiştirmek azaltır. Tam sayılar, font bulunabilirliği ve ikamesi, font boyutu, kenar boşlukları, girinti, sarma ve otomatik sığdırma ayarları gibi faktörlere göre değişebilir. Şablonu kontrol ederken hedef ortam için tasarlanan font ve yerleşim ayarlarını kullanın.

Satır sayısı yalnız başına metnin kapsayıcısının dışına taşma durumunu belirlemez. Kullanılabilir yükseklik, satır yükseklikleri, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; sarma devre dışı bırakıldığında tek bir satır bile kullanılabilir genişliği aşabilir.

## **Paragraf İçeriğini İçe Aktarma ve Dışa Aktarma**

HTML kullanarak metni bir sunuma getirin veya mevcut paragrafları dışarıda kullanmak üzere dışa aktarın. Bu bölüm ayrıca paragrafları görsel olarak oluşturmayı ve tablo hücrelerindeki paragrafları da kapsar.

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürün.

Bu C# örneği bir dosyadan HTML okur ve işaretlemesini [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metoduna yollar. Metin çerçevesinin varsayılan paragrafını temizler, böylece çerçeve yalnızca içe aktarılan içeriği içerir. Dikdörtgen şekil slaytın her iki tarafında 10 puanlık bir kenar boşluğu bırakır:

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

### **Paragraf Metnini HTML'ye Dışa Aktarma**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) kullanarak seçili paragraf aralığını HTML olarak dışa aktarın. Sunum metnini bir web sitesinde yeniden kullanırken, sunumun font, boyut veya metin kutusu stillerini taşımadan yerel vurgulamayı korumak isteyebilirsiniz. Dışa aktarıcının biçimlendirme kalıtımını ne kadar takip edeceğini kontrol etmek için [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) ayarlayın.

[örnek sunumu](text-inheritance.pptx) indirin ve uygulamanın çalışma dizinine koyun. İlk slaytı, “Inherited text; explicit red 18pt” metnini içeren bir metin şekli barındırır. Giriş, bilerek birkaç biçimlendirme seviyesi kullanır:

- Sunumun varsayılan metin stili Calibri ve 28 pt boyutunu sağlar.
- Metin çerçevesinin birinci seviye metin stili mavi metin ve italik sağlar.
- Paragraf, kalın metni açıkça ayarlar.
- İkinci bölüm, “explicit red 18pt”, kırmızı metni ve 18 pt boyutu açıkça ayarlar.

Aşağıdaki tam örnek aynı paragrafları üç kez dışa aktarır. Dışa aktarım metoduna [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) geçirir ve her sonucu ayrı bir UTF‑8 HTML dosyası olarak yazar:

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

Oluşturulan HTML, ilk bölüm “Inherited text; ” için aşağıdaki CSS’i içerir. Tablo ilgili bildirimleri listeler; diğer oluşturulan özellikler açıklık için atlanmıştır.

| Çıktı | İlk bölüm için ilgili CSS | Görünüm |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Mavi, kalın, italik metin, Calibri'de 28 pt, eğer bu font mevcutsa. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Mavi, kalın, italik metin; çevreleyen sayfa veya tarayıcı font ailesi ve boyutunu sağlar. |
| `ParagraphOnly.html` | `font-weight:bold` | Kalın metin; çevreleyen sayfa veya tarayıcı font ailesi, boyutu, rengi ve italik stilini sağlar. |

İkinci bölüm, tüm üç çıktıda `color:#ff0000`, `font-size:18pt` ve `font-weight:bold` değerlerini korur. Ayrıca `All` ve `TextBox` çıktılarında italik kalır, `ParagraphOnly` çıktısında ise kalmaz. Kalıtımı kısıtlamak, bir paragraf veya bölüme açıkça atanmış biçimlendirmeyi kaldırmaz.

Dosyaları aynı tarayıcıda açarak karşılaştırın. Kısıtlı iki modda atlanan CSS özellikleri, hedef sayfanın stilleri veya tarayıcı varsayılanları tarafından çözülür; böylece ortaya çıkan görünüm HTML’nin nerede kullanıldığına bağlıdır.

### **Paragrafı Görüntü Olarak Oluşturma**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) tek bir paragrafı doğrudan oluşturur ve bir [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) döndürür. Sonucu [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) ile dosyaya veya akıma kaydedin. İçeren şekli oluşturmanıza ya da bir bitmap’i manuel olarak kırpmanıza gerek yoktur.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) paragraf bulunamazsa, geçerli bir çizim sınırı yoksa veya oluşturulamıyorsa `null` dönebilir. Kaydetmeden önce sonucu kontrol edin ve kullanımdan sonra döndürülen görüntüyü serbest bırakın.

#### **Varsayılan Ölçekte Paragrafı Oluşturma**

Örnek, ilk şekli üç paragraf içeren bir metin kutusu olan tek slaytlı bir sunum kullanır.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, indeksi 1 olan ikinci paragrafı seçer ve ölçek parametreleri olmadan [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) çağırır. Şeklin gerekli paragrafı içerdiğini ve oluşturmanın bir görüntü döndürdüğünü kontrol eder, ardından görüntüyü PNG formatında kaydetmek için [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) çağırır. `using` ifadesi, görüntüyü kullanım sonrası serbest bırakır.

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

![Paragraf görüntüsü](paragraph_to_image_output.png)

#### **Tablo Hücresinde Ölçeklendirme ile Paragrafı Oluşturma**

`float scaleX` ve `float scaleY` parametrelerini kabul eden [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) aşırı yüklemesini kullanarak yatay ve dikey ölçek faktörlerini ayarlayın. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin ve yüksekliğinin iki katı olacak şekilde render eder ve sonucu PNG görüntüsü olarak kaydeder.

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

`1` ölçek faktörü, ekseni varsayılan piksel boyutunda tutar. Örneğin, iki faktör için `2` genişlik ve yükseklik yaklaşık iki katına çıkar, bu da dört kat piksel anlamına gelir. Daha büyük faktörler, yakınlaştırma veya yüksek çözünürlüklü çıktı için genellikle daha keskin metin üretir, ancak bellek kullanımını ve dosya boyutunu da artırır. `1`’in altındaki faktörler, daha az ayrıntı ile daha küçük görüntüler üretir. Paragrafın en boy oranını korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak esnetir.

[İShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) ile tüm bir şeklin render edilmesi, çıktının şeklin doldurmasını, kenarlığını veya diğer görsel bağlamını içermesi gerektiğinde faydalıdır. Yalnızca paragraf görüntüsü için [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) kullanın.

## **SSS**

**Metin çerçevesi içinde satır kırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Satır kırmayı devre dışı bırakmak için [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) ayarlayın, böylece satırlar metin çerçevesinin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki kesin sınırlarını nasıl alabilirim?**

Paragrafın sınırlayıcı dikdörtgenini almak için [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) kullanın. Tek bir bölümün sınırlarını almak için ise [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) kullanılır.

**Paragraf hizalaması (sol, sağ, orta veya iki yana yaslanmış) nerede kontrol edilir?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) bir paragraf‑düzeyi ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak bütün paragrafı etkiler.

Her satırdaki farklı font boyutlu bölümleri dikey olarak hizalamak için [Align Fonts Within a Line](/slides/tr/net/text-formatting/#align-fonts-within-a-line) bölümüne bakın.

**Paragrafın bir kısmı için düzeltme dili ayarlayabilir miyim?**

Evet. Bireysel bölümler için [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) ayarlayın, böylece bir paragraf birden fazla dilde metin içerebilir.