---
title: Convertir PPTX en PPT
linktitle: Convertir PPTX en PPT
type: docs
weight: 21
url: /fr/php-java/convert-pptx-to-ppt/
keywords: "PHP  Convertir PPTX en PPT, Convertir Présentation PowerPoint, PPTX en PPT, Java, Aspose.Slides"
description: "Convertir une présentation PowerPoint PPTX en PPT"
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT en utilisant PHP. Le sujet suivant est abordé.

- Convertir PPTX en PPT

## **Java Convertir PPTX en PPT**

Pour le code source Java permettant de convertir PPTX en PPT, veuillez consulter la section ci-dessous c'est-à-dire [Convertir PPTX en PPT](#convert-pptx-en-ppt). Cela charge simplement le fichier PPTX et le sauvegarde au format PPT. En précisant différents formats de sauvegarde, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme discuté dans ces articles.

- [Java Convertir PPTX en PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java Convertir PPTX en XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java Convertir PPTX en HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java Convertir PPTX en ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java Convertir PPTX en Image](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, il suffit de passer le nom du fichier et le format de sauvegarde à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). L'exemple de code PHP ci-dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.

```php
  # instancier un objet Presentation représentant un fichier PPTX
  $presentation = new Presentation("template.pptx");
  # sauvegarder la présentation en tant que PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);

```