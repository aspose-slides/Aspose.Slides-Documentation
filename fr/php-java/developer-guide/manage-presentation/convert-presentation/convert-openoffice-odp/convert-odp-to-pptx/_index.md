---
title: Convertir ODP en PPTX en PHP
linktitle: ODP en PPTX
type: docs
weight: 10
url: /fr/php-java/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir ODP
- OpenDocument en PPTX
- ODP en PPTX
- enregistrer ODP en tant que PPTX
- exporter ODP en PPTX
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Convertir ODP en PPTX avec Aspose.Slides pour PHP via Java. Exemples de code clairs, astuces de traitement par lots et résultats de haute qualité - aucune PowerPoint nécessaire."
---

## **Convertir ODP en présentation PPTX/PPT**
Aspose.Slides for PHP via Java propose la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui représente un fichier de présentation. La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) peut désormais accéder aux fichiers ODP via le constructeur [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) lorsque l’objet est instancié. L’exemple suivant montre comment convertir une présentation ODP en présentation PPTX.
```php
// Ouvrir le fichier ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Enregistrement de la présentation ODP au format PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Exemple en direct**
Vous pouvez visiter l’application web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) qui est construite avec **Aspose.Slides API**. L’application montre comment la conversion ODP en PPTX peut être implémentée avec l’API Aspose.Slides.

## **FAQ**

**Dois‑je installer Microsoft PowerPoint ou LibreOffice pour convertir ODP en PPTX ?**

Non. Aspose.Slides fonctionne de manière autonome et ne nécessite aucune application tierce pour lire ou écrire des fichiers ODP/PPTX.

**Les diapositives maîtres, les mises en page et les thèmes sont‑ils conservés lors de la conversion ?**

Oui. La bibliothèque utilise un modèle d’objet complet de présentation et conserve la structure, y compris les diapositives maîtres et les mises en page, de sorte que le design reste correct après la conversion.

**Puis‑je convertir des fichiers ODP protégés par mot de passe ?**

Oui. Aspose.Slides prend en charge la détection de la protection, l’ouverture et le travail avec les [presentations protégées](/slides/fr/php-java/password-protected-presentation/) (y compris ODP) lorsque vous fournissez le mot de passe, ainsi que la configuration du chiffrement et l’accès aux propriétés du document.

**Aspose.Slides convient‑il aux services de conversion cloud ou basés sur REST ?**

Oui. Vous pouvez utiliser la bibliothèque locale dans votre propre backend ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (API REST) ; les deux options prennent en charge la conversion ODP → PPTX.