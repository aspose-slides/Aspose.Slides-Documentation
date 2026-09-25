---
title: Android でのプレゼンテーションアクセシビリティの管理
linktitle: プレゼンテーションアクセシビリティ
type: docs
weight: 30
url: /ja/androidjava/presentation-accessibility/
keywords:
- プレゼンテーションアクセシビリティ
- 代替テキスト
- 代替テキストタイトル
- 代替テキスト説明
- 装飾としてマーク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java が PPT、PPTX、ODP ファイルにおけるプレゼンテーションアクセシビリティチェックを自動化し、スクリーンリーダー体験を向上させ、コンプライアンスを促進する方法をご紹介します。"
---
## **概要**

代替テキストは、支援技術を使用する人々が画像、チャート、その他の情報的な図形の意味を理解するのに役立ちます。本記事では、Aspose.Slides for Android via Java を使用して代替テキストのタイトルと説明を読み取って更新する方法、コードで使用される図形名とアクセシビリティ用の説明を区別する方法、そして図形が装飾としてマークされているかどうかを確認する方法を説明します。

これらの機能はプレゼンテーションのアクセシビリティを支援しますが、保証するものではありません。読み順、カラーコントラスト、テキストの可読性、その他のアクセシビリティ要件も確認する必要があります。

## **代替テキストのタイトルと説明の管理**

代替テキストを使用して、画像、チャート、その他の情報的な図形の意味を視覚的に確認できない人々に説明します。以下のメソッドとコンテンツはそれぞれ異なる目的で使用されます。

| メソッドまたはコンテンツ | 目的 |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | 代替説明の短いタイトルです。 |
| [getAlternativeText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | スライドのコンテキスト内で図形の内容または目的を示す意味のある説明です。 |
| [getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getName--) | 図形の名前で、コードがプレゼンテーション内の特定の図形を検索する際に使用できます。 |
| Visible text | スライド上に表示されるコンテンツ（例: 図形のテキストやチャートのタイトル・ラベル）。代替テキストを更新してもこのコンテンツは変更されません。 |

プレゼンテーションをテンプレートとして再利用する場合、コードは更新前に [getName] が返す名前で図形を検索することがあります。この名前は、ビジュアルが読者に伝える内容を説明する代替テキストとは別の目的で使用されます。名前で検索することで、作者はコードが図形を見つける方法を変えずに説明を改善したり翻訳したりできます。名前は編集可能で一意である保証はないため、対象の図形と一致しているか確認してください。詳しくは [Identify and Find Shapes](/slides/ja/androidjava/shape-manipulations/#identify-and-find-shapes) を参照してください。

以下の例では、最初のスライドの最初の図形としてオフィスの入口の画像が含まれる `input.pptx` が必要です。その画像は装飾としてマークされていてはいけません。この例は現在の代替テキストのタイトルと説明を読み取り、表示し、両方の値を更新してプレゼンテーションを `output.pptx` として保存します。実際の画像と伝える情報に合わせて文言を調整してください。

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

代替テキストを追加するだけでは、プレゼンテーションのアクセシビリティやアクセシビリティ標準への準拠が保証されません。説明が正確かつ適切であるか確認し、さらに読み順、カラーコントラスト、テキストの可読性、その他のアクセシビリティ要件もチェックしてください。情報を伝えるビジュアルは装飾としてマークすべきではありません。次のセクションでは [isDecorative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#isDecorative--) の確認方法を示します。

## **装飾としてマーク**

装飾としてマークは、純粋に装飾目的のビジュアルにフラグを付け、スクリーンリーダーがそれらをスキップするようにします。これによりノイズが減り、重要なコンテンツに集中できます。背景や装飾的なフローリッシュ、間隔用の要素に適用し、情報を伝えるチャート、アイコン、画像には決して使用しないでください。Aspose.Slides はこのフラグを検出・検証できるように公開しており、自動アクセシビリティチェックやクリーンアップが可能です。

![装飾としてマーク](mark_as_decorative.png)

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

## **FAQ**

**代替テキストのタイトルと説明には何を記入すべきですか？**

対象を識別するための短いタイトルを使用し、スライドのコンテキストでビジュアルが伝える情報を説明する説明文を付けます。チャートの場合、単に「チャート」と記すのではなく、関連する傾向や比較を記述してください。

**テンプレート内で図形を見つけるために代替テキストを使用すべきですか？**

図形は、[getName] が返す名前で検索し、期待する図形であることを確認する方法を優先してください。代替テキストは編集や翻訳が行われる可能性があり、正確な説明文で検索するコードが破損する恐れがあります。詳細は [Identify and Find Shapes](/slides/ja/androidjava/shape-manipulations/) を参照してください。

**図形を装飾としてマークすべきタイミングはいつですか？**

情報を付加しないビジュアル（装飾的なフローリッシュなど）に対して装飾フラグを使用してください。意味を伝える画像やチャートには、代わりに適切な説明が必要です。

**代替テキストを追加するだけでプレゼンテーションは完全にアクセシブルになりますか？**

いいえ。代替テキストはアクセシビリティの一部にしか対処しません。読み順、カラーコントラスト、テキストの可読性、その他の該当要件も確認してください。これらのプロパティを設定しただけでは準拠が確立されません。