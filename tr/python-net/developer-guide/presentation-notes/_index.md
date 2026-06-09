---
title: Python'da Sunum Notlarını Yönet
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

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu bölümde, bu özelliği, notların nasıl kaldırılacağını ve bir sunumdaki not slaytlarına nasıl stil uygulanacağını tanıtacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki yollarla kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldırın.
- Bir sunumdaki tüm slaytlardan notları kaldırın.

## **Slayttan Notları Kaldır**

Aşağıdaki örnekte gösterildiği gibi belirli bir slayttan notlar kaldırılabilir:

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # İlk slaytın notlarını kaldırma
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # sunumu diske kaydet
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tüm Slaytlardan Notları Kaldır**

Aşağıdaki örnekte gösterildiği gibi bir sunumdaki tüm slaytlardan notlar kaldırılabilir:

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Tüm slaytların notlarını kaldırma
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # sunumu diske kaydet
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **NotesStyle Ekle**

[notes_style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslide/notes_style/) özelliği, [MasterNotesSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masternotesslide/) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirtir. Uygulama aşağıdaki örnekte gösterilmiştir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide metin stilini al
        notesStyle = notesMaster.notes_style

        #İlk seviye paragraflar için sembol madde işareti ayarla
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX dosyasını diske kaydet
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Belirli bir slaydın notlarına erişimi sağlayan API varlığı nedir?**

Notlara, slaydın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [property](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notesslidemanager/notes_slide/) (not yoksa `None`) içerir.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteği açısından farklılıklar var mı?**

Kütüphane, geniş bir Microsoft PowerPoint (97–yeni) ve ODP formatı yelpazesini hedefler; notlar, bu formatlarda PowerPoint'in kurulu bir kopyasına bağımlı olmaksızın desteklenir.