---
title: なぜ Open XML SDK ではないのか
type: docs
weight: 120
url: /ja/php-java/why-not-open-xml-sdk/
---

{{% alert color="primary" %}} 

私たちは時々次の質問を耳にします:

**なぜ無料の Open XML SDK ではなく、Aspose 製品を使用すべきなのでしょうか？**

この質問には簡単に答えられます: **機能と機能性**。

{{% /alert %}} 
## **Open XML SDK とは？**
[MSDN ライブラリ](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)によると、Open XML SDK は次のように定義されています： 

Open XML SDK 2.0 は、Open XML パッケージやその内部の Open XML スキーマ要素を操作する作業を簡素化します。Open XML SDK 2.0 は、開発者が Open XML パッケージに対して実行する多くの一般的なタスクをカプセル化しているため、数行のコードで複雑な操作を実行できます。

OOXML 文書は本質的に圧縮された XML ファイルであり、Open XML SDK は OOXML 文書の内容を強い型付けで操作するためのクラスのコレクションです。つまり、ファイルを展開して XML を抽出し、その XML を DOM ツリーにロードして XML 要素や属性を直接操作する代わりに、Open XML SDK はそのためのクラスを提供しています。
## **Aspose.Slides とは？**
Aspose.Slides は、アプリケーションが次のプレゼンテーション処理タスクを実行できるようにするクラスライブラリです：

- **プレゼンテーション**オブジェクトモデルでのプログラミング。
- PDF、XPS、TIFF への変換を含むすべての人気のある PowerPoint プレゼンテーション形式の高品質な変換。
- PNG、JPEG、BMP などのよく知られた形式でスライドサムネイルを生成する能力、および SVG へのスライドエクスポート。
- スライドをゼロから作成する能力や、1 つまたは複数のドキュメントを組み合わせてプレゼンテーションを構築する能力。
- アニメーション、Ole フレーム、テーブルの追加、チャートの作成と管理のサポート。
- テキストフレーム、段落、部分レベルでのテキストフォーマット管理に関する広範なコントロールの利用可能性。

サポートされている機能の詳細については、[Aspose.Slides 機能](/slides/ja/php-java/product-overview/)をご覧ください。
## **Open XML SDK と Aspose.Slides の比較**
{{% alert color="primary" %}} 

以下の表は、Open XML SDK と Aspose.Slides の機能を比較しています。

{{% /alert %}} 

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|いいえ|はい|
|<p>プレゼンテーションドキュメントオブジェクトモデル（DOM）による高レベルのプログラミング:</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|いいえ|はい|
|ドキュメントオブジェクトモデルでの詳細なプログラミング、個々の要素やフォーマット（TextHolders、TextFrames、Paragraphs、Portionsなど）へのアクセス。|はい|はい|
|OOXML ドキュメントの関係識別子、リスト識別子などの基本的な XML 要素や属性への低レベルで直接的かつ完全なアクセス。|はい|いいえ|
|<p>レンダリング:</p><p>- プレゼンテーションを PDF、PDF ノート、XPS、TIFF 画像にレンダリングします。</p><p>- スライドサムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリングします。</p><p>- 画像の解像度、品質、圧縮、およびその他のオプションを指定できます。</p>|いいえ|はい |
|サポートされているプラットフォーム|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|
## **結論**
{{% alert color="primary" %}} 

Open XML SDK と Aspose.Slides は、非常に異なるニーズやオーディンスに対応しているため、直接競争することはありません。Open XML SDK は、OOXML ドキュメントを扱うための強い型付けの方法を提供するクラスライブラリです。Aspose.Slides は、ほぼすべての Microsoft PowerPoint ファイル形式を広範にサポートする非常に便利なプレゼンテーション処理ライブラリです。

もし、あなたが PPTX ドキュメントでのかなり基本的なプログラミング操作を行う必要があるだけなら、Open XML SDK は適切な選択かもしれません。Open XML SDK を使えば、単純な PPTX ドキュメントを生成したり、コメント、ヘッダー/フッターを削除したり、画像を抽出したりするような単純な作業をかなり快適に行うことができます。Open XML SDK で実現可能だが、Aspose.Slides では実現できない作業もあります。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用するべきです。しかし、次のタスクのようにドキュメントに対して複雑な操作を実行する必要がある場合は、Aspose.Slides を使用することが最適な選択肢です：

- PPTX に加えて古い PowerPoint 形式をサポートする。
- スライド内の図形を適切にオブジェクト、スタイル、その他のフォーマットを組み合わせる方法でコピーまたは複製する。
- フォーマットされたテキストまたはフォーマットされていないテキストを置き換える。
- アニメーションを適用し、使用される図形にコネクタを使用する。
- ドキュメントを PDF、TIFF、または XPS に変換し、Microsoft PowerPoint が変換したように正確に表示されるようにする。
- デスクトップおよびウェブベースの環境の両方で .NET または Java アプリケーションを開発する。

{{% /alert %}}