---
title: .NET'te Sunum Metnini Biçimlendirme
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/net/text-formatting/
keywords:
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürme
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitlemesi
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarları gibi konuları kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır‑bazlıdır. Kalın bölümleri seçen örnekler, etkili biçimlendirmeyi, kalıtsal kalın biçimlendirmeyi de içerir:

![Örnek metin](sample_text.png)

Gerçek metin veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için, [Metin Ara ve Değiştir](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragrafın varsayılan vurgulama rengini ayarlamak için [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) kullanın veya tek tek metin bölümleri için [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Tek tek bölümlerdeki belirli vurgulama renkleri bu varsayılanın üzerine geçer:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Paragrafın tamamı için vurgulama rengini ayarla.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağını gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Metin kısmı için vurgulama rengini ayarla.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

Bir metin çerçevesindeki paragraf hizalamasını ayarlamak için [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) kullanın. Değer, ortalanmış, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamayı gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Paragrafın hizalamasını ortaya ayarla.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçindeki Yazı Tiplerini Hizala**

Bir satır içinde farklı yazı tipi boyutlarına sahip metin bölümlerini dikey olarak hizalamak için [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) kullanın. Bu ayar tüm paragrafı etkiler ve her satırdaki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 puanda, farklı bir yazı tipi hizalamasıyla içerir. Arial kullanır, otomatik sığdırma ve kaydırmayı devre dışı bırakır ve tek satır için çerçeveleri yeterince büyük tutar:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Sonuç:

![Alt Çizgi, Üst, Orta ve Alt yazı tipi hizalama karşılaştırması](font_alignment.png)

Yazı tipi hizalaması, yazı tipi ölçümlerine dayanır; bu nedenle tek tek harflerin görünür kenarları kesin olarak aynı hizada olmayabilir. Örnek, üst harf ve bir descender içerir ve alt çizgi ile alt hizalama arasındaki farkı göstermeye yardımcı olur. Yazı tipi bulunabilirliği ve ikame, kullanılan karakterler ve yazı tipi boyutları sonucu etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da düzeni etkiler; modları karşılaştırırken aynı yazı tiplerini ve düzen ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ve metin bloğunu şekil içinde dikey konumlandıran [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) ayarlarından farklıdır. [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) ile uygulanan süperskript ve altyazı biçimlendirmesi, paragraf satırlarının alt çizgisine göre bireysel bölümleri kaydırır, yazı tipi hizalaması ayarlamaz.

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) üzerinden atanan rengin alfa bileşeni ile kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, %0‑255 ölçeğinde bir ARGB alfa kanal değeri olup şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflık uygulamayı gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Metin için yarı saydam siyah doldurma ayarla.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için şeffaflık uygulamayı gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Metin kısmının şeffaflığını ayarla.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarla**

Bir metin kutusundaki karakterler arasındaki aralığı genişletmek veya sıkıştırmak için [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) kullanın. Örnekler 3 puanlık bir aralık ekler; negatif değerler metni sıkıştırır.

Aşağıdaki C# kodu, **tüm paragraf** içinde karakter aralığını nasıl genişleteceğini gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Karakter aralığını genişlet.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** içinde karakter aralığını nasıl genişleteceğini gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
        portion.PortionFormat.Spacing = 3;  // Karakter aralığını genişlet.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırak**

Bazı durumlarda, Aspose.Slides tarafından oluşturulan metin, PowerPoint'te gösterilen aynı metinden biraz daha sıkı görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir; hatta yazı tipi geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda çıktıyı PowerPoint'e daha yakın hâle getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) değerini gerçek yazı tipi boyutundan daha büyük bir değere ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusuna sahip "presentation.pptx" dosyasını gerektirir. Etkili yazı tipi adlarını, kalıtsal fontları da dahil olmak üzere kontrol eder ve Roboto kullanan bölümler için 100 puanlık bir eşik belirler. Bu, 100 puandan küçük puntoya sahip eşleşen bölümler için kerning'i devre dışı bırakır:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Eşiğin altındaki eşleşen metinler için bu ayar kerning'i önler ve PowerPoint'in bu özel davranıştan etkilenen fontlar için görsel çıktısını Aspose.Slides ile uyumlu hâle getirmeye yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf düzeyinde [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) veya tek tek bölümlerde [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman, kalın, italik ve noktalı altı çizili olarak ayarlar. Tek tek bölümlerdeki belirli biçimlendirme bu varsayılanların üzerine geçer:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Paragraf için yazı tipi özelliklerini ayarla.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik ve noktalı altı çizili uygular:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Metin kısmı için yazı tipi özelliklerini ayarla.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Sonuç:

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarla**

Bir şekil içinde önceden tanımlı bir metin yönelimi ayarlamak için [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) kullanın.

Aşağıdaki kod örneği, şeklin içindeki metin yönelimini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Sonuç:

![Metin döndürme](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarla**

Bir [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) için özel bir döndürme açısı ayarlamak için [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) kullanın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini saat yönünde 3 derece döndürür:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Sonuç:

![Özel metin döndürme](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) ve [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır aralığını satır yüksekliğinin yüzdesi olarak belirtir.
* Negatif bir değer, satır aralığını puan olarak belirtir.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200'ü (çift satır aralığı) olarak ayarlar:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Satır Kesilmesini Kontrol Et**

Dar metin bloklarında ve Latin ile Doğu Asya metninin karıştığı sunumlarda paragraf satır kesme kuralları faydalıdır. Aşağıdaki özellikler [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) içinde bulunur; bu yüzden tüm paragrafı etkiler:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) Latin satır kesme kurallarını kontrol eder. Karışık metinde değiştirmek, bitişik Doğu Asya metni ve noktalama işaretlerinin nerede kaydırılacağını da etkileyebilir.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) Doğu Asya satır kesme kurallarını, satır başı ve sonundaki karakter kısıtlamalarını içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik kaydırmayı etkinleştiren [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) işlevini değiştirmez. Kaydırma gerçekleştiğinde düzeni etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır zorlar.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme özelliğini de açıkça ayarlar ve "line_breaking.pptx" olarak kaydeder. Herhangi bir kuralı denemek için, diğer ayarları sabit tutarak o özelliğin değerini değiştirin. Örnek, 24 puan Arial ve SimSun kullanır, çerçeve genişliği 160 puan ve yatay metin çerçeve kenar boşlukları sıfırdır. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) olarak ayarlanmıştır; böylece metin boyutu ve çerçeve boyutları sabit kalır.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Askıya Alınan Noktalama İşaretlerini Kontrol Et**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) uygun noktalama işaretlerinin metin satırının sağ kenarının ötesine uzanmasına izin verir; bir sonraki satırı işgal etmez. Tüm paragraf için geçerlidir ve askıya alınan girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde askıya alınan noktalama işaretini etkinleştirir ve "hanging_punctuation.pptx" olarak kaydeder. 24 puan Arial ve yatay metin çerçeve kenar boşlukları sıfır iken, son nokta "sentence" kelimesinden sonra kalır ve sağ metin kenarının ötesine uzanır. Karşılaştırma için özelliği [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) olarak ayarlayın: bu ayarlarla nokta ayrı bir satırda yer alır. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılmıştır; böylece kullanılabilir genişlik sabit kalır.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Her noktalama işareti askıya alınamaz. Yukarıda açıklanan [yazı tipi ve düzen koşulları](#control-line-breaking) bu karşılaştırmaya da uygulanır: yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) bir metin konteynerinin sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülmesini, taşmasını veya şeklin otomatik olarak yeniden boyutlandırılmasını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine göre yeniden boyutlandıracak şekilde yapılandırır ve sonucu "autofit_type.pptx" olarak kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Otomatik kaydırma sonrası satır sayısını saymak ve metin ya da şekil genişliğinin sonucu nasıl değiştirdiğini görmek için, [Renderlanan Satırları Say](/slides/tr/net/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin konteynerini aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) bir metnin bir şekil içinde dikey olarak nerede konumlandırılacağını tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Metin Sekmelerini Ayarla**

Paragrafta sek duraklarını yapılandırmak için [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) ve [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) kullanın. Aşağıdaki örnek, varsayılan sek aralığını 100 puana ayarlar ve 30 puanda sol hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Denetleme Dilini Ayarla**

Aspose.Slides, metin bölümü için denetleme dilini ayarlamanızı sağlayan [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) sunar. Denetleme dili, PowerPoint'te yazım ve dil bilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir metin kutusuna ve en az bir paragrafa sahip "presentation.pptx" dosyasını gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, font olarak SimSun ayarlar ve denetleme dili olarak Basitleştirilmiş Çince (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Denetleme dilini Basitleştirilmiş Çince olarak ayarla.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Varsayılan Dili Ayarla**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlayabilirsiniz. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi kullanan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dili olarak `en-US` yazdırır.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Yeni bir dikdörtgen şekil ekle ve metin ekle.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// İlk bölümün dilini kontrol et.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Varsayılan Metin Stili Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesi uygulamak için [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) kullanın.

Aşağıdaki örnek, yeni bir sunumdaki üst düzey paragraflar için varsayılan olarak 14 puan kalın bir font ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha belirgin bir biçimlendirme geçersiz kılmadıkça bu varsayılanları devralabilir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Üst düzey paragraf biçimini al.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **All-Caps Efektiyle Metni Çıkar**

PowerPoint'te **All Caps** font etkisini uygulamak, metni slaytta büyük harfle gösterir ancak orijinal olarak küçük harfle yazılmıştır. Aspose.Slides ile böyle bir metin bölümü alındığında, kitaplık metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusuna sahip "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, All Caps etkisi uygulanmış "Hello, Aspose!" içerir; aşağıda gösterildiği gibidir.

![All Caps efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tabloda metni nasıl değiştiririm?**

Bir slayttaki tabloda metni değiştirmek için [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) kullanın. Hücreleri döngüyle gezerek her hücreyi [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) aracılığıyla güncelleyin ve paragraf biçimlendirmesini [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) ile ayarlayın.

**PowerPoint slaytındaki metne nasıl bir degrade renk uygularım?**

Metne bir degrade renk uygulamak için [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) kullanın. [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) değerini [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.