---
title: Aspose.Slides for Java 15.1.0'da Genel API ve Geriye Dönük Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 15.1.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) sınıfları, yöntemleri, özellikleri ve benzeri, yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) listeler.

{{% /alert %}} {{% alert color="info" %}} 

Bazı resim madde işaretleri ve WordArt nesneleriyle ilgili bilinen sorunlar bulunmaktadır; bunlar Aspose.Slides for Java 15.2.0'de düzeltilecektir.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **Yazı tipi ikameleri işlevselliği eklendi**
Sunum boyunca yazı tiplerini küresel olarak ve renderleme sırasında geçici olarak değiştirme olanağı eklendi.

Presentation sınıfına yeni getFontsManager() yöntemi tanıtıldı. FontsManager sınıfı aşağıdaki üyeleri içerir:

**IFontSubstRuleCollection getFontSubstRuleList**() method  
Bu, renderleme sırasında yazı tiplerini ikame etmek için kullanılan IFontSubstRule örneklerinin koleksiyonudur. IFontSubstRule, IFontData arayüzünü uygulayan getSourceFont() ve getDestFont() yöntemlerine ve değiştirme koşulunu seçmeye izin veren ("WhenInaccessible" veya "Always") getReplaceFontCondition() yöntemine sahiptir.

**IFontData[] getFonts()** method can be used to retrieve all fonts used in the current presentation.  
**IFontData[] getFonts()** yöntemi, mevcut sunumda kullanılan tüm yazı tiplerini almak için kullanılabilir.

**replaceFont(...)** methods can be used to persistently replace a font in a presentation.  
**replaceFont(...)** yöntemleri, bir sunumdaki yazı tipini kalıcı olarak değiştirmek için kullanılabilir.

Aşağıdaki örnek, bir sunumda yazı tipinin nasıl değiştirileceğini gösterir:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Başka bir örnek, yazı tipinin erişilemez olduğunda renderleme için ikame edilmesini gösterir:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Erişilemediğinde SomeRareFont yerine Arial yazı tipi kullanılacaktır.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```