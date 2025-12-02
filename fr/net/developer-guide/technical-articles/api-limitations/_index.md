---
title: Limitations de l'API
type: docs
weight: 320
url: /fr/net/api-limitations/
keywords:
- limitations de l'API
- format d'exportation
- application
- producteur
- propriétés du document
- métadonnées
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez les limites d'Aspose.Slides for .NET : les exportations définissent des métadonnées Application/Producer fixes dans PPT, PPTX, ODP et PDF, vous aidant à planifier les intégrations sans surprises."
---

## **Application et Producteur**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for .NET, certaines métadonnées techniques sont écrites dans le fichier. Deux champs soulèvent souvent des questions :

**Application** identifie le programme qui a créé ou enregistré pour la dernière fois une présentation **PPTX**. Dans Aspose.Slides for .NET, cette valeur est fixe et affiche le fournisseur de la bibliothèque plutôt que le nom de votre application, même si vous définissez [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) .

**Producteur** identifie le moteur de rendu qui a généré le fichier final lors de l'exportation. Dans les exportations **PDF**, les métadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for .NET, ces deux champs sont fixes et reflètent la bibliothèque et sa version.

**Ce qui est restreint**

Vous ne pouvez pas remplacer ces champs via l'API pour les formats ci‑dessus. Pour **PPTX**, la propriété Application est écrite comme "Aspose.Slides for .NET". Pour **PDF**, les propriétés Creator et Producer sont écrites comme "Aspose.Slides for .NET x.x.x". Ce comportement est prévu par conception et s'applique quel que soit le mode de chargement ou d'enregistrement du fichier, et quelle que soit la valeur attribuée à [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) .