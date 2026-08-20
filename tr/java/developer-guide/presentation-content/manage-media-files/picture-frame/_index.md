---
title: Java Kullanarak Sunumlardaki Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/java/picture-frame/
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
- göreli ölçek
- görüntü efekti
- en/boy oranı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunumlardaki resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir görüntüyü gösteren slayt şeklidir. Aspose.Slides'de, görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) gömülü görüntü kaynaklarını [IImageCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagecollection/) aracılığıyla sahiplenirken, bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) görüntünün konumunu, boyutunu, çizgi biçimlendirmesini, dönüşünü, kırpmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı görüntünün birden fazla kez gösterilmesi gerektiğinde faydalıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu görüntü kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüleri ve SVG gibi vektör görüntüleri içerebilir. Ayrıca sunuma görüntü baytlarını depolamak yerine bağlanmış görüntülere de referans verebilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulanmadan önce görüntünün nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Görüntü Ekleme ve Biçimlendirme**

Gömülü bir görüntü için, görüntü verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metodunu kullanın. Görüntü sunum paketinin bir parçası haline gelir, bu yüzden sunum başka bir bilgisayara taşındığında kendine özgü kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün doğal boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile döndürmeyi uygular:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Resim çerçevesi, gösterilen geometrinin kontrolünü sağlar; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra görüntüyü kırpma veya sıkıştırma yaparken önem kazanır.

## **Göreli Ölçek Kullanımı**

[IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) çerçeve için göreli genişlik ve yükseklik ölçeklendirmesini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) aracılığıyla sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreli ölçek, bir iş akışının son boyutları manuel olarak hesaplarken kaynak görüntü boyutuyla ilişkisini koruması gerektiğinde kullanışlıdır.

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

Göreli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlı Görüntüler**

Gömülü bir resim, görüntü verisini sunum içinde saklar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçimdir. Bağlı bir resim, görüntü verisini aynı şekilde gömmek yerine [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) metodu aracılığıyla harici bir konuma işaret eder.

Bağlı görüntüler PPTX'te depolanan görüntü verisi miktarını azaltabilir, ancak harici bir bağımlılık oluşturur. Bağlı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak kullanılamaz hâle gelirse, bağlı resim beklendiği gibi gösterilemez. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlı Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve bunu yerel bir görüntü dosyasına yönlendirir. Sadece görüntü bağlamayla ilgilenir; video bağlama ayrı bir medya iş akışıdır ve kasıtlı olarak bu örneğe karıştırılmamıştır.

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

Harici dosya yönetiminin amaçlı olduğu durumlarda bağları kullanın. Sıkıştırma yerine yalnızca bir yedek olarak kullanmayın: kırık görüntü bağımlılıklarına sahip küçük bir PPTX, genellikle daha büyük kendine özgü bir sunumdan daha az faydalıdır.

## **Resim Çerçevelerinden Görüntü Çıkarma**

Mevcut bir sunumdan bir görüntü çıkarmadan önce, bir şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) olup olmadığını ve gömülü bir görüntü içerdiğini kontrol edin. Bağlı resim çerçeveleri, aynı şekilde çıkarılamayan görüntü baytları içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) kullanır ve eski Java görüntü sarmalayıcısına ihtiyaç duymaz. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) yöntemi aracılığıyla kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunum içinde depolanan kodlanmış baytlara, dönüştürülmüş raster dosya yerine ihtiyacınız varsa, görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

Bir SVG resmi için, [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) bir [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmeden doğrudan SVG verisini almanızı sağlar.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarmalar, bu vektör içeriği piksellere dönüştürür. PDF veya SVG slayt dışa aktarımı da bir render işlemidir; bu nedenle dışa aktarılan grafikler orijinal gömülü SVG'nin bayt‑bayt kopyası olarak ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/#getSvgData--) verisi kullanılmalıdır.

## **Görüntüyü Kırpma**

Kırpma, çerçeve içinde hangi görüntü kısmının görüneceğini değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzde olarak ifadesidir. Kırpma, gömülü görüntüdeki gizli pikselleri başlangıçta silmez; yalnızca görünür bölgeyi değiştirir.

Aşağıdaki örnek bir resim çerçevesini güvenli bir şekilde bulur ve kırpma değerlerini uygular:

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

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, sonraki bölümde açıkça kaldırılan kırpılmış bölgeler fiziksel olarak silinebilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini kaldırır ve ortaya çıkan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir kırpma geri alma işlemi için artık mevcut değildir.

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

Bu yöntem sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarını korumalıdır; bu yüzden kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. Bu yöntemle WMF veya EMF içeriği kırpıldığında sonuç PNG’ye rasterleştirilir.

## **Raster Görüntüleri Sıkıştırma**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) raster görüntü çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik gerekmediyse `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/java/com.aspose.slides/picturescompression/) değeri kullanın:

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

Belirli bir hedef gerektiğinde, önceden tanımlı bir değer yerine pozitif bir DPI değeri de geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içerikleri bu raster sıkıştırma akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinen kırpılmış bölgeler, optimize edilmiş sunumdan geri kazanılamaz. Hedef çözünürlüğü, görüntünün gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; genel olarak en düşük DPI'yı uygulamaktan kaçının.

## **Görüntü Efektlerini İnceleme**

Resim efektleri, çerçeve tarafından kullanılan resimde depolanır. Görüntü dönüşüm koleksiyonu, şeffaflık için sabit alfa modülasyonu ve parlaklık/kontrast için lüminans gibi efektler içerebilir. Aşağıdaki örnek, bir slayttaki ilk resim çerçevesinden her iki tür efekti de güvenli bir şekilde okur:

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

Bu efektler, görüntünün çerçevede nasıl render edildiğini değiştirir; orijinal gömülü görüntü baytlarını yeniden yazarlar.

## **Resim Çerçevesi Geometrisini Kilitleme**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakıldığını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) şeklin yeniden boyutlandırılırken en/boy oranını korur.

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

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en/boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu stretch olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içeriye doğru bir boşluk oluştururken, negatif yüzde değerleri dışarıya doğru bir taşma yaratır.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görüneceğini seçer; stretch offsetleri ise görünür resim doldurmasının hangi dikdörtgene uzatılacağını değiştirir.

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

Kırpma özellikleri kenarları gizlemek için kullanılır; stretch offsetleri doldurma yerleşimi için kullanılır.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görüntü depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel takaslar daha net yönetilir:

- **Gömülü görüntüler** sunumu kendine özgü hâle getirir ve paylaşım ile sunucu‑tarafı render için en güvenilir olandır; ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlı görüntüler** paketi daha küçük tutabilir, ancak sunum, depolanan yol veya konumlardaki harici dosyalara bağlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntülerin dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Sunumda kullanılacak gerçek slayt boyutu bilindiğinde uygulanmalıdır.
- **SVG görüntüler** vektör bütünlüğünün önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağına ihtiyaç duyduğunuzda gömülü SVG doğrudan çıkarın. Raster slayt dışa aktarmaları her zaman render edilen slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler** mümkün olduğunca mevcut bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) kaynağını yeniden kullanmalı, aynı dosyayı tekrar tekrar sunuma yüklemekten kaçınmalıdır.

Büyük sunumlarda, görüntü optimizasyonu genellikle seçici olarak yapıldığında daha etkilidir: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, yalnızca daha sonraki düzenleme gerekmediğinde kırpılmış pikselleri kaldırın ve dış bağlantılar, bağımlılık yönetimi dağıtım tasarımının bir parçası olmadıkça kullanılmasın.

## **SSS**

**Bir resim çerçevesi ile bir görüntü kaynağı arasındaki fark nedir?**

[IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) sunumla ilişkilendirilmiş bir görüntü kaynağını temsil eder. [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) ise bir slayt üzerindeki resmi gösteren, çerçeve‑düzeyinde boyut, döndürme, kırpma değerleri, efektler ve kilitleme gibi biçimlendirmeleri depolayan bir şekildir.

**Görüntüleri gömmeli miyim yoksa bağlamalı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutmak ve dış konumların güvenilir bir şekilde sürdürülebileceği durumlarda yalnızca bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden azaltmaz. Normal kırpma ayarları, kaynak görüntünün bölümlerini gizler ancak altındaki pikselleri tutar. Kırpılmış pikselleri kalıcı olarak kaldırmak için [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) veya kırpılmış alan kaldırımıyla birlikte görüntü sıkıştırmasını kullanın.

**Sıkıştırmadan sonra görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma, saklanan raster çözünürlüğü azaltabilir ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceği durumlar için orijinal kaynak görüntüyü sunum dışında tutun.

**SVG görüntüler nasıl ele alınmalı?**

Vektör doğruluğu önemliyse SVG içeriğini SVG olarak koruyun. Gömülü [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster bir formata slide render etmek, SVG'yi slide görüntüsünün bir parçası olarak piksellere dönüştürür.

**Mevcut slaytları okurken güvensiz tip dönüşümlerinden nasıl kaçınırım?**

Şekil tipini kullanmadan önce kontrol edin. [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) karşısında bir `instanceof` kontrolü, geçersiz dönüşümleri önler ve resim çerçevesi içermeyen slaytların kod tarafından doğru şekilde ele alınmasını sağlar.