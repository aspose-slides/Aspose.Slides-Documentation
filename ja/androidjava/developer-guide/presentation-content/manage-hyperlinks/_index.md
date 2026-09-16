---
title: Android でプレゼンテーション ハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/androidjava/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキスト ハイパーリンク
- スライド ハイパーリンク
- シェイプ ハイパーリンク
- 画像 ハイパーリンク
- 動画 ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java の例を使用して、Android 用 Aspose.Slides for Java で PowerPoint および OpenDocument のプレゼンテーション内のハイパーリンクを追加、書式設定、更新、削除します。"
---
## **はじめに**

ハイパーリンクは、プレゼンテーションのコンテンツとウェブサイトまたはプレゼンテーション内の位置を結び付けます。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、シェイプ、メディア フレームからウェブサイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for Android via Java を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除できます。以下の例では、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレーム単位でハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}
無料のオンライン Aspose PowerPoint エディタは[free online Aspose PowerPoint editor](https://products.aspose.app/slides/ja/editor)で利用できます。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

テキスト、シェイプ、メディア フレームにウェブサイトの URL を割り当てることができます。ハイパーリンクを割り当てる要素に応じてクリック領域が決まります。テキスト部分に割り当てると選択したテキストがリンクになり、シェイプやフレームに割り当てるとスライドオブジェクト全体がリンクになります。

### **テキストへの URL ハイパーリンクの追加**

テキストをウェブサイトにリンクするには、[Hyperlink](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/hyperlink/) をテキスト部分の[setHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) メソッドに渡します。以下の例のように、リンク対象となるのはそのテキスト部分だけです。

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

### **シェイプとメディア フレームへの URL ハイパーリンクの追加**

シェイプやフレームをクリック可能にするには、[setHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) メソッドを呼び出します。ハイパーリンクはテキスト部分ではなくオブジェクト自体に属します。

画像、音声、動画フレームも同様に、フレームにハイパーリンクを割り当て、必要に応じて[setTooltip](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) を呼び出します。

以下の例は、矩形をクリック可能にするものです。

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

## **目次作成のためのハイパーリンクの使用**

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。以下の例では、1 枚目のスライドの「Page 2」テキストを 2 枚目のスライドにリンクするために[setInternalHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) を使用しています。

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

[IHyperlink](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/) の[setColorSource](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) メソッドは、ハイパーリンクがプレゼンテーション全体のハイパーリンクカラーを使用するか、テキスト部分の書式を使用するかを決定します。カスタムテキストカラーを適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶしカラーを設定します。この機能は PowerPoint 2019 で導入され、旧バージョンでは適用されません。

以下の例は、同一スライドに 2 つのテキストハイパーリンクを追加します。1 つ目は赤いテキスト塗りつぶし、2 つ目はデフォルトのハイパーリンクカラーを使用します。

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

ハイパーリンクは、アクティブ時にサウンドを再生したり、再生中のサウンドを停止したりできます。以下のメソッドでこれらの動作を設定します。

- [IHyperlink.setSound](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) はハイパーリンクに関連付ける音声を指定します。
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) はハイパーリンクがクリックされたときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドの追加**

以下の例は `sampleaudio.wav` を読み込み、1 枚目のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別のシェイプはクリック時に前のサウンドを停止し、ナビゲーションは行いません。

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

#### **ハイパーリンク サウンドの抽出**

以下の例は、上記で作成したプレゼンテーションを開き、最初のシェイプのハイパーリンク音声を[getSound](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#getSound--) と[getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudio/#getBinaryData--) を使ってメモリに読み込みます。

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

テキストまたはシェイプにハイパーリンクを割り当てた後、以下の[IHyperlink](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/) メソッドを呼び出すことができます。

- [setTooltip](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) は、リンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) は、該当する場合に親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) は、リンクをアクティブにしたときに閲覧履歴に追加するかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) は、クリック時にハイパーリンクを強調表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

ハイパーリンクコンテナ（テキスト部分リンクを含む）を収集するには[getAnyHyperlinks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) を使用します。以下の例は、1 枚目のスライドから両方のアクションタイプを削除します。片方だけを削除したい場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) または[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) のみを呼び出します。クリックアクションを削除してもマウスオーバーは残ります。

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

条件なしで削除する場合、[removeAllHyperlinks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) が選択されたスコープ内の両方のアクティベーションタイプを一括で削除します。マスタ、レイアウト、ノートを含む選択的クリーンアップについては[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **ハイパーリンク在庫の作成**

プレゼンテーション配布前に、インタラクティブなアクションとウェブリンクの在庫を取得します。[getAnyHyperlinks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) は[IVyperlinkContainer](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkcontainer/) オブジェクトを返し、単なる URL 文字列のリストではありません。各コンテナで[getHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) と[getHyperlinkMouseOver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) を確認します。これらは独立しており、同一コンテナが両方のアクションを保持できるため、完全なレポートにはコンテナごとに最大 2 行が必要です。

シェイプレベルだけを走査すると、テキスト部分に付随するリンクが見逃される可能性があります。適切なスコープでクエリを実行し、返されたコンテナを保持して後で更新または削除できるようにしてください。

### **プレゼンテーション、スライド、テキストフレーム スコープのクエリ**

[IHyperlinkQueries](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkqueries/) インターフェイスは[IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--)、[IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)、[ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) から取得できます。各スコープは同じクエリをサポートします。

- [getHyperlinkClicks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) はクリックアクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) はマウスオーバーアクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) はいずれか、または両方のアクションを持つコンテナを返します。

以下の例は、外部クリックリンク、ファイルマウスオーバーリンク、内部スライドナビゲーション、テキストマウスオーバーリンク、マクロアクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。3 つのクエリはすべてのスコープで同じように機能し、カウントはコンテナ数を表します。テキストフレーム スコープは、囲むシェイプ自身のリンクは除外します。

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

この例では、プレゼンテーションおよびスライドクエリはそれぞれクリックコンテナが 3 件、マウスオーバーコンテナが 2 件、いずれかのアクションを持つコンテナが 3 件と報告します。テキストフレームクエリは各カテゴリで 1 件ずつ報告します。

### **アクションと宛先の分類**

[IHyperlink.getActionType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#getActionType--) を使用して、宛先を判断する前にアクションの種類を判別します。[HyperlinkActionType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/hyperlinkactiontype/) の値はウェブナビゲーション以外もカバーします。

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク。URL とスキームを確認します。 |
| `JumpSpecificSlide` | 特定スライドへの内部ナビゲーション。 |
| `JumpFirstSlide`,`JumpPreviousSlide`,`JumpNextSlide`,`JumpLastSlide`,`JumpLastViewedSlide` | スライドショー組み込みナビゲーション。スライドショーコンテキストで解決されます。 |
| `JumpEndShow`,`StartCustomSlideShow` | 現在のショーを終了またはカスタムショーを開始。 |
| `StartMacro` | マクロ実行。 |
| `StartProgram` | プログラム起動。 |
| `OpenFile`,`OpenPresentation` | ファイルまたは別プレゼンテーションを開く。ウェブ URL とは別に確認してください。 |
| `StartStopMedia` | メディア再生の開始または停止。 |
| `NoAction`,`Unknown` | ナビゲーションなし、または未確認のアクションでレビューが必要。 |

外部宛先は[getExternalUrl](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) から取得し、内部の具体的な宛先は[getTargetSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) から取得します。内部アクションや組み込みコマンドは外部 URL を持たないことがあります。空の URL がコンテナにアクションがないことを意味するわけではありません。[getExternalUrlOriginal](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) が正規化 URL と異なる場合はその値を保持し、利用可能な場合は[getTooltip](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) で取得したツールチップも含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の Java 例は、既存のプレゼンテーション（上記で作成したファイル）を読み込み、`hyperlink-audit.json` を書き出し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方のアクティベーションタイプをチェックします。変更前にコンテナを収集し、同一コンテナを二度処理しないように参照等価性を利用します。プレゼンテーションクエリは通常スライドを対象とし、パッケージ全体の在庫を取得するためにマスタ、レイアウト、ノート、ノート/ハンドアウトマスタも明示的にクエリします。

レポートは 1 ベースのスライドインデックスと、利用可能な場合は[getSlideId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) を記録します。[ISlideComponent.getSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecomponent/#getSlide--) は、サポート対象コンテナの所有スライドを提供します。マスタ、レイアウト、ノートは通常スライドインデックスを持たず、スコープで識別されます。シェイプコンテナとテキスト部分フォーマットコンテナは別々にラベル付けされ、他のコンテナタイプは実行時の型名を保持します。各コンテナにはレポート内でローカル ID が付与され、2 つのアクションを相関付けられるようにします。アクションタイプは Java 列挙型の整数定数として保存されます。

この制限的なポリシーは、絶対 HTTPS URL と有効な内部スライドターゲットのみを許可します。マクロ、プログラム、ファイル操作、その他のスライドショーアクション、未知のアクション、その他の URL スキームは拒否されます。これらの拒否はポリシー判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけで信頼が確立するわけではありません。ホスト許可リストや追加チェックを実装してください。オリジナルと正規化された外部 URL の両方をチェックします。例はリンクをたどったりアクションを実行したりせず、メタデータのみを監査します。

修正の際、コンテナの[getHyperlinkManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) を使い、[setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) を呼び出します。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディングページに置き換え、他の禁止クリックと禁止マウスオーバーは個別に削除します。`replaceExternalClicks` を `false` に設定すると、すべてのポリシー違反が削除されます。デプロイ前にアプリケーション所有の置換ページを決定してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用します。マウスオーバーアクションや外部リンク以外や特定スライドジャンプ以外は「潜在的にサポート外」とフラグ付けします。これはレビュー用ヒントであり、機能テストや未フラグのリンクがエクスポートで必ず保持される保証ではありません。サポート対象の[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) と[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) エクスポートはアクションやオプション、ビューアに依存してハイパーリンクを保持できる場合があります。ラスタ画像[images](/slides/ja/androidjava/convert-powerpoint-to-png/) と[video](/slides/ja/androidjava/convert-powerpoint-to-video/) はインタラクティブハイパーリンクを保持できないため、これらの出力向けに監査する際はすべてのアクションにフラグを付けてください。

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

    // 追加の JSON 依存なしでこのレポートのフラットな行をシリアライズします。
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

上記入力で生成されたレポートは 5 行のアクションを含みます。ファイルマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライドナビゲーションは残ります。検証は禁止アクションが 0 件であることを出力します。禁止された外部クリック URL を含む入力は置換ブランチを実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリックアクションを保持します。

この選択的クリーンアップは[removeAllHyperlinks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) とは異なり、ポリシーに関係なく選択スコープ内の両方のアクティベーションタイプを削除します。ここでの検証はハイパーリンクアクションのみを対象とし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF/HTML の検証は行いません。

## **FAQ**

**セクションまたはその最初のスライドへリンクするには？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクします。

**マスタスライドの要素にハイパーリンクを付けてすべてのスライドで機能させることはできますか？**

はい。マスタスライドおよびレイアウト要素はハイパーリンクをサポートします。これらの要素上のリンクは、対応するマスタまたはレイアウトを使用するスライドのショー中に利用可能です。

**ハイパーリンクは PDF、HTML、画像、動画へのエクスポート時に保持されますか？**

サポート対象の PDF と HTML エクスポートはハイパーリンクを保持できる場合がありますが、ラスタ画像および動画は保持できません。詳細は[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) のエクスポート考慮事項をご参照ください。