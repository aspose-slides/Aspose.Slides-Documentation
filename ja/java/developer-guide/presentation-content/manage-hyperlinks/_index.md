---
title: Java でプレゼンテーション ハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/java/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクを書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキスト ハイパーリンク
- スライド ハイパーリンク
- 図形 ハイパーリンク
- 画像 ハイパーリンク
- 動画 ハイパーリンク
- 変更可能なハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用し、Java のサンプルで PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを追加、書式設定、更新、削除します。"
---
## **イントロダクション**

ハイパーリンクはプレゼンテーションのコンテンツをウェブサイトやプレゼンテーション内の場所に接続します。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディア フレームからウェブサイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for Java を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除することができます。以下の例では、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレーム レベルでハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}
[無料のオンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/ja/editor)でもプレゼンテーションを編集できます。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディア フレームにウェブサイトの URL を割り当てることができます。ハイパーリンクを割り当てる要素によってクリック可能領域が決まります。テキスト部分に割り当てた場合は選択されたテキストが、図形やフレームに割り当てた場合はスライド オブジェクト全体がクリック可能になります。

### **テキストへの URL ハイパーリンクの追加**

テキストをウェブサイトにリンクするには、以下の例のようにテキスト部分の [setHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) メソッドに [Hyperlink](https://reference.aspose.com/slides/ja/java/com.aspose.slides/hyperlink/) を渡します。クリック可能になるのはそのテキスト部分だけです。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **図形およびメディア フレームへの URL ハイパーリンクの追加**

図形やフレームをクリック可能にするには、[setHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) メソッドを呼び出します。ハイパーリンクはテキスト部分ではなくオブジェクト自体に属します。

画像、音声、動画フレームでも同様に、フレームにハイパーリンクを割り当て、必要に応じて [setTooltip](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) を呼び出します。

次の例は四角形をクリック可能にします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ハイパーリンクを使用した目次の作成**

内部ハイパーリンクを使用すると、読者は目次から特定のスライドへジャンプできます。以下の例では、最初のスライドの「Page 2」テキストを 2 番目のスライドにリンクするために [setInternalHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) を使用しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ハイパーリンクの書式設定**

### **色**

[IHyperlink](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/) の [setColorSource](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#setColorSource-int-) メソッドは、ハイパーリンクがプレゼンテーション全体のハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタム テキスト色を適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、古いバージョンでは適用されません。

次の例は同じスライドに 2 つのテキスト ハイパーリンクを追加します。1 つ目は赤いテキスト塗りつぶし、2 つ目はデフォルトのハイパーリンク色を使用します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **サウンド**

ハイパーリンクはアクティブ化時にサウンドを再生したり、再生中のサウンドを停止したりできます。以下のメソッドでこれらの動作を設定します。

- [IHyperlink.setSound](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) はハイパーリンクに関連付けるオーディオを指定します。
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) はハイパーリンクをアクティブ化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドの追加**

次の例は `sampleaudio.wav` を読み込み、最初のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **ハイパーリンク サウンドの抽出**

次の例は上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンク オーディオを [getSound](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#getSound--) と [getBinaryData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaudio/#getBinaryData--) を使ってメモリに読み込みます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **ツールチップとインタラクション設定**

テキストまたは図形にハイパーリンクを割り当てた後、次の [IHyperlink](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/) メソッドを呼び出すことができます。

- [setTooltip](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) はリンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) は適用可能な場合、親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) はリンクをアクティブ化したときにその先が閲覧履歴に追加されるかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) はクリック時にハイパーリンクがハイライト表示されるかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

ハイパーリンク コンテナ（テキスト部分のリンクを含む）を取得するには [getAnyHyperlinks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) を使用します。その後で変更を加えます。次の例は最初のスライドから両方のアクティベーション タイプを削除します。1 つだけ削除したい場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) または [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) のみを呼び出します。クリック アクションを削除してもマウスオーバー アクションは残ります。

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

条件なしにすべて削除する場合は、[removeAllHyperlinks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) を使用すると、選択したスコープ内の両方のアクティベーション タイプが 1 回の呼び出しで削除されます。マスター、レイアウト、ノートを含む選択的クリーンアップとカバレッジについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **ハイパーリンク インベントリの作成**

プレゼンテーションを配布する前に、インタラクティブ アクションとウェブ リンクのインベントリを作成します。[getAnyHyperlinks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) は [IHyperlinkContainer](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkcontainer/) オブジェクトを返し、URL 文字列のフラットリストではありません。各コンテナで [getHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) と [getHyperlinkMouseOver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) の両方を確認します。これらは独立しており、同じコンテナが両方のアクションを公開できるため、完全なレポートではコンテナごとに最大 2 行が必要です。

図形レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随したリンクが見逃される可能性があります。適切なスコープでクエリを実行し、返されたコンテナを保持して後でアクションを更新または削除できるようにします。

### **プレゼンテーション、スライド、テキスト フレームのスコープをクエリする**

[IHyperlinkQueries](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkqueries/) インターフェイスは [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--)、[IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)、[ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) から取得できます。各スコープは同じクエリをサポートします。

- [getHyperlinkClicks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) はクリック アクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) はマウスオーバー アクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) はいずれかまたは両方のアクションを持つコンテナを返します。

次の例は外部クリックリンク、ファイルマウスオーバーリンク、内部スライド ナビゲーション、テキストマウスオーバーリンク、マクロ アクションを持つ `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。3 つのクエリはすべてのスコープで同じように機能し、カウントはコンテナ数を示します。テキスト フレーム スコープは囲んでいる図形自体のリンクを除外します。

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この例では、プレゼンテーションおよびスライドのクエリはそれぞれクリック コンテナが 3 件、マウスオーバー コンテナが 2 件、いずれかのアクションを持つコンテナが 3 件報告します。テキスト フレームのクエリは各カテゴリで 1 件ずつ報告します。

### **アクションと宛先の分類**

[IHyperlink.getActionType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#getActionType--) を使用して、宛先を解釈する前にアクションの種類を判別します。[HyperlinkActionType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/hyperlinkactiontype/) の値はウェブ ナビゲーション以外もカバーします。

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク；URL とスキームを確認します。 |
| `JumpSpecificSlide` | 特定スライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | スライドショー内の組み込みナビゲーション。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了またはカスタムショーを開始します。 |
| `StartMacro` | マクロを実行します。 |
| `StartProgram` | プログラムを起動します。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開きます。ウェブ URL とは別に確認してください。 |
| `StartStopMedia` | メディアの再生または停止を行います。 |
| `NoAction`, `Unknown` | ナビゲーション アクションがない、または未確認のアクションで、レビューが必要です。 |

外部宛先は [getExternalUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#getExternalUrl--) で取得し、内部の特定スライドは [getTargetSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#getTargetSlide--) で取得します。内部アクションや組み込みコマンドは外部 URL を持たないことがあります。空の URL があるからといってコンテナにアクションがないわけではありません。正規化された URL と異なる場合は [getExternalUrlOriginal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) の値を保持し、利用可能な場合は [getTooltip](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlink/#getTooltip--) のツールチップも含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

次の Java 例は既存のプレゼンテーション（上記で作成したファイル）を読み込み、`hyperlink-audit.json` を書き出し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方のアクティベーション タイプを確認します。変更前にコンテナを収集し、同一コンテナの二重処理を防ぐために参照等価性を使用します。プレゼンテーション クエリは通常のスライドを対象とし、パッケージ全体のインベントリを取得するためにマスター、レイアウト、ノート、およびノート/ハンドアウト マスターも明示的にクエリします。

レポートは 1 ベースのスライドインデックスと、利用可能な場合は [getSlideId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getSlideId--) を記録します。[ISlideComponent.getSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecomponent/#getSlide--) はサポート対象コンテナの所有スライドを提供します。マスター、レイアウト、ノートは通常のスライドインデックスを持たず、スコープで識別されます。図形コンテナとテキスト部分フォーマットコンテナは別々にラベル付けされ、その他のコンテナは実行時の型名を保持します。各コンテナにはレポート内でローカル ID が付与され、2 つのアクションを相関付けられます。アクション種別は Java 列挙型で定義された整数定数として保存されます。

この制限的なアプリケーション ポリシーは、絶対 HTTPS URL と有効な内部スライド ターゲットのみを許可します。マクロ、プログラム、ファイル アクション、その他のスライドショー アクション、未知のアクション、その他の URL スキームは拒否されます。これらの拒否はポリシー上の判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼性は確立できないため、ホスト許可リストや他のチェックを追加してください。元の URL と正規化された外部 URL の両方がチェック対象です。この例はリンクをたどったりアクションを実行したりせず、メタデータのみを監査します。

修正の際は、コンテナの [getHyperlinkManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) を使用して [setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) を行います。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディングページに置き換え、その他の禁止クリックと禁止マウスオーバーは個別に削除します。`replaceExternalClicks` を `false` に設定すると、すべてのポリシー違反が削除されます。デプロイ前にアプリケーション所有の置換ページを選択してください。

レポートのエクスポート フラグは保守的な PDF レビュー ポリシーを使用します：マウスオーバー アクションや外部リンク以外のスライドジャンプは「サポートされない可能性あり」とフラグ付けします。これはレビュー用ヒントであり、機能テストやフラグが付いていないリンクがエクスポートで必ず保持される保証ではありません。サポートされる [PDF](/slides/ja/java/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/java/convert-powerpoint-to-html/) エクスポートはアクションやエクスポートオプション、ビューアに依存してハイパーリンクを保持することがあります。ラスタ画像 [images](/slides/ja/java/convert-powerpoint-to-png/) と [video](/slides/ja/java/convert-powerpoint-to-video/) はインタラクティブ ハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // 追加の JSON 依存関係なしでこのレポートのフラット行をシリアライズします。
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

上記の入力で作成されたレポートは 5 行のアクションを含みます。ファイルのマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライド ナビゲーションは残ります。検証は禁止アクションを 0 件として出力します。禁止された外部クリック URL を含む入力は置換ブランチを実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリック アクションを保持します。

この選択的クリーンアップは、[removeAllHyperlinks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) がポリシーに関係なく選択したスコープ内の両方のアクティベーション タイプを削除するのとは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込まれた VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF や HTML ファイルの検証は行いません。

## **FAQ**

**セクションまたはその最初のスライドへのリンクはどうすれば作成できますか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスタースライド要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスター スライドやレイアウト要素はハイパーリンクをサポートします。これらの要素に付けたリンクは、対応するマスターまたはレイアウトを使用しているスライドのスライドショー中に利用可能です。

**ハイパーリンクは PDF、HTML、画像、動画にエクスポートするときに保持されますか？**

サポートされている PDF および HTML エクスポートはハイパーリンクを保持する可能性がありますが、ラスタ画像や動画は保持できません。詳細は [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) のエクスポート考慮事項をご参照ください。