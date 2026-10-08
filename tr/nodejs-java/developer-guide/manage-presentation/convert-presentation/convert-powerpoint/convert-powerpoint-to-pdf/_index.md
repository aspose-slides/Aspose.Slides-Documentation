---
title: JavaScript'te PPT ve PPTX'i PDF'ye Dönüştürün [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- PowerPoint'ten PDF'ye
- sunumu PDF'ye
- PPT'yi PDF'ye
- PPT'yi PDF'ye dönüştür
- PPTX'i PDF'ye
- PPTX'i PDF'ye dönüştür
- PowerPoint'i PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye dışa aktar
- PPTX'i PDF'ye dışa aktar
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint ve OpenDocument (PPT, PPTX, ODP vb.) sunumlarını JavaScript'te PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ve biçimlendirmesinin korunması gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, dönüşüm için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını [Sunum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu PDF olarak [kaydet](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) yöntemiyle kaydedin. [Sunum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [kaydet](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) yöntemini ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java, çıktı belgelerine API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürdüğünüzde, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** Aspose.Slides'in bu bilgileri çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamazsınız.
{{% /alert %}}

Aspose.Slides, aşağıdakileri dönüştürmenize olanak tanır:

* Tam sunumları PDF'ye dönüştürmek
* Bir sunumdan belirli slaytları PDF'ye dönüştürmek

Aspose.Slides, sunumları PDF'ye dışa aktararak, oluşturulan PDF'lerin orijinal sunumlara yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru şekilde işlenir; bunlar şunları içerir:

* Resimler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

İlgili örnek, bir sunumu yükler ve tüm görünür slaytları varsayılan dışa aktarma ayarlarıyla PDF'ye kaydeder.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint'ten PDF'ye dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Buradaki prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i Seçeneklerle PDF'ye Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi bir şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenize olanak tanıyan, [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sağlar.

### **PowerPoint'i Özelleştirilmiş Seçeneklerle PDF'ye Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin için bir sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

İlgili örnek, bir sunumu PDF 1.5 olarak dışa aktarır; JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması uygulanır.

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

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının hem slaytları görüntüleyebilmesini hem de çalışma kitabının verilerine erişebilmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) yöntemini `true` ile çağırın.

Varsayılan değer `false`'tır: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasına çizilir, ancak gömülü dosya ek olarak eklenmez. Seçeneği `true` olarak ayarlamak, dosya verilerini ek olarak dahil eder. Ön izleme görsel bir temsili olarak kalır; ek, alıcıların gömülü dosyayı ayrı ayrı açmasına veya kaydetmesine olanak tanır. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

İlgili örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

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

1. Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide dışa aktarılmış PDF'yi açın.
2. Görüntüleyicinin **Ekler** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ekten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar uygular: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları da dahil olmak üzere diğer dosya türlerine izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Eğer bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfından [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) yöntemini kullanabilirsiniz.

İlgili örnek, gizli slaytlar dahil olmak üzere bir sunumu PDF'ye dışa aktarır.

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

### **PowerPoint'i Şifre Koruması Olan PDF'ye Dönüştür**

İlgili örnek, açmak için `password` şifresini gerektiren bir PDF'ye sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı da dahil olmak üzere yazdırmaya izin verir.

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

### **Yazı Tipi İkame Tespiti**

Aspose.Slides, sunumdan PDF'ye dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan, [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfı altında [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) yöntemini sunar.

İlgili örnek, bir sunumu PDF'ye dışa aktarır ve konsola yazı tipi ikame uyarılarını yazdırır. Bir uyarı yalnızca mevcut olmayan bir yazı tipi dışa aktarım sırasında ikame edildiğinde yazdırılır.

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

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşleme**

Bir sunum, yazı tipinin ayrı bir kalın tipine sahip olmaması durumunda da metne kalın biçimlendirme uygulayabilir. Metin, düzenli glifleri yapay olarak kalınlaştıran sentetik kalınlaştırma ile hâlâ kalın görünebilir. Bu metin PDF'de çok ağır görünürse veya istenen görünümden farklıysa, [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) yöntemini `true` ile çağırmayı deneyin. Bu seçenek, etkilenmiş metni PDF dışa aktarım sırasında bir bitmap olarak render eder ve belirli yazı tiplerinin görünümünü iyileştirebilir. Varsayılan değeri `false`'tır.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı yazı tipine kalın biçimlendirme uygulanmış ve ayrı bir kalın tipine sahip olmayan bir yazı tipidir. İlgili örnek, sunumu yükler, desteklenmeyen yazı tipi stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Aşağıdaki ön izlemeler, devre dışı bırakılmış ve etkinleştirilmiş çıktıyı gösterir. Bu örnekte, seçenek devre dışı olduğunda kalın metnin çizgileri daha kalındır. Seçenek etkinleştirildiğinde çizgileri daha hafiftir; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Bu örnekte, seçeneği etkinleştirmek yalnızca kalın metni bir bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir olarak kalır. Seçenek devre dışı olduğunda, her iki dize de metin olarak kalır.

Bu seçenek, yazı tipinin ayrı bir kalın tipine sahip olmaması durumunda kalın biçimlendirilmiş metni rasterleştirir. [Yazı tipi ikamesi](/slides/tr/nodejs-java/font-substitution/) ise orijinal mevcut olmadığında başka bir yazı tipi seçer.

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

İlgili örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizideki slayt numaraları 1 tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **Özel Slayt Boyutu ile PowerPoint'i PDF'ye Dönüştür**

İlgili örnek, bir sunumdan ilk slaytı 612 × 792 puan (8,5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığdırmak için ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

    // Yeni sunum oluşturulurken eklenen boş slaytı kaldır.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

İlgili örnek, bir sunumu PDF'ye dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

Aspose.Slides, [Web İçerik Erişilebilirlik Yönergeleri (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, şu uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b**, ve **PDF/UA**.

Bu kod, farklı uyumluluk standartlarına göre birden fazla PDF oluşturan PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

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
Aspose.Slides, PDF dönüştürme işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF'den HTML'e](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF'den JPG'e](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) ve [PDF'den PNG'e](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Özelleşmiş formatlara – [PDF'den SVG'e](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/) ve [PDF'den TIFF'e](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) – diğer PDF dönüşüm işlemleri de desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık görselleri tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artifakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**  
Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınız üzerinde döngü kurarak dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle korumak mümkün mü?**  
Evet. Dönüşüm sürecinde bir şifre ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl dahil ederim?**  
[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfında [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) yöntemini `true` ile çağırarak gizli slaytları sonuç PDF'ye dahil edebilirsiniz.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**  
Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) ve [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**  
Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [çeşitli standartlara](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) uygun PDF'ler dışa aktarmanıza olanak tanır; bu sayede belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Node.js via Java Belgeleri](/slides/tr/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Referansı](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)