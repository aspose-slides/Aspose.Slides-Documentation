---
title: Java Kullanarak Sunumlarda Görsel Yönetimini Optimize Etme
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/java/image/
keywords:
- görsel ekle
- resim ekle
- görseli değiştir
- görsel koleksiyonu
- resim çerçevesi
- bağlantılı görsel
- arkaplan
- PNG ekle
- JPG ekle
- SVG ekle
- SVG'den şekillere
- harici SVG kaynakları
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarında raster ve SVG görselleri ekleme, yeniden kullanma, bağlama, değiştirme ve yönetme konularını öğrenin."
---
## **Giriş**

Aspose.Slides for Java, görüntülerle çalışmanın çeşitli yollarını sunar ve her biri farklı bir amaca hizmet eder. Bir görüntüyü bir sunumda saklayabilir, bir resim çerçevesinde görüntüleyebilir, slayt arka planı olarak kullanabilir, harici bir görüntüye bağlayabilir, paylaşılan bir görüntü kaynağını değiştirebilir veya SVG içeriğini düzenlenebilir şekillere dönüştürebilirsiniz.

Bu makale görüntü kaynaklarına ve bunların bir sunum içinde nasıl kullanıldığına odaklanır. Bir resim çerçevesine uygulanan kırpma, şeffaflık, efektler, uzatma ve diğer biçimlendirme işlemleri için lütfen [Picture Frame](/slides/tr/java/picture-frame/) sayfasına bakın.

## **Görüntü Modelini Anlama**

Aşağıdaki API kavramları birbirine yakındır ancak değiştirilebilir değildir:

- [Sunum görüntü koleksiyonu](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagecollection/) sunum tarafından kullanılan görüntü kaynaklarını depolar. Görüntü verisini eklemek ve bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) kaynağı elde etmek için [ImageCollection.addImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imagecollection/) kullanın.
- Bir [picture frame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) bir şekildir ve bir slayt, yerleşim ya da ana sayfada görüntüyü gösterir. Bir görüntü kaynağını slayta yerleştirmek için [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/) kullanın.
- Bir slayt arka planı, görüntüyü şekil olarak değil slayt dolgusunun bir parçası olarak kullanır. Bu nedenle bir resim çerçevesi gibi davranmaz.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) bir görüntü kaynağını değiştirir. Eğer birkaç sunum öğesi bu kaynağı kullanıyorsa, hepsi değiştirilen kaynağı kullanır.
- Bir SVG'nin şekillere dönüştürülmesi, düzenlenebilir slayt şekilleri oluşturur. Dönüştürmeden sonra içerik artık tek bir resim kaynağı olarak yönetilmez.

Bu nedenle tipik bir iş akışı şu şekildedir: görüntü verisini görüntü koleksiyonuna ekleyin, bir [IPPImage] alın ve ardından bu kaynağı bir veya daha fazla resim çerçevesinde veya dolgu içinde kullanın.

## **Gömülü Görüntü Ekleme**

Yerel bir görüntüyü eklemek için dosyayı yükleyin, görüntü koleksiyonuna ekleyin ve döndürülen `IPPImage`'ı kullanan bir resim çerçevesi oluşturun.

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

Bu şekilde eklenen görüntü sunuma gömülüdür, böylece ortaya çıkan dosya özgün görüntü dosyasının mevcut olmasına bağlı değildir.

### **Web'den Görüntü Ekleme**

Bir görüntü HTTP veya HTTPS üzerinden erişilebilir olduğunda, baytlarını indirin, sunum görüntü koleksiyonuna ekleyin ve döndürülen görüntü kaynağını yerel bir görüntü gibi aynı şekilde kullanın.

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

Uzun süre çalışan uygulamalarda, gereksiz ağ altyapısı oluşturmak yerine uygulamaya uygun bir HTTP istemcisi ya da bağlantı yönetim stratejisini yeniden kullanın. Ayrıca kaynak güvenilir değilse uzak URL'leri, yanıt boyutlarını ve içerik türlerini doğrulayın.

## **Slaytlar Arasında Görüntüleri Yeniden Kullanma**

Aynı görüntü birden fazla kez gerektiğinde, görüntüyü sunuma bir kez ekleyin ve ek resim çerçeveleri oluştururken döndürülen [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) kullanın. Bu, aynı kaynak verisinin tekrarlı yüklenmesini önler ve paylaşılan görüntü kaynağı ile kullanımları arasındaki ilişkiyi açıkça gösterir.

Bir firma logosu gibi birçok slaytta otomatik olarak görünmesi gereken grafikler için, her slayta eşdeğer bir şekil eklemek yerine resmi bir [slide master](/slides/tr/java/slide-master/) ya da yerleşime yerleştirmeyi düşünün.

## **Görüntüyü Slayt Arka Planı Olarak Kullanma**

Bir arka plan görüntüsü slayt doldurmasına atanır; resim çerçevesi şekli olarak eklenmez. Bu, resmin slayt arka planını kaplaması ve normal bir slayt nesnesi gibi manipüle edilmemesi gerektiğinde kullanışlıdır.

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

Ana sayfa ve yerleşim arka planları dahil ek arka plan seçenekleri için [Presentation Background](/slides/tr/java/presentation-background/) sayfasına bakın.

## **Gömülü Görüntüler ve Bağlantılı Görüntüler**

Gömülü ve bağlantılı görüntülerin taşınabilirlik ve dosya boyutu açısından farklı ticaret-offları vardır:

- **Gömülü görüntü:** görüntü verisi sunum içinde depolanır. Sunum bağımsızdır, ancak dosya boyutu görüntü verisini içerir.
- **Bağlantılı görüntü:** sunum, harici bir görüntünün yolunu ya da URL'sini depolar. Bu, sunum boyutunu azaltabilir, ancak harici kaynak sunum açıldığında veya oluşturulduğunda erişilebilir olmalıdır.

Bir bağlantılı resim, görüntü verisini gömmek yerine dış yol veya URL'yi [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidespicture/) aracılığıyla atayarak oluşturulabilir.

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

Bağlantılı görüntüleri yalnızca dağıtım ortamı harici kaynağa güvenilir bir şekilde erişebildiğinde kullanın. Çevrimdışı çalışması veya sistemler arasında taşınması gereken sunumlar için gömülü görüntüler genellikle daha güvenlidir.

## **SVG Görüntülerle Çalışma**

SVG, vektör bir format olduğu için ikonlar, diyagramlar ve raster görüntüler gibi detay kaybı olmadan ölçeklenmesi gereken diğer grafikler için faydalı olabilir. Aspose.Slides, SVG'yi hem bir görüntü kaynağı hem de düzenlenebilir slayt şekilleri için bir kaynak olarak destekler.

### **SVG'yi Görüntü Olarak Ekleme**

Bir [SvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgimage/) oluşturun, bunu görüntü koleksiyonuna ekleyin ve ortaya çıkan görüntü kaynağını bir resim çerçevesine yerleştirin.

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

### **Harici Kaynaklı SVG Dosyaları**

Bir SVG, harici görüntüler, stil sayfaları veya yazı tiplerine referans verebilir. Bu durumlar için, [SvgImage] bir [IExternalResourceResolver] ve temel bir URI kabul eden kurucular sağlar. Çözücü, göreli bir URI'yı izin verilen mutlak bir URI'ye eşleyebilir ve istenen kaynak için bir akış döndürebilir.

Çözücü, Aspose.Slides SVG'yi işlerken harici kaynakları kullanılabilir kılar, ancak SVG'yi bağımsız bir belgeye dönüştürmez. SVG'nin taşınabilir kalması gerekiyorsa, gerekli kaynakları SVG içinde gömün; örneğin bağlantılı görüntüler için `data:` URI'lerini kullanın.

SVG dosyaları güvensiz kaynaklardan geldiğinde, çözücünün erişebileceği şemaları, dosya konumlarını ve hostları kısıtlayın. Ağ çözücüleri ayrıca zaman aşımı, yanıt boyutu sınırları ve içerik doğrulaması uygulamalıdır.

### **SVG'yi Düzenlenebilir Şekillere Dönüştürme**

Aspose.Slides, bir SVG'yi ilgili PowerPoint komutuna benzer şekilde düzenlenebilir slayt şekilleri grubuna dönüştürebilir.

![PowerPoint Açılır Menüsü](img_01_01.png)

Dönüşümü gerçekleştirmek için bir [ISvgImage] kabul eden [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/) aşırı yüklemesini kullanın.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bireysel vektör öğelerinin PowerPoint şekilleri olarak düzenlenmesi gerektiğinde SVG'den şekillere dönüşümü kullanın. SVG yalnızca gösterilmesi gerekiyorsa, onu bir görüntü olarak tutmak daha basittir ve birçok ayrı şekil oluşturulmasını önler.

## **Mevcut Bir Görüntü Kaynağını Değiştirme**

Mevcut bir görüntü kaynağını değiştirmek istediğinizde [IPPImage.replaceImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) kullanın. Bu, logolar gibi paylaşılan grafikler için özellikle yararlıdır.

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

Birden fazla resim çerçevesi, arka plan, ana sayfa veya yerleşim aynı görüntü kaynağını kullanıyorsa, kaynağın değiştirilmesi tüm bu kullanımları günceller. Yalnızca bir resim çerçevesinin değişmesi gerekiyorsa, paylaşılan kaynağı değiştirmek yerine o çerçeveye farklı bir görüntü atayın.

`replaceImage` ayrıca bir bayt dizisi ya da başka bir [IPPImage] kabul eden aşırı yüklemeler de sunar.

## **Pratik Görüntü Yönetimi Rehberi**

### **Sunum Boyutunu Kontrol Etme**

Büyük raster görüntüler bir sunumu gereksiz yere büyük yapabilir. Kaynak görüntüleri, hedef gösterim boyutlarıyla uyumlu boyutlarda kullanın, mümkün olduğunda paylaşılan görüntü kaynaklarını yeniden kullanın ve aynı tam çözünürlükteki grafiklerin tekrarlanan kopyalarını gömmekten kaçının.

Zaten resim çerçevelerine yerleştirilmiş raster resimler için, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) seçilen çözünürlük ve kırpma ayarlarına göre görüntü verisini azaltabilir. Bu, görüntü koleksiyonu yönetimi değil, resim çerçevesi işleme olduğundan, ilgili biçimlendirme işlemleri için [Picture Frame](/slides/tr/java/picture-frame/) sayfasına bakın.

### **Gömülü ve Bağlantılı İçerik Arasında Seçim Yapma**

Gömme, tüm gerekli görüntü verisinin dosyayla birlikte gitmesi nedeniyle sunumu taşınabilir kılar. Bağlantı dosya boyutunu azaltabilir, ancak dış bir bağımlılık getirir. Bağlantıları yalnızca bu bağımlılık kabul edilebilir ve istikrarlı olduğunda kullanın.

### **Paylaşılan Marka Unsurlarını Yeniden Kullanma**

Tekrarlanan logolar, filigranlar veya dekoratif grafikler için tek bir görüntü kaynağı kullanın ve yeniden kullanın. Grafik, slayt içeriği yerine sunum tasarımına aitse, uygun slaytlar tarafından devralınması için bir ana sayfa ya da yerleşime yerleştirin.

### **SVG Kaynaklarını Taşınabilir Tutma**

Bağımsız bir SVG, harici dosyalara veya ağ kaynaklarına bağımlı bir SVG'ye göre taşınması ve tutarlı render edilmesi daha kolaydır. Mümkün olduğunda, SVG'yi içe aktarmadan önce gerekli kaynakları gömün. SVG'yi şekillere yalnızca bireysel vektör öğelerinin düzenlenmesi gerektiğinde dönüştürün.

### **Modern Çapraz Platform Görüntü API'sini Kullanma**

Yeni Java kodu için, `java.awt.image.BufferedImage` tabanlı eski genel API yerine Aspose.Slides [IImage] ve [Images] API'lerini kullanın. Geçiş rehberi için [Modern API](/slides/tr/java/modern-api/) sayfasına bakın.

WMF ve EMF özel bir dikkate ihtiyaç duyar. Bu formatlar bir [IImage] üzerinden geçirildiğinde, [ImageCollection.addImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imagecollection/) eklemeden önce metafili bir raster PNG temsiline dönüştürür. Metafili veriyi korumak önemliyse, akış tabanlı bir [ImageCollection.addImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imagecollection/) aşırı yüklemesi kullanın. Elektronik tablolardan veya diğer ürünlerden EMF içeriği üretmek ayrı bir entegrasyon iş akışıdır ve bu makalenin kapsamı dışındadır.

## **SSS**

**Görüntü koleksiyonu ile resim çerçevesi arasındaki fark nedir?**

Görüntü koleksiyonu, tekrar kullanılabilir görüntü kaynaklarını depolar. Bir resim çerçevesi, bu kaynaklardan birini gösteren bir slayt şeklidir ve kırpma ve efektler gibi resme özgü biçimlendirme sağlar.

**Aynı logoyu her yerde değiştirmek için en iyi yol nedir?**

Logo zaten tek bir görüntü kaynağı olarak paylaşılıyorsa, bu kaynağı [IPPImage.replaceImage] ile değiştirin. Sunum genelinde marka için logoyu bir ana sayfa ya da yerleşime yerleştirmek de yinelenen slayt içeriğini azaltabilir.

**Bağlantılı bir görüntü başka bir bilgisayarda neden kaybolur?**

Bağlantılı bir resim, dış dosya veya URL'ye bağlıdır. Bu kaynak diğer bilgisayardan erişilemezse, bağlantılı görüntü bulunamayabilir. Sunumun bağımsız olması gerektiğinde görüntüyü gömün.

**Eklenen bir SVG PowerPoint şekilleri olarak düzenlenebilir mi?**

Evet. SVG'yi [IShapeCollection.addGroupShape] ile dönüştürün; ortaya çıkan grup tek bir SVG resim yerine düzenlenebilir slayt şekilleri içerir.

**Birçok görüntülü sunumları nasıl daha küçük tutabilirim?**

Paylaşılan görüntü kaynaklarını yeniden kullanın, gereksiz büyük raster kaynaklardan kaçının, uygun olduğunda raster resimleri sıkıştırın, tekrarlanan markayı ana sayfalarda ya da yerleşimlerde tutun ve dış bağımlılık kabul edilebilir olduğunda yalnızca bağlantılı görüntüler kullanın.