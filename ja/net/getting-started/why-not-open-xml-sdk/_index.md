---
title: Open XML SDK を使用しない理由
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
description: "無料の Open XML SDK より Aspose.Slides が優れた選択肢である理由をご確認ください：機能、オートメーション不要の変換、PPT、PPTX、ODP の広範なサポートを比較しています。"
---
## **概要**

この記事では、開発者がプレゼンテーション文書の処理に Open XML SDK または Aspose.Slides を選択するタイミングについて説明します。Open XML SDK は OOXML パッケージとその基になる XML 要素を操作するためのライブラリとして説明され、Aspose.Slides は高レベルのオブジェクトモデルと多数の PowerPoint 関連タスクをサポートするプレゼンテーション処理ライブラリとして提示されています。

この記事では、サポートされている形式、プログラミングモデル、レンダリング、プラットフォームサポート、一般的なユースケースの観点から両者を比較します。また、Open XML SDK が基本的な PPTX 操作や OOXML 要素への直接アクセスに適している可能性がある一方で、Aspose.Slides は複数の PowerPoint 形式の取り扱い、シェイプのコピーやクローン、テキストの置換、アニメーションの適用、プレゼンテーションの PDF、TIFF、XPS への変換など、複雑なプレゼンテーションタスクにより適していることを明確にします。

## **Open XML SDK とは？**

時々、次のような質問を受けます: *なぜ無料の Open XML SDK ではなく Aspose 製品を使用すべきなのでしょうか？*  

この質問には機能や機能性の観点から答えるのが容易です。

[MSDN ライブラリ](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) によると、Open XML SDK は次のように定義されています:

> "Open XML SDK 2.0 は、Open XML パッケージとパッケージ内の基礎となる Open XML スキーマ要素の操作作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージ上で実行する多くの一般的なタスクをカプセル化し、数行のコードだけで複雑な操作を実行できるようにします。OOXML 文書は基本的に zip 圧縮された XML ファイルであり、Open XML SDK は OOXML 文書の内容を強く型付けされた方法で扱えるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、その XML を DOM ツリーに読み込んで XML 要素や属性を直接操作する代わりに、Open XML SDK がそれらを行うクラスを提供します。"

## **Aspose.Slides とは？**

Aspose.Slides は、アプリケーションが以下のプレゼンテーション処理タスクを実行できるようにするクラス ライブラリです:

- プレゼンテーション オブジェクト モデルでのプログラミング。
- PDF、XPS、TIFF への変換を含む、すべての一般的にサポートされている PowerPoint プレゼンテーション形式に対する高品質な変換。
- PNG、JPEG、BMP などのよく知られた形式でのスライド サムネイル生成、および SVG へのスライドエクスポート。
- 1 つまたは複数のドキュメントから要素を組み合わせて、ゼロからプレゼンテーションを構築。
- アニメーション、OLE フレーム、テーブルの追加、チャートの作成と管理。
- TextFrames、Paragraph、Portion レベルでのテキスト書式設定の（広範な）制御と管理。

利用可能な機能の詳細については、[Aspose.Slides の機能](/slides/ja/net/product-overview/) ページをご覧ください。

## **Open XML SDK と Aspose.Slides の比較**

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|No|Yes|
|<p>プレゼンテーション ドキュメント オブジェクト モデル (DOM) を使用した高レベルのプログラミング：</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|No|Yes|
|ドキュメントオブジェクトモデルを用いた詳細なプログラミング；TextHolders、TextFrames、Paragraph、Portion などの個々の要素や書式設定へのアクセス。|Yes|Yes|
|関係識別子や OOXML 文書のリスト識別子など、基礎となる XML 要素や属性への低レベルかつ完全な直接アクセス。|Yes|No|
|<p>プレゼンテーションのレンダリング：</p><p>- PDF、PDF ノート、XPS、TIFF 画像へのレンダリング。</p><p>- PNG、JPEG、BMP、SVG、TIFF へのスライド サムネイルのレンダリング。</p><p>- 画像解像度、品質、圧縮およびその他のオプションの指定。</p>|No|Yes|
|サポートされているプラットフォーム|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**

Open XML SDK と Aspose.Slides は、対象とするニーズが大きく異なるため直接競合するものではなく、対象とするユーザー層も異なります。

{{% alert color="info" %}} 
Open XML SDK は OOXML 文書を強く型付けされた方法で扱うクラス ライブラリであり、Aspose.Slides はほぼすべての Microsoft PowerPoint ファイル形式に対して優れたサポートを提供する非常に有用なプレゼンテーション処理ライブラリです。 
{{% /alert %}} 

ワークフローが PPTX ドキュメントに対する基本的なプログラミング操作である場合、Open XML SDK が適切な選択肢となるでしょう。Open XML SDK を使用すれば、シンプルな PPTX ドキュメントの生成やコメント・ヘッダー/フッターの削除、画像の抽出などの簡単なタスクを快適に実行できます。特定のタスクは Open XML SDK で実行できても Aspose.Slides では実行できません。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。

文書に対して以下のような複雑なタスクを実行する必要がある場合は、Aspose.Slides が最適な選択肢です。

- 古い PowerPoint 形式（および PPTX も）を含む操作。
- スライド内のシェイプをコピーまたはクローンし、オブジェクト、スタイル、その他の書式設定要素を適切に組み合わせる方法。
- 書式付きまたは無書式のテキストの置換。
- アニメーションの適用やシェイプ間コネクタの使用。
- 文書を PDF、TIFF、XPS に変換し、Microsoft PowerPoint が変換したかのような結果を得る。
- デスクトップおよび Web ベースの環境の両方で .NET または Java アプリケーションを開発すること。