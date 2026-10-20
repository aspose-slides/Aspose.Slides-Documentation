---
title: Python üzerinden Java ile Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandırma
type: docs
weight: 110
url: /tr/python-java/resizing-shapes-on-slide/
aliases:
  - /tr/python-java/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekillerini yeni boyutlara sığacak şekilde yeniden boyutlandırmanız ve konumlarını ayarlamanız gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçekleyeceğinizi ve tabloları slaytlarda, ana slaytlarda ve düzenlerde nasıl işleyeceğinizi gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her şeklin göreceli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliği ile orijinal genişliğin oranı ile çarpın. Aynı şekilde, yüksekliğini ve dikey koordinatlarını da ilgili yükseklik oranıyla uygulayın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Sonraki döngünün ölçeklemeyi kontrol etmesi için [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) ve [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklemez.

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
Tablolar ayrı bir işlem gerektirir: tablonun toplam genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenenden büyük kalabilir.
{{% /alert %}}

İkinci örnek tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlardaki, düzenlerdeki ve bireysel slaytlardaki şekilleri işler. Yardımcısı, her [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) öğesini [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) ile sütun genişliklerini ve [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) ile minimum satır yüksekliklerini ölçeklendirerek işler. Daha sonra tablonun konumunu, toplam boyutlarını ayrı ayrı ölçeklendirmeden ölçeklendirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Tablo boyutları sütun genişlikleri ve satır yükseklikleriyle kontrol edilir.
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

    # Ana slaytlar ve düzenlerde tanımlı şekilleri ve tek tek slaytları yeniden boyutlandırın.
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

**Bir slaytı yeniden boyutlandırdıktan sonra şekiller neden bozuluyor ya da kesiliyor?**

Slayt boyutunu şekilleri ölçeklemeden değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına çıkabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

İlk örnek şekil sınırlarını doğrudan değiştirir ve tablo içermeyen slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak işler. Bu örnekler yazı tipi boyutlarını ölçeklendirmediğinden ve tablo içeriği satır yüksekliğini kısıtlayabildiğinden, özellikle metin ve tablolar açısından sonuç düzenini kontrol edin.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranı ile, minimum satır yüksekliklerini ise yükseklik oranı ile ölçeklendirin, ardından tablonun konumunu ikinci örnekte gösterildiği gibi ölçeklendirin.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için çalışır mı?**

Evet. İkinci örnek, [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) ve her bir ana slaytın [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) elemanları üzerinde döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Bir slaytın yönünü (dikey/yatay) yeniden boyutlandırma ile birlikte değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) çağırın, böylece ölçek faktörleri son yönelimi yansıtır.

**Ayarlayabileceğim slayt boyutu için bir sınır var mı?**

[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) ile özel slayt boyutları belirtebilirsiniz. Desteklenen boyutlar ayrıca sunum formatına ve dosyayı açan uygulamaya bağlıdır.

**Sabıt en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için genişlik ve yükseklik oranlarından daha küçüğünü hem boyutlar hem de konumlar için kullanın. Bu, oranı korur ancak bir kenarda kullanılmayan boşluk bırakabilir.