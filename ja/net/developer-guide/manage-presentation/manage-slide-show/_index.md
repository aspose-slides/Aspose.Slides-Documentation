---
title: スライドショーの管理
type: docs
weight: 90
url: /ja/net/manage-slide-show/
keywords:
- ショータイプ
- スピーカーによる提示
- 個人が閲覧
- キオスクで閲覧
- ショーオプション
- 継続的にループ
- ナレーションなしで表示
- アニメーションなしで表示
- ペンの色
- スライドを表示
- カスタムショー
- スライドを進める
- 手動で
- タイミングを使用
- PowerPoint
- プレゼンテーション
- C#
- .NET
- Aspose.Slides for .NET
description: "C# を使用して PowerPoint プレゼンテーションのスライドショー設定を管理する"
---

Microsoft PowerPoint では、**Slide Show** 設定はプロフェッショナルなプレゼンテーションの作成と実施に不可欠なツールです。このセクションの最も重要な機能のひとつが **Set Up Show** で、プレゼンテーションを特定の条件や聴衆に合わせて調整でき、柔軟性と利便性を確保します。この機能を使用すると、ショーの種類（例：スピーカーが提示、個人が閲覧、キオスクでの閲覧）を選択したり、ループの有無を設定したり、表示するスライドを指定したり、タイミングを使用したりできます。準備段階のこのステップは、プレゼンテーションをより効果的でプロフェッショナルにするために重要です。

`SlideShowSettings` は[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのプロパティで、型は[SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/)です。これにより、PowerPoint プレゼンテーションのスライドショー設定を管理できます。本稿では、このプロパティを使用してスライドショー設定のさまざまな側面を構成・制御する方法を説明します。

## **Select Show Type**

`SlideShowSettings.SlideShowType` はスライドショーの種類を定義し、以下のクラスのいずれかのインスタンスになります:[PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/)、または[BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/)。このプロパティを使用すると、自動キオスクや手動プレゼンテーションなど、さまざまな使用シナリオに合わせてプレゼンテーションを調整できます。

以下のコード例は新しいプレゼンテーションを作成し、スクロールバーを表示せずに「個人が閲覧」タイプに設定します。
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Enable Show Options**

`SlideShowSettings.Loop` はスライドショーを手動で停止するまでループさせるかどうかを決定します。これは、継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings.ShowNarration` はスライドショー中に音声ナレーションを再生するかどうかを決定します。聴衆向けに音声ガイダンスを含む自動プレゼンテーションに有用です。`SlideShowSettings.ShowAnimation` はスライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。プレゼンテーションの視覚効果を完全に提供するために役立ちます。

以下のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Select Slides to Show**

`SlideShowSettings.Slides` プロパティを使用すると、プレゼンテーション中に表示するスライドの範囲を選択できます。これにより、プレゼンテーション全体ではなく一部だけを表示したい場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、スライド範囲を`2`から`9`に設定します。
```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Use Advance Slides**

`SlideShowSettings.UseTimings` プロパティは、各スライドの事前設定されたタイミングの使用を有効または無効にします。これにより、事前に定義された表示時間で自動的にスライドを切り替えることができます。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Show Media Controls**

`SlideShowSettings.ShowMediaControls` プロパティは、マルチメディア コンテンツ（例：ビデオやオーディオ）が再生される際に、スライドショー中にメディアコントロール（再生、停止、停止など）を表示するかどうかを決定します。プレゼンテーション中にメディアの再生を制御したい場合に便利です。

以下のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**

はい。ファイルをPPSXまたはPPSM形式で保存すると、PowerPointで開いたときにスライドショーモードで直接起動します。Aspose.Slidesでは、エクスポート時に対応する保存形式を選択します[エクスポート時](/slides/ja/net/save-presentation/)。

**Can I exclude individual slides from the show without deleting them from the file?**

はい。スライドを[非表示](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/)としてマークします。非表示スライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

いいえ。Aspose.Slidesはプレゼンテーションファイルの編集、解析、変換を行うもので、実際の再生はPowerPointなどのビューア アプリケーションが担当します。