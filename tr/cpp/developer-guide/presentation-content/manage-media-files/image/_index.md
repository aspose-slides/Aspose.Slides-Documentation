---
title: C++ Kullanarak Sunumlarda Görsel Yönetimini Optimize Etme
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
- arkaplan
- PNG ekle
- JPG ekle
- SVG ekle
- harici SVG kaynakları
- SVG çözücü
- bağlantılı SVG görselleri
- SVG yazı tipleri
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument'ta görsel yönetimini Aspose.Slides for C++ ile kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Introduction**

Görseller sunumları daha ilgi çekici ve görsel açıdan çekici hâle getirir. Microsoft PowerPoint'te, dosyalardan, internetten veya diğer kaynaklardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides birkaç yöntemle sunum slaytlarına görsel eklemenizi sağlar. 

{{% alert title="İpucu" color="info" %}} 
Aspose, görsellerden hızlıca sunum oluşturmanıza olanak tanıyan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 
{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}
Bir resmi resim çerçevesi olarak eklemek istiyorsanız—özellikle boyutlandırmayı, efekt uygulamayı veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](/slides/tr/cpp/picture-frame/) sayfasına bakın. 
{{% /alert %}} 

{{% alert title="Not" color="warning" %}}
Görselleri bir formattan diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: [image to JPG](https://products.aspose.com/slides/tr/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/tr/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/tr/cpp/conversion/png-to-svg/), ve [SVG to PNG](https://products.aspose.com/slides/tr/cpp/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlardaki görselleri destekler. 

## **Add Images Stored Locally to Slides**

Bilgisayarınızda depolanan bir veya daha fazla görseli sunum slaydına ekleyebilirsiniz. Aşağıdaki C++ örnek kodu, bir görselin slayta nasıl ekleneceğini gösterir:

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

## **Add Images from the Web to Slides**

Bir slayta eklemek istediğiniz görsel bilgisayarınızda depolanmamışsa, doğrudan web üzerinden ekleyebilirsiniz. 

Aşağıdaki C++ örnek kodu, web üzerinden bir görselin slayta nasıl ekleneceğini gösterir:

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

## **Add Images to Slide Masters**

Slide master, onu kullanan slaytların tema ve düzen gibi bilgilerini depolar ve kontrol eder. Bir slide master'a görsel eklerseniz, görsel o master tabanlı her slaytta görünür. 

Aşağıdaki C++ örnek kodu, bir slide master'a görselin nasıl ekleneceğini gösterir:

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

## **Add Images as Slide Backgrounds**

Bir veya birden fazla slaytın arka planı olarak bir resmi kullanabilirsiniz. Detaylar için *[Setting Images as Backgrounds for Slides](/slides/tr/cpp/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **Add SVG to Presentations**

SVG içeriği, [SvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/svgimage/) sınıfı kullanılarak bir sunuma eklenebilir. Oluşan [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) nesnesi daha sonra sunumun görüntü koleksiyonuna eklenip bir resim çerçevesi oluşturmak için kullanılabilir.

Aşağıdaki C++ örneği, bağımsız bir SVG dizesini içe aktarır. Bu SVG tarafından kullanılan tüm görseller, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülüdür.

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

## **Import SVG Content with External Resources**

Tasarım araçları, diyagram editörleri, ikon sistemleri ve web işlem hatlarından dışa aktarılan SVG dosyaları, SVG belgesi dışındaki kaynaklara başvurabilir. Örneğin, bir SVG `images/photo.png` gibi bir görüntü bağlantısı, bir CSS `url(...)` değeri veya bir font URL'si içerebilir. 

Böyle bir SVG içeriğini içe aktarmak için bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/iexternalresourceresolver/) uygulaması oluşturup, temel URI ile birlikte uygun `SvgImage` yapıcısına geçirmeniz gerekir. Temel URI, SVG belgesinin konumunu belirler ve göreli bağlantıların çözülmesinde kullanılır. 

[ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) arayüzü, içe aktarılan SVG hakkında bilgiye erişim sağlar:

- `get_SvgContent()` SVG işaretlemesini bir dize olarak döndürür.  
- `get_SvgData()` SVG içeriğini bir bayt dizisi olarak döndürür.  
- `get_BaseUri()` göreli bağlantılar için kullanılan temel URI'yi döndürür.  
- `get_ExternalResourceResolver()` SVG görseline atanan çözücüyü döndürür.  

### **Implement an External Resource Resolver**

Çözücünün iki yöntemi vardır:

- [ResolveUri](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) temel URI ile göreli kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemiyorsa veya izin verilmiyorsa null dize döndürün.  
- [GetEntity](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) mutlak kaynak URI'si için okunabilir bir akış döndürür. Kaynak eksik, engellenmiş veya kullanılamıyorsa `nullptr` döndürün. Gerektiğinde bir yedek akış da döndürülebilir.  

Aşağıdaki çözücü, yalnızca izin verilen yerel dizinden bağlanan kaynakları yükler. Ağ kaynakları ve izin verilen dizin dışındaki yollar engellenir. Çözülmeyen görüntü bağlantıları için isteğe bağlı bir yedek resim döndürülür.

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

        // Yalnızca görüntü kaynakları için bir yedek kullanın. Bir görüntü akışı döndürmek
        // eksik bir font veya stil sayfası için geçerli olmaz.
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

### **Resolve Linked Resources During SVG Import**

`assets/diagram.svg` dosyasının aşağıdaki gibi bir göreli referansı olduğunu varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki C++ örneği, SVG dosyası URI'sini temel URI olarak geçirir ve özel bir çözücü sağlar. Çözücü, göreli görüntü bağlantısını mutlak bir URI'ye dönüştürür ve Aspose.Slides SVG'yi işlerken bağlanan kaynağı içeren bir akış döndürür.

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

// ISvgImage, kaynak içeriği, ikili veriyi, temel URI'yi ve çözücüyü ortaya çıkar.
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

`SvgImage` sınıfı ayrıca SVG verisini bir bayt dizisi veya akış olarak, dış kaynak çözücüsü ve temel URI ile kabul eden aşırı yüklemeler sunar.

{{% alert title="Önemli" color="warning" %}}
Kaynak çözücü, Aspose.Slides SVG'yi işler ve render ederken dış kaynakların kullanılabilir olmasını sağlar. Orijinal SVG işaretlemesini değiştirmez ve çözülen kaynakları otomatik olarak içine gömme yapmaz.  
Bir `ISvgImage` sunumun görüntü koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de raster bir yedek görüntü içerebilir. Bağlantılı bir kaynak, oluşturulan yedek görüntüde görünebilir; ancak `images/photo.png` gibi bir göreli bağlantı saklanan SVG'de değişmeden kalır. Yerel SVG temsilini render eden bir uygulama, orijinal dış kaynak erişilemezse bağlanan içeriği atlayabilir.  
{{% /alert %}}

### **Create a Portable SVG Picture**

Harici dosyalara bağımlı olmayan bir SVG resmi oluşturmak için `SvgImage` oluşturulmadan önce SVG'yi bağımsız hâle getirin. Örneğin, bağlanan görüntü URL'lerini, görüntü verisini içeren `data:` URI'larıyla değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Tüm gerekli kaynaklar SVG içeriğine gömüldükten sonra `SvgImage` oluşturun, sunumun görüntü koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Handle Missing or Blocked Resources**

`ResolveUri` geçersiz, yasak veya çözülemeyen bir kaynak URI'si ile karşılaştığında null dize döndürmelidir. `GetEntity` kaynağa erişilemediğinde `nullptr` döndürmelidir. Aspose.Slides mümkün olduğunca bu kaynağı olmadan SVG işlemesine devam eder.  
Eksik bir kaynak için bir yedek akış döndürülebilir, ancak içeriği istenen kaynak türüyle uyumlu olmalıdır. Örneğin, yalnızca eksik bir görüntü için görüntü akışı döndürülmeli; font veya stil sayfası için değil.

{{% alert title="Güvenlik" color="warning" %}}
Güvenilmeyen SVG dosyalarından rastgele dosya yolları veya sınırsız ağ URL'leri çözülmemelidir. İzin verilen şemalar, dizinler ve ana makineler kısıtlanmalıdır. Ağ kaynakları için bağlantı zaman aşımı, yanıt boyutu sınırları ve içerik doğrulaması da uygulanmalıdır.  
{{% /alert %}}

## **Convert SVG to a Set of Shapes**
Aspose.Slides, bir SVG'yi PowerPoint'teki karşılık gelen işlevselliğe benzer şekilde bir şekil kümesine dönüştürebilir:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, bir [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) nesnesini ilk argüman olarak alan [AddGroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) metodunun bir aşırı yüklemesi tarafından sağlanır.

Aşağıdaki C++ örnek kodu, bu yöntemi kullanarak bir SVG dosyasını şekil kümesine nasıl dönüştüreceğinizi gösterir:

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

// SVG görüntüsünü bir şekil grubuna dönüştür ve slayt boyutuna ölçekle
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Sunumu PPTX formatında kaydet
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Add Images as EMF to Slides**
Aspose.Slides for C++, Aspose.Cells ile Excel çalışma sayfalarından EMF görselleri oluşturup bu görselleri sunum slaytlarına eklemenizi sağlar. 

Aşağıdaki C++ örnek kodu bunu nasıl yapacağınızı gösterir:

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

// Aspose.Cells for C++ tiplerinin herhangi biri kullanılmadan önce başlatılmalıdır.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render the worksheet as EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells işlenen sayfayı bir tampon olarak döndürür, bu da Aspose.Slides tarafından bir görsel olarak eklenir.
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

## **Replace Images in the Image Collection**

Aspose.Slides, bir sunumun görüntü koleksiyonunda depolanan görselleri, slayt şekilleri tarafından kullanılan görseller dahil, değiştirmenize izin verir. Bu bölüm, koleksiyondaki görselleri güncellemenin çeşitli yollarını açıklar. Bir görseli ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut başka bir görsel kullanarak değiştirebilirsiniz.

Aşağıdaki adımları izleyin:

1. Görselleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı ile yükleyin.  
1. Yeni bir görseli dosyadan bir bayt dizisine yükleyin.  
1. Hedef görseli yeni görselin bayt dizisiyle değiştirin.  
1. İkinci yöntemde, görseli bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) nesnesine yükleyip hedef görseli bu nesneyle değiştirin.  
1. Üçüncü yöntemde, hedef görseli sunumun görüntü koleksiyonunda zaten mevcut bir görselle değiştirin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

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

// Sunum dosyasını temsil eden Presentation sınıfını başlat.
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
Aspose'un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü sayesinde metni kolayca canlandırabilir ve metinden GIF'ler oluşturabilirsiniz. 
{{% /alert %}}

## **FAQ**

**Orijinal görsel çözünürlüğü ekleme sonrasında aynı kalır mı?**  
Evet. Kaynak pikseller korunur, ancak nihai görünüm, slayttaki [picture](/slides/tr/cpp/picture-frame/) ölçeklemesi ve kaydetme sırasında uygulanan sıkıştırma gibi faktörlere bağlıdır.  

**Onlarca slaytta aynı logoyu aynı anda değiştirmek için en iyi yol nedir?**  
Logoyu master slayta veya bir layout'a yerleştirin ve sunumun görüntü koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.  

**Eklemiş olduğum bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**  
Evet. SVG'yi bir şekil grubuna dönüştürebilir, ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.  

**Birden fazla slayt için resmi aynı anda arka plan olarak nasıl ayarlarım?**  
Resmi master slaytta veya ilgili layout'ta arka plan olarak atayın—o master/layout kullanan tüm slaytlar arka planı miras alır.  

**Sunum, çok sayıda resim nedeniyle çok büyük hale gelmesini nasıl önleyebilirim?**  
Tek bir görsel kaynağını tekrar kullanın, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve tekrarlanan grafikleri mümkünse master üzerinde tutun.