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
description: "Aspose.Slides for .NET ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak üretkenliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, bu özelliği tanıtacağız; notları nasıl kaldıracağınızı ve bir sunumdaki not slaytlarına nasıl stil uygulayacağınızı açıklayacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki yöntemlerle kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldırın.
- Bir sunumdaki tüm slaytlardan notları kaldırın.

[Not Sayfası Boyutu](/slides/tr/net/notes-size/)

## **Slayttan Notları Kaldır**

Belirli bir slayttaki notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturulur
Presentation presentation = new Presentation("AccessSlides.pptx");

// İlk slaydın notları kaldırılıyor
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Sunumu diske kaydet
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Tüm Slaytlardan Notları Kaldır**

Bir sunumdaki tüm slaytların notları, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturulur
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

## **Bir Not Stili Ekle**

NotesStyle özelliği, sırasıyla [IMasterNotesSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasternotesslide) arayüzüne ve [MasterNotesSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/masternotesslide) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirler. Uygulama aşağıdaki örnekte gösterilmiştir.

```c#
using Aspose.Slides;

// Sunum dosyasını temsil eden Presentation sınıfının örneği oluşturuluyor
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide metin stilini al
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //İlk seviye paragraflar için sembol madde işareti ayarla
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX dosyasını diske kaydet
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### Hangi API varlığı, belirli bir slaytın notlarına erişim sağlar?

Notlara, slaytın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/net/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [property](https://reference.aspose.com/slides/tr/net/aspose.slides/notesslidemanager/notesslide/) içerir; not yoksa `null` döndürülür.

### Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteğiyle ilgili farklar var mı?

Kütüphane, geniş bir Microsoft PowerPoint biçimi (97–yeni) ve ODP yelpazesini hedefler; notlar, bu biçimler içinde PowerPoint'in yüklü bir kopyasına bağlı olmadan desteklenir.