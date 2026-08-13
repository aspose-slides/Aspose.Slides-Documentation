---
title: "C++'ta PPT ve PPTX'i PDF'ye Dönüştür [Gelişmiş Özellikler Dahil]"
linktitle: "PowerPoint'ten PDF'ye"
type: docs
weight: 40
url: /tr/cpp/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint dönüştür"
- "sunumu dönüştür"
- "PowerPoint'ten PDF'ye"
- "sunumu PDF'ye"
- "PPT'den PDF'ye"
- "PPT'yi PDF'ye dönüştür"
- "PPTX'den PDF'ye"
- "PPTX'i PDF'ye dönüştür"
- "PowerPoint'i PDF olarak kaydet"
- "PPT'yi PDF olarak kaydet"
- "PPTX'i PDF olarak kaydet"
- "PPT'yi PDF'ye dışa aktar"
- "PPTX'i PDF'ye dışa aktar"
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) C++'ta PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ve biçimlendirmesini koruma gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifreyle korumayı, yazı tipi ikamelerini tespit etmeyi, dönüşüm için belirli slaytları seçmeyi ve çıktıya uyumluluk standartları uygulamayı göstermektedir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını bir argüman olarak [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfına geçirin ve ardından `Save` yöntemiyle sunumu PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan `Save` yöntemini ortaya çıkarır.

{{%  alert title="NOT"  color="warning"   %}} 

Aspose.Slides for C++ çıktısı belgelerine API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application (Uygulama) alanını "*Aspose.Slides*" ve PDF Producer (PDF Üreticisi) alanını "*Aspose.Slides v XX.XX*" şeklinde doldurur. **Not** bu bilgiyi çıktıda değiştiremez veya kaldıramazsınız.

{{% /alert %}}

Aspose.Slides şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF olarak dışa aktarır ve elde edilen PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve nitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üst bilgi ve alt bilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Sunumu PDF olarak kaydet.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose, sunum‑PDF dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint to PDF dönüştürücü**](https://products.aspose.app/slides/tr/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyle bir deneme yapabilirsiniz.

{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi bir şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sağlar.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PdfOptions sınıfının bir örneğini oluştur.
auto pdfOptions = MakeObject<PdfOptions>();

// JPG görüntülerinin kalitesini ayarla.
pdfOptions->set_JpegQuality(90);

// Görüntüler için DPI ayarla.
pdfOptions->set_SufficientResolution(300);

// Metafile'ların davranışını ayarla.
pdfOptions->set_SaveMetafilesAsPng(true);

// Metin içeriği için metin sıkıştırma seviyesini ayarla.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF uyumluluk modunu tanımla.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Sunumu PDF belgesi olarak kaydet.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint'i Gizli Slaytlarla PDF'ye Dönüştür**

Eğer bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_ShowHiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) yöntemini kullanabilirsiniz.

Bu C++ kodu, gizli slaytları dahil edilmiş bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions sınıfının bir örneğini oluştur.
auto pdfOptions = MakeObject<PdfOptions>();

// Gizli slaytları ekle.
pdfOptions->set_ShowHiddenSlides(true);

// Sunumu PDF olarak kaydet.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint'i Şifre Koruması Olan PDF'ye Dönüştür**

Bu C++ kodu, [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfının koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF'ye nasıl dönüştüreceğinizi gösterir:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions sınıfının bir örneğini oluştur.
auto pdfOptions = MakeObject<PdfOptions>();

// PDF şifresi ve erişim izinlerini ayarla.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Sunumu PDF olarak kaydet.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Yazı Tipi İkame Tespiti**

Aspose.Slides, sunumu PDF'ye dönüştürme sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan, [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfı altında bulunan [set_WarningCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_warningcallback/) yöntemini sunar.

Bu C++ kodu, yazı tipi ikamelerini nasıl tespit edeceğinizi gösterir:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

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
    // PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // PDF seçeneklerinde uyarı geri çağrısını ayarla.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Sunumu PDF olarak kaydet.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

Renderleme sürecinde yazı tipi ikameleri için geri çağrıları alma hakkında daha fazla bilgi için [Getting Warning Callbacks for Fonts Substitution](/slides/tr/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/cpp/font-substitution/) makalesine bakın.

{{% /alert %}} 

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Bu C++ kodu, bir PowerPoint sunumundan yalnızca belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Slayt numaralarının dizisini ayarla.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Sunumu PDF olarak kaydet.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint'i Özel Slayt Boyutu ile PDF'ye Dönüştür**

Bu C++ kodu, belirli bir slayt boyutu ile bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Ayarlanmış slayt boyutuyla yeni bir sunum oluştur.
auto resizedPresentation = MakeObject<Presentation>();

// Özel slayt boyutunu ayarla.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Orijinal sunumdan ilk slaytı kopyala.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Yeniden boyutlandırılmış sunumu notlarla birlikte PDF olarak kaydet.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Bu C++ kodu, notları içeren bir PDF oluşturmak için bir PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Not düzeniyle PDF seçeneklerini yapılandır.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sunumu notlarla birlikte PDF olarak kaydet.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye dışa aktarırken bu uyumluluk standartlarından herhangi birini kullanabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu C++ kodu, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint‑PDF dönüşüm sürecini gösterir:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Aspose.Slides, PDF dönüştürme işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-jpg/), ve [PDF to PNG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, özel formatlara—[PDF to SVG](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/tr/cpp/conversion/pdf-to-xml/)—dönüştürme işlemleri de desteklenir.

{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Tek tek yol elemanları ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; yalnızca bütün şekil için alternatif metin sağlanır.

## **SSS**

### Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?

Evet, Aspose.Slides birçok PPT veya PPTX dosyasını toplu olarak PDF'ye dönüştürmeyi destekler. Dosyalarınız arasında döngü kurarak dönüşüm sürecini programlı olarak uygulayabilirsiniz.

### Dönüştürülen PDF'yi şifreyle korumak mümkün mü?

Kesinlikle. Dönüşüm sürecinde bir şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfını kullanın.

### Gizli slaytları PDF'ye nasıl ekleyebilirim?

[PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfındaki `set_ShowHiddenSlides` yöntemini kullanarak gizli slaytları sonuç PDF'ye ekleyebilirsiniz.

### Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/) sınıfındaki `set_JpegQuality` ve `set_SufficientResolution` gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

### Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere çeşitli standartlara uygun PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for C++ Dokümantasyonu](/slides/tr/cpp/)
- [Aspose.Slides for C++ API Referansı](https://reference.aspose.com/slides/tr/cpp/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)