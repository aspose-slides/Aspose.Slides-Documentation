---
title: Convertir PowerPoint en XPS 
type: docs
weight: 70
url: /python-net/convert-powerpoint-to-xps
keywords: "Convertir la présentation PowerPoint, PowerPoint en XPS, PPT en XPS, PPTX en XPS, Conversion, Python, Aspose.Slides"
description: "Convertir la présentation PowerPoint en XPS en Python."
---

## **À propos de XPS**
Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme une alternative à [PDF](https://docs.fileformat.com/pdf/). Il vous permet d'imprimer du contenu en produisant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d'un fichier XPS reste la même sur tous les systèmes d'exploitation et imprimantes. 

## Quand utiliser le format Microsoft XPS

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit une présentation PPT ou PPTX en format XPS, vous pouvez essayer [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si vous souhaitez réduire vos coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint au format XPS. De cette façon, il vous sera plus facile de sauvegarder, partager et imprimer vos documents. 

Microsoft continue de mettre en œuvre un support solide pour XPS dans Windows (même dans Windows 10), donc vous souhaiterez peut-être envisager d'enregistrer des fichiers dans ce format. Si vous utilisez Windows 8.1, Windows 8, Windows 7 et Windows Vista, alors XPS pourrait en fait être votre meilleure option pour certaines opérations. 

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version standardisée du format XPS d'origine. Windows 8 offre un meilleur support pour les fichiers XPS que pour les fichiers PDF. 
  - **XPS:** Visionneuse/lecteur XPS intégré et fonctionnalité d'impression en XPS disponible. 
  - **PDF**: Lecteur PDF disponible mais pas de fonctionnalité d'impression en PDF. 

-  **Windows 7 et Windows Vista** utilisent le format XPS d'origine. Ces systèmes d'exploitation offrent également un meilleur support pour les fichiers XPS que pour les PDF. 
  - **XPS**: Visionneuse XPS intégrée et fonctionnalité d'impression en XPS disponible. 
  - **PDF**: Pas de lecteur PDF. Pas de fonctionnalité d'impression en PDF. 

|<p>**Entrée PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft a finalement implémenté un support pour les opérations d'impression en PDF grâce à la fonctionnalité Imprimer en PDF dans Windows 10. Auparavant, les utilisateurs s'attendaient à imprimer des documents via le format XPS. 

## Conversion XPS avec Aspose.Slides

Dans [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) pour .NET, vous pouvez utiliser la méthode [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour convertir l'ensemble de la présentation en document XPS. 

Lors de la conversion d'une présentation en XPS, vous devez enregistrer la présentation en utilisant l'une de ces options :

- Paramètres par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- Paramètres personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **Conversion de présentations en XPS en utilisant les paramètres par défaut**

Ce code d'exemple en Python vous montre comment convertir une présentation en document XPS en utilisant des paramètres standards :

```py
import aspose.slides as slides

# Instancier un objet Presentation représentant un fichier de présentation
pres = slides.Presentation("Convert_XPS.pptx")

# Sauvegarder la présentation en document XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Conversion de présentations en XPS en utilisant des paramètres personnalisés**
Ce code d'exemple vous montre comment convertir une présentation en document XPS en utilisant des paramètres personnalisés en Python :

```py
import aspose.slides as slides

# Instancier un objet Presentation représentant un fichier de présentation
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instancier la classe TiffOptions
options = slides.export.XpsOptions()

# Enregistrer les mét fichiers au format PNG
options.save_metafiles_as_png = True

# Sauvegarder la présentation en document XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```