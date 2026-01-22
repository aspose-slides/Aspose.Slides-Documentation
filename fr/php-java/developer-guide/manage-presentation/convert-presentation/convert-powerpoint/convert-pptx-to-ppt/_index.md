---
title: Convertir PPTX en PPT avec PHP
linktitle: PPTX en PPT
type: docs
weight: 21
url: /fr/php-java/convert-pptx-to-ppt/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPTX
- PPTX en PPT
- enregistrer PPTX en tant que PPT
- exporter PPTX en PPT
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides — assurez une compatibilité transparente avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT en utilisant PHP. Le sujet suivant est couvert.

- Convertir PPTX en PPT

## **Convertir PPTX en PPT avec PHP**

Pour le code d'exemple Java permettant de convertir PPTX en PPT, veuillez consulter la section ci-dessous, à savoir [Convertir PPTX en PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme indiqué dans ces articles. 

- [Convertir PPTX en PDF avec PHP](/slides/fr/php-java/convert-powerpoint-to-pdf/)
- [Convertir PPTX en XPS avec PHP](/slides/fr/php-java/convert-powerpoint-to-xps/)
- [Convertir PPTX en HTML avec PHP](/slides/fr/php-java/convert-powerpoint-to-html/)
- [Convertir PPTX en ODP avec PHP](/slides/fr/php-java/save-presentation/)
- [Convertir PPTX en PNG avec PHP](/slides/fr/php-java/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, transmettez simplement le nom du fichier et le format d'enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). L'exemple de code PHP ci-dessous convertit une Presentation du PPTX au PPT en utilisant les options par défaut.
```php
  # instancier un objet Presentation qui représente un fichier PPTX
  $presentation = new Presentation("template.pptx");
  # enregistrer la présentation au format PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **FAQ**

**Tous les effets et fonctionnalités PPTX sont-ils conservés lors de l'enregistrement au format PPT hérité (97–2003) ?**

Pas toujours. Le format PPT ne possède pas certaines capacités plus récentes (par exemple, certains effets, objets et comportements), de sorte que les fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis-je convertir uniquement des diapositives sélectionnées en PPT au lieu de la présentation entière ?**

L'enregistrement direct cible l'ensemble de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la au format PPT ; sinon, utilisez un service/API qui prend en charge les paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l'ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/php-java/password-protected-presentation/) pour le PPT enregistré.