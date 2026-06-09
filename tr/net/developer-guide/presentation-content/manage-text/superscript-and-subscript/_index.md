---
title: ".NET'te Sunumlarda Üst Simge ve Alt Simgeyi Yönet"
linktitle: "Üst Simge ve Alt Simge"
type: docs
weight: 80
url: /tr/net/superscript-and-subscript/
keywords:
- "üst simge"
- "alt simge"
- "üst simge ekle"
- "alt simge ekle"
- PowerPoint
- OpenDocument
- "sunum"
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile üst ve alt simgeyi ustalaşın ve sunumlarınızı profesyonel metin biçimlendirmesiyle maksimum etki için yükseltin."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarınıza üst simge ve alt simge metni ekleme özellikleri sunar. Kimyasal formülleri, matematiksel denklemleri vurgulamanız ya da içeriği dipnotlarla açıklamanız gerektiğinde, bu özel biçimlendirme seçenekleri açıklığı ve doğruluğu korur. Bu makalede, üst ve alt simge stillerini sorunsuz bir şekilde nasıl uygulayacağınızı ve her slaytta profesyonel sonuçlar elde edeceğinizi öğreneceksiniz.

## **Üst Simge ve Alt Simge Metni Ekle**

Bir sunumdaki herhangi bir paragrafta üst simge ve alt simge metni ekleyebilirsiniz. Bunu Aspose.Slides ile gerçekleştirmek için [PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/portionformat/) sınıfının `Escapement` özelliğini kullanmalısınız.

Bu özellik, -%100 (alt simge) ile %100 (üst simge) arasında değerler belirleyerek üst ya da alt simge metni ayarlamanızı sağlar.

Uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Slayta `Rectangle` türünde bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. [IAutoShape] ile ilişkilendirilmiş [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) e erişin.
1. Mevcut paragrafları temizleyin.
1. Üst simge metni için yeni bir [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) oluşturun ve bunu [ITextFrame]’in paragraf koleksiyonuna ekleyin.
1. Yeni bir metin bölümü nesnesi oluşturun.
1. Metin bölümünün `Escapement` özelliğini 0 ile 100 arasında ayarlayarak üst simge uygulayın (0 üst simge olmadığı anlamına gelir).
1. [Portion](https://reference.aspose.com/slides/tr/net/aspose.slides/portion/) için bir metin belirleyin ve bunu paragrafın bölüm koleksiyonuna ekleyin.
1. Alt simge metni için başka bir [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) oluşturun ve bunu paragraf koleksiyonuna ekleyin.
1. Yeni bir metin bölümü nesnesi oluşturun.
1. Metin bölümünün `Escapement` özelliğini 0 ile -100 arasında ayarlayarak alt simge uygulayın (0 alt simge olmadığı anlamına gelir).
1. [Portion](https://reference.aspose.com/slides/tr/net/aspose.slides/portion/) için bir metin belirleyin ve bunu paragrafın bölüm koleksiyonuna ekleyin.
1. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu bu adımları uygular:

```c#
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Bir metin kutusu oluştur.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Üst simge metni için bir paragraf oluştur.
    IParagraph superPar = new Paragraph();

    // Normal metin içeren bir metin bölümü oluştur.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Üst simge metni içeren bir metin bölümü oluştur.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Alt simge metni için bir paragraf oluştur.
    IParagraph paragraph2 = new Paragraph();

    // Normal metin içeren bir metin bölümü oluştur.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Alt simge metni içeren bir metin bölümü oluştur.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Paragrafları metin kutusuna ekle.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Superscript and Subscript](superscript_and_subscript.png)

## **SSS**

**Üst ve alt simge, PDF veya diğer formatlara aktarılırken korunur mu?**

Evet, Aspose.Slides for .NET, sunumları PDF, PPT/PPTX, görüntüler ve diğer desteklenen formatlara dışa aktarırken üst ve alt simge biçimlendirmesini doğru şekilde korur. Özel formatlama tüm çıktı dosyalarında bozulmadan kalır.

**Üst ve alt simge, kalın veya italik gibi diğer biçimlendirme stilleriyle birleştirilebilir mi?**

Evet, Aspose.Slides, tek bir metin bölümü içinde çeşitli metin stillerini karıştırmanıza izin verir. [PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/portionformat/) sınıfındaki ilgili özellikleri yapılandırarak kalın, italik, alt çizgi gibi stilleri etkinleştirebilir ve aynı anda üst ya da alt simge uygulayabilirsiniz.

**Üst ve alt simge biçimlendirmesi, tablolar, grafikler veya SmartArt içindeki metinlerde çalışır mı?**

Evet, Aspose.Slides for .NET, tablolar ve grafik öğeleri de dahil olmak üzere çoğu nesne içinde biçimlendirmeyi destekler. SmartArt ile çalışırken, ilgili öğelere (örneğin [SmartArtNode](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartartnode/)) ve metin kapsayıcılarına erişmeniz ve ardından [PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/portionformat/) özelliklerini benzer şekilde yapılandırmanız gerekir.