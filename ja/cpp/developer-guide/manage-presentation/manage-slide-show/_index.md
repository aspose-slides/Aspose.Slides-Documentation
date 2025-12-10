---
title: C++ でスライドショーを管理する
linktitle: スライドショー
type: docs
weight: 90
url: /ja/cpp/manage-slide-show/
keywords:
- ショータイプ
- 発表者による提示
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
- タイミング使用
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライドショーを管理する方法を学びます。PPT、PPTX、ODP 形式のスライド遷移やタイミングなどを簡単に制御できます。"
---

Microsoft PowerPoint では、**Slide Show** 設定は、プロフェッショナルなプレゼンテーションを作成し提供するための重要なツールです。このセクションで最も重要な機能のひとつは **Set Up Show** で、プレゼンテーションを特定の条件や対象に合わせて調整でき、柔軟性と利便性を確保します。この機能を使用すると、ショータイプ（例: 発表者によるプレゼンテーション、個人が閲覧、キオスクで閲覧）を選択したり、ループの有無を設定したり、表示する特定のスライドを選んだり、タイミングを使用したりできます。この準備ステップは、プレゼンテーションをより効果的かつプロフェッショナルにするために不可欠です。

`get_SlideShowSettings` は、クラス [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) のメソッドで、[SlideShowSettings](https://reference.aspose.com/slides/cpp/aspose.slides/slideshowsettings/) 型のオブジェクトを返し、PowerPoint プレゼンテーションのスライドショー設定を管理できます。本稿では、このメソッドを使用してスライドショー設定のさまざまな側面を構成および制御する方法を解説します。 

## **ショータイプの選択**

`SlideShowSettings.set_SlideShowType` はスライドショーの種類を定義し、以下のクラスのインスタンスのいずれかに設定できます: [PresentedBySpeaker](https://reference.aspose.com/slides/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cpp/aspose.slides/browsedbyindividual/), または [BrowsedAtKiosk](https://reference.aspose.com/slides/cpp/aspose.slides/browsedatkiosk/)。このメソッドを使用すると、例えば自動キオスクや手動プレゼンテーションなど、様々な使用シナリオに合わせてプレゼンテーションを調整できます。

以下のコード例は新しいプレゼンテーションを作成し、スクロールバーを表示せずに「個人が閲覧」モードに設定します。
```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **ショーオプションの有効化**

`SlideShowSettings.set_Loop` はスライドショーを手動で停止するまでループ再生するかどうかを決定します。これは継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings.set_ShowNarration` はスライドショー中に音声ナレーションを再生するかどうかを決定します。音声ガイダンスを含む自動プレゼンテーションに有用です。`SlideShowSettings.set_ShowAnimation` はスライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。プレゼンテーションの視覚効果を完全に提供するために役立ちます。

以下のコード例は新しいプレゼンテーションを作成し、スライドショーをループさせます。
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **表示スライドの選択**

`SlideShowSettings.set_Slides` メソッドは、プレゼンテーション中に表示するスライドの範囲を選択できます。これにより、プレゼンテーション全体ではなく一部だけを表示したい場合に便利です。以下のコード例は新しいプレゼンテーションを作成し、スライド `2` から `9` までの範囲を表示するように設定します。
```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **スライドの自動進行を使用**

`SlideShowSettings.set_UseTimings` メソッドは、各スライドの事前設定された表示時間（タイミング）を使用するかどうかを有効化または無効化します。これにより、事前に定義された表示期間でスライドを自動的に切り替えることができます。以下のコード例は新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **メディアコントロールの表示**

`SlideShowSettings.set_ShowMediaControls` メソッドは、マルチメディア コンテンツ（例: ビデオやオーディオ）が再生される際に、スライドショー中にメディアコントロール（再生、停止、ポーズなど）を表示するかどうかを決定します。プレゼンテーション中にプレゼンターがメディア再生を制御できるようにしたい場合に便利です。

以下のコード例は新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **よくある質問**

**プレゼンテーションを保存すると、スライドショーモードで直接開くようにできますか？**

はい。ファイルを PPSX または PPSM 形式で保存すると、PowerPoint で開いたときにスライドショーが直接起動します。Aspose.Slides では、[エクスポート時](/slides/ja/cpp/save-presentation/)に対応する保存形式を選択してください。

**個別のスライドをファイルから削除せずにショーから除外できますか？**

はい。スライドを[非表示](https://reference.aspose.com/slides/cpp/aspose.slides/slide/set_hidden/)に設定します。非表示のスライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides はスライドショーを再生したり、画面上でライブ プレゼンテーションを制御したりできますか？**

いいえ。Aspose.Slides はプレゼンテーション ファイルの編集、解析、変換を行うライブラリであり、実際の再生は PowerPoint などのビューア アプリケーションが処理します。