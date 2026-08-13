---
title: Java でフォールバック フォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/java/render-presentation-with-fallback-font/
keywords:
- フォールバック フォント
- PowerPoint のレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でフォールバック フォントを使用してプレゼンテーションをレンダリングします – PPT、PPTX、ODP 間でテキストを一貫させるためのステップバイステップの Java コードサンプルを提供します。"
---
## **概要**

Aspose.Slides はフォールバック フォント ルールを使用してプレゼンテーションをレンダリングできます。この記事では、フォールバック フォント ルール コレクションの作成方法、フォントを削除または追加してルールを変更する方法、および `FontsManager.setFontFallBackRulesCollection` メソッドを使用してコレクションを割り当てる方法を示します。

フォールバック フォント ルール コレクションがプレゼンテーションの `FontsManager` に割り当てられると、保存、レンダリング、変換などの操作中にルールが適用されます。例では、スライドのサムネイルをレンダリングし、JPEG 画像として保存する際に設定されたルールを使用する方法を示しています。

## **フォールバック フォント ルールを使用したスライドのレンダリング**

1. [フォールバック フォント ルール コレクションを作成](/slides/ja/java/create-fallback-fonts-collection/)。
1. [削除](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) フォールバック フォント ルールを削除し、別のルールに [addFallBackFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) を追加します。
1. 規則コレクションを [getFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) メソッドに設定します。
1. [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、プレゼンテーションを同じ形式で保存するか、別の形式で保存できます。フォールバック フォント ルール コレクションが [FontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsManager) に設定されると、保存、レンダリング、変換など、プレゼンテーションに対するあらゆる操作でこれらのルールが適用されます。

```java
import com.aspose.slides.*;

// ルール コレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 複数のルールを作成
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 読み込まれたルールからフォールバック フォント "Tahoma" を削除しようとしています
    fallBackRule.remove("Tahoma");

    // 指定された範囲のルールを更新します
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// 既存のルールをすべて削除できますが、レンダリング用に少なくとも1つのルールは残します
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // 使用するために準備したルールリストを割り当てます
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 初期化されたルールコレクションを使用してサムネイルをレンダリングし、JPEG で保存します
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 画像を JPEG 形式でディスクに保存します
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Java で PPT と PPTX を JPG に変換する方法の詳細は、[Java で PPT と PPTX を JPG に変換](/slides/ja/java/convert-powerpoint-to-jpg/) をご覧ください。
{{% /alert %}}