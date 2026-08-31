---
title: Open XML SDK を使わない理由
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
description: "Aspose.Slides が無料の Open XML SDK より優れた選択肢である理由をご覧ください：機能比較、手動不要の変換、PPT、PPTX、ODP の幅広いサポート。"
---
## **概要**

この記事では、開発者がプレゼンテーション ドキュメントの操作に Open XML SDK または Aspose.Slides を選択する場合について説明します。Open XML SDK は OOXML パッケージとその基礎となる XML 要素を操作するためのライブラリとして紹介され、Aspose.Slides は高レベルのオブジェクト モデルと多数の PowerPoint 関連タスクをサポートするプレゼンテーション 処理ライブラリとして提示されます。

この記事では、サポート形式、プログラミング モデル、レンダリング、プラットフォーム サポート、一般的な使用例という観点から両者を比較します。また、Open XML SDK は基本的な PPTX 操作や OOXML 要素への直接アクセスに適しているのに対し、Aspose.Slides は複数の PowerPoint 形式の操作、シェイプのコピーやクローン、テキストの置換、アニメーションの適用、プレゼンテーションの PDF、TIFF、XPS への変換など、複雑なプレゼンテーション タスクにより適していることを明確にします。

## **Open XML SDK とは？**
[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)によると、Open XML SDK は次のように定義されています。

Open XML SDK 2.0 は、Open XML パッケージとその基礎となる Open XML スキーマ要素を操作する作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージで実行する多くの一般的なタスクをカプセル化し、数行のコードだけで複雑な操作を実行できるようにします。

OOXML ドキュメントは本質的に圧縮された XML ファイルであり、Open XML SDK は OOXML ドキュメントの内容を強く型付けされた方法で操作できるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、XML を DOM ツリーにロードして要素や属性を直接操作する代わりに、Open XML SDK はそれらを行うクラスを提供します。

## **Aspose.Slides とは？**
Aspose.Slides は、アプリケーションが以下のプレゼンテーション処理タスクを実行できるようにするクラス ライブラリです。

- **Presentation** オブジェクト モデルによるプログラミング。
- PDF、XPS、TIFF を含む、すべての一般的な PowerPoint プレゼンテーション形式間での高品質変換。
- PNG、JPEG、BMP などの一般的な形式でのスライド サムネイル生成と、SVG へのスライド エクスポート。
- 0 からプレゼンテーションを作成するか、1 つまたは複数のドキュメントを組み合わせて作成。
- アニメーション、Ole フレーム、テーブルの追加、チャートの作成と管理のサポート。
- TextFrames、Paragraphs、Portions レベルでのテキスト書式設定を管理するための詳細なコントロール。

機能の詳細については、[Aspose.Slides Features](/slides/ja/java/product-overview/) をご覧ください。

## **Open XML SDK と Aspose.Slides の比較**
{{% alert color="info" %}} 

以下の表は Open XML SDK と Aspose.Slides の機能を比較しています。

{{% /alert %}} 

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|いいえ|はい|
|<p>プレゼンテーション ドキュメント オブジェクト モデル (DOM) を使用した高レベル プログラミング：</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|いいえ|はい|
|テキストホルダー、テキストフレーム、段落、ポーションなどの個別要素や書式設定にアクセスできる、ドキュメント オブジェクト モデルを使用した詳細なプログラミング。|はい|はい|
|OOXML ドキュメントのリレーションシップ識別子、リスト識別子など、基礎となる XML 要素や属性への低レベルの直接かつ完全なアクセス。|はい|いいえ|
|<p>レンダリング：</p><p>- プレゼンテーションを PDF、PDF ノート、XPS、TIFF 画像にレンダリングする。</p><p>- スライドサムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリングする。</p><p>- 画像解像度、品質、圧縮、その他のオプションを指定できる。</p>|いいえ|はい |
|サポートプラットフォーム|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **結論**
{{% alert color="info" %}} 

Open XML SDK と Aspose.Slides は、対象とするニーズとユーザー層がかなり異なるため、正面から競合するわけではありません。Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作するためのクラス ライブラリです。Aspose.Slides は、ほぼすべての Microsoft PowerPoint ファイル形式に対して優れたサポートを提供する、非常に有用なプレゼンテーション処理ライブラリです。

もし必要なのが PPTX ドキュメントに対する比較的基本的なプログラミング操作だけであれば、Open XML SDK が適切な選択となるでしょう。Open XML SDK を使用すれば、シンプルな PPTX ドキュメントの生成やコメント・ヘッダー/フッターの削除、画像の抽出などの簡単なタスクを快適に実行できます。いくつかのタスクは Open XML SDK で実現可能ですが、Aspose.Slides では実現できません。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。しかし、次のような複雑な操作が必要な場合は、Aspose.Slides が最適な選択です。

- PPTX に加えて古い PowerPoint 形式もサポートする。
- スライド内のシェイプをオブジェクト、スタイル、書式設定を適切に組み合わせてコピーまたはクローンする。
- 書式設定済みまたは未書式のテキストを置換する。
- アニメーションを適用し、シェイプ間のコネクタを使用する。
- ドキュメントを PDF、TIFF、XPS に変換し、Microsoft PowerPoint と同様の外観にする。
- デスクトップおよび Web ベースの環境の両方で .NET または Java アプリケーションを開発する。

{{% /alert %}}