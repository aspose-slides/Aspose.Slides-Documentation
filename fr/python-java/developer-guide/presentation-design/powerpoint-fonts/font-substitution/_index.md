---
title: Configurer la substitution de police dans les présentations en utilisant Python via Java
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/python-java/font-substitution/
keywords:
- police
- police de substitution
- substitution de police
- remplacer la police
- remplacement de police
- règle de substitution
- règle de remplacement
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Configurer les règles de substitution de police et inspecter les polices substituées dans Aspose.Slides pour Python via Java lors du rendu ou de la conversion de présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

La substitution de police permet à Aspose.Slides d’utiliser une police disponible à la place d’une police qui ne peut pas être accédée lorsqu’une présentation est rendue ou convertie. La substitution affecte le rendu final ; elle ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu’une police particulière est indisponible et inspecter les substitutions qu’Aspose.Slides effectuera pendant le rendu. Cela aide à garder une sortie cohérente entre des environnements avec des polices installées différentes.

Si une police est disponible mais ne possède pas de graisse dédiée, consultez [Gérer les polices sans une graisse dédiée](/slides/fr/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Cette section explique comment rasteriser le texte concerné lors de l’exportation en PDF ainsi que les conséquences sur la sélection du texte, la recherche et le redimensionnement.

## **Obtenir les substitutions de police**

Utilisez la méthode [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) pour déterminer quelles polices seront substituées lors du rendu de la présentation. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d’origine et de substitution.

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

Utilisez la surcharge de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) avec un tableau d’entiers Java pour n’inspecter que les substitutions nécessaires au rendu de diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d’une présentation, que vous vérifiez incrémentiellement une grande présentation, que vous localisez des diapositives dépendant de polices indisponibles, que vous préparez un paquet de polices minimal pour un serveur ou un conteneur, ou que vous diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

Le tableau `slides` contient des index de diapositives à base 1 : `1` désigne la première diapositive. En revanche, l’accesseur de collection [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) utilise un index à base 0, de sorte que la même diapositive est accès via `presentation.getSlides().get_Item(0)`. Gardez cette différence à l’esprit lors de la construction du tableau afin d’éviter les erreurs d’index.

Appelez la surcharge via la méthode [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Elle ne renvoie que les substitutions déterminées pendant le rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) contenant les noms de police d’origine et de substitution. Le résultat reflète l’environnement de police actuel, les règles de secours configurées, les règles de substitution stockées dans une [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/), et les [polices chargées externement](/slides/fr/python-java/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de pré‑flight. L’exemple suivant rapporte chaque substitution renvoyée puis crée une liste triée des correspondances de polices uniques :

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

La classe [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) propose les deux surcharges. Choisissez‑en une selon la portée de l’opération de rendu :

| Surcharge | Quand l'utiliser |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) sans arguments | Vous avez besoin de substitutions pour l’ensemble de la présentation. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) avec un tableau d’entiers Java | Vous avez besoin de substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir des règles de substitution de police**

Pour spécifier la police qu’Aspose.Slides doit utiliser lorsqu’une police source est indisponible :

1. Chargez la présentation.
2. Créez les définitions de police pour la police source et la police de substitution.
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. Assignez la collection en utilisant la méthode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Rendez ou convertissez la présentation.

L’exemple Python suivant substitue `Arial` à `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

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

{{% alert color="info" title="Note" %}}
Pour un changement inconditionnel des polices utilisées dans toute la présentation, consultez [Font Replacement](/slides/fr/python-java/font-replacement/).
{{% /alert %}}

## **Limitations pour les polices des équations mathématiques**

Les règles de substitution de police font partie du processus standard de sélection de police utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut nécessiter cette police exacte pour calculer et rendre la mise en page de l’équation. Une règle qui substitue une autre police mathématique, telle que **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cet effet, et le rendu peut toujours indiquer que **Cambria Math** est requise.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d’exploitation ou chargez‑la comme une [police externe](/slides/fr/python-java/custom-font/).

Cette limitation s’applique à la mise en page des équations. Les règles de substitution décrites ci‑dessus restent valables pour le texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**  
[Font replacement](/slides/fr/python-java/font-replacement/) change intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour le rendu lorsque la condition configurée est remplie, par exemple lorsque la police d’origine est indisponible.

**Quand les règles de substitution sont‑elles appliquées ?**  
Les règles participent à la [séquence de sélection de police](/slides/fr/python-java/font-selection-sequence/) lors du rendu et de la conversion. Avec `WhenInaccessible`, une règle n’est utilisée que lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu’une police manque et aucune règle de substitution n’est configurée ?**  
Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection de police. Le résultat dépend des polices présentes dans l’environnement d’exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**  
Oui. Vous pouvez [charger des polices externes](/slides/fr/python-java/custom-font/) afin qu’Aspose.Slides les utilise lors du rendu et de la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**  
Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**  
Oui. Les polices installées et les emplacements de recherche de polices diffèrent selon le système d’exploitation, de sorte qu’une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment assurer une sélection de police cohérente lors de conversions par lots ?**  
Utilisez les mêmes fichiers de police et les mêmes versions sur chaque machine ou conteneur, [chargez les polices externes requises](/slides/fr/python-java/custom-font/), et [intégrez les polices](/slides/fr/python-java/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) avant l’exportation pour identifier les substitutions inattendues.