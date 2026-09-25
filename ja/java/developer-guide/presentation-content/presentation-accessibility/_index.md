---
title: Java でプレゼンテーションのアクセシビリティを管理する
linktitle: プレゼンテーションアクセシビリティ
type: docs
weight: 30
url: /ja/java/presentation-accessibility/
keywords:
- プレゼンテーションアクセシビリティ
- 代替テキスト
- 代替テキストのタイトル
- 代替テキストの説明
- 装飾としてマーク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java が PPT、PPTX、ODP ファイルにおけるプレゼンテーションのアクセシビリティチェックを自動化し、スクリーンリーダーの体験を向上させ、コンプライアンスを強化する方法をご紹介します。"
---
## **はじめに**

代替テキストは、支援技術を使用するユーザーが画像、チャート、その他の情報的な図形の意味を理解できるようにします。本記事では、Aspose.Slides for Java を使用して代替テキストのタイトルと説明を読み取り・更新する方法、コードで使用される図形名とは別のアクセシビリティ記述を区別する方法、図形が装飾としてマークされているかを確認する方法を説明します。

これらの機能はプレゼンテーションのアクセシビリティを支援しますが、保証するものではありません。読み順、色のコントラスト、テキストの可読性、その他のアクセシビリティ要件も確認する必要があります。

## **代替テキストのタイトルと説明の管理**

代替テキストは、画像、チャート、その他の情報的な図形の意味を視覚に頼れない人に説明するために使用します。以下のメソッドやコンテンツはそれぞれ異なる目的を持ちます。

| メソッドまたはコンテンツ | 目的 |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | 代替説明の短いタイトルです。 |
| [getAlternativeText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getAlternativeText--) | スライド上の図形の内容または目的を意味的に説明したテキストです。 |
| [getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getName--) | コードがプレゼンテーション内の特定の図形を検索するために使用できる図形名です。 |
| 表示テキスト | 図形のテキストやチャートのタイトル・ラベルなど、スライド上に表示される内容です。代替テキストを更新してもこの内容は変わりません。 |

プレゼンテーションをテンプレートとして再利用する場合、コードは [getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getName--) が返す名前で図形を取得してから更新することがあります。この名前は、読者に対して視覚が何を伝えているかを説明する代替テキストとは別の目的です。名前で検索できることで、作者はコードが図形を探す方法を変更せずに説明を改善したり翻訳したりできます。名前は編集可能で一意である保証はないため、対象の図形と一致しているか確認してください。詳細は [Identify and Find Shapes](/slides/ja/java/shape-manipulations/#identify-and-find-shapes) を参照してください。

以下の例は、最初のスライドの最初の図形としてオフィス入口の画像が配置された `input.pptx` を前提としています。その画像は装飾としてマークされていてはいけません。この例は現在の代替テキストのタイトルと説明を読み取り、両方の値を更新し、プレゼンテーションを `output.pptx` として保存します。実際の画像と伝える情報に合わせて文言を調整してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

代替テキストを追加しただけでは、プレゼンテーションのアクセシビリティやアクセシビリティ基準への準拠は保証されません。説明文の正確性と妥当性を確認すると同時に、読み順、色のコントラスト、可読テキスト、その他のアクセシビリティ要件もチェックしてください。情報を伝えるビジュアルは装飾としてマークすべきではありません。次のセクションでは [isDecorative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#isDecorative--) の確認方法を示します。

## **装飾としてマーク**

装飾としてマークは、純粋に装飾目的のビジュアルに付けられ、スクリーンリーダーがそれらをスキップするようにします。これによりノイズが減り、重要なコンテンツに集中できます。背景、装飾的なフローリッシュ、スペーサーなどに適用し、情報を伝えるチャート、アイコン、画像には決して使用しないでください。Aspose.Slides はこのフラグを検出・検証できるように公開しており、アクセシビリティの自動チェックやクリーンアップに利用できます。

![Mark as Decorative](mark_as_decorative.png)

以下のコードサンプルは、図形が装飾としてマークされているかどうかを判定する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**代替テキストのタイトルと説明には何を書けばよいですか？**

短いタイトルで対象を識別し、説明でスライドの文脈でビジュアルが伝える情報を説明します。チャートの場合は「チャート」とだけ書くのではなく、関連するトレンドや比較を記述してください。

**テンプレート内で図形を見つけるために代替テキストを使用すべきですか？**

[ getName ](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getName--) が返す名前で図形を検索し、期待通りの図形か確認することを推奨します。代替テキストは編集や翻訳が行われる可能性があり、正確な記述で検索するコードが壊れる恐れがあります。詳細は [Identify and Find Shapes](/slides/ja/java/shape-manipulations/) を参照してください。

**図形はいつ装飾としてマークすべきですか？**

情報を提供しない装飾的なビジュアル（フローリッシュなど）に対して装飾フラグを使用します。意味を持つ画像やチャートには適切な説明が必要です。

**代替テキストを追加すればプレゼンテーションは完全にアクセシブルになりますか？**

いいえ。代替テキストはアクセシビリティの一部にすぎません。読み順、色のコントラスト、テキストの可読性、その他該当する要件も確認してください。これらのプロパティを設定しただけでコンプライアンスが成立するわけではありません。