---
title: フォントの置き換え - PowerPoint Java API
linktitle: フォントの置き換え
type: docs
weight: 60
url: /androidjava/font-replacement/
description: Java APIを使用してPowerPointで明示的な置き換え方法を使用してフォントを置き換える方法を学びます。
---

フォントの使用について考え直した場合、古いフォントを別のフォントに置き換えることができます。古いフォントのすべてのインスタンスは新しいフォントに置き換えられます。 

Aspose.Slidesでは、この方法でフォントを置き換えることができます。

1. 関連するプレゼンテーションを読み込む。 
2. 置き換えられるフォントを読み込む。
3. 新しいフォントを読み込む。 
4. フォントを置き換える。 
5. 修正されたプレゼンテーションをPPTXファイルとして書き出す。

このJavaコードはフォントの置き換えを示しています：

```java
// プレゼンテーションを読み込む
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 置き換えられるソースフォントを読み込む
    IFontData sourceFont = new FontData("Arial");
    
    // 新しいフォントを読み込む
    IFontData destFont = new FontData("Times New Roman");
    
    // フォントを置き換える
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // プレゼンテーションを保存する
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

特定の条件で何が起こるかを決定するルールを設定する方法（例えば、フォントにアクセスできない場合など）については、[**フォントの代替**](/slides/androidjava/font-substitution/)を参照してください。

{{% /alert %}}