---
title: JavaScript'te PPT ve PPTX'i PDF'e Dönüştür [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'e
type: docs
weight: 40
url: /tr/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- PowerPoint'ten PDF'e
- sunumu PDF'e
- PPT'den PDF'e
- PPT'yi PDF'e dönüştür
- PPTX'ten PDF'e
- PPTX'i PDF'e dönüştür
- PowerPoint'i PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'e aktar
- PPTX'i PDF'e aktar
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint PPT/PPTX'i yüksek kalite, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint ve OpenDocument sunumlarını (PPT, PPTX, ODP vb.) JavaScript'te PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelere nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini algılamayı, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir argümanı olarak geçirin ve ardından [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) metodunu kullanarak sunumu PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) metodunu sunar.

{{% alert color="info" title="Not" %}}
Aspose.Slides for Node.js via Java, çıktı belgelerine API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application (Uygulama) alanını "*Aspose.Slides*" ve PDF Producer (PDF Üreticisi) alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** bu bilgiyi çıktı belgelerinden değiştirme ya da kaldırma talimatı veremeyeceğinizi belirtir.
{{% /alert %}}

Aspose.Slides, şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumun belirli slaytlarını PDF'ye

Aspose.Slides, sunumları PDF olarak dışa aktarır ve oluşan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşümde öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek, bir sunumu yükler ve varsayılan dışa aktarım ayarlarını kullanarak tüm görünen slaytları PDF olarak kaydeder.

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

{{% alert color="info" title="Not" %}}
Aspose, ücretsiz bir çevrimiçi [**PowerPoint PDF dönüştürücüsü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar; bu dönüştürücüyle burada açıklanan prosedürün canlı bir uygulamasını test edebilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfının altındaki özelleştirilebilir seçenekler—özellikler—sunar; bu sayede oluşturulan PDF'yi özelleştirebilir, PDF'yi bir şifreyle kilitleyebilir veya dönüşüm sürecinin nasıl ilerleyeceğini belirleyebilirsiniz.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirtebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, bir sunumu PDF 1.5 olarak dışa aktarır; JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve metin Flate sıkıştırması kullanılır.

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

### **Görüntü Sıkıştırmasını Otomatik Seç**

Bir sunumda çok sayıda fotoğraf veya ekran görüntüsü bulunduğunda, dışa aktarılan PDF'nin boyutunu küçültmek e‑posta ile gönderimi veya indirmeyi kolaylaştırır. PDF dışa aktarımı sırasında her görüntü için en uygun sıkıştırma algoritmasını otomatik olarak seçmek için [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) metodunu `true` ile çağırın.

Aşağıdaki örnek, mevcut bir sunumu yükler, otomatik görüntü sıkıştırma seçimini etkinleştirir ve onu PDF belgesi olarak kaydeder. Diğer tüm PDF dışa aktarım ayarları varsayılan değerlerini korur.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Bu seçenek, her görüntü için bir sıkıştırma algoritması seçer. [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) metoduna verilen değeri düşürmek JPEG görüntü kalitesini azaltırken, [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) metoduna verilen değeri düşürmek görüntülerin daha düşük bir çözünürlüğe indirgeyerek detay kaybına yol açabilir. Otomatik sıkıştırma seçimini etkinleştirmek bu ayarları kendiliğinden düşürmez.

Görüntü sıkıştırma algoritmalarının seçilmesi ek işlem süresi ve bellek gerektirir. Boyut azalması, sunumdaki görüntülere ve dışa aktarım ayarlarına bağlıdır; her sunum için sabit bir azalma garantilenmez.

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Bir sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının hem slaytları görüntülemesini hem de çalışma kitabının verilerine erişmesini isteyebilirsiniz. [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) metodunu `true` ile çağırarak gömülü OLE dosyalarını sonuç PDF'de ek olarak koruyabilirsiniz.

Varsayılan değer `false`'dır: OLE nesnesinin önizleme resmi veya simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `true` olarak ayarlamak ayrıca dosya verisini ekler. Önizleme görsel bir temsili kalır; ek, alıcıların gömülü dosyayı ayrı olarak açıp kaydetmesini sağlar. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

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

1. Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide dışa aktarılan PDF'yi açın.
2. Görüntüleyicinin **Attachments** (Ekler) panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın; ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki önizleme ekten ayrı bir öğedir.

{{% alert color="info" title="Not" %}}
PDF/A standartları ekler konusunda kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bu kısıtlamalar standartların gereksinimleridir, Aspose.Slides'e özgü sınırlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A ihracatını göstermemektedir.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) metodunu `true` ile çağırarak gizli slaytları sonuç PDF'de sayfalar olarak dahil edebilirsiniz.

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

### **PowerPoint'i Şifreli PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumu `password` şifresiyle açılması gereken bir PDF'ye dışa aktarır. Erişim izinleri, yüksek kalite baskı dahil baskıya izin verir.

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

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfı altında [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) metodunu sunar; bu sayede sunum‑PDF dönüşüm sürecinde yazı tipi ikamelerini algılayabilirsiniz.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve yazı tipi ikameleri uyarılarını konsola yazdırır. Uyarı, yalnızca dışa aktarım sırasında mevcut olmayan bir yazı tipinin ikamesi gerçekleştiğinde görüntülenir.

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

{{% alert color="info" title="Not" %}}
Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/nodejs-java/font-substitution/) makalesine bakın.
{{% /alert %}} 

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşle**

Bir sunum, fontunda ayrı bir kalın yazı tipi olmamasına rağmen metne kalın biçimlendirme uygulayabilir. Metin, sentetik kalınlaştırma yoluyla hâlâ kalın görünebilir; bu, normal glifleri yapay olarak kalınlaştırır. Bu metin PDF'de çok ağır görünürse veya istenen görünüme uymuyorsa, [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) metodunu `true` ile çağırmayı deneyin. Bu seçenek, etkilenen metni PDF dışa aktarımı sırasında bitmap olarak işler ve belirli fontlarda görünümünü iyileştirebilir. Varsayılan değeri `false`'tur.

Örnek sunum, aynı fontta normal metin ve kalın biçimlendirme uygulanmış iki metin kutusu içerir; bu fontun ayrı bir kalın yazı tipi yoktur. Aşağıdaki örnek, sunumu yükler, desteklenmeyen font stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

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

Aşağıdaki ön izlemeler, devre dışı bırakılmış ve etkinleştirilmiş çıktıyı gösterir. Bu örnekte, seçenek devre dışı olduğunda kalın metnin çizgileri daha kalındır. Seçenek etkinleştirildiğinde çizgileri daha ince olur; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF, desteklenmeyen font stili rasterleştirmesi devre dışı](unsupported-bold-disabled.png) | ![PDF, desteklenmeyen font stili rasterleştirmesi etkin](unsupported-bold-enabled.png) |

Bu örnekte, seçenek yalnızca kalın metni bitmap haline getirir: OCR olmadan metin olarak seçilemez, kopyalanamaz veya aranamaz ve kenarları 800% yakınlaştırmada daha yumuşaktır. Normal metin aranabilir kalır. Seçenek devre dışı olduğunda her iki dize de metin olarak kalır.

Bu seçenek, fontunda ayrı bir kalın yazı tipi olmadığında kalın olarak biçimlendirilmiş metni rasterleştirir. [Font Substitution](/slides/tr/nodejs-java/font-substitution/) ise orijinal mevcut olmadığında başka bir font seçer.

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizideki slayt numaraları bir tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **PowerPoint'i Özel Slayt Boyutu ile PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan ilk slaytı 612 × 792 puan (8.5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığdırmak için ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) standartlarına uygun bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi bu uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz.

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

{{% alert color="info" title="Not" %}}
Aspose.Slides, PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) gibi özel formatlara da dönüşüm desteklenir.
{{% /alert %}}

**Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides karmaşık grafikleri (SmartArt, grafikler ve formüller gibi) tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden çok PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides, birden çok PPT veya PPTX dosyasının toplu olarak PDF'ye dönüştürülmesini destekler. Dosyalarınız üzerinde döngü kurarak dönüşüm sürecini programlı bir şekilde uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle korumak mümkün mü?**

Evet. Dönüşüm sürecinde bir şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'ye nasıl ekleyebilirim?**

[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfında [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) metodunu `true` ile çağırarak gizli slaytları sonuç PDF'ye dahil edebilirsiniz.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) ve [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) gibi metodları kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [various standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) ile uyumlu PDF'ler dışa aktarmanızı sağlar; bu sayede belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Node.js via Java Dokümantasyonu](/slides/tr/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Referansı](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)