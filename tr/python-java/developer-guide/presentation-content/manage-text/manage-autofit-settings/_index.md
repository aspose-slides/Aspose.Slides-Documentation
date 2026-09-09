---
title: Sunumlarınızı Python'da AutoFit ile Geliştirin
linktitle: Autofit Ayarları
type: docs
weight: 30
url: /tr/python-java/manage-autofit-settings/
keywords:
- metin kutusu
- autofit
- autofit yapma
- metni sığdır
- metni küçült
- metni kaydır
- şekli yeniden boyutlandır
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da AutoFit ayarlarını nasıl yöneteceğinizi öğrenerek PowerPoint ve OpenDocument sunumlarınızda metin görüntülenmesini optimize edin ve içerik okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde Microsoft PowerPoint, metin kutusu için **Resize shape to fit text** ayarını kullanır—metin kutusunu otomatik olarak yeniden boyutlandırarak metnin her zaman içine sığmasını sağlar.

![PowerPoint'te Metin Kutusu](textbox-in-powerpoint.png)

* Metin kutusundaki metin daha uzun veya daha büyük olduğunda, PowerPoint metin kutusunu otomatik olarak genişletir—yüksekliğini artırır—daha fazla metin tutmasına izin verir.
* Metin kutusundaki metin daha kısa veya daha küçük olduğunda, PowerPoint metin kutusunu otomatik olarak küçültür—yüksekliğini azaltır—gereksiz boşluğu ortadan kaldırır.

PowerPoint'te bunlar, bir metin kutusu için autofit davranışını kontrol eden 4 önemli parametre veya seçenektir:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint'te AutoFit Seçenekleri](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java, sunumlarda metin kutuları için autofit davranışını kontrol etmenizi sağlayan, [TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfı altındaki bazı özellikler gibi benzer seçenekler sunar.

## **Şekli Metne Uyumlu Yeniden Boyutlandır**

Eğer bir kutudaki metnin, metinde yapılan değişikliklerden sonra her zaman o kutuya sığmasını istiyorsanız, **Resize shape to fit text** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType) metodunu ([TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfından) [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textautofittype/#Shape) ile kullanın.

![PowerPoint'te Her Zaman Sığdır Ayarı](alwaysfit-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda metnin her zaman kutusuna sığması gerektiğini nasıl belirteceğinizi gösterir:

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

Metin daha uzun veya daha büyük olursa, metin kutusu otomatik olarak yeniden boyutlandırılacak (yüksekliği artacak) ve tüm metnin içine sığmasını sağlayacaktır. Metin daha kısa olursa, ters durum gerçekleşir.

## **AutoFit Kullanma**

Bir metin kutusunun veya şeklinin, içindeki metinde yapılan değişikliklere bakılmaksızın boyutlarını korumasını istiyorsanız, **Do not Autofit** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType) metodunu ([TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfından) [None](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textautofittype/#None) ile kullanın.

![PowerPoint'te AutoFit Kullanma Ayarı](donotautofit-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda metin kutusunun her zaman boyutlarını korumasını nasıl belirteceğinizi gösterir:

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

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
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metin kutusuna sığamayacak kadar uzun olduğunda, metin dışarı taşar.

## **Taşkınlıkta Metni Küçült**

Eğer metin kutusuna sığamayacak kadar uzun olursa, **Shrink text on overflow** seçeneğini kullanarak metnin boyutunun ve aralığının azaltılmasını ve kutuya sığdırılmasını belirtebilirsiniz. Bu ayarı belirtmek için, [setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType) metodunu ([TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfından) [Normal](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textautofittype/#Normal) ile kullanın.

![PowerPoint'te Taşkınlıkta Metni Küçült Ayarı](shrinktextonoverflow-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda taşkınlıkta metnin küçültülmesini nasıl belirteceğinizi gösterir:

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

## **Metni Kaydır**

Bir şekildeki metnin, metin şeklinin kenarını (yalnızca genişlik) aştığında şekil içinde kaymasını istiyorsanız, **Wrap text in shape** parametresini kullanmanız gerekir. Bu ayarı belirtmek için, [setWrapText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setWrapText) metodunu ([TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfından) [NullableBool.True_](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/#True) ile kullanmalısınız.

Bu Python kodu, bir PowerPoint sunumunda Metni Kaydır ayarını nasıl kullanacağınızı gösterir:

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
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
[setWrapText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setWrapText) metodunu bir şekil için [NullableBool.False](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/#False) ile kullandığınızda, şeklin içindeki metin şeklin genişliğinden daha uzun olduğunda, metin tek satırda şeklin kenarlarının dışına uzanır.
{{% /alert %}}

## **SSS**

**Metin çerçevesinin iç kenar boşlukları AutoFit'i etkiler mi?**  
Evet. Dolgu (iç kenar boşlukları) metin için kullanılabilir alanı azaltır, bu yüzden AutoFit daha erken devreye girer—yazı tipini küçülterek ya da şekli daha erken yeniden boyutlandırarak. AutoFit'i ayarlamadan önce kenar boşluklarını kontrol edin ve ayarlayın.

**AutoFit, manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**  
Zorunlu satır sonları yerinde kalır ve AutoFit bunların etrafında yazı tipi boyutunu ve aralığını ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit'in metni ne kadar agresif küçültmesi gerektiğini çoğu zaman azaltır.

**Tema yazı tipini değiştirmek veya yazı tipi ikamesi tetiklemek AutoFit sonuçlarını etkiler mi?**  
Evet. Farklı glif metriklerine sahip bir yazı tipine ikame etmek, metnin genişliğini/yüksekliğini değiştirir ve bu da son yazı tipi boyutunu ve satır kaydırmayı etkileyebilir. Herhangi bir yazı tipi değişikliğinden veya ikamesinden sonra slaytları yeniden kontrol edin.