---
title: "C++'ta PPT ve PPTX'i PDF'ye Dönüştürme [Gelişmiş Özellikler Dahildir]"
linktitle: "PowerPoint PDF'ye"
type: docs
weight: 40
url: /tr/cpp/convert-powerpoint-to-pdf/
keywords:
  - "PowerPoint dönüştür"
  - "sunumu dönüştür"
  - "PowerPoint PDF'ye"
  - "sunumu PDF'ye"
  - "PPT PDF'ye"
  - "PPT'yi PDF'ye dönüştür"
  - "PPTX PDF'ye"
  - "PPTX'i PDF'ye dönüştür"
  - "PowerPoint'i PDF olarak kaydet"
  - "PPT'yi PDF olarak kaydet"
  - "PPTX'i PDF olarak kaydet"
  - "PPT'yi PDF'ye dışa aktar"
  - "PPTX'i PDF'ye dışa aktar"
  - "PDF/A1a"
  - "PDF/A1b"
  - "PDF/UA"
  - "C++"
  - "Aspose.Slides"
description: "Aspose.Slides kullanarak C++'ta PowerPoint PPT/PPTX'i yüksek kalitede, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) C++'ta PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi birçok avantaj sağlar. Bu kılavuz, sunumları PDF belgelerine dönüştürmeyi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF dosyalarına parola koruması eklemeyi, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını bir argüman olarak [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfına geçirin ve ardından sunumu `Save` yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı, tipik olarak bir sunumu PDF'ye dönüştürmek için kullanılan `Save` yöntemini sunar.

{{%  alert title="NOT"  color="warning"   %}} 

Aspose.Slides for C++ çıktıya API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, **Application** alanını "*Aspose.Slides*" ve **PDF Producer** alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not** ki Aspose.Slides bu bilgileri çıktılardan değiştiremez veya kaldıramaz.

{{% /alert %}}

Aspose.Slides, şunları dönüştürmenize olanak tanır:

* Tam sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'e dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüştürmede öğeler ve öznitelikler doğru şekilde işlenir, bunlar arasında:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint‑to‑PDF dönüştürme işlemi varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, verilen sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

Bu C++ kodu, bir sunumu (PPT, PPTX, ODP vb.) PDF'ye nasıl dönüştüreceğinizi gösterir:

```c++
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Sunumu PDF olarak kaydedin.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose, sunum‑to‑PDF dönüştürme sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint PDF Dönüştürücü**](https://products.aspose.app/slides/tr/conversion/ppt-to-pdf) sunar. Buradaki dönüştürücü ile işlemi canlı olarak test edebilirsiniz.

{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfı altında bulunan özelleştirilebilir seçenekler—özellikler—sağlayarak oluşturulan PDF'yi özelleştirmenize, PDF'yi parola ile kilitlemenize veya dönüştürme sürecinin nasıl ilerleyeceğini belirlemenize olanak tanır.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özel dönüştürme seçenekleriyle raster görüntüler için tercih edilen kalite ayarını, metafile'ların nasıl işleneceğini, metin sıkıştırma seviyesini, görüntüler için DPI ayarını ve daha fazlasını tanımlayabilirsiniz.

Aşağıdaki kod örneği, birkaç özel seçenekle bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir.

```c++
// PdfOptions sınıfını örnekleyin.
auto pdfOptions = MakeObject<PdfOptions>();

// JPG görüntüleri için kaliteyi ayarlayın.
pdfOptions->set_JpegQuality(90);

// Görüntüler için DPI'yi ayarlayın.
pdfOptions->set_SufficientResolution(300);

// Metafile'ların davranışını ayarlayın.
pdfOptions->set_SaveMetafilesAsPng(true);

// Metin içeriği için metin sıkıştırma düzeyini ayarlayın.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF uyumluluk modunu tanımlayın.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Sunumu PDF belgesi olarak kaydedin.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_ShowHiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metodunu kullanabilirsiniz.

Bu C++ kodu, gizli slaytlar dahil edilerek bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```c++
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions sınıfını örnekleyin.
auto pdfOptions = MakeObject<PdfOptions>();

// Gizli slaytları ekleyin.
pdfOptions->set_ShowHiddenSlides(true);

// Sunumu PDF olarak kaydedin.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Parola Korumasıyla PDF'ye PowerPoint Dönüştür**

Bu C++ kodu, [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak bir PowerPoint sunumunu parola korumalı PDF'ye nasıl dönüştüreceğinizi gösterir:

```c++
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions sınıfını örnekleyin.
auto pdfOptions = MakeObject<PdfOptions>();

// PDF şifresi ve erişim izinlerini ayarlayın.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Sunumu PDF olarak kaydedin.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Yazı Tipi İkamelerini Tespit Et**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfı altında bulunan [set_WarningCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metodu sayesinde sunum‑to‑PDF dönüştürme sırasında yazı tipi ikamelerini tespit etmenizi sağlar.

Bu C++ kodu, yazı tipi ikamelerini nasıl tespit edeceğinizi gösterir:

```c++
// Uyarı geri çağrısının uygulanması.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // PDF seçeneklerinde uyarı geri çağrısını ayarlayın.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Sunumu PDF olarak kaydedin.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Yazı tipi ikameleri sırasında geri arama (callback) alımıyla ilgili daha fazla bilgi için [/slides/tr/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/](../slides/tr/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) adresindeki **Yazı Tipi İkamesi için Uyarı Geri Aramaları Alma** bölümüne bakın.

Yazı tipi ikameleriyle ilgili daha fazla bilgi için [/slides/tr/cpp/font-substitution/](../slides/tr/cpp/font-substitution/) adresindeki **Yazı Tipi İkamesi** makalesine göz atın.

{{% /alert %}} 

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Bu C++ kodu, bir PowerPoint sunumundan yalnızca belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```C++
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Slayt numaralarının dizisini ayarlayın.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Sunumu PDF olarak kaydedin.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Özel Slayt Boyutuyla PowerPoint'i PDF'ye Dönüştür**

Bu C++ kodu, belirli bir slayt boyutuyla bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

Bu C++ kodu, notları da içeren bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```C++
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Notlar düzeniyle PDF seçeneklerini yapılandır.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sunumu notlarla bir PDF'ye kaydedin.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüştürme prosedürü kullanmanıza olanak tanır. PowerPoint belgesini PDF'ye dışa aktarırken aşağıdaki uyumluluk standartlarından herhangi birini kullanabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu C++ kodu, farklı uyumluluk standartlarına göre birden çok PDF oluşturan bir PowerPoint‑to‑PDF dönüştürme sürecini gösterir:

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Not" color="warning" %}} 

Aspose.Slides, PDF dönüştürme işlemlerini destekler ve PDF dosyalarını popüler formatlara dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-png/) gibi dönüşümler yapabilirsiniz. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-xml/) gibi özel formatlara da dönüşüm desteklenir.

{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken Aspose.Slides, SmartArt, grafikler ve formüller gibi karmaşık görselleri tek bir şekil olarak ele alır. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **S.S.S.**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınızın üzerinden döngü kurarak dönüşüm işlemini programatik olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi parola ile koruyabilir miyim?**

Kesinlikle. Dönüştürme sırasında bir parola belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfını kullanabilirsiniz.

**PDF'ye gizli slaytları nasıl ekleyebilirim?**

Gizli slaytları sonuç PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfındaki `set_ShowHiddenSlides` metodunu kullanın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini korur mu?**

Evet, `set_JpegQuality` ve `set_SufficientResolution` gibi metodları [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfı içinde kullanarak PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlara uygun PDF'ler oluşturmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for C++ Belgeleri](/slides/tr/cpp/)
- [Aspose.Slides for C++ API Referansı](https://reference.aspose.com/slides/tr/cpp/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)