---
title: Aspose.Slides for Node.js via .NET
second_title: Node.js 用 Aspose.Slides
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

Aspose.Slides for Node.js via .NET は、Microsoft PowerPoint や Office Automation を使用せずに、Node.js アプリケーションで PowerPoint および OpenDocument プレゼンテーションの作成、読み取り、編集、変換を可能にするライブラリです。edge‑js ブリッジを介して Aspose.Slides for .NET を実行するため、JavaScript API は .NET API を鏡像し、メンバー名は camelCase です。

PPT、PPTX、PPS、POT、ODP をロードおよび保存でき、マクロ対応やテンプレートバリエーションも含みます。また、PDF、XPS、HTML、TIFF、Markdown、画像へのエクスポートが可能です。

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
<li><a href="/slides/ja/nodejs-net/evaluate-aspose-slides/">試用版の制限</a></li>
<li><a href="/slides/ja/nodejs-net/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides を使用して構築</b></p>
<hr>
<p>一般的なタスク</p>
<ul>
<li><a href="/slides/ja/nodejs-net/open-presentation/">プレゼンテーションを開いて保存</a></li>
<li><a href="/slides/ja/nodejs-net/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/nodejs-net/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/nodejs-net/manage-text/">テキストの編集</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンス&amp;サポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">リリースノート</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">製品ページ</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">ダウンロード</a></li>
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

Node.js 22 または 24 と .NET SDK 8 以降が必要です。Linux ではいくつかのシステムパッケージも必要です。[Installation](/slides/ja/nodejs-net/installation/) に必要なものとテスト済みプラットフォームが記載されています。プロジェクトを作成し、npm にインストールする edge‑js のリリースを指定するオーバーライドを追加して、パッケージをインストールします:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

マシンごとに 1 回、ライブラリが依存する .NET パッケージを復元します。[Restore the .NET Dependencies](/slides/ja/nodejs-net/installation/#restore-the-net-dependencies) から取得した `deps.csproj` ファイルをプロジェクトフォルダー内の `deps` フォルダーに保存し、次のコマンドを実行します:

```sh
dotnet restore deps/deps.csproj
```

このコードをプロジェクトフォルダーに *hello.js* として保存します:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 新しいプレゼンテーションには空のスライドが1枚含まれます。
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置とサイズはポイント単位 (1/72インチ) です: x, y, 幅, 高さ。
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // .NET オブジェクト（プレゼンテーションの基盤）を解放します。
    presentation.dispose();
}
```

プロジェクトフォルダーから実行します:

```sh
node hello.js
```

スクリプトは `Saved hello.pptx` と出力し、テキストを含む矩形が 1 つのスライドとして *hello.pptx* を保存します。ライセンスがない場合、保存されたファイルには評価用の透かしが入ります — 詳細は [Licensing](/slides/ja/nodejs-net/licensing/) を参照してください。プレゼンテーションの作成や内容の入力方法については、[Create a Presentation](/slides/ja/nodejs-net/create-presentation/) をご覧ください。