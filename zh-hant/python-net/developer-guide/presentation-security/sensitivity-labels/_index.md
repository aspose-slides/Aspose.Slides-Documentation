---
title: 在 Python 中管理 PowerPoint 簡報的敏感度標籤
linktitle: 敏感度標籤
type: docs
weight: 50
url: /zh-hant/python-net/sensitivity-labels/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 讀取、新增、更新、移除及遷移 PowerPoint PPTX 簡報中的 Microsoft Purview 敏感度標籤。"
---
## **概觀**

Microsoft Purview 敏感度標籤協助組織對文件進行分類與治理。在自動化的簡報處理過程中，應用程式可能需要保留現有標籤、套用政策所選擇的標籤、更新其狀態，或是遷移舊版 Microsoft Information Protection（MIP）工作流程所寫入的標籤中繼資料。

Aspose.Slides for Python via .NET 透過 [Presentation.sensitivity_labels](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/sensitivity_labels/) 公开現代的敏感度標籤中繼資料。此屬性會回傳一個 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcollection/)，您可在儲存為 PPTX 之前檢查與修改它。

{{% alert color="primary" title="注意" %}}

敏感度標籤識別碼與政策資訊由您的 Microsoft Purview 組態定義。在加入或遷移中繼資料之前，請先在您的環境中驗證標籤的可用性與政策需求。[SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/content_mark_types/) 的值描述與標籤關聯的內容標記；它們本身不會在投影片上新增可見的文字或圖形。

{{% /alert %}}

## **了解敏感度標籤屬性**

每個 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/) 包含以下中繼資料：

| Property | Purpose |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/id/) | 識別 Purview 政策中的敏感度標籤。 |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/site_id/) | 識別與標籤政策關聯的站台。 |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/is_enabled/) | 指示此標籤是否已啟用。 |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/is_removed/) | 指示此標籤已被移除。當必須在中繼資料中保留移除狀態時，將此屬性設為 `True`。 |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | 指定此標籤是自動套用還是使用者決策套用。 |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | 列出與此標籤關聯的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelassignmenttype/) 列舉說明了標籤的指派方式：

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelassignmenttype/) 代表預設或自動套用的標籤。  
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelassignmenttype/) 代表透過使用者決策套用的標籤，包含手動套用、建議與強制標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcontenttype/) 列舉識別與標籤關聯的標記：

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcontenttype/) | 標籤以預設或自動方式套用。 |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcontenttype/) | 與標籤關聯的頁首內容標記。 |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcontenttype/) | 與標籤關聯的頁尾內容標記。 |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcontenttype/) | 與標籤關聯的浮水印內容標記。 |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcontenttype/) | 與標籤關聯的加密保護。 |

一個標籤可以同時關聯多種標記類型。

## **列出現有的敏感度標籤**

從 [Presentation.sensitivity_labels](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/sensitivity_labels/) 讀取現代標籤集合並將其列舉。以下範例會列出每個標籤的所有屬性與內容標記：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **新增具內容標記的敏感度標籤**

使用 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcollection/add/)，傳入標籤識別碼、站台識別碼、啟用狀態與指派方法。站台識別碼應以 Python `uuid.UUID` 物件傳遞。方法回傳新的 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/)，之後把必要的標記值加入 [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/content_mark_types/)。

以下範例新增一個手動選取、同時具頁尾與浮水印標記的標籤，並將結果儲存為 PPTX：

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **更新敏感度標籤**

[SensitivityLabel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/) 的屬性皆為可讀寫，唯獨 [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/content_mark_types/) 回傳的清單需透過清單操作進行變更。定位到目標標籤後，您可以更新其識別碼、站台識別碼、啟用狀態、指派方法、移除狀態與內容標記類型。完成後儲存簡報以寫入變更。

以下範例更新第一個標籤的啟用狀態與指派方法：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **將敏感度標籤標記為已移除**

若需保留標籤已被移除的事實，找到該標籤並將 [SensitivityLabel.is_removed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/is_removed/) 設為 `True`。這樣可以在保留條目之餘記錄其移除狀態。若想從現代集合中刪除條目，請使用 [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcollection/remove_at/)；若要一次刪除所有條目，使用 [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcollection/clear/)。

以下範例將特定標籤標記為已移除，並儲存更新後的簡報：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **讀取與遷移舊版 MIP 敏感度標籤**

舊版基於 MIP 的工作流程可能會將敏感度標籤中繼資料儲存在自訂文件屬性，而非現代標籤集合。可使用 [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) 讀取該中繼資料。此方法會解析舊版自訂屬性，並回傳 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/) 物件。

要遷移這些中繼資料，請透過 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcollection/add/) 將每個回傳的標籤加入現代的 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcollection/)。因為加入重複的標籤識別碼會拋出例外，範例在複製每個標籤前先檢查目標集合。您也可以加入進一步的驗證，以確認每個舊版標籤仍存在於目前的 Purview 政策中。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

遷移會將已解析的標籤物件寫入現代集合。此過程不需要清除所有自訂文件屬性，因此與標籤無關的文件中繼資料會保持完整。使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 搭配 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)，即可將現代標籤中繼資料寫入 PPTX 檔案。

## **常見問題**

**加入內容標記類型會在投影片上產生可見的頁首、頁尾或浮水印嗎？**

不會。透過 [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/content_mark_types/) 加入的值僅說明與敏感度標籤關聯的標記，它們不會在簡報中產生可見的文字或圖形。如果您的工作流程必須呈現這些標記，請自行在投影片內容中加入相應的元素。

**將標籤標記為已移除與從集合中刪除有何不同？**

將 [SensitivityLabel.is_removed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/is_removed/) 設為 `True` 會保留標籤條目，並記錄其已移除的狀態。呼叫 [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) 則會將條目從現代集合中移除。請依照貴組織的中繼資料保留需求選擇相應的操作。

**簡報可以同時包含舊版 MIP 中繼資料與現代敏感度標籤嗎？**

可以。舊版標籤可保留在自訂文件屬性中，而現代標籤則透過 [Presentation.sensitivity_labels](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/sensitivity_labels/) 取得。使用 [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) 讀取舊版中繼資料，僅遷移尚未出現在現代集合中的有效標籤。

**當相同識別碼的標籤被多次加入時會發生什麼？**

當集合已包含相同識別碼的標籤時，[SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabelcollection/add/) 會拋出例外。請在加入或遷移標籤之前，先檢查現有的 [SensitivityLabel.id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sensitivitylabel/id/) 值。

**應使用哪種輸出格式才能保留更新後的敏感度標籤？**

請以 PPTX 格式儲存簡報，方法是呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 並傳入 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)，如前述範例所示。