---
title: .NET kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D sunum
- 3D döndürme
- 3D derinlik
- 3D ekstrüzyon
- 3D degrade
- 3D metin
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET ile Aspose.Slides kullanarak PowerPoint şekilleri ve metni için 3D efektler uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for .NET, şekiller ve metin için PowerPoint tarzı 3D biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, köşe yuvarlamaları, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3D metin gibi 3D etkileri kapsar.

{{% alert color="info" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3D biçimlendirme etkileriyle ilgilidir. Ayrı ayrı 3D model dosyalarının eklenmesi ya da düzenlenmesiyle ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D etkileri dışa aktarılan 2D çıktıya renderlar.
{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [IShape.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/threedformat) özelliğini kullanın. Bu özellik, o şekil için 3D sahneyi kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat)’ı ortaya çıkarır.

Metin için, [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/threedformat) özelliğini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli özellikler şunlardır:

| Özellik | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/camera) | Bakış noktası, ön ayarlı kamera türü, dönüş, zoom ve perspektif. | Nesneyi 3D uzayda döndürmek veya PowerPoint 3D dönüş ön ayarını eşleştirmek istediğinizde. |
| [LightRig](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/lightrig) | Işık ön ayarı, yön ve ışık dönüşü. | 3D yüzey üzerindeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek istediğinizde. |
| [Material](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/material) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, yumuşak, parlak veya metalik görünmesini istediğinizde. |
| [ExtrusionHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusionheight) | Şeklin ön yüzünden geriye ne kadar uzandığı. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürmek istediğinizde. |
| [ExtrusionColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Ekstrüde edilen kenarların rengi. | Derinliği görünür kılmak veya kenar rengini ön doldurma ile uyumlu hale getirmek istediğinizde. |
| [Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekil veya metin için, özellikle köşe yuvarlaması ve malzeme ayarlarıyla birlikte, derinliği ince ayarlamak istediğinizde. |
| [BevelTop](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/beveltop) ve [BevelBottom](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/bevelbottom) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşak veya kalıplanmış bir kenar eklemek istediğinizde. |
| [ContourColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/contourcolor) ve [ContourWidth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D nesnenin etrafındaki kontur. | Render çıktısında nesne sınırını vurgulamak istediğinizde. |

## **3D Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3D görünmesi için genellikle dört tür ayar gerekir:

- Kamera ayarları, çünkü varsayılan önyüz ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma kenarların ve yüzlerin okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl yansıdığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şekil kalınlığa ihtiyaç duyar.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3D biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsü olarak renderlar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

Renderlanan slayt görüntüsü, dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzünde beyaz 3D metin bulunan mavi 3D dikdörtgenin renderlanmış görüntüsü](img_01_01.png)

## **Kamerayı Kullanarak Şekli Döndürme**

PowerPoint’te 3D döndürme, 3‑D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API’si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3‑D Rotation bölmesi](img_02_01.png)

Aspose.Slides’te kamera türünü ve dönüşünü [IThreeDFormat.Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/camera) aracılığıyla ayarlayın:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez; PowerPoint ve Aspose.Slides’in render sırasında kullandığı 3D bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şeklin ön yüzünün arkasına uzatarak kalın görünmesini sağlar. PowerPoint’te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini belirler.

![Ekstrüzyon renk ve ekstrüzyon yüksekliği özelliklerine eşlenmiş PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlık için [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusionheight), yan renk için ise [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusioncolor) ayarlayın:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

PowerPoint’in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği köşe yuvarlaması, malzeme ve metin efektleriyle birleştirmeniz gerektiğinde [IThreeDFormat.Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/depth) kullanın. Çoğu şekil senaryosunda, `ExtrusionHeight` daha açık bir ayardır çünkü görünür ekstrüzyonu doğrudan ifade eder.

## **3D Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3D biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını sürdürebilirsiniz.

Bu örnek, şekle degrade doldurma ve yan yüzlere daha koyu bir ekstrüzyon rengi uygular:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

Renderlanan çıktı, ön yüzde degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑turuncu degrade doldurma ve turuncu ekstrüzyonlu 3D dikdörtgenin renderlanmış görüntüsü](img_02_03.png)

Resim doldurması kullanmak isterseniz, resmi sunuma ekleyin ve şekil doldurmasına atayın:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Resim ön yüzde renderlanırken, ekstrüzyon 3D yan yüz olarak renderlanır:

![Ön yüzde fotoğraf doldurma ve turuncu ekstrüzyonlu 3D dikdörtgenin renderlanmış görüntüsü](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirmesi şekil gövdesini etkiler. Metin 3D biçimlendirmesi ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarları gerektirdiği WordArt benzeri efektler için yararlıdır.

Aşağıdaki örnek, desenli bir doldurma ile metin oluşturur, bir WordArt dönüşümü uygular ve [ITextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat) üzerinde 3D ayarları yapılandırır:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

Metin, kavisli, ekstrüde 3D harfler olarak renderlanır:

![Kavisli WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu 3D metnin renderlanmış görüntüsü](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit‑düzen formatlarına renderlarken veya dışa aktarırken 3D sahne rasterleştirilir veya 2D sonuç olarak çıkışa çizilir. Bu, slaytları [PNG](/slides/tr/net/convert-powerpoint-to-png/), [PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/net/convert-powerpoint-to-html/) olarak renderladığınızda veya [video dönüştürme](/slides/tr/net/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

Şunları aklınızda tutun:

- Dışa aktarılan görüntüler ve PDF’ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Final görünümü, kamera, ışık rig’i, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin birleşimine bağlıdır.
- Kalıtılmış veya tema‑bazlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkin şekil özelliklerini](/slides/tr/net/shape-effective-properties/) okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3D biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları olarak değil, renderlanmış bir görüntü olarak saklanır.

## **SSS**

### Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?

Aspose.Slides, şekiller ve metin için PowerPoint 3D etkilerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF’ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3D sahneler haline getirmez. PPTX’te, format destekliyorsa 3D biçimlendirme PowerPoint içinde düzenlenebilir kalır.

### 3D model ile 3D efekt arasındaki fark nedir?

3D model, sunuma eklenen ayrı bir 3D nesnedir. 3D efekt ise bir PowerPoint şekli veya metnine uygulanan, döndürme, ekstrüzyon, köşe yuvarlaması, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3D efektleri ele alır.

### Görünür bir 3D şekil için hangi ayarlar gereklidir?

En azından bir kamera döndürmesi ve ekstrüzyon ya da derinlik ayarı yapılmalıdır. Uygulamada, renderlanan yüzlerin belirgin vurgular ve gölgeler alması için bir ışık rig’i ve malzeme de ayarlanması önerilir.

### Hem şekillere hem de metne 3D efektleri uygulayabilir miyim?

Evet. Şekil gövdesi için [IShape.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/threedformat), metin için ise [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/threedformat) kullanın.

### 3D efektler görüntüler, PDF, HTML veya video karelerine dışa aktarıldığında görünür mü?

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüştürme için kullanılan kareler üretildiğinde 3D efektleri renderlar. Dışa aktarılmış çıktı, renderlanmış görünümü içerir; düzenlenebilir bir 3D nesne içermez.

### Kalıtım ve tema ayarları uygulandıktan sonra nihai 3D değerlerini okuyabilir miyim?

Evet. Nihai kamera, ışık rig’i, köşe yuvarlaması ve ilgili 3D değerlerini okumak için [Şekil Etkin Özellikleri](/slides/tr/net/shape-effective-properties/) bölümünde açıklanan etkin biçimlendirme API’lerini kullanın.