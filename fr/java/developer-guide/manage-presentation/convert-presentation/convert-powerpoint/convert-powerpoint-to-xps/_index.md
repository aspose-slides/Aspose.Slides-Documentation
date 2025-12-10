---
title: Convertir des présentations PowerPoint en XPS avec Java
linktitle: PowerPoint vers XPS
type: docs
weight: 70
url: /fr/java/convert-powerpoint-to-xps/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers XPS
- présentation vers XPS
- diapositive vers XPS
- PPT vers XPS
- PPTX vers XPS
- enregistrer PPT en XPS
- enregistrer PPTX en XPS
- exporter PPT en XPS
- exporter PPTX en XPS
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Convertissez les fichiers PowerPoint PPT/PPTX en XPS de haute qualité et indépendants de la plateforme avec Java en utilisant Aspose.Slides. Obtenez un guide étape par étape et du code d'exemple."
---

## **À propos de XPS**
Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme une alternative à [PDF](https://docs.fileformat.com/pdf/). Il vous permet d'imprimer du contenu en générant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d'un fichier XPS reste la même sur tous les systèmes d'exploitation et imprimantes. 

## **Quand utiliser le format XPS de Microsoft**

{{% alert color="primary" %}} 
Pour voir comment Aspose.Slides convertit les présentations PPT ou PPTX au format XPS, vous pouvez consulter [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

Si vous souhaitez réduire les coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint au format XPS. Ainsi, il vous sera plus facile d'enregistrer, de partager et d'imprimer vos documents. 

Microsoft continue d'implémenter un support fort pour XPS sous Windows (même sous Windows 10), vous pourriez donc envisager d'enregistrer les fichiers dans ce format. Si vous travaillez avec Windows 8.1, Windows 8, Windows 7 et Windows Vista, XPS pourrait en fait être votre meilleure option pour certaines opérations. 

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version standardisée du format XPS original. Windows 8 offre un meilleur support des fichiers XPS que des fichiers PDF. 
  - **XPS** : visionneuse/lecteur XPS intégré et fonction d’impression vers XPS disponible. 
  - **PDF** : lecteur PDF disponible mais aucune fonction d’impression vers PDF. 

- **Windows 7 et Windows Vista** utilisent le format XPS original. Ces systèmes d'exploitation offrent également un meilleur support des fichiers XPS que des PDF. 
  - **XPS** : visionneuse XPS intégrée et fonction d’impression vers XPS disponible. 
  - **PDF** : aucun lecteur PDF. aucune fonction d’impression vers PDF. 

|<p>**Entrée PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft a finalement implémenté le support des opérations d’impression en PDF via la fonction Imprimer en PDF sous Windows 10. Auparavant, les utilisateurs devaient imprimer les documents via le format XPS. 

## **Conversion XPS avec Aspose.Slides**

Dans [**Aspose.Slides**](https://products.aspose.com/slides/java/) pour Java, vous pouvez utiliser la méthode [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) pour convertir l'intégralité de la présentation en document XPS. 

Lors de la conversion d’une présentation en XPS, vous devez enregistrer la présentation en utilisant l’une de ces configurations :
- Paramètres par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))
- Paramètres personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))

### **Convertir des présentations en XPS avec les paramètres par défaut**

Ce code d’exemple en Java vous montre comment convertir une présentation en document XPS en utilisant les paramètres standards :
```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Enregistrement de la présentation au format XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Convertir des présentations en XPS avec des paramètres personnalisés**
Ce code d’exemple vous montre comment convertir une présentation en document XPS en utilisant des paramètres personnalisés en Java :
```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instancier la classe TiffOptions
    XpsOptions options = new XpsOptions();

    // Enregistrer les MetaFiles en PNG
    options.setSaveMetafilesAsPng(true);

    // Enregistrer la présentation dans un document XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis-je enregistrer le XPS dans un flux plutôt que dans un fichier ?**

Oui—Aspose.Slides vous permet d’exporter directement vers un flux, ce qui est idéal pour les API web, les pipelines côté serveur, ou tout scénario où vous souhaitez envoyer le XPS sans toucher au système de fichiers.

**Les diapositives masquées sont‑elles transférées vers le XPS, et puis‑je les exclure ?**

Par défaut, seules les diapositives ordinaires (visibles) sont rendues. Vous pouvez [inclure ou exclure les diapositives masquées](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) via les [paramètres d’exportation](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/) avant d’enregistrer en XPS, garantissant que la sortie contient exactement les pages que vous souhaitez.