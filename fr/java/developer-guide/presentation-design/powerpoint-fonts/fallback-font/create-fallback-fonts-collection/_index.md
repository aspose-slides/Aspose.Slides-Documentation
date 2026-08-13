---
title: Configurer les collections de polices de secours en Java
linktitle: Collection de polices de secours
type: docs
weight: 20
url: /fr/java/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- installer la police
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Configurez une collection de polices de secours dans Aspose.Slides pour Java afin de maintenir le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de configurer une collection de règles de police de secours pour une présentation. Chaque règle de secours est représentée par la classe `FontFallBackRule` et peut être ajoutée à une `FontFallBackRulesCollection`, qui implémente l’interface `IFontFallBackRulesCollection`.

Après avoir créé la collection, vous pouvez l’assigner à la propriété `FontFallBackRulesCollection` du `FontsManager` de la présentation. Le `FontsManager` contrôle les polices dans l’ensemble de la présentation, et chaque instance de `Presentation` possède son propre `FontsManager`.

Une fois le `FontsManager` initialisé avec la collection de polices de secours, les polices de secours spécifiées sont appliquées lors du rendu de la présentation.

## **Appliquer les règles de secours**

Des instances de [FontFallBackRule](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRule) peuvent être organisées dans une [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRulesCollection), qui implémente l’interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IFontFallBackRulesCollection). Il est possible d’ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la méthode [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRulesCollection) de la classe [FontsManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontsManager). FontsManager contrôle les polices dans l’ensemble de la présentation.

Chaque [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) possède une méthode [getFontsManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getFontsManager--) avec sa propre instance de la classe [FontsManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontsManager).

Voici un exemple de création d’une collection de règles de polices de secours et de son assignation au [FontsManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getFontsManager--) d’une présentation donnée :

```java
import com.aspose.slides.*;

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

Après que le FontsManager a été initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="info" %}} 
En savoir plus sur la façon de [Rendre une présentation avec une police de secours](/slides/fr/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Mes règles de secours seront-elles intégrées au fichier PPTX et visibles dans PowerPoint après l’enregistrement ?

Non. Les règles de secours sont des paramètres de rendu à l’exécution ; elles ne sont pas sérialisées dans le PPTX et n’apparaîtront pas dans l’interface de PowerPoint.

### Le secours s’applique-t-il au texte contenu dans SmartArt, WordArt, les graphiques et les tableaux ?

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte présent dans ces objets.

### Aspose distribue-t‑il des polices avec la bibliothèque ?

Non. Vous ajoutez et utilisez les polices de votre côté, sous votre propre responsabilité.

### La substitution/remplacement des polices manquantes et le secours pour les glyphes manquants peuvent-ils être utilisés simultanément ?

Oui. Ce sont des étapes indépendantes du même pipeline de résolution de polices : d’abord le moteur résout la disponibilité des polices ([remplacement](/slides/fr/java/font-replacement/)/[substitution](/slides/fr/java/font-substitution/)), puis le secours comble les lacunes pour les glyphes manquants dans les polices disponibles.