---
title: C++ ile PowerPoint Sunumlarında Duyarlılık Etiketlerini Yönetme
linktitle: Duyarlılık Etiketleri
type: docs
weight: 50
url: /tr/cpp/sensitivity-labels/
keywords:
- duyarlılık etiketi
- Microsoft Purview
- Microsoft Information Protection
- MIP meta verileri
- içerik işaretleme
- bilgi koruması
- belge yönetimi
- PowerPoint
- PPTX
- sunum güvenliği
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint PPTX sunumlarındaki Microsoft Purview duyarlılık etiketlerini okuyun, ekleyin, güncelleyin, kaldırın ve taşıyın."
---
## **Genel Bakış**

Microsoft Purview duyarlılık etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya daha eski bir Microsoft Information Protection (MIP) iş akışı tarafından yazılmış etiket meta verilerini taşımak zorunda kalabilir.

Aspose.Slides, modern duyarlılık etiketi meta verilerini [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) aracılığıyla sunar. Bu yöntem, sunum PPTX olarak kaydedilmeden önce incelenebilen ve değiştirilebilen bir [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabelcollection/) döndürür.

{{% alert color="info" title="Not" %}}
Duyarlılık etiketi tanımlayıcıları ve politika bilgileri, Microsoft Purview yapılandırmanız tarafından belirlenir. Ortamınızda etiket kullanılabilirliğini ve politika gereksinimlerini doğruladıktan sonra meta verileri ekleyin veya taşıyın. [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) değerleri, bir etiketle ilişkili içerik işaretlemelerini açıklar; bunlar tek başına slaytlara görünür metin veya şekil eklemez.
{{% /alert %}}

## **Duyarlılık Etiketi Özelliklerini Anlayın**

Her [ISensitivityLabel](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/) aşağıdaki meta verilere sahiptir:

| Erişimciler | Amaç |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/set_id/) | Purview politikasındaki duyarlılık etiketini tanımlar. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Etiket politikasına ilişkili siteyi tanımlar. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Etiketin etkin olup olmadığını gösterir. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Etiketin kaldırıldığını gösterir. Kaldırma durumunun meta veride tutulması gerektiğinde değeri `true` olarak ayarlayın. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Etiketin otomatik mi yoksa kullanıcı kararıyla mı uygulandığını belirtir. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Etiketle ilişkili içerik işaretleme türlerini listeler. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelassignmenttype/) sayımı, bir etiketin nasıl atandığını tanımlar:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanmış bir etiketi temsil eder.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelassignmenttype/) kullanıcı kararıyla uygulanan bir etiketi temsil eder; manuel uygulanmış, önerilen ve zorunlu etiketler dahil.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelcontenttype/) sayımı, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan olarak veya otomatik olarak uygulanmıştır. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Üstbilgi içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Altbilgi içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Filigran içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etiketle ilişkilidir. |

Bir etiketle birden fazla işaretleme türü ilişkilendirilebilir.

## **Mevcut Duyarlılık Etiketlerini Listele**

Modern etiket koleksiyonunu [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) üzerinden okuyun ve yineleyin. Aşağıdaki örnek, her etiket için depolanan tüm özellikleri ve içerik işaretlemelerini listeler:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **İçerik İşaretlemesiyle Duyarlılık Etiketi Ekle**

Etiket tanımlayıcısı, site tanımlayıcısı, etkin durum ve atama yöntemi ile [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabelcollection/add/) kullanın. Yöntem yeni bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) aracılığıyla ekleyin.

Aşağıdaki örnek, altbilgi ve filigran işaretlemeleriyle ilişkili, manuel olarak seçilmiş bir etiket ekler ve ardından sonucu PPTX olarak kaydeder:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Duyarlılık Etiketini Güncelle**

[ISensitivityLabel](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/) değerleri, getter ve setter yöntemleri aracılığıyla okuma/yazma yapılabilir; ancak [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) tarafından döndürülen koleksiyon, liste operasyonlarıyla değiştirilir. Gerekli etiketi bulduktan sonra, tanımlayıcısını, site tanımlayıcısını, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcı kılmak için sunumu kaydedin.

Aşağıdaki örnek, ilk etiketin etkin durumunu ve atama yöntemini günceller:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Duyarlılık Etiketini Kaldırıldı Olarak İşaretle**

Bir etiketin kaldırıldığını korumak için etiketi bulup [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/set_isremoved/) yöntemini `true` ile çağırın. Bu, etiket kaydını tutar ve kaldırma durumunu kaydeder. Bunun yerine modern koleksiyondan bir girişi silmeniz gerekiyorsa, [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabelcollection/removeat/) kullanın; tüm girdileri silmek için [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabelcollection/clear/) kullanın.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Eski MIP Duyarlılık Etiketlerini Okuma ve Taşıma**

Eski MIP tabanlı iş akışları, modern etiket koleksiyonu yerine özel belge özelliklerinde duyarlılık etiketi meta verilerini saklayabilir. Bu meta verileri [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) ile okuyun. Yöntem, eski özel özellikleri ayrıştırır ve bir dizi [ISensitivityLabel](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/) nesnesi döndürür.

Meta verileri taşımak için, dönen her etiketi modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabelcollection/) içine [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabelcollection/add/) ile ekleyin. Aynı etiket tanımlayıcısını eklemek istisna oluşturduğundan, örnek her etiketi kopyalamadan önce hedef koleksiyonu kontrol eder. Mevcut Purview politikasında her eski etiketin hâlâ mevcut olduğunu doğrulamak için ek doğrulamalar ekleyebilirsiniz.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Taşıma, ayrıştırılmış etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerini temizlemeye gerek yoktur; böylece alakasız belge meta verileri bozulmaz. Modern etiket meta verilerini bir PPTX dosyasına yazmak için [IPresentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/save/) ile [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) kullanın.

## **SSS**

**Bir içerik işaretleme türü eklemek slaytlarda görünür bir üstbilgi, altbilgi veya filigran oluşturur mu?**

Hayır. [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) üzerinden eklenen değerler, duyarlılık etiketiyle ilişkili işaretlemeleri tanımlar. Bunlar sunumda görünür metin veya şekil oluşturmaz. İş akışınız bu işaretlemeleri görüntülemek zorundaysa, ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırıldı olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/set_isremoved/) yöntemini `true` ile çağırmak, etiket kaydını tutar ve kaldırma durumunu kaydeder. [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabelcollection/removeat/) metodunu çağırmak, modern koleksiyondan girdiyi siler. Organizasyonunuzun meta veri saklama gereksinimlerine uyan işlemi seçin.

**Bir sunum hem eski MIP meta verilerini hem de modern duyarlılık etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken, modern etiketler [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) üzerinden kullanılabilir. Eski meta verileri okumak için [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) kullanın ve modern koleksiyonda zaten bulunmayan geçerli etiketleri taşıyın.

**Aynı tanımlayıcıya sahip bir etiket birden fazla eklendiğinde ne olur?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabelcollection/add/) yöntemi, koleksiyonda aynı tanımlayıcıya sahip bir etiket zaten bulunduğunda bir argüman istisnası fırlatır. Etiket eklemeden veya taşımadan önce mevcut [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isensitivitylabel/get_id/) değerlerini kontrol edin.

**Güncellenmiş duyarlılık etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Yukarıdaki örneklerde gösterildiği gibi, sunumu [IPresentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/save/) ile [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) kullanarak PPTX olarak kaydedin.