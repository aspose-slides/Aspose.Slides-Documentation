---
title: Gérer les polices de thème spécifiques aux scripts en Java
linktitle: Polices de thème spécifiques aux scripts
type: docs
weight: 15
url: /fr/java/script-specific-font-mappings/
keywords:
- police spécifique au script
- mappage de police de thème
- présentation multilingue
- système d'écriture
- police cyrillique
- police arabe
- police japonaise
- police géorgienne
- police thaana
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Inspectez, ajoutez, remplacez et supprimez les mappages de polices spécifiques aux scripts dans les thèmes PowerPoint avec Aspose.Slides pour Java."
---
## **Vue d’ensemble**

Un thème de présentation peut sélectionner différentes familles de polices pour différents systèmes d’écriture. Cela permet à du texte multilingue qui utilise encore les polices du thème de suivre un schéma de polices cohérent tout en employant des polices appropriées pour le cyrillique, l’arabe, le japonais, le géorgien, le thaana et d’autres scripts.

Le [IFontScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontscheme/) du thème contient une collection de polices majeures, généralement utilisée pour les titres, et une collection de polices mineures, généralement utilisée pour le corps du texte. En plus de leurs paramètres de polices latines et d’Asie de l’Est, les deux collections exposent des mappages des balises de système d’écriture vers les noms de familles de polices via l’interface [IFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifonts/).

Cet article montre comment inspecter et modifier ces mappages dans le thème maître de la présentation et vérifier que les modifications survivent à un cycle d’enregistrement et de rechargement.

## **Comprendre les balises de script**

Les méthodes de police de script utilisent des sous‑balises de script BCP 47 à quatre lettres pour identifier les systèmes d’écriture. Les valeurs courantes incluent :

| Balise de script | Système d’écriture |
|---|---|
| `Cyrl` | Cyrillique |
| `Arab` | Arabe |
| `Hans` | Chinois simplifié |
| `Jpan` | Japonais |
| `Geor` | Géorgien |
| `Thaa` | Thaana |

Ces mappages appartiennent au schéma de police du thème, pas à des portions de texte individuelles. Une présentation peut définir des mappages différents pour les collections majeures et mineures, et peut omettre des mappages pour certains scripts.

## **Accéder et inspecter les mappages de police de script**

Utilisez [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getMasterTheme--) pour accéder au thème au niveau de la présentation. Les méthodes [IFontScheme.getMajor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontscheme/#getMajor--) et [IFontScheme.getMinor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontscheme/#getMinor--) renvoient les deux collections [IFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifonts/).

Appelez [IFonts.getScriptFontMap](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fonts/#getScriptFontMap--) pour récupérer tous les mappages d’une collection. Pour rechercher un système d’écriture, appelez [IFonts.getScriptFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) avec sa balise de script. `getScriptFont` renvoie `null` lorsque cette collection ne définit pas le mappage demandé.

## **Modifier les mappages et vérifier la persistance**

Utilisez [IFonts.setScriptFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) pour créer un mappage ou remplacer la famille de polices actuelle. Utilisez [IFonts.removeScriptFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) pour supprimer un mappage.

L’exemple de bout en bout suivant lit tous les mappages majeurs et mineurs existants, recherche la police majeure japonaise, change la police majeure cyrillique, supprime le mappage mineur thaana, enregistre la présentation et la rouvre pour vérifier les deux changements. Pour que l’étape de suppression soit indépendante du thème initial, l’exemple crée d’abord un mappage Thaana uniquement lorsqu’aucun n’est déjà défini.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

La vérification utilise le même comportement `null` qu’une recherche ordinaire : après que la suppression soit enregistrée, `getScriptFont("Thaa")` renvoie `null` pour la collection mineure.

## **Faire la distinction entre les mappages du thème et les autres réglages de police**

Les mappages de thème spécifiques au script participent à la sélection de la police, mais ils résolvent un problème différent de la mise en forme directe du texte, de la substitution et du recours à une police de secours :

| Mécanisme | Objectif | Effet du changement d’un mappage de thème |
|---|---|---|
| Mappage de police de thème spécifique au script | Sélectionne une police de thème majeure ou mineure pour un système d’écriture. | Le texte qui utilise toujours la police de thème correspondante peut être résolu vers la nouvelle famille mappée. |
| Police attribuée explicitement à une portion de texte | Fixe la famille de police demandée sur cette portion au lieu de dépendre du thème. | La portion peut rester inchangée car son formatage direct l’emporte sur le choix du thème. |
| Substitution de police | Remplace une police demandée lorsqu’elle n’est pas disponible ou lorsqu’une règle de substitution s’applique. | Elle intervient après qu’une police a été demandée ; elle ne redéfinit pas le mappage du script du thème. |
| Police de secours | Fournit des glyphes que la police sélectionnée ne contient pas, souvent pour des plages Unicode spécifiques. | Elle comble les lacunes de couverture des glyphes ; elle ne modifie pas le mappage de thème stocké. |

Pour plus d’informations sur les deux derniers mécanismes, voir [Font Substitution](/slides/fr/java/font-substitution/) et [Fallback Fonts](/slides/fr/java/fallback-font/).

Modifier un mappage dans [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getMasterTheme--) n’affecte que le contenu dont le formatage effectif dépend encore de ce thème. Le texte peut, à la place, hériter d’une surcharge de thème provenant d’un maître, d’une disposition ou d’une diapositive, ou utiliser une police attribuée explicitement. Inspectez ces niveaux lorsque le résultat visible ne suit pas le mappage au niveau de la présentation.

## **Rendre les polices mappées disponibles et valider le résultat**

Un mappage de script stocke un nom de famille de police ; il n’installe pas et ne charge pas le fichier de police correspondant. Pour un rendu et une exportation cohérents, chaque police mappée doit être installée dans l’environnement ou fournie à Aspose.Slides via une source personnalisée telle que [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ou [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Voir [Custom Fonts](/slides/fr/java/custom-font/) pour les options de chargement disponibles.

Vérifier le mappage sauvegardé confirme uniquement que la définition du thème a été préservée. Cela ne prouve pas que la police est disponible, qu’elle contient tous les glyphes requis ou qu’elle produit la mise en page prévue. Rendu du texte représentatif pour chaque système d’écriture requis vers une image ou un PDF et inspectez le résultat. Cela permet de détecter les polices manquantes, la couverture incomplète des glyphes, le comportement de secours et les changements de mise en page avant la distribution de la présentation. Voir [Convert PowerPoint Presentations](/slides/fr/java/convert-powerpoint/) pour des exemples de rendu et d’exportation.

## **FAQ**

**Que renvoie `getScriptFont` lorsqu’un script n’est pas mappé ?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) renvoie `null` lorsque le mappage de script demandé n’est pas défini dans cette collection de polices majeures ou mineures.

**`setScriptFont` ajoute‑t‑il un deuxième mappage lorsque le script existe déjà ?**

Non. [IFonts.setScriptFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) crée le mappage lorsqu’il manque et remplace la famille de police mappée lorsque la même balise de script est déjà présente.

**Pourquoi le changement d’un mappage de thème n’a‑t‑il pas modifié certains textes ?**

Le texte peut avoir une police attribuée explicitement, hériter d’un thème différent via une surcharge, ou être affecté par la substitution ou le recours à une police de secours lors du rendu. Un mappage de script au niveau de la présentation ne contrôle que le texte dont le formatage effectif fait encore référence à cette collection de polices du thème.

**L’enregistrement et la réouverture suffisent‑ils à valider la sortie multilingue ?**

Non. La réouverture vérifie la persistance des données du thème. Il faut également rendre le texte représentatif de chaque système d’écriture requis afin de confirmer que les polices mappées sont disponibles et contiennent les glyphes nécessaires.