---
title: Convertir PPTX en PPT en C++
linktitle: PPTX en PPT
type: docs
weight: 21
url: /fr/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides pour C++ — assurez une compatibilité transparente avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT à l’aide de C++. Le sujet suivant est couvert.

- Convertir PPTX en PPT en C++

## **Convertir PPTX en PPT en C++**

Pour le code d’exemple C++ permettant de convertir PPTX en PPT, veuillez consulter la section ci‑dessous : [Convert PPTX to PPT](#convert-pptx-to-ppt). Le code charge simplement le fichier PPTX et l’enregistre au format PPT. En spécifiant d’autres formats d’enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles.

- [Convertir PPTX en PDF en C++](/slides/fr/cpp/convert-powerpoint-to-pdf/)
- [Convertir PPTX en XPS en C++](/slides/fr/cpp/convert-powerpoint-to-xps/)
- [Convertir PPTX en HTML en C++](/slides/fr/cpp/convert-powerpoint-to-html/)
- [Convertir PPTX en ODP en C++](/slides/fr/cpp/save-presentation/)
- [Convertir PPTX en PNG en C++](/slides/fr/cpp/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
Pour convertir un PPTX en PPT, il suffit de transmettre le nom du fichier et le format d’enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). L’exemple de code C++ ci‑dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.
```cpp
// Charger le PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Enregistrer au format PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Tous les effets et fonctionnalités PPTX sont‑ils conservés lors de l’enregistrement au format PPT hérité (97–2003) ?**

Pas toujours. Le format PPT ne prend pas en charge certaines capacités plus récentes (par exemple, certains effets, objets et comportements), de sorte que les fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT au lieu de toute la présentation ?**

L’enregistrement direct cible l’ensemble de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives puis enregistrez‑la au format PPT ; alternativement, utilisez un service/API qui accepte des paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l’ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/cpp/password-protected-presentation/) pour le PPT enregistré.