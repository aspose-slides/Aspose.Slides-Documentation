---
title: Python aracılığıyla Java ile Sunum Üst Bilgilerini ve Alt Bilgilerini Yönetin
linktitle: Üst Bilgi ve Alt Bilgi
type: docs
weight: 140
url: /tr/python-java/presentation-header-and-footer/
keywords:
- üst bilgi
- üst bilgi metni
- alt bilgi
- alt bilgi metni
- üst bilgi ayarla
- alt bilgi ayarla
- el kitabı
- notlar
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile slaytlarda, not sayfalarında ve el kitaplarında alt bilgi, tarih-saat, slayt numarası ve üst bilgi yer tutucularını nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

PowerPoint, sayfa türüne bağlı olarak farklı üst bilgi ve alt bilgi yer tutucuları kullanır. Aspose.Slides for Python via Java, bu yer tutucuların metnini ve görünürlüğünü üst bilgi/alt bilgi yöneticileri aracılığıyla kontrol etmenizi sağlar.

Kullanılabilir yer tutucular kapsamına göre değişir:

| Kapsam | Üst Bilgi | Alt Bilgi | Tarih/Zaman | Slayt/sayfa numarası |
|---|---|---|---|---|
| Normal slayt | Hayır | Evet | Evet | Evet |
| Notlar ana slaytı | Evet | Evet | Evet | Evet |
| Not slaytı | Evet | Evet | Evet | Evet |
| El kitabı ana slaytı | Evet | Evet | Evet | Evet |

Normal bir sunum slaytının bir üst bilgi yer tutucusu yoktur. Üst bilgiler not sayfalarında ve el kitaplarında bulunur. Normal slaytlar için alt bilgi, tarih/zaman ve slayt-numarası yer tutucularını kullanın.

Değişikliğin kapsamı, kullandığınız yöneticiye bağlıdır. [SlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideheaderfootermanager/) sınıfı bir normal slaytı kontrol eder. [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notesslideheaderfootermanager/) sınıfı bir not slaytını kontrol eder. Ana ve düzen yöneticileri ayarları bağımlı slaytlara da aktarabilir; [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) sınıfı el kitabı ana slaytını kontrol eder.

## **Normal Slaytlarda Alt Bilgi, Tarih/Zaman ve Slayt Numaralarını Ayarlama**

Normal slaytlar için temel iş akışı, her slaytın üst bilgi/alt bilgi yöneticisine erişmek, alt bilgi ve tarih/zaman metnini ayarlamak, gerekli yer tutucuları etkinleştirmek ve sunumu kaydetmektir. Slayt numaraları sunum tarafından otomatik olarak oluşturulur; sadece görünürlüklerini kontrol etmeniz gerekir.

Metni ayarlamak için [setFooterText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) ve [setDateTimeText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) kullanın; ilgili yer tutucuları göstermek için [setFooterVisibility](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) ve [setSlideNumberVisibility](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) kullanın.

Aşağıdaki uçtan uca örnek, aynı alt bilgi, tarih/zaman metni ve slayt-numarası görünürlüğünü tüm normal slaytlara uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sadece bir slaytı güncellemek istiyorsanız, tüm koleksiyonu döngüyle gezmek yerine [getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) yöntemiyle o slayta doğrudan erişin.

## **Notlar Ana Sayfasında Üst Bilgi ve Alt Bilgi Ayarlama**

Notlar ana sayfası, not sayfaları için ortak biçimlendirme ve yer tutucu davranışını tanımlar. Yalnızca notlar ana sayfasını değiştirmek istiyorsanız [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/) sınıfını kullanın.

Aşağıdaki örnek, notlar ana sayfasına üst bilgi, alt bilgi ve tarih/zaman metni ekler ve o ana sayfadaki tüm desteklenen yer tutucuları görünür hâle getirir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`getMasterNotesSlide` yöntemi, sunumda bir notlar ana sayfası bulunmadığında `None` döndürür.

## **Notlar Ana Sayfası Ayarlarını Alt Not Slaytlarına Uygulama**

Bir notlar ana sayfası, kendi üst bilgi ve alt bilgi ayarlarını kendisine ve tüm bağımlı not slaytlarına uygulayabilir. Aynı ayarların not hiyerarşisinde yaygın olarak uygulanması gerektiğinde [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/) üzerindeki özel yayma yöntemlerini kullanın.

Örneğin, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) ve [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) notlar ana sayfasının üst bilgisini ve tüm alt üst bilgileri günceller. Alt bilgiler, tarih/zaman ve slayt numaraları için eşdeğer yöntemler de mevcuttur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Yukarıda kullanılan yayma yöntemleri şunlardır: [setFooterAndChildFootersText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) ve [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Bireysel Bir Not Slaytında Üst Bilgi ve Alt Bilgi Ayarlama**

Bir not slaytı, belirli bir normal slayta aittir. Yalnızca o not sayfasını özelleştirmek istediğinizde onun [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notesslideheaderfootermanager/) sınıfını kullanın.

[addNotesSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notesslidemanager/#addNotesSlide) yöntemi, mevcut slayt için not slaytını döndürür ve henüz yoksa oluşturur. Aşağıdaki örnek, ilk sunum slaytıyla ilişkili not sayfasını yapılandırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

İlk olarak notlar ana sayfasından ayarları yayar, ardından bireysel bir not slaytını değiştirirseniz, sonraki slayt‑başına ayarlar o not sayfasını bağımsız olarak özelleştirmenizi sağlar.

## **El Kitabı Ana Sayfasında Üst Bilgi ve Alt Bilgi Ayarlama**

El kitabı sayfaları, üst bilgi, alt bilgi, tarih/zaman ve sayfa‑numarası yer tutucuları için el kitabı ana sayfasını kullanır. Not sayfalarının aksine, el kitabı ayarları bireysel el kitabı slaytları yerine el kitabı ana sayfası üzerinden yönetilir.

El kitabı ana sayfasına erişmek için `getMasterHandoutSlide` yöntemini kullanın. Mevcut değilse, varsayılan el kitabı ana sayfasını oluşturmak için `setDefaultMasterHandoutSlide` yöntemini çağırın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kapsam ve Kalıtımı Anlama**

Değiştirmek istediğiniz kapsamla eşleşen üst bilgi/alt bilgi yöneticisini seçin:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideheaderfootermanager/) bir normal slayt için alt bilgi, tarih/zaman ve slayt‑numarası ayarlarını değiştirir.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslideheaderfootermanager/) bir düzen slaytını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslideheaderfootermanager/) bir normal slayt ana sayfasını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslideheaderfootermanager/) notlar ana sayfasını kontrol eder ve tüm bağımlı not slaytlarına ayarları yayabilir.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notesslideheaderfootermanager/) bir not slaytını değiştirir ve üst bilgi yer tutucusunu da alt bilgi, tarih/zaman ve slayt numarası ile birlikte destekler.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) el kitabı ana sayfasını değiştirir ve dört yer tutucu tipinin tamamını destekler.

Aynı ayarın hiyerarşisinin tamamına uygulanması gerektiğinde bir ana sayfa veya düzen üzerinden yayma kullanın. Tek bir sayfa için yerel bir ayar gerektiğinde bireysel slayt veya not‑slayt yöneticisini kullanın.

## **SSS**

**Normal bir slayta üst bilgi ekleyebilir miyim?**

Hayır. PowerPoint, normal slaytlar için bir üst bilgi yer tutucusu tanımlamaz. Normal slaytlarda alt bilgi, tarih/zaman ve slayt‑numarası yer tutucularını kullanın. Üst bilgi yer tutucuları not sayfalarında ve el kitaplarında mevcuttur.

**Alt bilgi, tarih/zaman veya slayt‑numarası yer tutucusu görünmüyorsa ne yapmalıyım?**

İlgili üst bilgi/alt bilgi yöneticisini kullanarak görünürlüğünü kontrol edin ve gerektiğinde etkinleştirin. Örneğin, [isFooterVisible](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) bir alt bilgi yer tutucusunun mevcut olup olmadığını rapor eder; [setFooterVisibility](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) ise görünürlüğünü değiştirir.

**Slayt numaralandırmasını 1 dışında bir değerden başlatmak istiyorum, nasıl yapabilirim?**

Sunumun [setFirstSlideNumber](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#setFirstSlideNumber) yöntemini çağırın. Slayt‑numarası yer tutucuları ardından güncellenmiş numaralandırma dizisini kullanır.

**Üst bilgi ve alt bilgiler PDF, görüntü veya HTML formatına dışa aktarılırken ne olur?**

Görünür üst bilgi ve alt bilgi öğeleri, çıktı biçiminde sunum içeriğiyle birlikte işlenir. Görünüşleri, dışa aktarılan sayfa türüne ve ilgili yer tutucu görünürlük ayarlarına bağlıdır.