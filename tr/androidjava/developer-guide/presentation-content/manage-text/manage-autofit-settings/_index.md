---
title: "Android'de AutoFit ile Sunumlarınızı Geliştirin"
linktitle: "Autofit Ayarları"
type: docs
weight: 30
url: /tr/androidjava/manage-autofit-settings/
keywords:
- metin kutusu
- otomatik sığdırma
- otomatik sığdırma yok
- metni sığdır
- metni küçült
- metni kaydır
- şekli yeniden boyutlandır
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da AutoFit ayarlarını yöneterek PowerPoint ve OpenDocument sunumlarınızda metin görüntüsünü optimize edin ve içerik okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde Microsoft PowerPoint, metin kutusu için **Resize shape to fix text** ayarını kullanır—metnin her zaman kutuya sığmasını sağlamak için metin kutusunun boyutunu otomatik olarak değiştirir. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Metin kutusundaki metin daha uzun ya da daha büyük olduğunda, PowerPoint metin kutusunu otomatik olarak genişletir—yüksekliğini artırır—daha fazla metin alabilmesi için. 
* Metin kutusundaki metin daha kısa ya da daha küçük olduğunda, PowerPoint metin kutusunu otomatik olarak küçültür—yüksekliğini azaltır—gereksiz boşluğu temizlemek için. 

PowerPoint’te, bir metin kutusunun otomatik sığdırma davranışını kontrol eden 4 önemli parametre veya seçenek şunlardır: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java, benzer seçenekler—[TextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrameFormat) sınıfı altındaki bazı özellikler—sunular içinde metin kutularının otomatik sığdırma davranışını kontrol etmenizi sağlar.

## **Şekli Metne Uydurmak İçin Yeniden Boyutlandırma**

Metnin, kutuda yapılan değişikliklerden sonra her zaman kutuya sığmasını istiyorsanız **Resize shape to fix text** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) özelliğini ([TextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrameFormat) sınıfından) `Shape` olarak ayarlayın.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Bu Java kodu, bir PowerPoint sunumunda metnin her zaman kutusuna sığması gerektiğini nasıl belirteceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Metin daha uzun ya da daha büyük olursa, metin kutusu otomatik olarak yeniden boyutlandırılır (yüksekliği artırılır) ve tüm metnin sığmasını sağlar. Metin daha kısa olursa, tersine işlem gerçekleşir. 

## **Do Not Autofit**

Bir metin kutusunun veya şeklinin, içerdiği metindeki değişikliklerden bağımsız olarak boyutlarını korumasını istiyorsanız **Do not Autofit** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) özelliğini `None` olarak ayarlayın.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Bu Java kodu, bir PowerPoint sunumunda metin kutusunun her zaman boyutlarını koruması gerektiğini nasıl belirteceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Metin kutusunun kutusuna sığamayacak kadar uzun olduğunda, metin dışarı taşar. 

## **Shrink Text on Overflow**

Bir metin kutusunun kutusuna sığamayacak kadar uzun olması durumunda, **Shrink text on overflow** seçeneği sayesinde metnin boyutu ve satır aralığı azaltılarak kutuya sığdırılmasını sağlayabilirsiniz. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) özelliğini `Normal` olarak ayarlayın.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Bu Java kodu, bir PowerPoint sunumunda metnin taşma durumunda küçültülmesi gerektiğini nasıl belirteceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
**Shrink text on overflow** seçeneği kullanıldığında, ayar yalnızca metin kutusunun kutusuna sığamayacak kadar uzun olduğunda uygulanır. 
{{% /alert %}}

## **Wrap Text**

Metnin, şeklin sınırlarını (yalnızca genişlik) aştığında şekil içinde satır satır kaydırılmasını istiyorsanız **Wrap text in shape** parametresini kullanmanız gerekir. Bu ayarı belirtmek için, [WrapText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) özelliğini `true` olarak ayarlamalısınız.

Bu Java kodu, bir PowerPoint sunumunda Metni Kaydır ayarını nasıl kullanacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Bir şekil için `WrapText` özelliğini `False` olarak ayarlarsanız, şeklin içindeki metin şeklin genişliğinden uzun olduğunda, metin tek bir satırda şeklin kenarlarının dışına uzanır. 
{{% /alert %}}

## **SSS**

**Metin çerçevesinin iç boşlukları AutoFit'i etkiler mi?**  
Evet. İç dolgu (padding) metin için kullanılabilir alanı azaltır, bu nedenle AutoFit daha erken devreye girer—yazı tipini küçülterek ya da şekli daha erken yeniden boyutlandırarak. AutoFit'i ayarlamadan önce kenar boşluklarını kontrol edin ve gerektiğinde düzeltin.

**AutoFit manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**  
Zorunlu satır sonları yerinde kalır ve AutoFit bunların etrafında yazı tipi boyutunu ve satır aralığını ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit'in metni aşırı küçültme ihtiyacını azaltabilir.

**Tema yazı tipini değiştirmek veya yazı tipi ikamesi yapmak AutoFit sonuçlarını etkiler mi?**  
Evet. Farklı glif metriklerine sahip bir yazı tipine ikame edildiğinde, metnin genişliği/yüksekliği değişir ve bu da nihai yazı tipi boyutunu ve satır kaydırmayı etkileyebilir. Herhangi bir yazı tipi değişikliğinden veya ikamesinden sonra slaytları yeniden kontrol edin.