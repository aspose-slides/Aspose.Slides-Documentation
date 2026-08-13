---
title: Android でフォールバックフォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/androidjava/render-presentation-with-fallback-font/
keywords:
- フォールバックフォント
- PowerPoint のレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Androidでフォールバックフォントを使用してプレゼンテーションをレンダリングし、PPT、PPTX、ODP間でテキストの一貫性を保つステップバイステップの Java コードサンプル。"
---
## **概要**

Aspose.Slides ではフォールバックフォント ルールを使用してプレゼンテーションをレンダリングできます。本記事では、フォールバックフォント ルール コレクションの作成方法、フォールバックフォントを削除または追加してルールを変更する方法、および `FontsManager.setFontFallBackRulesCollection` メソッドを使用してコレクションを割り当てる方法を示します。

フォールバックフォント ルール コレクションをプレゼンテーションの `FontsManager` に割り当てると、保存、レンダリング、変換などの操作中にルールが適用されます。この例では、スライド サムネイルをレンダリングし JPEG 画像として保存する際に設定したルールを使用する方法を示しています。

## **フォールバックフォント ルールを使用してスライドをレンダリングする**

以下の例では次の手順を含みます。

1. フォールバックフォント ルール コレクションを[作成](/slides/ja/androidjava/create-fallback-fonts-collection/)します。
2. [削除](/reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) でフォールバックフォント ルールを削除し、別のルールに[addFallBackFonts](/reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) を追加します。
3. ルール コレクションを[getFontsManager](/reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](/reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) メソッドに設定します。
4. [Presentation.save](/reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用してプレゼンテーションを同じ形式で保存するか、別の形式で保存できます。フォールバックフォント ルール コレクションが [FontsManager](/reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontsManager) に設定されると、保存、レンダリング、変換などプレゼンテーションに対するすべての操作でこれらのルールが適用されます。

```java
import com.aspose.slides.*;

// ルールコレクションの新しいインスタンスを作成する
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // ロードされたルールからフォールバックフォント "Tahoma" を削除しようとしています
    fallBackRule.remove("Tahoma");

    // 指定された範囲のルールを更新します
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// リストから既存のルールをすべて削除できますが、レンダリングに使用するために少なくとも1つのルールは残します
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // 使用するために準備したルールリストを割り当てる
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 初期化されたルールコレクションを使用してサムネイルをレンダリングし、JPEGで保存する
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 画像を JPEG 形式でディスクに保存する
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
[Android で PPT および PPTX を JPG に変換する](/slides/ja/androidjava/convert-powerpoint-to-jpg/) 方法の詳細をご覧ください。
{{% /alert %}}