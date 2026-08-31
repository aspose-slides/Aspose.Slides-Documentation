---
title: Open XML SDK を使わない理由
type: docs
weight: 100
url: /ja/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 比較
- プレゼンテーション オブジェクト モデル
- 高品質変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides が無料の Open XML SDK より優れた選択肢である理由をご覧ください：機能比較、オートメーション不要の変換、PPT、PPTX、ODP の広範なサポート"
---
## **概要**

この記事では、開発者がプレゼンテーション文書の操作に Open XML SDK と Aspose.Slides のどちらを選択すべきかのケースを説明します。Open XML SDK は OOXML パッケージとその基礎となる XML 要素を操作するためのライブラリとして説明され、Aspose.Slides は高レベルのオブジェクトモデルと多数の PowerPoint 関連タスクをサポートするプレゼンテーション処理ライブラリとして提示されます。

この記事は、サポート形式、プログラミングモデル、レンダリング、プラットフォームサポート、一般的なユースケースに基づいて両方のオプションを比較します。また、Open XML SDK は基本的な PPTX 操作や OOXML 要素への直接アクセスに適している可能性がある一方で、Aspose.Slides は複数の PowerPoint 形式の処理、シェイプのコピーやクローン、テキストの置換、アニメーションの適用、PDF・TIFF・XPS への変換など、複雑なプレゼンテーションタスクにより適していることを明確にします。

## **Open XML SDK とは何か？**
私たちは時々この質問を耳にします: なぜ無料の Open XML SDK ではなく Aspose 製品を使用すべきなのでしょうか? この質問への答えは簡単です: 機能と機能性です。 [MSDNライブラリ](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) によると、Open XML SDK は次のように定義されています: Open XML SDK 2.0 は Open XML パッケージとその内部の Open XML スキーマ要素の操作タスクを簡素化します。Open XML SDK 2.0 は開発者が Open XML パッケージ上で行う多くの共通タスクをカプセル化し、数行のコードだけで複雑な操作を実行できるようにします。OOXML ドキュメントは本質的に zip 圧縮された XML ファイルであり、Open XML SDK は OOXML ドキュメントの内容を強く型付けされた方法で操作できるクラスのコレクションです。つまり、ファイルを解凍して XML を抽出し、その XML を DOM ツリーにロードして XML 要素や属性を直接操作する代わりに、Open XML SDK はそれらを行うクラスを提供します。

## **Aspose.Slides とは何か？**
Aspose.Slides は、アプリケーションが以下のプレゼンテーション処理タスクを実行できるようにするクラスライブラリです。

- **Presentation** オブジェクトモデルを使用したプログラミング。
- PDF や XPS への変換を含む、すべての一般的なサポート対象 PowerPoint プレゼンテーション形式間での高品質な変換。
- PNG、JPEG、BMP などの一般的な形式でスライドサムネイルを生成し、SVG へのスライドエクスポートも可能。
- プレゼンテーションをゼロから作成するか、1つまたは複数のドキュメントを組み合わせて構築する機能。
- アニメーション、Ole フレーム、テーブルの追加、チャートの作成と管理のサポート。
- TextFrames、Paragraph、Portion のレベルでテキスト書式設定を管理するための広範な制御が利用可能。

サポートされている機能の詳細については、[Aspose.Slidesの機能](/slides/ja/cpp/product-overview/) をご覧ください。

## **Open XML SDK と Aspose.Slides の比較**
以下の表は Open XML SDK と Aspose.Slides の機能を比較したものです。

|**機能または機能カテゴリ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|サポートされているプレゼンテーション形式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT から PPTX への変換|No|Yes|
|<p>Presentation Document Object Model (DOM) を使用した高レベルのプログラミング:</p><p>- テキストの検索と置換。</p><p>- プレゼンテーション内のスライドを組み立てる。</p>|No|Yes|
|テキストホルダー、テキストフレーム、段落、ポーションなどの個々の要素や書式にアクセスできる、ドキュメントオブジェクトモデルを使用した詳細なプログラミング。|Yes|Yes|
|リレーションシップ識別子や OOXML ドキュメントのリスト識別子など、基礎となる XML 要素や属性への低レベルで直接かつ完全なアクセス。|Yes|No|
|<p>レンダリング:</p><p>- プレゼンテーションを PDF、PDF ノート、XPS、TIFF 画像にレンダリング。</p><p>- スライドサムネイルを PNG、JPEG、BMP、SVG、TIFF にレンダリング。</p><p>- 画像の解像度、品質、圧縮その他のオプションを指定。</p>|No|Yes|

## **結論**
Open XML SDK と Aspose.Slides は、対象とするニーズと対象ユーザーが大きく異なるため、正面から競合するものではありません。Open XML SDK は OOXML ドキュメントを強く型付けされた方法で操作するためのクラスライブラリです。Aspose.Slides は、ほぼすべての Microsoft PowerPoint ファイル形式に対して優れたサポートを提供する非常に有用なプレゼンテーション処理ライブラリです。もし行う必要があるのが PPTX ドキュメントに対するかなり基本的なプログラミング操作だけであれば、Open XML SDK が適切な選択となるでしょう。Open XML SDK を使用すれば、シンプルな PPTX ドキュメントの生成やコメント・ヘッダー/フッターの削除、画像の抽出などの簡単なタスクを快適に行うことができます。あるタスクは Open XML SDK で実現可能ですが、Aspose.Slides では実現できません。たとえば、OOXML ドキュメントの XML 要素や属性に直接アクセスする必要がある場合は、Open XML SDK を使用すべきです。一方、以下のような複雑な操作をドキュメント上で実行する必要がある場合は、Aspose.Slides が最適な選択肢です。

- PPTX に加えて、古い PowerPoint 形式のサポート。
- スライド内のシェイプをコピーまたはクローンし、オブジェクト、スタイル、その他の書式設定を適切に組み合わせる方法。
- 書式付きまたは書式なしテキストの置換。
- アニメーションの適用やシェイプ間コネクタの使用。
- ドキュメントを PDF または XPS に変換し、Microsoft PowerPoint が変換したときと同じ外観にする。
- デスクトップおよびコンソール環境の両方で C++ アプリケーションを開発すること。