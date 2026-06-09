---
title: .NET'te Sunum Notlarını Yönet
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunum notlarınızı özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak üretkenliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırma özelliğini destekler. Bu konuda, notların nasıl kaldırılacağını ve bir sunumdaki not slaytlarına nasıl stil uygulanacağını tanıtacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Sunumda belirli bir slayttan notları kaldırın.
- Sunumdaki tüm slaytlardan notları kaldırın.

## **Bir Slayttan Notları Kaldırma**
Belirli bir slaydın notları aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```c#
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// İlk slaydın notlarını kaldırma
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Sunumu diske kaydet
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Tüm Slaytlardan Notları Kaldırma**
Sunumdaki tüm slaytların notları aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```c#
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Tüm slaytların notlarını kaldırma
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Sunumu diske kaydet
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Not Stili Ekleme**
NotesStyle özelliği sırasıyla [IMasterNotesSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasternotesslide) arayüzüne ve [MasterNotesSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslide) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirler. Uygulama aşağıdaki örnekte gösterilmiştir.

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide metin stilini alın
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // İlk seviye paragraflar için sembol madde işareti ayarlayın
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX dosyasını diske kaydedin
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

**Hangi API varlığı belirli bir slaydın notlarına erişim sağlar?**

Notlara, slaydın not yöneticisi aracılığıyla erişilir: slaytta bir [NotesSlideManager](https://reference.aspose.com/slides/tr/net/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [property](https://reference.aspose.com/slides/tr/net/aspose.slides/notesslidemanager/notesslide/) bulunur, not yoksa `null` döner.

**Kütüphanenin çalıştığı PowerPoint sürümlerinde not desteğiyle ilgili farklar var mı?**

Kütüphane, Microsoft PowerPoint'in geniş bir sürüm aralığını (97‑ve üzeri) ve ODP'yi hedefler; notlar bu formatlar içinde, yüklü bir PowerPoint kopyasına bağlı olmadan desteklenir.