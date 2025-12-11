---
title: Androidでスライドショーを管理する
linktitle: スライドショー
type: docs
weight: 90
url: /ja/androidjava/manage-slide-show/
keywords:
- 表示タイプ
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
- タイミング使用
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android（Java）でスライドショーを管理する方法を学びます。PPT、PPTX、ODP形式のスライド遷移やタイミングなどを簡単に制御できます。"
---

Microsoft PowerPointでは、**スライドショー**設定は、プロフェッショナルなプレゼンテーションを準備・実施するための重要なツールです。このセクションで最も重要な機能のひとつは**セットアップショー**で、プレゼンテーションを特定の条件やオーディエンスに合わせて調整でき、柔軟性と利便性が確保されます。この機能を使うと、ショータイプ（例: スピーカーが提示する、個人が閲覧する、キオスクで閲覧する）を選択したり、ループの有無を設定したり、表示するスライドを指定したり、タイミングを使用したりできます。準備段階でこのステップを踏むことは、プレゼンテーションをより効果的でプロフェッショナルにするために不可欠です。

`getSlideShowSettings` は、[プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのメソッドで、[SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/) 型のオブジェクトを返します。このオブジェクトを使用すると、PowerPoint プレゼンテーションのスライドショー設定を管理できます。この記事では、このメソッドの使用方法と、スライドショー設定のさまざまな側面を構成・制御する方法を解説します。

## **表示タイプの選択**

`SlideShowSettings.setSlideShowType` は、スライドショーのタイプを定義します。このタイプは、次のクラスのいずれかのインスタンスにできます: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), または [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). このメソッドを使用すると、キオスクの自動化や手動プレゼンテーションなど、さまざまな利用シナリオに合わせてプレゼンテーションを調整できます。

以下のコード例は新しいプレゼンテーションを作成し、スクロールバーを表示せずに「個人が閲覧する」タイプに設定します。
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **ショーオプションの有効化**

`SlideShowSettings.setLoop` は、スライドショーを手動で停止するまでループ再生するかどうかを決定します。これは、継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings.setShowNarration` は、スライドショー中に音声ナレーションを再生するかどうかを決定します。これは、聴衆に音声ガイダンスを提供する自動プレゼンテーションに有用です。`SlideShowSettings.setShowAnimation` は、スライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。これにより、プレゼンテーションの視覚効果を完全に表現できます。

以下のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **表示するスライドの選択**

`SlideShowSettings.setSlides` メソッドを使用すると、プレゼンテーション中に表示するスライドの範囲を選択できます。プレゼンテーション全体ではなく、一部のスライドだけを表示したい場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、スライド範囲を `2` から `9` に設定します。
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **スライドの自動進行の使用**

`SlideShowSettings.setUseTimings` メソッドは、各スライドの事前設定されたタイミングの使用を有効または無効にできます。これは、あらかじめ定義された表示時間でスライドを自動的に表示する際に便利です。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **メディアコントロールの表示**

`SlideShowSettings.setShowMediaControls` メソッドは、マルチメディア コンテンツ（例: ビデオやオーディオ）が再生されるスライドショー中に、メディアコントロール（再生、停止、ポーズなど）を表示するかどうかを決定します。プレゼンテーション中にプレゼンターがメディア再生を制御できるようにしたい場合に便利です。

以下のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **よくある質問**

**プレゼンテーションを保存すると、スライドショーモードで直接開くようにできますか？**

はい。ファイルを PPSX または PPSM として保存してください。これらの形式は PowerPoint で開くと直接スライドショーが開始されます。Aspose.Slides では、対応する保存形式を[エクスポート時](/slides/ja/androidjava/save-presentation/) に選択します。

**ファイルから削除せずに、個別のスライドをショーから除外できますか？**

はい。スライドを[hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-) としてマークします。非表示のスライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides はスライドショーを再生したり、画面上でライブプレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーション ファイルの編集、解析、変換を行うだけで、実際の再生は PowerPoint などのビューア アプリケーションが担当します。