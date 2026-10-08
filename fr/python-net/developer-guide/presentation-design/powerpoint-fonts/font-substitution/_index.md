---
title: Configurer la substitution de police dans les présentations avec Python
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/python-net/font-substitution/
keywords:
- police
- police de substitution
- substitution de police
- remplacement de police
- remplacement de police
- règle de substitution
- règle de remplacement
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Configurer les règles de substitution de police et inspecter les polices substituées dans Aspose.Slides pour Python via .NET lors du rendu ou de la conversion de présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

La substitution de police permet à Aspose.Slides d’utiliser une police disponible à la place d’une police qui ne peut pas être accédée lorsqu’une présentation est rendue ou convertie. La substitution affecte la sortie rendue ; elle ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu’une police particulière n’est pas disponible, et vous pouvez inspecter les substitutions que Aspose.Slides effectuera lors du rendu. Cela aide à garder la sortie cohérente entre des environnements avec différentes polices installées.

Si une police est disponible mais ne possède pas de graisse dédiée, consultez [Gérer les polices sans empattement gras dédié](/slides/fr/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Cette section explique comment rastériser le texte concerné lors de l’export PDF ainsi que les conséquences pour la sélection du texte, la recherche et le redimensionnement.

## **Obtenir les substitutions de police**

Utilisez la méthode [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) pour déterminer quelles polices seront substituées lors du rendu de la présentation. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d’origine et de substitution.

L’exemple Python suivant répertorie toutes les substitutions de police pour une présentation :

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Obtenir les substitutions de police pour les diapositives sélectionnées**

Utilisez [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) avec une liste d’index de diapositives pour n’inspecter que les substitutions nécessaires au rendu de diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d’une présentation, vérifiez incrémentalement une grande présentation, localisez les diapositives qui dépendent de polices indisponibles, préparez un package de polices minimal pour un serveur ou un conteneur, ou diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

La liste contient des index de diapositives à base 1 : `1` identifie la première diapositive. En revanche, la collection [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) utilise une base 0, de sorte que la même diapositive s’obtient avec `presentation.slides[0]`. Gardez cette différence à l’esprit lors de la création de la liste afin d’éviter les erreurs d’indice de décalage.

Appelez la méthode via la propriété [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Elle renvoie uniquement les substitutions déterminées lors du rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) contenant les noms de police d’origine et de substitution. Le résultat reflète l’environnement de police actuel, les règles de secours configurées, les règles de substitution stockées dans une [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), et les [polices chargées externement](/slides/fr/python-net/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de pré‑flight. L’exemple suivant rapporte chaque substitution retournée puis crée une liste triée de correspondances de polices uniques :

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

La classe [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) fournit les deux formes de la méthode. Choisissez‑en une en fonction de la portée de l’opération de rendu :

| Appel de méthode | Quand l’utiliser |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) sans arguments | Vous avez besoin des substitutions pour l’ensemble de la présentation. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) avec une liste d’index de diapositives | Vous avez besoin des substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir les règles de substitution de police**

Pour spécifier la police que Aspose.Slides doit utiliser lorsqu’une police source n’est pas disponible :

1. Chargez la présentation.
2. Créez des définitions de polices pour les polices source et de substitution.
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) avec la condition [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Assignez la collection à la propriété [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Rendez ou convertissez la présentation.

L’exemple Python suivant substitue `Arial` à `SomeRareFont` lorsque `SomeRareFont` n’est pas disponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Pour une modification inconditionnelle des polices utilisées dans toute la présentation, consultez [Remplacement de police](/slides/fr/python-net/font-replacement/).
{{% /alert %}}

## **Limitations pour les polices d’équations mathématiques**

Les règles de substitution de police font partie du processus standard de sélection de police utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut avoir besoin de cette police exacte pour calculer et rendre la disposition de l’équation. Une règle qui substitue une autre police mathématique, comme **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cet effet, et le rendu peut encore indiquer que **Cambria Math** est requise.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d’exploitation ou chargez‑la comme une [police externe](/slides/fr/python-net/custom-font/).

Cette limitation s’applique à la disposition des équations. Les règles de substitution décrites ci‑dessus s’appliquent toujours au texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Remplacement de police](/slides/fr/python-net/font-replacement/) change intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsqu’une condition configurée est remplie, par exemple lorsque la police d’origine n’est pas disponible.

**Quand les règles de substitution sont‑elles appliquées ?**

Les règles participent à la [séquence de sélection de police](/slides/fr/python-net/font-selection-sequence/) lors du rendu et de la conversion. Avec `WHEN_INACCESSIBLE`, une règle n’est utilisée que lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu’une police est manquante et qu’aucune règle de substitution n’est configurée ?**

Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection de police. Le résultat dépend des polices disponibles dans l’environnement d’exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**

Oui. Vous pouvez [charger des polices externes](/slides/fr/python-net/custom-font/) afin qu’Aspose.Slides les utilise lors du rendu et de la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**

Oui. Les polices installées et les emplacements de recherche de polices diffèrent selon le système d’exploitation, de sorte qu’une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment rendre la sélection de police cohérente lors de conversions en lot ?**

Utilisez les mêmes fichiers de police et les mêmes versions sur chaque machine ou conteneur, [chargez les polices externes requises](/slides/fr/python-net/custom-font/), et [intégrez les polices](/slides/fr/python-net/embedded-font/) lorsque la licence le permet. Vous pouvez également appeler [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) avant l’exportation pour identifier les substitutions inattendues.