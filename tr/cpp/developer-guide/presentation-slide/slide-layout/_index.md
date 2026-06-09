---
title: "C++'ta Slayt Düzenlerini Uygulama veya Değiştirme"
linktitle: "Slayt Düzeni"
type: docs
weight: 60
url: /tr/cpp/slide-layout/
keywords:
- slayt düzeni
- içerik düzeni
- yer tutucu
- sunum tasarımı
- slayt tasarımı
- kullanılmayan düzen
- altbilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- sadece başlık
- boş düzen
- başlıklı içerik
- başlıklı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta slayt düzenlerini yönetin ve özelleştirin. Layout türlerini, yer tutucu kontrolünü ve altbilgi görünürlüğünü C++ kod örnekleriyle keşfedin."
---
## **Giriş**

Bir slayt düzeni, bir slayttaki yer tutucu kutuların düzenini ve içerik biçimlendirmesini tanımlar. Hangi yer tutucuların mevcut olduğunu ve nerede görüneceklerini kontrol eder. Slayt düzenleri, basit ya da daha karmaşık bir şey oluşturuyor olsanız da, sunumları hızlı ve tutarlı bir şekilde tasarlamanıza yardımcı olur. PowerPoint’te en yaygın slayt düzenlerinden bazıları şunlardır:

**Başlık Slaytı düzeni** – Başlık ve alt başlık için iki metin yer tutucu içerir.

**Başlık ve İçerik düzeni** – Üstte daha küçük bir başlık yer tutucu ve aşağıda metin, madde işaretleri, grafikler, resimler ve daha fazlası gibi ana içerik için daha büyük bir yer tutucu bulunur.

**Boş düzen** – Hiç yer tutucu içermez; slaytı sıfırdan tasarlamak için tam kontrol sağlar.

Slayt düzenleri, sunumun düzen stillerini tanımlayan en üst seviye slayt olan bir slayt ustasının parçasıdır. Düzen slaytlarına slayt ustası aracılığıyla—tipine, adına ya da benzersiz kimliğine göre—erişebilir ve bunları değiştirebilirsiniz. Alternatif olarak, belirli bir düzen slaytını doğrudan sunum içinde düzenleyebilirsiniz.

Aspose.Slides for Android’da slayt düzenleriyle çalışmak için şunları kullanabilirsiniz:

- **[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/)** sınıfı altında **[get_LayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_layoutslides/)** ve **[get_Masters](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_masters/)** gibi yöntemler
- **[ILayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/)**, **[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterlayoutslidecollection/)**, **[ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/)** ve **[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslideheaderfootermanager/)** gibi tipler

{{% alert title="Info" color="info" %}}
Ana slaytlarla çalışma hakkında daha fazla bilgi edinmek için [Slide Master](/slides/tr/cpp/slide-master/) makalesine göz atın.
{{% /alert %}}

## **Sunumlara Slayt Düzenleri Ekleme**

Slaytlarınızın görünümünü ve yapısını özelleştirmek için sunuma yeni düzen slaytları eklemeniz gerekebilir. Aspose.Slides for Android, belirli bir düzenin zaten var olup olmadığını kontrol etmenize, gerekirse yeni bir tane eklemenize ve bu düzeni kullanarak slayt eklemenize olanak tanır.

1. Bir **[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/)** sınıfının örneğini oluşturun.  
1. **[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterlayoutslidecollection/)**'e erişin.  
1. İstenen düzen slaytının koleksiyonda zaten var olup olmadığını kontrol edin. Yoksa ihtiyaç duyduğunuz düzen slaytını ekleyin.  
1. Yeni düzen slaytına dayalı boş bir slayt ekleyin.  
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir PowerPoint sunumuna slayt düzeni eklemeyi gösterir:

```cpp
// PowerPoint dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Sunumun tüm düzen türlerini içermediği bir durum.
    // Sunum dosyası sadece Boş ve Özel düzen türlerini içerir.
    // Ancak, özel türlere sahip düzen slaytları tanınabilir isimlere sahip olabilir,
    // örneğin "Title", "Title and Content" gibi, bu isimler düzen slaytı seçimi için kullanılabilir.
    // Ayrıca bir dizi yer tutucu şekil türüne güvenebilirsiniz.
    // Örneğin, bir Başlık slaytının yalnızca Başlık yer tutucu türüne sahip olması gerekir vb.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Eklenen düzen slaytını kullanarak boş bir slayt ekleyin.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Sunumu diske kaydedin.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan düzen slaytlarını silmenizi sağlayan **[Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/)** sınıfındaki **[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)** yöntemini sunar.

Aşağıdaki C++ kodu, bir PowerPoint sunumundan bir düzen slaytının nasıl kaldırılacağını gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Slayt Düzenlerine Yer Tutucular Ekleme**

Aspose.Slides, bir düzen slaytına yeni yer tutucular eklemenizi sağlayan **[ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/)** yöntemini sunar.

Bu yönetici aşağıdaki yer tutucu türleri için yöntemler içerir:

| PowerPoint Yer Tutucu               | **[ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/)** Yöntemi |
| ----------------------------------- | ------------------------------------------------------------ |
| ![İçerik](content.png)              | AddContentPlaceholder(float x, float y, float width, float height) |
| ![İçerik (Dikey)](contentV.png)    | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Metin](text.png)                  | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Metin (Dikey)](textV.png)        | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Resim](picture.png)               | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafik](chart.png)                | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tablo](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medya](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Çevrimiçi Resim](onlineimage.png)| AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Aşağıdaki C++ kodu, Boş düzen slaytına yeni yer tutucu şekilleri eklemeyi gösterir:

```cpp
auto presentation = MakeObject<Presentation>();

// Boş düzen slaytını al.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Get the placeholder manager of the layout slide.
auto placeholderManager = layout->get_PlaceholderManager();

// Add different placeholders to the Blank layout slide.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

## **Bir Düzen Slaytı İçin Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özel metin gibi altbilgi öğeleri, slayt düzenine bağlı olarak gösterilebilir ya da gizlenebilir. Aspose.Slides for Android, bu altbilgi yer tutucularının görünürlüğünü kontrol etmenizi sağlar. Bu, belirli düzenlerin altbilgi bilgilerinin gösterilmesini, diğerlerinin ise temiz ve sade kalmasını istediğinizde kullanışlıdır.

1. Bir **[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/)** sınıfının örneğini oluşturun.  
1. Diziniyle bir düzen slaytı referansı alın.  
1. Slayt altbilgi yer tutucusunu görünür yapın.  
1. Slayt numarası yer tutucusunu görünür yapın.  
1. Tarih‑zaman yer tutucusunu görünür yapın.  
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir slayt altbilgisinin görünürlüğünü ayarlamayı ve ilgili işlemleri göstermektedir:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir Slayt İçin Alt Slayt Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özel metin gibi altbilgi öğeleri, tüm düzen slaytları arasında tutarlılığı sağlamak için ana slayt seviyesinde kontrol edilebilir. Aspose.Slides for Android, bu altbilgi yer tutucularının görünürlüğünü ve içeriğini ana slaytta ayarlamanıza ve bu ayarları tüm alt düzen slaytlarına yaymanıza olanak tanır. Bu yaklaşım, sunumunuz boyunca tutarlı altbilgi bilgileri sağlar.

1. Bir **[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/)** sınıfının örneğini oluşturun.  
1. Diziniyle ana slayta bir referans alın.  
1. Ana slaydın ve tüm alt slaytların altbilgi yer tutucularını görünür yapın.  
1. Ana slaydın ve tüm alt slaytların slayt numarası yer tutucularını görünür yapın.  
1. Ana slaydın ve tüm alt slaytların tarih‑zaman yer tutucularını görünür yapın.  
1. Sunumu kaydedin.

Aşağıdaki C++ kodu bu işlemi göstermektedir:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Ana slayt ile düzen slaytı arasındaki fark nedir?**

Ana slayt genel temayı ve varsayılan biçimlendirmeyi tanımlarken, düzen slaytları farklı içerik türleri için belirli yer tutucu düzenlerini tanımlar.

**Bir düzen slaytını bir sunumdan başka bir sunuma kopyalayabilir miyim?**

Evet, bir sunumun **[get_LayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_layoutslides/)** yöntemiyle erişilebilen düzen slayt koleksiyonundan bir düzen slaytını klonlayabilir ve `AddClone` yöntemiyle başka bir sunuma ekleyebilirsiniz.

**Bir slayt tarafından hâlâ kullanılan bir düzen slaytını silersem ne olur?**

Bir düzen slaytı, sunumdaki en az bir slayt tarafından hâlâ referans alınıyorsa silmeye çalıştığınızda Aspose.Slides **[PptxEditException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxeditexception/)** fırlatır. Bunu önlemek için, yalnızca kullanılmayan düzen slaytlarını güvenli bir şekilde kaldıran **[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)** yöntemini kullanın.