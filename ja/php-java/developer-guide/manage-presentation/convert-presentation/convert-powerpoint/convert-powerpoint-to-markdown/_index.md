---
title: PowerPoint プレゼンテーションを PHP で Markdown に変換
linktitle: PowerPoint を Markdown に変換
type: docs
weight: 140
url: /ja/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を MD に変換
- プレゼンテーションを MD に変換
- スライドを MD に変換
- PPT を MD に変換
- PPTX を MD に変換
- PowerPoint を Markdown として保存
- プレゼンテーションを Markdown として保存
- スライドを Markdown として保存
- PPT を MD として保存
- PPTX を MD として保存
- PPT を MD にエクスポート
- PPTX を MD にエクスポート
- Markdown 画像エクスポート
- CDN 画像リンク
- PowerPoint
- プレゼンテーション
- Markdown
- PHP
- Aspose.Slides
description: "PHP で PPT および PPTX プレゼンテーションを Markdown に変換し、エクスポートされたビットマップ、メタファイル、SVG 画像の保存場所と参照先を制御します。"
---
## **概要**

Aspose.Slides for PHP via Java は、ドキュメント作成、静的サイト、コンテンツ移行、バージョン管理ワークフロー向けに、PPT および PPTX プレゼンテーションを Markdown に変換できます。Markdown のフレーバーを選択し、スライド内容のレンダリング方法を制御し、エクスポートされた画像の保存場所と生成された Markdown がそれらを参照する方法を決めることができます。

デフォルトでは、Markdown エクスポートはテキストのみの出力を使用します。ビジュアルコンテンツをエクスポートするには、[MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) メソッドで [MarkdownExportType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownexporttype/) 列挙体の `Sequential` または `Visual` 値に設定します。`Sequential` はスライド項目を個別かつ順番通りにレンダリングし、`Visual` はグループ化された項目を一緒に保持して視覚的な関係を保ちます。`TextOnly` 値は画像リソースを出力しないため、そのモードでは画像保存コールバックは呼び出されません。

## **プレゼンテーションを Markdown に変換**

[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスでソースファイルを読み込み、次に [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) メソッドに [SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) 列挙体の `Md` 値を渡して呼び出します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Markdown フレーバーの選択**

[MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) メソッドは出力に使用される Markdown 仕様を制御します。[Flavor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/flavor/) 列挙体には CommonMark、GitHub Flavored Markdown、その他のサポートされているバリエーションが含まれます。

以下の例はプレゼンテーションを CommonMark としてエクスポートします。

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **デフォルトのローカル保存動作で画像をエクスポート**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) クラスはローカルに保存される画像を構成するための 2 つのメソッドを提供します：

- [setBasePath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) は Markdown ドキュメントとそのリソースのベースディレクトリを指定します。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) は画像サブディレクトリを指定します。その既定値は `Images` です。

以下の例はビジュアルコンテンツをレンダリングし、画像を `output/assets` に書き込み、Markdown ドキュメントに相対画像参照を作成します。

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

この動作はカスタム画像保存ハンドラが `false` を返した場合のフォールバックとしても機能します。

## **画像保存と Markdown リンクのカスタマイズ**

[MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) メソッドを使用して、Markdown エクスポート中に出力される非 SVG ビットマップおよびメタファイルリソース用のコールバックを登録します。その `MarkdownImageSavingHandler` コールバックは [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) オブジェクト、その [ImageFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imageformat/) 値、および 1 要素の Java 文字列配列として生成された Markdown リンクを受け取ります。提供された形式で画像を保存またはアップロードし、`$link[0]` を Markdown 出力に記載すべき参照に置き換えます。

SVG 形式で出力されるリソースは別途処理されます。[MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) メソッドでコールバックを登録します。その `MarkdownSvgImageSavingHandler` コールバックは [ISvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/isvgimage/) オブジェクトと 1 要素の Java 文字列配列 `$link` を受け取ります。SVG には `ImageFormat` 引数がないため、代わりに [ISvgImage::getSvgData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/isvgimage/) メソッドから XML データを書き込むかアップロードします。エクスポートモードや視覚的なグループ化に応じて、ソースプレゼンテーション内の SVG がラスタライズされたり他のコンテンツと結合されたりすることがあり、結果として得られた非 SVG リソースが画像保存コールバックに渡されます。すべてのエクスポートされたビジュアルリソースにカスタム処理が必要な場合は、両方のコールバックを登録してください。

PHP via Java では、各コールバックを PHP クラスで実装し、`java_closure` を使用してそのオブジェクトを対応する Java インターフェイスとして公開します。

{{% alert color="info" title="Note" %}}
`JAVA_PREFER_VALUES` を有効にした状態で PHP/Java ブリッジを初期化し、`Java.inc` をロードする前に設定してください。[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) メソッドは `void` を返し、ブリッジの既定ストリームモードではキューイングされた呼び出し中に PHP コールバックを呼び出すことができません。以下の完全な例には必要な初期化が含まれています。
{{% /alert %}}

ハンドラの戻り値は画像を処理する側を決定します：

- ハンドラが画像を保存、アップロード、変換、またはその他の方法で処理し、`$link[0]` に有効な値を割り当てた後に `true` を返します。Aspose.Slides はその値を Markdown ドキュメントに書き込み、既定のローカル保存は行いません。
- `false` を返すと、Aspose.Slides が画像をローカルに保存し、[MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) と [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) で設定された値に従ってリンクを生成します。

{{% alert color="warning" title="Important" %}}
`true` を返すハンドラは画像に対する責任を負います。有効で空でないリンクを割り当てずに `true` を返すと、`InvalidOperationException` がスローされエクスポートが失敗します。
{{% /alert %}}

### **画像を CDN オリジンディレクトリに保存し、外部 URL を使用**

以下の例は `cdn-origin/presentations/quarterly-report` をマウントまたは同期された CDN オリジンディレクトリとして扱います。各ハンドラは生成されたファイル名を抽出し、そのカスタムディレクトリに画像を保存し、生成されたローカル参照を公開 CDN URL に置き換えます。サンプル自体はネットワークへのアップロードを行いません：ディレクトリが CDN オリジンとしてマウントされるかファイルが CDN に公開された後にのみ URL が有効になります。オブジェクトストレージの場合は、ファイルシステムへの書き込みをストレージ SDK のアップロード操作に置き換え、アップロードが成功した後にのみ `$link[0]` を割り当ててください。

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

ビットマップハンドラは 128 × 128 ピクセル未満の画像に対して意図的に `false` を返すため、Aspose.Slides はそれらの画像を既定の動作で `output/fallback-images` に保存します。より大きなビットマップやメタファイル、SVG リソースはカスタムコードで処理されます。たとえば、生成されたローカル参照 `fallback-images/image1.png` は `https://cdn.example.com/presentations/quarterly-report/image1.png` に変換されます。ハンドラはファイルを書き込む際に OS のパス区切り文字のみを使用し、Markdown に書き込むリンクはスラッシュと URL エンコードされたファイル名を使用します。相対リンクを作成する際も同様に `/` を使用し、プラットフォーム固有のディレクトリ区切り文字は使用しないでください。

## **FAQ**

**ハンドラはラスタ画像と SVG 画像の両方を処理できますか？**

できません。ビットマップおよびメタファイルリソース用には [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) を使用し、SVG として出力されるリソース用には [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) を使用してください。前者は [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) オブジェクトと [ImageFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imageformat/) 値を提供し、後者は [ISvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/isvgimage/) オブジェクトとその SVG データを取得できる [ISvgImage::getSvgData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/isvgimage/) を提供します。エクスポート中にラスタライズされた SVG は画像保存コールバックで処理されます。

**画像保存ハンドラが `false` を返した場合はどうなりますか？**

Aspose.Slides は既定のローカル保存動作を使用します。画像の保存場所と生成された参照は、[MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) と [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/markdownsaveoptions/) で設定された値によって制御されます。

**ハンドラは画像をローカルに保存せずに URL を提供できますか？**

はい。ハンドラは画像をオブジェクトストレージにアップロードするなどして URL を取得し、その URL を `$link[0]` に割り当てて `true` を返すことができます。`true` を返すと既定のローカル保存は行われません。

**ハンドラから `InvalidOperationException` がスローされるのはなぜですか？**

ハンドラが `true` を返したにもかかわらず有効なリンクが提供されなかったときにこの例外が発生します。`true` を返す前に、Markdown に書き込むべき相対パスまたは外部 URL を `$link[0]` に設定してください。

**画像リンクはどのパス区切り文字を使用すべきですか？**

Markdown リンクと URL ではスラッシュ `/` を使用してください。ファイルシステムパスでのみ `DIRECTORY_SEPARATOR` を使用し、Markdown の参照は別に構築または正規化してください。

**Markdown エクスポート時にハイパーリンクは保持されますか？**

保持されます。テキストの [ハイパーリンク](/slides/ja/php-java/manage-hyperlinks/) は標準的な Markdown リンクとして残ります。スライドの [遷移](/slides/ja/php-java/slide-transition/) や [アニメーション](/slides/ja/php-java/powerpoint-animation/) は変換されません。

**プレゼンテーションを並列で Markdown に変換できますか？**

異なるプレゼンテーションファイルを並列に処理することは可能ですが、同じ [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。[マルチスレッドのガイドライン](/slides/ja/php-java/multithreading/) に従い、ファイルごとに個別のインスタンスを使用してください。