---
title: Java 経由の Node.js 用 Aspose.Slides
second_title: Node.js 用 Aspose.Slides
type: docs
weight: 47
url: /ja/nodejs-java/
keywords:
- ドキュメンテーション
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "まずはここから: Aspose.Slides for Node.js via Java をインストールし、最初のプレゼンテーションを作成し、一般的なタスク、API リファレンス、サポートに関するガイドを見つけましょう。"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java は、Microsoft PowerPoint を使用せずに、Node.js アプリケーションで PowerPoint および OpenDocument プレゼンテーションを作成、読み取り、編集、変換できるライブラリです。

PPT、PPTX、PPS、POT、ODP をマクロ対応やテンプレートバリアントを含めて読み書きでき、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始する</b></p>
<hr>
<p>はじめに</p>
<ul>
<li><a href="/slides/ja/nodejs-java/installation/">インストール</a></li>
<li><a href="/slides/ja/nodejs-java/create-presentation/">最初のプレゼンテーションを作成する</a></li>
<li><a href="/slides/ja/nodejs-java/getting-started/">はじめにガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/nodejs-java/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/nodejs-java/evaluate-aspose-slides/">トライアルの制限</a></li>
<li><a href="/slides/ja/nodejs-java/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>一般的なタスク</p>
<ul>
<li><a href="/slides/ja/nodejs-java/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/nodejs-java/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/nodejs-java/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/nodejs-java/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/nodejs-java/manage-text/">テキストと図形の編集</a></li>
</ul>
<p>Slides ワークフロー</p>
<ul>
<li><a href="/slides/ja/nodejs-java/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/nodejs-java/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/nodejs-java/manage-media-files/">オーディオとビデオ</a></li>
<li><a href="/slides/ja/nodejs-java/presentation-design/">スライドデザイン</a></li>
<li><a href="/slides/ja/nodejs-java/merge-presentation/">プレゼンテーションのマージ</a></li>
</ul>
<p>例</p>
<ul>
<li><a href="/slides/ja/nodejs-java/examples/">スライド要素別の例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンスとサポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ja/nodejs-java/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/ja/nodejs-java/release-notes/">リリースノート</a></li>
<li><a href="/slides/ja/nodejs-java/known-issues/">既知の問題</a></li>
<li><a href="https://releases.aspose.com/slides/ja/nodejs-java/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ja/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

Node.js 20 以降に加えて、このパッケージは Java Development Kit (JDK)、Python、C++ ビルドツールチェーンが必要です。npm がインストール時に `java` ブリッジをコンパイルするためです。各 OS の手順については[Installation](/slides/ja/nodejs-java/installation/)をご確認ください。その後、プロジェクトを作成し npm からパッケージをインストールします：

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

このコードをプロジェクトフォルダーに *hello.js* として保存してください：

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides は Java 仮想マシン上で実行され、Node.js を継続させるため、プロセスを明示的に終了させます。
process.exit(0);
```

`node hello.js` で実行します。このスクリプトはテキストボックスを含む 1 枚のスライドを持つ *hello.pptx* を保存します。ライセンスがない場合、保存されたファイルには評価用の透かしが入ります — 詳しくは[Licensing](/slides/ja/nodejs-java/licensing/)をご覧ください。プレゼンテーションの作成や内容の入力についての他の方法は[Create Presentations](/slides/ja/nodejs-java/create-presentation/)をご参照ください。