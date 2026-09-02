---
title: Sunum Slaytlarını .NET'te Görüntülere Dönüştürme
linktitle: Slayt Görüntüye
type: docs
weight: 41
url: /tr/net/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntü
- slaytı görüntü olarak kaydet
- slayttan EMF
- slayttan PNG
- slayttan JPEG
- slayttan bitmap
- slayttan TIFF
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PPT, PPTX ve ODP sunumlarından PNG, JPEG, GIF, TIFF, EMF ve diğer görüntü formatlarına C# ile Aspose.Slides for .NET kullanarak slaytları dönüştürün."
---
## **Giriş**

Aspose.Slides for .NET, PowerPoint ve OpenDocument sunumlarından tek tek slaytları PNG, JPEG, GIF, TIFF ve diğer görüntü formatları olarak render edebilir.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. Sunumu [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. Render etmek istediğiniz slaytı seçin.
3. Gerekirse renderlemeyi [RenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/renderingoptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/) sınıfı ile yapılandırın.
4. [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) yöntemini çağırın. Bu, bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesi döndürür.
5. [IImage.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/save/) yöntemini çağırın ve çıktı formatını bir [ImageFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/) değeriyle belirtin.

## **Bir Slaytı PNG Görüntüsü Olarak Dönüştürme**

En basit dönüşüm, varsayılan render ayarlarını kullanır. Oluşan [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesi bellekte işlenebilir veya bir dosyaya kaydedilebilir.

Aşağıdaki C# örneği ilk slaytı render eder ve PNG görüntüsü olarak kaydeder:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Özel Boyutlarla Slaytları Görüntülere Dönüştürme**

Bir slaytı tam piksel boyutlarıyla renderlemek için [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) değerini kabul eden [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) aşırı yüklemesini kullanın.

Aşağıdaki örnek 1820 × 1040 JPEG görüntüsü oluşturur:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Not ve Yorumlu Slaytları Görüntülere Dönüştürme**

Varsayılan olarak, slayt görüntüleri notları veya yorumları içermez. Notların ve yorumların nerede görüneceğini kontrol etmek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) nesnesini [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) özelliğine atayın.

Aşağıdaki örnek, kesilmiş notları slaydın altına ve yorumları sağ tarafına yerleştirir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Uyarı" color="warning" %}}
Slaytı-görüntüye dönüştürme işlemi için, [NotesPosition](https://reference.aspose.com/slides/tr/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) özelliğini [BottomFull](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notespositions/) olarak ayarlamayın. Notlar, sabit görüntü boyutunun alabileceğinden daha fazla metin içerebilir. Bunun yerine [BottomTruncated](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notespositions/) kullanın.
{{% /alert %}}

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/) sınıfı, render edilen TIFF görüntüsünün boyutunu, çözünürlüğünü ve diğer özelliklerini kontrol etmenizi sağlar.

Aşağıdaki örnek, ilk slaytı 2160 × 2880 TIFF görüntüsü olarak 300 DPI'da render eder:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Tüm Slaytları Görüntülere Dönüştürme**

Tüm sunumu bir dizi görüntüye dönüştürmek için slayt koleksiyonunu yineleyin. Gizli slaytlar, açıkça atmadığınız sürece dahil edilir.

Aşağıdaki örnek, her slaytı yatay ve dikey ölçek faktörleri 2 olan JPEG görüntüsü olarak render eder:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Gelişmiş Metafile Çıktısı Oluşturma**

Gelişmiş Metafile (EMF), vektör tabanlı grafiklerin Microsoft Office veya Windows metafile desteği olan diğer Windows uygulamalarıyla değiş tokuş edilmesi gerektiğinde faydalıdır. Piksel tabanlı bir görüntünün aksine, EMF, keskinlik kaybı olmadan ölçeklenebilen vektör çizim işlemlerini koruyabilir. Ancak EMF, temel olarak Windows metafile desteği olan uygulamalar için bir uyumluluk formatıdır, evrensel bir değişim formatı değildir. Ayrıca, bitmap görüntüler ve bazı efektler gibi karmaşık slayt içeriği, vektör metafile kapsayıcısının içinde rasterleştirilmiş öğeler olarak saklanabilir.

### **Bir Slaytı EMF Olarak Dışa Aktarma**

[ISlide.WriteAsEmf](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/writeasemf/) yöntemi, bir [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/) hedef akışa EMF formatında yazar. Aşağıdaki örnek bir sunumu yükler, ilk slaytı seçer ve onu bir EMF dosya akışına yazar:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Çağıran, [ISlide.WriteAsEmf](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/writeasemf/) yöntemine geçirilen akışın sahibi olup, onu kapatmalı veya dispose etmelidir. Aspose.Slides, akışın mevcut konumunda yazar ve akışı açık bırakır.

### **Bir SVG Görüntüsünü EMF Olarak Dönüştürme ve Sunuma Ekleme**

SVG içeriğini EMF'e dönüştürmek için [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/writeasemf/) kullanın. Ortaya çıkan baytlar, [IImageCollection.AddImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection/addimage/) aracılığıyla sunuma eklenebilir ve bir slayta [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addpictureframe/) ile yerleştirilebilir.

Aşağıdaki örnek, SVG işaretlemesinden bir [SvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/svgimage/) oluşturur, bunu bellek içi bir EMF'e dönüştürür, metafile'i ilk slayta ekler ve sunumu kaydeder:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/writeasemf/) hedef akışın sahipliğini almaz. Yazdıktan sonra, akış konumu üretilen verinin sonunda olur. Yukarıda gösterildiği gibi aynı seekable akışı bir okuyucuya geçirmeden önce `Position`'ı başa sıfırlayın. Akışı, tüketici okumayı bitirene kadar açık tutun ve ardından dispose edin. Alternatif olarak, `ToArray`'i çağırıp dönen bayt dizisini [IImageCollection.AddImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection/addimage/) yöntemine gönderin; `ToArray`, mevcut akış konumundan bağımsız olarak tam tamponu döndürür.

EMF oluşturma, seçilen Aspose.Slides for .NET derlemesi tarafından desteklenen işletim sistemlerinde mümkündür, ancak yazı tipleri veya yerel grafik bağımlılıkları mevcut olmadığında platformlar arasında renderleme farklılık gösterebilir. Kaynak içeriği tarafından kullanılan yazı tiplerini kurun veya uygun ikameler yapılandırın, Aspose.Slides paketinize ilişkin [platform gereksinimlerini](/slides/tr/net/system-requirements/) izleyin ve hedef EMF tüketen uygulamada sonucu doğrulayın. Linux ve macOS uygulamaları genellikle Windows metafilelarını görüntüleme ve düzenleme konusunda sınırlı veya tutarsız destek sunar.

## **Renkli Emoji Renderleme**

{{% alert title="Not" color="info" %}}
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru bir şekilde renderlemek için, sunumda kullanılan emoji yazı tiplerinin dönüştürmeyi yapan sistemde kurulmuş ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların render edilmesini destekliyor mu?**

Hayır. [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) yöntemi slaytın statik bir görüntüsünü render eder ve animasyonları dışa aktarmaz.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet. Gizli slaytlar normal slaytlar gibi render edilebilir. Yukarıdaki örnekte gösterildiği gibi işleme döngüsüne dahil edin.

**Slayt görüntülerinde gölgeler ve diğer efektler korunuyor mu?**

Evet. Aspose.Slides, slayt görüntülerinde gölgeler, şeffaflık ve diğer desteklenen grafik efektlerini render eder.