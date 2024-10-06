---
title: Convertir PPTX en PPT en C++
linktitle: Convertir PPTX en PPT
type: docs
weight: 21
url: /cpp/convert-pptx-to-ppt/
keywords: "C++ Convertir PPTX en PPT, Convertir Présentation PowerPoint, PPTX en PPT, Python, Aspose.Slides"
description: "Convertir PowerPoint PPTX en PPT en C++"
---

## **Aperçu**

Cet article explique comment convertir une Présentation PowerPoint au format PPTX en format PPT en utilisant C++. Le sujet suivant est traité.

- Convertir PPTX en PPT en C++

## **C++ Convertir PPTX en PPT**

Pour du code d'échantillon en C++ pour convertir PPTX en PPT, veuillez consulter la section ci-dessous c'est-à-dire [Convertir PPTX en PPT](#convert-pptx-to-ppt). Cela charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc. comme discuté dans ces articles.

- [C++ Convertir PPTX en PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Convertir PPTX en XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Convertir PPTX en HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Convertir PPTX en ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Convertir PPTX en Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, il suffit de passer le nom du fichier et le format d'enregistrement à la méthode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). L'exemple de code C++ ci-dessous convertit une Présentation de PPTX en PPT en utilisant les options par défaut.

```cpp
// Charger le PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Enregistrer au format PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```