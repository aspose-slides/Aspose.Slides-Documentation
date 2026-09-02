---
title: Android 上の PowerPoint プレゼンテーションで感度ラベルを管理
linktitle: 感度ラベル
type: docs
weight: 50
url: /ja/androidjava/sensitivity-labels/
keywords:
- 感度ラベル
- Microsoft Purview
- Microsoft Information Protection
- MIP メタデータ
- コンテンツマーキング
- 情報保護
- 文書ガバナンス
- PowerPoint
- PPTX
- プレゼンテーションのセキュリティ
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint PPTX プレゼンテーションにおける Microsoft Purview の感度ラベルを読み取り、追加、更新、削除、そして移行します。"
---
## **概要**

Microsoft Purview の感度ラベルは、組織がドキュメントを分類および管理するのに役立ちます。自動プレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベルメタデータを移行したりする必要があります。

Aspose.Slides for Android via Java は、最新の感度ラベルメタデータを [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) で公開します。このメソッドは、プレゼンテーションを PPTX として保存する前に検査および変更できる [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/) を返します。

{{% alert color="primary" title="注意" %}}

感度ラベルの識別子とポリシー情報は、Microsoft Purview の設定で定義されます。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を検証してください。[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) の値はラベルに関連付けられたコンテンツマーキングを記述しますが、スライドに可視的なテキストや図形を自動的に追加するわけではありません。

{{% /alert %}}

## **感度ラベル プロパティの理解**

各 [ISensitivityLabel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/) は以下のメタデータを含みます：

| メソッド | 目的 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getId--) と [ISensitivityLabel.setId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview ポリシー内の感度ラベル識別子を取得または設定します。 |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) と [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | ラベルポリシーに関連付けられたサイトを取得または設定します。 |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) と [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | ラベルが有効かどうかを取得または設定します。 |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) と [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | ラベルが削除されたかどうかを取得または設定します。メタデータに削除状態を保持する必要がある場合は、値を `true` に設定します。 |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) と [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | ラベルが自動的に適用されたか、ユーザーの判断によって適用されたかを取得または設定します。 |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | ラベルに関連付けられたコンテンツマーキングの種類を取得します。 |

クラス [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) は、ラベルがどのように割り当てられたかを定義します：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) は、デフォルトまたは自動的に適用されたラベルを表します。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) は、ユーザーの判断により適用されたラベルを表し、手動適用、推奨、必須ラベルが含まれます。

クラス [SensitivityLabelContentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) は、ラベルに関連付けられたマーキングを定義します：

| 値 | 意味 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | ラベルはデフォルトまたは自動的に適用されました。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | ヘッダー コンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | フッター コンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 透かし コンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられています。 |

複数のマーキングタイプを 1 つのラベルに関連付けることができます。

## **既存の感度ラベルを一覧表示**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) から最新のラベルコレクションを読み取り、列挙します。以下の例は、各ラベルごとに保存されているすべてのプロパティとコンテンツマーキングを一覧表示します：

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

## **コンテンツマーキング付き感度ラベルの追加**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) を使用して、ラベル識別子、サイト識別子、有効状態、割り当て方法を指定します。メソッドが新しい [ISensitivityLabel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/) を返したら、[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストを通じて必要なマーキング値を追加します。

以下の例は、フッターと透かしのマーキングが関連付けられた手動選択ラベルを追加し、結果を PPTX として保存します：

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

## **感度ラベルの更新**

[ISensitivityLabel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/) の値は読み書き可能ですが、[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストはそのリスト操作を通じて変更します。目的のラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、およびコンテンツマーキングタイプを更新できます。プレゼンテーションを保存して変更を永続化します。

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

## **感度ラベルを削除済みとしてマーク**

ラベルが削除された事実を保持するには、ラベルを見つけて [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) を `true` で呼び出します。これにより、ラベルエントリは残り、削除状態が記録されます。代わりに最新コレクションからエントリを削除する必要がある場合は、[ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) を使用し、すべてのエントリを削除するには [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) を使用します。

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

## **レガシー MIP 感度ラベルの読み取りと移行**

古い MIP ベースのワークフローは、最新のラベルコレクションの代わりにカスタム ドキュメント プロパティに感度ラベルメタデータを格納することがあります。これらのメタデータは [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) で読み取ります。このメソッドはレガシーのカスタム プロパティを解析し、[ISensitivityLabel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/) オブジェクトの配列を返します。

メタデータを移行するには、返された各ラベルを [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) を介して最新の [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/) に追加します。重複したラベル識別子を追加すると例外がスローされるため、サンプルではコピー前に宛先コレクションをチェックしています。レガシー ラベルが現在の Purview ポリシーにまだ存在するかどうかを確認する追加の検証を行うことも可能です。

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

移行は解析されたラベルオブジェクトを最新コレクションにコピーします。すべてのカスタム ドキュメント プロパティをクリアする必要はなく、関係のないドキュメント メタデータはそのまま残ります。[IPresentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) と [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) を使用して、最新のラベルメタデータを PPTX ファイルに書き込みます。

## **FAQ**

**コンテンツマーキングタイプを追加すると、スライドに目に見えるヘッダー、フッター、または透かしが作成されますか？**

**いいえ**。[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストに追加された値は、感度ラベルに関連付けられたマーキングを記述します。これらはプレゼンテーションに目に見えるテキストや図形を作成しません。ワークフローでそれらのマーキングを表示する必要がある場合は、別途スライドコンテンツを追加してください。

**ラベルを削除済みとしてマークすることと、コレクションから削除することの違いは何ですか？**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) を `true` に設定すると、ラベルエントリは保持され、削除状態が記録されます。[ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) を呼び出すと、エントリは最新コレクションから完全に削除されます。組織のメタデータ保持要件に合った操作を選択してください。

**プレゼンテーションにレガシー MIP メタデータと最新の感度ラベルの両方を含めることはできますか？**

はい。レガシー ラベルはカスタム ドキュメント プロパティに残したままにでき、最新のラベルは [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) で取得できます。レガシー メタデータの読み取りには [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) を使用し、まだ最新コレクションに存在しない有効なラベルだけを移行してください。

**同じ識別子のラベルを複数回追加するとどうなりますか？**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) は、コレクションに同一識別子のラベルがすでに存在する場合に例外をスローします。ラベルや移行を行う前に、[ISensitivityLabel.getId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isensitivitylabel/#getId--) が返す既存の値を確認してください。

**更新された感度ラベルを保持するために使用すべき出力形式はどれですか？**

上記の例に示すように、[IPresentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) で [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) を指定してプレゼンテーションを PPTX として保存します。