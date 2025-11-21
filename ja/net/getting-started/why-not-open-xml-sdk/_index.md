---
title: なぜ Open XML SDK ではないのか
type: docs
weight: 50
url: /ja/net/why-not-open-xml-sdk/
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
description: "Aspose.Slides が無料の Open XML SDK よりも優れた選択肢である理由：機能比較、変換の自動化不要、PPT、PPTX、ODP の幅広いサポートを紹介。"
---

## **Open XML SDK とは？**
時々、次のような質問を受けます: *なぜ無料の Open XML SDK ではなく Aspose 製品を使用すべきなのでしょうか？*  

この質問には、機能や性能の観点から簡単に答えることができます。  

[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) によると、Open XML SDK は以下のように定義されています：

> "Open XML SDK 2.0 は、Open XML パッケージとパッケージ内部の基礎となる Open XML スキーマ要素を操作する作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージ上で実行する多くの共通タスクをカプセル化しており、数行のコードだけで複雑な操作を行えるようにします。OOXML ドキュメントは本質的に ZIP 圧縮された XML ファイルであり、Open XML SDK は OOXML ドキュメントの内容を強く型付けされた方法で扱えるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、その XML を DOM ツリーに読み込んで XML 要素や属性を直接操作する代わりに、Open XML SDK がそれらを行うクラスを提供します。"

## **Aspose.Slides とは？**
Aspose.Slides は、アプリケーションが以下のプレゼンテーション処理タスクを実行できるクラス ライブラリです:

- プレゼンテーション オブジェクト モデルでのプログラミング。
- PDF、XPS、TIFF への変換や印刷を含む、すべての一般的な PowerPoint プレゼンテーション フォーマットをサポートする高品質な変換。
- PNG、JPEG、BMP などの一般的な形式でスライドのサムネイルを生成し、SVG へのエクスポートも可能。
- 新規にプレゼンテーションを作成するか、1 つまたは複数のドキュメントから要素を組み合わせて構築する。
- アニメーション、OLE フレーム、テーブルの追加、およびチャートの作成と管理。
- TextFrames、Paragraph、Portion レベルでのテキスト書式設定を包括的に制御・管理。

利用可能な機能の詳細については、[Aspose.Slides Features](/slides/ja/net/product-overview/) ページをご覧ください。

## **Open XML SDK と Aspose.Slides の比較**
|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|No|Yes|
|<p>Presentation Document Object Model (DOM) を使用した高レベルのプログラミング:</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドの組み立て。</p>|No|Yes|
|ドキュメント オブジェクト モデルを用いた詳細なプログラミング; TextHolders、TextFrames、Paragraph、Portion などの個別要素や書式へのアクセス。|Yes|Yes|
|基礎となる XML 要素や属性（リレーションシップ識別子、OOXML ドキュメントのリスト識別子など）への低レベルで直接かつ完全なアクセス。|Yes|No|
|<p>レンダリングおよび印刷:</p><p>- プレゼンテーションを PDF、PDF Notes、XPS、TIFF 画像にレンダリング。</p><p>- スライドのサムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリング。</p><p>- 画像の解像度、品質、圧縮その他のオプションを指定。</p><p>- .NET の印刷基盤を使用してプレゼンテーションを印刷。コンポーネントには、MS PowerPoint の印刷プレビューに表示されるようにプレゼンテーションを印刷する組み込みの印刷メソッドがあります。</p>|No|Yes|
|サポートプラットフォーム|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**
Open XML SDK と Aspose.Slides は、対象とするニーズやオーディエンスが大きく異なるため、直接競合するものではありません。

{{% alert color="primary" %}} 
Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作できるクラス ライブラリであり、Aspose.Slides はほぼすべての Microsoft PowerPoint ファイル形式を幅広くサポートする、非常に有用なプレゼンテーション処理ライブラリです。 
{{% /alert %}} 

もしワークフローが PPTX ドキュメントに対する基本的なプログラミング操作である場合、Open XML SDK が適した選択肢になることがあります。Open XML SDK を使用すれば、簡単な PPTX ドキュメントの生成やコメント・ヘッダー/フッターの削除、画像の抽出などのシンプルなタスクを快適に実行できます。特定のタスクは Open XML SDK で実行できても Aspose.Slides では実行できません。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。

ドキュメントに対して複雑なタスクを実行する必要がある場合（以下のリストのようなタスク）は、Aspose.Slides が最適な選択肢です。

- 古い PowerPoint 形式（および PPTX）に関わる操作。
- スライド内のシェイプをコピーまたはクローンし、オブジェクト、スタイル、その他の書式要素を適切に組み合わせる方法。
- 書式付きまたは書式なしテキストの置換。
- アニメーションの適用やシェイプ間のコネクタ使用。
- ドキュメントを PDF、TIFF、XPS に変換し、Microsoft PowerPoint が変換したかのような結果を得る。
- .NET または Java アプリケーションをデスクトップおよび Web 環境の両方で開発する。