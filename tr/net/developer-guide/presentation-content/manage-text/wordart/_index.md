---
title: WordArt Efektlerini .NET'te Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/net/wordart/
keywords:
- WordArt
- WordArt oluştur
- WordArt şablonu
- WordArt efekti
- gölge efekti
- görünüm efekti
- parıltı efekti
- WordArt dönüşümü
- 3D efekti
- dış gölge efekti
- iç gölge efekti
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin C#'ta profesyonel metinle sunumları geliştirmelerine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel olarak çekici, stilize metin eklemenizi sağlar. Aspose.Slides for .NET ile geliştiriciler, Microsoft PowerPoint'te olduğu gibi WordArt'ı programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office yüklü olmasına gerek yok. Bu makale, .NET'te WordArt ile çalışmaya genel bir bakış sunar; metin dönüşümleri, dolgu stilleri, kenarlıklar, gölgeler ve sunum içeriğinizi daha ifadeli ve ilgi çekici hâle getiren diğer biçimlendirme seçeneklerini nasıl uygulayacağınızı açıklar. WordArt, metni grafik nesnesi gibi işlemeyi sağlar. Metni daha çekici veya belirgin hâle getirmek için uygulanan efektler veya özel değişiklikler bütünüdür.

## **Basit Bir WordArt Şablonu Oluşturma ve Metne Uygulama**

Bu bölümde, Aspose.Slides for .NET kullanarak basit bir WordArt şablonu oluşturmayı ve metne uygulamayı inceleyeceğiz. WordArt, çarpıcı görsel efektler ve stillerle metnin görünümünü geliştirmek için kolay bir yol sunar. WordArt oluşturma ve kullanımının temel adımlarını öğrenerek bu teknikleri herhangi bir projeye uyarlayabilir, sunumlarınızı daha canlı ve akılda kalıcı hâle getirebilirsiniz.

İlk olarak, aşağıdaki C# kodu ile basit bir metin oluşturuyoruz:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Şimdi, efekti daha belirgin hâle getirmek için metnin yazı tipi yüksekliğini daha büyük bir değere ayarlıyoruz:

```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```

Burada, metne SmallGrid desen dolgusunu uyguluyor ve 1 genişliğinde siyah bir metin kenarlığı ekliyoruz:

```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Oluşan metin:

![Basit WordArt şablonu](WordArt_template.png)

## **Diğer WordArt Efektlerini Uygulama**

Temel dönüşümlere ek olarak, Aspose.Slides for .NET, metninizin görünümünü artırmak için çeşitli gelişmiş WordArt efektleri uygulamanıza olanak tanır. Bu efektler arasında kenarlıklar, dolgular, gölgeler, yansımalar ve parıltı efektleri bulunur. Bu özellikleri birleştirerek sunumlarınızda öne çıkan göz alıcı metin stilleri oluşturabilirsiniz. Bu bölüm, bu efektleri basit ve temiz kod örnekleriyle programlı olarak nasıl uygulayacağınızı gösterir.

### **Dış Gölge Efektlerini Uygulama**

Dış gölge efektleri, metnin konturunun arkasına bir gölge ekleyerek derinlik ve arka plandan ayrışma hissi yaratır. Aspose.Slides for .NET, WordArt metnine dış gölgeleri kolayca uygulamanıza ve özelleştirmenize imkan verir. Bu bölümde gölge rengi, yönü, mesafesi, bulanıklık yarıçapı ve daha fazlasını ayarlayarak istenen görsel etkiyi elde etmeyi öğreneceksiniz.

Aşağıdaki C# kod parçacığı, yukarıda oluşturulan metne gölge efekti uygular.

```cs
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
```

Oluşan metin:

![Dış Gölge efekti](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- OuterShadow ve PresetShadow birlikte kullanıldığında, yalnızca OuterShadow efekti uygulanır.  
- OuterShadow ve InnerShadow aynı anda kullanıldığında, ortaya çıkan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki katına çıkarken, PowerPoint 2007'de yalnızca OuterShadow efekti uygulanır.  
{{% /alert %}}

### **Yansıma Efektlerini Uygulama**

Bu bölümde, Aspose.Slides for .NET kullanarak slaytlarınıza yansıma efektleri eklemeyi inceleyeceksiniz. Yansıma efektleri, metninize veya şekillerinize şık ve modern bir görünüm kazandırarak önemli öğelerin öne çıkmasını sağlar ve sunumunuza derinlik katar. Bu efektleri uygulama ve özelleştirme sürecini anlayarak tasarım ihtiyaçlarınıza ve marka gereksinimlerinize uygun hâle getirebilirsiniz.

Aşağıdaki C# kod örneğiyle metne bir yansıma efekti ekleyin:

```cs
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
```

Oluşan metin:

![Yansıma efekti](reflection_effect.png)

### **Parıltı Efektlerini Uygulama**

Bu bölümde, Aspose.Slides for .NET kullanarak metne bir parıltı efekti eklemeyi keşfedeceksiniz. Parıltı efekti, metninizi ışıklı bir konturla vurgulayarak slaytlarınızın görsel çekiciliğini artırır. Renk ve yoğunluk gibi ayarları değiştirerek parıltıyı tasarım ve marka ihtiyaçlarınıza göre kolayca uyarlayabilirsiniz; böylece sunumunuzdaki ana noktalar izleyicinin dikkatini çeker.

Aşağıdaki kodla metne parlak bir parıltı efekti uygulayın:

```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Oluşan metin:

![Parıltı efekti](glow_effect.png)

### **WordArt Dönüşümlerini Uygulama**

Bu bölümde, Aspose.Slides for .NET ile WordArt'ta dönüşümleri nasıl kullanacağınızı inceleyeceksiniz. Dönüşümler, metni bükmenize, uzatmanıza veya eğmenize olanak tanır; benzersiz ve görsel açıdan çarpıcı efektler oluşturur. Bu tekniklere hâkim olarak, metin şekillerini ve stillerini marka kimliğinize veya yaratıcı vizyonunuza uygun hâle getirip etkileyici ve profesyonel bir sunum hazırlayabilirsiniz.

Aşağıdaki kodu kullanarak tüm metin bloğuna uygulanacak `Transform` özelliğini ayarlayın:

```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Oluşan metin:

![WordArt dönüşümü](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides for .NET, önceden tanımlı [dönüşüm türleri](https://reference.aspose.com/slides/tr/net/aspose.slides/textshapetype/) sağlar.  
{{% /alert %}} 

### **Şekillere ve Metne 3D Efektleri Uygulama**

Gerçekçi ve göz alıcı görseller yaratmak, sunumlarınızın etkisini büyük ölçüde artırabilir. Bu bölümde, Aspose.Slides for .NET kullanarak şekillere üç boyutlu (3D) efektler eklemeyi inceleyeceksiniz. Derinlik, açı ve aydınlatma gibi parametreleri manipüle ederek, izleyicinizin dikkatini çeken etkileyici 3D dönüşümler üretebilirsiniz. İster ince vurgular ister dramatik illüzyonlar hedefleyin, bu özellikler tasarımınızı yükseltmek ve fikirlerinizi daha çekişmeli bir şekilde iletmek için esnek yollar sunar.

Aşağıdaki örnek kodu kullanarak şekle bir 3D efekti ayarlayın:

```cs
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
```

Oluşan şekil:

![Şekil 3D efekti](shape_3D_effect.png)

Aşağıdaki örnek kodu kullanarak metne bir 3D efekti ayarlayın:

```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Oluşan metin:

![Metin 3D efekti](text_3D_effect.png)

{{% alert color="primary" %}} 
Metne veya şekline uygulanan 3D efektlerin ve bu efektlerin birbirleriyle etkileşiminin belirli kuralları vardır. Metni ve bu metni içeren şekli içeren bir sahneyi düşünün. Bir 3D efekt, nesnenin 3D temsili ve üzerine yerleştirildiği sahneyi içerir.

- Eğer sahne hem şekil hem de metin için ayarlanmışsa, şeklin sahnesi önceliklidir ve metnin sahnesi yok sayılır.  
- Eğer şeklin kendi sahnesi yoksa ancak bir 3D temsili varsa, metnin sahnesi kullanılır.  
- Şeklin hiç 3D efekti yoksa, düz kabul edilir ve 3D efekt yalnızca metne uygulanır.  

Bu davranışlar, [ThreeDFormat.LightRig](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/lightrig/) ve [ThreeDFormat.Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/camera/) özellikleriyle ilişkilidir.  
{{% /alert %}} 

## **SSS**

**Farklı yazı tipleri veya betikler (ör. Arapça, Çince) ile WordArt efektlerini kullanabilir miyim?**

Evet, Aspose.Slides for .NET Unicode desteği sağlar ve tüm büyük yazı tipleri ve betiklerle çalışır. WordArt efektleri (gölge, dolgu, kenarlık vb.) dil bağımsız olarak uygulanabilir; ancak yazı tipi bulunabilirliği ve render edilmesi sistem yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt ana sayfası (master) öğelerine uygulayabilir miyim?**

Evet, başlık yer tutucuları, alt bilgi bölümleri veya arka plan metni gibi master slaytlardaki şekillere WordArt efektleri uygulayabilirsiniz. Master düzeninde yapılan değişiklikler, ilişkili tüm slaytlara yansıtılır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

Bir miktar. Gölgeler, parıltılar ve degrade dolgular gibi WordArt efektleri, ek biçimlendirme meta verileri eklediği için dosya boyutunu hafifçe artırabilir; ancak fark genellikle ihmal edilebilir düzeydedir.

**WordArt efektlerinin sonucunu sunumu kaydetmeden önizleyebilir miyim?**

Evet, [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) veya [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/) arayüzlerinden `GetImage` yöntemiyle WordArt içeren slaytları PNG, JPEG gibi görüntülere render edebilirsiniz. Böylece tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellek içinde veya ekranda önizleyebilirsiniz.