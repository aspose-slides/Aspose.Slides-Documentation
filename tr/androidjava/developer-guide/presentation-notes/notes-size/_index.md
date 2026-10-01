---
title: Android'de Not Sayfası Boyutu ve Yönünü Değiştir
linktitle: Not Sayfası Boyutu
type: docs
weight: 10
url: /tr/androidjava/notes-size/
keywords:
- not sayfası boyutu
- not yönü
- yatay notlar
- dikey notlar
- el kitabı boyutu
- PowerPoint
- sunum
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de Java aracılığıyla not sayfası boyutlarını okuyun ve değiştirin, yönü değiştirin, kaydedilen boyutları doğrulayın ve notları veya el kitaplarını PDF ve görüntülere dışa aktarın."
---
## **Genel Bakış**

Sunumun not sayfası ayarlarına erişmek için [Presentation.getNotesSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getNotesSize--) kullanın. Bu, sayfa boyutlarını ayarlayan [setSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) metoduna sahip bir [INotesSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/inotessize/) nesnesi döndürür. Ayar nesnesi değiştirilemese de, yeni boyutları bu yöntemle atayabilirsiniz.

En ve yükseklik **nokta** biriminde belirtilir; inç başına 72 nokta vardır. Örneğin, 900 × 600 nokta 12.5 × 8⅓ inç eder. Bu ayarlar, bireysel bir slaytın notlarından ziyade sunuma uygulanır.

| Ayar | Amacı |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Not sayfası boyutlarını ve el kitabı dışa aktarımı için kullanılan sayfa boyutlarını kontrol eder. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Normal sunum slaytı boyutlarını [ISlideSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidesize/) aracılığıyla kontrol eder. |

Bu ayarlardan birini değiştirmek diğerini otomatik olarak etkilemez. Not sayfası yönünü değiştirmek de normal slaytları döndürmez. Normal slaytları yeniden boyutlandırmak için [Slide Size](/slides/tr/androidjava/slide-size/) bölümüne bakın.

Aşağıdaki örnekler mevcut bir `sample.pptx` dosyasını kullanır. Dışa aktarma örnekleri için en az bir slaytta konuşmacı notları bulunan bir sunum kullanın. Her örnek bağımsız olarak çalıştırılabilir.

## **Not Sayfası Boyutunu ve Yönünü Okuma**

En ve yüksekliği okuyup karşılaştırarak yönünü belirleyin: daha geniş bir sayfa yatay, daha yüksek bir sayfa dikey, eşit boyutlar ise kare bir sayfayı tanımlar. Bu örnek, standart bir kağıt boyutu varsaymadan, gerçek boyutları nokta cinsinden yazdırır.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **Kağıt Boyutunu Değiştirmeden Yatay Moda Geçiş**

Yalnızca yönü değiştirmek için mevcut en ve yüksekliği takas edin. Bu, özel kağıt boyutu dahil her iki tarafın uzunluklarını korur. Aşağıdaki koşul, zaten yatay olan bir sayfanın tekrar dikeye çevrilmesini önler ve kare bir sayfayı değiştirilmemiş bırakır.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dikey yön için, `size.getWidth() > size.getHeight()` olduğunda aynı atamayı kullanın. Kağıt boyutunu da değiştirmek istemediğiniz sürece A4 veya Letter boyutlarını değiştirmeyin.

## **Özel Not Sayfası Boyutu Ayarlama ve Doğrulama**

İki boyutu birlikte atayın, ardından sunumu kaydetmek için [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) kullanın. Bu örnek, 900 × 600 nokta boyutunda bir yatay sayfa ayarlar, PPTX olarak kaydeder ve kaydedilen dosyayı tekrar açarak kalıcı değerleri kontrol eder. Karşılaştırma, kayan nokta değerleri için 0.01 nokta toleransına izin verir; bu, her dosya formatı için kesinlik garantisi değildir.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Beklenen sonuç `900.0 x 600.0 points` ve `Size preserved: true` şeklindedir. Yeni açılan bir sunumu kontrol etmek, yalnızca bellek içi ayarları değil, kaydedilen dosyayı doğrular.

## **Notları ve El Kitaplarını Dışa Aktarma**

Sayfa boyutları, notlar veya el kitabı düzenleri için kullanılabilir alanı tanımlar. Tek başına bu düzenleri etkinleştirmezler; dışa aktarma seçeneklerini de yapılandırmanız gerekir. Normal slayt dışa aktarımı slayt boyutlarını kullanmaya devam eder.

### **Notları PDF ve PNG Olarak Dışa Aktarma**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) nesnesini [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)\'a atayarak PDF\'ye notları dahil edin. Bu örnek ayrıca, notları olan ilk slaytı [Slide.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ve [RenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/renderingoptions/) kullanarak PNG olarak render eder.

[BottomTruncated](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notespositions/) modu, notları tek bir sayfada tutar; sığmayan notlar kırpılabilir. PDF, 900 × 600 nokta sayfalar kullanır. Aşağıda kullanılan 1 × 1 görüntü ölçeğinde PNG, 900 × 600 piksel olur. Noktalar sayfa geometrisini, pikseller ise raster çıktıyı tanımlar; boyutları render ölçeğine de bağlıdır.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Uzun notlarla PDF dışa aktarmada, [BottomFull](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notespositions/) gerek duyulduğunda ek sayfalara izin verir. Yukarıdaki tek‑slayt görüntü çağrısı bu modu desteklemediği için kullanmayın. Yeniden boyutlandırdıktan sonra, kırpılmış notları ve mevcut notes‑master nesnelerinin yerleşimini kontrol edin; yalnızca sayfa boyutlarını değiştirmek, tüm içeriğin sığacağı garantisi değildir. Not dışa aktarması hakkında daha fazla bilgi için [Convert PowerPoint to PDF with Notes](/slides/tr/androidjava/convert-powerpoint-to-pdf-with-notes/) bölümüne bakın.

### **El Kitaplarını PDF Olarak Dışa Aktarma**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handoutlayoutingoptions/) kullanarak bir sayfada birden çok slayt küçük resmi elde edin. Aşağıdaki örnek 900 × 600 nokta bir sayfa ayarlar ve sayfa başına en fazla dört slayt yerleştirmek için [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handouttype/) kullanır. Yatay ön ayar slayt sırasını kontrol eder; sayfa yönü genişlik ve yükseklikten elde edilir.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Sayfa boyutunu değiştirmek, el kitabı ızgarası için kullanılabilir alanı etkiler, kaynak slaytların boyutlarını değiştirmez. El kitabı görüntüleri için, bireysel slayt görüntü yönteminin yerine el kitabı düzeniyle [Presentation.getImages](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) kullanın. Aspose.Slides'ta, sunum‑seviyesinde el kitabı renderı not sayfası boyutlarını kullanırken, tek slayt görüntü çağrısı el kitabı sayfası üretmez. Düzen seçenekleri için [Handout Mode](/slides/tr/androidjava/convert-powerpoint-in-handout-mode/) bölümüne bakın.

## **İzleyicilerde, Dışa Aktarımda ve Yazdırmada Sayfa Boyutu**

Kaydedilen sunum boyutu, dışa aktarılan sayfa boyutu ve yazdırılan kağıt boyutu farklı tutulmalıdır:

- **Presentation viewers:** Bir izleyici, kendi düzen kurallarını kullanarak notları görüntüleyebilir veya yazdırabilir. Başka bir uygulama dosyayı kaydederse, yeniden açın ve boyutları tekrar kontrol edin; o uygulamanın format dönüşümü değerleri normalleştirebilir.
- **Export formats:** Yukarıdaki not ve el kitabı PDF örnekleri yapılandırılmış sayfa boyutlarını kullanır. Raster görüntüler tam sayı piksel boyutları ve render ölçeği ile oluşturulur, bu yüzden kesirli nokta değerleri görüntü çıktısında yuvarlanabilir. Normal slaytları dışa aktarmak not sayfası boyutunu uygulamaz.
- **Printer drivers:** Kağıt seçimi, otomatik döndürme ve sayfaya sığdırma ayarları, sunum veya PDF'teki saklı boyutları değiştirmeden fiziksel çıktıyı değiştirebilir. Belirli bir kağıt boyutu için, yazıcı ayarlarını eşleştirin ve ön izlemeyi kontrol edin.

## **SSS**

**Not sayfası boyutunu sadece bir slayt için ayarlayabilir miyim?**

Not sayfası boyutu sunum‑seviyesinde bir ayardır. Bireysel slaytların farklı not içerikleri olabilir, ancak bu özellik her slayt için ayrı bir sayfa boyutu sağlamaz.

**Not yönünü değiştirmek neden slaytlarımı etkilemedi?**

Not sayfaları ve normal slaytlar bağımsız boyutlara sahiptir. Slaytları yeniden boyutlandırmak istediğinizde, normal slayt boyutu ayarlarını kullanın.

**Kaydedilen ya da yazdırılan sonucum farklı bir boyutta neden görünüyor?**

İlk olarak kaydedilen sunumu yeniden açın ve not boyutlarını karşılaştırın. Değişti ise, dosyanın başka bir uygulamada kaydedilmesi veya dönüştürülmesi sayfa ayarlarını değiştirmiş olabilir. Değişmemişse, dışa aktarma düzeni, görüntü ölçeği, izleyici ayarları ve yazıcı kağıt seçimini kontrol edin.