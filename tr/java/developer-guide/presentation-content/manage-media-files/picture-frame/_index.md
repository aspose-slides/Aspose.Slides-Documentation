---
title: Java ile Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü görsel
- bağlı görsel
- görsel çıkar
- raster görsel
- SVG görsel
- görsel kırp
- kırpılmış alanları sil
- görsel sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreli ölçek
- görsel efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir resmi gösteren bir slayt şeklidir. Aspose.Slides'te, görsel kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Sunum](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) gömülü görsel kaynaklarını [IImageCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagecollection/) aracılığıyla sahiplenirken, bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) resmin konumunu, boyutunu, çizgi biçimlendirmesini, döndürülmesini, kırpılmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı resim birden fazla kez gösterildiğinde faydalıdır. Resmi sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/)'i tutun ve resim çerçeveleri oluştururken bu görsel kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görselleri ve SVG gibi vektör görselleri içerebilir. Ayrıca görsel baytlarını sunuma depolamak yerine bağlı (linked) görsellere de başvurabilirler. Seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görselin nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Bir Görseli Ekle ve Biçimlendir**

Gömülü bir görsel için, görsel verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemini kullanın. Görsel sunum paketinin bir parçası haline gelir, bu sayede sunum başka bir bilgisayara taşındığında kendine yeterli olur.

Aşağıdaki örnek bir JPEG görseli ekler, görselin yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile döndürmeyi uygular:

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

Resim çerçevesi gösterilen geometrileri kontrol eder; çerçeve boyutunun değiştirilmesi gömülü görsel kaynağındaki orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görseli kırpma veya sıkıştırma gerektiğinde önem kazanır.

## **Göreli Ölçek Kullanımı**

[IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) çerçeve için göreli genişlik ve yükseklik ölçeklendirmesini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) aracılığıyla sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak resim boyutuyla ilişkisini koruması gerektiğinde kullanışlıdır.

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

Göreli ölçek, çerçevenin ölçek ayarlarını değiştirir; gömülü görseli yeniden örnekleme veya sıkıştırma yapmaz.

## **Gömülü ve Bağlı Görseller**

Gömülü bir resim, görsel verisini sunum içinde depolar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli tercihtir. Bağlı bir resim, görsel verisini aynı şekilde gömmek yerine [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) yöntemiyle harici bir konuma işaret eder.

Bağlı görseller PPTX içinde depolanan görsel veri miktarını azaltabilir, ancak harici bir bağımlılık getirir. Bağlı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak kullanılamazsa, bağlı resim beklendiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda render edilmesi gereken sunumlar için gömülü görseller genellikle daha güvenilirdir.

### **Bağlı Bir Görsel Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve yerel bir resim dosyasına işaret eder. Yalnızca görsel bağlamayı gösterir; video bağlaması ayrı bir medya iş akışıdır ve bu örneğe kasten eklenmemiştir.

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

Harici dosya yönetimi kasıtlıysa bağlamaları kullanın. Sıkıştırmanın yerine sadece bir alternatif olarak kullanmayın: kırık görsel bağımlılıkları olan küçük bir PPTX, daha büyük, kendine yeterli bir sunumdan genellikle daha az yararlıdır.

## **Resimleri Resim Çerçevelerinden Çıkarma**

Mevcut bir sunumdan bir görsel çıkarmadan önce, şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) olup olmadığını ve gömülü bir görsel içerdiğini kontrol edin. Bağlı resim çerçeveleri, aynı şekilde çıkarılamayabilecek görüntü baytları içermeyebilir.

### **Raster Görsel Çıkarma**

Modern görsel API'si, eski Java görsel sarmalayıcısına ihtiyaç duymadan doğrudan [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) aracılığıyla kaydetmek, çıkarılan görseli istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytlara ihtiyaç duyarsanız, dönüştürülmüş raster dosya yerine görsel kaynağının ikili verisini kullanın.

### **SVG Görsel Çıkarma**

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarmalar bu vektör içeriği piksel olarak render eder. PDF veya SVG slayt dışa aktarması da bir render işlemi olduğundan, dışa aktarılan grafikler orijinal gömülü SVG'nin bayt‑bayt kopyası olarak değerlendirilmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/#getSvgData--) verisi kullanılmalıdır.

## **Bir Görseli Kırpma**

Kırpma, çerçeve içinde hangi kısmın görünür olduğunu değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görselin boyutlarının yüzde olarak ifade edilmesidir. Kırpma, gömülü görseldeki gizli pikselleri başlangıçta silmez; yalnızca görünür bölgeyi değiştirir.

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

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, kırpılmış bölgeler sonraki bölümde fiziksel olarak kaldırılabilir.

## **Kırpılmış Görsel Verisini Kaldırma**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini kaldırır ve sonuçtaki görsel kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir "uncrop" işlemi için artık kullanılamaz.

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

Yöntem, sunuma yeni bir görsel kaynağı ekleyebilir. Orijinal görsel başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçevelerin hâlâ mevcut kaynaklarına ihtiyacı vardır; bu nedenle kırpılmış alanların silinmesi mutlaka toplam görsel sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Görselleri Sıkıştırma**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) görüntünün, resmin gösterildiği boyuta göre çözünürlüğünü azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görsel yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik gerekmediyse `false` döndürür.

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

Belirli bir hedef gerektiğinde önceden tanımlı bir değer yerine özel pozitif DPI değeri geçirilebilir.

Sıkıştırma raster görseller için tasarlanmıştır. SVG ve metafile içerikleri bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca, düşük çözünürlük ve silinmiş kırpılmış bölgeler optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, görüntünün aslında görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; tüm sunumda en düşük DPI’yı uygulamayın.

## **Görsel Dönüşüm Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklık, alfa efektleri, sıralı zincirler, inceleme, kaldırma ve çift yönlü doğrulama gibi tam bir iş akışı için [Image Transform Effects](/java/image-transform-effects/) bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) şeklin yeniden boyutlandırılırken oranının korunmasını sağlar.

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

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu "stretch" olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içeri, negatif yüzde değerleri dışarı doğru bir genişleme oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görünür olduğunu seçerken; stretch offset’ler, görünür resim doldurmasının hangi dikdörtgene gerileceğini değiştirir.

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

Doldurma konumlandırması için stretch offset’leri kullanın. Kaynak görüntünün kenarlarını gizlemek amaçlıysa kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görsel depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel ödünleşimler daha kolay yönetilir:

- **Gömülü görseller** sunumu kendine yeterli hâle getirir ve paylaşım ile sunucu‑tarafı render için en güvenilir olandır; ancak büyük raster görseller PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlı görseller** paketi daha küçük tutabilir, ancak sunum, depolanan yollar veya konumlardaki dış dosyaların ulaşılabilir olmasına bağımlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görseller için dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Görselin slayt üzerindeki nihai boyutu bilindikten sonra uygulanmalıdır.
- **SVG görseller** vektör korumanın önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılmalıdır. Raster slayt dışa aktarmaları her zaman slaytı piksellere dönüştürür.
- **Tekrarlanan görseller**, mümkün olduğunca aynı [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) kaynağını yeniden kullanmalı, aynı dosyayı tekrar‑tekrar sunuma yüklemek yerine.

Büyük sunumlar için görsel optimizasyonu genellikle seçici olarak yapıldığında en etkili olur: logolar ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca daha sonraki düzenleme gerekmiyorsa kaldırın ve dış bağlantıları yalnızca bağımlılık yönetimi dağıtım tasarımının bir parçasıysa kullanın.

## **SSS**

**Bir resim çerçevesi ile görsel kaynağı arasındaki fark nedir?**

[IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) sunumla ilişkili bir görsel kaynağı temsil eder. [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) ise bir slayttaki resmi gösteren ve çerçeve‑düzeyi geometri ve biçimlendirmeyi (boyut, döndürme, kırpma değerleri, efektler, kilitlemeler) saklayan bir şekildir.

**Görselleri gömmeli mi yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görselleri gömün. Görselleri dışarıda tutmak kasıtlıysa ve dış konumlar güvenilir bir şekilde yönetilebiliyorsa sadece bağlayın; sıkıştırma yerine bir alternatif olarak kullanmayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden değildir. Normal kırpma ayarları, kaynak görselin bir kısmını gizler ancak altında yatan pikselleri tutar. Bu pikselleri kalıcı olarak kaldırmak için [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) veya kırpılmış alanların kaldırıldığı görüntü sıkıştırmasını kullanın.

**Sıkıştırmadan sonra görsel kalitesi geri getirilebilir mi?**

Hayır. Sıkıştırma depolanan raster çözünürlüğü azaltır ve kırpılmış bölgelerin kaldırılması görsel veriyi siler. Daha sonraki yüksek çözünürlükli düzenleme gerekebilecekse orijinal kaynak görseli sunum dışında tutun.

**SVG görseller nasıl işlenmelidir?**

Vektör doğruluğu önemliyse SVG içeriğini SVG olarak tutun. Gömülü [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) doğrudan çıkarılabilir. Bir slaytı PNG veya JPEG gibi raster formata render etmek, SVG’yi slayt görüntüsünün bir parçası olarak piksele dönüştürür.

**Mevcut slaytları okurken güvenli olmayan tip dönüşümlerinden nasıl kaçınılır?**

Şekil tipini, resim‑çerçevesi‑özelliği kullanmadan önce kontrol edin. [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) karşısında bir `instanceof` kontrolü, geçersiz dönüşümleri önler ve resim çerçevesi içermeyen slaytların kod tarafından düzgün şekilde işlenmesini sağlar.