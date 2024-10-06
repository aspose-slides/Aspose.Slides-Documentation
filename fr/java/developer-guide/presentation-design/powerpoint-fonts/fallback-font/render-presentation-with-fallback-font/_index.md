---
title: Rendre une présentation avec une police de remplacement
type: docs
weight: 30
url: /java/render-presentation-with-fallback-font/
---

L'exemple suivant inclut ces étapes :

1. Nous [créons une collection de règles de police de remplacement](/slides/java/create-fallback-fonts-collection/).
1. [Supprimer](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) une règle de police de remplacement et [ajouter des polices de remplacement](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) à une autre règle.
1. Définir la collection de règles sur [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) méthode.
1. Avec [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) méthode, nous pouvons enregistrer la présentation dans le même format ou l'enregistrer dans un autre. Après que la collection de règles de police de remplacement est définie sur [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), ces règles sont appliquées lors de toute opération sur la présentation : sauvegarde, rendu, conversion, etc.

```java
// Créer une nouvelle instance d'une collection de règles
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// créer un certain nombre de règles
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Essayer de supprimer la police de remplacement "Tahoma" des règles chargées
    fallBackRule.remove("Tahoma");

    // Et mettre à jour les règles pour la plage spécifiée
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Nous pouvons également supprimer toutes les règles existantes de la liste
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Attribution d'une liste de règles préparée à utiliser
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendu de la vignette en utilisant la collection de règles initialisée et sauvegarde en JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Sauvegarder l'image sur le disque au format JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Lisez-en plus sur [Sauvegarde et conversion dans Presentation](/slides/java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}