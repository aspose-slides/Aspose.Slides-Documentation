---
title: JavaScript'te Sunum Notlarını Yönetme
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/nodejs-java/presentation-notes/
keywords:
- notlar
- not slaytı
- nota ekle
- notları kaldır
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

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, bu özelliği, notları nasıl kaldıracağınızı ve bir sunumdaki not slaytlarına nasıl stil uygulayacağınızı tanıtacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Sunumdaki belirli bir slayttan notları kaldır.
- Sunumdaki tüm slaytlardan notları kaldır.

## **Slayttan Notları Kaldır**
Belirli bir slaydın notları aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```javascript
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // İlk slaydın notlarını kaldırma
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Sunumu diske kaydetme
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunumdan Notları Kaldır**
Sunumdaki tüm slaytların notları aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```javascript
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Tüm slaytların notlarını kaldırma
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Sunumu diske kaydetme
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotStilini Ekle**
[getNotesStyle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) yöntemi, [MasterNotesSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MasterNotesSlide) sınıfına ve [MasterNotesSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MasterNotesSlide) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirler. Uygulama aşağıdaki örnekte gösterilmiştir.

```javascript
// Sunum dosyasını temsil eden bir Presentation nesnesi oluştur
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // MasterNotesSlide metin stilini al
        var notesStyle = notesMaster.getNotesStyle();
        // İlk seviye paragraflar için sembol madde işaretini ayarla
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Belirli bir slaydın notlarına hangi API varlığı erişim sağlar?**

Notlara, slaydın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [method](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) içerir; not yoksa `null` döner.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteğiyle ilgili farklılıklar var mı?**

Kütüphane, Microsoft PowerPoint formatlarının geniş bir yelpazesini (97–yeni) ve ODP'yi hedefler; notlar bu formatlar içinde, PowerPoint'in kurulu bir kopyasına bağlı olmaksızın desteklenir.