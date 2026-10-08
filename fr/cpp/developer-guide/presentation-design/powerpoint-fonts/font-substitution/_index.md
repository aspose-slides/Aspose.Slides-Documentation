---
title: Configurer la substitution de police dans les présentations en C++
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "Configurer les règles de substitution de police et inspecter les polices substituées dans Aspose.Slides pour C++ lors du rendu ou de la conversion de présentations PowerPoint et OpenDocument."
---
## **Vue d’ensemble**

La substitution de police permet à Aspose.Slides d’utiliser une police disponible à la place d’une police qui ne peut pas être accédée lors du rendu ou de la conversion d’une présentation. La substitution affecte la sortie rendue ; elle ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu’une police particulière est indisponible, et vous pouvez inspecter les substitutions qu’Aspose.Slides effectuera lors du rendu. Cela permet de maintenir une sortie cohérente entre des environnements disposant de polices installées différentes.

Si une police est disponible mais ne possède pas de style gras dédié, consultez [Gestion des polices sans style gras dédié](/slides/fr/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Cette section explique comment rasteriser le texte concerné lors de l’exportation PDF et les conséquences pour la sélection de texte, la recherche et le redimensionnement.

## **Obtenir les substitutions de police**

Utilisez la méthode [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) pour déterminer quelles polices seront substituées lors du rendu de la présentation. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police originaux et substitués.

L’exemple C++ suivant répertorie toutes les substitutions de police pour une présentation :

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Obtenir les substitutions de police pour les diapositives sélectionnées**

Utilisez la surcharge de [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) avec un argument `System::ArrayPtr<int32_t> slides` pour inspecter uniquement les substitutions requises pour rendre des diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d’une présentation, vérifiez progressivement une grande présentation, localisez les diapositives dépendantes de polices indisponibles, préparez un package de polices minimal pour un serveur ou un conteneur, ou diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

Le tableau `slides` contient des index de diapositives à base 1 : `1` identifie la première diapositive. En revanche, la méthode [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) utilise un index à base 0, de sorte que la même diapositive est accessible via `presentation->get_Slide(0)`. Gardez cette différence à l’esprit lors de la construction du tableau afin d’éviter les erreurs d’indice hors de portée.

Appelez la surcharge via la méthode [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Elle renvoie uniquement les substitutions déterminées lors du rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) contenant les noms de police originaux et substitués. Le résultat reflète l’environnement de polices actuel, les règles de secours configurées, les règles de substitution stockées dans une [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/), et les [polices chargées externement](/slides/fr/cpp/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de pré‑flight. L’exemple suivant indique chaque substitution renvoyée, puis crée une liste triée de correspondances de polices uniques :

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

L’interface [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) fournit les deux surcharges. Choisissez‑en une en fonction de la portée de l’opération de rendu :

| Surcharge | Utiliser lorsqu’on |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Vous avez besoin de substitutions pour l’ensemble de la présentation. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | Vous avez besoin de substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir des règles de substitution de police**

Pour spécifier la police que Aspose.Slides doit utiliser lorsqu’une police source est indisponible :

1. Chargez la présentation.  
2. Créez des définitions de police pour les polices source et de substitution.  
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).  
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).  
5. Attribuez la collection en utilisant la méthode [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).  
6. Rendez ou convertissez la présentation.

L’exemple C++ suivant substitue `Arial` à la place de `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Pour un changement inconditionnel des polices utilisées dans l’ensemble d’une présentation, consultez [Remplacement de police](/slides/fr/cpp/font-replacement/).
{{% /alert %}}

## **Limites pour les polices d’équations mathématiques**

Les règles de substitution de police font partie du processus standard de sélection de police utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut nécessiter cette police exacte pour calculer et rendre la mise en page de l’équation. Une règle qui substitue une autre police mathématique, comme **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cet effet, et le rendu peut toujours indiquer que **Cambria Math** est requis.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d’exploitation ou chargez‑la comme une [police externe](/slides/fr/cpp/custom-font/).

Cette limitation s’applique à la mise en page des équations. Les règles de substitution décrites ci‑dessus restent applicables au texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**  
[Remplacement de police](/slides/fr/cpp/font-replacement/) modifie intentionnellement une police en une autre dans l’ensemble de la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsque la condition configurée est remplie, par exemple lorsque la police originale est indisponible.

**Quand les règles de substitution sont‑elles appliquées ?**  
Les règles participent à la [séquence de sélection de police](/slides/fr/cpp/font-selection-sequence/) pendant le rendu et la conversion. Avec `WhenInaccessible`, une règle est utilisée uniquement lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu’une police est manquante et aucune règle de substitution n’est configurée ?**  
Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection de police. Le résultat dépend des polices disponibles dans l’environnement d’exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**  
Oui. Vous pouvez [charger des polices externes](/slides/fr/cpp/custom-font/) afin qu’Aspose.Slides les utilise pendant le rendu et la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**  
Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**  
Oui. Les polices installées et les emplacements de recherche de polices diffèrent selon le système d’exploitation, de sorte qu’une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment rendre la sélection de police cohérente lors de conversions par lots ?**  
Utilisez les mêmes fichiers de police et les mêmes versions sur chaque machine ou conteneur, [chargez les polices externes requises](/slides/fr/cpp/custom-font/), et [intégrez les polices](/slides/fr/cpp/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) avant l’exportation afin d’identifier les substitutions inattendues.