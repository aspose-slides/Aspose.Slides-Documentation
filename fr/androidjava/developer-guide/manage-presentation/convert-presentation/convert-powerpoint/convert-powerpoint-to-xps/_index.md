---
title: Convertir PowerPoint en XPS
type: docs
weight: 70
url: /androidjava/convert-powerpoint-to-xps/
keywords: "PPT, PPTX en XPS"
description: "Convertir PowerPoint PPT(X) en XPS en Java"
---

## **À propos de XPS**
Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme une alternative au [PDF](https://docs.fileformat.com/pdf/). Il vous permet d'imprimer du contenu en produisant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d'un fichier XPS reste la même sur tous les systèmes d'exploitation et imprimantes. 

## Quand utiliser le format XPS de Microsoft

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit une présentation PPT ou PPTX en format XPS, vous pouvez consulter [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si vous souhaitez réduire les coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint en format XPS. Ainsi, vous trouverez plus facile de sauvegarder, partager et imprimer vos documents. 

Microsoft continue de mettre en œuvre un support solide pour XPS dans Windows (même dans Windows 10), donc vous voudrez peut-être envisager d'enregistrer des fichiers dans ce format. Si vous utilisez Windows 8.1, Windows 8, Windows 7 et Windows Vista, alors XPS pourrait en réalité être votre meilleure option pour certaines opérations. 

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version standardisée du format XPS original. Windows 8 offre un meilleur support pour les fichiers XPS que pour les fichiers PDF. 
  - **XPS:** Visionneuse/lecteur XPS intégré et fonction d'impression vers XPS disponible. 
  - **PDF**: Lecteur PDF disponible mais pas de fonction d'impression vers PDF. 

-  **Windows 7 et Windows Vista** utilisent le format XPS original. Ces systèmes d'exploitation offrent également un meilleur support pour les fichiers XPS que pour les PDF. 
  - **XPS**: Visionneuse XPS intégrée et fonction d'impression vers XPS disponible. 
  - **PDF**: Pas de lecteur PDF. Pas de fonction d'impression vers PDF. 

|<p>**Entrée PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft a finalement mis en œuvre un support pour les opérations d'impression en PDF grâce à la fonction Imprimer en PDF dans Windows 10. Auparavant, les utilisateurs devaient imprimer des documents via le format XPS. 

## Conversion XPS avec Aspose.Slides

Dans [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) pour Java, vous pouvez utiliser la méthode [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) pour convertir l'ensemble de la présentation en un document XPS.

Lors de la conversion d'une présentation en XPS, vous devez enregistrer la présentation en utilisant l'un de ces paramètres :

- Paramètres par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))
- Paramètres personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))

### **Conversion de présentations en XPS en utilisant les paramètres par défaut**

Ce code d'exemple en Java vous montre comment convertir une présentation en un document XPS en utilisant les paramètres standards :

```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Enregistrer la présentation en document XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Conversion de présentations en XPS en utilisant des paramètres personnalisés**
Cet exemple de code vous montre comment convertir une présentation en un document XPS en utilisant des paramètres personnalisés en Java :

```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instancier la classe TiffOptions
    XpsOptions options = new XpsOptions();

    // Enregistrer les MetaFiles en tant que PNG
    options.setSaveMetafilesAsPng(true);

    // Enregistrer la présentation en document XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```