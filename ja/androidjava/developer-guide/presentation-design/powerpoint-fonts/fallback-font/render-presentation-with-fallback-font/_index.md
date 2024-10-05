---
title: フォールバックフォントを使用してプレゼンテーションをレンダリング
type: docs
weight: 30
url: /androidjava/render-presentation-with-fallback-font/
---

次の例は、以下の手順を含みます：

1. [フォールバックフォントルールコレクションを作成](/slides/androidjava/create-fallback-fonts-collection/)します。
1. フォールバックフォントルールを[削除](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)し、別のルールに[addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)を追加します。
1. ルールコレクションを[getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--)の[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)メソッドに設定します。
1. [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用して、同じ形式でプレゼンテーションを保存するか、別の形式で保存できます。フォールバックフォントルールコレクションが[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)に設定されると、これらのルールはプレゼンテーションに対するすべての操作（保存、レンダリング、変換など）の際に適用されます。

```java
// ルールコレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// ルールの数を作成
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 読み込まれたルールからフォールバックフォント「Tahoma」を削除しようとする
    fallBackRule.remove("Tahoma");

    // 指定された範囲のルールを更新する
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// リストから既存のルールを削除することもできます
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // 使用するために準備されたルールリストを割り当てる
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 初期化されたルールコレクションを使用してサムネイルをレンダリングし、JPEGに保存
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
[プレゼンテーションの保存と変換について](/slides/androidjava/creating-saving-and-converting-a-presentation/)もっと読む。
{{% /alert %}}