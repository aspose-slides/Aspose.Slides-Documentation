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
- göreceli ölçek
- görüntü efekti
- en‑boy oranı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir görüntüyü gösteren slayt şeklidir. Aspose.Slides'ta, görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) yerleşik görüntü kaynaklarını [IImageCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagecollection/) aracılığıyla sahiplenirken, bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) görüntünün konumunu, boyutunu, çizgi biçimlendirmesini, dönüşümünü, kırpmasını, resim efektlerini ve diğer çerçeve‑seviyesi ayarları kontrol eder.

Aynı görüntünün birden çok kez gösterildiği durumlarda bu ayrım faydalıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu görüntü kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntülerin yanı sıra vektör SVG görüntülerini de içerebilir. Ayrıca görüntü baytlarını sunuma depolamak yerine ilişkilendirilmiş görüntülere de başvurabilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek yararlıdır.

## **Gömülü Bir Görüntü Ekleme ve Biçimlendirme**

Gömülü bir görüntü için, görüntü verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak üzere [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemini kullanın. Görüntü sunum paketinin bir parçası haline gelir, böylece sunum başka bir bilgisayara taşındığında kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile dönüşüm uygular:

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

Resim çerçevesi gösterilen geometrinin kontrolünü sağlar; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra görüntüyü kırpma veya sıkıştırma yapıldığında önem kazanır.

## **Göreceli Ölçek Kullanma**

[IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) çerçeve için göreceli genişlik ve yükseklik ölçeklendirmesini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) aracılığıyla sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreceli ölçek, bir iş akışının kaynak görüntü boyutuna ilişkin bir ilişkiyi koruması gerektiğinde, son boyutları elle hesaplamaktan daha kullanışlıdır.

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

Göreceli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örnekleme veya sıkıştırma yapmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir resim, görüntü verilerini sunum içinde saklar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlantılı bir resim ise görüntü verilerini aynı şekilde gömmek yerine [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) yöntemiyle harici bir konumu tutar.

Bağlantılı görüntüler PPTX içindeki görüntü verisi miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak mevcut olmazsa, bağlantılı resim beklenildiği gibi görüntülenmeyebilir. E-posta, arşivleme veya izole ortamlarda render edilen sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Bir Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve yerel bir görüntü dosyasına yönlendirir. Sadece görüntü bağlantısına odaklanır; video bağlantısı ayrı bir medya iş akışıdır ve bu örnek içinde karıştırılmamıştır.

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

Harici dosya yönetimi amaçlıysa bağlantıları kullanın. Sıkıştırmanın yerine sadece bir alternatif olarak kullanmayın: kırık görüntü bağımlılıklarına sahip küçük bir PPTX, genellikle büyük, kendine yeterli bir sunumdan daha az yararlıdır.

## **Resim Çerçevelerinden Görüntü Çıkarma**

Mevcut bir sunumdan görüntü çıkarmadan önce, şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) olup olmadığını ve gömülü bir görüntü içerdiğini kontrol edin. Bağlantılı resim çerçeveleri, aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si, daha eski Java görüntü sarmalayıcısına ihtiyaç duymadan doğrudan [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ile kaydetmek, çıkarılan görüntüyü istenen çıktı biçimine dönüştürür. Sunum içinde saklanan kodlanmış baytlara ihtiyacınız varsa, dönüştürülmüş raster dosya yerine görüntü kaynağının ikili verilerini kullanın.

### **SVG Görüntüsü Çıkarma**

Bir SVG resmi için, [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) bir [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmeden doğrudan SVG verisini almanızı sağlar.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarmalar, o vektör içeriği piksellere dönüştürür. PDF veya SVG slayt dışa aktarma da bir render işlemidir; dışa aktarılan grafikler, orijinal gömülü SVG'nin bayt‑bayt kopyası olarak görülmemelidir; asıl vektör kaynağı gerektiğinde gömülü [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/#getSvgData--) verisi kullanılmalıdır.

## **Bir Görüntüyü Kırpma**

Kırpma, görüntünün çerçeve içinde hangi bölümünün görüneceğini değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görüntü boyutlarının yüzdesi olarak tanımlanır. Kırpma, gömülü görüntüdeki gizli pikselleri başlangıçta silmez; yalnızca görünür bölgeyi değiştirir.

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

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu, geri dönüşümden daha önemliyse, sonraki bölümde anlatıldığı gibi kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini siler ve oluşan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir “uncrop” işlemiyle elde edilemez.

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

Bu yöntem sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarını gerektirir; bu nedenle kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) raster görüntü çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, değişiklik gerekmediyse `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda ön tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturescompression/) değeri kullanın:

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

Belirli bir hedef gerektiğinde, ön tanımlı bir değer yerine özel pozitif DPI değeri geçirilebilir.

Sıkıştırma raster görüntüler içindir. SVG ve metafile içeriği bu raster sıkıştırma süreciyle azaltılmaz. Ayrıca, düşük çözünürlük ve silinmiş kırpılmış bölgeler, optimize edilmiş sunumdan geri getirilemez. En büyük görüntü izleme veya dışa aktarma boyutuna göre hedef çözünürlük seçin; tüm sunumda en düşük DPI’yı uygulamaktan kaçının.

## **Görüntü Dönüşüm Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, inceleme, kaldırma ve iki yönlü doğrulama gibi tam bir iş akışı için [Image Transform Effects](/androidjava/image-transform-effects/) bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) yeniden boyutlandırılırken şeklin en‑boy oranını korur.

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

Kilit, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en‑boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim dolgu modu “stretch” olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri kenardan içeriye doğru bir kenar boşluğu oluştururken, negatif yüzde değerleri dışarıya doğru bir genişleme yaratır.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynağın hangi kısmının görüneceğini seçerken; stretch offset değerleri, görünür resim dolgusunun hangi dikdörtgene gerileceğini belirler.

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

Dolgu yerleştirme için stretch offset kullanın. Kaynak görüntünün kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görüntü depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel ticaret‑off’lar daha iyi yönetilir:

- **Gömülü görüntüler** sunumu kendine yeterli kılar ve paylaşım ve sunucu‑tarafı render için en güvenilir olanlardır; ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, ancak sunumun dış dosyaların belirtilen yollarda erişilebilir olmasına bağımlılığı vardır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene ya da sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntülerin dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Slayt üzerindeki hedef boyut bilindiğinde uygulanmalıdır.
- **SVG görüntüler** vektör korumasının önemli olduğu durumlarda SVG olarak bırakılmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarmaları her zaman render edilen slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler** mümkün olduğunca mevcut bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) kaynağını yeniden kullanmalı, aynı dosyayı birden çok kez sunuma yüklemekten kaçınmalıdır.

Büyük sunumlarda, görüntü optimizasyonu genellikle seçici olarak yapıldığında en etkili olur: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca ileri düzenleme gerekmediğinde kaldırın ve dış bağlantıları yalnızca bağımlılık yönetimi dağıtım tasarımının bir parçasıysa kullanın.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

Bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) sunuma ilişkilendirilmiş bir görüntü kaynağını temsil eder. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) ise bir slaytta görüntüyü gösteren ve çerçeve‑seviyesi geometri ve biçimlendirmeyi (boyut, dönüş, kırpma değerleri, efektler ve kilitler gibi) depolayan bir şekildir.

**Görüntüleri gömmeli miyim yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutma ve dış konumların güvenilir bir şekilde korunması amaçlıysa bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden olmaz. Normal kırpma ayarları, kaynak görüntünün bir kısmını gizler ancak temel pikselleri tutar. Bu pikselleri kalıcı olarak atmak için [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) veya kırpılmış alanların kaldırıldığı sıkıştırma kullanılmalıdır.

**Sıkıştırma sonrası görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma saklanan raster çözünürlüğü düşürür ve kırpılmış bölgelerin kaldırılması görüntü verisini yok eder. Daha sonraki yüksek çözünürlük düzenlemeleri gerekebilecekse, orijinal kaynağı sunum dışında tutun.

**SVG görüntüler nasıl ele alınmalı?**

Vektör doğruluğunun önemli olduğu durumlarda SVG içeriği SVG olarak kalmalıdır. Gömülü [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster bir formata slayt render etmek, SVG’yi slayt görüntüsünün bir parçası olarak piksellere dönüştürür.

**Mevcut slaytları okurken güvensiz tip dönüşümlerinden nasıl kaçınılır?**

Şekil tipini kullanmadan önce kontrol edin. Bir `instanceof` kontrolü ile [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) olup olmadığını doğrulamak, geçersiz dönüşümleri önler ve resim çerçevesi içermeyen slaytların kod tarafından güvenli bir şekilde işlenmesini sağlar.