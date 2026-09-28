---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /ja/net/
keywords:
- ドキュメント
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "ここから始めましょう: Aspose.Slides for .NET をインストールし、最初のプレゼンテーションを作成し、共通タスク、導入、API リファレンスに関するガイドを見つけてください。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET は、Microsoft PowerPoint や Office Automation を使用せずに、.NET アプリケーションで PowerPoint および OpenDocument プレゼンテーションの作成、読み取り、編集、変換を行うクラス ライブラリです。

マクロ対応やテンプレート バージョンを含む PPT、PPTX、PPS、POT、ODP を読み込み・保存でき、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>開始ガイド</p>
<ul>
<li><a href="/slides/ja/net/installation/">インストール</a></li>
<li><a href="/slides/ja/net/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/net/system-requirements/">システム要件</a></li>
<li><a href="/slides/ja/net/getting-started/">開始ガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/net/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/net/features-overview/">機能の概要</a></li>
<li><a href="/slides/ja/net/evaluate-aspose-slides/">試用版の制限</a></li>
<li><a href="/slides/ja/net/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>共通タスク</p>
<ul>
<li><a href="/slides/ja/net/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/net/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/net/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/net/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/net/manage-text/">テキストと図形を編集</a></li>
</ul>
<p>Slides ワークフロー</p>
<ul>
<li><a href="/slides/ja/net/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/net/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/net/manage-media-files/">音声と動画</a></li>
<li><a href="/slides/ja/net/presentation-design/">スライド デザイン</a></li>
<li><a href="/slides/ja/net/merge-presentation/">プレゼンテーションの結合</a></li>
</ul>
<p>サンプル</p>
<ul>
<li><a href="/slides/ja/net/examples/">スライド要素別のサンプル</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub 上のサンプル</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>導入とサポート</b></p>
<hr>
<p>導入</p>
<ul>
<li><a href="/slides/ja/net/net6/">クロスプラットフォーム (.NET 6+)</a></li>
<li><a href="/slides/ja/net/how-to-run-aspose-slides-in-docker/">Docker で実行</a></li>
<li><a href="/slides/ja/net/deploy-fonts/">フォント</a></li>
<li><a href="/slides/ja/net/security/">セキュリティ</a></li>
</ul>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ja/net/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/ja/net/release-notes/">リリースノート</a></li>
<li><a href="/slides/ja/net/known-issues/">既知の問題</a></li>
<li><a href="/slides/ja/net/api-limitations/">出力メタデータの制限</a></li>
<li><a href="https://releases.aspose.com/slides/ja/net/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ja/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **最初のプレゼンテーション**

.NET SDK 6 以降を使用してコンソール アプリケーションを作成します：

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

次に、プラットフォーム用のパッケージを 1 つ追加します：

- Windows の場合: `dotnet add package Aspose.Slides.NET`
- Linux および macOS の場合: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — Linux の前提条件や Aspose.Slides.NET が必要なシステムについては、[Installation](/slides/ja/net/installation/) を参照してください。

*Program.cs* の内容を次のコードに置き換えて、`dotnet run` を実行します：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

このプログラムはテキスト ボックスを含む 1 枚のスライドを持つ *hello.pptx* を保存します。ライセンスがない場合、保存されたファイルには評価用の透かしが入ります — 詳細は [Licensing](/slides/ja/net/licensing/) を参照してください。プレゼンテーションの作成や内容の設定に関する他の方法については、[Create Presentations](/slides/ja/net/create-presentation/) をご覧ください。