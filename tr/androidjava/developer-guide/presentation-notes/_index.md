---
title: Android'de Sunum Notlarını Yönetin
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
description: "Java aracılığıyla Android için Aspose.Slides ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, notları nasıl kaldıracağınızı ve bir sunumdaki not slaytlarına nasıl stil uygulayacağınızı göstereceğiz. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki biçimlerde kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldırmak.
- Bir sunumdaki tüm slaytlardan notları kaldırmak.

Not sayfası boyutlarını okumak veya değiştirmek, yönelim değiştirip dışa aktarma davranışını kontrol etmek için [Not Sayfası Boyutu](/slides/tr/androidjava/notes-size/) bölümüne bakın.

## **Slayttan Notları Kaldır**
Belirli bir slayttaki notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation nesnesi oluştur
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // İlk slaydın notlarını kaldırıyor
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Sunumu diske kaydediyor
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumdan Notları Kaldır**
Bir sunumdaki tüm slaytlardan notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```java
import com.aspose.slides.*;

// Bir sunum dosyasını temsil eden Presentation nesnesi oluştur
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Tüm slaytların notlarını kaldırıyor
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Sunumu diske kaydediyor
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Not Stili Ekle**
[getNotesStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) yöntemi, [IMasterNotesSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMasterNotesSlide) arayüzüne ve [MasterNotesSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/MasterNotesSlide) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirtir. Uygulama aşağıdaki örnekte gösterilmiştir.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation nesnesi oluştur
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide metin stilini al
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Set İlk seviye paragraflar için sembol madde işareti ayarla
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Belirli bir slaytın notlarına erişimi sağlayan API varlığı hangisidir?**

Notlara, slaytın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [method](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) içerir; not yoksa `null` döner.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteğiyle ilgili farklılıklar var mı?**

Kütüphane, geniş bir Microsoft PowerPoint formatı (97‑yeni) ve ODP yelpazesini hedefler; notlar bu formatlarda, PowerPoint yüklü olmasına bağlı olmaksızın desteklenir.