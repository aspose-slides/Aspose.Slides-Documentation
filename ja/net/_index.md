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
description: "ここから始めましょう：Aspose.Slides for .NET をインストールし、最初のプレゼンテーションを作成し、一般的なタスクのガイド、API リファレンス、サポート情報を確認してください。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET は、Microsoft PowerPoint や Office Automation を使用せずに、.NET アプリケーションで PowerPoint および OpenDocument プレゼンテーションを作成、読み取り、編集、変換するためのクラス ライブラリです。

マクロ対応およびテンプレート バリアントを含む PPT、PPTX、PPS、POT、ODP を読み込み・保存し、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートできます。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>開始手順</p>
<ul>
<li><a href="/slides/ja/net/installation/">インストール</a></li>
<li><a href="/slides/ja/net/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/net/getting-started/">開始ガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/net/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/net/evaluate-aspose-slides/">試用版の制限</a></li>
<li><a href="/slides/ja/net/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>一般的なタスク</p>
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
<p>例</p>
<ul>
<li><a href="/slides/ja/net/examples/">スライド要素別の例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub 上の例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンスとサポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">リリース ノート</a></li>
<li><a href="/slides/ja/net/known-issues/">既知の問題</a></li>
<li><a href="https://releases.aspose.com/slides/net/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

.NET SDK 6 以降を使用してコンソール アプリケーションを作成します:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

次に、使用するプラットフォーム向けに 1 つのパッケージを追加します:

- Windows の場合: `dotnet add package Aspose.Slides.NET`
- Linux と macOS の場合: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — Linux の前提条件や、代わりに Aspose.Slides.NET が必要なシステムについては、[インストール](/slides/ja/net/installation/) を参照してください。

*Program.cs* の内容をこのコードに置き換え、`dotnet run` を実行します:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

このプログラムはテキスト ボックスを含む 1 つのスライドを持つ *hello.pptx* を保存します。ライセンスがない場合、保存されたファイルには評価版の透かしが付加されます — 詳細は[ライセンス](/slides/ja/net/licensing/) を参照してください。プレゼンテーションを作成および構成する他の方法については、[プレゼンテーションの作成](/slides/ja/net/create-presentation/) をご覧ください。