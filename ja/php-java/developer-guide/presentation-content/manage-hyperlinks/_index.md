---
title: PHPでプレゼンテーションのハイパーリンクを管理
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/php-java/manage-hyperlinks/
keywords:
- URLを追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクを書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- ビデオハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用し、PHP のサンプルで、PowerPoint および OpenDocument のプレゼンテーションにおけるハイパーリンクの追加、書式設定、更新、削除を行います。"
---
## **はじめに**

ハイパーリンクは、プレゼンテーションのコンテンツを Web サイトまたはプレゼンテーション内の場所に接続します。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます:

* テキスト、図形、またはメディア フレームから Web サイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for PHP via Java を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除できます。以下の例は、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレーム レベルでハイパーリンクにアクセスする方法を示しています。PHP/Java Bridge と Aspose.Slides PHP ラッパーが初期化されていることを前提としています。PHP リファレンス ページがない API メンバーは、基盤となる Java API へのリンクです。

{{% alert color="info" title="Note" %}}
[無料オンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/editor)でプレゼンテーションを編集することもできます。
{{% /alert %}} 

## **URL ハイパーリンクを追加**

テキスト、図形、またはメディア フレームに Web サイトの URL を割り当てることができます。ハイパーリンクを割り当てた要素がクリック領域を決定します。テキスト部分の場合は選択したテキストがリンクされ、図形やフレームの場合はスライド オブジェクトがリンクされます。

相対ハイパーリンクを含むプレゼンテーションについては、[ハイパーリンクベースの管理](/slides/ja/php-java/presentation-properties/#manage-the-hyperlink-base) を参照し、ドキュメント レベルのベースの読み取り、変更、クリアを行ってください。

### **テキストへの URL ハイパーリンクの追加**

テキストを Web サイトにリンクさせるには、以下のようにテキスト部分の [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) メソッドに [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) を渡します。指定したテキスト部分だけがクリック可能になります。

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

図形またはフレームをクリック可能にするには、その [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) メソッドを呼び出します。ハイパーリンクは、内部のテキスト部分ではなくオブジェクト自体に属します。

画像、オーディオ、ビデオ フレームにも同様の方法が適用されます。フレームにハイパーリンクを割り当て、必要に応じて [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) を呼び出します。

以下の例は、矩形をクリック可能にします：

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

## **ハイパーリンクを使用して目次を作成**

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。以下の例では、[setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) を使用して、1 枚目のスライドの「Page 2」テキストを 2 枚目のスライドにリンクさせています。

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

[Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) の [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) メソッドは、ハイパーリンクがプレゼンテーションのハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタム テキスト色を適用するには、[HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入されました。古いバージョンではこの設定は適用されません。

以下の例は、同じスライドに 2 つのテキスト ハイパーリンクを追加します。1 つ目は赤いテキスト塗りつぶしを使用し、2 つ目はデフォルトのハイパーリンク色を保持します。

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

ハイパーリンクは、アクティブ化時にサウンドを再生したり、再生中のサウンドを停止したりできます。これらの動作を設定するには、次のメソッドを使用します。

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) はハイパーリンクに関連付けるオーディオを指定します。
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) はハイパーリンクをアクティブ化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドを追加**

以下の例は `sampleaudio.wav` を読み込み、1 枚目のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライドの 2 番目の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

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

#### **ハイパーリンク サウンドを抽出**

以下の例は、上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンクオーディオを [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) と [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) を介してメモリに読み込みます。

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

テキストまたは図形にハイパーリンクを割り当てた後、次の [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) メソッドを呼び出すことができます。

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) はリンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) は適用可能な場合、親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) はリンクをアクティブ化したときに、目的地が閲覧したハイパーリンクの一覧に追加されるかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) はクリック時にハイパーリンクがハイライト表示されるかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除**

[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) を使用して、テキスト部分のリンクを含むハイパーリンク コンテナを収集し、変更する前に取得します。以下の例は、1 枚目のスライドから両方のアクティベーション タイプを削除します。1 つだけ削除する場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) または [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) のみを呼び出します。クリック アクションを削除しても、マウスオーバー対応は削除されません。

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

無条件に削除する場合は、[removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) が選択したスコープですべてのアクティベーション タイプを一度に削除します。マスタ、レイアウト、ノートの選択的クリーンアップとカバレッジについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **完全なハイパーリンクインベントリを作成**

プレゼンテーションを配布する前に、インタラクティブなアクションと Web リンクのインベントリを作成します。[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) は URL 文字列のフラットリストではなく、[IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) オブジェクトを返します。各コンテナで [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) と [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) の両方を調べます。これらは独立しており、同一コンテナが両方のアクションを持つことがあるため、完全なレポートではコンテナごとに最大 2 行が必要です。

形状レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随したリンクが見落とされる可能性があります。代わりに適切なスコープをクエリし、返されたコンテナを保持して後でアクションを更新または削除できるようにします。

### **プレゼンテーション、スライド、テキスト フレーム スコープのクエリ**

[HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) クラスは、[Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/)、[IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)、[TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) から利用できます。各スコープは同じクエリをサポートします:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) はクリック アクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) はマウスオーバー アクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) はいずれか、または両方のアクションを持つコンテナを返します。

以下の例は、外部クリックリンク、ファイルマウスオーバーリンク、内部スライド ナビゲーション、テキストマウスオーバーリンク、マクロ アクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。同じ 3 つのクエリはすべてのスコープで機能し、カウントはコンテナ数を示し、アクション総数ではありません。テキスト フレーム スコープは、囲む形状自身のリンクを除外します。

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

この例では、プレゼンテーションとスライドのクエリはそれぞれ 3 つのクリック コンテナ、2 つのマウスオーバー コンテナ、いずれかのアクションを持つ 3 つのコンテナを報告します。テキスト フレームのクエリは各カテゴリで 1 つのコンテナを報告します。

### **アクションと宛先の分類**

[Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) を使用して、宛先を解釈する前にアクションを解釈します。[HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) の値は Web ナビゲーションだけでなく、以下を含みます:

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク；URL とそのスキームを確認してください。 |
| `JumpSpecificSlide` | 特定のスライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 組み込みのスライドショー ナビゲーションで、スライドショー コンテキストで解決されます。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了するか、カスタムショーを開始します。 |
| `StartMacro` | マクロを実行します。 |
| `StartProgram` | プログラムを起動します。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開きます；Web URL とは別に確認してください。 |
| `StartStopMedia` | メディア再生を開始または停止します。 |
| `NoAction`, `Unknown` | ナビゲーション アクションがない、または未確認のアクションで、レビューが必要です。 |

[getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) から外部の宛先を読み取り、[getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) から特定の内部宛先を読み取ります。内部アクションや組み込みコマンドには外部 URL がない場合があります。URL が空でもコンテナにアクションがないことを意味しません。[getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) が正規化された URL と異なる場合はその値を保持し、利用可能な場合は [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) が返すツールチップも含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の PHP の例は、既存のプレゼンテーションを読み込み（上で作成したファイルを使用）、`hyperlink-audit.json` に書き出し、ポリシーを適用し、`hyperlink-sanitized.pptx` として保存し、再度開いて両方のアクティベーション タイプを確認します。変更前にコンテナを収集し、参照の等価性を使用して同一コンテナの二重処理を防ぎます。プレゼンテーションのクエリは通常のスライドを対象とし、パッケージ全体のインベントリについては、必要に応じてマスタ、レイアウト、ノート、ノートおよび配布資料マスタも明示的にクエリします。

レポートは、利用可能な場合に 1 から始まるスライドインデックスと [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) を記録します。[ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) はサポート対象コンテナの所有スライドを提供します。マスタ、レイアウト、ノートは通常のスライドインデックスを持たず、スコープで識別されます。図形コンテナとテキスト部分の書式コンテナは別々にラベル付けされ、その他のコンテナタイプはランタイムタイプ名を保持します。各コンテナにはレポート内でローカル ID が付与され、2 つのアクションを関連付けられます。レポートはアクションタイプを PHP 列挙体で定義された整数定数として保存します。

この意図的に制限されたアプリケーション ポリシーは、絶対 HTTPS URL と有効な内部スライド ターゲットのみを許可します。マクロ、プログラム、ファイル アクション、その他のスライドショー アクション、未知のアクション、その他の URL スキームは拒否されます。これらの拒否はポリシー判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼を確立できないため、ホスト許可リストやその他のチェックをアプリケーションに追加してください。元の URL と正規化された外部 URL の両方がチェックされます。例はリンクをたどったりアクションを実行したりせずにメタデータを監査します。

修正のために、コンテナの [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) は [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)、[removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) をサポートします。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディング ページに置き換え、他の禁止クリックと禁止マウスオーバー アクションは個別に削除します。すべてのポリシー違反を削除するには、`$replaceExternalClicks` を `false` に設定してください。展開前に、アプリケーション所有の置換ページを選択してください。

レポートのエクスポートフラグは、保守的な PDF レビュー ポリシーを使用します：マウスオーバー アクションや外部リンクまたは特定スライドジャンプ以外のすべてを潜在的に未サポートとしてフラグ付けします。これはレビューのヒントであり、機能テストやフラグが付いていないリンクがエクスポートで保持される保証ではありません。サポートされている [PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) および [HTML](/slides/ja/php-java/convert-powerpoint-to-html/) エクスポートは、アクション、エクスポートオプション、ビューアに応じてハイパーリンクを保持できる場合があります。ラスタ画像 [images](/slides/ja/php-java/convert-powerpoint-to-png/) と [video](/slides/ja/php-java/convert-powerpoint-to-video/) はインタラクティブなハイパーリンクを保持できません；それらの出力を監査する際はすべてのアクションにフラグを付けてください。

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

上記で作成した入力に対して、レポートには 5 行のアクションが含まれます。ファイルのマウスオーバー リンクとマクロクリックは削除され、HTTPS リンクと内部スライド ナビゲーションは残ります。検証では禁止アクションは 0 件と出力されます。禁止された外部クリック URL を含む入力は置換分岐も実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリック アクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく選択したスコープ全体の両方のアクティベーション タイプを削除する [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) とは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツは削除せず、エクスポートされた PDF や HTML ファイルの検証も行いません。

## **よくある質問**

**セクションまたはその最初のスライドにリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスタースライドの要素にハイパーリンクを添付して、すべてのスライドで機能させることはできますか？**

はい。マスタースライドとレイアウトの要素はハイパーリンクをサポートしています。これらの要素のリンクは、対応するマスターまたはレイアウトを使用するスライドのスライドショー中に利用可能です。

**PDF、HTML、画像、または動画にエクスポートする際にハイパーリンクは保持されますか？**

サポートされている PDF および HTML のエクスポートはハイパーリンクを保持できる場合がありますが、ラスタ画像や動画は保持できません。エクスポートに関する考慮事項は、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。