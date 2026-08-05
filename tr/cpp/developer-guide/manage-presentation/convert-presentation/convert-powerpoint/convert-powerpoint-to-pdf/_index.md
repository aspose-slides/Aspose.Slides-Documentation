---
title: C++'ta PPT ve PPTX'i PDF'ye Dönüştürün [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/cpp/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) C++'ta PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ve biçimlendirmesinin korunması gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları eklemeyi, PDF dosyalarını şifre korumalı hale getirmeyi, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyum standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından `Save` yöntemini kullanarak sunumu PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan `Save` yöntemini sağlar.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ çıktıya API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** Aspose.Slides'in bu bilgileri çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamazsınız.

{{% /alert %}}

Aspose.Slides şunları dönüştürmenizi sağlar:

* Tam sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktarır, ortaya çıkan PDF'lerin orijinal sunumlara çok yakın olmasını sağlar. Dönüşümde öğeler ve özellikler doğru bir şekilde işlenir, aşağıdakileri içerir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgiler ve altbilgiler
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint‑to‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

Bu C++ kodu bir sunumu (PPT, PPTX, ODP vb.) PDF'ye nasıl dönüştüreceğinizi gösterir:

```c++
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Sunumu PDF olarak kaydedin.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose, sunumdan PDF'ye dönüştürme sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint to PDF converter**](https://products.aspose.app/slides/tr/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını denemek için bu dönüştürücüyle bir test çalıştırabilirsiniz.

{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, sonuç PDF'sini özelleştirmenize, PDF'yi bir şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sağlar.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirtebilir, metin için bir sıkıştırma seviyesi ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki kod örneği bir PowerPoint sunumunu birkaç özel seçenekle PDF'ye nasıl dönüştüreceğinizi gösterir.

```c++
// PdfOptions sınıfını örnekleyin.
auto pdfOptions = MakeObject<PdfOptions>();

// JPG görüntüleri için kaliteyi ayarlayın.
pdfOptions->set_JpegQuality(90);

// Görüntüler için DPI'yi ayarlayın.
pdfOptions->set_SufficientResolution(300);

// Metafile'ların davranışını ayarlayın.
pdfOptions->set_SaveMetafilesAsPng(true);

// Metin içeriği için metin sıkıştırma seviyesini ayarlayın.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF uyumluluk modunu tanımlayın.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Sunumu PDF belgesi olarak kaydedin.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint'i Gizli Slaytlarla PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları ortaya çıkan PDF'de sayfa olarak dahil etmek için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfının [set_ShowHiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metodunu kullanabilirsiniz.

Bu C++ kodu gizli slaytların dahil edildiği bir PDF'ye nasıl dönüştürüleceğini gösterir:

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

### **PowerPoint'i Şifre Korumalı PDF'ye Dönüştür**

Bu C++ kodu, [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfının koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF'ye nasıl dönüştüreceğinizi gösterir:

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

### **Yazı Tipi İkamelerini Algıla**

Aspose.Slides, sunum‑to‑PDF dönüşüm sürecinde yazı tipi ikamelerini algılamanızı sağlayan [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfı altında [set_WarningCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metodunu sunar.

Bu C++ kodu yazı tipi ikamelerini nasıl algılayacağınızı gösterir:

```c++
// Uyarı geri çağırmasının uygulanması.
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

    // PDF seçeneklerinde uyarı geri çağırmasını ayarlayın.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Sunumu PDF olarak kaydedin.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Render sürecinde yazı tipi ikameleri için geri çağırma almak hakkında daha fazla bilgi için [Getting Warning Callbacks for Fonts Substitution](/slides/tr/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) bölümüne bakın.

Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/cpp/font-substitution/) makalesine göz atın.

{{% /alert %}} 

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Bu C++ kodu bir PowerPoint sunumundan yalnızca belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```C++
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Slayt numaralarının dizisini ayarlayın.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Sunumu PDF olarak kaydedin.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint'i Özel Slayt Boyutu ile PDF'ye Dönüştür**

Bu C++ kodu belirli bir slayt boyutu ile bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

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

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Bu C++ kodu notlar içeren bir PDF oluşturmak için bir PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```C++
// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// PDF seçeneklerini Not Düzeni ile yapılandırın.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sunumu notlarla birlikte PDF'ye kaydedin.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF İçin Erişilebilirlik ve Uyum Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bu uyum standartlarından herhangi birini kullanarak bir PowerPoint belgesini PDF'ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu C++ kodu farklı uyum standartlarına göre birden çok PDF oluşturan bir PowerPoint‑to‑PDF dönüşüm sürecini gösterir:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides, PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanıyan PDF dönüşüm işlemlerini destekler. [PDF to HTML](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Özelleştirilmiş formatlara yönelik diğer PDF dönüşüm işlemleri—[PDF to SVG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-xml/)—da desteklenir.

{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarılırken Aspose.Slides, SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını PDF'ye toplu olarak dönüştürmeyi destekler. Dosyalarınızın üzerinden döngü kurarak dönüşüm sürecini programlı bir şekilde uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle korumak mümkün mü?**

Kesinlikle. Dönüşüm sırasında bir şifre ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl ekleyebilirim?**

Gizli slaytları ortaya çıkan PDF'ye dahil etmek için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfındaki `set_ShowHiddenSlides` metodunu kullanın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, `set_JpegQuality` ve `set_SufficientResolution` gibi metodları [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfında kullanarak PDF'nizde yüksek kaliteli görsellerin olmasını sağlayabilirsiniz.

**Aspose.Slides PDF/A uyum standartlarını destekliyor mu?**

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere çeşitli standartlara uygun PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for C++ Documentation](/slides/tr/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/tr/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/tr/conversion)