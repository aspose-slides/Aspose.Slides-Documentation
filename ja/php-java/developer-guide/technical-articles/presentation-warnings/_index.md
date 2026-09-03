---
title: PHP でプレゼンテーション警告を処理する
type: docs
weight: 90
url: /ja/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告コールバック
- 警告ポリシー
- データ損失
- ソース破損
- 互換性問題
- フォント置き換え
- デジタル署名
- プレゼンテーション読み込み
- プレゼンテーションレンダリング
- プレゼンテーション変換
- プレゼンテーション保存
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、プレゼンテーションの読み込み、レンダリング、変換、保存時に警告を収集、分類、対処する方法を学びます。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの読み込み、レンダリング、変換、保存中に回復可能な問題を報告できます。例として、破損したソースレコード、保存できないコンテンツ、フォントの置き換え、対象フォーマットの制限などがあります。警告コールバックを使用すると、アプリケーションはこれらの状態を記録し、現在の操作を継続できるかどうかを判断できます。

PHP のクラスを作成し、public な `warning` メソッドを実装して、PHP Java Bridge を介して Java の [IWarningCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarningcallback/) インターフェイスとして `java_closure` で公開します。[IWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/) から提供される [getWarningType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getWarningType--) と [getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) の値を調べます。警告を受け入れる場合は [ReturnAction::Continue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/returnaction/#Continue) を返し、操作を停止する場合は [ReturnAction::Abort](https://reference.aspose.com/slides/ja/php-java/aspose.slides/returnaction/#Abort) を返します。

プレゼンテーションを開く際に発生する警告には [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setWarningCallback) を使用します。レンダリングおよびエクスポートオプション クラスは [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveoptions/#setWarningCallback) を継承し、スライドのレンダリング、変換、保存時の警告を受け取ります。警告自体はアプリケーションの操作を特定しないため、結合レポートを作成する際には各コールバックインスタンスを操作ステージに関連付けてください。

## **警告と例外**

Java の例外は PHP Java Bridge を通じて PHP に公開されます。例のように操作境界でキャッチしてください。この記事内の Java インターフェイスリンクは、ブリッジが使用するコールバック契約を説明しています。

警告は、コールバックが `ReturnAction::Continue` を返すことで Aspose.Slides が回復できる状態を示します。例外は要求された操作が正常に完了できないことを意味し、例外は警告に変換されず、警告ポリシーで処理できません。

`ReturnAction::Abort` を返すと、警告ディスパッチャは例外を発生させて現在の操作を終了させます。公開される例外は操作やプレゼンテーション形式によって異なります。たとえば、読み込み時には [PptxReadException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxreadexception/) や [PptReadException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptreadexception/) が発生し、保存やエクスポート時には [PptxException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxexception/) が発生する可能性があります。操作の境界で例外を処理し、警告レポートを使用して終了がアプリケーションポリシーによるものかを判断してください。コールバックは `ReturnAction::Abort` を返す前に警告を記録するため、理由はアプリケーション側で利用可能です。

## **警告カテゴリ**

[WarningType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/warningtype/) クラスは以下のカテゴリに対応する整数定数を提供します。

| 警告タイプ | 意味 | 典型的なポリシー |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ja/php-java/aspose.slides/warningtype/#SourceFileCorruption) | ソースプレゼンテーションに破損があり、元の形式で保存するとファイルが使用不能になる可能性があります。 | 中止 |
| [DataLoss](https://reference.aspose.com/slides/ja/php-java/aspose.slides/warningtype/#DataLoss) | 読み込みまたは保存後にテキスト、チャート、画像、その他のデータが欠落している可能性があります。 | 中止 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ja/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | 重要な書式情報が失われる可能性があります。 | 厳格な検証モードでは中止、そうでなければ記録して継続 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ja/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | 限定的な書式差異が発生する可能性があります。 | 診断用に記録し継続 |
| [CompatibilityIssue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/warningtype/#CompatibilityIssue) | 結果が一部のアプリケーションや古いバージョンで正しく開かない、または正しく動作しない可能性があります。 | ログに残して継続（互換性が必須でない限り） |
| [UnexpectedContent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/warningtype/#UnexpectedContent) | ソースに未対応または認識できないコンテンツが含まれ、影響が不明な場合があります。 | 記録して継続、あるいは厳格ポリシーではエラーとして扱う |

カテゴリはポリシー決定の指針となります。[getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) で取得した値は診断に保存しますが、メッセージ文言はシナリオや製品バージョンにより変わるため、アプリケーションロジックの根拠にはしないでください。

## **警告の収集と分類**

以下の例は、全処理パイプライン用の単一アプリケーションレベルレポートを使用します。個別のコールバックインスタンスが読み込み、レンダリング、PDF 変換、PPTX 保存からの警告にラベル付けします。ポリシーはソース破損やデータ損失で中止し、必要に応じて重要な書式損失でも中止し、その他の警告は継続します。コールバックは `java_values` を使って警告値をネイティブ PHP 値に変換し、記録および比較を行います。

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

`WarningPolicy` を構築する際に `abortOnMajorFormattingLoss` に `false` を渡すと、重要な書式差異が許容可能な場合に継続できます。互換性問題、軽微な書式損失、予期しないコンテンツは、操作が継続してもレポートに保持されます。これらのカテゴリをすべて拒否する必要がある場合は `WarningPolicy::getAction` を拡張してください。

## **一般的な警告シナリオ**

警告はワークフローのさまざまな段階で発生する可能性があります。

- **デジタル署名:** 署名付きプレゼンテーションは、読み込み時に処理中に署名が失われる旨の警告を出すことがあります。Aspose.Slides はこの `DataLoss` 条件を [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationsignedwarninginfo/) を通じて報告します。ロード段階のコールバックでファイルを拒否するか、報告された損失を明示的に受け入れるか選択できます。
- **フォント置き換え:** 利用できないフォントは、スライドのレンダリングやエクスポート時に置き換えられます。フォント置き換え警告は `DataLoss` として報告されるため、上記の厳格ポリシーではアプリケーションが視覚的に許容できても中止します。この動作を確認するには、ランタイムで利用できないフォントでテキストが書かれた入力プレゼンテーションを使用してください。警告の説明で置き換えが識別できますので、必要なフォントを用意するか、[フォント置き換えルール](/slides/ja/php-java/font-substitution/) を設定して再試行してください。
- **未対応または予期しないコンテンツ:** ローダーが認識できないプレゼンテーションレコードや機能に遭遇することがあります。このような警告は `UnexpectedContent`、またはデータや書式への影響が明らかな場合はより重大なカテゴリになることがあります。
- **フォーマット互換性:** 別のプレゼンテーション形式へ保存すると機能が省かれたり、特定のアプリケーションで挙動が異なる結果になることがあります。たとえば、8 本を超える水平または垂直の描画ガイドを含むプレゼンテーションを旧式 PPT に保存すると `CompatibilityIssue` が報告されます。保存段階のコールバックで損失を記録し継続するか、すべてのガイドを保持する必要がある場合は拒否できます。
- **読み込み動作:** 読み込みオプションやレガシー動作でも警告が発生します。たとえば、[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) は、廃止されたプレゼンテーション ロック動作の使用を `CompatibilityIssue` として識別します。

警告はソース文書、対象フォーマット、操作、Aspose.Slides のバージョンに依存します。すべてのファイルが警告を出すとは限らず、シナリオが必ずしも 1 つのカテゴリにマッピングされるわけでもありません。

## **中止した操作の安全な取り扱い**

コールバックが `ReturnAction::Abort` を返した場合、読み込みに失敗したオブジェクトを使用しないでください。また、レンダリングや保存の出力が完了していると仮定しないでください。操作は出力ファイルを作成した段階で終了することがあります。

検証済みの結果は `validated-output.pptx` のような別パスに保存してください。既存のプレゼンテーションを上書きするのは、操作が正常に完了し、警告レポートがポリシーを満たし、出力が開いて確認できた場合に限ります。これにより、部分的または拒否された結果で有効なソースファイルを上書きするリスクを防げます。

空の警告レポートは、すべてのソース機能が保持されたことを保証するものではありません。アプリケーション固有の追加コンテンツやビジュアルチェックを実施してください。詳しくは [プレゼンテーションのオープン](/slides/ja/php-java/open-presentation/) と [プレゼンテーションの保存](/slides/ja/php-java/save-presentation/) を参照してください。

## **FAQ**

**警告コールバックはすべての Aspose.Slides エラーを処理できますか？**

いいえ。回復可能な条件として警告が報告された場合にのみ処理できます。コールバックとは別に発生する例外は、読み込み、レンダリング、変換、保存呼び出しの周囲でアプリケーション側で処理する必要があります。

**`ReturnAction::Continue` を返すと出力が完全に同一になる保証がありますか？**

いいえ。処理を継続できるだけで、報告された条件によりデータ、書式、互換性の差異が生じる可能性があります。収集された警告タイプと説明を確認してください。

**アプリケーションはどの操作で警告が発生したかをどう識別しますか？**

各操作ごとにコールバックインスタンスを作成し、[getWarningType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getWarningType--) と [getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) が返す値とともに、アプリケーション定義のステージ情報を保存してください。例をご参照ください。