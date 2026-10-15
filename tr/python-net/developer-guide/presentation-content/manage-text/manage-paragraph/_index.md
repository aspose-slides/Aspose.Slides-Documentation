---
title: PowerPoint Metin Paragraflarını Python'da Yönet
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
  - /python-net/paragraf/
  - /python-net/bolum/
keywords:
- metin ekle
- paragraf ekle
- metin yönet
- paragraf yönet
- madde işareti yönet
- paragraf girintisi
- askı girintisi
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'ye
- paragrafları HTML'ye
- paragrafları resme
- metni resme
- paragrafı dışa aktar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görselleri oluşturma ve biçimlendirme konularını öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET metni bir metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) bir şeklin içindeki metin konteynerini temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf‑seviyesi biçimlendirmesine erişim sağlar.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) bir paragraftaki metin yürütmesini temsil eder. Her bölüm kendi metnine ve karakter‑seviyesi biçimlendirmesine sahip olabilir.

Bu sayede bir paragraf, birden çok bölüm kullanılarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içerebilir.

## **Paragrafları Oluştur ve Biçimlendir**

Bir şeklin metin çerçevesinde paragraflar oluşturun ve bölümleri kullanarak tek tek metin yürütmelerini biçimlendirin. Bu bölüm, her paragrafta birden çok bölümü birleştirip farklı renkler, yazı boyutları ve stiller uygulamayı gösterir.

### **Birden Çok Bölüm İçeren Paragraflar Oluştur**

Aşağıdaki Python örneği, [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) koleksiyonunda üç metin yürütmesi içeren üç paragraf yaratır. Varsayılan paragrafı ve boş bölümünü yeniden kullanır, ardından kalan paragrafları ve bölümleri ekler. Biçimlendirme, [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) aracılığıyla uygulanır: her paragraftaki ilk bölüm kırmızı, kalın ve 15 puan; ikinci bölüm mavi, italik ve 18 puan. Üçüncü bölüm varsayılan biçimlendirmesini korur:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Madde İşaretli ve Numaralı Listeler Oluştur**

Paragraf metnini semboller, sayılar veya özel resimler ile listelere dönüştürün. Bu bölümde madde işareti biçimlendirme, çok seviyeli listeler ve özel başlangıç sayıları ele alınır.

### **Madde İşaretli veya Numaralı Liste Oluştur**

Madde işaretleri ve numaralar ilgili öğelerin taranmasını kolaylaştırır. Aspose.Slides içinde liste ayarları [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) aracılığıyla tanımlanır.

Bu Python örneği aynı metin çerçevesine bir sembol madde işareti ve bir numaralı öğe ekler. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) madde işareti türünü seçerken, [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) sembolü sağlar ve [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) numaralandırma stilini seçer. Her iki öğe de %100 yükseklikte siyah madde işaretleri ve 25 puan paragraf girintisi kullanır:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Resim Madde İşaretleri Kullan**

Resim madde işaretleri, bir sembol veya sayı yerine özel bir resim kullanmanıza olanak tanır.

Bu örnek, çalışma dizininde `bullets.png` dosyasının bulunmasını gerektirir. Bu Python örneği bir resmi sunumun resim koleksiyonuna bir [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) olarak ekler ve paragraf madde işareti olarak kullanır. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) resim madde işareti olarak ayarlanır ve resim [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) ile atanır. [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) %100 olarak ayarlanır, böylece madde işareti paragraf metnine göre boyutlandırılır:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Çok Seviyeli Liste Oluştur**

[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) ayarı, paragrafları bir listenin farklı seviyelerinde konumlandırır. En üst seviye derinliği `0` dır.

Bu Python örneği, dört paragraf için [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) değerlerini 0‑3 arasında atar ve tek bir metin çerçevesinde bir hiyerarşi oluşturur. Her paragraf bir sembol madde işareti kullanır, [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) ise yan yana gelen seviyeleri ayırt etmek için yuvarlak madde işareti ve tire arasında değişir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Numaralı Liste Öğelerini Özel Değerlerle Başlat**

[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) ile bir numaralı paragraf için gösterilecek başlangıç sayısı ayarlanabilir.

Bu Python örneği üç paragraf için [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) numaralandırma olarak ayarlar ve [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) değerlerini 2, 3 ve 7 olarak atar. Başlangıç değeri her paragraf için ayrı ayrı yapılandırılır, böylece görüntülenen sayılar atlamalar yapabilir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Paragraf Düzeni ve Son Özelliklerini Kontrol Et**

Paragraf kenar boşluklarını ve girintilerini ayarlayarak ilk satır ve satır devamı konumlarını kontrol edin. Paragraf son işaretini görünür metin bölümlerinden ayrı olarak biçimlendirebilirsiniz.

### **İlk Satır Girintisi Ayarla**

[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) özelliği, bir paragrafın ilk satır girintisini kontrol eder. Bu özellik yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tam paragrafı taşımanız gerektiğinde [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) kullanın. Yalnızca ilk satırı taşımak istediğinizde [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) kullanın.

Aşağıdaki örnek üç paragrafın aynı [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 20 puan ve [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) değerlerini sırasıyla 0, 20 ve 40 puan olarak ayarlar. İlk satırlar giderek daha büyük ofsetlerle başlarken, satır devamları aynı sol kenar boşluğunu korur:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

### **Askı Girintisi Ayarla**

Askı girintisi, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides içinde bu etkiyi [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) özelliği ile elde edersiniz. `indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırın.

Uygulamada, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) paragraf gövdesinin sol konumunu, [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) ise bu kenar boşluğuna göre ilk satırın konumunu tanımlar. Askı girintisi oluşturmak için pozitif bir `margin_left` ve negatif bir `indent` değeri ayarlayın.

Bu biçimlendirme bibliyografiler, referanslar, sözlük girişleri ve satır devamının paragraf gövdesinin altında hizalanması gereken diğer paragraflar için faydalıdır.

Aşağıdaki Python örneği, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) değerlerini 40 ve 60 puan, [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) değerlerini -20 ve -30 puan olarak eşleştirir. Her paragrafta ilk satır satır devamının solunda başlar; ikinci paragrafta daha derin bir askı girintisi vardır:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragrafların askı girintisi](hanging_indent.png)

### **Paragraf Sonu Çalışma Özelliklerini Ayarla**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) özelliği, paragraf son işaretinin biçimlendirmesini kontrol eder. Örnek, en az bir slayt içeren `Test.pptx` dosyasını yükler ve [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) oluşturur; bu formatta [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) 48 puan ve [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) Times New Roman olarak ayarlanır. Bu format ikinci paragrafın son işaretine atanır, görünür metin bölümleri değişmeden kalır:

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Renderlanmış Satırları Say**

Satır sonlarındaki otomatik kaydırma ve noktalama işaretlerini etkileyen paragraf kuralları için [Control Line Breaking](/slides/tr/python-net/text-formatting/#control-line-breaking) ve [Control Hanging Punctuation](/slides/tr/python-net/text-formatting/#control-hanging-punctuation) bölümlerine bakın.

[Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) yöntemi, otomatik kaydırma dahil metin yerleşiminden sonra bir paragrafın kapladığı satır sayısını verir. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken faydalıdır.

Bir paragraf, [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) içinde bir öğedir ve birkaç renderlanmış satır kaplayabilir. Paragraf içinde açık bir satır sonu, başka bir paragraf oluşturmadan yeni bir satır zorlar. Otomatik kaydırma, mevcut genişliğe göre satır oluşturur ve metne açık satır sonu eklemez. Bu nedenle paragrafları ya da satır sonu karakterlerini saymak renderlanmış satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Örnek, [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) etkinleştirir ve [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) devre dışı bırakır; böylece şekil genişliği kaydırmayı kontrol eder, metni otomatik olarak küçültmez ya da şekli yeniden boyutlandırmaz. Her ölçüm [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) ile yapılır. Şekil boyutları puan cinsindendir. Son olarak örnek bir paragraf daha ekler ve metin çerçevesi üzerindeki satır sayılarını toplar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Bu metin ve boyutlarla, şekli daraltmak satır sayısını artırırken, kısa dizeyle değiştirmek azaltır. Tam sayılar yazı tipi bulunabilirliği, yerine koyma, yazı tipi boyutu, kenar boşlukları, girinti, kaydırma ve otomatik sığdırma ayarlarına göre değişebilir. Şablonu kontrol ederken hedef ortam için planlanan yazı tiplerini ve yerleşim ayarlarını kullanın.

Satır sayısı yalnız başına metnin kapsayıcı içinde taşma olup olmadığını belirlemez. Kullanılabilir yükseklik, satır yükseklikleri, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; kaydırma devre dışı bırakıldığında tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçe/Dışa Aktar**

HTML kullanarak metni bir sunuma getirebilir veya mevcut paragrafları dışarda kullanmak için dışa aktarabilirsiniz. Bu bölüm ayrıca bireysel paragrafları resim olarak renderlamayı, tablo hücrelerindeki paragrafları da kapsayacak şekilde gösterir.

### **HTML Metnini Paragraflara İçe Aktar**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) yöntemi, HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürür.

Bu Python örneği çalışma dizinindeki `file.html` dosyasından HTML okur ve işaretlemeyi [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) metoduna geçirir. Metin çerçevesinin varsayılan paragrafını temizler, böylece çerçeve yalnızca içe aktarılan içeriği taşır. Dikdörtgen şekil slaytın her iki tarafında 10 puan kenar boşluğu bırakır:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Paragraf Metnini HTML’ye Dışa Aktar**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) yöntemi, seçilen paragraf aralığını HTML olarak dışa aktarır. Sunum metnini bir web sitesinde yeniden kullanırken, sunumun yazı tipi, boyutu ya da metin kutusu stillerini taşımadan yerel vurgulamayı korumak isteyebilirsiniz. [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) ayarı, dışa aktarımcının biçimlendirme kalıtımını ne kadar takip edeceğini kontrol eder.

[örnek sunumu](text-inheritance.pptx) indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, "Inherited text; explicit red 18pt" metnini içeren bir metin şekli barındırır. Giriş kasıtlı olarak birkaç biçimlendirme seviyesini kullanır:

- Sunumun varsayılan metin stili Calibri ve 28 pt boyut sağlar.
- Metin çerçevesinin birinci seviyeli metin stili mavi metin ve italik sağlar.
- Paragraf açıkça kalın metin ayarlar.
- İkinci bölüm, "explicit red 18pt", kırmızı metin ve 18 pt boyutunu açıkça ayarlar.

Aşağıdaki tam örnek aynı paragrafları üç kez dışa aktarır. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) dışa aktarım metoduna geçirilir ve her sonuç ayrı bir UTF‑8 HTML dosyasına yazılır:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

Oluşturulan HTML, ilk bölüm için aşağıdaki CSS’i içerir, "Inherited text; ". Tablo ilgili bildirimleri listeler; diğer oluşturulan özellikler açıklık için çıkarılmıştır.

| Output | İlk bölüm için ilgili CSS | Görünüm |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Mavi, kalın, italik metin, Calibri’de 28 pt, font mevcutsa. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Mavi, kalın, italik metin; çevre sayfa veya tarayıcı yazı tipi ailesi ve boyutunu sağlar. |
| `ParagraphOnly.html` | `font-weight:bold` | Kalın metin; çevre sayfa veya tarayıcı yazı tipi ailesi, boyutu, rengi ve italik stilini sağlar. |

İkinci bölüm tüm üç çıktıda `color:#ff0000`, `font-size:18pt` ve `font-weight:bold` değerlerini korur. `ALL` ve `TEXT_BOX` için italik korunur, `PARAGRAPH_ONLY` için korunmaz. Kalıtımı kısıtlamak, bir paragraf veya bölüme açıkça atanan biçimlendirmeyi kaldırmaz.

Dosyaları aynı tarayıcıda açarak karşılaştırın. Kısıtlı iki kipte, atlanan CSS özellikleri hedef sayfanın stilleri veya tarayıcı varsayılanlarıyla çözülür; ortaya çıkan görünüm HTML’nin nerede kullanıldığına bağlıdır.

### **Paragrafı Resim Olarak Renderla**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) bireysel bir paragrafı doğrudan renderlar ve bir [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) döndürür. Sonucu bir dosyaya veya akışa [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) ile kaydedebilirsiniz. İçeren şekli renderlamaya veya bitmap’i manuel olarak kırpmaya gerek yoktur.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) paragraf ana koleksiyonunda bulunamazsa, geçerli bir render sınırı yoksa veya renderlanamazsa `None` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve kullanılan görüntüyü işiniz bittikten sonra serbest bırakın.

#### **Varsayılan Ölçekte Paragrafı Renderla**

Örnek, bir slaytı olan `sample.pptx` dosyasını kullanır; ilk şekli üç paragraf içeren bir metin kutusudur.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek indeks 1’deki ikinci paragrafı seçer ve [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) metodunu ölçek parametresi olmadan çağırır. Şeklin gerekli paragrafı içerdiğini ve renderlamanın bir görüntü döndürdüğünü kontrol eder, ardından [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) ile PNG formatında kaydeder. Bağlam yöneticisi, kullanım sonrası görüntü kaynaklarını serbest bırakır.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Sonuç:

![Paragraf resmi](paragraph_to_image_output.png)

#### **Tablo Hücresinde Ölçekli Paragraf Renderlama**

`scale_x` ve `scale_y` parametrelerini kabul eden [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) aşırı yüklemesini kullanarak yatay ve dikey ölçek faktörlerini ayarlayın. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin iki katı ve yüksekliğinin iki katı olarak renderlar ve sonucu PNG olarak kaydeder.

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

`1` faktörü, ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` genişlik ve yükseklik yaklaşık olarak iki katına, piksel sayısı dört katına çıkarır. Daha büyük faktörler yakınlaştırma veya yüksek çözünürlüklü çıkış için daha keskin metin verir, ancak bellek kullanımını ve dosya boyutunu artırır. `1`‑in altındaki faktörler daha az detaylı, daha küçük görüntüler üretir. Oranı korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

[Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ile bir bütün şekli renderlamak, çıktının şeklin doldurması, kenarlığı veya diğer görsel bağlamını içermesi gerektiğinde hâlâ faydalıdır. Yalnızca paragraf resmi için [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) kullanın.

## **SSS**

**Bir metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) özelliğini devre dışı bırakarak kaydırmayı kapatın, böylece satırlar metin çerçevesinin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki kesin sınırlarını nasıl alabilirim?**

[Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) yöntemini kullanarak paragrafın sınırlayıcı dikdörtgenini alın. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) ise tek bir bölümün sınırlarını verir.

**Paragraf hizalaması (sol, sağ, ortalanmış veya iki yana yaslanmış) nerede kontrol edilir?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) bir paragraf‑seviyesi ayardır ve bireysel bölüm biçimlendirmesine bakılmaksızın tüm paragrafı etkiler.

Farklı yazı tipi boyutlarına sahip bölümleri her satırda dikey olarak hizalamak için [Align Fonts Within a Line](/slides/tr/python-net/text-formatting/#align-fonts-within-a-line) bölümüne bakın.

**Paragrafın bir kısmı için doğrulama dili ayarlayabilir miyim?**

Evet. [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) tek tek bölümlere atanabilir, böylece bir paragraf birden çok dilde metin içerebilir.