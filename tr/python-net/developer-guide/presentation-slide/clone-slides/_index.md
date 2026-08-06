---
title: Python'da PowerPoint Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 40
url: /tr/python-net/clone-slides/
keywords:
- slayt klonlama
- slayt kopyalama
- slayt kaydetme
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint slaytlarını hızlı bir şekilde klonlayın veya çoğaltın. Kod örneklerimiz ve ipuçlarımızı izleyerek PPT oluşturmayı saniyeler içinde otomatikleştirin, verimliliği artırın ve manuel işleri ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides ayrıca herhangi bir slaytı kopyalamanıza (klonlamanıza) ve ardından klonlanan slaytı mevcut sunuma veya başka bir açık sunuma eklemenize olanak tanır. Slayt klonlama, geliştiricilerin orijinal slaytı etkilemeden değiştirebileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç yolu vardır:

- Sunumun sonuna klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumun sonuna klonla.
- Başka bir sunumda başka bir konuma klonla.
- Başka bir sunumda belirli bir konuma klonla.

Aspose.Slides for Python via .NET’te, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi tarafından sağlanan [slayt koleksiyonu](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) `add_clone` ve `insert_clone` yöntemlerini kullanarak bu slayt klonlama türlerini gerçekleştirebilir.

## **Kurulum**

```bash
pip install aspose.slides
```

## **Aynı Sunumda Sonuna Klonla**

Aynı sunum içinde bir slaytı klonlamak ve mevcut slaytların sonuna eklemek istiyorsanız `add_clone` yöntemini kullanın. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinden slayt koleksiyonunu alın.
1. Klonlanacak slaytı geçirerek `add_clone` yöntemini [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırın.
1. Değiştirilen sunumu kaydedin.

Aşağıdaki örnekte, ilk slayt (indeks 0) klonlanır ve sunumun sonuna eklenir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil etmek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # İstenilen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın.
    presentation.slides.add_clone(presentation.slides[0])
    # Değiştirilen sunumu diske kaydedin.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aynı Sunumda Belirli Bir Konuma Klonla**

Aynı sunum içinde bir slaytı klonlamak ve farklı bir konuma yerleştirmek istiyorsanız `insert_clone` yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinden slayt koleksiyonunu alın.
1. Klonlanacak slaytı ve yeni konumu belirten hedef indeksi geçirerek `insert_clone` yöntemini [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırın.
1. Değiştirilen sunumu kaydedin.

Aşağıdaki örnekte, indeks 1’deki (konum 2) slayt, aynı sunum içinde indeks 2’ye (konum 3) klonlanır.

```py
import aspose.slides as slides

# Sunum dosyasını temsil etmek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # İstenilen slaytı aynı sunum içinde belirtilen konuma (indeks) klonlayın.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Değiştirilen sunumu diske kaydedin.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunumun Sonuna Klonla**

Bir sunumdan slaytı klonlayıp başka bir sunumun sonuna eklemek istiyorsanız:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunum (slaytın ekleneceği) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunumun slayt koleksiyonunu alın.
1. Kaynak sunumdan slaytı geçerek hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `add_clone` yöntemini çağırın.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumdaki indeks 0’daki slayt, hedef sunumun sonuna klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil etmek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Slaytın klonlanacağı hedef PPTX (hedef sunum) için Presentation sınıfının bir örneğini oluşturun.
    with slides.Presentation() as target_presentation:
        # İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Hedef sunumu diske kaydedin.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunumda Belirli Bir Konuma Klonla**

Bir slaytı bir sunumdan başka bir sunuma belirli bir konuma eklemek istiyorsanız:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunum (slaytın ekleneceği) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunumun slayt koleksiyonunu alın.
1. Kaynak slaytı ve istenen hedef indeksi geçirerek `insert_clone` yöntemini hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırın.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumdaki indeks 0’daki slayt, hedef sunumda indeks 2’ye (konum 3) klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil etmek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Slaytın klonlanacağı hedef PPTX için Presentation sınıfının bir örneğini oluşturun.
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # İlk slaytı kaynaktan alarak hedef sunumda indeks 2'ye bir klon ekleyin.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Hedef sunumu diske kaydedin.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Slaytı Ana Slaytıyla Başka Bir Sunuma Klonla**

Bir slaytı **ana slaytıyla** başka bir sunuma klonlamanız ve orada kullanmanız gerekiyorsa, önce gerekli ana slaytı kaynak sunumdan hedef sunuma klonlayın. Ardından slaytı klonlarken bu hedef ana slaytı kullanın. `add_clone(Slide, MasterSlide)` yöntemi, **kaynak değil** hedef sunumun bir ana slaytını bekler.

Bir slaytı ana slaytıyla klonlamak için şu adımları izleyin:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Hedef sunum için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
1. Klonlanacak kaynak slaytı ve onun ana slaytını erişin.
1. Hedef sunumun ana slayt koleksiyonundan [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) alın.
1. `add_clone` yöntemini hedef [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) üzerinde çağırarak kaynak ana slaytı hedefe klonlayın.
1. Hedef sunumun slayt koleksiyonundan [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) alın.
1. `add_clone` yöntemini hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırarak kaynak slaytı ve klonlanan hedef ana slaytı geçin.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumdaki indeks 0’daki slayt, kaynakta klonlanan ana slaytı kullanarak hedef sunumun sonuna klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil etmek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Slaytın klonlanacağı hedef sunum için Presentation sınıfının bir örneğini oluşturun.
    with slides.Presentation() as target_presentation:
        # Kaynak sunumdan ilk slaytı alın.
        source_slide = source_presentation.slides[0]
        # İlk slayt tarafından kullanılan ana slaytı alın.
        source_master = source_slide.layout_slide.master_slide
        # Ana slaytı hedef sunumun ana slayt koleksiyonuna klonlayın.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Kaynak sunumdan slaytı, klonlanmış ana slaytı kullanarak hedef sunumun sonuna klonlayın.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Hedef sunumu diske kaydedin.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Bir Bölümde Sonuna Klonla**

Aspose.Slides for Python via .NET ile bir sunumun bir bölümünden slaytı klonlayıp aynı sunum içinde başka bir bölüme ekleyebilirsiniz. Bunu yapmak için [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) sınıfının `add_clone(Slide, Section)` yöntemini kullanın.

Aşağıdaki Python örneği, bir slaytı klonlayıp klonu belirli bir bölüme eklemeyi gösterir:

```py
import aspose.slides as slides

# Yeni bir boş sunum oluştur.
with slides.Presentation() as presentation:
    # İlk slayın düzenine dayalı boş bir slayt ekle.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Yeni slayta bir elips şekli ekle; bu slayt daha sonra klonlanacak.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # İlk slayın düzenine dayalı bir başka boş slayt ekle.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # "Section2" adlı bir bölüm oluştur ve slide2'den başlat.
    section = presentation.sections.add_section("Section2", slide2)
    # Önceden oluşturulan slaytı "Section2" bölümüne klonla.
    presentation.slides.add_clone(slide, section)
    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

### Konuşmacı notları ve gözden geçirme yorumları klonlanır mı?

Evet. Not sayfası ve gözden geçirme yorumları klona dahil edilir. Eğer istemiyorsanız, ekledikten sonra [kaldırın](/slides/tr/python-net/presentation-notes/).

### Grafikler ve veri kaynakları nasıl ele alınır?

Grafik nesnesi, biçimlendirmesi ve gömülü verileri kopyalanır. Grafik dış bir kaynağa (ör. OLE gömülü bir çalışma kitabı) bağlıysa, bu bağlantı bir [OLE nesnesi](/slides/tr/python-net/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

### Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüme](/slides/tr/python-net/slide-section/) yerleştirebilirsiniz. Hedef bölüm yoksa, önce oluşturun ve ardından slaytı ona taşıyın.