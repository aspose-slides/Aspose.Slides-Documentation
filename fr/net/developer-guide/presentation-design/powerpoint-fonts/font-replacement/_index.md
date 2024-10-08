---
title: Remplacement de police - API PowerPoint C#  
linktitle: Remplacement de police  
type: docs  
weight: 60  
url: /fr/net/font-replacement/  
keywords: "Police, remplacer police, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"  
description: Avec l'API PowerPoint C#, vous pouvez remplacer explicitement une police par une autre dans la présentation.  
---

Si vous changez d'avis sur l'utilisation d'une police, vous pouvez remplacer cette police par une autre. Toutes les instances de l'ancienne police seront remplacées par la nouvelle police.

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation concernée.  
2. Chargez la police qui sera remplacée.  
3. Chargez la nouvelle police.  
4. Remplacez la police.  
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C# démontre le remplacement de police :

```c#
// Charge une présentation
Presentation presentation = new Presentation("Fonts.pptx");

// Charge la police source qui sera remplacée
IFontData sourceFont = new FontData("Arial");

// Charge la nouvelle police
IFontData destFont = new FontData("Times New Roman");

// Remplace les polices
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Sauvegarde la présentation
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 

Pour définir des règles qui déterminent ce qui se passe dans certaines conditions (si une police ne peut pas être accessible, par exemple), consultez [**Substitution de police**](/slides/fr/net/font-substitution/).

{{% /alert %}}