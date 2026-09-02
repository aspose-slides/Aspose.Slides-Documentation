---
title: 在 PHP 中管理 PowerPoint 簡報的敏感度標籤
linktitle: 敏感度標籤
type: docs
weight: 50
url: /zh-hant/php-java/sensitivity-labels/
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
- PHP
- Aspose.Slides
description: "在 PHP 中讀取、新增、更新、移除並遷移 Microsoft Purview 的敏感度標籤於 PowerPoint PPTX 簡報。"
---
## **概觀**

Microsoft Purview 敏感度標籤協助組織分類與治理文件。在自動化簡報處理期間，應用程式可能需要保留現有標籤、套用政策選取的標籤、更新其狀態，或遷移舊版 Microsoft Information Protection (MIP) 工作流程所寫入的標籤中繼資料。

Aspose.Slides for PHP via Java 透過 [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSensitivityLabels) 透露現代敏感度標籤中繼資料。此方法會傳回一個 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcollection/)，可在簡報儲存為 PPTX 之前檢查與修改。

{{% alert color="primary" title="注意" %}}

敏感度標籤識別碼與政策資訊由您的 Microsoft Purview 設定決定。請先在您的環境中驗證標籤可用性與政策需求，再新增或遷移中繼資料。[SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 的值描述與標籤相關的內容標記；它們本身不會在投影片上新增可見文字或圖形。

{{% /alert %}}

## **了解敏感度標籤屬性**

每個 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/) 包含以下中繼資料：

| 方法 | 目的 |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getId) and [SensitivityLabel::setId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#setId) | 取得或設定 Purview 政策中的敏感度標籤識別碼。 |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getSiteId) and [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#setSiteId) | 取得或設定與標籤政策相關聯的網站。 |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#isEnabled) and [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#setEnabled) | 取得或設定標籤是否已啟用。 |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#isRemoved) and [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#setRemoved) | 取得或設定標籤是否已被移除。當必須在中繼資料中保留移除狀態時，請將值設為 `true`。 |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | 取得或設定標籤是自動套用還是由使用者決策套用。 |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | 取得與標籤相關聯的內容標記類型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelassignmenttype/) 類別定義了標籤的指派方式：

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelassignmenttype/) 代表預設或自動套用的標籤。
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelassignmenttype/) 代表透過使用者決策套用的標籤，包括手動、建議及強制套用的標籤。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcontenttype/) 類別定義了與標籤相關的標記：

| 值 | 含義 |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcontenttype/) | 標籤為預設或自動套用。 |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcontenttype/) | 標題內容標記與此標籤相關聯。 |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcontenttype/) | 頁腳內容標記與此標籤相關聯。 |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcontenttype/) | 水印內容標記與此標籤相關聯。 |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcontenttype/) | 加密保護與此標籤相關聯。 |

多個標記類型可以同時關聯到同一個標籤。

## **列出現有敏感度標籤**

從 [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSensitivityLabels) 讀取現代標籤集合並列舉。以下範例會列出每個標籤所儲存的所有屬性與內容標記：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **新增具內容標記的敏感度標籤**

使用 [SensitivityLabelCollection::add](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcollection/#add)，提供標籤識別碼、網站識別碼、啟用狀態與指派方法。方法回傳新的 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/)，之後透過 [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳的列表加入所需的標記值。

以下範例會新增一個手動選取、同時具頁腳與水印標記的標籤，並將結果儲存為 PPTX：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **更新敏感度標籤**

[SensitivityLabel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/) 的值皆可讀寫，唯一例外是透過其列表操作修改的 [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳的列表。定位到目標標籤後，您可以更新其識別碼、網站識別碼、啟用狀態、指派方法、移除狀態以及內容標記類型。儲存簡報即可永久保存變更。

以下範例會更新第一個標籤的啟用狀態與指派方法：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **將敏感度標籤標記為已移除**

若要保留標籤已被移除的事實，找到該標籤並呼叫 [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#setRemoved) 並傳入 `true`。這會保留標籤條目，同時記錄其已移除狀態。若需從現代集合中刪除條目，請使用 [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcollection/#removeAt)；若要一次刪除全部條目，請使用 [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcollection/#clear)。

以下範例將特定標籤標記為已移除，並儲存更新後的簡報：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **讀取與遷移舊版 MIP 敏感度標籤**

舊的基於 MIP 的工作流程可能會將敏感度標籤中繼資料儲存在自訂文件屬性中，而非現代標籤集合。可使用 [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getSensitivityLabels) 讀取這些中繼資料。此方法會解析舊版自訂屬性，並傳回一個 Java 陣列，內含 [SensitivityLabel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/) 物件。

要遷移中繼資料，請將每個傳回的標籤透過 [SensitivityLabelCollection::add](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcollection/#add) 加入現代的 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcollection/)。因為加入重複的標籤識別碼會拋出例外，範例在複製每個標籤之前會先檢查目標集合。您也可以加入額外驗證，以確認每個舊版標籤仍在目前的 Purview 政策中存在。

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

遷移會將解析出的標籤物件複製到現代集合中，無需清除所有自訂文件屬性，因而不會影響其他文件中繼資料。使用 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 搭配 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/) 即可將現代標籤中繼資料寫入 PPTX 檔案。

## **常見問題與解答**

**加入內容標記類型會在投影片上產生可見的標題、頁腳或水印嗎？**

不會。透過 [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 回傳的列表所加入的值僅描述與敏感度標籤相關的標記，它們不會在簡報中產生可見的文字或圖形。若您的工作流程必須呈現這些標記，需另行在投影片內容中加入相應的標題、頁腳或水印。

**將標籤標記為已移除與從集合中刪除有何差異？**

呼叫 [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#setRemoved) 並傳入 `true` 會保留標籤條目，同時記錄其已移除狀態。呼叫 [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) 則會將條目從現代集合中刪除。請依照組織的中繼資料保留需求選擇適當的操作。

**簡報可以同時包含舊版 MIP 中繼資料與現代敏感度標籤嗎？**

可以。舊版標籤可保留在自訂文件屬性中，而現代標籤則可透過 [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSensitivityLabels) 取得。使用 [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getSensitivityLabels) 讀取舊版中繼資料，並只遷移尚未存在於現代集合中的有效標籤。

**如果多次加入相同識別碼的標籤會發生什麼情況？**

當集合已包含相同識別碼的標籤時，呼叫 [SensitivityLabelCollection::add](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabelcollection/#add) 會拋出例外。加入或遷移標籤前，請先檢查 [SensitivityLabel::getId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sensitivitylabel/#getId) 回傳的現有值。

**應使用哪種輸出格式才能保留已更新的敏感度標籤？**

請以 PPTX 格式儲存簡報，方法是呼叫 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 並傳入 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/)，如前述範例所示。