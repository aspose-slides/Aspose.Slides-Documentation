---
title: PPT ve PPTX'i Android'de PDF'ye Dönüştür [Gelişmiş Özellikler Dahil]
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
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX'i Java'da Aspose.Slides for Android kullanarak yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Android'de PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ve biçimlendirmesinin korunması gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını parola korumalı hale getirmeyi, yazı tipi ikamelerini algılamayı, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını bir argüman olarak [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfına gönderin ve ardından sunumu bir PDF olarak bir [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle kaydedin. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini ortaya çıkarır.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Android via Java, çıktılara API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Uygulama alanını "*Aspose.Slides*" ve PDF Üretici alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** Aspose.Slides'in bu bilgileri çıktılardan değiştirmesini veya kaldırmasını isteyemezsiniz.

{{% /alert %}}

Aspose.Slides, şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarırken ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru şekilde işlenir, bunlar arasında:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üst bilgi ve alt bilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides, sağlanan sunumu mümkün olan en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve varsayılan dışa aktarma ayarlarını kullanarak tüm görünür slaytları PDF olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose, çevrimiçi ücretsiz bir [**PowerPoint PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar ve bu, sunumdan PDF'ye dönüşüm sürecini gösterir. Bu dönüştürücüyle bir test çalıştırarak burada açıklanan prosedürün canlı bir uygulamasını görebilirsiniz.

{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfı altında yer alan özelleştirilebilir seçenekler—özellikler—sağlayarak oluşan PDF'yi özelleştirmenize, PDF'yi bir parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanır.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özelleştirilmiş dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini belirtebilir, metin için bir sıkıştırma seviyesi ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının hem slaytları görüntülemesini hem de çalışma kitabının verilerine erişmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) yöntemini `true` ile çağırın.

Varsayılan değer `false`'tur: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `true` olarak ayarlamak ek olarak dosya verisini de içerir. Ön izleme görsel bir temsil olmaya devam eder; ek, alıcıların gömülü dosyayı ayrı ayrı açmasına veya kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Sonucu kontrol etmek için:

1. Export edilen PDF'yi dosya eklerini destekleyen bir görüntüleyicide, örneğin Adobe Acrobat Reader'da açın.  
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.  
3. Ek'i kaydedin ve Excel'de verilerini incelemek için açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ekten ayrı bir şeydir.

{{% alert color="info" title="Note" %}}

PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları da dahil olmak üzere diğer dosya türlerine izin verir. Bu gereksinimler standartların kendisinden kaynaklanır, Aspose.Slides'e özgü bir kısıtlama değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmasını göstermez.

{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) yöntemini [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfından kullanarak gizli slaytları sonuç PDF'de sayfa olarak ekleyebilirsiniz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Parola Korumalı PDF Olarak PowerPoint'i Dönüştür**

Aşağıdaki örnek, açmak için `password` parolasını gerektiren bir PDF olarak bir sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı dahil olmak üzere yazdırmaya izin verir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Yazı Tipi Değiştirmelerini Algıla**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfı altında [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metodunu sunar ve bu, sunumdan PDF'ye dönüşüm sırasında yazı tipi ikamelerini algılamanızı sağlar.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Yazı tipi ikameleri hakkında daha fazla bilgi için [Yazı Tipi Değiştirme](/slides/tr/androidjava/font-substitution/) makalesine bakın.

{{% /alert %}} 

## **PowerPoint'ten Seçilen Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF olarak dışa aktarır. Bu dizideki slayt numaraları bir tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Özel Slayt Boyutuyla PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan ilk slaytı 612 × 792 nokta (8,5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF olarak dışa aktarır.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Yeni sunum oluşturulurken eklenen boş slaytı kaldır.

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumu PDF olarak dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, aşağıdaki uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu kod, farklı uyumluluk standartlarına göre birden fazla PDF oluşturan bir PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

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

{{% alert color="info" title="Note" %}}

Aspose.Slides PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF'den HTML'ye](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF'den görüntüye](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), ve [PDF'den PNG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Özel formatlara dönüşümler—[PDF'den SVG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF'den TIFF'e](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), ve [PDF'den XML'e](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—da desteklenir.

{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides, SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını PDF'ye toplu olarak dönüştürmeyi destekler. Dosyalarınızda gezinebilir ve dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi parola korumalı yapabilir miyim?**

Evet. Dönüşüm sırasında bir parola ayarlamak ve erişim izinlerini belirlemek için [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**PDF'de gizli slaytları nasıl dahil ederim?**

Gizli slaytları sonuç PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metodunu `true` olarak çağırın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) ve [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) gibi yöntemlerle görüntü kalitesini kontrol edebilir ve PDF'nizde yüksek kaliteli görseller elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [çeşitli standartlara](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) uygun PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Android via Java Belgeleri](/slides/tr/androidjava/)
- [Aspose.Slides for Android via Java API Referansı](https://reference.aspose.com/slides/androidjava/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)