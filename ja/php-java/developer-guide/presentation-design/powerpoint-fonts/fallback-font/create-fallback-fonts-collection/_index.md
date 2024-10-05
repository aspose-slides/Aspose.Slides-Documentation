---
title: フォールバックフォントコレクションの作成
type: docs
weight: 20
url: /php-java/create-fallback-fonts-collection/
---

[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) クラスのインスタンスは、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection) インターフェースを実装する [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) に整理できます。コレクションからルールを追加または削除することが可能です。

次に、このコレクションは、[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) クラスの [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) メソッドに割り当てることができます。FontsManagerはプレゼンテーション全体のフォントを管理します。詳細は [About FontsManager and FontsLoader](/slides/php-java/about-fontsmanager-and-fontsloader/) をお読みください。

各 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) には、独自の [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) インスタンスを持つ [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) メソッドがあります。

ここでは、フォールバックフォントルールコレクションを作成し、特定のプレゼンテーションの [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) に割り当てる例を示します：

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

FontsManagerがフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
フォールバックフォントを使用してプレゼンテーションを[レンダリングする方法](/slides/php-java/render-presentation-with-fallback-font/)についてさらにお読みください。
{{% /alert %}}