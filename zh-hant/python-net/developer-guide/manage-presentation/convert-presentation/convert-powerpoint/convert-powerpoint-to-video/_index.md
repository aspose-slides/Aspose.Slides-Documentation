---
title: 在 Python 中將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint 轉影片
- 將 PowerPoint 轉換為影片
- 簡報轉影片
- 將簡報轉換為影片
- PPT 轉影片
- 將 PPT 轉換為影片
- PPTX 轉影片
- 將 PPTX 轉換為影片
- ODP 轉影片
- 將 ODP 轉換為影片
- PowerPoint 轉 MP4
- 將 PowerPoint 轉換為 MP4
- 簡報轉 MP4
- 將簡報轉換為 MP4
- PPT 轉 MP4
- 將 PPT 轉換為 MP4
- PPTX 轉 MP4
- 將 PPTX 轉換為 MP4
- PowerPoint 轉影片轉換
- 簡報轉影片轉換
- PPT 轉影片轉換
- PPTX 轉影片轉換
- ODP 轉影片轉換
- Python 影片轉換
- PowerPoint
- Python
- Aspose.Slides
description: "了解如何使用 Python 將 PowerPoint 和 OpenDocument 簡報轉換為影片。探索範例程式碼與自動化技術，以簡化您的工作流程。"
---
## **簡介**

透過將您的 PowerPoint 或 OpenDocument 簡報轉換為影片，您可以獲得：

**提升可及性：** 所有裝置，不論平台，預設皆配備影片播放器，使用者比起傳統簡報應用程式更容易開啟或播放影片。

**更廣的受眾：** 影片讓您能觸及更大的觀眾，並以更具吸引力的形式呈現資訊。調查與統計顯示，人們較喜好觀看與消費影片內容，因而使您的訊息更具衝擊力。

{{% alert color="primary" %}} 

請查看我們的[**PowerPoint 轉影片線上轉換器**](https://products.aspose.app/slides/zh-hant/video)，因為它提供了本文所述流程的即時且有效的實作。

{{% /alert %}} 

在[Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/zh-hant/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/)中，我們實作了將簡報轉換為影片的支援。

* 使用 Aspose.Slides for Python 依指定的幀率 (FPS) 從簡報投影片產生影格。
* 接著，使用第三方工具（例如 ffmpeg）將這些影格合併為影片。

## **將 PowerPoint 簡報轉換為影片**

1. 使用 pip 安裝指令將 Aspose.Slides for Python 加入您的專案： `pip install aspose-slides==24.4.0`
2. 從[此處](https://ffmpeg.org/download.html)下載 ffmpeg，或透過套件管理員安裝。
3. 確保 ffmpeg 已加入 `PATH`。否則，請以二進位檔的完整路徑啟動 ffmpeg（例如 Windows 上的 `C:\ffmpeg\ffmpeg.exe` 或 Linux 上的 `/opt/ffmpeg/ffmpeg`）。
4. 執行 PowerPoint 轉影片的程式碼。

以下 Python 程式碼示範如何將包含圖形與兩個動畫效果的簡報轉換為影片：

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **影片效果**

使用 Aspose.Slides for Python 將 PowerPoint 簡報轉換為影片時，您可以套用各種影片效果，以提升輸出畫面的視覺品質。這些效果讓您能透過平滑的轉場、動畫與其他視覺元素，控制投影片在最終影片中的呈現方式。本節說明可用的影片效果選項，並示範如何套用它們。

{{% alert color="primary" %}} 

請參閱[PowerPoint Animation](https://docs.aspose.com/slides/zh-hant/python-net/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/zh-hant/python-net/shape-animation/)以及[Shape Effect](https://docs.aspose.com/slides/zh-hant/python-net/shape-effect/)。

{{% /alert %}} 

動畫與轉場讓投影片播放更具吸引力與趣味─影片亦是如此。讓我們為前面的簡報程式碼新增另一張投影片與轉場：

```python
import aspose.pydrawing as drawing

# 新增笑臉形狀並為其設定動畫。
# ...

# 新增一張投影片並加入動畫過場效果。
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python 也支援文字動畫。在此範例中，我們對物件上的段落進行動畫，使其依序顯示，且每個段落之間有一秒的延遲：

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 新增文字和動畫。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # 將影格轉換為影片。
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **影片轉換類別**

為了支援 PowerPoint 轉影片的任務，Aspose.Slides for Python 提供了[PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/presentationenumerableframesgenerator/)。

`PresentationEnumerableFramesGenerator` 允許您於建構子中設定影片的影格大小（稍後會建立）與 FPS（每秒影格數）值。若傳入簡報實例，會使用其 `Presentation.SlideSize`。

若要讓簡報中的所有動畫一次播放，請使用 `PresentationEnumerableFramesGenerator.enumerate_frames` 方法。此方法接受投影片集合，並依序回傳[EnumerableFrameArgs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/enumerableframeargs/)。之後，使用 `EnumerableFrameArgs.get_frame()` 取得各個影片影格。

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

產生的影格即可編譯成影片。更多細節，請參閱[Convert PowerPoint to Video](https://docs.aspose.com/slides/zh-hant/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video)章節。

## **支援的動畫與效果**

使用 Aspose.Slides for Python 將 PowerPoint 簡報轉換為影片時，了解最終輸出支援哪些動畫與效果十分重要。Aspose.Slides 支援多種常見的進入、退出與強調效果，如淡入、飛入、縮放與旋轉。然而，某些進階或自訂動畫可能無法完整保留，或在最終影片中呈現方式不同。本節列出已支援的動畫與效果。

**進入**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**強調**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**退出**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**動作路徑**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **支援的投影片轉場效果**

投影片轉場效果在影片中創造平滑且具視覺吸引力的切換，扮演重要角色。Aspose.Slides for Python 支援多種常見的轉場效果，以協助在轉換過程中保留原始簡報的流程與風格。本節說明哪些轉場效果在轉換期間受到支援。

**細緻**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**令人興奮**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**動態內容**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **常見問題**

**是否可以轉換受密碼保護的簡報？**

是的，Aspose.Slides for Python 支援處理受密碼保護的簡報。處理此類檔案時，您需要提供正確的密碼，以便程式庫能存取簡報內容。

**Aspose.Slides for Python 是否支援在雲端解決方案中使用？**

是的，Aspose.Slides for Python 可整合至雲端應用程式與服務。此程式庫專為伺服器環境設計，確保在大量檔案批次處理時具備高效能與可擴充性。

**在轉換過程中，簡報的大小是否有限制？**

Aspose.Slides for Python 幾乎可以處理任何大小的簡報。然而，當處理非常大型的檔案時，可能需要額外的系統資源，且有時建議先最佳化簡報以提升效能。