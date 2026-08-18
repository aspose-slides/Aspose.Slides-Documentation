---
title: Sunum Başlık ve Alt Bilgilerini .NET'te Yönet
linktitle: Başlık ve Alt Bilgi
type: docs
weight: 140
url: /tr/net/presentation-header-and-footer/
keywords:
- başlık
- başlık metni
- alt bilgi
- alt bilgi metni
- başlık ayarla
- alt bilgi ayarla
- el ilanı
- notlar
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile slaytlarda, not sayfalarında ve el ilanlarında alt bilgi, tarih‑saat, slayt‑numarası ve başlık yer tutucularını nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

PowerPoint, sayfa türüne bağlı olarak farklı başlık ve alt bilgi yer tutucuları kullanır. Aspose.Slides for .NET, bu yer tutucuların metnini ve görünürlüğünü başlık/alt bilgi yöneticisi arabirimleri aracılığıyla kontrol etmenizi sağlar.

Mevcut yer tutucular kapsamına bağlıdır:

| Kapsam | Başlık | Alt Bilgi | Tarih/saat | Slayt/sayfa numarası |
|---|---|---|---|---|
| Normal slayt | Hayır | Evet | Evet | Evet |
| Notlar ana şablonu | Evet | Evet | Evet | Evet |
| Not slaytı | Evet | Evet | Evet | Evet |
| El ilanı ana şablonu | Evet | Evet | Evet | Evet |

Normal bir sunum slaytının başlık yer tutucusu yoktur. Başlıklar not sayfalarında ve el ilanlarında bulunur. Normal slaytlar için, bunun yerine alt bilgi, tarih/saat ve slayt numarası yer tutucularını kullanın.

Bir değişikliğin kapsamı kullandığınız yöneticiye bağlıdır. [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/islideheaderfootermanager/) arabirimi bir normal slaytı kontrol eder. [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/inotesslideheaderfootermanager/) arabirimi bir not slaytını kontrol eder. Ana ve düzen yöneticileri ayrıca ayarları bağlı slaytlara yayabilir, [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterhandoutslideheaderfootermanager/) arabirimi ise el ilanı ana şablonunu kontrol eder.

## **Normal Slaytlarda Alt Bilgi, Tarih/Saat ve Slayt Numaralarını Ayarlama**

Normal slaytlar için temel iş akışı, her slaytın başlık/alt bilgi yöneticisine erişmek, alt bilgi ve tarih/saat metnini ayarlamak, gerekli yer tutucuları etkinleştirmek ve sunumu kaydetmektir. Slayt numaraları sunum tarafından oluşturulur, bu nedenle yalnızca görünürlüğünü kontrol etmeniz gerekir.

[`SetFooterText`](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) ve [`SetDateTimeText`](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) kullanarak metni ayarlayın ve [`SetFooterVisibility`](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) kullanarak ilgili yer tutucuları gösterin.

Aşağıdaki uçtan uca örnek, aynı alt bilgi, tarih/saat metni ve slayt numarası görünürlüğünü tüm normal slaytlara uygular:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Yalnızca bir slaytı güncellemeniz gerekiyorsa, tüm koleksiyonu döngüyle gezmek yerine [`Slides`](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) koleksiyonu üzerinden o slayta doğrudan erişin.

## **Notlar Ana Şablonunda Başlık ve Alt Bilgileri Ayarlama**

Notlar ana şablonu, not sayfaları için ortak biçimlendirme ve yer tutucu davranışını tanımlar. Yalnızca notlar ana şablonunu değiştirmek istediğinizde [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasternotesslideheaderfootermanager/) arabirimini kullanın.

Aşağıdaki örnek, notlar ana şablonunda başlık, alt bilgi ve tarih/saat metnini ayarlar ve o ana şablondaki tüm desteklenen yer tutucuları görünür kılar:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

[`MasterNotesSlide`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasternotesslidemanager/masternotesslide/) özelliği, sunumda notlar ana şablonu bulunmadığında `null` döndürür.

## **Notlar Ana Şablonu Ayarlarını Alt Not Slaytlarına Uygulama**

Bir notlar ana şablonu, kendi başlık ve alt bilgi ayarlarını kendisine ve tüm bağlı not slaytlarına uygulayabilir. Aynı ayarların notlar hiyerarşisi boyunca uygulanması gerektiğinde [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasternotesslideheaderfootermanager/) üzerindeki özel yayma yöntemlerini kullanın.

Örneğin, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) ve [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) notlar ana şablonu başlığını ve tüm alt başlıkları günceller. Alt bilgiler, tarih/saat ve slayt numaraları için eşdeğer yöntemler mevcuttur.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Yukarıda kullanılan yayma yöntemleri şunlardır: [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), ve [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Bireysel Not Slaytında Başlık ve Alt Bilgileri Ayarlama**

Bir not slaytı, belirli bir normal slayta bağlıdır. Yalnızca o not sayfasını özelleştirmek istediğinizde onun [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/inotesslideheaderfootermanager/) arabirimini kullanın.

[`AddNotesSlide`](https://reference.aspose.com/slides/tr/net/aspose.slides/inotesslidemanager/addnotesslide/) yöntemi, mevcut slayt için not slaytını döndürür ve henüz mevcut değilse bir tane oluşturur. Aşağıdaki örnek, ilk sunum slaytıyla ilişkili not sayfasını yapılandırır:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Önce notlar ana şablonundan ayarları yayar, ardından bireysel bir not slaytını değiştirirseniz, sonradan yapılan slayt‑başına ayarlar o not sayfasını bağımsız olarak özelleştirmenizi sağlar.

## **El İlanı Ana Şablonunda Başlık ve Alt Bilgileri Ayarlama**

El ilanı sayfaları, başlık, alt bilgi, tarih/saat ve sayfa numarası yer tutucuları için el ilanı ana şablonunu kullanır. Not sayfalarından farklı olarak, el ilanı ayarları bireysel el ilanı slaytları yerine el ilanı ana şablonu üzerinden yönetilir.

[`MasterHandoutSlide`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) özelliğini kullanarak el ilanı ana şablonuna erişin. Mevcut değilse, varsayılan el ilanı ana şablonunu oluşturmak için [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) yöntemini çağırın.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Kapsam ve Kalıtımı Anlama**

Değiştirmek istediğiniz kapsamla eşleşen başlık/alt bilgi yöneticisini seçin:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/islideheaderfootermanager/) bir normal slayt için alt bilgi, tarih/saat ve slayt numarası ayarlarını değiştirir.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslideheaderfootermanager/) bir yerleşim slaytını kontrol eder ve desteklenen ayarları bağlı slaytlara yayabilir.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslideheaderfootermanager/) normal bir slayt ana şablonunu kontrol eder ve desteklenen ayarları bağlı slaytlara yayabilir.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasternotesslideheaderfootermanager/) notlar ana şablonunu kontrol eder ve ayarları tüm bağlı not slaytlarına yayabilir.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/inotesslideheaderfootermanager/) tek bir not slaytını değiştirir ve alt bilgi, tarih/saat, slayt numarasının yanı sıra bir başlık yer tutucusunu da destekler.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterhandoutslideheaderfootermanager/) el ilanı ana şablonunu değiştirir ve dört yer tutucu tipinin tamamını destekler.

Aynı ayarın hiyerarşisi boyunca uygulanması gerektiğinde bir ana şablondan veya yerleşimden yayım kullanın. Tek bir sayfa için yerel bir ayar gerektiğinde bireysel slayt veya not‑slayt yöneticisini kullanın.

## **SSS**

**Normal bir slayta başlık ekleyebilir miyim?**

Hayır. PowerPoint normal slaytlar için bir başlık yer tutucusu tanımlamaz. Normal slaytlarda alt bilgi, tarih/saat ve slayt numarası yer tutucularını kullanın. Başlık yer tutucuları not sayfalarında ve el ilanlarında bulunur.

**Alt bilgi, tarih/saat veya slayt numarası yer tutucusu görünür değilse ne olur?**

İlgili başlık/alt bilgi yöneticisini kullanarak görünürlüğünü kontrol edin ve gerektiğinde etkinleştirin. Örneğin, [`IsFooterVisible`](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) bir alt bilgi yer tutucusunun mevcut olup olmadığını raporlar ve [`SetFooterVisibility`](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) görünürlüğünü değiştirir.

**Slayt numaralandırmasını 1 dışındaki bir değerden nasıl başlatırım?**

Sunumun [`FirstSlideNumber`](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/firstslidenumber/) özelliğini ayarlayın. Slayt‑numarası yer tutucuları güncellenen numaralandırma dizisini kullanır.

**PDF, görüntüler veya HTML'ye dışa aktarırken başlık ve alt bilgiler ne olur?**

Görünür başlık ve alt bilgi öğeleri, sunum içeriğinin geri kalanıyla birlikte çıktıda render edilir. Görünüm, dışa aktarılan sayfa türüne ve ilgili yer tutucu görünürlük ayarlarına bağlıdır.