---
title: C++'ta Sunum Slaytlarını SVG Görüntüler Olarak Render Etme
linktitle: Slayttan SVG
type: docs
weight: 50
url: /tr/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'ten SVG'ye
- SVG dışa aktarım seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "C++'ta PowerPoint slaytlarını SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tipleri, metin, görüntüler, kimlikler ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik son işleme için iyi çalışan ölçeklenebilir XML tabanlı bir görüntü formatıdır. Aspose.Slides for C++ her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin sıkışık, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktarma**

Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) oluşturun, bir slaytı seçin ve onu bir akısa yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

Dosya adı, döngü indeksi yerine [ISlide::get_SlideNumber](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/get_slidenumber/) kullanır. Bir slayt görüntüleyicisi ya da web sayfası yalnızca belirli bir şekle ihtiyaç duyduğunda, [IShape::WriteAsSvg](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/writeassvg/) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/) SVG renderlemesini kontrol eder. Metin çerçeveleri için, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_useframesize/) metin çerçevesini renderleme alanına dahil eder ve [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_useframerotation/) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz renderlenmesi gerektiğinde [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) değerini `true` olarak ayarlayın.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Metin ve Yazı Tiplerini Kontrol Etme**

### **Tüm Metni Vektörleştir**

Tüm slayt metnini vektör grafik olarak yazmak için [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) değerini `true` olarak ayarlayın. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Harici Yazı Tiplerinin Nasıl İşleneceğini Seçin**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) harici olarak yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için `AddLinksToFontFiles`, yazı tipi verisini SVG'ye dahil etmek için `Embed` ve harici yazı tiplerini kullanan metni yalnızca grafik olarak renderlemek için `Vectorize` seçeneğini seçin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Gömülü Görüntü Boyutunu Azaltma**

Gömülü resimlerin çözünürlüğünü azaltmak için [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_picturescompression/), kırpılmış kaynak alanlarını dışarıda bırakmak için [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/), ve JPEG kodlama kalitesini kontrol etmek için [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_jpegquality/) kullanın. Bu ayarlar, dosya boyutunu azaltır ancak görüntü doğruluğu veya tutulan görüntü verisi pahasına olur.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Şekillere ve Metne Kararlı Kimlikler Atama**

Her SVG şekli için [ISvgShape::set_Id](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isvgshape/set_id/) ayarlamak amacıyla [ISvgShapeFormattingController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isvgshapeformattingcontroller/) kullanın. Metin `tspan` öğelerine de [ISvgTSpan::set_Id](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isvgtspan/set_id/) değerleri atamak için [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) uygulayın. Bu denetleyicilerden birini [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) ile atayın.

Aşağıdaki denetleyici, şeklin ömrü boyunca kararlı olan ve metin span'ları için tekrarlanabilir bir sayaç sağlayan [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_officeinteropshapeid/) yöntemini kullanır. Bu, oluşturulan kimliklerin değişmemiş bir sunumun son işlemine uygun olmasını sağlar.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **SVG Olay İşleyicileri Ekleme**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isvgshapeformattingcontroller/) içinde bir [SvgEvent](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgevent/) değeriyle [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isvgshape/seteventhandler/) çağırarak dışa aktarılan bir şekle JavaScript olay işleyicisi ekleyin. Denetleyiciyi [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) ile atayın ve sonucu barındıran sayfa veya SVG belgesinde JavaScript fonksiyonunu tanımlayın.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

Ana sayfa, işleyici tarafından referans edilen JavaScript fonksiyonunu tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) yerine [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgexternalfontshandling/) ne zaman kullanılmalı?**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanılmalıdır. [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgexternalfontshandling/) yalnızca harici yazı tiplerini kullanan metnin grafiklere dönüştürülmesi gerektiğinde kullanılmalıdır.

**Bir SVG'yi daha küçük yapmanın en iyi yolu nedir?**

İlk olarak gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bu dosyaları sunabiliyorsa bağlantılı yazı tipi dosyalarını seçin. Sonucu test edin; çünkü düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin her biri farklı kalite ve boyut dengelerine sahiptir.

**Dışa aktarılan SVG öğelerini dışa aktarımdan sonra değiştirebilir miyim?**

Evet. Bir biçimlendirme denetleyicisi aracılığıyla kimlikler atayın, ardından bu kimlikleri post‑işleme aracınızda veya tarayıcı betiğinizde eşleşen SVG öğelerini seçin.