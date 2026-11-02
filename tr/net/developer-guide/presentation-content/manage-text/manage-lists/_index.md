---
title: ".NET ile Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme"
linktitle: "Listeleri Yönet"
type: docs
weight: 70
url: /tr/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - "madde işareti"
  - "madde işaretli liste"
  - "numaralı liste"
  - "sembol madde işareti"
  - "resimli madde işareti"
  - "özel madde işareti"
  - "çok seviyeli liste"
  - "madde işareti oluştur"
  - "madde işareti ekle"
  - "liste ekle"
  - "PowerPoint"
  - "OpenDocument"
  - "sunum"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturup biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde imleç ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyindeki liste ayarlarına erişmek için [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) özelliğini kullanın. Ana giriş noktası, bir [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) nesnesi döndüren [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) özelliğidir. Bu nesne ile madde işareti tipini, simgesini, resmini, rengini, boyutunu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale şunları gösterir:

- özel bir sembolle madde işaretli liste oluşturma
- resimli madde işareti oluşturma
- paragraf derinliğini ayarlayarak çok seviyeli liste oluşturma
- numaralı liste oluşturma
- mevcut bir sunumda liste biçimlendirmesini inceleme ve değiştirme
- paragraf metniyle birlikte gerçek liste işaretçilerini ve numaralarını okuma

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için bir [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) içine [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) nesneleri ekleyin ve [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) değerini [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) olarak ayarlayın. Ardından madde işaretinin görünümünü kontrol etmek için [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/) ve [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) değerlerini ayarlayabilirsiniz.

Bu C# kodu, bir slaytta madde işaretli liste oluşturmayı gösterir:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Sonuç:

![Sembol madde işaretleri](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Öğelerin sırası önemli olduğunda numaralı listeler kullanın. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) değerini [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) olarak ayarlayın. Ayrıca [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) ile bir numaralandırma biçimi seçebilir veya listenin 1’den farklı bir değerden başlaması gerektiğinde [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) ayarını kullanabilirsiniz.

Aşağıdaki C# kodu, bir slaytta numaralı liste oluşturmayı gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Sonuç:

![Numaralı madde işaretleri](numbered_bullets.png)

## **Resimli Madde İşareti Oluşturma**

Aspose.Slides, normal bir madde işareti simgesini bir görüntüyle değiştirmenize olanak tanır. Resimli madde işaretleri, küçük boyutlarda okunabilirliğini koruyan basit görüntülerde, örneğin simgelerde veya küçük saydam PNG dosyalarında en iyi şekilde çalışır.

{{% alert color="info" title="Note" %}}
İdeal olarak, normal madde işareti simgesini bir görüntüyle değiştirmeyi planlıyorsanız, şeffaf arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özel madde işareti sembolleri olarak iyi çalışır.

Görselin çok küçük bir boyuta ölçeklendirileceğini unutmayın. Bu nedenle, bir listede madde işareti olarak kullanıldığında net ve görsel olarak etkili kalan bir görsel seçmenizi şiddetle öneririz.
{{% /alert %}}

Resimli bir madde işareti oluşturmak için bir görüntüyü [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) koleksiyonuna ekleyin ve döndürülen görüntü nesnesini [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) özelliğine atayın. Görüntüyü atamadan önce [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) değerini [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde "image.png" var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Bu C# kodu, bir slaytta resimli madde işaretleri oluşturmayı gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Sonuç:

![Resimli madde işaretleri](picture_bullets.png)

## **Çok Seviyeli Liste Oluşturma**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) özelliğini kullanarak liste öğelerini farklı seviyelere yerleştirin. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe bir seviyedir ve bu şekilde devam eder.

Aşağıdaki C# kodu, çok seviyeli bir madde işaretli liste oluşturmayı gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Sonuç:

![Çok seviyeli liste](multilevel_list.png)

## **Mevcut Bir Listeyi Değiştirme**

Mevcut bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı erişin ve [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

Aşağıdaki C# kodu, bir metin çerçevesindeki ilk paragrafı numaralı bir liste stiline dönüştürür:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Gerçek Madde İşareti Değerlerini Okuma**

Sunum içeriğini çıkarırken, liste işaretçilerini paragraf metniyle birlikte tutun. Gerçek madde işareti biçimini elde etmek için [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) yöntemini çağırın ve [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) özelliğine erişin. [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) değerini okumadan önce [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) özelliğini kontrol edin.

Numaralı listeler için bu üç değeri ayırt edin:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) formatı belirler; örneğin nokta ile biten Arap rakamları veya küçük harfler.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) numaralı paragraf grubunun başlangıç numarasını belirler.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) belirli bir paragraf için biçimlendirilmiş işaretçiyi döndürür. Örneğin, 5'ten başlayan bir listede ikinci öğe `6.` döndürür.

[Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) özelliğini her paragrafta koruyarak iç içeleme seviyesini saklayın. Gerçek işaretçi tam hiyerarşiyi kodlamaz: iç içe bir öğe `c.` döndürebilir, `6.c.` gibi birleşik bir etiket yerine.

Aşağıdaki bağımsız örnek, listeler oluşturur, bir sunuma kaydeder ve sunuyu yeniden yükleyerek her paragrafın metnini, derinliğini, madde işareti tipini ve gerçek değerini raporlar. Küçük mavi resim işareti, satır içi SVG'den oluşturulur.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Harici bir görüntü dosyası olmadan bir resim işareti oluştur.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

Kaynak listeler aşağıda gösterilmiştir.

![5'ten başlayan listeler, iç içe harf ve Roma rakamı öğeleri, bir sembol işareti, madde işareti olmayan bir paragraf ve mavi resim işareti](actual_bullet_values.png)

Rapor, PowerPoint'te gösterilen işaretçileri eşleştirir:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType.None ve BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) için, [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) boş bir dize yerine `null` döndürür. Bu tipleri ayrı ayrı ele alın: ilki işaretçi içermez, ikincisi ise madde işareti görüntüsünün ayrı olarak çıkarılmasını gerektirir. Bir resim madde işareti, yalnızca metin işaretçisini çıkararak yeniden oluşturulamaz.

## **SSS**

**Madde işaretli ve numaralı listeler PDF veya görüntülere dışa aktarılabilir mi?**

Evet. Aspose.Slides, hedef format ilgili metin düzeni ve madde işareti özelliklerini desteklediğinde liste biçimlendirmesini korur.

**Mevcut sunumlarda listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler Latin dışı metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, böylece çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyacınız olan karakterleri desteklediğinden emin olun.