---
title: 在 Android 上管理 PowerPoint 簡報的敏感度標籤
linktitle: 敏感度標籤
type: docs
weight: 50
url: /zh-hant/androidjava/sensitivity-labels/
keywords:
- 敏感度標籤
- Microsoft Purview
- Microsoft 信息保護
- MIP 中繼資料
- 內容標記
- 資訊保護
- 文件治理
- PowerPoint
- PPTX
- 簡報安全
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 讀取、新增、更新、移除及遷移 PowerPoint PPTX 簡報中的 Microsoft Purview 敏感度標籤。"
---
## **概觀**

Microsoft Purview 敏感度標籤可協助組織對文件進行分類與治理。在自動化簡報處理過程中，應用程式可能需要保留現有標籤、套用政策所選擇的標籤、更新其狀態，或遷移由舊版 Microsoft Information Protection (MIP) 工作流程所寫入的標籤中繼資料。

Aspose.Slides for Android via Java 透過 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) 提供現代敏感度標籤中繼資料。此方法會傳回一個 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/)，可在簡報儲存為 PPTX 之前檢查並修改。

{{% alert color="info" title="Note" %}}
敏感度標籤識別碼與政策資訊由您的 Microsoft Purview 設定定義。在加入或遷移中繼資料之前，請先在您的環境中驗證標籤的可用性與政策需求。[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 的值描述與標籤相關的內容標記；它們本身不會在投影片中加入可見的文字或圖形。
{{% /alert %}}

## **了解敏感度標籤屬性**

每個 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/) 包含以下中繼資料：

| 方法 | 目的 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getId--)和[ISensitivityLabel.setId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | 取得或設定 Purview 政策中的敏感度標籤識別碼。 |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--)和[ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | 取得或設定與標籤政策關聯的站台。 |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--)和[ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | 取得或設定標籤是否已啟用。 |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--)和[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | 取得或設定標籤是否已被移除。當必須在中繼資料中保留移除狀態時，將值設為 `true`。 |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--)和[ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | 取得或設定標籤是自動套用還是透過使用者決策套用。 |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | 取得與標籤相關的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) 類別定義標籤的指派方式：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) 表示預設或自動套用的標籤。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) 表示透過使用者決策套用的標籤，包括手動套用、建議及強制標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) 類別定義與標籤相關的標記：

| 值 | 含義 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 標籤以預設或自動方式套用。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 標籤關聯的頁首內容標記。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 標籤關聯的頁尾內容標記。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 標籤關聯的浮水印內容標記。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 標籤關聯的加密保護。 |

一個標籤可以關聯多種標記類型。

## **列出現有的敏感度標籤**

從 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) 讀取現代標籤集合並列舉。以下範例列出每個標籤儲存的所有屬性與內容標記：

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

使用 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) 並提供標籤識別碼、站台識別碼、啟用狀態與指派方式。方法回傳新的 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/)，後，透過 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單加入所需的標記值。

以下範例新增一個手動選取、關聯頁尾與浮水印標記的標籤，並將結果儲存為 PPTX：

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

[ISensitivityLabel] 的值可讀寫，唯一例外是透過其清單操作修改由 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單。定位到目標標籤後，您可以更新其識別碼、站台識別碼、啟用狀態、指派方式、移除狀態與內容標記類型。儲存簡報以持續變更。

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

## **將敏感度標籤標記為已移除**

若要保留標籤已被移除的事實，請找到該標籤並以 `true` 呼叫 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-)。這會保留標籤項目，同時記錄其移除狀態。若需從現代集合中刪除項目，請使用 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-)；如需刪除所有項目，使用 [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--)。

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

## **讀取與遷移舊版 MIP 敏感度標籤**

舊版基於 MIP 的工作流程可能會將敏感度標籤中繼資料存放於自訂文件屬性，而非現代標籤集合。可使用 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) 讀取該中繼資料。此方法會解析舊版自訂屬性，並傳回 [ISensitivityLabel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/) 物件陣列。

若要遷移中繼資料，請透過 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) 將每個回傳的標籤加入現代 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/)。由於加入重複的標籤識別碼會拋出例外，範例會在複製每個標籤前檢查目標集合。您亦可加入進一步驗證，以確認每個舊版標籤仍存在於目前的 Purview 政策中。

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

遷移會將解析出的標籤物件複製到現代集合中。此過程不需要清除所有自訂文件屬性，因此與此無關的文件中繼資料仍會保留。使用 [IPresentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/) 將現代標籤中繼資料寫入 PPTX 檔案。

## **常見問題**

**加入內容標記類型會在投影片上產生可見的頁首、頁尾或浮水印嗎？**

不會。透過 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 回傳的清單所加入的值僅描述與敏感度標籤相關的標記，並不會在簡報中產生可見的文字或圖形。若您的工作流程必須呈現這些標記，請另行加入相應的投影片內容。

**將標籤標記為已移除與從集合中刪除有何不同？**

以 `true` 呼叫 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) 會保留標籤項目並記錄其移除狀態。呼叫 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) 會從現代集合中刪除該項目。請依據貴組織的中繼資料保留需求選擇相應的操作。

**簡報能同時包含舊版 MIP 中繼資料與現代敏感度標籤嗎？**

可以。舊版標籤可保留於自訂文件屬性中，而現代標籤則可透過 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) 取得。使用 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) 讀取舊版中繼資料，僅遷移尚未出現在現代集合中的有效標籤。

**當相同識別碼的標籤被多次加入時會發生什麼情況？**

若集合已包含相同識別碼的標籤，[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) 會拋出例外。在加入或遷移標籤前，請先檢查 [ISensitivityLabel.getId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isensitivitylabel/#getId--) 所回傳的現有值。

**應使用哪種輸出格式才能保留已更新的敏感度標籤？**

如上述範例所示，使用 [IPresentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/) 將簡報儲存為 PPTX，即可保留已更新的敏感度標籤。