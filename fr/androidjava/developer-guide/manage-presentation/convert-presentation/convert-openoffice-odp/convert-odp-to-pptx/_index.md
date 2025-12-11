---
title: Convertir ODP en PPTX sur Android
linktitle: ODP en PPTX
type: docs
weight: 10
url: /fr/androidjava/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir ODP
- OpenDocument en PPTX
- ODP en PPTX
- enregistrer ODP en PPTX
- exporter ODP en PPTX
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertir ODP en PPTX avec Aspose.Slides pour Android. Exemples de code Java clairs, astuces par lots et résultats de haute qualité—pas besoin de PowerPoint."
---

## **Convertir ODP en présentation PPTX/PPT**
Aspose.Slides for Android via Java propose la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui représente un fichier de présentation. La classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) peut désormais également accéder aux fichiers ODP via le constructeur [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.
```java
// Ouvrir le fichier ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Enregistrer la présentation ODP au format PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exemple en direct**
Vous pouvez visiter l'application web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) qui est construite avec **Aspose.Slides API**. L'application montre comment la conversion ODP vers PPTX peut être implémentée avec Aspose.Slides API.

## **FAQ**

**Dois‑je installer Microsoft PowerPoint ou LibreOffice pour convertir ODP en PPTX ?**

Non. Aspose.Slides fonctionne de manière autonome et ne nécessite aucune application tierce pour lire ou écrire des fichiers ODP/PPTX.

**Les diapositives maîtres, les mises en page et les thèmes sont‑ils conservés lors de la conversion ?**

Oui. La bibliothèque utilise un modèle d'objet de présentation complet et conserve la structure, y compris les diapositives maîtres et les mises en page, de sorte que le design reste correct après la conversion.

**Puis‑je convertir des fichiers ODP protégés par mot de passe ?**

Oui. Aspose.Slides prend en charge la détection de protection, l'ouverture et le travail avec les [présentations protégées](/slides/fr/androidjava/password-protected-presentation/) (y compris ODP) lorsque vous fournissez le mot de passe, ainsi que la configuration du chiffrement et l'accès aux propriétés du document.

**Aspose.Slides convient‑il aux services de conversion cloud ou basés sur REST ?**

Oui. Vous pouvez utiliser la bibliothèque locale dans votre propre back‑end ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (API REST) ; les deux options prennent en charge la conversion ODP → PPTX.