---
title: .NET Kullanarak Sunumlarda 3D Efektler Oluşturma
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

Aspose.Slides for .NET, şekil ve metinler için PowerPoint benzeri 3D biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, kenar yumuşatma, aydınlatma, malzeme, degradeli veya resimli doldurmalar ve 3D metin gibi 3D efektlerini kapsar.

{{% alert color="primary" %}}
Bu makale, PowerPoint şekilleri ve metinleri üzerindeki 3D biçimlendirme efektleriyle ilgilidir. Ayrı 3D model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D efektlerini dışa aktarılan 2D çıktıya renderlar.
{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [IShape.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/threedformat) özelliğini kullanın. Bu özellik, şeklin 3D sahnesini kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat) nesnesini ortaya çıkarır.

Metin için, [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/threedformat) özelliğini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli özellikler şunlardır:

| Özellik | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/camera) | Bakış noktası, ön ayarlı kamera tipi, döndürme, yakınlaştırma ve perspektif. | Objeyi 3D uzayda döndürmek veya bir PowerPoint 3D döndürme ön ayarına uymak için. |
| [LightRig](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/lightrig) | Işık ön ayarı, yön ve ışık döndürmesi. | 3D yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [Material](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/material) | Yüzey malzemesi, düz, mat, plastik veya metal gibi. | Aynı geometrinin daha düz, yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [ExtrusionHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusionheight) | Şeklin ön yüzünden geriye ne kadar uzandığı. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürmek için. |
| [ExtrusionColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılmak ya da yan rengi ön doldurma ile eşleştirmek için. |
| [Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekil veya metin için derinliği ince ayarlamak, özellikle kenar yumuşatma ve malzeme ayarları ile birlikte. |
| [BevelTop](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/beveltop) ve [BevelBottom](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/bevelbottom) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz yüz yerine yumuşak veya kalıplanmış bir kenar eklemek için. |
| [ContourColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/contourcolor) ve [ContourWidth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D nesnenin etrafındaki kontur. | Render çıktısında nesne sınırını vurgulamak için. |

## **3D Şekil Oluşturma**

Bir şeklin inandırıcı bir şekilde 3D görünmesi için genellikle dört tür ayar gerekir:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve kenarların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlanacağını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3D biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsüne renderlar.

```csharp
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

Render edilmiş slayt görüntüsü dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzde beyaz 3D metinli mavi 3D dikdörtgenin render edilmiş görüntüsü](img_01_01.png)

## **Kamerayla Şekli Döndürme**

PowerPoint'te 3D döndürme, 3‑D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'de kamera tipini ve döndürmeyi [IThreeDFormat.Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/camera) üzerinden ayarlayın:

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez; PowerPoint ve Aspose.Slides'in render sırasında kullandığı 3D bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şeklin ön yüzünün arkasına uzatarak kalın görünmesini sağlar. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

Kalınlık için [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusionheight), yan renk için [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/extrusioncolor) ayarlayın:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği kenar yumuşatma, malzeme ve metin efektleriyle birleştirmek istediğinizde [IThreeDFormat.Depth](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/properties/depth) kullanın. Çoğu şekil senaryosunda `ExtrusionHeight` daha net bir ayardır çünkü görünür ekstrüzyonu doğrudan ifade eder.

## **3D Efektlerle Degrade veya Resim Doldurmalarını Kullanma**

3D biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüzde katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını koruyabilirsiniz.

Bu örnek, şekle bir degrade doldurma ve yan yüzlere daha koyu bir ekstrüzyon rengi uygular:

```csharp
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

Render çıktısı ön yüzde degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑turuncu degrade doldurma ve turuncu ekstrüzyonlu render edilmiş 3D dikdörtgen](img_02_03.png)

Resim doldurma kullanmak isterseniz, resmi sunuma ekleyin ve şekil doldurmasına atayın:

```csharp
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

![Ön yüzde fotoğraf doldurma ve turuncu ekstrüzyonlu render edilmiş 3D dikdörtgen](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirmesi şekil gövdesini etkiler. Metin 3D biçimlendirmesi ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek, desen doldurma ile metin oluşturur, bir WordArt dönüşümü uygular ve [ITextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat) üzerinde 3D ayarları yapılandırır:

```csharp
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

Metin kavisli, ekstrüde edilmiş 3D harfler olarak renderlanır:

![Kemer şeklinde WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu render edilmiş 3D metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit‑düşünceli formatlara render ederken veya dışa aktarırken 3D sahne rasterize edilerek 2D sonuç olarak çıktıya dahil edilir. Bu, slaytları [PNG](/slides/tr/net/convert-powerpoint-to-png/), [PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/net/convert-powerpoint-to-html/) olarak renderlarken veya [video dönüştürme](/slides/tr/net/convert-powerpoint-to-video/) için kareler üretirken geçerlidir.

Şu noktaları aklınızda bulundurun:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin kombinasyonuna bağlıdır.
- Miras alınan veya tema‑tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özelliklerini](/slides/tr/net/shape-effective-properties/) okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3D biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları olarak korunmaz; sadece renderlanmış biçimde sunulur.

## **SSS**

**Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metinler için PowerPoint 3D efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3D sahneler haline getirmez. PPTX içinde, format destekliyorsa 3D biçimlendirme PowerPoint'te düzenlenebilir olarak kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, sunuma ayrı bir 3D nesne olarak eklenen bağımsız bir objedir. 3D efekt ise standart bir PowerPoint şekli veya metnine uygulanan, döndürme, ekstrüzyon, kenar yumuşatma, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3D efektleri ele alır.

**Görünür bir 3D şekil için hangi ayarlar gereklidir?**

Minimum olarak bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı gerekir. Pratikte, yüzeylerin net vurgular ve gölgeler alması için bir ışık rig'i ve malzeme de ayarlanmalıdır.

**Hem şekillere hem de metne 3D efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/threedformat), metin için ise [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/threedformat) kullanın.

**3D efektler, görüntülere, PDF, HTML veya video karelerine dışa aktarırken görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretirken 3D efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümleri içerir, düzenlenebilir 3D nesne değildir.

**Miras ve tema ayarları uygulandıktan sonra nihai 3D değerlerini okuyabilir miyim?**

Evet. Nihai kamera, ışık rig'i, kenar yumuşatma ve ilgili 3D değerlerini okumak için [Şekil Etkili Özellikleri](/slides/tr/net/shape-effective-properties/) API'lerini kullanın.