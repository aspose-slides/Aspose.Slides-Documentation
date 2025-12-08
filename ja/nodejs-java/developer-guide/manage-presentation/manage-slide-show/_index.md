---
title: スライドショーの管理
type: docs
weight: 90
url: /ja/nodejs-java/manage-slide-show/
keywords:
- ショータイプ
- スピーカーによる提示
- 個人による閲覧
- キオスクでの閲覧
- ショーオプション
- 連続ループ
- ナレーションなしで表示
- アニメーションなしで表示
- ペンの色
- スライドの表示
- カスタムショー
- スライドの進行
- 手動で
- タイミングの使用
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "JavaScript を使用して PowerPoint プレゼンテーションのスライドショー設定を管理する"
---

Microsoft PowerPoint では、**スライドショー**設定はプロフェッショナルなプレゼンテーションの作成と実施に不可欠なツールです。このセクションで最も重要な機能のひとつは **Set Up Show** で、プレゼンテーションを特定の条件やオーディエンスに合わせて調整でき、柔軟性と利便性を確保します。この機能を使用すると、ショータイプ（例: スピーカーが提示、個人が閲覧、キオスクで閲覧）を選択し、ループの有無を設定し、表示するスライドを指定し、タイミングを使用できます。この準備段階は、プレゼンテーションをより効果的かつプロフェッショナルにするために重要です。

`getSlideShowSettings` は [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのメソッドで、[SlideShowSettings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowsettings/) 型のオブジェクトを返し、PowerPoint プレゼンテーションのスライドショー設定を管理できます。本稿では、このメソッドを使用してスライドショー設定のさまざまな側面を構成および制御する方法を解説します。

## **ショータイプの選択**

`SlideShowSettings.setSlideShowType` はスライドショーのタイプを定義し、次のクラスのいずれかのインスタンスを指定できます: [PresentedBySpeaker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedbyindividual/)、[BrowsedAtKiosk](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedatkiosk/)。このメソッドを使用すると、自動キオスクや手動プレゼンテーションなど、さまざまな使用シナリオに合わせてプレゼンテーションを適応させることができます。

以下のコード例は新しいプレゼンテーションを作成し、スクロールバーを表示せずに「個人が閲覧」タイプに設定します。
```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **ショーオプションの有効化**

`SlideShowSettings.setLoop` はスライドショーを手動で停止するまでループさせるかどうかを決定します。これは継続的に実行する必要がある自動プレゼンテーションに役立ちます。`SlideShowSettings.setShowNarration` はスライドショー中に音声ナレーションを再生するかどうかを決定します。音声ガイダンスを含む自動プレゼンテーションに有用です。`SlideShowSettings.setShowAnimation` はスライドオブジェクトに追加されたアニメーションを再生するかどうかを決定し、プレゼンテーションの完全な視覚効果を提供します。

以下のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **表示スライドの選択**

`SlideShowSettings.setSlides` メソッドは、プレゼンテーション中に表示するスライドの範囲を選択できます。これにより、全スライドではなくプレゼンテーションの一部のみを表示したい場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、スライド範囲を `2` から `9` に設定します。
```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **スライドの自動進行の使用**

`SlideShowSettings.setUseTimings` メソッドは、各スライドの事前設定されたタイミングの使用を有効または無効にします。これにより、事前定義された表示時間でスライドを自動的に切り替えることができます。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **メディアコントロールの表示**

`SlideShowSettings.setShowMediaControls` メソッドは、マルチメディアコンテンツ（例: ビデオやオーディオ）が再生される際に、スライドショー中にメディアコントロール（再生、停止、ポーズなど）を表示するかどうかを決定します。プレゼンターがプレゼンテーション中にメディア再生を制御したい場合に便利です。

以下のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**プレゼンテーションを保存すると、スライドショーモードで直接開くようにできますか？**

はい。ファイルを PPSX または PPSM として保存すると、PowerPoint で開いたときに直接スライドショーが起動します。Aspose.Slides では、対応する保存形式を[エクスポート中](/slides/ja/nodejs-java/save-presentation/)に選択してください。

**個別のスライドをファイルから削除せずにショーから除外できますか？**

はい。スライドを[非表示](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/sethidden/)としてマークします。非表示スライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides はスライドショーを再生したり、ライブプレゼンテーションを画面上で制御できますか？**

いいえ。Aspose.Slides はプレゼンテーションファイルの編集、分析、変換を行い、実際の再生は PowerPoint などのビューアアプリケーションが担当します。