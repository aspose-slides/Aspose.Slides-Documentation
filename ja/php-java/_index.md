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
description: "ここから始めましょう: Aspose.Slides for PHP via Java をインストールし、最初のプレゼンテーションを作成し、共通タスクのガイド、API リファレンス、サポートを見つけてください。"
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java は、Microsoft PowerPoint や Office Automation を使用せずに、PHP アプリケーションで PowerPoint および OpenDocument プレゼンテーションを作成、読み取り、編集、変換するためのクラス ライブラリです。

マクロ対応やテンプレート バリアントを含む PPT、PPTX、PPS、POT、ODP を読み込み・保存でき、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>開始手順</p>
<ul>
<li><a href="/slides/ja/php-java/installation/">インストール</a></li>
<li><a href="/slides/ja/php-java/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/php-java/getting-started/">開始ガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/php-java/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/php-java/evaluate-aspose-slides/">試用版の制限</a></li>
<li><a href="/slides/ja/php-java/licensing/">ライセンス情報</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>共通タスク</p>
<ul>
<li><a href="/slides/ja/php-java/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/php-java/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/php-java/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/php-java/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/php-java/manage-text/">テキストと図形を編集</a></li>
</ul>
<p>Slides ワークフロー</p>
<ul>
<li><a href="/slides/ja/php-java/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/php-java/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/php-java/manage-media-files/">音声と動画</a></li>
<li><a href="/slides/ja/php-java/presentation-design/">スライド デザイン</a></li>
<li><a href="/slides/ja/php-java/merge-presentation/">プレゼンテーションの結合</a></li>
</ul>
<p>例</p>
<ul>
<li><a href="/slides/ja/php-java/examples/">スライド要素別の例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンスとサポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">リリース ノート</a></li>
<li><a href="/slides/ja/php-java/known-issues/">既知の問題</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">製品ページ</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

Aspose.Slides for PHP via Java は Apache Tomcat 上の Java で動作し、PHP スクリプトは PHP/Java Bridge を通じてアクセスします。[インストール](/slides/ja/php-java/installation/) は PHP 8.3 以前、Java、Tomcat、ブリッジをセットアップし、Packagist からプロジェクト フォルダーにパッケージをインストールします。

```bash
composer require aspose/slides
```

次に、パッケージの JAR ファイルをブリッジにコピーし、Tomcat を再起動します。これは [Linux にインストール](/slides/ja/php-java/installation/#install-on-linux) のステップ 4、または [Windows にインストール](/slides/ja/php-java/installation/#install-on-windows) のステップ 6 と同様です。Tomcat が起動したら、このスクリプトをプロジェクト フォルダーに *hello.php* として保存し、`php hello.php` を実行します：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

このスクリプトは同ディレクトリに *hello.pptx* を保存し、テキスト ボックスを含むスライドが 1 枚作成されます。ライセンスがない場合、保存されたファイルには評価用の透かしが入ります — 詳細は [ライセンス情報](/slides/ja/php-java/licensing/) を参照してください。プレゼンテーションの作成や内容の設定についての詳しい方法は、[プレゼンテーションの作成](/slides/ja/php-java/create-presentation/) をご覧ください。