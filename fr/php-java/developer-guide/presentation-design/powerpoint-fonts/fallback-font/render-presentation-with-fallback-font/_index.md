---
title: Rendre une présentation avec une police de secours
type: docs
weight: 30
url: /php-java/render-presentation-with-fallback-font/
---

L'exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de police de secours](/slides/php-java/create-fallback-fonts-collection/).
1. [Supprimez](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) une règle de police de secours et [ajoutezFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) à une autre règle.
1. Définissez la collection de règles sur [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) méthode.
1. Avec la méthode [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) nous pouvons enregistrer la présentation dans le même format ou l'enregistrer dans un autre. Après que la collection de règles de police de secours soit définie sur [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), ces règles sont appliquées lors de toutes les opérations sur la présentation : sauvegarde, rendu, conversion, etc.

```php
  # Créer une nouvelle instance d'une collection de règles
  $rulesList = new FontFallBackRulesCollection();
  # créer un certain nombre de règles
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Essayer de supprimer la police de secours "Tahoma" des règles chargées
    $fallBackRule->remove("Tahoma");
    # Et pour mettre à jour les règles pour la plage spécifiée
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Nous pouvons également supprimer toutes les règles existantes de la liste
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Assigner une liste de règles préparée pour utilisation
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Rendu de la miniature en utilisant la collection de règles initialisée et sauvegarde au format JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Enregistrez l'image sur le disque au format JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Lisez-en plus sur [Sauvegarde et conversion dans une présentation](/slides/php-java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}