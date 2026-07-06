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
- görsel ekle
- görsel oluştur
- görsel çıkar
- raster görüntü
- vektör görüntü
- görüntüyü kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreli ölçek
- görsel efekti
- en boy oranı
- görsel şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı düzenleyin ve slayt tasarımlarını geliştirin.
---
## **Giriş**

Resim çerçevesi, bir resmi içeren bir şekildir—çerçeve içindeki bir fotoğraf gibidir.  

Bir slayta resmi bir resim çerçevesi aracılığıyla ekleyebilirsiniz. Bu sayede resmi, resim çerçevesini biçimlendirerek formatlayabilirsiniz.

{{% alert  title="Tip" color="primary" %}} 

Aspose, ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlayarak kullanıcıların resimlerden hızlıca sunum oluşturmasını sağlar. 

{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)class örneği oluşturun. 
2. Bir slaydın referansını dizini üzerinden alın. 
3. Sunum nesnesine bağlı olan [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection) içine bir resim ekleyerek [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır. 
4. Resmin genişliğini ve yüksekliğini belirtin. 
5. Referans verilen slayda ait şekil nesnesi tarafından sunulan `AddPictureFrame` yöntemiyle resmin genişliği ve yüksekliğine göre bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe) oluşturun. 
6. Resim çerçevesini (içindeki resmi) slayta ekleyin. 
7. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki C# kodu, bir resim çerçevesi oluşturmayı gösterir:

```c#
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

Resim çerçeveleri, resimlere dayalı sunum slaytlarını hızlıca oluşturmanızı sağlar. Resim çerçevesini Aspose.Slides kaydetme seçenekleriyle birleştirerek giriş/çıkış işlemlerini yönlendirebilir, resimleri bir formattan diğerine dönüştürebilirsiniz. Şu sayfalara da göz atabilirsiniz: [image to JPG](https://products.aspose.com/slides/tr/net/conversion/image-to-jpg/) dönüştürme; [JPG to image](https://products.aspose.com/slides/tr/net/conversion/jpg-to-image/) dönüştürme; [JPG to PNG](https://products.aspose.com/slides/tr/net/conversion/jpg-to-png/) dönüştürme, [PNG to JPG](https://products.aspose.com/slides/tr/net/conversion/png-to-jpg/) dönüştürme; [PNG to SVG](https://products.aspose.com/slides/tr/net/conversion/png-to-svg/) dönüştürme, [SVG to PNG](https://products.aspose.com/slides/tr/net/conversion/svg-to-png/) dönüştürme.

{{% /alert %}}

## **Göreli Ölçekli Resim Çerçevesi Oluşturma**

Bir resmin göreli ölçeklemesini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) class örneği oluşturun. 
2. Bir slaydın referansını dizini üzerinden alın. 
3. Sunumun resim koleksiyonuna bir resim ekleyin. 
4. Sunum nesnesine bağlı olan [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection) içine bir resim ekleyerek [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır. 
5. Resim çerçevesindeki resmin göreli genişliğini ve yüksekliğini belirtin. 
6. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki C# kodu, göreli ölçekli bir resim çerçevesi oluşturmayı gösterir:

```c#
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
using (Presentation presentation = new Presentation())
{
    // Bir görüntü yükler ve sunumun görüntü koleksiyonuna ekler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Slayta bir resim çerçevesi ekler
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Göreli ölçek genişliğini ve yüksekliğini ayarlar
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Sunumu kaydeder
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Resim Çerçevelerinden Raster Görüntü Çıkarma**

[PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe) nesnelerinden raster görüntüleri çıkarabilir ve PNG, JPG gibi formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, “sample.pptx” belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi gösterir.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Resim Çerçevelerinden SVG Görüntü Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) şekilleri içinde SVG grafikleri barındırıyorsa, Aspose.Slides for .NET, özgün vektör görüntülerini tam özgünlükle almanıza olanak tanır. Slaydın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) nesnesini tanımlayabilir, altında yatan [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesinin SVG içeriği taşıyıp taşımadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske ya da akıma kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü çıkarmayı gösterir:

```cs
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

## **Bir Görüntünün Şeffaflığını Alma**

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza imkan tanır. Bu C# kodu işlemi gösterir:

```c#
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

## **Bir Görüntünün Parlaklık ve Kontrastını Alma**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast etkisini almanıza imkan tanır. Bu görüntü dönüşüm etkisini temsil eden [ILuminance](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/iluminance/) arayüzüdür.

Aşağıdaki C# kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını almayı gösterir:

```csharp
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

{{% alert color="primary" %}} 
Görüntülere uygulanan tüm efektler [Aspose.Slides.Effects](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/) içinde bulunabilir.
{{% /alert %}}

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak bir resim çerçevesini belirli gereksinimlere uygun hâle getirebilirsiniz.

1. [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) class örneği oluşturun. 
2. Bir slaydın referansını dizini üzerinden alın. 
3. Sunum nesnesine bağlı olan [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection) içine bir resim ekleyerek [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır. 
4. Resmin genişliğini ve yüksekliğini belirtin. 
5. Referans verilen slayda ait [IShapes](http://www.aspose.com/api/net/slides/tr/aspose.slides/ishapecollection) nesnesi üzerinden sunulan [AddPictureFrame](http://www.aspose.com/api/net/slides/tr/aspose.slides/ishapecollection/methods/addpictureframe) yöntemiyle resmin genişliği ve yüksekliğine göre bir `PictureFrame` oluşturun. 
6. Resim çerçevesini (içindeki resmi) slayta ekleyin. 
7. Resim çerçevesinin kenar çizgi rengini ayarlayın. 
8. Resim çerçevesinin kenar çizgi kalınlığını ayarlayın. 
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif değer, görüntüyü saat yönünde döndürür.  
   * Negatif değer, görüntüyü saat yönünün tersine döndürür. 
10. Resim çerçevesini (içindeki resmi) slayta ekleyin. 
11. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki C# kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```c#
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

{{% alert color="primary" %}}

Aspose yakın zamanda ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntüleri birleştirmeniz, fotoğraflardan ızgara oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz. 

{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekleme**

Sunum dosyalarının boyutunu azaltmak için görüntüleri (veya videoları) doğrudan dosyaya gömmek yerine bağlantı yoluyla ekleyebilirsiniz. Bu C# kodu, bir yer tutucu içine görüntü ve video eklemeyi gösterir:

```c#
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

Bu C# kodu, bir slayt üzerindeki mevcut bir görüntüyü kırpmayı gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    // Yeni bir görüntü nesnesi oluşturur
    IImage image = Images.FromFile(imagePath);
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

## **Bir Resim Çerçevesinin Kırpılmış Alanlarını Silme**

Bir çerçeve içinde bulunan görüntünün kırpılmış alanlarını silmek istiyorsanız, [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemini kullanabilirsiniz. Bu yöntem, kırpılmış görüntüyü ya da kırpma gerekmediğinde orijinal görüntüyü döndürür.

Aşağıdaki C# kodu işlemi göstermektedir:

```c#
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

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemi, kırpılmış görüntüyü sunumun resim koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) içinde kullanılıyorsa bu yapı sunum boyutunu azaltabilir. Aksi takdirde sonuç sunumdaki resim sayısı artar.

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafile'larını raster PNG görüntüsüne dönüştürür. 

{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/compressimage/) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre resmi küçülterek, isteğe bağlı olarak kırpılmış alanları silebilir. 

PowerPoint'in **Picture Format → Compress Pictures → Resolution** özelliğine benzer şekilde resmin boyutunu ve çözünürlüğünü ayarlar.

Aşağıdaki C# örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumda görüntüyü sıkıştırmayı gösterir:

```csharp
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
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Görüntüyü 150 DPI (web çözünürlüğü) sıkıştırır, kırpılmış alanları kaldırır.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Yöntem, şeklin boyutu ve sağlanan DPI temelinde görüntüyü daha düşük bir çözünürlüğe dönüştürür. Dosya boyutunu optimize etmek için kırpılmış bölgeler de silinebilir.  
Görüntü bir metafile (WMF/EMF) ya da SVG ise sıkıştırma uygulanmaz. JPEG kalitesi, çözünürlüğe bağlı olarak korunur veya hafifçe düşer; bu davranış PowerPoint'in yüksek çözünürlüklü JPEG'leri ele almasıyla benzerlik gösterir.

{{% /alert %}}

## **En Boy Oranını Kilitleme**

Bir şekil içindeki görüntünün boyutlarını değiştirdiğinizde bile şeklin en boy oranını korumak istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframelock/aspectratiolocked/) özelliğini kullanabilirsiniz. 

Aşağıdaki C# kodu, bir şeklin en boy oranını kilitlemeyi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Şeklin yeniden boyutlandırmada en boy oranını korumasını ayarlar
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en boy oranını korur, içerdiği resmi değil.

{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat) sınıfı üzerinden [StretchOffsetLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetright) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) özelliklerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz. 

Bir görüntü için germe (stretch) belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklenir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun karşı kenarına göre yüzde offset ile tanımlanır. Pozitif yüzde bir içeriği (inset) belirtirken negatif yüzde bir dışarıyı (outset) belirtir.

1. [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) class örneği oluşturun. 
2. Bir slaydın referansını dizini üzerinden alın. 
3. Bir `AutoShape` dikdörtgeni ekleyin. 
4. Bir resim oluşturun. 
5. Şeklin doldurma türünü ayarlayın. 
6. Şeklin resim doldurma modunu ayarlayın. 
7. Şekli doldurmak için bir resim ekleyin. 
8. Resim offset'lerini şeklin sınırlayıcı kutusunun karşı kenarına göre belirtin. 
9. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki C# kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Şekil gövdesinde görüntünün her yanından gerilmesini ayarlar
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) nesnesine atanan görüntü nesnesi aracılığıyla raster (PNG, JPEG, BMP, GIF vb.) ve vektör (ör. SVG) görüntüleri destekler. Desteklenen formatların listesi, slayt ve görüntü dönüştürme motorunun yetenekleriyle genellikle örtüşür.

**Yüzlerce büyük görüntü eklemek PPTX boyutunu ve performansını nasıl etkiler?**

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlamak (link) dosya boyutunu düşük tutar ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı yoluyla ekleme imkanı sunar.

**Bir görüntü nesnesini yanlışlıkla taşınması/yeniden boyutlandırılmasından nasıl kilitleyebilirim?**

[PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/pictureframelock/) (ör. hareketi veya yeniden boyutlandırmayı devre dışı bırakma) kullanın. Kilitleme mekanizması, çeşitli şekil türleri için ayrı bir [protection article](/slides/tr/net/applying-protection-to-presentation/) içinde açıklanmıştır.

**SVG vektör özgünlüğü, bir sunumu PDF/görüntülere dışa aktarırken korunur mu?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) içindeki SVG'yi özgün vektör olarak çıkarabilir. [PDF'ye dışa aktarırken](/slides/tr/net/convert-powerpoint-to-pdf/) veya [raster formatlara](/slides/tr/net/convert-powerpoint-to-png/) çıkış yapılırken, ayarlara bağlı olarak sonuç rasterleştirilebilir; ancak SVG'nin vektör olarak saklandığı, çıkarma davranışıyla doğrulanır.