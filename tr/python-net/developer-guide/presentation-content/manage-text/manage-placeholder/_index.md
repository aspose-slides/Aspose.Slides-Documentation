---
title: Python ile Sunumlarda Yer Tutucuları Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/python-net/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- istem metni
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ile .NET üzerinden yer tutucuları zahmetsizce yönetin: metni değiştirin, istemleri özelleştirin ve PowerPoint ve OpenDocument'te resim şeffaflığını ayarlayın."
---
## **Overview**

Aspose.Slides, sunum yer tutucularını programlı olarak yönetmenizi sağlar. Bu makale, slaytlardaki yer tutucuları bulmayı ve metinlerini değiştirmeyi, yer tutucu düzenleri için özel istem metni ayarlamayı ve bir yer tutucu arka planı olarak kullanılan resmin şeffaflığını ayarlamayı açıklar. Ayrıca, temel yer tutucular ile yerel şekiller arasındaki farkı açıklayan kısa bir SSS, yer tutucu değişikliklerinin düzenler veya ana şablonlar aracılığıyla nasıl uygulanabileceğini ve başlık ve alt bilgi yer tutucu yönetimine dair yönlendirmeler içerir.

## **Change Text in Placeholders**

Aspose.Slides for Python kullanarak bir sunumdaki slaytlarda yer tutucuları bulabilir ve değiştirebilirsiniz. Aspose.Slides, bir yer tutucudaki metni değiştirmenize olanak tanır.

**Ön Koşul:** Yer tutucu içeren bir sunuma ihtiyacınız var. Bu tür bir sunumu Microsoft PowerPoint'te oluşturabilirsiniz.

Bu, bir yer tutucunun metnini değiştirmek için Aspose.Slides kullanımını gösterir:

1. Sunumu bir argüman olarak vererek [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksiyle slayta bir referans alın.
3. Yer tutucuyu bulmak için şekiller arasında döngü yapın.
4. Metni, [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ile ilişkili [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) kullanarak değiştirin.
5. Değiştirilmiş sunumu kaydedin.

Bu Python kodu, bir yer tutucunun metninin nasıl değiştirileceğini gösterir:

```python
import aspose.slides as slides

# Presentation sınıfını örnekleyin.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Yer tutucuları bulmak için şekillerde döngü yapın.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Her yer tutucudaki metni değiştirin.
            shape.text_frame.text = "This is Placeholder"

    # Sunumu diske kaydedin.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Prompt Text for a Placeholder**

Standart ve önceden oluşturulmuş düzenler, **Click to add a title** veya **Click to add a subtitle** gibi yer tutucu istem metinleri içerir. Aspose.Slides ile bu istemleri yer tutucu düzenlerinde kendi metninizle değiştirebilirsiniz.

Aşağıdaki Python örneği, bir yer tutucu için istem metninin nasıl ayarlanacağını gösterir:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Şekillerde dolaşarak yer tutucuları bulun.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Image Transparency in a Placeholder**

Aspose.Slides, bir metin yer tutucusundaki arka plan resminin şeffaflığını ayarlamanıza olanak tanır. Bu çerçevedeki resmin şeffaflığını ayarlayarak, renklerine bağlı olarak metni ya da resmi öne çıkarabilirsiniz.

Aşağıdaki Python örneği, bir şekil içindeki resim arka planının şeffaflığının nasıl ayarlanacağını gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**Temel yer tutucu nedir ve slayttaki yerel şekilden nasıl farklıdır?**

Bir temel yer tutucu, slaytın şeklinin kalıtım aldığı düzen veya ana şablondaki orijinal şekildir— tip, konum ve bazı biçimlendirmeler ondan gelir. Yerel bir şekil bağımsızdır; temel yer tutucu yoksa kalıtım uygulanmaz.

**Sunumdaki tüm başlıkları veya altyazıları, her slaytı tek tek dolaşmadan nasıl güncelleyebilirim?**

İlgili yer tutucuyu düzenlemede veya ana şablonda değiştirin. Bu düzen/ana şablondan türetilen slaytlar değişikliği otomatik olarak miras alır.

**Standart başlık/alt bilgi yer tutucularını—tarih & saat, slayt numarası ve alt bilgi metni—nasıl kontrol edebilirim?**

Uygun kapsamda (normal slaytlar, düzenler, ana şablon, notlar/el ilanları) HeaderFooter yöneticilerini kullanarak bu yer tutucuları açıp kapatabilir ve içeriklerini ayarlayabilirsiniz.