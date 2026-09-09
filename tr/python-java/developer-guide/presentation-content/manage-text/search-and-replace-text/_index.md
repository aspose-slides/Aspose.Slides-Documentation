---
title: Python aracılığıyla Java ile PowerPoint Sunumlarında Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/python-java/search-and-replace-text/
keywords:
- metin arama
- metin vurgulama
- metin değiştirme
- düzenli ifade
- sonuç geri çağırma
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında metin arama, vurgulama ve değiştirme işlemleri yaparken her eşleşmeyi toplar."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, tek bir metin çerçevesinde veya tüm bir sunum boyunca metin arama, vurgulama ve değiştirme yapabilir. Her işlem, sonuç geri çağrısı aracılığıyla her eşleşme hakkında uygulamayı da bilgilendirebilir. Bu, bir sunumu güncellerken eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izi oluşturmayı mümkün kılar.

Bu yetenekler, inceleme, karalama, terminoloji kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için faydalıdır.

Aşağıdaki ilk örneklerde, ilk slaytta tek bir metin kutusu içeren ve aşağıdaki metni barındıran "sample.pptx" adlı dosyayı kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

[TextFrame] üzerindeki yöntemleri kullanarak bir işlemi tek bir metin çerçevesiyle sınırlayabilirsiniz. [Presentation] üzerindeki yöntemleri kullanarak sunumdaki tüm uygulanabilir metni işleyebilirsiniz.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Literal metni vurgula | [TextFrame.highlightText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#highlightText) | [Presentation.highlightText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#highlightText) |
| Düzenli ifade eşleşmelerini vurgula | [TextFrame.highlightRegex](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#highlightRegex) | [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#highlightRegex) |
| Literal metni değiştir | [TextFrame.replaceText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#replaceText) | [Presentation.replaceText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#replaceText) |
| Düzenli ifade eşleşmelerini değiştir | [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#replaceRegex) | [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#replaceRegex) |

## **Metin Eşleştirmeyi Yapılandır**

Literal-metin işlemleri için, eşleşmeyi kontrol etmek amacıyla [TextSearchOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textsearchoptions/) kullanın:

- [setWholeWordsOnly](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) eşleşmeleri yalnızca tam kelimelerle sınırlar.
- [setCaseSensitive](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) karakterin büyük/küçük harf eşleşmesi gerekip gerekmediğini kontrol eder.
- [setIncludeNotes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) sunum seviyesindeki arama, değiştirme ve vurgulama işlemlerinde slayt notlarını da içerir.

Düzenli ifade işlemleri bir Java `Pattern` kullanır; bu yüzden büyük/küçük harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifadenin ve bayraklarının içinde tanımlanır.

## **Bir Metin Çerçevesinin Sahibini Belirleme**

Genel metin işleme iş akışları genellikle arama, değiştirme, doğrulama veya metin dışa aktarma sırasında bir [TextFrame] alır. Metin çerçevesinin hangi sunum nesnesine ait olduğunu belirlemek için [TextFrame.getParentShape] ve [TextFrame.getParentCell] kullanın.

Beklenen değerler sahibi nesneye bağlıdır:

| Metin çerçevesi sahibi | `getParentShape` | `getParentCell` |
|---|---|---|
| Bir [AutoShape] veya başka bir metin içeren şekil | Sahip olan [Shape] | `None` |
| Bir tablo hücresi | `None` | Sahip olan [Cell] |

Her iki yöntem de yalnızca okunabilir gezinme sağlar. Bunları çağırmak metin çerçevesini taşımaz veya sahibini değiştirmez. Genel kod, her iki değeri de `None` için kontrol etmeli ve hiçbir sahibin mevcut olmama olasılığını ele almalıdır.

İşte aşağıdaki örnek, bir sunumdaki metin çerçevelerini yinelemek için [SlideUtil.getAllTextFrames] kullanır. Şekiller için şekil adını, Java çalışma zamanı tipini ve içinde bulunduğu slaytı rapor eder. Tablo hücreleri için sıfır tabanlı sütun ve satır koordinatlarını ve içinde bulunduğu slaytı rapor eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

presentation = Presentation("presentation.pptx")
try:
    text_frames = SlideUtil.getAllTextFrames(presentation, False)
    for text_frame in text_frames:
        owner_shape = text_frame.getParentShape()
        owner_cell = text_frame.getParentCell()
        if owner_shape is not None:
            shape_name = str(owner_shape.getName()) or "(unnamed)"
            shape_type = owner_shape.getClass().getSimpleName()
            base_slide = owner_shape.getSlide()
        elif owner_cell is not None:
            base_slide = owner_cell.getSlide()
        else:
            print("The text frame owner is not available as a shape or table cell.")
            continue

        if isinstance(base_slide, Slide):
            slide_label = f"slide {base_slide.getSlideNumber()}"
        elif isinstance(base_slide, NotesSlide):
            slide_label = f"notes for slide {base_slide.getParentSlide().getSlideNumber()}"
        else:
            slide_label = str(base_slide.getClass().getSimpleName())

        if owner_shape is not None:
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
        else:
            print(f"Table cell: column {owner_cell.getFirstColumnIndex()}, row {owner_cell.getFirstRowIndex()}; {slide_label}")
finally:
    presentation.dispose()
```

SmartArt içeriği için, [SmartArtNode.getShapes] içindeki şekiller üzerinden yineleyin ve her bir [SmartArtShape.getTextFrame] erişin. Metin çerçevesi, ilgili şekle [TextFrame.getParentShape] aracılığıyla izlenebilir, [TextFrame.getParentCell] ise `None` döndürür. Bu nedenle, örnekteki şekil dalı SmartArt düğümlerinden gelen metni de işler.

## **Eşleşme Bilgilerini Geri Çağırma ile Toplama**

`jpype.JProxy` aracılığıyla `IFindResultCallback` uygulayarak her eşleşme için bir bildirim alabilirsiniz. `foundResult` metodu ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşme konumunu sağlar.

Geri çağırma doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, bunu üst slayttan türetir ve slayt notlarında bulunan metni de işler. İsteğe bağlı bir slayt numarası, aynı sonuç modelinin diğer slayt türleriyle ilişkili metni temsil etmesine olanak tanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)
```

Değiştirme işlemleri için, `found_text` orijinal eşleşen metni içerir, böylece geri çağırma tam olarak hangi terimlerin değiştirildiğini kaydedebilir.

## **Metni Vurgulama**

Metin çerçevesinde literal metin eşleşmelerini vurgulamak için [TextFrame.highlightText] metodunu kullanın. Aramayı kontrol etmek için [TextSearchOptions] ve eşleşme detaylarını toplamak için bir geri çağırma sağlayın.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm tekrarlarını vurgular ve ardından yalnızca tam **"to"** kelimesini vurgular. Her iki arama da eşleşmelerini aynı geri çağırmaya rapor eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)

    substring_search_options = TextSearchOptions()
    substring_search_options.setCaseSensitive(False)
    substring_highlight_color = Color(173, 216, 230)

    # Metin çerçevesinde "try" ifadesinin her oluşumunu vurgula.
    shape.getTextFrame().highlightText("try", substring_highlight_color, substring_search_options, callback)

    whole_word_search_options = TextSearchOptions()
    whole_word_search_options.setWholeWordsOnly(True)
    whole_word_search_options.setCaseSensitive(False)
    whole_word_highlight_color = Color(238, 130, 238)

    # Yalnızca tam kelime "to"yu vurgula.
    shape.getTextFrame().highlightText("to", whole_word_highlight_color, whole_word_search_options, callback)

    for result in callback_handler.results:
        print(f"Found '{result.found_text}' at position {result.text_position} on slide {result.slide_number}.")

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgulama**

[TextFrame.highlightRegex] metodu, bir metin çerçevesinde düzenli ifade ile bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular ve her eşleşmeyi toplar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    regex = Pattern.compile("\\b[^\\s]{7,}\\b")

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback)

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Düzenli ifade kullanarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgulama**

Bir sunumdaki tüm uygulanabilir metin çerçevelerini aramak için [Presentation.highlightText] ve [Presentation.highlightRegex] kullanın. Aşağıdaki örnek, iki arama için ayrı sonuç koleksiyonları tutarak bir literal terimi ve tüm e-posta adreslerini vurgular.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    term_callback_handler = TextSearchCallback()
    term_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=term_callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    presentation.highlightText("confidential", Color.ORANGE, search_options, term_callback)

    email_callback_handler = TextSearchCallback()
    email_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=email_callback_handler)
    email_regex = Pattern.compile("\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", Pattern.CASE_INSENSITIVE)

    presentation.highlightRegex(email_regex, Color.YELLOW, email_callback)
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Metin Çerçevesinde Metin Değiştirme**

Literal metin için [TextFrame.replaceText] ve desen tabanlı değiştirme için [TextFrame.replaceRegex] kullanın. Bu yöntemler, mevcut metin çerçevesi içinde eşleşen metni günceller; bu da metin çerçevesini düz bir dizeden yeniden oluşturmak yerine çevresindeki bölüm biçimlendirmesini korur.

Aşağıdaki örnek, bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir. Aynı geri çağırma, her iki işlemde eşleşen orijinal terimleri kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    shape.getTextFrame().replaceText("colour", "color", search_options, callback)

    version_regex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE)
    shape.getTextFrame().replaceRegex(version_regex, "current version", callback)

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Eğer bir eşleşme, farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı inceleyerek hangi biçimlendirmenin değiştirme metnine uygulanması gerektiğini doğrulayın.

## **Sunum Genelinde Metin Değiştirme**

Aynı işlemleri sunum genelinde uygulamak için [Presentation.replaceText] ve [Presentation.replaceRegex] kullanın. Bu, şablon temizliği, terminoloji güncellemeleri ve karalama için faydalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Raporlama İçin Eşleşmeleri Gruplama**

Her sonuç slayt numarasını ve metin çerçevesini sakladığından, uygulamalar denetim, raporlama veya inceleme iş akışları için eşleşmeleri gruplandırabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, ardından metin çerçevesine göre gruplar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
    matches_by_slide = {}
    for result in callback_handler.results:
        matches_by_text_frame = matches_by_slide.setdefault(result.slide_number, {})
        text_frame_matches = matches_by_text_frame.setdefault(result.text_frame, [])
        text_frame_matches.append(result)

    for slide_number, matches_by_text_frame in matches_by_slide.items():
        slide_label = "Other" if slide_number is None else str(slide_number)
        print(f"Slide: {slide_label}")
        for text_frame, results in matches_by_text_frame.items():
            print(f"  Text frame: {text_frame.getText()}")
            for result in results:
                print(f"    '{result.found_text}' at position {result.text_position}; context: '{result.source_text}'")
finally:
    presentation.dispose()
```

## **SSS**

**Nasıl sadece bir metin kutusunu, tüm sunum yerine arayabilirim?**

Şeklin metin çerçevesini alın ve o metin çerçevesi üzerinde [TextFrame.highlightText], [TextFrame.highlightRegex], [TextFrame.replaceText] veya [TextFrame.replaceRegex] metodlarını çağırın. Sunum seviyesindeki yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Tam kelimeleri doğru büyük/küçük harfle nasıl eşleştirebilirim?**

[TextSearchOptions.setWholeWordsOnly] ve [TextSearchOptions.setCaseSensitive] değerlerini `True` olarak ayarlayın ve bu seçenekleri literal metin vurgulama veya değiştirme metoduna iletin. Düzenli ifadeler için, kelime sınırlarını ve büyük/küçük harf duyarlılığını doğrudan Java `Pattern` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de içerebilir mi?**

Evet. Sunum seviyesindeki bir literal metin işlemi kullanırken [TextSearchOptions.setIncludeNotes] değerini `True` olarak ayarlayın. Yukarıda gösterilen geri çağırma uygulaması, not slaytındaki bir eşleşmeyi üst slayt numarasına geri eşler.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

Vurgulama veya değiştirme işlemi sırasında bir `IFindResultCallback` uygulamasını iletin. Geri çağırma, işlem çalışırken her eşleşmeyi alır; bu sayede uygulama daha sonraki gruplama veya dışa aktarma için kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını depolayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[TextFrame.replaceText] ve [TextFrame.replaceRegex] mevcut metin çerçevesi içinde eşleşen metni değiştirir ve çevresindeki bölüm biçimlendirmesini korur. Eğer bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, sonuçları inceleyerek değiştirmenin istenen stili kullandığından emin olun.