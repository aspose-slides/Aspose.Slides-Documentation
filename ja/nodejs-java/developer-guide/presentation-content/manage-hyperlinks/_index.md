---
title: JavaScript でプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/nodejs-java/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js 用 Aspose.Slides for Java を使用し、JavaScript の例で PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを追加、書式設定、更新、削除します。"
---
## **概要**

ハイパーリンクはプレゼンテーションのコンテンツを Web サイトやプレゼンテーション内の特定の場所に接続します。PowerPoint ではハイパーリンクは主に以下の 2 つの目的で使用されます。

* テキスト、図形、またはメディア フレームから Web サイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for Node.js via Java を使用すると、これらのリンクを追加したり、外観やサウンドを制御したり、プロパティを更新したり、削除したりできます。以下の例では、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレームレベルでハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}
[無料のオンライン Aspose PowerPoint エディタ](https://products.aspose.app/slides/ja/editor)でもプレゼンテーションを編集できます。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディア フレームに Web サイトの URL を割り当てることができます。ハイパーリンクを割り当てる要素によってクリック領域が決まります。テキストの一部に割り当てると選択したテキストだけがクリック可能になり、図形やフレームに割り当てるとスライド オブジェクト全体がクリック可能になります。

### **テキストへの URL ハイパーリンクの追加**

テキストを Web サイトにリンクするには、以下のようにテキスト部分の [setHyperlinkClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) メソッドに [Hyperlink](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink) を渡します。指定したテキスト部分だけがクリック可能になります。

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

### **図形およびメディア フレームへの URL ハイパーリンクの追加**

図形またはフレームをクリック可能にするには、そのオブジェクトの [setHyperlinkClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Shape#setHyperlinkClick) メソッドを呼び出します。ハイパーリンクはテキスト部品ではなくオブジェクト自体に属します。

画像、音声、動画フレームにも同様のアプローチが適用されます。フレームにハイパーリンクを割り当て、必要に応じて [setTooltip](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#setTooltip) を呼び出します。

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

## **目次作成のためのハイパーリンクの使用**

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。以下の例は、最初のスライド上の「Page 2」テキストを 2 番目のスライドにリンクするために [setInternalHyperlinkClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) を使用しています。

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

## **ハイパーリンクの書式設定**

### **色**

[Hyperlink](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink) の [setColorSource](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#setColorSource) メソッドは、ハイパーリンクがプレゼンテーションのハイパーリンク色を使用するか、テキスト部品の書式設定を使用するかを決定します。カスタム テキスト色を適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkColorSource) を選択し、部品の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、旧バージョンでは設定が適用されません。

次の例は同じスライドに 2 つのテキストハイパーリンクを追加します。1 つ目は赤いテキスト塗りつぶし、2 つ目はデフォルトのハイパーリンク色を使用します。

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
### **サウンド**

ハイパーリンクはアクティブ時にサウンドを再生したり、再生中のサウンドを停止したりできます。以下のメソッドでこれらの動作を設定します。

- [Hyperlink.setSound](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#setSound) はハイパーリンクに関連付ける音声を指定します。
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) はハイパーリンクをアクティブ化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンクサウンドの追加**

次の例は `sampleaudio.wav` を読み込み、最初のスライド上のボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

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

#### **ハイパーリンクサウンドの抽出**

次の例は上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンク音声を [getSound](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#getSound) と [getBinaryData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Audio#getBinaryData) を使用してメモリに読み取ります。

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

### **ツールチップとインタラクション設定**

テキストまたは図形にハイパーリンクを割り当てた後、次の [Hyperlink](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink) メソッドを呼び出すことができます。

- [setTooltip](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#setTooltip) は閲覧者がリンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) は該当する場合、親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#setHistory) はリンクをアクティブ化したときにその宛先を閲覧済みハイパーリンクの一覧に追加するかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) はクリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

ハイパーリンク コンテナ（テキスト部品リンクを含む）を変更する前に収集するには、[getAnyHyperlinks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) を使用します。次の例は最初のスライドから両方のアクティベーション タイプ（クリックとマウスオーバー）を削除します。片方だけを削除したい場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) または [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) を単独で呼び出してください。クリック アクションを削除してもマウスオーバーは残ります。

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

条件なしで削除する場合、[removeAllHyperlinks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) を使用すると、選択したスコープ内の両方のアクティベーション タイプが一度に削除されます。マスタ、レイアウト、ノートまで含めた選択的クリーンアップについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **完全なハイパーリンク インベントリの作成**

プレゼンテーションを配布する前に、インタラクティブ アクションと Web リンクの両方をインベントリ化します。[getAnyHyperlinks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) はハイパーリンク コンテナの集合を返し、単純な URL 文字列のリストは返しません。各コンテナで [getHyperlinkClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Shape#getHyperlinkClick) と [getHyperlinkMouseOver](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) を調べます。これらは独立しており、同じコンテナが両方のアクションを持つことがあるため、完全なレポートではコンテナあたり最大 2 行が必要です。

テキスト部品に付随したリンクはシェイプ レベルのハイパーリンクだけをスキャンすると見逃す可能性があります。適切なスコープでクエリを実行し、返されたコンテナを保持して後でアクションの更新や削除に利用してください。

### **プレゼンテーション、スライド、テキスト フレーム スコープのクエリ**

[HyperlinkQueries](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkQueries) クラスは [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)、[BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) および [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) から取得できます。各スコープは同じクエリをサポートします。

- [getHyperlinkClicks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) はクリック アクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) はマウスオーバー アクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) はいずれか、または両方のアクションを持つコンテナを返します。

次の例は外部クリックリンク、ファイルマウスオーバーリンク、内部スライド ナビゲーション、テキストマウスオーバーリンク、マクロ アクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。同じ 3 つのクエリはすべてのスコープで機能し、カウントはコンテナ数を示します。テキスト フレーム スコープは囲むシェイプ自身のリンクを除外します。

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

この例では、プレゼンテーションとスライドのクエリはそれぞれクリック コンテナが 3 件、マウスオーバー コンテナが 2 件、いずれかのアクションを持つコンテナが 3 件と報告します。テキスト フレームのクエリは各カテゴリで 1 件ずつ報告します。

### **アクションと宛先の分類**

[Hyperlink.getActionType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#getActionType) を使用してアクションの種類を判別し、その後で宛先を解釈します。[HyperlinkActionType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkActionType) の値は Web ナビゲーション以外もカバーします。

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク；URL とスキームを確認 |
| `JumpSpecificSlide` | 特定スライドへの内部ナビゲーション |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | スライドショー内の組み込みナビゲーション |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了、またはカスタムショーを開始 |
| `StartMacro` | マクロを実行 |
| `StartProgram` | プログラムを起動 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別プレゼンテーションを開く；Web URL とは別に確認 |
| `StartStopMedia` | メディアの再生/停止 |
| `NoAction`, `Unknown` | ナビゲーションがなし、または未確認のアクションでレビューが必要 |

外部宛先は [getExternalUrl](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) で取得し、内部の特定スライドは [getTargetSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) で取得します。内部アクションや組み込みコマンドは外部 URL を持たないことがあります。空の URL がコンテナにアクションがないことを意味するわけではありません。[getExternalUrlOriginal](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) が正規化された URL と異なる場合はその値を保持し、利用可能な場合は [getTooltip](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Hyperlink#getTooltip) が返すツールチップも含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の JavaScript例は既存のプレゼンテーション（前述のファイル）を読み込み、`hyperlink-audit.json` に書き出し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方のアクティベーション タイプをチェックします。変更前にコンテナを収集し、同一コンテナを二度処理しないよう参照等価で管理します。プレゼンテーション クエリは通常スライドを対象とし、パッケージ全体のインベントリが必要な場合はマスタ、レイアウト、ノート、ノートおよびハンドアウト マスタも明示的にクエリします。

レポートは 1 ベースのスライドインデックスと、利用可能な場合は [getSlideId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/BaseSlide#getSlideId) を記録します。サポート対象のコンテナは [getSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Shape#getSlide) で所有スライドを取得できます。マスタ、レイアウト、ノートは通常スライドインデックスを持たず、スコープで識別されます。シェイプ コンテナとテキスト部品フォーマット コンテナは別々にラベル付けされ、他のコンテナ種別は実行時の型名を保持します。各コンテナにはレポート内ローカル ID が付与され、2 つのアクションを相関付けられます。アクション種別は HyperlinkActionType 列挙体の整数定数として保存されます。

このポリシーは絶対 HTTPS URL と有効な内部スライドターゲットのみを許可し、マクロ、プログラム、ファイル アクション、その他のスライドショー アクション、未知のアクション、その他の URL スキームは拒否します。これらの拒否はポリシー判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼を確立できないため、ホスト許可リストや追加チェックを実装してください。オリジナルと正規化された外部 URL の両方がチェック対象です。例はリンクをたどったりアクションを実行したりせず、メタデータのみを監査します。

修正時はコンテナの [getHyperlinkManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Shape#getHyperlinkManager) を使用し、[setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) を呼び出します。禁止された外部クリックリンクは固定の HTTPS ランディングページに置き換え、禁止されたクリックやマウスオーバーは個別に削除します。ポリシー違反をすべて削除したい場合は `replaceExternalClicks` を `false` に設定してください。デプロイ前にアプリケーション所有の置換ページを用意してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用します。マウスオーバー アクションや外部リンク以外、特定スライドジャンプ以外のものは「サポート外」としてフラグ付けします。これはレビューのヒントであり、機能テストやフラグ付けされていないリンクがエクスポートで必ず残る保証ではありません。サポート対象の [PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/) エクスポートはアクションやオプション、ビューアによりハイパーリンクを保持する場合があります。ラスタ画像 [images](/slides/ja/nodejs-java/convert-powerpoint-to-png/) と [video](/slides/ja/nodejs-java/convert-powerpoint-to-video/) はインタラクティブ ハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

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

上記の入力で作成したレポートは 5 行のアクションを含みます。ファイルマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライド ナビゲーションは保持されます。検証は禁止アクションが 0 件であることを出力します。禁止された外部クリック URL を含む入力は置換ロジックも実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリック アクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく両方のアクティベーション タイプを削除する [removeAllHyperlinks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) とは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF/HTML の有効性は検証しません。

## **FAQ**

**セクションまたはその最初のスライドにリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成する場合は、そのセクションの最初のスライドにリンクしてください。

**マスタースライドの要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスタースライドとレイアウトの要素はハイパーリンクをサポートします。これらの要素に付いたリンクは、対応するマスターまたはレイアウトを使用しているスライドのスライドショー中に利用可能です。

**PDF、HTML、画像、動画へエクスポートするときにハイパーリンクは保持されますか？**

サポート対象の PDF と HTML エクスポートはハイパーリンクを保持する可能性がありますが、ラスタ画像や動画は保持できません。詳細は [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) のエクスポートに関する考慮事項をご覧ください。