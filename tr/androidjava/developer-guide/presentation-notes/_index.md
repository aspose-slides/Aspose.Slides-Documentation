---
title: Android'de Sunum Notlarını Yönetme
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java üzerinden sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, bu özelliği, notların nasıl kaldırılacağını ve bir sunumdaki not slaytlarına nasıl stil uygulanacağını tanıtacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldırın.
- Bir sunumdaki tüm slaytlardan notları kaldırın.

## **Bir Slayttan Notları Kaldırma**
Belirli bir slayttaki notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // İlk slaytın notlarını kaldırma
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Sunumu diske kaydetme
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Sunumdan Notları Kaldırma**
Bir sunumdaki tüm slaytlardaki notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturun
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Tüm slaytların notlarını kaldırma
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Sunumu diske kaydetme
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Not Stili Ekleme**
[getNotesStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) yöntemi, [IMasterNotesSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMasterNotesSlide) arayüzüne ve [MasterNotesSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/MasterNotesSlide) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirtir. Uygulama aşağıdaki örnekte gösterilmiştir.

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide metin stilini al
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Set birinci seviye paragraflar için sembol madde işareti
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Belirli bir slaytın notlarına erişimi sağlayan API öğesi hangisidir?**

Notlara, slaytın not yöneticisi aracılığıyla erişilir: slaytın bir [NotesSlideManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [method](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) vardır; not yoksa `null` döner.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteğinde farklılıklar var mı?**

Kütüphane, Microsoft PowerPoint (97-yenisi) ve ODP formatlarının geniş bir yelpazesini hedefler; notlar bu formatlarda, PowerPoint'in kurulu bir kopyasına bağımlı olmaksızın desteklenir.