---
title: JavaScript'te Sunum Notlarını Yönetme
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/nodejs-java/presentation-notes/
keywords:
- notlar
- not slaytı
- not ekle
- not kaldır
- not stili
- ana notlar
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, bu özelliği tanıtacağız; notları nasıl kaldıracağınızı ve bir sunumdaki not slaytlarına nasıl stil uygulanacağını açıklayacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldırın.
- Bir sunumdaki tüm slaytlardan notları kaldırın.

Not sayfası boyutlarını okumak veya değiştirmek, yönlendirmeyi değiştirmek ve dışa aktarma davranışını kontrol etmek için, [Not Sayfası Boyutu](/slides/tr/nodejs-java/notes-size/) sayfasına bakın.

## **Slayttan Notları Kaldırma**
Belirli bir slayttan notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturuluyor
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // İlk slaydın notları kaldırılıyor
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Sunumu diske kaydediyor
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunumdan Notları Kaldırma**
Bir sunumdaki tüm slaytlardan notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturuluyor
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Tüm slaytların notları kaldırılıyor
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Sunumu diske kaydediliyor
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotesStyle Ekle**
[getNotesStyle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) metodu, [MasterNotesSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MasterNotesSlide) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirler. Uygulama aşağıdaki örnekte gösterilmiştir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturuluyor
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // MasterNotesSlide metin stilini al
        var notesStyle = notesMaster.getNotesStyle();
        // İlk seviye paragraflar için sembol madde işareti ayarla
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Belirli bir slaytın notlarına erişimi sağlayan API varlığı nedir?**

Notlar, slaytın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [method](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) içerir; not yoksa `null` döner.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteği farklılık gösterir mi?**

Kütüphane, Microsoft PowerPoint formatlarının geniş bir yelpazesini (97–yeni) ve ODP'yi hedefler; notlar bu formatlarda, yüklü bir PowerPoint kopyasına bağlı olmadan desteklenir.