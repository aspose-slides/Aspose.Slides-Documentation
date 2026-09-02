---
title: 在 Android 上管理 PowerPoint 簡報的敏感性標籤
linktitle: 敏感性標籤
type: docs
weight: 50
url: /zh-hant/androidjava/sensitivity-labels/
keywords:
- 敏感性標籤
- Microsoft Purview
- Microsoft Information Protection
- MIP 中繼資料
- 內容標記
- 資訊保護
- 文件治理
- PowerPoint
- PPTX
- 簡報安全性
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 讀取、加入、更新、移除及遷移 PowerPoint PPTX 簡報中的 Microsoft Purview 敏感性標籤。"
---
## **概述**

Microsoft Purview 敏感性標籤協助組織對文件進行分類與治理。在自動化簡報處理過程中，應用程式可能需要保留現有標籤、套用政策選擇的標籤、更新其狀態，或遷移由較舊的 Microsoft Information Protection (MIP) 工作流程寫入的標籤中繼資料。

Aspose.Slides for Android via Java 透過 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) 公开現代敏感標籤中繼資料。此方法會傳回一個 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/)，可於將簡報另存為 PPTX 前檢查與修改。

{{% alert color="primary" title="注意" %}}

敏感標籤識別碼與政策資訊由您的 Microsoft Purview 設定所定義。在新增或遷移中繼資料之前，請先於您的環境中驗證標籤的可用性與政策需求。[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 的值說明了與標籤相關聯的內容標記；它們本身不會在投影片上加入可見的文字或圖形。

{{% /alert %}}

## **了解敏感標籤屬性**

每個 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/) 包含以下中繼資料：

| 方法 | 用途 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | 取得或設定 Purview 政策中的敏感標籤識別碼。 |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | 取得或設定與標籤政策相關聯的網站。 |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | 取得或設定標籤是否已啟用。 |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | 取得或設定標籤是否已被移除。若必須在中繼資料中保留移除狀態，請將值設為 `true`。 |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | 取得或設定標籤是自動套用還是由使用者決策套用。 |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | 取得與標籤相關聯的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) 類別定義了標籤的指派方式：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) 代表預設或自動套用的標籤。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) 代表透過使用者決策套用的標籤，包括手動套用、建議及必須的標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) 類別定義了與標籤相關的標記：

| 值 | 意義 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 標籤是預設或自動套用的。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 與標籤相關聯的標頭內容標記。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 與標籤相關聯的頁腳內容標記。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 與標籤相關聯的浮水印內容標記。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 與標籤相關聯的加密保護。 |

一個標籤可以關聯多種標記類型。

## **列出現有敏感標籤**

從 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) 讀取現代標籤集合並列舉。以下範例列出每個標籤所儲存的所有屬性與內容標記：

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

## **加入具有內容標記的敏感標籤**

使用 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) 並提供標籤識別碼、網站識別碼、啟用狀態以及指派方式。方法返回新的 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/) 後，透過 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單加入必要的標記值。

以下範例加入一個手動選取的標籤，並關聯頁腳與浮水印標記，然後將結果另存為 PPTX：

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

## **更新敏感標籤**

[ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/) 的值皆可讀寫，唯一需透過其清單操作來修改由 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單。定位到所需標籤後，您可以更新其識別碼、網站識別碼、啟用狀態、指派方式、移除狀態以及內容標記類型。儲存簡報以使變更永久化。

以下範例更新第一個標籤的啟用狀態與指派方式：

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

## **將敏感標籤標記為已移除**

若要保留標籤已被移除的事實，請找到該標籤並以 `true` 呼叫 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-)。此操作會保留標籤條目並記錄其移除狀態。若需從現代集合中刪除條目，請使用 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-)；若要刪除所有條目，請使用 [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--)。

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

## **讀取與遷移舊版 MIP 敏感標籤**

較舊的基於 MIP 的工作流程可能會將敏感標籤中繼資料儲存在自訂文件屬性中，而非現代標籤集合。可使用 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) 讀取該中繼資料。此方法會解析舊版自訂屬性並回傳 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/) 物件的陣列。

若要遷移中繼資料，請透過 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) 將每個返回的標籤加入現代的 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/)。由於加入重複的標籤識別碼會拋出例外，範例在複製每個標籤前會檢查目標集合。您亦可加入進一步驗證，以確認每個舊版標籤仍存在於目前的 Purview 政策中。

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

遷移會將解析出的標籤物件複製到現代集合中。此過程不需要清除所有自訂文件屬性，因而不相關的文件中繼資料保持完整。使用 [IPresentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/) 將現代標籤中繼資料寫入 PPTX 檔案。

## **FAQ**

**加入內容標記類型會在投影片上產生可見的標頭、頁腳或浮水印嗎？**

不會。透過 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單加入的值僅說明與敏感標籤相關的標記，並不會在簡報中產生可見的文字或圖形。如果您的工作流程必須呈現這些標記，請另行在投影片內容中加入相應的元素。

**將標籤標記為已移除與從集合中刪除有何差異？**

呼叫 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) 並傳入 `true` 會保留標籤條目，同時記錄其已移除的狀態。呼叫 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) 會將條目從現代集合中刪除。請依照貴組織的中繼資料保留需求選擇相應的操作。

**簡報可以同時包含舊版 MIP 中繼資料與現代敏感標籤嗎？**

可以。舊版標籤可以保留在自訂文件屬性中，而現代標籤則可透過 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) 取得。使用 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) 讀取舊版中繼資料，僅遷移尚未出現在現代集合中的有效標籤。

**當同一識別碼的標籤被多次加入時會發生什麼情況？**

當集合已包含相同識別碼的標籤時，呼叫 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) 會拋出例外。加入或遷移標籤前，請先檢查由 [ISensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getId--) 回傳的現有值。

**應使用哪種輸出格式才能保留已更新的敏感標籤？**

請使用 [IPresentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/) 將簡報儲存為 PPTX，正如上述範例所示。