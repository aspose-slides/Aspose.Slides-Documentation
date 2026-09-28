---
title: "C++'ta Sunum Slide Master'larını Yönet"
linktitle: Slayt Master
type: docs
weight: 80
url: /tr/cpp/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slayt
- çoklu master slaytlar
- master slaytları karşılaştır
- arka plan
- yer tutucu
- master slaytı klonla
- master slaytı kopyala
- master slaytı çoğalt
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarında master slaytlara erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için paylaşılan tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint’te bir slide master’ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for C++ aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birden çok yerleşim slaytı barındırabilir. Normal slaytlar doğrudan bir master slayta başvurmaz. Bunun yerine, bir normal slayt bir yerleşim slaytı kullanır ve bu yerleşim slaytı bir master slayta aittir.

Hiyerarşi şu şekildedir:

1. **Slide master** – paylaşılan tasarımı ve temayı tanımlar.  
1. **Layout slide** – yer tutucuların ve yerleşim‑seviyesi biçimlendirmelerin belirli bir düzenini tanımlar.  
1. **Normal slide** – gerçek sunum içeriğini barındırır ve bir layout slide kullanır.

![Ana slaytların, yerleşim slaytlarının ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’te bir slide master, [IMasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/) arayüzüyle temsil edilir. Sunumdaki tüm master slaytlar, [Presentation::get_Masters](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_masters/) koleksiyonu üzerinden erişilebilir ve bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/) arayüzünü uygular.

{{% alert color="info" title="Inheritance" %}}
Birden fazla seviyede aynı özellik tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir master slayt ve bir layout slayt aynı arka planı tanımlıyorsa, o layout’a dayanarak oluşturulan slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/cpp/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slide Master’lara Erişim**

PowerPoint’te **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’te master slaytlara erişmek için `get_Masters()` koleksiyonunu kullanın:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Ayrıca bir normal slaytın kullandığı master slaytı, onun layout’u aracılığıyla da alabilirsiniz:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Bir Slide Master’ın İçeriği**

Bir master slayt, slayt benzeri bir nesnedir. [IBaseSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/) arayüzünü uygular, dolayısıyla normal ve layout slaytlarda kullanılan birçok slayt özelliğine sahiptir. Master‑özel üyeler [IMasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/) API sayfasında listelenmiştir.

Sık kullanılan master slayt üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `get_Background()` | Master‑seviyesindeki slayt arka planını ayarlar. |
| `get_Shapes()` | Logolar, resim çerçeveleri ve paylaşılan metin gibi master üzerine yerleştirilen şekilleri saklar. |
| `get_LayoutSlides()` | Master’a ait layout slaytlarını saklar. |
| `get_ThemeManager()` | Master tema API’lerine erişim sağlar. |
| `get_HeaderFooterManager()` | Master ve onun alt layoutları için başlık, alt bilgi, tarih ve slayt numarası ayarlarını kontrol eder. |
| `GetDependingSlides()` | Layoutları aracılığıyla master’a bağımlı olan normal slaytları döndürür. |

## **Slide Master’a Resim Ekleme**

Bir master slayta resim eklediğinizde, o master’dan layout kullanan slaytlarda görünür. Bu, logolar, filigranlar, dekoratif bantlar ve diğer tekrarlanan görsel öğeler için faydalıdır.

Aşağıdaki örnek, ilk master slayta bir logo ekler:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/cpp/picture-frame/) bölümüne bakın.

## **Master Grafiklerinin Görünürlüğünü Kontrol Etme**

[Müşterek] master grafiklerini (ör. logolar, dekoratif şekiller) silmeden gizlemek için [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/set_showmastershapes/) kullanın. Bu özelliği, grafikleri gizlemek istenen slaytta [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/set_showmastershapes/) metoduna `false` olarak, görüntülenmesini istediğiniz slaytlara ise `true` olarak aktarın.

Aşağıdaki örnek, bir master’da mavi bir dekoratif bant oluşturur ve aynı boş layout’u kullanan iki slaytta görüntülenme durumunu farklılaştırır. İlk slaytta bant görünür, ikinci slaytta gizlenir. Giriş sunumu veya resim gerektirmez.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Örnek, yeni bir sunumla birlikte gelen **Blank** layout’u kullanır ve başlangıç slaytının kendi yer tutucularını kaldırır.

### **Ayarlamanın Kapsamını Seçme**

Normal bir slayt, masterına [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/get_layoutslide/) ve [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_masterslide/) aracılığıyla ulaşır. Özelliği bireysel bir slaytta ayarlamak yalnız o slaytı etkiler. `false` değerini [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/layoutslide/set_showmastershapes/) metoduna geçirirseniz, aynı paylaşılan layout’u kullanan diğer slaytların ayarı `true` olsa bile master grafikleri gizlenir. Sadece bir slaytta grafikleri gizlemek istiyorsanız, slayt özelliğini değiştirip paylaşılan layout’u aynı bırakın.

Bu ayar, master slayt üzerinde görünürlük kontrolü olarak desteklenmez. Master üzerinde her zaman `false` döner ve `true` atamaya çalıştığınızda `System::NotSupportedException` oluşur. Bunun yerine bir normal slayt ya da layout üzerinde uygulayın.

### **Grafikleri Arka Plandan Ayırma**

| İşlem | Etki |
| --- | --- |
| Master grafikleri gizle | Master’dan kalıtılan şekilleri silmeden görünürlüğünü kontrol eder. |
| Slayt arka plan doldurmasını değiştir | Arka plan rengi, geçişi veya resmini değiştirir. Master grafikleri ayrı şekiller olduğundan arka planın üzerine görünmeye devam eder. [Presentation Background](/slides/tr/cpp/presentation-background/) bölümüne bakın. |
| Master’dan bir şekli sil | Paylaşılan kaynak şekli kaldırır; bu şekil artık o master’ı kullanan hiçbir slaytta bulunmaz. |

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layoutların kalıtacağı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların mevcut olacağını ve nerede konumlanacağını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümündedir.

![PowerPoint Slide Master görünümündeki Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides’da yeni yer tutucular eklemek için, master’a ait layout slaytı ile çalışın:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ayrıca bir master slaytta zaten bulunan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve doğrusal bir geçiş doldurması uygular:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Normal slaytlara kalıtılan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Ek yer tutucu ve metin biçimlendirme seçenekleri için [Set Prompt Text in Placeholder](/slides/tr/cpp/manage-placeholder/) ve [Text Formatting](/slides/tr/cpp/text-formatting/) bölümlerine bakın.

## **Slide Master Arka Planını Değiştirme**

Bir master arka planı, onu geçersiz kılmayan layout ve slaytlar tarafından kalıtılır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

İlgili konular için [Presentation Background](/slides/tr/cpp/presentation-background/) ve [Presentation Theme](/slides/tr/cpp/presentation-theme/) bölümlerine göz atın.

## **Bir Slide Master’ı Başka Bir Sunuma Kopyalama**

[IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/addclone/) kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Normal slaytları ve onların masterlarını birlikte kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/cpp/clone-slides/) bölümüne bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden çok master slayt içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![PowerPoint’te master slayt ekleme ve yönetme komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master’ı klonlar, klona farklı bir arka plan verir, o klon master altında bir layout oluşturur ve bu layout’a dayalı yeni bir slayt ekler:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Slide Master’ları Karşılaştırma**

Master slaytlar, [IBaseSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/) üzerinden miras alınan `Equals` yöntemiyle karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/cpp/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) üzerindeki `set_LastView` yöntemiyle PowerPoint’in ilk açtığı görünüm kontrol edilebilir. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Diğer görünüm ayarları için [Save Presentation](/slides/tr/cpp/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen sunumlarda artık hiçbir normal slayt tarafından kullanılmayan master slaytlar bulunur. Kullanılmayan masterları kaldırmak dosya boyutunu azaltır ve şablon bakımını basitleştirir.

`get_Masters()` koleksiyonunda kullanılmayan masterları kaldırmak için [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/tr/cpp/aspose.slides/masterslidecollection/removeunused/) metodunu kullanın:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ayrıca düşük‑kodlu [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) metodunu da tercih edebilirsiniz:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Slide master ile layout slayt arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi paylaşılan tasarım ayarlarını tanımlar. Layout slayt, bir master’a aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slayt kullanır, böylece hem layout hem de master’dan kalıtım alır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master barındırabilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden çok master kullanın.

**Yer tutucuları master slayta mı yoksa layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeleri master slayta koyun, içerik yer tutucularını ise normal slaytların kullanacağı layout slaytlara yerleştirin.

**Kullanılan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slaytı doğrudan güvenli bir şekilde kaldırılamaz. Önce bu slaytları başka bir master’ın layout’larına taşıyın veya sadece kullanılmayan masterları temizleyen bir yöntem uygulayın.