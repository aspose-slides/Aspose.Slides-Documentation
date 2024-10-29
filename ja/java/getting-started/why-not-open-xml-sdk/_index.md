---
title: Open XML SDKを使用しない理由
type: docs
weight: 120
url: /ja/java/why-not-open-xml-sdk/
---

{{% alert color="primary" %}} 

この質問を時々耳にします：

**なぜ無料のOpen XML SDKではなく、Aspose製品を使用すべきでしょうか？**

この質問には簡単に答えられます：**機能と機能性**。

{{% /alert %}} 
## **Open XML SDKとは？**
[MSDNライブラリ](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)によると、Open XML SDKは次のように定義されています：

Open XML SDK 2.0は、Open XMLパッケージの操作と、そのパッケージ内の基礎となるOpen XMLスキーマ要素の操作を簡素化します。Open XML SDK 2.0は、開発者がOpen XMLパッケージで実行する多くの共通タスクをカプセル化しているため、数行のコードで複雑な操作を実行できます。

OOXMLドキュメントは本質的にZIP形式のXMLファイルであり、Open XML SDKは、OOXMLドキュメントの内容を強タイプの方法で操作することを可能にするクラスのコレクションです。つまり、ファイルを解凍してXMLを抽出し、そのXMLをDOMツリーに読み込み、XML要素や属性を直接扱う代わりに、Open XML SDKはそれを行うためのクラスを提供します。
## **Aspose.Slidesとは？**
Aspose.Slidesは、アプリケーションが次のプレゼンテーション処理タスクを実行できるようにするクラスライブラリです：

- **Presentation**オブジェクトモデルでのプログラミング。
- PDF、XPSおよびTIFFへの変換を含む、すべての人気のあるサポートPowerPointプレゼンテーション形式間の高品質な変換。
- PNG、JPEG、BMPなどの一般的な形式でのスライドサムネイルの生成と、SVGへのスライドエクスポート。
- 一からプレゼンテーションを構築する能力、または1つまたは複数のドキュメントを組み合わせることによる。
- アニメーション、Oleフレーム、テーブルの追加、チャートの作成と管理のサポート。
- TextFrames、段落、部分レベルでのテキストフォーマッティングを管理するための広範な制御の利用可能性。

サポートされている機能の詳細については、[Aspose.Slidesの機能](/slides/ja/java/product-overview/)をご覧ください。
## **Open XML SDKとAspose.Slidesの比較**
{{% alert color="primary" %}} 

以下の表は、Open XML SDKとAspose.Slidesの機能を比較しています。

{{% /alert %}} 

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT、POT、PPS、PPTX、POTX、PPSX、ODP|
|PPTからPPTXへの変換|いいえ|はい|
|<p>プレゼンテーションドキュメントオブジェクトモデル（DOM）を使用した高レベルプログラミング :</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|いいえ|はい|
|個々の要素やフォーマット（TextHolders、TextFrames、段落及び部分など）へのアクセスを持つ詳細なドキュメントオブジェクトモデルによるプログラミング。|はい|はい|
|OOXMLドキュメントの基礎となるXML要素および属性への低レベルで直接的かつ完全なアクセス。|はい|いいえ|
|<p>レンダリング :</p><p>- プレゼンテーションをPDF、PDFノート、XPS、TIFF画像にレンダリングする。</p><p>- スライドサムネイルをPNG、JPEG、BMP、SVGおよびTIFFにレンダリングする。</p><p>- 画像の解像度、品質、圧縮およびその他のオプションを指定する。</p>|いいえ|はい|
|サポートされているプラットフォーム|Windows、.NET|Windows、Linux、UNIX、MAC、Java、PHP、Mono|
## **結論**
{{% alert color="primary" %}} 

Open XML SDKとAspose.Slidesは、異なるニーズとターゲットを対象としているため、直接競合することはありません。Open XML SDKは、OOXMLドキュメントを扱うための強タイプの方法を提供するクラスライブラリです。Aspose.Slidesは、ほぼすべてのMicrosoft PowerPointファイル形式をサポートする非常に便利なプレゼンテーション処理ライブラリです。

PPTXドキュメントで比較的基本的なプログラミング操作を行うだけであれば、Open XML SDKは適切な選択かもしれません。Open XML SDKを使用すれば、単純なPPTXドキュメントを生成したり、コメント、ヘッダー/フッターを削除したり、画像を抽出したりするような簡単なタスクを快適に実行できます。一部のタスクはOpen XML SDKで達成できますが、Aspose.Slidesでは達成できません。たとえば、OOXMLドキュメントのXML要素や属性に直接アクセスする必要がある場合、Open XML SDKを使用するべきです。しかし、ドキュメントに複雑な操作を行う必要がある場合（以下のようなタスクなど）、Aspose.Slidesを使用することが最適な選択です：

- PPTXの他に、古いPowerPoint形式をサポートする。
- スライド内の形状を適切な方法でオブジェクト、スタイルやその他のフォーマットを組み合わせる方法でコピーまたは複製する。
- 書式付きまたは書式なしのテキストを置き換える。
- 使用する形状にアニメーションを適用し、コネクタを使用する。
- 文書をPDF、TIFFまたはXPSに変換し、Microsoft PowerPointが変換した内容と全く同じに見えるようにする。
- デスクトップおよびWebベースの環境で.NETまたはJavaアプリケーションを開発する。

{{% /alert %}}