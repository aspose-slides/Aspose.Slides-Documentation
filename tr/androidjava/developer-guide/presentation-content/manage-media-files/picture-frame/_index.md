---
title: Android'ta Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/androidjava/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü resim
- bağlantılı resim
- resim çıkar
- raster resim
- SVG resmi
- resim kırp
- kırpılmış alanları sil
- resim sıkıştır
- StretchOffset
- resim çerçevesi formatlama
- göreceli ölçek
- resim efekti
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

Bir resim çerçevesi, bir resmi gösteren slayt şeklidir. Aspose.Slides içinde resim kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Sunum] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) gömülü resim kaynaklarını [IImageCollection] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagecollection/) aracılığıyla sahiplenirken, bir [IPictureFrame] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) resmin konumunu, boyutunu, kenar biçimlendirmesini, döndürülmesini, kırpılmasını, resim efektlerini ve diğer çerçeve‑seviyesi ayarları kontrol eder.

Bu ayrım, aynı resmin birden fazla kez gösterilmesi gerektiğinde faydalıdır. Resmi sunuma bir kez ekleyin, döndürülen [IPPImage] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu resim kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster resimler ile SVG gibi vektör resimleri içerebilir. Ayrıca resim baytlarını sunuma depolamak yerine bağlanmış resimlere de referans verebilir. Bu seçim, taşınabilirliği, dosya boyutunu, çıkartma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce resmin nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Resim Ekleme ve Biçimlendirme**

Gömülü bir resim için, resim verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [IShapeCollection.addPictureFrame] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metodunu kullanın. Resim sunum paketinin bir parçası haline gelir, bu sayede sunum başka bir bilgisayara taşındığında kendine yeterli kalır.

Aşağıdaki örnek bir JPEG resmi ekler, resmin özgün boyutlarında bir çerçeve oluşturur ve kenar biçimlendirmesi ile döndürme uygular:

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

Resim çerçevesi görüntülenen geometriyi kontrol eder; çerçeve boyutunu değiştirmek gömülü resim kaynağında saklanan piksel boyutlarını değiştirmez. Bu ayrım, daha sonra resim kırpma ya da sıkıştırma yapıldığında önem kazanır.

## **Göreceli Ölçeği Kullanma**

[IPictureFrame] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) çerçeve için göreceli genişlik ve yükseklik ölçeklemeyi [setRelativeScaleWidth] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) metodlarıyla sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreceli ölçek, bir iş akışının kaynak resim boyutuyla oranı koruması gerektiğinde, nihai boyutları elle hesaplamaktan daha kullanışlıdır.

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

Göreceli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü resmi yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Resimler**

Gömülü bir resim, resim verilerini sunum içinde saklar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlantılı bir resim, resim verilerini aynı şekilde gömmek yerine [ISlidesPicture.setLinkPathLong] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) metodu aracılığıyla harici bir konuma referans verir.

Bağlantılı resimler PPTX içinde depolanan resim verisi miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa ya da kaynak kullanılmazsa, bağlantılı resim beklenildiği gibi görüntülenmeyebilir. E‑posta ile gönderilmesi, arşivlenmesi veya izole ortamda render edilmesi gereken sunumlar için gömülü resimler genellikle daha güvenilirdir.

### **Bağlantılı Resim Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir resim dosyasına yönlendirir. Sadece resim bağlamayı gösterir; video bağlama ayrı bir medya iş akışıdır ve bu örnekte bilinçli olarak karıştırılmamıştır.

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

Dış dosya yönetimi kasıtlıysa bağlantı kullanın. Sıkıştırmanın yerine yalnızca bir yedek olarak kullanmayın: kırık bağımlılıkları olan küçük bir PPTX, büyük, kendine yeterli bir sunumdan genellikle daha az kullanışlıdır.

## **Resim Çerçevelerinden Resimleri Çıkarma**

Mevcut bir sunumdan resmi çıkarmadan önce, şeklin gerçekten bir [IPictureFrame] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) olup olmadığını ve gömülü bir resim içerdiğini kontrol edin. Bağlantılı resim çerçeveleri aynı şekilde çıkarılabilecek resim baytlarını içermeyebilir.

### **Raster Resim Çıkarma**

Modern resim API’si, eski Java resim sarmalayıcısına gerek kalmadan [IImage] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesini doğrudan kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage.save] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) aracılığıyla kaydetmek, çıkarılan resmi istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytlara ihtiyacınız varsa, dönüştürülmüş raster dosya yerine resim kaynağının ikili verisini kullanın.

### **SVG Resim Çıkarma**

SVG resmi için, [IPPImage] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) bir [ISvgImage] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmeden doğrudan SVG verisini almanızı sağlar.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımlar bu vektör içeriği piksele dönüştürür. PDF veya SVG slayt dışa aktarma da bir render işlemi olduğundan, dışa çıkan grafikler orijinal gömülü SVG’nin bayt‑bayt bir kopyası olarak değerlendirilmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage.getSvgData] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/#getSvgData--) verisi kullanılmalıdır.

## **Bir Resmi Kırpma**

Kırpma, resmin çerçeve içinde hangi kısmının görüneceğini değiştirir. [IPictureFillFormat] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak resim boyutlarının yüzde değerleridir. Kırpma başlangıçta gizli pikselleri gömülü resimden silmez; yalnızca görünür bölgeyi değiştirir.

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

Gizli resim verisi hâlâ mevcut olduğu için, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu tersinirlikten daha önemliyse, sonraki bölümde açıklanan gibi kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Resim Verilerini Kaldırma**

[IPictureFillFormat.deletePictureCroppedAreas] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeninin dışındaki resim verilerini siler ve ortaya çıkan resim kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir kırpma geri alma işlemi için artık kullanılamaz.

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

Bu yöntem sunuma yeni bir resim kaynağı ekleyebilir. Orijinal resim başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçevelerin hâlen mevcut kaynağa ihtiyacı olur; bu yüzden kırpılmış alanların silinmesi mutlaka toplam resim sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Resimleri Sıkıştırma**

[IPictureFillFormat.compressImage] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) raster resim çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Metod, resim yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik gerekmediyse `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturescompression/) değeri kullanın:

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

Belirli bir hedef gerektiğinde, önceden tanımlı bir değer yerine pozitif DPI değeri de geçirilebilir.

Sıkıştırma raster resimler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca, düşük çözünürlük ve silinmiş kırpılmış bölgeler, optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, resmin aslında görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; tüm sunumda en düşük DPI’yı uygulamaktan kaçının.

## **Resim Dönüştürme Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, inceleme, kaldırma ve çift yönlü doğrulama gibi tam bir iş akışı için [Image Transform Effects](/slides/tr/androidjava/image-transform-effects/) sayfasına bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[IPictureFrameLock] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) şeklin oranını yeniden boyutlandırılırken korur.

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

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak resmin aynı en‑boy oranına yeniden örneklenmesi veya kalıcı olarak değiştirilmesi zorunlu kılmaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” (germe) ise, [IPictureFillFormat] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerler bir kenardan içeriye doğru bir girinti oluştururken, negatif yüzde değerler dışarıya doğru bir çıkıntı oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak resmin hangi kısmının görüneceğini seçerken; stretch offset değerleri, görünür resim doldurmasının hangi dikdörtgene gerileceğini belirler.

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

Doldurma yerleşimi için stretch offset kullanın. Kaynak resim kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Resim depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel ödünleşimler daha net yönetilir:

- **Gömülü resimler** sunumu kendine yeterli kılar ve paylaşım ile sunucu‑tarafı render için en güvenilirdir, ancak büyük raster resimler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı resimler** paketi daha küçük tutabilir, ancak sunum, belirtilen yollar veya konumlardaki dış dosyalara bağımlı hâle gelir.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene ya da sıkıştırma sırasında kaldırılıncaya kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster resimlerin dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Kaynak boyut biliniyorsa, sıkıştırma bu boyut kesinleştirildikten sonra uygulanmalıdır.
- **SVG resimler**, vektör korumanın önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarımları her zaman render edilen slaytı piksele dönüştürür.
- **Tekrarlanan resimler**, mümkün olduğunca aynı [IPPImage] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) kaynağını yeniden kullanmalı, aynı dosyayı tekrar‑tekrar sunuma yüklemekten kaçınmalıdır.

Büyük sunumlarda, resim optimizasyonu seçici olarak yapıldığında en etkili olur: logolar ve diyagramlar vektör içerik olarak tutulur, fotoğraflar gerçek gösterim boyutuna göre sıkıştırılır, kırpılmış pikseller yalnızca sonraki düzenleme gerekmediğinde kaldırılır ve dış bağlantılar, bağımlılık yönetimi dağıtım tasarımının bir parçası olmadıkça kullanılmaz.

## **SSS**

**Resim çerçevesi ile resim kaynağı arasındaki fark nedir?**

[IPPImage] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) sunuma bağlı bir resim kaynağını temsil eder. [IPictureFrame] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) bir slayttaki resmi gösteren, boyut, döndürme, kırpma değerleri, efektler ve kilitler gibi çerçeve‑seviyesi geometrik ve biçimsel bilgileri saklayan bir şekildedir.

**Resimleri gömmeli mi yoksa bağlamalı mıyım?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklar olmadan render edilmesi gerekiyorsa resimleri gömün. Resimleri dış dosyalarda tutmak ve dış konumları güvenilir bir şekilde yönetebiliyorsanız, bağlamayı tercih edin.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden olmaz. Normal kırpma ayarları kaynağın bir kısmını gizler ancak altındaki pikselleri tutar. Kırpılmış pikselleri kalıcı olarak kaldırmak için [IPictureFillFormat.deletePictureCroppedAreas] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) veya kırpılmış alanların kaldırıldığı bir sıkıştırma işlemi kullanılmalıdır.

**Sıkıştırma sonrası görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma saklanan raster çözünürlüğü düşürür, kırpılmış bölgelerin kaldırılması ise resim verisini siler. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceğini düşünüyorsanız, orijinal kaynak resmi sunum dışına saklayın.

**SVG resimlerin nasıl ele alınması gerekir?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriği SVG olarak tutun. Gömülü [ISvgImage] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) doğrudan çıkarılabilir. Slaytı PNG veya JPEG gibi raster bir formata dışa aktarmak, SVG’yi slayt görüntüsünün bir parçası olarak piksele dönüştürür.

**Mevcut slaytları okurken güvensiz tip dönüşümlerinden nasıl kaçınırım?**

Resim‑çerçevesi‑özel üyeleri kullanmadan önce şekil tipini kontrol edin. [IPictureFrame] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) karşısında bir `instanceof` kontrolü, geçersiz dönüşümleri önler ve resim çerçevesi içermeyen slaytların kod tarafından güvenli bir şekilde işlenmesini sağlar.