---
title: Python ile Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme
linktitle: Listeleri Yönet
type: docs
weight: 70
url: /tr/python-net/manage-lists/
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
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanızı ve biçimlendirmenizi sağlar. Bir liste öğesi, madde işareti ayarları paragraf formatı aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyinde liste ayarlarına erişmek için [Paragraph.paragraph_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/paragraph_format/) özelliğini kullanın. Ana giriş noktası, bir [BulletFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/) nesnesi döndüren [ParagraphFormat.bullet](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/bullet/) özelliğidir. Bu nesne ile madde işareti tipi, sembol, resim, renk, boyut, numaralandırma stili ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale aşağıdakileri gösterir:

- özel bir sembolle madde işaretli liste oluşturma
- resimli madde işareti oluşturma
- paragraf derinliğini ayarlayarak çok seviyeli liste oluşturma
- numaralı liste oluşturma
- mevcut bir sunumda liste biçimlendirmesini inceleme ve değiştirme

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içine [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) nesneleri ekleyin ve [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.SYMBOL](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın. Ardından [BulletFormat.char](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/color/) ve [BulletFormat.height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/height/) özelliklerini ayarlayarak madde işareti görünümünü kontrol edebilirsiniz.

Aşağıdaki Python kodu bir slaytta madde işaretli liste oluşturmayı gösterir:

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

Öğelerin sırası önemli olduğunda numaralı listeler kullanın. [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.NUMBERED](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın. Ayrıca [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/numbered_bullet_style/) ile bir numaralandırma biçimi seçebilir veya listenin 1 dışındaki bir değerden başlamasını istiyorsanız [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) özelliğini ayarlayabilirsiniz.

Aşağıdaki Python kodu bir slaytta numaralı liste oluşturmayı gösterir:

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

Aspose.Slides, normal bir madde işareti sembolünü bir resimle değiştirmenize olanak tanır. Resimli madde işaretleri, küçük bir boyutta okunabilirliği koruyan basit görüntüler, örneğin simgeler veya küçük şeffaf PNG dosyaları ile en iyi şekilde çalışır.

{{% alert color="primary" %}}
İdeal olarak, normal madde işareti sembolünü bir görüntü ile değiştirmeyi planlıyorsanız, şeffaf arka planlı basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özel madde işareti sembolleri olarak iyi çalışır.

Unutmayın ki görüntü çok küçük bir boyuta ölçeklendirilecektir. Bu nedenle, bir listede madde işareti olarak kullanıldığında net ve görsel olarak etkili kalan bir görüntü seçmenizi şiddetle tavsiye ederiz.
{{% /alert %}}

Resimli bir madde işareti oluşturmak için bir resmi [Presentation.images](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/images/) koleksiyonuna ekleyin ve döndürülen resim nesnesini [BulletFormat.picture](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/picture/) özelliğine atayın. Görüntüyü atamadan önce [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.PICTURE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde bir "image.png" var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki Python kodu bir slaytta resimli madde işaretleri oluşturmayı gösterir:

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

Liste öğelerini farklı seviyelerde konumlandırmak için [ParagraphFormat.depth](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/depth/) özelliğini kullanın. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe bulunur ve bu şekilde devam eder.

Aşağıdaki Python kodu çok seviyeli bir madde işaretli liste oluşturmayı gösterir:

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

Mevcut bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı alın ve [ParagraphFormat.bullet](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/bullet/) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

Aşağıdaki Python kodu bir metin çerçevesindeki ilk paragrafı numaralı bir liste stiline dönüştürür:

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

**Madde işaretli ve numaralı listeler PDF ya da görüntülere aktarılabilir mi?**

Evet. Aspose.Slides, hedef format ilgili metin düzeni ve madde işareti özelliklerini desteklediği sürece liste biçimlendirmesini korur.

**Mevcut sunumlardaki listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı alın, [ParagraphFormat.bullet](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/bullet/) ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler Latin dışı metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, bu sayede çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyaç duyduğunuz karakterleri desteklediğinden emin olun.