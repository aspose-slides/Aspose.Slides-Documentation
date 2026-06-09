---
title: JavaScript ile Sunum Üstbilgi ve Altbilgilerini Yönetme
linktitle: Üstbilgi & Altbilgi
type: docs
weight: 140
url: /tr/nodejs-java/presentation-header-and-footer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında üstbilgi ve altbilgileri eklemek ve özelleştirmek için JavaScript ve Aspose.Slides for Node.js kullanın ve profesyonel bir görünüm elde edin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında üstbilgi ve altbilgi ayarlarını yönetmenizi sağlar. Üstbilgi ve altbilgiler sunum ana düzeyinde ele alınır ve API, altbilgi metnini ayarlama, altbilgi görünürlüğünü değiştirme ve ana not slaytlarındaki üstbilgi metnini güncelleme yöntemleri sunar.

Ayrıca el ilanı ve not slaytları için üstbilgi ve altbilgi yönetebilirsiniz. Bu, not ana slaytı, tüm alt not slaytları veya tek bir not slaytı için üstbilgi, altbilgi, slayt numarası ve tarih‑saat yer tutucularının görünürlüğünü ve metnini değiştirmeyi içerir.

## **Sunumda Üstbilgi ve Altbilgiyi Yönetme**
Bazı belirli bir slaydın notları aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```javascript
// Sunumu Yükle
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Altbilgi Ayarlama
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Üstbilgiye Eriş ve Güncelle
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Sunumu Kaydet
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **El İlanı ve Not Slaytlarında Üstbilgi ve Altbilgiyi Yönetme**
Aspose.Slides for Node.js via Java, El İlanı ve not slaytlarında Üstbilgi ve Altbilgiyi destekler. Lütfen aşağıdaki adımları izleyin:

- Video içeren bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) yükleyin.
- Not ana slaytı ve tüm not slaytları için Üstbilgi ve Altbilgi ayarlarını değiştirin.
- Ana not slaydında ve tüm alt Footer yer tutucularını görünür yapın.
- Ana not slaydında ve tüm alt Tarih ve saat yer tutucularını görünür yapın.
- Yalnızca ilk not slaytı için Üstbilgi ve Altbilgi ayarlarını değiştirin.
- Not slaydındaki Üstbilgi yer tutucusunu görünür yapın.
- Not slaydındaki Üstbilgi yer tutucusuna metin atayın.
- Not slaydındaki Tarih‑saat yer tutucusuna metin atayın.
- Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte kod parçacığı sağlanmıştır.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Not ana slaytı ve tüm not slaytları için Üstbilgi ve Altbilgi ayarlarını değiştir
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// Ana not slaytını ve tüm alt Footer yer tutucularını görünür yap
        headerFooterManager.setFooterAndChildFootersVisibility(true);// Ana not slaytını ve tüm alt Header yer tutucularını görünür yap
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// Ana not slaytını ve tüm alt SlideNumber yer tutucularını görünür yap
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// Ana not slaytını ve tüm alt Tarih ve saat yer tutucularını görünür yap
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// Metni ana not slaytına ve tüm alt Header yer tutucularına ayarla
        headerFooterManager.setFooterAndChildFootersText("Footer text");// Metni ana not slaytına ve tüm alt Footer yer tutucularına ayarla
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// Metni ana not slaytına ve tüm alt Tarih ve saat yer tutucularına ayarla
    }
    // Sadece ilk not slaytı için Üstbilgi ve Altbilgi ayarlarını değiştir
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// Bu not slaytının Header yer tutucusunu görünür yap
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// Bu not slaytının Footer yer tutucusunu görünür yap
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// Bu not slaytının SlideNumber yer tutucusunu görünür yap
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// Bu not slaytının Date-time yer tutucusunu görünür yap
        headerFooterManager.setHeaderText("New header text");// Metni not slaytının Header yer tutucusuna ayarla
        headerFooterManager.setFooterText("New footer text");// Metni not slaytının Footer yer tutucusuna ayarla
        headerFooterManager.setDateTimeText("New date and time text");// Metni not slaytının Date-time yer tutucusuna ayarla
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Normal slaytlara bir "üstbilgi" ekleyebilir miyim?**

PowerPoint'te "Header" yalnızca notlar ve el ilanları için mevcuttur; normal slaytlarda desteklenen öğeler altbilgi, tarih/saat ve slayt numarasıdır. Aspose.Slides'de de aynı sınırlamalar geçerlidir: üstbilgi sadece Notlar/El İlanı için, slaytlarda ise Altbilgi/TarihSaat/SlaytNumarası.

**Düzen altbilgi alanı içermiyorsa—görünürlüğünü "aç"abilir miyim?**

Evet. Üstbilgi/altbilgi yöneticisi aracılığıyla görünürlüğü kontrol edin ve gerekirse etkinleştirin. Bu API göstergeleri ve yöntemleri, yer tutucu eksik ya da gizli olduğunda kullanılmak üzere tasarlanmıştır.

**Slayt numarasının 1 yerine başka bir değerden başlamasını nasıl sağlarım?**

Sunumun [first slide number](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) özelliğini ayarlayın; bundan sonra tüm numaralandırma yeniden hesaplanır. Örneğin, 0 ya da 10'dan başlayabilir ve başlık slaydındaki numarayı gizleyebilirsiniz.

**PDF/görseller/HTML olarak dışa aktarıldığında üstbilgi/altbilgiler ne olur?**

Sunumun normal metin öğeleri olarak işlenirler. Yani, öğeler slaytlarda/not sayfalarında görünür durumdaysa, çıktı formatında da içeriğin geri kalanıyla birlikte görüneceklerdir.