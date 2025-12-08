---
title: Pythonでスライドショーを管理する
linktitle: スライドショー
type: docs
weight: 90
url: /ja/python-net/manage-slide-show/
keywords:
- ショータイプ
- スピーカーによる提示
- 個人閲覧
- キオスクで閲覧
- ショーオプション
- 連続ループ
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NETでスライドショーを管理する方法を学びます。PPT、PPTX、ODP形式のスライド遷移、タイミングなどを簡単に制御できます。"
---

Microsoft PowerPoint では、**Slide Show** 設定は、プロフェッショナルなプレゼンテーションを作成し配信するための重要なツールです。このセクションで最も重要な機能の一つは **Set Up Show** で、プレゼンテーションを特定の条件やオーディエンスに合わせて調整でき、柔軟性と利便性が確保されます。この機能を使用すると、ショータイプ（例: スピーカーが提示、個人が閲覧、キオスクで閲覧）を選択し、ループの有無を設定し、表示するスライドを指定し、タイミングを使用できます。準備段階でこの手順を踏むことは、プレゼンテーションをより効果的かつプロフェッショナルにするために不可欠です。

`slide_show_settings` は [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのプロパティで、型は [SlideShowSettings](https://reference.aspose.com/slides/python-net/aspose.slides/slideshowsettings/) です。このプロパティを使用すると、PowerPoint プレゼンテーションのスライドショー設定を管理できます。本稿では、このプロパティを使ってスライドショー設定のさまざまな側面を構成および制御する方法を紹介します。

## **ショータイプの選択**

`SlideShowSettings.slide_show_type` はスライドショーのタイプを定義し、次のクラスのいずれかのインスタンスになります: [PresentedBySpeaker](https://reference.aspose.com/slides/python-net/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/python-net/aspose.slides/browsedbyindividual/)、または [BrowsedAtKiosk](https://reference.aspose.com/slides/python-net/aspose.slides/browsedatkiosk/)。このプロパティを使用すると、キオスクの自動実行や手動プレゼンテーションなど、さまざまな使用シナリオに合わせてプレゼンテーションを調整できます。

以下のコード例は新しいプレゼンテーションを作成し、スクロールバーを表示せずに「個人が閲覧」モードに設定します。
```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **ショーオプションの有効化**

`SlideShowSettings.loop` はスライドショーを手動で停止するまでループさせるかどうかを決定します。これは継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings.show_narration` はスライドショー中に音声ナレーションを再生するかどうかを決定します。これは聴衆に音声ガイダンスを提供する自動プレゼンテーションに役立ちます。`SlideShowSettings.show_animation` はスライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。これにより、プレゼンテーションの視覚効果を完全に表現できます。

次のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **表示スライドの選択**

`SlideShowSettings.slides` プロパティを使用すると、プレゼンテーション中に表示するスライドの範囲を選択できます。これにより、プレゼンテーション全体ではなく一部だけを表示したい場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、スライド範囲を `2` から `9` に設定します。
```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **スライドの自動進行の使用**

`SlideShowSettings.use_timings` プロパティは、各スライドの事前設定されたタイミングの使用を有効または無効にします。これにより、あらかじめ定義された表示時間でスライドを自動的に切り替えることができます。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **メディアコントロールの表示**

`SlideShowSettings.show_media_controls` プロパティは、マルチメディア コンテンツ（ビデオやオーディオなど）の再生時に、スライドショー中にメディアコントロール（再生、停止、ポーズなど）を表示するかどうかを決定します。これにより、プレゼンテーション中にプレゼンターがメディアの再生を制御できるようになります。

次のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**プレゼンテーションを保存すると、直接スライドショー モードで開くようにできますか？**

はい。ファイルを PPSX または PPSM 形式で保存してください。この形式は PowerPoint で開くと自動的にスライドショーで起動します。Aspose.Slides では、エクスポート時に対応する保存形式を選択します（[保存時の設定](/slides/ja/python-net/save-presentation/)）。

**個々のスライドをファイルから削除せずにショーから除外できますか？**

はい。スライドを [hidden](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) としてマークします。非表示スライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides はスライドショーを再生したり、画面上でライブ プレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーション ファイルの編集、解析、変換を行う製品であり、実際の再生は PowerPoint などのビューア アプリケーションが担当します。