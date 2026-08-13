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
- スライドサイズの設定
- スライドサイズの変更
- カスタムスライドサイズ
- 特殊スライドサイズ
- ユニークスライドサイズ
- フルサイズスライド
- スクリーンタイプ
- スケールしない
- フィットを確保
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを素早くリサイズし、画質を損なうことなく任意の画面向けにプレゼンテーションを最適化する方法を学びます。"
---
## **はじめに**

Aspose.Slides は、印刷および画面表示の両方において重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。 

一般的なスライドサイズと比率：

- **標準 (4:3 アスペクト比)**: 旧式の画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに同一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、トラブルを防ぐためにプレゼンテーション作成の初期段階でスライドの寸法を設定してください。

{{% alert color="info" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、Aspose.Slides を使用して C++ でプレゼンテーションのスライドサイズを変更する方法を示しています。

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

一般的なスライドサイズ (4:3 と 16:9) が作業に適さない場合、特定またはユニークなスライドサイズを使用することを検討できます。たとえば、プレゼンテーションのフルサイズスライドをカスタムページレイアウトで印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合、カスタムサイズ設定を使用すると便利です。 

このサンプルコードは、C++ 用 Aspose.Slides を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示しています。

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

## **サイズ変更後のスライドコンテンツの取り扱い**

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは自動的に新しいスライドサイズに合わせてリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライドサイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい場合（コンテンツの欠損を防ぐため）には、この設定を使用します。 

- `Maximize`

  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させたい場合は、この設定を使用します。 

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

## **FAQ**

### インチ以外の単位（例えばポイントやミリメートル）でカスタムスライドサイズを設定できますか？

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、その変換値を使用してスライドの幅と高さを設定できます。

### 非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？

はい。ポイント単位でスライドの寸法が大きくなると、レンダリングスケールが高くなるため、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールのみ調整して目的の出力品質を得るようにしてください。

### 標準外のスライドサイズを定義し、異なるサイズのプレゼンテーションからスライドをマージできますか？

スライドサイズが異なる状態では、[merge presentations](/slides/ja/cpp/merge-presentation/) を実行できません。まず、どちらかのプレゼンテーションのサイズをもう一方に合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの取り扱い方法を選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

### 個々のシェイプやスライドの特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを考慮しますか？

はい。Aspose.Slides は、[entire slides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/getimage/) と [selected shapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getimage/) のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保ちます。