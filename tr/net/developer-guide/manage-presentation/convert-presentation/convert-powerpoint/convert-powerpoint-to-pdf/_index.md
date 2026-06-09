---
title: .NET'te PPT ve PPTX'i PDF'ye Dönüştürün [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/net/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı C# kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

C#'ta PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzenini ve biçimlendirmesini koruma gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, font değişimlerini algılamayı, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfına parametre olarak geçirin ve ardından sunumu bir [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini sunar.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET, API bilgisi ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not**: Aspose.Slides'ın bu bilgileri çıktı belgelerinden değiştirmesini veya kaldırmasını isteyemezsiniz.

{{% /alert %}}

Aspose.Slides şunları dönüştürmenize olanak tanır:

* Tüm sunuları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüştürme sırasında aşağıdaki öğeler ve öznitelikler doğru şekilde işlenir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Hiperlinkler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

Bu C# kodu, bir sunumu (PPT, PPTX, ODP vb.) PDF'ye nasıl dönüştüreceğinizi gösterir:

```c#
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
using var presentation = new Presentation("PowerPoint.ppt");

// Sunumu PDF olarak kaydedin.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose, **PowerPoint to PDF converter** adlı ücretsiz bir çevrimiçi araç sunar ve sunum‑PDF dönüşüm sürecini gösterir. Buradaki dönüştürücüyle bir test yaparak burada açıklanan prosedürü canlı olarak deneyebilirsiniz.

{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfı altında bulunan özel seçenekler—özellikler—ile oluşturulan PDF'yi özelleştirmenize, PDF'yi bir şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanır.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özel dönüşüm seçenekleri kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafilleri nasıl işleneceğini belirleyebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki kod örneği, birkaç özel seçenekle bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir.

```c#
// PdfOptions sınıfını örnekleyin.
var pdfOptions = new PdfOptions
{
    // JPG görüntüleri için kaliteyi ayarlayın.
    JpegQuality = 90,

    // Görüntüler için DPI'yi ayarlayın.
    SufficientResolution = 300,

    // Metafile'lerin davranışını ayarlayın.
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

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Sunumda gizli slaytlar varsa, [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfındaki [ShowHiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini kullanarak gizli slaytları sonuç PDF'de sayfa olarak dahil edebilirsiniz.

Bu C# kodu, gizli slaytların dahil edildiği bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```c#
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions sınıfını örnekleyin.
var pdfOptions = new PdfOptions();

// Gizli slaytları ekleyin.
pdfOptions.ShowHiddenSlides = true;

// Sunumu PDF olarak kaydedin.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Şifreli PDF ile PowerPoint'i Dönüştür**

Bu C# kodu, [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak bir PowerPoint sunumunu şifreli PDF'ye nasıl dönüştüreceğinizi gösterir:

```c#
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

### **Font Değişimlerini Algıla**

Aspose.Slides, sunum‑PDF dönüşüm sürecinde font değişimlerini algılamanızı sağlayan [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfı altındaki [WarningCallback](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/warningcallback/) özelliğini sunar.

Bu C# kodu, font değişimlerini nasıl algılayacağınızı gösterir:

```c#
public static void Main()
{
    // PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin. 
    using var presentation = new Presentation("sample.pptx");

    // PDF seçeneklerinde uyarı geri aramasını ayarlayın.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Sunumu PDF olarak kaydedin.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Uyarı geri aramasının uygulanması.
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

{{%  alert color="primary"  %}} 

Render işlemi sırasında font değişimleri için geri bildirim almayı öğrenmek için [Getting Warning Callbacks for Fonts Substitution](/slides/tr/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) konusuna bakın.

Font değişimi hakkında daha fazla bilgi için [Font Substitution](/slides/tr/net/font-substitution/) makalesine göz atın.

{{% /alert %}} 

## **PowerPoint'ten PDF'ye Seçili Slaytları Dönüştür**

Bu C# kodu, bir PowerPoint sunumundan yalnızca belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```c#
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
using var presentation = new Presentation("PowerPoint.pptx");

// Slayt numaralarının dizisini ayarlayın.
int[] slides = { 1, 3 };

// Sunumu PDF olarak kaydedin.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Özel Slayt Boyutuyla PowerPoint'i PDF'ye Dönüştür**

Bu C# kodu, belirli bir slayt boyutu ile bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **Not Slayt Görünümünde PowerPoint'i PDF'ye Dönüştür**

Bu C# kodu, notları içeren bir PDF oluşturmak üzere bir PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```c#
// PowerPoint sunumunu yükleyin.
using var presentation = new Presentation("NotesFile.pptx");

// Notlar düzeniyle PDF seçeneklerini yapılandırın.
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

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. PowerPoint belgenizi aşağıdaki uyumluluk standartlarından herhangi biriyle PDF'ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu C# kodu, farklı uyumluluk standartlarına göre birden çok PDF oluşturan bir PowerPoint‑PDF dönüşüm sürecini gösterir:

```c#
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides, PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler formatlara dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/tr/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/net/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/tr/net/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/tr/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/net/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/tr/net/conversion/pdf-to-xml/) gibi özel formatlara dönüşüm de desteklenmektedir.

{{% /alert %}}

> **Not:** PDF/UA olarak dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides, birden çok PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyerek dönüşüm sürecini programatik olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle koruyabilir miyim?**

Kesinlikle. Dönüşüm sırasında bir şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl ekleyebilirim?**

Gizli slaytları sonuç PDF'ye dahil etmek için [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfındaki `ShowHiddenSlides` özelliğini `true` olarak ayarlayın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, `JpegQuality` ve `SufficientResolution` gibi özellikleri [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) sınıfında ayarlayarak PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere çeşitli standartlara uygun PDF'lerin dışa aktarılmasını sağlar; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for .NET Documentation](/slides/tr/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/tr/net/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)