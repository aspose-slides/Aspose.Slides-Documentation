---
title: PHPでプレゼンテーションを効率的に結合する
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/php-java/merge-presentation/
keywords:
- PowerPointを結合
- プレゼンテーションを結合
- スライドを結合
- PPTを結合
- PPTXを結合
- ODPを結合
- PowerPointを統合
- プレゼンテーションを統合
- スライドを統合
- PPTを統合
- PPTXを統合
- ODPを統合
- PHP
- Aspose.Slides
description: "スライドをクローンし、マスターとレイアウトを制御し、スライドコンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを処理することで、PHPでPowerPointおよびOpenDocumentプレゼンテーションを結合する方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java は、1 つの [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) から別のプレゼンテーションへスライドをクローンしてプレゼンテーションを結合します。主な操作は [SlideCollection::addClone()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) で、元のスライドの書式を保持したままコピーしたり、結合先プレゼンテーションのマスターまたはレイアウトにクローンされたスライドを割り当てたりできます。

本記事では、最も一般的な結合ワークフローを取り上げます。

- ソース書式を保持しながらすべてのスライドを結合
- 選択したスライドだけを結合
- 結合先プレゼンテーションのマスターを適用
- 結合先プレゼンテーションの特定レイアウトを適用
- 結合前に異なるスライドサイズを正規化
- クローンしたスライドをセクションに追加
- 複数のプレゼンテーションを 1 つのエンドツーエンド ワークフローで結合
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、巨大ファイル、マルチスレッドに関する考慮事項を処理

## **スライド クローンがマスターとレイアウトに与える影響**

スライドはレイアウトおよびマスターから外観の多くを継承します。そのため、選択するクローンのオーバーロードにより、結合されたスライドが結合先プレゼンテーションにどのように統合されるかが決まります。

以下のいずれかの方法で [SlideCollection::addClone()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) を使用します。

- `addClone(sourceSlide)` — ソーススライドのレイアウトと書式を保持します。必要に応じて、ソースマスターが自動的に結合先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じマスターを使用するスライドが繰り返しクローンされることを防ぎます。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンされたスライドを特定の結合先 [MasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) に割り当てます。Aspose.Slides はマスター内でレイアウトタイプまたは名前に基づいて一致するレイアウトを探します。
- `addClone(sourceSlide, destinationLayout)` — クローンされたスライドを直接特定の結合先 [LayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/) に割り当てます。

`addClone` のオーバーロードに渡すマスターまたはレイアウトは、**結合先** プレゼンテーションに属している必要があり、ソースプレゼンテーションのものではありません。

## **プレゼンテーション全体を結合し、ソース書式を保持**

最も簡単な結合は、ソースプレゼンテーションのすべてのスライドを結合先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適しています。

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

ソースと結合先でデザインが異なる場合、結果のプレゼンテーションに複数のマスターが含まれることがあります。これはソース書式を意図的に保持した場合の予想通りの動作です。

## **選択したスライドだけを結合**

すべてのスライドをクローンする必要はありません。以下の例は、ソースプレゼンテーションから特定のスライドインデックスだけをインポートします。

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

ユーザー入力や外部設定から取得したインデックスの場合は、クローン前にスライドインデックスの有効性を確認してください。

## **結合先マスターを使用してスライドを結合**

インポートされたスライドが、すでに結合先プレゼンテーションに存在するマスターに従うべき場合は、[addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) オーバーロードを使用します。

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

Aspose.Slides は、ソースレイアウトのタイプまたは名前と一致する適切なレイアウトを指定されたマスターの下で選択します。該当レイアウトが存在せず `allowCloneMissingLayout` が `true` の場合、ソースレイアウトがクローンされスライドが追加されます。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxeditexception/) がスローされます。

追加レイアウトを結合先マスターに導入したくない場合は、`false` を使用して結合を失敗させます。

## **特定の結合先レイアウトを使用してスライドを結合**

インポートされたスライドが使用すべき結合先レイアウトが明確に決まっている場合は、[addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) オーバーロードを使用します。

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

結合先レイアウトを適用すると、継承されたレイアウトの関係が変わりますが、ソーススライドのコンテンツ自体は再設計されません。ソースと結合先のレイアウトでプレースホルダー構造が異なる場合は、結果を確認し、継承された書式とプレースホルダーの動作が適切かどうかを検証してください。

## **スライドサイズが異なるプレゼンテーションを結合**

スライド寸法が異なるプレゼンテーションでも結合は可能ですが、別サイズのプレゼンテーションへスライドをクローンしただけではコンテンツが新しいキャンバスに自動で再設計されません。そのため、シェイプがずれたり、スケーリングが予期せず変わったり、スライド領域外に出ることがあります。

実用的な方法は、クローン前にソースプレゼンテーションのサイズを変更することです。[SlideSize::setSize()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesize/setsize/) メソッドは、スライド寸法を変更しながら既存コンテンツをスケーリングできます。[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesizescaletype/) はコンテンツを要求サイズに収めるようにスケーリングします。

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

リサイズはメモリ上のソースプレゼンテーションオブジェクトを変更します。別の操作で元のソースプレゼンテーションを保持したい場合は、結合用に別インスタンスを開いてください。

## **スライドをセクションに結合**

基本的なスライドクローンループは、ソースプレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、結合先プレゼンテーションにセクションを作成または選択し、[addClone(Slide, Section)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) を使用して明示的にスライドをセクションへクローンします。

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

クローンされたスライドは指定された結合先セクションに追加されます。複数のソースセクションを保持したい場合は、結合先に同様のセクションを再作成し、各ソーススライドを対応する結合先セクションへマッピングしてください。

## **複数プレゼンテーションを安全に結合**

以下のエンドツーエンド例は、最初のプレゼンテーションを結合先として使用し、追加の各ソースのスライドサイズを正規化し、コピー中だけソースを開き、最終的に一度だけファイルを保存します。

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

これはインポートされたスライドのソース書式を保持するための有用な基本形です。出力で単一の結合先テーマを使用したい場合は、単純な `addClone($slide)` 呼び出しを前述の結合先マスターまたは結合先レイアウトオーバーロードに置き換えてください。

## **実践的な考慮事項**

### **マスター、レイアウト、書式忠実度**

デフォルトのスライドクローンは、必要に応じてソースマスターを自動的に結合先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同一マスターの重複クローンを防止します。手動でクローンしたマスターはこのレジストリに登録されないため、明示的に制御しない限り事前にマスターをクローンしないでください。

名前が同じでも、2 つのマスターやレイアウトが視覚的に同等であるとは限りません。企業テンプレートで最終的な外観を制御する必要がある場合は、結合先マスターまたはレイアウトを明示的に選択し、結合後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドのコンテンツに紐づいており、スライドがクローンされると同時にコピーされます。Aspose.Slides には [presentation notes](https://docs.aspose.com/slides/ja/php-java/presentation-notes/) と [presentation comments](https://docs.aspose.com/slides/ja/php-java/presentation-comments/) 用の専用 API も用意されています。

ノートページの書式が重要な場合、結合されたプレゼンテーションでノートマスターが異なることがあるため、結果を確認してください。レビュー作業では、コメントの作成者やスレッド構造も結合後に検証することを推奨します。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像や埋め込み音声・動画、OLE データなどのプレゼンテーションレベルのリソースを参照できます。スライド自体をクローンし、可視シェイプだけをコピーしないことで、Aspose.Slides がこれらリソースとの関係を保持できます。

埋め込みリソースとリンクリソースは扱いが異なります。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。結合後にプレゼンテーションを開く環境で、リンクリソースのパスや URL が有効かテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、無関係なソースプレゼンテーション間で同一バイナリリソースが常に重複除去されるという保証ではありません。ファイルサイズが重要な場合は、結合パッケージを検査し、結果を測定して重複除去の有無を確認してください。

### **埋め込みフォントとフォントの可用性**

フォントはプレゼンテーションレベルで管理されます。機械間でタイポグラフィの一貫性が必要な場合、スライドだけをクローンしただけでは目的のフォントが結合先環境に存在するとは限りません。[FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getembeddedfonts/) で埋め込みフォントを確認し、[Embed Fonts in Presentations](https://docs.aspose.com/slides/ja/php-java/embedded-font/) に従って明示的に埋め込みを管理してください。

また、ソースファイルで使用されているフォントの埋め込みが許可されているか確認してください。フォントライセンスに埋め込み制限がある場合があります。

### **パスワード保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンできるようにまず正常に開く必要があります。パスワードは [LoadOptions::setPassword()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/setpassword/) で指定します。

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

暗号化されたソースを開いても、同じ保護が自動的に結合先プレゼンテーションに適用されることはありません。必要に応じて出力保護を別途設定してください。

### **巨大プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大容量バイナリオブジェクトを含む巨大プレゼンテーションは、かなりのメモリを消費します。[LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) で BLOB の取り扱いと一時ファイル使用を制御できます。大容量ファイルのサンプルは [Open Presentations](https://docs.aspose.com/slides/ja/php-java/open-presentation/#open-large-presentations) を参照してください。

大きなファイルの場合は、可能な限りファイルパスから読み込み、ソースプレゼンテーションは結合が完了したら速やかに破棄し、ワークフローでチェックポイントが不要なら中間結果の保存を繰り返さないようにしてください。

### **スレッド安全性**

[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを複数スレッドで同時にロード、変更、保存、クローンしないでください。PHP via Java ではこれらの操作はマルチスレッド使用をサポートしていません。並列結合ジョブが必要な場合は、各プロセスが単一スレッドで独立したプレゼンテーションインスタンスを使用するようにし、[Aspose.Slides マルチスレッド ガイダンス](https://docs.aspose.com/slides/ja/php-java/multithreading/) に従ってください。

## **FAQ**

**各ソースプレゼンテーションの元のデザインを保持するには？**

`addClone(sourceSlide)` を使用し、結合先マスターやレイアウトを指定しません。必要に応じて Aspose.Slides がソースマスターを自動的にクローンします。

**インポートされたスライドに結合先テーマを適用するには？**

結合先マスターを受け取るオーバーロードを使用します。ソースではなく結合先プレゼンテーションのマスターを渡してください。Aspose.Slides は各ソーススライドをそのマスターの適切なレイアウトにマップしようとします。

**結合先マスターではなく特定の結合先レイアウトを使用すべきはいつですか？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合は、特定レイアウトを選択します。ソースレイアウトのタイプや名前に応じてマスター内のレイアウトを自動選択させたい場合は、マスターを使用してください。

**スライドサイズが異なるプレゼンテーションは結合できますか？**

はい。ただし、スライドコンテンツは結合先サイズに自動で再設計されません。予測可能な配置が必要な場合は、[SlideSize::setSize()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesize/setsize/) と [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesizescaletype/) を使用してソースプレゼンテーションを先にリサイズしてください。

**PPT、PPTX、ODP のプレゼンテーションを 1 つのファイルに結合できますか？**

できます。各ソースプレゼンテーションを読み込み、必要なスライドを 1 つの結合先にクローンし、サポートされている出力形式で保存します。フォーマット間で機能セットが完全に一致しない場合があるため、複合形式の結合後は複雑なコンテンツを確認してください。[Supported File Formats](https://docs.aspose.com/slides/ja/php-java/supported-file-formats/) を参照してください。

**ソースのセクションは自動で保持されますか？**

スライドだけをクローンする基本ループでは保持されません。結合先で必要なセクションを再作成し、[addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/addclone/) のセクションオーバーロードを使用してください。

**スピーカーノートとコメントは保持されますか？**

クローンされたスライドと共にコピーされます。ノートマスターの書式やコメント作者、スレッド構造に依存するワークフローでは、結合結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなりますか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままで、結合後もリンク先のファイルや URL が利用可能である必要があります。

**すべてのソースから埋め込まれたフォントは結合後に利用可能ですか？**

スライドクローンだけに依存してフォント展開を保証しないでください。結合先の埋め込みフォントを確認し、タイポグラフィが重要な場合はフォント埋め込みまたは外部フォントの配置を明示的に管理してください。

**パスワード保護されたファイルを結合するには？**

正しい [LoadOptions::setPassword()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/setpassword/) で開き、通常通りスライドをクローンしてください。出力の保護は別途設定します。

**非常に大きなプレゼンテーションはどう扱うべきですか？**

BLOB 管理オプションを使用し、大容量ファイルは可能な限りファイルパスから読み込み、ソースプレゼンテーションは結合が終わったら速やかに破棄し、最終結果の保存は必要なときだけ行ってください。

**複数スレッドでスライドを結合できますか？**

PHP via Java では、プレゼンテーションの読み込み、保存、クローンを複数スレッドで実行することはサポートされていません。並列作業が必要な場合は、各プロセスを単一スレッドで実行し、プレゼンテーションインスタンスをプロセス間で共有しないようにしてください。