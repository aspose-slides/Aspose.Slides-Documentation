---
title: Convertir PPTX en PPT avec JavaScript
linktitle: PPTX en PPT
type: docs
weight: 21
url: /fr/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides — assurez une compatibilité transparente avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT à l'aide de JavaScript. Le sujet suivant est abordé.

- Convertir PPTX en PPT avec JavaScript

## **JavaScript Convertir PPTX en PPT**

Pour le code d'exemple JavaScript permettant de convertir PPTX en PPT, veuillez consulter la section ci‑dessous, à savoir [Convert PPTX to PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles. 

- [Convertir PPTX en PDF avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/)
- [Convertir PPTX en XPS avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-xps/)
- [Convertir PPTX en HTML avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-html/)
- [Convertir PPTX en ODP avec JavaScript](/slides/fr/nodejs-java/save-presentation/)
- [Convertir PPTX en PNG avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**

Pour convertir un PPTX en PPT, il suffit de transmettre le nom du fichier et le format d'enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). L'exemple de code JavaScript ci‑dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.
```javascript
// instancier un objet Presentation qui représente un fichier PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// enregistrer la présentation au format PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **FAQ**

**Tous les effets et fonctionnalités PPTX survivent-ils lors de l'enregistrement au format PPT hérité (97‑2003) ?**

Pas toujours. Le format PPT ne prend pas en charge certaines fonctionnalités plus récentes (par exemple, certains effets, objets et comportements), de sorte que les fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT au lieu de toute la présentation ?**

L'enregistrement direct cible l'intégralité de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la au format PPT ; sinon, utilisez un service/API qui prend en charge les paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l'ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/nodejs-java/password-protected-presentation/) pour le PPT enregistré.