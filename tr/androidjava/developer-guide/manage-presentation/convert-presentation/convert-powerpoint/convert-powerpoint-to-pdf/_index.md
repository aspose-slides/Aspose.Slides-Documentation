---
title: Android'de PPT ve PPTX'yi PDF'ye Dönüştür [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF
type: docs
weight: 40
url: /tr/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PowerPoint'ten PDF'ye
- sunumdan PDF'ye
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
description: "Aspose.Slides for Android kullanarak Java'da PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleri içerir."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Android üzerinde PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ve biçimlendirmesinin korunması gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini algılamayı, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'den PDF Dönüşümleri**

Aspose.Slides kullanarak, aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını [Sunum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu PDF olarak [kaydet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle kaydedin. [Sunum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [kaydet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini sağlar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java, çıktı belgelerine API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Uygulama alanını "*Aspose.Slides*" ve PDF Üreticisi alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** Aspose.Slides'in bu bilgileri çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamayacağınızı unutmayın.
{{% /alert %}}

Aspose.Slides şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, şunları içerir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'e Dönüştür**

Standart PowerPoint‑to‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve varsayılan dışa aktarma ayarlarıyla tüm görünür slaytları PDF olarak kaydeder.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint'ten PDF'ye dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını denemek için bu dönüştürücüyle bir test çalıştırabilirsiniz.
{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'e Dönüştür**

Aspose.Slides, sonucu PDF'yi özelleştirmenizi, PDF'yi bir parola ile kilitlemenizi veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sunar.

### **Özel Seçeneklerle PowerPoint'i PDF'e Dönüştür**

Özel dönüşüm seçenekleriyle, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini seçebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

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

### **Görüntü Sıkıştırmasını Otomatik Seç**

Bir sunumda birçok fotoğraf veya ekran görüntüsü olduğunda, dışa aktarılan PDF'nin boyutunu küçültmek e-posta göndermeyi veya indirmeyi kolaylaştırabilir. PDF dışa aktarımı sırasında her görüntü için en uygun sıkıştırma algoritmasını otomatik olarak seçmek için [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) metodunu `true` ile çağırın.

Aşağıdaki örnek mevcut bir sunumu yükler, otomatik görüntü sıkıştırması seçimini etkinleştirir ve onu PDF belgesi olarak kaydeder. Diğer tüm PDF dışa aktarım ayarları varsayılan değerlerini korur.

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

Bu seçenek her görüntü için bir sıkıştırma algoritması seçer. [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) metoduna geçirilen değeri düşürmek JPEG görüntü kalitesini azaltırken, [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) metoduna geçirilen değeri düşürmek görüntülerin daha düşük çözünürlüğe indirgenmesine izin verir; bu da ayrıntıyı azaltabilir. Otomatik sıkıştırma seçiminin kendisi bu ayarları düşürmez.

Görüntü sıkıştırma algoritmalarının seçilmesi ek işleme süresi ve bellek gerektirir. Boyut azalması, sunumun görüntülerine ve dışa aktarım ayarlarına bağlıdır; her sunum için sabit bir azalma garantilenmez.

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Bir sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının yalnızca slaytları görmekle kalmayıp çalışma kitabının verilerine de erişmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak tutmak için [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metodunu `true` ile çağırın.

Varsayılan değer `false`tır: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasında render edilir, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `true` yaparsanız dosya verisi de eklenir. Ön izleme görsel bir temsil olmaya devam eder; ek, alıcıların gömülü dosyayı ayrı olarak açmasına veya kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

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

1. PDF'yi ekleri destekleyen bir görüntüleyicide (ör. Adobe Acrobat Reader) açın.
2. Görüntüleyicinin **Attachments** (Ekler) panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme, eklentiden ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir, PDF/A-3 ise Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermemektedir.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'e Dönüştür**

Bir sunumda gizli slaytlar bulunuyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metodunu [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfından `true` olarak ayarlayabilirsiniz.

Aşağıdaki örnek bir sunumu PDF'e dışa aktarır ve gizli slaytları da içerir.

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

### **Şifre Koruması Olan PDF ile PowerPoint'i Dönüştür**

Aşağıdaki örnek, açmak için `password` şifresi gerektiren bir PDF olarak sunumu dışa aktarır. Erişim izinleri, yüksek kalite baskı dahil olmak üzere baskıya izin verir.

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

Aspose.Slides, [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metodunu [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfı altında sağlar; bu sayede sunum‑PDF dönüşüm sürecinde yazı tipi ikamelerini algılayabilirsiniz.

Aşağıdaki örnek bir sunumu PDF olarak dışa aktarır ve yazı tipi ikameleriyle ilgili uyarıları konsola yazdırır. İkame yalnızca kullanılabilir olmayan bir yazı tipi dışa aktarım sırasında değiştirildiğinde uyarı üretilir.

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
Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/androidjava/font-substitution/) makalesine bakın.
{{% /alert %}} 

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşle**

Bir sunum, fontunda ayrı bir kalın tip bulunmasa bile kalın biçimlendirme uygulayabilir. Metin, sentetik kalınlaştırma yoluyla kalın görünebilir; bu, normal glifleri yapay olarak kalınlaştırır. Bu metin PDF'de çok ağır veya beklentiden farklı görünürse, [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) metodunu `true` ile çağırmayı deneyin. Bu seçenek, PDF dışa aktarımı sırasında etkilenmiş metni bir bitmap olarak render eder ve belirli yazı tipleri için görünümünü iyileştirebilir. Varsayılan değeri `false`tır.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı fontta kalın biçimlendirilmiş ancak ayrı bir kalın tip bulunmayan metin. Aşağıdaki örnek sunumu yükler, desteklenmeyen font stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

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

Aşağıdaki ön izlemeler devre dışı ve etkin çıktıyı gösterir. Bu örnekte, kalın metin seçeneği devre dışı iken daha kalın çizgilere sahiptir. Seçenek etkin olduğunda çizgileri daha ince; normal metin değişmez. Ayarı sunumunuz için seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF, desteklenmeyen yazı tipi stili rasterleştirme devre dışı](unsupported-bold-disabled.png) | ![PDF, desteklenmeyen yazı tipi stili rasterleştirme etkin](unsupported-bold-enabled.png) |

Bu örnekte, seçenek etkinleştirildiğinde yalnızca kalın metin bitmap hâline gelir: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir kalır. Seçenek devre dışı bırakıldığında ise iki metin de metin olarak kalır.

Bu seçenek, fontunda ayrı bir kalın tip bulunmadığında kalın olarak biçimlendirilmiş metni bitmap hâline getirir. [Font substitution](/slides/tr/androidjava/font-substitution/) ise orijinal font mevcut olmadığında başka bir font seçer.

## **PowerPoint'ten PDF'e Seçili Slaytları Dönüştür**

Aşağıdaki örnek bir sunumdan 1 ve 3 numaralı slaytları PDF olarak dışa aktarır. Dizi içindeki slayt numaraları 1‑tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **Özel Slayt Boyutu ile PowerPoint'i PDF'e Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 puan (8.5 × 11 inç) boyutunda yeni bir sunuma kopyalar. Slayt içeriği ölçeklenir ve tek slayt PDF olarak dışa aktarılır.

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

    // Yeni oluşturulan sunumla birlikte gelen boş slaytı kaldır.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'e Dönüştür**

Aşağıdaki örnek bir sunumu PDF'e dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. PowerPoint belgenizi aşağıdaki uyumluluk standartlarından herhangi birini kullanarak PDF'ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Aşağıdaki kod, farklı uyumluluk standartlarına göre birden çok PDF üreten bir PowerPoint‑to‑PDF dönüşüm sürecini gösterir:

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
Aspose.Slides, PDF dönüştürme işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize imkan verir. [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) gibi özel formatlara da PDF dönüştürme işlemleri desteklenmektedir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafik ve formüller gibi karmaşık grafikleri tek bir figür olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün figür için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını toplu olarak PDF'ye dönüştürmeyi destekler. Dosyalarınızı döngüyle işleyip dönüşüm sürecini programmatically uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreleyebilir miyim?**

Evet. Dönüşüm sürecinde bir şifre ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**PDF'ye gizli slaytları dahil edebilir miyim?**

Gizli slaytları sonuç PDF'ye dahil etmek için [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metodunu `true` olarak ayarlayın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) ve [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [çeşitli standartlar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) ile uyumlu PDF'ler dışa aktarmanıza olanak tanır; bu sayede belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for Android via Java Documentation](/slides/tr/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)