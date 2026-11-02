---
title: Python via Java でプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/python-java/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクを書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキスト ハイパーリンク
- スライド ハイパーリンク
- シェイプ ハイパーリンク
- 画像 ハイパーリンク
- ビデオ ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides を使用し、Python のサンプルで PowerPoint および OpenDocument のプレゼンテーションにハイパーリンクを追加、書式設定、更新、削除します。"
---
## **概要**

ハイパーリンクは、プレゼンテーションのコンテンツをウェブサイトまたはプレゼンテーション内の場所に接続します。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディア フレームからウェブサイトを開く。
* 別のスライドへ移動する。たとえば、目次から。

Aspose.Slides for Python via Java を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除できます。以下の例では、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレームレベルでハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}
プレゼンテーションは、[無料オンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/editor)でも編集できます。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディア フレームにウェブサイトの URL を割り当てることができます。ハイパーリンクを割り当てる要素によってクリック可能領域が決まります。テキスト部分は選択したテキストにリンクし、図形やフレームはスライド オブジェクト全体にリンクします。

相対ハイパーリンクを含むプレゼンテーションについては、[ハイパーリンクベースの管理](/slides/ja/python-java/presentation-properties/#manage-the-hyperlink-base)を参照して、ドキュメント レベルのベースを読み取り、変更、またはクリアしてください。

### **テキストへの URL ハイパーリンクの追加**

テキストをウェブサイトにリンクするには、以下のようにテキスト部分の [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) メソッドに [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) を渡します。対象のテキスト部分だけがクリック可能になります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **図形およびメディア フレームへの URL ハイパーリンクの追加**

図形またはフレームをクリック可能にするには、その [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) メソッドを呼び出します。ハイパーリンクは、内部のテキスト部分ではなくオブジェクト自体に属します。

同じアプローチは画像、オーディオ、ビデオ フレームにも適用できます。フレームにハイパーリンクを割り当て、必要に応じて [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) を呼び出します。

以下の例は矩形をクリック可能にします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ハイパーリンクを使用した目次の作成**

内部ハイパーリンクにより、目次から特定のスライドへジャンプできます。以下の例は、最初のスライドの「Page 2」テキストを 2 番目のスライドにリンクするために [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) を使用しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ハイパーリンクの書式設定**

### **色**

[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) の [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) メソッドは、ハイパーリンクがプレゼンテーションのハイパーリンク色を使用するかテキスト部分の書式設定を使用するかを決定します。カスタム テキスト色を適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、古いバージョンでは適用されません。

以下の例は同じスライドに 2 つのテキストハイパーリンクを追加します。最初は赤いテキスト塗りつぶしを使用し、2 番目はデフォルトのハイパーリンク色を保持します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **サウンド**

ハイパーリンクは、アクティブ化時にサウンドを再生したり、既に再生中のサウンドを停止したりできます。これらの動作を構成するには、以下のメソッドを使用します。

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) はハイパーリンクに関連付けるオーディオを指定します。
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) はハイパーリンクをアクティブ化した際に前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドの追加**

以下の例は `sampleaudio.wav` を読み込み、最初のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライドの 2 番目の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **ハイパーリンク サウンドの抽出**

以下の例は上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンクオーディオを [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) と [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) を介してメモリに読み込みます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **ツールチップとインタラクション設定**

テキストまたは図形にハイパーリンクを割り当てた後、以下の [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) メソッドを呼び出すことができます。

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) はビューアがリンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) は適用可能な場合、親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) はリンクをアクティブ化した際にその宛先を閲覧したハイパーリンクの一覧に追加するかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) はクリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除**

変更前にテキスト部分のリンクを含むハイパーリンク コンテナを収集するには、[getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) を使用します。以下の例は最初のスライドから両方のアクティベーション タイプを削除します。1 つだけ削除したい場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) または [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) のみを呼び出してください。クリック アクションを削除してもマウスオーバー対応は残ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

無条件に削除する場合は、[removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) が選択したスコープ内の両方のアクティベーション タイプを一度に削除します。マスター、レイアウト、ノートの選択的クリーンアップとカバレッジについては、[ハイパーリンクのレポート、サニタイズ、検証](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **完全なハイパーリンクインベントリの作成**

プレゼンテーションを配布する前に、インタラクティブなアクションとウェブ リンクのインベントリを作成します。[getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) は URL 文字列のフラットリストではなく、[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) や [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) などのハイパーリンク コンテナを返します。各コンテナで [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) と [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) の両方を確認してください。これらは独立しており、同じコンテナが両方のアクションを持つことがあるため、完全なレポートではコンテナごとに最大 2 行が必要です。

シェイプレベルのハイパーリンクだけをスキャンすると、テキスト部分に付随するリンクを見落とすことがあります。適切なスコープでクエリを実行し、返されたコンテナを保持して後でアクションの更新や削除に利用してください。

### **プレゼンテーション、スライド、およびテキスト フレーム スコープのクエリ**

[HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) クラスは、[Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries)、[BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries)、[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) から利用できます。各スコープは同じクエリをサポートします。

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) はクリック アクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) はマウスオーバー アクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) はいずれか、または両方のアクションを持つコンテナを返します。

以下の例は、外部クリックリンク、ファイルマウスオーバーリンク、内部スライド ナビゲーション、テキストマウスオーバーリンク、マクロ アクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。3 つのクエリはすべてのスコープで同様に機能し、カウントはコンテナ数を表し、アクション総数ではありません。テキスト フレーム スコープは囲んでいるシェイプのリンクを除外します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この例では、プレゼンテーションとスライドのクエリはそれぞれクリック コンテナが 3、マウスオーバー コンテナが 2、いずれかのアクションを持つコンテナが 3 であることを報告します。テキスト フレームのクエリは各カテゴリで 1 つのコンテナを報告します。

### **アクションと宛先の分類**

[Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) を使用して、宛先を解釈する前にアクションを判別します。[HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) の値はウェブ ナビゲーション以上のものをカバーしています。

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク; URL とそのスキームを確認します。 |
| `JumpSpecificSlide` | 特定のスライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 組み込みのスライドショー ナビゲーション、スライドショー コンテキストで解決されます。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了するか、カスタムショーを開始します。 |
| `StartMacro` | マクロを実行します。 |
| `StartProgram` | プログラムを起動します。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開きます。ウェブ URL とは別に確認してください。 |
| `StartStopMedia` | メディアの再生を開始または停止します。 |
| `NoAction`, `Unknown` | ナビゲーション アクションがない、または認識できないアクションで、確認が必要です。 |

外部宛先は [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) で取得し、内部宛先は [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide) で取得します。内部アクションや組み込みコマンドには外部 URL がないことがあります。空の URL がコンテナにアクションがないことを意味するわけではありません。[getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) が正規化された URL と異なる場合はその値を保持し、利用可能な場合は [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) が返すツールチップも含めてください。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の Python 例は既存のプレゼンテーションを読み取り（上記で作成したファイルを使用）、`hyperlink-audit.json` を書き出し、ポリシーを適用し、`hyperlink-sanitized.pptx` を保存して再度開き、両方のアクティベーション タイプを再チェックします。変更前にコンテナを収集し、参照等価性を使用して同じコンテナの二重処理を防止します。プレゼンテーション クエリは通常のスライドを対象とし、パッケージ全体のインベントリについてはマスター、レイアウト、ノート、および存在する場合はノートとハンドアウト マスターも明示的にクエリします。

レポートは利用可能な場合、1 ベースのスライドインデックスと [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) を記録します。[getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) はサポート対象コンテナの所有スライドを提供します。マスター、レイアウト、ノートは通常のスライドインデックスを持たず、スコープで識別されます。シェイプ コンテナとテキスト部分の書式コンテナは別々にラベル付けされ、他のコンテナ種別はランタイム型名を保持します。各コンテナはレポート内でローカル ID を取得し、2 つのアクションを相関付けられるようにします。レポートはアクション種別を Java 列挙体で定義された整数定数として保存します。

この意図的に制限的なアプリケーション ポリシーは、絶対 HTTPS URL と有効な内部スライド ターゲットのみを許可します。マクロ、プログラム、ファイル アクション、その他のスライドショー アクション、未知のアクション、その他の URL スキームは拒否されます。これらの拒否はポリシー上の判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼を確立できないため、ホスト許可リストやその他のチェックをアプリケーションに追加してください。元の URL と正規化された外部 URL の両方がチェック対象です。例はリンクをたどったりアクションを実行したりせずにメタデータを監査します。

修正のために、コンテナの [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) は [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)、[removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) をサポートします。ここでは、禁止された外部クリックリンクは固定の HTTPS ランディング ページに置き換え、他の禁止クリックと禁止マウスオーバー アクションは個別に削除します。`replace_external_clicks` を `False` に設定すると、すべてのポリシー違反が削除されます。デプロイ前にアプリケーション所有の置換ページを選択してください。

レポートのエクスポート フラグは保守的な PDF レビュー ポリシーを使用します：マウスオーバー アクションおよび外部リンクや特定スライドジャンプ以外のすべてを潜在的に未サポートとしてフラグ付けします。これは機能テストやフラグ付けされていないリンクがエクスポートで保持される保証ではなく、レビューのヒントです。サポートされる [PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/python-java/convert-powerpoint-to-html/) エクスポートはアクションやエクスポートオプション、ビューアに応じてハイパーリンクを保持する場合があります。ラスター [images](/slides/ja/python-java/convert-powerpoint-to-png/) および [video](/slides/ja/python-java/convert-powerpoint-to-video/) はインタラクティブ ハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

上記で作成した入力を使用すると、レポートには 5 行のアクションが含まれます。ファイルマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライド ナビゲーションは残ります。検証は禁止アクションをゼロと表示します。禁止された外部クリック URL を含む入力は置換ブランチも実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリック アクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく選択スコープ全体の両方のアクティベーション タイプを削除する [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) とは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF または HTML ファイルの検証は行いません。

## **FAQ**

**セクションやその最初のスライドにリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象とします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスタースライドの要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスタースライドおよびレイアウト要素はハイパーリンクをサポートします。これらの要素上のリンクは、対応するマスターまたはレイアウトを使用するスライドのスライドショー中に利用できます。

**PDF、HTML、画像、またはビデオにエクスポートする際、ハイパーリンクは保持されますか？**

サポートされる PDF および HTML エクスポートはハイパーリンクを保持する場合がありますが、ラスター画像やビデオは保持できません。エクスポートに関する考慮事項は、[ハイパーリンクのレポート、サニタイズ、検証](#report-sanitize-and-verify-hyperlinks) を参照してください。