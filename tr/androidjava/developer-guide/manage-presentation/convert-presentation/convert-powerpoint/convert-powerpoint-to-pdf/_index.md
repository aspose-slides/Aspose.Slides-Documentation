---
title: Android'de PPT ve PPTX'i PDF'ye Dönüştür (Gelişmiş Özellikler Dahil)
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
description: "Aspose.Slides for Android kullanarak Java'da PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Android'de PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumun düzen ve biçimlendirmesinin korunması gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelere nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları eklemeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini algılamayı, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüştürmeler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu `save` yöntemiyle PDF olarak kaydedin. [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan `save` yöntemini ortaya çıkarır.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Android via Java, API bilgisi ve sürüm numarasını çıktı belgelere ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not**: Aspose.Slides'ın bu bilgileri çıktı belgelerden değiştirmesini veya kaldırmasını isteyemezsiniz.
{{% /alert %}}

Aspose.Slides aşağıdakileri dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktararak ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüştürme sırasında öğeler ve nitelikler doğru bir şekilde işlenir, özellikle:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint‑to‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki kod, bir sunumu (PPT, PPTX, ODP vb.) PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Sunumu PDF olarak kaydedin.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 
Aspose, burada açıklanan prosedürün canlı bir uygulamasını test edebileceğiniz ücretsiz bir çevrimiçi **PowerPoint'ten PDF'ye dönüştürücü** sunar: [PowerPoint to PDF converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pdf).
{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize izin veren [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler (özellikler) sunar.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özel dönüşüm seçenekleriyle raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile’ların nasıl işleneceğini belirleyebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki kod örneği, birkaç özel seçenekle bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir.

```java
import com.aspose.slides.*;

// PdfOptions sınıfını örnekleyin.
PdfOptions pdfOptions = new PdfOptions();

// JPG görüntülerin kalitesini ayarlayın.
pdfOptions.setJpegQuality((byte)90);

// Görüntüler için DPI ayarlayın.
pdfOptions.setSufficientResolution(300);

/// Metafile davranışını ayarlayın.
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

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) yöntemini kullanabilirsiniz.

Bu kod, gizli slaytların dahil edildiği bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

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

### **Şifreli PDF Olarak PowerPoint'i Dönüştür**

Aşağıdaki kod, [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

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

Aspose.Slides, sunum‑to‑PDF dönüşüm sürecinde yazı tipi ikamelerini algılamanızı sağlayan [setWarningCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) yöntemini [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfı altında sunar.

Bu kod, yazı tipi değiştirilmelerini nasıl algılayacağınızı gösterir:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
    Presentation presentation = new Presentation("sample.pptx");

    // PDF seçeneklerinde uyarı geri aramasını ayarlayın.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Sunumu PDF olarak kaydedin.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Uyarı geri aramasının uygulanması.
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

{{%  alert color="info"  %}} 
Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/androidjava/font-substitution/) makalesine bakın.
{{% /alert %}} 

## **PowerPoint'ten PDF'ye Seçili Slaytları Dönüştür**

Bu kod, bir PowerPoint sunumundan yalnızca belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Slayt numaraları dizisini ayarlayın.
    int[] slides = { 1, 3 };

    // Sunumu PDF olarak kaydedin.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Özel Slayt Boyutu ile PowerPoint'i PDF'ye Dönüştür**

Bu kod, belirli bir slayt boyutu ile bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Ayarlanmış slayt boyutuyla yeni bir sunum oluşturun.
Presentation resizedPresentation = new Presentation();

try {
    // Özel slayt boyutunu ayarlayın.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Orijinal sunumdan ilk slaytı kopyalayın.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Yeni sunumun oluşturulduğu boş slaytı kaldırın.
    resizedPresentation.getSlides().removeAt(1);

    // Yeniden boyutlandırılmış sunumu PDF olarak kaydedin.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

Bu kod, notları içeren bir PDF elde etmek için bir PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Not Düzeni ile PDF seçeneklerini yapılandırın.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu notlarla bir PDF olarak kaydedin.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza izin verir. PowerPoint belgesini PDF'ye şu uyumluluk standartlarından biriyle dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Aşağıdaki kod, farklı uyumluluk standartlarına göre birden fazla PDF oluşturan bir PowerPoint‑to‑PDF dönüşüm sürecini gösterir:

```java
import com.aspose.slides.*;

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
Aspose.Slides, PDF dosyalarını popüler formatlara dönüştürmenizi sağlayan PDF dönüşüm işlemlerini destekler. [PDF to HTML](https://products.aspose.com/slides/tr/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/tr/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/java/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/tr/java/conversion/pdf-to-xml/) gibi özel formatlara dönüşüm de desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken Aspose.Slides, SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve yapay öğeler olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

### Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyerek dönüşüm sürecini programlı olarak uygulayabilirsiniz.

### Dönüştürülen PDF'yi şifreyle korumak mümkün mü?

Kesinlikle. Dönüştürme sırasında şifre ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfını kullanın.

### PDF'ye gizli slaytları nasıl ekleyebilirim?

Sonuç PDF'de gizli slaytları dahil etmek için [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki `setShowHiddenSlides` yöntemini kullanın.

### Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?

Evet, `[PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/)` sınıfındaki `setJpegQuality` ve `setSufficientResolution` gibi yöntemleri kullanarak PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

### Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlara uygun PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Android via Java Documentation](/slides/tr/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/tr/androidjava/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)