---
title: "JavaScript'te Sunum Başlık ve Alt Bilgilerini Yönetme"
linktitle: "Başlık ve Alt Bilgi"
type: docs
weight: 140
url: /tr/nodejs-java/presentation-header-and-footer/
keywords:
- "başlık"
- "başlık metni"
- "alt bilgi"
- "alt bilgi metni"
- "başlık ayarla"
- "alt bilgi ayarla"
- "dağıtım"
- "notlar"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java ile slaytlarda, not sayfalarında ve dağıtımlarda alt bilgi, tarih-saat, slayt numarası ve başlık yer tutucularını nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

PowerPoint, sayfa türüne göre farklı başlık ve alt bilgi yer tutucuları kullanır. Java aracılığıyla Node.js için Aspose.Slides, bu yer tutucuların metnini ve görünürlüğünü başlık/alt bilgi yöneticisi sınıfları aracılığıyla kontrol etmenizi sağlar.

Kullanılabilir yer tutucular kapsamına bağlıdır:

| Kapsam | Başlık | Alt Bilgi | Tarih/Zaman | Slayt/sayfa numarası |
|---|---|---|---|---|
| Normal slayt | No | Yes | Yes | Yes |
| Notlar ana sayfası | Yes | Yes | Yes | Yes |
| Not slaytı | Yes | Yes | Yes | Yes |
| Dağıtım ana sayfası | Yes | Yes | Yes | Yes |

Normal bir sunum slaytının başlık yer tutucusu yoktur. Başlıklar not sayfalarında ve dağıtımlarda mevcuttur. Normal slaytlar için, bunun yerine alt bilgi, tarih/zaman ve slayt-numarası yer tutucularını kullanın.

Bir değişikliğin kapsamı kullandığınız yöneticiye bağlıdır. [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideheaderfootermanager/) sınıfı tek bir normal slaytı kontrol eder. [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslideheaderfootermanager/) sınıfı tek bir not slaytını kontrol eder. Ana ve düzen yöneticileri ayarları bağımlı slaytlara da yayabilir, [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) sınıfı ise dağıtım ana sayfasını kontrol eder.

## **Normal Slaytlarda Alt Bilgi, Tarih/Zaman ve Slayt Numaralarını Ayarlama**

Normal slaytlar için temel iş akışı, her slaytın başlık/alt bilgi yöneticisine erişmek, alt bilgi ve tarih/zaman metnini ayarlamak, gerekli yer tutucuları etkinleştirmek ve sunumu kaydetmektir. Slayt numaraları sunum tarafından üretilir, bu yüzden sadece görünürlüğünü kontrol etmeniz yeterlidir.

[`setFooterText`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) ve [`setDateTimeText`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) ile metin ayarlayın, ve [`setFooterVisibility`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) ve [`setSlideNumberVisibility`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) ile ilgili yer tutucuları gösterin.

Aşağıdaki uçtan uca örnek, aynı alt bilgi, tarih/zaman metni ve slayt numarası görünürlüğünü tüm normal slaytlara uygular:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca bir slaytı güncellemeniz gerektiğinde, tüm koleksiyonu döngüyle dolaşmak yerine, o slayta [`getSlides`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslides/) yöntemiyle doğrudan erişin.

## **Notlar Ana Sayfasında Başlık ve Alt Bilgileri Ayarlama**

Notlar ana sayfası, not sayfaları için ortak biçimlendirme ve yer tutucu davranışını tanımlar. Yalnızca notlar ana sayfasını değiştirmek istediğinizde [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) sınıfını kullanın.

Aşağıdaki örnek, notlar ana sayfasında başlık, alt bilgi ve tarih/zaman metnini ayarlar ve o ana sayfada desteklenen tüm yer tutucuları görünür kılar:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sunum bir notlar ana sayfası içermediğinde [`getMasterNotesSlide`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) yöntemi `null` döndürür.

## **Notlar Ana Sayfası Ayarlarını Alt Not Slaytlarına Uygulama**

Notlar ana sayfası, başlık ve alt bilgi ayarlarını kendisine ve tüm bağımlı not slaytlarına uygulayabilir. Notlar hiyerarşisi boyunca aynı ayarların uygulanması gerektiğinde [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) üzerindeki özel yayma yöntemlerini kullanın.

Örneğin, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) ve [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) notlar ana sayfası başlığını ve tüm alt başlıkları günceller. Alt bilgiler, tarih/zaman ve slayt numaraları için eşdeğer yöntemler de mevcuttur.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yukarıda kullanılan yayma yöntemleri şunlardır: [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) ve [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Tek Bir Not Slaytında Başlık ve Alt Bilgileri Ayarlama**

Not slaytı, belirli bir normal slayta aittir. Yalnızca o not sayfasını özelleştirmek istediğinizde onun [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslideheaderfootermanager/) sınıfını kullanın.

[`addNotesSlide`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) yöntemi geçerli slayt için not slaytını döndürür ve henüz yoksa bir tane oluşturur. Aşağıdaki örnek, ilk sunum slaytıyla ilişkili not sayfasını yapılandırır:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Önce notlar ana sayfasından ayarları yayar, ardından tek bir not slaytını değiştirirseniz, sonraki slayt başına ayarlar o not sayfasını bağımsız olarak özelleştirmenizi sağlar.

## **Dağıtım Ana Sayfasında Başlık ve Alt Bilgileri Ayarlama**

Dağıtım sayfaları, başlık, alt bilgi, tarih/zaman ve sayfa numarası yer tutucuları için dağıtım ana sayfasını kullanır. Not sayfalarının aksine, dağıtım ayarları ayrı dağıtım slaytları yerine dağıtım ana sayfası üzerinden yönetilir.

Dağıtım ana sayfasına erişmek için [`getMasterHandoutSlide`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) kullanın. Eğer mevcut değilse, varsayılan dağıtım ana sayfasını oluşturmak için [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) çağırın.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kapsam ve Kalıtımı Anlamak**

Değiştirmek istediğiniz kapsama uyan başlık/alt bilgi yöneticisini seçin:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideheaderfootermanager/) tek bir normal slayt için alt bilgi, tarih/zaman ve slayt-numarası ayarlarını değiştirir.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) bir düzen slaytını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslideheaderfootermanager/) normal bir slayt ana sayfasını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) notlar ana sayfasını kontrol eder ve ayarları tüm bağımlı not slaytlarına yayabilir.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslideheaderfootermanager/) tek bir not slaytını değiştirir ve alt bilgi, tarih/zaman ve slayt numarasına ek olarak bir başlık yer tutucusunu da destekler.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) dağıtım ana sayfasını değiştirir ve dört yer tutucu tipinin tümünü destekler.

Aynı ayarın hiyerarşisinin tümünde uygulanması gerektiğinde bir ana sayfa veya düzen üzerinden yayma kullanın. Tek bir sayfa için yerel bir ayar gerektiğinde bireysel slayt veya not‑slayt yöneticisini kullanın.

## **SSS**

**Normal bir slayta başlık ekleyebilir miyim?**

Hayır. PowerPoint normal slaytlar için bir başlık yer tutucusu tanımlamaz. Normal slaytlarda alt bilgi, tarih/zaman ve slayt‑numarası yer tutucularını kullanın. Başlık yer tutucuları not sayfalarında ve dağıtımlarda mevcuttur.

**Alt bilgi, tarih/zaman veya slayt‑numarası yer tutucusu görünür değilse ne olur?**

İlgili başlık/alt bilgi yöneticisini kullanarak görünürlüğünü kontrol edin ve gerektiğinde etkinleştirin. Örneğin, [`isFooterVisible`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) bir alt bilgi yer tutucusunun mevcut olup olmadığını bildirir ve [`setFooterVisibility`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) görünürlüğünü değiştirir.

**Slayt numaralandırmasını 1 dışındaki bir değerden nasıl başlatırım?**

Sunumun [`setFirstSlideNumber`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) yöntemini çağırın. Slayt‑numarası yer tutucuları ardından güncellenmiş numaralandırma sırasını kullanır.

**PDF, görseller veya HTML'ye dışa aktarırken başlık ve alt bilgiler ne olur?**

Görünür başlık ve alt bilgi öğeleri, çıktı formatında sunum içeriğinin geri kalanıyla birlikte işlenir. Görünümleri, dışa aktarılan sayfa tipine ve ilgili yer tutucu görünürlük ayarlarına bağlıdır.