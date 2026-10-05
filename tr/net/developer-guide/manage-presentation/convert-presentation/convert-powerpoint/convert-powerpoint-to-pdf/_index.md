---
title: PPT ve PPTX'i .NET'te PDF'e Dönüştürme [Gelişmiş Özellikler Dahildir]
linktitle: PowerPoint'ten PDF'e
type: docs
weight: 40
url: /tr/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- PowerPoint'ten PDF'e
- sunumu PDF'e
- PPT'yi PDF'e
- PPT'yi PDF'e dönüştür
- PPTX'i PDF'e
- PPTX'i PDF'e dönüştür
- PowerPoint'i PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'e dışa aktar
- PPTX'i PDF'e dışa aktar
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı C# kod örnekleri ve gelişmiş dönüşüm seçenekleri içerir."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) C# içinde PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını parola ile korumayı, font ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfına bir argüman olarak geçirin ve ardından sunumu PDF olarak [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemiyle kaydedin. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET, API bilgilerini ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** bu bilgiyi çıktı belgelerinden değiştiremez veya kaldıramazsınız.
{{% /alert %}}

Aspose.Slides şu dönüşümleri yapmanıza olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlara yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Köprüler
* Üst ve alt bilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştürme**

Standart PowerPoint‑to‑PDF dönüşüm süreci, varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve varsayılan dışa aktarma ayarlarıyla tüm görünür slaytları PDF'ye kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose, sunum‑PDF dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Buradaki prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i Seçeneklerle PDF'ye Dönüştürme**

Aspose.Slides, ortaya çıkan PDF'yi özelleştirmenize, PDF'yi bir parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenize olanak tanıyan özelleştirilmiş seçenekler—[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfının özellikleri—sağlar.

### **PowerPoint'i Özelleştirilmiş Seçeneklerle PDF'ye Dönüştürme**

Özelleştirilmiş dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

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

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Korumak**

Bir sunumda gömülü bir Excel çalışma kitabı bulunuyorsa, PDF alıcılarının slaytları görmesinin yanı sıra çalışma kitabının verilerine de erişmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) özelliğini `true` olarak ayarlayın.

Varsayılan değer `false`'tir: OLE nesnesinin önizleme görüntüsü veya simgesi PDF sayfasına işlenir, ancak gömülü dosya ek olarak dahil edilmez. Bu seçeneği `true` yaparsanız dosya verileri de eklenir. Önizleme görsel bir temsil olmaya devam eder; ek, alıcıların gömülü dosyayı ayrı olarak açmasına veya kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Sonucu kontrol etmek için:

1. PDF'yi, Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide açın.
2. Görüntüleyicinin **Ekler** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki önizleme ek'ten ayrı bir görseldir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde sınırlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bunlar standartların gereksinimleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmayı göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştürme**

Bir sunum gizli slaytlar içeriyorsa, sonuç PDF'de gizli slaytları sayfa olarak eklemek için [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfından kullanabilirsiniz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Parola Korumalı PDF Olarak PowerPoint'i Dönüştürme**

Aşağıdaki örnek, açmak için `password` parolasını gerektiren ve erişim izinlerinin yüksek kalite baskıyı da kapsayan bir PDF olarak sunumu dışa aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Font İkamelerini Tespit Etme**

Aspose.Slides, sunum‑PDF dönüşüm sürecinde font ikamelerini tespit etmenizi sağlayan [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) özelliğini [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfı altında sunar.

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve font ikame uyarılarını konsola yazdırır. Yalnızca bulunamayan bir font dışa aktarım sırasında ikame edildiğinde bir uyarı basılır.

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
Font ikameleri hakkında daha fazla bilgi için [Font İkamesi](/slides/tr/net/font-substitution/) makalesine bakın.
{{% /alert %}} 

## **PowerPoint'ten Seçilen Slaytları PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumun 1 ve 3 numaralı slaytlarını PDF'ye dışa aktarır. Bu dizi içindeki slayt numaraları bir‑tabanlıdır ve giriş sunumunda en az üç slayt bulunmalıdır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint'i Özelleştirilmiş Slayt Boyutu ile PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 puan (8,5 × 11 inç) boyutunda yeni bir sunuma kopyalar, slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştürme**

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır; her slaytın konuşmacı notları slaytın altında yer alır. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) standardına uygun bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini aşağıdaki uyumluluk standartlarından herhangi birini kullanarak PDF'ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu C# kodu, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint‑PDF dönüşüm sürecini gösterir:

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
Aspose.Slides PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize izin verir. [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) gibi özel formatlara yönelik PDF dönüşüm işlemleri de desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken Aspose.Slides, SmartArt, grafikler ve formüller gibi karmaşık grafik öğelerini tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını toplu olarak PDF'ye dönüştürmeyi destekler. Dosyalarınızın üzerinden döngüyle geçerek dönüşüm sürecini programatik olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi parola ile korumak mümkün mü?**

Evet. Dönüşüm sürecinde bir parola ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'ye nasıl dahil edebilirim?**

Gizli slaytları sonuç PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfındaki [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini `true` olarak ayarlayın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sınıfındaki [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) ve [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) gibi özellikleri ayarlayarak PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere çeşitli standartlara uygun PDF'ler dışa aktarabilir; bu sayede belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for .NET Belgeleri](/slides/tr/net/)
- [Aspose.Slides for .NET API Referansı](https://reference.aspose.com/slides/net/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)