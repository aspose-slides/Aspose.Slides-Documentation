---
title: Open XML SDK が選ばれない理由
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
description: "Aspose.Slides が無料の Open XML SDK より優れた選択肢である理由をご覧ください：機能の比較、自動化不要の変換、そして PPT、PPTX、ODP の幅広いサポート。"
---
## **概要**

この記事では、開発者がプレゼンテーション ドキュメントを操作する際に Open XML SDK と Aspose.Slides のどちらを選択すべきかについて説明します。Open XML SDK は OOXML パッケージとその基礎となる XML 要素を操作するためのライブラリとして紹介され、Aspose.Slides は高レベルのオブジェクト モデルと多数の PowerPoint 関連タスクをサポートするプレゼンテーション処理ライブラリとして提示されます。

この記事では、サポート形式、プログラミング モデル、レンダリング、プラットフォーム サポート、一般的な使用例の観点から両者を比較します。また、Open XML SDK は基本的な PPTX 操作や OOXML 要素への直接アクセスに適しているのに対し、Aspose.Slides は複数の PowerPoint 形式の取り扱い、シェイプのコピーやクローン、テキストの置換、アニメーションの適用、プレゼンテーションを PDF、TIFF、XPS に変換するなど、複雑なプレゼンテーション タスクにより適していることを明らかにします。

## **Open XML SDK とは何か？**
[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)によると、Open XML SDK は次のように定義されています。

Open XML SDK 2.0 は、Open XML パッケージとパッケージ内の基礎となる Open XML スキーマ要素を操作する作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージ上で実行する多くの一般的なタスクをカプセル化し、数行のコードだけで複雑な操作を実行できるようにします。

OOXML ドキュメントは本質的に zip された XML ファイルであり、Open XML SDK は OOXML ドキュメントの内容を強く型付けされた方法で操作できるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、DOM ツリーに読み込んで XML 要素や属性を直接操作する代わりに、Open XML SDK がそれらのクラスを提供します。

## **Aspose.Slides とは何か？**
Aspose.Slides は、アプリケーションが以下のプレゼンテーション処理タスクを実行できるようにするクラス ライブラリです。

- **Presentation** オブジェクト モデルによるプログラミング。
- PDF、XPS、TIFF への変換を含む、すべての一般的にサポートされている PowerPoint プレゼンテーション形式間での高品質な変換。
- PNG、JPEG、BMP などの一般的な形式でのスライド サムネイル生成、および SVG へのスライド エクスポート。
- 1 つまたは複数のドキュメントから組み合わせて、ゼロからプレゼンテーションを作成。
- アニメーション、Ole フレーム、テーブル、チャートの作成と管理のサポート。
- TextFrames、Paragraph、Portion レベルでのテキスト書式設定を詳細に管理できる広範なコントロール。

機能の詳細については、[Aspose.Slides Features](/slides/ja/php-java/product-overview/)をご覧ください。

## **Open XML SDK と Aspose.Slides の比較**
{{% alert color="info" %}} 
以下の表は Open XML SDK と Aspose.Slides の機能を比較したものです。
{{% /alert %}} 

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|いいえ|はい|
|<p>プレゼンテーション ドキュメント オブジェクト モデル (DOM) を使用した高レベルのプログラミング:</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|いいえ|はい|
|TextHolders、TextFrames、Paragraph、Portion などの個々の要素や書式設定にアクセスできる、ドキュメントオブジェクトモデルを使用した詳細なプログラミング。|はい|はい|
|OOXML ドキュメントのリレーションシップ識別子やリスト識別子など、基礎となる XML 要素や属性への低レベルかつ直接的なフルアクセス。|はい|いいえ|
|<p>レンダリング:</p><p>- プレゼンテーションを PDF、PDF Notes、XPS、TIFF 画像に変換。</p><p>- スライドサムネイルを PNG、JPEG、BMP、SVG、TIFF に変換。</p><p>- 画像解像度、品質、圧縮、その他のオプションを指定。</p>|いいえ|はい |
|サポートプラットフォーム|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **結論**
{{% alert color="info" %}} 

Open XML SDK と Aspose.Slides は、対象とするニーズとユーザー層がかなり異なるため、正面から直接競合するものではありません。Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作するためのクラス ライブラリです。Aspose.Slides は、ほぼすべての Microsoft PowerPoint ファイル形式をサポートし、非常に有用なプレゼンテーション処理ライブラリです。

もし必要なのが PPTX ドキュメントに対する比較的基本的なプログラミング操作だけであれば、Open XML SDK が適切な選択になるでしょう。Open XML SDK を使用すれば、シンプルな PPTX ドキュメントの生成やコメント・ヘッダー/フッターの削除、画像の抽出などの簡単なタスクを十分に快適に実行できます。Open XML SDK で達成できるタスクもありますが、Aspose.Slides では実現できないものもあります。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。しかし、以下のような複雑な操作が必要な場合は、Aspose.Slides が最適な選択です。

- PPTX に加えて古い PowerPoint 形式もサポート。
- スライド内のシェイプをオブジェクト、スタイル、書式を組み合わせて適切にコピーまたはクローン。
- 書式付きまたは書式なしテキストの置換。
- アニメーションの適用とシェイプ間コネクタの使用。
- ドキュメントを PDF、TIFF、XPS に変換し、Microsoft PowerPoint が変換したときと同じ外観にする。
- デスクトップ環境および Web 環境の両方で .NET または Java アプリケーションを開発。

{{% /alert %}}