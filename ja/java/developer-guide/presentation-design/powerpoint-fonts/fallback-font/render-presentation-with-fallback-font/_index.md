---
title: Javaでフォールバックフォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/java/render-presentation-with-fallback-font/
keywords:
- フォールバックフォント
- PowerPoint をレンダリング
- プレゼンテーションをレンダリング
- スライドをレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でフォールバックフォントを使用してプレゼンテーションをレンダリングし、PPT、PPTX、ODP 間でテキストを一貫させるステップバイステップの Java コードサンプル。"
---

次の例では、これらの手順が含まれています:

1. [フォールバック フォント ルール コレクションを作成](/slides/ja/java/create-fallback-fonts-collection/)します。
1. [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) フォールバック フォント ルールを削除し、別のルールに[addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) を追加します。
1. ルール コレクションを[getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) メソッドに設定します。
1. [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、プレゼンテーションを同じ形式で保存したり、別の形式で保存したりできます。フォールバック フォント ルール コレクションが[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) に設定された後、これらのルールは保存、レンダリング、変換など、プレゼンテーションに対するすべての操作で適用されます。
```java
// ルールコレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 複数のルールを作成
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 読み込まれたルールからフォールバックフォント「Tahoma」を削除しようとしています
    fallBackRule.remove("Tahoma");

    // 指定された範囲のルールを更新します
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// リストから既存のルールをすべて削除することもできます
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // 使用するために準備したルールリストを割り当てます
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 初期化されたルールコレクションを使用してサムネイルをレンダリングし、JPEGで保存します
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 画像をJPEG形式でディスクに保存します
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
[Java で PPT と PPTX を JPG に変換](/slides/ja/java/convert-powerpoint-to-jpg/) の詳細をご覧ください。
{{% /alert %}}