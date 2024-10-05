---
title: フォールバックフォントコレクションの作成
type: docs
weight: 20
url: /androidjava/create-fallback-fonts-collection/
---

[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule)クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection)に整理できます。これは、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection)インターフェースを実装しています。コレクションからルールを追加または削除することが可能です。

その後、このコレクションは、[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)クラスの[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection)メソッドに割り当てることができます。FontsManagerはプレゼンテーション全体のフォントを制御します。[FontsManagerとFontsLoaderについて詳しく読む](/slides/androidjava/about-fontsmanager-and-fontsloader/)。

各[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)には、独自の[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)クラスのインスタンスを持つ[getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--)メソッドがあります。

次に、フォールバックフォントルールのコレクションを作成し、特定のプレゼンテーションの[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--)に割り当てる例を示します。  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

FontsManagerがフォールバックフォントコレクションで初期化された後、フォールバックフォントはプレゼンテーションのレンダリング中に適用されます。

{{% alert color="primary" %}} 
フォールバックフォントでプレゼンテーションを[レンダリングする方法](/slides/androidjava/render-presentation-with-fallback-font/)について詳しく読む。
{{% /alert %}}