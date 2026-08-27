---
title: Java ile PowerPoint Sunumlarında Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/java/search-and-replace-text/
keywords:
- metin arama
- metin vurgulama
- metin değiştirme
- düzenli ifade
- sonuç geri çağrısı
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile her eşleşmeyi toplarken PowerPoint sunumlarında metin arama, vurgulama ve değiştirme."
---
## **Genel Bakış**

Aspose.Slides for Java, bireysel bir metin çerçevesinde veya tüm sunu boyunca metin arayabilir, vurgulayabilir ve değiştirebilir. Her işlem aynı zamanda bir sonuç geri çağrısı aracılığıyla her eşleşme hakkında uygulamayı bilgilendirebilir. Bu, bir sunuyu güncellerken eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izini aynı anda oluşturmayı mümkün kılar.

Bu yetenekler inceleme, redaksiyon, terminoloji kontrolleri, şablon temizleme ve otomatik raporlama iş akışları için yararlıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan **sample.pptx** adlı dosyayı kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesiyle sınırlamak için [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) üzerindeki yöntemleri kullanın. Sunudaki tüm geçerli metni işlemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) üzerindeki yöntemleri kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunu |
|---|---|---|
| Düz metni vurgula | [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini vurgula | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Düz metni değiştir | [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini değiştir | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Metin Eşleştirmeyi Yapılandırma**

Literal-metin işlemleri için eşleşmeyi kontrol etmek amacıyla [TextSearchOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) eşleşmeleri yalnızca tam sözcüklerle sınırlar.  
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) karakter büyük/küçük harf duyarlılığını kontrol eder.  
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) slayt notlarını da sunu düzeyinde arama, değiştirme ve vurgulama işlemlerine dahil eder.

Regular ifade işlemleri bir Java `Pattern` kullanır, bu nedenle büyük/küçük harf duyarlılığı ve sözcük sınırları gibi eşleşme kuralları ifadenin ve bayraklarının tanımladığı şekildedir.

## **Bir Metin Çerçevesinin Sahibini Belirleme**

Genel metin işleme iş akışları, metin ararken, değiştirirken, doğrularken veya dışa aktarırken sıklıkla bir [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) alır. Metin çerçevesinin hangi sunu nesnesine ait olduğunu belirlemek için [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentShape--) ve [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentCell--) kullanın.

Beklenen değerler sahibine bağlıdır:

| Metin çerçevesi sahibi | `getParentShape` | `getParentCell` |
|---|---|---|
| Bir AutoShape veya başka bir metin içeren şekil | Sahip olan [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) | `null` |
| Bir tablo hücresi | `null` | Sahip olan [ICell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icell/) |

Her iki yöntem de yalnızca okuma amaçlı gezinme sağlar. Bunları çağırmak metin çerçevesini taşımaz veya sahibini değiştirmez. Genel kod, her iki değeri de `null` için kontrol etmeli ve hiçbir sahibin mevcut olmama ihtimalini ele almalıdır.

Aşağıdaki örnek, bir sunudaki metin çerçevelerini yinelemek için [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) kullanır. Şekiller için şekil adını, Java çalışma zamanı türünü ve içeren slaytı raporlar. Tablo hücreleri için sıfır tabanlı sütun ve satır koordinatlarını ve içeren slaytı raporlar.

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

SmartArt içeriği için, [ISmartArtNode.getShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ismartartnode/#getShapes--) içindeki şekilleri yineleyin ve her bir [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ismartartshape/#getTextFrame--) erişin. Metin çerçevesi, [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentShape--) aracılığıyla ilişkili şekle izlenebilir, [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentCell--) ise `null` döndürür. Bu nedenle, örnekteki şekil dalı SmartArt düğümlerinden gelen metni de işler.

## **Eşleşme Bilgilerini Geri Çağrı ile Toplama**

Her eşleşme için bir bildirim almak üzere [IFindResultCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifindresultcallback/) uygulayın. Bunun [IFindResultCallback.foundResult](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) metodu ilgili metin çerçevesi, kaynak metin, eşleşen metin ve eşleşme konumunu sağlar.

Geri çağrı doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, onu üst slayttan türetir ve slayt notlarında bulunan metni de işler. Nullable bir `Integer`, aynı sonuç modelinin diğer slayt türleriyle ilişkili metni temsil etmesini sağlar.

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

Değiştirme işlemleri için, `foundText` orijinal eşleşen metni içerir; böylece geri çağrı tam olarak hangi terimlerin değiştirildiğini kaydedebilir.

## **Metni Vurgulama**

Bir metin çerçevesindeki literal metin eşleşmelerini vurgulamak için [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metodunu kullanın. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/) ve eşleşme detaylarını toplamak için bir geri çağrı gönderin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm oluşumlarını ve ardından yalnızca tam **"to"** kelimesini vurgular. Her iki arama da eşleşmelerini aynı geri çağrıya rapor eder.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Metin çerçevesindeki "try" ifadesinin her oluşumunu vurgula.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Sadece tam kelime "to"yu vurgula.
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

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgulama**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) metodu, bir metin çerçevesinde düzenli ifade ile bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm sözcükleri vurgular ve her eşleşmeyi toplar:

```java
import com.aspose.slides.*;
import java.awt.Color;
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

![Düzenli ifade kullanarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunuda Metni Vurgulama**

Bir sunudaki tüm geçerli metin çerçevelerini aramak için [Presentation.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) kullanın. Aşağıdaki örnek, iki arama için ayrı sonuç koleksiyonları tutarak bir literal terimi ve tüm e-posta adreslerini vurgular.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

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

Literal metin için [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)..., desen tabanlı değiştirme için [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)... kullanın. Bu metodlar, mevcut metin çerçevesi içinde eşleşen metni günceller ve metin çerçevesini düz bir dizeden yeniden oluşturmak yerine çevresindeki bölüm formatlamasını korur.

Aşağıdaki örnek, bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir. Aynı geri çağrı, her iki işlem tarafından eşleşen orijinal terimleri kaydeder.

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

Eğer bir eşleşme farklı formatlamalı bölümleri kapsıyorsa, çıkışı inceleyerek hangi formatlamanın değiştirme metnine uygulanması gerektiğini doğrulayın.

## **Sunuda Metni Değiştirme**

Aynı işlemleri tüm sunu boyunca uygulamak için [Presentation.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanın. Bu, şablon temizleme, terminoloji güncellemeleri ve redaksiyon için yararlıdır.

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

Her sonuç slayt numarasını ve metin çerçevesini depoladığından, uygulamalar eşleşmeleri denetim, raporlama veya inceleme iş akışları için gruplayabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, ardından metin çerçevesine göre gruplar:

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

**Sadece bir metin kutusunu tüm sunu yerine nasıl arayabilirim?**

Şeklin metin çerçevesini alın ve bu metin çerçevesinde [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), veya [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) yöntemlerini çağırın. Sunu düzeyindeki yöntemler tüm geçerli metin çerçevelerini işler.

**Tam sözcükleri doğru büyük/küçük harf duyarlılığıyla nasıl eşleştirebilirim?**

[TextSearchOptions.setWholeWordsOnly] ve [TextSearchOptions.setCaseSensitive] seçeneklerini `true` olarak ayarlayın ve bu seçenekleri literal metin vurgulama veya değiştirme metoduna gönderin. Düzenli ifadeler için, sözcük sınırlarını ve büyük/küçük harf duyarlılığını Java `Pattern` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de içerebilir mi?**

Evet. Sunu düzeyinde literal metin işlemi kullanırken [TextSearchOptions.setIncludeNotes] seçeneğini `true` olarak ayarlayın. Yukarıdaki geri çağrı uygulaması, not slaytındaki bir eşleşmeyi üst slayt numarasına eşler.

**Sunuyu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

[IFindResultCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifindresultcallback/) uygulamasını vurgulama veya değiştirme işlemine gönderin. Geri çağrı, işlem çalışırken her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra grup oluşturma veya dışa aktarma için depolayabilir.

**Metni değiştirmek formatını korur mu?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) mevcut metin çerçevesi içinde eşleşen metni değiştirir ve çevresindeki bölüm formatlamasını korur. Eğer bir eşleşme farklı formatlamalı bölümleri kapsıyorsa, sonucu inceleyerek değiştirmenin istenen stili kullandığından emin olun.