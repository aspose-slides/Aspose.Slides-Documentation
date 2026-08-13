---
title: Android'de Sunumlarda Resim Çerçevelerini Yönet
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
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı basitleştirin ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Bir resim çerçevesi, bir görüntüyü içeren bir şekildir—çerçevede bir resim gibi.

Bir resim çerçevesi aracılığıyla bir slayta görüntü ekleyebilirsiniz. Böylece, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="info" %}} 

Aspose, görüntülerden hızlı bir şekilde sunumlar oluşturmanıza izin veren ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 

{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection)‘e bir görüntü ekleyerek bir [IPPImage]() nesnesi oluşturun.  
4. Görüntünün genişlik ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı şekil nesnesinin sunduğu `AddPictureFrame` yöntemiyle, görüntünün genişlik ve yüksekliğine dayanarak bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PictureFrame) oluşturun.  
6. Slayta bir resim çerçevesi (içinde resim barındıran) ekleyin.  
7. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX dosyasını temsil eden Presentation sınıfını örnek oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnek oluşturur
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

## **Göreli Ölçekli Resim Çerçevesi Oluşturma**

Bir görüntünün göreli ölçeklemesini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Sunum görüntü koleksiyonuna bir görüntü ekleyin.  
4. Sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection)‘e bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPPImage) nesnesi oluşturun.  
5. Resim çerçevesindeki görüntünün göreli genişlik ve yüksekliğini belirtin.  
6. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX'yi temsil eden Presentation sınıfını örnek oluştur
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnek oluştur
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Resmin yüksekliği ve genişliğiyle eşdeğer bir Resim Çerçevesi ekle
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Göreli ölçek genişliği ve yüksekliğini ayarla
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX dosyasını diske yaz
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Resim Çerçevelerinden Raster Görüntüler Çıkarma**

Raster görüntüleri [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PictureFrame) nesnelerinden çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü nasıl çıkarıp PNG formatında kaydedeceğinizi gösterir.

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

## **Resim Çerçevelerinden SVG Görüntüler Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) şekilleri içinde yer alan SVG grafikleri içerdiğinde, Java üzerinden Android için Aspose.Slides, orijinal vektör görüntülerini tam doğrulukla almanızı sağlar. SVG içeriğine sahip bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) ve içinde [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) bulunan bir nesne elde ettiğinizde, o SVG görüntüyü okuyabilir ve yerel SVG formatında diske veya bir akışa kaydedebilirsiniz.

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

## **Bir Görüntünün Parlaklık ve Kontrastını Alma**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast efektini almanıza izin verir. [ILuminance](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iluminance/) arayüzü bu görüntü dönüşüm etkisini temsil eder.  

Bu Java kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını nasıl alacağınızı gösterir:

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

Aspose.Slides, bir resim çerçevesine uygulanabilen birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, belirli gereksinimlere uyması için bir resim çerçevesini değiştirebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection)‘e bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPPImage) nesnesi oluşturun.  
4. Görüntünün genişlik ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı [IShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesinin sunduğu [AddPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemiyle, görüntünün genişlik ve yüksekliğine dayanarak bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (içinde resim barındıran) slayta ekleyin.  
7. Resim çerçevesinin çizgi rengini ayarlayın.  
8. Resim çerçevesinin çizgi kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif değer resmi saat yönünde döndürür.  
   * Negatif değer resmi saat yönünün tersine döndürür.  
10. Resim çerçevesini (içinde resim barındıran) slayta ekleyin.  
11. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX'i temsil eden Presentation sınıfını örnek oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image sınıfını örnek oluşturur
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

{{% alert title="Tip" color="info" %}}

Aspose yakın zamanda bir [free Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntüleri [merge JPG/JPEG](https://products.aspose.app/slides/tr/collage/jpg) ya da fotoğraflardan ızgara oluşturmak [create grids from photos](https://products.aspose.app/slides/tr/collage/photo-grid) gerektiğinde bu hizmeti kullanabilirsiniz. 

{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekleme**

Sunum boyutunun büyük olmasını önlemek için, dosyaları doğrudan gömmek yerine bağlantılar aracılığıyla görüntü (veya video) ekleyebilirsiniz. Bu Java kodu, bir yer tutucuya görüntü ve video nasıl ekleyeceğinizi gösterir:

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

Bu Java kodu, bir slayttaki mevcut bir görüntüyü nasıl kırpacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// Yeni görüntü nesnesi oluşturur
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
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
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Resmin Kırpılmış Alanlarını Silme**

Bir çerçeve içinde bulunan bir görüntünün kırpılmış alanlarını silmek istiyorsanız, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksizse orijinal görüntüyü, aksi takdirde kırpılmış görüntüyü döndürür.  

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

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) yöntemi kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) içinde kullanılıyorsa, bu yapı sunum boyutunu azaltabilir. Aksi takdirde, ortaya çıkan sunumdaki görüntü sayısı artar.

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafile’larını raster PNG görüntüsüne dönüştürür. 

{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) yöntemiyle sıkıştırabilirsiniz.  
Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre görüntünün boyutunu küçülterek, istenirse kırpılmış alanları da silebilir.  

PowerPoint’teki **Picture Format > Compress Pictures > Resolution** özelliğine benzer şekilde, resmin boyutunu ve çözünürlüğünü ayarlar.  

Aşağıdaki Java örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntüyü nasıl sıkıştıracağını gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Görüntüyü hedef çözünürlük 150 DPI (Web çözünürlüğü) ile sıkıştır ve kırpılmış alanları kaldır.
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
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Görüntüyü 150 DPI (web çözünürlüğü) seviyesine sıkıştır, kırpılmış alanları kaldır.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Yöntem, şeklin boyutuna ve sağlanan DPI’ye göre görüntüyü daha düşük çözünürlüğe dönüştürür. Dosya boyutunu optimize etmek için kırpılmış bölgeler de silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe göre korunur veya hafifçe azalır; bu, PowerPoint’in yüksek çözünürlüklü JPEG’leri nasıl işlediğine benzer.  

{{% /alert %}}

## **En-Boy Oranını Kilitleme**

Bir görüntü içeren şeklin, görüntü boyutları değiştirildiğinde bile en-boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) yöntemini kullanabilirsiniz.

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

    // Şeklin yeniden boyutlandırıldığında en-boy oranını korumasını ayarlar
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı sadece şeklin en‑boy oranını korur, içinde bulunduğu görüntüyü değil. 

{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat) sınıfındaki [StretchOffsetLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) özelliklerini kullanarak bir doldurma dikdörtgeni belirleyebilirsiniz.

Bir görüntü için esnetme belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklenir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde olarak bir ofsetle tanımlanır. Pozitif yüzde içeriye, negatif yüzde dışarıya doğru bir kaydırma belirtir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Bir `AutoShape` dikdörtgeni ekleyin.  
4. Bir görüntü oluşturun.  
5. Şeklin doldurma türünü ayarlayın.  
6. Şeklin resim doldurma modunu ayarlayın.  
7. Şekli doldurmak için bir görüntü ekleyin.  
8. Görüntünün ofsetlerini, şeklin sınırlayıcı kutusunun ilgili kenarına göre belirtin.  
9. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```java
import com.aspose.slides.*;

// PPTX dosyasını temsil eden Presentation sınıfını örnek oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx sınıfını örnek oluşturur
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

    // Şekli dolduracak görüntüyü ayarlar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Görüntünün ofsetlerini şeklin sınırlayıcı kutusunun ilgili kenarına göre belirtir
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // PPTX dosyasını diske yazar
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

### Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/)‘e atanan görüntü nesnesi aracılığıyla raster (PNG, JPEG, BMP, GIF vb.) ve vektör (ör. SVG) görüntüleri destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.

### Çok sayıda büyük görüntü eklemek PPTX boyutunu ve performansını nasıl etkiler?

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; bağlantı olarak eklemek sunum boyutunu küçültür ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı ile ekleme özelliği sunar.

### Görüntü nesnesini kazara taşınması/yeniden boyutlandırılmasından nasıl kilitleyebilirim?

[Şekil kilitleri](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) kullanarak bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/)‘i (ör. taşıma veya yeniden boyutlandırmayı devre dışı bırakmak) kilitleyebilirsiniz. Kilitleme mekanizması, [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) dahil çeşitli şekil türleri için desteklenir.

### PDF/görüntülere dışa aktarırken SVG vektör bütünlüğü korunuyor mu?

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/)‘den SVG’yi orijinal vektör olarak çıkarmanıza izin verir. PDF’ye [/slides/tr/androidjava/convert-powerpoint-to-pdf/] ya da raster formatlara [/slides/tr/androidjava/convert-powerpoint-to-png/] dışa aktarırken, dışa aktarım ayarlarına bağlı olarak sonuç rasterleştirilebilir; ancak SVG’nin vektör olarak saklandığı çıkarım davranışı bunun kanıtıdır.