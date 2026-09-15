---
title: Limitations de l'API
type: docs
weight: 320
url: /fr/python-java/api-limitations/
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
- Python
- Java
- Aspose.Slides
description: "Découvrez les limitations d'Aspose.Slides pour Python via Java : métadonnées Application, Creator et Producer fixes dans les fichiers PPTX et PDF."
---
## **Vue d'ensemble**

Lorsque des présentations sont créées ou exportées avec Aspose.Slides, certaines métadonnées techniques sont écrites dans le fichier de sortie. Cet article explique les limitations liées aux champs de métadonnées `Application`, `Creator` et `Producer` dans les fichiers PPTX et PDF.

## **Application et Producteur**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for Python via Java, quelques métadonnées techniques sont écrites dans le fichier. Deux champs suscitent souvent des questions :

**Application** identifie le programme qui a créé ou enregistré en dernier une présentation **PPTX**. Dans Aspose.Slides for Python via Java, cette valeur est fixe et indique le fournisseur de la bibliothèque plutôt que le nom de votre application, même si vous utilisez [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producteur** identifie le moteur de rendu qui a généré le fichier final lors de l’exportation. Dans les exportations **PDF**, les métadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for Python via Java, ces deux champs sont fixes et reflètent la bibliothèque et sa version.

**Ce qui est restreint**

Vous ne pouvez pas remplacer ces champs via l’API pour les formats mentionnés ci‑dessus. Pour **PPTX**, la propriété Application est écrite comme « Aspose.Slides for Java ». Pour **PDF**, les propriétés Creator et Producer sont écrites comme « Aspose.Slides for Java x.x.x. ». Ce comportement est intentionnel et s’applique quel que soit le mode de chargement ou d’enregistrement du fichier, ainsi que les valeurs assignées avec [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **FAQ**

**Puis‑je remplacer la valeur Application dans un fichier PPTX par le nom de mon application ?**

Non. La valeur est fixe, même si vous utilisez [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Puis‑je remplacer les champs Creator et Producer dans les exportations PDF ?**

Non. Les deux champs sont fixes et reflètent la bibliothèque et sa version, quel que soit le mode de chargement ou d’enregistrement de la présentation.