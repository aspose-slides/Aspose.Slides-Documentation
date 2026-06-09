---
title: JavaScript'te AutoFit ile Sunumlarınızı Geliştirin
linktitle: Autofit Ayarları
type: docs
weight: 30
url: /tr/nodejs-java/manage-autofit-settings/
keywords:
- metin kutusu
- autofit
- autofit yapma
- metni uydur
- metni küçült
- metni kaydır
- şekli yeniden boyutlandır
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde AutoFit ayarlarını yöneterek PowerPoint ve OpenDocument sunumlarınızdaki metin görüntüsünü optimize edin ve içeriğin okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde Microsoft PowerPoint, metin kutusu için **Resize shape to fix text** ayarını kullanır—metin kutusunu otomatik olarak yeniden boyutlandırarak metnin her zaman kutuya sığmasını sağlar. 

![textbox-powerpoint'ta](textbox-in-powerpoint.png)

* Metin kutusundaki metin daha uzun veya büyük olduğunda, PowerPoint metin kutusunu otomatik olarak büyütür—yüksekliğini artırır—daha fazla metin içerebilmesi için. 
* Metin kutusundaki metin daha kısa veya küçük olduğunda, PowerPoint metin kutusunu otomatik olarak küçültür—yüksekliğini azaltır—gereksiz boşluğu temizlemek için. 

PowerPoint'te, bir metin kutusunun otomatik sığdırma davranışını kontrol eden 4 önemli parametre veya seçenek şunlardır: 

* **Otomatik Sığdırma Yapma**
* **Taşma Durumunda Metni Küçült**
* **Şekli Metne Sığdırmak İçin Yeniden Boyutlandır**
* **Şekilde Metni Kaydır.**

![autofit-seçenekleri-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java, sunumlarda metin kutularının otomatik sığdırma davranışını kontrol etmenizi sağlayan benzer seçenekler—[TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfı altında bulunan bazı özellikler—sunar.

## **Şekli Metne Sığdırmak İçin Yeniden Boyutlandır**

Bir kutudaki metnin, metinde yapılan değişikliklerden sonra her zaman o kutuya sığmasını istiyorsanız, **Resize shape to fix text** seçeneğini kullanmanız gerekir. Bu ayarı belirlemek için, `Shape` değerini kullanarak [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfındaki [setAutofitType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) metodunu çağırın.

![herzaman-sığdır-ayarı-powerpoint](alwaysfit-setting-powerpoint.png)

Bu JavaScript kodu, bir PowerPoint sunumunda metnin her zaman kutusuna sığdırılması gerektiğini nasıl belirteceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Metin daha uzun veya büyük olursa, metin kutusu otomatik olarak yeniden boyutlandırılır (yüksekliği artar) ve tüm metnin sığması sağlanır. Metin daha kısa olursa, tersine durum gerçekleşir. 

## **Otomatik Sığdırma Yapma**

Bir metin kutusunun veya şeklinin, içinde bulunan metinde yapılan değişikliklerden bağımsız olarak boyutlarını korumasını istiyorsanız, **Otomatik Sığdırma Yapma** seçeneğini kullanmanız gerekir. Bu ayarı belirlemek için, `None` değerini kullanarak [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfındaki [setAutofitType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) metodunu çağırın.

![otomatik-sığdırma-yapma-ayarı-powerpoint](donotautofit-setting-powerpoint.png)

Bu JavaScript kodu, bir PowerPoint sunumunda bir metin kutusunun boyutlarını her zaman korumasını nasıl belirteceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Metin kutusunun kapsamından fazla uzun olduğunda, metin dışarı taşar. 

## **Taşma Durumunda Metni Küçült**

Bir metin kutusu çok uzun olduğunda, **Taşma Durumunda Metni Küçült** seçeneğiyle metnin boyutunun ve aralığının azaltılarak kutuya sığmasını sağlayabilirsiniz. Bu ayarı belirlemek için, `Normal` değerini kullanarak [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfındaki [setAutofitType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) metodunu çağırın.

![taşma-durumunda-metni-küçült-ayarı-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Bu JavaScript kodu, bir PowerPoint sunumunda metnin taşma durumunda küçültülmesini nasıl belirteceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
**Taşma Durumunda Metni Küçült** seçeneği kullanıldığında, ayar yalnızca metin kutusunun kapasitesinden daha uzun olduğunda uygulanır. 
{{% /alert %}}

## **Metni Kaydır**

Metnin, şeklin kenarını (yalnızca genişliği) aştığında o şekil içinde kaydırılmasını istiyorsanız, **Şekilde Metni Kaydır** parametresini kullanmanız gerekir. Bu ayarı belirlemek için, `true` değerini kullanarak [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfındaki [setWrapText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) metodunu çağırmalısınız.

Bu JavaScript kodu, bir PowerPoint sunumunda Metni Kaydır ayarını nasıl kullanacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
`setWrapText` metodunu bir şekil için `False` değeriyle çağırırsanız, şeklin içindeki metin şeklin genişliğinden uzun olduğunda, metin tek bir satırda şeklin sınırlarının dışına uzanır. 
{{% /alert %}}

## **SSS**

**Metin çerçevesinin iç kenar boşlukları AutoFit'i etkiler mi?**  
Evet. Dolgu (iç kenar boşlukları) metin için kullanılabilir alanı azaltır, bu yüzden AutoFit daha erken devreye girer—yazı tipini küçültür veya şekli daha erken yeniden boyutlandırır. AutoFit'i ayarlamadan önce kenar boşluklarını kontrol edin ve ayarlayın.

**AutoFit manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**  
Zorunlu satır sonları yerinde kalır ve AutoFit, onların etrafındaki yazı tipi boyutunu ve aralığını ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit'in metni ne kadar agresif küçültmesi gerektiğini genellikle azaltır.

**Tema yazı tipini değiştirmek veya yazı tipi ikamesi tetiklemek AutoFit sonuçlarını etkiler mi?**  
Evet. Farklı glif ölçümlerine sahip bir yazı tipine ikame etmek, metnin genişliğini/yüksekliğini değiştirir ve bu da son yazı tipi boyutunu ve satır kaydırmasını etkileyebilir. Herhangi bir yazı tipi değişikliği veya ikamesi sonrası slaytları yeniden kontrol edin.