---
title: Android'de PowerPoint Sunumlarında Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/androidjava/search-and-replace-text/
keywords:
- metin ara
- metin vurgula
- metin değiştir
- düzenli ifade
- sonuç geri çağrımı
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint sunumlarında metin arama, vurgulama ve değiştirme yaparken, her eşleşmeyi Android için Aspose.Slides via Java ile toplayın."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, bireysel bir metin çerçevesinde ya da tüm sunumda metin arama, vurgulama ve değiştirme işlemleri yapabilir. Her işlem ayrıca bir sonuç geri çağrısı aracılığıyla her eşleşme hakkında uygulamaya bildirimde bulunabilir. Bu sayede bir sunumu güncellerken eşleşen metin, bağlamı, konumu, metin çerçevesi ve slayt numarasını içeren bir denetim izi oluşturmak mümkün olur.

Bu yetenekler inceleme, kırpma, terminoloji denetimi, şablon temizliği ve otomatik raporlama iş akışları için yararlıdır.

Aşağıdaki ilk örneklerde, ilk slaytta tek bir metin kutusu bulunan ve aşağıdaki metni içeren “sample.pptx” adlı dosya kullanılmaktadır:

![Sample text](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesine sınırlamak için [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) üzerindeki yöntemleri kullanın. Sunumdaki tüm uygulanabilir metni işlemek için [IPresentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/) üzerindeki yöntemleri kullanın.

| İşlem | Tek bir metin çerçevesi | Tüm sunum |
|---|---|---|
| Düz metni vurgula | [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini vurgula | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Düz metni değiştir | [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini değiştir | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Metin Eşleşmesini Yapılandırma**

Düz‑metin işlemleri için eşleşmeyi kontrol etmek amacıyla [TextSearchOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) eşleşmeleri yalnızca tam kelimelerle sınırlar.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) karakterlerin büyük/küçük harf duyarlılığını kontrol eder.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) slayt notlarını sunum‑seviyesindeki arama, değiştirme ve vurgulama işlemlerine dahil eder.

Düzenli ifade işlemleri bir Java `Pattern` kullanır; bu nedenle büyük/küçük harf duyarlılığı ve kelime sınırları gibi kurallar ifadenin kendisi ve bayraklarıyla tanımlanır.

## **Bir Metin Çerçevesinin Sahibini Belirleme**

Genel metin işleme iş akışları genellikle arama, değiştirme, doğrulama ya da dışa aktarma sırasında bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) alır. Metin çerçevesinin hangi sunum nesnesine ait olduğunu belirlemek için [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentShape--) ve [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentCell--) kullanın.

Beklenen değerler sahibine göre değişir:

| Metin çerçevesi sahibi | `getParentShape` | `getParentCell` |
|---|---|---|
| Bir AutoShape ya da başka bir metin‑içeren şekil | Sahibi olan [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) | `null` |
| Bir tablo hücresi | `null` | Sahibi olan [ICell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/) |

Her iki yöntem sadece okuma‑yönlü gezinme sağlar. Çağrıldıklarında metin çerçevesini taşımaz ya da sahibini değiştirmez. Genel kod, her iki değeri de `null` için kontrol etmeli ve hiçbir sahibin bulunmadığı durumları ele almalıdır.

Aşağıdaki örnek, bir sunumdaki metin çerçevelerini yinelemek için [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) yöntemini kullanır. Şekiller için şekil adı, Java çalışma zamanı türü ve içinde bulunduğu slayt raporlanır. Tablo hücreleri için sıfır‑tabanlı sütun ve satır koordinatları ve içinde bulunduğu slayt raporlanır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

SmartArt içeriği için, [ISmartArtNode.getShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartartnode/#getShapes--) yöntemindeki şekiller yineleyin ve her bir [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) öğesine erişin. Metin çerçevesi, [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentShape--) aracılığıyla ilişkili şekle izlenebilir; [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentCell--) ise `null` döndürür. Bu yüzden örnek içindeki şekil dalı, SmartArt düğümlerinden gelen metni de işler.

## **Bir Geri Çağrım ile Eşleşme Bilgilerini Toplama**

Her eşleşme için bir bildirim almak üzere [IFindResultCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifindresultcallback/) uygulayın. Bu arayüzün [IFindResultCallback.foundResult](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) yöntemi ilgili metin çerçevesi, kaynak metin, eşleşen metin ve eşleşme konumunu sağlar.

Geri çağrım doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, bunu üst slayttan türetir ve slayt notlarında bulunan metni de işler. Nullable bir `Integer` aynı sonuç modelinin diğer slayt türleriyle ilişkili metni temsil etmesine imkan tanır.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Değiştirme işlemleri için, `foundText` orijinal eşleşen metni içerir; böylece geri çağrım hangi terimlerin değiştirildiğini kesin olarak kaydedebilir.

## **Metni Vurgulama**

Bir metin çerçevesinde düz‑metin eşleşmelerini vurgulamak için [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) yöntemini kullanın. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/) ve eşleşme ayrıntılarını toplamak için bir geri çağrım geçirin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm görünümlerini vurgular ve ardından yalnızca tam kelime **"to"** yi vurgular. Her iki arama da aynı geri çağrıma eşleşmelerini raporlar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // Metin çerçevesindeki "try" ifadesinin her görünümünü vurgula.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Yalnızca tam kelime "to" yu vurgula.
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The highlighted text](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgulama**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) yöntemi, bir metin çerçevesinde düzenli ifade tarafından bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular ve her eşleşmeyi toplar:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgulama**

Tüm uygulanabilir metin çerçevelerinde arama yapmak için [IPresentation.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [IPresentation.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) kullanılabilir. Aşağıdaki örnek, bir düz terimi ve tüm e‑posta adreslerini ayrı sonuç koleksiyonlarıyla vurgular.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Metin Çerçevesinde Metni Değiştirme**

Düz metin için [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), desen‑tabanlı değiştirme için ise [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) yöntemlerini kullanın. Bu yöntemler mevcut metin çerçevesindeki eşleşen metni günceller; böylece etrafındaki biçimlendirme korunur ve çerçeve yeni bir dizeyle yeniden oluşturulmaz.

Aşağıdaki örnek, bir heceleme varyantını standart hâle getirir ve ardından sürüm etiketlerini değiştirir. Aynı geri çağrım, her iki işlemde de eşleşen özgün terimleri kaydeder.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıdaki biçimlendirmeyi gözden geçirerek hangi stilin uygulanması gerektiğini doğrulayın.

## **Sunum Genelinde Metni Değiştirme**

Sunum genelinde aynı işlemleri uygulamak için [IPresentation.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [IPresentation.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanın. Bu, şablon temizliği, terminoloji güncellemeleri ve kırpma için yararlıdır.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Raporlama İçin Eşleşmeleri Gruplama**

Her sonuç slayt numarası ve metin çerçevesi içerdiğinden, uygulamalar denetim, raporlama ya da inceleme iş akışları için eşleşmeleri gruplayabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, sonra metin çerçevesine göre gruplayarak gösterir:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **SSS**

**Sadece bir metin kutusunda, tüm sunumu değil, nasıl arama yapabilirim?**

Şeklin metin çerçevesini alın ve o çerçeve üzerinde [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ya da [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) yöntemlerini çağırın. Sunum‑seviyesindeki yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Tam kelimeleri doğru büyük/küçük harfle nasıl eşleştirebilirim?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ve [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) seçeneklerini `true` yapın ve bu seçenekleri düz‑metin vurgulama veya değiştirme yöntemine geçirin. Düzenli ifadeler için ise kelime sınırlarını ve duyarlılığı Java `Pattern` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de kapsar mı?**

Evet. Sunum‑seviyesindeki düz‑metin işlemi kullanırken [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) seçeneğini `true` yapın. Yukarıdaki geri çağrım uygulaması, bir not slaydındaki eşleşmeyi ana slayt numarasına geri eşler.

**Sunumu ikinci kez taramadan bir rapor oluşturabilir miyim?**

[Varlık] bir [IFindResultCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifindresultcallback/) uygulamasını vurgulama ya da değiştirme işlemine aktarın. Geri çağrım işlem sırasında her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonraki gruplama ya da dışa aktarma için saklayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) yöntemleri, mevcut metin çerçevesindeki eşleşen metni değiştirir ve çevredeki biçimlendirmeyi korur. Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, sonuçtaki biçimlemenin istenen stil olduğundan emin olmak için çıktıyı inceleyin.