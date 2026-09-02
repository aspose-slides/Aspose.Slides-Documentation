---
title: 在 JavaScript 中管理 PowerPoint 簡報的敏感度標籤
linktitle: 敏感度標籤
type: docs
weight: 50
url: /zh-hant/nodejs-java/sensitivity-labels/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint PPTX 簡報中讀取、加入、更新、移除和遷移 Microsoft Purview 敏感度標籤。"
---
## **概觀**

Microsoft Purview 敏感度標籤可協助組織對文件進行分類和治理。在自動化簡報處理期間，應用程式可能需要保留現有標籤、套用政策所選的標籤、更新其狀態，或遷移舊版 Microsoft Information Protection (MIP) 工作流程所寫入的標籤中繼資料。

Aspose.Slides for Node.js via Java 透過 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) 釋出現代敏感度標籤中繼資料。此方法會傳回一個 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcollection/)，可在簡報儲存為 PPTX 之前檢閱和修改。

{{% alert color="primary" title="Note" %}}
敏感度標籤識別碼與政策資訊由您的 Microsoft Purview 設定定義。在新增或遷移中繼資料之前，請先在環境中驗證標籤的可用性與政策需求。[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 值描述與標籤相關的內容標記；它們本身不會在投影片上加入可見的文字或圖形。
{{% /alert %}}

## **了解敏感度標籤屬性**

每個 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/) 都包含以下中繼資料：

| 方法 | 目的 |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getId) and [SensitivityLabel.setId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#setId) | 取得或設定 Purview 政策中的敏感度標籤識別碼。 |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) and [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | 取得或設定與標籤政策關聯的網站。 |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) and [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | 取得或設定標籤是否已啟用。 |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) and [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | 取得或設定標籤是否已被移除。當必須在中繼資料中保留移除狀態時，將值設為 `true`。 |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | 取得或設定標籤是自動套用還是透過使用者決策套用。 |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | 取得與標籤相關聯的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) 類別定義了標籤的分配方式：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) 代表預設或自動套用的標籤。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) 代表透過使用者決策套用的標籤，包括手動套用、建議性以及強制性標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) 類別定義了與標籤相關聯的標記：

| 值 | 意義 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 標籤是預設或自動套用的。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 頁首內容標記與標籤相關聯。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 頁尾內容標記與標籤相關聯。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 浮水印內容標記與標籤相關聯。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 加密保護與標籤相關聯。 |

一個標籤可以關聯多種標記類型。

## **列舉現有敏感度標籤**

從 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) 讀取現代標籤集合並列舉它。以下範例列出每個標籤所儲存的所有屬性與內容標記：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **加入帶內容標記的敏感度標籤**

使用 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) 並提供標籤識別碼、網站識別碼、啟用狀態與分配方式。方法傳回新的 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/) 後，透過 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳的清單加入所需的標記值。

以下範例加入一個手動選取且與頁尾與浮水印標記相關聯的標籤，然後將結果儲存為 PPTX：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **更新敏感度標籤**

[SensitivityLabel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/) 的值皆可讀寫，唯一例外是透過其清單操作修改由 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳的清單。找到目標標籤後，您可以更新其識別碼、網站識別碼、啟用狀態、分配方式、移除狀態與內容標記類型。儲存簡報以使變更永久化。

以下範例更新第一個標籤的啟用狀態與分配方式：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將敏感度標籤標記為已移除**

若要保留標籤已被移除的事實，請找到該標籤並以 `true` 呼叫 [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved)。這會保留標籤項目同時記錄其移除狀態。若您需要從現代集合中刪除項目，請使用 [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt)；若要刪除所有項目，使用 [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear)。

以下範例將特定標籤標記為已移除，並儲存更新後的簡報：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **讀取與遷移舊版 MIP 敏感度標籤**

舊版基於 MIP 的工作流程可能會將敏感度標籤中繼資料儲存在自訂文件屬性中，而非現代標籤集合。可使用 [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) 讀取該中繼資料。此方法會解析舊版自訂屬性並回傳 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/) 物件的陣列。

若要遷移中繼資料，請透過 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) 將每個回傳的標籤加入現代的 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcollection/)。由於加入重複的標籤識別碼會拋出例外，範例在複製每個標籤前會先檢查目標集合。您可以加入進一步的驗證，以確認每個舊版標籤仍在目前的 Purview 政策中。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

遷移會將解析出的標籤物件複製到現代集合中。此過程不需要清除所有自訂文件屬性，因而不相關的文件中繼資料保持不變。使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 將現代標籤中繼資料寫入 PPTX 檔案。

## **常見問題**

**加入內容標記類型會在投影片上產生可見的頁首、頁尾或浮水印嗎？**

不會。透過 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳的清單加入的值僅描述與敏感度標籤相關的標記。它們不會在簡報中產生可見的文字或圖形。若您的工作流程必須呈現這些標記，請另行加入相應的投影片內容。

**將標籤標記為已移除與從集合中刪除其有何差異？**

以 `true` 呼叫 [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) 會保留標籤項目並記錄其移除狀態。呼叫 [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) 則會從現代集合中刪除該項目。請依照組織的中繼資料保留需求選擇適當的操作。

**簡報可以同時包含舊版 MIP 中繼資料與現代敏感度標籤嗎？**

可以。舊版標籤可保留在自訂文件屬性中，而現代標籤則可透過 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) 取得。使用 [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) 讀取舊版中繼資料，僅遷移尚未出現在現代集合中的有效標籤。

**當相同識別碼的標籤被多次加入時會發生什麼？**

當集合已包含相同識別碼的標籤時，[SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) 會拋出例外。加入或遷移標籤前，請先檢查由 [SensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sensitivitylabel/#getId) 回傳的現有值。

**應使用哪種輸出格式才能保留已更新的敏感度標籤？**

如上例所示，使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 並搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 以 PPTX 格式儲存簡報，即可保留已更新的敏感度標籤。