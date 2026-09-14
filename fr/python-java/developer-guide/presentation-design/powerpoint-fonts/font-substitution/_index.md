---
title: "Configurer la substitution de police dans les présentations en utilisant Python via Java"
linktitle: "Substitution de police"
type: docs
weight: 70
url: /fr/python-java/font-substitution/
keywords:
- "police"
- "police de substitution"
- "substitution de police"
- "remplacer la police"
- "remplacement de police"
- "règle de substitution"
- "règle de remplacement"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Configurez les règles de substitution de police et inspectez les polices substituées dans Aspose.Slides pour Python via Java lors du rendu ou de la conversion de présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

La substitution de police permet à Aspose.Slides d’utiliser une police disponible à la place d’une police inaccessible lors du rendu ou de la conversion d’une présentation. La substitution affecte la sortie rendue ; elle ne modifie pas la police affectée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu’une police particulière n’est pas disponible, et vous pouvez examiner les substitutions qu’Aspose.Slides effectuera pendant le rendu. Cela permet de garantir une sortie cohérente entre des environnements possédant des polices installées différentes.

## **Obtenir les substitutions de police**

Utilisez la méthode [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getSubstitutions) pour déterminer quelles polices seront substituées lors du rendu de la présentation. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d’origine et les noms de police substitués.

L’exemple Python suivant répertorie toutes les substitutions de police pour une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Obtenir les substitutions de police pour des diapositives sélectionnées**

Utilisez la surcharge de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getSubstitutions) avec un tableau d’entiers Java pour examiner uniquement les substitutions nécessaires au rendu de diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d’une présentation, que vous vérifiez une grande présentation de façon incrémentielle, que vous localisez des diapositives dépendantes de polices indisponibles, que vous préparez un paquet de polices minimal pour un serveur ou un conteneur, ou que vous diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

Le tableau `slides` contient des index de diapositives basés sur 1 : `1` désigne la première diapositive. En revanche, l’accesseur de collection [Presentation.getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides) utilise un indexation à partir de 0, de sorte que la même diapositive s’accès via `presentation.getSlides().get_Item(0)`. Gardez cette différence à l’esprit lors de la création du tableau afin d’éviter les erreurs d’indice décalé.

Appelez la surcharge via la méthode [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getFontsManager). Elle renvoie uniquement les substitutions déterminées pendant le rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsubstitutioninfo/) contenant les noms de police d’origine et substitués. Le résultat reflète l’environnement de police actuel, les règles de repli configurées, les règles de substitution stockées dans une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsubstrulecollection/), et les [polices chargées externement](/slides/fr/python-java/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de pré‑flight. L’exemple suivant signale chaque substitution retournée puis crée une liste triée de mappages de polices uniques :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

La classe [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) propose les deux surcharges. Choisissez‑en une selon la portée de l’opération de rendu :

| Surcharge | À utiliser lorsqu’ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getSubstitutions) sans arguments | Vous avez besoin des substitutions pour l’ensemble de la présentation. |
| [getSubstitutions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getSubstitutions) avec un tableau d’entiers Java | Vous avez besoin des substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir des règles de substitution de police**

Pour spécifier la police qu’Aspose.Slides doit utiliser lorsqu’une police source est indisponible :

1. Chargez la présentation.  
2. Créez des définitions de police pour les polices source et de substitution.  
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsubstrulecollection/).  
5. Assignez la collection en utilisant la méthode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Rendez ou convertissez la présentation.

L’exemple Python suivant substitue `Arial` à `SomeRareFont` lorsque `SomeRareFont` n’est pas disponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Remarque" %}}
Pour un changement inconditionnel des polices utilisées dans toute la présentation, consultez [Remplacement de police](/slides/fr/python-java/font-replacement/).
{{% /alert %}}

## **Limites pour les polices des équations mathématiques**

Les règles de substitution de police font partie du processus standard de sélection des polices utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire quand Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut avoir besoin de cette police exacte pour calculer et rendre la mise en page de l’équation. Une règle qui substitue une autre police mathématique, telle que **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cette fin, et le rendu peut toujours indiquer que **Cambria Math** est requise.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d’exploitation ou chargez‑la comme [police externe](/slides/fr/python-java/custom-font/).

Cette limitation s’applique à la mise en page des équations. Les règles de substitution décrites ci‑dessus continuent de s’appliquer au texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Remplacement de police](/slides/fr/python-java/font-replacement/) change intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsque la condition configurée est remplie, par exemple lorsqu’elle n’est pas disponible.

**Quand les règles de substitution sont‑elles appliquées ?**

Les règles participent à la [séquence de sélection des polices](/slides/fr/python-java/font-selection-sequence/) pendant le rendu et la conversion. Avec `WhenInaccessible`, une règle n’est utilisée que lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu’une police est manquante et aucune règle de substitution n’est configurée ?**

Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection des polices. Le résultat dépend des polices présentes dans l’environnement d’exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**

Oui. Vous pouvez [charger des polices externes](/slides/fr/python-java/custom-font/) afin qu’Aspose.Slides les utilise pendant le rendu et la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**

Oui. Les polices installées et les emplacements de recherche de polices diffèrent selon le système d’exploitation, de sorte qu’une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment garantir une sélection de police cohérente lors de conversions en lot ?**

Utilisez les mêmes fichiers de police et les mêmes versions sur chaque machine ou conteneur, [chargez les polices externes requises](/slides/fr/python-java/custom-font/), et [intégrez les polices](/slides/fr/python-java/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getSubstitutions) avant l’exportation pour identifier les substitutions inattendues.