---
title: "Limitations de l'API"
type: docs
weight: 210
url: /fr/python-net/api-limitations/
keywords:
- "limitations de l'API"
- "format d'exportation"
- application
- producteur
- "propriétés du document"
- métadonnées
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez les limites d'Aspose.Slides pour Python : les exportations définissent des métadonnées Application/Producer fixes dans PPT, PPTX, ODP et PDF, vous aidant à planifier les intégrations sans mauvaises surprises."
---

## **Application et Producteur**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for Python via .NET, certaines métadonnées techniques sont écrites dans le fichier. Deux champs posent souvent des questions :

**Application** identifie le programme qui a créé ou enregistré en dernier une présentation **PPTX**. Dans Aspose.Slides for Python via .NET, cette valeur est fixe et indique le fournisseur de la bibliothèque plutôt que le nom de votre application, même si vous définissez [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/).

**Producteur** identifie le moteur de rendu qui a généré le fichier final lors de l’exportation. Dans les exportations **PDF**, les métadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for Python via .NET, ces deux champs sont fixes et reflètent la bibliothèque ainsi que sa version.

**Ce qui est restreint**

Vous ne pouvez pas remplacer ces champs via l’API pour les formats ci‑dessus. Pour **PPTX**, la propriété Application est écrite comme "Aspose.Slides for Python via .NET". Pour **PDF**, les propriétés Creator et Producer sont écrites comme "Aspose.Slides for Python via .NET x.x.x". Ce comportement est intentionnel et s’applique quel que soit le mode de chargement ou d’enregistrement du fichier, et quels que soient les valeurs affectées à [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/).