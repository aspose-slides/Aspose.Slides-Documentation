---
title: JavaScript'te Not Sayfası Boyutunu ve Yönünü Değiştirme
linktitle: Not Sayfası Boyutu
type: docs
weight: 10
url: /tr/nodejs-java/notes-size/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde not sayfası boyutlarını okuyun ve değiştirin, Java aracılığıyla yönü değiştirin, kaydedilen boyutları doğrulayın ve notları veya el ilanlarını PDF ve görüntülere dışa aktarın."
---
## **Genel Bakış**

Sunumun not sayfası ayarlarına erişmek için [Presentation.getNotesSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getnotessize/) kullanın. Bu, sayfa boyutlarını ayarlayan [setSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notessize/setsize/) metoduna sahip bir [NotesSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notessize/) nesnesi döndürür. Ayarlar nesnesi kendisi değiştirilemese de, bu metod aracılığıyla yeni boyutlar atayabilirsiniz.

Genişlik ve yükseklik **nokta** cinsinden belirtilir; bir inçte 72 nokta vardır. Örneğin, 900 × 600 nokta 12,5 × 8⅓ inçtir. Bu ayarlar bireysel bir slayt notundan ziyade sunuma uygulanır.

| Ayar | Amaç |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getnotessize/) | Not sayfası boyutlarını ve el ilanı dışa aktarma için kullanılan sayfa boyutlarını kontrol eder. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslidesize/) | Normal sunum slayt boyutlarını [SlideSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/) aracılığıyla kontrol eder. |

Bu ayarlardan birini değiştirmek diğerini otomatik olarak değiştirmez. Not sayfası yönünü değiştirmek de normal slaytları döndürmez. Normal slaytları yeniden boyutlandırmak için [Slide Size](/slides/tr/nodejs-java/slide-size/) sayfasına bakın.

Aşağıdaki örnekler mevcut bir `sample.pptx` dosyasını kullanır. Dışa aktarma örnekleri için, içinde en az bir slayt notu bulunan bir sunum kullanın. Her örnek bağımsız olarak çalıştırılabilir.

## **Not Sayfası Boyutunu ve Yönünü Okuma**

Genişlik ve yüksekliği okuyup karşılaştırarak yönü belirleyin: daha geniş bir sayfa yatay, daha yüksek bir sayfa dikey, eşit boyutlar kare bir sayfayı tanımlar. Bu örnek, standart bir kağıt boyutu varsaymadan gerçek boyutları nokta olarak yazdırır.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Kağıt Boyutunu Değiştirmeden Yatay Moda Geçiş**

Yalnızca yönü değiştirmek için mevcut genişlik ve yüksekliği yer değiştirin. Bu, özel kağıt boyutu dahil, her iki kenarın uzunluklarını korur. Aşağıdaki koşul, zaten yatay olan bir sayfanın tekrar dikeye dönüşmesini engeller ve kare bir sayfayı değiştirmez.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dikey yön için, `size.getWidth() > size.getHeight()` olduğunda aynı atamayı kullanın. Kağıt boyutunu da değiştirmek istemiyorsanız A4 veya Letter boyutlarını değiştirmeyin.

## **Özel Not Sayfası Boyutunu Ayarlama ve Doğrulama**

Her iki boyutu birlikte atayın, ardından sunumu kaydetmek için [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/save/) kullanın. Bu örnek, 900 × 600 noktalık bir yatay sayfa ayarlar, PPTX olarak kaydeder ve kaydedilen dosyayı tekrar açarak kalıcı değerleri kontrol eder. Karşılaştırma, kayan nokta değerleri için 0,01 nokta toleransına izin verir; bu, her dosya formatı için kesinlik garantisi değildir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Beklenen sonuç `900 x 600 points` ve `Size preserved: true`dır. Yeni açılan bir sunumu kontrol etmek, yalnızca bellek içi ayarlar yerine kaydedilen dosyayı doğrular.

## **Notları ve El İlanlarını Dışa Aktarma**

Sayfa boyutları, notlar veya el ilanı düzenleri için kullanılabilir alanı tanımlar. Tek başına bu düzenleri etkinleştirmezler: dışa aktarma seçeneklerini de yapılandırmanız gerekir. Normal slayt dışa aktarımı, slayt boyutlarını kullanmaya devam eder.

### **Notları PDF ve PNG’ye Dışa Aktarma**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) nesnesini [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metoduna atayarak notları PDF’ye dahil edin. Bu örnek ayrıca, [Slide.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) ve [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/) kullanarak notlu ilk slaytı PNG’ye render eder.

[BottomTruncated](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notespositions/) modu notları tek bir sayfada tutar; sığmayan notlar kesilebilir. PDF, 900 × 600 noktalık sayfalar kullanır. Aşağıda kullanılan 1 × 1 görüntü ölçeğinde PNG 900 × 600 piksel olur. Noktalar sayfa geometrisini, pikseller ise raster çıktıyı tanımlar; boyutlar aynı zamanda render ölçeğine de bağlıdır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Uzun notlarla PDF dışa aktarma için, [BottomFull](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notespositions/) ihtiyaç duyulduğunda ek sayfalara izin verir. Yukarıdaki tek slayt görüntü çağrısı bu modu desteklemediği için kullanmayın. Yeniden boyutlandırdıktan sonra, çıktıda kesilmiş notları ve mevcut notes-master nesnelerinin yerleşimini inceleyin; sadece sayfa boyutlarını değiştirmek tüm içeriğin sığacağı garantisi olarak görülmemelidir. Not dışa aktarma hakkında daha fazla bilgi için [Convert PowerPoint to PDF with Notes](/slides/tr/nodejs-java/convert-powerpoint-to-pdf-with-notes/) sayfasına bakın.

### **El İlanlarını PDF’ye Dışa Aktarma**

Tek bir sayfada birden fazla slayt küçük resmi için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handoutlayoutingoptions/) kullanın. Aşağıdaki örnek 900 × 600 noktalık bir sayfa ayarlar ve sayfa başına dört slayt düzenlemek için [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handouttype/) kullanır. Yatay ön ayar slayt sırasını kontrol eder; sayfa yönü genişlik ve yükseklikten gelir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Sayfa boyutunu değiştirmek, kaynak slaytların boyutlarını etkilemeden el ilanı ızgarası için mevcut alanı değiştirir. El ilanı görüntüleri için, tek bir slaytın görüntü metodunu değil, el ilanı düzeniyle birlikte [Presentation.getImages](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getimages/) kullanın. Aspose.Slides’da sunum seviyesindeki el ilanı render'ı not sayfası boyutlarını kullanırken, tek slayt görüntü çağrısı el ilanı sayfası üretmez. Düzen seçenekleri için [Handout Mode](/slides/tr/nodejs-java/convert-powerpoint-in-handout-mode/) sayfasına bakın.

## **Görüntüleyicilerde, Dışa Aktarmada ve Baskıda Sayfa Boyutu**

Kaydedilen sunum boyutunu, dışa aktarılan sayfa boyutunu ve basılan kağıt boyutunu ayrı tutun:

- **Presentation viewers:** Bir görüntüleyici, notları kendi düzen kurallarını kullanarak görüntüleyebilir veya yazdırabilir. Başka bir uygulama dosyayı kaydederse, dosyayı yeniden açın ve boyutları kontrol edin; o uygulamanın format dönüşümü onları normalleştirebilir.
- **Export formats:** Yukarıdaki not ve el ilanı PDF örnekleri yapılandırılmış sayfa boyutlarını kullanır. Raster görüntüler, tam sayı piksel boyutları ve bir render ölçeği kullanır; bu yüzden kesirli nokta değerleri görüntü çıktısında yuvarlanabilir. Normal slaytların dışa aktarımı not sayfası boyutunu uygulamaz.
- **Printer drivers:** Kağıt seçimi, otomatik döndürme ve sayfaya sığdırma ayarları, sunumda veya PDF’de depolanan boyutları değiştirmeden fiziksel çıktıyı değiştirebilir. Belirli bir kağıt boyutu için, yazıcı ayarlarıyla eşleşin ve yazdırma önizlemesini kontrol edin.

## **SSS**

**Bir slayt için yalnızca not boyutunu ayarlayabilir miyim?**

Not sayfası boyutu, sunum düzeyinde bir ayardır. Tek tek slaytların farklı not içerikleri olabilir, ancak bu özellik her slayt için ayrı bir sayfa boyutu sağlamaz.

**Not yönünü değiştirmek slaytlarımı neden değiştirmedi?**

Not sayfaları ve normal slaytlar bağımsız boyutlara sahiptir. Slaytların kendisini yeniden boyutlandırmak istediğinizde normal slayt boyutu ayarlarını kullanın.

**Kaydedilen veya yazdırılan sonuç neden farklı bir boyuta sahip?**

Öncelikle kaydedilen sunumu yeniden açın ve not boyutlarını karşılaştırın. Eğer değişmişse, dosyayı başka bir uygulamada kaydetmenin veya dönüştürmenin sayfa ayarlarını değiştirip değiştirmediğini kontrol edin. Değişmemişse, dışa aktarma düzenini, görüntü ölçeğini, görüntüleyici ayarlarını ve yazıcı kağıt seçimini kontrol edin.