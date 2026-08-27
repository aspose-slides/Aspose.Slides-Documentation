---
title: ".NET ile PowerPoint Sunumlarında Metin Arama ve Değiştirme"
linktitle: "Metni Ara ve Değiştir"
type: docs
weight: 55
url: /tr/net/search-and-replace-text/
keywords:
- metin ara
- metin vurgulama
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
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında metin arama, vurgulama ve değiştirme işlemlerini gerçekleştirirken her eşleşmeyi toplar."
---
## **Genel Bakış**

Aspose.Slides for .NET, bireysel bir metin çerçevesinde veya tüm sunumda metin arayabilir, vurgulayabilir ve değiştirebilir. Her işlem, sonuç geri çağrısı aracılığıyla her eşleşme hakkında bir uygulamayı da bilgilendirebilir. Bu, bir sunumu güncellerken eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izi oluşturmayı mümkün kılar.

Bu özellikler, inceleme, redaksiyon, terminoloji kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için kullanışlıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan **"sample.pptx"** adlı bir dosya kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

[ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) yöntemiyle bir işlemi tek bir metin çerçevesiyle sınırlayabilirsiniz. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yöntemiyle sunumdaki tüm uygulanabilir metni işleyebilirsiniz.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Literal metni vurgula | [ITextFrame.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/highlighttext/) |
| Düzenli ifade eşleşmelerini vurgula | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/highlightregex/) |
| Literal metni değiştir | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/replacetext/) |
| Düzenli ifade eşleşmelerini değiştir | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/replaceregex/) |

## **Metin Eşleştirmeyi Yapılandırma**

Literal metin işlemleri için, eşleşmeyi kontrol etmek üzere [TextSearchOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/wholewordsonly/) eşleşmeleri yalnızca tam kelimelerle sınırlar.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/casesensitive/) karakter büyük/küçük harf eşleşmesinin gerekip gerekmediğini kontrol eder.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/includenotes/) sunum seviyesindeki arama, değiştirme ve vurgulama işlemlerine slayt notlarını dahil eder.

Düzenli ifade işlemleri bir .NET `Regex` kullanır; bu nedenle büyük/küçük harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifadenin ve seçeneklerinin içinde tanımlanır.

## **Bir Metin Çerçevesinin Sahibini Belirleme**

Genel metin işleme iş akışları, metin ararken, değiştirirken, doğrularken veya dışa aktarırken genellikle bir [ITextFrame] alır. Metin çerçevesine sahip sunum nesnesini belirlemek için [ITextFrame.ParentShape](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentshape/) ve [ITextFrame.ParentCell](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentcell/) kullanın.

| Metin çerçevesi sahibi | `ParentShape` | `ParentCell` |
|---|---|---|
| Bir AutoShape veya metin içeren başka bir şekil | The owning [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) | `null` |
| Bir tablo hücresi | `null` | The owning [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/) |

Her iki özellik de salt‑okunur gezinme özellikleridir. Okunmaları metin çerçevesini hareket ettirmez veya sahibini değiştirmez. Genel kod, her iki değeri de `null` için kontrol etmeli ve hiçbir sahibin bulunmadığı durumları ele almalıdır.

Aşağıdaki örnek, bir sunumdaki metin çerçevelerini yinelemek için [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/getalltextframes/) kullanır. Şekiller için şekil adını, şekil tipini ve içinde bulunduğu slaytı raporlar. Tablo hücreleri için sıfır tabanlı sütun ve satır koordinatlarını ve içinde bulunduğu slaytı raporlar.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

SmartArt içeriği için, [ISmartArtNode.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/ismartartnode/shapes/) içindeki şekilleri yineleyin ve her [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/ismartartshape/textframe/) erişin. Metin çerçevesi, ilişkili şekle [ITextFrame.ParentShape](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentshape/) aracılığıyla izlenebilir, [ITextFrame.ParentCell](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentcell/) ise `null` dır. Bu nedenle, örnekteki şekil dalı SmartArt düğümlerinden gelen metni de işler.

## **Bir Geri Çağrı ile Eşleşme Bilgisi Toplama**

[IFindResultCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/ifindresultcallback/) uygulayarak her eşleşme için bir bildirim alabilirsiniz. Bunun [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/tr/net/aspose.slides/ifindresultcallback/foundresult/) yöntemi ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşme konumunu sağlar.

Geri çağrı doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, bunu üst slayttan türetir ve slayt notlarında bulunan metni de işler. Null olabilen bir slayt numarası, aynı sonuç modelinin diğer slayt tiplerine ait metni temsil etmesine izin verir.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

Değiştirme işlemleri için, `FoundText` orijinal eşleşen metni içerir; bu sayede geri çağrı hangi terimlerin değiştirildiğini tam olarak kaydedebilir.

## **Metni Vurgulama**

[ITextFrame.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlighttext/) yöntemini kullanarak bir metin çerçevesinde literal metin eşleşmelerini vurgulayabilirsiniz. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/) geçirin ve eşleşme ayrıntılarını toplamak için bir geri çağrı sağlayın.

Aşağıdaki kod örneği **"try"** karakterlerinin tüm tekrarlarını vurgular ve ardından yalnızca tam **"to"** kelimesini vurgular. Her iki arama da eşleşmelerini aynı geri çağrıya raporlar.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadelerle Metni Vurgulama**

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

## **Sunum Genelinde Metni Vurgulama**

[Presentation.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/highlighttext/) ve [Presentation.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/highlightregex/) yöntemlerini kullanarak bir sunumdaki tüm uygulanabilir metin çerçevelerinde arama yapabilirsiniz. Aşağıdaki örnek, bir literal terimi ve tüm e‑posta adreslerini vurgular; iki arama için sonuç koleksiyonları ayrı tutulur.

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

## **Bir Metin Çerçevesinde Metni Değiştirme**

Literal metin için [ITextFrame.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replacetext/), desen‑tabanlı değiştirme için [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replaceregex/) kullanın. Bu yöntemler, mevcut metin çerçevesi içinde eşleşen metni günceller; böylece çerçeve, yalnızca düz bir dizeden yeniden oluşturulmak yerine çevresindeki bölüm biçimlendirmesini korur.

Aşağıdaki örnek, bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir. Aynı geri çağrı, iki işlemde de eşleşen orijinal terimleri kaydeder.

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

Bir eşleşme, farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı gözden geçirerek hangi biçimin değiştirme metnine uygulanacağını doğrulayın.

## **Sunum Genelinde Metni Değiştirme**

[Presentation.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/replacetext/) ve [Presentation.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/replaceregex/) kullanarak aynı işlemleri tüm sunuma uygulayabilirsiniz. Bu, şablon temizliği, terminoloji güncellemeleri ve redaksiyon için kullanışlıdır.

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

## **Raporlama için Eşleşmeleri Gruplama**

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

**Nasıl tüm sunum yerine yalnızca bir metin kutusunu arayabilirim?**

Şeklin metin çerçevesini alın ve o çerçeve üzerinde [ITextFrame.HighlightText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replacetext/) veya [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replaceregex/) çağırın. Sunum‑seviyesi yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Nasıl tam kelimeleri doğru büyük/küçük harfle eşleştirebilirim?**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/wholewordsonly/) ve [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/casesensitive/) seçeneklerini `true` olarak ayarlayın ve bu seçenekleri literal‑metin vurgulama veya değiştirme yöntemine geçirin. Düzenli ifadeler için, kelime sınırlarını ve büyük/küçük harf duyarlılığını .NET `Regex` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de içerebilir mi?**

Evet. Sunum‑seviyesi literal‑metin işlemi kullanırken [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/tr/net/aspose.slides/textsearchoptions/includenotes/) seçeneğini `true` yapın. Yukarıdaki geri çağrı uygulaması, not slaydındaki bir eşleşmeyi üst slayt numarasına bağlar.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

Vurgulama veya değiştirme işlemi sırasında bir [IFindResultCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/ifindresultcallback/) uygulaması sağlayın. Geri çağrı, işlem çalışırken her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra gruplamak veya dışa aktarmak için saklayabilir.

**Metni değiştirmek biçimini korur mu?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replacetext/) ve [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/replaceregex/) mevcut metin çerçevesi içinde eşleşen metni değiştirir ve çevresindeki bölüm biçimlendirmesini tutar. Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, değiştirme işleminin istediğiniz stili kullandığını doğrulamak için sonucu inceleyin.