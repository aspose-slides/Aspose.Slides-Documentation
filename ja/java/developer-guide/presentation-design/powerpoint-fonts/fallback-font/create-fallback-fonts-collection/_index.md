---
title: フォールバックフォントコレクションの作成
type: docs
weight: 20
url: /ja/java/create-fallback-fonts-collection/
---

[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection)に整理でき、これは[IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection)インターフェースを実装します。コレクションからルールを追加または削除することが可能です。

次に、このコレクションは[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)クラスの[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection)メソッドに割り当てることができます。FontsManagerはプレゼンテーション全体のフォントを管理します。詳細は[FontsManagerとFontsLoaderについて](/slides/ja/java/about-fontsmanager-and-fontsloader/)をご覧ください。

各[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)には、それ自体の[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)クラスのインスタンスを持つ[getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--)メソッドがあります。

以下は、フォールバックフォントルールコレクションを作成し、特定のプレゼンテーションの[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--)に割り当てる方法の例です。

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
フォールバックフォントを使用して[プレゼンテーションをレンダリングする](/slides/ja/java/render-presentation-with-fallback-font/)方法についてさらにお読みください。
{{% /alert %}}