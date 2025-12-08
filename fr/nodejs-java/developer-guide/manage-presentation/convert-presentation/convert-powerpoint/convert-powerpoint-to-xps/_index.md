---
title: Convertir PowerPoint en XPS
type: docs
weight: 70
url: /fr/nodejs-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX en XPS"
description: "Convertir PowerPoint PPT(X) en XPS en JavaScript"
---

## **À propos de XPS**

Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme une alternative à [PDF](https://docs.fileformat.com/pdf/). Il vous permet d’imprimer du contenu en générant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d’un fichier XPS reste identique sur tous les systèmes d’exploitation et toutes les imprimantes. 

## **Quand utiliser le format Microsoft XPS**

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit une présentation PPT ou PPTX au format XPS, vous pouvez consulter [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si vous souhaitez réduire les coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint au format XPS. Ainsi, vous trouverez plus facile d’enregistrer, de partager et d’imprimer vos documents. 

Microsoft continue d’assurer une prise en charge solide de XPS sous Windows (même sous Windows 10), vous pourriez donc envisager d’enregistrer les fichiers dans ce format. Si vous travaillez avec Windows 8.1, Windows 8, Windows 7 ou Windows Vista, XPS pourrait en fait être votre meilleure option pour certaines opérations. 

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version standardisée du format XPS original. Windows 8 offre une meilleure prise en charge des fichiers XPS que des fichiers PDF. 
  - **XPS** : Visionneuse/lecteur XPS intégré et fonction d’impression vers XPS disponible. 
  - **PDF** : Lecteur PDF disponible mais aucune fonction d’impression vers PDF. 

- **Windows 7 et Windows Vista** utilisent le format XPS original. Ces systèmes d’exploitation offrent également une meilleure prise en charge des fichiers XPS que des PDF. 
  - **XPS** : Visionneur XPS intégré et fonction d’impression vers XPS disponible. 
  - **PDF** : Aucun lecteur PDF. Aucun fonction d’impression vers PDF. 

|<p>**Entrée PPT(X) :**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS :**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft a finalement implémenté la prise en charge des opérations d’impression en PDF grâce à la fonction Imprimer en PDF sous Windows 10. Auparavant, on s’attendait à ce que les utilisateurs impriment les documents via le format XPS. 

## **Conversion XPS avec Aspose.Slides**

Dans [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), vous pouvez utiliser la méthode [**save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) pour convertir l’ensemble de la présentation en document XPS.

Lors de la conversion d’une présentation en XPS, vous devez enregistrer la présentation en utilisant l’un de ces paramètres :

- Paramètres par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))
- Paramètres personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))

### **Conversion de présentations en XPS avec les paramètres par défaut**

Ce code d’exemple en JavaScript montre comment convertir une présentation en document XPS en utilisant les paramètres standards :
```javascript
// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Enregistrement de la présentation dans un document XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```



### **Conversion de présentations en XPS avec des paramètres personnalisés**
Ce code d’exemple montre comment convertir une présentation en document XPS en utilisant des paramètres personnalisés en JavaScript :
```javascript
// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Instancier la classe TiffOptions
    var options = new aspose.slides.XpsOptions();
    // Enregistrer les MetaFiles en PNG
    options.setSaveMetafilesAsPng(true);
    // Enregistrer la présentation dans un document XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je enregistrer en XPS dans un flux plutôt que dans un fichier ?**

Oui — Aspose.Slides vous permet d’exporter directement vers un flux, ce qui est idéal pour les API Web, les pipelines côté serveur, ou tout scénario où vous souhaitez envoyer le XPS sans toucher au système de fichiers.

**Les diapositives masquées sont‑elles conservées dans le XPS, et puis‑je les exclure ?**

Par défaut, seules les diapositives régulières (visibles) sont rendues. Vous pouvez [inclure ou exclure les diapositives masquées](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) via les [paramètres d’exportation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) avant d’enregistrer en XPS, garantissant que la sortie contient exactement les pages que vous souhaitez.