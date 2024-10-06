---
title: Enregistrer la Présentation
type: docs
weight: 80
url: /python-net/save-presentation/
keywords: "Enregistrer PowerPoint, PPT, PPTX, Enregistrer la Présentation, fichier, flux, Python"
description: "Enregistrer une Présentation PowerPoint en tant que fichier ou flux en Python"
---

## **Enregistrer la Présentation**
L'ouverture d'une Présentation décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contient le contenu d'une présentation. Que vous créiez une présentation de toutes pièces ou que vous modifiiez une existante, lorsque vous avez fini, vous souhaitez enregistrer la présentation. Avec Aspose.Slides pour Python via .NET, elle peut être enregistrée en tant que **fichier** ou **flux**. Cet article explique comment enregistrer une présentation de différentes manières :

### **Enregistrement de Présentations dans des Fichiers**
Enregistrez une présentation dans des fichiers en appelant la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Il suffit de passer le nom du fichier et le format d'enregistrement à la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Les exemples qui suivent montrent comment enregistrer une présentation avec Aspose.Slides pour Python via .NET en utilisant Python.

```py
import aspose.slides as slides

# Instancier un objet Presentation représentant un fichier PPT
with slides.Presentation() as presentation:
    
    #...faites du travail ici...

    # Enregistrez votre présentation dans un fichier
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Enregistrement de Présentations dans des Flux**
Il est possible d'enregistrer une présentation dans un flux en passant un flux de sortie à la méthode Save de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Il existe de nombreux types de flux dans lesquels une présentation peut être enregistrée. Dans l'exemple ci-dessous, nous avons créé un nouveau fichier de Présentation, ajouté du texte dans une forme et enregistré la présentation dans le flux.

```py
import aspose.slides as slides

# Instancier un objet Presentation représentant un fichier PPT
with slides.Presentation() as presentation:
    
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 200, 200)

    # Enregistrez votre présentation dans un flux
    with open("Save_As_Stream_out.pptx", "bw") as stream:
        presentation.save(stream, slides.export.SaveFormat.PPTX)
```


### **Enregistrement de Présentations avec un Type de Vue Prédéfinie**
Aspose.Slides pour Python via .NET fournit une fonctionnalité pour définir le type de vue pour la présentation générée lorsqu'elle est ouverte dans PowerPoint via la classe [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/). La propriété [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) est utilisée pour définir le type de vue en utilisant l'énumérateur [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

# Instancier un objet Presentation représentant un fichier PPT
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **Enregistrement de Présentations au Format Strict Office Open XML**
Aspose.Slides vous permet d'enregistrer la présentation au format Strict Office Open XML. À cette fin, il fournit la classe [**PptxOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) dans laquelle vous pouvez définir la propriété Conformance lors de l'enregistrement du fichier de présentation. Si vous définissez sa valeur comme Conformance.Iso29500_2008_Strict, alors le fichier de présentation de sortie sera enregistré au format Strict Office Open XML.

Le code d'exemple suivant crée une présentation et l'enregistre au format Strict Office Open XML. Lors de l'appel de la méthode Save pour la présentation, l'objet **[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** est passé avec la propriété **[Conformance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** définie comme **[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/python-net/aspose.slides.export/conformance/)**.

```py
import aspose.slides as slides

# Instancier un objet Presentation représentant un fichier de présentation
with slides.Presentation() as presentation:
    # Obtenir la première diapositive
    slide = presentation.slides[0]

    #Ajouter une forme automatique de type ligne
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # Enregistrer la présentation au format Strict Office Open XML
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```


### **Enregistrement des Mises à Jour de Progrès en Pourcentage**
Une nouvelle interface [**IProgressCallback**](https://reference.aspose.com/slides/python-net/aspose.slides/iprogresscallback/) a été ajoutée à l'interface [**ISaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/isaveoptions/) et à la classe abstraite [**SaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/). L'interface **IProgressCallback** représente un objet de rappel pour enregistrer les mises à jour de progrès en pourcentage.

Les extraits de code suivants montrent comment utiliser l'interface IProgressCallback :

```py
# [TODO[non_soutenu_encore]: implémentation python des interfaces .net]
```

{{% alert title="Info" color="info" %}}

En utilisant sa propre API, Aspose a développé une [application gratuite de découpage PowerPoint](https://products.aspose.app/slides/splitter) qui permet aux utilisateurs de diviser leurs présentations en plusieurs fichiers. Essentiellement, l'application enregistre les diapositives sélectionnées d'une présentation donnée en tant que nouveaux fichiers PowerPoint (PPTX ou PPT).

{{% /alert %}}