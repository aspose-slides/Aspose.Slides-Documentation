---
title: .NET でスライドショーを管理する
linktitle: スライドショー
type: docs
weight: 90
url: /ja/net/manage-slide-show/
keywords:
- 表示タイプ
- スピーカーによる提示
- 個人が閲覧
- キオスクで閲覧
- ショーオプション
- 継続ループ
- ナレーションなしで表示
- アニメーションなしで表示
- ペンカラー
- スライド表示
- カスタムショー
- スライド進行
- 手動で
- タイミング使用
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でスライドショーを管理する方法を学びます。PPT、PPTX、ODP 形式のスライド遷移、タイミングなどを簡単に制御できます。"
---

Microsoft PowerPoint では、**スライドショー**設定がプロフェッショナルなプレゼンテーションの準備と実施に欠かせない重要なツールです。このセクションで最も重要な機能のひとつが **Set Up Show** で、プレゼンテーションを特定の条件や対象に合わせて調整でき、柔軟性と利便性を確保します。この機能を使うと、ショーの種類（例: 話者が提示、個人が閲覧、キオスクで閲覧）を選択したり、ループの有無を設定したり、表示するスライドを指定したり、タイミングを使用したりできます。プレゼンテーションをより効果的かつプロフェッショナルにするための重要な準備ステップです。

`SlideShowSettings` は [プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのプロパティで、型は [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/) です。PowerPoint プレゼンテーションのスライドショー設定を管理できます。この記事では、このプロパティを使用してスライドショー設定のさまざまな側面を構成および制御する方法を解説します。

## **表示タイプの選択**

`SlideShowSettings.SlideShowType` はスライドショーのタイプを定義し、次のクラスのいずれかのインスタンスになります: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/)、または [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/)。このプロパティを使用すると、キオスク向けの自動実行や手動プレゼンテーションなど、さまざまな使用シナリオに合わせてプレゼンテーションを調整できます。

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


## **ショーオプションの有効化**

`SlideShowSettings.Loop` はスライドショーを手動で停止するまでループさせるかどうかを決定します。これは、継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings.ShowNarration` はスライドショー中に音声ナレーションを再生するかどうかを決定します。音声ガイダンスを含む自動プレゼンテーションに有用です。`SlideShowSettings.ShowAnimation` はスライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。プレゼンテーションの視覚効果を完全に提供するために役立ちます。

次のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **表示スライドの選択**

`SlideShowSettings.Slides` プロパティを使用すると、プレゼンテーション中に表示するスライドの範囲を選択できます。プレゼンテーション全体ではなく一部だけを表示したい場合に便利です。次のコード例は新しいプレゼンテーションを作成し、スライド `2` から `9` までの範囲を表示するように設定します。
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


## **スライドの自動進行の使用**

`SlideShowSettings.UseTimings` プロパティは、各スライドの事前設定タイミングの使用を有効または無効にします。事前に定義された表示時間でスライドを自動的に切り替える場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **メディアコントロールの表示**

`SlideShowSettings.ShowMediaControls` プロパティは、マルチメディアコンテンツ（ビデオやオーディオなど）再生時にスライドショー中にメディアコントロール（再生、停止、停止など）を表示するかどうかを決定します。プレゼンテーション中にプレゼンターがメディア再生を制御できるようにしたい場合に便利です。

次のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**プレゼンテーションを保存すると、直接スライドショーモードで開くことはできますか？**

はい。ファイルを PPSX または PPSM として保存すると、PowerPoint で開いたときに直接スライドショーが開始します。Aspose.Slides では、[エクスポート時に対応する保存形式](/slides/ja/net/save-presentation/) を選択してください。

**個々のスライドを削除せずにショーから除外できますか？**

はい。スライドを [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) としてマークします。非表示スライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides でスライドショーを再生したり、画面上でライブプレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーションファイルの編集、解析、変換を行うものであり、実際の再生は PowerPoint などのビューアアプリケーションが担当します。