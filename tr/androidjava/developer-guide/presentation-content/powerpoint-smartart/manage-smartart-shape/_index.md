---
title: Android'de Sunumlarda SmartArt Grafiklerini Yönetin
linktitle: SmartArt Grafikler
type: docs
weight: 20
url: /tr/androidjava/manage-smartart-shape/
keywords:
- SmartArt nesnesi
- SmartArt grafiği
- SmartArt stili
- SmartArt rengi
- SmartArt oluştur
- SmartArt ekle
- SmartArt düzenle
- SmartArt değiştir
- SmartArt eriş
- SmartArt yerleşim tipi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak PowerPoint SmartArt oluşturma, düzenleme ve stillendirmeyi otomatikleştirin; özlü Java kod örnekleri ve performansa odaklı rehberlik sunar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında SmartArt grafiklerini programmatically oluşturmanıza ve yönetmenize olanak tanır. Bu makale, bir SmartArt şekli eklemeyi, mevcut SmartArt şekillerine erişmeyi, belirli bir yerleşim türüne göre SmartArt bulmayı ve SmartArt stilini veya renk stilini değiştirerek görsel görünümünü güncellemeyi açıklar.

Örnekler, sunum slaytının şekil koleksiyonu aracılığıyla SmartArt şekilleriyle nasıl çalışılacağını, bir şeklin SmartArt olup olmadığını kontrol etmeyi ve ardından özelliklerini değiştirmeyi veya incelemeyi gösterir.

## **SmartArt Şekli Oluşturma**
Aspose.Slides for Android via Java, SmartArt şekilleri oluşturmak için bir API sağlamaktadır. Bir slaytta SmartArt şekli oluşturmak için lütfen aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı örneği oluşturun.
2. Slaytın indeksini kullanarak bir slayt referansı alın.
3. [SmartArt şekli ekleyin](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) by setting it [LayoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType).
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```java
// Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Smart Art şekli ekle
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Sunumu kaydet
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Slayta eklenen SmartArt şekli**|

## **Bir Slayttaki SmartArt Şekline Erişme**
Aşağıdaki kod, sunum slaydına eklenen SmartArt şekillerine erişmek için kullanılacaktır. Örnek kodda, slayt içindeki her şekli dolaşacak ve bunun bir [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) şekli olup olmadığını kontrol edeceğiz. Şekil SmartArt tipindeyse, onu [**SmartArt**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) örneğine tip dönüştüreceğiz.

```java
// İstenen sunumu yükle
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // İlk slayttaki tüm şekillerde dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (shape instanceof ISmartArt)
        {
            // Şekli SmartArtEx'e tip dönüştür
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Belirli Bir Yerleşim Türüne Sahip SmartArt Şekline Erişme**
Aşağıdaki örnek kod, belirli bir LayoutType'a sahip [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) şekline erişmenize yardımcı olacaktır. Lütfen SmartArt'ın LayoutType'ını değiştiremeyeceğinizi, bunun yalnızca okunabilir olduğunu ve [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) şekli eklendiğinde ayarlandığını unutmayın.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı örneği oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
2. İlk slaydın referansını indeksini kullanarak alın.
3. İlk slayt içindeki her şekli dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt'a tip dönüştürün.
5. Belirli LayoutType'a sahip SmartArt şeklinin kontrolünü yapın ve ardından gerekli işlemleri gerçekleştirin.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // İlk slayttaki tüm şekillerde dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (shape instanceof ISmartArt)
        {
            // Şekli SmartArtEx'e tip dönüştür
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt yerleşimini kontrol et
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt Şekli Stilini Değiştirme**
Bu örnekte, herhangi bir SmartArt şekli için hızlı stili değiştirmeyi öğreneceğiz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı örneği oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
2. İlk slaydın referansını indeksini kullanarak alın.
3. İlk slayt içindeki her şekli dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt'a tip dönüştürün.
5. Belirli bir Stil'e sahip SmartArt şekli bulun.
6. SmartArt şekli için yeni Stil'i ayarlayın.
7. Sunumu kaydedin.

```java
// Presentation sınıfını örnekle
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayttaki tüm şekillerde dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArtEx'e tip dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt stilini kontrol et
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt stilini değiştir
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Sunumu kaydet
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Stili değiştirilen SmartArt şekli**|

## **SmartArt Şekli Renk Stili Değiştirme**
Bu örnekte, herhangi bir SmartArt şekli için renk stilini değiştirmeyi öğreneceğiz. Aşağıdaki örnek kod, belirli bir renk stiline sahip SmartArt şekline erişecek ve stilini değiştirecektir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı örneği oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
2. İlk slaydın referansını indeksini kullanarak alın.
3. İlk slayt içindeki her şekli dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt'a tip dönüştürün.
5. Belirli bir Renk Stil'ine sahip SmartArt şekli bulun.
6. SmartArt şekli için yeni Renk Stili'ni ayarlayın.
7. Sunumu kaydedin.

```java
// Presentation sınıfını örnekle
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayttaki tüm şekillerde dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArtEx'e tip dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt renk tipini kontrol et
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt renk tipini değiştir
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Sunumu kaydet
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Şekil: Renk Stili değiştirilen SmartArt şekli**|

## **SSS**

**SmartArt'ı tek bir nesne olarak animasyon ekleyebilir miyim?**

Evet. SmartArt bir şekildir, bu nedenle diğer şekillerde olduğu gibi animasyon API'si üzerinden [standart animasyonlar](/slides/tr/androidjava/powerpoint-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilirsiniz.

**Bir slaytta belirli bir SmartArt'ı iç ID'sini bilmiyorsam nasıl bulabilirim?**

Alternatif Metni (AltText) ayarlayın ve kullanın, ardından şekli bu değerle arayın — bu, hedef şekli bulmanın önerilen bir yoludur.

**SmartArt'ı diğer şekillerle gruplayabilir miyim?**

Evet. SmartArt'ı diğer şekillerle (resimler, tablolar vb.) gruplayabilir ve ardından [grubu yönet](/slides/tr/androidjava/group/) işlemini yapabilirsiniz.

**Belirli bir SmartArt'ın (ör. önizleme veya rapor için) görüntüsünü nasıl alabilirim?**

Şeklin bir küçük resmini/görselini dışa aktarın; kütüphane, [tek tek şekilleri render eder](/slides/tr/androidjava/create-shape-thumbnails/) (PNG/JPG/TIFF) raster dosyalarına dönüştürebilir.

**Tüm sunumu PDF'ye dönüştürürken SmartArt görünümü korunacak mı?**

Evet. Render motoru, [PDF dışa aktarımı](/slides/tr/androidjava/convert-powerpoint-to-pdf/) için yüksek doğruluk hedefler ve çeşitli kalite ve uyumluluk seçenekleri sunar.