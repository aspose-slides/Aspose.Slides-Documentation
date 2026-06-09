---
title: ".NET'te Sunum Metnini Biçimlendirme"
linktitle: "Metin Biçimlendirme"
type: docs
weight: 50
url: /tr/net/text-formatting/
keywords:
- "metni vurgulama"
- "düzenli ifade"
- "paragraf hizalama"
- "metin stili"
- "metin arka planı"
- "metin şeffaflığı"
- "karakter aralığı"
- "yazı tipi özellikleri"
- "yazı tipi ailesi"
- "metin döndürmesi"
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
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Vurgulama, arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sekme durakları ve dil ayarlarını kapsar.

Aşağıdaki örneklerde, ilk slaytta tek bir metin kutusu içeren "sample.pptx" adlı dosyayı kullanacağız; metin şu şekildedir:

![Örnek metin](sample_text.png)

## **Metni Vurgulama**

Metin çerçevesinde belirli bir örnekle eşleşen metni vurgulamanız gerektiğinde [ITextFrame.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlighttext/) metodunu kullanın. Bu metod, eşleşen metin parçalarına vurgulama rengi uygular ve sadece tam kelimelerle eşleştirme gibi arama davranışını kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/) ile birlikte kullanılabilir.

Aşağıdaki kod örneği **"try"** karakterlerinin tüm oluşumlarını vurgular ve ardından yalnızca tam kelime **"to"**'yu vurgular.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // İlk slayttan ilk şekli al.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Şekilde "try" kelimesini vurgula.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Şekilde "to" kelimesini vurgula.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgulama**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlightregex/) metodu, düzenli ifade ile bulunan metin eşleşmelerini vurgular. .NET'te bu API, [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) üzerinden sunulur.

Aşağıdaki kod örneği **yedi veya daha fazla karakter** içeren tüm kelimeleri vurgular:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Yedi veya daha fazla karaktere sahip tüm kelimeleri vurgula.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Düzenli ifade kullanarak vurgulanan metin](highlighted_text_using_regex.png)

## **Metin Arkaplan Rengini Ayarlama**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaultportionformat/) kullanın veya bireysel metin bölümleri için [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/highlightcolor/) kullanın.

Aşağıdaki kod örneği **tüm paragraf** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Tüm paragraf için vurgulama rengini ayarla.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Metin bölümünün vurgulama rengini ayarla.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizalama**

Metin çerçevesinde paragraf hizalamasını ayarlamak için [IParagraphFormat.Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/alignment/) kullanın. Değer merkezlenmiş, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamanın nasıl yapılacağını gösterir:

```cs
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

## **Metin Şeffaflığını Ayarlama**

Metin şeffaflığı, [IPortionFormat.FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/fillformat/) üzerinden atanan rengin alfa bileşeniyle kontrol edilir. Aşağıdaki örneklerde `alpha = 50` 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflık uygulamanın nasıl yapılacağını gösterir:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Metnin doldurma rengini şeffaf renk olarak ayarla.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipine sahip metin bölümleri** için şeffaflık uygulamanın nasıl yapılacağını gösterir:

```cs
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

## **Metin Karakter Aralığını Ayarlama**

Metin kutusundaki karakterler arasındaki boşluğu genişletmek veya sıkıştırmak için [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/spacing/) kullanın.

Aşağıdaki C# kodu **tüm paragrafta** karakter aralığını nasıl genişleteceğinizi gösterir:

```cs
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

Aşağıdaki kod örneği **kalın yazı tipine sahip metin bölümleri** için karakter aralığını nasıl genişleteceğinizi gösterir:

```cs
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

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırakma**

Bazı durumlarda, Aspose.Slides tarafından render edilen metin, PowerPoint'te aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in bazı yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir; font kerning verisine sahip olsa bile PowerPoint ayarlarında kerning etkinleştirilmiş olsa bile.

Böyle durumlarda render çıktısını PowerPoint'e daha yakın hale getirmek için, etkilenen fontu kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/kerningminimalsize/) değerini gerçek yazı tipi boyutundan çok daha büyük bir değere ayarlayın:

```cs
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

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını önler ve böylece Aspose.Slides renderlamasını PowerPoint'in görsel çıktısıyla hizalamaya yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaultportionformat/) üzerinden paragraf seviyesinde veya bireysel bölümler için [IPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/) üzerinden ayarlanabilir.

Aşağıdaki kod **tüm paragraf** için yazı tipini ve metin stilini ayarlar; tüm bölümlere yazı tipi boyutu, kalın, italik, noktalı altı çizgi ve Times New Roman uygular:

```cs
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

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipine sahip metin bölümleri** için benzer özellikleri uygular:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Metin bölümünün yazı tipi özelliklerini ayarla.
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

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmesini Ayarlama**

Şekil içinde önceden tanımlanmış bir metin yönü ayarlamak için [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/textverticaltype/) kullanın.

Aşağıdaki kod örneği şeklin içindeki metin yönünü `Vertical270` olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarlama**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/rotationangle/) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini saat yönünde 3 derece döndürür:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spacebefore/) ve [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/spacewithin/) sağlar. Bu özellikler aşağıdaki gibi kullanılır:

* Satır aralığını satır yüksekliğinin yüzdesi olarak belirtmek için pozitif bir değer kullanın.
* Satır aralığını puan cinsinden belirtmek için negatif bir değer kullanın.

Aşağıdaki kod örneği paragraftaki satır aralığını nasıl belirleyeceğinizi gösterir:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarlama**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/autofittype/) metnin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülmesi, taşması veya şeklin otomatik olarak yeniden boyutlandırılması gibi davranışları kontrol etmek için kullanın.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Metin Çerçevelerinin Sabitlemesini Ayarlama**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/anchoringtype/) metnin bir şekil içinde dikey konumunu, örneğin üst, orta veya alt olarak tanımlar.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Metin Sekmelerini Ayarlama**

Paragrafta sekme duraklarını yapılandırmak için [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/defaulttabsize/) ve [IParagraphFormat.Tabs](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/tabs/) kullanın.

```cs
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

## **Düzeltme Dilini Ayarlama**

Aspose.Slides, bir metin bölümü için düzeltme dili ayarlamanızı sağlayan [IPortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/languageid/) sunar. Düzeltme dili, PowerPoint'te imla ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki kod örneği bir metin bölümü için düzeltme dilini nasıl ayarlayacağınızı gösterir:

```cs
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

## **Varsayılan Dili Ayarlama**

Yükleme veya sunum oluşturma sırasında oluşturulan metin için varsayılan dili tanımlamak üzere [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/defaulttextlanguage/) kullanın.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Metin içeren yeni bir dikdörtgen şekli ekle.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // İlk bölümün dilini kontrol et.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Varsayılan Metin Stilini Ayarlama**

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/defaulttextstyle/) kullanın.

Aşağıdaki kod örneği yeni bir sunumda tüm slaytlardaki tüm metinler için 14 pt boyutunda kalın bir varsayılan yazı tipi ayarlamayı gösterir.

```cs
using (var presentation = new Presentation())
{
    // Üst düzey paragraf formatını al.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **All-Caps (Tam Büyük Harf) Efektiyle Metni Çıkarma**

PowerPoint'te **All Caps** yazı tipi etkisini uygulamak, metnin slaytta büyük harf olarak görünmesini sağlar, ancak metin aslında küçük harflerle girilmiş olabilir. Aspose.Slides ile böyle bir metin bölümü alındığında kütüphane metni tam olarak girildiği gibi döndürür. Görünen metni eşleştirmek için [TextCapType](https://reference.aspose.com/slides/tr/net/aspose.slides/textcaptype/) kontrol edin ve değer **All** olduğunda döndürülen dizeyi büyük harfe çevirin.

Örneğin, sample2.pptx dosyasının ilk slaydında aşağıdaki metin kutusuna sahip olduğumuzu varsayalım.

![All Caps etkisi](all_caps_effect.png)

Aşağıdaki kod örneği **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```cs
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

**Slayttaki bir tabloda metni nasıl değiştiririm?**

Tablodaki metni değiştirmek için [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) kullanın. Hücreler üzerinde dolaşın ve her bir hücreyi [ICell.TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/textframe/) ve paragraf biçimlendirmesini [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/paragraphformat/) aracılığıyla güncelleyin.

**PowerPoint slaytındaki metne degrade renk nasıl uygulanır?**

Degrade renk uygulamak için [IPortionFormat.FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/fillformat/) kullanın. [IFillFormat.FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformat/filltype/) değerini [FillType.Gradient](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.