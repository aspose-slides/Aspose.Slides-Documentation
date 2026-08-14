---
title: Python'da PowerPoint Slaytlarını Klonla
linktitle: Klon Slaytları
type: docs
weight: 40
url: /tr/python-net/clone-slides/
keywords:
- slayt klonla
- slayt kopyala
- slayt kaydet
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint slaytlarını hızlıca klonlayın veya çoğaltın. Açık kod örneklerimiz ve ipuçlarımızı takip ederek PPT oluşturmayı saniyeler içinde otomatikleştirin, verimliliği artırın ve manuel işi ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides ayrıca herhangi bir slaytı kopyalamanıza (klonlamanıza) ve ardından klonlanan slaytı mevcut sunuma veya başka bir açık sunuma eklemenize izin verir. Slayt klonlama, geliştiricilerin orijinal slaytı etkilemeden değiştirebileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç yolu vardır:

- Sunumun sonunda klonla.
- Sunum içinde başka bir konumda klonla.
- Başka bir sunumun sonunda klonla.
- Başka bir sunumda başka bir konumda klonla.
- Başka bir sunumda belirli bir konumda klonla.

Aspose.Slides for Python via .NET'de, [slide collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) nesnesi tarafından [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi sunulan `add_clone` ve `insert_clone` yöntemlerini bu tür slayt klonlamalarını gerçekleştirmek için sağlar.

## **Kurulum**

```bash
pip install aspose.slides
```

## **Aynı Sunumda Sonuna Kopyala**

Eğer aynı sunum içinde bir slaytı klonlayıp mevcut slaytların sonuna eklemek istiyorsanız, `add_clone` yöntemini kullanın. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinden slide collection'ı alın.
1. [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `add_clone` yöntemini çağırın ve klonlanacak slaytı parametre olarak geçin.
1. Değiştirilen sunumu kaydedin.

Aşağıdaki örnekte, ilk slayt (indeks 0) klonlanıp sunumun sonuna eklenir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil etmek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Aynı sunumdaki slayt koleksiyonunun sonuna istenen slaytı klonlayın.
    presentation.slides.add_clone(presentation.slides[0])
    # Değiştirilen sunumu diske kaydedin.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aynı Sunumda Belirli Bir Konuma Kopyala**

Eğer aynı sunum içinde bir slaytı klonlayıp farklı bir konuma yerleştirmek istiyorsanız, `insert_clone` yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinden slide collection'ı alın.
1. [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `insert_clone` yöntemini çağırın, klonlanacak slaytı ve yeni konumu belirten hedef indeksi parametre olarak geçin.
1. Değiştirilen sunumu kaydedin.

Aşağıdaki örnekte, indeks 1'deki slayt (konum 2) aynı sunum içinde indeks 2'ye (konum 3) klonlanır.

```py
import aspose.slides as slides

# Sunum dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Aynı sunum içinde istenen slaytı belirtilen konuma (indeks) klonlayın.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Değiştirilen sunumu diske kaydedin.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunumun Sonuna Kopyala**

Bir sunumdan bir slaytı klonlayıp başka bir sunumun sonuna eklemeniz gerektiğinde:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunum (slaytın ekleneceği) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunumdan slide collection'ı alın.
1. Hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `add_clone` metodunu çağırın ve kaynak sunumdaki slaytı parametre olarak geçin.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumdaki indeks 0'deki slayt, hedef sunumun sonuna klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil etmek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Kaydırılacak slaytın ekleneceği hedef PPTX için Presentation sınıfının bir örneğini oluşturun.
    with slides.Presentation() as target_presentation:
        # Kaynak sunumdan istenen slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonlayın.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Hedef sunumu diske kaydedin.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunumda Belirli Bir Konuma Kopyala**

Bir sunumdan bir slaytı klonlayıp başka bir sunuma belirli bir konumda eklemeniz gerektiğinde:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunum (slaytın ekleneceği) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunumdan slide collection'ı alın.
1. Hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `insert_clone` metodunu çağırın, kaynak sunumdaki slaytı ve istenen hedef indeksi parametre olarak geçin.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumdaki indeks 0'deki slayt, hedef sunumda indeks 2'ye (konum 3) klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil etmek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Slaytın klonlanacağı hedef PPTX için Presentation sınıfının bir örneğini oluşturun.
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # İlk slaytın bir klonunu kaynak sunumdan hedef sunumda indeks 2'ye ekleyin.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Hedef sunumu diske kaydedin.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunuma Ana Slaytıyla Bir Slaytı Kopyala**

Eğer bir sunumdan **ana slaytıyla birlikte** bir slaytı klonlayıp diğerinde kullanmanız gerekiyorsa, önce gerekli ana slaytı kaynak sunumdan hedef sunuma klonlayın. Ardından slaytı klonlarken bu hedef ana slaytı kullanın. `add_clone(Slide, MasterSlide)` yöntemi **kaynak değil, hedef sunumdan bir ana slayt** bekler.

1. Kaynak sunum için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunum için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Klonlanacak kaynak slaytı ve onun ana slaytını alın.
1. Hedef sunumun master collection'ından [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) alın.
1. Hedef [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) üzerinde `add_clone` metodunu çağırın, kaynak ana slaytı geçirerek hedefe klonlayın.
1. Hedef sunumun slide collection'ından [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) alın.
1. Hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `add_clone` metodunu çağırın, kaynak slaytı ve klonlanmış hedef ana slaytı parametre olarak geçin.
1. Değiştirilen hedef sunumu kaydedin.

Aşağıdaki örnekte, kaynak sunumdaki indeks 0'deki slayt, kaynakta klonlanan ana slaytı kullanarak hedef sunumun sonuna klonlanır.

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
        # Ana slaytı hedef sunumun master koleksiyonuna klonlayın.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Kaynak sunumdaki slaytı, klonlanmış masterı kullanarak hedef sunumun sonuna klonlayın.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Hedef sunumu diske kaydedin.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Bir Bölümde Sonuna Kopyala**

Aspose.Slides for Python via .NET ile bir sunumun bir bölümünden bir slaytı klonlayıp aynı sunum içinde başka bir bölüme ekleyebilirsiniz. Bunu yapmak için [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) sınıfının `add_clone(Slide, Section)` yöntemini kullanın.

Aşağıdaki Python örneği, bir slaytı nasıl klonlayıp belirli bir bölüme ekleyeceğinizi gösterir:

```py
import aspose.slides as slides

# Yeni boş bir sunum oluşturun.
with slides.Presentation() as presentation:
    # İlk slaytın düzenine dayalı boş bir slayt ekleyin.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Yeni slayta bir elips şekli ekleyin; bu slayt daha sonra klonlanacak.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # İlk slaytın düzenine dayalı bir başka boş slayt ekleyin.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # slide2'de başlayan "Section2" adlı bir bölüm oluşturun.
    section = presentation.sections.add_section("Section2", slide2)
    # Daha önce oluşturulan slaytı "Section2" bölümüne klonlayın.
    presentation.slides.add_clone(slide, section)
    # Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Uyumlu Slayt Boyutunu Sağlayın**

Slaytları başka bir sunuma klonlarken, hedef sunumun slayt boyutunun kaynakla aynı olduğundan emin olun. Slayt boyutları farklıysa, Aspose.Slides klonlanan şekilleri otomatik olarak yeniden ölçeklendirmez—orijinal koordinat ve boyutları korunur, bu da içeriğin kaymış görünmesine veya slayt sınırlarının dışına taşmasına neden olabilir.

Master ve slaytı klonlamadan önce, hedef sunumun slayt boyutunu kaynağa eşitleyebilirsiniz:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Bunu master ve slaytı klonlamadan önce yapın.

## **SSS**

### Konuşmacı notları ve gözden geçirme yorumları klonlanır mı?

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. Eğer istemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/python-net/presentation-notes/).

### Grafikler ve veri kaynakları nasıl ele alınır?

Grafik nesnesi, biçimlendirme ve gömülü veri kopyalanır. Grafik harici bir kaynağa (ör. OLE gömülü bir çalışma kitabı) bağlıysa, bu bağlantı bir [OLE nesnesi](/slides/tr/python-net/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

### Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüme](/slides/tr/python-net/slide-section/) yerleştirebilirsiniz. Hedef bölüm yoksa, önce oluşturun ve ardından slaytı ona taşıyın.