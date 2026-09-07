---
title: PythonでPowerPointプレゼンテーションをビデオに変換
linktitle: PowerPoint をビデオに変換
type: docs
weight: 130
url: /ja/python-java/convert-powerpoint-to-video/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint からビデオへ
- プレゼンテーションからビデオへ
- PPT からビデオへ
- PPTX からビデオへ
- PowerPoint から MP4 へ
- プレゼンテーションから MP4 へ
- PPT から MP4 へ
- PPTX から MP4 へ
- PPT を MP4 として保存
- PPTX を MP4 として保存
- PPT を MP4 にエクスポート
- PPTX を MP4 にエクスポート
- ビデオ変換
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Java 経由で Python を使用して PowerPoint プレゼンテーションを MP4 ビデオに変換します。Aspose.Slides でフレームを生成し、FFmpeg でアニメーションやトランジションを含むビデオにエンコードします。"
---
## **概要**

PowerPointまたはOpenDocumentのプレゼンテーションをビデオに変換すると、プレゼンテーションアプリケーションを開かずにビデオプレーヤーで内容を視聴できます。Aspose.Slides for Python via Java は、プレゼンテーションのアニメーションとトランジションを画像フレームにレンダリングします。FFmpeg のような別のエンコーダーが、これらのフレームをビデオファイルに結合します。

{{% alert color="info" title="注" %}}
オンラインの[PowerPoint to Video converter](https://products.aspose.app/slides/ja/video)を試して、プレゼンテーションからビデオへの変換を実際に確認してください。
{{% /alert %}}

## **PowerPointをビデオに変換**

変換は 2 つの段階で行われます。選択したフレームレートで PNG フレームを生成し、次に画像シーケンスを MP4 にエンコードします。アニメーションのタイミングを保持するため、両方の段階で同じフレームレートを使用してください。

サンプルを実行する前に:

1. [Aspose.Slides for Python via Java](/slides/ja/python-java/installation/) をセットアップします。
2. [FFmpeg](https://ffmpeg.org/download.html) をダウンロードし、実行可能ファイルを `PATH` に配置します。サンプルでは `libx264` エンコーダーを含むビルドを使用しています。
3. 書き込み可能なディレクトリで以下の Python コードを実行します。

このサンプルは、入口と退出のアニメーションを持つ笑顔のシェイプを作成し、30 FPS でフレームをレンダリングし、FFmpeg を呼び出して `output.mp4` を作成します。新しいフレームディレクトリを使用することで、以前の実行で生成されたフレームがビデオに含まれることを防ぎます。

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

既存のファイルを変換するには、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) をファイルパスで初期化し、シェイプ作成とアニメーション作成のステートメントを省略します。

FFmpeg コマンドは番号付きの[image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2) を読み取り、奇数の寸法を偶数にパッドし、`yuv420p` ピクセルフォーマットで H.264 ビデオを書き出します。`-n` オプションは既存の出力ファイルの上書きを防止します。生成された PNG ファイルはフレームディレクトリに残りますので、不要になったら削除してください。

{{% alert color="info" title="注" %}}
このサンプルは画像フレームのみをエンコードします。動画にナレーションやプレゼンテーションに埋め込まれた音声は追加されません。
{{% /alert %}}

## **動画エフェクト**

アニメーションはスライドオブジェクトの表示、移動、または消失を制御します。トランジションはスライド間の切り替えを制御します。これらのエフェクトは動画フレームを生成する前に追加してください。

以下をご覧ください: [PowerPoint Animation](/slides/ja/python-java/powerpoint-animation/), [Shape Animation](/slides/ja/python-java/shape-animation/), [Shape Effects](/slides/ja/python-java/shape-effect/), および [Slide Transitions](/slides/ja/python-java/slide-transition/)。

### **スライド トランジションを追加**

以下の自己完結型サンプルは、2 枚のスライドからなるプレゼンテーションを作成します。2 枚目のスライドはマゼンタ背景でプッシュトランジションが設定されています。プレゼンテーションを保存し、上記のフレーム生成サンプルの入力として使用してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **段落にアニメーションを付ける**

テキストは段落ごとに表示できます。このサンプルは、3 つの段落を作成し、順次フェードインの入口エフェクトを適用し、各エフェクトは前のエフェクトから 1 秒遅れます。保存した `paragraphs.pptx` ファイルを動画変換サンプルの入力として使用してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **動画変換クラス**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationanimationsgenerator/) はスライドのアニメーションイベントを生成します。プレゼンテーションから構築すると、プレゼンテーションのスライドサイズがフレームに使用されます。[setDefaultDelay](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) を使用してデフォルトの遅延をミリ秒で設定します。

[PresentationPlayer](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationplayer/) はコンストラクタで指定されたフレームレートで生成されたアニメーションをサンプリングします。JPype を介して [setFrameTick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationplayer/#setFrameTick) で Python コールバックを登録し、[run](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationanimationsgenerator/#run) を呼び出してフレームを生成します。最初のサンプルは独自のゼロベースカウンタを使用し、ファイル名が FFmpeg の入力シーケンスと一致するようにしています。

個々のアニメーション状態については、[setNewAnimation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation) でコールバックを登録します。コールバックは、任意の時間に位置付け可能なアニメーションプレイヤーを受け取ります。以下のサンプルは、生成された各アニメーションの最初と最後のフレームをユニークなファイル名で保存します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **サポートされているアニメーションとエフェクト**

以下の表は、Java 変換記事で説明されているレンダリングサポートをまとめたものです。プレゼンテーションが未サポートのエフェクトを使用している場合は、生成されたフレームをプレビューしてください。

**入口**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly In** | Yes | Yes |
| **Float In** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Wheel** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Grow & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**強調**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | No | Yes |
| **Color Pulse** | No | Yes |
| **Teeter** | Yes | Yes |
| **Spin** | Yes | Yes |
| **Grow/Shrink** | No | Yes |
| **Desaturate** | No | Yes |
| **Darken** | No | Yes |
| **Lighten** | No | Yes |
| **Transparency** | No | Yes |
| **Object Color** | No | Yes |
| **Complementary Color** | No | Yes |
| **Line Color** | No | Yes |
| **Fill Color** | No | Yes |

**退出**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly Out** | Yes | Yes |
| **Float Out** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Shrink & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**モーション パス:**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **よくある質問**

**Aspose.Slides は直接 MP4 ファイルを作成しますか？**

いいえ。Aspose.Slides はプレゼンテーションのフレームを生成します。FFmpeg などのビデオエンコーダーを使用してそれらを MP4 ファイルに結合してください。

**動画の再生が期待より速くまたは遅くなるのはなぜですか？**

フレーム生成時とエンコーダの入力フレームレートで同じ FPS を使用してください。不一致があると画像シーケンスの再生時間が変わります。

**パスワードで保護されたプレゼンテーションを変換できますか？**

はい。[保護されたプレゼンテーションの読み込み](/slides/ja/python-java/password-protected-presentation/) 時に正しいパスワードを指定し、ロードされたコンテンツからフレームを生成してください。

**このワークフローはプレゼンテーションの音声を保持しますか？**

サンプルは画像フレームのみをエクスポートするため、生成された動画は無音です。音声を含めるには、動画エンコード時に別途音声トラックを提供してください。

**一時的なディスク使用量を減らすにはどうすればよいですか？**

フレームサイズを小さくするか、FPS を下げてください。また、エンコードが成功したら一時的な PNG ファイルを削除します。設定を減らす際は、結果の動画品質を確認してください。