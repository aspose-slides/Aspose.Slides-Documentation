---
title: Java'da Not Sayfası Boyutunu ve Yönünü Değiştirme
linktitle: Not Sayfası Boyutu
type: docs
weight: 10
url: /tr/java/notes-size/
keywords:
- not sayfası boyutu
- not yönü
- yatay notlar
- dikey notlar
- el ilanı boyutu
- PowerPoint
- sunum
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da not sayfası boyutlarını okuyun ve değiştirin, yönü değiştirin, kaydedilen boyutları doğrulayın ve notları veya el ilanlarını PDF ve görüntülere dışa aktarın."
---
## **Genel Bakış**

Presentation.getNotesSize metodunu kullanarak sunumun not sayfası ayarlarına erişin. Bu metod, sayfa boyutlarını ayarlayan [setSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) metoduna sahip bir [INotesSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotessize/) nesnesi döndürür. Ayarlar nesnesi değiştirilemese de, bu metod aracılığıyla yeni boyutlar atanabilir.

Genişlik ve yükseklik **puan** cinsinden belirtilir; bir inçte 72 puan vardır. Örneğin, 900 × 600 puan 12,5 × 8⅓ inçtir. Bu ayarlar sunuma uygulanır, tek bir slaytın notlarına değil.

| Setting | Amaç |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getNotesSize--) | Not sayfası boyutlarını ve el ilanı dışa aktarımı için kullanılan sayfa boyutlarını kontrol eder. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlideSize--) | Normal sunum slaytlarının boyutlarını [ISlideSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidesize/) aracılığıyla kontrol eder. |

Bu ayarlardan birini değiştirmek otomatik olarak diğerini değiştirmez. Not sayfası yönünü değiştirmek aynı zamanda normal slaytları döndürmez. Normal slaytları yeniden boyutlandırmak için [Slide Size](/slides/tr/java/slide-size/) sayfasına bakın.

Aşağıdaki örnekler mevcut bir `sample.pptx` dosyasını kullanır. Dışa aktarım örnekleri için en az bir slaytta konuşmacı notları bulunan bir sunum kullanın. Her örnek bağımsız olarak çalıştırılabilir.

## **Not Sayfası Boyutunu ve Yönünü Okuma**

Genişlik ve yüksekliği okuyup karşılaştırarak yönü belirleyin: daha geniş bir sayfa yatay, daha yüksek bir sayfa dikey, eşit boyutlar kare sayfa anlamına gelir. Bu örnek gerçek boyutları puan cinsinden yazdırır, standart bir kağıt boyutu varsaymaz.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Kağıt Boyutunu Değiştirmeden Yatay Moduna Geçiş**

Yalnızca yönü değiştirmek için mevcut genişlik ve yüksekliği takaslayın. Bu, özel bir kağıt boyutu dahil olmak üzere her iki kenarın uzunluğunu korur. Aşağıdaki koşul, zaten yatay olan bir sayfanın tekrar dikeye geçmesini önler ve kare bir sayfayı değiştirmez.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dikey yön için, `size.getWidth() > size.getHeight()` olduğunda aynı atamayı kullanın. Kağıt boyutunu da değiştirmek istemiyorsanız A4 veya Letter boyutlarını değiştirmeyin.

## **Özel Not Sayfası Boyutu Ayarlama ve Doğrulama**

Her iki boyutu aynı anda atayın, ardından sunumu kaydetmek için [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu kullanın. Bu örnek 900 × 600 puanlık yatay bir sayfa ayarlar, PPTX olarak kaydeder ve kaydedilen dosyayı tekrar açarak kalıcı değerleri kontrol eder. Karşılaştırma, kayan nokta değerleri için 0,01 puan toleransına izin verir; bu, her dosya formatı için kesinlik garantisi değildir.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Beklenen sonuç `900.0 x 600.0 points` ve `Size preserved: true` şeklindedir. Yeni açılan bir sunumu kontrol etmek, yalnızca bellek içi ayarları değil, kaydedilen dosyayı da doğrular.

## **Notları ve El İlanlarını Dışa Aktarma**

Sayfa boyutları, notlar veya el ilanı düzenleri için mevcut alanı tanımlar. Tek başına bu düzenleri etkinleştirmezler: dışa aktarım seçeneklerini de yapılandırmanız gerekir. Normal slayt dışa aktarımı slayt boyutlarını kullanmaya devam eder.

### **Notları PDF ve PNG Olarak Dışa Aktarma**

[NotesCommentsLayoutingOptions] öğesini [PdfOptions.setSlidesLayoutOptions] metoduna atayarak PDF'e notları dahil edin. Bu örnek ayrıca ilk slaytı notlarla birlikte PNG'ye render etmek için [Slide.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ve [RenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/renderingoptions/) kullanır.

[BottomTruncated] modu notları tek sayfada tutar; sığmayan notlar kırpılabilir. PDF 900 × 600 puanlık sayfalar kullanır. Aşağıda kullanılan 1 × 1 görüntü ölçeğinde PNG 900 × 600 pikseldir. Puanlar sayfa geometrisini, pikseller ise raster çıktıyı tanımlar; boyutlar ayrıca render ölçeğine bağlıdır.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Uzun notlarla PDF dışa aktarımı için [BottomFull] gerek duyulduğu kadar ek sayfa oluşturur. Yukarıdaki tek slayt görüntü çağrısında bu modu kullanmayın, çünkü desteklemez. Yeniden boyutlandırdıktan sonra, kesilmiş notları ve mevcut not‑master nesnelerinin yerleşimini inceleyin; sayfa boyutlarını değiştirmek tek başına tüm içeriğin sığacağı garantisi değildir. Not dışa aktarımı hakkında daha fazla bilgi için [Convert PowerPoint to PDF with Notes](/slides/tr/java/convert-powerpoint-to-pdf-with-notes/) sayfasına bakın.

### **El İlanlarını PDF Olarak Dışa Aktarma**

Bir sayfada birden çok slayt küçük resmini göstermek için [HandoutLayoutingOptions] kullanın. Aşağıdaki örnek 900 × 600 puanlık bir sayfa ayarlar ve sayfa başına dört slayta kadar yerleştirmek için [HandoutType.Handouts4Horizontal] kullanır. Yatay ön ayar slayt sırasını kontrol eder; sayfa yönü genişlik ve yükseklik değerlerinden gelir.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Sayfa boyutunu değiştirerek el ilanı ızgarası için kullanılabilir alan değişir, kaynak slaytların boyutları değişmez. El ilanı görüntüleri için, tek bir slaytın görüntü metodunu değil, el ilanı düzeniyle birlikte [Presentation.getImages](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) metodunu kullanın. Aspose.Slides'ta sunum düzeyinde el ilanı render’ı not sayfası boyutlarını kullanırken, tek slayt görüntü çağrısı el ilanı sayfası üretmez. Düzen seçenekleri için [Handout Mode](/slides/tr/java/convert-powerpoint-in-handout-mode/) sayfasına bakın.

## **Görüntüleyicilerde, Dışa Aktarmada ve Yazdırmada Sayfa Boyutu**

Depolanan sunum boyutu, dışa aktarılan sayfa boyutu ve yazdırılan kağıt boyutu ayrı tutulmalıdır:

- **Sunum görüntüleyicileri:** Görüntüleyici, notları kendi düzen kurallarını kullanarak gösterebilir veya yazdırabilir. Başka bir uygulama dosyayı kaydederse, dosyayı yeniden açıp boyutları kontrol edin; o uygulamanın format dönüşümü değerleri normalleştirebilir.
- **Dışa aktarma formatları:** Yukarıdaki not ve el ilanı PDF örnekleri yapılandırılmış sayfa boyutlarını kullanır. Raster görüntüler tam sayı piksel boyutları ve bir render ölçeği kullanır; bu nedenle kesirli puan değerleri görüntü çıktısında yuvarlanabilir. Normal slaytların dışa aktarımı not sayfası boyutunu uygulamaz.
- **Yazıcı sürücüleri:** Kağıt seçimi, otomatik dönüş ve sayfaya sığdırma ayarları, sunumda veya PDF'de depolanan boyutları değiştirmeden fiziksel çıktıyı değiştirebilir. Belirli bir kağıt boyutu için yazıcı ayarlarını eşleştirin ve yazdırma önizlemesini kontrol edin.

## **SSS**

**Can I set the notes size for just one slide?**

Not sayfası boyutu sunum düzeyinde bir ayardır. Tekil slaytların farklı not içerikleri olabilir, fakat bu özellik her slayt için ayrı bir sayfa boyutu sağlamaz.

**Why did changing notes orientation not change my slides?**

Not sayfaları ve normal slaytlar bağımsız boyutlara sahiptir. Slaytların kendisini yeniden boyutlandırmak istediğinizde normal slayt boyutu ayarlarını kullanın.

**Why does my saved or printed result have a different size?**

İlk olarak kaydedilen sunumu yeniden açın ve not boyutlarını karşılaştırın. Eğer değişmişse, dosyayı başka bir uygulamada kaydetmenin veya dönüştürmenin sayfa ayarlarını değiştirip değiştirmediğini kontrol edin. Değişmemişse, dışa aktarım düzenini, görüntü ölçeğini, görüntüleyici ayarlarını ve yazıcı kağıt seçimini inceleyin.