---
title: Python ile Sunum Başlık ve Altbilgilerini Yönet
linktitle: Başlık ve Altbilgi
type: docs
weight: 140
url: /tr/python-net/presentation-header-and-footer/
keywords:
- başlık
- başlık metni
- altbilgi
- altbilgi metni
- başlık ayarla
- altbilgi ayarla
- dağıtım
- notlar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Profesyonel bir görünüm için PowerPoint ve OpenDocument sunumlarına başlık ve altbilgiler eklemek ve özelleştirmek amacıyla .NET üzerinden Aspose.Slides for Python kullanın."
---
## **Genel Bakış**

Aspose.Slides for Python, bir sunum boyunca başlık ve altbilgi yer tutucularını hassas bir kapsamda kontrol etmenizi sağlar. Altbilgi metni, tarih/saat ve slayt numaraları slaytlarda ana düzeyden yönetilir ve tüm sunuma uygulanabilir veya slayta göre ayarlanabilir. Başlıklar notlar ve dağıtım sayfalarında desteklenir; burada görünürlüğü açıp kapatabilir ve başlık, altbilgi, tarih/saat ve sayfa numaraları için metinleri, ana not slaytındaki veya ayrı not slaytlarındaki özel başlık ve altbilgi yöneticisi aracılığıyla ayarlayabilirsiniz. Bu makale, bu yer tutucuları güncellemek ve değişiklikleri sununuzda tutarlı bir şekilde yaymak için temel desenleri özetlemektedir.

## **Başlık ve Altbilgi Metnini Yönetme**

Bu bölümde, bir sunumdaki başlık ve altbilgi içeriğini nasıl yöneteceğinizi öğreneceksiniz—altbilgiyi, tarih ve zamanı ve slayt numaralarını etkinleştirebilir veya değiştirebilirsiniz. Bu ayarların uygulanma kapsamlarını (tüm sunum, tek tek slaytlar ve not/dağıtım görünümleri) kısaca özetleyecek ve Aspose.Slides API'sını kullanarak bunları hızlı ve tutarlı bir şekilde nasıl güncelleyeceğinizi göstereceğiz.

Aşağıdaki kod örneği bir sunumu açar, altbilgi metnini etkinleştirir ve ayarlar, ana not slaydındaki başlık metnini günceller ve dosyayı kaydeder.

```py
import aspose.slides as slides

# Başlık metnini ayarlama işlevi.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Sunumu yükle.
with slides.Presentation("sample.pptx") as presentation:
    # Altbilgiyi ayarla.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Başlığa eriş ve güncelle.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Sunumu kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Not Slaytlarında Başlık ve Altbilgiyi Yönetme**

Bu bölümde, Aspose.Slides içinde not slaytları için başlık ve altbilgileri nasıl yöneteceğinizi öğreneceksiniz. İlgili yer tutucuları etkinleştirmeyi, altbilgi, tarih/saat ve sayfa numaraları için metin ayarlamayı ve bu değişiklikleri not ana sayfası ve ayrı not sayfaları arasında tutarlı bir şekilde uygulamayı ele alacağız.

Aşağıdaki adımları izleyin:

1. Bir sunum dosyası yükleyin.
1. Ana not slaydını ve onun [başlık ve altbilgi yöneticisi](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/) alın.
1. Ana not slaydında, ana ve tüm alt not slaytları için Başlık, Altbilgi, Slayt numarası ve Tarih-saat görünürlüğünü etkinleştirin.
1. Ana not slaydında, ana ve tüm alt not slaytları için Başlık, Altbilgi ve Tarih-saat metnini ayarlayın.
1. İlk sunum slaydi için not slaydını ve onun [başlık ve altbilgi yöneticisi](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslideheaderfootermanager/) alın.
1. Bu ilk not slaydında yalnızca, Başlık, Altbilgi, Slayt numarası ve Tarih-saatin görünür olduğundan emin olun (kapalı olanları açın).
1. Bu ilk not slaydında yalnızca, Başlık, Altbilgi ve Tarih-saat metnini ayarlayın.
1. Sunumu PPTX formatında kaydedin.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Ana not slaytını ve tüm başlık, altbilgi, slayt numarası ve tarih/saat yer tutucularını görünür yap.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Ana not slaydında ve tüm başlık, altbilgi ve tarih/saat yer tutucularında metni ayarla.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Yalnızca ilk not slaydındaki başlık, altbilgi, slayt numarası ve tarih/saat ayarlarını değiştir.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Başlık, altbilgi, slayt numarası ve tarih/saat yer tutucularının görünür olduğundan emin ol.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Not slaydındaki başlık, altbilgi ve tarih/saat yer tutucularına metin ayarla.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Sunumu kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Normal slaytlara "başlık" ekleyebilir miyim?**

PowerPoint'te "Header" sadece notlar ve dağıtım sayfalarında bulunur; normal slaytlarda desteklenen öğeler altbilgi, tarih/saat ve slayt numarasıdır. Aspose.Slides'te de aynı sınırlamalar geçerlidir: başlık yalnızca Notlar/Dağıtım için, slaytlarda ise Altbilgi/TarihSaat/SlaytNumarası.

**Düzen bir altbilgi alanı içermiyorsa—görünürlüğünü "aç"abilir miyim?**

Evet. Görünürlüğü başlık/altbilgi yöneticisi aracılığıyla kontrol edin ve gerektiğinde etkinleştirin. Bu API göstergeleri ve yöntemler, yer tutucu eksik ya da gizli olduğunda kullanılmak üzere tasarlanmıştır.

**Slayt numarasını 1 yerine başka bir değerden nasıl başlatırım?**

Sunumun [first slide number](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/first_slide_number/) değerini ayarlayın; bundan sonra tüm numaralandırma yeniden hesaplanır. Örneğin, 0 ya da 10’dan başlayabilir ve başlık slaydındaki numarayı gizleyebilirsiniz.

**PDF/görseller/HTML'ye dışa aktarırken başlıklar/altbilgiler ne olur?**

Bunlar, sunumun normal metin öğeleri olarak işlenir. Yani, öğeler slaytlarda/not sayfalarında görünürse, çıktı formatında da diğer içeriklerle birlikte görüntülenir.