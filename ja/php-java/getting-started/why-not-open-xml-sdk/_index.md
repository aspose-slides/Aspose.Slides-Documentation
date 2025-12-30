---
title: Open XML SDKはなぜ使えないのか
type: docs
weight: 120
url: /ja/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 比較
- プレゼンテーション オブジェクト モデル
- 高品質変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides が無料の Open XML SDK より優れた選択肢である理由をご覧ください：機能比較、オートメーション不要の変換、PPT、PPTX、ODP の幅広いサポート。"
---

{{% alert color="primary" %}} 

私たちは時々この質問を聞きます：

**なぜ無料の Open XML SDK ではなく Aspose 製品を使用すべきなのでしょうか？**

この質問への答えは簡単です: **機能と機能性**。

{{% /alert %}} 
## **Open XML SDK とは何ですか？**
[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) によると、Open XML SDK は次のように定義されています: 

Open XML SDK 2.0 は、Open XML パッケージおよびパッケージ内の基礎となる Open XML スキーマ要素を操作する作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージで行う多くの一般的なタスクをカプセル化しており、数行のコードで複雑な操作を実行できるようにします。

OOXML ドキュメントは本質的に zip された XML ファイルであり、Open XML SDK は OOXML ドキュメントの内容を強く型付けされた方法で操作できるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、その XML を DOM ツリーに読み込んで XML 要素や属性を直接操作する代わりに、Open XML SDK はそれを行うためのクラスを提供します。
## **Aspose.Slides とは何ですか？**
Aspose.Slides は、アプリケーションが次のプレゼンテーション処理タスクを実行できるクラス ライブラリです：

- **Presentation** オブジェクト モデルによるプログラミング。
- PDF、XPS、TIFF への変換を含む、すべての一般的にサポートされている PowerPoint プレゼンテーション形式間の高品質変換。
- PNG、JPEG、BMP などの一般的な形式でスライドサムネイルを生成し、SVG へスライドをエクスポートする機能。
- ゼロから、または 1 つまたは複数のドキュメントを組み合わせてプレゼンテーションを作成する機能。
- アニメーション、Ole フレーム、テーブルの追加、チャートの作成および管理のサポート。
- TextFrames、Paragraph、Portion レベルでのテキスト書式設定を管理するための幅広いコントロールが利用可能。

サポートされている機能の詳細については、[Aspose.Slides Features](/slides/ja/php-java/product-overview/) をご覧ください。
## **Open XML SDK と Aspose.Slides の比較**
{{% alert color="primary" %}} 

次の表は Open XML SDK と Aspose.Slides の機能を比較しています。

{{% /alert %}} 

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|No|Yes|
|<p>Presentation Document Object Model (DOM) を使用した高レベルプログラミング：</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドの組み立て。</p>|No|Yes|
|ドキュメント オブジェクト モデルを使用した詳細なプログラミング、TextHolders、TextFrames、Paragraphs、Portions などの個々の要素や書式設定へのアクセス。|Yes|Yes|
|関係識別子や OOXML ドキュメントのリスト識別子など、基礎となる XML 要素や属性への低レベルで直接かつ完全なアクセス。|Yes|No|
|<p>レンダリング：</p><p>- プレゼンテーションを PDF、PDF ノート、XPS、TIFF 画像にレンダリング。</p><p>- スライドサムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリング。</p><p>- 画像の解像度、品質、圧縮、その他のオプションを指定。</p>|No|Yes|
|サポートプラットフォーム|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|
## **結論**
{{% alert color="primary" %}} 

Open XML SDK と Aspose.Slides は、対象とするニーズやユーザー層が大きく異なるため、正面から競合するものではありません。Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作できるクラス ライブラリです。Aspose.Slides は、ほぼすべての Microsoft PowerPoint ファイル形式に対して優れたサポートを提供する、非常に有用なプレゼンテーション処理ライブラリです。

もし、PPTX ドキュメントに対して比較的基本的なプログラミング操作だけが必要であれば、Open XML SDK が適切な選択になるかもしれません。Open XML SDK を使用すれば、シンプルな PPTX ドキュメントの生成やコメント、ヘッダー/フッターの削除、画像の抽出などの単純なタスクを十分に快適に行えます。Open XML SDK で実現できるタスクもあれば、Aspose.Slides では実現できないものもあります。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。一方、以下のような複雑な処理をドキュメントに対して行う必要がある場合は、Aspose.Slides を使用するのが最適です：

- PPTX に加えて、古い PowerPoint 形式もサポート。
- スライド内のシェイプをコピーまたはクローンし、オブジェクト、スタイル、その他の書式設定を適切に組み合わせる方法で処理。
- 書式付きまたは書式なしテキストの置換。
- アニメーションの適用およびシェイプ間のコネクタの使用。
- ドキュメントを PDF、TIFF、XPS に変換し、Microsoft PowerPoint が変換したときと同じ外観にする。
- .NET または Java アプリケーションをデスクトップおよび Web 環境の両方で開発。

{{% /alert %}}