---
title: "Aspose.Slides for .NET 15.1.0'deki Genel API ve Geriye Uyumsuz Değişiklikler"
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

This page lists all [added](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) or [removed](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **Public API Değişiklikleri**
#### **Yazı Tipi Değiştirme İşlevselliği Eklendi**
Sunum boyunca yazı tipini küresel olarak ve geçici olarak render sırasında değiştirme imkanı eklendi.

Presentation sınıfının yeni "FontsManager" özelliği tanıtıldı. FontsManager sınıfının aşağıdaki üyeleri bulunmaktadır:

**IFontSubstRuleCollection FontSubstRuleList** Property

Bu koleksiyon, render sırasında yazı tiplerini değiştirmek için kullanılan IFontSubstRule örneklerini içerir. IFontSubstRule, IFontData arayüzünü uygulayan SourceFont ve DestFont özelliklerine ve değişim koşulunu seçmeye izin veren ReplaceFontCondition özelliğine sahiptir ("WhenInaccessible" veya "Always").

**IFontData[] GetFonts()** Method

Mevcut sunumda kullanılan tüm yazı tiplerini almak için kullanılır.

**ReplaceFont** Methods

Sunum içinde yazı tipini kalıcı olarak değiştirmek için kullanılır.  

The following example shows how to replace font in the presentation:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Another example, demonstrates font substitution for rendering when inaccessible:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial yazı tipi, SomeRareFont erişilemez olduğunda kullanılacak

            pres.Slides[0].GetImage();

```