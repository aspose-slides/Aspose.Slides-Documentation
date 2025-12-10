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
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides pour C++—assurez une compatibilité transparente avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT à l'aide de C++. Le sujet suivant est couvert.

- Convertir PPTX en PPT avec C++

## **Convertir PPTX en PPT avec C++**

Pour le code d'exemple C++ permettant de convertir PPTX en PPT, veuillez consulter la section ci‑dessous, à savoir [Convertir PPTX en PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme indiqué dans ces articles.

- [C++ Convertir PPTX en PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Convertir PPTX en XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Convertir PPTX en HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Convertir PPTX en ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Convertir PPTX en Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, transmettez simplement le nom du fichier et le format d'enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). L'exemple de code C++ ci‑dessous convertit une Presentation du PPTX au PPT en utilisant les options par défaut.
```cpp
// Charger le PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Enregistrer au format PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Toutes les effets et fonctionnalités PPTX sont‑ils conservés lors de l'enregistrement au format PPT (97–2003) hérité ?**

Pas toujours. Le format PPT ne possède pas certaines capacités plus récentes (par exemple, certains effets, objets et comportements), de sorte que les fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT plutôt que la présentation entière ?**

L'enregistrement direct cible toute la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la au format PPT ; sinon, utilisez un service/API qui prend en charge des paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l'ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/cpp/password-protected-presentation/) pour le PPT enregistré.