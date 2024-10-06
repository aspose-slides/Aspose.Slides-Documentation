---
title: プレゼンテーションスライド全体の背景を画像として取得する
type: docs
weight: 95
url: /ja/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 画像への背景
- PowerPoint
- PPT
- PPTX
- PowerPointプレゼンテーション
- Java
- Aspose.Slides for Android via Java
---

PowerPointプレゼンテーションでは、スライドの背景は多くの要素で構成される場合があります。[スライド背景](/slides/ja/androidjava/presentation-background/)として設定された画像に加え、最終的な背景はプレゼンテーションのテーマ、カラースキーム、マスタースライド及びレイアウトスライドに配置された形状の影響を受けることがあります。

Aspose.Slides for Android via Javaは、プレゼンテーションスライド全体の背景を画像として抽出するための簡単な方法を提供していませんが、以下の手順に従うことでこれを行うことができます：
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドのサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドから形状を削除します。
1. クローンしたスライドを画像に変換します。

以下のコード例は、プレゼンテーションスライド全体の背景を画像として抽出します。
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```