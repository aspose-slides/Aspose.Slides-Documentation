---
title: .NET'te Sunum Metnini Biçimlendir
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
- metin sekme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stillendirin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, PowerPoint ve OpenDocument sunumlarında metni Aspose.Slides for .NET kullanarak nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin yerleşimi, sek durakları ve dil ayarları ele alınmaktadır.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slayttaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıdaki metni içerir. Hem slayt hem de şekil indeksleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, devralınan kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Bu yöntemi, literal metin ya da düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Metin Arama ve Değiştirme](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarla**

Paragraf için varsayılan vurgulama rengini ayarlamak amacıyla [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) kullanın veya bireysel metin bölümleri için [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerde belirtilen vurgulama renkleri bu varsayılanın üzerine yazar:

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

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

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

Metin çerçevesi içinde paragraf hizalamasını ayarlamak için [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) kullanın. Değer merkezlenmiş, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

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

## **Satır İçinde Yazı Tiplerini Hizala**

Farklı yazı tipi boyutlarına sahip metin bölümlerini aynı satır içinde dikey olarak hizalamak için [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) kullanın. Bu ayar tüm paragraf için geçerlidir ve satır içindeki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 punto boyutlarında içerir ve farklı bir yazı tipi hizalaması kullanır. Arial kullanılır, otomatik sığdırma ve kaydırma devre dışı bırakılır, metin çerçeveleri tek satır için yeterince büyük tutulur.

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

![Alt Çizgi, Üst, Orta ve Alt yazı tipi hizalamasının karışık yazı tipleriyle karşılaştırması](font_alignment.png)

Yazı tipi hizalaması yazı tipi metriklerine dayanır; bu nedenle tek tek harflerin görünen kenarları tam olarak hizalanmayabilir. Örnek, farkı göstermek için bir büyük harf ve bir alt çizgi karakteri içerir. Yazı tipi bulunabilirliği, değişimi, kullanılan karakterler ve yazı tipi boyutları sonucu etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da yerleşimi etkiler; modları karşılaştırırken aynı yazı tipleri ve yerleşim ayarları kullanılmalıdır.

Bu ayar, yatay paragraf hizalamasını kontrol eden [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ve şekil içinde metin bloğunu dikey olarak konumlandıran [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) ayarlarından farklıdır. [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) ile süper ve alt simge biçimlendirmesi, bireysel bölümleri temel çizgiye göre kaydırır; paragraf satırları için yazı tipi hizalaması ayarlamaz.

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) üzerine atanan rengin alfa bileşeni aracılığıyla kontrol edilir. Aşağıdaki örneklerde `alpha = 50` 0–255 aralığındaki bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği **tam paragraf** üzerine şeffaflık uygulamayı gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Metin için yarı şeffaf siyah dolgu ayarla.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** üzerine şeffaflık uygulamayı gösterir:

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

Bir metin kutusundaki karakterler arasındaki aralığı genişletmek ya da sıkıştırmak için [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) kullanın. Aşağıdaki örnekler 3 puan aralık ekler; negatif değerler metni sıkıştırır.

Aşağıdaki C# kodu **tam paragraf** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

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

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

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

Bazen Aspose.Slides tarafından render edilen metin, PowerPoint'te aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in bazı yazı tipleri için kerning verisini yok saymasından kaynaklanabilir; yazı tipi kerning bilgisi içeriyor ve PowerPoint ayarlarında kerning açıksa bile.

Bu durumlarda render edilen çıktıyı PowerPoint'e yakınlaştırmak için, etkilenen yazı tipini kullanan metin bölümlerinde kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) değerini gerçek yazı tipi boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusuna sahip “presentation.pptx” dosyasını gerektirir. Etkili yazı tipi adlarını (devralınanlar dahil) kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değeri belirler. Böylece 100 puandan düşük boyuttaki eşleşen bölümlerde kerning devre dışı bırakılır:

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

Eşik altındaki eşleşen metinler için bu ayar kerning'i engeller ve PowerPoint’in bu yazı tipleri için gösterdiği görsel çıktıya daha yakın bir render elde edilmesine yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf seviyesinde [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) üzerinden veya tek tek bölümler için [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) üzerinden ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman, kalın, italik ve noktalı alt çizgi biçiminde ayarlar. Bireysel bölümlerde açık biçimlendirme bu varsayılanların üzerine yazar:

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

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik ve noktalı alt çizgi uygular:

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
        // Metin bölümü için yazı tipi özelliklerini ayarla.
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

## **Metin Yüksekliği Normalleştirmesini Kontrol Et**

Şablon tipografisini yeniden üretirken ya da karakter yüksekliği farklarını incelerken [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) kullanın. PowerPoint’te normalleştirmeyi etkinleştirmek, bireysel karakterleri dikey olarak uzatır ya da sıkıştırır, böylece metin bölümü içinde görünür yükseklik aynı olur. Farklı yazı tiplerinde metin yüksekliklerinin eşit olacağını garanti etmez.

Özelliği açıkça etkinleştirmek ya da devre dışı bırakmak için [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) ayarlayın. `NullableBool.NotDefined` yerel ayarı unset bırakır; böylece bölüm, örneğin paragrafın [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) üzerinden değeri devralır. `False` anlamına gelmez. Çözülmüş Boolean değeri elde etmek için [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) ve [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) kullanın.

Aşağıdaki bağımsız örnek **Arial** yüklü olmasını gerektirir. Aynı büyük harf, küçük harf, alt çizgi ve aksanlı karakterleri 54 puanda iki metin bloğu olarak oluşturur. Her iki paragraf da varsayılan olarak normalleştirmeyi etkinleştirir. Üst bölüm bunu açıkça devre dışı bırakırken, alt bölüm devralır. Çerçeve boyutları, kenar boşlukları ve paragraf aralığı aynı olup kaydırma ve otomatik sığdırma devredışı bırakılmıştır, böylece karşılaştırma tutarlı kalır. Örnek `False: False` ve `NotDefined: True` çıktısını verir, ardından “text_height_normalization.pptx” kaydeder.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

Aşağıdaki karşılaştırma kaydedilen sunumdan dışa aktarılmıştır. Üst satırda normalleştirme devre dışı bırakılmıştır (`False`); alt satırda etkin ayar devralınmıştır (`NotDefined` → `True`). Bu görünümü yeniden üretmek için Arial yüklü olmalıdır.

![Arial 54-puan metin, üstte normalleştirme devre dışı ve altta devralınmış normalleştirme etkin](text_height_normalization.png)

Normalleştirme, atanmış [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) değerini değiştirmeden karakter yüksekliğini değiştirir; bu değer punto cinsinden yazı tipi boyutunu belirtir. Paragraf [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) satır aralığını kontrol ederken, metin çerçevesi [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) metnin ya da kapsayıcının nasıl ayarlanacağını belirler. Bu ayarlar farklı amaçlara hizmet eder ve genel yerleşimi bağımsız olarak etkileyebilir. Paragraf biçimlendirme ve kalıtım hakkında daha fazla bilgi için [Paragrafı Yönet](/slides/tr/net/manage-paragraph/) bölümüne bakın.

## **Üst Çizgiyi Uygula ve Kaldır**

Bir metin bölümü üzerinde [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) kullanarak düzeltmeler, iptal edilen terimler ya da önceki fiyatları, orijinal metni silmeden gösterebilirsiniz. Tek ya da iki çizgi için [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) ayarlayın.

Üst çizgiyi kaldırmak için `TextStrikethroughType.None` atayın. Bu, çevreleyen biçimlendirme üst çizgi belirtse bile etkiyi açıkça devre dışı bırakır. Buna karşılık, `TextStrikethroughType.NotDefined` yerel ayarı tanımsız bırakır; böylece bölüm, örneğin paragraftan biçimlendirme devralabilir. Üst çizginin kaldırıldığını garantilemez. Sonuç biçimlendirmeyi, devralınan değerler dahil olmak üzere okumak için [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) kullanın.

Aşağıdaki bağımsız örnek üç fiyat karşılaştırması oluşturur. Her paragraf etiket, önceki fiyat ve güncel fiyat için ayrı bölümler içerir; böylece yalnızca önceki fiyat etkilenir. İlk satır üst çizgiyi uygular ve ardından kaldırır; diğer satırlar tek ve çift üst çizgiyi korur. Bu özelliği değiştirmek, metni ve diğer biçimlendirmelerini, kalın önceki fiyatı da dahil olmak üzere korur.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Üst çizgiyi uygula, ardından ilk önceki fiyatın üzerindeki çizgiyi açıkça kaldır.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Sonuç, üstten alta: üst çizgi yok, tek üst çizgi, çift üst çizgi.

![Üst çizgisiz önceki fiyatlar, tek üst çizgili ve çift üst çizgili](strikethrough.png)

## **Metin Döndürmeyi Ayarla**

Metin çerçevesi içinde önceden tanımlanmış bir metin yönü ayarlamak için [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) kullanın.

Aşağıdaki kod örneği şekildeki metin yönünü [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarla**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayabilirsiniz.

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

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) ve [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif değer, satır yüksekliğinin yüzdesi olarak satır aralığını belirler.
* Negatif değer, satır aralığını puan cinsinden belirler.

Aşağıdaki örnek, ilk paragraftaki iç boşluğu satır yüksekliğinin %200’ü (çift satır aralığı) olarak ayarlar:

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

## **Satır Kesmeyi Kontrol Et**

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metninin karıştığı sunumlarda faydalıdır. Aşağıdaki özellikler [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/)’a aittir, bu nedenle bütün paragrafı etkiler:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) Latin satır kesme kurallarını kontrol eder. Karışık metinde bunu değiştirmek, bitişik Doğu Asya metni ve noktalama işaretlerinin nerede kaydırılacağını da etkileyebilir.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) Doğu Asya satır kesme kurallarını kontrol eder; satır başı ve sonundaki karakter kısıtlamalarını içerir.

Bu kurallar, otomatik kaydırmayı etkinleştiren [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) işlevini değiştirmez; kaydırma gerçekleştiğinde yerleşimi etkiler, satır sonu karakteri eklemez. Açık bir satır sonu, paragrafta mevcut genişliğe bakılmaksızın yeni bir satır başlatır.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. İki satır kesme özelliğini de açıkça ayarlar ve “line_breaking.pptx” olarak kaydeder. Her iki kuralı da deneyerek birini değiştirirken diğerini sabit tutabilirsiniz. Örnek, 24 puan Arial ve SimSun yazı tiplerini, 160 puan çerçeve genişliğini ve yatay çerçeve kenar boşluklarını sıfır olarak kullanır. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) olarak ayarlanmıştır; böylece metin boyutu ve çerçeve boyutları sabit kalır.

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

## **Askıda Noktalama İşaretlerini Kontrol Et**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) uygun noktalama işaretlerinin metin satırının sağ kenarını aşarak bir sonraki satıra geçmesini önler. Tüm paragrafı etkiler ve askıda girinti ile farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde askıda noktalama işaretlerini etkinleştirir ve “hanging_punctuation.pptx” olarak kaydeder. 24 puan Arial ve yatay çerçeve kenar boşlukları sıfır iken, son nokta “sentence” kelimesinin ardından kalır ve sağ kenarı aşar. Özelliği [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) yaparak karşılaştırın: bu ayarda nokta ayrı bir satıra yerleşir. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılmıştır, böylece kullanılabilir genişlik sabit kalır.

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

Her noktalama işareti askıya alınamaz. Yukarıda açıklanan [yazı tipi ve yerleşim koşulları](#control-line-breaking) de bu karşılaştırmaya uygulanır; yazı tipi, kullanılabilir genişlik, kenar boşlukları veya otomatik sığdırma ayarlarını değiştirerek görünen fark ortadan kalkabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) metnin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülmesini, taşmasını ya da şeklin otomatik olarak yeniden boyutlandırılmasını kontrol etmek için kullanın. Aşağıdaki örnek, şeklin metnine sığacak şekilde yeniden boyutlandırılmasını yapılandırır ve sonucu “autofit_type.pptx” olarak kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Otomatik kaydırma sonrası satır sayısını saymak ve metin ya da şekil genişliğinin sonucu nasıl değiştirdiğini görmek için [Render Edilen Satırları Say](/slides/tr/net/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) metnin şekil içinde dikey konumunu tanımlar; örneğin üst, orta ya da alt. Aşağıdaki örnek, metni ilk şeklin alt kısmına sabitler ve sonucu “text_anchor.pptx” olarak kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Metin Sekmeslemesini Ayarla**

Paragrafta sek duraklarını yapılandırmak için [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) ve [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) kullanın. Aşağıdaki örnek, varsayılan sek aralığını 100 puana ayarlar ve 30 puanda sola hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler.

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

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanızı sağlayan [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) sunar. Denetleme dili, PowerPoint’te imla ve dilbilgisi denetimi için kullanılan dili belirler.

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir metin kutusuna sahip “presentation.pptx” dosyasını ve en az bir paragrafı gerektirir. İlk paragrafın içeriğini “1。” ile değiştirir, yazı tipini SimSun olarak ayarlar ve basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonucu “proofing_language.pptx” olarak kaydeder:

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

// Dil denetimini Basitleştirilmiş Çince olarak ayarla.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Dil Üst Verilerini Kopyala**

Şablondan çok dilli metin kopyalarken, hem [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) hem de [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) koruyun. Aşağıdaki bağımsız örnek, kaynak bölümde US English’i dil, French’i alternatif dil olarak ayarlar ve metni ve tanımlayıcıları yeni bir sunumdaki bölüme kopyalar.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Kaynakta alternatif bir dil yoksa, null hedef değerini temizler.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Alternatif dil olmadan bir kaynak denemek için `"fr-FR"` atamasını atlayın. Alternatif tanımlayıcı o zaman `null` olur ve aynı kopya ifadesi, hedefte daha önce bir alternatif dil atanmış olsa bile, varlığını korur ve varsayılan bir değer eklemez.

Bu tanımlayıcılar dil üst verisi olarak saklanır. Bunların korunması, PowerPoint’in hangi sözlüğü imla ya da dilbilgisi denetimi için seçeceğini belirlemez.

## **Varsayılan Dili Ayarla**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) sunum yüklerken ya da oluştururken oluşturulan metin için varsayılan dili tanımlamak amacıyla kullanılır. Aşağıdaki örnek, varsayılan metin dili olarak US English ayarlayan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümü için `en-US` yazdırır.

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

Sunum seviyesinde varsayılan metin biçimlendirmesi uygulamak için [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve “default_text_style.pptx” olarak kaydeder. Metin, daha belirgin bir biçimlendirme bunu geçmediği sürece bu varsayılanları devralabilir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Üst seviyedeki paragraf formatını al.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Tüm Büyük Harf Efektiyle Metni Çıkar**

PowerPoint’te **All Caps** yazı tipi efekti uygulandığında, metin slaytta büyük harf olarak görülür, ancak aslında küçük harfle girilmiştir. Aspose.Slides ile böyle bir bölümü aldığınızda, kütüphane metni tam olarak girildiği gibi döndürür. Görünen metinle eşleşmesi için [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) kontrol edip değer `All` olduğunda dönen dizeyi büyük harfe çevirin.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusuna sahip “sample2.pptx” dosyasını gerektirir. İlk paragrafın ilk bölümü “Hello, Aspose!” metnini içerir ve All Caps efekti uygulanmıştır, aşağıda gösterildiği gibi.

![Tüm Büyük Harf efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** efekti uygulanmış metni nasıl çıkaracağınızı gösterir:

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

**Bir slayttaki tablo üzerindeki metni nasıl değiştiririm?**

Tablo üzerindeki metni değiştirmek için [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) kullanın. Hücreleri dolaşın ve her hücreyi [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) üzerinden güncelleyin; paragraf biçimlendirmesini ise [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) ile ayarlayın.

**PowerPoint slaytındaki metne nasıl bir degrade (gradient) renk uygularım?**

Metne degrade renk uygulamak için [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) kullanın. [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) özelliğini [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığı yapılandırın.

İlgili özellik: [Slaytlarda metni biçimlendirme](/slides/tr/features/text-formatting/).