---
title: PPT ve PPTX'i .NET'te PDF'ye Dönüştürme [Gelişmiş Özellikler Dahildir]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- PowerPoint'ten PDF'ye
- sunumu PDF'ye
- PPT'yi PDF'ye
- PPT'yi PDF'ye dönüştür
- PPTX'i PDF'ye
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı C# kod örnekleri ve gelişmiş dönüşüm seçenekleri ile."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) C# içinde PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelere dönüştürmeyi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF dosyalarına parola koruması eklemeyi, yazı tipi ikamelerini tespit etmeyi, belirli slaytları dönüştürmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu bir [Kaydet](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemiyle PDF olarak kaydedin. [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [Kaydet](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemini sunar.

{{% alert color="info" title="Not" %}}
Aspose.Slides for .NET, API bilgilerini ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** ki bu bilgiyi çıktı belgelerinden değiştiremez veya kaldıramazsınız.
{{% /alert %}}

Aspose.Slides, aşağıdakileri dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktararak elde edilen PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüştürmede öğeler ve öznitelikler doğru bir şekilde işlenir, şunları içerir:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştürme**

Varsayılan seçenekleri kullanan standart PowerPoint‑PDF dönüşüm süreci, en yüksek kalite seviyelerinde optimal ayarlarla bir PDF oluşturur. Bu durumda, Aspose.Slides sağlanan sunumu PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve tüm görünür slaytları varsayılan dışa aktarma ayarlarıyla PDF olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Not" %}}
Aspose, sunum‑PDF dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint PDF Dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i Seçeneklerle PDF'ye Dönüştürme**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfı altında bulunan özelleştirilebilir seçenekler—özellikler—sağlayarak oluşturulan PDF'yi özelleştirmenize, PDF'yi bir parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenize olanak tanır.

### **PowerPoint'i Özelleştirilmiş Seçeneklerle PDF'ye Dönüştürme**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını, metafile'ların nasıl işleneceğini, metin sıkıştırma seviyesini, görüntüler için DPI ayarını ve daha fazlasını tanımlayabilirsiniz.

Aşağıdaki örnek bir sunumu PDF 1.5 olarak dışa aktarır; JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması uygulanır.

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

### **Görüntü Sıkıştırmasını Otomatik Olarak Seçme**

Bir sunumda çok sayıda fotoğraf veya ekran görüntüsü varsa, dışa aktarılan PDF'nin boyutunu küçültmek e-posta veya indirme işlemlerini kolaylaştırabilir. PDF dışa aktarımı sırasında her görüntü için en uygun sıkıştırma algoritmasını otomatik olarak seçmek için [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) özelliğini `true` olarak ayarlayın.

Aşağıdaki örnek mevcut bir sunumu yükler, otomatik görüntü sıkıştırma seçimini etkinleştirir ve bir PDF belgesi olarak kaydeder. Diğer tüm PDF dışa aktarma ayarları varsayılan değerlerini korur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Bu seçenek her görüntü için bir sıkıştırma algoritması seçer. [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) değerini düşürmek JPEG görüntü kalitesini azaltırken, [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) değerini düşürmek görüntülerin daha düşük bir çözünürlüğe indirilmesine izin verir ve ayrıntıyı azaltabilir. Otomatik sıkıştırma seçimini etkinleştirmek bu ayarları kendiliğinden düşürmez.

Görüntü sıkıştırma algoritmalarının seçilmesi ek işlem süresi ve bellek gerektirir. Boyut azaltma, sunumdaki görüntülere ve dışa aktarma ayarlarına bağlıdır; her sunum için sabit bir azaltma garantisi yoktur.

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Korumak**

Bir sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının hem çalışma kitabının verilerine erişmesini hem de slaytları görmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak tutmak için [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) özelliğini `true` olarak ayarlayın.

Varsayılan değer `false`'tır: OLE nesnesinin önizleme resmi veya simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak eklenmez. Özelliği `true` yaparak dosya verisi de eklenir. Önizleme görsel temsili kalır; ek, alıcıların gömülü dosyayı ayrı olarak açıp kaydetmelerine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabını ekli olarak PDF'ye dışa aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Sonucu kontrol etmek için:
1. PDF'yi, dosya eklerini destekleyen bir görüntüleyicide (ör. Adobe Acrobat Reader) açın.  
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.  
3. Ek'i kaydedin ve Excel'de açarak verilerini inceleyin veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki önizleme ekten ayrı bir görseldir.

{{% alert color="info" title="Not" %}}
PDF/A standartları eklerle ilgili kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir, PDF/A-3 ise Excel çalışma kitapları da dahil olmak üzere diğer dosya türlerine izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmasını göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştürme**

Sunumda gizli slaytlar varsa, gizli slaytları sonuç PDF'de sayfa olarak dahil etmek için [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfındaki [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini `true` olarak ayarlayabilirsiniz.

Aşağıdaki örnek, gizli slaytları dahil ederek bir sunumu PDF'ye dışa aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Parola Korumalı PDF Olarak PowerPoint Dönüştürme**

Aşağıdaki örnek, `password` parolasıyla açılması gereken bir PDF olarak sunumu dışa aktarır. Erişim izinleri, yüksek kalite baskı dahil olmak üzere baskıyı izin verir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Yazı Tipi İkame Tespiti**

Aspose.Slides, sunum‑PDF dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfı altındaki [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) özelliğini sunar.

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve yazı tipi ikame uyarılarını konsola yazar. Bir uyarı yalnızca mevcut olmayan bir yazı tipi dışa aktarım sırasında ikame edildiğinde görüntülenir.

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

{{% alert color="info" title="Not" %}}
Yazı tipi ikameleri hakkında daha fazla bilgi için [Yazı Tipi İkamesi](/slides/tr/net/font-substitution/) makalesine bakın.
{{% /alert %}} 

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşleme**

Bir sunum, yazı tipinin ayrı bir kalın tipine sahip olmamasına rağmen kalın biçimlendirme uygulayabilir. Metin, sentetik kalınlaştırma yoluyla kalın görünebilir; bu, normal glifleri yapay olarak kalınlaştırır. Bu metin PDF'de çok ağır veya istenen görünümden farklı görünüyorsa, [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) özelliğini `true` olarak ayarlamayı deneyin. Bu seçenek, PDF dışa aktarımı sırasında etkilenmiş metni bitmap olarak işler ve belirli yazı tipleri için görünümünü iyileştirebilir. Varsayılan değeri `false`'tır.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı yazı tipine kalın biçimlendirme uygulanmış ancak ayrı bir kalın tipine sahip olmayan. Aşağıdaki örnek sunumu yükler, desteklenmeyen yazı tipi stillerinin rasterizasyonunu etkinleştirir ve PDF'ye dışa aktarır:

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

Aşağıdaki ön izlemeler devre dışı ve etkin çıktıyı gösterir. Bu örnekte, kalın metin seçenek devre dışıyken daha kalın hatlara sahiptir. Seçenek etkin olduğunda hatları daha ince; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Bu örnekte, seçenek yalnızca kalın metni bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir kalır. Seçenek devre dışıyken, iki dize de metin olarak kalır.

Bu seçenek, kalın yazı tipi stili olmayan bir yazı tipinde kalın olarak biçimlendirilmiş metni rasterleştirir. [Yazı Tipi İkamesi](/slides/tr/net/font-substitution/) ise orijinal yazı tipi mevcut olmadığında başka bir yazı tipini seçer.

## **Seçili Slaytları PowerPoint'ten PDF'ye Dönüştürme**

Aşağıdaki örnek bir sunumdan 1. ve 3. slaytları PDF'ye dışa aktarır. Bu dizi içindeki slayt numaraları bir‑tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Özel Slayt Boyutu ile PowerPoint'i PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 point (8.5 × 11 inç) boyutunda yeni bir sunuma kopyalar. Slayt içeriğini ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

## **Notlar Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştürme**

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır, her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web İçerik Erişilebilirlik Kılavuzları (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. PowerPoint belgesini PDF'ye aşağıdaki uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b**, ve **PDF/UA**.

Bu C# kodu, farklı uyumluluk standartlarına göre birden fazla PDF oluşturan bir PowerPoint‑PDF dönüşüm sürecini gösterir:

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

{{% alert color="info" title="Not" %}}
Aspose.Slides, PDF dönüşüm işlemlerini destekler; PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF'den HTML'ye](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF'den görüntüye](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), ve [PDF'den PNG'ye](https://products.aspose.com/slides/net/conversion/pdf-to-png/) dönüşümleri gerçekleştirebilirsiniz. Özel formatlara yönelik diğer PDF dönüşüm işlemleri—[PDF'den SVG'ye](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF'den TIFF'ye](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), ve [PDF'den XML'ye](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—de desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides akıllı sanat, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden çok PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınızın üzerinden döngü oluşturarak dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi parola ile koruyabilir miyim?**

Evet. Dönüşüm sırasında bir parola ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl dahil edebilirim?**

Sonuç PDF'de gizli slaytları dahil etmek için [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfındaki [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini `true` olarak ayarlayın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) ve [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) gibi özellikleri [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfında ayarlayabilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlarla uyumlu PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for .NET Documentation](/slides/tr/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)