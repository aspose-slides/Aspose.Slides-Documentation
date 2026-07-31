---
title: C++ でプレゼンテーションのスライドサイズを変更する
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/cpp/slide-size/
keywords:
- スライドサイズ
- アスペクト比
- 標準
- ワイドスクリーン
- 4:3
- 16:9
- スライドサイズを設定する
- スライドサイズを変更する
- カスタムスライドサイズ
- 特別なスライドサイズ
- 固有のスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットを保証する
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを素早くリサイズする方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides は、PowerPoint プレゼンテーションにおけるスライドサイズとアスペクト比を調整するための包括的なツールを提供し、印刷および画面表示の両方に重要です。 

一般的なスライドサイズと比率：

- **標準 (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに同じサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成の初期段階でスライドの寸法を設定し、問題を防ぎましょう。

{{% alert color="primary" %}} 
既定では、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションでスライドサイズを変更する**

このサンプルコードは、C++ で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示します。

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ（4:3 と 16:9）が目的に合わない場合、特定または固有のスライドサイズを使用することができます。たとえば、プレゼンテーションのスライドをカスタムページレイアウトでフルサイズ印刷したり、特定の画面タイプで表示したりする場合、カスタムサイズ設定を利用すると便利です。 

このサンプルコードは、C++ 用 Aspose.Slides を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示します。

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 用紙サイズ
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **サイズ変更後のスライドコンテンツの取り扱い**

プレゼンテーションのスライドサイズを変更すると、スライドのコンテンツ（画像やオブジェクトなど）が歪むことがあります。既定では、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決める設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます：

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライドサイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides にダウンスケールさせたい場合（コンテンツの損失を防ぐため）、この設定を使用します。 

- `Maximize`

  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用します。 

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示します。

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **よくある質問**

**インチ以外の単位（例: ポイントやミリメートル）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントはインチの 1/72 に相当します。ミリメートルやセンチメートルなど任意の単位をポイントに換算し、その換算値でスライドの幅と高さを指定できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位の大きなスライド寸法に加えて高いレンダリング倍率を使用すると、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリング倍率だけを調整して目的の出力品質を得るようにしてください。

**標準外のスライドサイズを定義し、異なるサイズのプレゼンテーションからスライドをマージできますか？**

異なるスライドサイズの状態では[merge presentations](/slides/ja/cpp/merge-presentation/)できません—まず、1つのプレゼンテーションをもう一方に合わせてサイズ変更します。スライドサイズを変更する際には、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**個々のシェイプやスライドの特定領域のサムネイルを生成できますか？また、新しいスライドサイズを尊重しますか？**

はい。Aspose.Slides は[entire slides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/getimage/) のサムネイルだけでなく、[selected shapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getimage/) のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保ちます。