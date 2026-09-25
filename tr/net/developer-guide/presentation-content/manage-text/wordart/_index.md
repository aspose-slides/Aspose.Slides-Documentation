---
title: WordArt Efektlerini .NET'te Oluşturun ve Uygulayın
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
- yansıma efekti
- ışıldama efekti
- WordArt dönüşümü
- 3B efekti
- dış gölge efekti
- iç gölge efekti
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım kılavuz, geliştiricilerin C# içinde profesyonel metinle sunumları geliştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, metni dolgu, kontur, gölge, yansıma, ışıldama, dönüşüm ve 3B biçimlendirme ile stil vermenizi sağlar. Bu makale, Microsoft Office yüklü olmadan Aspose.Slides for .NET kullanarak PowerPoint sunumlarında bu efektleri nasıl oluşturacağınızı ve özelleştireceğinizi açıklar.

## **Basit bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

Aşağıdaki örnekler, metin, yazı tipi, desen dolgusu ve konturu ayarlayarak basit bir WordArt stili oluşturur.

Her örnek yeni bir sunum oluşturur ve ilk slaytına bir dikdörtgen ekler; giriş dosyasına ihtiyaç yoktur. İlk örnek metni "Aspose.Slides" olarak ayarlar. Şeklin konumu ve boyutları puan cinsinden ölçülür:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Biçimin daha belirgin olmasını sağlamak için yazı tipini Arial Black ve 36 puan olarak ayarlayın:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Koyu turuncu ön plan ve beyaz arka plan ile bir [SmallGrid](https://reference.aspose.com/slides/tr/net/aspose.slides/patternstyle/) deseni uygulayın, ardından 1 puan genişliğinde siyah bir metin konturu ekleyin:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Ortaya çıkan metin:

![Basit WordArt şablonu](WordArt_template.png)

## **Diğer WordArt Efektlerini Uygulayın**

Aşağıdaki örnekler, metne gölge, yansıma, ışıldama, dönüşüm ve 3B efektler nasıl uygulanacağını gösterir.

### **Dış Gölge Efektlerini Uygulayın**

Dış gölge, metnin arkasına bir gölge yerleştirerek derinlik kazandırır. Renk, yön, mesafe, bulanıklaştırma yarıçapı, ölçek ve eğim gibi özelliklerini özelleştirebilirsiniz.

Bu örnek [EnableOuterShadowEffect](https://reference.aspose.com/slides/tr/net/aspose.slides/effectformat/enableoutershadoweffect/) metodunu çağırır ve 4 puan bulanık yarıçap, 230 derece yön ve 30 puan mesafe ile siyah bir gölge ayarlar. Ölçek değeri 100 gölgenin boyutunu korur, yatay eğim ise 20 derece eğim ekler. Alfa dönüşümü opaklığı %32 olarak ayarlar:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

Ortaya çıkan metin:

![Dış Gölge efekti](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Dış ve önceden tanımlı gölgeler birlikte kullanıldığında, yalnızca dış gölge uygulanır.
- Dış ve iç gölgeler aynı anda kullanılırsa, ortaya çıkan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki katına çıkar, PowerPoint 2007'de ise sadece dış gölge uygulanır.
{{% /alert %}}

### **Yansıma Efektlerini Uygulayın**

Yansıma, metnin aynalı bir kopyasını oluşturur. Konum, ölçek, bulanıklık ve opaklığı ayarlayarak görünümünü kontrol edebilirsiniz.

Bu örnek [EnableReflectionEffect](https://reference.aspose.com/slides/tr/net/aspose.slides/effectformat/enablereflectioneffect/) metodunu çağırır ve yansımayı -100% ölçekle dikey olarak ters çevirir. 0,5 puan bulanık yarıçap ve 4,72 puan mesafe kullanır. Opaklık, yansımanın 0% ile 60% konumları arasında %60'tan %0,9'a düşer:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

Ortaya çıkan metin:

![Yansıma efekti](reflection_effect.png)

### **Işıldama Efektlerini Uygulayın**

Işıldama, metnin etrafına yumuşak renkli bir kontur ekler. Renk, opaklık ve yarıçapını ayarlayarak efekti kontrol edebilirsiniz.

Bu örnek [EnableGlowEffect](https://reference.aspose.com/slides/tr/net/aspose.slides/effectformat/enablegloweffect/) metodunu çağırır ve %54 opaklıkta, 7 puan yarıçapta kırmızı bir ışıldama uygular:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Ortaya çıkan metin:

![Işıldama efekti](glow_effect.png)

### **WordArt Dönüşümlerini Uygulayın**

WordArt dönüşümleri bir metin bloğunu bükebilir, uzatabilir veya çarpıtabilir.

Metin çerçevesinin tamamını yukarı doğru kavis yapmak için [Transform](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/transform/) özelliğini [ArchUpPour](https://reference.aspose.com/slides/tr/net/aspose.slides/textshapetype/) olarak ayarlayın:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Ortaya çıkan metin:

![WordArt dönüşümü](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET, önceden tanımlanmış bir dizi [dönüşüm türü](https://reference.aspose.com/slides/tr/net/aspose.slides/textshapetype/) sunar.
{{% /alert %}}

### **Şekillere ve Metne 3B Efektler Uygulayın**

Bir şekle ya da metnine 3B efektler uygulayabilirsiniz. Koniç, ekstrüzyon, aydınlatma ve kamera ayarları ortaya çıkan görünümü kontrol eder.

Bu örnek, dikdörtgene dairesel koniçler, turuncu ekstrüzyon ve koyu kırmızı bir kontur eklemek için [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) kullanır. Koniç boyutları, ekstrüzyon yüksekliği, kontur genişliği ve derinlik puan cinsinden ölçülür. Plastik bir malzeme, Z ekseni etrafında 40 derece döndürülmüş dengeli aydınlatma ve perspektif kamera görünümünü tanımlar:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
```

Ortaya çıkan şekil:

![Şekil 3B efekti](shape_3D_effect.png)

Bu örnek, metne benzer 3B biçimlendirmeyi [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/threedformat/) aracılığıyla uygular. Daha küçük koniçler harf kenarlarını şekillendirirken, ekstrüzyon ve aydınlatma metne derinlik katar:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
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
```

Ortaya çıkan metin:

![Metin 3B efekti](text_3B_effect.png)

{{% alert color="info" title="Note" %}}
Metne veya şekillere 3B efektlerin uygulanması—ve bu efektler arasındaki etkileşim—belirli kurallara göre yönetilir. Hem metni hem de onu içeren şekli içeren bir sahneyi düşünün. Bir 3B efekt, nesnenin 3B temsilini ve yerleştirildiği sahneyi içerir.

- Eğer sahne hem şekil hem de metin için ayarlanmışsa, şeklin sahnesi öncelik kazanır ve metnin sahnesi yoksayılır.
- Şeklin kendine ait bir sahnesi yoksa ama bir 3B temsili varsa, metnin sahnesi kullanılır.
- Şeklin hiç 3B efekti yoksa, şekil düz olarak kabul edilir ve 3B efekt yalnızca metne uygulanır.

Bu davranışlar [ThreeDFormat.LightRig](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/lightrig/) ve [ThreeDFormat.Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/camera/) özellikleriyle ilişkilidir.
{{% /alert %}}

Metni düz ve okunabilir tutarken şeklin 3B biçimlendirmesini korumak için, her iki ayarın karşılaştırmasını ve tam bir C# örneğini içeren [Keep Text Flat on a 3D Shape](/slides/tr/net/3d-presentation/) sayfasına bakın.

## **SSS**

**Farklı yazı tipleri veya betikler (örn. Arapça, Çince) ile WordArt efektlerini kullanabilir miyim?**

Evet, Aspose.Slides for .NET Unicode'ı destekler ve tüm büyük yazı tipleri ve betiklerle çalışır. Gölge, doldurma ve kontur gibi WordArt efektleri, dil ne olursa olsun uygulanabilir; ancak yazı tipi bulunabilirliği ve renderleme sistem yazı tiplerine bağlı olabilir.

**Slayt ana düzeni (master) öğelerine WordArt efektlerini uygulayabilir miyim?**

Evet, başlık yer tutucuları, alt bilgi veya arka plan metni gibi ana slayt üzerindeki şekillere WordArt efektleri uygulayabilirsiniz. Ana düzen üzerinde yapılan değişiklikler, ilişkili tüm slaytlara yansıyacaktır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

Biraz. Gölge, ışıldama ve degrade dolgu gibi WordArt efektleri, ek biçimlendirme meta verileri nedeniyle dosya boyutunu biraz artırabilir, ancak fark genellikle önemsizdir.

**WordArt efektlerinin sonucunu sunumu kaydetmeden ön izleyebilir miyim?**

Evet, WordArt içeren slaytları [ISlide.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) ile görüntülere (ör. PNG, JPEG) renderleyebilir veya tek tek şekilleri [IShape.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getimage/) ile renderleyebilirsiniz. Bu sayede tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu hafızada veya ekranda ön izleyebilirsiniz.