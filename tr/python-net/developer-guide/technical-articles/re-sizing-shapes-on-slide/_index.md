---
title: Sunum Slaytlarında Şekilleri Yeniden Boyutlandırma (Python)
type: docs
weight: 130
url: /tr/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /tr/python-net/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekillerini yeni boyutlara sığdırmak için yeniden boyutlandırmanız ve konumlarını yeniden ayarlamanız da gerekebilir. Bu makale şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlarda, ana slaytlarda ve düzenlerdeki tabloları nasıl ele alacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her şeklin göreceli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliğinin orijinal genişliğe oranı ile çarpın. Aynı şekilde, dikey koordinatlarını ve yüksekliğini ilgili yükseklik oranı ile uygulayın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Ölçeklemeyi sonraki döngünün kontrol etmesi için [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) ile [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Yatay ve dikey bağımsız ölçek faktörlerini hesapla.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Tablolar ayrı bir işlem gerektirir: tablonun genel genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliğini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yüksekliği istenenden büyük kalabilir.
{{% /alert %}}

İkinci örnek tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlarda, düzenlerde ve tek tek slaytlarda şekilleri işler. Yardımcısı, her [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) öğesini [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) ve [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) ölçeklendirerek ele alır. Ardından tablonun konumunu, genel boyutlarını ayrı ayrı ölçeklendirmeden ölçeklendirir.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Tablo boyutları sütun genişlikleri ve satır yüksekliğiyle kontrol edilir.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Yatay ve dikey bağımsız ölçek faktörlerini hesapla.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Ana slaytlarda ve düzenlerde tanımlı şekilleri ayrıca tekli slaytlarda da yeniden boyutlandır.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Şekiller slayt yeniden boyutlandırıldıktan sonra neden bozulur veya kesilir?**

Şekilleri ölçeklendirmeden slayt boyutunu değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozabilir.

**Sağlanan kod tüm şekil tipleri için çalışır mı?**

İlk örnek şeklin sınırlarını doğrudan değiştirir ve tabloları olmayan slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak işler. Sonuçta oluşan yerleşimi, özellikle metin ve tabloları kontrol edin; çünkü bu örnekler yazı tipi boyutlarını ölçeklendirmez ve tablo içeriği satır yüksekliklerini sınırlayabilir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranı ile, minimum satır yüksekliklerini ise yükseklik oranı ile ölçeklendirin, ardından ikinci örnekte gösterildiği gibi tablonun konumunu ölçeklendirin.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için çalışır mı?**

Evet. İkinci örnek [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ve her bir ana slaydın [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) üzerinden iterasyon yapar ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırma ile birlikte bir slaytın yönünü (dikey/yatay) değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) ayarlayın, böylece ölçek faktörleri son yönelimi yansıtır.

**Ayarlayabileceğim slayt boyutu için bir limit var mı?**

[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) ile özel slayt boyutları belirtebilirsiniz. Desteklenen boyutlar, sunum formatına ve dosyayı açmak için kullanılan uygulamaya da bağlıdır.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Geniçlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal yerleşimi yeni slayt boyutlarına sığdırmak için hem genişlik hem de yükseklik oranlarından daha küçüğünü kullanın. Bu, oranları korur ancak bir kenarda kullanılmayan boşluk kalabilir.