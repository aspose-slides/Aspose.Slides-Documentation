---
title: JavaScript'te PPT ve PPTX'i PDF'ye Dönüştürme [Gelişmiş Özellikler Dahildir]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint ve OpenDocument sunumlarını (PPT, PPTX, ODP vb.) JavaScript kullanarak PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk sağlaması ve sunumun düzeni ile biçimlendirmesini koruması gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelere dönüştürmeyi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF’ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF’ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu `save` yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı, bir sunumu PDF’ye dönüştürmek için yaygın olarak kullanılan `save` yöntemini sunar.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java, API bilgilerini ve sürüm numarasını çıktı belgelere ekler. Örneğin, bir sunumu PDF’ye dönüştürürken Aspose.Slides, Uygulama alanını "*Aspose.Slides*" ve PDF Üreticisi alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not**: Aspose.Slides’in bu bilgileri çıktı belgelerden değiştirmesini veya kaldırmasını sağlayamazsınız.

{{% /alert %}}

Aspose.Slides şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF’ye
* Sunumdan belirli slaytları PDF’ye

Aspose.Slides sunumları PDF’ye dışa aktarır ve ortaya çıkan PDF’lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında aşağıdaki öğeler ve nitelikler doğru şekilde işlenir:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint’i PDF’ye Dönüştürme**

Standart PowerPoint‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF’ye dönüştürmeye çalışır.

Aşağıdaki kod, bir sunumu (PPT, PPTX, ODP vb.) PDF’ye nasıl dönüştüreceğinizi gösterir:

```js
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Sunumu PDF olarak kaydedin.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose, sunum‑PDF dönüşüm sürecini gösteren ücretsiz bir çevrimiçi **PowerPoint to PDF converter**[https://products.aspose.app/slides/tr/conversion/ppt-to-pdf] sunar. Buradaki dönüştürücüyle test yaparak burada açıklanan prosedürü canlı olarak deneyebilirsiniz.

{{% /alert %}}

## **Seçeneklerle PowerPoint’i PDF’ye Dönüştürme**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/) sınıfı altında bulunan özel seçenekler‑özellikleri sayesinde oluşturulan PDF’yi özelleştirmenize, PDF’yi bir şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanır.

### **Özel Seçeneklerle PowerPoint’i PDF’ye Dönüştürme**

Özel dönüşüm seçenekleriyle raster görüntüler için tercih edilen kalite ayarını, metafile’ların nasıl işleneceğini, metin için sıkıştırma seviyesini, görüntüler için DPI’yı ve daha fazlasını belirleyebilirsiniz.

Aşağıdaki kod örneği, bir PowerPoint sunumunu birkaç özel seçenekle PDF’ye nasıl dönüştüreceğinizi gösterir.

```js
// PdfOptions sınıfını örnekleyin.
let pdfOptions = new aspose.slides.PdfOptions();

// Set the quality for JPG images.
pdfOptions.setJpegQuality(java.newByte(90));

// Set DPI for images.
pdfOptions.setSufficientResolution(300);

// Set the behavior for metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Define the PDF compliance mode.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Sunumu PDF belgesi olarak kaydedin.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Gizli Slaytlarla PowerPoint’i PDF’ye Dönüştürme**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları ortaya çıkan PDF’de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PdfOptions) sınıfının [setShowHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) yöntemini kullanabilirsiniz.

Bu JavaScript kodu, gizli slaytların dahil olduğu bir PowerPoint sunumunu PDF’ye nasıl dönüştüreceğinizi gösterir:

```js
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions sınıfını örnekleyin.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Gizli slaytları ekle.
    pdfOptions.setShowHiddenSlides(true);

    // Sunumu PDF olarak kaydedin.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Şifre Koruması Olan PDF’ye PowerPoint Dönüştürme**

Bu JavaScript kodu, [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PdfOptions) sınıfının koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF’ye nasıl dönüştüreceğinizi gösterir:

```js
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions sınıfını örnekleyin.
    let pdfOptions = new aspose.slides.PdfOptions();

    // PDF şifresi ve erişim izinlerini ayarlayın.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Sunumu PDF olarak kaydedin.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Yazı Tipi Değiştirmelerini Tespit Etme**

Aspose.Slides, sunum‑PDF dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PdfOptions) sınıfı altındaki [setWarningCallback](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) yöntemini sunar.

Bu JavaScript kodu, yazı tipi değiştirilmelerini nasıl tespit edeceğinizi gösterir:

```js
// PDF seçeneklerinde uyarı geri aramasını ayarlayın.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Sunumu PDF olarak kaydedin.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/nodejs-java/font-substitution/) makalesine bakın.

{{% /alert %}} 

## **Seçilen Slaytları PDF’ye Dönüştürme**

Bu JavaScript kodu, bir PowerPoint sunumundan yalnızca belirli slaytları PDF’ye nasıl dönüştüreceğinizi gösterir:

```js
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Slayt numaraları dizisini ayarla.
    let slides = java.newArray("int", [1, 3]);

    // Sunumu PDF olarak kaydedin.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Özel Slayt Boyutuyla PowerPoint’i PDF’ye Dönüştürme**

Bu JavaScript kodu, belirli bir slayt boyutu kullanarak bir PowerPoint sunumunu PDF’ye nasıl dönüştüreceğinizi gösterir:

```js
const slideWidth = 612;
const slideHeight = 792;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Ayarlanmış slayt boyutu ile yeni bir sunum oluşturun.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Özel slayt boyutunu ayarlayın.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Orijinal sunumdan ilk slaytı kopyalayın.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Yeniden boyutlandırılmış sunumu notlarla birlikte PDF olarak kaydedin.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slaytı Görünümünde PDF’ye Dönüştürme**

Bu JavaScript kodu, notları içeren bir PDF oluşturmak için bir PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```js
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Notlar Düzeniyle PDF seçeneklerini yapılandırın.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu notlarla birlikte PDF olarak kaydedin.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza izin verir. Aşağıdaki uyumluluk standartlarından herhangi birini kullanarak bir PowerPoint belgesini PDF’ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu JavaScript kodu, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint‑PDF dönüşüm sürecini gösterir:

```js
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides, PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler formatlara dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/tr/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/tr/nodejs-java/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/tr/nodejs-java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/tr/nodejs-java/conversion/pdf-to-svg/) ve [PDF to TIFF](https://products.aspose.com/slides/tr/nodejs-java/conversion/pdf-to-tiff/) gibi özel formatlara dönüştürme işlemleri de desteklenir.

{{% /alert %}}

> **Not:** PDF/UA olarak dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF’ye dönüştürebilir miyim?**

Evet, Aspose.Slides, birden fazla PPT veya PPTX dosyasını PDF’ye toplu dönüştürmeyi destekler. Dosyalarınızı döngüyle işleyerek dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF’yi şifreyle koruyabilir miyim?**

Kesinlikle. Dönüşüm sırasında şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PdfOptions) sınıfını kullanın.

**Gizli slaytları PDF’ye nasıl dahil ederim?**

Gizli slaytları ortaya çıkan PDF’ye eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PdfOptions) sınıfındaki `setShowHiddenSlides` yöntemini kullanın.

**Aspose.Slides PDF’de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PdfOptions) sınıfındaki `setJpegQuality` ve `setSufficientResolution` gibi yöntemleri kullanarak PDF’nizde yüksek kaliteli görseller elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlara uyumlu PDF’ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Node.js via Java Documentation](/slides/tr/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/tr/nodejs-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)