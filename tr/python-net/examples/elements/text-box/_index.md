---
title: Metin Kutusu
type: docs
weight: 40
url: /tr/python-net/examples/elements/text-box/
keywords:
- metin kutusu
- metin kutusu ekle
- metin kutusuna eriş
- metin kutusunu kaldır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ile Aspose.Slides kullanarak metin kutuları oluşturun ve biçimlendirin: yazı tiplerini, hizalamayı, kaydırmayı, otomatik sığdırmayı ayarlayın ve PowerPoint ile OpenDocument için slaytları düzenlemek üzere bağlantılar ekleyin."
---
Aspose.Slides içinde, bir **metin kutusu** `AutoShape` ile temsil edilir. Neredeyse her şekil metin içerebilir, ancak tipik bir metin kutusunda dolgu veya kenarlık yoktur ve yalnızca metin gösterilir.

Bu kılavuz, programlı olarak metin kutularını nasıl ekleyeceğinizi, erişeceğinizi ve kaldıracağınızı açıklar.

## **Metin Kutusu Ekle**

Bir metin kutusu, dolgu ya da kenarlık olmayan ve bazı biçimlendirilmiş metin içeren bir `AutoShape`'dır. İşte bir tane nasıl oluşturulur:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Bir dikdörtgen şekil oluştur (varsayılan olarak kenarlıklı ve doldurulmuş, metin yok).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Dolgu ve kenarlığı kaldırarak tipik bir metin kutusu görünümü ver.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Metin biçimlendirmesini ayarla.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Gerçek metin içeriğini ata.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Not:** Boş olmayan bir `TextFrame` içeren herhangi bir `AutoShape`, metin kutusu olarak işlev görebilir.

## **İçeriğe Göre Metin Kutularına Erişim**

Belirli bir anahtar kelimeyi (ör. "Slide") içeren tüm metin kutularını bulmak için şekillerde döngü yapın ve metinlerini kontrol edin:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Yalnızca AutoShape'ler düzenlenebilir metin içerebilir.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Eşleşen metin kutusuyla bir şey yap.
                    pass
```

## **İçeriğe Göre Metin Kutularını Kaldırma**

Bu örnek, belirli bir anahtar kelimeyi içeren ilk slayttaki tüm metin kutularını bulur ve siler:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # "Slide" kelimesini içeren ve kaldırılacak AutoShape şekilleri bul.
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Eşleşen her şekli slayttan kaldır.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **İpucu:** Döngü sırasında koleksiyonu değiştirmeden önce şekil koleksiyonunun bir kopyasını oluşturun; böylece koleksiyon değişikliği hatalarından kaçınabilirsiniz.