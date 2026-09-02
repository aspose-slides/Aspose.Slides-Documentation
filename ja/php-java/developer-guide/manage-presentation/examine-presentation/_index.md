---
title: PHPでプレゼンテーション情報を取得および更新する
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/php-java/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTXの検査
- PPTの検査
- ODPの検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して、PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察と賢いコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、プレゼンテーションの内容をロードして処理するかどうかを判断する前にプロパティを検査したりする場合に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/) と [PresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/) を使用した軽量検査、および [DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/) を使用したターゲット更新を示します。

## **プレゼンテーション形式の確認**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/) を使用して、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを作成せずにファイルを検査します。 [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#getLoadFormat) メソッドは、検出された形式（PPTX、PPT、ODP など）を報告します。

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **軽量プレゼンテーションインベントリの作成**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システム向けのコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/) を使用して [PresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/) オブジェクトを取得し、続いて [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#readDocumentProperties) を呼び出してドキュメント メタデータを読み取ります。このアプローチは [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを作成したり、完全なプレゼンテーション オブジェクト モデルを走査したりする必要がありません。

[DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/) が公開する拡張プロパティは、次のインベントリ値を提供します。

| メソッド | インベントリ値 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getSlides) | スライド総数 |
| [getHiddenSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getHiddenSlides) | 非表示スライド数 |
| [getNotes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getNotes) | ノートが含まれるスライド数 |
| [getParagraphs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getParagraphs) | 利用可能な場合の段落総数 |
| [getWords](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getWords) | 単語総数 |
| [getMultimediaClips](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getMultimediaClips) | オーディオおよびビデオ クリップ総数 |

以下の例は、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) オブジェクトを作成せずにこれらの値を取得し、コンパクトなインベントリを出力します。また、[DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getHeadingPairs) と [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getTitlesOfParts) を組み合わせて、フォント、テーマ、スライド タイトルなどのコンテンツ グループを表示します。

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

各 [HeadingPair](https://reference.aspose.com/slides/ja/php-java/aspose.slides/headingpair/) はグループ名とそのグループ内の項目数を提供します。[DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getTitlesOfParts) はフラットで順序付けられた配列を返すため、各ヘディング ペアで指定された連続したタイトル数だけを使用します。

### **保存されたメタデータと形式の制限**

[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#readDocumentProperties) が返すインベントリ プロパティは、ソース ドキュメントに存在するメタデータを反映します。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルをロードおよび走査してこれらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新していない場合、保存された値は古くなることがあります。

- **PPTX:** スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウントに加え、ヘディング ペアとパート タイトルの拡張ドキュメント プロパティを提供します。利用可能性はドキュメント 作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応するドキュメント要約プロパティを保存できます。プロパティが存在しない、または作成者によって更新されていない場合、Aspose.Slides はスライドから計算するのではなく、保存された値またはデフォルト値を返します。
- **ODP:** OpenDocument メタデータはページ、段落、単語数などの一般的な統計情報を提供しますが、これらの値は PowerPoint 固有の拡張プロパティすべてにマッピングされません。非表示スライド、ノートスライド、マルチメディア、ヘディング ペア、パート タイトルのメタデータは利用できないことがあり、インベントリ プロパティはデフォルト値を返す可能性があります。ゼロ値や空配列を、該当コンテンツが存在しない決定的な証拠として扱わないでください。

軽量メタデータ アプローチはインベントリ作成や事前チェックに使用してください。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査してください。

## **プレゼンテーション プロパティの更新**

[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#readDocumentProperties) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを作成せずに変更できます。[PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) で変更を適用し、続いて [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#writeBindedPresentation) でバインドされたプレゼンテーションを書き込みます。

以下の画像は元のドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

以下の例はタイトルと最終保存時間を変更し、結果を新しいファイルに書き出します。

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

以下の画像は更新されたドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの変更されたドキュメントプロパティ](output_properties.png)

## **役立つリンク**

関連するセキュリティ チェックと保護設定については、以下の記事をご参照ください。

- [プレゼンテーションのパスワード保護](/slides/ja/php-java/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/php-java/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、[Presentation::getFontsManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getFontsManager) を使用します。[FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) で埋め込まれたフォントを取得し、[FontsManager::getFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#getFonts) でプレゼンテーションで使用されているフォントを取得します。両方の結果を比較して、レンダリングに必要だが埋め込まれていないフォントを特定します。

**ファイルに非表示スライドが含まれているか、またその数をすぐに知る方法はありますか？**

保存されたドキュメント メタデータが十分である場合、[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/) と [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#readDocumentProperties) を介して [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getHiddenSlides) を読み取ります。これは軽量インベントリに適しています。メモリ上でプレゼンテーションが変更されている場合や、ライブ値を確認する必要がある場合は、[Presentation::getSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSlides) を列挙し、各スライドの [Slide::getHidden](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getHidden) メソッドで確認してください。

**カスタム スライド サイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation::getSlideSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSlideSize) を呼び出します。[SlideSize::getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesize/#getType)、[SlideSize::getSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesize/#getSize)、[SlideSize::getOrientation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesize/#getOrientation) を使用して現在の設定を期待されるプリセットや寸法と比較します。

**チャートが外部データ ソースを参照しているかどうかを簡単に確認する方法はありますか？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/) を見つけ、[ChartData::getDataSourceType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/#getDataSourceType) を呼び出します。外部ブックの場合は、[ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/#getExternalWorkbookPath) を呼び出します。データ ソース タイプとパスが外部参照を示しますが、対象が利用可能かどうかは別途リソース チェックが必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価する方法はありますか？**

単一の複雑度プロパティは存在しません。[Presentation::getSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSlides) と各スライドの [BaseSlide::getShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/#getShapes) コレクションを走査します。形状数や大きな画像、エフェクト、アニメーション、マルチメディアの有無をスクリーニング信号として使用し、代表的なレンダリングまたはエクスポートを測定して、スライドを確実なパフォーマンス ボトルネックとして扱うかどうかを判断してください。