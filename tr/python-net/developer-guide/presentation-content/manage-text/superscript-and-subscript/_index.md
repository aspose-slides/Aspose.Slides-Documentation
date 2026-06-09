---
title: Python'da Üst Simge ve Alt Simge Yönetimi
linktitle: Üst Simge ve Alt Simge
type: docs
weight: 80
url: /tr/python-net/superscript-and-subscript/
keywords:
- üst simge
- alt simge
- üst simge ekle
- alt simge ekle
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile üst simge ve alt simgeyi ustalaştırın ve sunumlarınızı profesyonel metin biçimlendirmesi ile en yüksek etki için yükseltin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarınıza üst simge ve alt simge metni eklemek için özellikler sunar. Kimyasal formülleri, matematiksel denklemleri vurgulamanız veya içeriği dipnotlarla açıklamanız gerektiğinde, bu özel biçimlendirme seçenekleri netlik ve kesinlik sağlar. Bu makalede, üst simge ve alt simge stillerini sorunsuz bir şekilde nasıl uygulayacağınızı ve her slaytta profesyonel sonuçlar elde edeceğinizi öğreneceksiniz.

## **Üst Simge ve Alt Simge Metni Ekleme**

Herhangi bir paragraf bölümüne üst simge ve alt simge metni ekleyebilirsiniz. Aspose.Slides'te bu işlemi kontrol etmek için [PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) sınıfının `escapement` özelliğini kullanın.

`escapement` **-%100 ile %100** arasında bir yüzdelik değerdir:

- **> 0** → üst simge (örnek: %25 = hafif yükselme; %100 = tam üst simge)
- **0** → temel çizgi (üst/alt simge yok)
- **< 0** → alt simge (örnek: -%25 = hafif alçalma; -%100 = tam alt simge)

Adımlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) oluşturun ve bir slayt alın.
1. Bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin ve onun [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesine erişin.
1. Mevcut paragrafları temizleyin.
1. Üst simge için: bir paragraf ve bir bölüm oluşturun, `portion.portion_format.escapement` değerini **0 ile 100** arasında bir değere ayarlayın, metni belirleyin ve bölümü ekleyin.
1. Alt simge için: başka bir paragraf ve bölüm oluşturun, `escapement` değerini **-100 ile 0** arasında bir değere ayarlayın, metni belirleyin ve bölümü ekleyin.
1. Sunumu PPTX olarak kaydedin.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Bir slayt al.
    slide = presentation.slides[0]

    # Bir metin kutusu oluştur.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Üst simge metni için bir paragraf oluştur.
    superscript_paragraph = slides.Paragraph()

    # Normal metin içeren bir metin bölümü oluştur.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Üst simge metni içeren bir metin bölümü oluştur.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Alt simge metni için bir paragraf oluştur.
    subscript_paragraph = slides.Paragraph()

    # Normal metin içeren bir metin bölümü oluştur.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Alt simge metni içeren bir metin bölümü oluştur.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Paragrafları metin kutusuna ekle.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Tablolar ve diğer kapsayıcılarda, sadece normal metin kutularında değil, üst/alt simge uygulayabilir miyim?**

Evet. Bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) (tablo hücreleri dahil) sunan herhangi bir nesne içinde metni üst simge veya alt simge olarak biçimlendirebilirsiniz. Biçimlendirme, o çerçevedeki metin bölümlerine uygulanır.

**Üst/alt simgeler PDF, HTML veya görüntülere dışa aktarılırken korunur mu?**

Evet. Aspose.Slides, üst/alt simge biçimlendirmesini yaygın formatlara dışa aktarırken (örneğin [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/), ve [rastr görüntüler](/slides/tr/python-net/convert-powerpoint-to-png/)) korur; çünkü işleme hattı bölüm‑seviyesindeki metin biçimlendirmesine saygı gösterir.

**Aynı metin parçasında üst/alt simgeyi hiperlinklerle birleştirebilir miyim?**

Evet. [Hyperlinks](/slides/tr/python-net/manage-hyperlinks/) bölüm (parça) seviyesinde atanır, bu nedenle bir bölüm aynı anda hem bir hiperlinke sahip olabilir hem de üst simge veya alt simge olarak biçimlendirilmiş olabilir.