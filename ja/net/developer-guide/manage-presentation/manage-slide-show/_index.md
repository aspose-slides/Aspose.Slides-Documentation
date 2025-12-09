---
title: .NETでスライドショーを管理
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
- 連続ループ
- ナレーションなしのショー
- アニメーションなしのショー
- ペンの色
- スライドを表示
- カスタムショー
- スライドを進める
- 手動で
- タイミング使用
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でスライドショーの管理方法を学びましょう。PPT、PPTX、ODP 形式のスライド遷移やタイミングなどを簡単に制御できます。"
---

PowerPoint では、**スライドショー** 設定は、プロフェッショナルなプレゼンテーションを準備・実行するための重要なツールです。このセクションで最も重要な機能のひとつが **Set Up Show** で、プレゼンテーションを特定の条件や対象に合わせて調整でき、柔軟性と利便性を確保します。この機能を使うと、ショーの種類（例: 発表者が操作、個人が閲覧、キオスクが閲覧）を選択したり、ループの有無を設定したり、表示するスライドを指定したり、タイミングを使用したりできます。プレゼンテーションをより効果的かつプロフェッショナルにするための重要な準備ステップです。

`SlideShowSettings` は [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのプロパティで、型は [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/) です。このプロパティを使用すると、PowerPoint プレゼンテーションのスライドショー設定を管理できます。本記事では、このプロパティを使ってスライドショー設定のさまざまな側面を構成・制御する方法を解説します。

## **ショーの種類を選択**

`SlideShowSettings.SlideShowType` はスライドショーの種類を定義し、次のクラスのいずれかのインスタンスを指定できます: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/)、または [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/)。このプロパティを使用すると、キオスクの自動実行や手動プレゼンテーションなど、さまざまな使用シナリオに合わせてプレゼンテーションを調整できます。

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


## **ショーオプションを有効化**

`SlideShowSettings.Loop` はスライドショーを手動で停止するまでループさせるかどうかを決定します。これは継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings.ShowNarration` はスライドショー中に音声ナレーションを再生するかどうかを決定します。音声ガイダンスを含む自動プレゼンテーションに有用です。`SlideShowSettings.ShowAnimation` はスライド上のオブジェクトに設定されたアニメーションを再生するかどうかを決定します。プレゼンテーションの視覚効果を完全に表現できます。

次のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **表示するスライドを選択**

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


## **スライドの自動進行を使用**

`SlideShowSettings.UseTimings` プロパティは、各スライドに事前設定された表示時間（タイミング）を使用するかどうかを有効化または無効化します。事前に定義された表示期間でスライドを自動的に切り替える際に役立ちます。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **メディアコントロールの表示**

`SlideShowSettings.ShowMediaControls` プロパティは、マルチメディアコンテンツ（例: ビデオやオーディオ）が再生される際に、スライドショー中にメディアコントロール（再生、停止、ポーズなど）を表示するかどうかを決定します。プレゼンテーション中にメディアの再生を操作したい場合に便利です。

次のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**プレゼンテーションを保存すると、直接スライドショーモードで開くことはできますか？**

はい。ファイルを PPSX または PPSM 形式で保存すると、PowerPoint で開いたときに自動的にスライドショーが開始されます。Aspose.Slides では、エクスポート時に対応する保存形式を選択してください [/slides/net/save-presentation/](/slides/ja/net/save-presentation/)。

**個々のスライドを削除せずにショーから除外できますか？**

はい。スライドを [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) とマークします。非表示スライドはプレゼンテーション内に残りますが、スライドショー時には表示されません。

**Aspose.Slides はスライドショーを再生したり、画面上でライブプレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーションファイルの編集、解析、変換を行うもので、実際の再生は PowerPoint などのビューアアプリケーションが担当します。