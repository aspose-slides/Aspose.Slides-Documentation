---
title: Bölüm
type: docs
weight: 90
url: /tr/python-net/examples/elements/section/
keywords:
- bölüm
- slayt bölümü
- bölüm ekle
- bölüme eriş
- bölüm kaldır
- bölüm yeniden adlandır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da slayt bölümlerini yönetin: kolayca oluşturun, yeniden adlandırın, yeniden sıralayın, bölümler arasında slayt taşıyın ve PPT, PPTX ve ODP için görünürlüğü kontrol edin."
---
Program aracılığıyla **Aspose.Slides for Python via .NET** kullanarak sunum bölümlerini yönetme örnekleri—ekleme, erişme, kaldırma ve yeniden adlandırma.

## **Bölüm Ekle**

Belirli bir slaytta başlayan bir bölüm oluşturun.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Yeni bir bölüm ekleyin ve bölümün başlangıcını işaret eden slaytı belirtin.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Bölüme Eriş**

Bir sunumdan bir bölüm alın.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Dizindeki bir bölüme eriş.
        section = presentation.sections[0]
```

## **Bölümü Kaldır**

Daha önce eklenmiş bir bölümü silin.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Bölümü kaldır.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Bölümü Yeniden Adlandır**

Mevcut bir bölümün adını değiştirin.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Bölümü yeniden adlandır.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```