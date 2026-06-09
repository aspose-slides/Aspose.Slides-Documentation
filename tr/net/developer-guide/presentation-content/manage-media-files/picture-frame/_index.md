---
title: .NET'te Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/net/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekleme
- resim çerçevesi oluşturma
- görüntü ekleme
- görüntü oluşturma
- görüntü çıkarma
- raster görüntü
- vektör görüntü
- görüntüyü kırpma
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
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı basitleştirin ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Bir resim çerçevesi, bir resmi içeren bir şekildir—çerçevedeki bir resim gibidir.

Bir resmi bir slayta resim çerçevesi aracılığıyla ekleyebilirsiniz. Böylece, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="primary" %}} 
Aspose, ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlayarak, insanların görüntülerden hızlıca sunumlar oluşturmasını sağlar. 
{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun. 
2. Bir slaydın referansını indeksine göre alın. 
3. Şekli doldurmak için kullanılacak, sunum nesnesiyle ilişkili [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection) içine bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun. 
4. Resmin genişliğini ve yüksekliğini belirtin. 
5. Başvurulan slaytla ilişkili şekil nesnesi tarafından sunulan `AddPictureFrame` yöntemiyle, resmin genişliği ve yüksekliğine göre bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe) oluşturun. 
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin. 
7. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın. 

Bu C# kodu, bir resim çerçevesi oluşturmayı gösterir:

```c#
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
using (Presentation pres = new Presentation())
{
    // İlk slaytı alır
    ISlide slide = pres.Slides[0];

    // Bir görüntü yükler ve sunumun görüntü koleksiyonuna ekler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Aynı yükseklik ve genişliğe sahip bir resim çerçevesi ekler
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
Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlıca oluşturmanızı sağlar. Resim çerçevesi ile Aspose.Slides'ın kaydetme seçeneklerini birleştirerek, görüntüleri bir formattan diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz. Bu sayfalara bakmak isteyebilirsiniz: [image to JPG](https://products.aspose.com/slides/tr/net/conversion/image-to-jpg/); [JPG to image](https://products.aspose.com/slides/tr/net/conversion/jpg-to-image/); [JPG to PNG](https://products.aspose.com/slides/tr/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/tr/net/conversion/png-to-jpg/); [PNG to SVG](https://products.aspose.com/slides/tr/net/conversion/png-to-svg/), [SVG to PNG](https://products.aspose.com/slides/tr/net/conversion/svg-to-png/). 
{{% /alert %}} 

## **Göreceli Ölçekli Resim Çerçevesi Oluşturma**

Bir resmin göreceli ölçeklemesini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun. 
2. Bir slaydın referansını indeksine göre alın. 
3. Sunumun resim koleksiyonuna bir resim ekleyin. 
4. Şekli doldurmak için kullanılacak, sunum nesnesiyle ilişkili [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection) içine bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun. 
5. Resmin göreceli genişliğini ve yüksekliğini resim çerçevesinde belirtin. 
6. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın. 

Bu C# kodu, göreceli ölçekli bir resim çerçevesi oluşturmayı gösterir:

```c#
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
using (Presentation presentation = new Presentation())
{
    // Bir görüntü yükler ve sunumun görüntü koleksiyonuna ekler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Slayta bir resim çerçevesi ekler
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Göreceli ölçek genişlik ve yüksekliğini ayarlar
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Sunumu kaydeder
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Resim Çerçevelerinden Raster Görüntüler Çıkarma**

Raster görüntüleri [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe) nesnelerinden çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi göstermektedir.

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

## **Resim Çerçevelerinden SVG Görüntüler Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) şekilleri içinde yer alan SVG grafikler içerdiğinde, Aspose.Slides for .NET, orijinal vektör görüntülerini tam doğrulukla almanıza olanak tanır. Slaydın şekil koleksiyonunu dolaşarak, her bir [PictureFrame] nesnesini tanımlayabilir, altında bulunan [IPPImage] SVG içeriği taşıyıp taşımadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske ya da akışa kaydedebilirsiniz.

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

## **Bir Görüntünün Şeffaflığını Almak**

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza olanak tanır. Bu C# kodu işlemi gösterir:

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

{{% alert color="primary" %}} 
Görüntülere uygulanan tüm efektler [Aspose.Slides.Effects](https://reference.aspose.com/slides/tr/net/aspose.slides.effects/) içinde bulunabilir. 
{{% /alert %}}

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilen birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere uygun hale getirebilirsiniz.

1. Bir [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının bir örneğini oluşturun. 
2. Bir slaydın referansını indeksine göre alın. 
3. Şekli doldurmak için kullanılacak, sunum nesnesiyle ilişkili [IImagescollection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection) içine bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun. 
4. Resmin genişliğini ve yüksekliğini belirtin. 
5. Referans alınan slaytla ilişkili [IShapes](http://www.aspose.com/api/net/slides/tr/aspose.slides/ishapecollection) nesnesi tarafından sunulan [AddPictureFrame](http://www.aspose.com/api/net/slides/tr/aspose.slides/ishapecollection/methods/addpictureframe) metoduyla, resmin genişliği ve yüksekliğine göre bir `PictureFrame` oluşturun. 
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin. 
7. Resim çerçevesinin çizgi rengini ayarlayın. 
8. Resim çerçevesinin çizgi kalınlığını ayarlayın. 
9. Resim çerçevesini pozitif veya negatif bir değer vererek döndürün. 
   * Pozitif bir değer resmi saat yönünde döndürür. 
   * Negatif bir değer resmi saat yönünün tersine döndürür. 
10. Slayta bir resim çerçevesi (resmi içeren) ekleyin. 
11. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın. 

Bu C# kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```c#
 // PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
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

Aspose yakın zamanda bir [free Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntüleri birleştirmeniz, fotoğraflardan ızgara oluşturmanız gerektiğinde, bu hizmeti kullanabilirsiniz. 
{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekle**

Büyük sunum boyutlarından kaçınmak için, dosyaları doğrudan sunuma gömmek yerine, bağlantılar aracılığıyla resim (veya video) ekleyebilirsiniz. Bu C# kodu, bir yer tutucuya resim ve video eklemeyi gösterir:

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

Bu C# kodu, bir slayd üzerindeki mevcut bir resmi nasıl kırpacağınızı gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    // Yeni bir görüntü nesnesi oluşturur
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Bir Slayta PictureFrame ekler
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

## **Resmin Kırpılmış Alanlarını Silme**

Bir çerçevede bulunan bir resmin kırpılmış alanlarını silmek istiyorsanız, [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksizse kırpılmış resmi ya da orijinal resmi döndürür.

Bu C# kodu işlemi gösterir:

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

[IPictureFillFormat.DeletePictureCroppedAreas] yöntemi, kırpılmış resmi sunumun resim koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame] içinde kullanılıyorsa, bu düzenleme sunum boyutunu azaltabilir. Aksi takdirde, ortaya çıkan sunumdaki görüntü sayısı artacaktır.

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafilelerini raster PNG görüntüsüne dönüştürür. 
{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/compressimage/) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutu ve belirtilen çözünürlüğe göre boyutunu azaltarak, kırpılmış alanları silme seçeneğiyle bir görüntüyü sıkıştırır.

Resmin boyutunu ve çözünürlüğünü PowerPoint'in **Picture Format → Compress Pictures → Resolution** özelliğine benzer şekilde ayarlar.

Aşağıdaki C# örnekleri, bir hedef çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki resmi nasıl sıkıştıracağınızı gösterir:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Görüntüyü 150 DPI hedef çözünürlük (Web çözünürlüğü) ile sıkıştırır ve kırpılmış alanları kaldırır.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Sıkıştırma sonucunu kontrol eder.
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

    // Görüntüyü 150 DPI (web çözünürlüğü) seviyesine sıkıştırır, kırpılmış alanları kaldırır.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Bu yöntem, şeklin boyutu ve verilen DPI temelinde görüntüyü daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler dosya boyutunu optimize etmek için silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe bağlı olarak, PowerPoint'in yüksek çözünürlüklü JPEG'leri işlemesine benzer şekilde korunur veya hafifçe azaltılır. 
{{% /alert %}}

## **En Boy Oranını Kilitleme**

Eğer içinde bir resim bulunan bir şeklin, resim boyutlarını değiştirdikten sonra bile en boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframelock/aspectratiolocked/) özelliğini kullanabilirsiniz. 

Bu C# kodu, bir şeklin en boy oranını nasıl kilitleyeceğinizi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Şekli yeniden boyutlandırırken en boy oranını korumasını ayarlar
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı, yalnızca şeklin en boy oranını korur, içindeki resmi değil. 
{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[StretchOffsetLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetright) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) özelliklerini [IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat) sınıfından kullanarak bir doldurma dikdörtgeni belirleyebilirsiniz. 

Bir görüntü için germe (stretch) belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınır kutusunun ilgili kenarından yüzde ofsetiyle tanımlanır. Pozitif yüzde içe doğru (inset) bir kaydırma, negatif yüzde dışa doğru (outset) bir kaydırma belirtir.

1. Bir [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının bir örneğini oluşturun. 
2. Bir slaydın referansını indeksine göre alın. 
3. Bir `AutoShape` dikdörtgen ekleyin. 
4. Bir resim oluşturun. 
5. Şeklin doldurma türünü ayarlayın. 
6. Şeklin resim doldurma modunu ayarlayın. 
7. Şekli doldurmak için bir resim ekleyin. 
8. Şeklin sınır kutusunun ilgili kenarından görüntü ofsetlerini belirtin. 
9. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın. 

Bu C# kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Şekil gövdesindeki görüntünün her taraftan gerilmesini ayarlar
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
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) nesnesine atanan görüntü nesnesi aracılığıyla hem raster görüntüleri (PNG, JPEG, BMP, GIF vb.) hem de vektör görüntüleri (örneğin SVG) destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.

**Yüzlerce büyük görüntü eklemek PPTX dosyasının boyutunu ve performansını nasıl etkiler?**  
Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlantı olarak eklemek sunum boyutunu düşük tutmaya yardımcı olur, ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı ile ekleme imkanı sağlar.

**Bir görüntü nesnesini yanlışlıkla hareket ettirilmekten/büyütülmekten nasıl kilitleyebilirim?**  
[shape locks](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/pictureframelock/) kullanın. Kilitleme mekanizması, şekiller için ayrı bir [protection article](/slides/tr/net/applying-protection-to-presentation/) içinde açıklanmıştır ve [PictureFrame] dahil çeşitli şekil tipleri için desteklenir.

**Sunumu PDF/görüntülere dışa aktarırken SVG vektör bütünlüğü korunur mu?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) içinden orijinal vektör olarak bir SVG çıkarmaya olanak tanır. [exporting to PDF](/slides/tr/net/convert-powerpoint-to-pdf/) veya [raster formats](/slides/tr/net/convert-powerpoint-to-png/) sırasında sonuç, dışa aktarma ayarlarına bağlı olarak rasterleştirilebilir; orijinal SVG'nin vektör olarak saklandığı, çıkarma davranışıyla doğrulanır.