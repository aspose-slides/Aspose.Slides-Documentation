---
title: Créer une Collection de Polices de Repli
type: docs
weight: 20
url: /androidjava/create-fallback-fonts-collection/
---

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) peuvent être organisées en [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être affectée à la méthode [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) de la classe [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager). FontsManager contrôle les polices dans la présentation. Pour en savoir plus, consultez [À propos de FontsManager et FontsLoader](/slides/androidjava/about-fontsmanager-and-fontsloader/).

Chaque [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) a une méthode [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) avec sa propre instance de la classe [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

Voici un exemple de création d'une collection de règles de polices de repli et de l'affectation dans le [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) d'une certaine présentation :  

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

Après que le FontsManager soit initialisé avec la collection de polices de repli, les polices de repli sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
Pour en savoir plus sur [le rendu de la présentation avec une police de repli](/slides/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}