---
title: Convertir ODP en PPTX en Python
linktitle: ODP en PPTX
type: docs
weight: 10
url: /fr/python-net/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir ODP
- OpenDocument en PPTX
- ODP en PPTX
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Convertissez ODP en PPTX avec Aspose.Slides pour Python via .NET. Exemples de code clairs, astuces de traitement par lot et résultats de haute qualité — aucun PowerPoint requis."
---

## **Exporter ODP en PPTX**

Aspose.Slides for Python via .NET propose la classe Presentation qui représente un fichier de présentation. [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe peut désormais également accéder aux fichiers ODP via le constructeur Presentation lors de l'instanciation de l'objet. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.
```py
# Importer le module Aspose.Slides for Python via .NET
import aspose.slides as slides

# Ouvrir le fichier ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Enregistrer la présentation ODP au format PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Exemple en direct**

Vous pouvez visiter l'application web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), qui est construite avec **Aspose.Slides API.** L'application montre comment la conversion ODP en PPTX peut être implémentée avec Aspose.Slides API.

## **FAQ**

**Dois‑je installer Microsoft PowerPoint ou LibreOffice pour convertir ODP en PPTX ?**

Non. Aspose.Slides fonctionne de manière autonome et ne nécessite aucune application tierce pour lire ou écrire des fichiers ODP/PPTX.

**Les diapositives maîtres, les mises en page et les thèmes sont‑ils conservés lors de la conversion ?**

Oui. La bibliothèque utilise un modèle d'objet de présentation complet et conserve la structure, y compris les diapositives maîtres et les mises en page, de sorte que le design reste correct après la conversion.

**Puis‑je convertir des fichiers ODP protégés par mot de passe ?**

Oui. Aspose.Slides prend en charge la détection de protection, l'ouverture et la manipulation des [presentations protégées](/slides/fr/python-net/password-protected-presentation/) (y compris les ODP) lorsque vous fournissez le mot de passe, ainsi que la configuration du chiffrement et l'accès aux propriétés du document.

**Aspose.Slides convient‑il aux services de conversion cloud ou basés sur REST ?**

Oui. Vous pouvez utiliser la bibliothèque locale dans votre propre backend ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API) ; les deux options prennent en charge la conversion ODP → PPTX.