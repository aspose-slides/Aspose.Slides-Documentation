---
title: Rendre la présentation avec une police de secours
type: docs
weight: 30
url: /fr/androidjava/render-presentation-with-fallback-font/
---

L'exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de police de secours](/slides/fr/androidjava/create-fallback-fonts-collection/).
1. [Supprimez](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) une règle de police de secours et [ajoutez des polices de secours](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) à une autre règle.
1. Définissez la collection de règles pour [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) méthode.
1. Avec la méthode [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) nous pouvons enregistrer la présentation dans le même format ou l'enregistrer dans un autre format. Après que la collection de règles de police de secours est définie sur [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager), ces règles sont appliquées lors de toutes les opérations sur la présentation : enregistrer, rendre, convertir, etc.

```java
// Créer une nouvelle instance d'une collection de règles
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// créer un certain nombre de règles
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Essayer de supprimer la police de secours "Tahoma" des règles chargées
    fallBackRule.remove("Tahoma");

    //Et de mettre à jour les règles pour la plage spécifiée
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Nous pouvons également supprimer toutes les règles existantes de la liste
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //Attribution d'une liste de règles préparées pour utilisation
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendu de la miniature en utilisant la collection de règles initialisées et sauvegarde en JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Enregistrer l'image sur le disque au format JPEG
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
En savoir plus sur [Sauvegarde et Conversion dans la Présentation](/slides/fr/androidjava/creating-saving-and-converting-a-presentation/).
{{% /alert %}}