---
title: .NET でのプレゼンテーションアクセシビリティの管理
linktitle: プレゼンテーションアクセシビリティ
type: docs
weight: 30
url: /ja/net/presentation-accessibility/
keywords:
- プレゼンテーションアクセシビリティ
- 代替テキスト
- 代替テキストのタイトル
- 代替テキストの説明
- 装飾としてマーク
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PPT、PPTX、ODP ファイルのプレゼンテーションアクセシビリティチェックを自動化し、スクリーンリーダー体験を向上させ、コンプライアンスを強化します。"
---
## **概要**

代替テキストは、支援技術を使用する人が画像、チャート、その他の情報的な図形の意味を理解できるよう支援します。本記事では、Aspose.Slides for .NET を使用して代替テキストのタイトルと説明を読み取り、更新する方法、コードで使用される図形名とアクセシビリティの説明を区別する方法、図形が装飾としてマークされているかどうかを確認する方法について説明します。

これらの機能はプレゼンテーションのアクセシビリティを支援しますが、保証はできません。読み順、色のコントラスト、テキストの可読性、その他のアクセシビリティ要件も確認する必要があります。

## **代替テキストのタイトルと説明の管理**

代替テキストを使用して、画像、チャート、その他の情報的な図形の意味を視覚的に確認できない人に説明します。以下のプロパティはそれぞれ異なる目的を持ちます：

| プロパティまたはコンテンツ | 目的 |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/alternativetexttitle/) | 代替説明のための短いタイトルです。 |
| [AlternativeText](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/alternativetext/) | スライドのコンテキストにおける図形の内容または目的を示す意味のある説明です。 |
| [Name](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/name/) | 図形の名前で、コードがプレゼンテーション内の特定の図形を検索する際に使用できます。 |
| Visible text | スライド上に表示されるコンテンツで、図形のテキストやチャートのタイトル・ラベルなどがあります。代替テキストを更新してもこのコンテンツは変更されません。 |

プレゼンテーションをテンプレートとして再利用する場合、コードは[Name](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/name/)で図形を検索してから更新することがあります。この名前は、視覚的に読者に伝える代替テキストとは別の目的で使用されます。名前で検索することで、作者はコードが図形を検索する方法を変更せずに説明を改善または翻訳できます。名前は編集可能で一意である保証はないため、意図した図形と一致しているか確認してください。[図形の特定と検索](/slides/ja/net/shape-manipulations/#identify-and-find-shapes) を参照してください。

以下の例では、最初のスライドの最初の図形としてオフィス入口の画像が含まれる `input.pptx` が必要です。その画像は装飾としてマークされていてはいけません。この例は現在の代替テキストのタイトルと説明を読み取り、印刷し、両方の値を更新し、プレゼンテーションを `output.pptx` として保存します。実際の画像と伝える情報に合わせて文言を調整してください。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

代替テキストだけを追加しても、プレゼンテーションのアクセシビリティやアクセシビリティ標準への準拠は保証されません。説明の正確性と関連性を確認し、読み順、色のコントラスト、可読テキスト、その他のアクセシビリティ要件も確認してください。情報を伝えるビジュアルは装飾としてマークすべきではありません。次のセクションでは[IsDecorative](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/isdecorative/) を読む方法を示します。

## **装飾としてマーク**

装飾としてマークは、純粋に装飾的なビジュアルにフラグを付け、スクリーンリーダーがそれらをスキップすることでノイズを減らし、意味のあるコンテンツに焦点を当てます。背景や装飾的な要素、スペーサーに適用し、情報を伝えるチャート、アイコン、画像には決して使用しないでください。Aspose.Slides はこのフラグを検出および検証できるように公開しており、自動アクセシビリティチェックやクリーンアップを可能にします。

![Mark as Decorative](mark_as_decorative.png)

以下のコードサンプルは、図形が装飾としてマークされているかどうかを判定する方法を示します。

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **FAQ**

**代替テキストのタイトルと説明には何を書けばよいですか？**

代替テキストのタイトルは対象を識別する短いものとし、説明はスライドのコンテキストでビジュアルが伝える情報を説明します。チャートの場合、単に「チャート」と言うだけでなく、関連する傾向や比較を記述してください。

**テンプレート内で図形を見つけるために代替テキストを使用すべきですか？**

図形は可能な限り[Name](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/name/)で検索し、期待する図形であることを確認してください。代替テキストは編集や翻訳が行われる可能性があり、正確な説明を検索するコードが壊れる恐れがあります。[図形の特定と検索](/slides/ja/net/shape-manipulations/) を参照してください。

**図形はいつ装飾としてマークすべきですか？**

情報を提供しないビジュアル、例えば装飾的なフローリッシュに装飾フラグを使用します。意味を伝える画像やチャートには適切な説明が必要です。

**代替テキストを追加すればプレゼンテーションは完全にアクセシブルになりますか？**

いいえ。代替テキストはアクセシビリティの一部しかカバーしません。読み順、色のコントラスト、テキストの可読性、その他の要件も確認してください。これらのプロパティだけを設定してもコンプライアンスは確立されません。