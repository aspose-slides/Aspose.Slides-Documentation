---
title: Androidでフォールバック フォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/androidjava/render-presentation-with-fallback-font/
keywords:
- フォールバック フォント
- PowerPoint のレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でフォールバック フォントを使用してプレゼンテーションをレンダリングし、PPT、PPTX、ODP 間でテキストの一貫性を保つステップバイステップの Java コードサンプルを提供します。"
---

以下の例では、これらの手順が含まれています。

1. フォールバック フォント ルール コレクションを[作成](/slides/ja/androidjava/create-fallback-fonts-collection/)します。
1. [削除](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) フォールバック フォント ルール を削除し、[addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) を別のルールに追加します。
1. ルール コレクションを[getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) メソッドに設定します。
1. [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、プレゼンテーションを同じ形式で保存したり、別の形式で保存したりできます。フォールバック フォント ルール コレクションが[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)に設定されると、これらのルールはプレゼンテーションに対するすべての操作（保存、レンダリング、変換など）中に適用されます。
```java
// ルール コレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 複数のルールを作成
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 読み込んだルールからフォールバック フォント "Tahoma" を削除しようとしています
    fallBackRule.remove("Tahoma");

    // 指定された範囲のルールを更新します
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// また、リストから既存のルールをすべて削除できます
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // 使用するために準備されたルール リストを割り当て
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 初期化されたルール コレクションを使用してサムネイルをレンダリングし、JPEG に保存
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 画像を JPEG 形式でディスクに保存
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
Android で PPT と PPTX を JPG に変換する方法の詳細は、[Convert PPT and PPTX to JPG on Android](/slides/ja/androidjava/convert-powerpoint-to-jpg/)をご覧ください。
{{% /alert %}}