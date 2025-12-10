---
title: Configurer des collections de polices de secours en Java
linktitle: Collection de polices de secours
type: docs
weight: 20
url: /fr/java/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- mettre en place la police
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Configurez une collection de polices de secours dans Aspose.Slides pour Java afin de maintenir le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---

## **Appliquer les règles de secours**

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) peuvent être organisées dans [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la méthode [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) de la classe [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager). FontsManager contrôle les polices dans toute la présentation. En savoir plus [À propos de FontsManager et FontsLoader](/slides/fr/java/about-fontsmanager-and-fontsloader/).

Chaque [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) possède une méthode [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) avec sa propre instance de la classe [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager).

Voici un exemple montrant comment créer une collection de règles de polices de secours et l'assigner au [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) d'une présentation donnée :
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


Après que FontsManager a été initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur la façon de [Rendre la présentation avec une police de secours](/slides/fr/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Mes règles de secours seront-elles intégrées dans le fichier PPTX et visibles dans PowerPoint après l'enregistrement ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et n'apparaîtront pas dans l'interface de PowerPoint.

**Le secours s'applique-t-il au texte à l'intérieur des SmartArt, WordArt, graphiques et tableaux ?**

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

**Aspose distribue-t-il des polices avec la bibliothèque ?**

Non. Vous ajoutez et utilisez les polices de votre côté et sous votre propre responsabilité.

**Le remplacement/substitution de polices manquantes et le secours pour les glyphes manquants peuvent-ils être utilisés conjointement ?**

Oui. Ce sont des étapes indépendantes du même pipeline de résolution des polices : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/java/font-replacement/)/[substitution](/slides/fr/java/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.