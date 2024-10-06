---
title: API Publique et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour PHP via Java 15.1.0
type: docs
weight: 100
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), toute nouvelle restriction et d'autres [changements](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introduits avec l'API Aspose.Slides pour PHP via Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Il existe des problèmes connus avec certains bullets d'image et objets WordArt qui seront corrigés dans Aspose.Slides pour PHP via Java 15.2.0.

{{% /alert %}} 
## **Changements de l’API Publique**
### **Fonctionnalité de substitution de polices ajoutée**
La possibilité de remplacer les polices globalement dans la présentation et temporairement pour le rendu a été ajoutée.

La nouvelle méthode getFontsManager() de la classe Presentation a été introduite. La classe FontsManager a les membres suivants :

**IFontSubstRuleCollection getFontSubstRuleList**() méthode

Ceci est la collection d'instances IFontSubstRule utilisées pour substituer des polices lors du rendu. IFontSubstRule a des méthodes getSourceFont() et getDestFont() implémentant l'interface IFontData et une méthode getReplaceFontCondition() permettant de choisir la condition de remplacement ("WhenInaccessible" ou "Always").

**IFontData[] getFonts()** méthode peut être utilisée pour récupérer toutes les polices utilisées dans la présentation actuelle.

**replaceFont(...)** méthodes peuvent être utilisées pour remplacer de manière persistante une police dans une présentation.

L'exemple suivant montre comment remplacer une police dans une présentation :

```php
  $pres = new Presentation("PresContainsArialFont.pptx");
  $sourceFont = new FontData("Arial");
  $destFont = new FontData("Times New Roman");
  $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
  $pres->save("PresContainsTimesNoewRomanFont.pptx", SaveFormat::Pptx);

```

Un autre exemple montre la substitution de police pour le rendu lorsqu'elle est inaccessible :

```php
  $pres = new Presentation("PresContainsSomeRareFontFont.pptx");
  $sourceFont = new FontData("SomeRareFont");
  $destFont = new FontData("Arial");
  $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
  $fontSubstRuleCollection = new FontSubstRuleCollection();
  $fontSubstRuleCollection->add($fontSubstRule);
  $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
  # La police Arial sera utilisée à la place de SomeRareFont lorsqu'elle est inaccessible
  $pres->getSlides()->get_Item(0)->getThumbnail(1, 1);

```