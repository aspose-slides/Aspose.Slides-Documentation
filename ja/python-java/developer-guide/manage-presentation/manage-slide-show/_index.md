---
title: Python via Java でスライドショーを管理する
linktitle: スライドショー
type: docs
weight: 90
url: /ja/python-java/manage-slide-show/
keywords:
- ショータイプ
- スピーカーによる提示
- 個人閲覧
- キオスク閲覧
- ショーオプション
- 継続的にループ
- ナレーションなしで表示
- アニメーションなしで表示
- ペンの色
- スライドを表示
- カスタムショー
- スライドを進める
- 手動で
- タイミング使用
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でスライドショーを管理する方法を学びます。PPT、PPTX、ODP 形式でスライドの切り替え、タイミングなどを簡単に制御できます。"
---
## **概要**

Microsoft PowerPoint の **Set Up Show** オプションを使用すると、ショータイプの選択、ループの有効化、スライドの選択、スライドの進行方法を制御できます。Aspose.Slides for Python via Java を使えば、これらのオプションをプログラムで設定し、プレゼンテーション ファイルに保存できます。

[Presentation.getSlideShowSettings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlideShowSettings) メソッドは、これらのオプションを制御する [SlideShowSettings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/) オブジェクトを返します。以下の例は Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。各例は必要に応じて JVM を起動し、終了時にプレゼンテーションを解放します。

## **ショータイプの選択**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setSlideShowType) はスライドショーのタイプを定義し、次のクラスのいずれかのインスタンスを指定できます: [PresentedBySpeaker](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/ja/python-java/aspose.slides/browsedbyindividual/)、または [BrowsedAtKiosk](https://reference.aspose.com/slides/ja/python-java/aspose.slides/browsedatkiosk/)。このメソッドを使用すると、キオスク向けの自動実行や手動プレゼンテーションなど、さまざまな利用シーンに合わせてプレゼンテーションを調整できます。

以下のコード例は新しいプレゼンテーションを作成し、スクロールバーを表示せずに「個人が閲覧」タイプのショーを設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ショーオプションの有効化**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setLoop) は、スライドショーを手動で停止するまでループさせるかどうかを決定します。これは継続的に実行する必要がある自動プレゼンテーションに便利です。[SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setShowNarration) は、スライドショー中に音声ナレーションを再生するかどうかを決定します。音声ガイダンスが含まれる自動プレゼンテーションに有用です。[SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setShowAnimation) は、スライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。これにより、プレゼンテーションの視覚効果を完全に表現できます。

次のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **表示スライドの選択**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setSlides) メソッドを使用すると、プレゼンテーション中に表示するスライドの範囲を選択できます。すべてのスライドではなく、一部だけを表示したい場合に便利です。次のコード例は 9 枚のスライドを持つプレゼンテーションを作成し、スライド 2 から 9 を選択します。範囲は 1 から始まるスライド番号で指定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # 選択した範囲が存在するように、9枚のスライドを作成します。
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **スライドの進行制御**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setUseTimings) メソッドは、各スライドの事前設定タイミングの使用を有効または無効にします。事前に定義された表示時間で自動的にスライドを切り替える場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **メディアコントロールの表示**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) メソッドは、マルチメディア コンテンツ（ビデオやオーディオなど）を再生する際に、スライドショー中にメディアコントロール（再生、停止、ポーズなど）を表示するかどうかを決定します。プレゼンテーション中にプレゼンテーターがメディア再生を操作できるようにしたい場合に便利です。

次のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**プレゼンテーションを保存すると、直接スライドショーモードで開くことはできますか？**

はい。ファイルを PPSX または PPSM として保存すると、PowerPoint で開いたときに直接スライドショーが起動します。Aspose.Slides では、エクスポート時に対応する保存形式を選択します [/slides/ja/python-java/save-presentation/](/slides/ja/python-java/save-presentation/)。

**個々のスライドをファイルから削除せずにショーから除外できますか？**

はい。スライドを [hidden](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#setHidden) としてマークします。非表示スライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides はスライドショーを再生したり、画面上でライブ プレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーション ファイルの編集、解析、変換を行うツールであり、実際の再生は PowerPoint などのビューア アプリケーションが担当します。