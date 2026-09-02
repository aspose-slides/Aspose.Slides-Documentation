---
title: Configurer la substitution de police dans les présentations sur Android
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Configurez les règles de substitution de police et inspectez les polices substituées dans Aspose.Slides pour Android via Java lors du rendu ou de la conversion de présentations."
---
## **Vue d'ensemble**

La substitution de police permet à Aspose.Slides d’utiliser une police disponible à la place d’une police inaccessible lors du rendu ou de la conversion d’une présentation. La substitution affecte la sortie rendue ; elle ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu’une police particulière est indisponible, et vous pouvez examiner les substitutions que Aspose.Slides effectuera lors du rendu. Cela permet de garder la sortie cohérente sur les appareils Android et les environnements disposant de polices différentes.

## **Obtenir les substitutions de police**

Utilisez la méthode [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) pour déterminer quelles polices seront substituées lors du rendu de la présentation. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d’origine et de substitution.

L’exemple Java suivant répertorie toutes les substitutions de police pour une présentation :

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

Utilisez la surcharge de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) avec un argument `int[] slides` pour inspecter uniquement les substitutions nécessaires au rendu de diapositives spécifiques. Ceci est utile lorsque vous rendez ou exportez une partie d’une présentation, vérifiez une grande présentation de façon incrémentielle, localisez les diapositives dépendantes de polices indisponibles, préparez un paquet de polices minimal pour une application Android, ou diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

Le tableau `slides` contient des index de diapositives à base 1 : `1` identifie la première diapositive. En revanche, l’accesseur de collection [Presentation.getSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSlides--) utilise un index à base 0, de sorte que la même diapositive est obtenue avec `presentation.getSlides().get_Item(0)`. Gardez cette différence à l’esprit lors de la construction du tableau afin d’éviter les erreurs d’indice.

Appelez la surcharge via la méthode [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getFontsManager--) . Elle renvoie uniquement les substitutions déterminées lors du rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsubstitutioninfo/) contenant les noms de police d’origine et de substitution. Le résultat reflète l’environnement de police actuel, les règles de repli configurées, les règles de substitution stockées dans une [IFontSubstRuleCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsubstrulecollection/), et les [polices externes](/slides/fr/androidjava/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de préflight. L’exemple suivant indique chaque substitution renvoyée, puis crée une liste triée de mappages de police uniques :

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

L’interface [IFontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/) propose les deux surcharges. Choisissez celle qui correspond à la portée de l’opération de rendu :

| Surcharge | À utiliser lorsque |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) sans arguments | Vous avez besoin des substitutions pour l’ensemble de la présentation. |
| [getSubstitutions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) avec `int[] slides` | Vous avez besoin des substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir les règles de substitution de police**

Pour spécifier la police que Aspose.Slides doit utiliser lorsqu’une police source est indisponible :

1. Chargez la présentation.  
2. Créez les définitions de police pour la police source et la police de substitution.  
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsubstcondition/).  
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsubstrulecollection/).  
5. Assignez la collection en utilisant la méthode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Rendu ou conversion de la présentation.

L’exemple Java suivant substitue `Arial` à `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

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
Pour un changement inconditionnel des polices utilisées dans toute la présentation, consultez la section [Remplacement de police](/slides/fr/androidjava/font-replacement/).
{{% /alert %}}

## **Limites pour les polices des équations Math**

Les règles de substitution de police font partie du processus standard de sélection de police utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée dans une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut nécessiter cette police exacte pour calculer et rendre la mise en page de l’équation. Une règle qui substitue une autre police mathématique, comme **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cette fin, et le rendu peut encore indiquer que **Cambria Math** est requis.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Chargez‑la en tant que [police externe](/slides/fr/androidjava/custom-font/) afin que l’application puisse l’utiliser pendant le rendu et la conversion.

Cette limitation s’applique à la mise en page des équations. Les règles de substitution décrites ci‑dessus restent valables pour le texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Remplacement de police](/slides/fr/androidjava/font-replacement/) modifie intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsque la condition configurée est remplie, par exemple lorsque la police d’origine est indisponible.

**Quand les règles de substitution sont‑elles appliquées ?**

Les règles participent à la [séquence de sélection de police](/slides/fr/androidjava/font-selection-sequence/) pendant le rendu et la conversion. Avec `WhenInaccessible`, une règle n’est utilisée que lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu’une police manque et aucune règle de substitution n’est configurée ?**

Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection. Le résultat dépend des polices présentes dans l’environnement d’exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**

Oui. Vous pouvez [charger des polices externes](/slides/fr/androidjava/custom-font/) afin qu’Aspose.Slides les utilise lors du rendu et de la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer selon les appareils Android ?**

Oui. Les polices système disponibles peuvent varier selon les versions d’Android, les appareils et les fabricants, de sorte qu’une police disponible dans un environnement peut nécessiter une substitution dans un autre.

**Comment garantir une sélection de police cohérente sur tous les appareils Android ?**

Regroupez les mêmes fichiers de police requis avec l’application, [chargez‑les comme polices externes](/slides/fr/androidjava/custom-font/), et [intégrez les polices](/slides/fr/androidjava/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) avant l’exportation pour identifier les substitutions inattendues.