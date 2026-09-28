---
title: Sunum Metnini .NET'te Biçimlendir
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
- font özellikleri
- font ailesi
- metin dönüşü
- dönüş açısı
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
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Fontları, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, font özellikleri, dönüş, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sekme durakları ve dil ayarlarını kapsar.

Varsayılan olarak, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytının ilk şekli bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır‑tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Düz metin veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Metin Arama ve Değiştirme](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarla**

[IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaultportionformat/) kullanarak bir paragraf için varsayılan vurgulama rengini ayarlayabilir veya bireysel metin bölümleri için [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/highlightcolor/) kullanabilirsiniz.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerde belirtilen vurgulama renkleri bu varsayılanın üzerine yazılır:

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

Aşağıdaki kod örneği, **kalın bir fonta sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

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
        // Metin bölümü için vurgulama rengini ayarla.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/alignment/) kullanarak bir metin çerçevesi içinde paragraf hizalamasını ayarlayabilirsiniz. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Paragrafın hizalamasını merkeze ayarla.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin İçin Şeffaflığı Ayarla**

Metin şeffaflığı, [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/fillformat/) atanmış rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde, `alpha = 50` 0‑255 ölçeğinde bir ARGB alfa kanal değeri olup, şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflık uygulamayı gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Metin için yarı saydam siyah dolgu ayarla.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir fonta sahip metin bölümleri** için şeffaflık uygulamayı gösterir:

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
        // Metin bölümünün şeffaflığını ayarla.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarla**

[IBasePortionFormat.Spacing](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/spacing/) kullanarak bir metin kutusunda karakterler arasındaki boşluğu artırabilir veya azaltabilirsiniz. Örnekler 3 puanlık boşluk ekler; negatif değerler metni sıkıştırır.

Aşağıdaki C# kodu **tüm paragraf** içinde karakter aralığını artırmayı gösterir:

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

Aşağıdaki kod örneği **kalın bir fonta sahip metin bölümleri** içinde karakter aralığını artırmayı gösterir:

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

### **Belirli Fontlar İçin Kerning'i Devre Dışı Bırak**

Bazi durumlarda, Aspose.Slides tarafından oluşturulan metin, PowerPoint'te gösterilen aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in belirli fontlar için kerning verisini görmezden gelmesi durumunda gerçekleşir; font geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu gibi durumlarda oluşturulan çıktıyı PowerPoint'e yaklaştırmak için, etkilenen fontu kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/kerningminimalsize/) değerini gerçek font boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slaytın ilk şekli olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir. Etkili font adlarını, kalıtılan fontlar dahil, kontrol eder ve Roboto kullanan bölümler için 100 puanlık bir eşik ayarlar. Bu, 100 puanın altındaki font boyutuna sahip eşleşen bölümler için kerning'i devre dışı bırakır:

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

Eşiğin altındaki eşleşen metinler için bu ayar kerning'i engeller ve bu PowerPoint’e özgü davranıştan etkilenen fontların Aspose.Slides render'ı ile PowerPoint’in görsel çıktısının uyumlu olmasına yardımcı olabilir.

## **Metin Font Özelliklerini Yönet**

Font özellikleri, paragraf seviyesinde [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaultportionformat/) ile ya da bireysel bölümler için [IPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan fontunu 12 puan Times New Roman olarak kalın, italik ve noktalı altı çizili biçimlendirme ile ayarlar. Bireysel bölümlerde belirtilen biçimlendirme bu varsayılanların üzerine yazar.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Paragraf için font özelliklerini ayarla.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Paragraf için font özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik biçim ve noktalı altı çizgi uygular:

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
        // Metin bölümü için font özelliklerini ayarla.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Sonuç:

![Metin bölümleri için font özellikleri](font_properties_for_text_portions.png)

## **Metin Dönüşünü Ayarla**

[ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/textverticaltype/) kullanarak bir şekil içinde önceden tanımlı bir metin yönlendirmesini ayarlayabilirsiniz.

Aşağıdaki kod örneği, şeklin metin yönlendirmesini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/tr/net/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

![Metin dönüşü](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Dönüşü Ayarla**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/rotationangle/) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) için özel bir dönüş açısı ayarlayabilirsiniz.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

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

![Özel metin dönüşü](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spacebefore/) ve [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spacewithin/) sağlar. Bu özellikler aşağıdaki gibi kullanılır:

* Pozitif bir değer, satır aralığını satır yüksekliğinin yüzde olarak belirtmek için kullanılır.
* Negatif bir değer, satır aralığını puan cinsinden belirtmek için kullanılır.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200'ü (iki kat satır aralığı) olarak ayarlar:

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

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metnini karıştıran sunumlarda faydalıdır. Aşağıdaki özellikler [IParagraphFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/) aittir, bu nedenle tüm paragrafı etkiler:

- [LatinLineBreak](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/latinlinebreak/) Latin satır kesme kurallarını kontrol eder. Karışık metinde, bunu değiştirmek yan yana bulunan Doğu Asya metni ve noktalama işaretlerinin nerede kaydırılacağını da etkileyebilir.
- [EastAsianLineBreak](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/eastasianlinebreak/) Doğu Asya satır kesme kurallarını kontrol eder; satırın başındaki ve sonundaki karakterlerle ilgili kısıtlamaları içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik kaydırmayı sağlayan [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/wraptext/) işlevinin yerini almaz. Kaydırma gerçekleştiğinde düzeni etkiler; satır sonu karakterleri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır zorlar.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme özelliğini açıkça ayarlar ve "line_breaking.pptx" olarak kaydeder. Herhangi bir kuralla deneme yapmak için, diğer ayarlar sabit kalırken ilgili özelliğin değerini değiştirin. Örnek, 24 puan Arial ve SimSun fontlarını, 160 puan çerçeve genişliği ve sıfır yatay çerçeve kenar boşluklarıyla kullanır. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/autofittype/) [TextAutofitType.None](https://reference.aspose.com/slides/tr/net/aspose.slides/textautofittype/) olarak ayarlanır, böylece metin boyutu ve çerçeve boyutları sabit kalır.

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

## **Asılı Noktalama İşaretlerini Kontrol Et**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/hangingpunctuation/) uygun noktalama işaretlerinin bir sonraki satırı kaplamadan metin satırının sağ kenarının ötesine uzanmasına izin verir. Tüm paragrafı etkiler ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" olarak kaydeder. 24 puan Arial ve sıfır yatay çerçeve kenar boşluklarıyla, son nokta "sentence" kelimesinin ardından kalır ve sağ metin kenarının ötesine uzanır. Karşılaştırma için özelliği [NullableBool.False](https://reference.aspose.com/slides/tr/net/aspose.slides/nullablebool/) olarak ayarlayın: bu ayarlarda nokta ayrı bir satır alır. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılarak kullanılabilir genişlik sabit tutulur.

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

Her noktalama işareti asılı olamaz. Yukarıda açıklanan [font ve düzen koşulları](#conditions-and-limitations) bu karşılaştırmaya da uygulanır: font, kullanılabilir genişlik, kenar boşlukları veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/autofittype/) metin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine sığacak şekilde yeniden boyutlandırır ve sonucu "autofit_type.pptx" olarak kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Otomatik kaydırmadan sonra satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Render Edilen Satırları Sayma](/slides/tr/net/manage-paragraph/) bölümüne bakın. Satır sayısı tek başına metnin kapsayıcısını aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/anchoringtype/) bir şekil içinde metnin dikey konumunu tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin alt kısmına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Metin Sekme Ayarını Yap**

[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaulttabsize/) ve [IParagraphFormat.Tabs](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/tabs/) kullanarak bir paragrafta sekme duraklarını yapılandırabilirsiniz. Aşağıdaki örnek, varsayılan sekme aralığını 100 puan olarak ayarlar ve 30 puanda sola hizalı bir sekme durak ekler. Bu ayarlar sekme karakteri içeren metni etkiler.

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

## **Düzeltme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanızı sağlayan [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/languageid/) sunar. Düzeltme dili, PowerPoint'te imla ve dil bilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki örnek, ilk slaytın ilk şekli olarak bir metin kutusu içeren ve en az bir paragraf içeren "presentation.pptx" dosyasını gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, fontunu SimSun olarak ayarlar ve Basitleştirilmiş Çince düzeltme dilini (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

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

// Düzeltme dilini Basitleştirilmiş Çinceye ayarla.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Varsayılan Dili Ayarla**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/defaulttextlanguage/) kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metnin varsayılan dilini belirleyebilirsiniz. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi belirleyen bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Metin içeren yeni bir dikdörtgen şekil ekleyin.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// İlk bölümün dilini kontrol edin.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Varsayılan Metin Stili Ayarla**

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/defaulttextstyle/) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir font ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha spesifik bir biçimlendirme üzerine yazılmadıkça bu varsayılanları devralabilir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Üst seviye paragraf biçimini al.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **All-Caps Etkisiyle Metni Çıkar**

PowerPoint'te **All Caps** (Tam Büyük Harf) yazı tipi etkisini uygulamak, metnin slaytta büyük harf olarak görünmesini sağlar; orijinal olarak küçük harfle yazılmış olsa bile. Aspose.Slides ile bu tür bir metin bölümünü aldığınızda, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/tr/net/aspose.slides/textcaptype/) kontrol edin ve değer `All` ise dönen dizeyi büyük harfe çevirin.

Bu örnek, ilk slaytın ilk şekli olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış "Hello, Aspose!" içerir.

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

**Bir slayttaki tablo içindeki metni nasıl değiştiririm?**

Bir slayttaki tablodaki metni değiştirmek için [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) kullanın. Hücreler üzerinde döngü yapın ve her hücreyi [ICell.TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/textframe/) aracılığıyla güncelleyin; paragraf biçimlendirmesini ise [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/paragraphformat/) ile ayarlayın.

**PowerPoint slaytındaki metne nasıl bir renk geçişi (gradient) uygularım?**

Metne bir renk geçişi (gradient) uygulamak için [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/fillformat/) kullanın. [IFillFormat.FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformat/filltype/) değerini [FillType.Gradient](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) olarak ayarlayın ve geçiş duraklarını, yönü ve şeffaflığı yapılandırın.