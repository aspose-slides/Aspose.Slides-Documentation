---
title: Python ile Sunumlara Slayt Ekleme
linktitle: Slayt Ekle
type: docs
weight: 10
url: /tr/python-net/add-slide-to-presentation/
keywords:
- slayt ekle
- slayt oluştur
- boş slayt
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarınıza kolayca slayt ekleyin—saniyeler içinde sorunsuz ve verimli slayt ekleme."
---
## **Genel Bakış**

Bir sunuma slayt eklemeden önce, PowerPoint'in slaytları nasıl düzenlediğini anlamak faydalıdır. Her sunum bir ana slayt, isteğe bağlı düzen slaytları ve bir veya daha fazla normal slayt içerir. Her slayt eşsiz bir kimliğe sahiptir ve normal slaytlar sıfır tabanlı bir indeksle sıralanır. Bu makale, Aspose.Slides for Python kullanarak slaytların nasıl oluşturulacağını ve uygun düzenlerin nasıl seçileceğini gösterir.

## **Sunumalara Slayt Ekleme**

Aspose.Slides, mevcut düzen slaytlarını temel alarak yeni slaytlar eklemenizi sağlar. Aşağıdaki örnek, sunumdaki her düzeni döngüye alır, o düzeni kullanan bir slayt ekler ve ardından dosyayı kaydeder.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) öğesine erişin.
1. `presentation.layout_slides` içindeki her öğe için, o düzeni kullanan bir slayt eklemek üzere `add_empty_slide` metodunu çağırın.
1. İsteğe bağlı olarak yeni eklenen slaytları değiştirin.
1. Sunumu bir PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    # Slayt koleksiyonuna eriş.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Boş bir slaytı slayt koleksiyonuna ekle.
        slides.add_empty_slide(layout_slide)

    # Yeni eklenen slaytlar üzerinde bazı işlemler yap.

    # Sunumu diske kaydet.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Belirli bir konuma yeni bir slayt ekleyebilir miyim, sadece sona değil?**

Evet. Kütüphane slayt koleksiyonlarını ve [insert](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/insert_clone/) işlemlerini destekler, bu sayede sadece sonuna eklemek yerine istenen indeksde bir slayt ekleyebilirsiniz.

**Bir düzene dayalı slayt eklerken tema/stiller korunur mu?**

Evet. Bir düzen, ana slaytından biçimlendirmeyi devralır ve yeni slayt, seçilen düzenten ve ona bağlı ana slayttan devralır.

**Slayt eklemeden önce yeni bir “boş” sunumda hangi slayt bulunur?**

Yeni oluşturulan bir sunum zaten sıfır indeksli bir boş slayt içerir. Bu, ekleme indekslerini hesaplarken göz önünde bulundurulması önemlidir.

**Ana slaytta çok sayıda seçenek varsa, yeni bir slayt için “doğru” düzeni nasıl seçerim?**

Genellikle gereken yapıya uyan bir [LayoutSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/) seçilir ([Başlık ve İçerik, İki İçerik, vb.](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidelayouttype/)). Böyle bir düzen bulunmuyorsa, onu [mastera ekleyebilirsiniz](/slides/tr/python-net/slide-layout/) ve ardından kullanabilirsiniz.