---
title: Python'da Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme
linktitle: Listeleri Yönet
type: docs
weight: 70
url: /tr/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- madde işareti
- madde işaretli liste
- numaralı liste
- sembol madde işareti
- resimli madde işareti
- özel madde işareti
- çok seviyeli liste
- madde işareti oluştur
- madde işareti ekle
- liste ekle
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturup biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyindeki liste ayarlarına erişmek için [Paragraph.paragraph_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/paragraph_format/) özelliğini kullanın. Ana giriş noktası [ParagraphFormat.bullet](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/bullet/), bu da bir [BulletFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/) nesnesi döndürür. Bu nesne ile madde işareti türünü, sembolü, resmi, rengi, boyutu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale aşağıdakileri gösterir:

- özel bir sembolle madde işaretli bir liste oluşturma
- resimli bir madde işareti oluşturma
- paragraf derinliğini ayarlayarak çok seviyeli bir liste oluşturma
- numaralı bir liste oluşturma
- varolan bir sunumdaki liste biçimlendirmesini inceleme ve değiştirme

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için, bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içine [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) nesneleri ekleyin ve [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.SYMBOL](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın. Ardından madde işaretinin görünümünü kontrol etmek için [BulletFormat.char](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/color/) ve [BulletFormat.height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/height/) ayarlayabilirsiniz.

Aşağıdaki Python kodu, bir slaytta madde işaretli bir liste nasıl oluşturulacağını gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Sembol madde işaretleri](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Öğe sırası önemli olduğunda numaralı listeler kullanın. [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.NUMBERED](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın. Ayrıca bir numaralandırma biçimi seçmek için [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/numbered_bullet_style/) kullanabilir veya listenin 1 yerine farklı bir değerden başlamasını istediğinizde [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) özelliğini ayarlayabilirsiniz.

Aşağıdaki Python kodu, bir slaytta numaralı bir liste nasıl oluşturulacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Numaralı madde işaretleri](numbered_bullets.png)

## **Resimli Madde İşareti Oluşturma**

Aspose.Slides, normal bir madde işareti sembolünü bir görüntüyle değiştirmenize olanak tanır. Resimli madde işaretleri, küçük boyutta bile okunabilirliği koruyan basit görüntülerle, örneğin simgeler veya küçük şeffaf PNG dosyalarıyla en iyi şekilde çalışır.

{{% alert color="primary" %}}
İdeal olarak, normal madde işareti sembolünü bir görüntüyle değiştirmeyi planlıyorsanız, şeffaf arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özel madde işareti sembolleri olarak iyi çalışır.

Görselin çok küçük bir boyuta ölçeklendirileceğini unutmayın. Bu nedenle, listede madde işareti olarak kullanıldığında net ve görsel açıdan etkili kalan bir görüntü seçmenizi şiddetle tavsiye ederiz.
{{% /alert %}}

Resimli bir madde işareti oluşturmak için, bir görüntüyü [Presentation.images](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/images/) ekleyin ve döndürülen görüntü nesnesini [BulletFormat.picture](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/picture/) özelliğine atayın. Görüntüyü atamadan önce [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.PICTURE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde bir "image.png" var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki Python kodu, bir slaytta resimli madde işaretlerinin nasıl oluşturulacağını gösterir:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Resimli madde işaretleri](picture_bullets.png)

## **Çok Seviyeli Liste Oluşturma**

[ParagraphFormat.depth](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/depth/) özelliğini kullanarak liste öğelerini farklı seviyelerde konumlandırın. Seviye 0 en üst seviyedir, seviye 1 onun altında bir alt seviyedir ve bu şekilde devam eder.

Aşağıdaki Python kodu, çok seviyeli bir madde işaretli liste nasıl oluşturulacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Çok seviyeli liste](multilevel_list.png)

## **Mevcut Bir Listeyi Değiştirme**

Mevcut bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı erişin ve onun [ParagraphFormat.bullet](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/bullet/) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

Aşağıdaki Python kodu, bir metin çerçevesindeki ilk paragrafı numaralı liste stilini kullanacak şekilde değiştirir:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Madde işaretli ve numaralı listeler PDF veya görüntülere dışa aktarılabilir mi?**

Evet. Aspose.Slides, hedef format ilgili metin düzeni ve madde işareti özelliklerini desteklediğinde liste biçimlendirmesini korur.

**Mevcut sunumlarda listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, onun [ParagraphFormat.bullet](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/bullet/) ayarlarını inceleyin veya güncelleyin ve ardından sunumu kaydedin.

**Listeler Latin olmayan metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, böylece çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyaç duyduğunuz karakterleri desteklediğinden emin olun.