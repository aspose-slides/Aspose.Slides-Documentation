---
title: WordArt Efektlerini .NET'te Oluşturun ve Uygulayın
linktitle: WordArt
type: docs
weight: 110
url: /tr/net/wordart/
keywords:
- WordArt
- WordArt Oluştur
- WordArt Şablonu
- WordArt Efekti
- Gölge Efekti
- Görünüm Efekti
- Parıltı Efekti
- WordArt Dönüşümü
- 3D Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım kılavuz, geliştiricilerin C#'ta profesyonel metinle sunumları geliştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri PowerPoint sunumlarınıza görsel olarak çekici, stilize metin eklemenizi sağlar. Aspose.Slides for .NET ile geliştiriciler, Microsoft PowerPoint'te olduğu gibi WordArt'ı programatik olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office yüklü olmasına ihtiyaç duymadan. Bu makale, .NET'te WordArt ile çalışmanın bir özetini sunar; metin dönüşümleri, dolgu stilleri, kenarlıklar, gölgeler ve diğer biçimlendirme seçeneklerini uygulayarak sunum içeriğinizi daha ifade edici ve ilgi çekici hale getirmenizi açıklar. WordArt, metni bir grafik nesnesi gibi işlemenizi sağlar. Metni daha çekici veya belirgin kılmak için uygulanan efektler veya özel değişikliklerden oluşur.

## **Basit Bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

Bu bölümde, Aspose.Slides for .NET kullanarak basit bir WordArt şablonu oluşturmayı ve metne uygulamayı inceleyeceğiz. WordArt, çarpıcı görsel efektler ve stillerle metin görünümünü artırmanın kolay bir yolunu sunar. WordArt oluşturma ve kullanma temel adımlarını öğrenerek, bu teknikleri herhangi bir projeye kolayca uyarlayabilir, sunumlarınızı daha canlı ve akılda kalıcı hâle getirebilirsiniz.

İlk olarak, aşağıdaki C# kodu ile basit bir metin oluşturuyoruz:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Şimdi, aşağıdaki kodu kullanarak efektin daha belirgin olması için metnin yazı tipi yüksekliğini daha büyük bir değere ayarlıyoruz:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

Burada, aşağıdaki kodu kullanarak metne SmallGrid desen dolgusunu uyguluyor ve 1 birim genişliğinde siyah bir metin kenarlığı ekliyoruz:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

Elde edilen metin:

![Basit WordArt şablonu](WordArt_template.png)

## **Diğer WordArt Efektlerini Uygulayın**

Temel dönüşümlerin yanı sıra, Aspose.Slides for .NET, metninizin görünümünü geliştirmek için çeşitli gelişmiş WordArt efektleri uygulamanıza olanak tanır. Bu efektler arasında kenarlıklar, dolgular, gölgeler, yansımalar ve parıltı efektleri bulunur. Bu özellikleri birleştirerek, sunumlarınızda öne çıkan göz alıcı metin stilleri oluşturabilirsiniz. Bu bölüm, bu efektleri basit, temiz kod örnekleriyle programatik olarak nasıl uygulayacağınızı gösterir.

### **Dış Gölge Efektleri Uygulayın**

Dış gölge efektleri, metnin etrafına bir gölge ekleyerek metnin arka plandan ayrılmasını ve derinlik hissi kazanmasını sağlar. Aspose.Slides for .NET, WordArt metnine dış gölgeleri kolayca uygulamanıza ve özelleştirmenize imkan tanır. Bu bölümde, gölge rengini, yönünü, mesafesini, bulanıklık yarıçapını ve daha fazlasını ayarlayarak istenen görsel etkiyi nasıl elde edeceğinizi öğreneceksiniz.

Aşağıdaki C# kod parçacığı, yukarıda oluşturulan metne bir gölge efekti uygular.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
}
```

Elde edilen metin:

![Dış Gölge efekti](outer_shadow_effect.png)

{{% alert color="info" %}} 

- OuterShadow ve PresetShadow birlikte kullanıldığında yalnızca OuterShadow efekti uygulanır.
- OuterShadow ve InnerShadow aynı anda kullanılırsa, oluşan etki PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki katına çıkar, PowerPoint 2007'de sadece OuterShadow efekti uygulanır.

{{% /alert %}}

### **Yansıtma Efektleri Uygulayın**

Bu bölümde, Aspose.Slides for .NET kullanarak slaytlarınıza yansıtma efektleri eklemeyi inceleyeceğiz. Yansıtma efektleri, metin veya şekillerinize şık ve modern bir görünüm kazandırarak önemli unsurları öne çıkarmaya ve sunumunuza derinlik katmaya yardımcı olur. Bu efektleri uygulama ve özelleştirme sürecini anlayarak, tasarım ihtiyaçlarınıza ve marka gereksinimlerinize uygun hâle getirebilirsiniz.

Aşağıdaki C# örnek kodu ile metne bir yansıtma efekti ekleyin:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableReflectionEffect();
    portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
}
```

Elde edilen metin:

![Yansıtma efekti](reflection_effect.png)

### **Parıltı Efektleri Uygulayın**

Bu bölümde, Aspose.Slides for .NET kullanarak metne parıltı efekti eklemeyi inceleyeceğiz. Parıltı efekti, metnin etrafında ışıklı bir kenarlık oluşturarak slaytlarınızın görsel cazibesini artırır. Renk ve yoğunluk gibi ayarları değiştirerek, parıltıyı tasarım ve marka ihtiyaçlarınıza göre kolayca uyarlayabilir, sunumunuzdaki ana noktaların izleyicinin dikkatini çekmesini sağlayabilirsiniz.

Aşağıdaki kodu kullanarak metne parıltı efekti uygulayın:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

Elde edilen metin:

![Parıltı efekti](glow_effect.png)

### **WordArt Dönüşümlerini Uygulayın**

Bu bölümde, Aspose.Slides for .NET ile WordArt'ta dönüşümler kullanmayı inceleyeceğiz. Dönüşümler, metni bükmenize, uzatmanıza veya şekillendirmenize olanak tanır ve benzersiz, görsel olarak çarpıcı efektler oluşturur. Bu teknikleri ustalaştırarak, metin şekillerini ve stillerini marka ya da yaratıcı vizyonunuza göre kolayca uyarlayabilir, etkileyici ve profesyonel bir sunum elde edebilirsiniz.

Aşağıdaki kodu kullanarak tüm metin bloğuna `Transform` özelliğini uygulayın:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

Elde edilen metin:

![WordArt dönüşümü](transform_effect.png)

{{% alert color="info" %}} 

Aspose.Slides for .NET, önceden tanımlı [dönüşüm türleri](https://reference.aspose.com/slides/tr/net/aspose.slides/textshapetype/) sağlar.

{{% /alert %}} 

### **Şekillere ve Metne 3D Efektleri Uygulayın**

Gerçekçi, göz alıcı görseller oluşturmak, sunumlarınızın etkisini önemli ölçüde artırabilir. Bu bölümde, Aspose.Slides for .NET kullanarak şekillere üç boyutlu (3D) efektler eklemeyi inceleyeceğiz. Derinlik, açı ve ışıklandırma gibi parametreleri manipüle ederek, izleyicinizin dikkatini hemen çeken etkileyici 3D dönüşümler oluşturabilirsiniz. İster ince vurgular ister dramatik illüzyonlar hedefleyin, bu özellikler tasarımınızı yükseltmek ve fikirlerinizi daha etkileyici bir şekilde iletmek için esnek yollar sunar.

Aşağıdaki örnek kodu kullanarak şekle bir 3D efekti ayarlayın:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.TextFrame.Text = "Aspose.Slides";

    autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
    autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

    autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelTop.Height = 12.5;
    autoShape.ThreeDFormat.BevelTop.Width = 11;

    autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    autoShape.ThreeDFormat.ExtrusionHeight = 6;

    autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    autoShape.ThreeDFormat.ContourWidth = 1.5;

    autoShape.ThreeDFormat.Depth = 3;

    autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

    autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

Elde edilen şekil:

![Şekil 3D efekti](shape_3D_effect.png)

Aşağıdaki örnek kodu kullanarak metne bir 3D efekti ayarlayın:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

Elde edilen metin:

![Metin 3D efekti](text_3D_effect.png)

{{% alert color="info" %}} 

Metne veya şekline 3D efektlerinin uygulanması—ve bu efektlerin birbirleriyle etkileşimi—belirli kurallara tabidir. Metni ve onun bulunduğu şekli içeren bir sahneyi düşünün. Bir 3D efekt, nesnenin 3D temsili ve yerleştirildiği sahneyi kapsar.

- Şekil ve metin için ayrı ayrı sahne ayarlandıysa, şeklin sahnesi önceliklidir ve metnin sahnesi göz ardı edilir.
- Şeklin kendi sahnesi yoksa ancak bir 3D temsili varsa, metnin sahnesi kullanılır.
- Şeklin hiç 3D efekti yoksa, düz olarak değerlendirilir ve 3D efekt yalnızca metne uygulanır.

Bu davranışlar, [ThreeDFormat.LightRig](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/lightrig/) ve [ThreeDFormat.Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/camera/) özellikleriyle ilgilidir.

{{% /alert %}} 

## **SSS**

### Farklı yazı tipleri veya script'ler (ör. Arapça, Çince) ile WordArt efektleri kullanabilir miyim?

Evet, Aspose.Slides for .NET Unicode desteği sağlar ve tüm büyük yazı tipleri ve script'lerle çalışır. WordArt efektleri (gölge, dolgu, kenarlık vb.) dil bağımsızdır; ancak yazı tipi bulunabilirliği ve render edilmesi sistem yazı tiplerine bağlı olabilir.

### WordArt efektlerini slayt ana teması öğelerine uygulayabilir miyim?

Evet, ana slayt üzerindeki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine WordArt efektleri uygulayabilirsiniz. Ana düzente yapılan değişiklikler tüm ilişkili slaytlara yansır.

### WordArt efektleri sunum dosya boyutunu etkiler mi?

Biraz. Gölgeler, parıltılar ve degrade dolgular gibi WordArt efektleri, ek biçimlendirme meta verileri eklediği için dosya boyutunu hafifçe artırabilir; ancak fark genellikle ihmal edilebilir düzeydedir.

### WordArt efektlerinin sonucunu sunumu kaydetmeden önizleyebilir miyim?

Evet, WordArt içeren slaytları [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) veya [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/) arayüzlerinin `GetImage` yöntemiyle PNG, JPEG gibi görüntülere render edebilirsiniz. Bu sayede, tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellekte veya ekranda önizleyebilirsiniz.