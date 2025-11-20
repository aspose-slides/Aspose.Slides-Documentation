---
title: Convertir PPTX en PPT avec Python
linktitle: PPTX en PPT
type: docs
weight: 21
url: /fr/python-net/convert-pptx-to-ppt/
keywords:
- PPTX en PPT
- convertir PPTX en PPT
- convertir PowerPoint
- convertir une présentation
- Python
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides for Python via .NET — assurez une compatibilite fluide avec les formats PowerPoint tout en preservant la mise en page et la qualite de votre presentation."
---

## **Vue d’ensemble**

Aspose.Slides for Python vous permet de convertir des présentations PPTX modernes au format PPT hérité entièrement par code. Ouvrez un PPTX et exportez-le en PPT tout en conservant le contenu et la mise en page de la présentation, ce qui rend le résultat compatible avec les versions plus anciennes de PowerPoint. Le même flux de travail peut produire d’autres sorties — telles que PDF, XPS, ODP, HTML ou images — de sorte qu’il s’intègre facilement aux scripts, aux pipelines CI et au traitement par lots.

## **Convertir PPTX en PPT**

Pour convertir un PPTX en PPT, il suffit de transmettre le nom du fichier et le format d’enregistrement à la méthode [enregistrer](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) . L’exemple Python ci‑dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
presentation = slides.Presentation("presentation.pptx")

# Enregistrer la présentation au format PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```


## **FAQ**

**Tous les effets et fonctionnalités PPTX sont‑ils conservés lors de l’enregistrement au format PPT hérité (97–2003) ?**

Pas toujours. Le format PPT ne possède pas certaines capacités plus récentes (par ex. certains effets, objets et comportements), de sorte que les fonctionnalités peuvent être simplifiées ou rasterisées pendant la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT au lieu de toute la présentation ?**

L’enregistrement direct cible l’ensemble de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la en PPT ; alternativement, utilisez un service/API qui prend en charge des paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l’ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/python-net/password-protected-presentation/) pour le PPT enregistré.

**Voir aussi :**
- [Convertir PPT et PPTX en PDF avec Python | Options avancées](/slides/fr/python-net/convert-powerpoint-to-pdf/)
- [Convertir les présentations PowerPoint en XPS avec Python](/slides/fr/python-net/convert-powerpoint-to-xps/)
- [Convertir les présentations PowerPoint en HTML avec Python](/slides/fr/python-net/convert-powerpoint-to-html/)
- [Convertir les diapositives PowerPoint en PNG avec Python](/slides/fr/python-net/convert-powerpoint-to-png/)