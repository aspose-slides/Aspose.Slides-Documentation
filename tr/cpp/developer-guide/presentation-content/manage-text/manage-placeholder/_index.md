---
title: C++'ta Sunum Yer Tutucularını Yönetme
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
- ipucu metni
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile metin, resim, çizelge ve içerik yer tutucularını incelemeyi ve düzenlemeyi, ayrıca yer tutucu mirasını anlamayı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, çizelge ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konum, boyut, biçimlendirme ve diğer ayarları bir düzen slaytı ya da ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) yöntemi aracılığıyla sunar. Yöntem, normal bir şekil için `nullptr` dönen bir [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) nesnesi döndürür. Yer tutucunun ne tür içerik barındırması gerektiğini belirlemek için [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) kullanın.

Şekil arayüzü, yer tutucu türünü öğrendikten sonra da önemlidir:

- Boş bir metin, resim, çizelge veya içerik yer tutucu genellikle bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ile temsil edilir.
- Dolu bir resim yer tutucu, bir [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) ile temsil edilebilir.
- Dolu bir çizelge yer tutucu, bir [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) ile temsil edilebilir.
- İçerik yer tutucu, çeşitli içerik türleri barındırabilir. Her yer tutucunun bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) olduğunu varsaymak yerine hem [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) hem de çalışma zamanındaki şekil arayüzünü kontrol edin.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanı tipini garanti etmez. Metin, resim, çizelge, tablo veya medya‑özel üyelerine erişmeden önce her zaman bir tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Mirasını Anlamak**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana‑seviye yer tutucuları tanımlar.
2. Bir düzen slaytı, bir ya da daha fazla normal slayt için kullanılan düzeni tanımlar ve ana slayttan devralabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve düzeninden devralabilir.

Bu hiyerarşide bir seviye yukarı gitmek için [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) çağrın. Normalde bir slayt yer tutucusu, düzen yer tutucusunu; bir düzen yer tutucusu da ana yer tutucusunu döndürür. Şeklin temel yer tutucusu yoksa yöntem `nullptr` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve temel yer tutucularını rapor eder:

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili düzen ya da ana slaytı düzenlemek, hâlâ bu ayarı devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve aynı koordinatları kullandığı için otomatik olarak miras almaya başlamaz.

## **Yer Tutucu Durumunu Kaldırma**

Bir şablonu uyarlarken, mevcut nesneyi normal bir şekil olarak tutmak için [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) kullanın. Bunun [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) yöntemi `nullptr` döndürür, ancak şekil slayt koleksiyonunda kalır. Buna karşılık, [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) şekli o koleksiyondan siler.

Aşağıdaki örnek, en az bir slaytı ve ilk slaytta boş olmayan bir metin yer tutucusu bulunan bir `template.pptx` dosyasını gerektirir. Düzen ya da ana slayttan devralınan biçimlendirmeye sahip bir yer tutucu kullanarak ilişkinin kaldırılmasının etkisini görün. Örnek, aynı şeklin kaldığını doğrular, yöntemi artık normal bir şekil üzerinde yeniden çağırır ve sonucu kaydeder.

{{% alert color="warning" title="Warning" %}}
Yer tutucu durumunu kaldırmak, devralınan görünüm ayarlarını otomatik olarak korumaz. Aşağıdaki örnek bu ayarları bilerek değiştirmeden bırakır, bu nedenle çıktı farklı görünebilir. Pozisyon ve boyutu tamamen devralan bir şekil, çağrı sonrası sıfır koordinat ve boyuta sahip olabilir ve koleksiyonda kalmasına rağmen görünmez hâle gelir.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // Normal bir şekil üzerinde yöntemi çağırmak hiçbir etki yapmaz.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

Eşleşen bir yer tutucu için üç kontrol de `True` yazdırır. Metin kalır, ancak devralınan pozisyon, boyut, dönüş, yazı tipi, paragraf hizalaması, metin‑çerçeve kenar boşlukları, dikey sabitleme, doldurma ve kenar ayarları yer tutucu ilişkisi kaldırıldığında değişebilir. Örneğin, devralınan başlık biçimlendirmesi normal metin biçimlendirmesine geri dönebilir. Düzenler hakkında daha fazla bilgi için [Slide Layout](/slides/tr/cpp/slide-layout/) sayfasına bakın.

İstenen görünümü korumak için, çağrıdan önce çözümlenmiş pozisyon, boyut ve dönüş değerlerini yakalayın ve gerekli etkili biçimlendirme değerlerini ayrı değişkenlere kopyalayın. Bu değerleri [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) ve [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) aracılığıyla alın. Yalnızca etkili‑format nesnelerine güvenmeyin; ilişki kaldırıldıktan sonra metin‑biçimlendirme değerleri değişebilir. Yakalanan değerleri daha sonra normal şekle açıkça uygulayın; şablonunuzun kullandığı yazı tipi ailesi, boyutu, stili, rengi, paragraf ayarları, metin‑çerçeve ayarları, doldurma ve kenar ayarlarını da içermelidir.

Devralınan şekil geometrisi, ayrıca [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/) ile açıkça atanmalıdır. Dikdörtgen bir metin yer tutucu için bu, [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) atanması anlamına gelir; yalnızca doldurma ve kenarı geri yüklemek görünür dikdörtgeni sağlamaz. Ek efektlere veya daha karmaşık biçimlendirmelere sahip şablonlar da bu ayarların ayrıca ele alınmasını gerektirir.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış‑başlık, altbaşlık, gövde ve metin yer tutucuları normalde metin destekler. [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) olup olmadığını kontrol edin ve ardından [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) yöntemini kullanın.

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

Bu desen, resim, çizelge, tablo veya medya yer tutucularını [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) olarak dönüştürmekten kaçınır. Ayrıca yer tutucuyu, kırılgan bir şekil indeksine dayanmak yerine amacına göre tanımlar.

## **Düzen Üzerinde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda gösterilen tasarım‑zamanı talimatıdır; örneğin *Click to add title*. Normal bir slaytın şekil koleksiyonundan ulaşmaya çalışmak yerine, düzen yer tutucusu üzerinde özel ipucu metni ayarlayın. Düzeni, [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) aracılığıyla alın ve [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/) üzerinde yineleyin.

Aşağıdaki örnek, ilk slaytın kullandığı düzen üzerindeki başlık ve altbaşlık ipuçlarını değiştirir:

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

İpucu metni normal slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Bir kullanıcı ya da program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucunu değiştirmek, düzeni kullanan slaytlardaki mevcut metni değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

İki durum ele alınmalıdır:

- Resim yer tutucusu zaten doluysa ve bir [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) ile temsil ediliyorsa, resmi [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) ve [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) aracılığıyla değiştirin.
- Hâlâ boş bir yer tutucuysa, yer tutucunun koordinatlarında [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) ile bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Aşağıdaki örnek her iki durumu da destekler ve sunumu kaydeder:

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

Boş bir yer tutucu için oluşturulan değiştirme, yer tutucu ilişkisini artık devralmadığı için yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) yalnızca okunur. Rezerv edilen konumu korur ancak yer tutucu‑özel davranışı kaybolur. Yer tutucu ilişkisi kritikse, önce PowerPoint’te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile oluşan [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) güncelleyin.

Resim şeffaflığı, kırpma ve diğer resim‑özel etkiler için [Manage Picture Frames](/slides/tr/cpp/picture-frame/) sayfasına bakın. Bu işlemler resim çerçevesi veya resim doldurmasıyla ilgilidir, yer tutucu meta verisiyle değil.

## **Çizelge ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir çizelge yer tutucusu bir [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) ile temsil edilebilir. Bu örnek, hem yer tutucu tipine hem de çalışma zamanı arayüzüne göre böyle bir çizelgeyi bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucusu genellikle [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) tipindedir. PowerPoint’te bu, çizelgeler, tablolar, diyagramlar, resimler ve medyalar gibi çeşitli içerik türleri için bir başlatıcı görevi görür. Doldurulduktan sonra, gerçek şekil arayüzünü inceleyerek ne içerdiğini öğrenin. Özelleştirilmiş düzenler ayrıca [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) veya [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) tiplerini ortaya çıkarabilir.

Aspose.Slides, [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) değerini değiştirerek boş bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) yer tutucusunu bir [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) haline getirmez; tip yalnızca okunur. Boş bir çizelge ya da içerik alanını programatik olarak doldurmak için gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bunu bir çizelge için yapar:

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

Eklenen çizelge normal bir yerel çizelgedir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan devralmaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek gerektiğinde ilgili [chart management articles](/slides/tr/cpp/powerpoint-charts/) bölümlerini kullanın.

## **Tam Örnek: Metin ya da Görsel İçeriğini Güncelleme**

Aşağıdaki uçtan‑uza örnek bir şablonu açar, ilk slaytta bir başlık ya da resim yer tutucusunu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksi varsaymak ya da tüm yer tutucuları aynı arayüze dönüştürmekten kaçınır.

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

## **SSS**

**Temel bir yer tutucu nedir?**

Temel yer tutucu, başka bir yer tutucunun devraldığı düzen ya da ana slayttaki karşılık gelen şekildir. Onu almak için [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) kullanın. Normal bir yerel şekil, hiyerarşinin bir parçası olmadığı için `nullptr` döndürür.

**Tüm slayt başlıklarını bir düzen yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir düzen üzerinden devralınan biçimlendirme veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içerikleri normal slaytlarda saklanır. Sunum genelinde gerçek başlık metnini değiştirmek için slaytları döngüyle gezip her başlık yer tutucusunu güncelleyin.

**Tarih, slayt‑numarası, başlık ve altbilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, düzen, ana, not veya dağıtım kapsamındaki başlık ve altbilgi yöneticilerini kullanın. Ayrıntılı örnekler için [Manage Presentation Header and Footer](/slides/tr/cpp/presentation-header-and-footer/) sayfasına bakın.