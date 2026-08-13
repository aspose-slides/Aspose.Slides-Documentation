---
title: Configurer des collections de polices de secours sur Android
linktitle: Collection de polices de secours
type: docs
weight: 20
url: /fr/androidjava/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- installer la police
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Configurer une collection de polices de secours dans Aspose.Slides pour Android via Java afin de garder le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---
## **Vue d’ensemble**

Aspose.Slides vous permet de configurer une collection de règles de police de secours pour une présentation. Chaque règle de secours est représentée par la classe `FontFallBackRule` et peut être ajoutée à une `FontFallBackRulesCollection`, qui implémente l'interface `IFontFallBackRulesCollection`.

Après avoir créé la collection, vous pouvez l'assigner à la propriété `FontFallBackRulesCollection` du `FontsManager` de la présentation. Le `FontsManager` contrôle les polices à travers la présentation, et chaque instance de `Presentation` possède son propre `FontsManager`.

Une fois le `FontsManager` initialisé avec la collection de polices de secours, les polices de secours spécifiées sont appliquées lors du rendu de la présentation.

## **Appliquer les règles de secours**

Des instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontFallBackRule) peuvent être organisées dans une [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontFallBackRulesCollection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la méthode [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontFallBackRulesCollection) de la classe [FontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontsManager). Le FontsManager contrôle les polices à travers la présentation.

Chaque [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) possède une méthode [getFontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getFontsManager--) avec sa propre instance de la classe [FontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontsManager).

Voici un exemple de création d'une collection de règles de polices de secours et de son affectation au [FontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getFontsManager--) d'une présentation donnée :

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

Après que le FontsManager soit initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="info" %}} 
En savoir plus sur la façon de [Rendre une présentation avec une police de secours](/slides/fr/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Mes règles de secours seront‑elles intégrées dans le fichier PPTX et visibles dans PowerPoint après l’enregistrement ?

Non. Les règles de secours sont des paramètres de rendu à l’exécution ; elles ne sont pas sérialisées dans le PPTX et n’apparaîtront pas dans l’interface de PowerPoint.

### Le secours s’applique‑t‑il au texte à l’intérieur de SmartArt, WordArt, des graphiques et des tableaux ?

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

### Aspose distribue‑t‑il des polices avec la bibliothèque ?

Non. Vous ajoutez et utilisez les polices de votre côté et sous votre propre responsabilité.

### Le remplacement/substitution des polices manquantes et le secours pour les glyphes manquants peuvent‑ils être utilisés ensemble ?

Oui. Ils sont des étapes indépendantes du même pipeline de résolution des polices : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/androidjava/font-replacement/)/[substitution](/slides/fr/androidjava/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.