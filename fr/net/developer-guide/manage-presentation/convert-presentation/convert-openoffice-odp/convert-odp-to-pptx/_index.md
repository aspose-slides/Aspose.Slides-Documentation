---
title: Convertir ODP en PPTX avec .NET
linktitle: ODP en PPTX
type: docs
weight: 10
url: /fr/net/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir ODP
- OpenDocument en PPTX
- ODP en PPTX
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Convertir ODP en PPTX avec Aspose.Slides pour .NET. Exemples de code C# propres, astuces de traitement par lots, et résultats de haute qualité — aucune PowerPoint requis."
---

## **Vue d'ensemble**

Cet article explique les sujets suivants.

- [C# Convertir ODP en PPTX](#csharp-odp-to-pptx)
- [C# Convertir ODP en PowerPoint](#csharp-odp-to-powerpoint)

## **Conversion ODP en PPTX**

Aspose.Slides pour .NET propose la classe **Presentation** qui représente un fichier de présentation. La classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut désormais aussi accéder aux fichiers ODP via le constructeur Presentation lors de l'instanciation de l'objet. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Étapes : Convertir ODP en PPTX en C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Étapes : Convertir ODP en PowerPoint en C#</strong></a>
```c#
// Ouvrir le fichier ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Enregistrement de la présentation ODP au format PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Exemple en direct**

Vous pouvez visiter l'application Web [**Conversion Aspose.Slides**](https://products.aspose.app/slides/conversion/) qui est construite avec **Aspose.Slides API**. L'application montre comment la conversion ODP en PPTX peut être implémentée avec l'API Aspose.Slides.

## **FAQ**

**Dois-je installer Microsoft PowerPoint ou LibreOffice pour convertir ODP en PPTX ?**

Non. Aspose.Slides fonctionne de façon autonome et ne nécessite aucune application tierce pour lire ou écrire des fichiers ODP/PPTX.

**Les diapositives maîtres, les dispositions et les thèmes sont-ils conservés lors de la conversion ?**

Oui. La bibliothèque utilise un modèle d'objet de présentation complet et conserve la structure, y compris les diapositives maîtres et les dispositions, de sorte que le design reste correct après la conversion.

**Puis-je convertir des fichiers ODP protégés par mot de passe ?**

Oui. Aspose.Slides prend en charge la détection de la protection, l'ouverture et le traitement des [présentations protégées](/slides/fr/net/password-protected-presentation/) (y compris ODP) quand vous fournissez le mot de passe, ainsi que la configuration du chiffrement et l'accès aux propriétés du document.

**Aspose.Slides est-il adapté aux services de conversion cloud ou basés sur REST ?**

Oui. Vous pouvez utiliser la bibliothèque locale dans votre propre backend ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API) ; les deux options prennent en charge la conversion ODP → PPTX.