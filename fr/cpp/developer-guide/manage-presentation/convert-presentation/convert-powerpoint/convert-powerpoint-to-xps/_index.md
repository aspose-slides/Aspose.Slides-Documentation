---
title: Convertir PowerPoint en XPS 
type: docs
weight: 70
url: /cpp/convert-powerpoint-to-xps
keywords: "Convertir, PowerPoint en XPS, Conversion, PPT en XPS, PPTX en XPS"
description: "Convertir des documents PowerPoint PPT, PPTX en XPS avec l'API Aspose.Slides."
---

## **À propos de XPS**
Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme une alternative au [PDF](https://docs.fileformat.com/pdf/). Il vous permet d'imprimer du contenu en produisant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d'un fichier XPS reste la même sur tous les systèmes d'exploitation et imprimantes.

## Quand utiliser le format Microsoft XPS

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit une présentation PPT ou PPTX en format XPS, vous pouvez consulter [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si vous souhaitez réduire les coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint en format XPS. De cette manière, il sera plus facile de sauvegarder, partager et imprimer vos documents.

Microsoft continue de mettre en œuvre un support solide pour XPS dans Windows (même dans Windows 10), donc vous pourriez envisager de sauvegarder des fichiers dans ce format. Si vous utilisez Windows 8.1, Windows 8, Windows 7 et Windows Vista, alors XPS pourrait en réalité être votre meilleure option pour certaines opérations.

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version standardisée du format XPS original. Windows 8 fournit un meilleur support pour les fichiers XPS que pour les fichiers PDF. 
  - **XPS:** Visiteur/lecteur XPS intégré et fonction d'impression vers XPS disponible. 
  - **PDF**: Lecteur PDF disponible mais pas de fonction d'impression vers PDF. 

-  **Windows 7 et Windows Vista** utilisent le format XPS original. Ces systèmes d'exploitation fournissent également un meilleur support pour les fichiers XPS que pour les fichiers PDF. 
  - **XPS**: Visiteur XPS intégré et fonction d'impression vers XPS disponible. 
  - **PDF**: Pas de lecteur PDF. Pas de fonction d'impression vers PDF. 

|<p>**Entrée PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft a finalement mis en œuvre le support des opérations d'impression en PDF grâce à la fonction Imprimer en PDF dans Windows 10. Auparavant, les utilisateurs devaient imprimer des documents au format XPS.

## Conversion XPS avec Aspose.Slides

Dans [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) pour C++, vous pouvez utiliser la méthode [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) pour convertir l'ensemble de la présentation en un document XPS.

Lors de la conversion d'une présentation en XPS, vous devez sauvegarder la présentation en utilisant l'un de ces paramètres :

- Paramètres par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Paramètres personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Conversion de présentations en XPS en utilisant les paramètres par défaut**

Ce code exemple en C++ vous montre comment convertir une présentation en un document XPS en utilisant des paramètres standards :

``` cpp
// Instancier un objet Presentation qui représente un fichier de présentation
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Sauvegarder la présentation au format de document XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Conversion de présentations en XPS en utilisant des paramètres personnalisés**
Ce code exemple vous montre comment convertir une présentation en un document XPS en utilisant des paramètres personnalisés en C++ :

``` cpp
// Instancier un objet Presentation qui représente un fichier de présentation
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instancier la classe TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Sauvegarder les mét fichiers en tant que PNG
options->set_SaveMetafilesAsPng(true);

// Sauvegarder la présentation au format de document XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```