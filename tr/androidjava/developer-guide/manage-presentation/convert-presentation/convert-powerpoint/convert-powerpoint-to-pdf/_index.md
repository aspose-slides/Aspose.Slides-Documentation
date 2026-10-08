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
- PPTX'ten PDF'ye
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
description: "Aspose.Slides for Android'ı kullanarak Java'da PowerPoint PPT/PPTX'i yüksek kalite, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Android cihazlarda PDF formatına dönüştürmek, farklı cihazlarda uyumluluk, sunumunuzun düzen ve biçimlendirmesinin korunması gibi birçok avantaj sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları eklemeyi, PDF dosyalarını parola ile korumayı, yazı tipi ikamelerini tespit etmeyi, dönüştürülecek belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüştürmeler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfına argüman olarak geçin ve ardından sunumu bir [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı, tipik olarak bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java, API bilgisi ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'ye dönüştürdüğünüzde Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" şeklinde doldurur. **Not** ki bu bilgiyi çıktı belgelerinden değiştirmeniz veya kaldırmanız mümkün değildir.
{{% /alert %}}

Aspose.Slides aşağıdakileri dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarırken sonuç PDF'lerin orijinal sunumlara olabildiğince yakın olmasını sağlar. Dönüştürme sırasında aşağıdaki öğeler ve öznitelikler doğru şekilde işlenir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Hipermetin bağlantıları
* Üst bilgi ve alt bilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'ten PDF'ye Dönüştür**

Standart PowerPoint‑to‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

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
Aspose, ücretsiz bir çevrimiçi [**PowerPoint'ten PDF'ye dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar ve sunum‑to‑PDF dönüştürme sürecini gösterir. Buradaki prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'ten PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler‑özellikleri sunar; bu seçenekler sonucu PDF'yi özelleştirmenize, PDF'yi parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanır.

### **PowerPoint'ten PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilen ve Flate metin sıkıştırması kullanılan bir PDF 1.5 dışa aktarır.

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

Bir sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının hem çalışma kitabının verilerine erişmesini hem de slaytları görüntülemesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak tutmak için `true` ile [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metodunu çağırın.

Varsayılan değer `false`’tır: OLE nesnesinin ön izleme resmi ya da simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak bulunmaz. Seçeneği `true` yaparsanız dosya verileri de eklenir. Ön izleme görsel temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı ayrı açıp kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

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
2. Görüntüleyicinin **Attachments** (Ekler) panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve Excel'de açarak verileri inceleyin veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ekten ayrı bir varlıktır.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir, PDF/A-3 ise Excel çalışma kitapları da dahil olmak üzere diğer dosya türlerine izin verir. Bu gereksinimler standartların kendisinden kaynaklanır, Aspose.Slides'e özgü bir kısıtlama değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmayı göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'ten PDF'ye Dönüştür**

Bir sunumda gizli slaytlar varsa, [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metodunu [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfından çağırarak gizli slaytları sonuç PDF'de sayfa olarak ekleyebilirsiniz.

Aşağıdaki örnek, gizli slaytları da içerecek şekilde bir sunumu PDF'ye dışa aktarır.

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

### **Parola Korumalı PDF'ye PowerPoint Dönüştür**

Aşağıdaki örnek, açmak için `password` parolası gerektiren bir PDF olarak bir sunumu dışa aktarır. Erişim izinleri, yüksek kalite baskı dahil olmak üzere yazdırmaya izin verir.

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

### **Yazı Tipi Değiştirmelerini Tespit Et**

Aspose.Slides, sunum‑to‑PDF dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metodunu [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfı altında sunar.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve font ikameleri uyarılarını konsola yazdırır. Uyarı yalnızca dışa aktarım sırasında bulunamayan bir yazı tipi ikame edildiğinde basılır.

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

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşle**

Bir sunum, kalın bir yazı tipi içermeyen bir font için dahi kalın biçimlendirme uygulayabilir. Metin, sentetik kalınlaştırma (synthetic bolding) ile hâlâ kalın görünebilir; bu yöntem, normal glifleri yapay olarak kalınlaştırır. Bu metin PDF'de çok ağır görünüyorsa veya istenen görünüme uymuyorsa, `true` ile [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) metodunu çağırmayı deneyin. Bu seçenek, PDF dışa aktarımı sırasında etkilenen metni bitmap olarak işler ve belirli yazı tipleri için görünümünü iyileştirebilir. Varsayılan değer `false`’tır.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı fonta kalın biçimlendirme uygulanmış, ancak fontun ayrı bir kalın tipface’i yoktur. Aşağıdaki örnek, sunumu yükler, desteklenmeyen yazı tipi stillerinin rasterizasyonunu etkinleştirir ve PDF'ye dışa aktarır:

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

Aşağıdaki ön izlemeler, devre dışı ve etkin çıktıyı gösterir. Bu örnekte, seçenek devre dışıyken kalın metnin çizgileri daha ağırdır. Seçenek etkin olduğunda çizgileri daha ince; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Bu örnekte, seçeneği etkinleştirmek yalnızca kalın metni bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin araştırılabilir kalır. Seçenek devre dışıyken her iki dize de metin olarak kalır.

Bu seçenek, fontun ayrı bir kalın tipface’i yoksa kalın biçimlendirilmiş metni rasterleştirir. [Yazı Tipi Değiştirme](/slides/tr/androidjava/font-substitution/) ise orijinal font bulunamadığında başka bir font seçer.

## **PowerPoint'ten PDF'ye Seçili Slaytları Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizi içinde slayt numaraları bir‑tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **Özel Slayt Boyutu ile PowerPoint'ten PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını yeni bir sunuma 612 × 792 puan (8.5 × 11 inç) slayt boyutuyla kopyalar. Slayt içeriğini sığdırmak için ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

## **Not Slaytı Görünümünde PowerPoint'ten PDF'ye Dönüştür**

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

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web İçerik Erişilebilirlik İlkeleri (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. PowerPoint belgenizi aşağıdaki uyumluluk standartlarından herhangi birini kullanarak PDF'ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

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
Aspose.Slides, PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. Şu dönüştürmeleri gerçekleştirebilirsiniz: [PDF'den HTML'ye](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF'den resme](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), ve [PDF'den PNG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-png/) dönüşümleri. Özelleşmiş formatlara PDF dönüşüm işlemleri de desteklenir—[PDF'den SVG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF'den TIFF'ye](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), ve [PDF'den XML'ye](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) dönüşümleri.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken Aspose.Slides, SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını PDF'ye toplu olarak dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyerek programlı olarak dönüşüm sürecini uygulayabilirsiniz.

**Dönüştürülen PDF'yi parola ile koruyabilir miyim?**

Evet. Dönüşüm sürecinde bir parola ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl dahil ederim?**

Gizli slaytları sonuç PDF'ye dahil etmek için [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfında `true` ile [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metodunu çağırın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) ve [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) gibi yöntemleri kullanarak PDF'nizde yüksek kaliteli görüntüler sağlayabilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA gibi [çeşitli standartlara](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) uyumlu PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Android via Java Belgeleri](/slides/tr/androidjava/)
- [Aspose.Slides for Android via Java API Referansı](https://reference.aspose.com/slides/androidjava/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)