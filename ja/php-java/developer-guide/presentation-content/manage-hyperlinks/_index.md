---
title: PHPでプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/php-java/manage-hyperlinks/
keywords:
- URLを追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- シェイプハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用し、PHP の例で PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを追加、書式設定、更新、削除します。"
---
## **概要**

ハイパーリンクはプレゼンテーションのコンテンツをウェブサイトまたはプレゼンテーション内の場所に接続します。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディア フレームからウェブサイトを開く。
* 別のスライドへ移動する（例：目次から）。

Aspose.Slides for PHP via Java を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除できます。以下の例は個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレームレベルでハイパーリンクにアクセスする方法を示しています。PHP/Java Bridge と Aspose.Slides PHP ラッパーが初期化されていることを前提としています。PHP リファレンスページがない API メンバーは、基になる Java API へのリンクです。

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [無料のオンライン Aspose PowerPoint エディタ](https://products.aspose.app/slides/ja/editor).

{{% /alert %}} 

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディア フレームにウェブサイトの URL を割り当てることができます。ハイパーリンクを割り当てる要素によってクリック領域が決まります。テキスト部分に割り当てると選択したテキストがリンクとなり、図形やフレームに割り当てるとスライドオブジェクト全体がリンクになります。

### **テキストへの URL ハイパーリンクの追加**

テキストをウェブサイトにリンクさせるには、以下のようにテキスト部分の [setHyperlinkClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/sethyperlinkclick/) メソッドに [Hyperlink](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/) を渡します。対象のテキスト部分だけがクリック可能になります。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **図形およびメディア フレームへの URL ハイパーリンクの追加**

図形またはフレームをクリック可能にするには、そのオブジェクトの [setHyperlinkClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/sethyperlinkclick/) メソッドを呼び出します。ハイパーリンクはテキスト部分ではなく、オブジェクト自体に属します。

同じアプローチは画像、音声、ビデオ フレームにも適用できます。フレームにハイパーリンクを割り当て、必要に応じて [setTooltip](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/settooltip/) を呼び出します。

次の例は矩形をクリック可能にします。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **目次の作成にハイパーリンクを使用する**

内部ハイパーリンクを使用すると、読者は目次から特定のスライドへジャンプできます。次の例では、最初のスライドの “Page 2” テキストを [setInternalHyperlinkClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) を使って2枚目のスライドにリンクしています。

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ハイパーリンクの書式設定**

### **色**

[Hyperlink](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/) の [setColorSource](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/setcolorsource/) メソッドは、ハイパーリンクがプレゼンテーション全体のハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタムテキスト色を適用するには、[HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入されました。古いバージョンではこの設定は適用されません。

次の例は同じスライドに 2 つのテキストハイパーリンクを追加します。最初は赤いテキスト塗りつぶし、2 番目はデフォルトのハイパーリンク色を使用します。

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **サウンド**

ハイパーリンクはアクティブ化されたときにサウンドを再生したり、既に再生中のサウンドを停止したりできます。以下のメソッドでこれらの動作を構成します。

- [Hyperlink::setSound](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/setsound/) はハイパーリンクに関連付けるオーディオを指定します。
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/setstopsoundonclick/) はハイパーリンクのアクティブ化時に前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドの追加**

次の例は `sampleaudio.wav` を読み込み、最初のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **ハイパーリンク サウンドの抽出**

次の例は上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンクオーディオを [getSound](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/getsound/) と [getBinaryData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audio/getbinarydata/) を使ってメモリに読み取ります。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **ツールチップとインタラクション設定**

テキストまたは図形にハイパーリンクを割り当てた後、次の [Hyperlink](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/) メソッドを呼び出すことができます。

- [setTooltip](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/settooltip/) はリンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/settargetframe/) は該当する場合、親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/sethistory/) はリンクをアクティブ化したときにその宛先を閲覧済みハイパーリンク一覧に追加するかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/sethighlightclick/) はクリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

[getAnyHyperlinks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) を使用して、テキスト部分のリンクを含むハイパーリンク コンテナを収集し、変更前に取得します。次の例は最初のスライドから両方のアクティベーション タイプを削除します。片方だけを削除したい場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) または [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) のみを呼び出します。クリック アクションを削除してもマウスオーバー対応は残ります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

条件なしで削除する場合は、[removeAllHyperlinks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) が選択されたスコープ内の両方のアクティベーション タイプを一度に削除します。マスター、レイアウト、ノートを含む選択的クリーンアップとカバレッジについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **ハイパーリンクインベントリの作成**

プレゼンテーションを配布する前に、インタラクティブ アクションと Web リンクの両方をインベントリ化します。[getAnyHyperlinks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) は [IHyperlinkContainer](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkcontainer/) オブジェクトを返し、単なる URL 文字列のフラット リストではありません。各コンテナの [getHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) と [getHyperlinkMouseOver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) を調べます。これらは独立しており、同じコンテナが両方のアクションを持つことがあるため、完全なレポートではコンテナごとに最大 2 行が必要です。

テキスト部分にリンクされたハイパーリンクは、シェイプレベルだけをスキャンすると見逃す可能性があります。適切なスコープでクエリし、返されたコンテナを保持して後で更新または削除できるようにします。

### **プレゼンテーション、スライド、テキストフレームのスコープをクエリする**

[HyperlinkQueries](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkqueries/) クラスは [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/gethyperlinkqueries/)、[IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)、[TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/gethyperlinkqueries/) を通じて利用できます。各スコープは同じクエリをサポートします。

- [getHyperlinkClicks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) はクリック アクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) はマウスオーバー アクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) はいずれか、または両方のアクションを持つコンテナを返します。

次の例は外部クリックリンク、ファイルマウスオーバーリンク、内部スライド ナビゲーション、テキストマウスオーバーリンク、マクロ アクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。同じ 3 つのクエリはすべてのスコープで機能し、カウントはコンテナ数を示します。テキストフレーム スコープは囲むシェイプ自身のリンクを除外します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

この例では、プレゼンテーション と スライド のクエリはそれぞれクリック コンテナが 3 件、マウスオーバー コンテナが 2 件、いずれかのアクションを持つコンテナが 3 件と報告します。テキストフレーム クエリは各カテゴリで 1 件ずつ報告します。

### **アクションと宛先の分類**

[Hyperlink::getActionType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/getactiontype/) を使用して、宛先を解釈する前にアクションの種類を判断します。[HyperlinkActionType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkactiontype/) の値は Web ナビゲーション以外にも幅広くカバーしています。

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク。URL とそのスキームを確認します。 |
| `JumpSpecificSlide` | 特定スライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 組み込みのスライドショー ナビゲーション。スライドショー コンテキストで解決されます。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了するか、カスタムショーを開始します。 |
| `StartMacro` | マクロを実行します。 |
| `StartProgram` | プログラムを起動します。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開きます。Web URL とは別にレビューしてください。 |
| `StartStopMedia` | メディアの再生を開始または停止します。 |
| `NoAction`, `Unknown` | ナビゲーション アクションがない、または未認識のアクションで、レビューが必要です。 |

外部宛先は [getExternalUrl](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/getexternalurl/) で取得し、特定の内部宛先は [getTargetSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/gettargetslide/) で取得します。内部アクションや組み込みコマンドは外部 URL を持たないことがあります。空の URL がコンテナにアクションがないことを意味するわけではありません。[getExternalUrlOriginal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) が正規化された URL と異なる場合はその値を保持し、利用可能な場合は [getTooltip](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlink/gettooltip/) が返すツールチップも含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

次の PHP サンプルは既存のプレゼンテーション（上記で作成したファイル）を読み取り、`hyperlink-audit.json` を書き出し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方のアクティベーション タイプを確認します。変更前にコンテナを収集し、同一コンテナを二度処理しないよう参照等価性を利用します。プレゼンテーション クエリは通常スライドを対象とし、パッケージ全体のインベントリとしてマスター、レイアウト、ノート、ノートおよび配布資料マスターも明示的にクエリします。

レポートは 1 基準のスライドインデックスと、利用可能な場合は [getSlideId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getSlideId--) を記録します。[ISlideComponent::getSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecomponent/#getSlide--) はサポートされるコンテナの所有スライドを提供します。マスター、レイアウト、ノートは通常のスライドインデックスがなく、スコープで識別されます。シェイプ コンテナとテキスト部分フォーマット コンテナは別々にラベル付けされ、他のコンテナタイプは実行時の型名を保持します。各コンテナにはレポート内でローカル ID が付与され、2 つのアクションを相関付けられます。レポートはアクション種別を PHP 列挙で定義された整数定数として保存します。

この制限的なポリシーは、絶対 HTTPS URL と有効な内部スライド ターゲットのみを許可します。マクロ、プログラム、ファイル アクション、その他のスライドショー アクション、未確認アクション、他の URL スキームは拒否されます。これらの拒否はポリシー上の判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼を保証できません。ホスト許可リストやその他のチェックをアプリケーション側で追加してください。元の外部 URL と正規化された URL の両方がチェック対象です。例はメタデータを監査し、リンクをたどったりアクションを実行したりはしません。

修復のために、コンテナの [getHyperlinkManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) は [setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) をサポートします。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディングページに置き換え、その他の禁止クリックと禁止マウスオーバー アクションは個別に削除します。`$replaceExternalClicks` を `false` に設定すると、すべてのポリシー違反を削除します。デプロイ前にアプリケーション所有の置換ページを選定してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用します。マウスオーバー アクションと外部リンク以外のスライドジャンプを潜在的にサポート外としてマークします。これはレビューのヒントであり、機能テストや未マークリンクがエクスポートに残る保証ではありません。サポートされる [PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/php-java/convert-powerpoint-to-html/) エクスポートはアクション、エクスポートオプション、ビューアに応じてハイパーリンクを保持できる場合があります。ラスタ画像 [images](/slides/ja/php-java/convert-powerpoint-to-png/) と [video](/slides/ja/php-java/convert-powerpoint-to-video/) はインタラクティブ ハイパーリンクを保持できないため、これらの出力向けに監査する際はすべてのアクションにフラグを付けてください。

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

上記入力で作成されたレポートには 5 行のアクションが含まれます。ファイルマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライド ナビゲーションは残ります。検証結果は禁止アクションがゼロであることを示します。禁止外部クリック URL を含む入力は置換ブランチも実行します。許可されたクリックと禁止マウスオーバーを持つコンテナはクリック アクションを保持します。

この選択的クリーンアップは、[removeAllHyperlinks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) がポリシーに関係なく選択されたスコープ内の両方のアクティベーション タイプを削除するものとは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF や HTML ファイルの検証は行いません。

## **よくある質問**

**セクションまたはその最初のスライドにリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスター スライドの要素にハイパーリンクを付与すれば、すべてのスライドで機能しますか？**

はい。マスター スライドおよびレイアウト要素はハイパーリンクをサポートします。これらの要素に付いたリンクは、対応するマスターまたはレイアウトを使用しているスライドのスライドショー中に利用可能です。

**ハイパーリンクは PDF、HTML、画像、またはビデオへのエクスポート時に保持されますか？**

サポートされる PDF と HTML のエクスポートはハイパーリンクを保持できる場合がありますが、ラスタ画像やビデオは保持できません。詳細は [ハイパーリンクのレポート、サニタイズ、検証](#report-sanitize-and-verify-hyperlinks) のエクスポートに関する考慮事項をご覧ください。