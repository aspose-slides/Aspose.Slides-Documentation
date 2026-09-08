---
title: Python via Java ile Sunumlardan Gelişmiş Metin Çıkarma
linktitle: Metni Çıkar
type: docs
weight: 90
url: /tr/python-java/extract-text-from-presentation/
keywords:
- metin çıkarma
- slayttan metin çıkarma
- sunumdan metin çıkarma
- PowerPoint'tan metin çıkarma
- OpenDocument'ten metin çıkarma
- PPT'den metin çıkarma
- PPTX'ten metin çıkarma
- ODP'den metin çıkarma
- metin al
- slayttan metin al
- sunumdan metin al
- PowerPoint'tan metin al
- OpenDocument'ten metin al
- PPT'den metin al
- PPTX'ten metin al
- ODP'den metin al
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarından hızlıca metin çıkarın. Zaman tasarrufu için basit, adım adım rehberimizi izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarma, slayt içeriğiyle çalışan geliştiriciler için yaygın ancak önemli bir görevdir. Microsoft PowerPoint dosyaları PPT ya da PPTX formatında olsun ya da OpenDocument sunumları (ODP) ile çalışıyor olun, metinsel verilere erişmek ve bunları almak analiz, otomasyon, indeksleme veya içerik taşıma amacıyla kritik olabilir.

Bu makale, Aspose.Slides for Python via Java kullanarak PPT, PPTX ve ODP gibi çeşitli sunum formatlarından metni verimli bir şekilde nasıl çıkaracağınızı kapsamlı bir şekilde anlatır. Sunum öğeleri üzerinde sistematik olarak döngü yaparak ihtiyaç duyduğunuz metin içeriğini doğru şekilde almayı öğreneceksiniz.

## **Bir Slayttan Metin Çıkarma**

Aspose.Slides for Python via Java, [SlideUtil](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/) sınıfını sağlar. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için birden fazla aşırı yüklenmiş statik yöntemi ortaya çıkarır. Bir sunumdaki slayttan metin çıkarmak için [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/#getAllTextBoxes) yöntemini kullanın. Bu yöntem, [BaseSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/) türünde bir nesneyi parametre olarak kabul eder. Çalıştırıldığında, yöntem slaydın tamamında metni tarar ve herhangi bir metin biçimlendirmesini koruyarak [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) türünde nesnelerden oluşan bir dizi döndürür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Bir Sunumdan Metin Çıkarma**

Sunumun tamamındaki metni taramak için, [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/#getAllTextFrames) statik yöntemini kullanın. Bu yöntem iki parametre alır:

1. İlk olarak, metni çıkarılacak PowerPoint ya da OpenDocument sunumunu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi.  
2. İkinci olarak, master slaytların da taranıp taranmayacağını belirten bir `bool` değeri.

Yöntem, metin biçimlendirme bilgilerini içeren [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) türünde nesnelerden oluşan bir dizi döndürür. Aşağıdaki kod, master slaytlar dahil olmak üzere bir sunumdan metin ve biçimlendirme ayrıntılarını tarar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Kategorize Edilmiş ve Hızlı Metin Çıkarma**

[PresentationFactory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/) sınıfı da sunumlardan tüm metni çıkarmak için yöntemler sağlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Dosyadan metni çıkar.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Akıştan metni çıkar.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Yükleme seçeneklerini kullanarak akıştan metni çıkar.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textextractionarrangingmode/) enum argümanı, metin çıkarma sonucunun nasıl düzenleneceğini belirtir ve şu değerlerden biri olarak ayarlanabilir:

- [Unarranged](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - Slayttaki konumuna bakılmaksızın ham metin.  
- [Arranged](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - Metin, slayttaki sıraya aynı şekilde düzenlenir.

Hızın kritik olduğu durumlarda düzenlenmemiş (unarranged) mod kullanılabilir; bu mod, düzenli (arranged) moddan daha hızlıdır.

[PresentationText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationtext/) sunumdan çıkarılan ham metni temsil eder. Its [getSlidesText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationtext/#getSlidesText) yöntemi, `SlideText` türünde nesnelerden oluşan bir dizi döndürür. Her nesne ilgili slaydın metnini temsil eder. `SlideText` türündeki nesnenin aşağıdaki yöntemleri vardır:

- `getText` - Slaydın şekilleri içindeki metin.  
- `getMasterText` - Bu slaytla ilişkili master slaydın şekilleri içindeki metin.  
- `getLayoutText` - Bu slaytla ilişkili yerleşim slaydının şekilleri içindeki metin.  
- `getNotesText` - Bu slaytla ilişkili not slaydının şekilleri içindeki metin.  
- `getCommentsText` - Bu slaytla ilişkili yorumlardaki metin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **SSS**

**Aspose.Slides büyük sunumları metin çıkarma sırasında ne kadar hızlı işliyor?**

Aspose.Slides yüksek performans için optimize edilmiştir ve büyük sunumları bile işleyebilir, bu da gerçek zamanlı veya toplu işleme senaryoları için uygundur.

**Aspose.Slides sunumlardaki tablolar ve grafiklerden metin çıkarabilir mi?**

Evet. Aspose.Slides birçok slayt öğesinden, tablolar ve grafikle ilgili nesneler dahil, metin çıkarabilir, böylece yaygın sunum yapılarındaki metinsel içeriğe erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Metni, Aspose.Slides'in ücretsiz deneme sürümüyle çıkarabilirsiniz, ancak bu sürümde [certain limitations](/slides/tr/python-java/licensing/) gibi sınırlamalar bulunur; örneğin yalnızca sınırlı sayıda slayt işlenebilir. Sınırsız kullanım ve daha büyük sunumları işleyebilmek için tam lisans satın almanız önerilir.