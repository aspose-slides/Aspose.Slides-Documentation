---
title: Gérer les polices de thème spécifiques aux scripts en Python
linktitle: Polices de thème spécifiques aux scripts
type: docs
weight: 15
url: /fr/python-net/script-specific-font-mappings/
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
- Python
- Aspose.Slides
description: "Inspectez, ajoutez, remplacez et supprimez les mappages de polices spécifiques aux scripts dans les thèmes PowerPoint avec Aspose.Slides pour Python via .NET."
---
## **Aperçu**

Un thème de présentation peut sélectionner différentes familles de polices pour différents systèmes d’écriture. Cela permet à un texte multilingue qui utilise toujours les polices du thème de suivre un schéma de police coordonné tout en utilisant des polices appropriées pour le cyrillique, l’arabe, le japonais, le géorgien, le thaana et d’autres scripts.

Le [FontScheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/) du thème contient une collection de polices principales, généralement utilisées pour les titres, et une collection de polices secondaires, généralement utilisées pour le corps du texte. En plus de leurs propriétés de police latine et est‑asiatique, les deux collections exposent des mappages des balises de système d’écriture vers les noms de famille de polices via la classe [Fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fonts/).

Cet article montre comment inspecter et modifier ces mappages dans le thème maître de la présentation et vérifier que les modifications survivent à un cycle d’enregistrement‑et‑rechargement.

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

Ces mappages appartiennent au schéma de police du thème, pas à des portions de texte individuelles. Une présentation peut définir des mappages différents pour les collections principales et secondaires, et elle peut omettre des mappages pour certains scripts.

## **Accéder et inspecter les mappages de police de script**

Utilisez [Presentation.master_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/master_theme/) pour accéder au thème au niveau de la présentation. Les propriétés [FontScheme.major](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/major/) et [FontScheme.minor](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/minor/) renvoient les deux collections [Fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fonts/).

Appelez [Fonts.get_script_font_map](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fonts/get_script_font_map/) pour récupérer tous les mappages d’une collection. Pour rechercher un système d’écriture, appelez [Fonts.get_script_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fonts/get_script_font/) avec sa balise de script. `get_script_font` renvoie `None` lorsque la collection ne définit pas le mappage demandé.

## **Modifier les mappages et vérifier la persistance**

Utilisez [Fonts.set_script_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fonts/set_script_font/) pour créer un mappage ou remplacer sa famille de police actuelle. Utilisez [Fonts.remove_script_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fonts/remove_script_font/) pour supprimer un mappage.

L’exemple de bout en bout suivant lit tous les mappages principaux et secondaires existants, recherche la police principale japonaise, modifie la police principale cyrillique, supprime le mappage secondaire thaana, enregistre la présentation, puis la rouvre pour vérifier les deux changements. Pour que l’étape de suppression soit indépendante du thème initial, l’exemple crée d’abord un mappage thaana uniquement lorsqu’il n’est pas déjà défini.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

La vérification utilise le même comportement `None` qu’une recherche ordinaire : après que la suppression a été enregistrée, `get_script_font("Thaa")` renvoie `None` pour la collection secondaire.

## **Différencier les mappages du thème des autres paramètres de police**

Les mappages de thème spécifiques au script participent à la sélection de police, mais ils résolvent un problème différent de la mise en forme directe du texte, de la substitution et du secours :

| Mécanisme | Objectif | Effet d’un changement de mappage du thème |
|---|---|---|
| Mappage de police de thème spécifique au script | Sélectionne une police principale ou secondaire du thème pour un système d’écriture. | Le texte qui utilise toujours la police du thème correspondante peut se résoudre vers la nouvelle famille mappée. |
| Police assignée explicitement à une portion de texte | Fixe la famille de police demandée sur cette portion au lieu de se fier au thème. | La portion peut rester inchangée car son formatage direct écrase le choix du thème. |
| Substitution de police | Remplace une police demandée lorsqu’elle n’est pas disponible ou lorsqu’une règle de substitution s’applique. | Elle agit après qu’une police a été demandée ; elle ne redéfinit pas le mappage du script du thème. |
| Police de secours | Fournit les glyphes que la police sélectionnée ne contient pas, souvent pour des plages Unicode spécifiques. | Elle comble les lacunes de couverture de glyphes ; elle ne modifie pas le mappage stocké du thème. |

Pour plus d’informations sur les deux derniers mécanismes, consultez [Font Substitution](/slides/fr/python-net/font-substitution/) et [Fallback Fonts](/slides/fr/python-net/fallback-font/).

Modifier un mappage dans [Presentation.master_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/master_theme/) n’affecte que le contenu dont le formatage effectif dépend encore de ce thème. Le texte peut à la place hériter d’une surcharge de thème depuis un maître, une disposition ou une diapositive, ou utiliser une police assignée explicitement. Inspectez ces niveaux lorsque le résultat visible ne suit pas le mappage au niveau de la présentation.

## **Rendre les polices mappées disponibles et valider le résultat**

Un mappage de script stocke un nom de famille de police ; il n’installe pas et ne charge pas le fichier de police correspondant. Pour un rendu et une exportation cohérents, chaque police mappée doit être installée dans l’environnement ou fournie à Aspose.Slides via une source personnalisée telle que [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsloader/load_external_fonts/) ou [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/document_level_font_sources/). Consultez [Custom Fonts](/slides/fr/python-net/custom-font/) pour les options de chargement disponibles.

La vérification du mappage enregistré confirme uniquement que la définition du thème a été préservée. Elle ne prouve pas que la police est disponible, qu’elle contient tous les glyphes requis ou qu’elle produit la mise en page attendue. Rendu le texte représentatif de chaque système d’écriture requis dans une image ou un PDF et inspectez le résultat. Cela permet de détecter les polices manquantes, la couverture incomplète des glyphes, le comportement de secours et les changements de mise en page avant la distribution de la présentation. Voir [Convert PowerPoint Presentations](/slides/fr/python-net/convert-powerpoint/) pour des exemples de rendu et d’exportation.

## **FAQ**

**Que renvoie `get_script_font` lorsqu’un script n’est pas mappé ?**

[Fonts.get_script_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fonts/get_script_font/) renvoie `None` lorsque le mappage de script demandé n’est pas défini dans cette collection principale ou secondaire.

**`set_script_font` ajoute‑t‑il un second mappage lorsque le script existe déjà ?**

Non. [Fonts.set_script_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fonts/set_script_font/) crée le mappage lorsqu’il manque et remplace la famille de police mappée lorsque la même balise de script est déjà présente.

**Pourquoi la modification d’un mappage de thème n’a‑t‑elle pas affecté certains textes ?**

Le texte peut avoir une police assignée explicitement, hériter d’un thème différent via une surcharge, ou être affecté par la substitution ou le secours lors du rendu. Un mappage de script au niveau de la présentation contrôle uniquement le texte dont le formatage effectif fait encore référence à cette collection de polices du thème.

**L’enregistrement et la réouverture suffisent‑ils pour valider la sortie multilingue ?**

Non. La réouverture vérifie la persistance des données du thème. Il faut également rendre le texte représentatif de chaque système d’écriture requis pour confirmer que les polices mappées sont disponibles et contiennent les glyphes nécessaires.