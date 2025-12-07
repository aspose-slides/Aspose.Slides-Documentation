---
title: Convertir ODP en PPTX en C++
linktitle: ODP en PPTX
type: docs
weight: 10
url: /fr/cpp/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir ODP
- OpenDocument en PPTX
- ODP en PPTX
- enregistrer ODP comme PPTX
- exporter ODP vers PPTX
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Convertir ODP en PPTX avec Aspose.Slides pour C++. Exemples de code clairs, conseils pour le traitement par lot et résultats de haute qualité — aucune nécessité de PowerPoint."
---

## **Conversion ODP en PPTX**

Aspose.Slides for .NET propose la classe Presentation qui représente un fichier de présentation. La classe [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) peut désormais accéder aux fichiers ODP via le constructeur Presentation lors de l'instanciation de l'objet. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.
``` cpp
// Le chemin du répertoire des documents.
String dataDir = GetDataPath();

// Ouvrir le fichier ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Enregistrement de la présentation ODP au format PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Exemple en direct**

Vous pouvez visiter l'application web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), qui est construite avec **Aspose.Slides API**. L'application démontre comment la conversion ODP en PPTX peut être implémentée avec l'Aspose.Slides API.

## **FAQ**

**Dois‑je installer Microsoft PowerPoint ou LibreOffice pour convertir ODP en PPTX ?**

Non. Aspose.Slides fonctionne de façon autonome et ne nécessite aucune application tierce pour lire ou écrire des fichiers ODP/PPTX.

**Les masques de diapositives, les mises en page et les thèmes sont‑ils conservés lors de la conversion ?**

Oui. La bibliothèque utilise un modèle complet d'objet de présentation et conserve la structure, y compris les masques de diapositives et les mises en page, de sorte que le design reste correct après la conversion.

**Puis‑je convertir des fichiers ODP protégés par mot de passe ?**

Oui. Aspose.Slides supporte la détection de protection, l'ouverture et la manipulation des [presentations protégées](/slides/fr/cpp/password-protected-presentation/) (y compris ODP) lorsque vous fournissez le mot de passe, ainsi que la configuration du chiffrement et l'accès aux propriétés du document.

**Aspose.Slides convient‑il aux services de conversion cloud ou basés sur REST ?**

Oui. Vous pouvez utiliser la bibliothèque locale dans votre propre backend ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API) ; les deux options supportent la conversion ODP → PPTX.