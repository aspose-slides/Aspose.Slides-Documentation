---
title: Python via Java Kullanarak Sunumlarda Yazı Tiplerini Yönetme
linktitle: Yazı Tiplerini Yönet
type: docs
weight: 10
url: /tr/python-java/manage-fonts/
keywords:
- yazı tiplerini yönet
- yazı tipi özellikleri
- paragraf
- metin biçimlendirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Python via Java’da yazı tiplerini kontrol edin: PPT, PPTX ve ODP sunumlarını net, marka güvenli ve tutarlı tutmak için özel yazı tiplerini gömün, değiştirin ve yükleyin."
---
## **Genel Bakış**

Aspose.Slides, sunum metnindeki yazı tipi özelliklerini doğrudan kodunuzdan yönetmenizi sağlar. Metni slaytlarda şekiller, metin çerçeveleri, paragraflar ve bölümler aracılığıyla erişebilir ve ardından seçili metne biçimlendirme uygulayabilirsiniz.

Bu makale, bir sunumdaki mevcut metin için yazı tipi ailesi, kalın ve italik stiller, paragraf hizalaması ve yazı tipi rengi gibi yazı tipiyle ilgili özellikleri nasıl yapılandıracağınızı açıklar. Ayrıca bir metin kutusu oluşturmayı, içine metin eklemeyi ve sonuç PPTX dosyası olarak kaydetmeden önce yazı tipi ailesi, kalın, italik, alt çizgi, yazı tipi boyutu ve renk gibi özellikleri ayarlamayı gösterir.

## **Yazı Tipiyle İlgili Özellikleri Yönetme**
{{% alert color="info" title="Not" %}} 

Sunumlar genellikle hem metin hem de görsel içerir. Metin, belirli bölümleri ve kelimeleri vurgulamak ya da kurumsal stillere uymak amacıyla çeşitli şekillerde biçimlendirilebilir. Metin biçimlendirme, kullanıcıların sunum içeriğinin görünümünü çeşitlendirmesine yardımcı olur. Bu makale, Aspose.Slides for Python via Java kullanarak slaytlardaki paragraf metinlerinin yazı tipi özelliklerini nasıl yapılandıracağınızı gösterir.

{{% /alert %}} 

Aspose.Slides for Python via Java kullanarak bir paragrafın yazı tipi özelliklerini yönetmek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slaydın başvurusunu alın.
1. Slayttaki [Placeholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholder/) şekillerine [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) olarak erişin.
1. [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) tarafından sağlanan [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) üzerinden [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) alın.
1. Paragrafı iki yana yaslayın.
1. Bir [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) öğesinin metin [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) öğesine erişin.
1. Yazı tipini [FontData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontdata/) kullanarak tanımlayın ve ilgili metin [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) **Font** özelliğini ayarlayın.
   1. Yazı tipini kalın yapın.
   1. Yazı tipini italik yapın.
1. [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) nesnesi tarafından sağlanan [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/) ile yazı tipi rengini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir. Bu örnek, süssüz bir sunumu alır ve slaytlardan birindeki yazı tiplerini biçimlendirir. Aşağıdaki ekran görüntüleri giriş dosyasını ve kod parçacıklarının nasıl değiştiğini gösterir. Kod, yazı tipini, rengini ve stilini değiştirir.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Şekil: Girdi dosyasındaki metin**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Şekil: Güncellenmiş biçimlendirmeye sahip aynı metin**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Sunumu yükle.
presentation = Presentation("FontProperties.pptx")
try:
    # İlk slayta ve ilk iki yer tutucusunun metin çerçevelerine eriş.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Her metin çerçevesindeki ilk paragrafa eriş.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Her paragraftaki ilk bölüme eriş.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Yeni yazı tiplerini tanımla ve ata.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Yazı tiplerini kalın ve italik olarak ayarla.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Yazı tipi renklerini ayarla.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Sunumu kaydet.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Metin Yazı Tipi Özelliklerini Ayarlama**
{{% alert color="info" title="Not" %}} 

**Yazı Tipiyle İlgili Özellikleri Yönetme** bölümünde belirtildiği gibi, bir [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) paragrafta benzer biçimlendirme stiline sahip metni tutmak için kullanılır. Bu makale, Aspose.Slides for Python via Java kullanarak bir metin kutusu oluşturup içine metin ekleyip belirli bir yazı tipi ve çeşitli diğer yazı tipi özelliklerini nasıl tanımlayacağınızı gösterir.

{{% /alert %}} 

Bir metin kutusu oluşturup içindeki metnin yazı tipi özelliklerini ayarlamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slaydın başvurusunu alın.
1. Slayta **Rectangle** tipinde bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
1. [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ile ilişkili doldurma stilini kaldırın.
1. [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/)'in [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin.
1. [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) içine bazı metinler ekleyin.
1. [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) ile ilişkili [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) nesnesine erişin.
1. [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) için kullanılacak yazı tipini tanımlayın.
1. [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) nesnesi tarafından sağlanan ilgili özellikleri kullanarak kalın, italik, alt çizgi, renk ve yükseklik gibi diğer yazı tipi özelliklerini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıda gösterilmiştir.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Şekil: Aspose.Slides for Python via Java kullanılarak bazı yazı tipi özellikleri ayarlanmış metin**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # İlk slaytı al ve bir dikdörtgen ekle.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Şeklin doldurmasını kaldır.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Şeklin metin çerçevesine metin ekle.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Yazı tipi ailesini ayarla.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Kalın, italik, alt çizgi ve yazı tipi boyutunu ayarla.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Yazı tipi rengini ayarla.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Sunumu kaydet.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```