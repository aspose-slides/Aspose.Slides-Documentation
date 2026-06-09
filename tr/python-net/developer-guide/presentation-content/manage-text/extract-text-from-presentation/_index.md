---
title: Python'da Sunumlardan Gelişmiş Metin Çıkarma
linktitle: Metin Çıkar
type: docs
weight: 90
url: /tr/python-net/extract-text-from-presentation/
keywords:
- metin çıkar
- slayttan metin çıkar
- sunumlardan metin çıkar
- PowerPoint'tan metin çıkar
- OpenDocument'ten metin çıkar
- PPT'den metin çıkar
- PPTX'ten metin çıkar
- ODP'den metin çıkar
- metin al
- slayttan metin al
- sunumlardan metin al
- PowerPoint'tan metin al
- OpenDocument'ten metin al
- PPT'den metin al
- PPTX'ten metin al
- ODP'den metin al
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlardan hızlıca metin çıkarın. Zaman kazanmak için basit, adım adım rehberimizi izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarmak, slayt içeriğiyle çalışan geliştiriciler için yaygın ancak önemli bir görevdir. Microsoft PowerPoint dosyaları PPT veya PPTX formatında olsun, ya da OpenDocument sunumları (ODP) olsun, metin verilerine erişmek ve geri almak analiz, otomasyon, indeksleme veya içerik taşıma amaçları için kritik olabilir.

Bu makale, PPT, PPTX ve ODP dahil çeşitli sunum formatlarından metni verimli bir şekilde çıkarmak için Aspose.Slides for Python via .NET kullanarak kapsamlı bir rehber sunar. Sunum öğeleri üzerinde sistematik olarak yineleme yaparak ihtiyacınız olan metin içeriğini doğru bir şekilde almayı öğreneceksiniz.

## **Bir Slayttan Metin Çıkarma**

Aspose.Slides for Python via .NET, [aspose.slides.util](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/) ad alanını sağlar ve bu alan içinde [SlideUtil](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/) sınıfı bulunur. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için birkaç aşırı yüklenmiş statik metod sunar. Bir sunumdaki slayttan metin çıkarmak için [get_all_text_boxes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) metodunu kullanın. Bu metod, parametre olarak [BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) türünde bir nesne alır. Çalıştırıldığında, metod slaytın tamamını metin için tarar ve [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) türünde nesneler dizisini, metin biçimlendirmesini koruyarak döndürür.

Aşağıdaki kod parçacığı, sunumun ilk slaytındaki tüm metni çıkarır:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Bir Sunumdan Metin Çıkarma**

Tüm sunumdaki metni taramak için [SlideUtil](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/) sınıfının sunduğu [get_all_text_frames](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/get_all_text_frames/) statik metodunu kullanın. Bu metod iki parametre alır:

1. İlk olarak, metnin çıkarılacağı PowerPoint veya OpenDocument sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi.
1. İkinci olarak, sunumdan metin taranırken ana slaytların dahil edilip edilmemesi gerektiğini belirten bir `Boolean` değer.

Metod, [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) türündeki nesneler dizisini, metin biçimlendirme bilgilerini de içerecek şekilde döndürür. Aşağıdaki kod, ana slaytları da dahil ederek bir sunumdan metin ve biçimlendirme ayrıntılarını tarar.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Kategorizeli ve Hızlı Metin Çıkarma**

[PresentationFactory](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/) sınıfı da sunumlardan tüm metni çıkarmak için yöntemler sunar:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textextractionarrangingmode/) enum argümanı, metin çıkarma sonucunu düzenleme modunu belirtir ve aşağıdaki değerlerden birine ayarlanabilir:
- `UNARRANGED` - Slayt üzerindeki konumuna bakılmaksızın ham metin.
- `ARRANGED` - Metin, slayttaki aynı sırada düzenlenir.

`UNARRANGED` modu hızın kritik olduğu durumlarda kullanılabilir; `ARRANGED` modundan daha hızlıdır.

[PresentationText](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationtext/) sunumdan çıkarılan ham metni temsil eder. `slides_text` özelliği, slayt metni nesnelerinden oluşan bir dizi döndürür. Her nesne ilgili slayttaki metni temsil eder ve aşağıdaki özelliklere sahiptir:
- `text` - Slayt şekillerindeki metin.
- `master_text` - Bu slaytla ilişkili ana slayt şekillerindeki metin.
- `layout_text` - Bu slaytla ilişkili düzen slaytı şekillerindeki metin.
- `notes_text` - Bu slaytla ilişkili not slaytı şekillerindeki metin.
- `comments_text` - Bu slaytla ilişkili yorumlardaki metin.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **SSS**

**Aspose.Slides büyük sunumları metin çıkarma sırasında ne kadar hızlı işler?**

Aspose.Slides yüksek performans için optimize edilmiştir ve hatta [büyük sunumları](/slides/tr/python-net/open-presentation/) işleyebilir, bu da gerçek zamanlı veya toplu işleme senaryoları için uygundur.

**Aspose.Slides sunumlardaki tablolar ve grafiklerden metin çıkarabilir mi?**

Evet. Aspose.Slides birçok slayt öğesinden, tablolar ve grafikle ilgili nesneler dahil, metin çıkarabilir; böylece yaygın sunum yapılarındaki metin içeriğine erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Aspose.Slides'in ücretsiz deneme sürümünü kullanarak metin çıkarabilirsiniz, ancak bu sürüm [belirli sınırlamalara](/slides/tr/python-net/licensing/) sahip olacaktır; örneğin yalnızca sınırlı sayıda slaytı işleyebilir. Sınırsız kullanım ve daha büyük sunumları işlemek için tam lisans satın almanız önerilir.