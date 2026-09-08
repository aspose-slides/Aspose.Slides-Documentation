---
title: Sunumlarınızı Python’da AutoFit ile Geliştirin
linktitle: AutoFit Ayarları
type: docs
weight: 30
url: /tr/python-java/manage-autofit-settings/
keywords:
  - metin kutusu
  - otomatik sığdırma
  - otomatik sığdırma yapma
  - metni uydur
  - metni küçült
  - metni kaydır
  - şekli yeniden boyutlandır
  - PowerPoint
  - OpenDocument
  - sunum
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java'da AutoFit ayarlarını nasıl yöneteceğinizi öğrenerek PowerPoint ve OpenDocument sunumlarınızdaki metin görüntüsünü optimize edin ve içerik okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde, Microsoft PowerPoint metin kutusu için **Resize shape to fix text** ayarını kullanır—metnin her zaman içine sığmasını sağlamak için metin kutusunu otomatik olarak yeniden boyutlandırır. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Metin kutusundaki metin uzun ya da büyük olduğunda, PowerPoint metin kutusunu otomatik olarak genişletir—yüksekliğini artırır—daha fazla metin tutmasını sağlar. 
* Metin kutusundaki metin kısa ya da küçük olduğunda, PowerPoint metin kutusunu otomatik olarak küçültür—yüksekliğini azaltır—gereksiz boşluğu temizler. 

PowerPoint'te, bir metin kutusunun otomatik sığdırma davranışını kontrol eden 4 önemli parametre veya seçenek şunlardır: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java, sunumlarda metin kutularının otomatik sığdırma davranışını kontrol etmenizi sağlayan, [TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfı altında bulunan bazı özellikler gibi benzer seçenekler sunar. 

## **Şekli Metne Uydurmak İçin Yeniden Boyutlandır**

Bir kutudaki metnin, metinde yapılan değişikliklerden sonra her zaman o kutuya sığmasını istiyorsanız, **Resize shape to fix text** seçeneğini kullanmalısınız. Bu ayarı belirtmek için, [setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType) yöntemini ([TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfından) [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textautofittype/#Shape) ile birlikte kullanın. 

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda metnin her zaman kutusuna sığmasını nasıl belirteceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metin daha uzun veya büyük olursa, metin kutusu otomatik olarak yeniden boyutlandırılır (yüksekliği artar) ve tüm metnin içine sığması sağlanır. Metin daha kısa olursa, tersine işlem gerçekleşir. 

## **Do Not Autofit**

Bir metin kutusunun veya şeklinin, içerdiği metin değişse bile boyutlarını korumasını istiyorsanız, **Do not Autofit** seçeneğini kullanmalısınız. Bu ayarı belirtmek için, [setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType) yöntemini ([TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfından) [None](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textautofittype/#None) ile birlikte kullanın. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda metin kutusunun boyutlarını her zaman korumasını nasıl belirteceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metin kutusunun kutusuna sığamayacak kadar uzun olduğunda, metin dışarı taşar. 

## **Shrink Text on Overflow**

Metin bir kutunun kutusuna sığamayacak kadar uzun olduğunda, **Shrink text on overflow** seçeneği ile metnin boyutunun ve aralığının küçültülerek kutuya sığmasını belirtebilirsiniz. Bu ayarı belirtmek için, [setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType) yöntemini ([TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfından) [Normal](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textautofittype/#Normal) ile birlikte kullanın. 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda metnin taşma durumunda küçültülmesini nasıl belirteceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
**Shrink text on overflow** seçeneği kullanıldığında, ayar yalnızca metin kutusuna sığamayacak kadar uzun olduğunda uygulanır. 
{{% /alert %}}

## **Wrap Text**

Metin bir şeklin sınırını (yalnızca genişlik) aştığında, metnin şekil içinde satır sonuna sarılmasını istiyorsanız, **Wrap text in shape** parametresini kullanmalısınız. Bu ayarı belirtmek için, [setWrapText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setWrapText) yöntemini ([TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfından) [NullableBool.True](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/#True) ile birlikte kullanmanız gerekir. 

Bu Python kodu, bir PowerPoint sunumunda Wrap Text ayarını nasıl kullanacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
[setWrapText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setWrapText) yöntemini bir şekil için [NullableBool.False](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/#False) ile kullandığınızda, şeklin içindeki metin şeklin genişliğinden uzunlaşırsa, metin tek bir satırda şeklin sınırlarının dışına uzanır. 
{{% /alert %}}

## **FAQ**

**Metin çerçevesinin iç kenar boşlukları AutoFit'i etkiler mi?**  

Evet. Dolgu (iç kenar boşlukları) metin için kullanılabilir alanı azaltır, bu yüzden AutoFit daha erken devreye girer—yazı tipi küçülür veya şekil daha erken yeniden boyutlandırılır. AutoFit'i ayarlamadan önce kenar boşluklarını kontrol edin ve ayarlayın.  

**AutoFit manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**  

Zorunlu satır sonları yerinde kalır ve AutoFit, bunların etrafındaki yazı tipi boyutunu ve aralığını ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit'in metni ne kadar agresif küçültmesi gerektiğini genellikle azaltır.  

**Tema yazı tipini değiştirmek veya yazı tipi ikamesi tetiklemek AutoFit sonuçlarını etkiler mi?**  

Evet. Farklı glif ölçümlerine sahip bir yazı tipine ikame etmek metnin genişliğini/yüksekliğini değiştirir, bu da son yazı tipi boyutunu ve satır kaydırmayı etkileyebilir. Herhangi bir yazı tipi değişikliği veya ikamesi sonrasında slaytları yeniden kontrol edin.