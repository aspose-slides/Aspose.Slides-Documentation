---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /ja/php-java/
keywords:
- ドキュメント
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "ここから始めましょう: Aspose.Slides for PHP via Java をインストールし、最初のプレゼンテーションを作成し、共通タスクのガイド、API リファレンス、サポート情報を見つけてください。"
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java は、Microsoft PowerPoint や Office Automation を使用せずに、PHP アプリケーションで PowerPoint および OpenDocument プレゼンテーションの作成、読み取り、編集、変換を行うクラス ライブラリです。

PPT、PPTX、PPS、POT、ODP をロードおよび保存でき、マクロ対応やテンプレート バリアントも含み、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へのエクスポートが可能です。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/ja/php-java/installation/">インストール</a></li>
<li><a href="/slides/ja/php-java/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/php-java/getting-started/">はじめにガイド</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/ja/php-java/supported-file-formats/">対応ファイル形式</a></li>
<li><a href="/slides/ja/php-java/evaluate-aspose-slides/">トライアルの制限事項</a></li>
<li><a href="/slides/ja/php-java/licensing/">ライセンス情報</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/ja/php-java/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/php-java/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/php-java/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/php-java/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/php-java/manage-text/">テキストと図形を編集</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/ja/php-java/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/php-java/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/php-java/manage-media-files/">音声と動画</a></li>
<li><a href="/slides/ja/php-java/presentation-design/">スライド デザイン</a></li>
<li><a href="/slides/ja/php-java/merge-presentation/">プレゼンテーションの統合</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/ja/php-java/examples/">スライド要素別サンプル</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンス &amp; サポート</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">リリースノート</a></li>
<li><a href="/slides/ja/php-java/known-issues/">既知の問題</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">ダウンロード</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

Aspose.Slides for PHP via Java は Apache Tomcat 内の Java 上で動作し、PHP スクリプトは PHP/Java Bridge を通じてアクセスします。[Installation](/slides/ja/php-java/installation/) では PHP 8.3 以前、Java、Tomcat、ブリッジをセットアップし、Packagist からプロジェクト フォルダーにパッケージをインストールします。

```bash
composer require aspose/slides
```

次にパッケージの JAR ファイルをブリッジにコピーし、Tomcat を再起動します。これは [Install on Linux](/slides/ja/php-java/installation/#install-on-linux) の手順 4、または [Install on Windows](/slides/ja/php-java/installation/#install-on-windows) の手順 6 に相当します。Tomcat が起動したら、プロジェクト フォルダーに *hello.php* として次のスクリプトを保存し、`php hello.php` を実行します。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ja/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

スクリプトは自身と同じディレクトリに *hello.pptx* を保存し、1 枚のスライドにテキスト ボックスを配置します。ライセンスがない場合、保存されたファイルには評価用透かしが付加されます — 詳細は [Licensing](/slides/ja/php-java/licensing/) を参照してください。プレゼンテーションの作成や内容の設定については、[Create Presentations](/slides/ja/php-java/create-presentation/) をご覧ください。