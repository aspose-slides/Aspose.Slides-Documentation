---
title: Convertir les présentations PowerPoint en XPS en Java
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
description: "Convertir les fichiers PowerPoint PPT/PPTX en XPS de haute qualité et indépendant de la plate-forme en Java avec Aspose.Slides. Obtenez un guide étape par étape et du code d'exemple."
---
## **Aperçu**

Aspose.Slides vous permet de convertir des présentations PowerPoint en XPS en enregistrant un fichier PPT ou PPTX au format XPS. Cet article explique quand le format XPS peut être utile et montre comment effectuer la conversion avec Aspose.Slides en utilisant les paramètres par défaut ou des paramètres personnalisés [XpsOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xpsoptions/).

## **À propos de XPS**
Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme alternative au [PDF](https://docs.fileformat.com/pdf/). Il vous permet d’imprimer du contenu en générant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d’un fichier XPS reste identique sur tous les systèmes d’exploitation et toutes les imprimantes. 

## **Quand utiliser le format XPS de Microsoft**

{{% alert color="info" %}} 

Pour voir comment Aspose.Slides convertit une présentation PPT ou PPTX au format XPS, vous pouvez essayer [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/fr/conversion). 

{{% /alert %}} 

Si vous souhaitez réduire les coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint au format XPS. Vous la sauvegarderez, la partagerez et l’imprimerez plus facilement. 

Microsoft continue d’offrir une prise en charge solide de XPS sous Windows (même sous Windows 10), il peut donc être judicieux d’enregistrer les fichiers dans ce format. Si vous utilisez Windows 8.1, Windows 8, Windows 7 ou Windows Vista, le XPS pourrait être votre meilleure option pour certaines opérations. 

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version normalisée du format XPS original. Windows 8 offre un meilleur support des fichiers XPS que des fichiers PDF. 
  - **XPS** : visionneuse/lecteur XPS intégré et fonction d’impression vers XPS disponible. 
  - **PDF** : lecteur PDF disponible mais aucune fonction d’impression vers PDF. 

- **Windows 7** et **Windows Vista** utilisent le format XPS original. Ces systèmes d’exploitation offrent également un meilleur support des fichiers XPS que des PDF. 
  - **XPS** : visionneuse XPS intégrée et fonction d’impression vers XPS disponible. 
  - **PDF** : aucun lecteur PDF. Pas de fonction d’impression vers PDF. 

|<p>**Entrée PPT(X) :**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS :**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft a finalement ajouté la prise en charge des opérations d’impression en PDF grâce à la fonctionnalité Imprimer en PDF sous Windows 10. Auparavant, les utilisateurs devaient imprimer les documents via le format XPS. 

## **Conversion XPS avec Aspose.Slides**

Dans [**Aspose.Slides**](https://products.aspose.com/slides/fr/java/) pour Java, vous pouvez utiliser la méthode [**Save**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) pour convertir l’ensemble de la présentation en document XPS. 

Lors de la conversion d’une présentation en XPS, vous devez enregistrer la présentation en utilisant l’un de ces paramètres :

- Paramètres par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xpsoptions))
- Paramètres personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xpsoptions))

### **Convertir les présentations en XPS avec les paramètres par défaut**

Ce code d’exemple en Java montre comment convertir une présentation en document XPS avec les paramètres standards :

```java
import com.aspose.slides.*;

// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Enregistrement de la présentation au format XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convertir les présentations en XPS avec des paramètres personnalisés**
Ce code d’exemple montre comment convertir une présentation en document XPS avec des paramètres personnalisés en Java :

```java
import com.aspose.slides.*;

// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instancier la classe XpsOptions
    XpsOptions options = new XpsOptions();

    // Enregistrer les métafichiers en PNG
    options.setSaveMetafilesAsPng(true);

    // Enregistrer la présentation au format XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Puis-je enregistrer le XPS dans un flux au lieu d’un fichier ?

Oui — Aspose.Slides vous permet d’exporter directement vers un flux, ce qui est idéal pour les API web, les pipelines côté serveur ou tout scénario où vous devez transmettre le XPS sans toucher au système de fichiers.

### Les diapositives masquées sont‑elles reprises dans le XPS, et puis‑je les exclure ?

Par défaut, seules les diapositives régulières (visibles) sont rendues. Vous pouvez [inclure ou exclure les diapositives masquées](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) via les [paramètres d’exportation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xpsoptions/) avant d’enregistrer en XPS, assurant que la sortie contient exactement les pages souhaitées.