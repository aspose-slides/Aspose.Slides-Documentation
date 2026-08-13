---
title: 在 C++ 中管理 PowerPoint 簡報的敏感度標籤
linktitle: 敏感度標籤
type: docs
weight: 50
url: /zh-hant/cpp/sensitivity-labels/
keywords:
- 敏感度標籤
- Microsoft Purview
- Microsoft Information Protection
- MIP 中繼資料
- 內容標記
- 資訊保護
- 文件治理
- PowerPoint
- PPTX
- 簡報安全
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 讀取、添加、更新、移除並遷移 PowerPoint PPTX 簡報中的 Microsoft Purview 敏感度標籤。"
---
## **概觀**

Microsoft Purview 敏感度標籤協助組織對文件進行分類與治理。在自動化簡報處理過程中，應用程式可能需要保留現有標籤、套用政策所選擇的標籤、更新其狀態，或遷移由較舊的 Microsoft Information Protection (MIP) 工作流程寫入的標籤中繼資料。

Aspose.Slides 透過[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) 提供現代敏感度標籤中繼資料。此方法會回傳一個[ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabelcollection/)，可在儲存簡報為 PPTX 前檢查與修改。

{{% alert color="info" title="Note" %}}
敏感度標籤識別碼與政策資訊由您的 Microsoft Purview 設定所定義。在新增或遷移中繼資料之前，請先在您的環境中驗證標籤的可用性與政策需求。[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 的值描述與標籤相關的內容標記；它們本身不會在投影片中新增可見的文字或圖形。
{{% /alert %}}

## **了解敏感度標籤屬性**

每個[ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/)包含以下中繼資料：

| 存取子 | 目的 |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/set_id/) | 識別 Purview 政策中的敏感度標籤。 |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/set_siteid/) | 識別與標籤政策相關聯的站台。 |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | 指示此標籤是否已啟用。 |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | 指示此標籤已被移除。當必須在中繼資料中保留移除狀態時，將值設為 `true`。 |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | 指定此標籤是自動套用還是透過使用者決策套用。 |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | 列出與此標籤相關聯的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelassignmenttype/) 列舉描述標籤的指派方式：

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelassignmenttype/) 表示預設或自動套用的標籤。
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelassignmenttype/) 表示透過使用者決策套用的標籤，包括手動套用、建議及強制的標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelcontenttype/) 列舉識別與標籤相關的標記：

| 值 | 意義 |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelcontenttype/) | 此標籤是預設或自動套用的。 |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelcontenttype/) | 此標籤關聯到頁首內容標記。 |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelcontenttype/) | 此標籤關聯到頁尾內容標記。 |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelcontenttype/) | 此標籤關聯到浮水印內容標記。 |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sensitivitylabelcontenttype/) | 此標籤關聯到加密保護。 |

一個標籤可以關聯多種標記類型。

## **列出現有的敏感度標籤**

從[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) 讀取現代標籤集合並列舉它。以下範例列出每個標籤所儲存的所有屬性與內容標記：

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

## **新增具內容標記的敏感度標籤**

使用[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabelcollection/add/) 並提供標籤識別碼、站台識別碼、啟用狀態與指派方法。方法回傳新的[ISensitivityLabel] 後，透過[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 加入所需的標記值。

以下範例新增一個手動選取且關聯頁尾與浮水印標記的標籤，然後將結果儲存為 PPTX：

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

## **更新敏感度標籤**

[ISensitivityLabel] 的值可透過其 getter 與 setter 方法讀寫，唯一例外是[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 回傳的集合須使用其列表操作進行修改。定位到目標標籤後，您可以更新其識別碼、站台識別碼、啟用狀態、指派方法、移除狀態以及內容標記類型。儲存簡報以使變更永久化。

以下範例更新第一個標籤的啟用狀態與指派方法：

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

## **將敏感度標籤標記為已移除**

若要保留標籤已被移除的事實，找到該標籤並以 `true` 呼叫[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/set_isremoved/)。這會保留標籤條目同時記錄其已移除狀態。如果需要從現代集合中刪除條目，請使用[ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabelcollection/removeat/)，或使用[ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabelcollection/clear/) 刪除全部條目。

以下範例將特定標籤標記為已移除並儲存更新後的簡報：

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

## **讀取並遷移舊版 MIP 敏感度標籤**

較舊的基於 MIP 的工作流程可能會將敏感度標籤中繼資料存放在自訂文件屬性中，而非現代標籤集合。可使用[IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) 讀取這些中繼資料。該方法會解析舊版自訂屬性並回傳一個[ISensitivityLabel] 物件陣列。

為了遷移中繼資料，請透過[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabelcollection/add/) 將每個回傳的標籤加入現代[ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabelcollection/)。由於新增重複的標籤識別碼會拋出例外，範例會在複製每個標籤前檢查目標集合。您亦可加入進一步驗證，以確認每個舊版標籤仍在目前的 Purview 政策中。

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

遷移會將已解析的標籤物件複製到現代集合中，無需清除所有自訂文件屬性，因此不相關的文件中繼資料仍保持完整。使用[IPresentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/save/) 搭配[SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/) 即可將現代標籤中繼資料寫入 PPTX 檔案。

## **常見問題**

**新增內容標記類型會在投影片上產生可見的頁首、頁尾或浮水印嗎？**

不會。[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 所新增的值僅描述與敏感度標籤相關的標記。它們不會在簡報中產生可見的文字或圖形。如果您的工作流程必須呈現這些標記，請另行在投影片中加入對應的內容。

**將標籤標記為已移除與從集合中刪除有何差異？**

呼叫[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/set_isremoved/) 並傳入 `true` 會保留標籤條目，同時記錄其已移除的狀態。呼叫[ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabelcollection/removeat/) 則會將條目從現代集合中刪除。依照您組織對中繼資料保留的需求選擇相應的操作。

**簡報可以同時包含舊版 MIP 中繼資料與現代敏感度標籤嗎？**

可以。舊版標籤可以保留在自訂文件屬性中，同時現代標籤則可透過[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) 取得。使用[IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) 讀取舊版中繼資料，並僅遷移那些尚未存在於現代集合中的有效標籤。

**當使用相同識別碼的標籤被多次新增會發生什麼？**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabelcollection/add/) 會在集合已包含相同識別碼的標籤時拋出參數例外。請在新增或遷移標籤前檢查現有的[ISensitivityLabel::get_Id](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isensitivitylabel/get_id/) 值。

**應使用哪種輸出格式才能保留已更新的敏感度標籤？**

如上例所示，使用[IPresentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/save/) 搭配[SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/) 將簡報儲存為 PPTX，即可保留已更新的敏感度標籤。