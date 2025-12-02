---
title: "Limitations de l'API"
type: docs
weight: 320
url: /fr/cpp/api-limitations/
keywords:
- Limitations de l'API
- format d'exportation
- application
- producteur
- propriétés du document
- métadonnées
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez les limites d'Aspose.Slides pour C++ : les exportations définissent des métadonnées Application/Producer fixes dans PPT, PPTX, ODP et PDF, ce qui vous aide à planifier les intégrations sans surprises."
---

## **Application et Producteur**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for C++, certaines métadonnées techniques sont écrites dans le fichier. Deux champs suscitent souvent des questions :

**Application** identifie le programme qui a créé ou enregistré en dernier une présentation **PPTX**. Dans Aspose.Slides for C++, cette valeur est fixe et indique le fournisseur de la bibliothèque plutôt que le nom de votre application, même si vous utilisez [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** identifie le moteur de rendu qui a généré le fichier final lors de l’exportation. Dans les exportations **PDF**, les métadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for C++, ces deux champs sont fixes et reflètent la bibliothèque et sa version.

**Ce qui est limité**

Vous ne pouvez pas remplacer ces champs via l’API pour les formats ci‑dessus. Pour **PPTX**, la propriété Application est écrite comme « Aspose.Slides for C++ ». Pour **PDF**, les propriétés Creator et Producer sont écrites comme « Aspose.Slides for C++ x.x.x ». Ce comportement est prévu par la conception et s’applique quel que soit le mode de chargement ou d’enregistrement du fichier, et quelles que soient les valeurs assignées en utilisant [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/).