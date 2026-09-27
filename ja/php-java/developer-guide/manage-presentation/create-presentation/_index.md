---
title: PHPでプレゼンテーションを作成する
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/php-java/create-presentation/
keywords:
- プレゼンテーションの作成
- 新しいプレゼンテーション
- PPTの作成
- 新しいPPT
- PPTXの作成
- 新しいPPTX
- ODPの作成
- 新しいODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成してプログラムで保存し、確実な結果を得ることができます。"
---
## **概要**

この記事では、Aspose.Slidesでプレゼンテーションを作成し、最初のスライドにテキスト ボックスを追加して結果をファイルとして保存する方法を示します。また、空のプレゼンテーションを作成して保存する方法、およびサポートされている形式の既存プレゼンテーションを開いて別の形式で保存する方法も示します。最後の短い FAQ では、形式、テンプレート、スライドサイズ、単位、メモリ使用量、スレッド、ライセンス、デジタル署名、VBA のサポートに関する一般的な質問をカバーしています。

開始する前に、Composer を使用して PHP 用 Aspose.Slides for Java をインストールし、Apache Tomcat で PHP/Java Bridge を起動してください。完全なセットアップについては [Installation](/slides/ja/php-java/installation/) を参照してください。以下の例は、Tomcat が `localhost:8080` で実行されており、Composer の `vendor` フォルダーがスクリプトの隣にあることを前提としています。

## **PowerPoint プレゼンテーションの作成**

プレゼンテーションを作成し、最初のスライドにテキスト ボックスを配置するには、次の手順に従います：

1. Presentation クラスのインスタンスを作成します。新しいプレゼンテーションにはすでに空のスライドが 1 枚含まれています。  
   [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)
2. インデックス 0 で、[Presentation::getSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getslides/) が返すコレクションからそのスライドを取得します。  
   [Presentation::getSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getslides/)
3. [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addautoshape/) メソッドで矩形を追加し、[TextFrame::setText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/settext/) でテキストを設定します。  
   [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addautoshape/)  
   [TextFrame::setText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/settext/)
4. [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/save/) メソッドでプレゼンテーションを PPTX ファイルとして保存します。  
   [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/save/)

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

2 つの `require_once` 行は、Tomcat から PHP/Java Bridge クライアントを、Composer パッケージから Aspose.Slides クラスをロードします。矩形の左上隅はスライドの左端から 50 ポイント、上端から 50 ポイントの位置にあり、幅が 400 ポイント、高さが 100 ポイントです。保存されたファイルには、その矩形とテキストを含むスライドが 1 枚含まれます。ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしを追加します。詳細は [Licensing](/slides/ja/php-java/licensing/) を参照してください。

{{% alert color="info" title="Note" %}}
Aspose.Slides は PHP プロセスではなく Tomcat 内でファイルの読み書きを行うため、`"hello.pptx"` のような相対パスは Tomcat の作業フォルダーを基準に解決されます。このページの例では `__DIR__` を使用して絶対パスを構築しているため、ファイルはスクリプトの隣で読み取りおよび保存されます。
{{% /alert %}}

## **プレゼンテーションの作成と保存**

空のプレゼンテーションを作成して保存するには、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、[SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) 列挙体の任意の形式で保存します。結果として、空のスライドが 1 枚含まれるプレゼンテーションが得られます。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ja/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーションの開き方と保存**

プレゼンテーションを別の形式に変換するには、パスを [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) コンストラクタに渡して開き、目的の形式で保存します。Aspose.Slides はファイル自体から PPT、PPTX、ODP などの入力形式を検出します。

以下の例は、スクリプトの隣にある *Sample.odp* という名前の OpenDocument プレゼンテーションを対象とし、PPTX として保存します。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ja/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **よくある質問**

### 新しいプレゼンテーションを保存できる形式は何ですか？

[PPTX, PPT, and ODP](/slides/ja/php-java/save-presentation/) に保存でき、[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/php-java/convert-powerpoint-to-html/)、[SVG](/slides/ja/php-java/render-a-slide-as-an-svg-image/)、および [images](/slides/ja/php-java/convert-powerpoint-to-png/) などにもエクスポートできます。

### テンプレート (POTX/POTM) から開始して通常の PPTX として保存できますか？

はい。テンプレートをロードし、目的の形式で保存します。POTX/POTM/PPTM などの形式は [are supported](/slides/ja/php-java/supported-file-formats/) です。

### プレゼンテーション作成時にスライドのサイズ/アスペクト比をどのように制御しますか？

[slide size](/slides/ja/php-java/slide-size/) を設定します（4:3 や 16:9 のプリセット、またはカスタム寸法を含む）。そして、コンテンツのスケーリング方法を選択します。

### サイズや座標はどの単位で測定されますか？

ポイント単位です。1 インチは 72 ユニットに相当します。

### 多数のメディアファイルを含む非常に大きなプレゼンテーションでメモリ使用量を削減するにはどうすればよいですか？

[BLOB management strategies](/slides/ja/php-java/manage-blob/) を使用し、一時ファイルを活用してメモリ内ストレージを制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先します。

### プレゼンテーションを並行して作成/保存できますか？

同じ [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスに対して [multiple threads](/slides/ja/php-java/multithreading/) から操作することはできません。スレッドまたはプロセスごとに個別のインスタンスを実行してください。

### 評価版の透かしと制限を削除するには？

[Apply a license](/slides/ja/php-java/licensing/) をプロセスごとに一度実行します。ライセンス XML は変更せずに保持し、複数のスレッドが関与する場合はライセンス設定を同期させる必要があります。

### 作成した PPTX にデジタル署名できますか？

はい。プレゼンテーションでは、[Digital signatures](/slides/ja/php-java/digital-signature-in-powerpoint/)（追加および検証）がサポートされています。

### 作成されたプレゼンテーションでマクロ (VBA) はサポートされていますか？

はい。[create/edit VBA projects](/slides/ja/php-java/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。