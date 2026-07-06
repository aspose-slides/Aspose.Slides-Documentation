---
title: Sunumlarda Java Kullanarak Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- görüntü ekle
- görüntü oluştur
- görüntüyü çıkar
- raster görüntü
- vektör görüntü
- görüntüyü kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreli ölçek
- görüntü efekti
- en boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı kolaylaştırın ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Resim çerçevesi, bir görüntüyü içeren bir şekildir — çerçevede bir resim gibidir.  

Bir resmi bir slayta resim çerçevesi aracılığıyla ekleyebilirsiniz. Bu şekilde, resmi, resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.  

{{% alert  title="Tip" color="primary" %}} 

Aspose, ücretsiz dönüştürücüler—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlayarak, insanların görsellerden hızlı bir şekilde sunumlar oluşturmasını sağlar.  

{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Presentation sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Shape nesnesinin sunduğu `AddPictureFrame` yöntemiyle, resmi doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection)'a bir resim ekleyerek bir [IPPImage]() nesnesi oluşturun.  
4. Resmin genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı şekil nesnesinin sunduğu `AddPictureFrame` yöntemiyle, resmin genişliği ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PictureFrame) oluşturun.  
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu Java kodu, bir resim çerçevesi nasıl oluşturulacağını gösterir:  

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyerek oluşturur
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

{{% alert color="warning" %}} 

Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlı bir şekilde oluşturmanıza olanak tanır. Resim çerçevesini Aspose.Slides kaydetme seçenekleriyle birleştirdiğinizde, görüntüleri bir formattan diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz. Aşağıdaki sayfalara göz atmak isteyebilirsiniz: [görüntüyü JPG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/); [JPG'yi görüntüye dönüştür](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/); [JPG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/), [PNG'yi JPG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/); [PNG'yi SVG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/), [SVG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/).  

{{% /alert %}}

## **Göreli Ölçekli Resim Çerçevesi Oluşturma**

Bir resmin göreli ölçeklendirmesini değiştirerek, daha karmaşık bir resim çerçevesi oluşturabilirsiniz.  

1. Presentation sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Sunumun resim koleksiyonuna bir resim ekleyin.  
4. Shape nesnesinin sunduğu `AddPictureFrame` yöntemiyle, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection)'a bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesi oluşturun.  
5. Resmin göreli genişliğini ve yüksekliğini resim çerçevesinde belirtin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu Java kodu, göreli ölçekli bir resim çerçevesi nasıl oluşturulacağını gösterir:  

```java
// PPTX'i temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnekle
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Resmin eşdeğer yüksekliği ve genişliğiyle Resim Çerçevesi ekle
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Göreli ölçek genişliği ve yüksekliğini ayarlama
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

Raster görüntüleri, [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PictureFrame) nesnelerinden çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü nasıl çıkarıp PNG formatında kaydedeceğinizi gösterir.  

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

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) şekilleri içinde SVG grafikleri içerdiğinde, Aspose.Slides for Java, özgün vektör görüntülerini tam doğrulukla almanıza izin verir. Slaydın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) öğesini belirleyebilir, altında yatan [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesinin SVG içeriği taşıyıp taşımadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske ya da akışa kaydedebilirsiniz.  

Aşağıdaki kod örneği bir resim çerçevesinden SVG görüntüsünün nasıl çıkarılacağını gösterir:  

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

## **Bir Görüntünün Şeffaflığını Alma**

Aspose.Slides, bir görüntüye uygulanan şeffaflık efektini almanıza olanak tanır. Bu Java kodu işlemi gösterir:  

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

## **Bir Görüntünün Parlaklık ve Kontrastını Alma**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast efektini almanıza olanak tanır. [ILuminance](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iluminance/) arayüzü bu görüntü dönüşüm etkisini temsil eder.  

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

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere uygun şekilde değiştirebilirsiniz.  

1. Presentation sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Shape nesnesinin sunduğu `AddPictureFrame` yöntemiyle, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection)'a bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesi oluşturun.  
4. Resmin genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı [IShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesinin sunduğu [AddPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemiyle, resmin genişliği ve yüksekliğine dayalı bir `PictureFrame` oluşturun.  
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin.  
7. Resim çerçevesinin kenar rengini ayarlayın.  
8. Resim çerçevesinin kenar kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif bir değer resmi saat yönünde döndürür.  
   * Negatif bir değer resmi saat yönünün tersine döndürür.  
10. Resim çerçevesini (resmi içeren) slayta tekrar ekleyin.  
11. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu Java kodu, resim çerçevesi biçimlendirme sürecini gösterir:  

```java
// PPTX'i temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnekler
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Resmin eşdeğer yüksekliği ve genişliğiyle bir Resim Çerçevesi ekler
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

Aspose, yakın zamanda ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görselleri birleştirmeniz ya da fotoğraflardan ızgara oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz.  

{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekleme**

Büyük sunum boyutlarından kaçınmak için, dosyaları doğrudan sunuma eklemek yerine bağlantılar aracılığıyla resim (veya video) ekleyebilirsiniz. Bu Java kodu, bir görüntü ve videoyu yer tutucuya nasıl ekleyeceğinizi gösterir:  

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

## **Görüntüleri Kırpma**

Bu Java kodu, bir slayttaki mevcut bir görüntüyü nasıl kırpacağınızı gösterir:  

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

Bir çerçevede bulunan bir görüntünün kırpılmış alanlarını silmek istiyorsanız, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metodunu kullanabilirsiniz. Bu yöntem, kırpma gereksizse kırpılmış görüntüyü ya da orijinal görüntüyü döndürür.  

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

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) içinde kullanılıyorsa, bu ayar sunum boyutunu azaltabilir. Aksi takdirde, ortaya çıkan sunumdaki görüntü sayısı artar.  

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafile'lerini raster PNG görüntüsüne dönüştürür.  

{{% /alert %}}

## **Görüntüleri Sıkıştırma**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) metodunu kullanarak bir sunumdaki resmi sıkıştırabilirsiniz. Bu yöntem, şekil boyutu ve belirtilen çözünürlüğe göre resmi küçülterek sıkıştırır; ayrıca kırpılmış alanları silme seçeneği de sunar.  

Resmin boyut ve çözünürlüğünü PowerPoint'in **Picture Format -> Compress Pictures -> Resolution** özelliğine benzer şekilde ayarlar.  

Aşağıdaki Java örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki resmi nasıl sıkıştıracağınızı gösterir:  

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlük ile sıkıştır ve kırpılmış alanları kaldır.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Sıkıştırmanın sonucunu kontrol et.
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

    // Görüntüyü 150 DPI'ye (web çözünürlüğü) sıkıştır, kırpılmış alanları kaldır.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metod, şeklin boyutu ve sağlanan DPI temelinde görüntüyü daha düşük bir çözünürlüğe dönüştürür. Dosya boyutunu iyileştirmek için kırpılmış bölgeler de silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe göre korunur ya da hafifçe düşer; bu, PowerPoint'in yüksek çözünürlüklü JPEG'leri nasıl işlediğine benzer.  

{{% /alert %}}

## **En Boy Oranını Kilitleme**

Bir şeklin, içinde bir görüntü bulunsa da, görüntü boyutlarını değiştirdiğinizde en boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) metodunu kullanabilirsiniz.  

Bu Java kodu, bir şeklin en boy oranını nasıl kilitleyeceğinizi gösterir:  

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

    // şeklin yeniden boyutlandırıldığında en boy oranını korumasını sağla
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en boy oranını korur, içinde bulunan görüntüyü değil.  

{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[StretchOffsetLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) özelliklerini [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat) arayüzünden ve [PictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat) sınıfından kullanarak bir doldurma dikdörtgeni belirleyebilirsiniz.  

Bir görüntü için stretching tanımlandığında, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarına yüzde olarak bir kayma ile tanımlanır. Pozitif yüzde bir iç boşluk, negatif yüzde ise dışarı doğru bir genişleme belirtir.  

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Bir `AutoShape` dikdörtgen ekleyin.  
4. Bir resim oluşturun.  
5. Şeklin doldurma tipini ayarlayın.  
6. Şeklin resim doldurma modunu ayarlayın.  
7. Şekli doldurmak için bir resim ekleyin.  
8. Resim kaymalarını, şeklin sınırlayıcı kutusunun ilgili kenarına göre belirtin.  
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

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

    // Şeklin dolgu tipini ayarlar
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Şeklin resim dolgu modunu ayarlar
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Şekli dolduracak resmi ayarlar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Şeklin sınırlayıcı kutusunun ilgili kenarından görüntü kaymalarını belirtir
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // PPTX dosyasını diske yazar
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**  

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) nesnesine atanan görüntü nesnesi aracılığıyla raster görüntüler (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüler (örneğin SVG) desteği sağlar. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.  

**Yüzlerce büyük görüntü eklemek PPTX dosya boyutu ve performansını nasıl etkiler?**  

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntülere bağlantı vermek sunum boyutunu düşürür, ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı yoluyla ekleme imkanı sunar.  

**Bir görüntü nesnesinin yanlışlıkla taşınmasını/yeniden boyutlandırılmasını nasıl kilitleyebilirim?**  

[shape locks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) kullanarak bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) için (örneğin hareketi veya yeniden boyutlandırmayı devre dışı bırakmak) kilitleme yapabilirsiniz. Kilitleme mekanizması, ayrı bir [koruma makalesinde](/slides/tr/java/applying-protection-to-presentation/) şekiller için açıklanmıştır ve [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) dahil çeşitli şekil tipleri için desteklenir.  

**Bir sunumu PDF/görüntülere dışa aktarırken SVG vektör tutarlılığı korunur mu?**  

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) içinden SVG'yi orijinal vektör olarak çıkarabilir. PDF'ye veya raster formatlara ([PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [PNG](/slides/tr/java/convert-powerpoint-to-png/)) dışa aktarırken, sonuç dışa aktarma ayarlarına bağlı olarak rasterleştirilebilir; ancak çıkarma davranışı, orijinal SVG'nin vektör olarak saklandığını doğrular.