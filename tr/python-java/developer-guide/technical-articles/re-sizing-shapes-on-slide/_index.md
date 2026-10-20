---
title: Python üzerinden Java ile Sunum Slaytlarında Şekilleri Yeniden Boyutlandırma
type: docs
weight: 110
url: /tr/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/yeni-boyutlandirma-sablonlari-slayt-ustunde/
  - /tr/python-java/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştir
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve üretkenliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekilleri yeni boyutlara sığacak şekilde yeniden boyutlandırmanız ve konumlarını değiştirmeniz de gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlardaki, ana slaytlardaki ve düzenlerdeki tabloları nasıl ele alacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her şeklin göreli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliğinin orijinal genişliğe oranı ile çarpın. Aynı şekilde, dikey koordinatları ve yüksekliği yüksekliğin oranı ile uygulayın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Sonraki döngünün ölçeklemeyi kontrol etmesi için [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) ile [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Tablolar ayrı bir işlem gerektirir: tabloyun genel genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenenden büyük kalabilir.
{{% /alert %}}

İkinci örnek, tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlardaki, düzenlerdeki ve tek tek slaytlardaki şekilleri işleme alır. Yardımcısı, her [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) nesnesini sütun genişliklerini [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) ve minimum satır yüksekliklerini [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) ile ölçeklendirerek yönetir. Ardından, tablonun genel boyutlarını ayrı ayrı ölçeklendirmeden konumunu ölçeklendirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Tablo boyutları, sütun genişlikleri ve satır yükseklikleriyle kontrol edilir.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Ana slaytlarda ve düzenlerde tanımlı şekilleri ayrıca tek tek slaytlarda yeniden boyutlandırın.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Neden bir slaytı yeniden boyutlandırdıktan sonra şekiller bozuluyor veya kesiliyor?**

Şekilleri ölçeklendirmeden slayt boyutunu değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozabilir.

**Sağlanan kod tüm şekil tipleri için çalışıyor mu?**

İlk örnek, şekil sınırlarını doğrudan değiştirir ve tablosuz slaytlar için tasarlanmıştır. İkinci örnek ise tabloları ayrı olarak ele alır. Bu örnekler yazı tipi boyutlarını ölçeklendirmediği ve tablo içeriği satır yüksekliklerini kısıtlayabileceği için, özellikle metin ve tabloları kontrol edin.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranı, minimum satır yüksekliklerini yükseklik oranı ile ölçeklendirin ve ardından tablonun konumunu ölçeklendirin; bu ikinci örnekte gösterilmiştir.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için çalışır mı?**

Evet. İkinci örnek, [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) ve her bir ana slaytın [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) üzerinden döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırma ile birlikte bir slaytın yönünü (dikey/yatay) değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) çağırın; böylece ölçek faktörleri son yönelimi yansıtır.

**Ayarlayabileceğim slayt boyutu için bir limit var mı?**

[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) ile özel slayt boyutları belirtebilirsiniz. Desteklenen boyutlar aynı zamanda sunum formatına ve dosyayı açan uygulamaya bağlıdır.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için her iki boyut ve konum için genişlik ve yükseklik oranlarından küçüğünü kullanın. Bu, oranları korur ancak bir kenarda kullanılmayan boşluk bırakabilir.