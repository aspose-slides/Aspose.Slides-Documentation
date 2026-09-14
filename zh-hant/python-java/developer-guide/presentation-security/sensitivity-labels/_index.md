---
title: 在 Python 中管理 PowerPoint 簡報的敏感度標籤
linktitle: 敏感度標籤
type: docs
weight: 50
url: /zh-hant/python-java/sensitivity-labels/
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
description: "使用 Aspose.Slides for Python via Java，在 PowerPoint PPTX 簡報中讀取、加入、更新、移除及遷移 Microsoft Purview 敏感度標籤。"
---
## **概述**

Microsoft Purview 敏感度標籤協助組織對文件進行分類與治理。在自動化的簡報處理過程中，應用程式可能需要保留現有標籤、套用政策所選擇的標籤、更新其狀態，或移轉舊版 Microsoft Information Protection (MIP) 工作流程所寫入的標籤資料。

Aspose.Slides 透過 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSensitivityLabels) 釋出現代敏感度標籤資訊。此方法會回傳 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcollection/)，可於儲存為 PPTX 之前檢查並修改。

{{% alert color="info" title="注意" %}}
敏感度標籤識別碼與政策資訊皆由您的 Microsoft Purview 設定決定。請在環境中驗證標籤可用性與政策需求後，再加入或移轉資料。[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 的值描述與標籤相關的內容標記；它們本身不會在投影片上加入可見文字或圖形。
{{% /alert %}}

## **了解敏感度標籤屬性**

每個 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/) 包含以下中繼資料：

| 方法 | 用途 |
| --- | --- |
| [getId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getId) 和 [setId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#setId) | 取得或設定 Purview 政策中的敏感度標籤識別碼。 |
| [getSiteId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getSiteId) 和 [setSiteId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#setSiteId) | 取得或設定與標籤政策相關的站台。 |
| [isEnabled](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#isEnabled) 和 [setEnabled](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#setEnabled) | 取得或設定標籤是否已啟用。 |
| [isRemoved](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#isRemoved) 和 [setRemoved](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#setRemoved) | 取得或設定標籤是否已被移除。若必須在中繼資料中保留移除狀態，請將值設為 `True`。 |
| [getAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) 和 [setAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | 取得或設定標籤是自動套用還是由使用者決策套用。 |
| [getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | 取得與標籤相關的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelassignmenttype/) 類別定義標籤的指派方式：

- [Standard](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelassignmenttype/) 代表預設或自動套用的標籤。
- [Privileged](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelassignmenttype/) 代表透過使用者決策套用的標籤，包括手動套用、建議與強制標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcontenttype/) 類別定義與標籤相關的標記：

| 值 | 說明 |
| --- | --- |
| [None](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcontenttype/) | 標籤為預設或自動套用。 |
| [Header](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcontenttype/) | 標頭內容標記與此標籤相關。 |
| [Footer](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcontenttype/) | 頁腳內容標記與此標籤相關。 |
| [Watermark](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcontenttype/) | 水印內容標記與此標籤相關。 |
| [Encryption](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcontenttype/) | 加密保護與此標籤相關。 |

多種標記類型可同時關聯於同一標籤。

## **列出現有的敏感度標籤**

從 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSensitivityLabels) 讀取現代標籤集合並列舉。下例會列出每個標籤的所有屬性與內容標記：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **新增具有內容標記的敏感度標籤**

使用 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcollection/#add) 並提供標籤識別碼、站台識別碼、啟用狀態與指派方式。方法回傳新的 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/)，之後可透過 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳的清單加入必要的標記值。

下例新增手動選取的標籤，並關聯頁腳與水印標記，最後將結果儲存為 PPTX：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **更新敏感度標籤**

[SensitivityLabel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/) 的屬性皆可讀寫，唯一例外是透過其清單操作來修改 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳的清單。定位到目標標籤後，即可更新其識別碼、站台識別碼、啟用狀態、指派方式、移除狀態以及內容標記類型。儲存簡報以使變更永久化。

下例更新第一個標籤的啟用狀態與指派方式：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **將敏感度標籤標記為已移除**

若需保留標籤已被移除的事實，找到該標籤並以 `True` 呼叫 [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#setRemoved)。這會保留標籤條目，同時記錄其移除狀態。若要從現代集合中刪除條目，請使用 [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcollection/#removeAt)；若要一次清除所有條目，使用 [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcollection/#clear)。

下例將特定標籤標記為已移除，並儲存更新後的簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **讀取並遷移舊版 MIP 敏感度標籤**

舊版基於 MIP 的工作流程可能會將敏感度標籤資料儲存在自訂文件屬性中，而非現代標籤集合。可使用 [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getSensitivityLabels) 讀取該資料。此方法會解析舊版自訂屬性，並回傳一組 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/) 物件。

若要遷移這些資料，請透過 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcollection/#add) 將每個回傳的標籤加入現代 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcollection/)。因為加入重複的標籤識別碼會拋出例外，範例在複製每個標籤之前會先檢查目標集合。您亦可加入額外驗證，以確認每個舊版標籤仍存在於目前的 Purview 政策中。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此遷移將已解析的標籤物件複製到現代集合中，無需清除所有自訂文件屬性，因而保持與文件相關的其他中繼資料完整。使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 可將現代標籤中繼資料寫入 PPTX 檔案。

## **常見問題**

**加入內容標記類型會在投影片上產生可見的標頭、頁腳或水印嗎？**

不會。透過 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳清單加入的值僅描述與敏感度標籤相關的標記，並不會在簡報中產生可見文字或圖形。若工作流程必須呈現這些標記，請另行加入相應的投影片內容。

**將標籤標記為已移除與從集合中刪除有何差別？**

呼叫 [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#setRemoved) 並傳入 `True` 會保留標籤條目，同時記錄其已移除狀態。呼叫 [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) 會將條目從現代集合中刪除。請依照貴組織的中繼資料保存需求選擇適當操作。

**簡報可以同時包含舊版 MIP 中繼資料與現代敏感度標籤嗎？**

可以。舊版標籤可保留在自訂文件屬性中，而現代標籤則可透過 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSensitivityLabels) 取得。使用 [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getSensitivityLabels) 讀取舊版資料，僅遷移尚未存在於現代集合中的有效標籤。

**當同一識別碼的標籤被多次加入時會發生什麼情況？**

當集合已包含相同識別碼的標籤時，[SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabelcollection/#add) 會拋出例外。請在加入或遷移標籤前，使用 [SensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sensitivitylabel/#getId) 檢查現有值。

**應使用哪種輸出格式才能保留已更新的敏感度標籤？**

如前範例所示，使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 將簡報儲存為 PPTX，即可保留更新後的敏感度標籤。