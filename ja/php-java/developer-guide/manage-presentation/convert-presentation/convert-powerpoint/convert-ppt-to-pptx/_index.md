---
title: PHPでPPTをPPTXに変換
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/php-java/convert-ppt-to-pptx/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTからPPTXへ
- PPTをPPTXとして保存
- PPTをPPTXにエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して、PHPでレガシー PPT ファイルを PPTX に変換します。単一ファイルとバッチ変換の PHP サンプル、エラーハンドリング、忠実性に関する注意事項を含みます。"
---
## **概要**

PPT は従来のバイナリ PowerPoint 形式で、PPTX は新しい Open XML 形式です。Aspose.Slides for PHP via Java は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本稿では単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目について説明します。

## **PPT ファイルを PPTX に変換する**

ソース ファイルは [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスで読み込み、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) を [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/#Pptx) と共に呼び出します。`finally` ブロックはプレゼンテーションを破棄し、リソースを解放します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// レガシー PPT プレゼンテーションを読み込む。
$presentation = new Presentation("presentation.ppt");
try {
    // プレゼンテーションを PPTX 形式で保存する。
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ファイル拡張子だけでは出力形式は決まりません。出力形式は [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/#Pptx) 引数で指定します。元の PPT ファイルを保持する必要がある場合は、入力パスと出力パスを別々にしてください。

## **複数の PPT ファイルを変換する**

以下の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、1 つの変換が失敗してもバッチ全体が停止することはありません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

本番環境では、例外の全内容をログに記録し、既存の出力ファイルを上書きしてよいかを判断し、失敗したファイル名を再試行またはレビュー キューに書き出してください。破損したファイル、必要なパスワードなしで開かれたパスワード保護ファイル、アクセスできないパス、サポートされていないコンテンツは、変換失敗の原因となります。暗号化ファイルの読み込みについては、[Password-Protected Presentations](/php-java/password-protected-presentation/) を参照してください。

## **忠実性とレガシ機能**

変換では通常、スライド、マスタ、レイアウト、テキスト、図形、画像、表、チャートが保持されます。ただし、PPT と PPTX はすべての機能を完全に同一の形で表現できるわけではありません。PPTX に対応するものがないレガシ機能や、ライブラリでサポートされていない機能は、正規化されたり、省略されたり、別の形で表示されたりすることがあります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、マイナーなフォント、VBA マクロが含まれる場合は確認してください。通常の PPTX ファイルはマクロ有効形式ではないため、VBA を保持する必要がある場合は、マクロ有効なワークフローを使用してください。また、変換されたプレゼンテーションが開かれる環境に必要なフォントや外部リソースが揃っていることも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、スライド数や主要なコンテンツを検査し、意図したビューアでの外観やスライドショーの動作と比較してください。`[Presentation::save]` 呼び出しが成功したことを、すべてのレガシ機能が正確に PPTX に変換された証拠とみなさないでください。

## **PPTX を使用すべき時**

プレゼンテーションを最新の PowerPoint で編集したり、Open XML パッケージを扱うシステムとやり取りしたり、レガシのバイナリ PPT よりも検査や復元が容易な形式で保存したりする場合は、PPTX を使用してください。変換されたプレゼンテーションが忠実性チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS、またはその他の出力形式が必要な場合は、すべてのターゲットが編集可能な PowerPoint 機能を保持するという前提にせず、[Convert Presentations to Multiple Formats](/php-java/convert-presentation/) に記載されたフォーマット別ガイドラインを使用してください。

## **オンライン コンバータ**

たまにファイルを変換したり、簡単に比較したりする場合は、[オンライン PPT から PPTX へのコンバータ](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を使用できます。繰り返しの変換やバッチ処理、アプリケーションレベルのエラーハンドリングが必要な場合は、PHP API を使用してください。

## **関連記事**

- [PPT と PPTX](/php-java/ppt-vs-pptx/)
- [PHP でプレゼンテーションを保存する](/php-java/save-presentation/)
- [サポートされているファイル形式](/php-java/supported-file-formats/)
- [PHP でプレゼンテーションを開く](/php-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい。Aspose.Slides for PHP via Java は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルを読み込み、保存できます。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシ機能やサポートされていない機能が正確に保持される保証はありません。マクロ、OLE または ActiveX オブジェクト、メディア、特殊なアニメーション、マイナーなフォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルの読み込み時に正しいパスワードを指定すれば変換できます。パスワードがない、または間違っている場合はロード操作が失敗します。

**変換後に PPT ファイルを削除すべきですか？**

重要なビューアやワークフローで PPTX を確認するまで、元のファイルは保持してください。レガシ機能の変換結果が異なる場合に備えて、ロールバック用のコピーとして残しておくことができます。