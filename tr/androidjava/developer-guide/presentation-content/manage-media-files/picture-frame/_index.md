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
- gömülü görüntü
- bağlı görüntü
- görüntü çıkar
- raster görüntü
- SVG görüntü
- görüntüyü kırp
- kırpılmış alanları sil
- görüntüyü sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- bağıl ölçek
- görüntü efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir resmi gösteren bir slayt şeklidir. Aspose.Slides'da, resim kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) gömülü resim kaynaklarını [IImageCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagecollection/) aracılığıyla sahip olur, bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) ise resmin konumunu, boyutunu, çizgi biçimlendirmesini, döndürülmesini, kırpılmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı resmin birden fazla kez gösterilmesi gerektiğinde yararlıdır. Resmi sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu resim kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüler ve SVG gibi vektör görüntüler içerebilir. Ayrıca, görüntü baytlarını sunumda depolamak yerine bağlanmış (linked) görüntülere de referans verebilirler. Bu seçim taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağını belirlemek faydalıdır.

## **Gömülü Resmi Ekleme ve Biçimlendirme**

Gömülü bir resim için, resim verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metodunu kullanın. Resim, sunum paketinin bir parçası haline gelir, böylece sunum başka bir bilgisayara taşındığında kendi içinde bütün kalır.

Aşağıdaki örnek bir JPEG resmi ekler, resmin özgün boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile döndürmeyi uygular:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resim çerçevesi gösterilen geometriyi kontrol eder; çerçeve boyutunu değiştirmek, gömülü resim kaynağında depolanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir resmi kırpma veya sıkıştırma işlemi yaparken önem kazanır.

## **Bağıl Ölçeği Kullanma**

[IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) çerçeve için genişlik ve yükseklik bağıl ölçeklendirmesini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) aracılığıyla sağlar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Bağıl ölçek, bir iş akışının nihai boyutları manuel olarak hesaplamak yerine kaynak resim boyutuyla ilişkisini koruması gerektiğinde yararlıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bağıl ölçek, çerçevenin ölçek ayarlarını değiştirir; gömülü resmi yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlı Görüntüler**

Gömülü bir resim, görüntü verilerini sunumun içinde depolar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlı bir resim ise, resmi aynı şekilde gömmek yerine [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) yöntemiyle harici bir konumu saklar.

Bağlı görüntüler, PPTX içinde depolanan görüntü verisi miktarını azaltabilir, ancak harici bir bağımlılık getirir. Bağlı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir kalmalıdır. Yol değişirse, dosya taşınırsa veya kaynak kullanılamazsa, bağlı resim beklendiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlı Bir Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görüntü dosyasına yönlendirir. Bu örnek yalnızca görüntü bağlamayı ele alır; video bağlama ayrı bir medya iş akışıdır ve kasıtlı olarak bu örneğe dahil edilmemiştir.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Harici dosya yönetimi amaçlıyken bağlantıları kullanın. Sıkıştırma yerine sadece bir alternatif olarak kullanmayın: kırık görüntü bağımlılıklarına sahip küçük bir PPTX, genellikle daha büyük, kendi içinde bütün bir sunumdan daha az faydalıdır.

## **Resim Çerçevelerinden Görüntü Çıkarma**

Mevcut bir sunumdan görüntü çıkarmadan önce, bir şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) olup olmadığını ve gömülü bir görüntü içerip içermediğini kontrol edin. Bağlı resim çerçeveleri aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) kullanır ve eski Java görüntü sarmalayıcısına ihtiyaç duymaz. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

[IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ile kaydetmek, çıkarılan görüntüyü istenen çıkış formatına dönüştürür. Sunumda saklanan kodlanmış baytlara ihtiyacınız varsa ve dönüştürülmüş bir raster dosya istemiyorsanız, bunun yerine görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

SVG resmi için, [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) bir [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmek yerine SVG verisini doğrudan almanıza olanak tanır.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarmalar, bu vektör içeriğini piksellere dönüştürmek zorundadır. PDF veya SVG slayt dışa aktarması da bir render işlemidir, bu yüzden dışa aktarılan grafikler, orijinal gömülü SVG'nin bayt bazlı bir kopyası olarak değerlendirilmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/#getSvgData--) verisini kullanın.

## **Bir Görüntüyü Kırpma**

Kırpma, bir görüntünün çerçeve içinde hangi kısmının göründüğünü değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görüntü boyutlarının yüzdesidir. Kırpma, başlangıçta gömülü görüntüden gizli pikselleri silmez; yalnızca görünen bölgeyi değiştirir.

Aşağıdaki örnek güvenli bir şekilde bir resim çerçevesi bulur ve kırpma değerlerini uygular:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Gizli görüntü verisi hâlâ mevcut olduğu için, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu tersine dönüşten daha önemliyse, kırpılmış bölgeler bir sonraki bölümde açıklandığı gibi fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini kaldırır ve ortaya çıkan görüntü kaynağını döndürür. Bu, dosya boyutunu küçültebilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra, kaldırılan pikseller daha sonraki bir kırpma geri alma işlemi için artık mevcut değildir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Yöntem sunuma yeni bir görüntü kaynağı ekleyebilir. Eğer orijinal görüntü diğer resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarına ihtiyaç duyar; bu nedenle kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. Bu yöntemle WMF veya EMF içeriğini kırpmak, kırpılmış sonucu PNG'ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) resmin gösterildiği boyuta göre raster görüntü çözünürlüğünü azaltır. Aynı işlemde kırpılmış bölgeleri de kaldırabilir. Yöntem, görüntü yeniden boyutlandırıldığında veya kırpıldığında `true`, hiçbir değişiklik gerekmediğinde `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturescompression/) değeri kullanın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Belirli bir hedef gerektiğinde, önceden tanımlı bir değer yerine özel pozitif bir DPI değeri geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılamaz. Ayrıca, düşük çözünürlük ve silinen kırpılmış bölgeler, optimize edilmiş sunumdan geri alınamaz. En düşük DPI'yi küresel olarak uygulamak yerine, görüntünün gerçekte görüntüleneceği veya dışa aktarılacağı en büyük boyuta göre bir hedef çözünürlük seçin.

## **Görüntü Efektlerini İnceleme**

Resim efektleri, çerçeve tarafından kullanılan resimde depolanır. Görüntü dönüşüm koleksiyonu, şeffaflık için sabit alfa modülasyonu ve parlaklık ve kontrast için lüminans gibi efektler içerebilir. Aşağıdaki örnek, bir slayttaki ilk resim çerçevesinden her iki tür efekti güvenli bir şekilde okur:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Bu efektler, görüntünün çerçevede nasıl render edildiğini değiştirir; orijinal gömülü görüntü baytlarını yeniden yazmazlar.

## **Resim Çerçevesi Geometrisini Kilitleme**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) şeklin boyutlandırılırken oranını korur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün yeniden örneklenmesini veya aynı en‑boy oranına kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu stretch olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri kenardan içe doğru bir iç boşluk (inset) oluştururken, negatif yüzde değerleri dışa doğru bir çıkıntı (outset) oluşturur.

Bu, kırpmaktan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının göründüğünü seçerken; stretch offset değerleri, görülen resim doldurmasının uzatıldığı dikdörtgeni değiştirir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Doldurma konumlandırması için stretch offset değerlerini kullanın. Amaç, kaynak görüntünün kenarlarını gizlemek olduğunda kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görsel depolama ve resim çerçevesi biçimlendirmesi ayrı ayrı ele alındığında ana tavizler yönetimi daha kolaydır:

- **Gömülü görüntüler** sunumu kendi içinde bütün yapar ve paylaşım ve sunucu tarafı render için en güvenilir olanlardır, ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlı görüntüler** paketi daha küçük tutabilir, ancak sunum, depolanmış yollar veya konumlardaki dış dosyaların mevcut olmasına bağlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene ya da sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntülerde dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Görüntünün slayt üzerindeki hedef boyutu bilindikten sonra uygulanmalıdır.
- **SVG görüntüler**, vektör korumasının önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağının kendisine ihtiyacınız olduğunda gömülü SVG'yi doğrudan çıkarın. Raster slayt dışa aktarımları her zaman render edilen slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler**, mümkün olduğunda aynı dosyayı sunum iş akışına tekrar tekrar yüklemek yerine mevcut bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) kaynağını yeniden kullanmalıdır.

Büyük sunumlar için, görüntü optimizasyonu genellikle seçici olarak yapıldığında en etkili olur: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, daha sonraki düzenleme gerekmiyorsa kırpılmış pikselleri kaldırın ve bağımlılık yönetimi dağıtım tasarımının bir parçası olmadıkça harici bağlantılardan kaçının.

## **FAQ**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

[IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) sunumla ilişkili bir görüntü kaynağını temsil eder. [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) bir slaytta resmi gösteren ve çerçeve düzeyinde geometrik ve biçimlendirme bilgilerinin (boyut, döndürme, kırpma değerleri, efektler ve kilitler) saklandığı bir şekildir.

**Görüntüleri gömmeli mi yoksa bağlamalı mıyım?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerektiğinde görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutmak kasıtlı ve dış konumlar güvenilir bir şekilde sürdürülebilir olduğunda yalnızca bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden değil. Normal kırpma ayarları kaynak görüntünün bölümlerini gizler, ancak altındaki pikselleri tutar. Bu pikseller kalıcı olarak atılabilir olduğunda [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) veya kırpılmış bölge kaldırmalı görüntü sıkıştırmasını kullanın.

**Sıkıştırma sonrası görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma, depolanan raster çözünürlüğü azaltabilir ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonraki yüksek çözünürlüklü düzenleme gerekebilecekse, orijinal kaynağı sunumun dışında tutun.

**SVG görüntüler nasıl ele alınmalı?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriğini SVG olarak tutun. Gömülü [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) doğrudan çıkarılabilir. Bir slaytı PNG veya JPEG gibi raster bir formata render etmek, SVG'yi slayt görüntüsünün bir parçası olarak rasterleştirir.

**Mevcut slaytları okurken güvensiz dönüşümlerden nasıl kaçınabilirim?**

Resim çerçevesine özgü üyeleri kullanmadan önce şekil türünü kontrol edin. [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) üzerinde bir `instanceof` kontrolü, geçersiz dönüşümleri önler ve kodun resim çerçevesi içermeyen slaytları işlemesine olanak tanır.