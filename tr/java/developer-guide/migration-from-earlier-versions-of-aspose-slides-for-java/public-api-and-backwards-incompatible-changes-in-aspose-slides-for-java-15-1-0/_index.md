---
title: Aspose.Slides for Java 15.1.0'da Genel API ve Geriye Uyumsuz Değişiklikler
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
{{% alert color="primary" %}} 
Bu sayfa, Aspose.Slides for Java 15.1.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) sınıfları, yöntemleri, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) listeler.
{{% /alert %}} {{% alert color="primary" %}} 
Bazı görüntü madde işaretleri ve WordArt nesneleriyle ilgili bilinen sorunlar vardır; bu sorunlar Aspose.Slides for Java 15.2.0'da düzeltilecektir.
{{% /alert %}} 
## **Public API Değişiklikleri**
### **Yazı tipi ikameleri işlevselliği eklendi**
Sunum boyunca yazı tiplerini küresel olarak ve render sırasında geçici olarak değiştirme olanağı eklendi.

Presentation sınıfına yeni getFontsManager() yöntemi eklendi. FontsManager sınıfının aşağıdaki üyeleri vardır:

**IFontSubstRuleCollection getFontSubstRuleList**() yöntemi

Bu, render sırasında yazı tiplerini ikame etmek için kullanılan IFontSubstRule örneklerinin koleksiyonudur. IFontSubstRule, IFontData arayüzünü uygulayan getSourceFont() ve getDestFont() yöntemlerine ve ikame koşulunu seçmeye izin veren ("WhenInaccessible" veya "Always") getReplaceFontCondition() yöntemine sahiptir.

**IFontData[] getFonts()** yöntemi, geçerli sunumda kullanılan tüm yazı tiplerini almak için kullanılabilir.

**replaceFont(...)** yöntemleri, bir sunumdaki yazı tipini kalıcı olarak değiştirmek için kullanılabilir. 

Aşağıdaki örnek, bir sunumda yazı tipinin nasıl değiştirileceğini gösterir:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Başka bir örnek, erişilemediğinde render için yazı tipi ikamesini gösterir:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Arial yazı tipi, SomeRareFont erişilemez olduğunda kullanılacaktır

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```