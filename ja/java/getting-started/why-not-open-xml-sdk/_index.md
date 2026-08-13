---
title: Open XML SDKはなぜ選ばれないのか
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
description: "Aspose.Slidesが無料のOpen XML SDKよりも優れた選択である理由をご覧ください：機能比較、オートメーション不要の変換、PPT、PPTX、ODPの幅広いサポート。"
---
## **概要**

このドキュメントでは、開発者がプレゼンテーション ドキュメントを操作する際に Open XML SDK と Aspose.Slides のどちらを選択すべきかを説明します。Open XML SDK は OOXML パッケージとその基礎となる XML 要素を操作するためのライブラリとして紹介され、Aspose.Slides は高度なオブジェクト モデルと多数の PowerPoint 関連タスクをサポートするプレゼンテーション処理ライブラリとして提示されます。

本稿では、サポート形式、プログラミング モデル、レンダリングおよび印刷機能、プラットフォーム サポート、一般的な使用シナリオの観点から両者を比較します。また、Open XML SDK が基本的な PPTX 操作や OOXML 要素への直接アクセスに適しているのに対し、Aspose.Slides は複数の PowerPoint 形式の取り扱い、シェイプのコピーやクローン作成、テキスト置換、アニメーション適用、PDF、TIFF、XPS への変換など、複雑なプレゼンテーション タスクにより適していることを明確にします。

## **Open XML SDK とは？**
[MSDN ライブラリ](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)によれば、Open XML SDK は次のように定義されています。

Open XML SDK 2.0 は、Open XML パッケージとパッケージ内の基礎となる Open XML スキーマ要素の操作タスクを簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージで頻繁に行う多くの一般的タスクをカプセル化し、数行のコードで複雑な操作を実行できるようにします。

OOXML ドキュメントは本質的に圧縮された XML ファイルであり、Open XML SDK は OOXML ドキュメントの内容を強く型付けされた方法で操作できるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、DOM ツリーにロードして XML 要素や属性を直接操作する代わりに、Open XML SDK がそれらのクラスを提供します。

## **Aspose.Slides とは？**
Aspose.Slides は、アプリケーションが次のプレゼンテーション処理タスクを実行できるようにするクラス ライブラリです。

- **Presentation** オブジェクト モデルを使用したプログラミング。
- PDF、XPS、TIFF を含むすべての主要な PowerPoint プレゼンテーション形式間の高品質変換。
- PNG、JPEG、BMP などの一般的な形式でスライド サムネイルを生成し、SVG へのエクスポートも可能。
- ドキュメントをゼロから作成するか、1 つまたは複数のドキュメントを組み合わせてプレゼンテーションを構築。
- アニメーション、Ole フレーム、テーブル、チャートの作成と管理をサポート。
- TextFrames、Paragraphs、Portions レベルでのテキスト書式設定を詳細に制御可能。

機能の詳細については、[Aspose.Slides の機能](/slides/ja/java/product-overview/)をご覧ください。

## **Open XML SDK と Aspose.Slides の比較**
{{% alert color="info" %}} 

以下の表は Open XML SDK と Aspose.Slides の機能を比較したものです。

{{% /alert %}} 

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|No|Yes|
|<p>プレゼンテーション ドキュメント オブジェクト モデル (DOM) を使用した高水準プログラミング:</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|No|Yes|
|ドキュメント オブジェクト モデルを使用した詳細なプログラミングで、TextHolders、TextFrames、Paragraphs、Portions などの個々の要素や書式設定にアクセスできる。|Yes|Yes|
|OOXML ドキュメントのリレーションシップ識別子、リスト識別子など、基礎となる XML 要素や属性への低レベルの直接かつ完全なアクセス。|Yes|No|
|<p>レンダリング:</p><p>- プレゼンテーションを PDF、PDF Notes、XPS、TIFF 画像にレンダリングする。</p><p>- スライドサムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリングする。</p><p>- 画像の解像度、品質、圧縮、その他のオプションを指定できる。</p>|No|Yes|
|サポートされているプラットフォーム|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **結論**
{{% alert color="info" %}} 

Open XML SDK と Aspose.Slides は、対象とするニーズと利用者層が大きく異なるため、正面から競合するものではありません。Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作するためのクラス ライブラリであり、Aspose.Slides はほぼすべての Microsoft PowerPoint ファイル形式をサポートする非常に有用なプレゼンテーション処理ライブラリです。

もし行う作業が PPTX ドキュメントに対する比較的基本的なプログラミング操作だけであれば、Open XML SDK が適切な選択となるでしょう。Open XML SDK を使用すれば、シンプルな PPTX ドキュメントの生成やコメント・ヘッダー/フッターの除去、画像の抽出などの単純タスクを快適に実行できます。いくつかのタスクは Open XML SDK で実現可能ですが、Aspose.Slides では実現できません。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。しかし、以下のような複雑な操作が必要な場合は、Aspose.Slides が最適です。

- PPTX に加えて旧式の PowerPoint 形式もサポートする。
- スライド内のシェイプをコピーまたはクローンし、オブジェクト、スタイル、書式設定を適切に組み合わせる。
- 書式付きまたは書式なしテキストを置換する。
- アニメーションを適用し、シェイプ間のコネクタを使用する。
- ドキュメントを PDF、TIFF、XPS に変換し、Microsoft PowerPoint と同等の外観にする。
- デスクトップおよび Web ベースの環境で .NET または Java アプリケーションを開発する。

{{% /alert %}}