---
title: Remplacement de police
type: docs
weight: 60
url: /cpp/font-replacement/
keywords: "Police, remplacer police, présentation PowerPoint, C++, CPP, Aspose.Slides for C++"
description: "Remplacer les polices explicitement dans PowerPoint en C++"
---

Si vous changez d'avis au sujet de l'utilisation d'une police, vous pouvez remplacer cette police par une autre police. Toutes les instances de l'ancienne police seront remplacées par la nouvelle police.

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation pertinente.
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police.
4. Remplacez la police.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ démontre le remplacement de police :

``` cpp
// Loads a presentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Loads the source font that will be replaced
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Loads the new font
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Replaces the fonts
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Saves the presentation
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Pour définir des règles déterminant ce qui se passe dans certaines conditions (si une police ne peut pas être accessible, par exemple), consultez [**Substitution de police**](/slides/cpp/font-substitution/).

{{% /alert %}}