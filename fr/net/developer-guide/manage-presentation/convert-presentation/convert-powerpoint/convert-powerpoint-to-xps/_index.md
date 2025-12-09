---
title: Convertir des présentations PowerPoint en XPS avec .NET
linktitle: PowerPoint vers XPS
type: docs
weight: 70
url: /fr/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "Convertissez les fichiers PowerPoint PPT/PPTX en XPS de haute qualité et indépendant de la plateforme avec .NET en utilisant Aspose.Slides. Obtenez un guide étape par étape et un exemple de code C#."
---

## **À propos de XPS**
Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme alternative à [PDF](https://docs.fileformat.com/pdf/). Il vous permet d'imprimer du contenu en générant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d'un fichier XPS reste identique sur tous les systèmes d'exploitation et les imprimantes. 

## **Quand utiliser le format Microsoft XPS**

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit les présentations PPT ou PPTX au format XPS, vous pouvez consulter [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si vous souhaitez réduire les coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint au format XPS. Ainsi, il vous sera plus facile d'enregistrer, de partager et d'imprimer vos documents. 

Microsoft continue d'offrir une prise en charge solide de XPS sous Windows (même sous Windows 10), vous pourriez donc envisager d'enregistrer les fichiers dans ce format. Si vous travaillez avec Windows 8.1, Windows 8, Windows 7 et Windows Vista, XPS pourrait en fait être votre meilleure option pour certaines opérations. 

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version standardisée du format XPS original. Windows 8 offre une meilleure prise en charge des fichiers XPS que des fichiers PDF. 
  - **XPS**: visionneuse/lecteur XPS intégré et fonction d'impression vers XPS disponible. 
  - **PDF**: lecteur PDF disponible mais aucune fonction d'impression vers PDF. 

- **Windows 7 et Windows Vista** utilisent le format XPS original. Ces systèmes d'exploitation offrent également une meilleure prise en charge des fichiers XPS que des PDF. 
  - **XPS**: visionneuse XPS intégrée et fonction d'impression vers XPS disponible. 
  - **PDF**: Aucun lecteur PDF. Aucune fonction d'impression vers PDF. 

|<p>**Entrée PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft a finalement implémenté la prise en charge des opérations d'impression en PDF via la fonction Imprimer en PDF sous Windows 10. Auparavant, les utilisateurs devaient imprimer les documents via le format XPS. 

## **Conversion XPS avec Aspose.Slides**

Dans [**Aspose.Slides**](https://products.aspose.com/slides/net/) pour .NET, vous pouvez utiliser la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides.presentation) pour convertir l'intégralité de la présentation en document XPS. 

Lors de la conversion d'une présentation en XPS, vous devez enregistrer la présentation en utilisant l'un de ces paramètres : 

- Paramètres par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions)) 
- Paramètres personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions)) 

### **Conversion de présentations en XPS avec les paramètres par défaut**

Ce code d'exemple en C# montre comment convertir une présentation en document XPS en utilisant les paramètres standard :
```c#
// Instanciez un objet Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Enregistrement de la présentation vers un document XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Conversion de présentations en XPS avec des paramètres personnalisés**

Ce code d'exemple montre comment convertir une présentation en document XPS en utilisant des paramètres personnalisés en C# :
```c#
// Instancier un objet Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instancier la classe TiffOptions
    XpsOptions options = new XpsOptions();

    // Enregistrer les MetaFiles en PNG
    options.SaveMetafilesAsPng = true;

    // Enregistrer la présentation en document XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **FAQ**

**Puis-je enregistrer le XPS dans un flux au lieu d'un fichier ?**

Oui—Aspose.Slides vous permet d'exporter directement vers un flux, ce qui est idéal pour les API web, les pipelines côté serveur, ou tout scénario où vous souhaitez transmettre le XPS sans toucher au système de fichiers. 

**Les diapositives masquées sont-elles transférées vers le XPS, et puis-je les exclure ?**

Par défaut, seules les diapositives normales (visibles) sont rendues. Vous pouvez [inclure ou exclure les diapositives masquées](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) via les [paramètres d'exportation](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) avant d'enregistrer en XPS, garantissant que la sortie contient exactement les pages souhaitées.