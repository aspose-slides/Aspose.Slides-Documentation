---
title: Java'da AutoFit ile Sunumlarınızı Geliştirin
linktitle: AutoFit Ayarları
type: docs
weight: 30
url: /tr/java/manage-autofit-settings/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da AutoFit ayarlarını nasıl yöneteceğinizi öğrenin, PowerPoint ve OpenDocument sunumlarınızda metin görüntüsünü optimize edin ve içerik okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde, Microsoft PowerPoint metin kutusu için **Resize shape to fix text** ayarını kullanır—metin kutusunun metninin her zaman içine sığmasını sağlamak için otomatik olarak metin kutusunun boyutunu değiştirir. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Metin kutusundaki metin daha uzun veya daha büyük olduğunda, PowerPoint metin kutusunu otomatik olarak genişletir—yüksekliğini artırır—daha fazla metin tutabilmesi için. 
* Metin kutusundaki metin daha kısa veya daha küçük olduğunda, PowerPoint metin kutusunu otomatik olarak küçültür—yüksekliğini azaltır—gereksiz alana yer açmak için. 

PowerPoint'te, bir metin kutusunun otomatik sığdırma davranışını kontrol eden 4 önemli parametre veya seçenek şunlardır: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java, sunumlarda metin kutularının otomatik sığdırma davranışını kontrol etmenizi sağlayan, [TextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TextFrameFormat) sınıfındaki bazı özellikler gibi benzer seçenekler sunar. 

## **Şekli Metne Sığdırmak İçin Yeniden Boyutlandır**

Metnin kutusuna her zaman sığmasını istiyorsanız, **Resize shape to fix text** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TextFrameFormat#getAutofitType--) özelliğini ([TextFrameFormat] sınıfından) `Shape` olarak ayarlayın. 

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Bu Java kodu, PowerPoint sunumunda bir metnin her zaman kutusuna sığmasını nasıl belirteceğinizi gösterir:

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

Metin daha uzun veya daha büyük olduğunda, metin kutusu otomatik olarak yeniden boyutlandırılır (yüksekliği artar) ve tüm metnin içine sığması sağlanır. Metin daha kısa olduğunda ise tersine gerçekleşir. 

## **Do Not Autofit**

Metin kutusundaki veya şeklin içindeki metinde yapılan değişikliklere bakılmaksızın boyutlarının korunmasını istiyorsanız, **Do not Autofit** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TextFrameFormat#getAutofitType--) özelliğini ([TextFrameFormat] sınıfından) `None` olarak ayarlayın. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Bu Java kodu, PowerPoint sunumunda bir metin kutusunun boyutlarını her zaman korumasını nasıl belirteceğinizi gösterir:

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

Metin kutusunun kutusuna göre çok uzun olduğunda, metin dışarı taşar. 

## **Shrink Text on Overflow**

Bir metin kutusunun kutusuna göre çok uzun olduğunda, **Shrink text on overflow** seçeneği sayesinde, metnin boyutu ve satır aralığının azaltılarak kutuya sığdırılmasını belirtebilirsiniz. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TextFrameFormat#getAutofitType--) özelliğini ([TextFrameFormat] sınıfından) `Normal` olarak ayarlayın. 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Bu Java kodu, PowerPoint sunumunda bir metnin taşma durumunda küçültülmesini nasıl belirteceğinizi gösterir:

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
**Shrink text on overflow** seçeneği kullanıldığında, ayar yalnızca metin kutusuna göre çok uzun olduğunda uygulanır. 
{{% /alert %}}

## **Wrap Text**

Bir şeklin içindeki metin, şeklin kenarını (yalnızca genişliği) aştığında şekil içinde kaydırılmasını istiyorsanız, **Wrap text in shape** parametresini kullanmanız gerekir. Bu ayarı belirtmek için, [WrapText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TextFrameFormat#getWrapText--) özelliğini ([TextFrameFormat] sınıfından) `true` olarak ayarlamalısınız. 

Bu Java kodu, PowerPoint sunumunda Wrap Text ayarını nasıl kullanacağınızı gösterir:

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
Bir şekil için `WrapText` özelliğini `False` olarak ayarlarsanız, şeklin içindeki metin şeklin genişliğinden uzun olduğunda metin tek bir satırda şeklin kenarlarının dışına doğru uzanır. 
{{% /alert %}}

## **SSS**

**Metin çerçevesinin iç kenar boşlukları AutoFit'i etkiler mi?**  

Evet. Dolgu (iç kenar boşlukları) metin için kullanılabilir alanı azaltır, bu nedenle AutoFit daha erken devreye girer—yazı tipini küçültür veya şekli daha erken yeniden boyutlandırır. AutoFit'i ayarlamadan önce kenar boşluklarını kontrol edin ve gerektiğinde ayarlayın.  

**AutoFit, manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**  

Zorunlu satır sonları yerinde kalır ve AutoFit, etraflarındaki yazı tipi boyutunu ve satır aralığını ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit'in metni ne kadar agresif küçültmesi gerektiğini genellikle azaltır.  

**Tema yazı tipini değiştirmek veya yazı tipi ikamesi tetiklemek AutoFit sonuçlarını etkiler mi?**  

Evet. Farklı glif ölçümlerine sahip bir yazı tipine ikame etmek, metnin genişliğini/yüksekliğini değiştirir ve bu da son yazı tipi boyutunu ve satır kaydırmayı etkileyebilir. Herhangi bir yazı tipi değişikliği veya ikamesi sonrası slaytları yeniden kontrol edin.