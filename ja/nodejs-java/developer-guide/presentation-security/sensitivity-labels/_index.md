---
title: JavaScript で PowerPoint プレゼンテーションの機密ラベルを管理する
linktitle: 機密ラベル
type: docs
weight: 50
url: /ja/nodejs-java/sensitivity-labels/
keywords:
- 機密ラベル
- Microsoft Purview
- Microsoft Information Protection
- MIP メタデータ
- コンテンツ マーキング
- 情報保護
- ドキュメント ガバナンス
- PowerPoint
- PPTX
- プレゼンテーション セキュリティ
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint PPTX プレゼンテーション内の Microsoft Purview 機密ラベルを読み取り、追加、更新、削除、そして移行します。"
---
## **概要**

Microsoft Purview Sensitivity ラベルは、組織がドキュメントを分類および管理できるようにします。自動化されたプレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベル メタデータを移行したりする必要があります。

Aspose.Slides for Node.js via Java は、[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) を介して最新の機密ラベル メタデータを公開します。このメソッドは、[SensitivityLabelCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcollection/) を返し、プレゼンテーションを PPTX として保存する前に検査および変更できます。

{{% alert color="primary" title="注意" %}}
機密ラベルの識別子とポリシー情報は、Microsoft Purview の構成で定義されます。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を検証してください。[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) の値はラベルに関連付けられたコンテンツ マーキングを記述しますが、スライドに可視テキストやシェイプを直接追加するものではありません。
{{% /alert %}}

## **機密ラベルプロパティの理解**

各 [SensitivityLabel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/) には、以下のメタデータが含まれます。

| メソッド | 目的 |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getId) と [SensitivityLabel.setId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Purview ポリシー内の機密ラベル識別子を取得または設定します。 |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) と [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | ラベル ポリシーに関連付けられたサイトを取得または設定します。 |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) と [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | ラベルが有効かどうかを取得または設定します。 |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) と [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | ラベルが削除されたかどうかを取得または設定します。削除状態をメタデータに保持する必要がある場合は、値を `true` に設定します。 |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) と [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | ラベルが自動的に適用されたか、ユーザーの判断によって適用されたかを取得または設定します。 |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | ラベルに関連付けられたコンテンツ マーキングの種類を取得します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) クラスは、ラベルの割り当て方法を定義します。

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) は、デフォルトまたは自動適用ラベルを表します。  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) は、ユーザーの判断により適用されたラベルを表し、手動適用、推奨、必須ラベルを含みます。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) クラスは、ラベルに関連付けられるマーキングを定義します。

| 値 | 意味 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | ラベルはデフォルトまたは自動的に適用されました。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | ヘッダー コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | フッター コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | ウォーターマーク コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられています。 |

1 つのラベルに複数のマーキング タイプを関連付けることができます。

## **既存の機密ラベルを一覧表示**

[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) から最新のラベルコレクションを取得し、列挙します。以下の例は、各ラベルに保存されているすべてのプロパティとコンテンツ マーキングを一覧表示します。

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

## **コンテンツ マーキング付き機密ラベルを追加**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) を使用し、ラベル識別子、サイト識別子、有効状態、割り当て方法を指定します。メソッドが新しい [SensitivityLabel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/) を返したら、[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストを通じて必要なマーキング値を追加します。

以下の例は、フッターとウォーターマークのマーキングが関連付けられた手動選択ラベルを追加し、結果を PPTX として保存します。

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

## **機密ラベルを更新**

[SensitivityLabel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/) の値は読み書き可能ですが、[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストはそのリスト操作を通じて変更します。必要なラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツ マーキング タイプを更新できます。変更を永続化するためにプレゼンテーションを保存してください。

以下の例は、最初のラベルの有効状態と割り当て方法を更新します。

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

## **機密ラベルを削除済みとしてマーク**

ラベルが削除されたことを保持したい場合は、ラベルを見つけて [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) に `true` を渡して呼び出します。これにより、エントリは残り、削除状態が記録されます。最新コレクションからエントリ自体を削除したい場合は、[SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) を使用し、すべてのエントリを削除するには [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) を使用します。

以下の例は、特定のラベルを削除済みとしてマークし、更新されたプレゼンテーションを保存します。

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

## **レガシー MIP 機密ラベルの読み取りと移行**

古い MIP ベースのワークフローは、最新ラベルコレクションの代わりにカスタム ドキュメントプロパティに機密ラベル メタデータを格納することがあります。これらのメタデータは [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) で取得できます。このメソッドはレガシー カスタムプロパティを解析し、[SensitivityLabel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/) オブジェクトの配列を返します。

メタデータを移行するには、返された各ラベルを [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) を介して最新の [SensitivityLabelCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcollection/) に追加します。重複したラベル識別子を追加しようとすると例外がスローされるため、例ではコピー前に宛先コレクションをチェックしています。レガシー ラベルが現在の Purview ポリシーにまだ存在するかどうかを確認するさらなる検証を追加することもできます。

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

この移行は、解析されたラベルオブジェクトを最新コレクションにコピーするだけです。すべてのカスタム ドキュメントプロパティをクリアする必要はなく、無関係なドキュメントメタデータはそのまま残ります。最新ラベルメタデータを書き出すには、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) と [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) を使用して PPTX ファイルとして保存します。

## **FAQ**

**コンテンツ マーキング タイプを追加すると、スライドに可視的なヘッダー、フッター、またはウォーターマークが作成されますか？**

いいえ。[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストに追加された値は、機密ラベルに関連付けられたマーキングを記述するだけです。プレゼンテーションに可視テキストやシェイプは自動的に作成されません。ワークフローでそれらのマーキングを表示する必要がある場合は、別途スライド コンテンツを追加してください。

**ラベルを「削除済み」とマークすることと、コレクションから削除することの違いは何ですか？**

[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) に `true` を設定すると、ラベル エントリは保持され、削除状態が記録されます。一方、[SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) を呼び出すと、エントリ自体が最新コレクションから削除されます。組織のメタデータ保持要件に合わせて操作を選択してください。

**プレゼンテーションにレガシー MIP メタデータと最新の機密ラベルの両方を含めることはできますか？**

はい。レガシー ラベルはカスタム ドキュメントプロパティに残したままにでき、最新のラベルは [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) で取得できます。レガシー メタデータを読み取り、まだ最新コレクションに存在しない有効なラベルだけを移行するには、[DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) を使用してください。

**同じ識別子のラベルを複数回追加するとどうなりますか？**

同一識別子のラベルがコレクションに既に存在する場合、[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) は例外をスローします。追加または移行する前に、[SensitivityLabel.getId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sensitivitylabel/#getId) が返す既存の値を確認してください。

**更新された機密ラベルを保持するために推奨される出力形式は何ですか？**

上記の例に示すように、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) に [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) を指定してプレゼンテーションを PPTX として保存してください。