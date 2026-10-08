---
title: C++'ta PPT ve PPTX'i PDF'ye Dönüştür [Gelişmiş Özellikler Dahildir]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint'i dönüştür
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
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

C++'ta PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi birçok avantaj sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi değiştirmelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktılara uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından bir [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) yöntemi kullanarak sunumu PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) yöntemini ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++, çıktıya API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not** Aspose.Slides'in bu bilgiyi çıktılardan değiştirmesini veya kaldırmasını isteyemezsiniz.
{{% /alert %}}

Aspose.Slides, şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüştürmede öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgiler ve altbilgiler
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standard PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve varsayılan dışa aktarma ayarlarını kullanarak tüm görünür slaytları PDF olarak kaydeder.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint'ten PDF'ye dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulaması için bu dönüştürücüyle bir test yapabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenizi, PDF'yi bir şifreyle kilitlemenizi veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sunar.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini belirtebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilen ve Flate metin sıkıştırması kullanılan PDF 1.5'e bir sunumu dışa aktarır.

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

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının çalışma kitabının verilerine erişmesini ve slaytları görüntülemesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için `true` ile [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) metodunu çağırın.

Varsayılan değer `false`'tur: OLE nesnesinin ön izleme görüntüsü veya simgesi PDF sayfasında renderlanır, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `true` olarak ayarlamak, dosya verilerini ek olarak ekler. Ön izleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı ayrı açıp kaydetmesini sağlar. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, içinde gömülü bir Excel çalışma kitabı bulunan bir sunumu yükler ve çalışma kitabı ekli şekilde PDF'ye dışa aktarır.

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

1. Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide dışa aktarılan PDF'yi açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ek'ten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **PowerPoint'i Gizli Slaytlarla PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) yöntemini kullanabilirsiniz.

Aşağıdaki örnek, gizli slaytları dahil ederek bir sunumu PDF'ye dışa aktarır.

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

### **PowerPoint'i Şifre Koramlı PDF'ye Dönüştür**

Aşağıdaki örnek, açmak için `password` şifresini gerektiren bir PDF'ye sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı dahil olmak üzere yazdırmaya izin verir.

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

### **Yazı Tipi Değiştirmelerini Algıla**

Aspose.Slides, sunumdan PDF'ye dönüşüm sürecinde yazı tipi değiştirmelerini algılamanızı sağlayan [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfı altındaki [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metodunu sunar.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve yazı tipi değiştirme uyarılarını konsola yazdırır. Bir uyarı yalnızca mevcut olmayan bir yazı tipi dışa aktarım sırasında değiştirildiğinde yazdırılır.

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
Yazı tipi değiştirmeleri hakkında daha fazla bilgi için, [Yazı Tipi Değiştirme](/slides/tr/cpp/font-substitution/) makalesine bakın.
{{% /alert %}}

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşle**

Bir sunum, yazı tipinde ayrı bir kalın karakter seti olmasa bile metoda kalın biçimlendirme uygulayabilir. Metin, normal glifleri yapay olarak kalınlaştıran sentetik kalınlaştırma sayesinde yine de kalın görünebilir. Bu metin PDF'de çok ağır görünürse veya istenen görünümden farklıysa, [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) metodunu `true` ile çağırmayı deneyin. Bu seçenek, etkilenmiş metni PDF dışa aktarımı sırasında bitmap olarak işler ve bazı yazı tiplerinde görünümünü iyileştirebilir. Varsayılan değeri `false`'tur.

Örnek sunum, aynı yazı tipine uygulanmış kalın biçimlendirmeli bir metin kutusu ve normal metinli bir metin kutusu olmak üzere iki metin kutusu içerir; bu yazı tipinin ayrı bir kalın karakter seti yoktur. Aşağıdaki örnek, sunumu yükler, desteklenmeyen yazı tipi stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Aşağıdaki ön izlemeler, seçeneğin devre dışı ve etkin olduğu çıktıyı gösterir. Bu örnekte, seçeneği devre dışı bıraktığınızda kalın metnin çizgileri daha kalındır. Seçeneği etkinleştirdiğinizde çizgileri daha ince olur; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Bu örnekte, seçeneği etkinleştirmek yalnızca kalın metni bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin arama yapılabilir olarak kalır. Seçenek devre dışı bırakıldığında, her iki dize de metin olarak kalır.

Bu seçenek, yazı tipinde ayrı bir kalın karakter seti olmadığında kalın olarak biçimlendirilmiş metni rasterleştirir. [Yazı Tipi Değiştirme](/slides/tr/cpp/font-substitution/) ise orijinal yazı tipi mevcut olmadığında başka bir yazı tipi seçer.

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizi içindeki slayt numaraları birden başlar ve giriş sunumu en az üç slayt içermelidir.

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

## **PowerPoint'i Özel Slayt Boyutu ile PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 puan (8.5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve her slaytın konuşmacı notlarını slaytın altında yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web İçerik Erişilebilirlik Yönergeleri (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye bu uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b**, ve **PDF/UA**.

Bu C++ kodu, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

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
Aspose.Slides, PDF dosyalarını popüler dosya formatlarına dönüştürmenizi sağlayan PDF dönüşüm işlemlerini destekler. [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), ve [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Özelleşmiş formatlara PDF dönüşüm işlemleri—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—da desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**  
Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasının toplu olarak PDF'ye dönüştürülmesini destekler. Dosyalarınız üzerinde döngü kurarak dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifrelemek mümkün mü?**  
Evet. Dönüşüm sürecinde şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl eklerim?**  
Sonuç PDF'ye gizli slaytları eklemek için [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) yöntemini kullanın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**  
Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) ve [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**  
Evet, Aspose.Slides PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlara uygun PDF'ler dışa aktarmanıza izin verir; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for C++ Belgeleri](/slides/tr/cpp/)
- [Aspose.Slides for C++ API Referansı](https://reference.aspose.com/slides/cpp/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)