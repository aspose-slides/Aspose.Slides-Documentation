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
description: "ここから開始してください：Aspose.Slides for .NET をインストールし、最初のプレゼンテーションを作成し、一般的なタスク、デプロイ、および API リファレンスのガイドをご覧ください。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET は、Microsoft PowerPoint または Office Automation を使用せずに、.NET アプリケーションで PowerPoint および OpenDocument のプレゼンテーションを作成、読み取り、編集、変換できるクラスライブラリです。

PPT、PPTX、PPS、POT、ODP をロードおよび保存でき、マクロ対応やテンプレートバリエーションもサポートし、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へのエクスポートが可能です。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/ja/net/installation/">インストール</a></li>
<li><a href="/slides/ja/net/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/net/system-requirements/">システム要件</a></li>
<li><a href="/slides/ja/net/getting-started/">はじめにガイド</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/ja/net/supported-file-formats/">対応ファイル形式</a></li>
<li><a href="/slides/ja/net/features-overview/">機能概要</a></li>
<li><a href="/slides/ja/net/evaluate-aspose-slides/">トライアルの制限</a></li>
<li><a href="/slides/ja/net/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/ja/net/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/net/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/net/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/net/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/net/manage-text/">テキストとシェイプを編集</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/ja/net/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/net/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/net/manage-media-files/">音声および動画</a></li>
<li><a href="/slides/ja/net/presentation-design/">スライドデザイン</a></li>
<li><a href="/slides/ja/net/merge-presentation/">プレゼンテーションの結合</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/ja/net/examples/">スライド要素別のサンプル</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub のサンプル</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>デプロイ &amp; サポート</b></p>
<hr>
<p>DEPLOY</p>
<ul>
<li><a href="/slides/ja/net/net6/">クロスプラットフォーム (.NET 6+)</a></li>
<li><a href="/slides/ja/net/how-to-run-aspose-slides-in-docker/">Docker で実行</a></li>
<li><a href="/slides/ja/net/deploy-fonts/">フォント</a></li>
<li><a href="/slides/ja/net/security/">セキュリティ</a></li>
</ul>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">リリースノート</a></li>
<li><a href="/slides/ja/net/known-issues/">既知の問題</a></li>
<li><a href="/slides/ja/net/api-limitations/">出力メタデータの制限</a></li>
<li><a href="https://products.aspose.com/slides/net/">製品ページ</a></li>
<li><a href="https://releases.aspose.com/slides/net/">ダウンロード</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **最初のプレゼンテーション**

.NET SDK 6 以上でコンソールアプリケーションを作成します:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

次に、プラットフォームに合わせて 1 つのパッケージを追加します:

- Windows の場合: `dotnet add package Aspose.Slides.NET`
- Linux と macOS の場合: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — Linux の前提条件および Aspose.Slides.NET が必要なシステムについては[インストール](/slides/ja/net/installation/)をご参照ください。

*Program.cs* の内容を以下のコードに置き換え、`dotnet run` を実行します:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

このプログラムはテキストボックスを含む 1 枚のスライドを持つ *hello.pptx* を保存します。ライセンスがない場合、保存されたファイルには評価用の透かしが付加されます — 詳細は[ライセンス](/slides/ja/net/licensing/)をご覧ください。プレゼンテーションの作成や内容の入力の詳細については、[プレゼンテーションの作成](/slides/ja/net/create-presentation/)をご参照ください。