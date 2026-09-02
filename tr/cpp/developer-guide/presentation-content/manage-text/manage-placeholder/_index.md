---
title: C++'ta Sunum Yer Tutucularını Yönet
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/cpp/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- resim yer tutucu
- çizelge yer tutucu
- içerik yer tutucu
- istem metni
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile metin, resim, çizelge ve içerik yer tutucularını nasıl inceleyeceğinizi ve düzenleyeceğinizi ve yer tutucu mirasını nasıl anlayacağınızı öğrenin."
---
## **Overview**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için bir konumu rezerve eden bir şekildir. Yaygın örnekler başlık, gövde, resim, çizelge ve genel amaçlı içerik yer tutucularıdır. Olağan bir şekilden farklı olarak, bir yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir düzen slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [IShape::get_Placeholder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_placeholder/) yöntemi aracılığıyla sunar. Bu yöntem normal bir şekil için `nullptr` döndürür ve bir [IPlaceholder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iplaceholder/) nesnesi döndürür. Yer tutucunun ne içermesi gerektiğini belirlemek için [IPlaceholder::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iplaceholder/get_type/) kullanın.

Şekil arayüzü, yer tutucu türünü öğrendikten sonra da önemlidir:

- Boş bir metin, resim, çizelge veya içerik yer tutucusu genellikle bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) ile temsil edilebilir.
- Dolu bir çizelge yer tutucusu bir [IChart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini barındırabilir. Her yer tutucunun bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olduğunu varsaymak yerine hem [IPlaceholder::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iplaceholder/get_type/) hem de çalışma zamanı şekil arayüzünü kontrol edin.

{{% alert color="warning" title="Uyarı" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iplaceholder/get_type/) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanı türünü garanti etmez. Metin, resim, çizelge, tablo veya medya‑özel üyelerine erişmeden önce her zaman bir tür kontrolü yapın.
{{% /alert %}}

## **Understand Placeholder Inheritance**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt yeniden kullanılabilir stilleri ve bazı durumlarda ana‑seviye yer tutucuları tanımlar.
2. Bir düzen slaytı bir veya daha fazla normal slayt tarafından kullanılan yerleşimi tanımlar ve ana slayttan devralabilir.
3. Bir normal slayt, o slayt için yer tutucuları içerir ve düzeninden devralabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/getbaseplaceholder/) yöntemini çağırın. Bir slayt yer tutucusu normalde düzen yer tutucusunu döndürür; bir düzen yer tutucusu ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `nullptr` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve temel yer tutucularını raporlar:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili düzen ya da ana slaytı düzenlemek, hâlâ bu ayarı devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve aynı koordinatları kapladığı için devralmaya başlamaz.

## **Change Text in a Placeholder**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları genellikle metni destekler. Metin çerçevesine erişmeden önce [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olup olmadığını kontrol edin ve ardından [get_TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/get_textframe/) yöntemini kullanın.

Bu örnek, ilk slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Bu desen, resim, çizelge, tablo veya medya yer tutucularını [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olarak dökmekten kaçınır. Ayrıca, kırılgan bir şekil indeksine dayanmadan yer tutucuyu amacına göre tanımlar.

## **Set Prompt Text on a Layout**

İstem metni, boş bir yer tutucuda görünen tasarım zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. İstem metnini normal bir slaytın şekil koleksiyonundan almaya çalışmak yerine, düzen yer tutucusunda özel bir istem metni ayarlayın. Düzeni, [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/get_layoutslide/) ile erişin ve [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_shapes/) üzerinde döngü oluşturun.

Aşağıdaki örnek, ilk slayt tarafından kullanılan düzen üzerindeki başlık ve alt‑başlık istemlerini değiştirir:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

İstem metni normal slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Bir kullanıcı veya program gerçek içerik sağladığında, istem artık gösterilmez. Bir istemi değiştirmek, düzeni kullanan slaytlardaki mevcut metni değiştirmez.

## **Update a Picture Placeholder**

İki durum ele alınmalıdır:

- Resim yer tutucusu zaten doluysa ve bir [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) ile temsil ediliyorsa, resmi [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/get_picture/) ve [ISlidesPicture::set_Image](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidespicture/set_image/) aracılığıyla değiştirin.
- Hâlâ boş bir yer tutucusuysa, [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addpictureframe/) ile yer tutucunun koordinatlarına bir resim çerçevesi ekleyin ve boş yer tutucusunu kaldırın.

Sonraki örnek her iki durumu da destekler ve sunumu kaydeder:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Boş bir yer tutucu için oluşturulan değişim, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [IShape::get_Placeholder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_placeholder/) yalnızca okunabilir. Rezerv edilen konumu tutar ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisini korumak önemliyse, önce PowerPoint’te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile ortaya çıkan [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) güncelleyin.

Görsel şeffaflığı, kırpma ve diğer resim‑özel etkiler için [Resim Çerçevelerini Yönet](/slides/tr/cpp/picture-frame/) bölümüne bakın. Bu işlemler resim çerçevesi veya resim doldurmasıyla ilgilidir, yer tutucu meta verisiyle değil.

## **Work with Chart and Content Placeholders**

Dolu bir çizelge yer tutucusu bir [IChart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/) ile temsil edilebilir. Bu örnek, hem yer tutucu türüne hem de çalışma zamanı arayüzüne göre böyle bir çizelgeyi bulur, başlığını değiştirir ve dosyayı kaydeder:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Genel bir içerik yer tutucusu genellikle [PlaceholderType::Object](https://reference.aspose.com/slides/tr/cpp/aspose.slides/placeholdertype/) değerine sahiptir. PowerPoint’te, çizelgeler, tablolar, diyagramlar, resimler ve medya gibi çeşitli içerik türlerini başlatan bir başlatıcı görevi görür. Doldurulduktan sonra, gerçekte ne içerdiğini öğrenmek için şekil arayüzünü inceleyin. Özelleştirilmiş düzenler ayrıca [PlaceholderType::Chart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/tr/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/tr/cpp/aspose.slides/placeholdertype/), veya [PlaceholderType::Diagram](https://reference.aspose.com/slides/tr/cpp/aspose.slides/placeholdertype/) sağlayabilir.

Aspose.Slides, [IPlaceholder::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iplaceholder/get_type/) değerini değiştirerek boş bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) yer tutucusunu bir [IChart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/) içine dönüştürmez; tür salt okunurdur. Boş bir çizelge veya içerik alanını programlı olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bunu bir çizelge için yapar:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Eklenen çizelge sıradan yerel bir çizelgedir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan devralmaz. Kategorilerini, serilerini veya çalışma kitabı verilerini değiştirmek gerektiğinde ilgili [çizelge yönetimi makalelerini](/slides/tr/cpp/powerpoint-charts/) kullanın.

## **Complete Example: Update Text or Image Content**

Aşağıdaki uçtan uca örnek bir şablonu açar, ilk slaytta bir başlık veya resim yer tutucusu arar, yer tutucu ve şekil türlerini denetler, uygun içerği günceller ve çıktıyı kaydeder. Örnek, şekil indeksini varsaymaktan veya her yer tutucuyu aynı arayüze dökmekten kaçınır.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**What is a base placeholder?**

Temel yer tutucu, başka bir yer tutucunun devraldığı düzen ya da ana slayttaki karşılık gelen şekildir. Onu almak için [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/getbaseplaceholder/) kullanın. Normal bir yerel şekil `nullptr` döndürür çünkü yer tutucu hiyerarşisinin bir parçası değildir.

**Can I change all slide titles by editing a layout placeholder?**

Düzen üzerinden devralınan biçimlendirme veya istem metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda saklanır. Tüm sunumdaki gerçek başlık metinlerini değiştirmek için slaytlar üzerinde döngü oluşturup her başlık yer tutucusunu güncelleyin.

**How do I manage date, slide-number, header, and footer placeholders?**

İlgili slayt, düzen, ana, not veya el ilanı kapsamındaki başlık ve dipnot yöneticilerini kullanın. Tam örnekler için [Sunum Başlık ve Dipnotlarını Yönet](/slides/tr/cpp/presentation-header-and-footer/) bölümüne bakın.