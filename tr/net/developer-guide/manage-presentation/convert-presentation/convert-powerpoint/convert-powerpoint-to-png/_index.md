---
title: PowerPoint Slaytlarını .NET'te PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/net/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint PNG'ye
- sunum PNG'ye
- slayt PNG'ye
- PPT PNG'ye
- PPTX PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'yi PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'yi PNG'ye dışa aktar
- .NET
- C#
- Aspose.Slides
description: "PowerPoint sunumlarını, Aspose.Slides for .NET ile yüksek kaliteli PNG görüntülerine hızlı bir şekilde dönüştürün, kesin ve otomatik sonuçlar sağlar."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak sunum slaytlarını PNG görüntülerine nasıl dönüştüreceğinizi açıklar. PPT, PPTX ve ODP gibi formatlarda sunumları yükleyebilir, her slaytı işleyebilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Aşağıdaki örnekler, küçük resim oluşturmayı, ölçek faktörlerini ayarlamayı, çıkış boyutlarını piksel olarak belirtmeyi ve bir gradient işleme stili seçmeyi göstermektedir.

## **PowerPoint'i PNG'ye Dönüştür**

Bir sunumu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytlarına [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) koleksiyonu üzerinden erişin. Örnek, her slaytı parametresiz [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) yöntemiyle işleyerek bir küçük resim oluşturur. Ardından, işlenen her slaytı PNG görüntüsü olarak kaydetmek için [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) yöntemini [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) ile çağırır.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Parametresiz [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) aşırı yüklemesi 0.2 ölçekle işler. Örneğin, 720 × 540 puan ölçüsündeki bir slayt, 144 × 108 piksel bir küçük resim üretir. Çıkış boyutlarını kontrol etmek için aşağıda gösterildiği gibi ölçek faktörleriyle ya da açık bir görüntü boyutuyla aşırı yüklemeleri kullanın.
{{% /alert %}}

## **PowerPoint'i PNG'ye Özel Boyutlarla Dönüştür**

İşlenen boyutları kontrol etmek için yatay ve dikey ölçek faktörlerini [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) yöntemine geçirin. Bu örnekte, her iki faktör de 2'dir, böylece 720 × 540 puan ölçüsündeki bir slayt 1440 × 1080 piksel bir görüntü üretir. Eşit ölçek faktörleri slaytın en‑boy oranını korur. Her görüntü, [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) yöntemiyle PNG formatında kaydedilir.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **PowerPoint'i PNG'ye Özel Boyutla Dönüştür**

Çıkış boyutlarını piksel olarak belirtmek için ölçek faktörleri yerine bir boyut değerini [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) yöntemine geçirin. Bu örnek, her slaytı 960 × 720 pikselde işler ve sonucu [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) ile kaydeder. Görüntünün gerilmesini önlemek için slaytın en‑boy oranına uyan boyutları seçin.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Gradient İşleme Stili Seçimi**

Bir slayt gradient dolgu içerdiğini varsayalım, ancak dışa aktarılan PNG'deki geçişler PowerPoint'te gördüklerinizden daha açık ya da farklı görünebilir. Gradient'lerin nasıl işleneceğini seçmek için [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) nesnesinin [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) özelliğini kullanabilirsiniz.

[gradient-styles.pptx](gradient-styles.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, üstte camgöbeği‑turuncuya, altta mavi‑sarıya doğru iki lineer gradient içerir. Her gradientin %0 ve %100 konumlarında iki durak noktası vardır.

Aşağıdaki örnek bu sunumu yükler ve aynı ilk slaytı her iki modda da [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) ile işler.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Aşağıdaki görseller aynı slayttan elde edilen çıktıyı, her iki gradientin de bulunduğu şekilde gösterir:

| Default | PowerPointUI |
| --- | --- |
| ![Varsayılan ile işlenmiş camgöbeği‑turuncu ve mavi‑sarı gradientler](gradient-Default.png) | ![PowerPointUI ile işlenmiş aynı gradientler](gradient-PowerPointUI.png) |

Bu örnekte `Default` daha açık ara renkler üretirken, `PowerPointUI` daha koyu ara renkler üretir. Fark, gradientin renklerine ve durak noktalarına bağlıdır.

`Default` seçeneğini, standart Aspose.Slides çıktısı ihtiyaçlarınızı karşılıyorsa kullanın. PowerPoint'teki görünümle eşleşmek önceliğinizse `PowerPointUI` seçeneğini deneyin. Her iki çıktıyı da hedef sonucunuzla karşılaştırın; hiçbir mod her durumda tercih edilemez.

## **SSS**

**Tüm slayt yerine bir grafik veya resim gibi belirli bir şekli nasıl dışa aktarabilirim?**

Aspose.Slides, [tekil şekiller için küçük resim oluşturmayı](/slides/tr/net/create-shape-thumbnails/) destekler; böylece bir şekli PNG görüntüsü olarak işleyebilirsiniz.

**Bir sunucuda paralel dönüşüm destekleniyor mu?**

Evet. Her iş parçacığı veya süreç için ayrı bir sunum örneği kullanın; [tek bir örneği iş parçacıkları arasında paylaşmayın](/slides/tr/net/multithreading/).

**PNG olarak dışa aktarırken değerlendirme sınırlamaları nelerdir?**

Değerlendirme modu, çıkış görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/net/licensing/) uygular.