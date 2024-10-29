---
title: フォールバックフォントを使用したプレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/java/render-presentation-with-fallback-font/
---

以下の例では、これらの手順が含まれています：

1. [フォールバックフォントルールのコレクションを作成します](/slides/ja/java/create-fallback-fonts-collection/)。
1. [フォールバックフォントルールを削除し](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)、別のルールに[フォールバックフォントを追加します](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)。
1. ルールのコレクションを[getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--)。[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)メソッドに設定します。
1. [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用して、同じフォーマットでプレゼンテーションを保存するか、別のフォーマットで保存できます。フォールバックフォントルールのコレクションを[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)に設定すると、これらのルールはプレゼンテーションに対するすべての操作（保存、レンダリング、変換など）で適用されます。

```java
// ルールコレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// いくつかのルールを作成
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 読み込まれたルールからフォールバックフォント「Tahoma」を削除しようとしています
    fallBackRule.remove("Tahoma");

    // 指定された範囲のルールを更新します
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// リストから既存のルールを削除することもできます
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // 使用するために準備されたルールリストを割り当て
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 初期化されたルールコレクションを使用してサムネイルをレンダリングしJPEGに保存
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // JPEG形式でディスクに画像を保存
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
[プレゼンテーションの保存と変換についてもっと読む](/slides/ja/java/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}