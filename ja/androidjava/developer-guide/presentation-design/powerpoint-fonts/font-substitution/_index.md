---
title: フォントの置き換え - PowerPoint Java API
linktitle: フォントの置き換え
type: docs
weight: 70
url: /androidjava/font-substitution/
keywords: "フォント, 代替フォント, PowerPointプレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaにおけるPowerPointのフォント置き換え"
---

Aspose.Slidesを使用すると、特定の条件（たとえば、フォントにアクセスできない場合）で何をするかを決定するフォントに対するルールを設定できます。手順は以下の通りです：

1. 関連するプレゼンテーションをロードします。
2. 置き換えられるフォントをロードします。
3. 新しいフォントをロードします。
4. 置き換えのためのルールを追加します。
5. ルールをプレゼンテーションのフォント置き換えルールコレクションに追加します。
6. 効果を確認するためにスライド画像を生成します。

以下のJavaコードは、フォント置き換えプロセスを示しています：

```java
// プレゼンテーションをロードする
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 置き換えられるソースフォントをロードする
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 新しいフォントをロードする
    IFontData destFont = new FontData("Arial");
    
    // フォント置き換えのためのフォントルールを追加する
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // フォント代替ルールコレクションにルールを追加する
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // ルールリストにフォントルールコレクションを追加する
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // ArialフォントはSomeRareFontがアクセスできない場合に使用されます
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // JPEG形式で画像をディスクに保存する
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="注意"  color="warning"   %}} 

[**フォント置き換え**](/slides/androidjava/font-replacement/)を参照することをお勧めします。

{{% /alert %}}