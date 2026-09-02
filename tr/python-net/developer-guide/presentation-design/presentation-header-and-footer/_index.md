---
title: Python ile Sunum Üstbilgileri ve Altbilgilerini Yönetme
linktitle: Üstbilgi ve Altbilgi
type: docs
weight: 140
url: /tr/python-net/presentation-header-and-footer/
keywords:
- üstbilgi
- üstbilgi metni
- altbilgi
- altbilgi metni
- üstbilgi ayarla
- altbilgi ayarla
- dağıtım
- notlar
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile slaytlarda, not sayfalarında ve dağıtımlarda altbilgi, tarih-saat, slayt-numarası ve üstbilgi yer tutucularını nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

PowerPoint, sayfa türüne bağlı olarak farklı üstbilgi ve altbilgi yer tutucuları kullanır. Aspose.Slides for Python via .NET, bu yer tutucuların metin ve görünürlüğünü üstbilgi/altbilgi yöneticisi sınıfları aracılığıyla kontrol etmenizi sağlar.

Kullanılabilir yer tutucular kapsamına göre değişir:

| Kapsam | Üstbilgi | Altbilgi | Tarih/saat | Slayt/sayfa numarası |
|---|---|---|---|---|
| Normal slayt | Hayır | Evet | Evet | Evet |
| Notlar ana şablonu | Evet | Evet | Evet | Evet |
| Not slaytı | Evet | Evet | Evet | Evet |
| Dağıtım ana şablonu | Evet | Evet | Evet | Evet |

Normal bir sunum slaytının bir üstbilgi yer tutucusu yoktur. Üstbilgiler not sayfalarında ve dağıtımlarda bulunur. Normal slaytlar için altbilgi, tarih/saat ve slayt-numarası yer tutucularını kullanın.

Bir değişikliğin kapsamı kullandığınız yöneticiye bağlıdır. [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slideheaderfootermanager/) sınıfı tek bir normal slaytı kontrol eder. [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslideheaderfootermanager/) sınıfı tek bir not slaytını kontrol eder. Ana ve düzen yöneticileri ayrıca ayarları bağımlı slaytlara yayabilir, [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) sınıfı ise dağıtım ana şablonunu kontrol eder.

## **Normal Slaytlarda Altbilgi, Tarih/Saat ve Slayt Numaralarını Ayarlama**

Normal slaytlar için temel iş akışı, her slaytın üstbilgi/altbilgi yöneticisine erişmek, altbilgi ve tarih/saat metnini ayarlamak, gerekli yer tutucuları etkinleştirmek ve sunumu kaydetmek şeklindedir. Slayt numaraları sunum tarafından otomatik olarak oluşturulur; sadece görünürlüğünü kontrol etmeniz gerekir.

Metin ayarlamak için [`set_footer_text`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) ve [`set_date_time_text`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) metodlarını, ilgili yer tutucuları göstermek için ise [`set_footer_visibility`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/) ve [`set_slide_number_visibility`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) metodlarını kullanın.

Aşağıdaki uçtan uca örnek, aynı altbilgi, tarih/saat metni ve slayt numarası görünürlüğünü tüm normal slaytlara uygular:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Yalnızca bir slaytı güncellemeniz gerektiğinde, tüm koleksiyonu dolaşmak yerine [`slides`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) koleksiyonu üzerinden doğrudan o slayta erişin.

## **Notlar Ana Şablonunda Üstbilgi ve Altbilgileri Ayarlama**

Notlar ana şablonu, not sayfaları için ortak biçimlendirme ve yer tutucu davranışını tanımlar. Yalnızca notlar ana şablonunu değiştirmek istediğinizde [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/) sınıfını kullanın.

Aşağıdaki örnek, notlar ana şablonunda üstbilgi, altbilgi ve tarih/saat metnini ayarlar ve o ana şablondaki tüm desteklenen yer tutucuları görünür kılar:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Bir sunum notlar ana şablonuna sahip olmayabilir; bu yüzden değişiklik yapmadan önce dönen değerin `None` olup olmadığını kontrol edin.

## **Notlar Ana Şablonu Ayarlarını Alt Not Slaytlarına Uygulama**

Notlar ana şablonu, üstbilgi ve altbilgi ayarlarını kendisine ve tüm bağımlı not slaytlarına uygulayabilir. Aynı ayarların not hiyerarşisi boyunca yayılması gerektiğinde [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/) üzerindeki özel yayma metotlarını kullanın.

Örneğin, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) ve [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) metotları notlar ana şablonu üstbilgisini ve tüm alt üstbilgileri günceller. Altbilgiler, tarih/saat ve slayt numaraları için eşdeğer metotlar mevcuttur.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Yukarıda kullanılan yayma metotları şunlardır: [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), ve [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Bireysel Bir Not Slaytında Üstbilgi ve Altbilgileri Ayarlama**

Bir not slaytı belirli bir normal slayta aittir. Yalnızca o not sayfasını özelleştirmek istediğinizde, [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslideheaderfootermanager/) sınıfını kullanın.

[`add_notes_slide`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslidemanager/add_notes_slide/) yöntemi mevcut slayt için not slaytını döndürür ve yoksa oluşturur. Aşağıdaki örnek, ilk sunum slaytıyla ilişkili not sayfasını yapılandırır:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Önce notlar ana şablonundan ayarları yayar, ardından bireysel bir not slaytını değiştirirseniz, sonraki slayt bazlı ayarlar o not sayfasını bağımsız olarak özelleştirmenizi sağlar.

## **Dağıtım Ana Şablonunda Üstbilgi ve Altbilgileri Ayarlama**

Dağıtım sayfaları, üstbilgi, altbilgi, tarih/saat ve sayfa numarası yer tutucuları için dağıtım ana şablonunu kullanır. Not sayfalarından farklı olarak, dağıtım ayarları bireysel dağıtım slaytları yerine dağıtım ana şablonu üzerinden yönetilir.

Dağıtım ana şablonuna erişmek için [`master_handout_slide`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) özelliğini kullanın. Ana şablon yoksa, varsayılan dağıtım ana şablonunu oluşturmak için [`set_default_master_handout_slide`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) yöntemini çağırın.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Kapsam ve Kalıtımı Anlama**

Değiştirmek istediğiniz kapsamla eşleşen üstbilgi/altbilgi yöneticisini seçin:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slideheaderfootermanager/) bir normal slayt için altbilgi, tarih/saat ve slayt-numarası ayarlarını değiştirir.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslideheaderfootermanager/) bir düzen slaytını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslideheaderfootermanager/) bir normal slayt ana şablonunu kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslideheaderfootermanager/) notlar ana şablonunu kontrol eder ve tüm bağımlı not slaytlarına ayarları yayabilir.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslideheaderfootermanager/) bir not slaytını değiştirir ve üstbilgi yer tutucusunu altbilgi, tarih/saat ve slayt numarası ile birlikte destekler.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) dağıtım ana şablonunu değiştirir ve tüm dört yer tutucu tipini destekler.

Aynı ayarın hiyerarşi boyunca uygulanması gerektiğinde bir ana şablon veya düzenten yayım yapın. Tek bir sayfa için yerel bir ayar gerektiğinde bireysel slayt veya not‑slayt yöneticisini kullanın.

## **SSS**

**Normal bir slayta üstbilgi ekleyebilir miyim?**

Hayır. PowerPoint, normal slaytlar için bir üstbilgi yer tutucusu tanımlamaz. Normal slaytlarda altbilgi, tarih/saat ve slayt‑numarası yer tutucularını kullanın. Üstbilgi yer tutucuları not sayfalarında ve dağıtımlarda mevcuttur.

**Altbilgi, tarih/saat veya slayt‑numarası yer tutucusu görünmüyor ise ne yapmalıyım?**

İlgili üstbilgi/altbilgi yöneticisini kullanarak görünürlüğünü kontrol edin ve gerektiğinde etkinleştirin. Örneğin, [`is_footer_visible`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) bir altbilgi yer tutucusunun mevcut olup olmadığını raporlar ve [`set_footer_visibility`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) görünürlüğünü değiştirir.

**Slayt numaralandırmasını 1 dışındaki bir değerden başlatmak nasıl yapılır?**

Sunumun [`first_slide_number`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/first_slide_number/) özelliğini ayarlayın. Slayt‑numarası yer tutucuları ardından güncellenmiş numaralandırma dizisini kullanır.

**PDF, resim veya HTML olarak dışa aktarırken üstbilgi ve altbilgiler ne olur?**

Görünür üstbilgi ve altbilgi öğeleri, çıktı formatındaki sunum içeriğiyle birlikte işlenir. Görünüşleri, dışa aktarılan sayfa türüne ve ilgili yer tutucu görünürlük ayarlarına bağlıdır.