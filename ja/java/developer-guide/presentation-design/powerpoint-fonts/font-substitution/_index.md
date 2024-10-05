---
title: フォントの置き換え - PowerPoint Java API
linktitle: フォントの置き換え
type: docs
weight: 70
url: /java/font-substitution/
keywords: "フォント, 代替フォント, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointのフォントを置き換える"
---

Aspose.Slidesでは、特定の条件下（例えば、フォントにアクセスできない場合）で何をすべきかを決定するフォントのルールを設定できます。手順は以下の通りです：

1. 関連するプレゼンテーションをロードします。
2. 置き換えられるフォントをロードします。
3. 新しいフォントをロードします。
4. 置き換えのルールを追加します。
5. ルールをプレゼンテーションのフォント置き換えルールコレクションに追加します。
6. スライドの画像を生成して効果を確認します。

このJavaコードはフォントの置き換えプロセスを示しています：

```java
// プレゼンテーションをロードする
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 置き換えられるソースフォントをロードする
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 新しいフォントをロードする
    IFontData destFont = new FontData("Arial");
    
    // フォント置き換えのためのルールを追加する
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // ルールをフォント代替ルールのコレクションに追加する
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // ルールリストにフォントルールコレクションを追加する
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // SomeRareFontがアクセスできない場合、Arialフォントが使用される
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // 画像をJPEG形式でディスクに保存する
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

[**フォント置き換え**](/slides/java/font-replacement/)をチェックしたいかもしれません。 

{{% /alert %}}