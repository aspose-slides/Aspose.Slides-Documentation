---
title: Aspose.Slides for .NET 15.1.0'de Genel API ve Geriye Yönelik Uyumsuz Değişiklikler
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
description: "Aspose.Slides for .NET'te genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 
Bu sayfa, Aspose.Slides for .NET 15.1.0 API'siyle tanıtılan [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **Yazı Tipi Değiştirme İşlevselliği Eklendi**
Sunum boyunca yazı tipini küresel olarak ve render için geçici olarak değiştirme imkanı eklendi.

Presentation sınıfına yeni "FontsManager" özelliği eklendi. FontsManager sınıfı aşağıdaki üyeleri içerir:

**IFontSubstRuleCollection FontSubstRuleList** Özelliği

Bu koleksiyon, render sırasında yazı tiplerini değiştirmek için kullanılan IFontSubstRule örneklerini içerir. IFontSubstRule, IFontData arayüzünü uygulayan SourceFont ve DestFont özelliklerine ve değişim koşulunu seçmeye izin veren ReplaceFontCondition özelliğine sahiptir ("WhenInaccessible" veya "Always").

**IFontData[] GetFonts()** Metodu

Mevcut sunumda kullanılan tüm yazı tiplerini almak için kullanılır.

**ReplaceFont** Metodları

Sunum içinde yazı tipini kalıcı olarak değiştirmek için kullanılır. 

Aşağıdaki örnek, sunum içinde yazı tipinin nasıl değiştirileceğini gösterir:
``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 
Bir başka örnek, erişilemediğinde render için yazı tipi değişimini gösterir:
``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Erişilemediğinde SomeRareFont yerine Arial yazı tipi kullanılacaktır

            pres.Slides[0].GetThumbnail();

```