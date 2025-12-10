---
title: Open XML SDK はなぜ使わないのか
type: docs
weight: 120
url: /ja/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 比較
- プレゼンテーション オブジェクト モデル
- 高品質変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides が無料の Open XML SDK より優れた選択である理由をご覧ください：機能比較、完全自動化不要の変換、PPT、PPTX、ODP の幅広いサポート。"
---

{{% alert color="primary" %}} 

私たちは時々次の質問を耳にします:

**なぜ無料の Open XML SDK ではなく Aspose 製品を使うべきなのでしょうか？**

この質問への答えは簡単です: **機能と機能性**。

{{% /alert %}} 
## **Open XML SDK とは?**
[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) によると、Open XML SDK は次のように定義されています: 

Open XML SDK 2.0 は、Open XML パッケージとパッケージ内の基礎となる Open XML スキーマ要素を操作する作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージで実行する多くの共通タスクをカプセル化し、数行のコードだけで複雑な操作を実行できるようにします。

OOXML ドキュメントは本質的に圧縮された XML ファイルであり、Open XML SDK は OOXML ドキュメントの内容を強く型付けされた方法で操作できるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、DOM ツリーにロードして XML 要素や属性を直接操作する代わりに、Open XML SDK がそのためのクラスを提供します。
## **Aspose.Slides とは?**
Aspose.Slides は、アプリケーションが次のプレゼンテーション処理タスクを実行できるようにするクラス ライブラリです:

- **Presentation** オブジェクト モデルによるプログラミング。
- PDF、XPS、TIFF を含む、すべての一般的にサポートされている PowerPoint プレゼンテーション形式間の高品質変換。
- PNG、JPEG、BMP などのよく知られた形式でスライドサムネイルを生成し、SVG へのスライドエクスポートも可能。
- スライドをゼロから作成するか、1 つまたは複数のドキュメントを組み合わせて作成する機能。
- アニメーション、Ole フレーム、テーブル、チャートの作成と管理をサポート。
- TextFrames、Paragraphs、Portions レベルでのテキスト書式設定を細かく管理できる豊富なコントロール。

機能の詳細については、[Aspose.Slides Features](/slides/ja/java/product-overview/) をご覧ください。
## **Open XML SDK と Aspose.Slides の比較**
{{% alert color="primary" %}} 

以下の表は Open XML SDK と Aspose.Slides の機能を比較したものです。

{{% /alert %}} 

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされるプレゼンテーション形式|PPTX|PPT、POT、PPS、PPTX、POTX、PPSX、ODP|
|PPT から PPTX への変換|No|Yes|
|<p>プレゼンテーション ドキュメント オブジェクト モデル (DOM) を使用した高レベル プログラミング:</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|No|Yes|
|ドキュメント オブジェクト モデルによる詳細プログラミング。TextHolders、TextFrames、Paragraphs、Portions などの個々の要素や書式設定へのアクセス。|Yes|Yes|
|OOXML ドキュメントの関係識別子やリスト識別子など、基礎となる XML 要素や属性への低レベルの直接完全アクセス。|Yes|No|
|<p>レンダリング:</p><p>- プレゼンテーションを PDF、PDF Notes、XPS、TIFF 画像にレンダリング。</p><p>- スライド サムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリング。</p><p>- 画像の解像度、品質、圧縮、その他のオプションを指定。</p>|No|Yes |
|サポートプラットフォーム|Windows、.NET|Windows、Linux、UNIX、MAC、Java、PHP、Mono|
## **結論**
{{% alert color="primary" %}} 

Open XML SDK と Aspose.Slides は、対象とするニーズやユーザー層が大きく異なるため、正面から競合するものではありません。Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作するためのクラス ライブラリです。Aspose.Slides は、ほぼすべての Microsoft PowerPoint ファイル形式を幅広くサポートする、非常に便利なプレゼンテーション処理ライブラリです。

もし必要なのが PPTX ドキュメントに対する比較的基本的なプログラミング操作だけであれば、Open XML SDK が適切な選択になるでしょう。Open XML SDK を使えば、シンプルな PPTX ドキュメントの生成やコメント・ヘッダー/フッターの削除、画像の抽出などの単純作業を快適に行えます。あるタスクは Open XML SDK で実現できても Aspose.Slides では実現できないことがあります。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。一方、ドキュメントに対して以下のような複雑な操作を行う必要がある場合は、Aspose.Slides が最適な選択肢です:

- PPTX に加えて古い PowerPoint 形式もサポートする。
- スライド内のシェイプを、オブジェクト、スタイル、その他の書式設定を適切に組み合わせてコピーまたはクローンする。
- 書式付きまたは書式なしテキストの置換。
- アニメーションの適用やシェイプ間のコネクタの使用。
- ドキュメントを PDF、TIFF、XPS に変換し、Microsoft PowerPoint が変換したときと同じ外観にする。
- デスクトップおよび Web ベースの環境の両方で .NET または Java アプリケーションを開発する。

{{% /alert %}}