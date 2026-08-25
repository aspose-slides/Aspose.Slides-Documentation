---
title: Sunumlarda .NET ile Görüntü Dönüşüm Efektlerini Yönetme
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/net/image-transform-effects/
keywords:
- görüntü dönüşümü
- resim efekti
- parlaklık
- kontrast
- gri ölçek
- çift ton
- renk tonu
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
description: "Aspose.Slides for .NET ile resim çerçeveleri için görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını sıralı bir görüntü dönüşüm işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [ISlidesPicture](https://reference.aspose.com/slides/tr/net/aspose.slides/islidespicture/) ile başlayın ve [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/tr/net/aspose.slides/islidespicture/imagetransform/) öğesine erişin. Döndürülen [IImageTransformOperationCollection](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/) size etkileri ekleme, listeleme, inceleme, kaldırma ve temizleme imkanı sağlar; orijinal görüntü baytlarını yeniden yazmadan.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX çift yönlü doğrulama için tam bir iş akışını göstermektedir.

## **Efekt Sahipliğini ve Görüntü Yeniden Kullanımını Anlama**

Bir görüntü kaynağı ve onu gösteren resim farklı nesnelerdir:

- [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) sunumda sahip olunan kaynak görüntü verilerini depolar veya referans verir.
- [ISlidesPicture](https://reference.aspose.com/slides/tr/net/aspose.slides/islidespicture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvururken aynı zamanda görüntü dönüşüm koleksiyonunu depolar.
- [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) ilgili resim doldurmayı, geometrileri, kırpma ayarlarını ve diğer çerçeve seviyesindeki biçimlendirmeleri sahip olan slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) içindeki baytları değiştirmez. Aynı `IPPImage` [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addpictureframe/) metoduna birden fazla kez geçirilirse, her yeni resim çerçevesi kendi `ISlidesPicture` ve kendi dönüşüm koleksiyonunu alır. Bir çerçeveye gri ölçek uygulanması, diğer çerçevelerin gri ölçeğe geçmesine neden olmaz; tüm çerçeveler aynı gömülü görüntü kaynağını kullansa da.

Aynı `ISlidesPicture.ImageTransform` modeli şekil doldurması veya slayt arka planı gibi diğer resim doldurmalarında da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanmıştır.

## **Geçerli Parametre Aralıklarını ve Birimlerini Kullanma**

Gösterilen metodlar aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her dışarıdaki değeri reddetmese bile bu aralıkta kalın; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| Operation | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Yok | Sayısal parametre yok. Alfa değişmez. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Koyu ve açık pikseller için iki renk. `System.Drawing.Color` içindeki RGB ve alfa kanalları `0` ile `255` arasındadır. |
| [AddTintEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Ton `0` dahil, `360` hariç derece cinsinden; miktar `-100` ile `100` arasında, yüzde. |
| [AddHSLEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Ton `0` dahil, `360` hariç derece; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Değiştirme rengi kanallarını `0` ile `255` arasında kullanır. Mevcut alfa değerleri değişmez. |
| [AddBlurEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Yarıçap negatif olmayan ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını belirleyen bir Boolean'dır. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanılır: `0` tamamen şeffaf, `100` mevcut alfabayı korur. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Altındaki değerler şeffaf, eşit veya üzerindeki değerler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık karşılıklı tamamlayıcıdır. Örneğin, %35 şeffaflık %65 alfa modülasyon miktarına karşılık gelir.

## **Parlaklık ve Kontrast Uygulama**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) bir [IBrightnessContrast](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/ibrightnesscontrast/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/brightnesscontrast/geteffective/) hesaplanmış, yalnızca okunabilen değerleri döndürür; bu değerler incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir ön izleme üretir:

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

[BrightnessContrast](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/brightnesscontrast/) bir Office 2010 resim‑efekti uzantısıdır ve standart DrawingML parlaklık etkisine göre daha az taşınabilirdir. Parlaklık ve kontrastın PPTX çift yönlü yolculuktan sonra da düzenlenebilir kalması gerekiyorsa [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu farkı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı görüntü kaynağını kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve sırasıyla gri ölçek, duotone, ton, HSL ayarı ve renk değiştirme uygular.

[IDuotone](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iduotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `Color1` koyu pikselleri, `Color2` ise açık pikselleri temsil eder. Bu, ayarları tek bir skaler değerden daha karmaşık bir etki örneği olması bakımından faydalıdır.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) her pikselin rengini tek bir sabit renkle değiştirirken alfabayı korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [AddColorChangeEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) işleminden farklıdır.

## **Bulanıklaştırma, Şeffaflık ve Alfa Efektleri Ekleme**

[AddBlurEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) tüm renk kanallarını, alfa dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına uzanabileceği durumlarda `grow` değerini `true` olarak ayarlayın.

Tekdüzen şeffaflık için [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) kullanın. Bu, mevcut alfa değerlerini çarpan bir işlem olduğundan kısmen şeffaf pikseller orantılı olarak farklı kalır. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) ise tüm piksellere tek bir alfa değeri atar. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) ise alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

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

Parametresiz diğer alfa işlemleri arasında [AddAlphaCeilingEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) bulunur; bu, sıfır olmayan tüm alfabayı tamamen opak yapar. [AddAlphaFloorEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) tüm %100'ün altındaki alfabayı tamamen şeffaf eder; ve [AddAlphaInverseEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) alfabı `100% - alpha` biçiminde tersine çevirir.

## **Sıralı Bir Etki Zinciri Oluşturma**

Her `Add...Effect` metodu yeni bir işlemi koleksiyonun sonuna ekler. İşleyici koleksiyonu sıralı bir pipeline olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur ve bu şekilde devam eder. Dolayısıyla aynı işlemler farklı bir sırada farklı bir görüntü üretebilir.

Örneğin, gri ölçek ardından ton uygulamak önce renk bilgisini kaldırır, ardından parlaklık sonucunu yeniden renklendirir. Ton ardından gri ölçek uygulamak tonu tekrar kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemlerle hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise göreceli farkları korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem tiplerini hem de sıralarını kontrol eder ve yeniden açılan sonucu render eder:

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

Koleksiyon renk, alfa ve bulanıklaştırma işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birleştirilebilirler, ancak tüm kombinasyonlar yararlı olmayabilir. Sabit bir renk değişimi, önceki renk efektleriyle üretilen RGB varyasyonunu ortadan kaldırır; duotone sonrası gri ölçek iki seçili rengi siler; ve alfa tavan, taban, değiştirme veya iki‑seviyeli işlemler daha önce oluşturulan alfa detayını yok edebilir. Zinciri istediğiniz piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçimlendirme bayrakları olarak düşünmeyin.

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, `ISlidesPicture.ImageTransform` içinde depolanan nesnedir. Efekte bağlı olarak, yazılabilir üyeler doğrudan ortaya çıkabilir. Örneğin, [IBlur](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iblur/) yazılabilir `Radius` ve `Grow` öğelerini, [IAlphaModulateFixed](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/ialphamodulatefixed/) yazılabilir `Amount` öğesini, ve [IAlphaBiLevel](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/ialphabilevel/) yazılabilir `Threshold` öğesini ortaya çıkarır. [IDuotone](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iduotone/) gibi renk efektleri değiştirilebilir [IColorFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/icolorformat/) nesnelerini ortaya çıkarır.

[IBrightnessContrast](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/itint/) ve [IAlphaReplace](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/ialphareplace/) gibi bazı işlem arayüzleri, oluşturma skalerlerini yazılabilir özellik olarak ortaya koymaz. Bu ayarları değiştirmek için işlemi kaldırıp istenen konumda yeni bir işlem ekleyin.

`GetEffective()` tarafından döndürülen etkili veri hesaplanmış ve yalnızca okunabilir bir nesnedir. Tema bağımlı renkleri çözümlemek ve işleyicinin kullandığı normalleştirilmiş değerleri okumak için yararlıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri enumerate eder ve ilgili API sağlayan yerlerde etkili değerleri inceler:

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

Parametresiz efektler (gri ölçek, alfa tavan, alfa tersine çevirme gibi) hâlâ bir etkili veri nesnesine sahiptir, ancak bastırılacak skaler ayarları yoktur. Bulunmaları ve koleksiyondaki konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi indeksle kaldırmak için [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) kullanın. Kaldırma sonrası indeksler kaydığı için önce hedefi bulup enumerate ettikten sonra kaldırın. Tüm zinciri kaldırmak için `Clear()` kullanın.

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

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde değiştirmez.

## **Sunum Formatlarını ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüşümleri DrawingML içinde ortaya çıkar, bu yüzden PPTX etkili zincirler için tercih edilen düzenlenebilir formattır. PPTX bile olsa, her işlem aynı taşınabilirliğe sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri PPTX çift yönlü yolculuktan en iyi şekilde geçer. Saklanan dosyayı her zaman yeniden açın ve koleksiyonu inceleyin; koruma bir gereklilikse bu şarttır.
- [BrightnessContrast](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/brightnesscontrast/) bir Office 2010 uzantısıdır, standart DrawingML luminance işlemi değildir. Bellek içi render için kullanılabilir, ancak PPTX kaydedilip yeniden açıldıktan sonra düzenlenebilir bir [IBrightnessContrast](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/ibrightnesscontrast/) olarak kalması garanti edilmez. Kalıcı parlaklık ve kontrast ayarları için [AddLuminanceEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) tercih edin.
- Eski PPT formatı tam DrawingML efekt modelinden önce gelmiştir. PPT’ye kaydetmek desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaşık olarak oluşturabilir. Karmaşık düzenlenebilir bir zincir için PPT’yi doğrulama formatı olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılar desteklenen zinciri görünüm üzerine uygular. Bu çıktılar düzenlenebilir `IImageTransformOperationCollection` içermez; raster formatlar sonucu piksellere döker, belge/vektör dışa aktarımları ise kendi render temsillerini depolar.
- Efektler bağlanan bir görüntüyü kendi içinde özelleştirilmiş hâle getirmez. Bağlantılı bir resim render edildiğinde, sunum yüklendiğinde bağlantılı kaynağın mevcut olması gerekir.

Farklı sunum tüketicileri kenar durumları farklı render edebilir, özellikle birkaç alfa veya renk‑kuantalama işlemi bir arada kullanıldığında. Kritik çıktılar için aynı Aspose.Slides sürümüyle düzenlenebilir çift yönlü yolculuğu ve son dışa aktarım formatını test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan `ISlidesPicture` içinde tutulur. Alttaki `IPPImage` baytları değişmez.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi etkilerini paylaşır mı?**

Hayır. `IPPImage` yeniden kullanmak veri tekrarlamasını önler, ancak her resim çerçevesi genellikle ayrı bir `ISlidesPicture` ve ayrı bir görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklaştırma ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon bunları tek bir sıralı zincirde kabul eder. Önceki işlemin çıktısını ne yaptığına dikkat edin; değiştirme ve eşik işlemleri önceki renk veya alfa detayını ortadan kaldırabilir.

**Etkili değerler neden yalnızca okunabilir?**

Etkili veri, render için kullanılan hesaplanmış değerleri (çözülmüş renkler dahil) temsil eder. Yazılabilir üyeler varsa dönüşüm koleksiyonunda depolanan işlemi düzenleyin; aksi takdirde yeni oluşturma parametreleriyle bir yerine koyma ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT tam DrawingML efekt modelini temsil edemez; render edilen dışa aktarma formatları ise yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini değil.