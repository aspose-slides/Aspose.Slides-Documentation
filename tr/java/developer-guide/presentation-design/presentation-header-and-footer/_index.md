---
title: Java’da Sunum Üstbilgi ve Altbilgi Yönetimi
linktitle: Üstbilgi ve Altbilgi
type: docs
weight: 140
url: /tr/java/presentation-header-and-footer/
keywords:
- üstbilgi
- üstbilgi metni
- altbilgi
- altbilgi metni
- üstbilgi ayarla
- altbilgi ayarla
- el ilanı
- notlar
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile slaytlarda, not sayfalarında ve el ilanlarında altbilgi, tarih-saat, slayt numarası ve üstbilgi yer tutucularını nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

PowerPoint, sayfa türüne bağlı olarak farklı üstbilgi ve altbilgi yer tutucuları kullanır. Aspose.Slides for Java, bu yer tutucuların metnini ve görünürlüğünü üstbilgi/altbilgi yöneticisi arabirimleri aracılığıyla kontrol etmenizi sağlar.

Kullanılabilir yer tutucular kapsamına göre değişir:

| Kapsam | Üstbilgi | Altbilgi | Tarih/saat | Slayt/sayfa numarası |
|---|---|---|---|---|
| Normal slayt | Hayır | Evet | Evet | Evet |
| Notlar ana taslağı | Evet | Evet | Evet | Evet |
| Not slaytı | Evet | Evet | Evet | Evet |
| El ilanı ana taslağı | Evet | Evet | Evet | Evet |

Normal bir sunum slaytının üstbilgi yer tutucusu yoktur. Üstbilgiler not sayfalarında ve el ilanlarında bulunur. Normal slaytlar için altbilgi, tarih/saat ve slayt-numarası yer tutucularını kullanın.

Değişikliğin kapsamı kullandığınız yöneticiyi belirler. [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideheaderfootermanager/) arabirimi bir normal slaytı kontrol eder. [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotesslideheaderfootermanager/) arabirimi bir not slaytını kontrol eder. Ana ve düzen yöneticileri aynı zamanda ayarları bağımlı slaytlara yayabilirken, [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) arabirimi el ilanı ana taslağını kontrol eder.

## **Normal Slaytlarda Altbilgi, Tarih/Saat ve Slayt Numaralarını Ayarlama**

Normal slaytlar için temel iş akışı, her slaytın üstbilgi/altbilgi yöneticisine erişmek, altbilgi ve tarih/saat metnini ayarlamak, gerekli yer tutucuları etkinleştirmek ve sunumu kaydetmektir. Slayt numaraları sunum tarafından üretilir, bu yüzden yalnızca görünürlüklerini kontrol etmeniz gerekir.

Metin ayarlamak için [`setFooterText`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) ve [`setDateTimeText`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) metodlarını, ilgili yer tutucuları göstermek için ise [`setFooterVisibility`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-) ve [`setSlideNumberVisibility`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) metodlarını kullanın.

Aşağıdaki uçtan uca örnek, aynı altbilgi, tarih/saat metni ve slayt-numarası görünürlüğünü tüm normal slaytlara uygular:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca bir slaytı güncellemeniz gerektiğinde, tüm koleksiyonu döngüyle gezmek yerine [`getSlides`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlides--) yöntemiyle o slayta doğrudan erişin.

## **Notlar Ana Taslağında Üstbilgi ve Altbilgileri Ayarlama**

Notlar ana taslağı, not sayfaları için ortak biçimlendirme ve yer tutucu davranışını tanımlar. Yalnızca notlar ana taslağını değiştirmek istediğinizde [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/) arabirimini kullanın.

Aşağıdaki örnek, notlar ana taslağında üstbilgi, altbilgi ve tarih/saat metnini ayarlar ve o ana taslakta desteklenen tüm yer tutucuları görünür hâle getirir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Notlar ana taslağı içermeyen bir sunumda [`getMasterNotesSlide`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) yöntemi `null` döndürür.

## **Notlar Ana Taslağı Ayarlarını Alt Not Slaytlarına Uygulama**

Bir notlar ana taslağı, üstbilgi ve altbilgi ayarlarını kendisine ve ona bağlı tüm not slaytlarına uygulayabilir. Aynı ayarların not hiyerarşisi boyunca uygulanması gerektiğinde [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/) üzerindeki özel yayma metodlarını kullanın.

Örneğin, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) ve [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) metodları, notlar ana taslağı üstbilgisini ve tüm alt başlıkları günceller. Altbilgi, tarih/saat ve slayt numaraları için eşdeğer metodlar mevcuttur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yukarıda kullanılan yayma metodları şunlardır: [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-) ve [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Bireysel Bir Not Slaytında Üstbilgi ve Altbilgileri Ayarlama**

Bir not slaydı, belirli bir normal slayta aittir. Yalnızca o not sayfasını özelleştirmek istediğinizde [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotesslideheaderfootermanager/) arabirimini kullanın.

[`addNotesSlide`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) yöntemi, geçerli slayt için not slaytını döndürür ve mevcut değilse bir tane oluşturur. Aşağıdaki örnek, ilk sunum slaytıyla ilişkili not sayfasını yapılandırır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Önce notlar ana taslağından ayarları yayar, ardından bireysel bir not slaytını değiştirirseniz, sonraki slayt‑başına ayarlar o not sayfasını bağımsız olarak özelleştirmenizi sağlar.

## **El İlanı Ana Taslağında Üstbilgi ve Altbilgileri Ayarlama**

El ilanı sayfaları, üstbilgi, altbilgi, tarih/saat ve sayfa‑numarası yer tutucuları için el ilanı ana taslağını kullanır. Not sayfalarından farklı olarak, el ilanı ayarları bireysel el ilanı slaytları yerine el ilanı ana taslağı üzerinden yönetilir.

El ilanı ana taslağına erişmek için [`getMasterHandoutSlide`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) yöntemini kullanın. Eğer mevcut değilse, varsayılan el ilanı ana taslağını oluşturmak için [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) yöntemini çağırın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kapsam ve Kalıtımı Anlama**

Değiştirmek istediğiniz kapsama uygun üstbilgi/altbilgi yöneticisini seçin:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideheaderfootermanager/) bir normal slayt için altbilgi, tarih/saat ve slayt‑numarası ayarlarını değiştirir.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslideheaderfootermanager/) bir düzen slaytını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslideheaderfootermanager/) bir normal slayt ana taslağını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslideheaderfootermanager/) notlar ana taslağını kontrol eder ve tüm bağımlı not slaytlarına ayarları yayabilir.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotesslideheaderfootermanager/) bir not slaytını değiştirir ve altbilgi, tarih/saat ve slayt numarasının yanı sıra bir üstbilgi yer tutucusunu da destekler.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) el ilanı ana taslağını değiştirir ve dört yer tutucu tipinin tümünü destekler.

Aynı ayarın bütün hiyerarşi boyunca uygulanması gerektiğinde bir ana taslak veya düzen üzerinden yayma kullanın. Tek bir sayfa için yerel bir ayar gerektiğinde bireysel slayt veya not‑slayt yöneticisini kullanın.

## **SSS**

**Normal bir slayta üstbilgi ekleyebilir miyim?**

Hayır. PowerPoint, normal slaytlar için bir üstbilgi yer tutucusu tanımlamaz. Normal slaytlarda altbilgi, tarih/saat ve slayt‑numarası yer tutucularını kullanın. Üstbilgi yer tutucuları not sayfalarında ve el ilanlarında mevcuttur.

**Altbilgi, tarih/saat veya slayt‑numarası yer tutucusu görünmüyorsa ne yapmalıyım?**

İlgili üstbilgi/altbilgi yöneticisini kullanarak görünürlüğünü kontrol edin ve gerektiğinde etkinleştirin. Örneğin, [`isFooterVisible`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) bir altbilgi yer tutucusunun var olup olmadığını raporlar ve [`setFooterVisibility`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) onu görünür hâle getirir.

**Slayt numaralandırmasını 1 dışındaki bir değerden başlatmak istiyorum, nasıl yaparım?**

Sunumun [`setFirstSlideNumber`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) metodunu çağırın. Slayt‑numarası yer tutucuları ardından güncellenmiş numaralandırma dizisini kullanır.

**PDF, resim veya HTML dışa aktarılırken üstbilgi ve altbilgi ne olur?**

Görünür üstbilgi ve altbilgi öğeleri, çıkış formatındaki sunum içeriğiyle birlikte işlenir. Görünüm, dışa aktarılan sayfa tipine ve ilgili yer tutucu görünürlük ayarlarına bağlıdır.