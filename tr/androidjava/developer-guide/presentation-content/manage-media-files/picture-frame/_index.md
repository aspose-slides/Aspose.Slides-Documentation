---
title: Android'de Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/androidjava/picture-frame/
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
- en‑boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı basitleştirin ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Resim çerçevesi, bir görüntüyü içeren bir şekildir—tıpkı çerçevedeki bir resim gibi.

Bir slayta resim çerçevesi aracılığıyla bir görüntü ekleyebilirsiniz. Böylece, resim çerçevesini biçimlendirerek görüntüyü de biçimlendirmiş olursunuz.

{{% alert  title="Tip" color="primary" %}} 
Aspose ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar; bu sayede kullanıcılar görüntülerden hızlıca sunumlar oluşturabilir. 
{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını dizini aracılığıyla alın.  
3. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection)‘a bir görüntü ekleyerek bir [IPPImage]() nesnesi oluşturun.  
4. Görüntünün genişlik ve yüksekliğini belirtin.  
5. Referans alınan slayda bağlı şekil nesnesinin sunduğu `AddPictureFrame` yöntemiyle görüntünün genişlik ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PictureFrame) oluşturun.  
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin.  
7. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Bu Java kodu, bir resim çerçevesi nasıl oluşturulacağını gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnekler
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Resmin eşdeğer yüksekliği ve genişliğiyle bir resim çerçevesi ekler
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX dosyasını diske yazar
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Göreceli Ölçekli Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını dizini aracılığıyla alın.  
3. Sunumun görüntü koleksiyonuna bir görüntü ekleyin.  
4. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection)‘a bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPPImage) nesnesi oluşturun.  
5. Resim çerçevesinde görüntünün göreceli genişlik ve yüksekliğini belirtin.  
6. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Bu Java kodu, göreceli ölçekle bir resim çerçevesi nasıl oluşturulacağını gösterir:

```java
// PPTX'i temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnekle
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Resmin yüksekliği ve genişliğiyle eşdeğer bir Resim Çerçevesi ekle
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Göreceli ölçek genişliğini ve yüksekliğini ayarla
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX dosyasını diske yaz
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Resim Çerçevelerinden Raster Görüntüleri Çıkarma**

[PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PictureFrame) nesnelerinden raster görüntüleri çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, “sample.pptx” belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi gösterir.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Resim Çerçevelerinden SVG Görüntüleri Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) şekilleri içinde yer alan SVG grafikler içerdiğinde, Aspose.Slides for Android via Java, orijinal vektör görüntülerini tam doğrulukla almanıza olanak tanır. Slaydın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) nesnesini tanımlayabilir, altındaki [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/)‘in SVG içerip içermediğini kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske veya akıma kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü nasıl çıkarılacağını gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Bir Görüntünün Şeffaflığını Almak**

Aspose.Slides, bir görüntüye uygulanan şeffaflık efektini almanıza izin verir. Bu Java kodu işlemi gösterir:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Bir Görüntünün Parlaklık ve Kontrastını Almak**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast efektini almanıza izin verir. [ILuminance](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iluminance/) arabirimi bu görüntü dönüşüm efektini temsil eder.

Bu Java kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını nasıl alacağınızı gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilen birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere uygun hale getirebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını dizini aracılığıyla alın.  
3. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection)‘a bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPPImage) nesnesi oluşturun.  
4. Görüntünün genişlik ve yüksekliğini belirtin.  
5. Referans alınan slayda bağlı [IShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesinin sunduğu [AddPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemiyle görüntünün genişlik ve yüksekliğine dayalı bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (resmi içeren) slayta ekleyin.  
7. Resim çerçevesinin kenar rengini ayarlayın.  
8. Resim çerçevesinin kenar kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif bir değer görüntüyü saat yönünde döndürür.  
   * Negatif bir değer görüntüyü saat yönünün tersine döndürür.  
10. Resim çerçevesini (resmi içeren) slayta ekleyin.  
11. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Bu Java kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```java
// PPTX'i temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnekler
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Resmin yüksekliği ve genişliğiyle eşdeğer bir Resim Çerçevesi ekler
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx'e bazı biçimlendirmeler uygular
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // PPTX dosyasını diske yazar
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose yakın zamanda bir [free Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntülerini birleştirmeniz, fotoğraflardan ızgara oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz. 
{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekle**

Sunum dosyalarının boyutunu büyük tutmamak için, dosyaları doğrudan gömmek yerine bağlantılar aracılığıyla resim (veya video) ekleyebilirsiniz. Bu Java kodu, bir yer tutucuya nasıl görüntü ve video ekleneceğini gösterir:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Görüntüleri Kesme**

Bu Java kodu, bir slayttaki mevcut bir görüntünün nasıl kırpılacağını gösterir:

```java
Presentation pres = new Presentation();
// Yeni görüntü nesnesi oluşturur
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Bir slayta PictureFrame ekler
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Görüntüyü kırpar (yüzde değerleri)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Sonucu kaydeder
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Resmin Kırpılmış Alanlarını Silme**

Bir çerçevede bulunan görüntünün kırpılmış alanlarını silmek istiyorsanız, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksizse orijinal görüntüyü, aksi takdirde kırpılmış görüntüyü döndürür.

Bu Java kodu işlemi gösterir:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // İlk slayttan PictureFrame'i alır
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame görüntüsünün kırpılmış alanlarını siler ve kırpılmış görüntüyü döndürür
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Sonucu kaydeder
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemi kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) içinde kullanılıyorsa, bu yapılandırma sunum boyutunu azaltabilir. Aksi takdirde, ortaya çıkan sunumdaki görüntü sayısı artar.  
Bu yöntem, kırpma işlemi sırasında WMF/EMF metafile’larını raster PNG görüntüsüne dönüştürür. 
{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre görüntünün boyutunu azaltarak, isteğe bağlı olarak kırpılmış alanları silme seçeneği sunar.

Resmin boyut ve çözünürlüğünü, PowerPoint’ın **Picture Format > Compress Pictures > Resolution** özelliğine benzer şekilde ayarlar.

Aşağıdaki Java örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntünün nasıl sıkıştırılacağını gösterir:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlükte sıkıştır ve kırpılmış alanları kaldır.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Sıkıştırma sonucunu kontrol et.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Veya doğrudan özel bir DPI değeri kullanarak:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Görüntüyü 150 DPI (web çözünürlüğü) sıkıştır, kırpılmış alanları kaldır.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Yöntem, görüntüyü şeklin boyutuna ve verilen DPI değerine göre daha düşük bir çözünürlüğe dönüştürür. Dosya boyutunu optimize etmek için kırpılmış bölgeler de silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe göre korunur ya da hafifçe düşürülür; bu, PowerPoint’ın yüksek çözünürlüklü JPEG’leri nasıl işlediğine benzer. 
{{% /alert %}}

## **En-Boy Oranını Kilitlemek**

Bir şekil içinde bulunan görüntünün, görüntü boyutları değiştirildiğinde bile en-boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını yapmak için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) yöntemini kullanabilirsiniz.

Bu Java kodu, bir şeklin en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // Şeklin yeniden boyutlandırıldığında en-boy oranını korumasını ayarla
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en‑boy oranını korur, içinde bulunan görüntüyü değil. 
{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat) sınıfından [StretchOffsetLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) özelliklerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz.

Bir görüntü için germe (stretch) belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde olarak bir ofsetle tanımlanır. Pozitif yüzde bir içeriği, negatif yüzde bir dışarıyı gösterir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını dizini aracılığıyla alın.  
3. Bir `AutoShape` dikdörtgen ekleyin.  
4. Bir görüntü oluşturun.  
5. Şeklin dolgu tipini ayarlayın.  
6. Şeklin resim dolgu modunu ayarlayın.  
7. Şekli dolduracak bir görüntü ekleyin.  
8. Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarından ofsetlerini belirtin.  
9. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Bu Java kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx sınıfını örnekler
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Rectangle olarak ayarlanmış bir AutoShape ekler
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Şeklin doldurma tipini ayarlar
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Şeklin resim doldurma modunu ayarlar
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Şekli dolduracak resmi ayarlar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarından ofsetlerini belirtir
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Writes PPTX dosyasını diske yazar
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Resim çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/)‘e atanan görüntü nesnesi aracılığıyla raster görüntüler (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüler (ör. SVG) destekler. Desteklenen format listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.

**Yüzlerce büyük görüntü eklemek PPTX dosya boyutu ve performansını nasıl etkiler?**  
Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntülere bağlantı vermek sunum boyutunu düşük tutar ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı olarak ekleme imkanı sunar.

**Bir görüntü nesnesinin yanlışlıkla taşınmasını/yeniden boyutlandırılmasını nasıl kilitleyebilirim?**  
[shape locks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) kullanarak bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/)‘i (ör. hareket ettirmeyi veya yeniden boyutlandırmayı devre dışı bırakma) kilitleyebilirsiniz. Kilitleme mekanizması, [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) dahil birçok şekil türü için desteklenir.

**SVG vektör doğruluğu PDF/görüntülere dışa aktarırken korunuyor mu?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/)‘den SVG’yi orijinal vektör olarak çıkarabilir. [PDF’ye dışa aktarma](/slides/tr/androidjava/convert-powerpoint-to-pdf/) veya [raster formatlarına](/slides/tr/androidjava/convert-powerpoint-to-png/) dönüştürülürken, sonuç dışa aktarım ayarlarına bağlı olarak rasterleştirilebilir; ancak orijinal SVG’nin vektör olarak saklandığı çıkarma davranışıyla doğrulanır.