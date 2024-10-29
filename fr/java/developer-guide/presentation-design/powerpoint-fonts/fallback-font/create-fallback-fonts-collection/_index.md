---
title: Créer une Collection de Polices de Secours
type: docs
weight: 20
url: /fr/java/create-fallback-fonts-collection/
---

Les instances de la [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) peuvent être organisées dans une [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la méthode [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) de la classe [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager). FontsManager contrôle les polices à travers la présentation. Lire la suite [À propos de FontsManager et FontsLoader](/slides/fr/java/about-fontsmanager-and-fontsloader/).

Chaque [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) a une méthode [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) avec sa propre instance de la classe [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager).

Voici un exemple de création d'une collection de règles de polices de secours et de son affectation dans le [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) d'une certaine présentation :  

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

Une fois que le FontsManager est initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
Lire la suite sur [Rendre une Présentation avec une Police de Secours](/slides/fr/java/render-presentation-with-fallback-font/).
{{% /alert %}}