---
title: Open XML SDKを選ばない理由
type: docs
weight: 50
url: /ja/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- 比較
- プレゼンテーション オブジェクト モデル
- 高品質変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides が無料の Open XML SDK より優れた選択である理由をご覧ください：機能比較、オートメーション不要の変換、そして PPT、PPTX、ODP の幅広いサポート"
---
## **概要**

この記事では、開発者がプレゼンテーション ドキュメントの操作において Open XML SDK または Aspose.Slides を選択するタイミングについて説明します。Open XML SDK を OOXML パッケージおよびその基礎となる XML 要素を操作するためのライブラリとして説明し、Aspose.Slides は高レベルのオブジェクト モデルと多数の PowerPoint 関連タスクをサポートするプレゼンテーション処理ライブラリとして紹介します。

この記事では、サポート形式、プログラミングモデル、レンダリングおよび印刷機能、プラットフォーム サポート、一般的な使用例の観点から両方のオプションを比較します。また、Open XML SDK が基本的な PPTX 操作や OOXML 要素への直接アクセスに適している場合がある一方、Aspose.Slides は複数の PowerPoint 形式の取り扱い、シェイプのコピーやクローン、テキストの置換、アニメーションの適用、PDF、TIFF、XPS への変換など、複雑なプレゼンテーション タスクにより適していることを明確にします。

## **Open XML SDK とは？**
時々、次のような質問を受けます: *なぜ無料の Open XML SDK ではなく Aspose 製品を使用すべきなのでしょうか？*

機能や特長の観点からこの質問に答えるのは簡単です。

[MSDN ライブラリ](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)によると、Open XML SDK は次のように定義されています:

> "Open XML SDK 2.0 は、Open XML パッケージとパッケージ内の基礎となる Open XML スキーマ要素を操作する作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージ上で実行する多くの一般的なタスクをカプセル化しており、数行のコードだけで複雑な操作を実行できます。OOXML 文書は本質的に Zip 圧縮された XML ファイルであり、Open XML SDK は OOXML 文書の内容を強く型付けされた方法で操作できるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、その XML を DOM ツリーに読み込んで XML 要素や属性を直接操作する代わりに、Open XML SDK がそのためのクラスを提供します。"

## **Aspose.Slides とは？**
Aspose.Slides は、アプリケーションが以下のプレゼンテーション処理タスクを実行できるクラス ライブラリです:

- プレゼンテーション オブジェクト モデルによるプログラミング。
- PDF、XPS、TIFF への変換や印刷を含む、広くサポートされているすべての PowerPoint プレゼンテーション形式を対象とした高品質な変換。
- PNG、JPEG、BMP などの一般的な形式でスライドのサムネイルを生成し、SVG へのエクスポートも可能。
- ゼロからプレゼンテーションを作成するか、1 つまたは複数の文書から要素を組み合わせて構築する。
- アニメーション、OLE フレーム、テーブルの追加や、チャートの作成・管理。
- TextFrames、Paragraph、Portion レベルでのテキスト書式設定を詳細に制御・管理。

利用可能な機能の詳細については、[Aspose.Slides の機能](/slides/ja/net/product-overview/) ページをご覧ください。

## **Open XML SDK と Aspose.Slides の比較**
この表は Open XML SDK の機能と特徴を Aspose.Slides と比較したものです。

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|No|Yes|
|<p>プレゼンテーション ドキュメント オブジェクト モデル (DOM) を使用した高レベル プログラミング: </p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|No|Yes|
|ドキュメント オブジェクト モデルによる詳細なプログラミング; TextHolders、TextFrames、Paragraph、Portion などの個別要素と書式へのアクセス。|Yes|Yes|
|関係識別子や OOXML 文書のリスト識別子など、基礎となる XML 要素および属性への低レベルで直接かつ完全なアクセス。|Yes|No|
|<p>レンダリングと印刷:</p><p>- プレゼンテーションを PDF、PDF Notes、XPS、TIFF 画像にレンダリング。</p><p>- スライド サムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリング。</p><p>- 画像解像度、品質、圧縮、その他のオプションを指定。</p><p>- .NET 印刷インフラストラクチャを使用してプレゼンテーションを印刷。コンポーネントには、MS PowerPoint の印刷プレビューと同様に印刷する組み込みの印刷メソッドが含まれています。</p>|No|Yes|
|サポートされているプラットフォーム|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**
Open XML SDK と Aspose.Slides は直接競合するものではなく、対象とするニーズや対象ユーザーがかなり異なります。

{{% alert color="info" %}} 
Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作できるクラス ライブラリであり、Aspose.Slides は、事実上すべての Microsoft PowerPoint ファイル形式を幅広くサポートする非常に有用なプレゼンテーション処理ライブラリです。 
{{% /alert %}} 

ワークフローが PPTX 文書に対する基本的なプログラミング操作である場合、Open XML SDK が適切な選択肢になることがあります。Open XML SDK を使用すれば、シンプルな PPTX 文書の生成やコメント・ヘッダー/フッターの削除、画像抽出などの簡単なタスクを快適に実行できます。特定のタスクは Open XML SDK で実行可能ですが Aspose.Slides では実行できません。たとえば、OOXML 文書の XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。

文書に対して以下のような複雑なタスクを実行する必要がある場合は、Aspose.Slides が最適です。

- 古い PowerPoint 形式（および PPTX）に関わる操作。
- スライド内のシェイプをコピーまたはクローンし、オブジェクト、スタイル、その他の書式要素を適切に組み合わせる。
- 書式付きまたは書式なしテキストの置換。
- シェイプにアニメーションを適用し、コネクタを使用する。
- 文書を PDF、TIFF、XPS に変換し、Microsoft PowerPoint が変換したかのように表示させる。
- .NET または Java アプリケーションをデスクトップ環境および Web 環境の両方で開発する。