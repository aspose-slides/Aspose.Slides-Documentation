---
title: C++ でのプレゼンテーションアクセシビリティの管理
linktitle: プレゼンテーションアクセシビリティ
type: docs
weight: 30
url: /ja/cpp/presentation-accessibility/
keywords:
- プレゼンテーションアクセシビリティ
- 代替テキスト
- 代替テキストタイトル
- 代替テキスト説明
- 装飾としてマーク
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPT、PPTX、ODP ファイルのプレゼンテーションアクセシビリティチェックを自動化し、スクリーンリーダー体験を向上させ、コンプライアンスを高めます。"
---
## **はじめに**

代替テキストは、支援技術を使用するユーザーが画像、チャート、その他の情報を含む図形の意味を理解できるようにします。本記事では、Aspose.Slides for C++ を使用して代替テキストのタイトルと説明を読み取り・更新する方法、コードで使用される図形名とアクセシビリティ説明を区別する方法、図形が装飾としてマークされているかどうかを確認する方法を説明します。

これらの機能はプレゼンテーションのアクセシビリティを支援しますが、保証はできません。読み順、カラーコントラスト、テキストの可読性、その他のアクセシビリティ要件も確認する必要があります。

## **代替テキストのタイトルと説明の管理**

代替テキストは、画像、チャート、その他の情報を含む図形の意味を視覚に頼れない人に伝えるために使用します。以下のプロパティはそれぞれ異なる目的を持ちます。

| Property or content | Purpose |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_alternativetexttitle/) | 代替テキストの短いタイトルです。 |
| [AlternativeText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_alternativetext/) | スライドのコンテキストで図形の内容や目的を示す意味のある説明です。 |
| [Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_name/) | コードがプレゼンテーション内の特定の図形を検索するために使用できる図形の名前です。 |
| Visible text | スライド上に表示されるコンテンツ（図形のテキストやチャートのタイトル・ラベルなど）。代替テキストを更新してもこのコンテンツは変わりません。 |

プレゼンテーションをテンプレートとして再利用する場合、コードは代替テキストを更新する前に[Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_name/)で図形を検索することがあります。この名前は、視覚的に読者に伝える内容を説明する代替テキストとは別の目的を持ちます。名前で検索できるため、作者は説明を改善または翻訳してもコードが図形を見つける方法を変更せずにすみます。名前は編集可能で一意である保証はないため、対象の図形と一致しているか確認してください。詳細は[Identify and Find Shapes](/slides/ja/cpp/shape-manipulations/#identify-and-find-shapes)をご参照ください。

以下の例では、最初のスライドの最初の図形としてオフィスの入口画像が配置された `input.pptx` を使用します。この画像は装飾としてマークされていないことが前提です。例は現在の代替テキストのタイトルと説明を読み取り、表示し、両方の値を更新し、プレゼンテーションを `output.pptx` として保存します。実際の画像と伝える情報に合わせて文言を調整してください。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

代替テキストだけを追加しても、プレゼンテーションのアクセシビリティやアクセシビリティ標準への準拠は保証されません。説明が正確かつ関連性があるかを確認するとともに、読み順、カラーコントラスト、可読テキスト、その他のアクセシビリティ要件もチェックしてください。情報を伝えるビジュアルは装飾としてマークすべきではありません。次のセクションでは [IsDecorative](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_isdecorative/) の読み取り方法を示します。

## **装飾としてマーク**

装飾としてマークは、純粋に装飾目的のビジュアルにフラグを付け、スクリーンリーダーがそれらをスキップするようにします。これによりノイズが減り、重要なコンテンツに焦点が当たります。背景、装飾的な要素、スペーサーなどに適用し、情報を伝えるチャート、アイコン、画像には決して使用しないでください。Aspose.Slides はこのフラグを検出・検証できるように提供しており、自動アクセシビリティチェックやクリーンアップに利用できます。

![装飾としてマーク](mark_as_decorative.png)

以下のコードサンプルは、図形が装飾としてマークされているかどうかを判定する方法を示しています。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **よくある質問**

**代替テキストのタイトルと説明には何を入れるべきですか？**

短いタイトルで対象を特定し、説明でスライドの文脈でビジュアルが伝える情報を説明します。チャートの場合は「チャート」だけでなく、関連するトレンドや比較を記述してください。

**テンプレート内でシェイプを見つけるために代替テキストを使用すべきですか？**

図形はまず[Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_name/)で検索し、期待通りの図形か確認することを推奨します。代替テキストは編集や翻訳が行われる可能性があるため、正確な記述を検索するコードが壊れることがあります。詳細は[Identify and Find Shapes](/slides/ja/cpp/shape-manipulations/)をご覧ください。

**シェイプを装飾としてマークすべきタイミングはいつですか？**

情報を提供しない純粋な装飾的要素に対して装飾フラグを使用します。意味を伝える画像やチャートには適切な説明を付ける必要があります。

**代替テキストを追加するだけでプレゼンテーションは完全にアクセシブルになりますか？**

いいえ。代替テキストはアクセシビリティの一部にすぎません。読み順、カラーコントラスト、テキストの可読性、その他の要件も確認し、これらのプロパティだけでコンプライアンスが確立されるわけではありません。