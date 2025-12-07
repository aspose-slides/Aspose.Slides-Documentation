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
- enregistrer PPTX en PPT
- exporter PPTX en PPT
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides pour C++ — assurez une compatibilité parfaite avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT à l'aide de C++. Le sujet suivant est couvert.

- Convertir PPTX en PPT en C++

## **Convertir PPTX en PPT en C++**

Pour le code d'exemple C++ qui convertit PPTX en PPT, voir la section ci‑dessous, à savoir [Convertir PPTX en PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant d'autres formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme décrit dans ces articles.

- [C++ Convertir PPTX en PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Convertir PPTX en XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Convertir PPTX en HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Convertir PPTX en ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Convertir PPTX en Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, il suffit de passer le nom du fichier et le format de sauvegarde à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). L'exemple de code C++ ci‑dessous convertit une Presentation du format PPTX au format PPT en utilisant les options par défaut.
```cpp
// Charger le PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Enregistrer au format PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Tous les effets et fonctionnalités PPTX sont‑ils conservés lors de l'enregistrement au format PPT (97–2003) hérité ?**

Pas toujours. Le format PPT ne prend pas en charge certaines des capacités plus récentes (par exemple, certains effets, objets et comportements), ce qui peut entraîner une simplification ou une rasterisation des fonctionnalités lors de la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT au lieu de la présentation entière ?**

L'enregistrement direct cible l'ensemble de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la au format PPT ; alternativement, utilisez un service/API qui prend en charge les paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l’ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/cpp/password-protected-presentation/) pour le PPT enregistré.