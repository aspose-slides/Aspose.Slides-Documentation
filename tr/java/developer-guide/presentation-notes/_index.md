---
title: Java'da Sunum Notlarını Yönet
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, notları nasıl kaldıracağınızı ve bir sunumdaki not slaytlarına nasıl stil uygulayacağınızı göstereceğiz. Aspose.Slides herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza izin verir. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Sunumda belirli bir slayttan notları kaldır.
- Sunumdaki tüm slaytlardan notları kaldır.

Not sayfası boyutlarını okumak veya değiştirmek, yönlendirmeyi değiştirmek ve dışa aktarım davranışını kontrol etmek için [Notes Page Size](/slides/tr/java/notes-size/) bölümüne bakın.

## **Bir Slayttan Notları Kaldırma**
Belirli bir slayttan notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```java
import com.aspose.slides.*;

// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturun
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // İlk slaydın notlarını kaldırma
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Sunumu diske kaydetme
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Sunumdan Notları Kaldırma**
Bir sunumdaki tüm slaytlardan notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```java
import com.aspose.slides.*;

// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturun
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

## **Bir Not Stili Ekleme**
[getNotesStyle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) yöntemi [IMasterNotesSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IMasterNotesSlide) arabirimi ve [MasterNotesSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/MasterNotesSlide) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirler. Uygulama aşağıdaki örnekte gösterilmiştir.

```java
import com.aspose.slides.*;

// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturun
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide metin stilini al
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // İlk seviye paragraflar için sembol madde işareti ayarla
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Belirli bir slaytın notlarına erişimi sağlayan API nesnesi nedir?**

Notlar slaytın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [method](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) içerir; not yoksa `null` döner.

**Kütüphanenin çalıştığı PowerPoint sürümlerinde not desteği açısından farklar var mı?**

Kütüphane Microsoft PowerPoint (97‑yeni) ve ODP formatlarının geniş bir yelpazesini hedefler; notlar, PowerPoint yüklü olmasına bağlı olmaksızın bu formatlarda desteklenir.