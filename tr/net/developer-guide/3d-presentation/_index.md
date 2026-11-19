---
title: .NET kullanarak Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/net/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B döndürme
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET'te PowerPoint şekilleri ve metni için 3B efektleri uygulayin ve renderlayin. Kamera, isiklandirma, malzeme, ekstrüzyon, dolgu ve 3B metni yapılandırin."
---
## **Genel Bakış**

Aspose.Slides for .NET, şekiller ve metinler için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale döndürme, ekstrüzyon, köşe yumuşatmaları, ışıklandırma, malzeme, degrade veya resim dolgu ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Ayrı bir 3B model dosyasının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya işler.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) özelliğini kullanın. Bu özellik, o şeklin 3B sahnesini kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) öğesini ortaya çıkarır.

Metin için, [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) özelliğini kullanın. Bu, 3B biçimlendirmeyi şekil gövdesi yerine metin çerçevesine uygular.

En önemli özellikler şunlardır:

| Özellik | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Görüş noktası, önceden ayarlanmış kamera tipi, dönüş, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya PowerPoint 3B döndürme ön ayarıyla eşleştirmek için. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Işık ön ayarı, yön ve ışık rotasyonu. | 3B yüzeydeki vurgular ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Şeklin ön yüzünden geriye ne kadar uzadığı. | Düz bir şekli belirgin kalın bir 3B nesne haline getirmek için. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Ekstrüze edilen yanların rengi. | Derinliği görünür kılmak veya yan rengini ön dolgu ile uyumlu hale getirmek için. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekiller veya metin için derinliği inceltmek, özellikle köşe yumuşatma ve malzeme ayarlarıyla birlikte. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) ve [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplı bir kenar eklemek için. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) ve [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | 3B nesnenin etrafındaki kontur. | Render edilmiş çıktıda nesne sınırını vurgulamak için. |

## **3B Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3B görünmesi için genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü ışıklandırma yüzeyleri ve yanları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl render edildiğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3B biçimlendirme uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı varsayılan boyutunun iki katı bir PNG görüntüsü olarak render eder ve sunumu PPTX olarak kaydeder.

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

Render edilmiş slayt görüntüsü dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metin içeren render edilmiş mavi 3B dikdörtgen](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint'te 3B döndürme, 3-B Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-B Döndürme bölmesi](img_02_01.png)

Aspose.Slides'te, kameraya [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) üzerinden erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünümü seçer ve X, Y, Z dönüşlerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides'in render ederken kullandığı 3B bakış açısını değiştirir.

### **Şablon Şekildeki Kamera Yönelimini Kopyalama**

Şablondaki bir şekli eşleştirmek için, onun [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) ön ayarını kopyalayın ve açılarını [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) ile okuyun. Örnek `template.pptx` dosyasını açar, ilk slaydın ilk şeklinin kamerasını okur ve yönelimini ikinci şekle uygular. Her iki şekil de zaten 3B ışıklandırmaya sahiptir ve ikinci şeklin açık bir kamera dönüşü yoktur.

Açılar derecedir. `0` indeksi enlem, `1` indeksi boylam ve `2` indeksi devrimdir. Bu sırayla [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/)'a gönderin. Kaynak `null` döndürürse, açık bir dönüşü yoktur, bu yüzden ikinci şeklin açılarını ayarlamadan bırakın. `(0, 0, 0)` gibi açık bir dönüşüm üç sıfır döndürür ve kopyalanmalıdır.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

`camera-copy.pptx` dosyasını tekrar açtığınızda, iki şekil aynı kamera ön ayarı ve dönüşe sahiptir. PowerPoint'te, sağdaki ok, soldaki dikdörtgenden kopyalanan kamera yönelimini kullanır. Her iki şekil de aynı ışıklandırma ve ekstrüzyon derinliğini kullanır.

![Üstten ve sağdan bakıldığında eşleşen kamera yönelimine sahip bir mavi 3B dikdörtgen ve sağ ok](camera-orientation.png)

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te, derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

Kalınlık için [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight), yan renk için [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) ayarlayın. Bu örnek bir dikdörtgene mor yanlarla 100 puanlık ekstrüzyon verir ve kamerayı kalınlığı gösterecek şekilde döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

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

[IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) özelliği bir 3B şeklin derinliğini ayarlar. [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) özelliği, bu örnekte gösterildiği gibi, ekstrüzyon efektinin yüksekliğini kontrol eder.

## **3B Efektlerle Degrade veya Resim Dolguları Kullanma**

3B biçimlendirme şekil dolgusundan bağımsızdır. Ön yüzeye katı renk, degrade, desen veya resim dolgusu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, ön yüzeye mavi‑turuncu degrade ve 150 puanlık ekstrüzyona koyu turuncu renk uygular. Degrade, 0 ve 100 noktalarında başlangıç ve bitişi işaret eder. Kamera döndürme değerleri derecedir. Slayt, varsayılan boyutunun iki katı bir PNG görüntüsü olarak render edilir:

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

Render edilmiş çıktı, ön yüzde degradeyi korur ve ekstrüzyonu ayrı olarak render eder:

![Mavi‑turuncu degrade dolgu ve turuncu ekstrüzyona sahip render edilmiş 3B dikdörtgen](img_02_03.png)

Bunun yerine resim dolgusu kullanmak için, resmi sunuma ekleyin ve şekil dolgusuna atayın. Bu örnek, çalışma dizininde "image.jpg" adlı bir dosyanın var olmasını gerektirir. Resmi dikdörtgeni dolduracak şekilde gerer, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derecelerle ayarlar. Şekli dosya kaydetmeden veya render etmeden bellekte yapılandırır:

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

Resim ön yüzde render edilirken, ekstrüzyon 3B yan yüzey olarak render edilir:

![Ön yüzde fotoğraf dolgu ve turuncu ekstrüzyona sahip render edilmiş 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, ışıklandırma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara desenli metin oluşturur, yukarı doğru bir kemer uygular ve 3B ayarları [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) aracılığıyla yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindendir, ışık dönüşü derecedir. Şekil dolgu ve kenarlık gizlenir, böylece yalnızca metin görünür. Örnek, varsayılan slayt boyutunun iki katı bir PNG görüntüsü render eder ve sunumu PPTX olarak kaydeder:

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

Metin, eğimli, ekstrüzyonlu 3B harfler olarak render edilir:

![Eğimli WordArt dönüşümü, turuncu desen dolgu ve koyu ekstrüzyona sahip render edilmiş 3B metin](img_02_05.png)

## **3B Şekilde Metni Düz Tutma**

Bir şeklin 3B görünümünü korurken metnin okunabilir olmasını sağlamak için, [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) özelliğini [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/) aracılığıyla ayarlayın. Değer `true` olduğunda, metin 3B sahnenin dışındadır. `false` olduğunda, metin sahneye katılır ve 3B yönelimini takip eder.

Bu ayar, şeklin 3B biçimlendirmesini kaldırmaz: kamera, ışıklandırma, malzeme ve ekstrüzyon, [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) aracılığıyla yapılandırılmış halde kalır. Ayrıca normal döndürmeden farklıdır. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) şekli slayt düzleminde döndürürken, [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) metnin sınırlama kutusundaki özel döndürmesini kontrol eder. Metni 3B sahnenin dışına tutmak bu açılardan hiçbirini sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli mavi bir dikdörtgen oluşturur ve orijinalin yanına kopyalar. Her iki şekil de aynı 3B biçimlendirmeye sahiptir; sadece metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir ve ekstrüzyon yüksekliği 40 puandır. Örnek, sunumu PPTX olarak kaydeder ve karşılaştırma slaytını varsayılan boyutunun iki katı bir PNG olarak render eder.

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

Solda, metin 3B yönelimi izler. Sağda, metin düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünür ekstrüzyon ve 3B yönelimi korur.

![Yan yana 3B dikdörtgenler: Sol tarafta KeepTextFlat false, sağ tarafta true](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit düzen formatlarına render ederken veya dışa aktarırken, 3B sahne rasterleştirilir veya 2B sonuç olarak çıktıya çizilir. Bu, slaytları [PNG](/slides/tr/net/convert-powerpoint-to-png/) formatına render ettiğinizde, [PDF](/slides/tr/net/convert-powerpoint-to-pdf/) dışa aktardığınızda, [HTML](/slides/tr/net/convert-powerpoint-to-html/) dışa aktardığınızda veya [video conversion](/slides/tr/net/convert-powerpoint-to-video/) için çerçeveler oluşturduğunuzda geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, dolgu ve slayt ölçeklemesinin birleşimine bağlıdır.
- Eğer kalıtım veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özellikleri](/slides/tr/net/shape-effective-properties/) okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu formatlarda, görsel sonuç render edilir ve düzenlenebilir 3B ayar olarak korunmaz.

## **FAQ**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metinler için PowerPoint 3B efektlerini oluşturur ve render eder. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfalarını, izleyicinin döndürebileceği etkileşimli 3B sahnelere dönüştürmez. PPTX formatında, 3B biçimlendirme, formatın desteklediği yerlerde PowerPoint içinde düzenlenebilir olarak kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, bir sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise döndürme, ekstrüzyon, köşe yumuşatma, ışıklandırma ve malzeme gibi, normal bir PowerPoint şekline veya metnine uygulanan biçimlendirmedir. Bu makale 3B efektleri ele alır.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

En az bir kamera döndürmesi ve ekstrüzyon ya da derinlik ayarı yapılmalıdır. Pratikte, render edilen yüzlerin belirgin vurgular ve gölgeler alması için bir ışık rig'i ve malzeme de ayarlanmalıdır.

**Hem şekillere hem de metne 3B efekt uygulanabilir mi?**

Evet. Şekil gövdesi için [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) ve metin için ise [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) kullanın.

**3B efektler görüntülere, PDF'ye, HTML'ye veya video çerçevelerine dışa aktarırken görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan çerçeveler üretilirken 3B efektleri render eder. Dışa aktarılan çıktı, render edilmiş görünümü içerir; düzenlenebilir bir 3B nesne içermez.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3B değerleri okuyabilir miyim?**

Evet. Son kamera, ışık rig'i, köşe yumuşatma ve ilgili 3B değerleri okumak için [Şekil Etkili Özellikleri](/slides/tr/net/shape-effective-properties/) içinde açıklanan etkili biçimlendirme API'lerini kullanın.