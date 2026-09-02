---
title: .NET ile PowerPoint Sunumlarında Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/net/search-and-replace-text/
keywords:
- metin ara
- metni vurgula
- metni değiştir
- düzenli ifade
- sonuç geri çağrısı
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint sunumlarındaki metni arama, vurgulama ve değiştirme işlemlerini yaparken, her eşleşmeyi Aspose.Slides for .NET ile toplar."
---
## **Genel Bakış**

Aspose.Slides for .NET, bireysel bir metin çerçevesinde veya tüm sunum boyunca metin arama, vurgulama ve değiştirme yapabilir. Her işlem, bir sonuç geri çağrısı aracılığıyla her eşleşme hakkında bir uygulamayı da bilgilendirebilir. Bu, bir sunumu güncellerken eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izini aynı anda oluşturmayı mümkün kılar.

Bu yetenekler, inceleme, redaksiyon, terim kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için faydalıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan "sample.pptx" adlı bir dosya kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

[ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) üzerindeki yöntemleri bir işlemi tek bir metin çerçevesiyle sınırlamak için kullanın. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) üzerindeki yöntemleri sunumdaki tüm uygulanabilir metni işlemek için kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Düz metni vurgula | [ITextFrame.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/highlighttext/) |
| Düzenli ifade eşleşmelerini vurgula | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/highlightregex/) |
| Düz metni değiştir | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/replacetext/) |
| Düzenli ifade eşleşmelerini değiştir | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/replaceregex/) |

## **Metin Eşleştirmeyi Yapılandır**

Düz metin işlemleri için eşleşmeyi kontrol etmek üzere [TextSearchOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/wholewordsonly/) eşleşmeleri tamamen kelimelerle sınırlar.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/casesensitive/) karakter durumunun eşleşmesi gerekip gerekmediğini kontrol eder.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/includenotes/) sunum düzeyinde arama, değiştirme ve vurgulama işlemlerine slayt notlarını dahil eder.

Düzenli ifade işlemleri bir .NET `Regex` kullanır; bu yüzden büyük/küçük harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifadenin ve seçeneklerin tarafından tanımlanır.

## **Eşleşme Bilgilerini Geri Çağrı ile Topla**

[IFindResultCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/ifindresultcallback/) uygulayarak her eşleşme için bir bildirim alabilirsiniz. Bunun [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/tr/net/aspose.slides/ifindresultcallback/foundresult/) yöntemi ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşme konumunu sağlar.

Geri çağrı doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, bunu ebeveyn slayttan türetir ve slayt notlarında bulunan metni de işler. Nullable bir slayt numarası, aynı sonuç modelinin diğer slayt tipleriyle ilişkili metni temsil etmesini sağlar.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Değiştirme işlemleri için, `FoundText` orijinal eşleşen metni içerir, bu yüzden geri çağrı tam olarak hangi terimlerin değiştirildiğini kaydedebilir.

## **Metni Vurgula**

Bir metin çerçevesinde düz metin eşleşmelerini vurgulamak için [ITextFrame.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlighttext/) yöntemini kullanın. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/) ve eşleşme ayrıntılarını toplamak için bir geri çağrı gönderin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm görünümlerini ve ardından yalnızca tam **"to"** kelimesini vurgular. Her iki arama da eşleşmelerini aynı geri çağrıya rapor eder.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// İlk slayttaki ilk şekli alın.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// "try" metin çerçevesindeki her oluşumu vurgulayın.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Sadece tam "to" kelimesini vurgulayın.
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgula**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlightregex/) yöntemi, bir metin çerçevesinde düzenli ifade ile bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular ve her eşleşmeyi toplar:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

Sonuç:

![Düzenli ifade kullanılarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgula**

[Presentation.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/highlighttext/) ve [Presentation.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/highlightregex/) yöntemlerini kullanarak bir sunumdaki tüm uygulanabilir metin çerçevelerinde arama yapın. Aşağıdaki örnek, düz bir terimi ve tüm e-posta adreslerini vurgular ve iki arama için ayrı sonuç koleksiyonları tutar.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Bir Metin Çerçevesinde Metni Değiştir**

Düz metin için [ITextFrame.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replacetext/) ve desen tabanlı değişim için [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replaceregex/) kullanın. Bu yöntemler, mevcut metin çerçevesi içinde eşleşen metni günceller; bu, metin çerçevesini düz bir dizeden yeniden oluşturmak yerine çevresindeki bölümün biçimlendirmesini korur.

Aşağıdaki örnek, bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir. Aynı geri çağrı, her iki işlem tarafından eşleşen orijinal terimleri kaydeder.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Eğer bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı inceleyerek hangi biçimlendirmenin değiştirme metnine uygulanması gerektiğini doğrulayın.

## **Sunum Genelinde Metni Değiştir**

[Presentation.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/replacetext/) ve [Presentation.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/replaceregex/) yöntemlerini kullanarak aynı işlemleri tüm sunuma uygulayın. Bu, şablon temizliği, terim güncellemeleri ve redaksiyon için faydalıdır.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Raporlama İçin Eşleşmeleri Gruplandır**

Her sonuç slayt numarasını ve metin çerçevesini sakladığından, uygulamalar denetim, raporlama veya inceleme iş akışları için eşleşmeleri gruplayabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, ardından metin çerçevesine göre gruplar:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **SSS**

**Nasıl sadece tek bir metin kutusunu tüm sunum yerine arayabilirim?**

Şeklin metin çerçevesini alın ve bu metin çerçevesinde [ITextFrame.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replacetext/) veya [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replaceregex/) yöntemlerini çağırın. Sunum düzeyindeki yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Nasıl tam kelimeleri doğru büyük/küçük harfle eşleştirebilirim?**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/wholewordsonly/) ve [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/casesensitive/) seçeneklerini `true` olarak ayarlayın ve bu seçenekleri düz metin vurgulama veya değiştirme yöntemine iletin. Düzenli ifadeler için, kelime sınırlarını ve büyük/küçük harf duyarlılığını .NET `Regex` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni içerebilir mi?**

Evet. Sunum düzeyinde düz metin işlemi kullanırken [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/includenotes/) seçeneğini `true` olarak ayarlayın. Yukarıda gösterilen geri çağrı uygulaması, bir not slaydındaki eşleşmeyi ebeveyn slayt numarasına bağlar.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

[IFindResultCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/ifindresultcallback/) uygulamasını vurgulama veya değiştirme işlemine gönderin. Geri çağrı, işlem çalışırken her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonraki gruplama veya dışa aktarım için depolayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replacetext/) ve [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replaceregex/) eşleşen metni mevcut metin çerçevesi içinde değiştirir ve çevresindeki bölümün biçimlendirmesini korur. Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, sonucu inceleyerek değiştirmenin istenen stili kullandığından emin olun.