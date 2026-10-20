---
title: C++'ta PPT ve PPTX'i PDF'e Dönüştür [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'e
type: docs
weight: 40
url: /tr/cpp/convert-powerpoint-to-pdf/
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

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) C++'ta PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktıya uyum standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu PDF olarak [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) yöntemiyle kaydedin. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++, çıktıya API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürdüğünüzde, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** bu bilgiyi çıktılardan değiştirmeniz veya kaldırmanız mümkün değildir.
{{% /alert %}}

Aspose.Slides şunu dönüştürmenize izin verir:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşümde öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Köprüler
* Üstbilgiler ve altbilgiler
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'e Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides verilen sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint to PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada anlatılan prosedürün gerçek bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'e Seçeneklerle Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfı altındaki özellikler—özel seçenekler—sunar; bu sayede oluşturulan PDF'yi özelleştirebilir, PDF'yi bir şifreyle kilitleyebilir veya dönüşüm sürecinin nasıl ilerleyeceğini belirtebilirsiniz.

### **PowerPoint'i PDF'e Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirtebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek bir sunumu PDF 1.5'e dışa aktarır; JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması kullanılır.

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

### **Görsel Sıkıştırmasını Otomatik Olarak Seç**

Bir sunumda birçok fotoğraf veya ekran görüntüsü olduğunda, dışa aktarılan PDF'nin boyutunu küçültmek e-posta göndermeyi veya indirmeyi kolaylaştırabilir. PDF dışa aktarımı sırasında her görüntü için en uygun sıkıştırma algoritmasını otomatik olarak seçmek için [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) yöntemini `true` ile çağırın.

Aşağıdaki örnek mevcut bir sunumu yükler, otomatik görüntü sıkıştırma seçimini etkinleştirir ve PDF belgesi olarak kaydeder. Diğer tüm PDF dışa aktarma ayarları varsayılan değerlerini korur.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Bu seçenek her görüntü için bir sıkıştırma algoritması seçer. [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) ile JPEG kalitesini düşürmek JPEG görüntü kalitesini azaltırken, [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) ile çözünürlüğü düşürmek görüntülerin daha düşük çözünürlüğe downsample edilmesine izin verir ve detay kaybına yol açabilir. Otomatik sıkıştırma seçimini etkinleştirmek, bu ayarların kendisini düşürmez.

Görsel sıkıştırma algoritmalarını seçmek ek işlem süresi ve bellek gerektirir. Boyut azalması, sunumdaki görüntülere ve dışa aktarma ayarlarına bağlıdır; her sunum için sabit bir azalma garantisi yoktur.

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koruma**

Bir sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının çalışma kitabının verilerine erişmesini ve slaytları görüntülemesini isteyebilirsiniz. [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) yöntemini `true` ile çağırarak gömülü OLE dosyalarını sonuç PDF'de ek olarak koruyabilirsiniz.

Varsayılan değer `false`'tır: OLE nesnesinin önizleme görüntüsü veya simgesi PDF sayfasına işlenir, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `true` olarak ayarlamak dosya verisini ek olarak ekler. Önizleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı ayrı açmasına veya kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, içinde gömülü bir Excel çalışma kitabı bulunan bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

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

1. Exported PDF'yi ekleri destekleyen bir görüntüleyicide, örneğin Adobe Acrobat Reader'da açın.
2. Görüntüleyicinin **Eklentiler** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve Excel'de açarak verileri inceleyin, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki önizleme ekten ayrı bir görseldir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 sadece PDF/A eklerine izin verir ve PDF/A-3 diğer dosya türlerini, özellikle Excel çalışma kitaplarını, izin verir. Bunlar standartların gereklilikleri olup, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'e Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfından [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) yöntemini kullanarak gizli slaytları sonuç PDF'de sayfa olarak ekleyebilirsiniz.

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

### **Şifre Korumalı PDF Olarak PowerPoint'i Dönüştür**

Aşağıdaki örnek bir sunumu, `password` şifresiyle açılması gereken bir PDF olarak dışa aktarır. Erişim izinleri, yüksek kaliteli baskı dahil baskıya izin verir.

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

### **Yazı Tipi İkamelerini Algıla**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfı altında [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) yöntemini sağlar; bu sayede sunumdan PDF'ye dönüşüm sürecinde yazı tipi ikamelerini tespit edebilirsiniz.

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve yazı tipi ikameleri uyarılarını konsola yazdırır. Bir uyarı yalnızca dışa aktarma sırasında mevcut olmayan bir yazı tipi ikame edildiğinde yazdırılır.

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
Yazı tipi ikameleri hakkında daha fazla bilgi için [Yazı Tipi İkameleri](/slides/tr/cpp/font-substitution/) makalesine bakın.
{{% /alert %}}

### **Bağımsız Kalın Yazı Tipi Olmayan Yazı Tiplerini Yönet**

Bir sunum, yazı tipinin bağımsız bir kalın tipine sahip olmasa bile metne kalın biçimlendirme uygulayabilir. Metin, düzenli glifleri yapay olarak kalınlaştıran sentetik kalınlaştırma yoluyla yine de kalın görünebilir. Bu metin PDF'de çok ağır görünürse veya istenen görünümden farklıysa, [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) yöntemini `true` ile çağırmayı deneyin. Bu seçenek, ilgili metni PDF dışa aktarımında bitmap olarak işler ve belirli yazı tipleri için görünümünü iyileştirebilir. Varsayılan değeri `false`'tur.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı yazı tipine kalın biçimlendirme uygulanmış ancak bağımsız bir kalın tipine sahip olmayan. Aşağıdaki örnek sunumu yükler, desteklenmeyen yazı tipi stillerinin rasterizasyonunu etkinleştirir ve PDF'ye dışa aktarır:

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

Aşağıdaki ön izlemeler devre dışı ve etkin çıktıyı gösterir. Bu örnekte, seçenek devre dışıyken kalın metnin çizgileri daha kalındır. Seçenek etkin olduğunda çizgileri daha hafiftir; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![Desteklenmeyen yazı tipi stili rasterizasyonu devre dışı PDF](unsupported-bold-disabled.png) | ![Desteklenmeyen yazı tipi stili rasterizasyonu etkin PDF](unsupported-bold-enabled.png) |

Bu örnekte, seçeneği etkinleştirmek yalnızca kalın metni bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir olarak kalır. Seçenek devre dışı bırakıldığında, her iki dize de metin olarak kalır.

Bu seçenek, yazı tipinin bağımsız bir kalın tipine sahip olmadığı durumlarda kalın biçimlendirilmiş metni rasterleştirir. [Yazı Tipi İkameleri](/slides/tr/cpp/font-substitution/) ise orijinal mevcut olmadığında başka bir yazı tipi seçer.

## **PowerPoint'ten Seçili Slaytları PDF'e Dönüştür**

Aşağıdaki örnek bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizideki slayt numaraları 1'den başlar ve giriş sunumu en az üç slayt içermelidir.

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

## **PowerPoint'i Özel Slayt Boyutuyla PDF'e Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 puan (8.5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığdırmak için ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

## **Not Slaytı Görünümünde PowerPoint'i PDF'e Dönüştür**

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve her slaytın sunum notlarını slaytın altına yerleştirir. Sonucu görmek için sunum notları içeren bir sunum kullanın.

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

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz.

Bu C++ kodu, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint'ten PDF'e dönüşüm sürecini gösterir:

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
Aspose.Slides, PDF dönüştürme işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), ve [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Özelleşmiş formatlara PDF dönüşüm işlemleri—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—da desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'e dönüştürebilir miyim?**

**Evet**, Aspose.Slides, birden fazla PPT veya PPTX dosyasını PDF'e toplu dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyebilir ve dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'i şifreyle korumak mümkün mü?**

**Evet**. Dönüşüm sürecinde şifre ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'e nasıl dahil edebilirim?**

**[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) yöntemini kullanarak gizli slaytları sonuç PDF'e dahil edebilirsiniz.**

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

**Evet**, [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) sınıfındaki [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) ve [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) gibi yöntemleri kullanarak PDF'lerinizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

**Evet**, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlara uyumlu PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for C++ Dokümantasyonu](/slides/tr/cpp/)
- [Aspose.Slides for C++ API Referansı](https://reference.aspose.com/slides/cpp/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)