---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /ja/nodejs-net/
keywords:
- ドキュメント
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "ここから始めましょう: Aspose.Slides for Node.js via .NET をインストールし、最初のプレゼンテーションを作成し、一般的なタスク、ライセンス、API リファレンス、サポートに関するガイドを見つけてください。"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET は、Microsoft PowerPoint や Office Automation を使用せずに、Node.js アプリケーション内で PowerPoint および OpenDocument プレゼンテーションを作成、読み取り、編集、変換できるライブラリです。edge‑js ブリッジを介して Aspose.Slides for .NET を実行するため、JavaScript API は .NET API を鏡像し、メンバー名は camelCase です。

PPT、PPTX、PPS、POT、ODP を読み書きでき、マクロ対応やテンプレートバリアントもサポートし、PDF、XPS、HTML、TIFF、Markdown、画像へエクスポートできます。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>はじめに</p>
<ul>
<li><a href="/slides/ja/nodejs-net/installation/">インストール</a></li>
<li><a href="/slides/ja/nodejs-net/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/nodejs-net/developer-guide/">開発者ガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/nodejs-net/evaluate-aspose-slides/">トライアルの制限</a></li>
<li><a href="/slides/ja/nodejs-net/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slidesで構築</b></p>
<hr>
<p>共通タスク</p>
<ul>
<li><a href="/slides/ja/nodejs-net/open-presentation/">プレゼンテーションを開いて保存</a></li>
<li><a href="/slides/ja/nodejs-net/convert-powerpoint-to-pdf/">PDFに変換</a></li>
<li><a href="/slides/ja/nodejs-net/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/nodejs-net/manage-text/">テキストを編集</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンスとサポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ja/net/">.NET API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/ja/nodejs-net/release-notes/">リリースノート</a></li>
<li><a href="https://releases.aspose.com/slides/ja/nodejs-net/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ja/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

Node.js 22 または 24 と .NET SDK 8 以降が必要です。Linux ではいくつかのシステムパッケージも必要です。[インストール](/slides/ja/nodejs-net/installation/) に必要項目とテスト済みプラットフォームが記載されています。プロジェクトを作成し、npm がインストールする edge‑js のリリースを指定するオーバーライドを追加してパッケージをインストールします:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

マシンごとに一度、ライブラリが依存する .NET パッケージを復元します。[.NET 依存関係の復元](/slides/ja/nodejs-net/installation/#restore-the-net-dependencies) から `deps.csproj` ファイルをプロジェクト フォルダー内の `deps` フォルダーに保存し、次のコマンドを実行します:

```sh
dotnet restore deps/deps.csproj
```

このコードをプロジェクト フォルダーに *hello.js* として保存します:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 新しいプレゼンテーションには空のスライドが1つ含まれます。
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置とサイズはポイント (1/72 インチ) で指定されます: x, y, 幅, 高さ.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // プレゼンテーションを支える .NET オブジェクトを解放します。
    presentation.dispose();
}
```

プロジェクト フォルダーから実行します:

```sh
node hello.js
```

スクリプトは `Saved hello.pptx` と表示し、テキストを含む矩形が配置された 1 スライドの *hello.pptx* を保存します。ライセンスがない場合、保存されたファイルには評価ウォーターマークが付加されます — 詳細は[ライセンス](/slides/ja/nodejs-net/licensing/)をご覧ください。プレゼンテーションの作成や内容の設定については、[プレゼンテーションの作成](/slides/ja/nodejs-net/create-presentation/) を参照してください。