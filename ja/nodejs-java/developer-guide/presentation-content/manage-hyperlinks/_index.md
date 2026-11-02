---
title: JavaScript でプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/nodejs-java/manage-hyperlinks/
keywords:
- URL の追加
- ハイパーリンクの追加
- ハイパーリンクの作成
- ハイパーリンクの書式設定
- ハイパーリンクの削除
- ハイパーリンクの更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- ビデオハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用し、JavaScript の例で PowerPoint と OpenDocument のプレゼンテーションにハイパーリンクを追加、書式設定、更新、削除します。"
---
## **Introduction**

ハイパーリンクはプレゼンテーションのコンテンツをウェブサイトやプレゼンテーション内の場所に接続します。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディアフレームからウェブサイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for Node.js via Java を使用すると、これらのリンクを追加、外観やサウンドの制御、プロパティの更新、削除ができます。以下の例では、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキストフレームレベルでハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}

[無料のオンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/editor)でもプレゼンテーションを編集できます。

{{% /alert %}} 

## **Add URL Hyperlinks**

テキスト、図形、またはメディアフレームにウェブサイトの URL を割り当てられます。ハイパーリンクを割り当てる要素に応じてクリック可能領域が決まります。テキストの一部に割り当てた場合は選択したテキストがリンクとなり、図形やフレームに割り当てた場合はスライドオブジェクト全体がリンクになります。

相対ハイパーリンクを含むプレゼンテーションについては、[Manage the Hyperlink Base](/slides/ja/nodejs-java/presentation-properties/#manage-the-hyperlink-base) を参照し、ドキュメントレベルのベースを読み取り、変更、またはクリアしてください。

### **Add URL Hyperlinks to Text**

テキストをウェブサイトにリンクさせるには、テキスト部分の [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) メソッドに [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) を渡します。下記の例のように、対象となるテキスト部分だけがクリック可能になります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Add URL Hyperlinks to Shapes and Media Frames**

図形やフレームをクリック可能にするには、そのオブジェクトの [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) メソッドを呼び出します。ハイパーリンクはオブジェクト自体に所属し、内部のテキスト部分には属しません。

画像、音声、動画フレームでも同様に、フレームにハイパーリンクを割り当て、必要に応じて [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) を呼び出します。

次の例は矩形をクリック可能にします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Use Hyperlinks to Create a Table of Contents**

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。以下の例では、最初のスライドの「Page 2」テキストを [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) で 2 番目のスライドにリンクさせています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Format Hyperlinks**

### **Color**

[Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) の [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) メソッドは、ハイパーリンクがプレゼンテーションのハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタム文字色を適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、旧バージョンでは設定が適用されません。

次の例は同一スライドに 2 つのテキストハイパーリンクを追加します。1 つ目は赤い文字塗りつぶしを使用し、2 つ目はデフォルトのハイパーリンク色を保持します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Sound**

ハイパーリンクは、アクティブ化時にサウンドを再生したり、既に再生中のサウンドを停止したりできます。以下のメソッドで動作を設定します。

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) はハイパーリンクに関連付けるオーディオを指定します。
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) はハイパーリンクを有効化したときに前のサウンドを停止するかどうかを制御します。

#### **Add a Hyperlink Sound**

次の例は `sampleaudio.wav` を読み込み、最初のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Extract a Hyperlink Sound**

次の例は前節で作成したプレゼンテーションを開き、最初の図形のハイパーリンク音声を [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) と [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) を使用してメモリに読み込みます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip and Interaction Settings**

テキストまたは図形にハイパーリンクを割り当てた後、次の [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) メソッドを呼び出せます。

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) はリンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) は必要に応じて親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) はリンクを有効化したときに目的地を閲覧履歴に追加するかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) はクリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **Remove Hyperlinks from Presentations**

[getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) を使用して、テキスト部分リンクを含むハイパーリンクコンテナを取得し、変更前に収集します。下の例は最初のスライドから両方のアクティベーションタイプを削除します。1 つだけ削除したい場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) または [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) のみを呼び出してください。クリックアクションを削除してもマウスオーバー側は削除されません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

無条件に削除する場合は、[removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) が選択したスコープ内の両方のアクティベーションタイプを一括で削除します。マスター、レイアウト、ノートを対象にした選択的クリーンアップについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **Build a Complete Hyperlink Inventory**

プレゼンテーションを配布する前に、インタラクティブアクションとウェブリンクのインベントリを作成します。[getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) はハイパーリンクコンテナを返し、URL 文字列のフラットリストは返しません。各コンテナで [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) と [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) を確認してください。これらは独立しており、同一コンテナが両方のアクションを持つことがあります。そのため、完全なレポートではコンテナごとに最大 2 行が必要です。

テキスト部分に付随したリンクを見落とさないよう、形状レベルだけでなく適切なスコープでクエリを実行し、取得したコンテナを保持して後で更新または削除できるようにします。

### **Query Presentation, Slide, and Text-Frame Scopes**

[HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) クラスは [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)、[BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries)、[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) から取得できます。各スコープは同一のクエリをサポートします。

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) はクリックアクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) はマウスオーバーアクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) はいずれか、または両方のアクションを持つコンテナを返します。

次の例は外部クリックリンク、ファイルマウスオーバーリンク、内部スライドナビゲーション、テキストマウスオーバーリンク、マクロアクションを持つ `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。同じ 3 つのクエリがすべてのスコープで機能し、カウントはコンテナ数を示します。テキストフレームスコープは囲む図形自身のリンクを除外します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この例では、プレゼンテーションとスライドのクエリはそれぞれクリックコンテナが 3 件、マウスオーバーコンテナが 2 件、いずれかのアクションを持つコンテナが 3 件と報告します。テキストフレームクエリは各カテゴリで 1 件ずつ報告します。

### **Classify Actions and Destinations**

[Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) を使用してアクションを判別し、続いて目的地を解釈します。[HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) の値はウェブナビゲーション以外もカバーします。

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク; URL とスキームを確認 |
| `JumpSpecificSlide` | 特定スライドへの内部ナビゲーション |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | スライドショー内の組み込みナビゲーション |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了 または カスタムショーを開始 |
| `StartMacro` | マクロを実行 |
| `StartProgram` | プログラムを起動 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別プレゼンテーションを開く; ウェブ URL とは別にレビュー |
| `StartStopMedia` | メディア再生を開始または停止 |
| `NoAction`, `Unknown` | ナビゲーションなし、または未確認アクションでレビューが必要 |

外部目的地は [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) で取得し、内部目的地は [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) で取得します。内部アクションや組み込みコマンドは外部 URL を持たないことがあります。空の URL がコンテナにアクションがないことを意味するわけではありません。正規化された URL と異なる場合は [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) の値を保持し、利用可能な場合は [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) で取得したツールチップも含めます。

### **Report, Sanitize, and Verify Hyperlinks**

以下の JavaScript 例は、既存のプレゼンテーション（前節で作成したファイル）を読み取り、`hyperlink-audit.json` を書き出し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方のアクティベーションタイプをチェックします。変更前にコンテナを収集し、参照等価性で同一コンテナの二重処理を防ぎます。プレゼンテーションクエリは通常スライドを対象とし、パッケージ全体のインベントリが必要な場合はマスター、レイアウト、ノート、ノート・ハンドアウトマスターも明示的にクエリします。

レポートは 1 基準のスライドインデックスと、利用可能な場合は [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) を記録します。[getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) はサポート対象コンテナの所有スライドを提供します。マスター、レイアウト、ノートは通常スライドインデックスを持たず、スコープで識別されます。形状コンテナとテキスト部分書式コンテナは別々にラベル付けされ、他のコンテナタイプは実行時の型名を保持します。各コンテナにはレポート内でローカル ID が付与され、2 つのアクションを相関付けられます。アクションタイプは HyperlinkActionType 列挙体の整数定数として保存されます。

この制限的なポリシーは、絶対 HTTPS URL と有効な内部スライドターゲットのみを許可します。マクロ、プログラム、ファイルアクション、その他のスライドショーアクション、未知のアクション、その他の URL スキームは除外されます。これらの除外はポリシー上の決定であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼が確立できないため、ホスト許可リストやその他のチェックを追加してください。元の URL と正規化された外部 URL の両方が検査対象です。この例はリンク先にアクセスしたりアクションを実行したりせず、メタデータのみを監査します。

修正には、コンテナの [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) が [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)、[removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) をサポートします。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディングページに置き換え、その他の禁止クリックと禁止マウスオーバーは個別に削除します。`replaceExternalClicks` を `false` に設定すると、すべてのポリシー違反を削除します。デプロイ前にアプリケーション所有の代替ページを用意してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用し、マウスオーバーアクションや外部リンク以外・特定スライドジャンプ以外を潜在的に未サポートとしてフラグ付けします。これは機能テストではなく、フラグが付いていないリンクが必ずエクスポートに残る保証でもありません。サポート対象の [PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/) エクスポートはアクション、エクスポートオプション、ビューアによりハイパーリンクを保持できる場合があります。ラスタ画像 [images](/slides/ja/nodejs-java/convert-powerpoint-to-png/) と [video](/slides/ja/nodejs-java/convert-powerpoint-to-video/) はインタラクティブハイパーリンクを保持できないため、これらの出力向けに監査する際はすべてのアクションにフラグを付けてください。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

上記の入力で作成したレポートは 5 行のアクションを含みます。ファイルマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライドナビゲーションは残ります。検証は禁止アクションを 0 件と出力します。禁止された外部クリック URL を含む入力は置換ブランチも実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリックアクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく選択したスコープ内の両方のアクティベーションタイプを削除する [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) とは異なります。ここでの検証はハイパーリンクアクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブコンテンツは削除せず、エクスポートされた PDF や HTML の検証も行いません。

## **FAQ**

**How can I link to a section or its first slide?**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへの移動を作成するには、そのセクションの最初のスライドにリンクしてください。

**Can I attach a hyperlink to master slide elements so it works on all slides?**

はい。マスタースライドやレイアウト要素はハイパーリンクをサポートします。これらの要素に設定したリンクは、対応するマスターやレイアウトを使用しているスライドのスライドショー中に利用可能です。

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

サポートされている PDF と HTML のエクスポートはハイパーリンクを保持できる場合がありますが、ラスタ画像やビデオは保持できません。詳細は [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) のエクスポート考慮事項をご参照ください。