---
title: C++'ta PPT ve PPTX'i PDF'ye Dönüştürme [Gelişmiş Özellikler Dahil]
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
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) C++'ta PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ile biçimlendirmesini koruma gibi bir dizi avantaj sağlar. Bu kılavuz, sunumları PDF belgelerine dönüştürmeyi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları eklemeyi, PDF dosyalarına parola koruması eklemeyi, font ikamelerini tespit etmeyi, dönüşüm için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüştürmeler**

Aspose.Slides kullanarak aşağıdaki biçimlerdeki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfına argüman olarak aktarın ve ardından sunumu [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı, tipik olarak bir sunumu PDF'ye dönüştürmek için kullanılan [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) metodunu ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ çıktı belgelerine API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" şeklinde doldurur. **Not** Aspose.Slides'in bu bilgiyi çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamazsınız.
{{% /alert %}}

Aspose.Slides şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF olarak dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, bunlar şunları içerir:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'ten PDF'ye Dönüştürme**

Varsayılan seçenekleri kullanan standart PowerPoint‑to‑PDF dönüşüm süreci, en yüksek kalite seviyelerinde optimal ayarlarla sağlanan bir PDF üretmeye çalışır.

Aşağıdaki örnek, bir sunumu yükler ve tüm görünür slaytları varsayılan dışa aktarma ayarlarıyla PDF olarak kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose, sunum‑to‑PDF dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Buradaki prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'ten PDF'ye Seçeneklerle Dönüştürme**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfı altındaki özel seçenekler sağlar.

### **PowerPoint'ten PDF'ye Özel Seçeneklerle Dönüştürme**

Özel dönüşüm seçenekleri ile raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirtebilir, metin sıkıştırma seviyesi ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının yalnızca slaytları değil aynı zamanda çalışma kitabının verilerine de erişmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak tutmak için `true` ile [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) metodunu çağırın.

Varsayılan değer `false`'dır: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak eklenmez. Seçeneği `true` olarak ayarlamak ayrıca dosya verilerini de ekler. Ön izleme yalnızca görsel bir temsildir; ek, alıcıların gömülü dosyayı ayrı ayrı açıp kaydetmesini sağlar. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve bu çalışma kitabı ekli olarak PDF'ye dışa aktarır.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Sonucu kontrol etmek için:

1. PDF'yi dosya eklerini destekleyen bir görüntüleyicide (ör. Adobe Acrobat Reader) açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Eki kaydedin ve Excel'de açarak verileri inceleyin ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ekten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bu kısıtlamalar standartların gereklilikleridir, Aspose.Slides'e özgü bir sınırlama değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **PowerPoint'ten PDF'ye Gizli Slaytlarla Dönüştürme**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metodunu kullanabilirsiniz.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **PowerPoint'ten Parola Korumalı PDF'ye Dönüştürme**

Aşağıdaki örnek, `password` parolası ile açılması gereken bir PDF'ye sunumu dışa aktarır. Erişim izinleri, yüksek kalite baskı dahil olmak üzere baskıya izin verir.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Font İkamelerini Algıla**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfı altındaki [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metodunu sağlayarak sunum‑to‑PDF dönüşüm sürecinde font ikamelerini algılamanızı sağlar.

Aşağıdaki örnek, bir sunumu PDF olarak dışa aktarır ve font ikameleriyle ilgili uyarıları konsola yazar. Uyarı yalnızca mevcut olmayan bir font dışa aktarım sırasında ikame edildiğinde basılır.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Font ikameleri hakkında daha fazla bilgi için [Font İkamesi](/slides/tr/cpp/font-substitution/) makalesine bakın.
{{% /alert %}}

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizi içindeki slayt numaraları bir‑tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **PowerPoint'ten Özel Slayt Boyutuyla PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 nokta (8.5 × 11 inç) boyutunda yeni bir sunuma kopyalar. Slayt içeriği ölçeklenerek sığdırılır ve tek slayt PDF olarak dışa aktarılır.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Not Slaytı Görünümünde PowerPoint'ten PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve her slaytın notlarını slaytın altında yerleştirir. Sonucu görmek için not içeren bir sunum kullanın.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. PowerPoint belgesini PDF'ye dışa aktarırken şu uyumluluk standartlarından herhangi birini kullanabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu C++ kodu, farklı uyumluluk standartlarına göre birden çok PDF oluşturan bir PowerPoint‑to‑PDF dönüşüm sürecini gösterir:

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya biçimlerine dönüştürmenize olanak tanır. [PDF'den HTML'e](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF'den görüntüye](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF'den JPG'e](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) ve [PDF'den PNG'e](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) dönüşümleri gerçekleştirebilirsiniz. Özel biçimlere yönelik diğer PDF dönüşüm işlemleri—[PDF'den SVG'e](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF'den TIFF'e](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), ve [PDF'den XML'e](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—da desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken Aspose.Slides, SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden çok PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasının PDF'ye toplu dönüşümünü destekler. Dosyalarınızı döngü içinde işleyerek dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi parola ile korumak mümkün mü?**

Evet. Dönüşüm sırasında bir parola ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'ye nasıl ekleyebilirim?**

Gizli slaytları sonuç PDF'ye dahil etmek için [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metodunu kullanın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) ve [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) gibi metodları [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfında kullanarak PDF'nizde yüksek kalite görüntüler sağlayabilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlara uygun PDF'ler dışa aktararak belgelerinizin erişilebilirlik ve arşivleme gereksinimlerini karşılamasını sağlar.

## **Ek Kaynaklar**

- [Aspose.Slides for C++ Belgeleri](/slides/tr/cpp/)
- [Aspose.Slides for C++ API Referansı](https://reference.aspose.com/slides/cpp/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)