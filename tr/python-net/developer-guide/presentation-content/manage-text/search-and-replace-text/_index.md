---
title: Python'da PowerPoint Sunumlarında Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/python-net/search-and-replace-text/
keywords:
- metin arama
- metin vurgulama
- metin değiştirme
- düzenli ifade
- metin çerçevesi
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint sunumlarında metin arama, vurgulama ve değiştirme."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, tek bir metin çerçevesinde veya bir sunumun tamamında metin arama, vurgulama ve değiştirme işlemleri yapabilir. Bu özellikler inceleme, redaksiyon, terminoloji kontrolleri, şablon temizliği ve diğer otomatik belge işleme iş akışları için kullanışlıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan "sample.pptx" adlı dosyayı kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesine sınırlamak için [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) yöntemlerini kullanın. Sunumdaki tüm uygulanabilir metinleri işlemek için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yöntemlerini kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Düz metni vurgula | [TextFrame.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/highlight_text/) |
| Düzenli ifade eşleşmelerini vurgula | [TextFrame.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/highlight_regex/) |
| Düz metni değiştir | [TextFrame.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_text/) |
| Düzenli ifade eşleşmelerini değiştir | [TextFrame.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_regex/) |

## **Metin Eşleştirmesini Yapılandırma**

Düz metin işlemleri için eşleştirmeyi kontrol etmek amacıyla [TextSearchOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/whole_words_only/) eşleşmeleri yalnızca tam kelimelerle sınırlı tutar.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/case_sensitive/) karakter büyük/küçük harf eşleşmesini kontrol eder.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/include_notes/) slayt notlarını sunum düzeyinde arama, değiştirme ve vurgulama işlemlerine dahil eder.

Düzenli ifade işlemleri bir desen dizesi kullanır, böylece büyük/küçük harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifadenin içinde tanımlanır.

## **Bir Metin Çerçevesinin Sahibini Belirleme**

Genel metin işleme iş akışları, metin arama, değiştirme, doğrulama veya dışa aktarma sırasında sıklıkla bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) alır. Metin çerçevesinin hangi sunum nesnesine ait olduğunu belirlemek için [TextFrame.parent_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_shape/) ve [TextFrame.parent_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_cell/) kullanın.

Beklenen değerler sahibine bağlıdır:

| Metin çerçevesi sahibi | `parent_shape` | `parent_cell` |
|---|---|---|
| Bir AutoShape veya başka bir metin içeren şekil | The owning [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) | `None` |
| Bir tablo hücresi | `None` | The owning [Cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/) |

Her iki özellik de yalnızca okunabilir gezinme özellikleridir. Bunları okumak metin çerçevesini taşımaz veya sahibini değiştirmez. Genel kod, her iki değeri de `None` için kontrol etmeli ve hiçbir sahibin mevcut olmama olasılığını ele almalıdır.

Aşağıdaki örnek, bir sunumdaki metin çerçevelerini yinelemek için [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/get_all_text_frames/) kullanır. Şekiller için şekil adını, Python çalışma zamanı tipini ve içinde bulunduğu slaytı raporlar. Tablo hücreleri için sıfırıncı indeksli sütun ve satır koordinatlarını ve içinde bulunduğu slaytı raporlar.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

SmartArt içeriği için, [SmartArtNode.shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartartnode/shapes/) içindeki şekiller üzerinde döngü yapın ve her bir [ISmartArtShape.text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/ismartartshape/text_frame/) öğesine erişin. Metin çerçevesi, ilişkili şekle [TextFrame.parent_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_shape/) aracılığıyla izlenebilir, [TextFrame.parent_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_cell/) ise `None`'dır. Bu nedenle, örnekteki şekil dalı SmartArt düğümlerinden gelen metni de işler.

## **Metni Vurgulama**

[TextFrame.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_text/) metodunu, bir metin çerçevesindeki düz metin eşleşmelerini vurgulamak için kullanın. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/) gönderin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm görünümlerini vurgular ve ardından yalnızca tam kelime **"to"**'yu vurgular.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Metin çerçevesindeki "try" ifadesinin tüm tekrarlarını vurgula.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Yalnızca tam "to" kelimesini vurgula.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgulama**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_regex/) metodu, bir metin çerçevesinde düzenli ifade tarafından bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Sonuç:

![Düzenli ifade kullanılarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgulama**

[Presentation.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/highlight_text/) ve [Presentation.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/highlight_regex/) yöntemlerini kullanarak bir sunumdaki tüm uygulanabilir metin çerçevelerinde arama yapın. Aşağıdaki örnek, bir düz terimi ve tüm e-posta adreslerini vurgular:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Bir Metin Çerçevesinde Metni Değiştirme**

Düz metin için [TextFrame.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_text/) ve desen tabanlı değiştirme için [TextFrame.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_regex/) kullanın. Bu metodlar, mevcut metin çerçevesi içinde eşleşen metni günceller; bu, metin çerçevesini sade bir dizeden yeniden oluşturmak yerine çevreleyen kısmın biçimlendirmesini korur.

Aşağıdaki örnek, bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı inceleyerek hangi biçimlemenin değiştirilmiş metne uygulanması gerektiğini doğrulayın.

## **Sunum Genelinde Metni Değiştirme**

[Presentation.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_text/) ve [Presentation.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_regex/) yöntemlerini kullanarak aynı işlemleri tüm sunumda uygulayın. Bu, şablon temizliği, terminoloji güncellemeleri ve redaksiyon için yararlıdır.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **SSS**

**Tüm sunum yerine sadece bir metin kutusunda nasıl arama yapabilirim?**

Şeklin metin çerçevesini alın ve o metin çerçevesinde [TextFrame.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_text/) veya [TextFrame.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_regex/) metodlarını çağırın. Sunum düzeyindeki metodlar ise tüm uygulanabilir metin çerçevelerini işler.

**Doğru büyük/küçük harfle tam kelimeleri nasıl eşleştirebilirim?**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/whole_words_only/) ve [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/case_sensitive/) seçeneklerini `True` olarak ayarlayın ve bu seçenekleri düz metin vurgulama veya değiştirme metoduna geçirin. Düzenli ifadeler için kelime sınırlarını ve büyük/küçük harf duyarlılığını desende kendiniz tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de içerebilir mi?**

Evet. Sunum düzeyinde bir düz metin işlemi kullanırken [TextSearchOptions.include_notes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/include_notes/) seçeneğini `True` olarak ayarlayın.

**Metni değiştirmek biçimlendirmesini korur mu?**

[TextFrame.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_text/) ve [TextFrame.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_regex/) metodları, mevcut metin çerçevesindeki eşleşen metni değiştirir ve çevreleyen kısmın biçimlendirmesini korur. Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, sonuçları inceleyerek değiştirilen metnin istenen stili kullandığından emin olun.