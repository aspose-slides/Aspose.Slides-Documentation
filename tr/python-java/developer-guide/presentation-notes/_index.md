---
title: Python üzerinden Java ile Sunum Notlarını Yönet
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/python-java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak üretkenliğinizi artırın."
---
## **Overview**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konu, notları nasıl kaldıracağınızı ve bir sunumdaki not slaytlarına stil nasıl uygulayacağınızı da içeren bu özelliği tanıtır. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki yollarla kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldırın.
- Bir sunumdaki tüm slaytlardan notları kaldırın.

Not sayfası boyutlarını okumak veya değiştirmek, yönlendirmeyi değiştirmek ve dışa aktarım davranışını kontrol etmek için [Notes Page Size](/slides/tr/python-java/notes-size/) sayfasına bakın.

## **Remove Notes from a Slide**

Belirli bir slayttaki notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Bir sunum dosyasını temsil eden bir Presentation nesnesi oluşturuluyor.
presentation = Presentation("presWithNotes.pptx")
try:
    # İlk slayttan notlar kaldırılıyor.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Sunumu diske kaydediyor.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remove Notes from a Presentation**

Bir sunumdaki tüm slaytlardaki notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Bir sunum dosyasını temsil eden Presentation nesnesi oluştur.
presentation = Presentation("presWithNotes.pptx")
try:
    # Tüm slaytlardan notları kaldır.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Sunumu diske kaydet.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add a Notes Style**

[getNotesStyle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslide/#getNotesStyle) yöntemi, [MasterNotesSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslide/) sınıfının not metninin stiline erişim sağlar. Uygulama aşağıdaki örnekte gösterilmiştir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Bir sunum dosyasını temsil eden Presentation nesnesi oluştur.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Ana not slaytı metin stilini al.
        notes_style = notes_master.getNotesStyle()

        # Birinci seviyedeki paragraflar için sembol madde imlerini ayarla.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Belirli bir slaydın notlarına erişim sağlayan API varlığı nedir?**

Notlar, slaydın not yöneticisi aracılığıyla erişilir: slaydın bir [NotesSlideManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [getNotesSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notesslidemanager/#getNotesSlide) yöntemi vardır; not yoksa `None` döner.

**Kütüphanenin çalıştığı PowerPoint sürümlerinde not desteği açısından farklılıklar var mı?**

Kütüphane, geniş bir Microsoft PowerPoint formatı yelpazesini (97 ve sonrası) ve ODP'yi hedefler; notlar, bu formatlar içinde PowerPoint'in kurulu bir kopyasına bağımlı olmadan desteklenir.