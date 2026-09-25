---
title: .NET Kullanarak Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/net/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B dönüş
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET ile Aspose.Slides kullanarak PowerPoint şekilleri ve metinleri için 3B efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgu ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for .NET, şekil ve metin için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale dönüşüm, ekstrüzyon, köşe yuvarlama, aydınlatma, malzeme, degrade veya resim dolguları ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Bağımsız 3B model dosyalarını ekleme veya düzenleme hakkında değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya renderlar.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [IShape.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/threedformat) özelliğini kullanın. Bu özellik, o şeklin 3B sahnesini kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat) nesnesini ortaya çıkarır.

Metin için, [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/threedformat) özelliğini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli özellikler şunlardır:

| Özellik | Kontrol ettiği şey | Ne zaman kullanılmalı |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/camera) | Bakış noktası, önceden ayarlanmış kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B alanda döndürün veya bir PowerPoint 3B döndürme ön ayarıyla eşleştirin. |
| [LightRig](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/lightrig) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzey üzerindeki vurgular ve gölgelerin nasıl göründüğünü değiştirin. |
| [Material](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/material) | Yüzey malzemesi, düz, mat, plastik veya metal gibi. | Aynı geometriyi daha düz, yumuşak, parlak ya da metalik yapın. |
| [ExtrusionHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusionheight) | Şeklin ön yüzünden geriye doğru ne kadar uzandığı. | Düz bir şekli belirgin kalın bir 3B nesne haline getirin. |
| [ExtrusionColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılın ya da yan rengi ön dolgu ile uyumlu hale getirin. |
| [Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3B biçimlendirmesi tarafından kullanılan ek 3B derinlik. | Özellikle köşe yuvarlama ve malzeme ayarlarıyla birlikte şekiller veya metin için derinliği ince ayar yapın. |
| [BevelTop](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/bevelbottom) | Ön ve arka yüzlerde yükseltilmiş ya da yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşatılmış veya kalıplı bir kenar ekleyin. |
| [ContourColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/contourwidth) | 3B nesnenin etrafındaki kontur. | Renderlanan çıktıda nesne sınırını vurgulayın. |

## **3B Şekil Oluşturma**

Bir şekil, ikna edici bir 3B görünüm elde etmeden önce genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüz ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlandığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığı gerekir.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3B biçimlendirme uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek slaytı iki katı varsayılan boyutta bir PNG görüntüsüne renderlar ve sunumu PPTX olarak kaydeder.

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

Renderlanmış slayt görüntüsü dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metin bulunan, mavi 3B dikdörtgenin renderlanmış görüntüsü](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint'te 3B döndürme, 3-D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'te kameraya [IThreeDFormat.Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/camera) aracılığıyla erişin. Bu örnek bir dikdörtgen oluşturur, ortografik bir ön görünüm seçer ve X, Y ve Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

İzleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kamerayı kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides tarafından renderlandığında kullanılan 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şeklin ön yüzünden geriye doğru uzatarak kalın görünmesini sağlar. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini ayarlar.

![Ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenen PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlık için [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusionheight), yan renk için ise [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusioncolor) ayarlayın. Bu örnek dikdörtgene mor yanlarla 100 puanlık bir ekstrüzyon verir ve kalınlığını göstermek için kamerayı döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

[IThreeDFormat.Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/depth) özelliği bir 3B şeklin derinliğini ayarlar. [ExtrusionHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusionheight) özelliği, bu örnekte gösterildiği gibi ekstrüzyon efektinin yüksekliğini kontrol eder.

## **3B Efektlerle Degrade veya Resim Dolguları Kullanma**

3B biçimlendirme, şekil dolgusundan bağımsızdır. Ön yüze katı bir renk, degrade, desen veya resim dolgusu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanmaya devam edebilirsiniz.

Bu örnek ön yüze mavi‑turuncu bir degrade, 150 puanlık ekstrüzyona koyu turuncu bir renk uygular. Degrade durakları 0 ve 100, degrade başlangıç ve bitişini işaret eder. Kamera döndürme değerleri derecedir. Slayt iki katı varsayılan boyutta bir PNG görüntüsüne renderlanır:

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

Renderlanan çıktı ön yüze degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑turuncu degrade dolgu ve turuncu ekstrüzyonlu 3B dikdörtgenin renderlanmış görüntüsü](img_02_03.png)

Bir resim dolgusu kullanmak için, resmi sunuma ekleyin ve şekil dolgusuna atayın. Bu örnek çalıştırma dizininde "image.jpg" adlı bir dosyanın mevcut olmasını gerektirir. Resmi dikdörtgeni dolduracak şekilde uzatır, 150 puanlık bir ekstrüzyon uygular ve kamera döndürmesini derecelerde ayarlar. Şekli dosya kaydetmeden ya da renderlamadan bellekte yapılandırır:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Resim ön yüzde renderlanırken, ekstrüzyon 3B yan yüz olarak renderlanır:

![Ön yüzünde fotoğraf dolgusu ve turuncu ekstrüzyonlu 3B dikdörtgenin renderlanmış görüntüsü](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt‑benzeri efektler için kullanışlıdır.

Aşağıdaki örnek turuncu‑beyaz bir ızgara deseniyle metin oluşturur, yukarı doğru bir yay uygular ve 3B ayarları [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/threedformat) aracılığıyla yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindendir, ışık döndürmesi derecedir. Şekil dolgu ve kontur gizlidir, sadece metin görünür. Örnek iki katı varsayılan slayt boyutunda bir PNG görüntüsü renderlar ve sunumu PPTX olarak kaydeder:

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

Metin eğimli, ekstrüde edilmiş 3B harfler olarak renderlanır:

![Yukarı doğru bükülmüş WordArt dönüşümü, turuncu desen dolgusu ve koyu ekstrüzyonlu 3B metnin renderlanmış görüntüsü](img_02_05.png)

## **3B Şekilde Metni Düz Tutma**

Bir şeklin 3B görünümünü korurken metnin okunabilir olmasını sağlamak için [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/keeptextflat/) özelliğini [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/textframeformat/) üzerinden ayarlayın. Değer `true` olduğunda metin 3B sahneden dışarıda kalır. Değer `false` olduğunda metin sahneye katılır ve 3B yönelimini izler.

Bu ayar, şeklin kamera, aydınlatma, malzeme ve ekstrüzyon gibi 3B biçimlendirmesini kaldırmaz; bu ayarlar [IShape.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/threedformat/) aracılığıyla hâlâ yapılandırılmıştır. Ayrıca sıradan döndürmeden farklıdır. [IShape.Rotation](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/rotation/) şekli slayt düzleminde döndürürken, [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/rotationangle/) metnin kendi sınırlama kutusu içindeki özel döndürmesini kontrol eder. Metni 3B sahneden dışarıda tutmak bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek mavi bir dikdörtgen ve metin oluşturur, orijinalin yanına bir kopyasını yerleştirir. Her iki şeklin de aynı 3B biçimlendirmesi vardır; yalnızca metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir, ekstrüzyon yüksekliği 40 puandır. Örnek sunumu PPTX olarak kaydeder ve karşılaştırma slaytını iki katı varsayılan boyutta PNG’ye renderlar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

Solda metin 3B yönelime uyar. Sağda ise metin düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünen ekstrüzyon ve 3B yönelime sahiptir.

![Yan yana 3B dikdörtgenler: KeepTextFlat solda false, sağda true olarak gösteriliyor](keep_text_flat.png)

## **Dışa Aktarım ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydedildiğinde 3B biçimlendirmeyi korur. Sabit‑sayfa formatlarına renderlandığında veya dışa aktarıldığında 3B sahne rasterleştirilir veya 2B sonuç olarak çıktıya çizilir. Bu, slaytları [PNG](/slides/tr/net/convert-powerpoint-to-png/), [PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/net/convert-powerpoint-to-html/) olarak renderladığınızda veya [video dönüştürme](/slides/tr/net/convert-powerpoint-to-video/) için kareler ürettiğinizde geçerlidir.

Bu noktalara dikkat edin:

- Dışa aktarılan görüntüler ve PDF’ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig’i, malzeme, ekstrüzyon, dolgu ve slayt ölçeklemesinin kombinasyonuna bağlıdır.
- Kalıtlama veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özellikleri](/slides/tr/net/shape-effective-properties/) API’sini okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar yerine renderlanmış olarak gelir.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekil ve metin için PowerPoint 3B efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF’ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3B sahneler oluşturmaz. PPTX içinde, format destekliyorsa 3B biçimlendirme PowerPoint’te düzenlenebilir kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise bir PowerPoint şekli veya metnine uygulanan dönüşüm, ekstrüzyon, köşe yuvarlama, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3B efektleri kapsar.

**Görünür bir 3B şekil için hangi ayarlar gerekir?**

En az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı gereklidir. Pratikte, renderlanan yüzlerin net vurgular ve gölgeler alması için bir ışık rig’i ve malzeme de ayarlanmalıdır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/threedformat), metin için ise [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/threedformat) kullanın.

**3B efektler görüntülere, PDF, HTML veya video karelerine dışa aktarırken görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretildiğinde 3B efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3B nesne değildir.

**Kalıtım ve tema ayarları uygulandıktan sonra son 3B değerleri okuyabilir miyim?**

Evet. Son kamera, ışık rig’i, köşe yuvarlama ve ilgili 3B değerlerini okumak için [Şekil Etkili Özellikleri](/slides/tr/net/shape-effective-properties/) API’sini kullanın.