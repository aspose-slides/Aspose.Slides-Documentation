---
title: Convertir des présentations PowerPoint en XPS avec PHP
linktitle: PowerPoint en XPS
type: docs
weight: 70
url: /fr/php-java/convert-powerpoint-to-xps/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en XPS
- présentation en XPS
- diapositive en XPS
- PPT en XPS
- PPTX en XPS
- enregistrer PPT au format XPS
- enregistrer PPTX au format XPS
- exporter PPT en XPS
- exporter PPTX en XPS
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertir les fichiers PowerPoint PPT/PPTX en XPS de haute qualité, indépendant de la plateforme, à l’aide d'Aspose.Slides pour PHP via Java. Obtenez un guide étape par étape et un exemple de code."
---

## **À propos de XPS**
Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme une alternative à [PDF](https://docs.fileformat.com/pdf/).  Il vous permet d’imprimer du contenu en générant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d’un fichier XPS reste identique sur tous les systèmes d’exploitation et toutes les imprimantes. 

## **Quand utiliser le format Microsoft XPS**

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit une présentation PPT ou PPTX au format XPS, vous pouvez consulter [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si vous souhaitez réduire les coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint au format XPS. Ainsi, il vous sera plus facile d’enregistrer, de partager et d’imprimer vos documents. 

Microsoft continue d’assurer une prise en charge solide de XPS sous Windows (même sous Windows 10), il peut donc être judicieux d’enregistrer vos fichiers dans ce format. Si vous travaillez avec Windows 8.1, Windows 8, Windows 7 ou Windows Vista, le XPS pourrait être votre meilleure option pour certaines opérations. 

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version normalisée du format XPS d’origine. Windows 8 offre une meilleure prise en charge des fichiers XPS que des fichiers PDF. 
  - **XPS** : Visionneuse/lecteur XPS intégré et fonction d’impression en XPS disponible. 
  - **PDF** : Lecteur PDF disponible mais aucune fonction d’impression en PDF. 

- **Windows 7 et Windows Vista** utilisent le format XPS d’origine. Ces systèmes d’exploitation offrent également une meilleure prise en charge des fichiers XPS que des PDF. 
  - **XPS** : Visionneuse XPS intégrée et fonction d’impression en XPS disponible. 
  - **PDF** : Aucun lecteur PDF. Aucune fonction d’impression en PDF. 

|<p>**Entrée PPT(X) :**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS :**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft a finalement implémenté la prise en charge des opérations d’impression en PDF grâce à la fonction Imprimer en PDF sous Windows 10. Auparavant, les utilisateurs devaient imprimer les documents via le format XPS. 

## **Conversion XPS avec Aspose.Slides**

Dans [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) pour Java, vous pouvez utiliser la méthode [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) pour convertir l’ensemble de la présentation en document XPS.

Lors de la conversion d’une présentation en XPS, vous devez enregistrer la présentation en utilisant l’un de ces réglages :

- Réglages par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- Réglages personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **Convertir des présentations en XPS avec les réglages par défaut**

Ce code d’exemple montre comment convertir une présentation en document XPS en utilisant les paramètres standard :
```php
  # Instancier un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Enregistrement de la présentation au document XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Convertir des présentations en XPS avec des réglages personnalisés**
Ce code d’exemple montre comment convertir une présentation en document XPS en utilisant des paramètres personnalisés :
```php
  # Instancier un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Instancier la classe XpsOptions
    $options = new XpsOptions();
    # Enregistrer les MetaFiles en PNG
    $options->setSaveMetafilesAsPng(true);
    # Enregistrer la présentation au document XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis-je enregistrer en XPS dans un flux au lieu d’un fichier ?**

Oui — Aspose.Slides vous permet d’exporter directement vers un flux, ce qui est idéal pour les API web, les pipelines côté serveur ou tout scénario où vous devez transmettre le XPS sans toucher au système de fichiers.

**Les diapositives masquées sont‑elles transférées vers le XPS, et puis‑je les exclure ?**

Par défaut, seules les diapositives normales (visibles) sont rendues. Vous pouvez [inclure ou exclure les diapositives masquées](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) via les [paramètres d’exportation](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/) avant d’enregistrer en XPS, garantissant que la sortie contient exactement les pages que vous souhaitez.