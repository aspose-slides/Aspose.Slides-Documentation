---
title: Java'da PPT ve PPTX'yi PDF'ye Dönüştürme [Gelişmiş Özellikler Dahil]
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
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint PPT/PPTX'yi yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

Java'da PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak, aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfına argüman olarak aktarın ve ardından sunumu bir [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java, çıktı belgelere API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** Aspose.Slides'in bu bilgiyi çıktı belgelerinden değiştirmesini veya kaldırmasını isteyemezsiniz.
{{% /alert %}}

Aspose.Slides şunları dönüştürmenize izin verir:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, bir sunumu PDF'ye dışa aktarır ve oluşan PDF'lerin orijinal sunuma olabildiğince benzemesini sağlar. Dönüşüm sırasında öğeler ve nitelikler doğru bir şekilde işlenir, aşağıdakiler dahil:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Başlıklar ve altbilgiler
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştürme**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek, bir sunumu yükler ve varsayılan dışa aktarım ayarlarını kullanarak tüm görünür slaytları PDF olarak kaydeder.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint'ten PDF'ye dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştürme**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sunarak, oluşturulan PDF'yi özelleştirmenize, PDF'yi bir parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenize olanak tanır.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştürme**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirtebilir, metin için bir sıkıştırma seviyesi ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, bir sunumu PDF 1.5 olarak dışa aktarır; JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması uygulanır.

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

### **Görüntü Sıkıştırmasını Otomatik Olarak Seçme**

Bir sunumda birçok fotoğraf veya ekran görüntüsü bulunduğunda, dışa aktarılan PDF'nin boyutunu küçültmek e-posta veya indirme işlemlerini kolaylaştırabilir. PDF dışa aktarımı sırasında her görüntü için en uygun sıkıştırma algoritmasını otomatik olarak seçmek için [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) yöntemini `true` ile çağırın.

Aşağıdaki örnek, mevcut bir sunumu yükler, otomatik görüntü sıkıştırma seçimini etkinleştirir ve PDF belgesi olarak kaydeder. Diğer tüm PDF dışa aktarım ayarları varsayılan değerlerini korur.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Bu seçenek, her görüntü için bir sıkıştırma algoritması seçer. [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) parametresine verilen değeri azaltmak JPEG görüntü kalitesini düşürürken, [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) parametresine verilen değeri azaltmak görüntülerin daha düşük çözünürlüğe düşürülmesine izin verir ve detay kaybına yol açabilir. Otomatik sıkıştırma seçimini etkinleştirmek bu ayarları kendi başına düşürmez.

Görüntü sıkıştırma algoritmalarının seçilmesi ek işlem süresi ve bellek gerektirir. Boyut azaltma, sunumun görüntülerine ve dışa aktarım ayarlarına bağlıdır; her sunum için sabit bir azalma garanti edilmez.

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Eğer bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının hem çalışma kitabının verilerine erişmesini hem de slaytları görmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) yöntemini `true` ile çağırın.

Varsayılan değer `false`'tur: OLE nesnesinin önizleme görüntüsü veya simgesi PDF sayfasında gösterilir, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `true` olarak ayarlamak ek olarak dosya verisini de içerir. Önizleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı olarak açmasına veya kaydetmesine izin verir. OLE nesnesi, PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

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

1. PDF'yi, Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide açın.
2. Görüntüleyicinin **Attachments** (Ekler) panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki önizleme ek'ten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bunlar standartların gereksinimleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştürme**

Eğer bir sunum gizli slaytlar içeriyorsa, [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) yöntemini kullanarak gizli slaytları sonuç PDF'de sayfa olarak dahil edebilirsiniz.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve tüm gizli slaytları da içerir.

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

### **PowerPoint'i Şifre Koruması Olan PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumu `password` şifresiyle açılması gereken bir PDF'ye dışa aktarır. Erişim izinleri, yüksek kalite baskı da dahil olmak üzere baskıya izin verir.

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

### **Yazı Tipi İkamelerini Algılama**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfı altında [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) yöntemini sağlar; bu, sunumdan PDF'ye dönüşüm sırasında yazı tipi ikamelerini algılamanızı sağlar.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve yazı tipi ikameleri uyarılarını konsola yazdırır. Uyarı, yalnızca kullanılabilir olmayan bir yazı tipi dışa aktarım sırasında ikame edildiğinde yazdırılır.

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

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini Ele Alma**

Bir sunum, fontunun ayrı bir kalın tipine sahip olmamasına rağmen metne kalın biçimlendirme uygulayabilir. Metin, düzenli glifleri yapay olarak kalınlaştıran sentetik kalınlaştırma sayesinde yine de kalın görünebilir. Bu metin PDF'de çok ağır veya istenen görünüme uymuyorsa, [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) yöntemini `true` ile çağırmayı deneyin. Bu seçenek, etkilenen metni PDF dışa aktarımı sırasında bir bitmap olarak işler ve bazı fontlarda görünümünü iyileştirebilir. Varsayılan değeri `false`'tur.

Örnek sunum, aynı fonta sahip iki metin kutusu içerir; biri normal metin, diğeri ise ayrı bir kalın tipine sahip olmayan aynı fontta kalın biçimlendirme uygulanmıştır. Aşağıdaki örnek, sunumu yükler, desteklenmeyen font stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

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

Aşağıdaki ön izlemeler, devre dışı bırakılmış çıktıyı ve etkinleştirilmiş çıktıyı gösterir. Bu örnekte, seçenek devre dışı olduğunda kalın metnin çizgileri daha kalındır. Seçenek etkin olduğunda çizgileri daha hafiftir; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![Desteklenmeyen font stili rasterleştirilmesi devre dışı olan PDF](unsupported-bold-disabled.png) | ![Desteklenmeyen font stili rasterleştirilmesi etkin olan PDF](unsupported-bold-enabled.png) |

Bu örnekte, seçeneği etkinleştirmek yalnızca kalın metni bir bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir kalır. Seçenek devre dışı olduğunda, her iki metin de metin olarak kalır.

Bu seçenek, fontunun ayrı bir kalın tipine sahip olmadığı durumlarda kalın biçimlendirilmiş metni rasterleştirir. [Yazı Tipi İkamesi](/slides/tr/java/font-substitution/) ise orijinal mevcut olmadığında başka bir font seçer.

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizideki slayt numaraları bir tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **PowerPoint'i Özel Slayt Boyutu ile PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumdan ilk slaytı 612 × 792 puan (8,5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriği buna göre ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

    // Yeni oluşturulan sunumun boş slaytını kaldır.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştürme**

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

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz.

Bu kod, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

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
Aspose.Slides PDF dönüşüm işlemlerini destekler, PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF'den HTML'ye](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF'den Görüntüye](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) ve [PDF'den PNG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Diğer PDF dönüşüm işlemleri, uzmanlaşmış formatlar—[PDF'den SVG'ye](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF'den TIFF'e](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) ve [PDF'den XML'e](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—da desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca tüm şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını toplu olarak PDF'ye dönüştürmeyi destekler. Dosyalarınızda döngü oluşturup dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle korumak mümkün mü?**

Evet. Dönüşüm sürecinde bir şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfını kullanın.

**PDF'ye gizli slaytları nasıl dahil ederim?**

PDF'de gizli slaytları dahil etmek için, [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfında [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) yöntemini `true` ile çağırın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) ve [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [çeşitli standartlar](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) ile uyumlu PDF'ler dışa aktarmanıza olanak tanır; bu sayede belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Java Belgeleri](/slides/tr/java/)
- [Aspose.Slides for Java API Referansı](https://reference.aspose.com/slides/java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)