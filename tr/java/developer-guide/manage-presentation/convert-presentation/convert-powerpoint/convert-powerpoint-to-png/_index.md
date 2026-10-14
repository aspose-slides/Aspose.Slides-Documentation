---
title: Java'da PowerPoint Slaytlarını PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/java/convert-powerpoint-to-png/
keywords:
- PowerPoint'ı dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten PNG'ye
- sunumu PNG'ye
- slaytı PNG'ye
- PPT'yi PNG'ye
- PPTX'i PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarını yüksek kaliteli PNG görüntülerine hızlı bir şekilde dönüştürün, kesin ve otomatik sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Java kullanarak sunum slaytlarını PNG görüntülerine nasıl dönüştüreceğinizi açıklar. PPT, PPTX ve ODP gibi formatlarda sunumları yükleyebilir, her slaytı işleyebilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Aşağıdaki örnekler, varsayılan ölçekle işleme, ölçeği artırma, çıktının boyutlarını piksel olarak belirtme ve bir gradient işleme stilini seçme konularını gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bir sunumu [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı ile yükleyin ve slaytlarına [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) koleksiyonu aracılığıyla erişin. Örnek, her slaytı parametresiz olarak [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) çağırarak bir önizleme oluşturur. Ardından, her işlenen slaytı PNG görüntüsü olarak kaydetmek için [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) metodunu [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) ile çağırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Parametresiz [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) aşırı yüklemesi 0,2 ölçeğinde işler. Örneğin, 720 × 540 puan ölçüsündeki bir slayt 144 × 108 piksel önizleme üretir. Çıktı boyutlarını kontrol etmek için aşağıda gösterildiği gibi ölçek faktörleriyle veya açık bir görüntü boyutu ile aşırı yüklemeleri kullanın.
{{% /alert %}}

## **PowerPoint'i Özel Boyutlarla PNG'ye Dönüştür**

Yatay ve dikey ölçek faktörlerini [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) metoduna geçirerek işlenen boyutları kontrol edin. Bu örnekte, her iki faktör de 2 olduğundan, 720 × 540 puan ölçüsündeki bir slayt 1440 × 1080 piksel görüntü üretir. Eşit ölçek faktörleri slaytın en‑boy oranını korur. Her görüntü, [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ile PNG formatında kaydedilir.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint'i Özel Boyutla PNG'ye Dönüştür**

Çıktı boyutlarını piksel olarak belirtmek için ölçek faktörleri yerine [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) metoduna bir boyut gönderin. Bu örnek, her slaytı 960 × 720 piksel olarak işler ve sonucu [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ile kaydeder. Slaytın en‑boy oranına uygun boyutlar seçin, aksi takdirde görüntü uzar.
```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bir Gradient İşleme Stili Seçin**

Bir slayt gradient doldurmalar içerdiğini ve dışa aktarılan PNG'deki geçişlerin PowerPoint'te gördüklerinizden daha açık veya farklı göründüğünü varsayalım. [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) tarafından devralınan [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) metodunu kullanarak gradientlerin nasıl işleneceğini seçebilirsiniz.

[gradient-styles.pptx](gradient-styles.pptx) dosyasını indirin ve uygulamanın çalışma dizinine koyun. İlk slaytı, üstte camgöbeği‑turuncu ve altta mavi‑sarı olmak üzere iki lineer gradient içerir. Her gradientin iki durağı vardır: %0 ve %100.

Aşağıdaki örnek bu sunumu yükler ve aynı ilk slaytı iki modda da [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ile işler.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Aşağıdaki görüntüler aynı slayttan alınan çıktıyı gösterir, her görüntüde her iki gradient de vardır:

| Varsayılan | PowerPointUI |
| --- | --- |
| ![Varsayılan ile işlenmiş camgöbeği‑turuncu ve mavi‑sarı gradientler](gradient-Default.png) | ![PowerPointUI ile işlenmiş aynı gradientler](gradient-PowerPointUI.png) |

Bu örnekte, `Default` daha açık ara renkler üretirken, `PowerPointUI` daha koyu ara renkler üretir. Fark, gradientin renklerine ve duraklarına bağlıdır.

`Default` seçin, eğer standart Aspose.Slides çıktısı ihtiyaçlarınıza uygunsa. Görünümün PowerPoint ile eşleşmesi önceliğinizse `PowerPointUI` deneyin. Her iki çıktıyı da hedefinizle karşılaştırın; hiçbir mod evrensel olarak tercih edilebilir değildir.

## **SSS**

**Bir slaytın tamamı yerine bir grafik veya resim gibi belirli bir şekli nasıl dışa aktarabilirim?**

Aspose.Slides, [bireysel şekiller için önizleme oluşturmayı](/slides/tr/java/create-shape-thumbnails/) destekler; bu sayede bir şekli PNG görüntüsü olarak işleyebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet. Her iş parçacığı veya işlem için ayrı bir sunum örneği kullanın; [tek bir örneği iş parçacıkları arasında paylaşmayın](/slides/tr/java/multithreading/).

**PNG olarak dışa aktarırken değerlendirme sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve bir lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/java/licensing/) uygular.