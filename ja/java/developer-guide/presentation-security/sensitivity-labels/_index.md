---
title: Java で PowerPoint プレゼンテーションの機密ラベルを管理
linktitle: 機密ラベル
type: docs
weight: 50
url: /ja/java/sensitivity-labels/
keywords:
- 機密ラベル
- Microsoft Purview
- Microsoft Information Protection
- MIP メタデータ
- コンテンツマーキング
- 情報保護
- ドキュメントガバナンス
- PowerPoint
- PPTX
- プレゼンテーション セキュリティ
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint PPTX プレゼンテーション内の Microsoft Purview 機密ラベルを読み取り、追加、更新、削除、移行します。"
---
## **概要**

Microsoft Purview の機密ラベルは、組織がドキュメントを分類および管理するのに役立ちます。自動プレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベル メタデータを移行したりする必要があります。

Aspose.Slides は、[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) を介して最新の機密ラベル メタデータを公開します。このメソッドは、PPTX として保存する前に検査および変更できる [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabelcollection/) を返します。

{{% alert color="info" title="注" %}}
機密ラベルの識別子とポリシー情報は、Microsoft Purview の構成によって定義されます。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を確認してください。[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) の値はラベルに関連付けられたコンテンツ マークを記述しますが、スライドに目に見えるテキストや図形を自動的に追加するわけではありません。
{{% /alert %}}

## **機密ラベル プロパティの理解**

各 [ISensitivityLabel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/) には、以下のメタデータが含まれます。

| メソッド | 目的 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getId--) と [ISensitivityLabel.setId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview ポリシー内の機密ラベル識別子を取得または設定します。 |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getSiteId--) と [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | ラベル ポリシーに関連付けられたサイトを取得または設定します。 |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#isEnabled--) と [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | ラベルが有効かどうかを取得または設定します。 |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#isRemoved--) と [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | ラベルが削除されたかどうかを取得または設定します。削除状態をメタデータに保持する必要がある場合は `true` に設定します。 |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) と [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | ラベルが自動的に適用されたか、ユーザーの決定によって適用されたかを取得または設定します。 |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | ラベルに関連付けられたコンテンツ マーキングの種類を取得します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelassignmenttype/) クラスは、ラベルの割り当て方法を定義します。

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelassignmenttype/) は、デフォルトまたは自動的に適用されたラベルを表します。  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelassignmenttype/) は、ユーザーの決定によって適用されたラベル（手動適用、推奨、必須ラベルを含む）を表します。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelcontenttype/) クラスは、ラベルに関連付けられるマーキングを定義します。

| 値 | 意味 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelcontenttype/) | ラベルはデフォルトまたは自動的に適用されました。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelcontenttype/) | ヘッダー コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelcontenttype/) | フッター コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelcontenttype/) | ウォーターマーク コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられています。 |

複数のマーキング タイプを 1 つのラベルに関連付けることができます。

## **既存の機密ラベルの一覧表示**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) から最新のラベル コレクションを取得し、列挙します。以下のサンプルは、各ラベルに保存されているすべてのプロパティとコンテンツ マーキングを一覧表示します。

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

## **コンテンツ マーキング付き機密ラベルの追加**

ラベル識別子、サイト識別子、有効状態、割り当て方法を指定して [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) を使用します。メソッドが新しい [ISensitivityLabel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/) を返したら、[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストを通じて必要なマーキング値を追加します。

以下のサンプルは、フッターとウォーターマークのマーキングが関連付けられた手動選択ラベルを追加し、結果を PPTX として保存します。

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

[ISensitivityLabel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/) の値は読み書き可能ですが、[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストはリスト操作を介して変更します。必要なラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツ マーキング タイプを更新できます。変更を永続化するためにプレゼンテーションを保存してください。

以下のサンプルは、最初のラベルの有効状態と割り当て方法を更新します。

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

## **ラベルを削除済みとしてマークする**

ラベルが削除された事実を保持するには、ラベルを見つけて [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) に `true` を渡して呼び出します。これにより、ラベル エントリは保持され、削除状態が記録されます。最新コレクションからエントリを完全に削除したい場合は、[ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) を使用し、すべてのエントリを削除するには [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabelcollection/#clear--) を使用します。

以下のサンプルは、特定のラベルを削除済みとしてマークし、更新されたプレゼンテーションを保存します。

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

## **レガシー MIP 機密ラベルの読み取りと移行**

古い MIP ベースのワークフローは、最新のラベル コレクションの代わりにカスタム ドキュメント プロパティに機密ラベル メタデータを格納することがあります。[IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) を使用してそのメタデータを読み取ります。このメソッドはレガシーのカスタム プロパティを解析し、[ISensitivityLabel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/) オブジェクトの配列を返します。

メタデータを移行するには、返された各ラベルを [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) を介して最新の [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabelcollection/) に追加します。重複するラベル識別子の追加は例外を発生させるため、サンプルはコピー前に宛先コレクションをチェックします。必要に応じて、各レガシー ラベルが現在の Purview ポリシーにまだ存在するかどうかを追加で検証できます。

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

この移行は、解析されたラベル オブジェクトを最新コレクションにコピーします。すべてのカスタム ドキュメント プロパティをクリアする必要はないため、無関係なドキュメント メタデータはそのまま残ります。[IPresentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) と [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) を使用して、最新のラベル メタデータを PPTX ファイルに書き込みます。

## **FAQ**

**コンテンツ マーキング タイプを追加すると、スライドに目に見えるヘッダー、フッター、またはウォーターマークが作成されますか？**

いいえ。[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) が返すリストに追加された値は、機密ラベルに関連付けられたマーキングを記述するだけです。プレゼンテーションに目に見えるテキストや図形は自動的に作成されません。必要に応じて、ワークフローでそれらのマーキングをスライド コンテンツとして別途追加してください。

**ラベルを「削除済み」とマークすることと、コレクションから削除することの違いは何ですか？**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) に `true` を渡すと、ラベル エントリは保持され、削除状態が記録されます。[ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) を呼び出すと、最新コレクションからエントリが完全に削除されます。組織のメタデータ保持要件に合わせて操作を選択してください。

**プレゼンテーションにレガシー MIP メタデータと最新の機密ラベルの両方を含めることはできますか？**

はい。レガシー ラベルはカスタム ドキュメント プロパティに残したまま、最新のラベルは [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) で取得できます。[IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) を使用してレガシー メタデータを読み取り、最新コレクションにまだ存在しない有効なラベルだけを移行してください。

**同じ識別子のラベルを複数回追加しようとするとどうなりますか？**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) は、同じ識別子のラベルが既にコレクションに存在する場合に例外をスローします。ラベルを追加または移行する前に、[ISensitivityLabel.getId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isensitivitylabel/#getId--) が返す既存の値を確認してください。

**更新された機密ラベルを保持するために推奨される出力形式は何ですか？**

上記サンプルのように、[IPresentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) に [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) を指定してプレゼンテーションを PPTX として保存してください。