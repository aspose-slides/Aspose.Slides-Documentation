---
title: ".NET'te Sunum Metnini Biçimlendir"
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

Bu makale, Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin biçimlendirmeyi göstermektedir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sekme durakları ve dil ayarları ele alınmaktadır.

Aşağıdaki örneklerde, ilk slaytta tek bir metin kutusu bulunan ve aşağıdaki metni içeren "sample.pptx" adlı dosyayı kullanacağız:

![Örnek metin](sample_text.png)

Kelimeyi bulmak ve vurgulamak ya da düzenli ifade eşleşmelerini görmek için [Metin Ara ve Değiştir](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarla**

Paragraf için varsayılan vurgulama rengini ayarlamak için [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaultportionformat/) kullanın veya tek tek metin bölümleri için [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/highlightcolor/) kullanın.

Aşağıdaki kod örneği **tüm paragraf** için arka plan renginin nasıl ayarlanacağını gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Paragrafın tamamı için vurgulama rengini ayarla.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

Metin çerçevesi içinde paragraf hizalamasını ayarlamak için [IParagraphFormat.Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/alignment/) kullanın. Değer merkezlenmiş, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Paragrafın hizalamasını ortaya ayarla.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/fillformat/) için atanmış rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflık uygulamayı gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Metnin dolgu rengini şeffaf renk olarak ayarla.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için şeffaflık uygulamayı gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarla**

Metin kutusundaki karakterler arasındaki boşluğu genişletmek veya sıkıştırmak için [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/spacing/) kullanın.

Aşağıdaki C# kodu **tüm paragraf** içinde karakter aralığını genişletmeyi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Karakter aralığını genişlet.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** içinde karakter aralığını genişletmeyi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırak**

Bazı durumlarda Aspose.Slides tarafından render edilen metin, PowerPoint'te aynı metinden daha sıkı görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verisini görmezden gelmesinden kaynaklanabilir; hatta yazı tipinde geçerli kerning bilgisi olsa ve PowerPoint ayarlarında kerning açıksa bile.

Bu durumlarda render sonucunu PowerPoint'e daha yakın hâle getirmek için, etkilenmiş yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/kerningminimalsize/) değerini gerçek yazı tipi boyutundan önemli ölçüde büyük bir değere ayarlayın:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını önler ve PowerPoint'in bu yazı tipleri için gösterdiği görsel çıktıyla Aspose.Slides render'ını hizalamaya yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaultportionformat/) üzerinden paragraf düzeyinde veya tek tek bölümler için [IPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/) üzerinden ayarlanabilir.

Aşağıdaki kod, tüm paragraf için yazı tipi ve metin stilini ayarlar: yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman tüm bölümlere uygulanır.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Paragraf için yazı tipi özelliklerini ayarla.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Paragrafın yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için benzer özellikleri uygular:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Sonuç:

![Metin bölümlerinin yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarla**

Şekil içinde önceden tanımlı bir metin yönelimi ayarlamak için [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/textverticaltype/) kullanın.

Aşağıdaki kod örneği metin yönelimini `Vertical270` olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarla**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/rotationangle/) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayabilirsiniz.

Aşağıdaki kod örneği metin çerçevesini şekil içinde saat yönünde 3 derece döndürür:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spacebefore/) ve [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spacewithin/) sağlar. Bu özellikler şu şekilde kullanılır:

* Satır aralığını satır yüksekliğinin yüzde olarak belirtmek için pozitif bir değer kullanın.
* Satır aralığını puan cinsinden belirtmek için negatif bir değer kullanın.

Aşağıdaki kod örneği paragraf içindeki satır aralığını nasıl belirleyeceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Paragraf içindeki satır aralığı](line_spacing.png)

## **Metin Çerçeveleri İçin Otomatik Sığdırma Tipi Ayarla**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/autofittype/) metin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/anchoringtype/) metnin bir şekil içinde dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üstte, ortada veya altta.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Metin Sekme Ayarlarını Yap**

Paragrafta sekme duraklarını yapılandırmak için [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaulttabsize/) ve [IParagraphFormat.Tabs](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/tabs/) kullanın.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Düzeltme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanıza izin veren [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/languageid/) sağlar. Düzeltme dili, PowerPoint'te imla ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki kod örneği bir metin bölümü için düzeltme dilinin nasıl ayarlanacağını gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Düzeltme dilinin kimliğini ayarla.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Varsayılan Dili Ayarla**

Yükleme veya yeni bir sunum oluşturma sırasında oluşturulan metinler için varsayılan dili tanımlamak üzere [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/defaulttextlanguage/) kullanın.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Yeni bir dikdörtgen şekil ekle ve metin ekle.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // İlk bölümün dilini kontrol et.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Varsayılan Metin Stilini Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesi uygulamak için [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/defaulttextstyle/) kullanın.

Aşağıdaki kod örneği, yeni bir sunumdaki tüm slaytlarda varsayılan olarak kalın bir yazı tipi ve 14 pt boyut ayarlamayı gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // Üst seviye paragraf biçimini al.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **All-Caps Etkisiyle Metin Çıkarma**

PowerPoint’te **All Caps** (Tam Büyük Harf) yazı tipi efekti uygulandığında, metin slaytta büyük harf olarak görünür, ancak orijinal olarak küçük harfle girilmiştir. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni girildiği hâliyle döndürür. Görüntülenen metni eşleştirmek için [TextCapType](https://reference.aspose.com/slides/tr/net/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Örnek olarak sample2.pptx dosyasının ilk slaydındaki aşağıdaki metin kutusunu ele alalım.

![All Caps etkisi](all_caps_effect.png)

Aşağıdaki kod örneği **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tablo içinde metni nasıl değiştirebilirim?**

Bir slayttaki tablo içinde metni değiştirmek için [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) kullanın. Hücreler üzerinde döngü yapın ve her hücreyi [ICell.TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/textframe/) aracılığıyla güncelleyin; paragraf biçimlendirmesini ise [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/paragraphformat/) ile ayarlayın.

**PowerPoint slaytındaki metne degrade (gradient) renk nasıl uygulanır?**

Metne degrade renk uygulamak için [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/fillformat/) kullanın. [IFillFormat.FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformat/filltype/) değerini [FillType.Gradient](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.