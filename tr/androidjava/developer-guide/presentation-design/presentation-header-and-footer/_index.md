---
title: Android'de Sunum Üst ve Alt Bilgilerini Yönetme
linktitle: Üst Bilgi & Alt Bilgi
type: docs
weight: 140
url: /tr/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "Profesyonel bir görünüm için PowerPoint ve OpenDocument sunumlarına üst ve alt bilgiler eklemek ve özelleştirmek amacıyla Java aracılığıyla Android için Aspose.Slides kullanın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında üst bilgi ve alt bilgi ayarlarını yönetmenizi sağlar. Üst ve alt bilgiler sunum ana sayfası düzeyinde ele alınır ve API, alt bilgi metnini ayarlama, alt bilginin görünürlüğünü değiştirme ve ana not slaytlarındaki üst bilgi metnini güncelleme yöntemleri sunar.

Ayrıca el kitabı ve not slaytları için üst ve alt bilgileri yönetebilirsiniz. Bu, not ana sayfası, tüm alt not slaytları veya tek bir not slaytı için üst bilgi, alt bilgi, slayt numarası ve tarih‑zaman yer tutucularının görünürlüğünü ve metnini değiştirmeyi içerir.

## **Sunumda Üst ve Alt Bilgileri Yönetme**
Bazı belirli bir slaytın notları aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```java
// Sunumu Yükle
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Alt Bilgiyi Ayarlama
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Üst Bilgiye Eriş ve Güncelle
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
// Üst Bilgi/Alt Bilgi Metnini Ayarlama Yöntemi
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

## **El Kitabı ve Not Slaytlarında Üst ve Alt Bilgileri Yönetme**
Aspose.Slides for Android via Java, El kitabı ve not slaytlarında Üst ve Alt Bilgileri destekler. Lütfen aşağıdaki adımları izleyin:

- Video içeren bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) yükleyin.
- Not ana sayfası ve tüm not slaytları için Üst ve Alt Bilgi ayarlarını değiştirin.
- Ana not slaytındaki ve tüm alt Footer yer tutucularını görünür olarak ayarlayın.
- Ana not slaytındaki ve tüm alt Date and time yer tutucularını görünür olarak ayarlayın.
- Yalnızca ilk not slaytı için Üst ve Alt Bilgi ayarlarını değiştirin.
- Not slaytındaki Üst Bilgi yer tutucusunu görünür yapın.
- Not slaytı Üst Bilgi yer tutucusuna metin atayın.
- Not slaytı Date-time yer tutucusuna metin atayın.
- Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte kod bölümü sağlanmıştır.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Not ana sayfası ve tüm not slaytları için Üst ve Alt Bilgi ayarlarını değiştir
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // ana not slaytını ve tüm alt Footer yer tutucularını görünür yap
        headerFooterManager.setFooterAndChildFootersVisibility(true); // ana not slaytını ve tüm alt Header yer tutucularını görünür yap
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // ana not slaytını ve tüm alt SlideNumber yer tutucularını görünür yap
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // ana not slaytını ve tüm alt Date and time yer tutucularını görünür yap

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // metni ana not slaytı ve tüm alt Header yer tutucularına ayarla
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // metni ana not slaytı ve tüm alt Footer yer tutucularına ayarla
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // metni ana not slaytı ve tüm alt Date and time yer tutucularına ayarla
    }

    // İlk not slaytı için yalnızca Üst ve Alt Bilgi ayarlarını değiştir
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

        headerFooterManager.setHeaderText("New header text"); // metni not slaytı Header yer tutucusuna ayarla
        headerFooterManager.setFooterText("New footer text"); // metni not slaytı Footer yer tutucusuna ayarla
        headerFooterManager.setDateTimeText("New date and time text"); // metni not slaytı Date-time yer tutucusuna ayarla
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Normal slaytlara bir "üst bilgi" ekleyebilir miyim?**  
PowerPoint'te "Üst Bilgi" yalnızca notlar ve el kitapları için vardır; normal slaytlarda desteklenen öğeler alt bilgi, tarih/zaman ve slayt numarasıdır. Aspose.Slides'te de aynı sınırlamalar geçerlidir: üst bilgi yalnızca Notlar/El Kitapları için, slaytlarda ise Alt Bilgi/TarihZaman/SlaytNumarası.

**Düzen bir alt bilgi alanı içermiyorsa—görünürlüğünü "açabilir" miyim?**  
Evet. Görünürlüğü üst/alt bilgi yöneticisi aracılığıyla kontrol edin ve gerekirse etkinleştirin. Bu API göstergeleri ve yöntemleri, yer tutucu eksik veya gizli olduğunda kullanılmak üzere tasarlanmıştır.

**Slayt numarasının 1 yerine farklı bir değerden başlamasını nasıl sağlarım?**  
Sunumun [first slide number](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ayarlayın; bundan sonra tüm numaralandırma yeniden hesaplanır. Örneğin, 0 veya 10'dan başlayabilir ve başlık slaytında numarayı gizleyebilirsiniz.

**PDF/görseller/HTML'ye dışa aktarırken üst/alt bilgiler ne olur?**  
Üst ve alt bilgiler, sunumun normal metin öğeleri olarak işlenir. Yani, bu öğeler slaytlarda/not sayfalarında görünürse, çıktı formatında da içerikle birlikte görüntülenir.