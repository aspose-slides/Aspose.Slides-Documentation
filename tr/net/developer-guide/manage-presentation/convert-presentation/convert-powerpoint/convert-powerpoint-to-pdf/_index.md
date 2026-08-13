---
title: PPT ve PPTX'i .NET'te PDF'e Dönüştür [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'e
type: docs
weight: 40
url: /tr/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- PowerPoint PDF'e
- sunumu PDF'e
- PPT PDF'e
- PPT'yi PDF'e dönüştür
- PPTX PDF'e
- PPTX'i PDF'e dönüştür
- PowerPoint'i PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'e dışa aktar
- PPTX'i PDF'e dışa aktar
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı C# kod örnekleri ve gelişmiş dönüştürme seçenekleri ile."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP, vb.) C#'ta PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzenini ve biçimlendirmesini koruma gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF dosyalarına şifre koruması eklemeyi, yazı tipi ikamelerini tespit etmeyi, dönüşüm için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'e Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'e dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'e dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu bir [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'e dönüştürmek için kullanılan [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini sunar.

{{%  alert title="NOT"  color="warning"   %}} 

Aspose.Slides for .NET, API bilgilerini ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'e dönüştürürken Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not** ki bu bilgiyi çıktı belgelerinden değiştiremez veya kaldıramazsınız.

{{% /alert %}}

Aspose.Slides, şunları dönüştürmenize izin verir:

* Tüm sunumları PDF'e
* Bir sunumdan belirli slaytları PDF'e

Aspose.Slides, sunumları PDF'e dışa aktararak ortaya çıkan PDF'lerin orijinal sunumlarla çok yakın olmasını sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, şunları içerir:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'e Dönüştür**

Standart PowerPoint‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'e dönüştürmeye çalışır.

Bu C# kodu, bir sunumu (PPT, PPTX, ODP, vb.) PDF'e nasıl dönüştüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını oluşturun.
using var presentation = new Presentation("PowerPoint.ppt");

// Sunumu PDF olarak kaydedin.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose, sunum‑PDF dönüşüm sürecini gösteren ücretsiz bir çevrimiçi **PowerPoint to PDF converter**[https://products.aspose.app/slides/tr/conversion/ppt-to-pdf] sunar. Buradaki dönüştürücüyle bir test yaparak burada açıklanan prosedürü canlı olarak deneyebilirsiniz.

{{% /alert %}}

## **PowerPoint'i PDF'e Seçeneklerle Dönüştür**

Aspose.Slides, çıktıyı özelleştirmenize, PDF'i bir şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenize olanak tanıyan [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sağlar.

### **PowerPoint'i PDF'e Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını, metaverse dosyalarının nasıl işleneceğini, metin sıkıştırma seviyesini, görüntüler için DPI ayarını ve daha fazlasını belirleyebilirsiniz.

Aşağıdaki kod örneği, bir PowerPoint sunumunu birkaç özel seçenekle PDF'e nasıl dönüştüreceğinizi gösterir.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PdfOptions sınıfını örnekleyin.
var pdfOptions = new PdfOptions
{
    // JPG görüntüleri için kaliteyi ayarlayın.
    JpegQuality = 90,

    // Görüntüler için DPI'yi ayarlayın.
    SufficientResolution = 300,

    // Metadosyalar için davranışı ayarlayın.
    SaveMetafilesAsPng = true,

    // Metin içeriği için metin sıkıştırma seviyesini ayarlayın.
    TextCompression = PdfTextCompression.Flate,

    // PDF uyumluluk modunu tanımlayın.
    Compliance = PdfCompliance.Pdf15
};

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
using var presentation = new Presentation("PowerPoint.pptx");

// Sunumu PDF belgesi olarak kaydedin.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint'i Gizli Slaytlarla PDF'e Dönüştür**

Sunumda gizli slaytlar varsa, gizli slaytları çıkan PDF'te sayfa olarak dahil etmek için [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfındaki [ShowHiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini kullanabilirsiniz.

Bu C# kodu, gizli slaytlar dahil edilerek bir PowerPoint sunumunu PDF'e nasıl dönüştüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions sınıfını örnekleyin.
var pdfOptions = new PdfOptions();

// Gizli slaytları ekle.
pdfOptions.ShowHiddenSlides = true;

// Sunumu PDF olarak kaydedin.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint'i Şifre Koruması Olan PDF'e Dönüştür**

Bu C# kodu, [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF'e nasıl dönüştüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions sınıfını örnekleyin.
var pdfOptions = new PdfOptions();

// PDF şifresi ve erişim izinlerini ayarlayın.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Sunumu PDF olarak kaydedin.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Yazı Tipi İkamelerini Algıla**

Aspose.Slides, sunum‑PDF dönüşüm sürecinde yazı tipi ikamelerini algılamanızı sağlayan [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfı altındaki [WarningCallback](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/warningcallback/) özelliğini sunar.

Bu C# kodu, yazı tipi ikamelerini nasıl algılayacağınızı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin. 
    using var presentation = new Presentation("sample.pptx");

    // PDF seçeneklerinde uyarı geri çağrısını ayarlayın.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Sunumu PDF olarak kaydedin.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Uyarı geri çağrısının uygulanması.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

Render sürecinde yazı tipi ikameleri için geri arama almayı öğrenmek için [Getting Warning Callbacks for Fonts Substitution](/slides/tr/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) bölümüne bakın.

Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/net/font-substitution/) makalesine göz atın.

{{% /alert %}} 

## **PowerPoint'ten Seçili Slaytları PDF'e Dönüştür**

Bu C# kodu, bir PowerPoint sunumundan yalnızca belirli slaytları PDF'e nasıl dönüştüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
using var presentation = new Presentation("PowerPoint.pptx");

// Slayt numaraları dizisini ayarlayın.
int[] slides = { 1, 3 };

// Sunumu PDF olarak kaydedin.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint'i Özel Slayt Boyutuyla PDF'e Dönüştür**

Bu C# kodu, bir PowerPoint sunumunu belirli bir slayt boyutuyla PDF'e nasıl dönüştüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// PowerPoint sunumunu yükleyin.
using var presentation = new Presentation("SelectedSlides.pptx");

// Ayarlanmış slayt boyutu ile yeni bir sunum oluşturun.
using var resizedPresentation = new Presentation();

// Özel slayt boyutunu ayarlayın.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Orijinal sunumdan ilk slaytı kopyalayın.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Yeni sunumun oluşturulduğu boş slaytı kaldırın.
resizedPresentation.Slides.RemoveAt(1);

// Yeniden boyutlandırılmış sunumu PDF olarak kaydedin.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'e Dönüştür**

Bu C# kodu, notları içeren bir PDF oluşturmak için bir PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint sunumunu yükleyin.
using var presentation = new Presentation("NotesFile.pptx");

// PDF seçeneklerini Not Yerleşimiyle yapılandırın.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Sunumu notlarla birlikte PDF olarak kaydedin.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini aşağıdaki uyumluluk standartlarından herhangi birini kullanarak PDF'e dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu C# kodu, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint‑PDF dönüşüm sürecini gösterir:

```c#
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

{{% alert title="Not" color="warning" %}} 

Aspose.Slides, PDF dönüştürme işlemlerini destekleyerek PDF dosyalarını popüler formatlara dönüştürmenize izin verir. [PDF to HTML](https://products.aspose.com/slides/tr/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/net/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/tr/net/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/tr/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/net/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/tr/net/conversion/pdf-to-xml/) gibi özel formatlara da PDF dönüştürme işlemleri desteklenir.

{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir figür olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün figür için sağlanır.

## **SSS**

### Birden fazla PowerPoint dosyasını toplu olarak PDF'e dönüştürebilir miyim?

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını PDF'e toplu olarak dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyerek dönüşüm sürecini programlı olarak uygulayabilirsiniz.

### Dönüştürülen PDF'i şifreyle koruyabilir miyim?

Kesinlikle. Dönüşüm sırasında bir şifre ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfını kullanın.

### PDF içinde gizli slaytları nasıl dahil edebilirim?

Gizli slaytları çıkan PDF'e eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfındaki `ShowHiddenSlides` özelliğini `true` olarak ayarlayın.

### Aspose.Slides PDF'te yüksek görüntü kalitesini koruyabiliyor mu?

Evet, PDF'teki görüntü kalitesini yüksek tutmak için `JpegQuality` ve `SufficientResolution` gibi özellikleri [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfında ayarlayabilirsiniz.

### Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlarla uyumlu PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for .NET Belgeleri](/slides/tr/net/)
- [Aspose.Slides for .NET API Referansı](https://reference.aspose.com/slides/tr/net/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)