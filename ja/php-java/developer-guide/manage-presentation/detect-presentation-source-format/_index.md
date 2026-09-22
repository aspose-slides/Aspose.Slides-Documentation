---
title: PHP で元のプレゼンテーション形式を判定する
linktitle: ソース形式
type: docs
weight: 35
url: /ja/php-java/detect-presentation-source-format/
keywords:
- ソース形式
- プレゼンテーション形式の検出
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PHP で読み込んだプレゼンテーションの元の形式を取得し、検出 API を比較し、ファイル、ストリーム、レガシーフォーマットを処理します。"
---
## **概要**

プレゼンテーションを読み込んだ後、[Presentation::getSourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSourceFormat) メソッドを呼び出して、元の形式を判定します。現在のインスタンスが読み込まれた形式に依存する後続の処理が必要な場合に使用します。

ソース形式は、出力ファイル用に選択した [SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) とは別物です。別の形式で保存しても、既存インスタンスのソース形式は変わりません。

## **ファイルのソース形式を読む**

この例では既存の `sample.pptx` ファイルが必要です。ファイルを読み込み、ファイル名ではなく [Presentation::getSourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSourceFormat) を使用してアプリケーションの処理ポリシーを選択します。入力パスを変更すれば他の形式も試せます。例では選択されたポリシーを出力しています。メッセージは実際のアプリケーションロジックに置き換えてください。

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **サポートされている値を確認する**

[SourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sourceformat/) クラスは、以下のプレゼンテーション形式を区別する整数定数を定義しています。下記の拡張子は慣例的なものであり、元のファイル名の再構成ではありません。

| SourceFormat 値 | 拡張子 | フォーマット |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 プレゼンテーション |
| `Pptx` | `.pptx` | Office Open XML プレゼンテーション |
| `Pptm` | `.pptm` | マクロ対応 Office Open XML プレゼンテーション |
| `Pps` | `.pps` | PowerPoint 97–2003 スライドショー |
| `Ppsx` | `.ppsx` | Office Open XML スライドショー |
| `Ppsm` | `.ppsm` | マクロ対応 Office Open XML スライドショー |
| `Pot` | `.pot` | PowerPoint 97–2003 テンプレート |
| `Potx` | `.potx` | Office Open XML テンプレート |
| `Potm` | `.potm` | マクロ対応 Office Open XML テンプレート |
| `Odp` | `.odp` | OpenDocument プレゼンテーション |
| `Otp` | `.otp` | OpenDocument プレゼンテーションテンプレート |
| `Fodp` | `.fodp` | Flat XML ODF プレゼンテーション |
| `Xml` | `.xml` | PowerPoint XML プレゼンテーション |

## **ストリームのソース形式を読む**

この例では既存の `sample.pps` ファイルが必要です。バイト列をメモリストリームに読み込むことで、データベースの値やアップロードされたバイト配列など、ファイル名なしで受け取った入力をシミュレートします。[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) コンストラクタはストリームだけを受け取ります。

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT、PPS、POT は同じ基盤バイナリ形式を共有します。ファイルパスで読み込む場合、拡張子でスライドショーかテンプレートかを区別できます。ファイル名がない場合、レガシーな PPS や POT のコンテンツは `SourceFormat::Ppt` として報告されることがあります。上記の PPS の例では `SourceFormat::Ppt` の整数値を出力しています。

アプリケーション側でこの区別を保持する必要がある場合は、元のファイル名またはサブタイプメタデータを別途保存してください。拡張子はこれらレガシーサブタイプの有用なヒントになりますが、任意のプレゼンテーションコンテンツを識別する唯一の根拠にすべきではありません。

## **ロード前後の検出結果を比較する**

ファイル全体をプレゼンテーションオブジェクトモデルとして読み込む前にチェックしたい場合は、[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/#getPresentationInfo) と [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#getLoadFormat) を使用します。インスタンスが既に存在する場合は [Presentation::getSourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSourceFormat) を使用してください。

この例では `sample.pptx` が必要で、`LoadFormat::Pptx` と `SourceFormat::Pptx` の整数値をそれぞれ出力します。実際の運用では、処理段階に応じた API を選択してください。すでにロード済みのプレゼンテーションに対して、ソース形式取得だけのために再度検査する必要はありません。

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

結果に使用されている定数は異なるクラスからのものです: [LoadFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadformat/) と [SourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sourceformat/)。数値を直接比較したり、すべての形式で同一の検出結果が得られると推測しないでください。PowerPoint XML はロード前は `LoadFormat::Unknown`、ロード後は `SourceFormat::Xml` と報告されることがあります。

## **ソース形式と出力形式は別々に管理する**

この例では `sample.pptx` を読み込み、`converted.odp` に書き出します。元のインスタンスの保存前後で `SourceFormat::Pptx` の整数値を出力します。ODP 出力から新たに読み込んだインスタンスだけが `Odp` を報告します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

`new Presentation()` でゼロから作成したプレゼンテーションは `SourceFormat::Pptx` を報告します。入力ファイルがないため、これは新規インスタンスのデフォルト値であり、PPTX ファイルがロードされたことを意味するわけではありません。作成かロードかの区別が重要な場合は、アプリケーション側で別途追跡してください。

## **ソース形式を拡張子にマッピングする**

この例では `sample.pptx` が必要です。現在サポートされているすべての [SourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sourceformat/) 値を、入力ファイル名を解析せずに慣例的な拡張子へマッピングします。認識できない値に対しては拡張子を無音で割り当てないようフォールバックしています。

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

このマッピングはファイルを変換したり、ストリーム読み込み時に失われたレガシー PPS/POT サブタイプを復元したりするものではありません。実際に保存する際は、[SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) を明示的に選択するか、[Save Presentations in Their Original Format](/slides/ja/php-java/save-presentation/#save-presentations-in-their-original-format) に示す変換方法を使用してください。

## **保存と再オープンで形式を検証する**

この自己完結型サンプルはプレゼンテーションを作成し、作業ディレクトリに 3 つのファイルを書き込みます。同名のファイルがある場合は上書きします。各出力ファイルをパスで再度開くと同時に、メモリストリームでも開きます。PPTX と ODP の場合、両ルートとも保存された形式を報告します。PPS の場合、パスでのロードは `Pps`、ファイル名なしのバイトストリームは `Ppt` を報告します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

以下の表は、拡張子が一致するプレゼンテーションに対するソース形式の識別結果をまとめたものです。名前は定数を示しており、PHP の例ではその整数値を出力しています。

| 保存形式 | ファイルパスからの SourceFormat | ファイル名なしストリームからの SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`、`Pptm`（それぞれ） | ファイルパスと同じ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`、`Ppsm`（それぞれ） | ファイルパスと同じ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`、`Potm`（それぞれ） | ファイルパスと同じ |
| ODP, OTP | `Odp`、`Otp`（それぞれ） | ファイルパスと同じ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT コンテンツは名前なしストリームでは `Ppt` と識別されます。この表は形式の識別方法を示すものであり、変換時にすべてのプレゼンテーション機能が保持されることを保証するものではありません。

## **FAQ**

**ODP に保存すると、PPTX から読み込んだプレゼンテーションのソース形式は変わりますか？**

いいえ。既存インスタンスは依然として `Pptx` を報告します。保存された ODP ファイルから読み込んだインスタンスは `Odp` を報告します。

**ストリームだけでレガシーなプレゼンテーション、スライドショー、テンプレートを区別できますか？**

できません。PPT、PPS、POT は同じバイナリ形式を共有します。区別が必要な場合は、ファイル名またはサブタイプメタデータを別途保存してください。

**プレゼンテーションがすでにロード済みの場合、どの API を使うべきですか？**

[Presentation::getSourceFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSourceFormat) を使用してください。ロード前の検査が必要な場合は、[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/#getPresentationInfo) を利用してください。