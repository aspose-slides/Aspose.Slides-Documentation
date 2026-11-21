---
title: Python'da Sunum Notlarını Yönetme
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/python-net/presentation-notes/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, notları nasıl kaldıracağınızı ve bir sunumdaki not slaytlarına nasıl stil uygulayacağınızı içeren bu özelliği tanıtacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Belirli bir slayttan notları kaldırın.
- Sunumdaki tüm slaytlardan notları kaldırın.

Not sayfası boyutlarını okumak veya değiştirmek, yönlendirmeyi değiştirmek ve dışa aktarma davranışını kontrol etmek için, bakınız [Not Sayfası Boyutu](/slides/tr/python-net/notes-size/).

## **Bir Slayttan Notları Kaldırma**
Belirli bir slayttan notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```py
import aspose.slides as slides

# Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
with slides.Presentation("AccessSlides.pptx") as presentation:
    # İlk slaytın notlarını kaldırma
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # sunumu diske kaydet
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tüm Slaytlardan Notları Kaldırma**
Sunumdaki tüm slaytlardan notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```py
import aspose.slides as slides

# Bir sunum dosyasını temsil eden Presentation nesnesini oluştur 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Tüm slaytların notlarını kaldırma
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # sunumu diske kaydet
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Not Stili Uygulama**
Bu [notes_style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslide/notes_style/) özelliği, [MasterNotesSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslide/) sınıfına eklenmiştir. Bu özellik, not metninin stilini belirler. Uygulama aşağıdaki örnekte gösterilmiştir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekle
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide metin stilini al
        notesStyle = notesMaster.notes_style

        # İlk seviye paragraflar için sembol madde işareti ayarla
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX dosyasını diske kaydet
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Belirli bir slaytın notlarına erişimi sağlayan API varlığı nedir?**

Notlara, slaytın not yöneticisi aracılığıyla erişilir: slayt, bir [NotesSlideManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [property](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslidemanager/notes_slide/) içerir; not yoksa `None` döndürülür.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteği konusunda farklılıklar var mı?**

Kütüphane, Microsoft PowerPoint formatlarının (97‑yeni) ve ODP'nin geniş bir yelpazesini hedefler; notlar, bu formatlar içinde PowerPoint'in kurulu bir kopyasına bağımlı olmadan desteklenir.