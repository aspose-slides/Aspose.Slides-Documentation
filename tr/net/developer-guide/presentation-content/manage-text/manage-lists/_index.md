---
title: ".NET'te Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönet"
linktitle: "Listeleri Yönet"
type: docs
weight: 70
url: /tr/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - madde işareti
  - madde işaretli liste
  - numaralı liste
  - sembol madde işareti
  - resim madde işareti
  - özel madde işareti
  - çok seviyeli liste
  - madde işareti oluştur
  - madde işareti ekle
  - liste ekle
  - PowerPoint
  - OpenDocument
  - sunum
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturup biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftir.

Paragraf düzeyindeki liste ayarlarına erişmek için [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/paragraphformat/) özelliğini kullanın. Ana giriş noktası [IParagraphFormat.Bullet](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/bullet/)'dır ve bir [IBulletFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/) nesnesi döndürür. Bu nesne ile madde işareti türünü, sembolünü, resmini, rengini, boyutunu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale aşağıdakileri gösterir:

- özel bir sembol ile madde işaretli liste oluşturma
- resim madde işareti oluşturma
- paragraf derinliğini ayarlayarak çok düzeyli liste oluşturma
- numaralı liste oluşturma
- mevcut bir sunumda liste biçimlendirmesini inceleme ve değiştirme

## **Madde İşaretli Liste Oluştur**

Madde işaretli bir liste oluşturmak için, bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) içine [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) nesneleri ekleyin ve [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/)'ı [BulletType.Symbol](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın. Ardından madde işaretinin görünümünü kontrol etmek için [IBulletFormat.Char](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/color/), ve [IBulletFormat.Height](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/height/) değerlerini ayarlayabilirsiniz.

Aşağıdaki C# kodu, bir slaytta madde işaretli liste oluşturmayı gösterir:

```csharp
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

## **Numaralı Liste Oluştur**

Öğelerin sırası önemli olduğunda numaralı listeler kullanın. [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/)'ı [BulletType.Numbered](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın. Ayrıca, [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstyle/) ile bir numaralandırma biçimi seçebilir veya listenin 1 dışında bir değerden başlamasını istediğinizde [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstartwith/)'ı ayarlayabilirsiniz.

Aşağıdaki C# kodu, bir slaytta numaralı liste oluşturmayı gösterir:

```csharp
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

## **Resim Madde İşareti Oluştur**

Aspose.Slides, normal bir madde işareti simgesini bir görüntü ile değiştirmenize olanak tanır. Resim madde işaretleri, küçük boyutta okunabilirliğini koruyan basit görseller, örneğin simgeler veya küçük şeffaf PNG dosyaları ile en iyi şekilde çalışır.

{{% alert color="primary" %}}
İdealde, normal madde işareti simgesini bir resimle değiştirmeyi planlıyorsanız, şeffaf arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özel madde işareti simgeleri olarak iyi çalışır.

Görselin çok küçük bir boyuta ölçekleneceğini akılda tutun. Bu nedenle, listede madde işareti olarak kullanıldığında net ve görsel olarak etkili kalan bir görsel seçmenizi şiddetle tavsiye ederiz.
{{% /alert %}}

Resim madde işareti oluşturmak için, bir görüntüyü [Presentation.Images](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/images/) içine ekleyin ve döndürülen görüntü nesnesini [IBulletFormat.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/picture/) atayın. Görüntüyü atamadan önce [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/)'ı [BulletType.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde "image.png" var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki C# kodu, bir slaytta resim madde işaretleri oluşturmayı gösterir:

```csharp
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

![Resim madde işaretleri](picture_bullets.png)

## **Çok Düzeyli Liste Oluştur**

Liste öğelerini farklı seviyelere yerleştirmek için [IParagraphFormat.Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/depth/) kullanın. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe bir seviyedir ve bu şekilde devam eder.

Aşağıdaki C# kodu, çok düzeyli bir madde işaretli liste oluşturmayı gösterir:

```csharp
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

![Çok düzeyli liste](multilevel_list.png)

## **Mevcut Bir Listeyi Değiştir**

Mevcut bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı erişin ve onun [IParagraphFormat.Bullet](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/bullet/) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

Aşağıdaki C# kodu, bir metin çerçevesindeki ilk paragrafı numaralı liste stiline dönüştürür:

```csharp
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

## **SSS**

**Madde işaretli ve numaralı listeler PDF veya görüntülere dışa aktarılabilir mi?**

Evet. Aspose.Slides, hedef format ilgili metin düzeni ve madde işareti özelliklerini desteklediğinde liste biçimlendirmesini korur.

**Mevcut sunumlardaki listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, IParagraphFormat.Bullet ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler Latin dışı metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, bu yüzden çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyacınız olan karakterleri desteklediğinden emin olun.