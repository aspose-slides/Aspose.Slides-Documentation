---
title: Python'da PowerPoint Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 40
url: /tr/python-net/clone-slides/
keywords:
- slayt klonlama
- slaytı kopyala
- slaytı kaydet
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint slaytlarını hızlı bir şekilde klonlayın veya çoğaltın. PPT oluşturmayı saniyeler içinde otomatikleştirmek, verimliliği artırmak ve manuel çalışmayı ortadan kaldırmak için net kod örneklerimizi ve ipuçlarımızı izleyin."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides ayrıca herhangi bir slaytı kopyalamanıza (klonlamanıza) ve ardından kopyalanan slaytı geçerli sunuma veya başka bir açık sunuma eklemenize olanak tanır. Slayt klonlama, geliştiricilerin orijinal slaytı etkilemeden değiştirebileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç yolu vardır:

- Sunumun sonuna klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumun sonuna klonla.
- Başka bir sunumda başka bir konuma klonla.
- Başka bir sunumda belirli bir konuma klonla.

Aspose.Slides for Python via .NET’te, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi tarafından sağlanan [slayt koleksiyonu](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) `add_clone` ve `insert_clone` yöntemlerini kullanarak bu slayt klonlama türlerini gerçekleştirebilir.

## **Aynı Sunumda Sonuna Klonla**

Aynı sunum içinde bir slaytı klonlamak ve mevcut slaytların sonuna eklemek istiyorsanız `add_clone` yöntemini kullanın. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinden slayt koleksiyonunu alın.
1. Klonlanacak slaytı parametre olarak vererek `add_clone` yöntemini [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırın.
1. Değiştirilen sunumu kaydedin.

Aşağıdaki örnekte, ilk slayt (indeks 0) klonlanıp sunumun sonuna eklenir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın.
    presentation.slides.add_clone(presentation.slides[0])
    # Değiştirilen sunumu diske kaydedin.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aynı Sunumda Belirli Bir Konuma Klonla**

Aynı sunum içinde bir slaytı klonlamak ve farklı bir konuma yerleştirmek istiyorsanız `insert_clone` yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinden slayt koleksiyonunu alın.
1. Klonlanacak slaytı ve yeni konumu (hedef indeks) parametre olarak vererek `insert_clone` yöntemini [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırın.
1. Değiştirilen sunumu kaydedin.

Aşağıdaki örnekte, indeks 0’daki slayt (konum 1) aynı sunum içinde indeks 1’e (konum 2) klonlanır.

```py
import aspose.slides as slides

# Sunum dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # İstenen slaytı aynı sunum içinde belirtilen konuma (indeks) klonlayın.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Değiştirilen sunumu diske kaydedin.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunumun Sonuna Klonla**

Bir sunumdan bir slaytı alıp başka bir sunumun sonuna eklemek istiyorsanız:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunum (slaytın ekleneceği) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunumun slayt koleksiyonunu alın.
1. Kaynak sunumdan slaytı parametre olarak vererek hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `add_clone` yöntemini çağırın.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumun indeks 0’daki slaytı hedef sunumun sonuna klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin.
    with slides.Presentation() as target_presentation:
        # İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Hedef sunumu diske kaydedin.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunumda Belirli Bir Konuma Klonla**

Bir slaytı bir sunumdan alıp başka bir sunumda belirli bir konuma eklemek istiyorsanız:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunum (slaytın ekleneceği) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunumun slayt koleksiyonunu alın.
1. Kaynak sunumdan slaytı ve hedef indeksi parametre olarak vererek hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `insert_clone` yöntemini çağırın.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumun indeks 0’daki slaytı hedef sunumda indeks 1’e (konum 2) klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Slaytın klonlanacağı hedef PPTX için Presentation sınıfını örnekleyin.
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # İlk slaytı kaynaktan hedef sunumda indeks 2'ye bir klon olarak ekleyin.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Hedef sunumu diske kaydedin.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Slaytı Master Slaytıyla Birlikte Başka Bir Sunuma Klonla**

Bir slaytı **master’ı ile birlikte** bir sunumdan alıp başka bir sunuda kullanmanız gerekiyorsa, önce gerekli master slaytını kaynak sunumdan hedef sunuma klonlayın. Ardından slaytı klonlarken bu hedef master’ı kullanın. `add_clone(Slide, MasterSlide)` yöntemi **kaynak sunumdan değil, hedef sunumdan bir master slaytı** bekler.

Bir slaytı master’ı ile birlikte klonlamak için şu adımları izleyin:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunum için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Klonlanacak kaynak slaytı ve onun master slaytını alın.
1. Hedef sunumun master koleksiyonundan [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/)’ı alın.
1. Kaynak master slaytı parametre olarak vererek hedef [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) üzerinde `add_clone` yöntemini çağırın.
1. Hedef sunumun slayt koleksiyonundan [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/)’ı alın.
1. Kaynak slaytı ve yeni oluşturulan hedef master’ı parametre olarak vererek hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `add_clone` yöntemini çağırın.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumun indeks 0’daki slayt, kaynak master’dan klonlanan master kullanılarak hedef sunumun sonuna eklenir.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Slaytın klonlanacağı hedef sunum için Presentation sınıfını örnekleyin.
    with slides.Presentation() as target_presentation:
        # Kaynak sunumdan ilk slaytı alın.
        source_slide = source_presentation.slides[0]
        # İlk slaytın kullandığı master slaytı alın.
        source_master = source_slide.layout_slide.master_slide
        # Master slaytı hedef sunumun master koleksiyonuna klonlayın.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Kaynak sunumdan slaytı klonlanmış master'ı kullanarak hedef sunumun sonuna klonlayın.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Hedef sunumu diske kaydedin.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Bir Bölümde Sonuna Klonla**

Aspose.Slides for Python via .NET ile bir sunumun bir bölümünden slaytı klonlayıp aynı sunum içinde başka bir bölüme ekleyebilirsiniz. Bunu yapmak için [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) sınıfının `add_clone(Slide, Section)` yöntemini kullanın.

Aşağıdaki Python örneği, bir slaytı klonlayıp klonu belirli bir bölüme eklemeyi gösterir:

```py
import aspose.slides as slides

# Yeni boş bir sunum oluşturun.
with slides.Presentation() as presentation:
    # İlk slaytın yerleşimine dayalı boş bir slayt ekleyin.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Yeni slayta bir elips şekli ekleyin; bu slayt daha sonra klonlanacak.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # İlk slaytın yerleşimine dayalı bir başka boş slayt ekleyin.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # slide2'de başlayan "Section2" adlı bir bölüm oluşturun.
    section = presentation.sections.add_section("Section2", slide2)
    # Daha önce oluşturulan slaytı "Section2" bölümüne klonlayın.
    presentation.slides.add_clone(slide, section)
    # Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Konuşmacı notları ve gözden geçirme yorumları klonlanıyor mu?**

Evet. Not sayfası ve gözden geçirme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/python-net/presentation-notes/).

**Grafikler ve veri kaynakları nasıl işlenir?**

Grafik nesnesi, biçimlendirme ve gömülü veri kopyalanır. Grafik dış bir kaynağa (ör. OLE ile gömülü bir çalışma kitabı) bağlıysa, bu bağlantı bir [OLE nesnesi](/slides/tr/python-net/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri bulunabilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüme](/slides/tr/python-net/slide-section/) taşıyabilirsiniz. Hedef bölüm yoksa, önce bölümü oluşturup ardından slaytı ona taşıyın.