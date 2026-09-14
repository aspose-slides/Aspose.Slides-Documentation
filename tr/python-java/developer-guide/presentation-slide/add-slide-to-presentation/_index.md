---
title: Python'da Sunumlara Slayt Ekleme
linktitle: Slayt Ekle
type: docs
weight: 10
url: /tr/python-java/add-slide-to-presentation/
keywords:
- slayt ekle
- slayt oluştur
- boş slayt
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarınıza Aspose.Slides for Python via Java kullanarak kolayca slayt ekleyin—saniyeler içinde sorunsuz ve verimli slayt ekleme."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarına programlı olarak slayt eklemenizi sağlar. Bir sunum, master/düzen slaytları ve normal slaytlar içerir ve normal slaytlar sıfır tabanlı bir indeksle düzenlenir. Her slayt benzersiz bir kimliğe sahiptir ve slaytı olmayan sunum dosyaları desteklenmez.

Bu makale, bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturmayı, slayt koleksiyonuna erişmeyi, boş bir slayt eklemeyi, yeni eklenen slayt ile çalışmayı ve güncellenmiş sunumu kaydetmeyi açıklar. Ayrıca belirli bir konuma slayt ekleme, düzenleri kullanma ve yeni oluşturulan bir sunumda bulunan boş slaytı anlama gibi ilgili konuları da kapsar.

## **Sunuma Slayt Ekleme**

Sunum dosyalarına slayt ekleme konusuna geçmeden önce, slaytlar hakkında bazı gerçekleri gözden geçirelim. Her PowerPoint sunum dosyası **master/düzen** slaytları ve **normal** slaytlar içerir. Bir sunum dosyasında en az bir slayt bulunur. Slaytı olmayan sunum dosyaları, Aspose.Slides for Python via Java tarafından desteklenmez. Her slayt benzersiz bir kimliğe sahiptir ve tüm normal slaytlar sıfır tabanlı bir indeksle belirtilen bir sırada düzenlenir.

Aspose.Slides for Python via Java, geliştiricilerin sunumlarına boş slayt eklemelerine olanak tanır. Bir sunuma boş slayt eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi tarafından sağlanan [getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) yöntemini kullanarak [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesine bir referans alın.
- [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesi tarafından sağlanan [addEmptySlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addEmptySlide) yöntemini çağırarak sunumun slayt koleksiyonunun sonuna boş bir slayt ekleyin.
- Yeni eklenen boş slayt ile bazı işlemler yapın.
- Son olarak, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesini kullanarak sunum dosyasını kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

    # Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
presentation = Presentation()
try:
    # Slayt koleksiyonunu alın.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Boş bir slaytı slayt koleksiyonuna ekleyin.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Yeni eklenen slayt üzerinde bazı işlemler yapın.

    # PPTX dosyasını diske kaydedin.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Belirli bir konuma yeni bir slayt ekleyebilir miyim, sadece sonuna değil?**

Evet. Kütüphane slayt koleksiyonlarını ve [insert](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertClone) işlemlerini destekler, bu sayede sadece sona eklemek yerine gerekli indeksde bir slayt ekleyebilirsiniz.

**Düzeni temel alarak slayt eklerken tema/stiller korunur mu?**

Evet. Bir düzen, ana slaytından biçimlendirmeyi devralır ve yeni slayt, seçilen düzen ve ona bağlı ana slayttan devralır.

**Yeni bir "boş" sunumda slayt eklemeden önce hangi slayt bulunur?**

Yeni oluşturulan bir sunum zaten sıfır indeksli bir boş slayt içerir. Bu, ekleme indekslerini hesaplarken dikkate alınması önemlidir.

**Ana slaytta birçok seçenek varsa yeni bir slayt için "doğru" düzeni nasıl seçebilirim?**

Genellikle, gereken yapıya uyan [LayoutSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/) (ör. [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidelayouttype/)) seçilir. Eğer böyle bir düzen eksikse, [add it to the master](/slides/tr/python-java/slide-layout/) ve ardından kullanabilirsiniz.