---
title: Aspose.Slides for Java 15.11.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
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
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行しましょう。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for Java 15.11.0 APIで導入された、追加または削除されたクラス、メソッド、プロパティ等およびその他の変更を一覧表示します。  
[added](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) または [removed](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) のクラス、メソッド、プロパティなどが含まれます。

{{% /alert %}} 
## **パブリック API の変更**
#### **com.aspose.slides.DataLabelCollection クラスの廃止予定メソッドが削除されました**
com.aspose.slides.DataLabelCollection クラスの廃止予定メソッドが削除されました:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **Presentation クラスに新しいメソッド getFirstSlideNumber() と setFirstSlideNumber() が追加されました**
新しいメソッド getFirstSlideNumber() と setFirstSlideNumber() は、プレゼンテーションの最初のスライド番号を取得または設定できるようにします。  
新しい最初のスライド番号が指定されると、すべてのスライド番号が再計算されます。

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```