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
- ユニークなスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットを確保する
- 最大化する
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを素早くリサイズする方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **はじめに**

Aspose.Slides は、印刷および画面表示の両方で重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **標準 (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成の最初の段階でスライドの寸法を設定し、後からのトラブルを防ぎましょう。

{{% alert color="info" %}} 
デフォルトでは、Aspose.Slidesで作成されたプレゼンテーションは標準の4:3アスペクト比を使用します。
{{% /alert %}}

ノートページや配布資料ページは通常のスライドとは別のサイズです。サイズや向きを変更するには[ノートページサイズ](/slides/ja/cpp/notes-size/)をご参照ください。

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、C++ で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示しています。

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ (4:3 および 16:9) が要件に合わない場合、特定またはユニークなスライドサイズを使用することができます。たとえば、カスタムページレイアウトでフルサイズのスライドを印刷したり、特定の画面タイプでプレゼンテーションを表示したりする場合、カスタムサイズ設定が役立ちます。

このサンプルコードは、C++ で Aspose.Slides を使用してプレゼンテーションにカスタムスライドサイズを指定する方法を示しています。

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 用紙サイズ
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **サイズ変更後のスライドコンテンツの処理**

プレゼンテーションのスライドサイズを変更すると、スライドの内容 (画像やオブジェクトなど) が歪むことがあります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます:

- `DoNotScale`

  スライド上のオブジェクトをサイズ変更したくない場合は、この設定を使用します。

- `EnsureFit`

  小さなスライドサイズに縮小したい場合で、すべてのオブジェクトがスライド内に収まるように Aspose.Slides に縮小させたい (コンテンツが失われるのを防ぐ) 場合は、この設定を使用します。

- `Maximize`

  大きなスライドサイズに拡大したい場合で、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示しています。

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **よくある質問**

### カスタムスライドサイズをインチ以外の単位 (ポイントやミリメートルなど) で設定できますか？

はい。Aspose.Slides は内部でポイントを使用します。1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに変換し、変換した値でスライドの幅と高さを定義できます。

### 非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？

はい。ポイント単位での大きなスライド寸法と高いレンダリングスケールを組み合わせると、メモリ使用量が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して目的の出力品質を得てください。

### 異なるサイズのプレゼンテーションからスライドをマージしたい場合、非標準のスライドサイズを一つだけ定義できますか？

スライドサイズが異なる状態で[プレゼンテーションのマージ](/slides/ja/cpp/merge-presentation/)はできません。まず、どちらかのプレゼンテーションをサイズを合わせてリサイズします。スライドサイズを変更するときは、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

### スライドの個々のシェイプや特定領域のサムネイルを生成できますか？生成されたサムネイルは新しいスライドサイズを考慮しますか？

はい。Aspose.Slides は[全スライド]（https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/getimage/）だけでなく、[選択したシェイプ]（https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getimage/）のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保ちます。