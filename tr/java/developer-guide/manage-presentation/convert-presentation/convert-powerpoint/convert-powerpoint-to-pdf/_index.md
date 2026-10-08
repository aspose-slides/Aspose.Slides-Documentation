---
title: "Java'da PPT ve PPTX'yi PDF'ye Dönüştür [Gelişmiş Özellikler Dahil]"
linktitle: "PowerPoint'ten PDF'ye"
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
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint PPT/PPTX'yi yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Java’da PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzen ve biçimlendirmesinin korunması gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları eklemeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini algılamayı, dönüşüm için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides kullanarak, aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını bir argüman olarak [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfına aktarın ve ardından sunumu PDF olarak [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle kaydedin. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java, çıktı belgelerine API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** bu bilgiyi çıktı belgelerinden değiştiremez veya kaldıramazsınız.
{{% /alert %}}

Aspose.Slides size şunları dönüştürme imkanı verir:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktarır, böylece ortaya çıkan PDF'ler orijinal sunumlarla yakından eşleşir. Dönüşüm sırasında öğeler ve öznitelikler doğru şekilde işlenir, bunlar şunları içerir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve tüm görünür slaytları varsayılan dışa aktarma ayarlarıyla PDF'ye kaydeder.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint PDF Dönüştürücüsü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i Seçeneklerle PDF'ye Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sağlar.

### **PowerPoint'i Özel Seçeneklerle PDF'ye Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini seçebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek sunumu PDF 1.5'e, JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması ile dışa aktarır.

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

Bir sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının sadece slaytları değil, aynı zamanda çalışma kitabının verilerine de erişmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için `true` ile [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metodunu çağırın.

Varsayılan değer `false`'tur: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasında işlenir, ancak gömülü dosya ek olarak eklenmez. Seçeneği `true` yaparak dosya verileri de eklenir. Ön izleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı olarak açmasını veya kaydetmesini sağlar. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

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

1. PDF'yi ekleri destekleyen bir görüntüleyicide, örneğin Adobe Acrobat Reader'da açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve Excel'de açarak verilerini inceleyin veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ek'ten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler konusunda kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 diğer dosya türlerini, Excel çalışma kitapları dahil, izin verir. Bu kısıtlamalar standartların gereksinimleridir, Aspose.Slides'e özgü bir sınırlama değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Bir sunumda gizli slaytlar varsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfından [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) yöntemini kullanabilirsiniz.

Aşağıdaki örnek gizli slaytlar dahil olmak üzere bir sunumu PDF'ye dışa aktarır.

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

### **Şifre Koruması Olan PDF'ye PowerPoint'i Dönüştür**

Aşağıdaki örnek bir sunumu, açmak için `password` şifresini gerektiren bir PDF'ye dışa aktarır. Erişim izinleri, yüksek kaliteli baskı dahil baskıya izin verir.

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

### **Yazı Tipi İkamelerini Algıla**

Aspose.Slides, sunumdan PDF'ye dönüşüm sürecinde yazı tipi ikamelerini algılamanızı sağlayan [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfı altında [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) yöntemini sunar.

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve font ikamesi uyarılarını konsola yazar. Bir uyarı yalnızca kullanılmayan bir font dışa aktarım sırasında ikame edildiğinde yazdırılır.

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

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşle**

Bir sunum, fontunun ayrı bir kalın tipine sahip olmamasına rağmen metne kalın biçimlendirme uygulayabilir. Metin, normal glifleri yapay olarak kalınlaştıran sentetik kalınlaştırma sayesinde hâlâ kalın görünebilir. Bu metin PDF'de çok ağır görünürse veya istenen görünümden farklıysa, `true` ile [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) metodunu çağırmayı deneyin. Bu seçenek, ilgili metni PDF dışa aktarımı sırasında bitmap olarak işler ve belirli fontlar için görünümünü iyileştirebilir. Varsayılan değeri `false`'tur.

Örnek sunum iki metin kutusu içerir: birinde normal metin, diğerinde aynı fonta kalın biçimlendirme uygulanmış ancak ayrı bir kalın tipine sahip olmayan bir font. Aşağıdaki örnek sunumu yükler, desteklenmeyen font stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Aşağıdaki ön izlemeler devre dışı çıktıyı ve etkin çıktıyı gösterir. Bu örnekte, seçenek devre dışı iken kalın metnin hatları daha ağırdır. Seçenek etkin olduğunda hatları daha hafiftir; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF, desteklenmeyen yazı tipi stili rasterleştirme devre dışı](unsupported-bold-disabled.png) | ![PDF, desteklenmeyen yazı tipi stili rasterleştirme etkin](unsupported-bold-enabled.png) |

Bu örnekte, seçenek etkinleştirildiğinde yalnızca kalın metin bitmap'e dönüşür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları 800% yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir olmaya devam eder. Seçenek devre dışı olduğunda, her iki dize de metin olarak kalır.

Bu seçenek, fontunun ayrı bir kalın tipine sahip olmaması durumunda kalın biçimlendirilmiş metni bitmap'e dönüştürür. [Yazı Tipi İkamesi](/slides/tr/java/font-substitution/) ise orijinal font mevcut değilse başka bir font seçer.

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek bir sunumdan slayt 1 ve 3'ü PDF'ye dışa aktarır. Bu dizi içindeki slayt numaraları 1 tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **Özel Slayt Boyutu ile PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek bir sunumun ilk slaytını, 612 × 792 nokta (8.5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slayt Görünümünde PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır, her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web İçerik Erişilebilirlik Yönergeleri (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza izin verir. Bu uyumluluk standartlarından herhangi birini kullanarak bir PowerPoint belgesini PDF'ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu kod, farklı uyumluluk standartlarına göre birden çok PDF üreten bir PowerPoint‑to‑PDF dönüşüm sürecini gösterir:

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
Aspose.Slides, PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya biçimlerine dönüştürmenize olanak tanır. Şu dönüşümleri gerçekleştirebilirsiniz: [PDF'den HTML'ye](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF'den görüntüye](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), ve [PDF'den PNG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-png/) dönüşümleri. Uzmanlaşmış formatlara dönüşüm işlemleri de desteklenir: [PDF'den SVG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF'den TIFF'e](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), ve [PDF'den XML'e](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) dönüşümleri.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**  
Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını PDF'ye toplu olarak dönüştürmeyi destekler. Dosyalarınızda dolaşabilir ve dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle korumak mümkün mü?**  
Evet. Dönüştürme sırasında şifre ve erişim izinlerini ayarlamak için [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfını kullanın.

**PDF'ye gizli slaytları nasıl ekleyebilirim?**  
Sonuç PDF'sine gizli slaytları eklemek için [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) yöntemini `true` ile [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfında çağırın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**  
Evet, [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) ve [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) gibi yöntemleri [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfında kullanarak PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**  
Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [çeşitli standartlar](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) uyumlu PDF'ler dışa aktarmanıza izin verir, böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Java Belgeleri](/slides/tr/java/)
- [Aspose.Slides for Java API Referansı](https://reference.aspose.com/slides/java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)