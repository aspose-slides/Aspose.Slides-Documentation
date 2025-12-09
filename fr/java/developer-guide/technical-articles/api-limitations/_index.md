---
title: Limitations de l'API
type: docs
weight: 320
url: /fr/java/api-limitations/
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
- Java
- Aspose.Slides
description: "Découvrez les limites d'Aspose.Slides for Java : les exportations définissent des métadonnées Application/Producer fixes dans les fichiers PPT, PPTX, ODP et PDF—vous aidant à planifier vos intégrations sans surprise."
---

## **Application et Producteur**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for Java, certaines métadonnées techniques sont écrites dans le fichier. Deux champs suscitent souvent des questions :

**Application** identifie le programme qui a créé ou enregistré pour la dernière fois une présentation **PPTX**. Dans Aspose.Slides for Java, cette valeur est fixe et indique le fournisseur de la bibliothèque plutôt que le nom de votre application, même si vous utilisez [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producteur** identifie le moteur de rendu qui a généré le fichier final lors de l’exportation. Dans les exportations **PDF**, les métadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for Java, ces deux champs sont fixes et reflètent la bibliothèque et sa version.

**Ce qui est restreint**

Vous ne pouvez pas remplacer ces champs via l’API pour les formats ci‑dessus. Pour **PPTX**, la propriété Application est écrite comme « Aspose.Slides for Java ». Pour **PDF**, les propriétés Creator et Producer sont écrites comme « Aspose.Slides for Java x.x.x. ». Ce comportement est intentionnel et s’applique quelle que soit la façon dont vous chargez ou enregistrez le fichier, et quels que soient les valeurs affectées en utilisant [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).