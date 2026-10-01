---
title: .NET'te Not Sayfası Boyutunu ve Yönünü Değiştir
linktitle: Not Sayfası Boyutu
type: docs
weight: 10
url: /tr/net/notes-size/
keywords:
- not sayfası boyutu
- not yönü
- yatay notlar
- dikey notlar
- el ilanı boyutu
- PowerPoint
- sunum
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te not sayfası boyutlarını okuyun ve değiştirin, yönü değiştirin, kaydedilen boyutları doğrulayın ve notları veya el ilanlarını PDF ve görüntülere dışa aktarın."
---
## **Genel Bakış**

Sunumun not sayfası ayarlarına erişmek için [Presentation.NotesSize](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/notessize/) kullanın. Bu, [Size](https://reference.aspose.com/slides/tr/net/aspose.slides/inotessize/size/) özelliği yazılabilir olan bir [INotesSize](https://reference.aspose.com/slides/tr/net/aspose.slides/inotessize/) nesnesi döndürür. Ayar nesnesi kendisi yalnızca okunabilir olsa da, boyut özelliğine yeni boyutlar atayabilirsiniz.

Genişlik ve yükseklik **nokta** cinsinden belirtilir; bir inçte 72 nokta vardır. Örneğin, 900 × 600 nokta 12,5 × 8⅓ inçtir. Bu ayarlar bireysel bir slaytın notlarından ziyade sunuma uygulanır.

| Ayar | Amaç |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/notessize/) | Not sayfası boyutlarını ve el ilanı dışa aktarımı için kullanılan sayfa boyutlarını kontrol eder. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slidesize/) | Normal sunum slayt boyutlarını [ISlideSize](https://reference.aspose.com/slides/tr/net/aspose.slides/islidesize/) aracılığıyla kontrol eder. |

Bu ayarlardan birini değiştirmek diğerini otomatik olarak değiştirmez. Not sayfası yönünü değiştirmek de normal slaytları döndürmez. Normal slaytları yeniden boyutlandırmak için [Slide Size](/slides/tr/net/slide-size/) sayfasına bakın.

Aşağıdaki örnekler mevcut bir `sample.pptx` dosyasını kullanır. Dışa aktarım örnekleri için içinde konuşmacı notları bulunan en az bir slayt içeren bir sunum kullanın. Her örnek bağımsız olarak çalıştırılabilir.

## **Not Sayfası Boyutunu ve Yönünü Okuma**

Genişlik ve yüksekliği okuyup karşılaştırarak yönü belirleyin: daha geniş bir sayfa yatay, daha yüksek bir sayfa dikey, eşit boyutlar kare bir sayfayı tanımlar. Bu örnek, standart bir kağıt boyutu varsaymadan gerçek boyutları nokta cinsinden yazdırır.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Kağıt Boyutunu Değiştirmeden Yatay'a Geçiş**

Yalnızca yönü değiştirmek için mevcut genişlik ve yüksekliği değiştirin. Bu, özel bir kağıt boyutunun her iki tarafının uzunluğunu da korur. Aşağıdaki koşul, zaten yatay olan bir sayfanın tekrar dikeye çevrilmesini engeller ve kare bir sayfayı değiştirmez.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Dikey yön için, `size.Width > size.Height` olduğunda aynı atamayı kullanın. Kağıt boyutunu da değiştirmek istemiyorsanız A4 veya Letter boyutlarını değiştirmeyin.

## **Özel Bir Not Sayfası Boyutu Ayarlama ve Doğrulama**

Her iki boyutu aynı anda atayın, ardından sunumu kaydetmek için [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) kullanın. Bu örnek, 900 × 600 noktalık bir yatay sayfa ayarlar, PPTX olarak kaydeder ve kaydedilen dosyayı tekrar açarak kalıcı değerleri kontrol eder. Karşılaştırma, kayan nokta değerleri için 0,01 nokta toleransına izin verir; bu, her dosya formatı için kesinlik garantisi değildir.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Beklenen sonuç `900 x 600 points` ve `Size preserved: True` dir. Yeni açılan bir sunumu kontrol etmek, sadece bellek içi ayarları değil, kaydedilen dosyayı doğrular.

## **Notları ve El İlanlarını Dışa Aktarma**

Sayfa boyutları, notlar veya el ilanı düzenleri için kullanılabilir alanı tanımlar. Bu boyutlar tek başına bu düzenleri etkinleştirmez; dışa aktarma seçeneklerini de yapılandırın. Normal slayt dışa aktarma, slayt boyutlarını kullanmaya devam eder.

### **Notları PDF ve PNG Olarak Dışa Aktarma**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) öğesini [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) öğesine atayarak notları PDF'ye ekleyin. Bu örnek ayrıca [Slide.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/renderingoptions/) kullanarak notlu ilk slaytı PNG olarak işler.

[BottomTruncated](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notespositions/) modu notları tek bir sayfada tutar; sığmayan notlar kırpılabilir. PDF, 900 × 600 noktalık sayfalar kullanır. Aşağıda kullanılan 1 × 1 görüntü ölçeğinde PNG, 900 × 600 piksel olur. Noktalar sayfa geometrisini, pikseller raster çıktıyı tanımlar; boyutlar aynı zamanda render ölçeğine bağlıdır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Uzun notlarla PDF dışa aktarımı için, [BottomFull](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notespositions/) ihtiyaca göre ek sayfalara izin verir. Yukarıdaki tek slayt görüntü çağrısında bu modu kullanmayın, çünkü desteklenmez. Yeniden boyutlandırdıktan sonra, kırpılmış notlar ve mevcut not-ana nesnelerinin yerleşimi için çıktıyı inceleyin; sadece sayfa boyutlarını değiştirmek, tüm içeriğin sığıp sığmayacağına dair bir garanti olarak görülmemelidir. Not dışa aktarımı hakkında daha fazla bilgi için [Convert PowerPoint to PDF with Notes](/slides/tr/net/convert-powerpoint-to-pdf-with-notes/) sayfasına bakın.

### **El İlanlarını PDF Olarak Dışa Aktarma**

Bir sayfada birden çok slayt küçük resmini göstermek için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/handoutlayoutingoptions/) kullanın. Aşağıdaki örnek 900 × 600 noktalık bir sayfa ayarlar ve sayfa başına en fazla dört slaytı düzenlemek için [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/tr/net/aspose.slides.export/handouttype/) kullanır. Yatay ön ayar slayt sıralamasını kontrol eder; sayfa yönü ise genişlik ve yükseklikten gelir.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Sayfa boyutunu değiştirmek, kaynak slaytların boyutlarını değiştirmeden el ilanı ızgarası için kullanılabilir alanı değiştirir. El ilanı görüntüleri için, tek bir slaytın görüntü yöntemini değil, el ilanı düzeniyle birlikte [Presentation.GetImages](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/getimages/) kullanın. Aspose.Slides'ta, sunum düzeyinde el ilanı renderi not sayfası boyutlarını kullanırken, bireysel slayt görüntü çağrısı el ilanı sayfası oluşturmaz. Yerleşim seçenekleri için [Handout Mode](/slides/tr/net/convert-powerpoint-in-handout-mode/) sayfasına bakın.

## **Görüntüleyicilerde, Dışa Aktarmada ve Yazdırmada Sayfa Boyutu**

Saklanan sunum boyutunu, dışa aktarılan sayfa boyutunu ve yazdırılan kağıt boyutunu birbirinden ayrı tutun:

- **Sunum görüntüleyicileri:** Görüntüleyici, notları kendi yerleşim kurallarını kullanarak görüntüleyebilir veya yazdırabilir. Başka bir uygulama dosyayı kaydederse, dosyayı yeniden açıp boyutları tekrar kontrol edin; o uygulamanın format dönüşümü onları normalleştirebilir.
- **Dışa aktarma formatları:** Yukarıdaki not ve el ilanı PDF örnekleri yapılandırılmış sayfa boyutlarını kullanır. Raster görüntüler tam sayı piksel boyutları ve bir render ölçeği kullanır, bu yüzden kesirli nokta değerleri görüntü çıktısında yuvarlanabilir. Normal slaytların dışa aktarımı not sayfası boyutunu uygulamaz.
- **Yazıcı sürücüleri:** Kağıt seçimi, otomatik döndürme ve sayfaya sığdırma ayarları, sunumda veya PDF'de saklanan boyutları değiştirmeden fiziksel çıktıyı değiştirebilir. Belirli bir kağıt boyutu için, yazıcı ayarlarını buna göre ayarlayın ve yazdırma önizlemesini inceleyin.

## **SSS**

**Sadece bir slayt için not boyutunu ayarlayabilir miyim?**

Not sayfası boyutu bir sunum düzeyinde ayardır. Tek tek slaytların farklı not içerikleri olabilir, ancak bu özellik her slayt için ayrı bir sayfa boyutu sağlamaz.

**Notların yönünü değiştirmek slaytlarımı neden etkilemedi?**

Not sayfaları ve normal slaytlar bağımsız boyutlara sahiptir. Slaytların kendisini yeniden boyutlandırmak istediğinizde normal slayt boyutu ayarlarını kullanın.

**Kaydedilen veya yazdırılan sonucum neden farklı bir boyuta sahip?**

İlk olarak kaydedilen sunumu yeniden açın ve not boyutlarını karşılaştırın. Eğer değiştiyse, başka bir uygulamada dosyayı kaydetmenin veya dönüştürmenin sayfa ayarlarını değiştirip değiştirmediğini kontrol edin. Değişmediyse, dışa aktarma yerleşimini, görüntü ölçeğini, görüntüleyici ayarlarını ve yazıcı kağıt seçimini inceleyin.