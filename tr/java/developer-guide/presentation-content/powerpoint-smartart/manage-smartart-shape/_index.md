---
title: Java Kullanarak Sunumlarda SmartArt Grafiklerini Yönetin
linktitle: SmartArt Grafikler
type: docs
weight: 20
url: /tr/java/manage-smartart-shape/
keywords:
- SmartArt nesnesi
- SmartArt görseli
- SmartArt stili
- SmartArt rengi
- SmartArt oluştur
- SmartArt ekle
- SmartArt düzenle
- SmartArt değiştir
- SmartArt eriş
- SmartArt düzen türü
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java'da Aspose.Slides kullanarak PowerPoint SmartArt oluşturma, düzenleme ve stil verme işlemlerini otomatikleştirin; özlü kod örnekleri ve performansa odaklı rehberlik sunar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında SmartArt grafiklerini programlı olarak oluşturmanıza ve yönetmenize olanak tanır. Bu makale, bir slayta SmartArt şekli eklemeyi, mevcut SmartArt şekillerine erişmeyi, belirli bir düzen türüne göre SmartArt bulmayı ve SmartArt stilini veya renk stilini değiştirerek görsel görünümünü güncellemeyi açıklar.

Örnekler, sunum slaytının şekil koleksiyonu üzerinden SmartArt şekilleriyle nasıl çalışılacağını, bir şeklin SmartArt olup olmadığını nasıl kontrol edeceğinizi ve ardından özelliklerini nasıl değiştireceğinizi veya inceleyeceğinizi gösterir.

## **SmartArt Şekli Oluşturma**
Aspose.Slides for Java, SmartArt şekilleri oluşturmak için bir API sağlamaktadır. Bir slaytta SmartArt şekli oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaytın indeksini kullanarak slayt referansını alın.
1. [LayoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType) ayarlayarak bir SmartArt şekli [Add a SmartArt shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-).
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
// Sunum sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt şekli ekle
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Sunumu kaydediyor
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Slayta eklenen SmartArt şekli**|

## **Bir Slayttaki SmartArt Şekline Erişme**
Aşağıdaki kod, sunum slaydına eklenen SmartArt şekillerine erişmek için kullanılacaktır. Örnek kodda, slayt içindeki her şekli dolaşacak ve şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt) şekli olup olmadığını kontrol edeceğiz. Şekil SmartArt tipindeyse, onu [**SmartArt**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt) örneğine tip dönüştüreceğiz.

```java
// İstenen sunumu yükle
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (shape instanceof ISmartArt)
        {
            // Şekli SmartArtEx tipine dönüştür
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Belirli Bir Düzen Türüne Sahip SmartArt Şekline Erişme**
Aşağıdaki örnek kod, belirli bir LayoutType’a sahip [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt) şekline erişmenize yardımcı olur. LayoutType’ın yalnızca SmartArt şekli eklendiğinde ayarlandığını ve yalnızca okunabilir olduğunu unutmayın; değiştirilemez.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
1. Slaytın indeksini kullanarak ilk slayt referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt’a tip dönüştürün.
1. Belirli LayoutType’a sahip SmartArt şekli kontrol edin ve ardından gerekli işlemleri yapın.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (shape instanceof ISmartArt)
        {
            // Şekli SmartArtEx tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt düzenini kontrol ediyor
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
Bu örnekte, herhangi bir SmartArt şekli için hızlı stili nasıl değiştireceğimizi öğreneceğiz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
1. Slaytın indeksini kullanarak ilk slayt referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt’a tip dönüştürün.
1. Belirli bir Stil’e sahip SmartArt şekli bulun.
1. SmartArt şekli için yeni Stili ayarlayın.
1. Sunumu kaydedin.

```java
// Sunum sınıfını örnekleyin
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArtEx tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt stilini kontrol ediyor
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt stilini değiştir
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Sunumu kaydediyor
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Stili değiştirilmiş SmartArt şekli**|

## **SmartArt Şekli Renk Stilini Değiştirme**
Bu örnekte, herhangi bir SmartArt şekli için renk stilini nasıl değiştireceğimizi öğreneceğiz. Aşağıdaki örnek kod, belirli bir renk stiline sahip SmartArt şekline erişir ve stilini değiştirir.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
1. Slaytın indeksini kullanarak ilk slayt referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt’a tip dönüştürün.
1. Belirli bir Renk Stiline sahip SmartArt şekli bulun.
1. SmartArt şekli için yeni Renk Stilini ayarlayın.
1. Sunumu kaydedin.

```java
// Sunum sınıfını örnekleyin
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArtEx tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt renk tipini kontrol ediyor
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt renk tipini değiştir
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Sunumu kaydediyor
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Şekil: Renk Stili değiştirilmiş SmartArt şekli**|

## **SSS**

**SmartArt’ı tek bir nesne olarak canlandırabilir miyim?**

Evet. SmartArt bir şekildir, bu yüzden diğer şekillerde olduğu gibi animasyon API’si aracılığıyla [standart animasyonlar](/slides/tr/java/powerpoint-animation/) (giriş, çıkış, vurgulama, hareket yolları) uygulayabilirsiniz.

**İç kimliğini bilmediğim bir SmartArt’ı slaytta nasıl bulabilirim?**

Alternatif Metni (AltText) ayarlayın ve şekli bu değerle arayın—bu, hedef şekli bulmak için önerilen bir yöntemdir.

**SmartArt’ı diğer şekillerle gruplayabilir miyim?**

Evet. SmartArt’ı diğer şekiller (resimler, tablolar vb.) ile gruplayabilir ve ardından grubu [manipüle edebilirsiniz](/slides/tr/java/group/).

**Belirli bir SmartArt’ın görselini (ör. önizleme veya rapor için) nasıl alabilirim?**

Şeklin bir küçük resim/görselini dışa aktarın; kütüphane, tek tek şekilleri raster dosyalara (PNG/JPG/TIFF) [render edebilir](/slides/tr/java/create-shape-thumbnails/).

**Tüm sunumu PDF’ye dönüştürdüğümde SmartArt görünümü korunur mu?**

Evet. Render motoru, [PDF dışa aktarma](/slides/tr/java/convert-powerpoint-to-pdf/) için yüksek sadakat hedefler ve çeşitli kalite ve uyumluluk seçenekleri sunar.