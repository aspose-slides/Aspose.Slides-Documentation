---
title: Gérer les polices de thème spécifiques aux scripts en JavaScript
linktitle: Polices de thème spécifiques aux scripts
type: docs
weight: 15
url: /fr/nodejs-java/script-specific-font-mappings/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Inspecter, ajouter, remplacer et supprimer les correspondances de polices spécifiques aux scripts dans les thèmes PowerPoint avec Aspose.Slides pour Node.js."
---
## **Vue d'ensemble**

Un thème de présentation peut sélectionner différentes familles de polices pour différents systèmes d'écriture. Cela permet au texte multilingue qui utilise toujours les polices du thème de suivre un schéma de polices coordonné tout en utilisant des polices appropriées pour le cyrillique, l'arabe, le japonais, le géorgien, le thaana et d'autres scripts.

Le [FontScheme] du thème contient une collection de polices majeures, généralement utilisée pour les titres, et une collection de polices mineures, généralement utilisée pour le texte principal. En plus de leurs paramètres de polices latines et est‑asiatiques, les deux collections exposent des correspondances entre les balises de système d'écriture et les noms de familles de polices via la classe [Fonts].

Cet article montre comment inspecter et modifier ces correspondances dans le thème maître de la présentation et vérifier que les modifications survivent à un cycle d'enregistrement et de rechargement.

## **Comprendre les balises de script**

Les méthodes de police de script utilisent des sous‑balises de script BCP 47 de quatre lettres pour identifier les systèmes d'écriture. Les valeurs courantes comprennent :

| Balise de script | Système d'écriture |
|---|---|
| `Cyrl` | Cyrillique |
| `Arab` | Arabe |
| `Hans` | Chinois simplifié |
| `Jpan` | Japonais |
| `Geor` | Géorgien |
| `Thaa` | Thaana |

Ces correspondances appartiennent au schéma de police du thème, pas à des portions de texte individuelles. Une présentation peut définir différentes correspondances pour les collections majeures et mineures, et peut omettre des correspondances pour certains scripts.

## **Accéder et inspecter les correspondances de police de script**

Utilisez [Presentation.getMasterTheme] pour accéder au thème au niveau de la présentation. Les méthodes [FontScheme.getMajor] et [FontScheme.getMinor] renvoient les deux collections [Fonts].

Appelez [Fonts.getScriptFontMap] pour récupérer toutes les correspondances d’une collection. Pour rechercher un système d’écriture, appelez [Fonts.getScriptFont] avec sa balise de script. `getScriptFont` renvoie `null` lorsque cette collection ne définit pas la correspondance demandée.

## **Modifier les correspondances et vérifier la persistance**

Utilisez [Fonts.setScriptFont] pour créer une correspondance ou remplacer sa famille de police actuelle. Utilisez [Fonts.removeScriptFont] pour supprimer une correspondance.

L’exemple complet suivant lit toutes les correspondances majeures et mineures existantes, recherche la police majeure japonaise, change la police majeure cyrillique, supprime la correspondance mineure thaana, enregistre la présentation et la rouvre pour vérifier les deux changements. Pour rendre l’étape de suppression indépendante du thème initial, l’exemple crée d’abord une correspondance thaana uniquement si aucune n’est déjà définie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

La vérification utilise le même comportement `null` qu’une recherche ordinaire : après la sauvegarde de la suppression, `getScriptFont("Thaa")` renvoie `null` pour la collection mineure.

## **Distinguer les correspondances du thème des autres réglages de police**

Les correspondances de thème spécifiques au script participent à la sélection de la police, mais elles résolvent un problème différent de la mise en forme directe du texte, de la substitution et du secours :

| Mécanisme | Objectif | Effet du changement d'une correspondance du thème |
|---|---|---|
| Correspondance de police de thème spécifique au script | Sélectionne une police majeure ou mineure du thème pour un système d'écriture. | Le texte qui utilise toujours la police du thème correspondante peut être résolu vers la nouvelle famille mappée. |
| Police attribuée explicitement à une portion de texte | Fixe la famille de police demandée sur cette portion au lieu de dépendre du thème. | La portion peut rester inchangée car son formatage direct prévaut sur le choix du thème. |
| Substitution de police | Remplace une police demandée lorsqu'elle n'est pas disponible ou lorsqu'une règle de substitution s'applique. | Elle agit après qu'une police a été demandée ; elle ne redéfinit pas la correspondance de script du thème. |
| Polices de secours | Fournit les glyphes que la police sélectionnée ne contient pas, souvent pour des plages Unicode spécifiques. | Elle comble les lacunes de glyphes ; elle ne modifie pas la correspondance stockée du thème. |

Pour plus d’informations sur les deux derniers mécanismes, voir [Substitution de police](/slides/fr/nodejs-java/font-substitution/) et [Polices de secours](/slides/fr/nodejs-java/fallback-font/).

Modifier une correspondance dans [Presentation.getMasterTheme] affecte uniquement le contenu dont le formatage effectif dépend encore de ce thème. Le texte peut, à la place, hériter d’une substitution de thème provenant d’un maître, d’une disposition ou d’une diapositive, ou utiliser une police attribuée explicitement. Inspectez ces niveaux lorsque le résultat visible ne suit pas la correspondance du niveau de présentation.

## **Rendre les polices mappées disponibles et valider le résultat**

Une correspondance de script stocke un nom de famille de police ; elle n’installe ni ne charge le fichier de police correspondant. Pour un rendu et une exportation cohérents, chaque police mappée doit être installée dans l’environnement ou fournie à Aspose.Slides via une source personnalisée telle que [FontsLoader.loadExternalFonts] ou [LoadOptions.getDocumentLevelFontSources]. Consultez [Polices personnalisées](/slides/fr/nodejs-java/custom-font/) pour les options de chargement disponibles.

Vérifier la correspondance enregistrée confirme uniquement que la définition du thème a été préservée. Cela ne prouve pas que la police est disponible, qu’elle contient tous les glyphes requis ou qu’elle produit la mise en page attendue. Rendu du texte représentatif pour chaque système d’écriture requis en image ou PDF et inspectez la sortie. Cela permet de détecter les polices manquantes, la couverture de glyphes incomplète, le comportement de secours et les changements de mise en page avant la distribution de la présentation. Voir [Convertir des présentations PowerPoint](/slides/fr/nodejs-java/convert-powerpoint/) pour des exemples de rendu et d’exportation.

## **FAQ**

**Que renvoie `getScriptFont` lorsqu'un script n'est pas mappé ?**

[Fonts.getScriptFont] renvoie `null` lorsque la correspondance de script demandée n'est pas définie dans cette collection de polices majeures ou mineures.

**Est‑ce que `setScriptFont` ajoute une seconde correspondance lorsque le script existe déjà ?**

Non. [Fonts.setScriptFont] crée la correspondance lorsqu'elle est manquante et remplace la famille de police mappée lorsque la même balise de script est déjà présente.

**Pourquoi la modification d'une correspondance du thème n'a‑t‑elle pas changé certains textes ?**

Le texte peut avoir une police attribuée explicitement, hériter d'un thème différent via une substitution, ou être affecté par la substitution ou le secours lors du rendu. Une correspondance de script au niveau de la présentation ne contrôle que le texte dont le formatage effectif dépend encore de cette collection de polices du thème.

**Est‑ce que l'enregistrement et la réouverture suffisent à valider la sortie multilingue ?**

Non. La réouverture vérifie la persistance des données du thème. Il faut également rendre le texte représentatif de chaque système d'écriture requis pour confirmer que les polices mappées sont disponibles et contiennent les glyphes nécessaires.