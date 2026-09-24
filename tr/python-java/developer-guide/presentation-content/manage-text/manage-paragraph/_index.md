---
title: Python üzerinden Java ile PowerPoint Metin Paragraflarını Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- asmalı girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'ye
- paragrafı HTML'ye
- paragrafı görsele
- metni görsele
- paragrafı dışa aktar
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile paragraf, bölüm, madde işareti, numaralı listeler, girintiler, HTML içeriği ve paragraf görselleri oluşturma ve biçimlendirme yöntemlerini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) bir şekil içindeki metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf düzeyinde biçimlendirmeye erişim sağlar.
* [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) bir paragraftaki metin koşusunu temsil eder. Her bölüm kendi metnine ve karakter düzeyinde biçimlendirmeye sahip olabilir.

Bu sayede bir paragraf, birden çok bölüm kullanarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metinler içerebilir.

## **Paragrafları Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm İçeren Paragraflar Oluşturma**

Aşağıdaki adımlar, her biri üç bölüm içeren üç paragrafla bir metin çerçevesi oluşturur:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks aracılığıyla erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki tane daha [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) nesnesi ekleyin.
6. Her paragrafın üç bölüm içerecek şekilde yeterli sayıda [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.
7. Her bölümün metnini ayarlayın.
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getPortionFormat) aracılığıyla karakter düzeyinde biçimlendirme uygulayın.
9. Değiştirilen sunumu kaydedin.

Bu Python örneği adımları uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Madde İşaretli ve Numaralı Listeler Oluşturma**

### **Madde İşaretli veya Numaralı Bir Liste Oluşturma**

Madde işaretleri ve numaralar, ilgili öğelerin taranmasını kolaylaştırır. Aspose.Slides’te liste ayarları, [BulletFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bulletformat/) aracılığıyla tanımlanır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks aracılığıyla erişin.
3. Seçilen slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin.
5. Metin çerçevesinden varsayılan paragrafı kaldırın.
6. Bir sembol madde işareti için bir [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) oluşturun.
7. [BulletFormat.setType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bulletformat/#setType) öğesini [BulletType.Symbol](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bullettype/#Symbol) olarak ayarlayın ve madde işareti karakterini belirtin.
8. Paragraf metnini, girintisini, madde işareti rengini ve yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. İkinci bir paragraf oluşturun ve [BulletFormat.setType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bulletformat/#setType) öğesini [BulletType.Numbered](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bullettype/#Numbered) olarak ayarlayın.
11. Numaralı madde işareti stilini yapılandırın ve paragrafı metin çerçevesine ekleyin.
12. Sunumu kaydedin.

Bu Python örneği bir sembol madde işareti ve bir numaralı madde işareti oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Resim Madde İşaretleri Kullanma**

Resim madde işaretleri, bir sembol veya sayı yerine özel bir görsel kullanmanıza olanak tanır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks aracılığıyla erişin.
3. Bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin ve onun [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin.
4. Metin çerçevesinden varsayılan paragrafı kaldırın.
5. Madde işareti görselini yükleyin ve sunumun resim koleksiyonuna bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [BulletFormat.setType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bulletformat/#setType) öğesini [BulletType.Picture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bullettype/#Picture) olarak ayarlayın.
8. Görseli [BulletFormat.getPicture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bulletformat/#getPicture) aracılığıyla atayın ve madde işareti yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. Değiştirilen sunumu kaydedin.

Bu Python örneği bir resim madde işareti oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Çok Seviyeli Bir Liste Oluşturma**

Paragrafları bir listenin farklı seviyelerinde konumlandırmak için [ParagraphFormat.setDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setDepth) ayarlayın. Üst seviye derinliği `0` dır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin ve varsayılan paragrafı metin çerçevesinden temizleyin.
3. Dört paragraf oluşturun ve madde işareti sembollerini yapılandırın.
4. Bu paragrafların [ParagraphFormat.setDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setDepth) değerlerini sırasıyla `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Python örneği dört seviyeli bir madde işaretli liste oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Numaralı Liste Öğelerini Özel Değerlerle Başlatma**

Numaralı bir paragraf için görüntülenen ilk sayıyı ayarlamak üzere [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) kullanın.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) oluşturun ve bir slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
2. Şeklin metin çerçevesinden varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. İlgili paragraflar için [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) değerlerini sırasıyla `2`, `3` ve `7` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Python örneği her paragraf için özel bir başlangıç sayısı atar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Paragraf Düzeni ve Son Özelliklerini Kontrol Etme**

### **İlk Satır Girintisi Ayarlama**

Paragrafın ilk satır girintisini kontrol etmek için [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setIndent) kullanın. Bu metod yalnızca ilk satırı paragrafın sol kenar boşluğuna göre hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı hareket ettirmeniz gerektiğinde [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setMarginLeft) kullanın. Yalnızca ilk satırı taşımak istediğinizde [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setIndent) kullanın.

Aşağıdaki örnek, çeşitli paragraflar oluşturur ve farklı [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setIndent) değerleri uygulayarak ilk satır girintisinin paragraf düzenini nasıl etkilediğini gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Çeşitli paragraflar oluşturun ve onlara farklı [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setIndent) değerleri atayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilen sunumu kaydedin.

Bu kod, bir paragraf girintisinin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

### **Asma Girinti Ayarlama**

Asma girinti, ilk satırın kalan satırlardan daha sola başlaması şeklinde bir paragraf düzenidir. Aspose.Slides’te bu etkiyi [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setIndent) ile oluşturursunuz. İlk satırı paragraf gövdesine göre sola kaydırmak için negatif bir değer geçirin.

Uygulamada, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setMarginLeft) paragraf gövdesinin sol konumunu tanımlar ve [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setIndent) ilk satırın bu kenar boşluğuna göre konumunu belirler. Asma girinti oluşturmak için [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setMarginLeft)’e pozitif bir değer, [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setIndent)’e ise negatif bir değer verin.

Bu biçimlendirme, bibliyografiler, referanslar, sözlük girişleri ve satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Her paragraf için [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setMarginLeft)’e pozitif bir değer atayın.
6. Asma girinti etkisini oluşturmak için [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setIndent)’e negatif bir değer verin.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilen sunumu kaydedin.

Bu kod, bir paragraf için asma girinti nasıl ayarlanır gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Paragrafların asma girintisi](hanging_indent.png)

### **Paragraf Sonu Çalıştırma Özelliklerini Ayarlama**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat), paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek, ikinci paragrafın son işaretine bir yazı tipi boyutu ve Latin yazı tipi atar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yükleyin ve bir slayta erişin.
2. Bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin ve varsayılan paragrafını temizleyin.
3. İki paragraf oluşturun ve onlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) oluşturun.
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setFontHeight) ve [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLatinFont) ayarlayın.
6. Formatı [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) ile atayın ve sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Çizilen Satırları Sayma**

[Paragraph.getLinesCount](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#getLinesCount) kullanarak bir paragrafın metin yerleşimi sonrası kapladığı satır sayısını, otomatik sarmalamayı da dahil ederek sayabilirsiniz. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken faydalıdır.

Bir paragraf, [TextFrame.getParagraphs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getParagraphs) içinde bir öğedir ve birden çok çizilen satır kaplayabilir. Paragraf içinde açık bir satır sonu karakteri, yeni bir paragraf oluşturmadan yeni bir satır oluşturur. Otomatik sarmalama, metni bölmeden mevcut genişliğe göre satırlar üretir. Bu nedenle paragraf sayısı veya satır sonu karakteri saymak, gerçek çizilen satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Sarmalama etkinleştirilir ve otomatik sığdırma devre dışı bırakılır; böylece şekil genişliği sarmalamayı kontrol eder, metin otomatik olarak küçülmez veya şekil yeniden boyutlandırılmaz. Şekil boyutları puan cinsindendir. Son olarak örnek, bir başka paragraf ekler ve metin çerçevesi üzerindeki satır sayılarını toplar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

Bu metin ve bu boyutlarla, şekli daraltmak satır sayısını artırırken, kısa dizeyle değiştirmek azaltır. Kesin sayılar, kullanılan yazı tipine, yazı tipi boyutuna, kenar boşluklarına, girintiye, sarmalamaya ve otomatik sığdırma ayarlarına bağlı olarak değişebilir. Şablonu kontrol ederken hedef ortam için planlanan yazı tiplerini ve yerleşim ayarlarını kullanın.

Satır sayısı yalnız başına metnin kapsayıcısını aşıp aşmadığını belirlemez. Kullanılabilir yükseklik, satır yükseklikleri, paragraf ve satır aralıkları ve otomatik sığdırma davranışı da önemlidir; sarmalama devre dışı bırakıldığında tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçe/Dışa Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürmek için [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphcollection/#addFromHtml) kullanın.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Bir slayta erişin ve bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
3. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dosyasını okuyun.
5. HTML dizesini [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphcollection/#addFromHtml) metoduna gönderin.
6. Değiştirilen sunumu kaydedin.

Bu Python örneği HTML’i bir metin çerçevesine aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Paragraf Metnini HTML’ye Dışa Aktarma**

Seçilen bir paragraf aralığını HTML olarak dışa aktarmak için [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphcollection/#exportToHtml) kullanın.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun ve istediğiniz sunumu yükleyin.
2. Slayta erişin ve metni içeren [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) öğesini bulun.
3. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin.
4. Başlangıç paragrafı indeksi ve dışa aktarılacak paragraf sayısını belirterek [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphcollection/#exportToHtml) metodunu çağırın.
5. Dönen HTML dizesini bir dosyaya yazın.

Bu Python örneği ilk metin şeklinin tüm paragraflarını dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Paragrafı Görüntü Olarak Oluşturma**

[Paragraph.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) tek bir paragrafı doğrudan işler ve bir görüntü nesnesi döndürür. Sonucu `save` yöntemiyle bir dosyaya veya akışa kaydedebilirsiniz. İçeren şekli render etmenize veya bir bitmap’i manuel olarak kırpmanıza gerek yoktur.

[Paragraph.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) paragraf, üst koleksiyonunda bulunamazsa, geçerli bir render alanı yoksa veya render edilemezse `None` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve kullanım sonrası döndürülen görüntüyü serbest bırakın.

#### **Varsayılan Ölçekte Bir Paragrafı Oluşturma**

sample.pptx adlı bir sunum dosyamız olduğunu ve bir slayt içerdiğini varsayalım; ilk şekil üç paragraf içeren bir metin kutusudur.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, ikinci paragrafı normal bir metin şekli içinde varsayılan ölçekte oluşturur ve PNG formatında kaydeder. `finally` bloğu, görüntünün doğru şekilde serbest bırakılmasını sağlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Sonuç:

![Paragraf görüntüsü](paragraph_to_image_output.png)

#### **Bir Tablo Hücresinde Ölçeklendirilmiş Paragraf Oluşturma**

Yatay ve dikey ölçek faktörlerini ayarlamak için `scale_x` ve `scale_y` parametrelerini kabul eden [Paragraph.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) aşırı yüklemesini kullanın. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişlik ve yüksekliğinin iki katı olarak render eder ve sonucu PNG olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

`1` ölçek faktörü o ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` girilirse, genişlik ve yükseklik yaklaşık olarak iki katına çıkar ve piksel sayısı dört katına çıkar. Büyük faktörler, yakınlaştırma veya yüksek çözünürlüklü çıktılar için metni daha keskin yapar, ancak bellek kullanımını ve dosya boyutunu artırır. `1`’in altındaki faktörler daha az ayrıntılı, daha küçük görüntüler üretir. Paragrafın en boy oranını korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

[Shape.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) ile bütün bir şekli render etmek, çıktının şeklin dolgu, kenarlık veya diğer görsel bağlamını içermesi gerektiğinde yararlıdır. Sadece paragraf görüntüsü için [Paragraph.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) kullanın.

## **SSS**

**Bir metin çerçevesinde satır sarmalamasını tamamen devre dışı bırakabilir miyim?**

Evet. Satırların metin çerçevesinin kenarlarında kırılmaması için sarmalamayı devre dışı bırakmak üzere [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setWrapText) ayarlayın.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl elde edebilirim?**

Paragrafın sınırlayıcı dikdörtgenini almak için [Paragraph.getRect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#getRect) kullanın. Tek bir bölümün sınırlarını elde etmek için [Portion.getRect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getRect) kullanın.

**Paragraf hizalaması (sol, sağ, orta veya iki taraflı) nerede kontrol edilir?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setAlignment) bir paragraf düzeyi ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

**Paragrafın bir kısmı için doğrulama dili ayarlayabilir miyim?**

Evet. Bireysel bölümler için [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId) ayarlayarak bir paragrafta birden fazla dilde metin bulunmasını sağlayabilirsiniz.