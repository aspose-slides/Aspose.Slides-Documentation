---
title: Android'ta Sunumlarda Resim Çerçevelerini Yönetin
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
- göreli ölçek
- görüntü efekti
- en-boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarına Android için Aspose.Slides ile Java üzerinden resim çerçeveleri ekleyin. İş akışınızı sadeleştirin ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Resim çerçevesi, bir görüntüyü içeren bir şeklidir—çerçeve içinde bir resim gibidir.  

Bir slayta resmi bir resim çerçevesi aracılığıyla ekleyebilirsiniz. Böylece, resmi şekillendirmek yerine resim çerçevesini biçimlendirerek resmi biçimlendirebilirsiniz.  

{{% alert  title="İpucu" color="primary" %}} 

Aspose, ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlayarak kullanıcıların görüntülerden hızlıca sunumlar oluşturmasını sağlar. 

{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks aracılığıyla alın.  
3. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection) içine bir görüntü ekleyerek bir [IPPImage]() nesnesi oluşturun.  
4. Görüntünün genişliğini ve yüksekliğini belirtin.  
5. Referans verilen slayta bağlı şekil nesnesinin sunduğu `AddPictureFrame` yöntemiyle, görüntünün genişliği ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PictureFrame) oluşturun.  
6. Bir resim çerçevesini (görseli içeren) slayta ekleyin.  
7. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

```java
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfının bir örneğini oluşturur
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Görselin eşdeğer yüksekliği ve genişliğiyle bir resim çerçevesi ekler
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX dosyasını diske yazar
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Göreli Ölçekli Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks aracılığıyla alın.  
3. Sunumun görüntü koleksiyonuna bir görüntü ekleyin.  
4. Sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection) içine bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPPImage) nesnesi oluşturun.  
5. Resim çerçevesinde görüntünün göreli genişliğini ve yüksekliğini belirtin.  
6. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

```java
// PPTX'i temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfının bir örneğini oluşturur
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Görselin yüksekliği ve genişliğine eşdeğer bir Resim Çerçevesi ekler
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Göreli ölçek genişliği ve yüksekliğini ayarlar
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX dosyasını diske yazar
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Resim Çerçevelerinden Raster Görüntüleri Çıkarma**

Raster görüntüleri [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PictureFrame) nesnelerinden çıkarabilir ve PNG, JPG ve diğer biçimlerde kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü çıkarmayı ve PNG biçiminde kaydetmeyi gösterir.  

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

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) şekilleri içinde yer alan SVG grafikleri içerdiğinde, Java aracılığıyla Android için Aspose.Slides, özgün vektör görüntüleri tam doğrulukla almanızı sağlar. Slaydın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) nesnesini belirleyebilir, altındaki [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) SVG içeriği barındırıyor mu kontrol edebilir ve ardından bu görüntüyü yerel SVG biçiminde diske veya bir akışa kaydedebilirsiniz.  

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü çıkarmayı gösterir:  

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

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza olanak tanır. Bu Java kodu, işlemi gösterir:  

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

Aspose.Slides, bir resim çerçevesine uygulanabilen birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere uyacak şekilde değiştirebilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks aracılığıyla alın.  
3. Sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection) içine bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPPImage) nesnesi oluşturun.  
4. Görüntünün genişliğini ve yüksekliğini belirtin.  
5. Referans verilen slayta bağlı [IShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesinin sunduğu [AddPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemiyle, görüntünün genişliği ve yüksekliğine dayalı bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (görseli içeren) slayta ekleyin.  
7. Resim çerçevesinin çizgi rengini ayarlayın.  
8. Resim çerçevesinin çizgi kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif bir değer görüntüyü saat yönünde döndürür.  
   * Negatif bir değer görüntüyü saat yönünün tersine döndürür.  
10. Resim çerçevesini (görseli içeren) slayta ekleyin.  
11. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

```java
// PPTX'i temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfının bir örneğini oluşturur
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Görselin eşdeğer yüksekliği ve genişliğiyle bir Resim Çerçevesi ekler
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

{{% alert title="İpucu" color="primary" %}}

Aspose, yakın zamanda bir [ücretsiz Kolaj Oluşturucu](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntüleri birleştirmeniz, fotoğraflardan ızgara oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz.  

{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekleme**

Büyük sunum boyutlarından kaçınmak için, dosyaları doğrudan sunuma gömmek yerine bağlantılar aracılığıyla görüntü (veya video) ekleyebilirsiniz. Bu Java kodu, bir yer tutucu içine bir görüntü ve video eklemeyi gösterir:  

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

    // Bir Slide'a PictureFrame ekler
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

Bir çerçevede bulunan görüntünün kırpılmış alanlarını silmek istiyorsanız, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksizse kırpılmış görüntüyü ya da özgün görüntüyü döndürür.  

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

{{% alert title="NOT" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) içinde kullanılıyorsa, bu düzenleme sunum boyutunu azaltabilir. Aksi takdirde, ortaya çıkan sunumdaki görüntü sayısı artar.  

Bu yöntem, kırpma işleminde WMF/EMF metafile'larını raster PNG görüntüsüne dönüştürür. 

{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutu ve belirtilen çözünürlüğe göre görüntünün boyutunu küçülterek, kırpılmış alanları silme seçeneğiyle birlikte sıkıştırma yapar.  

Bu, PowerPoint'in **Resim Biçimi > Resimleri Sıkıştır > Çözünürlük** özelliğine benzer şekilde görüntünün boyut ve çözünürlüğünü ayarlar.  

Aşağıdaki Java örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntüyü nasıl sıkıştıracağınızı gösterir:  

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlükle sıkıştırır ve kırpılmış alanları kaldırır.
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

    // Görüntüyü 150 DPI (web çözünürlüğü) ile sıkıştırır ve kırpılmış alanları kaldırır.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOT" color="warning" %}} 

Yöntem, şeklin boyutu ve sağlanan DPI'ye göre görüntüyü daha düşük bir çözünürlüğe dönüştürür. Dosya boyutunu optimize etmek için kırpılmış bölgeler de silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe göre korunur ya da hafifçe azaltılır; bu, PowerPoint'in yüksek çözünürlüklü JPEG'leri işlemesine benzer.  

{{% /alert %}}

## **En-Boy Oranını Kilitleme**

Bir görüntü içeren şeklin, görüntü boyutları değiştirildiğinde bile en-boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) yöntemini kullanabilirsiniz.  

Bu Java kodu, bir şeklin en-boy oranını nasıl kilitleyeceğinizi gösterir:  

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

    // Şeklin yeniden boyutlandırırken en‑boy oranını korumasını ayarlar
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOT" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı sadece şeklin en-boy oranını korur; içinde bulunan görüntünün oranını korumaz.  

{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat) sınıfından [StretchOffsetLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) özelliklerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz.  

Bir görüntü için germe belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde olarak bir kaydırma ile tanımlanır. Pozitif yüzde içeriği, negatif yüzde dışarıyı belirtir.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks aracılığıyla alın.  
3. Bir `AutoShape` dikdörtgeni ekleyin.  
4. Bir görüntü oluşturun.  
5. Şeklin doldurma tipini ayarlayın.  
6. Şeklin resim doldurma modunu ayarlayın.  
7. Şekli dolduracak bir görüntü ekleyin.  
8. Görüntünün şeklin sınırlayıcı kutusunun ilgili kenarına göre kaydırmalarını belirtin.  
9. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Bu Java kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:  

```java
// PPTX dosyasını temsil eden Prseetation sınıfının bir örneğini oluşturur
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

    // Rectangle ayarlı bir AutoShape ekler
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Şeklin dolgu tipini ayarlar
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Şeklin resim dolgu modunu ayarlar
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Şekli dolduracak görüntüyü ayarlar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarına göre kaydırmalarını belirtir
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //PPTX dosyasını diske yazar
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) nesnesine atanan görüntü nesnesi aracılığıyla hem raster görüntüleri (PNG, JPEG, BMP, GIF vb.) hem de vektör görüntüleri (örneğin SVG) destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.  

**Onlarca büyük görüntü eklemek PPTX boyutu ve performansını nasıl etkiler?**  
Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlantı olarak eklemek sunum boyutunu düşük tutmaya yardımcı olur, ancak dış dosyaların erişilebilir kalmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı olarak ekleme imkanı sağlar.  

**Bir görüntü nesnesini yanlışlıkla taşınması/yeniden boyutlandırılmasından nasıl kilitleyebilirim?**  
Bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) kullanılabilir (örneğin, hareketi veya yeniden boyutlandırmayı devre dışı bırakma). Kilitleme mekanizması, [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) dahil çeşitli şekil tipleri için desteklenir.  

**Bir sunumu PDF/görüntülere dışa aktarırken SVG vektör doğruluğu korunur mu?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) içindeki SVG'yi özgün vektör olarak çıkarmanıza izin verir. [PDF'ye dışa aktarırken](/slides/tr/androidjava/convert-powerpoint-to-pdf/) veya [raster formatlarına](/slides/tr/androidjava/convert-powerpoint-to-png/) çıktıyı alırken, dışa aktarma ayarlarına bağlı olarak sonuç rasterleştirilebilir; ancak çıkarma davranışı, orijinal SVG'nin vektör olarak saklandığını doğrular.