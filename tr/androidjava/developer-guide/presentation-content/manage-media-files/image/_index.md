---
title: Android Sunularında Görüntü Yönetimini Optimize Etme
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/androidjava/image/
keywords:
- görüntü ekle
- resim ekle
- görüntüyü değiştir
- görüntü koleksiyonu
- resim çerçevesi
- bağlantılı görüntü
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- SVG'den şekillere
- harici SVG kaynakları
- PowerPoint
- OpenDocument
- sunu
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument sunularında raster ve SVG görüntülerini eklemeyi, yeniden kullanmayı, bağlamayı, değiştirmeyi ve yönetmeyi öğrenin."
---
## **Giriş**

Aspose.Slides for Android via Java, görüntülerle çalışmak için çeşitli yollar sunar ve her biri farklı bir amaç hizmet eder. Bir görüntüyü sunuya depolayabilir, bir resim çerçevesinde görüntüleyebilir, slayt arka planı olarak kullanabilir, harici bir görüntüye bağlayabilir, paylaşılan bir görüntü kaynağını değiştirebilir veya SVG içeriğini düzenlenebilir şekillere dönüştürebilirsiniz.

Bu makale, görüntü kaynaklarına ve bunların bir sunu içinde nasıl kullanıldığına odaklanır. Bir resim çerçevesine uygulanan kırpma, şeffaflık, efektler, uzatma ve diğer biçimlendirmeler için, bakınız [Picture Frame](/slides/tr/androidjava/picture-frame/).

## **Görüntü Modelini Anlayın**

Aşağıdaki API kavramları yakından ilişkilidir ancak birbirinin yerine kullanılamaz:

- [presentation image collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagecollection/) sununun kullandığı görüntü kaynaklarını depolar. Görüntü verisini eklemek ve bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) kaynağı elde etmek için [ImageCollection.addImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imagecollection/) kullanın.
- Bir [picture frame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) bir slayt, düzen veya master üzerinde bir görüntüyü gösteren bir şekildir. Görüntü kaynağını bir slayta yerleştirmek için [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) kullanın.
- Bir slayt arka planı, görüntüyü bir şekil yerine slayt doldurmasının bir parçası olarak kullanır. Bu nedenle bir picture frame gibi davranmaz.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) bir görüntü kaynağını değiştirir. Birkaç sunu öğesi bu kaynağı kullanıyorsa, hepsi değiştirilmiş olanı kullanır.
- Bir SVG'yi şekillere dönüştürmek, düzenlenebilir slayt şekilleri oluşturur. Dönüştürmeden sonra içerik artık tek bir resim kaynağı olarak yönetilmez.

Tipik bir iş akışı şu şekildedir: görüntü verisini görüntü koleksiyonuna ekleyin, bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) alın ve ardından bu kaynağı bir veya daha fazla picture frame veya doldurma içinde kullanın.

## **Gömülü Görüntü Ekleme**

Yerel bir görüntü eklemek için, dosyayı yükleyin, görüntü koleksiyonuna ekleyin ve döndürülen `IPPImage` kullanan bir picture frame oluşturun.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu şekilde eklenen görüntü, sunuya gömülür, bu nedenle ortaya çıkan dosya, özgün görüntü dosyasının hâlâ mevcut olmasına bağlı değildir.

### **Web'den Görüntü Ekleme**

Bir görüntü HTTP veya HTTPS üzerinden erişilebilir olduğunda, baytlarını indirin, sunu görüntü koleksiyonuna ekleyin ve döndürülen görüntü kaynağını yerel görüntü gibi aynı şekilde kullanın.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uzun süren uygulamalarda, gereksiz ağ altyapısını tekrar tekrar oluşturmak yerine, uygulamaya uygun bir HTTP istemcisi veya bağlantı yönetim stratejisini yeniden kullanın. Ayrıca kaynak güvenilir değilse uzak URL'leri, yanıt boyutlarını ve içerik türlerini doğrulayın.

## **Slaytlar Arasında Görüntüleri Yeniden Kullanma**

Aynı görüntü birden fazla kez gerekliyse, görüntüyü sunuya bir kez ekleyin ve ek picture frame'ler oluştururken döndürülen [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) yeniden kullanın. Bu, aynı kaynak verisinin tekrar tekrar yüklenmesini önler ve paylaşılan görüntü kaynağı ile kullanım ilişkisini açık hale getirir.

Birçok slaytta otomatik olarak görünmesi gereken grafikler, örneğin bir şirket logosu, her slayta eşdeğer bir şekil eklemek yerine picture frame'i bir [slide master](/slides/tr/androidjava/slide-master/) veya düzen üzerine yerleştirmeyi düşünün.

## **Görüntüyü Slayt Arka Planı Olarak Kullanma**

Bir arka plan görüntüsü slayt doldurmasına atanır; picture-frame şekli olarak eklenmez. Bu, görüntünün slayt arka planını kaplaması ve normal bir slayt nesnesi gibi işlenmemesi gerektiğinde kullanışlıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Master ve düzen arka planları dahil ek arka plan seçenekleri için, bakınız [Presentation Background](/slides/tr/androidjava/presentation-background/).

## **Gömülü Görüntüler ve Bağlantılı Görüntüler**

Gömülü ve bağlantılı görüntülerin taşınabilirlik ve dosya boyutu açısından farklı denge noktaları vardır:

- **Embedded image:** görüntü verisi sunu içinde depolanır. Sunu kendi kendine yeterlidir, ancak dosya boyutu görüntü verisini içerir.
- **Linked image:** sunu, harici bir görüntünün yolunu veya URL'sini saklar. Bu, sunu boyutunu azaltabilir, ancak dış kaynak, sunu açıldığında veya renderlanırken erişilebilir olmalıdır.

Bir bağlantılı resim, görüntü verisini gömmek yerine dış yolu veya URL'yi [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidespicture/) aracılığıyla atayarak oluşturulabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bağlantılı görüntüleri yalnızca dağıtım ortamı dış kaynağa güvenilir bir şekilde erişebildiğinde kullanın. Çevrim dışı çalışması veya sistemler arasında taşınması gereken sunular için gömülü görüntüler genellikle daha güvenlidir.

## **SVG Görüntüleriyle Çalışma**

SVG vektör formatıdır, bu nedenle ikonlar, diyagramlar ve raster görüntüler gibi ayrıntı kaybı olmadan ölçeklenmesi gereken diğer grafikler için faydalı olabilir. Aspose.Slides, SVG'yi hem bir görüntü kaynağı hem de düzenlenebilir slayt şekilleri kaynağı olarak destekler.

### **SVG'yi Görüntü Olarak Ekleme**

Bir [SvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgimage/) oluşturun, görüntü koleksiyonuna ekleyin ve ortaya çıkan görüntü kaynağını bir picture frame içinde yerleştirin.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dış Kaynaklı SVG Dosyaları**

Bir SVG, dış görüntüler, stil sayfaları veya yazı tiplerine referans verebilir. Bu durumlar için, [SvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgimage/) bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iexternalresourceresolver/) ve bir temel URI kabul eden yapıcılar sağlar. Çözücü, göreli bir URI'yi izin verilen mutlak bir URI'ye eşleyebilir ve istenen kaynak için bir akış döndürebilir.

Çözücü, Aspose.Slides SVG'yi işlerken dış kaynakları kullanılabilir kılar, ancak SVG'yi kendine yeterli bir belgeye yeniden yazmaz. SVG'nin taşınabilir kalması gerekiyorsa, gerekli kaynakları doğrudan SVG içinde gömün; örneğin bağlantılı görüntüler için `data:` URI'lerini kullanabilirsiniz.

SVG dosyaları güvenilmeyen kaynaklardan geldiğinde, çözücünün erişebileceği şemaları, dosya konumlarını ve hostları kısıtlayın. Ağ çözücüleri ayrıca zaman aşımı, yanıt boyutu limitleri ve içerik doğrulaması uygulamalıdır.

### **SVG'yi Düzenlenebilir Şekillere Dönüştürme**

Aspose.Slides, bir SVG'yi ilgili PowerPoint komutuna benzer şekilde düzenlenebilir slayt şekilleri grubuna dönüştürebilir.

![PowerPoint Popup Menu](img_01_01.png)

Dönüşümü gerçekleştirmek için bir [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) kabul eden [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) aşırı yüklemesini kullanın.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tek tek vektör öğelerinin PowerPoint şekilleri gibi düzenlenmesi gerektiğinde SVG'den şekillere dönüşümü kullanın. SVG yalnızca görüntülenmesi gerekiyorsa, onu bir görüntü olarak tutmak daha basittir ve birçok ayrı şekil oluşturmayı önler.

## **Mevcut Bir Görüntü Kaynağını Değiştirme**

Mevcut bir görüntü kaynağını değiştirmek istediğinizde [IPPImage.replaceImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) kullanın. Bu, logolar gibi paylaşılan grafikler için özellikle faydalıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Birden fazla picture frame, arka plan, master veya düzen aynı görüntü kaynağını kullanıyorsa, kaynağın değiştirilmesi bu kullanımların tümünü günceller. Sadece bir picture frame'in değişmesi gerekiyorsa, paylaşılan kaynağı değiştirmek yerine o frame'e farklı bir görüntü atayın.

`replaceImage` ayrıca bir bayt dizisi veya başka bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) kabul eden aşırı yüklemeler sağlar.

## **Uygulamalı Görüntü Yönetimi Rehberi**

### **Sunu Boyutunu Kontrol Etme**

Büyük raster görüntüler bir sunuyu gereksiz yere büyük yapabilir. Kaynak görüntüleri, amaçlanan gösterim boyutuna uygun boyutlarda kullanın, mümkün olduğunca paylaşılan görüntü kaynaklarını yeniden kullanın ve aynı tam çözünürlüklü grafiğin tekrar tekrar gömülmesinden kaçının.

Picture frame içinde zaten yerleştirilmiş raster resimler için, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) seçilen çözünürlük ve kırpma ayarlarına göre görüntü verisini azaltabilir. Bu, görüntü koleksiyonu yönetimi değil picture-frame işleme olduğundan, ilgili biçimlendirme işlemleri için [Picture Frame](/slides/tr/androidjava/picture-frame/) bölümüne bakın.

### **Gömülü ve Bağlantılı İçerik Arasından Seçim**

Gömme, sununun taşınabilir olmasını sağlar çünkü gerekli tüm görüntü verileri dosyayla birlikte taşınır. Bağlantı dosya boyutunu azaltabilir, ancak dış bir bağımlılık getirir. Bağlantıları, bu bağımlılığın kabul edilebilir ve istikrarlı olduğu durumlarda kullanın.

### **Paylaşılan Marka Unsurlarını Yeniden Kullanma**

Tekrarlanan logolar, filigranlar veya dekoratif grafikler için tek bir görüntü kaynağı kullanın ve yeniden kullanın. Grafik, slayt içeriği yerine sunu tasarımına aitse, ilgili slaytlar tarafından miras alınması için bir master veya düzen üzerine yerleştirin.

### **SVG Kaynaklarını Taşınabilir Tutma**

Kendine yeterli bir SVG, dış dosya veya ağ kaynaklarına bağımlı bir SVG'den daha kolay taşınabilir ve tutarlı olarak renderlanabilir. Mümkün olduğunda, SVG'yi içe aktarmadan önce gerekli kaynakları gömün. SVG'yi şekillere dönüştürmek, tek tek vektör öğelerinin düzenlenmesi gerektiğinde yapılmalıdır.

### **Modern Çapraz Platform Görüntü API'sını Kullanma**

Yeni Android via Java kodu için, `android.graphics.Bitmap` tabanlı eski genel API yerine Aspose.Slides [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) ve [Images](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/images/) API'lerini kullanın. Geçiş kılavuzu için [Modern API](/slides/tr/androidjava/modern-api/) bölümüne bakın.

WMF ve EMF özel bir dikkate ihtiyaç duyar. Bu formatlar bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) aracılığıyla geçirildiğinde, [ImageCollection.addImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imagecollection/) ekleme öncesinde metafili rastgele bir PNG temsiline dönüştürür. Metafile verisini korumak önemliyse, akış tabanlı bir [ImageCollection.addImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imagecollection/) aşırı yüklemesini kullanın. Elektronik tablo veya diğer ürünlerden EMF içeriği oluşturmak ayrı bir entegrasyon iş akışıdır ve bu makalenin kapsamı dışındadır.

## **SSS**

**Görüntü koleksiyonu ile picture frame arasındaki fark nedir?**

Görüntü koleksiyonu, yeniden kullanılabilir görüntü kaynaklarını depolar. Picture frame, bu kaynaklardan birini gösteren bir slayt şekli olup kırpma ve efektler gibi resme özgü biçimlendirme sağlar.

**Aynı logoyu her yerde değiştirmek için en iyi yol nedir?**

Logo zaten tek bir görüntü kaynağı olarak paylaşılıyorsa, o kaynağı [IPPImage.replaceImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) ile değiştirin. Sunu genelinde marka için, logoyu bir master veya düzen üzerine yerleştirmek, yinelenen slayt içeriğini de azaltabilir.

**Bağlantılı bir görüntü başka bir bilgisayarda neden kaybolur?**

Bağlantılı bir resim, dış dosya veya URL'ye bağlıdır. Bu kaynak diğer bilgisayardan erişilemezse, bağlantılı görüntü kullanılamaz olabilir. Sunu kendine yeterli olmalıysa görüntüyü gömün.

**Eklenen bir SVG PowerPoint şekilleri olarak düzenlenebilir mi?**

Evet. SVG'yi [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) ile dönüştürün; ortaya çıkan grup, tek bir SVG resmi yerine düzenlenebilir slayt şekilleri içerir.

**Çok sayıda görüntü içeren sunuları daha küçük nasıl tutabilirim?**

Paylaşılan görüntü kaynaklarını yeniden kullanın, gereksiz yere büyük raster kaynaklardan kaçının, uygun olduğunda raster resimleri sıkıştırın, tekrarlanan marka unsurlarını master veya düzenlerde tutun ve dış bağımlılık kabul edilebilir olduğunda yalnızca bağlantılı görüntüleri kullanın.