---
title: ".NET'te Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme"
linktitle: "Listeleri Yönet"
type: docs
weight: 70
url: /tr/net/manage-lists/
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
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturacağınızı ve biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint ve OpenDocument sunumlarında maddeli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyindeki liste ayarlarına erişmek için [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/paragraphformat/) özelliğini kullanın. Ana giriş noktası, bir [IBulletFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/) nesnesi döndüren [IParagraphFormat.Bullet](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/bullet/) özelliğidir. Bu nesne ile madde tipini, sembolünü, resmini, rengini, boyutunu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale şunları gösterir:

- özel bir sembolle maddeli bir liste oluşturma
- resimli madde oluşturma
- paragraf derinliğini ayarlayarak çok seviyeli bir liste oluşturma
- numaralı bir liste oluşturma
- var olan bir sunumdaki liste biçimlendirmesini inceleme ve değiştirme

## **Maddeli Liste Oluşturma**

Maddeli bir liste oluşturmak için, bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) içine [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) nesneleri ekleyin ve [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/) değerini [BulletType.Symbol](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın. Ardından madde görünümünü kontrol etmek için [IBulletFormat.Char](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/color/) ve [IBulletFormat.Height](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/height/) değerlerini belirleyebilirsiniz.

Aşağıdaki C# kodu, bir slaytta maddeli bir liste nasıl oluşturulacağını gösterir:

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

![Sembol maddeler](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Öğelerin sırası önemli olduğunda numaralı listeler kullanın. [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/) değerini [BulletType.Numbered](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın. Ayrıca [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstyle/) ile bir numaralandırma biçimi seçebilir veya listenin 1 yerine başka bir değerden başlamasını istiyorsanız [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstartwith/) değerini belirleyebilirsiniz.

Aşağıdaki C# kodu, bir slaytta numaralı bir liste nasıl oluşturulacağını gösterir:

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

![Numaralı maddeler](numbered_bullets.png)

## **Resimli Madde Oluşturma**

Aspose.Slides, normal bir madde simgesini bir görüntüyle değiştirmenize olanak tanır. Resimli maddeler, küçük boyutta bile okunaklı kalan basit görüntülerle, örneğin simgeler veya küçük saydam PNG dosyalarıyla en iyi şekilde çalışır.

{{% alert color="primary" %}}
İdeal olarak, normal madde simgesini bir görüntüyle değiştirmeyi planlıyorsanız, şeffaf arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özelleştirilmiş madde sembolleri olarak iyi çalışır.

Görüntünün çok küçük bir boyuta ölçeklendirileceğini unutmayın. Bu nedenle, bir listede madde olarak kullanıldığında net ve görsel olarak etkili kalan bir görüntü seçmenizi güçlü bir şekilde öneririz.
{{% /alert %}}

Resimli madde oluşturmak için, bir görüntüyü [Presentation.Images](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/images/) koleksiyonuna ekleyin ve döndürülen görüntü nesnesini [IBulletFormat.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/picture/) özelliğine atayın. Görüntüyü atamadan önce [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/) değerini [BulletType.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde "image.png" adlı bir dosya var:

![Maddeler için bir resim](picture_for_bullets.png)

Aşağıdaki C# kodu, bir slaytta resimli maddeler nasıl oluşturulacağını gösterir:

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

![Resimli maddeler](picture_bullets.png)

## **Çok Seviyeli Liste Oluşturma**

Liste öğelerini farklı seviyelere yerleştirmek için [IParagraphFormat.Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/depth/) özelliğini kullanın. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe bir seviyedir ve bu şekilde devam eder.

Aşağıdaki C# kodu, çok seviyeli maddeli bir liste nasıl oluşturulacağını gösterir:

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

![Çok seviyeli liste](multilevel_list.png)

## **Var Olan Bir Listeyi Değiştirme**

Var olan bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı erişin ve onun [IParagraphFormat.Bullet](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/bullet/) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

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

**Maddeli ve numaralı listeler PDF veya görüntülere dışa aktarılabilir mi?**

Evet. Hedef format ilgili metin düzeni ve madde özelliklerini desteklediğinde Aspose.Slides, liste biçimlendirmesini korur.

**Var olan sunumlardaki listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, onun [IParagraphFormat.Bullet](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/bullet/) ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler Latin dışı metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir; bu sayede çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyacınız olan karakterleri desteklediğinden emin olun.