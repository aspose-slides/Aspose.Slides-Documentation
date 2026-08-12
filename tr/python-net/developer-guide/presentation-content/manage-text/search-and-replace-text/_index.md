---
title: Python ile PowerPoint Sunumlarında Metin Arama ve Değiştirme
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

Aspose.Slides for Python via .NET, tek bir metin çerçevesinde ya da tüm bir sunumda metin arama, vurgulama ve değiştirme işlemleri yapabilir. Bu yetenekler inceleme, redaksiyon, terminoloji kontrolleri, şablon temizliği ve diğer otomatik belge işleme iş akışları için faydalıdır.

Aşağıdaki ilk örneklerde, ilk slaytta tek bir metin kutusu bulunan ve aşağıdaki metni içeren "sample.pptx" adlı bir dosya kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesiyle sınırlamak için [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) üzerindeki yöntemleri kullanın. Tüm sunumdaki geçerli metinleri işlemek için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) üzerindeki yöntemleri kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Doğrudan metni vurgula | [TextFrame.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/highlight_text/) |
| Düzenli ifade eşleşmelerini vurgula | [TextFrame.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/highlight_regex/) |
| Doğrudan metni değiştir | [TextFrame.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_text/) |
| Düzenli ifade eşleşmelerini değiştir | [TextFrame.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_regex/) |

## **Metin Eşleştirmeyi Yapılandır**

Doğrudan metin işlemleri için, eşleşmeyi kontrol etmek üzere [TextSearchOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/whole_words_only/) tam kelimelerle eşleşmeleri sınırlar.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/case_sensitive/) karakter büyük/küçük harfin eşleşmesi gerekip gerekmediğini kontrol eder.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/include_notes/) sunum düzeyinde arama, değiştirme ve vurgulama işlemlerine slayt notlarını dahil eder.

Düzenli ifade işlemleri bir desen dizesi kullanır, bu yüzden büyük/küçük harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifadeye göre tanımlanır.

## **Metni Vurgula**

Bir metin çerçevesindeki doğrudan metin eşleşmelerini vurgulamak için [TextFrame.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_text/) yöntemini kullanın. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/) geçirin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm oluşumlarını ve ardından sadece tam kelime **"to"** yi vurgular.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Metin çerçevesinde "try" ifadesinin her oluşumunu vurgula.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Yalnızca tam kelime "to" yu vurgula.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgula**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_regex/) yöntemi, bir metin çerçevesinde bir düzenli ifadeyle bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi ya da daha fazla karakter içeren tüm kelimeleri vurgular:

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

![Düzenli ifadeyle vurgulanan metin](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgula**

Bir sunumdaki tüm uygulanabilir metin çerçevelerini aramak için [Presentation.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/highlight_text/) ve [Presentation.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/highlight_regex/) kullanın. Aşağıdaki örnek doğrudan bir terimi ve tüm e-posta adreslerini vurgular:

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

## **Bir Metin Çerçevesinde Metni Değiştir**

Doğrudan metin için [TextFrame.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_text/), desen tabanlı değiştirme için ise [TextFrame.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_regex/) kullanın. Bu yöntemler, mevcut metin çerçevesi içinde eşleşen metni günceller ve çevresindeki bölümün biçimlendirmesini korur; metin çerçevesi tamamen yeni bir dizeyle yeniden oluşturulmaz.

Aşağıdaki örnek bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir:

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

Eğer bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı inceleyerek hangi biçimlendirmenin değiştirme metnine uygulanması gerektiğini doğrulayın.

## **Sunum Genelinde Metni Değiştir**

Aynı işlemleri tüm sunuma uygulamak için [Presentation.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_text/) ve [Presentation.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_regex/) kullanın. Bu, şablon temizliği, terminoloji güncellemeleri ve redaksiyon için faydalıdır.

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

**Nasıl sadece bir metin kutusunu tüm sunum yerine arayabilirim?**

Şeklin metin çerçevesini alın ve o çerçeve üzerinde [TextFrame.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_text/) veya [TextFrame.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_regex/) metodlarını çağırın. Sunum düzeyindeki yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Nasıl tam kelimeleri doğru büyük/küçük harfle eşleştirebilirim?**

Tam kelimeler ve doğru büyük/küçük harf eşleşmesi için [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/whole_words_only/) ve [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/case_sensitive/) seçeneklerini `True` olarak ayarlayın ve bu seçenekleri doğrudan metin vurgulama ya da değiştirme metoduna geçirin. Düzenli ifadeler için, kelime sınırlarını ve büyük/küçük harf duyarlılığını doğrudan desen içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni içerebilir mi?**

Evet. Sunum düzeyinde doğrudan metin işlemi kullanırken [TextSearchOptions.include_notes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/include_notes/) seçeneğini `True` olarak ayarlayın.

**Metni değiştirmek biçimlendirmesini korur mu?**

[TextFrame.replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_text/) ve [TextFrame.replace_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/replace_regex/) eşleşen metni mevcut metin çerçevesi içinde değiştirir ve çevresindeki bölümün biçimlendirmesini korur. Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, sonucu inceleyerek değiştirmenin istenen stilde olduğundan emin olun.