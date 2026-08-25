---
title: 効率的に PHP でプレゼンテーションをマージする
linktitle: プレゼンテーションをマージ
type: docs
weight: 40
url: /ja/php-java/merge-presentation/
keywords:
- PowerPoint をマージ
- プレゼンテーションをマージ
- スライドをマージ
- PPT をマージ
- PPTX をマージ
- ODP をマージ
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- PHP
- Aspose.Slides
description: "スライドをクローンし、マスターとレイアウトを制御し、スライドコンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを処理することで、PHP で PowerPoint および OpenDocument プレゼンテーションをマージする方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java は、スライドをクローンしてある [プレゼンテーション](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) から別のプレゼンテーションへマージします。主な操作は [SlideCollection::addClone()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) で、ソーススライドの書式設定を保持したままにしたり、クローンしたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付したりできます。

この記事では、最も一般的なマージワークフローを取り上げます。

- すべてのスライドを、ソースの書式設定を保持したままマージする;
- 選択したスライドをマージする;
- 宛先プレゼンテーションのマスターを適用する;
- 宛先プレゼンテーションの特定のレイアウトを適用する;
- マージ前に異なるスライドサイズを正規化する;
- クローンしたスライドをセクションに追加する;
- 複数のプレゼンテーションを1つのエンドツーエンドワークフローでマージする;
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、大容量ファイル、マルチスレッドに関する問題を処理する。

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから外観の大部分を継承します。そのため、選択するクローンのオーバーロードが、マージされたスライドが宛先プレゼンテーションにどのように統合されるかを決定します。

次のいずれかの方法で [SlideCollection::addClone()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) を使用します。

- `addClone(sourceSlide)` — ソーススライドのレイアウトと書式設定を保持します。必要に応じて、ソースマスターは自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じソースマスターを使用するスライドが繰り返しクローンされることを防ぎます。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンしたスライドを特定の宛先 [MasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) に添付します。Aspose.Slides はレイアウトタイプまたは名前でそのマスターの下に一致するレイアウトを探します。
- `addClone(sourceSlide, destinationLayout)` — クローンしたスライドを直接特定の宛先 [LayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/) に添付します。

`addClone` のオーバーロードに渡すマスターまたはレイアウトは、ソースプレゼンテーションではなく **宛先** プレゼンテーションに属している必要があります。

## **ソース書式設定を保持したままプレゼンテーション全体をマージする**

最も簡単なマージは、ソースプレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートしたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適した選択です。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

ソースと宛先でデザインが異なる場合、結果のプレゼンテーションに複数のマスターが含まれることがあります。これは、ソース書式設定を意図的に保持した場合に予想される動作です。

## **選択したスライドをマージする**

すべてのスライドをクローンする必要はありません。以下の例では、ソースプレゼンテーションから選択したスライドインデックスだけをインポートします。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

ユーザー入力や外部設定から取得したスライドインデックスは、クローンする前に検証してください。

## **宛先マスターを使用してスライドをマージする**

インポートしたスライドがすでに宛先プレゼンテーションに属するマスターに従うべき場合は、[addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) オーバーロードを使用します。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides は、ソースレイアウトのタイプまたは名前と一致させることで、指定されたマスターの下に適切なレイアウトを選択します。適切なレイアウトが存在せず `allowCloneMissingLayout` が `true` の場合、ソースレイアウトがクローンされてスライドを追加できるようになります。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxeditexception/) がスローされます。

追加のレイアウトを宛先マスターに導入したくない場合は、マージが失敗するように `false` を使用します。

## **特定の宛先レイアウトを使用してスライドをマージする**

インポートしたスライドが正確にどの宛先レイアウトを使用すべきかが分かっている場合は、[addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) オーバーロードを使用します。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

宛先レイアウトを適用すると、継承されるレイアウトの関係が変更されますが、ソーススライドのコンテンツ自体は再設計されません。ソースと宛先のレイアウトでプレースホルダー構造が異なる場合は、継承された書式設定とプレースホルダーの動作が適切かどうか、結果を確認してください。

## **サイズが異なるスライドを持つプレゼンテーションをマージする**

スライドサイズが異なるプレゼンテーションでもマージは可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけではコンテンツが新しいキャンバス用に自動で再設計されません。そのため、形状がずれたり、予期せず拡大縮小されたり、スライドの表示領域外に出ることがあります。

実用的な方法は、クローンする前にソースプレゼンテーションのサイズを変更することです。[SlideSize::setSize()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesize/setsize/) メソッドは、スライドサイズを変更しながら既存コンテンツを拡大縮小できます。[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesizescaletype/) は、要求されたサイズに収まるようにコンテンツをスケーリングします。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

リサイズはメモリ内のソースプレゼンテーションオブジェクトを変更します。他の操作で元のソースプレゼンテーションをそのまま残す必要がある場合は、マージ用に別インスタンスを開いてください。

## **プレゼンテーションのセクションにスライドをマージする**

基本的なスライドクローンループは、ソースプレゼンテーションのセクション階層を再作成しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[addClone(Slide, Section)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) を使ってスライドを明示的にセクションにクローンします。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

クローンされたスライドは指定された宛先セクションに追加されます。複数のソースセクションを保持したい場合は、[Presentation::getSections](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation/#getSections) を列挙し、各ソースセクションのスライドを [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getSlidesListOfSection) で取得し、宛先に同じセクションを再作成して、返された各スライドを対応する宛先セクションにクローンします。空セクションや構造変更を含む完全なセクション列挙例については [Manage Slide Sections](/slides/ja/php-java/slide-section/) を参照してください。

## **複数のプレゼンテーションを安全にマージする**

以下のエンドツーエンド例では、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライドサイズを正規化し、各ソースはコピー中のみ開き、最後に一度だけファイルを保存します。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

これはインポートしたスライドのソース書式設定を保持するための有用なベースラインです。出力が単一の宛先テーマを使用する必要がある場合は、シンプルな `addClone($slide)` 呼び出しを、前述の適切な宛先マスターまたは宛先レイアウトのオーバーロードに置き換えてください。

## **実用的な考慮事項**

### **マスター、レイアウト、書式の忠実度**

デフォルトのスライドクローンは、必要なソースマスターを自動的に宛先プレゼンテーションに持ち込むことができます。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同じマスターが繰り返しクローンされるのを防ぎます。手動でクローンしたマスターはこのレジストリで追跡されないため、マスター構造を明示的に制御する必要がない限り、事前にマスターをクローンしないようにしてください。

同名のマスターやレイアウトが視覚的に同等であると想定しないでください。企業テンプレートで最終的な外観を管理する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、マージ後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドコンテンツに紐付いており、スライドがクローンされる際にコピーされます。Aspose.Slides は [presentation notes](/slides/ja/php-java/presentation-notes/) と [presentation comments](/slides/ja/php-java/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式設定が重要な場合、ノートマスターはプレゼンテーションレベルのオブジェクトであり、ソースファイル間で異なることがあるため、マージされたプレゼンテーションを必ず確認してください。レビュー工程では、異なる作者やテンプレートから結合した場合のコメント投稿者やスレッドコメントも検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなどのプレゼンテーションレベルのリソースを参照できます。スライド自体をクローンし、可視形状だけをコピーしないようにして、Aspose.Slides がリソースとの関係を保持できるようにしてください。

埋め込みリソースとリンクリソースは別々に扱う必要があります。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。マージ後にプレゼンテーションが開かれる環境で、リンクリソースのパスや URL が正しく機能するかテストしてください。

Aspose.Slides は自動クローンされたマスターを明示的に追跡しますが、これは無関係なソースプレゼンテーション間で同一バイナリリソースが常に重複除去されるという一般的な保証ではありません。出力ファイルサイズが重要な場合は、マージ後のパッケージを検査し、結果を測定して暗黙的な重複除去に依存しないでください。

### **埋め込みフォントとフォントの可用性**

フォントはプレゼンテーションレベルで管理されます。タイポグラフィがマシン間で一貫して必要な場合、スライドのクローンだけでは目的のフォントが宛先環境に存在することを保証できないため、想定しないでください。埋め込みフォントは [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getembeddedfonts/) で確認でき、[Embed Fonts in Presentations](/slides/ja/php-java/embedded-font/) に示すように明示的に埋め込みを管理してください。

また、ソースファイルで使用されているフォントを埋め込む権限があるか確認してください。フォントのライセンスは埋め込みを制限することがあります。

### **パスワードで保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンする前に正しく開く必要があります。パスワードは [LoadOptions::setPassword()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/setpassword/) で指定してください。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // 復号化されたプレゼンテーションで作業します。
} finally {
    $source->dispose();
}
```

暗号化されたソースを開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力保護を別途設定してください。

### **大容量プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大容量バイナリオブジェクトを含む大規模プレゼンテーションは、かなりのメモリを消費します。[LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) は BLOB の取り扱いと一時ファイル使用を制御するオプションを提供します。PHP via Java の大容量ファイル例については [Open Presentations](/slides/ja/php-java/open-presentation/#open-large-presentations) を参照してください。

大容量ファイルの場合は、可能な限りファイルパスからの読み込みを優先し、マージが完了したらすぐに各ソースプレゼンテーションを破棄し、ワークフローでチェックポイントが必要な場合を除き、中間結果を繰り返し保存しないようにしてください。

### **スレッド安全性**

[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを複数スレッドでロード、変更、保存、クローンしないでください。これらの操作は PHP via Java のマルチスレッド使用をサポートしていません。並列マージジョブが必要な場合は、各プロセスが独自のプレゼンテーションインスタンスを使用する単一スレッドプロセスを別々に実行し、[Aspose.Slides マルチスレッド ガイダンス](/slides/ja/php-java/multithreading/) に従ってください。

## **FAQ**

**元のデザインを各ソースプレゼンテーションで保持するにはどうすればよいですか？**

宛先マスターやレイアウトを指定せずに [SlideCollection::addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) を使用します。インポートされたスライドに必要な場合、Aspose.Slides がソースマスターを自動的にクローンします。

**インポートされたスライドに宛先テーマを使用させるには？**

宛先マスターを受け取るオーバーロードを使用します。ソースではなく宛先プレゼンテーションのマスターを渡してください。Aspose.Slides はソーススライドをそのマスターの適切なレイアウトにマッピングしようとします。

**特定の宛先レイアウトを使用すべきケースはいつですか？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合に特定レイアウトを使用します。ソースレイアウトのタイプや名前に基づいてマスターのレイアウトを選択させたい場合はマスターを使用してください。

**サイズが異なるスライドを持つプレゼンテーションはマージできますか？**

はい。ただし、スライドコンテンツは宛先サイズに自動で再設計されません。予測可能な配置が必要な場合は、[SlideSize::setSize()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesize/setsize/) と [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesizescaletype/) を使ってソースプレゼンテーションをリサイズしてください。

**PPT、PPTX、ODP のプレゼンテーションを 1 ファイルにマージできますか？**

はい。各ソースプレゼンテーションを読み込み、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。プレゼンテーション形式間で機能セットが完全に一致しないため、クロスフォーマットマージ後は複雑なコンテンツを検証してください。[Supported File Formats](/slides/ja/php-java/supported-file-formats/) を参照してください。

**ソースのセクションは自動的に保持されますか？**

スライドだけをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先でセクションを再作成し、[addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) のセクションオーバーロードを使用してください。

**スピーカーノートとコメントは保持されますか？**

クローンされたスライドと共にコピーされます。ノートマスターのスタイリングやコメント投稿者、スレッドレビュー情報が重要なワークフローでは、マージ後に結果を必ず確認してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなりますか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままであり、リンク先のファイルや URL がマージ後も利用可能である必要があります。

**すべてのソースからの埋め込みフォントはマージ後に利用可能ですか？**

スライドのクローンだけに依存してフォント展開を保証しないでください。宛先の埋め込みフォントを確認し、タイポグラフィが重要な場合はフォントの埋め込みや外部フォントの利用を明示的に管理してください。

**パスワードで保護されたファイルをマージするには？**

正しい [LoadOptions::setPassword()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/setpassword/) で開き、通常通りスライドをクローンしてください。出力の保護は別途設定します。

**非常に大きなプレゼンテーションはどう扱うべきですか？**

BLOB 管理オプションを使用して大容量バイナリを制御し、可能な限りファイルパスから読み込み、ソースプレゼンテーションはマージ直後に破棄し、必要なときだけ最終結果を保存してください。

**複数スレッドからスライドをマージできますか？**

PHP via Java ではプレゼンテーションのロード、保存、クローンを複数スレッドで実行することはサポートされていません。並列作業が必要な場合は、各スレッドを独立した単一スレッドプロセスとして実行し、プロセスごとにプレゼンテーションインスタンスを分離してください。[/FAQ]