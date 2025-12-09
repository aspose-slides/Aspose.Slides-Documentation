---
title: "Limitations de l'API"
type: docs
weight: 320
url: /fr/androidjava/api-limitations/
keywords:
- "limitations de l'API"
- "format d'exportation"
- "application"
- "producteur"
- "propriétés du document"
- "métadonnées"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Découvrez les limites d'Aspose.Slides for Android : les exportations fixent les métadonnées Application/Producer dans PPT, PPTX, ODP et PDF—vous aidant à planifier vos intégrations sans surprises."
---

## **Application et Producer**

Lorsque vous créez ou exportez des présentations avec Aspose.Slides for Android via Java, certaines métadonnées techniques sont écrites dans le fichier. Deux champs soulèvent souvent des questions :

**Application** identifie le programme qui a créé ou enregistré pour la dernière fois une présentation **PPTX**. Avec Aspose.Slides for Android via Java, cette valeur est fixe et indique le fournisseur de la bibliothèque plutôt que le nom de votre application, même si vous utilisez [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifie le moteur de rendu qui a généré le fichier final lors de l'exportation. Dans les exportations **PDF**, les métadonnées utilisent les champs **Creator** et **Producer**. Avec Aspose.Slides for Android via Java, ces deux champs sont fixes et reflètent la bibliothèque et sa version.

**What’s restricted**

Vous ne pouvez pas remplacer ces champs via l’API pour les formats ci‑dessus. Pour **PPTX**, la propriété Application est écrite comme « Aspose.Slides for Android via Java ». Pour **PDF**, les propriétés Creator et Producer sont écrites comme « Aspose.Slides for Android via Java x.x.x. ». Ce comportement est intentionnel et s’applique quel que soit le mode de chargement ou d’enregistrement du fichier, et quels que soient les valeurs assignées en utilisant [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).