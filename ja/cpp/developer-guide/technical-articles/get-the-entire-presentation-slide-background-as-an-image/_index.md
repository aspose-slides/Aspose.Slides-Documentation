---
title: プレゼンテーションスライドの背景を画像として取得する
type: docs
weight: 95
url: /ja/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 背景を画像に
- PowerPoint
- PPT
- PPTX
- PowerPointプレゼンテーション
- C++
- Aspose.Slides for C++
---

PowerPointプレゼンテーションでは、スライドの背景は多くの要素から構成されることがあります。[スライド背景](/slides/ja/cpp/presentation-background/)として設定された画像に加え、最終的な背景はプレゼンテーションのテーマ、カラースキーム、マスタースライドやレイアウトスライドに配置された図形によって影響を受けることがあります。

Aspose.Slides for C++には、プレゼンテーションスライドの背景全体を画像として抽出する簡単な方法は提供されていませんが、以下の手順に従ってこれを行うことができます：
1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドから図形を削除します。
1. クローンしたスライドを画像に変換します。

以下のコード例は、プレゼンテーションスライドの背景全体を画像として抽出します。
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```