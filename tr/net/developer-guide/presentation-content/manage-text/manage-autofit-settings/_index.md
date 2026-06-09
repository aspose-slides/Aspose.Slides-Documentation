---
title: AutoFit ile .NET’te Sunumlarınızı Geliştirin
linktitle: Autofit Ayarları
type: docs
weight: 30
url: /tr/net/manage-autofit-settings/
keywords:
- metin kutusu
- otomatik sığdırma
- autofit yapma
- metni sığdır
- metni küçült
- metni kaydır
- şekli yeniden boyutlandır
- PowerPoint
- sunum
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET’te AutoFit ayarlarını yöneterek PowerPoint ve OpenDocument sunumlarınızda metin görüntülemesini optimize edin ve içerik okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde Microsoft PowerPoint, metin kutusu için **Resize shape to fit text** ayarını kullanır—metin kutusunun metninin her zaman sığmasını otomatik olarak yeniden boyutlandırır.

![PowerPoint'te bir metin kutusu](textbox-in-powerpoint.png)

* Metin kutusundaki metin daha uzun ya da daha büyük olduğunda, PowerPoint metin kutusunu otomatik olarak büyütür—yüksekliğini artırır—daha fazla metin almasını sağlar.
* Metin kutusundaki metin daha kısa ya da daha küçük olduğunda, PowerPoint metin kutusunu otomatik olarak küçültür—yüksekliğini azaltır—gereksiz boşluğu ortadan kaldırır.

PowerPoint'te, bir metin kutusunun otomatik sığdırma davranışını kontrol eden dört önemli parametre ya da seçenek şunlardır:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![PowerPoint'te Otomatik Sığdırma Seçenekleri](autofit-options-powerpoint.png)

Aspose.Slides for .NET, sunumlarda metin kutularının otomatik sığdırma davranışını kontrol etmenizi sağlayan, [TextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat) sınıfı altındaki benzer seçenekler—özellikler—sunar.

## **Şekli Metne Uydurmak İçin Yeniden Boyutlandır**

Metnin her zaman kutuya sığmasını istiyorsanız **Resize shape to fit text** seçeneğini kullanmalısınız. Bu ayarı belirtmek için `AutofitType` özelliğini [TextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat) sınıfından `Shape` olarak ayarlayın.

![Şekli metne uyacak şekilde yeniden boyutlandır](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Metin daha uzun ya da daha büyük olduğunda, metin kutusu otomatik olarak yeniden boyutlandırılır (yüksekliği artırılır) ve tüm metnin sığması sağlanır. Metin daha kısa olduğunda ise tersine bir işlem gerçekleşir.

## **Do Not Autofit**

Metin kutusunun veya şeklinin boyutlarını, içindeki metin ne kadar değişirse değişsin korumak istiyorsanız **Do not Autofit** seçeneğini kullanmalısınız. Bu ayarı belirtmek için `AutofitType` özelliğini [TextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat) sınıfından `None` olarak ayarlayın.

![\"Do not Autofit\" ayarı PowerPoint'te](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Metin kutusunun kutusuna sığamayacak kadar uzun olması durumunda metin dışarı taşar.

## **Shrink Text on Overflow**

Metin kutusu çok uzun olduğunda, **Shrink text on overflow** seçeneği sayesinde metnin boyutu ve satır aralığı küçültülerek kutuya sığdırılabilir. Bu ayarı belirtmek için `AutofitType` özelliğini [TextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat) sınıfından `Normal` olarak ayarlayın.

![\"Shrink text on overflow\" ayarı PowerPoint'te](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
**Shrink text on overflow** seçeneği kullanıldığında, ayar yalnızca metin kutusuna sığamayacak kadar uzun olduğunda uygulanır.
{{% /alert %}}

## **Wrap Text**

Metin şeklin sınırlarını (yalnızca genişlik) aştığında, şekil içinde metnin kaydırılmasını istiyorsanız **Wrap text in shape** parametresini kullanmalısınız. Bu ayarı belirtmek için `WrapText` özelliğini [TextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat) sınıfından `NullableBool.True` olarak ayarlayın.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}}
Bir şekil için `WrapText` özelliğini `NullableBool.False` olarak ayarlarsanız, şeklin içindeki metin şeklin genişliğinden daha uzun olduğunda metin tek satır halinde şeklin sınırlarını aşar.
{{% /alert %}}

## **FAQ**

**Metin çerçevesinin iç kenar boşlukları AutoFit'i etkiler mi?**

Evet. Dolgu (iç kenar boşlukları) metin için kullanılabilir alanı azaltır; bu nedenle AutoFit daha erken devreye girer—yazı tipini küçültür ya da şekli daha erken yeniden boyutlandırır. AutoFit'i ayarlamadan önce kenar boşluklarını kontrol edin ve gerektiğinde ayarlayın.

**AutoFit manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**

Zorunlu satır sonları yerinde kalır ve AutoFit bunların etrafında yazı tipi boyutunu ve satır aralığını ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit'in metni ne kadar küçülteceğini azaltabilir.

**Tema yazı tipini değiştirmek veya yazı tipi ikamesi AutoFit sonuçlarını etkiler mi?**

Evet. Farklı glif ölçümlerine sahip bir yazı tipine ikame yapmak, metnin genişliğini/yüksekliğini değiştirir ve bu da son yazı tipi boyutunu ve satır kaydırmayı etkileyebilir. Herhangi bir yazı tipi değişikliğinden veya ikamesinden sonra slaytları tekrar kontrol edin.