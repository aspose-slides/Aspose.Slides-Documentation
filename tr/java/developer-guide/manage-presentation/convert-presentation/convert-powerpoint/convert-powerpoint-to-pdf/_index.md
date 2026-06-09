---
title: Java'da PPT ve PPTX'i PDF'ye Dönüştürme [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

Java’da PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PDF formatına dönüştürmek, farklı cihazlarla uyumluluk sağlaması ve sunumun düzeni ile biçimlendirmesinin korunması gibi birçok avantaj sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu `save` yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı, tipik olarak bir sunumu PDF'ye dönüştürmek için kullanılan `save` metodunu sunar.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java, çıktı belgelerine API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not**: Aspose.Slides'ın bu bilgileri çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamazsınız.

{{% /alert %}}

Aspose.Slides aşağıdakileri dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarırken, ortaya çıkan PDF'lerin orijinal sunumlara çok yakın olmasını sağlar. Dönüşüm sırasında öğeler ve özellikler doğru şekilde işlenir, bunlar şunları içerir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'e Dönüştürme**

Standart PowerPoint‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'e dönüştürmeye çalışır.

Aşağıdaki kod, bir sunumu (PPT, PPTX, ODP vb.) PDF'e nasıl dönüştüreceğinizi gösterir:

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

Aspose, sunum‑PDF dönüşüm sürecini gösteren ücretsiz bir çevrimiçi **PowerPoint to PDF converter**[https://products.aspose.app/slides/tr/conversion/ppt-to-pdf] sunar. Buradan bir test çalıştırarak burada açıklanan prosedürün canlı uygulamasını görebilirsiniz.

{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'e Dönüştürme**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/) sınıfı altında bulunan özel seçenekler‑özellikleri sayesinde çıktıyı özelleştirmenize, PDF'i şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanır.

### **Özel Seçeneklerle PowerPoint'i PDF'e Dönüştürme**

Özel dönüşüm seçenekleriyle raster görüntüler için tercih ettiğiniz kalite ayarını, metafile'ların nasıl ele alınacağını, metin sıkıştırma seviyesini, görüntüler için DPI ayarını ve daha fazlasını belirleyebilirsiniz.

Aşağıdaki kod örneği, bir PowerPoint sunumunu birkaç özel seçenekle PDF'e nasıl dönüştüreceğinizi gösterir.

```java
// PdfOptions sınıfını örnekleyin.
PdfOptions pdfOptions = new PdfOptions();

// JPG görüntüleri için kaliteyi ayarlayın.
pdfOptions.setJpegQuality((byte)90);

// Görüntüler için DPI'yi ayarlayın.
pdfOptions.setSufficientResolution(300);

// Metafile'ların davranışını ayarlayın.
pdfOptions.setSaveMetafilesAsPng(true);

// Metin içeriği için metin sıkıştırma seviyesini ayarlayın.
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

### **Gizli Slaytlarla PowerPoint'i PDF'e Dönüştürme**

Sunumda gizli slaytlar varsa, gizli slaytları çıktıda sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) yöntemini kullanabilirsiniz.

Aşağıdaki kod, gizli slaytların dahil edildiği bir PowerPoint sunumunu PDF'e nasıl dönüştüreceğinizi gösterir:

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

### **Şifre Koruması Olan PDF'e PowerPoint Dönüştürme**

Aşağıdaki kod, [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF'e nasıl dönüştüreceğinizi gösterir:

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

### **Yazı Tipi İkamelerini Algılama**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/) sınıfı altında bulunan [setWarningCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) yöntemi sayesinde sunum‑PDF dönüşüm sürecinde yazı tipi ikamelerini algılamanızı sağlar.

Aşağıdaki kod, yazı tipi ikamelerini nasıl algılayacağınızı gösterir:

```java
public static void main(String[] args) {
    // PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
    Presentation presentation = new Presentation("sample.pptx");

    // PDF seçeneklerinde uyarı geri çağrısını ayarlayın.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Sunumu PDF olarak kaydedin.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Uyarı geri çağrısının uygulaması.
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

Render sürecinde yazı tipi ikameleri için geri arama alımı hakkında daha fazla bilgi için [Getting Warning Callbacks for Fonts Substitution](/slides/tr/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) sayfasına bakın.

Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/java/font-substitution/) makalesine göz atın.

{{% /alert %}} 

## **PowerPoint'ten PDF'e Seçili Slaytları Dönüştürme**

Aşağıdaki kod, bir PowerPoint sunumundan yalnızca belirli slaytları PDF'e nasıl dönüştüreceğinizi gösterir:

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

## **Özel Slayt Boyutuyla PowerPoint'i PDF'e Dönüştürme**

Aşağıdaki kod, belirli bir slayt boyutuyla bir PowerPoint sunumunu PDF'e nasıl dönüştüreceğinizi gösterir:

```java
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Ayarlanmış slayt boyutu ile yeni bir sunum oluşturun.
Presentation resizedPresentation = new Presentation();

try {
    // Özel slayt boyutunu ayarlayın.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Orijinal sunumdan ilk slaytı kopyalayın.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Yeniden boyutlandırılmış sunumu notlarla PDF olarak kaydedin.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slayt Görünümüyle PowerPoint'i PDF'e Dönüştürme**

Aşağıdaki kod, notlar dahil edilen bir PDF oluşturmak için bir PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```java
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Not Düzeniyle PDF seçeneklerini yapılandırın.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu notlarla PDF olarak kaydedin.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. PowerPoint belgesini PDF'e dışa aktarırken aşağıdaki uyumluluk standartlarından herhangi birini kullanabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Aşağıdaki kod, farklı uyumluluk standartlarına göre birden çok PDF üreten bir PowerPoint‑PDF dönüşüm sürecini gösterir:

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

Aspose.Slides, PDF dönüşüm işlemlerini destekler ve PDF dosyalarını yaygın formatlara dönüştürmenize izin verir. [PDF to HTML](https://products.aspose.com/slides/tr/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/java/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/tr/java/conversion/pdf-to-xml/) gibi özel formatlara da dönüşüm yapılabilir.

{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'e dönüştürebilir miyim?**

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasının toplu olarak PDF'e dönüştürülmesini destekler. Dosyalarınızı döngü içinde işleyerek dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'i şifreyle korumak mümkün mü?**

Kesinlikle. Dönüşüm sırasında şifre ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'e nasıl dahil ederim?**

Gizli slaytları sonuç PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/) sınıfındaki `setShowHiddenSlides` metodunu kullanın.

**Aspose.Slides PDF'te yüksek görüntü kalitesini koruyabilir mi?**

Evet, `setJpegQuality` ve `setSufficientResolution` gibi metodları [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/) sınıfı içinde kullanarak PDF'inizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA gibi [çeşitli standartları](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfcompliance/) destekleyerek belgelerinizin erişilebilirlik ve arşivleme gereksinimlerini karşılamasını sağlar.

## **Ek Kaynaklar**

- [Aspose.Slides for Java Documentation](/slides/tr/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/tr/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/tr/conversion)