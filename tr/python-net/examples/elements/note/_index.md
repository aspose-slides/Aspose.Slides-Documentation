---
title: Not
type: docs
weight: 240
url: /tr/python-net/examples/elements/note/
keywords:
- not
- not slaytı ekle
- not slaytına eriş
- not slaytını kaldır
- not metnini güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ile Aspose.Slides kullanarak konuşmacı notlarını ekleyin, okuyun, düzenleyin ve dışa aktarın: metni biçimlendirin, slayt başına notları yönetin ve PowerPoint ve OpenDocument'ta görünürlüğü kontrol edin."
---
**Aspose.Slides for Python via .NET** kullanarak not slaytlarını ekleme, okuma, kaldırma ve güncelleme işlemlerini gösterir.

## **Not Slaytı Ekle**

Bir not slaytı oluşturun ve ona metin atayın.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Not Slaytına Erişme**

Mevcut bir not slaytından metni okuyun.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Not Slaytını Kaldır**

Bir slayt ile ilişkili not slaytını kaldırın.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Not slaytını kaldır.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Not Metnini Güncelle**

Bir not slaytının metnini değiştirin.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Not metnini güncelle.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```