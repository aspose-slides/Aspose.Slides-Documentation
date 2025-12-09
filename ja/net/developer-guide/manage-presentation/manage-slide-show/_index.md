---
title: .NETでスライドショーを管理する
linktitle: スライドショー
type: docs
weight: 90
url: /ja/net/manage-slide-show/
keywords:
- ショータイプ
- 発表者によるプレゼンテーション
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
- タイミングの使用
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でスライドショーを管理する方法を学びます。PPT、PPTX、ODP 形式のスライド遷移やタイミングなどを簡単にコントロールできます。"
---

Microsoft PowerPoint では、**Slide Show** 設定はプロフェッショナルなプレゼンテーションを作成し、配信するための重要なツールです。このセクションで最も重要な機能のひとつは **Set Up Show** で、プレゼンテーションを特定の条件や対象に合わせて調整でき、柔軟性と利便性を確保します。この機能を使うと、ショータイプ（例: 発表者によるプレゼンテーション、個人閲覧、キオスク閲覧）を選択したり、ループの有無を設定したり、表示する特定のスライドを選んだり、タイミングを使用したりできます。この準備ステップは、プレゼンテーションをより効果的かつプロフェッショナルにするために重要です。

`SlideShowSettings` は [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのプロパティで、型は [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/) です。PowerPoint プレゼンテーションのスライドショー設定を管理できます。本稿では、このプロパティの使用方法を確認し、スライドショー設定のさまざまな側面を構成および制御する方法を紹介します。

## **ショータイプの選択**

`SlideShowSettings.SlideShowType` はスライドショーのタイプを定義し、以下のクラスのいずれかのインスタンスにできます: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), または [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/)。このプロパティを使用すると、自動キオスクや手動プレゼンテーションなど、さまざまな利用シナリオに合わせてプレゼンテーションを調整できます。

以下のコード例は新しいプレゼンテーションを作成し、スクロールバーを表示せずにショータイプを「個人閲覧」に設定します。
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **ショーオプションの有効化**

`SlideShowSettings.Loop` はスライドショーを手動で停止するまでループさせるかどうかを決定します。これは継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings.ShowNarration` はスライドショー中に音声ナレーションを再生するかどうかを決定します。観客向けに音声ガイダンスを含む自動プレゼンテーションに有用です。`SlideShowSettings.ShowAnimation` はスライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。プレゼンテーションの視覚効果をフルに提供するために役立ちます。

以下のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **表示するスライドの選択**

`SlideShowSettings.Slides` プロパティは、プレゼンテーション中に表示するスライドの範囲を選択できます。全スライドではなくプレゼンテーションの一部だけを表示したい場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、スライド `2` から `9` までの範囲を表示するように設定します。
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


## **スライドの自動進行を使用**

`SlideShowSettings.UseTimings` プロパティは、各スライドの事前設定されたタイミングの使用を有効または無効にできます。事前に定義された表示時間でスライドを自動的に表示したい場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **メディアコントロールの表示**

`SlideShowSettings.ShowMediaControls` プロパティは、マルチメディアコンテンツ（例: ビデオやオーディオ）が再生される際に、スライドショー中に再生、停止、ポーズなどのメディアコントロールを表示するかどうかを決定します。プレゼンテーション中にプレゼンターがメディア再生を制御したい場合に有用です。

以下のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**プレゼンテーションを保存して、直接スライドショーモードで開くことはできますか？**

はい。ファイルを PPSX または PPSM として保存します。これらの形式は PowerPoint で開くと直接スライドショーが開始されます。Aspose.Slides では、[エクスポート時](/slides/ja/net/save-presentation/)に対応する保存形式を選択します。

**ファイルから削除せずに、個々のスライドをショーから除外できますか？**

はい。スライドを [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) に設定します。非表示のスライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides がスライドショーを再生したり、画面上でライブプレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーションファイルの編集、解析、変換を行うだけで、実際の再生は PowerPoint などのビューアアプリケーションが行います。