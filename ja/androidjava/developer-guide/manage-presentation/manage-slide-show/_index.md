---
title: Android でスライドショーを管理する
linktitle: スライドショー
type: docs
weight: 90
url: /ja/androidjava/manage-slide-show/
keywords:
- ショータイプ
- スピーカーによる提示
- 個人閲覧
- キオスク閲覧
- ショーオプション
- 連続ループ
- ナレーションなしで表示
- アニメーションなしで表示
- ペンの色
- スライドを表示
- カスタムショー
- スライドの自動進行
- 手動
- タイミング使用
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用した Android 用 Aspose.Slides でスライドショーを管理する方法を学びます。PPT、PPTX、ODP 形式のスライド遷移、タイミングなどを簡単に制御できます。"
---

Microsoft PowerPointでは、**Slide Show** 設定は、プロフェッショナルなプレゼンテーションを準備し、実施するための重要なツールです。このセクションで最も重要な機能のひとつが **Set Up Show** で、プレゼンテーションを特定の条件やオーディエンスに合わせて調整でき、柔軟性と便利さを確保します。この機能を使用すると、ショータイプ（例：スピーカーが提示、個人が閲覧、キオスクで閲覧）を選択し、ループの有無を設定し、表示するスライドを指定し、タイミングを使用できます。この準備段階は、プレゼンテーションをより効果的かつプロフェッショナルにするために重要です。

`getSlideShowSettings` は [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのメソッドで、[SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/) 型のオブジェクトを返し、PowerPoint プレゼンテーションのスライドショー設定を管理できます。この項では、このメソッドを使用してスライドショー設定のさまざまな側面を構成および制御する方法を探ります。 

## **ショータイプの選択**

`SlideShowSettings.setSlideShowType` はスライドショーのタイプを定義し、次のクラスのインスタンスのいずれかに設定できます: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), または [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). このメソッドを使用すると、自動キオスクや手動プレゼンテーションなど、さまざまな使用シナリオに合わせてプレゼンテーションを調整できます。

以下のコード例は新しいプレゼンテーションを作成し、ショータイプを「Browsed by an individual」に設定し、スクロールバーを表示しません。
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **ショーオプションの有効化**

`SlideShowSettings.setLoop` はスライドショーを手動で停止するまでループ再生するかどうかを決定します。これは継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings.setShowNarration` はスライドショー中に音声ナレーションを再生するかどうかを決定します。これは聴衆に音声ガイダンスを提供する自動プレゼンテーションに有用です。`SlideShowSettings.setShowAnimation` はスライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。これにより、プレゼンテーションの視覚効果を完全に表示できます。

以下のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **表示するスライドの選択**

`SlideShowSettings.setSlides` メソッドを使用すると、プレゼンテーション中に表示するスライドの範囲を選択できます。これにより、プレゼンテーション全体ではなく、一部だけを表示したい場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、スライド範囲をスライド `2` から `9` に設定します。
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **スライドの自動進行を使用**

`SlideShowSettings.setUseTimings` メソッドは、各スライドの事前設定されたタイミングの使用を有効または無効にします。これにより、あらかじめ定義された表示時間でスライドを自動的に切り替えることができます。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **メディアコントロールの表示**

`SlideShowSettings.setShowMediaControls` メソッドは、マルチメディアコンテンツ（例：ビデオやオーディオ）が再生されるスライドショー中に、再生、停止、ポーズなどのメディアコントロールを表示するかどうかを決定します。これにより、プレゼンテーション中にメディアの再生を操作したい場合に役立ちます。

以下のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**プレゼンテーションを保存して直接スライドショーモードで開くことはできますか？**

はい。ファイルを PPSX または PPSM 形式で保存すると、PowerPoint で開いたときに直接スライドショーが開始されます。Aspose.Slides では、対応する保存形式を [during export](/slides/ja/androidjava/save-presentation/) で選択してください。

**ファイルから削除せずに個別のスライドをショーから除外できますか？**

はい。スライドを [hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-) に設定します。非表示のスライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides がスライドショーを再生したり、画面上のライブプレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーションファイルの編集、解析、変換を行うものであり、実際の再生は PowerPoint などのビューアーアプリケーションが担当します。