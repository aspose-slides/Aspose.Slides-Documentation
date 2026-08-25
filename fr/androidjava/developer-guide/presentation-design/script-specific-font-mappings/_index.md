---
title: Gérer les polices de thème spécifiques aux scripts sur Android
linktitle: Polices de thème spécifiques aux scripts
type: docs
weight: 15
url: /fr/androidjava/script-specific-font-mappings/
keywords:
- police spécifique au script
- correspondance de police de thème
- présentation multilingue
- système d'écriture
- police cyrillique
- police arabe
- police japonaise
- police géorgienne
- police thaana
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Inspectez, ajoutez, remplacez et supprimez les correspondances de polices spécifiques aux scripts dans les thèmes PowerPoint avec Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Un thème de présentation peut sélectionner différentes familles de polices pour différents systèmes d'écriture. Cela permet à un texte multilingue qui utilise toujours les polices du thème de suivre un schéma de polices coordonné tout en utilisant des polices adaptées pour le cyrillique, l’arabe, le japonais, le géorgien, le thaana et d’autres scripts.

Le [IFontScheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontscheme/) du thème contient une collection de polices majeures, généralement utilisée pour les titres, et une collection de polices mineures, généralement utilisée pour le corps du texte. En plus de leurs paramètres de polices latines et d’Asie orientale, les deux collections exposent des correspondances entre les balises de système d’écriture et les noms de familles de polices via l’interface [IFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifonts/).

Cet article montre comment inspecter et modifier ces correspondances dans le thème maître de la présentation et vérifier que les modifications survivent à un cycle d’enregistrement‑et‑rechargement.

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

Ces correspondances appartiennent au schéma de polices du thème, pas aux portions de texte individuelles. Une présentation peut définir des correspondances différentes pour les collections majeures et mineures, et elle peut omettre des correspondances pour certains scripts.

## **Accéder et inspecter les correspondances de police de script**

Utilisez [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getMasterTheme--) pour accéder au thème au niveau de la présentation. Les méthodes [IFontScheme.getMajor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontscheme/#getMajor--) et [IFontScheme.getMinor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontscheme/#getMinor--) renvoient les deux collections [IFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifonts/).

Appelez [IFonts.getScriptFontMap](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) pour récupérer toutes les correspondances d’une collection. Pour rechercher un système d’écriture, appelez [IFonts.getScriptFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) avec sa balise de script. `getScriptFont` renvoie `null` lorsque cette collection ne définit pas la correspondance demandée.

## **Modifier les correspondances et vérifier la persistance**

Utilisez [IFonts.setScriptFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) pour créer une correspondance ou remplacer la famille de polices actuelle. Utilisez [IFonts.removeScriptFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) pour supprimer une correspondance.

L’exemple de bout en bout suivant lit toutes les correspondances majeures et mineures existantes, recherche la police majeure japonaise, change la police majeure cyrillique, supprime la correspondance mineure Thaana, enregistre la présentation et la rouvre pour vérifier les deux modifications. Pour rendre l’étape de suppression indépendante du thème initial, l’exemple crée d’abord une correspondance Thaana uniquement lorsqu’elle n’est pas déjà définie.

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

La vérification utilise le même comportement `null` qu’une recherche ordinaire : après que la suppression a été enregistrée, `getScriptFont("Thaa")` renvoie `null` pour la collection mineure.

## **Faire la distinction entre les correspondances du thème et les autres réglages de police**

Les correspondances de thème spécifiques à un script participent à la sélection de la police, mais elles résolvent un problème différent de la mise en forme directe du texte, de la substitution et du repli :

| Mécanisme | Objectif | Effet du changement d’une correspondance du thème |
|---|---|---|
| Correspondance de police de thème spécifique à un script | Sélectionne une police majeure ou mineure du thème pour un système d’écriture. | Le texte qui utilise encore la police du thème correspondante peut se résoudre à la nouvelle famille mappée. |
| Police assignée explicitement à une portion de texte | Fixe la famille de police demandée sur cette portion au lieu de dépendre du thème. | La portion peut rester inchangée parce que son formatage direct écrase le choix du thème. |
| Substitution de police | Remplace une police demandée lorsqu’elle n’est pas disponible ou lorsqu’une règle de substitution s’applique. | Elle agit après qu’une police a été demandée ; elle ne redéfinit pas la correspondance du script du thème. |
| Repli de police | Fournit les glyphes que la police sélectionnée ne contient pas, souvent pour des plages Unicode spécifiques. | Elle comble les lacunes de couverture de glyphes ; elle ne modifie pas la correspondance du thème stockée. |

Pour plus d’informations sur les deux derniers mécanismes, consultez [Font Substitution](/slides/fr/androidjava/font-substitution/) et [Fallback Fonts](/slides/fr/androidjava/fallback-font/).

Modifier une correspondance dans [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getMasterTheme--) n’affecte que le contenu dont le formatage effectif dépend encore de ce thème. Le texte peut à la place hériter d’une surcharge de thème depuis un maître, une mise en page ou une diapositive, ou utiliser une police assignée explicitement. Inspectez ces niveaux lorsque le résultat visible ne suit pas la correspondance au niveau de la présentation.

## **Rendre les polices mappées disponibles et valider le résultat**

Une correspondance de script stocke un nom de famille de police ; elle n’installe pas et ne charge pas le fichier de police correspondant. Pour un rendu et une exportation cohérents, chaque police mappée doit être installée dans l’environnement ou fournie à Aspose.Slides via une source personnalisée telle que [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ou [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Consultez [Custom Fonts](/slides/fr/androidjava/custom-font/) pour les options de chargement disponibles.

Vérifier la correspondance enregistrée confirme uniquement que la définition du thème a été préservée. Cela ne prouve pas que la police est disponible, qu’elle contient tous les glyphes requis ou qu’elle produit la mise en page prévue. Rendu un texte représentatif pour chaque système d’écriture requis dans une image ou un PDF et inspectez le résultat. Cela permet de détecter les polices manquantes, la couverture de glyphes incomplète, le comportement de repli et les changements de mise en page avant la distribution de la présentation. Voir [Convert PowerPoint Presentations](/slides/fr/androidjava/convert-powerpoint/) pour des exemples de rendu et d’exportation.

## **FAQ**

**Que renvoie `getScriptFont` lorsqu’un script n’est pas mappé ?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) renvoie `null` lorsque la correspondance de script demandée n’est pas définie dans cette collection de police majeure ou mineure.

**`setScriptFont` ajoute‑t‑il une seconde correspondance lorsque le script existe déjà ?**

Non. [IFonts.setScriptFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) crée la correspondance lorsqu’elle manque et remplace la famille de police mappée lorsque la même balise de script est déjà présente.

**Pourquoi la modification d’une correspondance de thème n’a‑t‑elle pas changé certains textes ?**

Le texte peut avoir une police assignée explicitement, hériter d’un thème différent via une surcharge, ou être affecté par la substitution ou le repli lors du rendu. Une correspondance de script au niveau de la présentation ne contrôle que le texte dont le formatage effectif fait encore référence à cette collection de polices du thème.

**L’enregistrement et la réouverture suffisent‑ils pour valider la sortie multilingue ?**

Non. La réouverture ne vérifie que la persistance des données du thème. Il faut également rendre un texte représentatif de chaque système d’écriture requis afin de confirmer que les polices mappées sont disponibles et contiennent les glyphes nécessaires.