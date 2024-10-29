---
title: Convertir PPTX en PPT en Java
linktitle: Convertir PPTX en PPT
type: docs
weight: 21
url: /fr/androidjava/convert-pptx-to-ppt/
keywords: "Java Convertir PPTX en PPT, Convertir une présentation PowerPoint, PPTX en PPT, Java, Aspose.Slides"
description: "Convertir PowerPoint PPTX en PPT en Java"
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT en utilisant Java. Le sujet suivant est couvert.

- Convertir PPTX en PPT en Java

## **Java Convertir PPTX en PPT**

Pour voir un exemple de code Java pour convertir PPTX en PPT, veuillez consulter la section ci-dessous c'est-à-dire [Convertir PPTX en PPT](#convertir-pptx-en-ppt). Il suffit de charger le fichier PPTX et de l'enregistrer au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc. comme discuté dans ces articles.

- [Java Convertir PPTX en PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Convertir PPTX en XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Convertir PPTX en HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Convertir PPTX en ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Convertir PPTX en Image](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, il suffit de passer le nom de fichier et le format d'enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). L'exemple de code Java ci-dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.

```java
// instancier un objet Presentation qui représente un fichier PPTX
Presentation presentation = new Presentation("template.pptx");

// enregistrer la présentation en tant que PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```