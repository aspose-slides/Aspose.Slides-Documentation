---
title: Convertir PPTX en PPT sur Android
linktitle: PPTX en PPT
type: docs
weight: 21
url: /fr/androidjava/convert-pptx-to-ppt/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPTX
- PPTX en PPT
- enregistrer PPTX en tant que PPT
- exporter PPTX vers PPT
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides pour Android via Java — assurez une compatibilité transparente avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT en utilisant Java. Le sujet suivant est couvert.

- Convertir PPTX en PPT avec Java

## **Convertir PPTX en PPT sur Android**

Pour le code d'exemple Java permettant de convertir PPTX en PPT, veuillez consulter la section ci‑dessous, à savoir [Convertir PPTX en PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme abordé dans ces articles. 

- [Java Convertir PPTX en PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Convertir PPTX en XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Convertir PPTX en HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Convertir PPTX en ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Convertir PPTX en Image](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, transmettez simplement le nom du fichier et le format d'enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). L'exemple de code Java ci‑dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.
```java
// instancier un objet Presentation qui représente un fichier PPTX
Presentation presentation = new Presentation("template.pptx");

// enregistrer la présentation au format PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Tous les effets et fonctionnalités PPTX sont‑ils conservés lors de l'enregistrement au format PPT (97–2003) hérité ?**

Pas toujours. Le format PPT ne prend pas en charge certaines capacités plus récentes (par ex., certains effets, objets et comportements), de sorte que les fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT au lieu de la présentation entière ?**

L'enregistrement direct cible l'ensemble de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la au format PPT ; alternativement, utilisez un service/API qui prend en charge les paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l'ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/androidjava/password-protected-presentation/) pour le PPT enregistré.