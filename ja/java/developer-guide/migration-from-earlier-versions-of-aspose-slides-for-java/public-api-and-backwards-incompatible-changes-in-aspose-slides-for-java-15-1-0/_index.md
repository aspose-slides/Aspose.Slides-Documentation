---
title: Aspose.Slides for Java 15.1.0 の公開 API と後方互換性のない変更
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
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
description: "Aspose.Slides for Java の公開 API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---
{{% alert color="info" %}} 

このページは Aspose.Slides for Java 15.1.0 API で導入された、すべての [追加された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) クラス、メソッド、プロパティなど、 新しい制限やその他の [変更](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) を一覧表示します。

{{% /alert %}} {{% alert color="info" %}} 

一部の画像バレットと WordArt オブジェクトに既知の問題があり、これらは Aspose.Slides for Java 15.2.0 で修正される予定です。

{{% /alert %}} 
## **公開 API の変更**
### **フォント置換機能が追加されました**
プレゼンテーション全体およびレンダリング時に一時的にフォントを置換する機能が追加されました。

Presentation クラスに新しく getFontsManager() メソッドが導入されました。FontsManager クラスには以下のメンバーがあります:

**IFontSubstRuleCollection getFontSubstRuleList**() メソッド

これはレンダリング中にフォントを置換するために使用される IFontSubstRule インスタンスのコレクションです。IFontSubstRule には IFontData インターフェイスを実装する getSourceFont() と getDestFont() メソッド、および置換条件（「WhenInaccessible」または「Always」）を選択できる getReplaceFontCondition() メソッドがあります。

**IFontData[] getFonts**() メソッドは、現在のプレゼンテーションで使用されているすべてのフォントを取得するために使用できます。

**replaceFont(...)** メソッドは、プレゼンテーション内のフォントを永続的に置換するために使用できます。

以下の例は、プレゼンテーション内のフォントを置換する方法を示しています:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

別の例として、アクセスできない場合にレンダリング用のフォント置換を示します:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Arial フォントは、SomeRareFont にアクセスできない場合に代わりに使用されます。
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```