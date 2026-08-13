---
title: Android の PowerPoint プレゼンテーションにおける機密ラベルの管理
linktitle: 機密ラベル
type: docs
weight: 50
url: /ja/androidjava/sensitivity-labels/
keywords:
- 機密ラベル
- Microsoft Purview
- Microsoft Information Protection
- MIP メタデータ
- コンテンツマーキング
- 情報保護
- 文書ガバナンス
- PowerPoint
- PPTX
- プレゼンテーション セキュリティ
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint PPTX プレゼンテーション内の Microsoft Purview 機密ラベルを読み取り、追加、更新、削除、そして移行します。"
---
## **概要**

Microsoft Purview の機密ラベルは、組織がドキュメントを分類および管理するのに役立ちます。自動化されたプレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベルメタデータを移行したりする必要があります。

Aspose.Slides for Android via Java は、[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) を介して最新の機密ラベルメタデータを公開します。このメソッドは、プレゼンテーションを PPTX として保存する前に検査および変更できる [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/) を返します。

{{% alert color="info" title="Note" %}}
機密ラベルの識別子とポリシー情報は、Microsoft Purview の構成で定義されます。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を検証してください。 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) の値はラベルに関連付けられたコンテンツマーキングを説明しますが、スライドに可視的なテキストや形状を追加するものではありません。
{{% /alert %}}

## **機密ラベル プロパティの理解**

各 [ISensitivityLabel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/) には以下のメタデータが含まれます。

| メソッド | 目的 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getId--) と [ISensitivityLabel.setId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview ポリシー内の機密ラベル識別子を取得または設定します。 |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) と [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | ラベル ポリシーに関連付けられたサイトを取得または設定します。 |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) と [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | ラベルが有効かどうかを取得または設定します。 |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) と [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | ラベルが削除されたかどうかを取得または設定します。メタデータに削除状態を保持する必要がある場合は、値を `true` に設定します。 |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) と [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | ラベルが自動的に適用されたか、ユーザーの判断によって適用されたかを取得または設定します。 |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | ラベルに関連付けられたコンテンツマーキングの種類を取得します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) クラスは、ラベルがどのように割り当てられたかを定義します：

- `[SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/)` はデフォルトまたは自動的に適用されたラベルを表します。
- `[SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/)` は、ユーザーの判断により適用されたラベル（手動適用、推奨、必須ラベルを含む）を表します。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) クラスは、ラベルに関連付けられたマーキングを定義します：

| 値 | 意味 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | ラベルはデフォルトまたは自動的に適用されました。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | ヘッダー コンテンツマーキングがラベルに関連付けられます。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | フッター コンテンツマーキングがラベルに関連付けられます。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | ウォーターマーク コンテンツマーキングがラベルに関連付けられます。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられます。 |

複数のマーキングタイプを 1 つのラベルに関連付けることができます。

## **既存の機密ラベルの一覧**

最新のラベルコレクションを [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) から取得し、列挙します。以下の例は、各ラベルに保存されているすべてのプロパティとコンテンツマーキングを一覧表示します：

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

## **コンテンツマーキング付き機密ラベルの追加**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) を使用し、ラベル識別子、サイト識別子、有効状態、割り当て方法を指定します。メソッドが新しい [ISensitivityLabel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/) を返したら、[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストを通じて必要なマーキング値を追加します。

以下の例は、フッターとウォーターマークのマーキングが関連付けられた手動選択ラベルを追加し、その結果を PPTX として保存します：

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

## **機密ラベルの更新**

[ISensitivityLabel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/) の値は読み書き可能ですが、[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストはそのリスト操作を通じて変更します。必要なラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツマーキングタイプを更新できます。プレゼンテーションを保存して変更を永続化します。

以下の例は、最初のラベルの有効状態と割り当て方法を更新します：

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

## **機密ラベルを削除済みとしてマーク**

ラベルが削除された事実を保持するには、ラベルを見つけて [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) を `true` で呼び出します。これにより、削除された状態が記録されたままラベルエントリが保持されます。代わりに最新コレクションからエントリを削除する必要がある場合は、[ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) を使用し、すべてのエントリを削除するには [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) を使用します。

以下の例は、特定のラベルを削除済みとしてマークし、更新されたプレゼンテーションを保存します：

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

## **旧式 MIP 機密ラベルの読み取りと移行**

旧式の MIP ベースのワークフローは、最新のラベルコレクションの代わりにカスタム文書プロパティに機密ラベルメタデータを格納することがあります。[IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) を使用してそのメタデータを読み取ります。このメソッドはレガシーのカスタムプロパティを解析し、[ISensitivityLabel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/) オブジェクトの配列を返します。

メタデータを移行するには、返された各ラベルを [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) を通じて最新の [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/) に追加します。重複するラベル識別子を追加すると例外がスローされるため、例では各ラベルをコピーする前に宛先コレクションをチェックしています。各レガシーラベルが現在の Purview ポリシーにまだ存在することを確認するために、さらに検証を追加することもできます。

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

この移行は、解析されたラベルオブジェクトを最新のコレクションにコピーします。すべてのカスタム文書プロパティをクリアする必要はないため、無関係な文書メタデータはそのまま保持されます。[IPresentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) を [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) と共に使用して、最新のラベルメタデータを PPTX ファイルに書き込みます。

## **よくある質問**

**コンテンツマーキングタイプを追加すると、スライドに表示可能なヘッダー、フッター、またはウォーターマークが作成されますか？**

いいえ。[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストに追加された値は、機密ラベルに関連付けられたマーキングを説明するもので、プレゼンテーションに可視的なテキストや形状を作成するものではありません。ワークフローでこれらのマーキングを表示する必要がある場合は、別途対応するスライドコンテンツを追加してください。

**ラベルを削除済みとしてマークすることと、コレクションから削除することの違いは何ですか？**

`[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-)` を `true` で呼び出すと、ラベルエントリが保持され、削除状態が記録されます。`[ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-)` を呼び出すと、最新のコレクションからエントリが削除されます。組織のメタデータ保持要件に合致する操作を選択してください。

**プレゼンテーションに、レガシー MIP メタデータと最新の機密ラベルの両方を含めることはできますか？**

はい。レガシーラベルはカスタム文書プロパティに残したまま、最新のラベルは [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) を通じて利用できます。[IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) を使用してレガシー メタデータを読み取り、最新コレクションにまだ存在しない有効なラベルだけを移行してください。

**同じ識別子を持つラベルを複数回追加するとどうなりますか？**

`[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-)` は、同じ識別子を持つラベルがすでにコレクションに存在する場合に例外をスローします。ラベルを追加または移行する前に、[ISensitivityLabel.getId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getId--) が返す既存の値を確認してください。

**更新された機密ラベルを保持するために使用すべき出力形式は何ですか？**

上記の例のように、[IPresentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) を [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) と共に呼び出し、プレゼンテーションを PPTX として保存してください。