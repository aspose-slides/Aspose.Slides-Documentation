---
title: "Java'da PPT ve PPTX'i PDF'ye Dönüştürün [Gelişmiş Özellikler Dahil]"
linktitle: "PowerPoint'tan PDF'ye"
type: docs
weight: 40
url: /tr/java/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint dönüştür"
- "sunumu dönüştür"
- "PowerPoint'tan PDF'ye"
- "sunumu PDF'ye"
- "PPT'den PDF'ye"
- "PPT'yi PDF'ye dönüştür"
- "PPTX'den PDF'ye"
- "PPTX'i PDF'ye dönüştür"
- "PowerPoint'i PDF olarak kaydet"
- "PPT'yi PDF olarak kaydet"
- "PPTX'i PDF olarak kaydet"
- "PPT'yi PDF'ye dışa aktar"
- "PPTX'i PDF'ye dışa aktar"
- "ek"
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleri içerir."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Java'da PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi birçok avantaj sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, dönüşüm için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu bir PDF olarak [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle kaydedin. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java, API bilgilerini ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Uygulama alanını "*Aspose.Slides*" ve PDF Üretici alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** bu bilgileri çıktı belgelerinden değiştiremez veya kaldıramazsınız.
{{% /alert %}}

Aspose.Slides aşağıdakileri dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, PDF'ye dışa aktarılan PDF'lerin orijinal sunumlarla çok yakın bir eşleşme sağlamasını garantiler. Dönüşüm sırasında öğeler ve özellikler doğru bir şekilde işlenir, şunlar dahil:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'ten PDF'ye Dönüştürme**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek, bir sunumu yükler ve varsayılan dışa aktarma ayarlarını kullanarak tüm görünür slaytları PDF olarak kaydeder.

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
Aspose, sunum‑pdf dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Bu dönüştürücü ile burada anlatılan prosedürün canlı bir uygulamasını test edebilirsiniz.
{{% /alert %}}

## **PowerPoint'ten PDF'ye Seçeneklerle Dönüştürme**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfındaki özellikler aracılığıyla sonuç PDF'yi özelleştirmenize, PDF'yi bir şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan özel seçenekler sunar.

### **PowerPoint'ten Özel Seçeneklerle PDF'ye Dönüştürme**

Özel dönüşüm seçenekleri kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin için bir sıkıştırma seviyesi ayarlayabilir, görüntü DPI'sını yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilen ve Flate metin sıkıştırması kullanılan PDF 1.5'e bir sunumu dışa aktarır.

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

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının hem veri setine erişebilmesini hem de slaytları görüntüleyebilmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak tutmak için `true` ile [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metodunu çağırın.

Varsayılan değer `false`'tır: OLE nesnesinin ön izleme resmi ya da simgesi PDF sayfasında işlenir, ancak gömülü dosya ek olarak eklenmez. Seçeneği `true` yaparsanız dosya verileri ek olarak da dahil edilir. Ön izleme görsel bir temsildir; ek, alıcıların gömülü dosyayı ayrı ayrı açmasına ya da kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfası haline gelmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabını ekli olarak PDF'ye dışa aktarır.

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

1. PDF'yi, ekleri destekleyen bir görüntüleyicide (ör. Adobe Acrobat Reader) açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve Excel'de açarak verileri inceleyin veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ekten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler konusunda kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 diğer dosya türlerini, Excel çalışma kitapları dahil, kabul eder. Bu, standartların gereksinimleridir, Aspose.Slides'e özgü bir kısıtlama değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermemektedir.
{{% /alert %}}

### **Gizli Slaytlarla PDF'ye Dönüştürme**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak dahil etmek için [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metodunu kullanabilirsiniz.

Aşağıdaki örnek, gizli slaytları da dahil ederek bir sunumu PDF'ye dışa aktarır.

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

### **Şifre Koruması Olan PDF'ye Dönüştürme**

Aşağıdaki örnek, `password` şifresiyle açılması gereken bir PDF'ye bir sunumu dışa aktarır. Erişim izinleri, yüksek kalite baskı dahil baskıya izin verir.

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

### **Yazı Tipi İkamelerini Tespit Etme**

Aspose.Slides, sunum‑pdf dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfı altındaki [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metodunu sunar.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve yazı tipi ikame uyarılarını konsola yazar. Bir yazı tipi bulunamadığında ve ikame edildiğinde yalnızca bir uyarı yazdırılır.

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
Yazı tipi ikameleri hakkında daha fazla bilgi için [Yazı Tipi İkamesi](/slides/tr/java/font-substitution/) makalesine bakın.
{{% /alert %}} 

## **PowerPoint'ten Seçilen Slaytları PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizi içindeki slayt numaraları 1 tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **Özel Slayt Boyutu ile PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 puan (8,5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığdırmak için ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

    // Yeni oluşturulan sunumdaki boş slaytı kaldır.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slaytı Görünümünde PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. PowerPoint belgenizi aşağıdaki uyumluluk standartlarından biriyle PDF'ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Aşağıdaki kod, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint‑PDF dönüşüm sürecini gösterir:

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
Aspose.Slides PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenizi sağlar. [PDF'den HTML'ye](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF'den görüntüye](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), ve [PDF'den PNG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-png/) dönüşümleri yapabilirsiniz. Özel formatlara yönelik diğer PDF dönüşüm işlemleri—[PDF'den SVG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF'den TIFF'ye](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), ve [PDF'den XML'e](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—da desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir figür olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün figür için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**  
Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını PDF'ye toplu olarak dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyerek dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifre korumalı yapma imkanı var mı?**  
Evet. Dönüşüm sırasında bir şifre ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'ye nasıl dahil ederim?**  
Gizli slaytları sonuç PDF'ye dahil etmek için [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metodunu `true` olarak ayarlayın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**  
Evet, [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) ve [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) gibi yöntemlerle PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**  
Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [çeşitli standartlara](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) uyumlu PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Java Belgeleri](/slides/tr/java/)
- [Aspose.Slides for Java API Referansı](https://reference.aspose.com/slides/java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)