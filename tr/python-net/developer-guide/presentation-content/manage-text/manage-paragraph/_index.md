---
title: Python'da PowerPoint Metin Paragraflarını Yönet
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/python-net/manage-paragraph/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- asılı girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'ye
- paragrafı HTML'ye
- paragrafı görüntüye
- metni görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ve .NET ile paragraf biçimlendirmesinde uzmanlaşın—PowerPoint ve OpenDocument sunumlarında hizalama, boşluk ve stili optimize ederek izleyicileri etkileyin."
---
## **Giriş**

Aspose.Slides, Python'da PowerPoint metniyle çalışmak için gereken sınıfları sağlar.

* Aspose.Slides, metin çerçevesi nesneleri oluşturmak için [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) sınıfını sağlar. Bir `TextFrame` nesnesi bir veya daha fazla paragraf içerebilir (her paragraf bir satır sonu ile ayrılır).
* Aspose.Slides, paragraf nesneleri oluşturmak için [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfını sağlar. Bir `Paragraph` nesnesi bir veya daha fazla metin bölümü içerebilir.
* Aspose.Slides, metin bölümü nesneleri oluşturmak ve biçimlendirme özelliklerini belirtmek için [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) sınıfını sağlar.

`Paragraph` nesnesi, altta yatan `Portion` nesneleri aracılığıyla farklı biçimlendirme özelliklerine sahip metni işleyebilir.

## **Çoklu Bölümler İçeren Çoklu Paragraflar Ekle**

Bu adımlar, her biri üç bölüm içeren üç paragraf içeren bir metin çerçevesi eklemenin yolunu gösterir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef slayta indeksine göre bir referans alın.
1. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ile ilişkili [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) alın.
1. İki [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) nesnesi oluşturun ve bunları [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) nesnesinin paragraf koleksiyonuna ekleyin (varsayılan paragrafla birlikte bu üç paragraf verir).
1. Her paragraf için üç [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) nesnesi oluşturun ve bu paragrafın bölüm koleksiyonuna ekleyin.
1. Her bölüm için metni ayarlayın.
1. İstenilen biçimlendirmeyi, [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) tarafından sunulan özellikleri kullanarak her metin bölümüne uygulayın.
1. Değiştirilen sunumu kaydedin.

Aşağıdaki Python kodu bu adımları uygular:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Yeni bir PPTX dosyası oluşturmak için Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Bir dikdörtgen AutoShape ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # AutoShape'ın TextFrame'ine erişin.
    text_frame = shape.text_frame

    # Paragrafları ve bölümleri oluşturun; biçimlendirme aşağıda uygulanır.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # PPTX'i diske kaydedin.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Paragraf Madde İşaretlerini Yönet**

Madde işaretli listeler, bilgiyi hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Madde işaretli paragraflar genellikle daha okunaklı ve anlaşılırdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre hedef slayta erişin.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesine erişin.
1. Varsayılan paragrafı [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinden kaldırın.
1. İlk paragrafı [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfını kullanarak oluşturun.
1. Paragrafın madde işareti tipini `SYMBOL` olarak ayarlayın ve madde işareti karakterini belirtin.
1. Paragrafın metnini ayarlayın.
1. Paragraf için madde işareti girintisini ayarlayın.
1. Madde işareti rengini ayarlayın.
1. Madde işareti boyutunu (yüksekliğini) ayarlayın.
1. Paragrafı [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/)'in paragraf koleksiyonuna ekleyin.
1. İkinci paragrafı ekleyin ve adım 7–12'yi tekrarlayın.
1. Sunumu kaydedin.

Bu Python kodu, madde işaretli paragrafların nasıl eklenileceğini gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum örneği oluştur.
with slides.Presentation() as presentation:

    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Bir AutoShape ekleyin ve ona erişin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Oluşturulan AutoShape'ın metin çerçevesine erişin.
    text_frame = shape.text_frame

    # Varsayılan paragrafı kaldırın.
    text_frame.paragraphs.remove_at(0)

    # Bir paragraf oluşturun.
    paragraph = slides.Paragraph()

    # Paragrafın madde işareti stilini ve simgesini ayarlayın.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Paragraf metnini ayarlayın.
    paragraph.text = "Welcome to Aspose.Slides"

    # Madde işareti girintisini ayarlayın.
    paragraph.paragraph_format.indent = 25

    # Madde işareti rengini ayarlayın.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Madde işareti yüksekliğini ayarlayın.
    paragraph.paragraph_format.bullet.height = 100

    # Paragrafı metin çerçevesine ekleyin.
    text_frame.paragraphs.add(paragraph)

    # İkinci paragrafı oluşturun.
    paragraph2 = slides.Paragraph()

    # Paragrafın madde işareti tipini ve stilini ayarlayın.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Paragraf metnini ayarlayın.
    paragraph2.text = "This is numbered bullet"

    # Madde işareti girintisini ayarlayın.
    paragraph2.paragraph_format.indent = 25

    # Madde işareti rengini ayarlayın.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Madde işareti yüksekliğini ayarlayın.
    paragraph2.paragraph_format.bullet.height = 100

    # Paragrafı metin çerçevesine ekleyin.
    text_frame.paragraphs.add(paragraph2)

    # Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Resimli Madde İşaretlerini Yönet**

Madde işaretli listeler, bilgiyi hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Resimli madde işaretleri okunması ve anlaşılması kolaydır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre hedef slayta erişin.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesine erişin.
1. Varsayılan paragrafı [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinden kaldırın.
1. İlk paragrafı [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfını kullanarak oluşturun.
1. Bir görüntüyü [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) içine yükleyin.
1. Madde işareti tipini [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) olarak ayarlayın ve görüntüyü atayın.
1. Paragraf metnini ayarlayın.
1. Madde işareti için paragraf girintisini ayarlayın.
1. Madde işareti rengini ayarlayın.
1. Madde işareti yüksekliğini ayarlayın.
1. Yeni paragrafı [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/)'in paragraf koleksiyonuna ekleyin.
1. İkinci paragrafı ekleyin ve adım 8–12'yi tekrarlayın.
1. Sunumu kaydedin.

Bu Python kodu, resimli madde işaretlerinin nasıl eklenip yönetileceğini gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # İlk slayta eriş.
    slide = presentation.slides[0]

    # Madde işareti görüntüsünü yükle.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Bir AutoShape ekle ve ona eriş.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Oluşturulan AutoShape'ın TextFrame'ine eriş.
    text_frame = auto_shape.text_frame

    # Varsayılan paragrafı kaldır.
    text_frame.paragraphs.remove_at(0)

    # Yeni bir paragraf oluştur.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Paragrafın madde işareti tipini Resim olarak ayarla ve görüntüyü ata.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Madde işareti yüksekliğini ayarla.
    paragraph.paragraph_format.bullet.height = 100

    # Paragrafı metin çerçevesine ekle.
    text_frame.paragraphs.add(paragraph)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Sunumu PPT dosyası olarak kaydet.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Çok Düzeyli Madde İşaretlerini Yönet**

Madde işaretli listeler, bilgiyi hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Çok düzeyli madde işaretleri okunması ve anlaşılması kolaydır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre hedef slayta erişin.
1. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/)'in [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesine erişin.
1. Varsayılan paragrafı [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinden kaldırın.
1. İlk paragrafı [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfını kullanarak oluşturun ve derinliğini 0 olarak ayarlayın.
1. İkinci paragrafı [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfını kullanarak oluşturun ve derinliğini 1 olarak ayarlayın.
1. Üçüncü paragrafı [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfını kullanarak oluşturun ve derinliğini 2 olarak ayarlayın.
1. Dördüncü paragrafı [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfını kullanarak oluşturun ve derinliğini 3 olarak ayarlayın.
1. Yeni paragrafları [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/)'in paragraf koleksiyonuna ekleyin.
1. Sunumu kaydedin.

Aşağıdaki Python kodu, çok düzeyli madde işaretlerinin nasıl eklenip yönetileceğini gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum örneği oluştur.
with slides.Presentation() as presentation:

    # İlk slayta eriş.
    slide = presentation.slides[0]
    
    # Bir AutoShape ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Oluşturulan AutoShape'ın TextFrame'ine eriş.
    text_frame = auto_shape.text_frame
    
    # Varsayılan paragrafı temizle.
    text_frame.paragraphs.clear()

    # İlk paragrafı ekle.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Madde işareti seviyesini ayarla.
    paragraph1.paragraph_format.depth = 0

    # İkinci paragrafı ekle.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Madde işareti seviyesini ayarla.
    paragraph2.paragraph_format.depth = 1

    # Üçüncü paragrafı ekle.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Madde işareti seviyesini ayarla.
    paragraph3.paragraph_format.depth = 2

    # Dördüncü paragrafı ekle.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Madde işareti seviyesini ayarla.
    paragraph4.paragraph_format.depth = 3

    # Paragrafları koleksiyona ekle.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Numaralı Listelerle Paragrafları Yönet**

[BulletFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/bulletformat/) sınıfı, paragraflar için özel numaralandırma ve biçimlendirmeyi kontrol etmek amacıyla `numbered_bullet_start_with` özelliğini (ve diğerlerini) sağlar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Paragrafların bulunacağı slayta erişin.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesine erişin.
1. Varsayılan paragrafı [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinden kaldırın.
1. İlk [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) nesnesini oluşturun ve `numbered_bullet_start_with` değerini 2 olarak ayarlayın.
1. İkinci [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) nesnesini oluşturun ve `numbered_bullet_start_with` değerini 3 olarak ayarlayın.
1. Üçüncü [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) nesnesini oluşturun ve `numbered_bullet_start_with` değerini 7 olarak ayarlayın.
1. Paragrafları [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/)'in koleksiyonuna ekleyin.
1. Sunumu kaydedin.

Aşağıdaki Python kodu, özel numaralandırma ve biçimlendirme ile paragrafların nasıl eklenip yönetileceğini gösterir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape ekleyin ve ona erişin.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Oluşturulan AutoShape'ın TextFrame'ine erişin.
    text_frame = shape.text_frame

    # Varsayılan mevcut paragrafı kaldır.
    text_frame.paragraphs.remove_at(0)

    # İlk numaralı öğeyi oluştur (2'den başla, derinlik seviyesi 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # İkinci numaralı öğeyi oluştur (3'ten başla, derinlik seviyesi 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Üçüncü numaralı öğeyi oluştur (7'den başla, derinlik seviyesi 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Paragraf İçin İlk Satır Girintisini Ayarlama**

[ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) özelliğini kullanarak bir paragrafın ilk satır girintisini kontrol edebilirsiniz. Bu özellik sadece ilk satırı paragrafın sol kenar boşluğuna göre hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak istediğinizde [ParagraphFormat.margin_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/margin_left/) kullanın. Sadece ilk satırı taşımak istediğinizde ise [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) kullanın.

Aşağıdaki örnek, birkaç paragraf oluşturur ve farklı `indent` değerleri uygulayarak ilk satır girintisinin paragraf düzenine etkisini gösterir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Birçok paragraf oluşturun ve onlar için farklı [indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilen sunumu kaydedin.

Bu kod, bir paragraf girintisinin nasıl ayarlanacağını gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

## **Bir Paragraf İçin Asılı Girinti Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'de bu etkiyi [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) özelliğiyle oluşturursunuz. `indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırırsınız.

Uygulamada, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/margin_left/) paragraf gövdesinin sol konumunu tanımlar ve [ParagraphFormat.indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) bu kenar boşluğuna göre ilk satırın konumunu belirler. Asılı girinti oluşturmak için pozitif bir `margin_left` değeri ve negatif bir `indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografyalar, referanslar, sözlük girişleri ve satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için kullanışlıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için pozitif bir [margin_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/margin_left/) değeri ayarlayın.
6. Asılı girinti etkisini oluşturmak için negatif bir [indent](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/indent/) değeri ayarlayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilen sunumu kaydedin.

Bu kod, bir paragraf için asılı girintinin nasıl ayarlanacağını gösterir:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragrafların asılı girintisi](hanging_indent.png)

## **Paragraf Sonu Bölüm Biçimini Yönet**

Bir paragrafın “son” kısmının (son metin bölümünden sonra uygulanan biçimlendirme) stilini kontrol etmeniz gerektiğinde, `end_paragraph_portion_format` özelliğini kullanın. Aşağıdaki örnek, ikinci paragrafın sonuna daha büyük bir Times New Roman yazı tipi uygular.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) dosyası oluşturun veya açın.
2. İndeksine göre hedef slaytı alın.
3. Slayta bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesini kullanın ve iki paragraf oluşturun.
5. 48 punto Times New Roman olarak ayarlanmış bir [PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) oluşturun ve paragrafın son-paragraf bölüm biçimi olarak uygulayın.
6. Bunu paragrafın `end_paragraph_portion_format` özelliğine atayın (ikinci paragrafın sonuna uygulanır).
7. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, ikinci paragraf için paragraf sonu biçimlendirmesinin nasıl ayarlanacağını gösterir:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **HTML Metnini Paragraflara İçe Aktarma**

Aspose.Slides, HTML metnini paragraflara içe aktarmak için geliştirilmiş destek sağlar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. İndeksine göre hedef slayta erişin.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/)'in [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesine erişin.
5. Varsayılan paragrafı [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinden kaldırın.
6. Kaynak HTML dosyasını okuyun.
7. İlk paragrafı [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfını kullanarak oluşturun.
8. HTML içeriğini [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/)'in paragraf koleksiyonuna ekleyin.
9. Değiştirilen sunumu kaydedin.

Aşağıdaki Python kodu, HTML metninin paragraflara nasıl içe aktarılacağını uygular.

```python
import aspose.slides as slides

# Boş bir Presentation örneği oluştur.
with slides.Presentation() as presentation:

    # Sunumun ilk slaytına eriş.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # HTML içeriğini barındıracak bir AutoShape ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Eklenen metin çerçevesindeki tüm paragrafları temizle.
    shape.text_frame.paragraphs.clear()

    # HTML dosyasını yükle.
    with open("file.html", "rt") as html_stream:
        # HTML dosyasındaki metni metin çerçevesine ekle.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Sunumu kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Paragraf Metnini HTML'ye Dışa Aktarma**

Aspose.Slides, metni HTML'ye dışa aktarmak için geliştirilmiş destek sağlar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun ve hedef sunumu yükleyin.
2. İstenen slayta indeksine göre erişin.
3. Dışa aktarılacak metni içeren şekli seçin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesine erişin.
5. HTML çıktısını yazmak için bir dosya akışı açın.
6. Başlangıç indeksini belirleyin ve gereken paragrafları dışa aktarın.

```python
import aspose.slides as slides

# Sunum dosyasını yükle.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Sunumun ilk slaytına eriş.
    slide = presentation.slides[0]

    # Hedef şekil indeksi.
    index = 0

    # Şekle indeks ile eriş.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Paragraf verilerini HTML'ye, başlangıç paragraf indeksi ve dışa aktarılacak toplam paragraf sayısını sağlayarak yaz.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Bir Paragrafı Görüntü Olarak Kaydet**

Bu bölümde, [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) sınıfı ile temsil edilen bir metin paragrafını görüntü olarak kaydetmeyi gösteren iki örnek keşfedeceğiz. Her iki örnek de, paragrafı içeren şeklin görüntüsünü [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfının `get_image` yöntemleriyle elde etmeyi, paragrafın şekil içindeki sınırlarını hesaplamayı ve bunu bir bitmap görüntüsü olarak dışa aktarmayı içerir. Bu yaklaşımlar, PowerPoint sunumlarından belirli metin parçalarını ayıklayıp ayrı görüntüler olarak kaydetmenize olanak tanır; böylece çeşitli senaryolarda yeniden kullanılabilirler.

sample.pptx adlı bir sunum dosyamızın bir slaytı olduğunu ve ilk şeklinin üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

**Example 1**

Bu örnekte ikinci paragrafı bir görüntü olarak elde ediyoruz. Bunun için sunumun ilk slaydındaki şeklin görüntüsünü çıkarıp ardından şeklin metin çerçevesindeki ikinci paragrafın sınırlarını hesaplıyoruz. Paragraf daha sonra yeni bir bitmap görüntüsüne yeniden çizilir ve PNG formatında kaydedilir. Bu yöntem, belirli bir paragrafı ayrı bir görüntü olarak kaydetmek ve metnin tam boyutları ve biçimlendirmesini korumak istediğinizde özellikle yararlıdır.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Şekli bellekte bitmap olarak kaydet.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Bellekten bir şekil bitmap'i oluştur.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # İkinci paragrafın sınırlarını hesapla.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Çıktı görüntüsü için koordinatları ve boyutu hesapla (minimum boyut - 1x1 piksel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Paragraf bitmap'ini yalnızca almak için şekil bitmap'ini kırp.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Sonuç:

![Paragraf resmi](paragraph_to_image_output.png)

**Example 2**

Bu örnek, önceki yaklaşımı paragraf görüntüsüne ölçek faktörleri ekleyerek genişletir. Şekil sunumdan çıkarılır ve `2` ölçek faktörüyle bir görüntü olarak kaydedilir. Bu, paragrafı dışa aktarırken daha yüksek çözünürlük elde etmenizi sağlar. Paragraf sınırları, ölçeği göz önünde bulundurarak hesaplanır. Ölçekleme, daha ayrıntılı bir görüntü gerektiğinde, örneğin yüksek kaliteli basılı materyallerde kullanıldığında faydalı olabilir.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Şekli bellekte bitmap olarak kaydet.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Bellekten bir şekil bitmap'i oluştur.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # İkinci paragrafın sınırlarını hesapla.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Çıktı görüntüsü için koordinatları ve boyutu hesapla (minimum boyut - 1x1 piksel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Paragraf bitmap'ini yalnızca almak için şekil bitmap'ini kırp.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**Bir metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Satır kaydırmayı kapatmak için metin çerçevesinin kaydırma ayarını ([wrap_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/wrap_text/)) kullanın; böylece satırlar çerçevenin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**

Paragrafın (ve hatta tek bir bölümün) sınırlayıcı dikdörtgenini alarak konumunu ve boyutunu tam olarak öğrenebilirsiniz.

**Paragraf hizalaması (sol/sağ/ortala/iki yana yasla) nerede kontrol edilir?**

[Alignment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/alignment/) bir paragraf seviyesindeki ayardır ve [ParagraphFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/) içinde bulunur; bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

**Bir paragrafın sadece bir kısmı (ör. bir kelime) için yazım denetimi dili ayarlayabilir miyim?**

Evet. Dil, bölüm seviyesinde ([PortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/language_id/)) ayarlanır; böylece tek bir paragrafta birden fazla dil aynı anda bulunabilir.