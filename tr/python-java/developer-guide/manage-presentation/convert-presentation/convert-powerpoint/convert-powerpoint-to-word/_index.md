---
title: Python üzerinden Java ile PowerPoint Sunumlarını Word Belgelerine Dönüştür
linktitle: PowerPoint'tan Word'e
type: docs
weight: 110
url: /tr/python-java/convert-powerpoint-to-word/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- PowerPoint'tan Word'e
- sunumdan Word'e
- PPT'den Word'e
- PPTX'den Word'e
- ODP'den Word'e
- PowerPoint'tan DOCX'e
- PPT'den DOCX'e
- PPTX'den DOCX'e
- PowerPoint'tan DOC'a
- PPT'yi DOCX olarak kaydet
- PPTX'i DOCX olarak kaydet
- PPT'yi DOCX'e dışa aktar
- PPTX'i DOCX'e dışa aktar
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ve Aspose.Words kullanarak Python üzerinden Java ile PowerPoint ve OpenDocument sunumlarını Word'e dönüştürün; slayt görsellerini düzenlenebilir metinle birleştirir."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java ile birlikte Aspose.Words for Java kullanarak PowerPoint ve OpenDocument sunumlarını Word belgelerine nasıl dönüştüreceğinizi açıklar. Aspose.Slides her slaytı görüntüler ve metnini okur, Aspose.Words ise JPype aracılığıyla Word belgesini oluşturur. Microsoft Office gerekli değildir.

Ortaya çıkan belgede, bir slayt resmi ve ardından o slaydın üst seviye otomatik şekillerinden çıkarılan düzenlenebilir metin bulunur. Görüntü slaydın görsel görünümünü korur; tek tek şekiller, grafikler ve tablolar düzenlenebilir Word nesnelerine dönüştürülmez. Çıkarılan metin orijinal metin biçimlendirmesini veya konumlandırmasını korumaz.

## **PowerPoint'ı Word'e Dönüştür**

1. Aspose.Slides for Python via Java'ı [Aspose.Slides for Python via Java](/slides/tr/python-java/installation/) ve uyumlu bir Java çalışma zamanı kurun.
2. Aspose.Words for Java'ı [Aspose.Words for Java](https://releases.aspose.com/words/java/) indirin. Ana JAR dosyasını betiğinizin yanındaki bir `lib` klasörüne koyun ve adını `aspose-words.jar` olarak değiştirin, ya da örnekteki yolu indirdiğiniz dosyayla eşleşecek şekilde ayarlayın.
3. Giriş sunumunu, `sample.pptx` dosyasını çalışma dizinine koyun. `lib/aspose-words.jar` yolu da bu dizine göredir.
4. `output.docx` dosyasını oluşturmak için aşağıdaki Python kodunu çalıştırın.

Örnek, kaynağı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile yükler ve slaytları [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) ile görüntüler. Aspose.Words'tan [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) kullanarak görüntüleri ve metni Word belgesine ekler.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Slayt görüntüsünü metin alanının genişliğine uydurun, en‑boy oranını koruyarak.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Üst seviye otomatik şekillerden, metin kutularını da içerecek şekilde düz metni ekleyin.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Her slayt yeni bir sayfada başlar. Uzun çıkarılan metin veya aşırı yüksek slayt görselleri ek sayfalar gerektirebilir. Kod, yalnızca slaytlar arasında sayfa sonları ekler ve `finally` bloklarında sunumu ve oluşturulan görselleri serbest bırakır. JVM, aynı Python sürecindeki sonraki dönüşümler için kullanılabilir durumda kalır.

## **SSS**

**Gerekli kütüphaneler nelerdir?**

Aspose.Slides for Python via Java, JPype, uyumlu bir Java çalışma zamanı ve Aspose.Words for Java kullanın. Her iki Aspose kütüphanesi aynı JVM içinde çalışır. Aspose.Slides sunumu işler; Aspose.Words Word belgesini yazar.

**PPT ve ODP dosyalarını da PPTX gibi dönüştürebilir miyim?**

Evet. `sample.pptx` dosyasını bir PPT veya ODP dosyasıyla değiştirin. Sunum giriş formatları için [Supported File Formats](/slides/tr/python-java/supported-file-formats/) sayfasına bakın.

**Tüm slayt içeriği Word'de düzenlenebilir mi?**

Hayır. Her slayt statik bir görüntü olarak eklenir, üst seviye otomatik şekillerden alınan düz metin altına eklenir. Gruplar, tablolar, SmartArt, grafikler içindeki metin ile konuşmacı notları bu örnek tarafından çıkarılmaz. Animasyonlar ve geçişler Word belgesinde yeniden üretilmez.

**DOC yerine DOCX olarak kaydedebilir miyim?**

Evet. Çıktı dosya adını `output.doc` olarak değiştirin. Aspose.Words, bu kaydetme aşırı yüklemesini kullanırken dosya uzantısından çıktı formatını seçer.