---
title: Limitations des métadonnées de sortie
type: docs
weight: 320
url: /fr/java/api-limitations/
keywords:
- Limitations de l'API
- format d'exportation
- application
- producteur
- propriétés du document
- métadonnées
- générateur
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java écrit des métadonnées d'application, de créateur et de producteur fixes dans les fichiers PPTX, PDF et ODP enregistrés, quel que soit le nom d'application que vous avez défini."
---
## **Vue d'ensemble**

Lorsque des présentations sont créées ou exportées avec Aspose.Slides, certaines métadonnées techniques sont écrites dans le fichier de sortie. Cet article explique les limitations liées aux champs de métadonnées `Application`, `Creator`, `Producer` et generator dans les fichiers PPTX, PDF et ODP.

## **Application et Producer**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for Java, certaines métadonnées techniques sont écrites dans le fichier. Deux champs suscitent souvent des questions :

**Application** identifie le programme qui a créé ou enregistré en dernier une présentation **PPTX**. Dans Aspose.Slides for Java, cette valeur est fixe et indique le nom de la bibliothèque plutôt que le nom de votre application, même si vous utilisez [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fr/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifie le moteur de rendu qui a généré le fichier final lors de l'exportation. Dans les exportations **PDF**, les métadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for Java, ces deux champs sont fixes et reflètent la bibliothèque et sa version.

**Ce qui est restreint**

Vous ne pouvez pas remplacer ces champs via l'API pour les formats mentionnés ci‑dessus. Pour **PPTX**, la propriété Application est écrite comme « Aspose.Slides for Java ». Pour **PDF**, les propriétés Creator et Producer sont écrites comme « Aspose.Slides for Java » suivies de la version de la bibliothèque. Pour **ODP**, le champ generator est écrit comme « Aspose.Slides for Java » suivi de la version de la bibliothèque. Ce comportement est prévu par la conception et s'applique quel que soit le mode de chargement ou d'enregistrement du fichier, ainsi que quelles que soient les valeurs assignées en utilisant [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fr/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Cette restriction ne s'applique pas aux fichiers **PPT** : dans un fichier PPT, le nom de l'application que vous définissez avec [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fr/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) est enregistré.