---
title: Limitations de l'API
type: docs
weight: 320
url: /fr/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Connaissez les limites d'Aspose.Slides for Node.js : les exportations définissent des métadonnées Application/Producer fixes dans PPT, PPTX, ODP et PDF - vous aidant à planifier les intégrations sans surprises."
---

## **Application et Producteur**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for Node.js via Java, certaines metadonnées techniques sont ecrites dans le fichier. Deux champs suscitent souvent des questions :

**Application** identifie le programme qui a cree ou enregistre pour la derniere fois une presentation **PPTX**. Dans Aspose.Slides for Node.js via Java, cette valeur est fixe et indique le vendeur de la bibliothèque plutôt que le nom de votre application, meme si vous utilisez [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifie le moteur de rendu qui a genere le fichier final lors de l'exportation. Dans les exportations **PDF**, les metadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for Node.js via Java, les deux sont fixes et reflètent la bibliotheque et sa version.

**Ce qui est limite**

Vous ne pouvez pas remplacer ces champs via l'API pour les formats ci-dessus. Pour **PPTX**, la propriete Application est ecrite comme "Aspose.Slides for Node.js via Java". Pour **PDF**, les proprietes Creator et Producer sont ecrites comme "Aspose.Slides for Node.js via Java x.x.x." Ce comportement est prevu par conception et s'applique quel que soit le mode de chargement ou d'enregistrement du fichier, ainsi que quelle que soit la valeur assignee en utilisant [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).