---
title: Java kullanarak Sunumlarda Resim Çerçevelerini Yönetme
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
- göreceli ölçek
- görüntü efekti
- en-boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı kolaylaştırın ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Resim çerçevesi, bir resmi içeren bir şekildir; çerçeve içinde bir resim gibidir.

Bir resmi bir slayta resim çerçevesi aracılığıyla ekleyebilirsiniz. Böylece, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="info" %}} 
Aspose ücretsiz dönüştürücüler sunar—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—ki bunlar, insanların görüntülerden hızlı bir şekilde sunumlar oluşturmasını sağlar.
{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection) üzerine bir resim ekleyerek bir [IPPImage]() nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacak.  
4. Resmin genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı şekil nesnesi tarafından sunulan `AddPictureFrame` yöntemiyle, resmin genişliği ve yüksekliğine dayanarak bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PictureFrame) oluşturun.  
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu Java kodu, bir resim çerçevesi nasıl oluşturulacağını gösterir:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

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

{{% alert color="warning" %}} 
Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlı bir şekilde oluşturmanıza olanak tanır. Resim çerçevesini Aspose.Slides'ın kaydetme seçenekleriyle birleştirdiğinizde, görüntüleri bir formattan başka bir formata dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz. Aşağıdaki sayfalara göz atmak isteyebilirsiniz: dönüştür [görüntüyü JPG'ye](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/); dönüştür [JPG'yi görüntüye](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/); dönüştür [JPG'yi PNG'ye](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/), dönüştür [PNG'yi JPG'ye](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/); dönüştür [PNG'yi SVG'ye](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/), dönüştür [SVG'yi PNG'ye](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/).
{{% /alert %}}

## **Göreceli Ölçekli Resim Çerçevesi Oluşturma**

Bir görüntünün göreceli ölçeklemesini değiştirerek, daha karmaşık bir resim çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Sunumun görüntü koleksiyonuna bir resim ekleyin.  
4. Sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection) üzerine bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesi oluşturun.  
5. Resmin göreceli genişliğini ve yüksekliğini resim çerçevesinde belirtin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu Java kodu, göreceli ölçekli bir resim çerçevesi nasıl oluşturulacağını gösterir:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX'yi temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnekle
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Resmin yüksekliği ve genişliğiyle eşdeğer bir Resim Çerçevesi ekle
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Göreceli ölçek genişliği ve yüksekliğini ayarla
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

[IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PictureFrame) nesnelerinden raster görüntüler çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, “sample.pptx” belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;

        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Resim Çerçevelerinden SVG Görüntüleri Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) şekilleri içinde SVG grafikleri içerdiğinde, Aspose.Slides for Java, orijinal vektör görüntülerini tam bütünlükte almanıza imkan tanır. Slaydın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) tanımlayabilir, temel [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesinin SVG içeriği taşıyıp taşımadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske veya akışa kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü çıkarmayı gösterir:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        // getSvgImage, resim raster bir görüntü olduğunda null döndürür.
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
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
import com.aspose.slides.*;

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

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast etkisini almanıza izin verir. [ILuminance](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iluminance/) arayüzü bu görüntü dönüşüm etkisini temsil eder.

Bu Java kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını almayı gösterir:

```java
import com.aspose.slides.*;

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

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, belirli gereksinimlere uyması için bir resim çerçevesini değiştirebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection) üzerine bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesi oluşturun.  
4. Resmin genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı [IShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [AddPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemiyle, resmin genişliği ve yüksekliğine dayanarak bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (resmi içeren) slayta ekleyin.  
7. Resim çerçevesinin kenar renk ayarını yapın.  
8. Resim çerçevesinin kenar kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif veya negatif bir değer vererek döndürün.  
   * Pozitif değer resmi saat yönünde döndürür.  
   * Negatif değer resmi saat yönünün tersine döndürür.  
10. Resim çerçevesini (resmi içeren) slayta tekrar ekleyin.  
11. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu Java kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

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

{{% alert title="Tip" color="info" %}}
Aspose yakın zamanda [ücretsiz Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. Eğer bir zaman [JPG/JPEG birleştirmeniz](https://products.aspose.app/slides/tr/collage/jpg) veya PNG görüntüleri, [fotoğraflardan ızgaralar oluşturmanız](https://products.aspose.app/slides/tr/collage/photo-grid) gerekirse, bu hizmeti kullanabilirsiniz.
{{% /alert %}}

## **Görseli Bağlantı Olarak Ekleme**

Büyük sunum boyutlarından kaçınmak için, dosyaları doğrudan sunuma gömmek yerine bağlantılar aracılığıyla resim (veya video) ekleyebilirsiniz. Bu Java kodu, bir yer tutucuya resim ve video eklemeyi gösterir:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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

Bu Java kodu, bir slayttaki mevcut bir resmi nasıl kırpacağınızı gösterir:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

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

    //    Bir slayta PictureFrame ekler
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    //    Görüntüyü kırpar (yüzde değerleri)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    //    Sonucu kaydeder
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Resmin Kırpılmış Alanlarını Silme**

Bir çerçeve içinde bulunan resmin kırpılmış alanlarını silmek istiyorsanız, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemini kullanabilirsiniz. Bu yöntem, kırpılmış görüntüyü veya kırpma gereksizse orijinal görüntüyü döndürür.

Bu Java kodu işlemi gösterir:

```java
import com.aspose.slides.*;

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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) içinde kullanılıyorsa, bu yapı sunum boyutunu azaltabilir. Aksi takdirde, ortaya çıkan sunumdaki görüntü sayısı artar.

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafile'larını raster PNG görüntüsüne dönüştürür. 
{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre resmi boyutunu azaltır; ayrıca kırpılmış alanları silme seçeneği sunar.

PowerPoint'in **Picture Format -> Compress Pictures -> Resolution** özelliğine benzer şekilde resmin boyut ve çözünürlüğünü ayarlar.

Aşağıdaki Java örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki resmi nasıl sıkıştıracağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Görüntüyü hedef çözünürlük 150 DPI (Web çözünürlüğü) ile sıkıştır ve kırpılmış alanları kaldır.
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
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    //    Görüntüyü 150 DPI (web çözünürlüğü) olarak sıkıştır, kırpılmış alanları kaldır.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Yöntem, şeklin boyutuna ve sağlanan DPI'ye göre görüntüyü daha düşük bir çözünürlüğe dönüştürür. Dosya boyutunu optimize etmek için kırpılmış bölgeler de silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. JPEG kalitesi ise çözünürlüğe bağlı olarak korunur veya hafifçe düşürülür; bu, PowerPoint'in yüksek çözünürlüklü JPEG'leri işlemesiyle aynıdır. 
{{% /alert %}}

## **En-Boy Oranını Kilitleme**

Bir şeklin içinde bir görüntü barındırıyorsa ve görüntü boyutları değiştirilse bile şeklin en-boy oranını korumak istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) yöntemini kullanabilirsiniz. 

Bu Java kodu, bir şeklin en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // yeniden boyutlandırırken en-boy oranını koruması için şekli ayarla
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en‑boy oranını korur; içinde barındırdığı görüntünün oranını korumaz. 
{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat) arayüzünden ve [PictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat) sınıfından [StretchOffsetLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) özelliklerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz. 

Bir görüntü için germe belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her bir kenarı, şeklin sınırlayıcı kutusunun ilgili kenarına yüzde olarak bir sapma ile tanımlanır. Pozitif yüzde bir içeriği, negatif yüzde bir dışarıyı belirtir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Bir `AutoShape` dikdörtgeni ekleyin.  
4. Bir resim oluşturun.  
5. Şeklin doldurma tipini ayarlayın.  
6. Şeklin resim doldurma modunu ayarlayın.  
7. Şekli doldurmak için bir resim ayarlayın.  
8. Şeklin sınırlayıcı kutusunun ilgili kenarına göre görüntü sapmalarını belirleyin.  
9. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu Java kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```java
import com.aspose.slides.*;

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
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

    // Rectangle ayarlı bir AutoShape ekler
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Şeklin doldurma tipini ayarlar
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Şeklin resim doldurma modunu ayarlar
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Şekli doldurmak için görseli ayarlar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Görselin şeklin sınırlayıcı kutusunun ilgili kenarına göre sapmalarını belirtir
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //Writes the PPTX file to disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

### Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?

Aspose.Slides, hem raster (PNG, JPEG, BMP, GIF vb.) hem de vektör (örneğin SVG) görüntüleri, bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) nesnesine atanan görüntü nesnesi aracılığıyla destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.

### Çok sayıda büyük görüntü eklemek PPTX boyutunu ve performansını nasıl etkiler?

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntülere bağlantı vermek sunum boyutunu düşük tutar ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı olarak ekleme imkanı sunar.

### Bir görüntü nesnesini yanlışlıkla taşınması/yeniden boyutlandırılması durumuna karşı nasıl kilitleyebilirim?

Bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) kullanarak (örneğin taşıma veya yeniden boyutlandırmayı devre dışı bırakma) nesneyi kilitleyebilirsiniz. Kilitleme mekanizması, çeşitli şekil tipleri için ayrı bir [koruma makalesi](/slides/tr/java/applying-protection-to-presentation/) içinde açıklanmıştır ve [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) için de desteklenir.

### SVG vektör bütünlüğü bir sunum PDF/görüntülere dışa aktarılırken korunur mu?

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) içindeki SVG'yi orijinal vektör olarak çıkarabilir. PDF'ye [/slides/tr/java/convert-powerpoint-to-pdf/] veya raster formatlara [/slides/tr/java/convert-powerpoint-to-png/] dışa aktarırken, sonuç dışa aktarma ayarlarına bağlı olarak rasterleştirilebilir; orijinal SVG'nin vektör olarak saklandığı çıkarma davranışıyla doğrulanır.