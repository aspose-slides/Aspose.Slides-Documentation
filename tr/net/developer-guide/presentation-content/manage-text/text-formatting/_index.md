---
title: ".NET'te Sunum Metnini Biçimlendirme"
linktitle: "Metin Biçimlendirme"
type: docs
weight: 50
url: /tr/net/text-formatting/
keywords:
- "paragraf hizalama"
- "metin stili"
- "metin arka planı"
- "metin şeffaflığı"
- "karakter aralığı"
- "yazı tipi özellikleri"
- "yazı tipi ailesi"
- "metin döndürme"
- "döndürme açısı"
- "metin çerçevesi"
- "satır aralığı"
- "otomatik sığdırma özelliği"
- "metin çerçevesi sabitlemesi"
- "metin sekmesi"
- "varsayılan dil"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarındaki metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin biçimlendirmeyi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin yerleştirme, sekme durakları ve dil ayarları ele alınmaktadır.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slayttaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indisleri sıfır‑tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirmeyi içeren etkili biçimlendirmeyi kullanır:

![Örnek metin](sample_text.png)

Gerçek metni ya da düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Search and Replace Text](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarlama**

Bir paragraf için varsayılan vurgulama rengini ayarlamak üzere [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) kullanın veya bireysel metin bölümleri için [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerdeki açık vurgulama renkleri bu varsayılanın üzerindedir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Paragrafın tamamı için vurgulama rengini ayarla.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

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

## **Metin Paragraflarını Hizalama**

Bir metin çerçevesindeki paragraf hizalamasını ayarlamak için [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) kullanın. Değer “center”, “left”, “right”, “justify” vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Paragraf hizalamasını ortaya ayarla.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçinde Yazı Tipi Hizalamaları**

Farklı yazı tipi boyutlarına sahip metin bölümlerini bir satır içinde dikey olarak hizalamak için [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) kullanın. Bu ayar tüm paragraf için geçerlidir ve satır içi hizalamayı kontrol eder.

Aşağıdaki örnek, tek bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 puan boyutlarında, farklı yazı tipi hizalamalarıyla içerir. Arial kullanır, otomatik sığdırma ve kaydırmayı devre dışı bırakır ve tek satır için çerçeveleri yeterince büyük tutar.

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

![Baseline, Top, Center ve Bottom hizalamalarının karışık yazı tipi boyutlarıyla karşılaştırması](font_alignment.png)

Yazı tipi hizalaması, yazı tipi metriklerine dayanır; bu nedenle bireysel harflerin görünen kenarları tam olarak hizalanmayabilir. Örnek, farkı göstermek için bir büyük harf ve bir alt çizgi (descender) içerir. Yazı tipi bulunabilirliği, karakter seçimi ve yazı tipi boyutları sonuca etki eder. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da düzeni etkiler; modları karşılaştırırken aynı yazı tiplerini ve düzen ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ve şekil içinde metin bloğunu dikey konumlandıran [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) öğelerinden farklıdır. [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) ile alt/üst simge (subscript/superscript) biçimlendirmesi, bireysel bölümleri temel çizgiye göre kaydırır; paragraf satırları için yazı tipi hizalaması ayarlamaz.

## **Metin Şeffaflığını Ayarlama**

Metin şeffaflığı, [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) üzerinden atanmış rengin alfa bileşeniyle kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0‑255 ölçeğinde bir ARGB alfa değeri olup bir şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflık uygular:

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

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için şeffaflık uygular:

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

## **Metin İçin Karakter Aralığını Ayarlama**

Bir metin kutusundaki karakterler arasındaki boşluğu genişletmek ya da sıkıştırmak için [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) kullanın. Aşağıdaki örnekler 3 puan aralık ekler; negatif değerler metni sıkıştırır.

Aşağıdaki C# kodu, **tüm paragraf** için karakter aralığını nasıl genişleteceğinizi gösterir:

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

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için karakter aralığını nasıl genişleteceğinizi gösterir:

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

### **Belirli Yazı Tipleri İçin Kerning’i Devre Dışı Bırakma**

Bazı durumlarda Aspose.Slides tarafından işlenen metin, PowerPoint’teki aynı metinden biraz daha sık görünebilir. Bu, PowerPoint’in belirli yazı tipleri için kerning verisini görmezden gelmesinden kaynaklanabilir; yazı tipinde geçerli kerning bilgisi bulunsa ve PowerPoint ayarlarında kerning açıksa bile.

Bu durumlarda çıktıyı PowerPoint’e daha yakın hâle getirmek için, etkilenmiş yazı tipini kullanan metin bölümleri için kerning’i devre dışı bırakabilirsiniz. [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) değerini gerçek yazı tipi boyutundan daha büyük bir değere ayarlayın. Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip “presentation.pptx” dosyasını gerektirir. Etkili yazı tipi adlarını (kalıtılmış yazı tipleri dahil) kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değeri belirler. Bu, 100 puandan küçük boyuttaki eşleşen bölümler için kerning’i devre dışı bırakır:

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

Eşiğin altındaki eşleşen metinler için bu ayar kerning’i önler ve PowerPoint’e özgü bu davranıştan etkilenen yazı tiplerinin görsel çıktısını Aspose.Slides ile uyumlu hâle getirmeye yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, paragraf düzeyinde [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) üzerinden ya da bireysel bölümler için [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) üzerinden ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman, kalın, italik ve noktalı alt çizgi olarak ayarlar. Bireysel bölümler üzerindeki açık biçimlendirme bu varsayılanların üzerindedir.

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

## **Metin Yüksekliliği Normalleştirmesini Kontrol Etme**

Şablon tipografisini yeniden üretirken ya da karakter yüksekliği farklarını incelerken [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) kullanın. PowerPoint’te normalleştirmeyi etkinleştirmek, bireysel karakterleri dikey olarak gererek aynı metin bölümü içinde görünür yüksekliği eşitler. Farklı yazı tipleri arasında eşit metin yüksekliği garantilemez.

Özelliği, normalleştirmeyi açık ya da kapalı hâle getirmek için [NullableBool.True veya False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) olarak ayarlayın. `NullableBool.NotDefined` yerel ayarı boş bırakır; böylece değer, örneğin paragrafın [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) üzerinden devralınır. Bu, `False` anlamına gelmez. Çözülmüş Boolean değeri almak için [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) ve [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) kullanın.

Aşağıdaki örnek, **Arial** yüklü olmasını gerektirir. Aynı büyük harf, küçük harf, alt çizgi ve aksanlı karakterleri 54 puan olarak iki metin bloğunda oluşturur. Her iki paragraf da varsayılan olarak normalleştirmeyi etkinleştirir. Üst bölüm bunu açıkça devre dışı bırakırken, alt bölüm devralır. Çerçeve boyutları, kenar boşlukları ve paragraf aralığı aynıdır; karşılaştırmayı tutarlı kılmak için kaydırma ve otomatik sığdırma devredışı bırakılmıştır. Örnek `False: False` ve `NotDefined: True` çıktısı verir, ardından “text_height_normalization.pptx” dosyasını kaydeder.

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

Aşağıdaki karşılaştırma kaydedilen sunumdan dışa aktarılmıştır. Üst satırda normalleştirme devre dışı (`False`); alt satırda devralınan ayar (`NotDefined` → `True`). Bu görünümü yeniden üretmek için Arial yüklü olmalıdır.

![Arial 54 puan metin, üstte normalleştirme devre dışı ve altta devralınmış](text_height_normalization.png)

Normalleştirme, atanmış [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) değerini değiştirmeden karakter yüksekliğini değiştirir; bu değer puan cinsinden yazı tipi boyutunu belirtir. Paragraf [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) satır aralığını kontrol ederken, metin‑çerçevesi [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) metnin ya da kapsayıcısının boyutunu ayarlar. Bu ayarlar farklı amaçlara hizmet eder ve düzeni bağımsız olarak etkileyebilir. Paragraf biçimlendirmesi ve kalıtımı hakkında daha fazla bilgi için [Manage Paragraph](/slides/tr/net/manage-paragraph/) bölümüne bakın.

## **Üstü Çizili Metni Uygulama ve Kaldırma**

Bir metin bölümünde düzeltmeler, iptal edilen ifadeler ya da önceki fiyatları silmeden göstermek için [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) kullanın. Metnin üzerinden tek ya da iki satır çizmek için [TextStrikethroughType.Single veya Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) ayarlayın.

Üstü çizili özelliğini kaldırmak için `TextStrikethroughType.None` atayın. Bu, çevreleyen biçimlendirme üstü çizili olsa bile efekti açıkça devre dışı bırakır. Buna karşılık, `TextStrikethroughType.NotDefined` yerel ayarı tanımsız bırakır; böylece bölüm paragraftan kalıtım alabilir. Üstü çiziliyin kaldırıldığını garanti etmez. Sonuç biçimlendirmesini, kalıtılmış değerler dahil, okumak için [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) kullanın.

Aşağıdaki örnek üç fiyat karşılaştırması oluşturur. Her paragraf etiketi, önceki fiyat ve güncel fiyat için ayrı bölümler içerir; böylece yalnızca önceki fiyat etkilenir. İlk satır üstü çizili uygular ve ardından kaldırır; diğer satırlar tek ve çift üstü çiziliyi korur. Bu özelliği değiştirmek, metni ve diğer biçimlendirmeleri, özellikle kalın önceki fiyatı, korur.

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

// Üstü çizgiyi uygula, ardından ilk önceki fiyatın üstü çizgisini açıkça kaldır.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Sonuç, yukarıdan aşağıya: üstü çizili yok, tek üstü çizili, çift üstü çizili.

![Üstü çizili olmayan, tek üstü çizili ve çift üstü çizili önceki fiyatlar](strikethrough.png)

## **Metin Döndürmeyi Ayarlama**

Şekil içinde önceden tanımlanmış bir metin yönlendirmesi ayarlamak için [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) kullanın.

Aşağıdaki kod örneği, şekil içindeki metin yönlendirmesini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

## **Dikey Metinde Basamakları Yan Yana Gösterme**

İki basamaklı bir sayı, dikey bir Japon etiketi içinde birlikte kalmalıysa, her iki basamağı da tek bir metin bölümünde tutun ve o bölüme [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) uygulayın. Örnek, hem sol hem de sağ etiket için [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) ve 40 puan MS Gothic kullanır. Sayısal bölüme atanmış [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) değeri farklıdır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

PowerPoint’te sol etiket (`True`) basamakları dikey ve yan yana gösterirken, sağ etiket (`False`) 90 derece saat yönünde döndürülür. Çevredeki Japon karakterleri her iki etiketde de dikey kalır.

![Sol tarafta dikey basamaklar, sağ tarafta döndürülmüş basamaklar ile dikey tarih etiketlerinin PowerPoint karşılaştırması](vertical_date.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarlama**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayın.

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

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) ve [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif değer, satır yüksekliğinin yüzde olarak satır aralığını belirtir.
* Negatif değer, satır aralığını puan olarak belirtir.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200’ü (çift satır aralığı) olarak ayarlar:

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

## **Satır Bölme Kontrolü**

Paragraf satır bölme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metnini karıştıran sunumlarda faydalıdır. Aşağıdaki özellikler [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) elemanına aittir; bu nedenle tüm paragrafı etkiler:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) Latin satır bölme kurallarını kontrol eder. Karışık metinde değiştirilmesi, bitişik Doğu Asya metni ve noktalama işaretlerinin nerede kaydırılacağını da etkileyebilir.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) Doğu Asya satır bölme kurallarını, satır başı ve sonundaki karakter kısıtlamaları dahil olmak üzere kontrol eder.

Bu kurallar, otomatik kaydırmayı etkinleştiren [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) yerine geçmez; kaydırma gerçekleştiğinde yerleşimi etkiler, satır sonu karakteri eklemezler. Açık bir satır sonu, paragrafta mevcut genişliğe bakılmaksızın yeni bir satır başlatır.

Aşağıdaki örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır bölme özelliğini de açıkça ayarlar ve “line_breaking.pptx” dosyasını kaydeder. Herhangi bir kuralı denemek için, diğer ayarları sabit tutarak ilgili özelliğin değerini değiştirin. Örnek, 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve sıfır yatay kenar boşlukları kullanır. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) olarak ayarlanmıştır; böylece metin boyutu ve çerçeve boyutları sabit kalır.

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

## **Sarkan Noktalama İşaretlerini Kontrol Etme**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) uygun noktalama işaretlerinin metin satırının sağ kenarının ötesine uzanmasına izin verir; böylece bir sonraki satıra kaymaz. Bu, tüm paragrafı etkiler ve sarkan girinti (hanging indent) kavramından farklıdır.

Aşağıdaki örnek, 100 puan genişliğinde bir metin çerçevesinde sarkan noktalama işaretlerini etkinleştirir ve “hanging_punctuation.pptx” dosyasını kaydeder. 24 puan Arial ve sıfır yatay kenar boşluklarıyla, son nokta “sentence” kelimesinden sonra kalır ve sağ metin kenarının ötesine uzanır. Özelliği [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) yaparak karşılaştırın: bu ayarlarda nokta ayrı bir satır alır. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılmıştır; böylece kullanılabilir genişlik sabit kalır.

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

Her nokta işareti sarkamaz. Yukarıda açıklanan [yazı tipi ve yerleşim koşulları](#control-line-breaking) da bu karşılaştırmaya uygulanır: yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirerek görünen fark kaybolabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarlama**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) metnin kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülmesini, taşmasını ya da şeklin otomatik olarak yeniden boyutlandırılmasını kontrol etmek için kullanın. Aşağıdaki örnek, şeklin metni sığdırmak için yeniden boyutlandırılmasını ayarlar ve sonucun “autofit_type.pptx” olarak kaydedilmesini sağlar.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Otomatik kaydırma sonrası satır sayısını ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Count Rendered Lines](/slides/tr/net/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarlama**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) bir şekil içinde metnin dikey konumlandırılmasını tanımlar; örneğin, üst, orta veya alt. Aşağıdaki örnek, ilk şeklin metnini alt kısma sabitler ve sonucu “text_anchor.pptx” olarak kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Metin Sekmelerini Ayarlama**

Paragrafta sekme duraklarını yapılandırmak için [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) ve [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) kullanın. Aşağıdaki örnek, varsayılan sekme aralığını 100 puan olarak ayarlar ve 30 puanda sol‑hizalı bir sekme durak ekler. Bu ayarlar sekme karakteri içeren metni etkiler.

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

## **Düzeltme Dilini Ayarlama**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanızı sağlayan [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) sunar. Düzeltme dili, PowerPoint’te imla ve gramer denetimlerinde kullanılacak dili belirler.

Aşağıdaki örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip “presentation.pptx” dosyasını gerektirir ve en az bir paragraf içerir. İlk paragrafın içeriğini “1。” ile değiştirir, yazı tipini SimSun yapar ve Düzeltme dilini Basitleştirilmiş Çince (`zh-CN`) olarak atar. Sonuç “proofing_language.pptx” olarak kaydedilir:

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

// Düzeltme dilini Basitleştirilmiş Çince olarak ayarla.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Dil Üst Verilerini Kopyalama**

Şablondan çok dilli metin kopyalarken, hem [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) hem de [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) üst verilerini koruyun. Aşağıdaki örnek, kaynak bölümde ABD İngilizcesi ana dil ve Fransızca alternatif dil atar ve metni yeni bir sunumdaki bölüme kopyalar.

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
// Eğer kaynakta alternatif dil yoksa, null hedef değerini temizler.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Alternatif dil olmadan bir kaynak denemek için `"fr-FR"` atamasını kaldırın. Alternatif tanımlayıcı o zaman `null` olur ve aynı kopya ifadesi, hedefte önceden bir alternatif dil atanmış olsa bile, eksikliği varsayılan bir değer eklemeden korur.

Bu tanımlayıcılar dil üst verilerini saklar. Bunları korumak, PowerPoint’in hangi sözlüğü imla ya da dilbilgisi denetimi için seçeceğini belirlemez.

## **Varsayılan Dili Ayarlama**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) sunumu yüklerken ya da oluştururken oluşturulan metin için varsayılan dili tanımlamak için kullanılır. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi ayarlayan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümü için `en-US` yazdırır.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Metin içeren yeni bir dikdörtgen şekil ekle.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// İlk bölümün dilini kontrol et.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Varsayılan Metin Stili Ayarlama**

Sunum seviyesinde varsayılan metin biçimlendirmesi uygulamak için [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst‑seviye paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve “default_text_style.pptx” olarak kaydeder. Metin, daha özgül biçimlendirme tarafından geçersiz kılınmadıkça bu varsayılanları devralabilir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Üst seviye paragraf formatını al.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **All‑Caps Efektiyle Metin Çıkarma**

PowerPoint’te **All Caps** yazı tipi efekti, metnin slaytta büyük harfle görünmesini sağlar; ancak metin Aspose.Slides ile alındığında, kütüphane metni girildiği haliyle döndürür. Görünen metni eşleştirmek için [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip “sample2.pptx” dosyasını gerektirir. İlk paragrafın ilk bölümü “Hello, Aspose!” metnini **All Caps** efektiyle içerir; aşağıda gösterilmiştir.

![All Caps efekti](all_caps_effect.png)

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

**Bir slayttaki tablo içinde metni nasıl değiştiririm?**

Tablo içindeki metni değiştirmek için [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) kullanın. Hücreleri dolaşın ve her hücreyi [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) aracılığıyla güncelleyin; paragraf biçimlendirmesini ise [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) ile ayarlayın.

**PowerPoint slaytındaki metne nasıl degradeli renk uygularım?**

Metne degradeli renk uygulamak için [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) kullanın. [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) değerini [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.

İlgili özellik: [Format text within slides](/slides/tr/features/text-formatting/).