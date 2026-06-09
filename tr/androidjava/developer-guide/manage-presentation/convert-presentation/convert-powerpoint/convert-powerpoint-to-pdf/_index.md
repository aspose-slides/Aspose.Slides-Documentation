---
title: Android'de PPT ve PPTX'i PDF'ye Dönüştür [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PowerPoint'ten PDF'ye
- sunumu PDF'ye
- PPT'den PDF'ye
- PPT'yi PDF'ye dönüştür
- PPTX'den PDF'ye
- PPTX'i PDF'ye dönüştür
- PowerPoint'i PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye dışa aktar
- PPTX'i PDF'ye dışa aktar
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak Java'da PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

Android'de PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzen ve biçimlendirmesini koruma gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları eklemeyi, PDF dosyalarını şifreyle korumayı, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyum standartları uygulamayı gösterir.

## **PowerPoint PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki biçimlerdeki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu `save` yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı, tipik olarak bir sunumu PDF'ye dönüştürmek için kullanılan `save` yöntemini ortaya çıkarır.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java, çıktı belgelerine API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** bu bilgileri çıktı belgelerinden değiştiremez veya kaldıramazsınız.

{{% /alert %}}

Aspose.Slides aşağıdakileri dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlara çok yakın olmasını sağlar. Dönüşüm sırasında öğeler ve özellikler doğru bir şekilde işlenir, örneğin:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgiler ve altbilgiler
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Bu kod, bir sunumu (PPT, PPTX, ODP vb.) PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Sunumu PDF olarak kaydedin.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose, sunum‑PDF dönüşüm sürecini gösteren ücretsiz çevrimiçi bir **PowerPoint PDF dönüştürücüsü** sunar. Buradaki dönüştürücü ile burada açıklanan prosedürün canlı bir uygulamasını test edebilirsiniz.

{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sağlayarak ortaya çıkan PDF'yi özelleştirmenize, PDF'yi şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanır.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin için bir sıkıştırma seviyesi ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki kod örneği, birkaç özel seçenekle bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir.

```java
// PdfOptions sınıfını örnekleyin.
PdfOptions pdfOptions = new PdfOptions();

// JPG görüntüleri için kaliteyi ayarlayın.
pdfOptions.setJpegQuality((byte)90);

// Görüntüler için DPI'yi ayarlayın.
pdfOptions.setSufficientResolution(300);

/// Metafile'ların davranışını ayarlayın.
pdfOptions.setSaveMetafilesAsPng(true);

// Metin içeriği için sıkıştırma seviyesini ayarlayın.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF uyumluluk modunu tanımlayın.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Sunumu PDF belgesi olarak kaydedin.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint'i PDF'ye Gizli Slaytlarla Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) yöntemini kullanabilirsiniz.

Bu kod, gizli slaytları dahil edilmiş bir PDF'ye PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```java
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions sınıfını örnekleyin.
    PdfOptions pdfOptions = new PdfOptions();

    // Gizli slaytları ekleyin.
    pdfOptions.setShowHiddenSlides(true);

    // Sunumu PDF olarak kaydedin.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint'i Şifre Koramalı PDF'ye Dönüştür**

Bu kod, [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfının koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions sınıfını örnekleyin.
    PdfOptions pdfOptions = new PdfOptions();

    // PDF şifresi ve erişim izinlerini ayarlayın.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Sunumu PDF olarak kaydedin.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Yazı Tipi Değiştirmelerini Algıla**

Aspose.Slides, sunum‑PDF dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan [setWarningCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) yöntemini [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfı altında sunar.

Bu kod, yazı tipi ikamelerini nasıl algılayacağınızı gösterir:

```java
public static void main(String[] args) {
    // PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
    Presentation presentation = new Presentation("sample.pptx");

    // PDF seçeneklerinde uyarı geri çağrısını ayarlayın.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Sunumu PDF olarak kaydedin.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Uyarı geri çağrısının uygulanması.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Yazı tipi ikameleri hakkında daha fazla bilgi için, [Font Substitution](/slides/tr/androidjava/font-substitution/) makalesine bakın.

{{% /alert %}} 

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Bu kod, bir PowerPoint sunumundan yalnızca belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Slayt numaralarının dizisini ayarlayın.
    int[] slides = { 1, 3 };

    // Sunumu PDF olarak kaydedin.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint'i Özel Slayt Boyutuyla PDF'ye Dönüştür**

Bu kod, belirli bir slayt boyutu ile bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
float slideWidth = 612;
float slideHeight = 792;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Ayarlanmış slayt boyutuyla yeni bir sunum oluşturun.
Presentation resizedPresentation = new Presentation();

try {
    // Özel slayt boyutunu ayarlayın.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Orijinal sunumdan ilk slaytı klonlayın.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Yeniden boyutlandırılmış sunumu notlarla birlikte PDF olarak kaydedin.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Bu kod, notları içeren bir PDF oluşturmak için bir PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```java
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Not Düzeni ile PDF seçeneklerini yapılandırın.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu notlarla birlikte PDF olarak kaydedin.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Aşağıdaki uyumluluk standartlarından herhangi birini kullanarak bir PowerPoint belgesini PDF'ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu kod, farklı uyumluluk standartlarına göre birden çok PDF üreten bir PowerPoint‑PDF dönüşüm sürecini gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides, PDF dönüşüm işlemlerini destekleyerek PDF dosyalarını popüler dosya biçimlerine dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/tr/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-png/) dönüşümleri yapabilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/java/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/tr/java/conversion/pdf-to-xml/) gibi özel formatlara da dönüşüm desteklenir.

{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol elemanları ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını toplu olarak PDF'ye dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyerek dönüşüm sürecini programatik olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifre ile korumak mümkün mü?**

Kesinlikle. Dönüşüm sırasında şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'ye nasıl ekleyebilirim?**

[Görüntülenen] slaytları PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki `setShowHiddenSlides` yöntemini kullanın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, `setJpegQuality` ve `setSufficientResolution` gibi yöntemleri [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfı içinde kullanarak PDF'nizde yüksek kaliteli görüntüler sağlayabilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli uyumluluk standartlarına uygun PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Android via Java Dokümantasyonu](/slides/tr/androidjava/)
- [Aspose.Slides for Android via Java API Referansı](https://reference.aspose.com/slides/tr/androidjava/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)