---
title: Python'da Otomatik Sığdırma ile Sunumlarınızı Geliştirin
linktitle: Otomatik Sığdırma Ayarları
type: docs
weight: 30
url: /tr/python-net/manage-autofit-settings/
keywords:
- metin kutusu
- otomatik sığdırma
- otomatik sığdırma yok
- metni sığdır
- metni küçült
- metni kaydır
- şekli yeniden boyutlandır
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'de Otomatik Sığdırma ayarlarını nasıl yöneteceğinizi öğrenerek PowerPoint ve OpenDocument sunumlarınızda metin gösterimini optimize edin ve içeriğin okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde, Microsoft PowerPoint metin kutusu için **Resize shape to fix text** ayarını kullanır—metni her zaman içine sığacak şekilde otomatik olarak yeniden boyutlandırır. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Metin kutusundaki metin daha uzun veya daha büyük olduğunda, PowerPoint metin kutusunu otomatik olarak genişletir—yüksekliğini artırır—daha fazla metin tutabilmesi için. 
* Metin kutusundaki metin daha kısa veya daha küçük olduğunda, PowerPoint metin kutusunu otomatik olarak küçültür—yüksekliğini azaltır—gereksiz boşluğu temizlemek için. 

PowerPoint'te, bir metin kutusunun otomatik sığdırma davranışını kontrol eden 4 önemli parametre veya seçenek şunlardır: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET, sunumlardaki metin kutularının otomatik sığdırma davranışını kontrol etmenizi sağlayan, [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) sınıfı altındaki bazı özellikler gibi benzer seçenekler sunar. 

## **Metne Uyması İçin Şekilleri Yeniden Boyutlandır**

Metnin her zaman kutusuna sığmasını istediğinizde, **Resize shape to fix text** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [autofit_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) özelliğini [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) sınıfından `SHAPE` değerine ayarlayın. 

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda metnin her zaman kutusuna sığmasını nasıl belirteceğinizi gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Metin daha uzun veya daha büyük olduğunda, metin kutusu otomatik olarak yeniden boyutlandırılır (yüksekliği artırılır) ve tüm metin kutuya sığar. Metin daha kısa olduğunda ise tersine bir işlem gerçekleşir. 

## **Otomatik Sığdırma Yok**

Bir metin kutusunun veya şeklinin metindeki değişikliklere bakılmaksızın boyutlarını korumasını istiyorsanız, **Do not Autofit** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [autofit_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) özelliğini [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) sınıfından `NONE` değerine ayarlayın. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda bir metin kutusunun boyutlarını her zaman korumasını nasıl belirteceğinizi gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Metin kutusunun kutusuna sığamayacak kadar uzun olması durumunda metin dışarı taşar. 

## **Taşma Durumunda Metni Küçült**

Bir metin kutusu kutusuna sığamayacak kadar uzun olduğunda, **Shrink text on overflow** seçeneğiyle metnin boyutunun ve satır aralığının azaltılarak kutuya sığması sağlanabilir. Bu ayarı belirtmek için, [autofit_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) özelliğini [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) sınıfından `NORMAL` değerine ayarlayın. 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Bu Python kodu, bir PowerPoint sunumunda taşma durumunda metnin küçültülmesini nasıl belirteceğinizi gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
**Shrink text on overflow** seçeneği kullanıldığında, ayar yalnızca metin kutusuna sığamayacak kadar uzun olduğunda uygulanır. 
{{% /alert %}}

## **Metni Kaydır**

Metnin, şeklin sadece genişliğini aşması durumunda şekil içinde kaydırılmasını istiyorsanız, **Wrap text in shape** parametresini kullanmanız gerekir. Bu ayarı belirtmek için, [wrap_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) özelliğini [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) sınıfından `NullableBool.TRUE` değerine ayarlamalısınız. 

Bu Python kodu, bir PowerPoint sunumunda Metni Kaydır ayarının nasıl kullanılacağını gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Bir şekil için `wrap_text` özelliğini `NullableBool.FALSE` olarak ayarlarsanız, şeklin içindeki metin şeklin genişliğinden uzun olduğunda metin tek bir satırda şeklin sınırlarının dışına uzanır. 
{{% /alert %}}

## **SSS**

**Metin çerçevesinin iç kenar boşlukları AutoFit'i etkiler mi?**  
Evet. Dolgu (iç kenar boşlukları) metin için kullanılabilir alanı azaltır, bu yüzden AutoFit daha erken devreye girer—yazı tipini küçülterek veya şekli daha erken yeniden boyutlandırarak. AutoFit'i ayarlamadan önce kenar boşluklarını kontrol edip gerekirse ayarlayın.

**AutoFit manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**  
Zorunlu satır sonları yerinde kalır ve AutoFit bu satır sonları etrafında yazı tipi boyutunu ve aralığı ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit'in metni aşırı küçültme ihtiyacını azaltabilir.

**Tema yazı tipini değiştirmek veya yazı tipi ikamesi tetiklemek AutoFit sonuçlarını etkiler mi?**  
Evet. Farklı glif ölçümleri olan bir yazı tipine ikame edilmesi, metnin genişliğini/yüksekliğini değiştirir ve bu da son yazı tipi boyutunu ve satır kaydırmayı etkileyebilir. Herhangi bir yazı tipi değişikliğinden sonra slaytları yeniden kontrol edin.