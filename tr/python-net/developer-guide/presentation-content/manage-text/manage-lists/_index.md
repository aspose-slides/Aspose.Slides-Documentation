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
- özelleştirilmiş madde işareti
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

Aspose.Slides for Python via .NET, PowerPoint ve OpenDocument sunumlarında maddeli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyindeki liste ayarlarına erişmek için [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) özelliğini kullanın. Ana giriş noktası, [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) olup, bir [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) nesnesi döndürür. Bu nesne ile madde türü, sembol, resim, renk, boyut, numaralandırma stili ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale şunları gösterir:

- özel bir sembolle madde işaretli bir liste oluşturma
- resimli madde işareti oluşturma
- paragraf derinliği ayarlanarak çok düzeyli bir liste oluşturma
- numaralı bir liste oluşturma
- var olan bir sunumda liste biçimlendirmesini inceleme ve değiştirme
- paragraf metniyle birlikte gerçek liste işaretlerini ve numaralarını okuma

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için, bir [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) içine [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) nesneleri ekleyin ve [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) olarak ayarlayın. Ardından madde görünümünü kontrol etmek için [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/) ve [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) ayarlarını yapabilirsiniz.

Aşağıdaki Python kodu, bir slaytta madde işaretli bir liste oluşturmayı gösterir:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
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

![Sembollü madde işaretleri](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Öğelerin sırası önemli olduğunda numaralı listeler kullanın. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) olarak ayarlayın. Ayrıca bir numaralandırma biçimi seçmek için [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) kullanılabilir veya listenin 1 dışında bir değerden başlaması gerektiğinde [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) ayarlanabilir.

Aşağıdaki Python kodu, bir slaytta numaralı bir liste oluşturmayı gösterir:

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

Aspose.Slides, normal bir madde işareti sembolünü bir görüntüyle değiştirme imkanı sunar. Resimli madde işaretleri, küçük boyutta okunabilirliğini koruyan basit görüntülerle en iyi şekilde çalışır; örneğin simgeler veya küçük şeffaf PNG dosyaları.

{{% alert color="info" title="Note" %}}
İdeal olarak, normal madde işareti sembolünü bir görüntüyle değiştirmeyi planlıyorsanız, şeffaf arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özel madde işareti sembolleri olarak iyi çalışır.
{{% /alert %}}

Resimli bir madde işareti oluşturmak için, bir görüntüyü [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) koleksiyonuna ekleyin ve dönen görüntü nesnesini [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) özelliğine atayın. Görüntüyü atamadan önce [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde bir "image.png" var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki Python kodu, bir slaytta resimli madde işaretleri oluşturmayı gösterir:

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

## **Çok Düzeyli Liste Oluşturma**

Liste öğelerini farklı seviyelere yerleştirmek için [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) özelliğini kullanın. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe geçer vb. Derinlik yalnızca girintiyi kontrol eder; seviyelerin aynı zamanda madde işareti taşıması gerektiğinde her paragrafta [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) ayarlayın.

Aşağıdaki Python kodu, çok düzeyli bir liste oluşturmayı gösterir:

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

![Çok düzeyli liste](multilevel_list.png)

## **Var Olan Bir Listeyi Değiştirme**

Var olan bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı erişin ve [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) ayarlarını güncelleyin. Listeleri oluştururken kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

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

## **Gerçek Madde İşareti Değerlerini Okuma**

Sunum içeriği çıkarılırken, liste işaretlerini paragraf metniyle birlikte tutun. Etkili madde işareti biçimini elde etmek için [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) çağırın ve [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) erişin. [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) değerini okumadan önce [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) özelliğini kontrol edin.

Numaralı listeler için bu üç değeri ayırın:

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) örneğin nokta ile takip edilen Arap rakamları veya nokta ile takip edilen küçük harfler gibi formatı belirler.
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) numaralı paragraf grubunun başlangıç numarasını belirler.
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) belirli bir paragraf için biçimlendirilmiş işareti döndürür. Örneğin, 5'ten başlayan bir listede ikinci öğe `6.` döndürür.

[depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) her paragrafta korunarak iç içeleme seviyesi korunur. Gerçek işaret tam hiyerarşiyi kodlamaz: iç içe bir öğe `c.` döndürebilir, `6.c.` gibi birleşik bir etiket yerine.

Aşağıdaki bağımsız örnek listeler oluşturur, bir sunuma kaydeder ve sunumu yeniden yükleyerek her paragrafın metnini, derinliğini, madde işareti türünü ve gerçek değerini raporlar. Küçük mavi resim işareti, satır içi SVG'den oluşturulur.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # Harici bir resim dosyası olmadan bir resim işareti oluştur.
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

Kaynak listeler aşağıda gösterilmiştir.

![5'ten başlayan listeler, iç içe harf ve Roma rakamı öğeleri, bir sembol işareti, madde işareti olmayan bir paragraf ve mavi resim işareti](actual_bullet_values.png)

Rapor, PowerPoint'te gösterilen işaretlerle eşleşir:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

[BulletType.NONE ve BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) için, [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) boş bir dize yerine `None` döndürür. Bu türleri ayrı ayrı ele alın: birincisinin işareti yoktur, ikincisi ise madde işareti görüntüsünün ayrı olarak çıkarılmasını gerektirir. Bir resimli madde işareti yalnızca metin işareti çıkarılarak yeniden üretilemez.

## **SSS**

**Madde işaretli ve numaralı listeler PDF veya görüntülere aktarılabilir mi?**

Evet. Aspose.Slides, hedef format ilgili metin düzeni ve madde işareti özelliklerini desteklediğinde liste biçimlendirmesini korur.

**Var olan sunumlardaki listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler Latin olmayan metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, böylece çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyaç duyduğunuz karakterleri desteklediğinden emin olun.