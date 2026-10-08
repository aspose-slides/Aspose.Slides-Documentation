---
title: "PPT ve PPTX'i .NET'te PDF'ye Dönüştür [Gelişmiş Özellikler Dahildir]"
linktitle: "PowerPoint'ten PDF'ye"
type: docs
weight: 40
url: /tr/net/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint'i dönüştür"
- "sunumu dönüştür"
- "PowerPoint'ten PDF'ye"
- "sunumu PDF'ye"
- "PPT'yi PDF'ye"
- "PPT'yi PDF'ye dönüştür"
- "PPTX'i PDF'ye"
- "PPTX'i PDF'ye dönüştür"
- "PowerPoint'i PDF olarak kaydet"
- "PPT'yi PDF olarak kaydet"
- "PPTX'i PDF olarak kaydet"
- "PPT'yi PDF'ye dışa aktar"
- "PPTX'i PDF'ye dışa aktar"
- "ek"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides kullanarak .NET'te PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı C# kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) C# ile PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ile biçimlendirmesini koruma gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları eklemeyi, PDF dosyalarını parola ile korumayı, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfına argüman olarak geçin ve ardından sunumu bir [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET, çıktı belgelerine API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** ki Aspose.Slides'e bu bilgileri çıktı belgelerinden değiştirmesini veya kaldırmasını söyleyemezsiniz.
{{% /alert %}}

Aspose.Slides size şunları dönüştürme imkanı verir:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF olarak dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlara çok yakın olmasını sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve varsayılan dışa aktarma ayarlarını kullanarak tüm görünür slaytları PDF olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose, sunumu PDF'ye dönüştürme sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint to PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenizi, PDF'yi bir parola ile kilitlemenizi veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenizi sağlayan özel seçenekler—[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfının özellikleri—sağlar.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini belirtebilir, metin için bir sıkıştırma seviyesi ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, JPEG kalitesi 90 olarak ayarlanmış, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilmiş ve Flate metin sıkıştırması kullanılan bir PDF 1.5'e sunumu dışa aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının hem slaytları görüp hem de çalışma kitabının verilerine erişmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) özelliğini `true` olarak ayarlayın.

Varsayılan değer `false`'tır: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `true` olarak ayarlamak, dosya verilerini ek olarak ekler. Ön izleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı olarak açmasına veya kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfası haline gelmez.

Aşağıdaki örnek, içinde zaten gömülü bir Excel çalışma kitabı bulunan bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Sonucu kontrol etmek için:

1. Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide dışa aktarılan PDF'yi açın.
2. Görüntüleyicinin **Attachments** (Ekler) panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ekten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları eklerle ilgili kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfındaki [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini kullanarak gizli slaytları sonuç PDF'de sayfa olarak ekleyebilirsiniz.

Aşağıdaki örnek, gizli slaytları da dahil ederek bir sunumu PDF'ye dışa aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Parola Korunmuş PDF Olarak PowerPoint'i Dönüştür**

Aşağıdaki örnek, açmak için `password` parolasını gerektiren bir PDF'ye sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı dahil olmak üzere yazdırmaya izin verir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Yazı Tipi İkamelerini Algıla**

Aspose.Slides, sunumu PDF'ye dönüştürme sürecinde yazı tipi ikamelerini algılamanızı sağlayan [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfı altındaki [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) özelliğini sunar.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve konsola yazı tipi ikamesi uyarılarını yazar. İkame yalnızca kullanılabilir olmayan bir yazı tipi dışa aktarım sırasında değiştirildiğinde uyarı verilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/net/font-substitution/) makalesine bakın.
{{% /alert %}}

### **Ayrı Bold Yazı Tipi Olmayan Yazı Tiplerini İşleyin**

Bir sunum, yazı tipinin ayrı bir bold çeşidi olmasa bile metne bold biçimlendirme uygulayabilir. Metin, normal glifleri yapay olarak kalınlaştıran sentetik bold ile yine de bold görünebilir. Bu metin PDF'de çok ağır görünüyorsa veya beklenen görünümden farklı ise, [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) özelliğini `true` olarak ayarlamayı deneyin. Bu seçenek, etkilenen metni PDF dışa aktarımı sırasında bir bitmap olarak işler ve belirli yazı tipleri için görünümünü iyileştirebilir. Varsayılan değeri `false`dır.

Örnek sunum, aynı yazı tipine uygulanan bir normal metin kutusu ve ayrı bir bold çeşidi olmayan aynı yazı tipine bold biçimlendirme uygulanmış bir metin kutusu olmak üzere iki metin kutusu içerir. Aşağıdaki örnek sunumu yükler, desteklenmeyen yazı tipi stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Aşağıdaki ön izlemeler, seçeneğin devre dışı ve etkin olduğu çıktıyı gösterir. Bu örnekte, seçenek devre dışıyken bold metin daha kalın çizgilere sahip. Seçenek etkin olduğunda çizgileri daha ince olur; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Bu örnekte, seçeneğin etkinleştirilmesi sadece bold metni bir bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir kalır. Seçenek devre dışıyken, iki metin de metin olarak kalır.

Bu seçenek, yazı tipinin ayrı bir bold çeşidi olmadığında bold olarak biçimlendirilmiş metni rasterleştirir. [Font substitution](/slides/tr/net/font-substitution/) ise orijinal mevcut olmadığında başka bir yazı tipi seçer.

## **PowerPoint'ten Seçilen Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizideki slayt numaraları 1'den başlar ve giriş sunumu en az üç slayt içermelidir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint'i PDF'ye Özel Slayt Boyutu ile Dönüştür**

Aşağıdaki örnek, bir sunumdan ilk slaytı 612 × 792 puan (8.5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz.

Bu C# kodu, farklı uyumluluk standartlarına göre birden fazla PDF üreten PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert color="info" title="Note" %}}
Aspose.Slides PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) gibi özel formatlara PDF dönüşüm işlemleri de desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **FAQ**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını PDF'ye toplu olarak dönüştürmeyi destekler. Dosyalarınızda döngü kurarak dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi parola ile korumak mümkün mü?**

Evet. Dönüşüm sürecinde bir parola ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfını kullanın.

**PDF'ye gizli slaytları nasıl eklerim?**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfındaki [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini `true` olarak ayarlayarak gizli slaytları sonuç PDF'ye dahil edin.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfındaki [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) ve [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) gibi özellikleri ayarlayarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere çeşitli standartlarla uyumlu PDF'ler dışa aktarmanıza olanak tanır ve belgelerinizin erişilebilirlik ve arşivleme gereksinimlerini karşılamasını sağlar.

## **Ek Kaynaklar**

- [Aspose.Slides for .NET Dokümantasyonu](/slides/tr/net/)
- [Aspose.Slides for .NET API Referansı](https://reference.aspose.com/slides/net/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)