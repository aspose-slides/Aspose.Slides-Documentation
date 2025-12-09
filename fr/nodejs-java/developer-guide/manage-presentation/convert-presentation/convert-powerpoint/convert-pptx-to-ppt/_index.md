---
title: Convertir PPTX en PPT en JavaScript
linktitle: Convertir PPTX en PPT
type: docs
weight: 21
url: /fr/nodejs-java/convert-pptx-to-ppt/
keywords: "Java Convertir PPTX en PPT, Convertir une présentation PowerPoint, PPTX en PPT, Java, Aspose.Slides"
description: "Convertir PowerPoint PPTX en PPT en JavaScript"
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT à l'aide de JavaScript. Le sujet suivant est couvert.

- Convertir PPTX en PPT avec JavaScript

## **JavaScript Convertir PPTX en PPT**

Pour le code d'exemple JavaScript permettant de convertir PPTX en PPT, veuillez consulter la section ci‑dessous, à savoir [Convertir PPTX en PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles. 

- [JavaScript Convertir PPTX en PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [JavaScript Convertir PPTX en XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [JavaScript Convertir PPTX en HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [JavaScript Convertir PPTX en ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [JavaScript Convertir PPTX en Image](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**

Pour convertir un PPTX en PPT, il suffit de transmettre le nom du fichier et le format d'enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). L'exemple de code JavaScript ci‑dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.
```javascript
// instancier un objet Presentation qui représente un fichier PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// enregistrer la présentation au format PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **FAQ**

**Toutes les effets et fonctionnalités PPTX sont‑ils conservés lors de l'enregistrement au format PPT hérité (97–2003) ?**

Pas toujours. Le format PPT ne prend pas en charge certaines fonctionnalités plus récentes (par ex., certains effets, objets et comportements), de sorte que les fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT au lieu de toute la présentation ?**

L'enregistrement direct cible l'intégralité de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la au format PPT ; sinon, utilisez un service/API qui prend en charge les paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l'ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/nodejs-java/password-protected-presentation/) pour le PPT enregistré.