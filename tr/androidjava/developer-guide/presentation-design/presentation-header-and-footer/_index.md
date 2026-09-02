---
title: Android'de Sunum Başlık ve Alt Bilgilerini Yönetme
linktitle: Başlık ve Alt Bilgi
type: docs
weight: 140
url: /tr/androidjava/presentation-header-and-footer/
keywords:
- başlık
- başlık metni
- alt bilgi
- alt bilgi metni
- başlık ayarla
- alt bilgi ayarla
- dağıtım
- notlar
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile slaytlarda, not sayfalarında ve dağıtımlarda alt bilgi, tarih-saat, slayt-numarası ve başlık yer tutucularını nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

PowerPoint sayfa türüne göre farklı başlık ve alt bilgi yer tutucuları kullanır. Aspose.Slides for Android via Java, bu yer tutucuların metnini ve görünürlüğünü başlık/alt bilgi yöneticisi arayüzleri aracılığıyla kontrol etmenizi sağlar.

Mevcut yer tutucular kapsamına bağlıdır:

| Kapsam | Başlık | Alt Bilgi | Tarih/Zaman | Slayt/sayfa numarası |
|---|---|---|---|---|
| Normal slayt | Hayır | Evet | Evet | Evet |
| Notlar ana | Evet | Evet | Evet | Evet |
| Not slaytı | Evet | Evet | Evet | Evet |
| Dağıtım ana | Evet | Evet | Evet | Evet |

Normal bir sunum slaytının başlık yer tutucusu yoktur. Başlıklar not sayfalarında ve dağıtım sayfalarında bulunur. Normal slaytlar için bunun yerine alt bilgi, tarih/zaman ve slayt‑numarası yer tutucularını kullanın.

Bir değişikliğin kapsamı kullandığınız yönetime bağlıdır. [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideheaderfootermanager/) arayüzü bir normal slaytı kontrol eder. [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) arayüzü bir not slaytını kontrol eder. Ana ve yerleşim yöneticileri ayrıca ayarları bağımlı slaytlara yayabilir, buna karşın [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) arayüzü dağıtım ana sayfasını kontrol eder.

## **Normal Slaytlarda Alt Bilgi, Tarih/Zaman ve Slayt Numaralarını Ayarlama**

Normal slaytlar için temel iş akışı, her slaytın başlık/alt bilgi yöneticisine erişmek, alt bilgi ve tarih/zaman metnini ayarlamak, gerekli yer tutucuları etkinleştirmek ve sunumu kaydetmektir. Slayt numaraları sunum tarafından oluşturulur, bu yüzden yalnızca görünürlüklerini kontrol etmeniz yeterlidir.

[`setFooterText`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) ve [`setDateTimeText`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) metodlarını metin ayarlamak için kullanın ve [`setFooterVisibility`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), ve [`setSlideNumberVisibility`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) metodlarını ilgili yer tutucuları göstermek için kullanın.

Aşağıdaki uçtan uca örnek aynı alt bilgi, tarih/zaman metnini ve slayt‑numarası görünürlüğünü tüm normal slaytlara uygular:

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

Yalnızca bir slaytı güncellemeniz gerekiyorsa, tüm koleksiyonu döngüyle gezmek yerine [`getSlides`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlides--) yöntemiyle o slayta doğrudan erişin.

## **Notlar Ana Sayfasında Başlık ve Alt Bilgileri Ayarlama**

Notlar ana sayfası, not sayfaları için ortak biçimlendirme ve yer tutucu davranışını tanımlar. Yalnızca notlar ana sayfasını değiştirmek istediğinizde [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) arayüzünü kullanın.

Aşağıdaki örnek notlar ana sayfasında başlık, alt bilgi ve tarih/zaman metnini ayarlar ve o ana sayfadaki tüm desteklenen yer tutucuları görünür kılar:

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

[`getMasterNotesSlide`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) yöntemi, sunum bir notlar ana sayfası içermediğinde `null` döndürür.

## **Notlar Ana Ayarlarını Alt Not Slaytlarına Uygulama**

Bir notlar ana sayfası, başlık ve alt bilgi ayarlarını kendisine ve tüm bağımlı not slaytlarına uygulayabilir. Aynı ayarların not hiyerarşisi boyunca uygulanması gerektiğinde [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) üzerindeki özel yayma yöntemlerini kullanın.

Örneğin, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) ve [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) notlar ana sayfası başlığını ve tüm alt başlıkları günceller. Alt bilgiler, tarih/zaman ve slayt numaraları için eşdeğer yöntemler mevcuttur.

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

Yukarıda kullanılan yayma yöntemleri şunlardır: [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), ve [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Tek Bir Not Slaytında Başlık ve Alt Bilgileri Ayarlama**

Bir not slaytı belirli bir normal slayta aittir. Yalnızca o not sayfasını özelleştirmek istediğinizde onun [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) arayüzünü kullanın.

[`addNotesSlide`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) yöntemi mevcut slayt için not slaytını döndürür ve mevcut değilse bir tane oluşturur. Aşağıdaki örnek ilk sunum slaytıyla ilişkili not sayfasını yapılandırır:

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

Önce notlar ana sayfasından ayarları yayar, ardından tek bir not slaytını değiştirirseniz, daha sonraki slayt‑başına ayarlar o not sayfasını bağımsız olarak özelleştirmenizi sağlar.

## **Dağıtım Ana Sayfasında Başlık ve Alt Bilgileri Ayarlama**

Dağıtım sayfaları, başlık, alt bilgi, tarih/zaman ve sayfa numarası yer tutucuları için dağıtım ana sayfasını kullanır. Not sayfalarının aksine, dağıtım ayarları tek tek dağıtım slaytları yerine dağıtım ana sayfası üzerinden yönetilir.

[`getMasterHandoutSlide`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) yöntemini dağıtım ana sayfasına erişmek için kullanın. Eğer mevcut değilse, varsayılan dağıtım ana sayfasını oluşturmak için `[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--)` çağırın.

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

Kapsamını değiştirmek istediğiniz başlık/alt bilgi yöneticisini seçin:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideheaderfootermanager/) bir normal slayt için alt bilgi, tarih/zaman ve slayt‑numarası ayarlarını değiştirir.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) bir yerleşim slaytını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) bir normal slayt ana sayfasını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) notlar ana sayfasını kontrol eder ve tüm bağımlı not slaytlarına ayarları yayabilir.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) bir not slaytını değiştirir ve alt bilgi, tarih/zaman ve slayt numarasına ek olarak bir başlık yer tutucusunu da destekler.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) dağıtım ana sayfasını değiştirir ve dört yer tutucu tipinin tamamını destekler.

Aynı ayarın hiyerarşisinin tamamına uygulanması gerektiğinde bir ana ya da yerleşimden yayım kullanın. Tek bir sayfa için yerel bir ayara ihtiyaç duyduğunuzda bireysel slayt ya da not‑slayt yöneticisini kullanın.

## **SSS**

**Normal bir slayta başlık ekleyebilir miyim?**

Hayır. PowerPoint normal slaytlar için bir başlık yer tutucusu tanımlamaz. Normal slaytlarda alt bilgi, tarih/zaman ve slayt‑numarası yer tutucularını kullanın. Başlık yer tutucuları not sayfalarında ve dağıtımlarda mevcuttur.

**Alt bilgi, tarih/zaman veya slayt‑numarası yer tutucusu görünür değilse ne olur?**

İlgili başlık/alt bilgi yöneticisini kullanarak görünürlüğünü kontrol edin ve gerektiğinde etkinleştirin. Örneğin, [`isFooterVisible`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) bir alt bilgi yer tutucusunun mevcut olup olmadığını bildirir ve [`setFooterVisibility`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) görünürlüğünü değiştirir.

**Slayt numaralandırmasını 1'den farklı bir değerden nasıl başlatırım?**

Sunumun [`setFirstSlideNumber`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) metodunu çağırın. Slayt‑numarası yer tutucuları ardından güncellenmiş numaralandırma dizisini kullanır.

**Başlık ve alt bilgiler PDF, resimler veya HTML olarak dışa aktarıldığında ne olur?**

Görünür başlık ve alt bilgi öğeleri, çıktı formatında sunum içeriğinin geri kalanıyla birlikte işlenir. Görünüşleri, dışa aktarılacak sayfa türüne ve ilgili yer tutucu görünürlük ayarlarına bağlıdır.