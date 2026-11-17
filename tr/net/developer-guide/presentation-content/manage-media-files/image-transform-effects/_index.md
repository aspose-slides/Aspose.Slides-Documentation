---
title: Sunumlarda Görüntü Dönüşüm Efektlerini .NET ile Yönetme
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/net/image-transform-effects/
keywords:
- görüntü dönüşümü
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- çift ton
- tonlama
- HSL
- renk değiştirme
- bulanıklaştırma
- şeffaflık
- alfa efekti
- efekt zinciri
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile resim çerçevelerinde görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını, görüntü dönüşüm işlemlerinin sıralı bir koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) ile başlayın ve [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/) öğesine erişin. Döndürülen [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) size orijinal görüntü baytlarını yeniden yazmadan efekt ekleme, listeleme, inceleme, kaldırma ve temizlik yapma imkanı sağlar.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX çift yönlü doğrulama için tam bir iş akışını gösterir.

## **Efekt Sahipliği ve Görüntü Yeniden Kullanımını Anlama**

Bir görüntü kaynağı ve onu gösteren resim farklı nesnelerdir:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) sunumun sahip olduğu kaynak görüntü verilerini depolar veya başvurur.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) bir resim dolduruma aittir ve bir görüntü kaynağına atıfta bulunurken görüntü dönüşüm koleksiyonunu saklar.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) ilgili resim doldurumu, geometriyi, kırpma ayarlarını ve diğer çerçeve düzeyindeki biçimlendirmeleri sahip olan slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) içindeki baytları değiştirmez. Aynı `IPPImage` birden fazla kez [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) metoduna geçirildiğinde, her yeni resim çerçevesi kendi `ISlidesPicture` ve kendi dönüşüm koleksiyonunu alır. Bir çerçeveye gri tonlama uygulanması, diğer çerçevelerin gri tonlamasını yapmaz, çünkü hepsi aynı gömülü görüntü kaynağını yeniden kullanır.

Aynı `ISlidesPicture.ImageTransform` modeli, şekil ya da slayt arka planı gibi diğer resim doldurmalar tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıkları ve Birimlerini Kullanma**

Demonstrasyon yöntemleri aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü, out-of-range değerleri hemen reddetmese bile, bu aralıklardaki değerleri koruyun; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Sayısal parametre yok. Alfa değişmez. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Karanlık ve açık pikseller için iki renk. `System.Drawing.Color` içindeki RGB ve alfa kanalları `0` ile `255` arasında kullanılır. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Renk tonu `0` dahil, `360` hariç derecede; miktar `-100` ile `100` arasında, yüzde. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Renk tonu `0` dahil, `360` hariç derecede; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Yerine konulan renk `0` ile `255` arasındaki kanal değerlerini kullanır. Mevcut alfa değerleri değişmez. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Yarıçap negatif olmayan ve puan cinsinden ölçülür; `grow` bulanık içeriğin orijinal sınırlardan dışarı çıkıp çıkmayacağını kontrol eden bir Boolean’dır. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaftır ve `100` mevcut alfasını korur. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ile `100` arasında, yüzde alfa eşik değeri. Bu değerin altındaki değerler şeffaf, eşit ya da üstündekiler opak olur. |

Sabit alfa modülasyonu için, şeffaflık ve opaklık karşılıklıdır. Örneğin, %35 şeffaflık %65 alfa modülasyon miktarına karşılık gelir.

## **Parlaklık ve Kontrast Uygulama**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) bir [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) incelenebilen veya kaydedilebilen hesaplanmış sadece‑okunur değerleri döndürür.

Aşağıdaki örnek parlaklığı %15 ve kontrastı %20 artırır, ardından gömülü görüntüyü değiştirmeden bir ön izleme render eder:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) bir Office 2010 resim‑efekt uzantısıdır ve standart DrawingML parlaklık efektinden daha az taşınabilirdir. Parlaklık ve kontrast bir PPTX çift yönlü işlemden sonra düzenlenebilir kalmalıysa, [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu farkı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `Color1` karanlık pikselleri, `Color2` ise açık pikselleri eşler. Bu, ayarları tek bir skaler değerden daha karmaşık bir etkene örnek teşkil eder.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) her pikselin rengini sabit bir renk ile değiştirirken alfabı korur. Bu, bir kaynak rengi diğerine eşleyen ve hem kaynak hem hedef renk formatlarını ortaya çıkaran [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) farklıdır.

### **Parlaklık Eşiği Uygulama**

Bir parlaklık eşiği, taranmış bir sayfadaki hafif işaretleri arka plandan ayırt etmeyi kolaylaştırabilir. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) ara gri tonlarını korur. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) parlaklığı siyah veya beyaza eşler, [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) ise opaklığa bir eşik uygular.

Parlaklık eşiği %0 ile %100 arasında, dahil. Eşik altındaki pikseller siyah olur. Eşikte ya da üstünde olan pikseller beyaz olur. Eşiği yükseltmek, daha fazla tonu siyaha dönüştürür çünkü daha çok ton kesimin altına düşer.

[grayscale-swatches.png](grayscale-swatches.png) dosyasını çalışma dizinine indirin. Her etiket, 0‑255 ölçeğindeki orijinal gri seviyesini verir. Örnek, orijinali iki kopyanın yanına yerleştirir ve her kopyanın eşik değerini sunumda kaydeder.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Çıktı sunumunu PowerPoint'te açarak üç çerçeveyi karşılaştırın. 96 etiketi verilen örnek yaklaşık %38 parlaklığa (255 içinde 96) sahiptir. %20 eşikte beyaza, %60 eşikte siyaha dönüşür.

![Parlaklık eşikleri %20 ve %60’ta siyah‑beyaz sonuçların yanındaki orijinal gri ton örnekleri](luminance-threshold.png)

## **Bulanıklaştırma, Şeffaflık ve Alfa Efektleri Ekleme**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) alfa dahil tüm renk kanallarını etkiler. Bulanık kenar orijinal resim sınırlarının dışına çıkabilecekse `grow` değerini `true` olarak ayarlayın.

Tekdüze şeffaflık için [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) kullanın. Bu, mevcut her alfa değerini çarpar; böylece kısmen şeffaf pikseller orantılı olarak farklı kalır. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) ise tüm piksellere tek bir alfa değeri atar. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) alfa değerini bir eşik üzerine iki seviyeye dönüştürür.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Diğer parametresiz alfa işlemleri şunlardır: [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) – sıfır olmayan her alfabı tamamen opak yapar; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) – %100’ün altındaki her alfabı tamamen şeffaf hale getirir; ve [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) – alfabı `100% - alpha` şeklinde değiştirir.

## **Sıralı Bir Efekt Zinciri Oluşturma**

Her `Add...Effect` metodu koleksiyonun sonuna yeni bir işlem ekler. Renderleyici koleksiyonu sıralı bir taşıma hattı olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur ve böyle devam eder. Bu nedenle, aynı işlemler farklı bir sırada birleştirildiğinde farklı bir görüntü elde edilebilir.

Örneğin, gri tonlama ardından tonlama önce kromatik bilgiyi kaldırır, ardından parlaklık sonucunu yeniden renklendirir. Tonlama ardından gri tonlama tonu tekrar kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise bunların göreceli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem türlerini hem de sırasını kontrol eder ve yeniden açılan sonucu render eder:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Bunlar birleştirilebilir, ancak kombinasyonlar her zaman faydalı değildir. Sabit renk değiştirme, önceki renk efektleriyle oluşan RGB varyasyonunu kaldırır; duotone sonrası gri tonlama iki seçili rengi kaldırır; ve alfa tavan, taban, değiştirme veya iki seviyeli işlemler önceki alfa detaylarını silebilir. Zinciri, istenen piksel işlem sırasına göre oluşturun, öğelerini sırasız biçim işaretleri gibi görmeyin.

<!-- visual-explanation:image-transform-effects:start -->
[![Aynı görüntü önce gri tonlamadan sonra tonlamadan, ve tonlamadan önce gri tonlamadan geçer. İki son gri tonlama görüntüsü farklı tonlara sahiptir.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Bu açıklayıcı Aspose.Slides for .NET 26.11 render'ında, %25'lik 220° tonlama gri tonlama görüntüsünü değiştirmez. Aynı tonlamayı gri tonlamadan önce uygulamak farklı tonlar üretir.*
<!-- visual-explanation:image-transform-effects:end -->

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, `ISlidesPicture.ImageTransform` içinde depolanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeleri doğrudan ortaya çıkarabilir. Örneğin, [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) yazılabilir `Radius` ve `Grow` öğelerini; [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) yazılabilir `Amount`; ve [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) yazılabilir `Threshold` öğesini ortaya çıkarır. [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) gibi renk efektleri ise değiştirilebilir [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) nesnelerini ortaya çıkarır.

Bazı işlem arayüzleri, [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/) ve [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/) dahil, oluşturma skalerlerini yazılabilir özellikler olarak ortaya çıkarmaz. Bu ayarları değiştirmek için, işlemi kaldırın ve gereken konuma bir yenisi ekleyin.

`GetEffective()` tarafından döndürülen etkili veri hesaplanmış ve sadece‑okunurdur. Tema‑bağımlı renkleri çözmek ve renderleyicinin kullandığı normalleştirilmiş değerleri okumak için faydalıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri sıralar ve ilgili API'nin sağladığı yerlerde etkili değerleri inceler:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Gri tonlama, alfa tavan ve alfa ters gibi parametresiz efektlerin hâlâ bir etkili‑veri nesnesi vardır, ancak yazdırılacak skaler ayar yoktur. Bunların varlığı ve koleksiyondaki konumu önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi indeksle kaldırmak için [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) kullanın. Kaldırma sonrası indeksler kaydığı için, önce hedefi bulun ve ardından dolaşım sonrası kaldırın. Tüm zinciri kaldırmak için `Clear()` kullanın.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde değiştirmez.

## **Sunum Biçimlerini ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüşümleri DrawingML'de ortaya çıkar, bu yüzden PPTX efekt zincirleri için tercih edilen düzenlenebilir formattır. PPTX ile bile, her işlem aynı taşınabilirliğe sahip değildir:

- Parlaklık, gri tonlama, duotone, tonlama, HSL, bulanıklaştırma ve yaygın alfa işlemleri gibi standart DrawingML işlemleri, bir PPTX çift yönlü işleminde hayatta kalma şansı en yüksek olandır. Koruma bir gereklilik olduğunda daima oluşturulan dosyayı yeniden açın ve koleksiyonu inceleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) standart DrawingML parlaklık işlemi yerine bir Office 2010 uzantısıdır. Bellekte renderleme için kullanılabilir, ancak kaydedilip PPTX yeniden açıldıktan sonra düzenlenebilir bir [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarları için [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) tercih edin.
- İkili PPT formatı, tam DrawingML efekt modelinden öncedir. PPT'ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaşık olarak yakalayabilir. Karmaşık düzenlenebilir bir zincir için PPT'yi doğrulama formatı olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılara renderleme, desteklenen zinciri renderlenmiş görünüme uygular. Bu çıktılar, düzenlenebilir bir `IImageTransformOperationCollection` içermez; raster formatlar sonucu piksel hâline getirir ve belge/vektör dışa aktarımları kendi renderleme temsilini depolar.
- Efektler, bağlı bir görüntüyü kendi içinde bağımsız hâle getirmez. Bağlı bir resmi renderlemek, sunum yüklendiğinde bağlı kaynağın mevcut olmasına hâlâ bağlıdır.

Farklı sunum tüketicileri kenar durumları farklı renderleyebilir, özellikle birden fazla alfa veya renk-kuantizasyon işlemi birleştirildiğinde. Kritik çıktılar için, üretimde kullanılan aynı Aspose.Slides sürümüyle düzenlenebilir çift yönlü ve son dışa aktarım formatını test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurumu tarafından kullanılan `ISlidesPicture` a aittir. Alttaki `IPPImage` baytları değişmez.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi efektlerini paylaşır mı?**

Hayır. `IPPImage` yeniden kullanmak, kopya görüntü verisini önler, ancak her resim çerçevesi genellikle ayrı bir `ISlidesPicture` ve görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklaştırma ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon bunları tek bir sıralı zincirde kabul eder. Her bir işlemin önceki çıktıyı nasıl etkilediğini düşünün; çünkü değiştirme ve eşik işlemleri önceki renk veya alfa detaylarını ortadan kaldırabilir.

**Etkili değerler neden sadece‑okunur?**

Etkili veri, renderleme için kullanılan hesaplanmış değerleri, çözülmüş renkler dahil, temsil eder. Yazılabilir üyeleri olan transform koleksiyonundaki işlemi düzenleyin; aksi takdirde kaldırın ve yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT, tam DrawingML efekt modelini temsil edemez ve renderlenen dışa aktarma formatları, düzenlenebilir dönüşüm işlemleri yerine görünümü korur.