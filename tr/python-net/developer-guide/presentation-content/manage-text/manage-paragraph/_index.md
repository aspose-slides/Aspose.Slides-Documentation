---
title: Python’da PowerPoint Metin Paragraflarını Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- sarkıt girinti
- paragraf işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML’ye
- paragrafı HTML’ye
- paragrafı görüntüye
- metni görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) bir şeklin metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf‑seviyesi biçimlendirmeye erişim sağlar.
* [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) bir paragraftaki metin akışını temsil eder. Her bölüm kendi metnine ve karakter‑seviyesi biçimlendirmeye sahip olabilir.

Bu sayede bir paragraf, birden fazla bölüm kullanılarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metinler barındırabilir.

## **Paragrafları Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm İçeren Paragraflar Oluşturma**

Aşağıdaki adımlar, her biri üç bölüm içeren üç paragrafla bir metin çerçevesi oluşturur:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytı diziniyle erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) özelliğine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki adet daha [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) nesnesi ekleyin.
6. Her paragraf için üç bölüm içerecek kadar [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.
7. Her bölümün metnini ayarlayın.
8. [Portion.portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/portion_format/) aracılığıyla karakter‑seviyesi biçimlendirme uygulayın.
9. Değiştirilen sunumu kaydedin.

Bu Python örneği adımları uygular:

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

## **İşaretli ve Numaralı Listeler Oluşturma**

### **İşaretli veya Numaralı Liste Oluşturma**

İşaretçiler ve numaralar, ilgili öğelerin daha kolay taranmasını sağlar. Aspose.Slides’te liste ayarları, [BulletFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/) aracılığıyla tanımlanır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytı diziniyle erişin.
3. Seçili slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) özelliğine erişin.
5. Metin çerçevesinden varsayılan paragrafı kaldırın.
6. Sembol işaretçi için bir [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) oluşturun.
7. [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.SYMBOL](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın ve işaretçi karakterini belirtin.
8. Paragraf metnini, girintiyi, işaretçi rengini ve işaretçi yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. İkinci bir paragraf oluşturun ve [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.NUMBERED](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın.
11. Numaralı işaretçi stilini yapılandırın ve paragrafı metin çerçevesine ekleyin.
12. Sunumu kaydedin.

Bu Python örneği bir sembol işaretçi ve bir numaralı işaretçi oluşturur:

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

### **Resim İşaretçileri Kullanma**

Resim işaretçileri, bir sembol veya sayı yerine özelleştirilmiş bir görüntü kullanmanıza olanak tanır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytı diziniyle erişin.
3. Bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin ve onun [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) özelliğine erişin.
4. Metin çerçevesinden varsayılan paragrafı kaldırın.
5. İşaretçi görüntüsünü yükleyin ve sunumun görüntü koleksiyonuna bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [BulletFormat.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/type/) özelliğini [BulletType.PICTURE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bullettype/) olarak ayarlayın.
8. [BulletFormat.picture](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/picture/) aracılığıyla görüntüyü atayın ve işaretçi yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. Değiştirilen sunumu kaydedin.

Bu Python örneği bir resim işaretçisi oluşturur:

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

### **Çok Seviyeli Liste Oluşturma**

[ParagraphFormat.depth](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/depth/) özelliğini ayarlayarak paragrafları listenin farklı seviyelerinde konumlandırabilirsiniz. Üst seviye `0` derinliğe sahiptir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin ve varsayılan paragrafı metin çerçevesinden temizleyin.
3. Dört paragraf oluşturun ve işaretçi sembollerini yapılandırın.
4. Paragrafların [ParagraphFormat.depth](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/depth/) değerlerini sırasıyla `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Python örneği dört seviyeli bir işaretli liste oluşturur:

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

### **Numaralı Liste Öğelerini Özel Değerlerle Başlatma**

[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) özelliğini kullanarak bir numaralı paragraf için başlangıç numarasını belirleyebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) oluşturun ve bir slayta [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
2. Şeklin metin çerçevesinden varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. İlgili paragraflar için [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) değerlerini sırasıyla `2`, `3` ve `7` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Python örneği her paragraf için özel bir başlangıç numarası atar:

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

## **Paragraf Düzeni ve Bitiş Özelliklerini Kontrol Etme**

### **İlk Satır Girintisi Ayarlama**

[ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) özelliğini kullanarak bir paragrafın ilk satır girintisini kontrol edebilirsiniz. Bu özellik, yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken geri kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak istediğinizde [ParagraphFormat.margin_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/margin_left/) kullanın. Yalnızca ilk satırı taşımak istediğinizde ise [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) kullanın.

Aşağıdaki örnek, birkaç paragraf oluşturur ve farklı [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) değerleri uygulayarak ilk satır girintisinin paragraf düzenine etkisini gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) özelliğine erişin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve onlara farklı [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) değerleri atayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilen sunumu kaydedin.

Bu kod, bir paragraf girintisinin nasıl ayarlanacağını gösterir:

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

### **Sarkıt Girinti Ayarlama**

Sarkıt girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides’te bu etkiyi [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) özelliği ile oluşturursunuz. `indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırırsınız.

Pratikte, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/margin_left/) paragraf gövdesinin sol konumunu belirler, [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) ise ilk satırın bu kenar boşluğuna göre konumunu tanımlar. Sarkıt girinti oluşturmak için pozitif bir `margin_left` ve negatif bir `indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografiler, referanslar, sözlük girdileri ve satırların paragraf gövdesinin altında hizalanması gereken diğer paragraflar için faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) özelliğine erişin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için pozitif bir [ParagraphFormat.margin_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/margin_left/) değeri atayın.
6. Sarkıt girinti etkisini oluşturmak için negatif bir [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) değeri ayarlayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilen sunumu kaydedin.

Bu kod, bir paragraf için sarkıt girintisinin nasıl ayarlanacağını gösterir:

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

![Paragrafların sarkıt girintisi](hanging_indent.png)

### **Paragraf Sonu Koşul Özelliklerini Ayarlama**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) özelliği, paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek, ikinci paragrafın son işaretine bir font boyutu ve Latin fontu atar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yükleyin ve bir slayta erişin.
2. Bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin ve varsayılan paragrafını temizleyin.
3. İki paragraf oluşturun ve bunlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) oluşturun.
5. [PortionFormat.font_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/font_height/) ve [PortionFormat.latin_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/latin_font/) ayarlarını yapın.
6. Biçimi [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) özelliğine atayın ve sunumu kaydedin.

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

## **Çizilen Satırları Sayma**

Satır sonundaki otomatik sarmalama ve noktalama kurallarıyla ilgili bilgiler için [Control Line Breaking](/slides/tr/python-net/text-formatting/#control-line-breaking) ve [Control Hanging Punctuation](/slides/tr/python-net/text-formatting/#control-hanging-punctuation) bölümlerine bakın.

[Paragraph.get_lines_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/get_lines_count/) metodunu kullanarak, metin yerleşimi sonrasında bir paragrafın kapladığı satır sayısını (otomatik sarmalama dahil) sayabilirsiniz. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol etmek için faydalıdır.

Bir paragraf, [TextFrame.paragraphs](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/paragraphs/) içinde bir öğedir ve birkaç çizilen satır kaplayabilir. Paragraf içinde açık bir satır sonu karakteri, yeni bir paragraf oluşturmadan yeni bir satır başlatır. Otomatik sarmalama ise genişlik sınırlamasına göre satır oluşturur, metne ek bir satır sonu karakteri eklemez. Bu nedenle paragraf sayısını veya satır sonu karakterlerini saymak, gerçek çizilen satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satır sayısını alır, şeklin genişliğini daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Sarmalama açıktır ve otomatik sığdırma kapatılmıştır, böylece şekil genişliği sarmalamayı kontrol eder, metin otomatik olarak küçülmez veya şekil yeniden boyutlandırılmaz. Şekil boyutları puan cinsindendir. Son olarak örnek, bir paragraf daha ekler ve metin çerçevesi üzerindeki satır sayılarını toplar.

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

Bu metin ve bu boyutlarla, şekli daraltmak satır sayısını artırırken, kısa dizeyle değiştirmek sayıyı azaltır. Gerçek sayılar, kullanılabilir font, font ikamesi, font boyutu, kenar boşlukları, girintiler, sarmalama ve otomatik sığdırma ayarlarına göre değişebilir. Şablon kontrolü yaparken hedef ortam için düşünülen font ve yerleşim ayarlarını kullanın.

Satır sayısı, metnin kapsayıcısının dışına taşma durumunu tek başına belirlemez. Kullanılabilir yükseklik, satır yükseklikleri, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; sarmalama kapalıyken tek bir satır bile genişliğin üstüne çıkabilir.

## **Paragraf İçeriğini İçe/Dışa Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphcollection/add_from_html/) metodunu kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
2. Bir slayta erişin ve bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
3. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) özelliğine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dosyasını okuyun.
5. HTML dizesini [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphcollection/add_from_html/) metoduna iletin.
6. Değiştirilen sunumu kaydedin.

Bu Python örneği HTML’yi bir metin çerçevesine aktarır:

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

### **Paragraf Metnini HTML’ye Dışa Aktarma**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphcollection/export_to_html/) metodunu kullanarak seçili paragraf aralığını HTML olarak dışa aktarabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun ve istediğiniz sunumu yükleyin.
2. Slayta erişin ve metni içeren [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) öğesini bulun.
3. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) özelliğine erişin.
4. Başlangıç paragrafı indeksi ve dışa aktarılacak paragraf sayısını belirterek [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphcollection/export_to_html/) metodunu çağırın.
5. Dönen HTML dizesini bir dosyaya yazın.

Bu Python örneği ilk metin şeklinin tüm paragraflarını dışa aktarır:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Paragrafı Görüntü Olarak Render Etme**

[Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfı, tek bir paragrafı doğrudan render etmek için `get_image` metodunu sağlar. Metod, bir [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) döndürür; bu görüntüyü [IImage.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/save/) ile dosyaya veya akışa kaydedebilirsiniz. İçeren şekli render etmeye veya bitmap’i elle kırpmaya gerek yoktur.

`get_image` metodu, paragraf ana koleksiyonunda bulunamazsa, geçerli bir render sınırı yoksa veya render edilemezse `None` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve görüntüyü bir bağlam yöneticisi olarak kullanarak kaynaklarını serbest bırakın.

#### **Varsayılan Ölçekte Paragrafı Render Etme**

sample.pptx adlı bir sunum dosyamız olduğunu ve içinde bir slayt bulunup, ilk şeklin üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, ikinci paragrafı normal bir metin şekline varsayılan ölçekte render eder ve PNG formatında kaydeder:

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

![Paragraf görüntüsü](paragraph_to_image_output.png)

#### **Bir Tablo Hücresindeki Paragrafı Ölçekle Render Etme**

`get_image` metoduna yatay ve dikey ölçek faktörleri göndererek render edilen paragrafın boyutunu kontrol edebilirsiniz. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin ve yüksekliğinin iki katı olacak şekilde render eder ve sonucu PNG olarak kaydeder:

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

`1` faktörü o ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` verilirse, genişlik ve yükseklik yaklaşık olarak iki katına çıkar ve piksel sayısı dört katına yükselir. Daha büyük faktörler, yakınlaştırma veya yüksek çözünürlüklü çıktı için metni genellikle daha keskin yapar, ancak bellek kullanımını ve dosya boyutunu artırır. `1`’in altındaki faktörler daha az detaylı, daha küçük görüntüler üretir. En-boy oranını korumak için faktörleri eşit tutun; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

[Shape.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/) ile bütün bir şekli render etmek, çıktının şeklin doldurması, kenarlığı veya diğer görsel bağlamını içermesi gerektiğinde hâlâ yararlıdır. Sadece paragrafın görüntüsü için `Paragraph.get_image` kullanın.

## **SSS**

**Bir metin çerçevesi içinde satır sarmalamayı tamamen devre dışı bırakabilir miyim?**

Evet. [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/wrap_text/) özelliğini `False` yaparak sarmalamayı kapatabilirsiniz; böylece satırlar metin çerçevesinin kenarlarında kesilmez.

**Belirli bir paragrafın slayt üzerindeki kesin sınırlarını nasıl alabilirim?**

[Paragraph.get_rect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/get_rect/) metodunu kullanarak paragrafın sınırlayıcı dikdörtgenini elde edebilirsiniz. [Portion.get_rect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/get_rect/) ise tek bir bölümün sınırlarını verir.

**Paragraf hizalaması (sol, sağ, ortala veya iki yana yasla) nerede kontrol edilir?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/alignment/) paragraf‑seviyesi bir ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

**Paragrafın bir kısmı için denetleme dilini ayarlayabilir miyim?**

Evet. Bireysel bölümlere [PortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/language_id/) atayarak bir paragrafta birden çok dilde metin bulunmasını sağlayabilirsiniz.