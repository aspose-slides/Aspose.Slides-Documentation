---
title: .NET'te Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/net/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- görüntü ekle
- görüntü oluştur
- görüntü çıkar
- raster görüntü
- vektör görüntü
- görüntüyü kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreceli ölçek
- görüntü efekti
- en boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı sadeleştirin ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Resim çerçevesi, bir resmi içinde barındıran bir şekildir—çerçeve içinde bir resim gibidir.  

Bir slayta resmi bir resim çerçevesi aracılığıyla ekleyebilirsiniz. Böylece, resim çerçevesini biçimlendirerek resmi biçimlendirebilirsiniz.

{{% alert  title="Tip" color="info" %}} 
Aspose, insanların görüntülerden hızlıca sunumlar oluşturmasını sağlayan ücretsiz dönüştürücüler—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—sunar. 
{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection)’a bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun.  
4. Resmin genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı şekil nesnesi tarafından sunulan `AddPictureFrame` yöntemiyle, resmin genişliği ve yüksekliğine dayanarak bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe) oluşturun.  
6. Bir resim çerçevesini (içindeki resmi) slayta ekleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C# kodu, bir resim çerçevesi oluşturmayı gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX dosyasını temsil eden Presentation sınıfını örnekler
using (Presentation pres = new Presentation())
{
    // İlk slaytı alır
    ISlide slide = pres.Slides[0];

    // Bir görüntü yükler ve sunumun görüntü koleksiyonuna ekler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Aynı yüksekliğe ve genişliğe sahip bir resim çerçevesi ekler
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Resim çerçevesine bazı biçimlendirmeler uygular
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Sunumu bir PPTX dosyasına yazar
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlıca oluşturmanızı sağlar. Resim çerçevesini Aspose.Slides kaydetme seçenekleriyle birleştirerek giriş/çıkış işlemlerini yönetebilir ve görüntüleri bir formattan diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara da göz atabilirsiniz: [görüntüyü JPG'e dönüştür](https://products.aspose.com/slides/tr/net/conversion/image-to-jpg/); [JPG'yi görüntüye dönüştür](https://products.aspose.com/slides/tr/net/conversion/jpg-to-image/); [JPG'yi PNG'e dönüştür](https://products.aspose.com/slides/tr/net/conversion/jpg-to-png/), [PNG'yi JPG'e dönüştür](https://products.aspose.com/slides/tr/net/conversion/png-to-jpg/); [PNG'yi SVG'e dönüştür](https://products.aspose.com/slides/tr/net/conversion/png-to-svg/), [SVG'yi PNG'e dönüştür](https://products.aspose.com/slides/tr/net/conversion/svg-to-png/). 
{{% /alert %}}

## **Göreceli Ölçekli Resim Çerçevesi Oluşturma**

Görselin göreceli ölçeklendirilmesini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Sunumun resim koleksiyonuna bir resim ekleyin.  
4. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection)’a bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun.  
5. Resmin göreceli genişliğini ve yüksekliğini resim çerçevesinde belirtin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C# kodu, göreceli ölçekli bir resim çerçevesi oluşturmayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX dosyasını temsil eden Presentation sınıfını örnekler
using (Presentation presentation = new Presentation())
{
    // Bir görüntü yükler ve sunumun görüntü koleksiyonuna ekler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Slayta bir resim çerçevesi ekler
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Göreceli ölçek genişliğini ve yüksekliğini ayarlar
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Sunumu kaydeder
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Resim Çerçevelerinden Raster Görüntüleri Çıkarma**

[PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe) nesnelerinden raster görüntüleri çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü çıkarıp PNG formatında nasıl kaydedeceğinizi gösterir.

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Resim Çerçevelerinden SVG Görüntüleri Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) şekilleri içinde SVG grafikler barındırdığında, Aspose.Slides for .NET, özgün vektör görüntülerini tam sadakatle almanıza olanak tanır. Slaytın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) öğesini tanımlayabilir, altındaki [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesinin SVG içeriği taşıyıp taşımadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske veya akıma kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü çıkarmayı gösterir:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Bir Görüntünün Şeffaflığını Almak**

Aspose.Slides, bir görüntüye uygulanmış şeffaflık etkisini almanıza izin verir. Bu C# kodu işlemi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Bir Görüntünün Parlaklık ve Kontrastını Almak**

Aspose.Slides, bir görüntüye uygulanmış parlaklık ve kontrast etkisini almanıza izin verir. [ILuminance](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iluminance/) arayüzü bu görüntü dönüşüm etkisini temsil eder.

Bu C# kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını nasıl alacağınızı gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
Görüntülere uygulanan tüm efektler [Aspose.Slides.Effects](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/) içinde bulunabilir. 
{{% /alert %}}

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak bir resim çerçevesini belirli gereksinimlere uygun şekilde değiştirebilirsiniz.  

1. Bir [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection)’a bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun.  
4. Resmin genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı [IShapes](http://www.aspose.com/api/net/slides/tr/aspose.slides/ishapecollection) nesnesi tarafından sunulan [AddPictureFrame](http://www.aspose.com/api/net/slides/tr/aspose.slides/ishapecollection/methods/addpictureframe) yöntemiyle, resmin genişliği ve yüksekliğine dayanarak bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (içindeki resmi) slayta ekleyin.  
7. Resim çerçevesinin çizgi rengini ayarlayın.  
8. Resim çerçevesinin çizgi kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif değer saat yönünde döndürür.  
   * Negatif değer saat yönünün tersine döndürür.  
10. Resim çerçevesini (içindeki resmi) slayta ekleyin.  
11. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C# kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX dosyasını temsil eden Presentation sınıfını örnekler
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alır
    ISlide slide = presentation.Slides[0];

    // Bir görüntü yükler ve sunumun görüntü koleksiyonuna ekler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Resmin eşdeğer yüksekliği ve genişliğiyle bir resim çerçevesi ekler
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Resim çerçevesine bazı biçimlendirmeler uygular
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Sunumu bir PPTX dosyasına yazar
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Aspose yakın zamanda ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntülerini birleştirmek, fotoğraflardan ızgara oluşturmak istediğinizde bu hizmeti kullanabilirsiniz. 
{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekleme**

Sunum boyutlarını büyük tutmamak için, dosyaları doğrudan gömmek yerine bağlantılar aracılığıyla görüntü (veya video) ekleyebilirsiniz. Bu C# kodu, bir yer tutucuya görüntü ve video nasıl ekleyeceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Görüntüleri Kırpma**

Bu C# kodu, bir slayttaki mevcut bir görüntüyü nasıl kırpacağınızı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Yeni bir görüntü nesnesi oluşturur
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Bir slayta PictureFrame ekler
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Görüntüyü kırpar (yüzde değerleri)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Sonucu kaydeder
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Resim Çerçevesindeki Kırpılmış Alanları Silme**

Bir çerçevede bulunan görüntünün kırpılmış alanlarını silmek istiyorsanız, [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksiz ise orijinal görüntüyü, aksi takdirde kırpılmış görüntüyü döndürür.

Bu C# kodu işlemi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // İlk slayttan PictureFrame'i alır
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // PictureFrame görüntüsünün kırpılmış alanlarını siler ve kırpılmış görüntüyü döndürür
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Sonucu kaydeder
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görsel yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu yapı sunum boyutunu azaltabilir. Aksi takdirde, sonuç sunumdaki görüntü sayısı artar.  

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafilelerini raster PNG görüntüsüne dönüştürür. 
{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/compressimage/) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre resmi küçülterek kırpılmış alanları silme seçeneği sunar.  

PowerPoint'in **Picture Format → Compress Pictures → Resolution** özelliğine benzer şekilde resmin boyut ve çözünürlüğünü ayarlar.  

Aşağıdaki C# örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki resmi nasıl sıkıştıracağınızı gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Görüntüyü hedef çözünürlük 150 DPI (Web çözünürlüğü) ile sıkıştırır ve kırpılmış alanları kaldırır.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Sıkıştırmanın sonucunu kontrol eder.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Veya doğrudan özel bir DPI değeri kullanarak:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Görüntüyü 150 DPI (web çözünürlüğü) seviyesine sıkıştırır, kırpılmış alanları kaldırır.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
Yöntem, şeklin boyutuna ve sağlanan DPI değerine göre resmi daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler de dosya boyutunu optimize etmek için silinebilir.  
Görüntü bir metafile (WMF/EMF) ya da SVG ise sıkıştırma uygulanmaz. JPEG kalitesi ise çözünürlüğe bağlı olarak korunur ya da hafifçe azaltılır; bu davranış PowerPoint'in yüksek çözünürlüklü JPEG'leri işlemesine benzer. 
{{% /alert %}}

## **En Boy Oranını Kilitleme**

Bir şeklin içinde bulunan görüntünün boyutlarını değiştirdiğinizde bile şeklin en boy oranının korunmasını istiyorsanız, [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframelock/aspectratiolocked/) özelliğini kullanarak *En Boy Oranı Kilitle* ayarını belirleyebilirsiniz.  

Bu C# kodu, bir şeklin en boy oranını nasıl kilitleyeceğinizi gösterir:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Yeniden boyutlandırmada şeklin en boy oranını korumasını ayarlar
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 
Bu *En Boy Oranı Kilitle* ayarı yalnızca şeklin en boy oranını korur; içinde barındırdığı görüntüyü korumaz. 
{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat) sınıfı üzerinden [StretchOffsetLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetright) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) özelliklerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz.  

Bir görüntü için germe (stretch) belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde olarak bir offset ile tanımlanır. Pozitif yüzde içeri çekmeyi, negatif yüzde dışarı itmeyi belirtir.  

1. Bir [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Bir `AutoShape` dikdörtgeni ekleyin.  
4. Bir resim oluşturun.  
5. Şeklin doldurma tipini ayarlayın.  
6. Şeklin resim doldurma modunu ayarlayın.  
7. Şekli doldurmak için bir resim seti ekleyin.  
8. Resim offsetlerini şeklin sınırlayıcı kutusunun ilgili kenarından belirtin.  
9. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C# kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Şekil gövdesindeki resmin her bir taraftan gerilmesini ayarlar
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **SSS**

### Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) üzerine atanan görüntü nesnesi aracılığıyla raster görüntüler (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüler (örneğin SVG) destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüşüm motorunun yetenekleriyle örtüşür.  

### Çok sayıda büyük görüntü eklemek PPTX boyutunu ve performansı nasıl etkiler?

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlamak sunum boyutunu düşük tutar ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı yoluyla ekleme imkanı sunar.  

### Bir görüntü nesnesinin kazara hareket etmesini/yeniden boyutlandırılmasını nasıl kilitleyebilirim?

[PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/pictureframelock/) (örneğin taşıma veya yeniden boyutlandırmayı devre dışı bırakma) kullanın. Kilitleme mekanizması, çeşitli şekil tipleri için ayrı bir [koruma makalesinde](/slides/tr/net/applying-protection-to-presentation/) açıklanmıştır ve [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) dahil olmak üzere birçok şekil türü için desteklenir.  

### SVG vektör doğruluğu, bir sunumu PDF/görüntülere dışa aktardığımda korunur mu?

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) üzerinden SVG'yi özgün vektör olarak çıkarabilir. PDF'ye ([exporting to PDF](/slides/tr/net/convert-powerpoint-to-pdf/)) veya raster formatlara ([exporting to PNG](/slides/tr/net/convert-powerpoint-to-png/)) dışa aktarırken, ayarlara bağlı olarak sonuç rasterleştirilebilir; ancak SVG'nin vektör olarak saklanması çıkarma davranışıyla kanıtlanır.