---
title: PHPでプレゼンテーションを保存
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/php-java/save-presentation/
keywords:
- PowerPoint を保存
- OpenDocument を保存
- プレゼンテーションを保存
- スライドを保存
- PPT を保存
- PPTX を保存
- ODP を保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義ビュー タイプ
- Strict Office Open XML フォーマット
- Zip64 モード
- サムネイルの更新
- 保存進行状況
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint および OpenDocument のプレゼンテーションをファイルまたはストリームに保存し、PPTX の出力と進行状況の報告を構成します。"
---
## **概要**

プレゼンテーションを作成するか、[既存のプレゼンテーションを開く](/slides/ja/php-java/open-presentation/) かした後、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) メソッドを使用して結果を書き込みます。Aspose.Slides for PHP via Java は、PowerPoint、OpenDocument、PDF などの形式でプレゼンテーションをファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力に利用できるオプションについて説明します。

## **プレゼンテーションをファイルに保存**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) の値を [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) メソッドに渡します。フォーマット値は、Aspose.Slides が作成するファイルの種類を決定します。

以下の例はプレゼンテーションを作成し、PPTX ファイルとして保存します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // プレゼンテーションのコンテンツを追加または変更してください。

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **元の形式でプレゼンテーションを保存**

ファイルおよびストリームの検出例や、新規に作成されたプレゼンテーションの動作、元の形式と出力形式の違いについては、[Determine the Original Presentation Format](/slides/ja/php-java/detect-presentation-source-format/) を参照してください。

バッチ処理アプリケーションでは、入力形式が事前に分からないことがあります。ファイルを読み込んだ後、[Presentation::getSourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSourceFormat) メソッドから元の形式を取得します。取得した [SourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sourceformat/) の値を [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/#toSaveFormat) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) の値を取得し、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) で変更後のプレゼンテーションを書き込みます。

以下の完全な例は、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新して、読み込んだ形式のままで出力ディレクトリに保存します：

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/#toSaveFormat) は PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、PowerPoint XML をそれぞれのプレゼンテーション保存形式にマッピングします。これはプレゼンテーションの元形式のみを対象とし、PDF、HTML、TIFF、画像などのエクスポート形式を選択するためのものではありません。サポートされていない、または無効な [SourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sourceformat/) の値を渡すと、[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) がスローされます。

レガシーな PPT、PPS、POT ファイルは同じバイナリ コンテナを使用します。そのようなプレゼンテーションを拡張子なしのストリームから読み込むと、PPS や POT が PPT として識別されることがあります。これらのレガシーサブタイプを保持する必要がある場合は、元のファイル名またはフォーマット メタデータを別途保持し、出力ファイル名および形式を選択するときに使用してください。

## **プレゼンテーションをストリームに保存**

最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能なストリームと [SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) の値を [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) メソッドに渡します。このアプローチは、出力を Web サービスから返す必要がある場合や、データベースに保存する場合、またはメモリ内で処理する場合に便利です。

以下の例は、新しいプレゼンテーションをファイル ストリームに保存します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **事前定義されたビュー タイプでプレゼンテーションを保存**

保存されたプレゼンテーションを PowerPoint が最初に開くビューを指定できます。保存前に [ViewProperties::setLastView](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/#setLastView) メソッドに [ViewType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewtype/) の値を渡してください。

以下の例は、スライド マスター ビューを初期ビューとして設定します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Strict プロファイルに準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/) インスタンスを作成し、[PptxOptions::setConformance](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/#setConformance) メソッドに [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/php-java/aspose.slides/conformance/#Iso29500-2008-Strict) の値を渡します。その後、オプションを [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) メソッドに渡します。

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zip64 モードで Office Open XML 形式に保存**

標準的な ZIP アーカイブは各エントリの圧縮サイズ・非圧縮サイズ、総アーカイブサイズ、エントリ数に制限があります。PPTX ファイルは ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超えることがあります。ZIP64 拡張機能は、適用可能なサイズとエントリ数の制限を緩和します。

[PptxOptions::setZip64Mode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/#setZip64Mode) メソッドで Aspose.Slides が ZIP64 拡張を書き込むかどうかを制御します。

- [IfNecessary](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが標準 ZIP 制限を超える場合にのみ ZIP64 を使用します。これがデフォルトモードです。
- [Never](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zip64mode/#Never) は ZIP64 拡張を無効にします。
- [Always](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zip64mode/#Always) は常に ZIP64 拡張を書き込みます。

以下の例は、出力プレゼンテーションに対して常に ZIP64 拡張を有効にします：

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
[Zip64Mode::Never](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zip64mode/#Never) を使用し、プレゼンテーションが標準 ZIP 制限に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **圧縮レベルを指定して Office Open XML 形式に保存**

PPTX 出力では、[PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/#setCompressionLevel) メソッドを使用して、保存速度とファイルサイズのバランスを調整できます。[CompressionLevel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/) クラスは以下の値を提供します。

- [None](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#None) は圧縮せずにデータを保存します。
- [Level1](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level1) は最速の圧縮で、圧縮後のサイズが最も大きくなります。
- [Level2](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level2) から [Level5](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level5) は、保存速度よりも小さな出力を徐々に優先します。
- [Level6](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level6) は保存速度とファイルサイズのバランスを取ります。これはデフォルトレベルです。
- [Level7](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level7) と [Level8](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level8) は、さらに小さな出力を優先します。
- [Level9](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level9) は最強の圧縮を提供し、最も多くの処理時間が必要です。

以下の例は圧縮なしでプレゼンテーションを保存します：

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

以下の例は最大圧縮レベルで保存します：

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **サムネイルを更新せずに保存**

プレゼンテーションを PPTX として保存する際、[PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) メソッドでドキュメント サムネイルの再生成を制御できます。

- `true` は保存時にサムネイルを再生成します（デフォルト値）。
- `false` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides はサムネイルを生成しません。

以下の例はサムネイルを更新せずにプレゼンテーションを保存します：

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
サムネイルの更新を無効にすると、PPTX ファイルの保存に要する時間を短縮できます。
{{% /alert %}}

## **保存進行状況をパーセンテージで取得**

保存操作の進行状況を監視するには、[IProgressCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/) インターフェイスを実装した Java プロキシを作成し、[SaveOptions::setProgressCallback](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveoptions/#setProgressCallback) メソッドにそのプロキシを渡します。Aspose.Slides はエクスポート中に [IProgressCallback::reporting](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/#reporting-double-) メソッドを呼び出し、進行状況の数値を提供します。

以下の例は PDF エクスポートの進行状況をコンソールに出力します：

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose は、Aspose.Slides API を使用して構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供しています。これにより、プレゼンテーションから選択したスライドを個別の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はインクリメンタル保存（“高速保存”）をサポートしていますか？**

いいえ。各保存操作は変更された部分だけを更新するのではなく、完全な出力ファイルを作成します。

**同じ Presentation インスタンスを複数スレッドで保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスは **スレッド セーフではありません** (/slides/ja/php-java/multithreading/)。各インスタンスへのアクセスと保存は、同時に 1 スレッドからのみ行ってください。

**プレゼンテーションを保存するとハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/php-java/manage-hyperlinks/) はプレゼンテーションに残ります。Aspose.Slides は外部リンクされたファイルをコピーしないため、保存されたプレゼンテーションは引き続きそれらの場所にアクセスできる必要があります。

**作者、タイトル、会社、作成日などのドキュメント メタデータを保存できますか？**

はい。保存前に適切な [ドキュメント プロパティ](/slides/ja/php-java/presentation-properties/) を設定すれば、Aspose.Slides がそれらを出力ファイルに書き込みます。