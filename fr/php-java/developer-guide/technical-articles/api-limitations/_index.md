---
title: Limitations de l'API
type: docs
weight: 320
url: /fr/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Connaissez les limites d'Aspose.Slides for PHP : les exportations définissent des métadonnées Application/Producer fixes dans PPT, PPTX, ODP et PDF—vous aidant à planifier vos intégrations sans surprise."
---

## **Application et Producteur**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for PHP via Java, certaines métadonnées techniques sont écrites dans le fichier. Deux champs soulèvent souvent des questions :

**Application** identifie le programme qui a créé ou enregistré en dernier une présentation **PPTX**. Dans Aspose.Slides for PHP via Java, cette valeur est fixe et affiche le fournisseur de la bibliothèque plutôt que le nom de votre application, même si vous utilisez [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifie le moteur de rendu qui a généré le fichier final lors de l'exportation. Dans les exportations **PDF**, les métadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for PHP via Java, ces deux champs sont fixes et reflètent la bibliothèque et sa version.

**Ce qui est limité**

Vous ne pouvez pas remplacer ces champs via l'API pour les formats ci‑dessus. Pour **PPTX**, la propriété Application est écrite comme « Aspose.Slides for PHP via Java ». Pour **PDF**, les propriétés Creator et Producer sont écrites comme « Aspose.Slides for PHP via Java x.x.x. ». Ce comportement est prévu par conception et s'applique quel que soit le mode de chargement ou d'enregistrement du fichier, ainsi que quelles que soient les valeurs attribuées en utilisant [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/).