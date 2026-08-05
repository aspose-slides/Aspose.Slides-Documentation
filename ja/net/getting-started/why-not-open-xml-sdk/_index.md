---
title: Open XML SDK はなぜ選ばれないのか
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
description: "無料の Open XML SDK より Aspose.Slides が優れた選択肢である理由をご確認ください：機能比較、非自動化変換、PPT、PPTX、ODP の幅広いサポート。"
---
## **概要**

この記事では、開発者がプレゼンテーション文書の操作において Open XML SDK または Aspose.Slides を選択するタイミングについて説明します。Open XML SDK は OOXML パッケージとその基になる XML 要素を操作するためのライブラリとして説明され、Aspose.Slides は高度なオブジェクトモデルを持ち、さまざまな PowerPoint 関連タスクをサポートするプレゼンテーション処理ライブラリとして提示されます。

この記事は、サポートされている形式、プログラミングモデル、レンダリングおよび印刷機能、プラットフォームサポート、一般的なユースケースの観点から両者を比較します。また、Open XML SDK は基本的な PPTX 操作や OOXML 要素への直接アクセスに向いている可能性がある一方、Aspose.Slides は複数の PowerPoint 形式での作業、シェイプのコピーやクローン、テキストの置換、アニメーションの適用、PDF、TIFF、XPS への変換といった複雑なプレゼンテーションタスクにより適していることを明らかにします。

## **Open XML SDK とは何か？**
時々、次のような質問を受けます: *なぜ無料の Open XML SDK ではなく Aspose 製品を使用すべきなのでしょうか？* 

この質問には、機能や機能性の観点から答えるのが簡単です。 

[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) によると、Open XML SDK は次のように定義されています: 

> "Open XML SDK 2.0 は、Open XML パッケージとパッケージ内の基礎となる Open XML スキーマ要素の操作作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージ上で行う多くの共通タスクをカプセル化し、数行のコードだけで複雑な操作を実行できるようにします。OOXML 文書は本質的に zip 圧縮された XML ファイルであり、Open XML SDK は OOXML 文書の内容を強く型付けされた方法で操作できるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、その XML を DOM ツリーにロードし、XML 要素や属性を直接操作する代わりに、Open XML SDK がそれらを行うクラスを提供します。"

## **Aspose.Slides とは何ですか？**
Aspose.Slides は、アプリケーションが以下のプレゼンテーション処理タスクを実行できるようにするクラス ライブラリです: 

- プレゼンテーション オブジェクト モデルでプログラミングする。  
- PDF、XPS、TIFF への変換や印刷を含む、すべての主要な PowerPoint プレゼンテーション形式に対する高品質な変換。  
- PNG、JPEG、BMP などの一般的な形式でスライドサムネイルを生成し、SVG へエクスポートする。  
- 1 つまたは複数のドキュメントから要素を組み合わせて、ゼロからプレゼンテーションを構築する。  
- アニメーション、OLE フレーム、テーブル、チャートの作成と管理を追加する。  
- TextFrames、Paragraph、Portion レベルでのテキスト書式設定を（広範に）制御および管理する。  

利用可能な機能の詳細については、[Aspose.Slides Features](/slides/ja/net/product-overview/) ページをご覧ください。

## **Open XML SDK と Aspose.Slides の比較**
この表は Open XML SDK の機能と特徴を Aspose.Slides と比較したものです。

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|いいえ|はい|
|<p>Presentation Document Object Model (DOM) を使用したハイレベル プログラミング：</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|いいえ|はい|
|ドキュメント オブジェクト モデルによる詳細なプログラミング；TextHolders、TextFrames、Paragraph、Portion など個々の要素と書式設定へのアクセス。|はい|はい|
|OOXML ドキュメントのリレーションシップ識別子、リスト識別子など、基礎となる XML 要素および属性への低レベルかつ完全な直接アクセス。|はい|いいえ|
|<p>レンダリングおよび印刷：</p><p>- プレゼンテーションを PDF、PDF ノート、XPS、TIFF 画像へレンダリング。</p><p>- スライドサムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリング。</p><p>- 画像解像度、品質、圧縮その他のオプションを指定。</p><p>- .NET 印刷インフラストラクチャを使用してプレゼンテーションを印刷。コンポーネントには MS PowerPoint の印刷プレビューと同様にプレゼンテーションを印刷する組み込み印刷メソッドがある。</p>|いいえ|はい|
|サポートされているプラットフォーム|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**
Open XML SDK と Aspose.Slides は直接競合するものではなく、対象とするニーズが大きく異なり、対象ユーザーも異なります。

{{% alert color="primary" %}} 

Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作できるクラス ライブラリであり、Aspose.Slides はほぼすべての Microsoft PowerPoint ファイル形式に対して優れたサポートを提供する非常に有用なプレゼンテーション処理ライブラリです。 

{{% /alert %}} 

ワークフローが PPTX ドキュメントに対する基本的なプログラミング操作である場合、Open XML SDK が適切な選択肢となる可能性があります。Open XML SDK を使用すれば、シンプルな PPTX ドキュメントの生成やコメント、ヘッダー/フッターの削除、画像の抽出などの簡単なタスクを快適に実行できます。特定のタスクは Open XML SDK で実行できても Aspose.Slides では実行できないことがあります。たとえば、OOXML ドキュメントの XML 要素と属性へ直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。 

文書上で複雑なタスクを実行する必要がある場合—以下のリストにあるようなタスク—は、Aspose.Slides が最適な選択肢です。 

- 古い PowerPoint 形式（および PPTX）を含む操作。  
- スライド内のシェイプをコピーまたはクローンし、オブジェクト、スタイル、その他の書式設定要素を適切に組み合わせる方法。  
- 書式付きまたは書式なしテキストの置換。  
- アニメーションの適用およびシェイプ間のコネクタ使用。  
- 文書を PDF、TIFF、XPS に変換し、Microsoft PowerPoint が変換したかのように表示させる。  
- デスクトップおよび Web ベースの環境の両方で .NET または Java アプリケーションを開発する。