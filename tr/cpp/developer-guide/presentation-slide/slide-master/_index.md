---
title: C++'de Sunum Slide Master'larını Yönetme
linktitle: Slayt Master'ı
type: docs
weight: 80
url: /tr/cpp/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slaytı
- birden fazla master slayt
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
description: "Aspose.Slides for C++'de slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarında master slaytlarına erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

A **slide master** ortak tasarım ayarlarını bir grup slayt için tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve altbilgi ayarları içerebilir. PowerPoint'te bir slide master'ı düzenlemek, her slaytta aynı biçimlendirmeyi tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for C++ aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birkaç layout slayt içerebilir. Normal slaytlar genellikle doğrudan bir master slayta başvurmaz. Bunun yerine, bir normal slayt bir layout slayt kullanır ve bu layout slayt bir master slayta aittir.

Hiyerarşi şudur:

1. **Slide master** - ortak tasarımı ve temayı tanımlar.  
2. **Layout slide** - yer tutucuların ve layout seviyesindeki biçimlendirmenin belirli bir düzenini tanımlar.  
3. **Normal slide** - gerçek sunum içeriğini içerir ve bir layout slayt kullanır.  

![Master slaytların, layout slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides'te bir slide master, [IMasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/) arabirimiyle temsil edilir. Bir sunumdaki tüm master slaytlar, [Presentation::get_Masters](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_masters/) koleksiyonu aracılığıyla elde edilebilir; bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/) arabirimini uygular.

{{% alert color="info" title="Inheritance" %}}
Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye kazanır. Örneğin, bir master slayt ve bir layout slayt ikisi de bir arka plan tanımlarsa, o layout'a dayalı slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/cpp/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slide Master'lara Erişim**

PowerPoint'te **View** > **Slide Master** yoluyla Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides'te master slaytlara erişmek için `get_Masters()` koleksiyonunu kullanın:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Ayrıca bir normal slaytın kullandığı master slaytı, onun layout'u üzerinden alabilirsiniz:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Bir Slide Master'ın İçeriği**

Master slayt, slayt benzeri bir nesnedir. [IBaseSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/) arabirimini uygular, bu yüzden normal ve layout slaytlarda kullanılan birçok aynı slayt özelliğini sunar. Master'a özgü üyeler [IMasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/) API sayfasında listelenmiştir.

Sıkça kullanılan master slayt üyeleri şunlardır:

| Üye | Açıklama |
| --- | --- |
| `get_Background()` | Master düzeyindeki slayt arka planını ayarlar. |
| `get_Shapes()` | Logolar, resim çerçeveleri ve ortak metin gibi master üzerine yerleştirilen şekilleri depolar. |
| `get_LayoutSlides()` | Master'a ait layout slaytları saklar. |
| `get_ThemeManager()` | Master tema API'lerine erişim sağlar. |
| `get_HeaderFooterManager()` | Master ve onun alt layout'ları için başlık, altbilgi, tarih ve slayt numaralarını kontrol eder. |
| `GetDependingSlides()` | Layout'ları aracılığıyla master'a bağımlı olan normal slaytları döndürür. |

## **Slide Master'a Görüntü Ekleme**

Bir master slayta görüntü eklediğinizde, o master'ın layout'larını kullanan slaytlarda görünür. Bu, logolar, filigranlar, dekoratif bantlar ve diğer yinelenen görsel öğeler için faydalıdır.

Aşağıdaki örnek, ilk master slayta bir logo ekler:

```cpp
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

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layout'ların devraldığı ortak stil ve temayı sağlar, her layout ise hangi yer tutucuların mevcut olacağına ve nerede konumlandırılacağına karar verir.

PowerPoint'te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümündeki Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için, master'a ait layout slaytı ile çalışın:

```cpp
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

Ayrıca master slaytta zaten mevcut olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer bir degrade dolgu uygular:

```cpp
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

![Normal slaytlar tarafından devralınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/cpp/manage-placeholder/) ve [Text Formatting](/slides/tr/cpp/text-formatting/) bölümlerine bakın.

## **Slide Master Arka Planını Değiştirme**

Bir master arka planı, üzerine yazmayan layout'lar ve slaytlar tarafından devralınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

İlgili konular için [Presentation Background](/slides/tr/cpp/presentation-background/) ve [Presentation Theme](/slides/tr/cpp/presentation-theme/) bölümlerine bakın.

## **Slide Master'ı Başka Bir Sunuma Kopyalama**

[IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/addclone/) metodunu kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout'lar ve slaytlar tarafından kullanılabilir.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Master'larıyla birlikte normal slaytları da kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/cpp/clone-slides/) bölümüne bakın.

## **Birden Fazla Slide Master Ekleme**

Bir sunum birden fazla master slayt içerebilir. Bu, farklı bölümlerin farklı marka kimliği, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![Master slayt ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master'ı kopyalar, klona farklı bir arka plan verir, o kopyalanmış master altında bir layout oluşturur ve o layout'a dayalı yeni bir slayt ekler:

```cpp
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

## **Slide Master'ları Karşılaştırma**

Master slaytlar, [IBaseSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/) tarafından devralınan `Equals` yöntemiyle karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya mevcut tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```cpp
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

[ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) üzerindeki `set_LastView` metodunu kullanarak PowerPoint'in ilk açtığı görünümü kontrol edebilirsiniz. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/cpp/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Sunumlar bazen normal slaytlar tarafından artık kullanılmayan master slaytlar içerir. Kullanılmayan masterları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

Kullanılmayan masterları `get_Masters()` koleksiyonundan kaldırmak için [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/tr/cpp/aspose.slides/masterslidecollection/removeunused/) metodunu kullanın:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ayrıca düşük kodlu [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) metodunu da kullanabilirsiniz:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Slide master ile layout slayt arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Layout slayt, bir master slayta ait olup yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt layout slaytı kullanır, bu yüzden hem layout hem de master'dan devralır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master içerebilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden çok master kullanın.

**Yer tutucuları bir master slayta mı yoksa bir layout slayta mı eklemeliyim?**

Çoğu durumda, yer tutucular layout slaytlara eklenmelidir. Ortak görsel öğeler ve ortak biçimlendirmeyi master slayta koyun, ardından içerik yer tutucularını normal slaytların kullanacağı layout'lara yerleştirin.

**Hâlâ kullanılan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytlara sahip bir master slayt doğrudan güvenli bir şekilde silinemez. Önce bu slaytları başka bir master altındaki layout'lara taşıyın veya yalnızca kullanılmayan masterları kaldıran bir temizlik yöntemini kullanın.