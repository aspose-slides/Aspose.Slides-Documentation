---
title: Python via Javaでプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/python-java/manage-hyperlinks/
keywords:
- URLを追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクの削除
- ハイパーリンクの更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用し、Python のサンプルで PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを追加、書式設定、更新、削除します。"
---
## **概要**

ハイパーリンクはプレゼンテーションのコンテンツを Web サイトやプレゼンテーション内の場所に接続します。PowerPoint のハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディアフレームから Web サイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for Python via Java を使用すると、これらのリンクを追加、外観やサウンドの制御、プロパティの更新、削除ができます。以下の例は個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキストフレームレベルでハイパーリンクにアクセスする方法を示しています。

{{% alert color="info" title="注" %}}
無料のオンライン Aspose PowerPoint エディター[でプレゼンテーションを編集]することもできます(https://products.aspose.app/slides/ja/editor)。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディアフレームに Web サイトの URL を割り当てることができます。ハイパーリンクを割り当てる要素がクリック可能領域を決定します。テキストの一部に割り当てた場合は選択したテキストがリンクになり、図形やフレームに割り当てた場合はスライドオブジェクト全体がリンクになります。

### **テキストへの URL ハイパーリンクの追加**

テキストを Web サイトにリンクするには、[Hyperlink](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/) をテキスト部分の[setHyperlinkClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#setHyperlinkClick) メソッドに渡します。下記の例のように、対象のテキスト部分だけがクリック可能になります。

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

### **図形およびメディアフレームへの URL ハイパーリンクの追加**

図形やフレームをクリック可能にするには、その[setHyperlinkClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#setHyperlinkClick) メソッドを呼び出します。ハイパーリンクはテキスト部分ではなくオブジェクト自体に属します。

画像、音声、ビデオフレームにも同様に適用できます。フレームにハイパーリンクを割り当て、必要に応じて[setTooltip](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setTooltip) を呼び出します。

次の例は矩形をクリック可能にします。

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

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。以下の例は、最初のスライドの「Page 2」テキストを 2 番目のスライドにリンクするために[setInternalHyperlinkClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) を使用しています。

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

[Hyperlink](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/) の[setColorSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setColorSource) メソッドは、ハイパーリンクがプレゼンテーションのハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタムテキスト色を適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、以前のバージョンでは設定が適用されません。

次の例は同じスライドに 2 つのテキストハイパーリンクを追加します。1 つ目は赤いテキスト塗りつぶし、2 つ目はデフォルトのハイパーリンク色を使用します。

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

ハイパーリンクは、アクティブ化されたときにサウンドを再生したり、既に再生中のサウンドを停止したりできます。以下のメソッドで動作を設定します。

- [Hyperlink.setSound](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setSound) はハイパーリンクに関連付ける音声を指定します。
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) はハイパーリンクをアクティブ化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンクサウンドの追加**

次の例は `sampleaudio.wav` を読み込み、最初のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別の図形をクリックすると、サウンドが停止し、ナビゲーションは行われません。

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

#### **ハイパーリンクサウンドの抽出**

以下の例は上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンク音声を [getSound](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#getSound) と [getBinaryData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audio/#getBinaryData) を使用してメモリに読み込みます。

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

テキストまたは図形にハイパーリンクを割り当てた後、以下の [Hyperlink](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/) メソッドを呼び出すことができます。

- [setTooltip](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setTooltip) はリンクのヒントとして表示できるテキストを設定します。
- [setTargetFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setTargetFrame) は該当する場合に、親 HTML フレームセット内のターゲットフレームを指定します。
- [setHistory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setHistory) はリンクをアクティブ化したときに閲覧履歴に追加するかどうかを制御します。
- [setHighlightClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setHighlightClick) はクリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

変更前にテキスト部分リンクを含むハイパーリンクコンテナを収集するには、[getAnyHyperlinks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) を使用します。次の例は最初のスライドから両方のアクティベーションタイプを削除します。片方だけを削除したい場合は、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) または [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) のみを呼び出します。クリックアクションを削除してもマウスオーバーは残ります。

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

条件なしで削除する場合、[removeAllHyperlinks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) を使用すると、選択したスコープ内の両方のアクティベーションタイプが一度の呼び出しで削除されます。マスター、レイアウト、ノートを含む選択的クリーンアップについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **完全なハイパーリンクインベントリの作成**

プレゼンテーションを配布する前に、インタラクティブなアクションと Web リンクをインベントリ化します。[getAnyHyperlinks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) は、[Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) や [PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) オブジェクトなどのハイパーリンクコンテナを返し、単なる URL 文字列の一覧は返しません。各コンテナで [getHyperlinkClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getHyperlinkClick) と [getHyperlinkMouseOver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getHyperlinkMouseOver) の両方を確認します。これらは独立しており、同じコンテナが両方のアクションを持つことがあります。そのため、完全なレポートにはコンテナごとに最大 2 行が必要です。

形状レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随するリンクを見逃す可能性があります。適切なスコープでクエリを実行し、返されたコンテナを保持して後で更新または削除できるようにしてください。

### **プレゼンテーション、スライド、テキストフレームスコープのクエリ**

[HyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/) クラスは、[Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getHyperlinkQueries)、[BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getHyperlinkQueries)、[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#getHyperlinkQueries) から利用できます。各スコープは同じクエリをサポートします。

- [getHyperlinkClicks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) はクリックアクションを持つコンテナを返します。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) はマウスオーバーアクションを持つコンテナを返します。
- [getAnyHyperlinks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) はいずれか、または両方のアクションを持つコンテナを返します。

次の例は外部クリックリンク、ファイルマウスオーバーリンク、内部スライドナビゲーション、テキストマウスオーバーリンク、マクロアクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。同じ 3 つのクエリはすべてのスコープで機能し、カウントはアクション総数ではなくコンテナ数を示します。テキストフレームスコープは、囲む形状のリンクは除外します。

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

この例では、プレゼンテーションとスライドのクエリはそれぞれクリックコンテナが 3 件、マウスオーバーコンテナが 2 件、いずれかのアクションを持つコンテナが 3 件を報告します。テキストフレームクエリは各カテゴリで 1 件を報告します。

### **アクションと宛先の分類**

[Hyperlink.getActionType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#getActionType) を使用して、宛先を評価する前にアクションの種類を判断します。[HyperlinkActionType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkactiontype/) の値は Web ナビゲーション以上の機能をカバーします。

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク; URL とスキームを確認 |
| `JumpSpecificSlide` | 特定スライドへの内部ナビゲーション |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | スライドショー内部の組み込みナビゲーション |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーの終了またはカスタムショーの開始 |
| `StartMacro` | マクロの実行 |
| `StartProgram` | プログラムの起動 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションのオープン; Web URL とは別に確認 |
| `StartStopMedia` | メディア再生の開始または停止 |
| `NoAction`, `Unknown` | ナビゲーションなし、または未確認のアクション; 要レビュー |

外部宛先は [getExternalUrl](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#getExternalUrl) で取得し、内部の特定スライドは [getTargetSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#getTargetSlide) で取得します。内部アクションや組み込みコマンドは外部 URL を持たないことがあります。空の URL がコンテナにアクションがないことを意味するわけではありません。[getExternalUrlOriginal](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) が正規化された URL と異なる場合はその値を保持し、利用可能な場合は [getTooltip](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#getTooltip) で取得したツールチップも含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の Python 例は既存のプレゼンテーション（上記で作成したファイル）を読み込み、`hyperlink-audit.json` を書き出し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方のアクティベーションタイプを確認します。変更前にコンテナを収集し、参照等価性で同一コンテナの二重処理を防ぎます。プレゼンテーションクエリは通常スライドを対象とし、パッケージ全体のインベントリが必要な場合はマスター、レイアウト、ノート、ノートおよびハンドアウトマスターも明示的にクエリします。

レポートは 1 ベースのスライドインデックスと利用可能な場合は [getSlideId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getSlideId) を記録します。サポート対象コンテナには所有スライドを取得するために [getSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getSlide) を使用します。マスター、レイアウト、ノートは通常スライドインデックスを持たず、スコープで識別されます。形状コンテナとテキスト部分書式コンテナは別々にラベル付けされ、その他のコンテナは実行時の型名を保持します。各コンテナにはレポート用ローカル ID が付与され、2 つのアクションを関連付けられます。アクションタイプは Java 列挙型で定義された整数定数として保存されます。

この厳格な適用ポリシーは絶対 HTTPS URL と有効な内部スライドターゲットのみを許可します。マクロ、プログラム、ファイルアクション、その他のスライドショーアクション、未知のアクション、その他の URL スキームは拒否されます。これらの拒否はポリシー判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼が確立しないため、ホスト許可リストやその他のチェックをアプリケーション側で追加してください。元の URL と正規化された外部 URL の両方がチェック対象です。例はリンクをたどったりアクションを実行したりせずにメタデータを監査します。

修正のために、コンテナの [getHyperlinkManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getHyperlinkManager) は [setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)、[removeHyperlinkClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick)、[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) をサポートします。この例では、禁止された外部クリックリンクは固定の HTTPS ランディングページに置き換えられ、その他の禁止クリックと禁止マウスオーバーは個別に削除されます。`replace_external_clicks` を `False` に設定すると、すべてのポリシー違反が削除されます。展開前にアプリケーション所有の置換ページを選択してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用します: マウスオーバーアクションと外部リンク以外のスライドジャンプは「サポートされない可能性あり」としてフラグ付けします。これはレビューのヒントであり、機能テストやフラグが付いていないリンクがエクスポートで保持される保証ではありません。サポートされている [PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/python-java/convert-powerpoint-to-html/) エクスポートはアクション、エクスポートオプション、ビューアに応じてハイパーリンクを保持できる場合があります。ラスタ画像 [images](/slides/ja/python-java/convert-powerpoint-to-png/) と [video](/slides/ja/python-java/convert-powerpoint-to-video/) はインタラクティブハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

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

上記で作成した入力を使用すると、レポートには 5 行のアクションが含まれます。ファイルマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライドナビゲーションは残ります。検証では違反アクションが 0 件であることが出力されます。禁止された外部クリック URL を含む入力は置換ブランチもテストします。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリックアクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく選択したスコープ内の両方のアクティベーションタイプを削除する [removeAllHyperlinks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) とは異なります。ここでの検証はハイパーリンクアクションのみをチェックし、埋め込まれた VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF や HTML の検証は行いません。

## **FAQ**

**セクションやその最初のスライドへリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへ移動するナビゲーションを作成するには、そのセクションの最初のスライドへリンクしてください。

**マスタースライドの要素にハイパーリンクを付けてすべてのスライドで機能させることはできますか？**

できます。マスタースライドやレイアウトの要素はハイパーリンクをサポートします。これらの要素に付けたリンクは、該当するマスターまたはレイアウトを使用するスライドのスライドショー中に利用可能です。

**ハイパーリンクは PDF、HTML、画像、ビデオへのエクスポート時に保持されますか？**

サポートされている PDF と HTML のエクスポートはハイパーリンクを保持できる場合がありますが、ラスタ画像やビデオは保持できません。[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) のエクスポートに関する考慮事項をご参照ください。