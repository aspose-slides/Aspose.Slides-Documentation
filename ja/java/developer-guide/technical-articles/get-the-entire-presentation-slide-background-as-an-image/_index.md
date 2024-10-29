---
title: プレゼンテーションスライドの背景全体を画像として取得する
type: docs
weight: 95
url: /ja/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライドの背景
- 画像への背景
- PowerPoint
- PPT
- PPTX
- PowerPointプレゼンテーション
- Java
- Aspose.Slides for Java
---

PowerPointプレゼンテーションでは、スライドの背景は多くの要素で構成される場合があります。[スライドの背景](/slides/ja/java/presentation-background/)として設定された画像に加えて、最終的な背景はプレゼンテーションテーマ、カラースキーム、およびマスタースライドやレイアウトスライドに配置された図形の影響を受ける可能性があります。

Aspose.Slides for Javaは、プレゼンテーションスライドの背景全体を画像として抽出する簡単な方法を提供していませんが、以下の手順に従ってこれを行うことができます：
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスを使用してプレゼンテーションを読み込みます。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドから図形を削除します。
1. クローンしたスライドを画像に変換します。

以下のコード例は、プレゼンテーションスライドの背景全体を画像として抽出します。
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```