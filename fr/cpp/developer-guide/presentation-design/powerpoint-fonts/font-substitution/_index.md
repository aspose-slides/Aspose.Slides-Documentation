---
title: Configurer la substitution de police dans les présentations avec C++
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "Activez une substitution de police optimale dans Aspose.Slides pour C++ lors de la conversion de présentations PowerPoint et OpenDocument vers d’autres formats de fichier."
---
## **Vue d'ensemble**

La substitution de police permet à Aspose.Slides d’utiliser une autre police lorsque la police originale de la présentation n’est pas disponible lors du rendu ou de la conversion. Vous pouvez vérifier quelles polices ont été substituées en utilisant la méthode `GetSubstitutions` de l’interface `IFontsManager`.

Aspose.Slides vous permet également de définir des règles de substitution de police. Par exemple, vous pouvez spécifier qu’une police inaccessible doit être remplacée par une autre police disponible, puis appliquer ces règles via le gestionnaire de polices de la présentation.

## **Définir les règles de substitution de police**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu’une police ne peut pas être accédée) de la manière suivante :

1. Charger la présentation concernée.
2. Charger la police qui sera remplacée.
3. Charger la nouvelle police.
4. Ajouter une règle pour le remplacement.
5. Ajouter la règle à la collection de règles de remplacement de police de la présentation.
6. Générer l’image de la diapositive pour observer l’effet.

Ce code C++ illustre le processus de substitution de police :

```c++
// Le chemin du répertoire des documents.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Charge une présentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Définit la police qui sera remplacée et la nouvelle police
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Ajoute une règle de police pour le remplacement de police
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Ajoute la règle à la collection de règles de substitution de police
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Ajoute la collection de règles de police à la liste des règles
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Enregistre le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Vous pourriez vouloir consulter [**Remplacement de police**](/slides/fr/cpp/font-replacement/). 
{{% /alert %}}

## **Limitations pour les polices d'équations mathématiques**

Les règles de substitution de police participent au processus standard de sélection de police utilisé lors du rendu et de la conversion. Elles conviennent aux scénarios de texte normal où Aspose.Slides peut remplacer une police inaccessible par une autre police disponible selon la règle configurée.

Cependant, les équations mathématiques d’Office présentent une limitation importante. Si une équation a été créée avec **Cambria Math**, Aspose.Slides peut toujours exiger la police originale **Cambria Math** pour calculer et rendre correctement la mise en page de l’équation. En raison de cela, la substitution de **Cambria Math** par une autre police mathématique, telle que **STIX Two Math**, n’est pas prise en charge pour le rendu des équations et peut toujours entraîner une exception indiquant que **Cambria Math** est requise.

Pour convertir correctement ces présentations, assurez‑vous que **Cambria Math** soit disponible pour Aspose.Slides à l’exécution. Vous pouvez installer la police dans le système d’exploitation ou la fournir en tant que [police externe](/slides/fr/cpp/custom-font/) afin qu’elle participe au processus normal de sélection de police lors du rendu et de la conversion.

Cette limitation est spécifique au rendu des équations. Les règles standards de substitution de police décrites ci‑dessus s’appliquent toujours au texte normal d’une présentation lorsque la police originale est inaccessible.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**  
[Remplacement](/slides/fr/cpp/font-replacement/) est une substitution forcée d’une police par une autre sur l’ensemble de la présentation. La substitution est une règle qui se déclenche sous une condition spécifique, par exemple lorsque la police originale n’est pas disponible, et qu’une police de secours désignée est alors utilisée.

**Quand exactement les règles de substitution sont‑elles appliquées ?**  
Les règles participent à la séquence standard de [sélection de police](/slides/fr/cpp/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n’est pas disponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si aucun remplacement ni substitution n’est configuré et que la police est absente du système ?**  
La bibliothèque tentera de choisir la police système disponible la plus proche, similaire à ce que ferait PowerPoint.

**Puis‑je joindre des polices externes personnalisées au moment de l’exécution pour éviter la substitution ?**  
Oui. Vous pouvez [ajouter des polices externes](/slides/fr/cpp/custom-font/) au moment de l’exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**  
Non. Aspose ne distribue aucune police, qu’elle soit payante ou gratuite ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**  
Oui. La découverte des polices commence à partir des répertoires de polices du système d’exploitation. L’ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui affecte la disponibilité et le besoin de substitution.

**Comment préparer l’environnement pour minimiser les substitutions inattendues lors de conversions par lots ?**  
Synchronisez l’ensemble des polices entre les machines ou les conteneurs, [ajoutez les polices externes](/slides/fr/cpp/custom-font/) requises pour les documents de sortie, et [incorporez des polices](/slides/fr/cpp/embedded-font/) dans les présentations lorsque cela est possible afin que les polices choisies soient disponibles lors du rendu.