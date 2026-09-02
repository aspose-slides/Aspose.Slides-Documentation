---
title: Python'da PowerPoint Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 40
url: /tr/python-net/clone-slides/
keywords:
- slaytı klonla
- slaytı kopyala
- slaytı kaydet
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint slaytlarını hızlıca klonlayın veya çoğaltın. Açık kod örneklerimiz ve ipuçlarımızla PPT oluşturmayı saniyeler içinde otomatikleştirin, verimliliği artırın ve manuel işi ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides ayrıca herhangi bir slaytı kopyalamanıza (klonlamanıza) ve ardından klonlanmış slaytı mevcut sunuma veya başka bir açık sunuma eklemenize olanak tanır. Slayt klonlaması, geliştiricilerin orijinal slaytı etkilemeden değiştirebileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın çeşitli yolları vardır:

- Sunumun sonuna klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumun sonuna klonla.
- Başka bir sunumda başka bir konuma klonla.
- Başka bir sunumda belirli bir konuma klonla.

Aspose.Slides for Python via .NET'te, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi tarafından sunulan [slide collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) `add_clone` ve `insert_clone` yöntemlerini bu tür slayt klonlamalarını gerçekleştirmek için sağlar.

## **Kurulum**

```bash
pip install aspose.slides
```

## **Kurulum**

```bash
pip install aspose.slides
```

## **Aynı Sunumda Sonuna Klonla**

Aynı sunum içinde bir slaytı klonlamak ve mevcut slaytların sonuna eklemek istiyorsanız `add_clone` yöntemini kullanın. Aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinden slayt koleksiyonunu alın.  
1. Slaytı klonlamak için `add_clone` yöntemini [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki örnekte, ilk slayt (indeks 0) klonlanır ve sunumun sonuna eklenir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # İstenilen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın.
    presentation.slides.add_clone(presentation.slides[0])
    # Değiştirilmiş sunumu diske kaydedin.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aynı Sunumda Belirli Bir Konuma Klonla**

Aynı sunum içinde bir slaytı klonlamak ve farklı bir konuma yerleştirmek istiyorsanız `insert_clone` yöntemini kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinden slayt koleksiyonunu alın.  
1. `insert_clone` yöntemini [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırın; klonlanacak slaytı ve yeni konumu belirten hedef indeksi geçirin.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki örnekte, indeks 1 (konum 2)deki slayt, aynı sunum içinde indeks 2 (konum 3)e klonlanır.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # İstenilen slaytı aynı sunum içinde belirtilen konuma (indekse) klonlayın.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Değiştirilmiş sunumu diske kaydedin.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunumun Sonuna Klonla**

Bir slaytı bir sunumdan alıp başka bir sunumun sonuna eklemeniz gerektiğinde:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.  
1. Hedef sunum (slaytın ekleneceği) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.  
1. Hedef sunumun slayt koleksiyonunu alın.  
1. Hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `add_clone` yöntemini çağırarak kaynak sunumdan slaytı geçirin.  
1. Değiştirilmiş hedef sunumu kaydedin.  

Aşağıdaki örnekte, kaynak sunumda indeks 0’daki slayt, hedef sunumun sonuna klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Kaydırının klonlanacağı hedef PPTX için Presentation sınıfını örnekleyin.
    with slides.Presentation() as target_presentation:
        # İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Hedef sunumu diske kaydedin.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Başka Bir Sunumda Belirli Bir Konuma Klonla**

Bir slaytı bir sunumdan alıp başka bir sunuma belirli bir konuma eklemeniz gerektiğinde:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.  
1. Hedef sunum (slaytın ekleneceği) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.  
1. Hedef sunumun slayt koleksiyonunu alın.  
1. Hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde `insert_clone` yöntemini çağırarak kaynak slaytı ve istenen hedef indeksi geçirin.  
1. Değiştirilmiş hedef sunumu kaydedin.  

Aşağıdaki örnekte, kaynak sunumda indeks 0’daki slayt, hedef sunumda indeks 2’ye (konum 3) klonlanır.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Kaydırının klonlanacağı hedef PPTX için Presentation sınıfını örnekleyin.
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Kaynak sunumdan ilk slaytı hedef sunumda indeks 2'ye ekleyerek klonlayın.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Hedef sunumu diske kaydedin.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Slaytı Ana Slaytıyla Başka Bir Sunuma Klonla**

Bir slaytı **ana slaytıyla** bir sunumlardan alıp başka bir sunumda kullanmanız gerektiğinde, önce gerekli ana slaytı kaynak sunumdan hedef sunuma klonlayın. Ardından slaytı klonlarken bu hedef ana slaytı kullanın. `add_clone(Slide, MasterSlide)` yöntemi **hedef sunumdan** bir ana slayt bekler, kaynaktan değil.

Bu işlemi gerçekleştirmek için şu adımları izleyin:

1. Kaynak sunum (klonlanacak slaytı içeren) için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.  
1. Hedef sunum için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.  
1. Klonlanacak kaynak slaytı ve onun ana slaytını alın.  
1. Hedef sunumun ana koleksiyonundan [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) elde edin.  
1. `add_clone` yöntemini hedef [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) üzerinde çağırarak kaynak ana slaytı hedefe klonlayın.  
1. Hedef sunumun [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) alın.  
1. `add_clone` yöntemini hedef [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinde çağırarak kaynak slaytı ve klonlanmış hedef ana slaytı geçirin.  
1. Değiştirilmiş hedef sunumu kaydedin.  

Aşağıdaki örnekte, kaynak sunumda indeks 0’daki slayt, kaynakta klonlanan ana slaytı kullanarak hedef sunumun sonuna eklenir.

```py
import aspose.slides as slides

# Kaynak sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Slaytın klonlanacağı hedef sunum için Presentation sınıfının bir örneğini oluşturun.
    with slides.Presentation() as target_presentation:
        # Kaynak sunumdan ilk slaytı alın.
        source_slide = source_presentation.slides[0]
        # İlk slaytın kullandığı ana slaytı alın.
        source_master = source_slide.layout_slide.master_slide
        # Ana slaytı hedef sunumun ana koleksiyonuna klonlayın.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klonlanmış ana slaytı kullanarak slaytı kaynak sunumdan hedef sunumun sonuna klonlayın.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Hedef sunumu diske kaydedin.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Bir Bölümde Sonuna Klonla**

Aspose.Slides for Python via .NET ile bir sunumun bir bölümünden slaytı klonlayıp aynı sunum içinde başka bir bölüme ekleyebilirsiniz. Bunun için [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) sınıfının `add_clone(Slide, Section)` yöntemini kullanın.

Aşağıdaki Python örneği, bir slaytı klonlayıp klonu belirtilen bölüme eklemeyi gösterir:

```py
import aspose.slides as slides

# Yeni boş bir sunum oluştur.
with slides.Presentation() as presentation:
    # İlk slaytın düzenine göre boş bir slayt ekle.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Yeni slayta bir elips şekli ekle; bu slayt daha sonra klonlanacak.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # İlk slaytın düzenine göre bir başka boş slayt ekle.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # slide2'de başlayan "Section2" adlı bir bölüm oluştur.
    section = presentation.sections.add_section("Section2", slide2)
    # Daha önce oluşturulan slaytı "Section2" bölümüne klonla.
    presentation.slides.add_clone(slide, section)
    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Uyumlu Slayt Boyutunu Sağlayın**

Slaytları başka bir sunuma klonlarken, hedef sunumun slayt boyutunun kaynakla aynı olduğundan emin olun. Boyutlar farklıysa, Aspose.Slides klonlanan şekilleri otomatik olarak yeniden ölçeklendirmez; orijinal koordinat ve boyutları korunur; bu da içeriğin kaydırılmış veya slayt sınırlarının dışına çıkmış gibi görünmesine neden olabilir.

Klonlamadan önce hedef sunumun slayt boyutunu kaynakla eşleştirmek için şu kodu kullanabilirsiniz:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Bunu ana slaytı ve slaytı klonlamadan önce yapın.

## **SSS**

**Sunucu notları ve inceleme yorumları klonlanır mı?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. Eğer istemiyorsanız, ekledikten sonra [remove them](/slides/tr/python-net/presentation-notes/) adresini kullanarak kaldırabilirsiniz.

### Grafikler ve veri kaynakları nasıl ele alınır?

Grafik nesnesi, biçimlendirme ve gömülü veri kopyalanır. Grafik harici bir kaynağa (ör. OLE‑gömülü bir çalışma kitabı) bağlanmışsa, bu bağlantı bir [OLE object](/slides/tr/python-net/manage-ole/) olarak korunur. Dosyalar arasında taşıdıktan sonra veri erişilebilirliğini ve yenileme davranışını kontrol edin.

### Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [section](/slides/tr/python-net/slide-section/) içine yerleştirebilirsiniz. Hedef bölüm yoksa, önce bölümü oluşturup ardından slaytı ona taşıyın.
