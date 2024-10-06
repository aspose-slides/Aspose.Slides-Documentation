---
title: プレゼンテーションスライド全体の背景を画像として取得する
type: docs
weight: 95
url: /ja/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 画像に背景を
- PowerPoint
- PPT
- PPTX
- PowerPoint プレゼンテーション
- Java
- Php
- Aspose.Slides for PHP via Java
---

PowerPoint プレゼンテーションでは、スライドの背景は多くの要素で構成されている可能性があります。[スライド背景](/slides/ja/php-java/presentation-background/)として設定された画像に加え、最終的な背景はプレゼンテーションテーマ、カラースキーム、マスタースライドおよびレイアウトスライドに配置されたシェイプによって影響を受ける可能性があります。

Aspose.Slides for PHP via Java では、プレゼンテーションスライド全体の背景を画像として抽出するための簡単な方法は提供されていませんが、以下の手順に従ってこれを行うことができます:
1. [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込む。
1. プレゼンテーションからスライドサイズを取得する。
1. スライドを選択する。
1. 一時的なプレゼンテーションを作成する。
1. 一時的なプレゼンテーションに同じスライドサイズを設定する。
1. 選択したスライドを一時的なプレゼンテーションにクローンする。
1. クローンされたスライドからシェイプを削除する。
1. クローンされたスライドを画像に変換する。

以下のコード例は、プレゼンテーションスライド全体の背景を画像として抽出します。
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```