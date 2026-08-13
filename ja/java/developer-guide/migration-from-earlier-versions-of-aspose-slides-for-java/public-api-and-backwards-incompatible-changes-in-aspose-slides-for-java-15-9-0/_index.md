---
title: Aspose.Slides for Java 15.9.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 
このページでは、Aspose.Slides for Java 15.8.0 APIで導入された、[追加された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) または [削除された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) クラス、メソッド、プロパティ等、およびその他の変更を一覧表示します。
{{% /alert %}} 
## **パブリック API の変更**
#### **renderToGraphics メソッドが com.aspose.slides.ISlide、Slide に追加されました**
以下のメソッドが追加されました：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
これらは com.aspose.slides.ISlide インターフェイスと com.aspose.slides.Slide クラスに追加されました。これらのメソッドは、スライドを指定された Graphics2D オブジェクトに描画することを可能にします。

`renderToGraphics` メソッドはその後パブリック API から削除されました。現在のバージョンでは、以下の例のように [ISlide.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) を使用してスライドを描画します：

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```