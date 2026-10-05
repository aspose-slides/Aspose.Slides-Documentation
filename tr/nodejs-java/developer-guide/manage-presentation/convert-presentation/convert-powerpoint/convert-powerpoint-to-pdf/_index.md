---
title: "JavaScript'te PPT ve PPTX'i PDF'e Dönüştür [Gelişmiş Özellikler Dahil]"
linktitle: "PowerPoint'ten PDF'e"
type: docs
weight: 40
url: /tr/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint'i dönüştür"
- "sunumu dönüştür"
- "PowerPoint'ten PDF'e"
- "sunumu PDF'e"
- "PPT'den PDF'e"
- "PPT'yi PDF'e dönüştür"
- "PPTX'den PDF'e"
- "PPTX'i PDF'e dönüştür"
- "PowerPoint'i PDF olarak kaydet"
- "PPT'yi PDF olarak kaydet"
- "PPTX'i PDF olarak kaydet"
- "PPT'yi PDF'e aktar"
- "PPTX'i PDF'e aktar"
- "ek"
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint ve OpenDocument sunumlarını (PPT, PPTX, ODP vb.) JavaScript'te PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ile biçimlendirmesini koruma gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını parola ile korumayı, yazı tipi ikamelerini tespit etmeyi, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'tan PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'e dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'e dönüştürmek için, dosya adını [Sunum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından bir [kaydet](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) yöntemiyle sunumu PDF olarak kaydedin. [Sunum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'e dönüştürmek için kullanılan [kaydet](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) yöntemini ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java, çıktı belgelerine API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'e dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** bu bilgiyi çıktı belgelerinden değiştiremez veya kaldıramazsınız.
{{% /alert %}}

Aspose.Slides size şunları dönüştürme imkanı verir:

* **Tüm sunumları PDF'e**
* **Bir sunumdan belirli slaytları PDF'e**

Aspose.Slides sunumları PDF'e dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, aşağıdakiler dahil:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Köprüler
* Üstbilgiler ve altbilgiler
* Madde imleri
* Tablolar

## **PowerPoint'i PDF'e Dönüştür**

Standart PowerPoint'tan PDF'e dönüştürme süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'e dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve varsayılan dışa aktarma ayarlarını kullanarak tüm görünür slaytları PDF olarak kaydeder.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose, ücretsiz bir çevrimiçi [**PowerPoint'tan PDF'ye Dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar ve sunumdan PDF'ye dönüşüm sürecini gösterir. Bu dönüştürücü ile burada açıklanan prosedürün canlı bir uygulamasını test edebilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'e Seçeneklerle Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenizi, PDF'yi bir parola ile kilitlemenizi veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenizi sağlayan özel seçenekler—[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfı altındaki özellikler—sağlar.

### **PowerPoint'i PDF'e Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI'yi yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilmiş ve Flate metin sıkıştırması kullanılarak bir sunumu PDF 1.5 formatına dışa aktarır.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koruma**

Bir sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının çalışma kitabının verilerine erişmesini ve slaytları görmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) metodunu `true` ile çağırın.

Varsayılan değer `false`'tur: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak eklenmez. Seçeneği `true` olarak ayarlamak, dosya verilerini ayrıca ekler. Ön izleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı olarak açmasına veya kaydetmesine olanak tanır. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, içinde zaten gömülü bir Excel çalışma kitabı bulunan bir sunumu yükler ve çalışma kitabı ekli olarak PDF'e dışa aktarır.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Sonucu kontrol etmek için:

1. PDF'yi Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide açın.
2. Görüntüleyicinin **Ekler** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ek'ten ayrı bir unsurdur.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerini izin verir ve PDF/A-3 diğer dosya türlerini, Excel çalışma kitapları dahil, izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **PowerPoint'i Gizli Slaytlarla PDF'e Dönüştür**

Bir sunumda gizli slaytlar varsa, [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metodunu [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfından kullanarak gizli slaytları sonuç PDF'te sayfa olarak dahil edebilirsiniz.

Aşağıdaki örnek, gizli slaytları dahil ederek bir sunumu PDF'e dışa aktarır.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint'i Parola Korumalı PDF'e Dönüştür**

Aşağıdaki örnek, açmak için `password` şifresini gerektiren bir PDF olarak sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı da dahil olmak üzere yazdırmaya izin verir.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Yazı Tipi İkamelerini Algıla**

Aspose.Slides, sunumu PDF'e dönüştürme sürecinde yazı tipi ikamelerini algılamanızı sağlayan [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfı altında [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) metodunu sunar.

Aşağıdaki örnek, bir sunumu PDF'e dışa aktarır ve konsola yazı tipi ikame uyarılarını yazdırır. Bir uyarı yalnızca kullanılabilir olmayan bir yazı tipi dışa aktarma sırasında ikame edildiğinde yazdırılır.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Yazı tipi ikamesi hakkında daha fazla bilgi için [Yazı Tipi İkamesi](/slides/tr/nodejs-java/font-substitution/) makalesine bakın.
{{% /alert %}} 

## **PowerPoint'ten Seçili Slaytları PDF'e Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'e dışa aktarır. Bu dizi içindeki slayt numaraları bir temellidir ve giriş sunumu en az üç slayt içermelidir.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint'i Özel Slayt Boyutu ile PDF'e Dönüştür**

Aşağıdaki örnek, bir sunumdan ilk slaytı 612 × 792 puan (8.5 × 11 inç) boyutunda bir yeni sunuma kopyalar. Slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF'e dışa aktarır.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Yeni oluşturulan sunumda bulunan boş slaytı kaldır.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'e Dönüştür**

Aşağıdaki örnek, bir sunumu PDF'e dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'e, aşağıdaki uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b**, ve **PDF/UA**.

Bu kod, farklı uyumluluk standartlarına göre birden fazla PDF oluşturan bir PowerPoint'ten PDF'e dönüşüm sürecini gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides, PDF dönüştürme işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF'den HTML'ye](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/) , [PDF'den JPG'ye](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) ve [PDF'den PNG'ye](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Özel formatlara yönelik diğer PDF dönüştürme işlemleri—[PDF'den SVG'ye](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/) , [PDF'den TIFF'e](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—da desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir figür olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün figür için sağlanır.

## **SSS**

**Birden çok PowerPoint dosyasını toplu olarak PDF'e dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasının toplu olarak PDF'e dönüştürülmesini destekler. Dosyalarınızda döngü oluşturarak dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'i parola ile korumak mümkün mü?**

Evet. Dönüşüm sürecinde bir şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'e nasıl ekleyebilirim?**

PDF'e gizli slaytları dahil etmek için [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metodunu `true` ile [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfında çağırın.

**Aspose.Slides PDF'te yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'inizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setJpegQuality) ve [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setSufficientResolution) gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, [various standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) (PDF/A1a, PDF/A1b ve PDF/UA dahil) ile uyumlu PDF'ler dışa aktarmanıza izin verir ve belgelerinizin erişilebilirlik ve arşivleme gereksinimlerini karşılamasını sağlar.

## **Ek Kaynaklar**

- [Aspose.Slides for Node.js via Java Belgeleri](/slides/tr/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Referansı](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)