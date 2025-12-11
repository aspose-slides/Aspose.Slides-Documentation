---
title: Configurer la substitution de police dans les présentations avec С++
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/cpp/font-substitution/
keywords:
- police
- police de substitution
- substitution de police
- remplacement de police
- police de remplacement
- règle de substitution
- règle de remplacement
- PowerPoint
- OpenDocument
- présentation
- С++
- Aspose.Slides
description: "Activez une substitution de police optimale dans Aspose.Slides pour С++ lors de la conversion des présentations PowerPoint et OpenDocument vers d'autres formats de fichier."
---

## **Définir les règles de substitution de police**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu’une police ne peut pas être accédée) de la manière suivante :

1. Chargez la présentation concernée.  
2. Chargez la police qui sera remplacée.  
3. Chargez la nouvelle police.  
4. Ajoutez une règle pour le remplacement.  
5. Ajoutez la règle à la collection de règles de remplacement de police de la présentation.  
6. Générez l’image de la diapositive pour observer l’effet.  

Ce code C++ illustre le processus de substitution de police :
```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Charge une présentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Définit la police qui sera remplacée et la nouvelle police
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Ajoute une règle de police pour le remplacement
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
Vous pouvez consulter [**Remplacement de police**](/slides/fr/cpp/font-replacement/). 
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Remplacement](/slides/fr/cpp/font-replacement/) est un remplacement forcé d’une police par une autre sur l’ensemble de la présentation. La substitution est une règle qui se déclenche sous une condition spécifique, par exemple lorsque la police d’origine n’est pas disponible, et alors une police de secours désignée est utilisée.

**Quand exactement les règles de substitution sont‑elles appliquées ?**

Les règles participent à la séquence standard de [sélection de police](/slides/fr/cpp/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n’est pas disponible, un remplacement ou une substitution est appliqué.

**Quel est le comportement par défaut si aucun remplacement ni substitution n’est configuré et que la police manque sur le système ?**

La bibliothèque tentera de choisir la police système disponible la plus proche, similaire à ce que ferait PowerPoint.

**Puis‑je attacher des polices externes personnalisées à l’exécution pour éviter la substitution ?**

Oui. Vous pouvez [ajouter des polices externes](/slides/fr/cpp/custom-font/) à l’exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue aucune police payante ou gratuite ; vous ajoutez et utilisez les polices à votre propre discrétion et sous votre responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices débute à partir des répertoires de polices du système d’exploitation. L’ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui affecte la disponibilité et le besoin de substitution.

**Comment devrais‑je préparer l’environnement pour minimiser les substitutions inattendues lors de conversions par lots ?**

Synchronisez l’ensemble des polices entre les machines ou conteneurs, [ajoutez les polices externes](/slides/fr/cpp/custom-font/) requises pour les documents de sortie, et [intégrez les polices](/slides/fr/cpp/embedded-font/) dans les présentations lorsque cela est possible afin que les polices choisies soient disponibles lors du rendu.