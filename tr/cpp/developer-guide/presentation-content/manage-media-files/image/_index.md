---
title: C++ Kullanarak Sunumlarda Görsel Yönetimini Optimize Et
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/cpp/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görsel değiştir
- resim değiştir
- webden
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- harici SVG kaynakları
- SVG çözücü
- bağlantılı SVG görüntüleri
- SVG yazı tipleri
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument'ta Aspose.Slides for C++ ile görsel yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha ilgi çekici ve görsel olarak çekici hâle getirir. Microsoft PowerPoint'te, dosyalardan, internetten veya diğer kaynaklardan slaytlara resimler ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunum slaytlarına çeşitli yollarla görsel eklemenize olanak tanır.

{{% alert title="İpucu" color="primary" %}} 
Aspose, resimlerden hızlıca sunum oluşturmanızı sağlayan ücretsiz dönüştürücüler—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 
{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}
Bir resmi resim çerçevesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırmayı, efekt uygulamayı veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Resim Çerçevesi](/slides/tr/cpp/picture-frame/) bölümüne bakın. 
{{% /alert %}} 

{{% alert title="Not" color="warning" %}}
Görüntüleri bir formattan diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: [görüntüyü JPG'e dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/image-to-jpg/), [JPG'yi görüntüye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-image/), [JPG'yi PNG'e dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-png/), [PNG'yi JPG'e dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/png-to-jpg/), [PNG'yi SVG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/png-to-svg/), ve [SVG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlardaki görselleri destekler. 

## **Yerel Olarak Depolanan Görselleri Slaytlara Ekle**

Bilgisayarınızda depolanan bir veya daha fazla görseli bir sunum slaytına ekleyebilirsiniz. Aşağıdaki C++ örnek kodu, bir görselin slayta nasıl ekleneceğini gösterir:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Web'den Görselleri Slaytlara Ekle**

Eklemek istediğiniz görsel bilgisayarınızda bulunmuyorsa, doğrudan web'den ekleyebilirsiniz. 

Aşağıdaki C++ örnek kodu, bir görseli web'den slayta nasıl ekleyeceğinizi gösterir:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Görselleri Slayt Ana Şablonlarına Ekle**

Bir slayt ana şablonu, onu kullanan slaytların tema ve düzen gibi bilgilerini depolar ve kontrol eder. Bir görüntüyü slayt ana şablonuna eklediğinizde, o şablona dayanan her slaytta görüntü görünür. 

Aşağıdaki C++ örnek kodu, bir görseli slayt ana şablonuna nasıl ekleyeceğinizi gösterir:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Görselleri Slayt Arka Planı Olarak Ekle**

Bir veya daha fazla slaytın arka planı olarak bir resim kullanabilirsiniz. Ayrıntılar için *[Slaytlar İçin Görselleri Arka Plan Olarak Ayarlama](/slides/tr/cpp/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **Sunumlara SVG Ekle**

SVG içeriği, [SvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/svgimage/) sınıfı kullanılarak bir sunuma eklenebilir. Ortaya çıkan [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) nesnesi daha sonra sunumun görsel koleksiyonuna eklenerek bir resim çerçevesi oluşturmak için kullanılabilir.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Harici Kaynaklı SVG İçeriğini İçeri Aktar**

SVG dosyaları, tasarım araçları, diyagram editörleri, ikon sistemleri ve web pipeline'larından dışarıda depolanan kaynaklara referans içerebilir. Örneğin, bir SVG `images/photo.png` gibi bir resim bağlantısı, bir CSS `url(...)` değeri ya da bir yazı tipi URL'si içerebilir.

Böyle bir SVG içeriğini içeri aktarmak için bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/iexternalresourceresolver/) uygulaması oluşturun ve temel URI ile birlikte uygun bir `SvgImage` yapıcıya aktarın. Temel URI, SVG belgesinin konumunu belirler ve göreli bağlantıların çözülmesinde kullanılır.

[ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) arayüzü, içe aktarılan SVG hakkında bilgiye erişim sağlar:

- `get_SvgContent()` SVG işaretlemesini bir dize olarak döndürür. 
- `get_SvgData()` SVG içeriğini bir bayt dizisi olarak döndürür. 
- `get_BaseUri()` göreli bağlantılar için kullanılan temel URI'yi döndürür. 
- `get_ExternalResourceResolver()` SVG görseline atanmış çözücüyü döndürür. 

### **Harici Kaynak Çözücüsü Uygula**

Çözücünün iki yöntemi vardır:

- [ResolveUri](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) temel URI ile göreli kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemez veya izin verilmezse null dize döndürün. 
- [GetEntity](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) mutlak kaynak URI'si için okunabilir bir akış döndürür. Kaynak eksik, engellenmiş veya kullanılamıyorsa `nullptr` döndürün. Gerektiğinde bir yedek akış da döndürülebilir. 

Aşağıdaki çözücü, yalnızca izin verilen yerel bir dizinden bağlanmış kaynakları yükler. Ağ kaynakları ve izin verilen dizin dışındaki yollar engellenir. Çözülmemiş resim bağlantıları için isteğe bağlı bir yedek resim döndürülür.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Bu çözücü yalnızca yerel dosyalara izin verecek şekilde tasarlanmıştır.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Yalnızca görüntü kaynakları için bir yedek kullanın. Görüntü akışı döndürmek
        // eksik bir yazı tipi veya stil sayfası için geçerli olmaz.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **SVG İçe Aktarım Sırasında Bağlı Kaynakları Çözümle**

`assets/diagram.svg` dosyasının aşağıdaki gibi bir göreli referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki C++ örneği, SVG dosya URI'sini temel URI olarak aktarır ve özel bir çözücü sağlar. Çözücü, göreli resim bağlantısını mutlak bir URI'ye dönüştürür ve Aspose.Slides SVG'yi işlerken bağlanmış kaynağı içeren bir akış döndürür.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// Temel URI, SVG belgesinin konumunu temsil eder.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage, kaynak içeriği, ikili veri, temel URI ve çözücüyü ortaya çıkar.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`SvgImage` sınıfı ayrıca SVG verilerini bir bayt dizisi veya akış olarak, dış kaynak çözücüsü ve temel URI ile birlikte kabul eden aşırı yüklemeler sunar.

{{% alert title="Önemli" color="warning" %}}
Kaynak çözücü, Aspose.Slides SVG'yi işler ve render ederken harici kaynakları kullanılabilir hâle getirir. Orijinal SVG işaretlemesini değiştirmez ve çözülen kaynakları otomatik olarak içine gömme yapmaz.

Bir `ISvgImage` sunumun görsel koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de raster bir yedek görsel içerebilir. Bağlı bir kaynak, oluşturulan yedek görselde görünebilirken `images/photo.png` gibi bir göreli bağlantı depolanmış SVG'de değişmeden kalır. Yerel SVG temsilini render eden bir uygulama, orijinal harici kaynak kullanılamadığında bağlı içeriği atlayabilir.
{{% /alert %}}

### **Taşınabilir Bir SVG Resmi Oluştur**

Harici dosyalara bağlı olmayan bir SVG resmi oluşturmak için `SvgImage` oluşturmadan önce SVG'yi kendine yeter hâle getirin. Örneğin, bağlı resim URL'lerini resim verisini içeren `data:` URI'leriyle değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra `SvgImage` oluşturun, sunum görsel koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Eksik veya Engellenen Kaynakları İşle**

Bir kaynak URI geçersiz, yasak veya çözülemezse `ResolveUri` metodundan null dize döndürün. Kaynak okunamıyorsa `GetEntity` metodundan `nullptr` döndürün. Aspose.Slides mümkün olduğunda o kaynağı olmadan SVG işleme devam eder.

Eksik bir kaynak için yedek bir akış döndürülebilir, ancak içeriği istenen kaynak türüyle uyumlu olmalıdır. Örneğin, yalnızca eksik bir resim için resim akışı döndürün; bir yazı tipi veya stil sayfası için değil.

{{% alert title="Güvenlik" color="warning" %}}
Güvenilmeyen SVG dosyalarından rastgele dosya yolları veya sınırsız ağ URL'leri çözülmemelidir. İzin verilen şemalar, dizinler ve ortamlar kısıtlanmalıdır. Ağ kaynakları için bağlantı zaman aşımı, yanıt boyutu sınırları ve içerik doğrulaması da uygulanmalı.
{{% /alert %}}

## **SVG'yi Şekil Kümesine Dönüştür**
Aspose.Slides, SVG'yi PowerPoint'teki karşılık gelen işlevselliğe benzer şekilde bir şekil kümesine dönüştürebilir:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, bir [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) nesnesini ilk bağımsız değişken olarak alan [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) arayüzünün [AddGroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) metodunun bir aşırı yüklemesi tarafından sağlanır.

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Kaynak SVG dosya adı
auto svgFileName = System::String(u"sample.svg");

// Çıktı sunum dosya adı
auto outPptxPath = System::String(u"presentation.pptx");

// Yeni bir sunum oluştur
auto presentation = System::MakeObject<Presentation>();

// SVG dosya içeriğini oku
auto svgContent = File::ReadAllText(svgFileName);

// Bir SvgImage nesnesi oluştur
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Slayt boyutunu al
auto slideSize = presentation->get_SlideSize()->get_Size();

// SVG görüntüyü bir şekil grubuna dönüştür ve slayt boyutuna ölçekle
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Sunumu PPTX formatında kaydet
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Görselleri EMF Olarak Slaytlara Ekle**
Aspose.Slides for C++, Aspose.Cells ile Excel çalışma sayfalarından EMF görselleri oluşturup bunları sunum slaytlarına eklemenize olanak tanır. 

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells for C++ herhangi bir türü kullanılmadan önce başlatılmalıdır.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Çalışma sayfasını EMF olarak oluştur.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells oluşturulan sayfayı bir tampon olarak döndürür, Aspose.Slides bunu bir görüntü olarak ekler.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Görsel Koleksiyonundaki Görselleri Değiştir**

Aspose.Slides, slayt şekilleri tarafından da kullanılan, sunumun görsel koleksiyonunda depolanan görselleri değiştirmenizi sağlar. Bu bölüm, koleksiyondaki görselleri güncellemenin çeşitli yollarını açıklar. Bir görseli ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) örneği ya da koleksiyonda zaten var olan başka bir görsel kullanarak değiştirebilirsiniz.

Aşağıdaki adımları izleyin:

1. Görselleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı ile yükleyin.  
2. Yeni bir görseli dosyadan bayt dizisine yükleyin.  
3. Hedef görseli, bayt dizisini kullanarak yeni görsel ile değiştirin.  
4. İkinci yöntemde, görseli bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesneyle değiştirin.  
5. Üçüncü yöntemde, hedef görseli sunumun görsel koleksiyonunda zaten var olan bir görsel ile değiştirin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Sunum dosyasını temsil eden Presentation sınıfının örneğini oluştur.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// İlk yöntem.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// İkinci yöntem.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Üçüncü yöntem.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Sunumu bir dosyaya kaydet.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Bilgi" color="info" %}}
Aspose'un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsüyle metni kolayca canlandırabilir ve metinden GIF'ler oluşturabilirsiniz. 
{{% /alert %}}

## **SSS**

**Ekleme işleminden sonra orijinal görsel çözünürlüğü aynı kalır mı?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slaytta [resmin](/slides/tr/cpp/picture-frame/) nasıl ölçeklendirildiğine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Onlarca slaytta aynı logoyu bir anda değiştirmek için en iyi yol nedir?**

Logoyu ana slayta ya da bir düzene yerleştirin ve sunumun görsel koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklemiş bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. SVG'yi bir şekil grubuna dönüştürebilir ve ardından bireysel parçalar, standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi aynı anda birden çok slaytın arka planı olarak nasıl ayarlayabilirim?**

Resmi ana slayta ya da ilgili düzene arka plan olarak atayın—bu ana/slayt düzenini kullanan tüm slaytlar arka planı miras alır.

**Birçok resim nedeniyle sunumun çok büyük olmasını nasıl engelleyebilirim?**

Tek bir görsel kaynağını tekrar kullanın, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve gerektiğinde tekrarlanan grafikleri ana slayta taşıyın.