---
title: Java'da Sunum Üstbilgi ve Altbilgilerini Yönetme
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
- el dağıtımı
- notlar
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Profesyonel bir görünüm için PowerPoint ve OpenDocument sunumlarına üstbilgi ve altbilgi eklemek ve özelleştirmek için Java için Aspose.Slides'ı kullanın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında üstbilgi ve altbilgi ayarlarını yönetmenizi sağlar. Üstbilgi ve altbilgiler sunum ana sayfası seviyesinde işlenir ve API, altbilgi metnini ayarlama, altbilgi görünürlüğünü değiştirme ve ana not slaytlarında üstbilgi metnini güncelleme yöntemleri sunar.

Ayrıca el dağıtım ve not slaytları için üstbilgi ve altbilgi yönetebilirsiniz. Bu, not ana sayfası, tüm alt not slaytları veya tek bir not slaytı için üstbilgi, altbilgi, slayt numarası ve tarih‑saat yer tutucularının görünürlüğünü ve metnini değiştirmeyi içerir.

## **Sunumda Üstbilgi ve Altbilgi Yönetimi**
Bazı belirli bir slaytın notları, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```java
// Sunumu Yükle
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Altbilgiyi Ayarlama
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Üstbilgiye Erişim ve Güncelleme
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Sunumu Kaydet
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Üstbilgi/Altbilgi Metnini Ayarlama Yöntemi
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Dağıtım ve Not Slaytlarında Üstbilgi ve Altbilgi Yönetimi**
Aspose.Slides for Java, dağıtım ve not slaytlarında Üstbilgi ve Altbilgi desteği sağlar. Aşağıdaki adımları izleyin:

- Video içeren bir [Sunum](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) yükleyin.
- Not ana sayfası ve tüm not slaytları için Üstbilgi ve Altbilgi ayarlarını değiştirin.
- Ana not slaytını ve tüm alt Footer yer tutucularını görünür yapın.
- Ana not slaytını ve tüm alt Tarih ve saat yer tutucularını görünür yapın.
- Yalnızca ilk not slaytı için Üstbilgi ve Altbilgi ayarlarını değiştirin.
- Not slaytı Üstbilgi yer tutucusunu görünür yapın.
- Not slaytı Üstbilgi yer tutucusuna metin atayın.
- Not slaytı Tarih‑saat yer tutucusuna metin atayın.
- Değiştirilmiş sunum dosyasını yazın.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Not ana sayfası ve tüm not slaytları için Üstbilgi ve Altbilgi ayarlarını değiştir
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // ana not slaytını ve tüm alt Footer yer tutucularını görünür yap
        headerFooterManager.setFooterAndChildFootersVisibility(true); // ana not slaytını ve tüm alt Header yer tutucularını görünür yap
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // ana not slaytını ve tüm alt SlideNumber yer tutucularını görünür yap
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // ana not slaytını ve tüm alt tarih ve saat yer tutucularını görünür yap

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // metni ana not slaytına ve tüm alt Header yer tutucularına ata
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // metni ana not slaytına ve tüm alt Footer yer tutucularına ata
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // metni ana not slaytına ve tüm alt tarih ve saat yer tutucularına ata
    }

    // Sadece ilk not slaytı için Üstbilgi ve Altbilgi ayarlarını değiştir
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // bu not slaytının Header yer tutucusunu görünür yap

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // bu not slaytının Footer yer tutucusunu görünür yap

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // bu not slaytının SlideNumber yer tutucusunu görünür yap

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // bu not slaytının Date-time yer tutucusunu görünür yap

        headerFooterManager.setHeaderText("New header text"); // metni not slaytı Header yer tutucusuna ata
        headerFooterManager.setFooterText("New footer text"); // metni not slaytı Footer yer tutucusuna ata
        headerFooterManager.setDateTimeText("New date and time text"); // metni not slaytı Date-time yer tutucusuna ata
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Normal slaytlara bir “üstbilgi” ekleyebilir miyim?**

PowerPoint’te “Üstbilgi” yalnızca notlar ve dağıtım için bulunur; normal slaytlarda desteklenen öğeler altbilgi, tarih/saat ve slayt numarasıdır. Aspose.Slides’da da aynı sınırlamalar geçerlidir: üstbilgi sadece Not/Dağıtım için, slaytlarda ise Altbilgi/Tarih‑Saat/SlaytNumarası.

**Düzen bir altbilgi alanı içermiyorsa – görünürlüğünü “açabilir” miyim?**

Evet. Görünürlüğü üstbilgi/altbilgi yöneticisi üzerinden kontrol edin ve gerekirse etkinleştirin. Bu API göstergeleri ve yöntemleri, yer tutucu eksik ya da gizli olduğunda kullanılmak üzere tasarlanmıştır.

**Slayt numarasını 1 dışında bir değerden başlatmak istiyorum, nasıl yapabilirim?**

Sunumun [ilk slayt numarasını](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ayarlayın; ardından tüm numaralandırma yeniden hesaplanır. Örneğin 0 veya 10’dan başlayabilir ve başlık slaytındaki numarayı gizleyebilirsiniz.

**PDF/görüntüler/HTML’ye dışa aktarırken üstbilgi/altbilgi ne olur?**

Üstbilgi ve altbilgi, sunumun normal metin öğeleri olarak işlenir. Yani bu öğeler slayt/nota sayfalarında görünürse, çıktı formatında da diğer içeriklerle birlikte görüntülenir.