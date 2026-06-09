---
title: Tablo
type: docs
weight: 120
url: /tr/python-net/examples/elements/table/
keywords:
- tablo
- tablo ekle
- tabloya eriş
- tablo kaldır
- hücre birleştir
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ile Aspose.Slides kullanarak tablolar oluşturun ve biçimlendirin: veri ekleyin, hücreleri birleştirin, kenarlıkları stilize edin, içeriği hizalayın ve PPT, PPTX ve ODP için içe/dışa aktarın."
---
**Aspose.Slides for Python via .NET** kullanarak tablo ekleme, tabloya erişme, tablo silme ve hücre birleştirme örnekleri.

## **Tablo Ekle**

İki satır ve iki sütundan oluşan basit bir tablo oluşturun.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Sütun genişliklerini ve satır yüksekliklerini tanımla.
        widths = [80, 80]
        heights = [30, 30]

        # Slayta bir tablo şekli ekle.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabloya Eriş**

Slayttaki ilk tablo şekline ulaşın.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Slayttaki ilk tabloya eriş.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Tabloyu Kaldır**

Bir slayttan tabloyu silin.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir tablo olduğu varsayılıyor.
        table = slide.shapes[0]

        # Tabloyu slayttan kaldır.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Hücrelerini Birleştir**

Bir tablonun yan yana hücrelerini tek bir hücrede birleştirin.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir tablo olduğu varsayılıyor.
        table = slide.shapes[0]

        # Hücreleri birleştir.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```