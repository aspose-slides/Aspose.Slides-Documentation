---
title: .NET'te Sunum Yerelleştirmesini Otomatikleştirin
linktitle: Sunum Yerelleştirme
type: docs
weight: 100
url: /tr/net/presentation-localization/
keywords:
- dil değişikliği
- imla denetimi
- dil kimliği
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET içinde PowerPoint ve OpenDocument slayt yerelleştirmesini otomatikleştirin, pratik C# kod örnekleri ve daha hızlı küresel dağıtım için ipuçları kullanarak."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki metnin `LanguageId` değerinin nasıl ayarlanacağını açıklar. Bir sunumu nasıl açacağınızı, metinli bir şekil ekleyeceğinizi, bir metin bölümüne dil tanımlayıcısı atayacağınızı ve sonucu PPTX dosyası olarak kaydedeceğinizi gösterir.

## **Sunum ve Şekil Metni İçin Dili Değiştir**
- [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaytın referansını, dizinini kullanarak alın.
- Slayta Dikdörtgen tipinde bir AutoShape ekleyin.
- TextFrame'e biraz metin ekleyin.
- Metne Dil Kimliği ayarlama.
- Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulanması aşağıdaki örnekte gösterilmiştir.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **SSS**

**Dil kimliği otomatik metin çevirisini tetikler mi?**

Hayır. Aspose.Slides içindeki [LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/languageid/) imla denetimi ve dilbilgisi denetimi için dili saklar, ancak metni çevirmeyi veya içeriğini değiştirmeyi yapmaz. PowerPoint’in denetleme amaçlı anladığı bir meta veridir.

**Dil kimliği işleme sırasında kesme ve satır sonlarını etkiler mi?**

Aspose.Slides’te [LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/languageid/) denetleme içindir. Kesme kalitesi ve satır kaydırma öncelikle [uygun yazı tiplerinin](/slides/tr/net/powerpoint-fonts/) ve yazı sistemi için düzen/satır sonu ayarlarının mevcut olmasına bağlıdır. Doğru renderleme için gerekli yazı tiplerini sağlayın, [yazı tipi ikame kurallarını](/slides/tr/net/font-substitution/) yapılandırın ve/veya sunuma [yazı tiplerini gömün](/slides/tr/net/embedded-font/).

**Tek bir paragrafta farklı dilleri ayarlayabilir miyim?**

Evet. [LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/languageid/) metin bölümü seviyesinde uygulanır, bu yüzden tek bir paragrafta birden çok dili farklı denetleme ayarlarıyla karıştırabilirsiniz.