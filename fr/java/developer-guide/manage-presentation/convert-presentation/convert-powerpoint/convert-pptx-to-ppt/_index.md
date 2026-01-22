---
title: Convertir PPTX en PPT en Java
linktitle: PPTX en PPT
type: docs
weight: 21
url: /fr/java/convert-pptx-to-ppt/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPTX
- PPTX en PPT
- enregistrer PPTX comme PPT
- exporter PPTX vers PPT
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides pour Java—assurez une compatibilité transparente avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT à l’aide de Java. Le sujet suivant est abordé.

- Convertir PPTX en PPT en Java

## **Convertir PPTX en PPT en Java**

Pour le code d’exemple Java permettant de convertir PPTX en PPT, veuillez consulter la section ci‑dessous, à savoir [Convertir PPTX en PPT](#convert-pptx-to-ppt). Le code charge simplement le fichier PPTX et l’enregistre au format PPT. En spécifiant d’autres formats d’enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux formats tels que PDF, XPS, ODP, HTML, etc., comme indiqué dans ces articles.

- [Convertir PPTX en PDF en Java](/slides/fr/java/convert-powerpoint-to-pdf/)
- [Convertir PPTX en XPS en Java](/slides/fr/java/convert-powerpoint-to-xps/)
- [Convertir PPTX en HTML en Java](/slides/fr/java/convert-powerpoint-to-html/)
- [Convertir PPTX en ODP en Java](/slides/fr/java/save-presentation/)
- [Convertir PPTX en PNG en Java](/slides/fr/java/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, transmettez simplement le nom du fichier et le format d’enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). L’exemple de code Java ci‑dessous convertit une Presentation de PPTX en PPT en utilisant les options par défaut.
```java
// instancier un objet Presentation qui représente un fichier PPTX
Presentation presentation = new Presentation("template.pptx");

// sauvegarder la présentation en PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Toutes les effets et fonctionnalités PPTX sont‑ils conservés lors de l’enregistrement au format PPT hérité (97–2003) ?**

Pas toujours. Le format PPT ne prend pas en charge certaines des capacités plus récentes (par exemple, certains effets, objets et comportements), si bien que les fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis‑je convertir uniquement les diapositives sélectionnées en PPT au lieu de l’ensemble de la présentation ?**

L’enregistrement direct cible l’ensemble de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives puis enregistrez‑la au format PPT ; alternativement, utilisez un service/API qui accepte des paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l’ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/java/password-protected-presentation/) pour le PPT enregistré.