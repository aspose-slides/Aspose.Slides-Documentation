---
title: Android でプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクを管理する
type: docs
weight: 20
url: /ja/androidjava/manage-hyperlinks/
keywords:
- URL の追加
- ハイパーリンクの追加
- ハイパーリンクの作成
- ハイパーリンクの書式設定
- ハイパーリンクの削除
- ハイパーリンクの更新
- テキスト ハイパーリンク
- スライド ハイパーリンク
- 図形 ハイパーリンク
- 画像 ハイパーリンク
- 動画 ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用し、Java のサンプルで PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを追加、書式設定、更新、削除します。"
---
## **導入**

ハイパーリンクはプレゼンテーションのコンテンツをウェブサイトまたはプレゼンテーション内の場所に接続します。PowerPointでは、ハイパーリンクは主に次の2つの目的で使用されます:

* テキスト、図形、またはメディアフレームからウェブサイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for Android via Java を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除することができます。以下の例では、個々の要素のハイパーリンクの操作方法と、プレゼンテーション、スライド、テキストフレームレベルでハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}
プレゼンテーションは[無料のオンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/editor)でも編集できます。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディアフレームにウェブサイトの URL を割り当てることができます。ハイパーリンクを割り当てた要素がクリック領域を決定します。テキストの部分は選択したテキストに、図形やフレームはスライドオブジェクトにリンクします。

相対ハイパーリンクを含むプレゼンテーションについては、[ハイパーリンクベースの管理](/slides/ja/androidjava/presentation-properties/#manage-the-hyperlink-base)をご覧ください。

### **テキストへの URL ハイパーリンクの追加**

テキストをウェブサイトにリンクするには、以下に示すように、テキスト部分の[setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-)メソッドに[Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) を渡します。テキストのその部分だけがクリック可能になります。

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

### **図形およびメディアフレームへの URL ハイパーリンクの追加**

図形やフレームをクリック可能にするには、その[setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-)メソッドを呼び出します。ハイパーリンクはテキスト部分ではなく、オブジェクト自体に属します。

画像、音声、動画フレームにも同様のアプローチが適用されます。フレームにハイパーリンクを割り当て、必要に応じて[setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-)を呼び出します。

次の例は四角形をクリック可能にします:

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

内部ハイパーリンクを使用すると、読者は目次から特定のスライドへジャンプできます。次の例では、[setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) を使用して、1枚目スライドの「Page 2」テキストを2枚目スライドにリンクします。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

[IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) の[setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) メソッドは、ハイパーリンクがプレゼンテーション全体のハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタムテキストカラーを適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、古いバージョンではこの設定は適用されません。

次の例は同じスライドに2つのテキストハイパーリンクを追加します。1つ目は赤いテキスト塗りつぶしを使用し、2つ目はデフォルトのハイパーリンク色のままです。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

ハイパーリンクは、アクティブ化されたときにサウンドを再生したり、再生中のサウンドを停止したりできます。これらの動作を構成するには、以下のメソッドを使用します:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) はハイパーリンクに関連付けられたオーディオを指定します。
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) はハイパーリンクを有効化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンクサウンドの追加**

次の例では `sampleaudio.wav` をロードし、1枚目スライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライドの2つ目の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

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

#### **ハイパーリンクサウンドの抽出**

次の例では、上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンクオーディオを [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) と [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) を使用してメモリに読み込みます。

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

テキストまたは図形にハイパーリンクを割り当てた後、以下の [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) メソッドを呼び出すことができます:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) は、リンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) は、該当する場合に親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) は、リンクを有効化した際にその宛先を閲覧済みハイパーリンクのリストに追加するかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) は、クリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

[getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) を使用して、テキスト部分のリンクを含むハイパーリンクコンテナを変更前に収集します。次の例は最初のスライドから両方のアクティベーションタイプを削除します。1つだけ削除したい場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) または [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) のいずれかだけを呼び出します。クリックアクションを削除してもマウスオーバーの対応は削除されません。

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

無条件に削除するには、[removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) を使用すると、選択したスコープ内の両方のアクティベーションタイプが一度の呼び出しで削除されます。マスター、レイアウト、ノートの選択的クリーンアップと対象範囲については、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)をご参照ください。

## **完全なハイパーリンクインベントリの作成**

プレゼンテーションを配布する前に、インタラクティブなアクションとウェブリンクのインベントリを作成します。[getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) は URL 文字列の平坦なリストではなく、[IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) オブジェクトを返します。各コンテナで [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) と [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) の両方を確認してください。これらは独立しており、同一コンテナが両方のアクションを持つことがあるため、完全なレポートではコンテナごとに最大2行が必要です。

図形レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随したリンクを見逃す可能性があります。代わりに適切なスコープをクエリし、返されたコンテナを保持して、後でそのアクションを更新または削除できるようにします。

### **プレゼンテーション、スライド、テキストフレームスコープのクエリ**

[IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) インターフェイスは、[IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--)、[IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)、[ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) を通じて利用できます。各スコープは同じクエリをサポートします:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) はクリックアクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) はマウスオーバーアクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) はいずれか、または両方のアクションを持つコンテナを返します。

次の例は、外部クリックリンク、ファイルマウスオーバーリンク、内部スライドナビゲーション、テキストマウスオーバーリンク、マクロアクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。同じ3つのクエリはすべてのスコープで機能し、カウントはコンテナ数を示し、アクションの総数ではありません。テキストフレームスコープは、包含する図形自身のリンクを除外します。

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

この例では、プレゼンテーションおよびスライドクエリはそれぞれ、クリックコンテナが3つ、マウスオーバーコンテナが2つ、いずれかのアクションを持つコンテナが3つと報告します。テキストフレームクエリは各カテゴリで1つのコンテナを報告します。

### **アクションと宛先の分類**

[IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) を使用して、宛先を解釈する前にアクションを判別します。[HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) の値はウェブナビゲーション以上のものをカバーします:

| Values | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク; URL とそのスキームを確認してください。 |
| `JumpSpecificSlide` | 特定のスライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ビルトインのスライドショー ナビゲーション、スライドショー コンテキストで解決されます。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了するか、カスタムショーを開始します。 |
| `StartMacro` | マクロを実行します。 |
| `StartProgram` | プログラムを起動します。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開きます; ウェブ URL とは別に確認してください。 |
| `StartStopMedia` | メディアの再生開始または停止。 |
| `NoAction`, `Unknown` | ナビゲーションアクションなし、または認識できないアクションで、レビューが必要です。 |

[getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) で外部宛先を取得し、[getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) で特定の内部宛先を取得します。内部アクションやビルトインコマンドには外部 URL が存在しないことがあります。空の URL はコンテナにアクションがないことを意味しません。[getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) が正規化された URL と異なる場合はその値を保持し、利用可能な場合は [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) が返すツールチップも含めてください。

### **ハイパーリンクのレポート、サニタイズ、検証**

次の Java の例は、既存のプレゼンテーションを読み込み（上記で作成したファイルを使用）、`hyperlink-audit.json` を書き出し、ポリシーを適用し、`hyperlink-sanitized.pptx` として保存し、再度開いて両方のアクティベーションタイプを確認します。変更前にコンテナを収集し、参照等価性を使用して同一コンテナの二重処理を防ぎます。プレゼンテーションクエリは通常のスライドを対象とし、パッケージ全体のインベントリの場合は、マスター、レイアウト、ノート、ノートとハンドアウトマスターも明示的にクエリします。

レポートは、利用可能な場合に 1 ベースのスライドインデックスと [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) を記録します。[ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) はサポート対象コンテナの所有スライドを提供します。マスター、レイアウト、ノートは通常のスライドインデックスを持たず、スコープで識別されます。図形コンテナとテキスト部分書式コンテナは別々にラベル付けされ、他のコンテナタイプはランタイム型名を保持します。各コンテナにはレポート内でローカル ID が付与され、2 つのアクションを関連付けられます。レポートはアクションタイプを Java 列挙型で定義された整数定数として保存します。

この意図的に制限的なアプリケーションポリシーは、絶対的な HTTPS URL と有効な内部スライドターゲットのみを許可します。マクロ、プログラム、ファイルアクション、その他のスライドショーアクション、未知のアクション、その他の URL スキームは拒否されます。これらの拒否はポリシー上の決定であり、Aspose.Slides の安全性評価ではありません。HTTPS だけでは信頼性は確立できません。ホスト許可リストやその他のチェックをアプリケーションに追加してください。元の URL と正規化された外部 URL の両方がチェックされます。この例はリンクをたどったりアクションを実行したりせずにメタデータを監査します。

修正のために、コンテナの [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) は [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)、[removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) をサポートしています。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディングページに置き換え、他の禁止クリックや禁止マウスオーバーアクションは個別に削除します。`replaceExternalClicks` を `false` に設定すると、すべてのポリシー違反を削除します。デプロイ前にアプリケーション所有の置換ページを選択してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用します: マウスオーバーアクションや外部リンク・特定スライドジャンプ以外のものは、サポートされていない可能性があるとフラグ付けします。これはレビューのヒントであり、機能テストやフラグが付いていないリンクがエクスポートで残る保証ではありません。サポートされている [PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) および [HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) のエクスポートは、アクション、エクスポートオプション、ビューアに応じてハイパーリンクを保持できる場合があります。ラスタ画像 [images](/slides/ja/androidjava/convert-powerpoint-to-png/) と [video](/slides/ja/androidjava/convert-powerpoint-to-video/) はインタラクティブハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
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

    // 追加のJSON依存なしでこのレポートのフラット行をシリアライズします。
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
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
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
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

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

上記で作成した入力に対し、レポートには 5 行のアクションが含まれます。ファイルのマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライドナビゲーションは残ります。検証では禁止アクションはゼロと出力されます。禁止された外部クリック URL を含む入力は置換ブランチも実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナは、クリックアクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく選択されたスコープ全体の両方のアクティベーションタイプを削除する [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) とは異なります。ここでの検証はハイパーリンクのアクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツは削除せず、エクスポートされた PDF や HTML ファイルの検証も行いません。

## **FAQ**

**セクションまたはその最初のスライドにリンクするには？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象とします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスタースライドの要素にハイパーリンクを付けてすべてのスライドで機能させることはできますか？**

はい。マスタースライドやレイアウトの要素はハイパーリンクをサポートしています。これらの要素上のリンクは、対応するマスターまたはレイアウトを使用しているスライドのスライドショー中に利用可能です。

**PDF、HTML、画像、動画へのエクスポート時にハイパーリンクは保持されますか？**

サポートされている PDF および HTML エクスポートではハイパーリンクが保持される可能性がありますが、ラスタ画像や動画では保持できません。エクスポートに関する考慮事項は [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。