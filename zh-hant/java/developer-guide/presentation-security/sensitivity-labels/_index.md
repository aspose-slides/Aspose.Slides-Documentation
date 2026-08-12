---
title: 在 Java 中管理 PowerPoint 簡報的敏感度標籤
linktitle: 敏感度標籤
type: docs
weight: 50
url: /zh-hant/java/sensitivity-labels/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 讀取、新增、更新、移除及遷移 PowerPoint PPTX 簡報中的 Microsoft Purview 敏感度標籤。"
---
## **概述**

Microsoft Purview 敏感度標籤協助組織對文件進行分類與治理。在自動化簡報處理期間，應用程式可能需要保留現有標籤、套用政策所選的標籤、更新其狀態，或遷移由較舊的 Microsoft Information Protection (MIP) 工作流程寫入的標籤中繼資料。

Aspose.Slides 透過 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) 讓使用者存取現代敏感度標籤的中繼資料。此方法回傳一個 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabelcollection/)，可在簡報儲存為 PPTX 之前檢查與修改。

{{% alert color="primary" title="Note" %}}
Sensitivity label identifiers and policy information are defined by your Microsoft Purview configuration. Validate label availability and policy requirements in your environment before adding or migrating metadata. The [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) values describe the content markings associated with a label; they do not by themselves add visible text or shapes to slides.
{{% /alert %}}

## **了解敏感度標籤屬性**

每個 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/) 包含以下中繼資料：

| 方法 | 目的 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | 取得或設定 Purview 政策中的敏感度標籤識別碼。 |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | 取得或設定與標籤政策關聯的網站。 |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | 取得或設定標籤是否已啟用。 |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | 取得或設定標籤是否已被移除。當必須在中繼資料中保留移除狀態時，將值設為 `true`。 |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | 取得或設定標籤是自動套用還是透過使用者決策套用。 |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | 取得與該標籤關聯的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelassignmenttype/) 類別定義了標籤的指派方式：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelassignmenttype/) 代表預設或自動套用的標籤。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelassignmenttype/) 代表透過使用者決策套用的標籤，包括手動套用、建議與強制性標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelcontenttype/) 類別定義了與標籤相關的標記：

| 值 | 意義 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelcontenttype/) | 標籤以預設或自動方式套用。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelcontenttype/) | 與標籤關聯的內容標記為標題。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelcontenttype/) | 與標籤關聯的內容標記為頁尾。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelcontenttype/) | 與標籤關聯的內容標記為浮水印。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sensitivitylabelcontenttype/) | 與標籤關聯的內容標記為加密保護。 |

一個標籤可以關聯多種標記類型。

## **列出現有的敏感度標籤**

從 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) 讀取現代標籤集合並列舉它。以下範例會列出每個標籤所儲存的所有屬性與內容標記：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **新增具內容標記的敏感度標籤**

使用 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) 搭配標籤識別碼、網站識別碼、啟用狀態與指派方法。方法回傳新的 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/) 後，透過 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單加入所需的標記值。

以下範例新增一個手動選取、且關聯頁尾與浮水印標記的標籤，然後將結果儲存為 PPTX：

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **更新敏感度標籤**

[ISensitivityLabel] 的值皆可讀寫，唯一例外是透過 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單，需使用其清單操作進行修改。找到目標標籤後，您可以更新其識別碼、網站識別碼、啟用狀態、指派方法、移除狀態以及內容標記類型。儲存簡報以使變更永久化。

以下範例更新第一個標籤的啟用狀態與指派方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將敏感度標籤標記為已移除**

若要保留標籤已被移除的事實，請找出該標籤並以 `true` 呼叫 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-)。這會保留標籤項目，同時記錄其移除狀態。如需從現代集合中刪除項目，請使用 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-)；如要刪除所有項目，請使用 [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabelcollection/#clear--)。

以下範例將特定標籤標記為已移除，並儲存更新後的簡報：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **讀取與遷移傳統 MIP 敏感度標籤**

較舊的基於 MIP 的工作流程可能會將敏感度標籤中繼資料存放於自訂文件屬性中，而非現代標籤集合。可使用 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) 讀取該中繼資料。此方法會解析傳統的自訂屬性，並回傳一個 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/) 物件陣列。

若要遷移中繼資料，請透過 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) 將每個回傳的標籤加入現代 [ISensitivityLabelCollection]。由於加入重複的標籤識別碼會拋出例外，範例在複製每個標籤前會先檢查目標集合。您亦可加入額外的驗證，以確認每個傳統標籤仍在目前的 Purview 政策中。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

遷移會將已解析的標籤物件複製到現代集合中。此過程不需要清除所有自訂文件屬性，因此與此無關的文件中繼資料會保持完整。使用 [IPresentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 可將現代標籤中繼資料寫入 PPTX 檔案。

## **FAQ**

**新增內容標記類型會在投影片上產生可見的標頭、頁尾或浮水印嗎？**

不會。透過 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單所新增的值僅說明與敏感度標籤關聯的標記，它們不會在簡報中產生可見的文字或圖形。如果您的工作流程必須呈現這些標記，請另外加入相應的投影片內容。

**將標籤標記為已移除與從集合中刪除之間有何差異？**

呼叫 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) 並傳入 `true` 會保留標籤項目，同時記錄其已移除的狀態。呼叫 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) 則會將該項目從現代集合中刪除。請依組織的中繼資料保留需求選擇相應的操作。

**簡報可以同時包含傳統 MIP 中繼資料與現代敏感度標籤嗎？**

可以。傳統標籤可以保留在自訂文件屬性中，而現代標籤則可透過 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) 取得。使用 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) 讀取傳統中繼資料，並僅遷移尚未存在於現代集合中的有效標籤。

**當多次新增具有相同識別碼的標籤時會發生什麼情況？**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) 會在集合已包含相同識別碼的標籤時拋出例外。於新增或遷移標籤前，請先檢查 [ISensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isensitivitylabel/#getId--) 回傳的現有值。

**應使用哪種輸出格式才能保留更新後的敏感度標籤？**

如上述範例所示，請使用 [IPresentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/)，將簡報儲存為 PPTX，以保留已更新的敏感度標籤。