---
title: Android'de PowerPoint Slaytlarını PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint'i dönüştür
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint sunumlarını Android için Aspose.Slides ile Java üzerinden hızlı bir şekilde yüksek kaliteli PNG görüntülerine dönüştürün, kesin ve otomatik sonuçlar sağlayarak."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android'i Java üzerinden kullanarak sunum slaytlarını PNG görüntülerine dönüştürmeyi açıklar. PPT, PPTX ve ODP gibi formatlarda sunumları yükleyebilir, her slaytı renderlayabilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Aşağıdaki örnekler, varsayılan ölçekte renderlama, ölçeği artırma, çıktı boyutlarını piksel cinsinden belirtme ve bir degrade renderlama stilini seçme işlemlerini göstermektedir.

## **PowerPoint'i PNG'ye Dönüştür**

Sunumu, [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfını kullanarak yükleyin ve slaytlarına [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) koleksiyonu aracılığıyla erişin. Örnek, her slaytı parametresiz olarak [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) çağırarak bir önizleme resmi oluşturur. Ardından, her renderlanmış slaytı PNG görüntüsü olarak kaydetmek için [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metodunu [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) ile çağırır.

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
Parametresiz [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) aşırı yüklemesi, 0.2 ölçeğinde renderlar. Örneğin, 720 × 540 puan ölçüsündeki bir slayt, 144 × 108 piksel bir önizleme resmi üretir. Çıktı boyutlarını kontrol etmek için aşağıda gösterildiği gibi ölçek faktörleriyle veya açık bir görüntü boyutuyla aşırı yüklemeleri kullanın.
{{% /alert %}}

## **PowerPoint'i Özel Boyutlarla PNG'ye Dönüştür**

Renderlenen boyutları kontrol etmek için yatay ve dikey ölçek faktörlerini [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) metoduna geçirin. Bu örnekte, iki faktör de 2'dir, böylece 720 × 540 puan ölçüsündeki bir slayt, 1440 × 1080 piksel bir görüntü üretir. Eşit ölçek faktörleri, slaytın en‑boy oranını korur. Her görüntü, [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) kullanılarak PNG formatında kaydedilir.

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

## **PowerPoint'i Özel Boyutta PNG'ye Dönüştür**

Çıktı boyutlarını piksel olarak belirtmek için ölçek faktörleri yerine bir boyut nesnesini [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) metoduna geçirin. Bu örnek, her slaytı 960 × 720 piksel olarak renderlar ve sonucu [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ile kaydeder. Görüntünün gerilmesini önlemek için slaytın en‑boy oranına uyan boyutları seçin.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

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

## **Bir Degrade Renderlama Stili Seçin**

Bir slayt degrade dolgu içerdiğini ve dışa aktarılan PNG'de geçişlerin PowerPoint'te gördüğünüzden daha açık veya farklı göründüğünü varsayalım. Degradelerin nasıl renderlanacağını seçmek için [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) tarafından devralınan [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) metodunu kullanabilirsiniz.

Uygulamanın çalışma dizinine [gradient-styles.pptx](gradient-styles.pptx) dosyasını indirin ve yerleştirin. İlk slaytı, üstte camgöbeğinden turuncuya ve alttaki maviden sarıya iki lineer degrade içerir. Her degradenin iki durak noktası vardır: %0 ve %100.

Aşağıdaki örnek bu sunumu yükler ve [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) metodunu kullanarak aynı ilk slaytı her iki modda da renderlar.

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

| Varsayılan | PowerPointUI |
| --- | --- |
| ![Varsayılan ile renderlanmış camgöbeğinden turuncuya ve maviden sarıya degradeler](gradient-Default.png) | ![Aynı degradeler PowerPointUI ile renderlanmış](gradient-PowerPointUI.png) |

Bu örnekte, `Default` daha açık ara renkler üretirken, `PowerPointUI` daha koyu ara renkler üretir. Fark, degradenin renklerine ve durak noktalarına bağlıdır.

İhtiyacınızı karşılayan standart Aspose.Slides çıktısı için `Default` seçin. PowerPoint'teki görünümle eşleşmek önceliğinizse `PowerPointUI` deneyin. Her iki çıktıyı da hedef sonucunuzla karşılaştırın; hiçbir mod genellikle daha üstün değildir.

## **SSS**

**Bir grafiği veya resmi gibi belirli bir şekli, tüm slayt yerine nasıl dışa aktarabilirim?**

Aspose.Slides, bireysel şekiller için [küçük resimler oluşturmayı](/slides/tr/androidjava/create-shape-thumbnails/) destekler; böylece bir şekli PNG görüntüsü olarak renderlayabilirsiniz.

**Bir sunucuda paralel dönüşüm destekleniyor mu?**

Evet. Her iş parçacığı veya süreç için ayrı bir sunum örneği kullanın; [tek bir örneği iş parçacıkları arasında paylaşmayın](/slides/tr/androidjava/multithreading/).

**PNG olarak dışa aktarırken değerlendirme sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/androidjava/licensing/) uygular.