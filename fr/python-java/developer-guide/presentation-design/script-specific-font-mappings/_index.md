---
title: Gérer les polices de thème spécifiques aux scripts en Python via Java
linktitle: Polices de thème spécifiques aux scripts
type: docs
weight: 15
url: /fr/python-java/script-specific-font-mappings/
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
- Python
- Java
- Aspose.Slides
description: "Inspecter, ajouter, remplacer et supprimer les correspondances de polices spécifiques aux scripts dans les thèmes PowerPoint avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Un thème de présentation peut sélectionner différentes familles de polices pour différents systèmes d'écriture. Cela permet au texte multilingue qui utilise toujours les polices du thème de suivre un schéma de polices coordonné tout en utilisant des polices appropriées pour le cyrillique, l'arabe, le japonais, le géorgien, le thaana et d'autres scripts.

Le [FontScheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontscheme/) du thème contient une collection de polices principales, généralement utilisée pour les titres, et une collection de polices secondaires, généralement utilisée pour le texte principal. En plus de leurs paramètres de polices latines et d'Asie de l'Est, les deux collections exposent des correspondances entre les balises de système d'écriture et les noms de familles de polices via la classe [Fonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fonts/).

Cet article montre comment inspecter et modifier ces correspondances dans le thème maître de la présentation et vérifier que les modifications survivent à un cycle d'enregistrement et de rechargement.

## **Comprendre les balises de script**

Les méthodes de police de script utilisent des sous‑balises de script BCP 47 à quatre lettres pour identifier les systèmes d'écriture. Les valeurs courantes incluent :

| Tag de script | Système d'écriture |
|---|---|
| `Cyrl` | Cyrillique |
| `Arab` | Arabe |
| `Hans` | Chinois simplifié |
| `Jpan` | Japonais |
| `Geor` | Géorgien |
| `Thaa` | Thaana |

Ces correspondances appartiennent au schéma de police du thème, pas aux portions de texte individuelles. Une présentation peut définir des correspondances différentes pour les collections majeures et mineures, et elle peut omettre des correspondances pour certains scripts.

## **Accéder et inspecter les correspondances de police de script**

Utilisez [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasterTheme) pour accéder au thème au niveau de la présentation. Les méthodes [FontScheme.getMajor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontscheme/#getMajor) et [FontScheme.getMinor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontscheme/#getMinor) renvoient les deux collections [Fonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fonts/).

Appelez [Fonts.getScriptFontMap](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fonts/#getScriptFontMap) pour récupérer toutes les correspondances d’une collection. Pour rechercher un seul système d'écriture, appelez [Fonts.getScriptFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fonts/#getScriptFont) avec sa balise de script. `getScriptFont` renvoie `None` lorsque cette collection ne définit pas la correspondance demandée.

## **Modifier les correspondances et vérifier la persistance**

Utilisez [Fonts.setScriptFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fonts/#setScriptFont) pour créer une correspondance ou remplacer la famille de police actuelle. Utilisez [Fonts.removeScriptFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fonts/#removeScriptFont) pour supprimer une correspondance.

L'exemple de bout en bout suivant lit toutes les correspondances majeures et mineures existantes, recherche la police majeure japonaise, change la police majeure cyrillique, supprime la correspondance Thaana mineure, enregistre la présentation et la rouvre pour vérifier les deux changements. Pour rendre l'étape de suppression indépendante du thème initial, l'exemple crée d'abord une correspondance Thaana uniquement lorsqu'aucune n'est déjà définie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

La vérification utilise le même comportement `None` qu’une recherche ordinaire : après que la suppression a été enregistrée, `getScriptFont("Thaa")` renvoie `None` pour la collection mineure.

## **Différencier les correspondances de thème des autres paramètres de police**

Les correspondances de thème spécifiques à un script participent à la sélection de police, mais elles résolvent un problème différent de la mise en forme directe du texte, de la substitution et du fallback :

| Mécanisme | Objectif | Effet du changement d'une correspondance de thème |
|---|---|---|
| Correspondance de police de thème spécifique à un script | Sélectionne une police de thème majeure ou mineure pour un système d'écriture. | Le texte qui utilise toujours la police de thème correspondante peut être résolu vers la nouvelle famille mappée. |
| Police affectée explicitement à une portion de texte | Fixe la famille de police demandée sur cette portion au lieu de s’appuyer sur le thème. | La portion peut rester inchangée car sa mise en forme directe écrase le choix du thème. |
| Substitution de police | Remplace une police demandée lorsqu’elle n’est pas disponible ou lorsqu’une règle de substitution s’applique. | Elle agit après qu’une police a été demandée ; elle ne redéfinit pas la correspondance de script du thème. |
| Fallback de police | Fournit des glyphes que la police sélectionnée ne contient pas, souvent pour des plages Unicode spécifiques. | Il comble les lacunes de couverture de glyphes ; il ne modifie pas la correspondance de thème stockée. |

Pour plus d'informations sur les deux derniers mécanismes, voir [Font Substitution](/slides/fr/python-java/font-substitution/) et [Fallback Fonts](/slides/fr/python-java/fallback-font/).

Modifier une correspondance dans [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasterTheme) n'affecte que le contenu dont le format effectif dépend encore de ce thème. Le texte peut à la place hériter d’une substitution de thème depuis un maître, une disposition ou une diapositive, ou utiliser une police assignée explicitement. Inspectez ces niveaux lorsque le résultat visible ne suit pas la correspondance au niveau de la présentation.

## **Rendre les polices mappées disponibles et valider le résultat**

Une correspondance de script stocke un nom de famille de police ; elle n’installe pas et ne charge pas le fichier de police correspondant. Pour un rendu et une exportation cohérents, chaque police mappée doit être installée dans l’environnement ou fournie à Aspose.Slides via une source personnalisée telle que [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#loadExternalFonts) ou [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Consultez [Custom Fonts](/slides/fr/python-java/custom-font/) pour les options de chargement disponibles.

Vérifier la correspondance enregistrée confirme uniquement que la définition du thème a été préservée. Cela ne prouve pas que la police est disponible, qu’elle contient tous les glyphes requis ou qu’elle produit la mise en page souhaitée. Rendu du texte représentatif pour chaque système d'écriture requis dans une image ou un PDF et inspectez le résultat. Cela permet de détecter les polices manquantes, une couverture de glyphes incomplète, le comportement de fallback et les changements de mise en page avant la distribution de la présentation. Voir [Convert PowerPoint Presentations](/slides/fr/python-java/convert-powerpoint/) pour des exemples de rendu et d'exportation.

## **FAQ**

**Que renvoie `getScriptFont` lorsqu'un script n'est pas mappé ?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fonts/#getScriptFont) renvoie `None` lorsque la correspondance de script demandée n'est pas définie dans cette collection de polices majeure ou mineure.

**Est-ce que `setScriptFont` ajoute une seconde correspondance lorsque le script existe déjà ?**

Non. [Fonts.setScriptFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fonts/#setScriptFont) crée la correspondance lorsqu'elle manque et remplace la famille de police mappée lorsque le même tag de script est déjà présent.

**Pourquoi le changement d'une correspondance de thème n'a-t-il pas modifié certains textes ?**

Le texte peut avoir une police assignée explicitement, hériter d’un thème différent via une substitution, ou être affecté par la substitution ou le fallback lors du rendu. Une correspondance de script au niveau de la présentation ne contrôle que le texte dont le format effectif fait encore référence à cette collection de polices du thème.

**L'enregistrement et la réouverture suffisent-ils à valider la sortie multilingue ?**

Non. La réouverture vérifie la persistance des données du thème. Il faut également rendre du texte représentatif de chaque système d'écriture requis pour confirmer que les polices mappées sont disponibles et contiennent les glyphes nécessaires.