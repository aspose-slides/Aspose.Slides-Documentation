---
title: Substitution de police
type: docs
weight: 70
url: /fr/cpp/font-substitution/
keywords: "Police, police de substitution, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Substituer la police dans PowerPoint en C++"
---

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu'une police ne peut pas être accessible) de cette manière :

1. Chargez la présentation pertinente.
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police.
4. Ajoutez une règle pour le remplacement.
5. Ajoutez la règle à la collection de règles de remplacement de polices de la présentation.
6. Générez l'image de la diapositive pour observer l'effet.

Ce code C++ démontre le processus de substitution de police :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Charge une présentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Définit la police qui sera remplacée et la nouvelle police
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Ajoute une règle de police pour le remplacement de police
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Ajoute la règle à la collection de règles de substitution de polices
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Ajoute la collection de règles de police à la liste des règles
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Enregistre le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

Vous voudrez peut-être voir [**Remplacement de police**](/slides/fr/cpp/font-replacement/). 

{{% /alert %}}