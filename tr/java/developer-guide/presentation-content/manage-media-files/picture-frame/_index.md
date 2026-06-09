---
title: Java Kullanarak Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- görsel ekle
- görsel oluştur
- görsel çıkart
- raster görüntü
- vektör görüntü
- görsel kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreceli ölçek
- görsel efekti
- en boy oranı
- görsel şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı düzenleyin ve slayt tasarımlarını iyileştirin."
---
## **Introduction**

Resim çerçevesi, bir görüntüyü içeren bir şekildir—çerçeve içindeki bir resim gibidir.  

Bir resmi bir slayta resim çerçevesi aracılığıyla ekleyebilirsiniz. Bu sayede, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.  

{{% alert  title="Tip" color="primary" %}} 
Aspose, insanlara görüntülerden hızlıca sunumlar oluşturmayı sağlayan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlamaktadır.  
{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. [IPPImage]() nesnesini, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection) üzerine bir görüntü ekleyerek oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
4. Görüntünün genişlik ve yüksekliğini belirtin.  
5. Referans verilen slayt ile ilişkili şekil nesnesi tarafından sunulan `AddPictureFrame` yöntemiyle, görüntünün genişlik ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PictureFrame) oluşturun.  
6. Slayta (görseli içeren) bir resim çerçevesi ekleyin.  
7. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.  

Bu Java kodu, bir resim çerçevesi nasıl oluşturulur gösterir:  

```java
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfının bir örneğini oluşturur
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
Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlıca oluşturmanızı sağlar. Resim çerçevesini Aspose.Slides'ın kaydetme seçenekleriyle birleştirdiğinizde, görüntüleri bir formattan diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz. Aşağıdaki sayfalara bakabilirsiniz: [image to JPG](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/); [JPG to image](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/); [JPG to PNG](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/); [PNG to SVG](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/), [SVG to PNG](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/).  
{{% /alert %}} 

## **Göreceli Ölçekle Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Sunumun görüntü koleksiyonuna bir görüntü ekleyin.  
4. [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesini, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection) üzerine bir görüntü ekleyerek oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
5. Görüntünün resim çerçevesindeki göreceli genişlik ve yüksekliğini belirtin.  
6. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.  

Bu Java kodu, göreceli ölçekle bir resim çerçevesi nasıl oluşturulur gösterir:  

```java
// PPTX'i temsil eden Presentation sınıfını başlatır
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfının bir örneğini oluşturur
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Resmin eşdeğer yüksekliği ve genişliğiyle Resim Çerçevesi ekle
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Göreceli ölçek genişliği ve yüksekliğini ayarlama
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

Raster görüntüleri, [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PictureFrame) nesnelerinden çıkartabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü çıkartıp PNG formatında kaydetmeyi gösterir.  

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

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) şekilleri içinde SVG grafikleri içerdiğinde, Aspose.Slides for Java, orijinal vektör görüntülerini tam sadakatle almanıza olanak tanır. Slaytın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) nesnesini tanımlayabilir, altında bulunan [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) SVG içerip içermediğini kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske ya da bir akışa kaydedebilirsiniz.  

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü nasıl çıkarılır gösterir:  

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

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza izin verir. Bu Java kodu işlemi gösterir:  

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

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, resim çerçevesini belirli gereksinimlere uyacak şekilde değiştirebilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesini, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection) üzerine bir görüntü ekleyerek oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
4. Görüntünün genişlik ve yüksekliğini belirtin.  
5. Referans verilen slayt ile ilişkili [IShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [AddPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemiyle, görüntünün genişlik ve yüksekliğine dayalı bir `PictureFrame` oluşturun.  
6. Slayta (görseli içeren) bir resim çerçevesi ekleyin.  
7. Resim çerçevesinin çizgi rengini ayarlayın.  
8. Resim çerçevesinin çizgi kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif veya negatif bir değer vererek döndürün.  
   * Pozitif bir değer, görüntüyü saat yönünde döndürür.  
   * Negatif bir değer, görüntüyü saat yönünün tersine döndürür.  
10. Resim çerçevesini (görseli içeren) slayta ekleyin.  
11. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.  

Bu Java kodu, resim çerçevesi biçimlendirme sürecini gösterir:  

```java
// PPTX'i temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfının bir örneğini oluşturur
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Resmin eşdeğer yüksekliği ve genişliğiyle Resim Çerçevesi ekler
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
Aspose yakın zamanda bir [Ücretsiz Kollaj Oluşturucu](https://products.aspose.app/slides/tr/collage) geliştirdi. Eğer [JPG/JPEG](https://products.aspose.app/slides/tr/collage/jpg) veya PNG görüntüleri birleştirmeniz, [fotoğraflardan ızgaralar oluşturmanız](https://products.aspose.app/slides/tr/collage/photo-grid) gerekirse, bu hizmeti kullanabilirsiniz.  
{{% /alert %}}  

## **Bir Görüntüyü Bağlantı Olarak Ekle**

Büyük sunum boyutlarından kaçınmak için, dosyaları doğrudan sunuma gömmek yerine bağlantılar aracılığıyla görüntü (veya video) ekleyebilirsiniz. Bu Java kodu, bir yer tutucu içine bir görüntü ve video nasıl eklenir gösterir:  

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
// Yeni bir görüntü nesnesi oluşturur
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Bir Slayta PictureFrame ekler
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

## **Resim Çerçevesinin Kırpılmış Alanlarını Silme**

Bir çerçevede bulunan görüntünün kırpılmış alanlarını silmek istiyorsanız, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksizse kırpılmış görüntüyü veya orijinal görüntüyü döndürür.  

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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) içinde kullanılıyorsa, bu yapı sunum boyutunu azaltabilir. Aksi takdirde, sonuçta oluşan sunumdaki görüntü sayısı artar.  

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafilelarını raster PNG görüntüsüne dönüştürür.  
{{% /alert %}}  

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre boyutunu küçülterek, kırpılmış alanları silme seçeneğiyle bir resmi sıkıştırır.  

Resmin boyut ve çözünürlüğünü, PowerPoint'ın **Picture Format -> Compress Pictures -> Resolution** özelliğine benzer şekilde ayarlar.  

Aşağıdaki Java örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki resmi nasıl sıkıştıracağınızı gösterir:  

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlüğüyle sıkıştırır ve kırpılmış alanları kaldırır.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Sıkıştırma sonucunu kontrol eder.
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

    // Görüntüyü 150 DPI (web çözünürlüğü) sıkıştırır, kırpılmış alanları kaldırır.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```  

{{% alert title="NOTE" color="warning" %}} 
Yöntem, görüntüyü şeklin boyutuna ve belirtilen DPI'ye göre daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler, dosya boyutunu optimize etmek için silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe bağlı olarak korunur veya hafifçe düşürülür; bu, PowerPoint'in yüksek çözünürlüklü JPEG'leri nasıl işlediğine benzer.  
{{% /alert %}}  

## **En Boy Oranını Kilitleme**

Bir şeklin içinde bulunan görüntünün boyutlarını değiştirdiğinizde bile en boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* (En Boy Oranı Kilitle) ayarını ayarlamak için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) yöntemini kullanabilirsiniz.  

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

    // şeklin yeniden boyutlandırıldığında en boy oranını korumasını ayarla
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```  

{{% alert title="NOTE" color="warning" %}} 
Bu *Lock Aspect Ratio* (En Boy Oranı Kilitle) ayarı yalnızca şeklin en boy oranını korur, içinde bulunan görüntüyü değil.  
{{% /alert %}}  

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat) sınıfındaki [StretchOffsetLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) özelliklerini kullanarak bir doldurma dikdörtgeni belirleyebilirsiniz.  

Bir görüntü için streçleme belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun karşılık gelen kenarından bir yüzde ofsetiyle tanımlanır. Pozitif yüzde bir içeri çekme, negatif yüzde ise dışarı çıkma anlamına gelir.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. `AutoShape` dikdörtgeni ekleyin.  
4. Bir görüntü oluşturun.  
5. Şeklin doldurma tipini ayarlayın.  
6. Şeklin resim doldurma modunu ayarlayın.  
7. Şekli dolduracak bir görüntü ekleyin.  
8. Görüntünün, şeklin sınırlayıcı kutusunun karşılık gelen kenarına olan ofsetlerini belirtin.  
9. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.  

Bu Java kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:  

```java
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx sınıfının bir örneğini oluşturur
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

    // Görüntüyü şekli dolduracak şekilde ayarlar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarına göre ofsetlerini belirler
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

**PictureFrame için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) üzerine atanan görüntü nesnesi aracılığıyla hem raster görüntüleri (PNG, JPEG, BMP, GIF vb.) hem de vektör görüntüleri (örneğin SVG) destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.  

**Onlarca büyük görüntü eklemek PPTX dosya boyutu ve performansını nasıl etkiler?**  
Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlamak sunum boyutunu düşük tutmaya yardımcı olur ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı olarak ekleme imkanı sunar.  

**Bir görüntü nesnesini kazara hareket ettirilip yeniden boyutlandırılmasından nasıl koruyabilirim?**  
[PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) kullanın (örneğin, hareketi veya yeniden boyutlandırmayı devre dışı bırakın). Kilitleme mekanizması, şekiller için ayrı bir [koruma makalesinde](/slides/tr/java/applying-protection-to-presentation/) açıklanmıştır ve [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) dahil çeşitli şekil tipleri için desteklenir.  

**Bir sunumu PDF/görüntülere dışa aktarırken SVG vektör doğruluğu korunur mu?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) üzerinden SVG'yi orijinal vektör olarak çıkarmanıza olanak tanır. [PDF'ye dışa aktarırken](/slides/tr/java/convert-powerpoint-to-pdf/) veya [raster formatlara](/slides/tr/java/convert-powerpoint-to-png/) dönüştürürken, sonuç dışa aktarma ayarlarına bağlı olarak rasterleştirilebilir; orijinal SVG'nin bir vektör olarak depolandığı durum çıkartma davranışıyla doğrulanır.