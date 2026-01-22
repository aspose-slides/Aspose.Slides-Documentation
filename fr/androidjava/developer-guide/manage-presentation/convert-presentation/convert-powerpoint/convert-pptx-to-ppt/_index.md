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
- exporter PPTX en PPT
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides pour Android via Java — assurez une compatibilité fluide avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT a l'aide de Java. Le sujet suivant est couvre.

- Convertir PPTX en PPT avec Java

## **Convertir PPTX en PPT sur Android**

Pour le code d'exemple Java permettant de convertir PPTX en PPT, veuillez consulter la section ci-desous, c'est-a-dire[Convertir PPTX en PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En specifiant differentes formats d'enregistrement, vous pouvez egalement enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme discute dans ces articles.

- [Convertir PPTX en PDF sur Android](/slides/fr/androidjava/convert-powerpoint-to-pdf/)
- [Convertir PPTX en XPS sur Android](/slides/fr/androidjava/convert-powerpoint-to-xps/)
- [Convertir PPTX en HTML sur Android](/slides/fr/androidjava/convert-powerpoint-to-html/)
- [Convertir PPTX en ODP sur Android](/slides/fr/androidjava/save-presentation/)
- [Convertir PPTX en PNG sur Android](/slides/fr/androidjava/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**

Pour convertir un PPTX en PPT, il suffit de transmettre le nom du fichier et le format d'enregistrement a la methode **Save** de la classe [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). L'exemple de code Java ci-desous convertit une presentation de PPTX en PPT en utilisant les options par defaut.
```java
// instancier un objet Presentation qui représente un fichier PPTX
Presentation presentation = new Presentation("template.pptx");

// enregistrer la présentation au format PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Tous les effets et fonctionnalites PPTX sont-ils conserves lors de l'enregistrement au format PPT heritage (97-2003) ?**

Pas toujours. Le format PPT ne possede pas certaines des capacites plus recentes (par-exemple, certains effets, objets et comportements), de sorte que les fonctionnalites peuvent etre simplifiees ou rasterisees lors de la conversion.

**Puis-je convertir uniquement des diapositives selectionnees en PPT au lieu de toute la presentation ?**

L'enregistrement direct cible l'ensemble de la presentation. Pour convertir des diapositives specifices, creez une nouvelle presentation contenant uniquement ces diapositives et enregistrez-la au format PPT; sinon, utilisez un service/API qui prend en charge des parametres de conversion par diapositive.

**Les presentations proteges par mot de passe sont-elles prises en charge ?**

Oui. Vous pouvez detecter si un fichier est protege, l'ouvrir avec un mot de passe, et egalement [configurer les parametres de protection/chiffrement](/slides/fr/androidjava/password-protected-presentation/) pour le PPT enregistre.