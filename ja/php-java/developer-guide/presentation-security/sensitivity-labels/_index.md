---
title: PHPでPowerPointプレゼンテーションの機密ラベルを管理する
linktitle: 機密ラベル
type: docs
weight: 50
url: /ja/php-java/sensitivity-labels/
keywords:
- 機密ラベル
- Microsoft Purview
- Microsoft Information Protection
- MIP メタデータ
- コンテンツマーキング
- 情報保護
- ドキュメント ガバナンス
- PowerPoint
- PPTX
- プレゼンテーション セキュリティ
- PHP
- Aspose.Slides
description: "PHPでPowerPoint PPTXプレゼンテーションのMicrosoft Purview機密ラベルを読み取り、追加、更新、削除、移行します。"
---
## **概要**

Microsoft Purview の機密ラベルは、組織がドキュメントを分類および管理するのに役立ちます。自動化されたプレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベルメタデータを移行したりする必要がある場合があります。

Aspose.Slides for PHP via Java は、[Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSensitivityLabels) を通じて最新の機密ラベルメタデータを公開します。このメソッドは、保存前に検査および変更できる [SensitivityLabelCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcollection/) を返します。

{{% alert color="primary" title="Note" %}}
機密ラベル識別子およびポリシー情報は、Microsoft Purview の設定で定義されます。メタデータを追加または移行する前に、環境内でラベルの利用可能性とポリシー要件を検証してください。[SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) の値はラベルに関連付けられたコンテンツマーキングを記述しますが、スライドに目に見えるテキストや図形を自動的に追加するものではありません。
{{% /alert %}}

## **機密ラベル プロパティの理解**

各 [SensitivityLabel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/) には、次のメタデータが含まれます。

| メソッド | 用途 |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getId) と [SensitivityLabel::setId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#setId) | Purview ポリシー内の機密ラベル識別子を取得または設定します。 |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getSiteId) と [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#setSiteId) | ラベル ポリシーに関連付けられたサイトを取得または設定します。 |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#isEnabled) と [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#setEnabled) | ラベルが有効かどうかを取得または設定します。 |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#isRemoved) と [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#setRemoved) | ラベルが削除されたかどうかを取得または設定します。メタデータに削除状態を保持する必要がある場合は、値を `true` に設定します。 |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) と [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | ラベルが自動的に適用されたか、ユーザーの判断によって適用されたかを取得または設定します。 |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | ラベルに関連付けられたコンテンツマーキングの種類を取得します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelassignmenttype/) クラスは、ラベルの割り当て方法を定義します。

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelassignmenttype/) は、既定または自動的に適用されたラベルを表します。
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelassignmenttype/) は、ユーザーの判断によって適用されたラベルを表し、手動適用、推奨、必須ラベルを含みます。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcontenttype/) クラスは、ラベルに関連付けられるマーキングを定義します。

| 値 | 意味 |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcontenttype/) | ラベルは既定または自動的に適用されました。 |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcontenttype/) | ラベルにはヘッダー コンテンツ マーキングが関連付けられています。 |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcontenttype/) | ラベルにはフッター コンテンツ マーキングが関連付けられています。 |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcontenttype/) | ラベルには透かし コンテンツ マーキングが関連付けられています。 |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcontenttype/) | ラベルには暗号化保護が関連付けられています。 |

複数のマーキングタイプを1つのラベルに関連付けることができます。

## **既存の機密ラベルの一覧表示**

[Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSensitivityLabels) から最新のラベルコレクションを読み取り、列挙します。以下の例は、各ラベルに保存されているすべてのプロパティとコンテンツマーキングを一覧表示します。

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

## **コンテンツマーキング付き機密ラベルの追加**

ラベル識別子、サイト識別子、 有効状態、割り当て方法を指定して [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcollection/#add) を使用します。メソッドが新しい [SensitivityLabel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/) を返したら、[SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストを通じて必要なマーキング値を追加します。

以下の例は、フッターと透かしのマーキングが関連付けられた手動選択ラベルを追加し、結果を PPTX として保存します。

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

## **機密ラベルの更新**

[SensitivityLabel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/) の値は読み書き可能ですが、[SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストはそのリスト操作を通じて変更します。必要なラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツマーキングタイプを更新できます。変更を永続化するためにプレゼンテーションを保存してください。

以下の例は、最初のラベルの有効状態と割り当て方法を更新します。

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

## **機密ラベルを削除済みとしてマークする**

ラベルが削除された事実を保持するために、ラベルを見つけて [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#setRemoved) に `true` を渡して呼び出します。これにより、ラベルエントリは残り、削除状態が記録されます。モダンコレクションからエントリを完全に削除したい場合は、[SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) を使用します。すべてのエントリを削除するには [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcollection/#clear) を使用します。

以下の例は、特定のラベルを削除済みとしてマークし、更新されたプレゼンテーションを保存します。

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

## **レガシー MIP 機密ラベルの読み取りと移行**

古い MIP ベースのワークフローは、最新のラベルコレクションではなくカスタムドキュメント プロパティに機密ラベルメタデータを保存することがあります。[DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getSensitivityLabels) を使ってそのメタデータを読み取ります。このメソッドはレガシーのカスタムプロパティを解析し、[SensitivityLabel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/) オブジェクトの Java 配列を返します。

メタデータを移行するには、取得した各ラベルを [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcollection/#add) を介して最新の [SensitivityLabelCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcollection/) に追加します。重複するラベル識別子の追加は例外を発生させるため、例ではコピー前に宛先コレクションをチェックしています。さらに、各レガシーラベルが現在の Purview ポリシーにまだ存在するかどうかを検証するロジックを追加できます。

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

この移行は、解析されたラベルオブジェクトを最新のコレクションにコピーします。すべてのカスタムドキュメント プロパティをクリアする必要はなく、関連しないドキュメント メタデータはそのまま残ります。[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) と [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) を使用して、最新のラベルメタデータを PPTX ファイルに書き込みます。

## **FAQ**

**コンテンツマーキングタイプを追加しても、スライドにヘッダー、フッター、または透かしが表示されますか？**

いいえ。[SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストに追加された値は、機密ラベルに関連付けられたマーキングを記述するだけで、プレゼンテーションに目に見えるテキストや図形を自動的に作成するものではありません。マーキングをスライドに実際に表示する必要がある場合は、別途スライド コンテンツを追加してください。

**ラベルを削除済みとしてマークすることと、コレクションから削除することの違いは何ですか？**

[SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#setRemoved) に `true` を設定すると、ラベルエントリは残り、削除状態がメタデータに記録されます。[SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) を呼び出すと、モダンコレクションからエントリ自体が削除されます。組織のメタデータ保持要件に合った操作を選択してください。

**プレゼンテーションにレガシー MIP メタデータと最新の機密ラベルの両方を含めることはできますか？**

はい。レガシーラベルはカスタムドキュメント プロパティに残したまま、最新のラベルは [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSensitivityLabels) で取得できます。[DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getSensitivityLabels) を使用してレガシー メタデータを読み取り、最新コレクションにまだ存在しない有効なラベルだけを移行してください。

**同一識別子のラベルを複数回追加するとどうなりますか？**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabelcollection/#add) は、コレクションに同じ識別子のラベルがすでに存在する場合例外をスローします。ラベルを追加または移行する前に、[SensitivityLabel::getId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sensitivitylabel/#getId) が返す既存の値を確認してください。

**更新された機密ラベルを保持するために使用すべき出力形式はどれですか？**

上記の例に示すように、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) に [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) を指定して PPTX としてプレゼンテーションを保存してください。