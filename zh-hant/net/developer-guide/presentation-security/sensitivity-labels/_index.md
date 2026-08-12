---
title: 在 .NET 中管理 PowerPoint 簡報的敏感度標籤
linktitle: 敏感度標籤
type: docs
weight: 50
url: /zh-hant/net/sensitivity-labels/
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
- 簡報安全性
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 讀取、加入、更新、移除及遷移 PowerPoint PPTX 簡報中的 Microsoft Purview 敏感度標籤。"
---
## **概述**

Microsoft Purview 敏感度標籤協助組織對文件進行分類與治理。在自動化簡報處理過程中，應用程式可能需要保留現有標籤、套用政策所選擇的標籤、更新其狀態，或遷移舊版 Microsoft Information Protection (MIP) 工作流程所寫入的標籤中繼資料。

Aspose.Slides 透過 [Presentation.SensitivityLabels](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sensitivitylabels/) 來公開現代敏感度標籤中繼資料。此屬性會回傳一個 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabelcollection/)，可在簡報儲存為 PPTX 前檢查與修改。

{{% alert color="primary" title="Note" %}}
敏感度標籤識別碼與政策資訊由您的 Microsoft Purview 設定決定。請先在您的環境中驗證標籤可用性與政策需求，然後再新增或遷移中繼資料。[ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/contentmarktypes/) 的值說明與標籤相關的內容標記；它們本身不會在投影片上新增可見文字或圖形。
{{% /alert %}}

## **了解敏感度標籤屬性**

每個 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/) 都包含以下中繼資料：

| 屬性 | 目的 |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/id/) | 在 Purview 政策中識別敏感度標籤。 |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/siteid/) | 識別與標籤政策相關聯的站台。 |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/isenabled/) | 表示該標籤是否啟用。 |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/isremoved/) | 表示該標籤已被移除。當必須在中繼資料中保留移除狀態時，將此屬性設為 `true`。 |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | 指定標籤是自動套用還是由使用者決定套用。 |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/contentmarktypes/) | 列出與標籤相關的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelassignmenttype/) 列舉說明標籤的指派方式：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelassignmenttype/) 代表預設或自動套用的標籤。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelassignmenttype/) 代表透過使用者決策套用的標籤，包括手動套用、建議與強制標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelcontenttype/) 列舉辨識與標籤相關的標記：

| 值 | 含義 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelcontenttype/) | 標籤是預設或自動套用的。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelcontenttype/) | 標籤關聯的頁首內容標記。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelcontenttype/) | 標籤關聯的頁尾內容標記。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelcontenttype/) | 標籤關聯的浮水印內容標記。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sensitivitylabelcontenttype/) | 標籤關聯的加密保護。 |

多種標記類型可以同時關聯於同一標籤。

## **列出現有的敏感度標籤**

從 [Presentation.SensitivityLabels](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sensitivitylabels/) 讀取現代標籤集合並列舉它。以下範例會列出每個標籤的所有屬性與內容標記：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **加入帶內容標記的敏感度標籤**

使用 [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabelcollection/add/)，提供標籤識別碼、站台識別碼、啟用狀態與指派方式。方法回傳新的 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/)，之後透過 [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/contentmarktypes/) 加入必要的標記值。

以下範例新增一個手動選取、同時具備頁尾與浮水印標記的標籤，並將結果儲存為 PPTX：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **更新敏感度標籤**

[ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/) 的屬性皆可讀寫，唯一例外是由 [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/contentmarktypes/) 回傳的集合，需要透過其列表操作進行修改。找到目標標籤後，您可以更新其識別碼、站台識別碼、啟用狀態、指派方式、移除狀態與內容標記類型。最後儲存簡報以永久保存變更。

以下範例更新第一個標籤的啟用狀態與指派方式：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **將敏感度標籤標記為已移除**

若要保留標籤已被移除的事實，找到該標籤並將 [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/isremoved/) 設為 `true`。這會在保留標籤條目同時記錄其移除狀態。如果需要從現代集合中刪除條目，請使用 [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabelcollection/removeat/)；若要一次刪除全部條目，則使用 [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabelcollection/clear/)。

以下範例將特定標籤標記為已移除，並儲存更新後的簡報：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **讀取與遷移舊版 MIP 敏感度標籤**

較舊的基於 MIP 的工作流程可能會將敏感度標籤中繼資料儲存在自訂文件屬性中，而非現代標籤集合。使用 [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/getsensitivitylabels/) 讀取此中繼資料。該方法會解析舊版自訂屬性並回傳一組 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/) 物件。

要遷移這些中繼資料，請透過 [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabelcollection/add/) 將每個回傳的標籤加入現代的 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabelcollection/)。因為加入重複的標籤識別碼會拋出例外，範例會在複製每個標籤前先檢查目標集合。您也可以加入額外驗證，以確認每個舊版標籤仍存在於目前的 Purview 政策中。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

遷移過程會將解析出的標籤物件寫入現代集合。此操作不需要清除所有自訂文件屬性，因此與文件無關的中繼資料會保持完整。使用 [IPresentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/save/) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/)，即可將現代標籤中繼資料寫入 PPTX 檔案。

## **常見問答**

**加入內容標記類型會在投影片上建立可見的頁首、頁尾或浮水印嗎？**

不會。透過 [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/contentmarktypes/) 加入的值僅描述與敏感度標籤相關的標記，它們不會在簡報中產生可見的文字或圖形。若工作流程必須呈現這些標記，需另行加入相對應的投影片內容。

**將標籤標記為已移除與從集合中刪除有何不同？**

將 [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/isremoved/) 設為 `true` 會保留標籤條目並記錄其已移除的狀態。呼叫 [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabelcollection/removeat/) 則會將條目從現代集合中刪除。請依照組織的中繼資料保留需求選擇適當的操作。

**簡報可以同時包含舊版 MIP 中繼資料與現代敏感度標籤嗎？**

可以。舊版標籤可以保留在自訂文件屬性中，而現代標籤則透過 [Presentation.SensitivityLabels](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sensitivitylabels/) 取得。使用 [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/getsensitivitylabels/) 讀取舊版中繼資料，並只遷移尚未存在於現代集合中的有效標籤。

**當相同識別碼的標籤被多次加入會發生什麼情況？**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabelcollection/add/) 會在集合已包含相同識別碼的標籤時拋出 `ArgumentException`。在加入或遷移標籤前，請先檢查現有的 [ISensitivityLabel.Id](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isensitivitylabel/id/) 值。

**應使用哪種輸出格式才能保留已更新的敏感度標籤？**

如前範例所示，使用 [IPresentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/save/) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 將簡報儲存為 PPTX，即可保留更新後的敏感度標籤。