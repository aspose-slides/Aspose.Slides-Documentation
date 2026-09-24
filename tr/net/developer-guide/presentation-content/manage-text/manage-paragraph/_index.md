---
title: .NET'te PowerPoint Metin Paragraflarını Yönetme
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
- metni HTML'ye
- paragrafı HTML'ye
- paragrafı görüntüye
- metni görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntülerini nasıl oluşturup biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) şekil içindeki metin konteynerini temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf‑düzeyindeki biçimlendirmeye erişim sağlar.
* [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) bir paragraftaki metin çalışmasını (run) temsil eder. Her bölüm kendi metnine ve karakter‑düzeyindeki biçimlendirmeye sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmelerle metin içerebilir.

## **Paragraflar Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm İçeren Paragraflar Oluşturma**

Aşağıdaki adımlar, her biri üç bölüm içeren üç paragraf ile bir metin çerçevesi oluşturur:

1. Presentation sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/)ʼine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki tane daha [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) nesnesi ekleyin.
6. Her paragrafın üç bölüm içermesi için yeterli [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.
7. Her bölümün metnini ayarlayın.
8. Karakter düzeyinde biçimlendirmeyi [IPortion.PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/portionformat/) üzerinden uygulayın.
9. Değiştirilen sunumu kaydedin.

Bu C# örneği adımları uygular:

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

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralar ilgili öğeleri taramayı kolaylaştırır. Aspose.Slides'da liste ayarları [IBulletFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/) aracılığıyla tanımlanır.

1. Presentation sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Seçili slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/)ʼine erişin.
5. Metin çerçevesinden varsayılan paragrafı kaldırın.
6. Sembol madde işareti için bir [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) oluşturun.
7. [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/) özelliğini [BulletType.Symbol](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın ve madde işareti karakterini belirleyin.
8. Paragraf metnini, girintiyi, madde işareti rengini ve yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. İkinci paragrafı oluşturun ve [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/) özelliğini [BulletType.Numbered](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın.
11. Numaralı madde işareti stilini yapılandırın ve paragrafı metin çerçevesine ekleyin.
12. Sunumu kaydedin.

Bu C# örneği bir sembol madde işareti ve bir numaralı madde işareti oluşturur:

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

### **Resim Madde İşaretlerini Kullanma**

Resim madde işaretleri, bir sembol veya sayı yerine özel bir görüntü kullanmanızı sağlar.

1. Presentation sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin ve onun [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/)ʼine erişin.
4. Metin çerçevesinden varsayılan paragrafı kaldırın.
5. Madde işareti görselini yükleyin ve sunumun görüntü koleksiyonuna bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [IBulletFormat.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/type/) özelliğini [BulletType.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/bullettype/) olarak ayarlayın.
8. Görüntüyü [IBulletFormat.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/picture/) aracılığıyla atayın ve madde işareti yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. Değiştirilen sunumu kaydedin.

Bu C# örneği bir resim madde işareti oluşturur:

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

Paragrafları bir listenin farklı seviyelerine yerleştirmek için [IParagraphFormat.Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/depth/) ayarlayın. En üst seviye `0` derinliğe sahiptir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin ve metin çerçevesinden varsayılan paragrafı temizleyin.
3. Dört paragraf oluşturun ve madde işareti sembollerini yapılandırın.
4. Bu paragrafların [IParagraphFormat.Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/depth/) değerlerini sırasıyla `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu C# örneği dört seviyeli bir madde işaretli liste oluşturur:

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

Numaralı bir paragraf için gösterilecek ilk sayıyı ayarlamak için [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstartwith/) kullanın.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) oluşturun ve bir slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
2. Şeklin metin çerçevesinden varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. İlgili paragraflar için [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstartwith/) özelliğini sırasıyla `2`, `3` ve `7` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu C# örneği her paragraf için özel bir başlangıç numarası atar:

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

## **Paragraf Düzeni ve Son Özelliklerini Kontrol Etme**

### **İlk Satır Girintisi Ayarlama**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) özelliği bir paragrafın ilk satır girintisini kontrol eder. Bu özellik yalnızca ilk satırı paragrafın sol kenar boşluğuna göre kaydırır. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak gerektiğinde [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) kullanın. Yalnızca ilk satırı taşımak istediğinizde ise [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) kullanın.

Aşağıdaki örnek birkaç paragraf oluşturur ve farklı [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) değerleri uygulayarak ilk satır girintisinin paragraf düzenini nasıl etkilediğini gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/)ʼine erişin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve bunların farklı [Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) değerlerini ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilen sunumu kaydedin.

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

Asılı girinti, ilk satırın kalan satırlardan daha sola başlamasıyla oluşan bir paragraf düzenidir. Aspose.Slides’da bu etkiyi [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) özelliğiyle oluşturursunuz. `Indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırırsınız.

Gerçekte, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) paragraf gövdesinin sol konumunu, [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) ise ilk satırın bu kenar boşluğuna göre konumunu belirler. Asılı girinti oluşturmak için pozitif bir `MarginLeft` ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme bibliyografiler, referanslar, sözlük girişleri ve satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için yararlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/)ʼine erişin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için pozitif bir [MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) değeri ayarlayın.
6. Asılı girinti etkisini yaratmak için negatif bir [Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) değeri atayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilen sunumu kaydedin.

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

### **Paragraf Sonu Çalışma Özelliklerini Ayarlama**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/endparagraphportionformat/) özelliği paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek ikinci paragrafın son işaretine bir yazı tipi boyutu ve Latin yazı tipi atar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yükleyin ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin ve varsayılan paragrafı temizleyin.
3. İki paragraf oluşturun ve onlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/portionformat/) oluşturun.
5. [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/fontheight/) ve [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/latinfont/) ayarlarını yapın.
6. Biçimi [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/endparagraphportionformat/)ʼa atayın ve sunumu kaydedin.

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

## **Oluşturulan Satırları Sayma**

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getlinescount/) kullanılarak bir paragrafın metin yerleşimi sonrası (otomatik kaydırma dahil) kapladığı satır sayısı sayılabilir. Bu, sunum şablonlarındaki metin uzunluğunu ve düzenini kontrol ederken yararlıdır.

Bir paragraf, [ITextFrame.Paragraphs](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/paragraphs/) koleksiyonundaki bir öğedir ve birden çok oluşturulmuş satır kaplayabilir. Paragraf içinde açık bir satır sonu karakteri (`\n` gibi) yeni bir satır başlatır ve yeni bir paragraf oluşturmaz. Otomatik kaydırma, mevcut genişliğe göre satırları oluşturur; metne ek bir satır sonu karakteri eklemez. Bu nedenle, paragraf sayısını veya satır‑sonu karakterlerini saymak, oluşturulan satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şeklin genişliğini daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Kaydırma açıktır ve otomatik sığdırma kapalıdır; böylece şekil genişliği kaydırmayı kontrol eder ve metin otomatik olarak küçülmez. Şekil boyutları puan cinsindendir. Son olarak örnek başka bir paragraf ekler ve metin çerçevesi üzerindeki satır sayılarını toplar.

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

Bu metin ve boyutlarla, şekli daraltmak satır sayısını artırırken, kısa dizeye değiştirmek azaltır. Kesin sayılar, kullanılan yazı tipi, yedekleme, yazı tipi boyutu, kenar boşlukları, girinti, kaydırma ve otomatik sığdırma ayarlarına göre değişebilir. Şablonu kontrol ederken hedef ortamda kullanılacak yazı tiplerini ve yerleşim ayarlarını göz önünde bulundurun.

Satır sayısı yalnız başına metnin kapsayıcısını aşıp aşmadığını belirlemez. Kullanılabilir yükseklik, satır yüksekliği, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; kaydırma kapalıyken tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçe/Dışa Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphcollection/addfromhtml/) kullanılarak HTML işaretlemesi, bir metin çerçevesindeki paragraflara ve bölümlere dönüştürülür.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Bir slayta erişin ve bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/)ʼine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dosyasını okuyun.
5. HTML dizesini [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphcollection/addfromhtml/) metoduna gönderin.
6. Değiştirilen sunumu kaydedin.

Bu C# örneği HTML'i bir metin çerçevesine aktarır:

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

### **Paragraf Metnini HTML Olarak Dışa Aktarma**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphcollection/exporttohtml/) kullanılarak seçilen paragraf aralığı HTML olarak dışa aktarılır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) örneği oluşturun ve istediğiniz sunumu yükleyin.
2. Slayta erişin ve metni içeren [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) öğesini bulun.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/)ʼine erişin.
4. Başlangıç paragraf indeksi ve dışa aktarılacak paragraf sayısını belirterek [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphcollection/exporttohtml/) metodunu çağırın.
5. Dönen HTML dizesini bir dosyaya yazın.

Bu C# örneği ilk metin şeklinin tüm paragraflarını dışa aktarır:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Paragrafı Görüntü Olarak Oluşturma**

[IParagraph.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getimage/) tek bir paragrafı doğrudan işler ve bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) döndürür. Sonucu [IImage.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/save/) ile bir dosyaya veya akışa kaydedebilirsiniz; kapsayıcı şekli ayrıca oluşturmanıza ya da bitmap’i elle kırpmanıza gerek yoktur.

[IParagraph.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getimage/) paragraf bulunamazsa, geçerli bir çizim sınırı yoksa veya çizilemezse `null` dönebilir. Kaydetmeden önce sonucu kontrol edin ve görüntüyü kullanımdan sonra dispose edin.

#### **Paragrafları Varsayılan Ölçekte Oluşturma**

sample.pptx adlı bir sunum dosyamız olduğunu ve bir slayt içinde ilk şeklin üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek ikinci paragrafı normal bir metin şekli içinde varsayılan ölçekte oluşturur ve sonucu PNG formatında kaydeder. `using` ifadesi, görüntünün doğru şekilde dispose edilmesini sağlar.

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

#### **Tablo Hücresinde Ölçekli Paragraf Oluşturma**

[IParagraph.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getimage/) metodunun `float scaleX` ve `float scaleY` parametrelerini kabul eden aşırı yüklemesini kullanarak yatay ve düşey ölçek faktörlerini ayarlayabilirsiniz. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin iki katı ve yüksekliğinin iki katı olacak şekilde işler ve sonucu PNG görüntüsü olarak kaydeder.

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

`1` ölçek faktörü ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` ayarlanırsa, görüntünün genişliği ve yüksekliği yaklaşık olarak varsayılan boyutların iki katı olur; bu da piksel sayısının dört katı demektir. Daha büyük faktörler genellikle yakınlaştırma ya da yüksek çözünürlük çıktısı için daha keskin metin sağlar, ancak bellek kullanımını ve dosya boyutunu artırır. `1`’in altındaki faktörler daha az detaylı, daha küçük görüntüler üretir. Paragrafın en‑boy oranını korumak için aynı faktörleri kullanın; farklı yatay ve düşey faktörler çıktıyı bağımsız olarak uzatır.

[Tüm şekli render etmek] için [IShape.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getimage/) hâlâ yararlıdır; çünkü bu yöntem şeklin doldurmasını, kenarlığını veya diğer görsel bağlamını da içerir. Yalnızca paragraf görüntüsü için [IParagraph.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getimage/) kullanılmalıdır.

## **SSS**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**  
Evet. [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/wraptext/) özelliğini `false` olarak ayarlayarak kaydırmayı devre dışı bırakabilirsiniz; böylece satırlar metin çerçevesinin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**  
[İParagraph.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getrect/) metodunu kullanarak paragrafın sınırlayıcı dikdörtgenini alabilirsiniz. Bireysel bir bölümün sınırlarını elde etmek için [IPortion.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/getrect/) kullanılır.

**Paragraf hizalaması (sol, sağ, ortalanmış veya iki yana yaslanmış) nerede kontrol edilir?**  
[IParagraphFormat.Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/alignment/) bir paragraf‑düzeyi ayardır ve bölüm‑düzeyi biçimlendirmeden bağımsız olarak bütün paragrafı etkiler.

**Paragrafın bir bölümü için düzeltme dilini ayarlayabilir miyim?**  
Evet. Bireysel bölümler için [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/languageid/) ayarlanabilir; böylece tek bir paragrafta birden fazla dilde metin bulunabilir.