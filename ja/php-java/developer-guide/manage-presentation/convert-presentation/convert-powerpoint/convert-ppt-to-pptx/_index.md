---
title: PHP で PPT を PPTX に変換
linktitle: PPT から PPTX
type: docs
weight: 20
url: /ja/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT から PPTX へ
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でレガシー PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換、エラーハンドリング、忠実度に関するメモの PHP サンプルを含みます。"
---
## **概要**

PPT はレガシーなバイナリ PowerPoint フォーマットで、PPTX は新しい Open XML フォーマットです。Aspose.Slides for PHP via Java は Microsoft PowerPoint を使用せずに PPT ファイルをロードし、PPTX として保存できます。この記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目について説明します。

## **PPT ファイルを PPTX に変換する**

ソース ファイルは [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスでロードし、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) を [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/#Pptx) とともに呼び出します。`finally` ブロックはプレゼンテーションを破棄し、リソースを解放します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// レガシー PPT プレゼンテーションをロードします。
$presentation = new Presentation("presentation.ppt");
try {
    // プレゼンテーションを PPTX 形式で保存します。
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ファイル拡張子だけでは出力フォーマットは選択されません。出力フォーマットは [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/#Pptx) 引数で指定します。元の PPT ファイルを保持する必要がある場合は、入力パスと出力パスを別々にしてください。

## **複数の PPT ファイルを変換する**

次の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、1 つの変換が失敗してもバッチ全体が中止されることはありません。

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

本番環境では、例外の全体をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名を再試行またはレビュー キューに書き込みます。破損したファイル、必要なパスワードなしで開かれたパスワード保護されたファイル、アクセスできないパス、サポートされていないコンテンツはすべて変換失敗の原因となります。暗号化されたファイルのロードについては、[Password-Protected Presentations](/slides/ja/php-java/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換は通常、スライド、マスター、レイアウト、テキスト、図形、画像、表、チャートを保持します。ただし、PPT と PPTX はすべての機能を完全に同一の方法で表現しているわけではありません。PPTX に対応するものがないレガシー機能や、ライブラリでサポートされていない機能は、正規化されたり、省略されたり、別の形で表示されたりする可能性があります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、マイナーなフォント、VBA マクロが含まれる場合は確認してください。普通の PPTX ファイルはマクロ有効形式ではないため、VBA を利用可能なままにする必要がある場合は、適切なマクロ有効ワークフローを使用してください。また、変換されたプレゼンテーションが開かれるまたはレンダリングされる環境に、必要なフォントや外部リソースが存在することも確認してください。

重要な文書については、生成された PPTX をプログラムから再度開き、主要なスライド数や内容を検査し、意図したビューアでの外観やスライドショーの挙動と比較してください。成功した [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) 呼び出しを、すべてのレガシー機能が正確に PPTX に変換されたという証拠として扱わないでください。

## **PPTX を使用すべき時**

プレゼンテーションを現在の PowerPoint バージョンで編集したり、Open XML パッケージを扱うシステムとやり取りしたり、レガシーなバイナリ PPT よりも検査や復元が容易な形式で保存したりする場合は PPTX を使用してください。変換されたプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持しましょう。

代わりに PDF、HTML、画像、XPS、または別の出力タイプが必要な場合は、すべてのターゲットが編集可能な PowerPoint 機能を保持すると想定せず、[Convert Presentations to Multiple Formats](/slides/ja/php-java/convert-presentation/) の形式固有のガイダンスを使用してください。

## **オンライン変換ツール**

たまにファイルを変換したり、簡単に比較したりする場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換、バッチ処理、またはアプリケーションレベルのエラーハンドリングが必要な場合は、PHP API を使用してください。

## **関連記事**

- [PPT と PPTX](/slides/ja/php-java/ppt-vs-pptx/)
- [PHP でプレゼンテーションを保存する](/slides/ja/php-java/save-presentation/)
- [サポートされているファイル形式](/slides/ja/php-java/supported-file-formats/)
- [PHP でプレゼンテーションを開く](/slides/ja/php-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides for PHP via Java は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルをロードおよび保存できます。

**PPT から PPTX への変換はすべてのコンテンツを正確に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシー機能や未サポート機能が正確に保持される保証はありません。マクロ、OLE または ActiveX オブジェクト、メディア、特化したアニメーション、マイナーなフォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルをロードする際に正しいパスワードを指定すれば可能です。パスワードが欠如しているか誤っている場合、ロード操作は失敗します。

**変換後に PPT ファイルを削除すべきですか？**

重要なビューアやワークフローで PPTX を確認するまで、元のファイルは保持してください。レガシー機能が異なる形で変換された場合に備えて、ロールバック用のコピーとして残しておくことができます。