---
title: Python aracılığıyla Java ile Sunum Notlarını Yönetin
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
description: "Aspose.Slides for Python via Java ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konu, notları kaldırma ve bir sunumdaki not slaytlarına stil uygulama dahil bu özelliği tanıtır. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldırın.
- Bir sunumdaki tüm slaytlardan notları kaldırın.

## **Bir Slayttan Notları Kaldır**

Belirli bir slayttaki notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Bir sunum dosyasını temsil eden Presentation nesnesini oluşturun.
presentation = Presentation("presWithNotes.pptx")
try:
    # İlk slayttan notları kaldırın.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Sunumu diske kaydedin.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Sunumdan Notları Kaldır**

Bir sunumdaki tüm slaytlardan notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Bir sunum dosyasını temsil eden Presentation nesnesini oluşturun.
presentation = Presentation("presWithNotes.pptx")
try:
    # Tüm slaytlardan notları kaldırın.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Sunumu diske kaydedin.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Not Stili Ekle**

[getNotesStyle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslide/#getNotesStyle) yöntemi, [MasterNotesSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslide/) sınıfının not metni stiline erişim sağlar. Uygulama aşağıdaki örnekte gösterilmiştir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Ana not slaytı metin stilini alın.
        notes_style = notes_master.getNotesStyle()

        # Birinci seviye paragraflar için simge madde işaretleri ayarlayın.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Belirli bir slaytın notlarına erişim sağlayan API varlığı nedir?**

Notlar, slaytın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notesslidemanager/) ve not nesnesini döndüren veya not yoksa `None` döndüren bir [getNotesSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notesslidemanager/#getNotesSlide) yöntemine sahiptir.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteğinde farklılıklar var mı?**

Kütüphane, Microsoft PowerPoint formatlarının (97 ve sonrası) ve ODP'nin geniş bir yelpazesini hedefler; notlar bu formatlarda, PowerPoint'in yüklü bir kopyasına bağımlı olmaksızın desteklenir.