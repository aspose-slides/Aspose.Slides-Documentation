---
title: Configurer la substitution de police dans les présentations avec Java
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Configurez les règles de substitution de police et examinez les polices substituées dans Aspose.Slides pour Java lors du rendu ou de la conversion de présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

La substitution de police permet à Aspose.Slides d'utiliser une police disponible à la place d'une police qui ne peut pas être accessible lors du rendu ou de la conversion d'une présentation. La substitution affecte la sortie rendue ; elle ne modifie pas la police affectée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu'une police particulière est indisponible, et vous pouvez inspecter les substitutions que Aspose.Slides effectuera pendant le rendu. Cela permet de maintenir une sortie cohérente entre des environnements avec des polices installées différentes.

## **Obtenir les substitutions de police**

Utilisez la méthode [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) pour déterminer quelles polices seront substituées lors du rendu de la présentation. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d'origine et de substitution.

L'exemple Java suivant répertorie toutes les substitutions de police pour une présentation :

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir les substitutions de police pour des diapositives sélectionnées**

Utilisez la surcharge de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) avec un argument `int[] slides` pour inspecter uniquement les substitutions nécessaires au rendu de diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d'une présentation, vérifiez une grande présentation de façon incrémentielle, localisez les diapositives qui dépendent de polices indisponibles, préparez un paquet de polices minimal pour un serveur ou un conteneur, ou diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

Le tableau `slides` contient des index de diapositives basés sur 1 : `1` identifie la première diapositive. En revanche, l'accesseur de collection [Presentation.getSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSlides--) utilise un indexation à partir de 0, de sorte que la même diapositive est accessible via `presentation.getSlides().get_Item(0)`. Gardez cette différence à l'esprit lors de la construction du tableau afin d'éviter les erreurs de décalage d'un.

Appelez la surcharge via la méthode [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getFontsManager--) . Elle renvoie uniquement les substitutions déterminées lors du rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsubstitutioninfo/) contenant les noms de police d'origine et de substitution. Le résultat reflète l'environnement de police actuel, les règles de secours configurées, et les [polices chargées externement](/slides/fr/java/custom-font/). Les règles de substitution stockées dans une [IFontSubstRuleCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsubstrulecollection/) sont appliquées lors du rendu de la présentation, mais le résultat ne les répertorie pas ; vérifiez les polices dans le fichier de sortie à la place.

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de pré‑validation. L'exemple suivant signale chaque substitution retournée puis crée une liste triée des correspondances de polices uniques :

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

L'interface [IFontsManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/) fournit les deux surcharges. Choisissez‑en une en fonction de la portée de l'opération de rendu :

| Surcharge | Quand l'utiliser |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) sans arguments | Vous avez besoin de substitutions pour l'intégralité de la présentation. |
| [getSubstitutions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) avec `int[] slides` | Vous avez besoin de substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir des règles de substitution de police**

Pour spécifier la police que Aspose.Slides doit utiliser lorsqu'une police source est indisponible :

1. Chargez la présentation.
2. Créez des définitions de police pour les polices source et de substitution.
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsubstcondition/).
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsubstrulecollection/).
5. Attribuez la collection en utilisant la méthode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) .
6. Rendez ou convertissez la présentation.

L'exemple Java suivant substitue `Arial` à `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Pour un changement inconditionnel des polices utilisées dans l'ensemble d'une présentation, consultez [Font Replacement](/slides/fr/java/font-replacement/).
{{% /alert %}}

## **Limitations pour les polices d'équations mathématiques**

Les règles de substitution de police font partie du processus standard de sélection de police utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut nécessiter cette police exacte pour calculer et rendre la mise en page de l'équation. Une règle qui substitue une autre police mathématique, telle que **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cette fin, et le rendu peut toujours indiquer que **Cambria Math** est requis.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d'exploitation ou chargez‑la comme une [police externe](/slides/fr/java/custom-font/).

Cette limitation s'applique à la mise en page des équations. Les règles de substitution décrites ci‑dessus continuent de s'appliquer au texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Font replacement](/slides/fr/java/font-replacement/) modifie intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsque la condition configurée est remplie, par exemple quand la police originale est indisponible.

**Quand les règles de substitution sont‑elles appliquées ?**

Les règles participent à la [séquence de sélection de police](/slides/fr/java/font-selection-sequence/) pendant le rendu et la conversion. Avec `WhenInaccessible`, une règle n'est utilisée que lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu'une police manque et qu'aucune règle de substitution n'est configurée ?**

Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection de police. Le résultat dépend des polices disponibles dans l'environnement d'exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**

Oui. Vous pouvez [charger des polices externes](/slides/fr/java/custom-font/) afin qu'Aspose.Slides puisse les utiliser pendant le rendu et la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**

Oui. Les polices installées et les emplacements de recherche de polices diffèrent selon le système d'exploitation, de sorte qu'une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment garantir une sélection de police cohérente lors de conversions en lot ?**

Utilisez les mêmes fichiers de police et les mêmes versions sur chaque machine ou conteneur, [chargez les polices externes requises](/slides/fr/java/custom-font/), et [intégrez les polices](/slides/fr/java/embedded-font/) lorsque la licence le permet. Vous pouvez également appeler [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) avant l'exportation pour identifier les substitutions inattendues.