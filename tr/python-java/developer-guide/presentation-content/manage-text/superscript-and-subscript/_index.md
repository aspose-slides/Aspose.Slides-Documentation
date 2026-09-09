---
title: Python üzerinden Java ile Sunumlarda Üst Simge ve Alt Simgeyi Yönetme
linktitle: Üst Simge ve Alt Simge
type: docs
weight: 80
url: /tr/python-java/superscript-and-subscript/
keywords:
- üst simge
- alt simge
- üst simge ekle
- alt simge ekle
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile Aspose.Slides'te üst simge ve alt simgeyi ustalaşın ve sunumlarınızı en yüksek etki için profesyonel metin biçimlendirmesiyle yükseltin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarınıza üst simge ve alt simge metni ekleme özellikleri sunar. Kimyasal formülleri, matematiksel denklemleri vurgulamanız ya da içeriği dipnotlarla açıklamanız gerektiğinde, bu özel biçimlendirme seçenekleri netlik ve kesinlik sağlar. Bu makalede, üst simge ve alt simge stillerini sorunsuz bir şekilde nasıl uygulayacağınızı ve her slaytta profesyonel sonuçlar elde edeceğinizi öğreneceksiniz.

## **Üst Simge ve Alt Simge Metnini Yönetme**

Üst simge ve alt simge metnini bir paragrafın herhangi bir kısmına ekleyebilirsiniz. Aspose.Slides metin çerçevesinde bu biçimlendirmeyi uygulamak için [PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) sınıfının [setEscapement](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#setEscapement) metodunu kullanın.

Escapement değeri -%100 (alt simge) ile %100 (üst simge) arasında değişir. Örneğin:

- [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- Diziniyle bir slayt alın.
- Slayta [ShapeType.Rectangle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapetype/#Rectangle) türünde bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
- [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ile ilişkili [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesine erişin.
- Mevcut paragrafları temizleyin.
- Üst simge metnini tutacak bir paragraf oluşturun ve bunu metin çerçevesinin [paragraf koleksiyonu](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getParagraphs)'na ekleyin.
- Bir Portion oluşturun.
- Üst simge için (0 üst simge yok demektir) 0 ile 100 arasında bir değer ayarlamak üzere [setEscapement](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#setEscapement) kullanın.
- [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) metnini ayarlayın ve bunu paragrafın portion koleksiyonuna ekleyin.
- Alt simge metnini tutacak bir paragraf oluşturun ve bunu metin çerçevesinin [paragraf koleksiyonu](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getParagraphs)'na ekleyin.
- Bir Portion oluşturun.
- Alt simge için (0 alt simge yok demektir) -100 ile 0 arasında bir değer ayarlamak üzere [setEscapement](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#setEscapement) kullanın.
- [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) metnini ayarlayın ve bunu paragrafın portion koleksiyonuna ekleyin.
- Sunumu PPTX dosyası olarak kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Bir sunum oluştur.
presentation = Presentation()
try:
    # Slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Bir metin kutusu oluştur.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Üst simge metni için bir paragraf oluştur.
    superscript_paragraph = Paragraph()

    # Normal metin içeren bir bölüm oluştur.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Üst simge metni içeren bir bölüm oluştur.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Alt simge metni için bir paragraf oluştur.
    subscript_paragraph = Paragraph()

    # Normal metin içeren bir bölüm oluştur.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Alt simge metni içeren bir bölüm oluştur.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Paragrafları metin kutusuna ekle.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Üst simge ve alt simge PDF veya diğer formatlara aktarılırken korunur mu?**

Evet, Aspose.Slides, sunumları PDF, PPT/PPTX, görüntüler ve diğer desteklenen formatlara aktarırken üst simge ve alt simge biçimlendirmesini doğru bir şekilde korur. Özel biçimlendirme tüm çıkış dosyalarında bozulmadan kalır.

**Üst simge ve alt simge kalın veya italik gibi diğer biçimlendirme stilleriyle birleştirilebilir mi?**

Evet, Aspose.Slides, tek bir metin bölümünde çeşitli metin stillerinin karıştırılmasına izin verir. Kalın, italik, altı çizili stilleri etkinleştirebilir ve aynı anda ilgili özellikleri [PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) içinde yapılandırarak üst simge veya alt simge uygulayabilirsiniz.

**Üst simge ve alt simge biçimlendirmesi tablolar, grafikler veya SmartArt içindeki metinlerde çalışır mı?**

Evet, Aspose.Slides, tablolar ve grafik öğeleri dahil çoğu nesnede biçimlendirmeyi destekler. SmartArt ile çalışırken, uygun öğelere (örneğin [SmartArtNode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnode/)) ve metin kapsayıcılarına erişmeniz ve ardından benzer şekilde [PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) özelliklerini yapılandırmanız gerekir.