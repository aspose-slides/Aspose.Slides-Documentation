---
title: Python'da Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandır
type: docs
weight: 130
url: /tr/python-net/resizing-shapes-on-slide/
aliases:
  - /tr/python-net/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekillerin yeni boyutlara uyması için yeniden boyutlandırılması ve konumlandırılması gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlarda, ana slaytlarda ve düzenlerdeki tabloları nasıl ele alacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her şeklin göreli konum ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliği ile orijinal genişlik arasındaki oranla çarpın. Aynı şekilde, dikey koordinatlarını ve yüksekliğini yüksekliği oranı ile uygulayın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. `[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/)` metodunu `[SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/)` ile kullanır; böylece sonraki döngü ölçeklemeyi kontrol eder. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsindendir. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tiplerinin boyutunu ölçeklendirmez.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Bağımsız yatay ve dikey ölçek faktörlerini hesapla.
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
Tablolar ayrı bir işlem gerektirir: tablonun toplam genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenen değerden daha büyük kalabilir.
{{% /alert %}}

İkinci örnek, tabloları destekler ve bireysel slaytların yanı sıra ana slaytlar ve düzenlerdeki şekilleri işleyerek yeniden boyutlandırılmış sunumu kaydeder. Yardımcısı, her `[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)` öğesini `[Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/)` ve `[Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/)` değerlerini ölçeklendirerek işler. Ardından, tablonun toplam boyutlarını ayrı ayrı ölçeklendirmeden konumunu ölçeklendirir.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Tablo boyutları sütun genişlikleri ve satır yükseklikleriyle kontrol edilir.
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
    # Bağımsız yatay ve dikey ölçek faktörlerini hesapla.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Ana slaytlarda ve düzenlerde tanımlı şekilleri, ayrıca tek tek slaytlardaki şekilleri yeniden boyutlandır.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Slaytı yeniden boyutlandırdıktan sonra şekiller neden bozuluyor veya kesiliyor?**

Slayt boyutunu şekilleri ölçeklendirmeden değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozar.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

İlk örnek, şekil sınırlarını doğrudan değiştirir ve tabloları içermeyen slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak işler. Sonuç düzenini, özellikle metin ve tabloları kontrol edin; bu örnekler yazı tipi boyutlarını ölçeklendirmez ve tablo içeriği satır yüksekliklerini kısıtlayabilir.

**Slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranıyla, minimum satır yüksekliklerini ise yükseklik oranıyla ölçeklendirin, ardından tablonun konumunu ölçeklendirin; ikinci örnekte gösterildiği gibi.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için de çalışır mı?**

Evet. İkinci örnek `[Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/)` ve her bir ana slaydın `[MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/)` koleksiyonları üzerinde döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Slaytın yönünü (dikey/yatay) yeniden boyutlandırma sırasında değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce `[SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/)` ayarlayın; böylece ölçek faktörleri son yönelime göre hesaplanır.

**Ayarlayabileceğim bir slayt boyutu sınırı var mı?**

`[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/)` ile özel slayt boyutları belirleyebilirsiniz. Desteklenen boyutlar, sunum formatına ve dosyayı açan uygulamaya da bağlıdır.

**Sabit en-boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için genişlik ve yükseklik oranlarından küçüğünü her iki boyut ve konum için de kullanın. Bu, oranı korur ancak bir kenarda kullanılmayan boşluk bırakabilir.