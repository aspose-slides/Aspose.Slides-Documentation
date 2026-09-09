---
title: "Python via Java でスライドショーを管理する"
linktitle: "スライドショー"
type: docs
weight: 90
url: /ja/python-java/manage-slide-show/
keywords:
- "ショータイプ"
- "スピーカー表示"
- "個人閲覧"
- "キオスク閲覧"
- "ショーオプション"
- "継続ループ"
- "ナレーションなしショー"
- "アニメーションなしショー"
- "ペンの色"
- "スライドを表示"
- "カスタムショー"
- "スライドを進める"
- "手動で"
- "タイミング使用"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java でスライドショーを管理する方法を学びます。PPT、PPTX、ODP 形式のスライド遷移やタイミングなどを簡単に制御できます。"
---
## **はじめに**

Microsoft PowerPoint の **Set Up Show** オプションを使用すると、ショーの種類を選択したり、ループを有効にしたり、スライドを選択したり、スライドの進行方法を制御したりできます。Aspose.Slides for Python via Java を使用すれば、これらのオプションをプログラムで構成し、プレゼンテーション ファイルに保存できます。

[Presentation.getSlideShowSettings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlideShowSettings) メソッドは、これらのオプションを制御する [SlideShowSettings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/) オブジェクトを返します。以下の例は Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。各例は必要に応じて JVM を起動し、終了時にプレゼンテーションを解放します。

## **ショーの種類を選択**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setSlideShowType) はスライドショーの種類を定義し、次のクラスのいずれかのインスタンスにすることができます: [PresentedBySpeaker](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/ja/python-java/aspose.slides/browsedbyindividual/), または [BrowsedAtKiosk](https://reference.aspose.com/slides/ja/python-java/aspose.slides/browsedatkiosk/)。このメソッドを使用すると、自動キオスクや手動プレゼンテーションなど、さまざまな使用シナリオに合わせてプレゼンテーションを調整できます。

以下のコード例は新しいプレゼンテーションを作成し、スクロールバーを表示せずに「Browsed by an individual」タイプに設定します。

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

## **ショーオプションを有効にする**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setLoop) はスライドショーを手動で停止するまでループさせるかどうかを決定します。これは継続的に実行する必要がある自動プレゼンテーションに便利です。[SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setShowNarration) はスライドショー中に音声ナレーションを再生するかどうかを決定します。音声ガイダンスを含む自動プレゼンテーションに有用です。[SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setShowAnimation) はスライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。プレゼンテーションの視覚効果を完全に提供する際に役立ちます。

以下のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。

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

## **表示するスライドを選択**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setSlides) メソッドを使用すると、プレゼンテーション中に表示するスライドの範囲を選択できます。プレゼンテーション全体ではなく一部のスライドだけを表示したい場合に便利です。以下のコード例は 9 枚のスライドを持つプレゼンテーションを作成し、スライド 2 から 9 を選択します。範囲は 1 ベースのスライド番号を使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpole.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # 選択された範囲が存在するように、9枚のスライドを作成します。
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

## **スライドの進行を制御**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setUseTimings) メソッドは、各スライドの事前設定されたタイミングの使用を有効または無効にします。事前に定義された表示時間で自動的にスライドを切り替える場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。

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

## **メディアコントロールを表示**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) メソッドは、マルチメディア コンテンツ（例: ビデオやオーディオ）が再生される際に、スライドショー中にメディアコントロール（再生、停止、一時停止など）を表示するかどうかを決定します。プレゼンテーション中にメディアの再生を操作したい場合に便利です。

以下のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。

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

## **よくある質問**

**プレゼンテーションを保存すると、スライドショーモードで直接開くことができますか？**

はい。ファイルを PPSX または PPSM として保存すると、PowerPoint で開いたときに直接スライドショーモードで起動します。Aspose.Slides では、対応する保存形式を [during export](/slides/ja/python-java/save-presentation/) で選択してください。

**個々のスライドをファイルから削除せずにショーから除外できますか？**

はい。スライドを [hidden](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#setHidden) としてマークします。非表示スライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides はスライドショーを再生したり、画面上でライブ プレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーション ファイルの編集、解析、変換を行うものであり、実際の再生は PowerPoint などのビューア アプリケーションが担当します。