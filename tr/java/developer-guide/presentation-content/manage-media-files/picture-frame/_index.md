---
title: Java ile Sunularda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü görüntü
- bağlantılı görüntü
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
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunumlarda resim çerçevelerini oluşturma, biçimlendirme, bağlama, kırpma, çıkarma ve sıkıştırma."
---
## **Genel Bakış**

Bir resim çerçevesi, bir görüntüyü gösteren slayt şeklidir. Aspose.Slides içinde, görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) gömülü görüntü kaynaklarını [IImageCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagecollection/) aracılığıyla sahiplenirken, bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) görüntünün konumunu, boyutunu, çizgi biçimlendirmesini, dönüşünü, kırpmasını, resim efektlerini ve diğer çerçeve düzeyi ayarlarını kontrol eder.

Bu ayrım, aynı görüntünün birden fazla kez gösterilmesi gerektiğinde kullanışlıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesini tutun ve resim çerçeveleri oluştururken bu görüntü kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüler ve SVG gibi vektör görüntüler içerebilir. Ayrıca görüntüyü sunuma yerleştirmek yerine bağlı (linked) görüntülere de referans verebilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek faydalıdır.

## **Eklenmiş Görüntü Ekleme ve Biçimlendirme**

Eklenmiş bir görüntü için görüntü verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemini kullanın. Görüntü, sunum paketinin bir parçası haline gelir; bu sayede sunum başka bir bilgisayara taşındığında kendi kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile dönüş uygular:

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

Resim çerçevesi, görüntülenen geometriyi kontrol eder; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görüntüyü kırpma veya sıkıştırma yapılacaksa önem kazanır.

## **Göreli Ölçeği Kullan**

[IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) çerçeve için genişlik ve yükseklik ölçeğini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) yöntemleri aracılığıyla sunar. `1.0` değeri, orijinal resim boyutunun %100’üne karşılık gelir. Göreli ölçek, işlem akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuyla olan ilişkiyi koruması gerektiğinde faydalıdır.

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

Göreli ölçek, çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir resim, görüntü verisini sunum içinde saklar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlantılı bir resim, görüntü verisini aynı şekilde gömmek yerine [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) yöntemiyle harici bir konumu depolar.

Bağlantılı görüntüler, PPTX içinde depolanan görüntü verisi miktarını azaltabilir, ancak dış bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak mevcut değilse, bağlantılı resim beklenildiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Görüntü Ekle**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görüntü dosyasına yönlendirir. Sadece görüntü bağlamasıyla ilgilenir; video bağlaması ayrı bir medya iş akışıdır ve kasıtlı olarak bu örneğe karıştırılmamıştır.

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

Harici dosya yönetimi kasıtlı olduğunda bağlantılar kullanın. Sıkıştırma yerine sadece bir alternatif olarak kullanmayın: kırık görüntü bağımlılıklarına sahip küçük bir PPTX, daha büyük kendi içinde bütün bir sunuma göre genellikle daha az yararlıdır.

## **Resim Çerçevelerinden Görüntü Çıkarma**

Mevcut bir sunumdan görüntü çıkarmadan önce, şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) olup olmadığını ve gömülü bir görüntü içerip içermediğini kontrol edin. Bağlantılı resim çerçeveleri, aynı şekilde çıkarılabilecek görüntü baytları içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API’si, eski Java görüntü sarmalayıcısına gerek kalmadan [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) doğrudan kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ile kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytlara ihtiyaç duyuyorsanız, dönüştürülmüş raster dosya yerine görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

SVG bir resim için [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) bir [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) nesnesi sunar. Bu sayede resmi rasterleştirmeden doğrudan SVG verisini alabilirsiniz.

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

SVG içeriğini SVG olarak tutmak, sunum içinde vektör kaynağını korur. PNG veya JPEG gibi raster dışa aktarımlar, o vektör içeriğini piksele dönüştürmek zorundadır. PDF veya SVG slayt dışa aktarımları da bir render işlemidir; bu yüzden dışa aktarılan grafikler orijinal gömülü SVG’nin bayt‑bayt kopyası olarak değerlendirilmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/#getSvgData--) verisi kullanılmalıdır.

## **Bir Görüntüyü Kırpma**

Kırpma, bir görüntünün çerçeve içinde hangi kısmının görüneceğini değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzde değerleridir. Kırpma, gömülü görüntüdeki gizli pikselleri başlangıçta silmez; yalnızca görünür bölgeyi değiştirir.

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

Gizli görüntü verisi hâlâ mevcut olduğu için kırpma, orijinal pikselleri kaybetmeden daha sonra değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, kırpılmış bölgeler sonraki bölümde açıklanan şekilde fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verilerini Kaldırma**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeninin dışındaki görüntü verilerini kaldırır ve ortaya çıkan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir “uncrop” işlemi için artık mevcut değildir.

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

Yöntem, sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü diğer resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarına ihtiyaç duyar; bu nedenle kırpılmış alanları silmek toplam görüntü sayısını mutlaka azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) görüntünün gösterildiği boyuta göre raster görüntü çözünürlüğünü azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, değişiklik gerekmediyse `false` döndürür.

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

Belirli bir hedef gerektiğinde önceden tanımlı bir değer yerine pozitif bir DPI değeri de geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinmiş kırpılmış bölgelerin, optimize edilmiş sunumdan geri getirilemeyeceğini unutmayın. En düşük DPI’yı küresel olarak uygulamaktan ziyade, görüntünün gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre bir hedef çözünürlük seçin.

## **Görüntü Dönüştürme Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklık, alfa efektleri, sıralı zincirler, inceleme, kaldırma ve çift yön doğrulama konularını kapsayan tam bir iş akışı için [Image Transform Effects](/slides/tr/java/image-transform-effects/) sayfasına bakın.

## **Resim Çerçevesi Geometrisini Kilitle**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) yeniden boyutlandırılırken şeklin oranını korur.

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

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en‑boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içeriye doğru bir boşluk oluştururken, negatif yüzde değerleri dışarıya doğru bir çıkıntı yaratır.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görüneceğini seçerken; stretch offset değerleri, görünür doldurmanın hangi dikdörtgen içine gerileceğini değiştirir.

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

Doldurma konumlandırması için stretch offsetleri kullanın. Kaynak görüntünün kenarlarını gizlemek amaçlandığında kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarım Hususları**

Görüntü depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel ticaret‑off’lar daha kolay yönetilir:

- **Gömülü görüntüler** sunumu kendi içinde bütün hâle getirir ve paylaşım ile sunucu‑tarafı render için en güvenilir seçenek olur, ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, ancak sunum, depolanan yol veya konumlardaki dış dosyaların mevcut olmasına bağımlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılan alanlar açıkça silinene veya sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntülerde dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Slayt üzerindeki hedef boyut bilindikten sonra uygulanmalıdır.
- **SVG görüntüler**, vektör korumasının önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağının kendisine ihtiyacınız varsa gömülü SVG’yi doğrudan çıkarın. Raster slayt dışa aktarımları her zaman render edilen slaytı piksele dönüştürür.
- **Tekrarlanan görüntüler**, mümkün olduğunca mevcut bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) kaynağını yeniden kullanmalıdır; aynı dosyayı sunum iş akışına tekrar tekrar yüklemek yerine.

Büyük sunumlar için görüntü optimizasyonu genellikle seçici olarak yapıldığında en etkili olur: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca sonraki düzenleme gerekmiyorsa kaldırın ve dış bağlantılardan kaçının, bu bağlantılar bağımlılık yönetiminin dağıtım tasarımının bir parçası olduğu durumlar hariç.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

[IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) sunuma ilişkin bir görüntü kaynağını temsil eder. [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) ise bir slayttaki görüntüyü gösteren ve çerçeve‑düzeyi geometriyi ve biçimlendirmeyi (boyut, dönüş, kırpma değerleri, efektler, kilitlemeler) depolayan bir şekildir.

**Görüntüleri gömmeli mi yoksa bağlamalı mıyım?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına koymak kasıtlıysa ve dış konumlar güvenilir bir şekilde sürdürülebilir ise yalnızca o zaman bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden değil. Normal kırpma ayarları, kaynağın bir kısmını gizler ancak alttaki pikselleri tutar. Bu pikseller kalıcı olarak atılabilir olduğunda, [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) veya kırpılmış‑alan kaldırmalı sıkıştırma kullanılmalıdır.

**Sıkıştırma sonrası görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma, depolanan raster çözünürlüğü düşürebilir ve kırpılmış bölgelerin kaldırılması görüntü verisini yok eder. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceği durumlarda orijinal kaynak görüntüyü sunum dışında tutun.

**SVG görüntüleri nasıl ele alınmalı?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriğini SVG olarak koruyun. Gömülü [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster bir formata slayt render edildiğinde SVG, slayt görüntüsünün bir parçası olarak rasterleştirilir.

**Mevcut slaytları okurken güvensiz tip dönüşümlerinden nasıl kaçınabilirim?**

Resim‑çerçevesine özgü üyeleri kullanmadan önce şekil tipini kontrol edin. `[IPictureFrame]` üzerinde bir `instanceof` kontrolü, geçersiz dönüşümleri önler ve kodun resim çerçevesi içermeyen slaytları uygun şekilde işlemesini sağlar.