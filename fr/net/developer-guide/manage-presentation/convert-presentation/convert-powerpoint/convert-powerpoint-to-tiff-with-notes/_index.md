---
title: Convertir PowerPoint en TIFF avec des notes
type: docs
weight: 100
url: /fr/net/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint en TIFF avec des notes"
description: "Convertir PowerPoint en TIFF avec des notes dans Aspose.Slides."
---

{{% alert title="Astuce" color="primary" %}}

Vous voudrez peut-être consulter le [convertisseur GRATUIT de PowerPoint en Poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.

{{% /alert %}}

TIFF est l'un des nombreux formats d'image largement utilisés que Aspose.Slides pour .NET prend en charge pour convertir une présentation PowerPoint PPT et PPTX avec des notes en images. Vous pouvez également générer des miniatures de diapositives dans la vue des diapositives de notes. La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposée par la classe Presentation peut être utilisée pour convertir l'ensemble de la présentation en vue de diapositives de notes en TIFF. Sauvegarder une présentation Microsoft PowerPoint en notes TIFF avec Aspose.Slides pour .NET est un processus en deux lignes. Vous ouvrez simplement la présentation et l'enregistrez en notes TIFF. Vous pouvez également générer une miniatures de diapositives dans la vue des diapositives de notes pour des diapositives individuelles. Les extraits de code ci-dessous mettent à jour la présentation d'exemple en images TIFF dans la vue des diapositives de notes, comme montré ci-dessous :

```c#
// Instancier un objet Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // Sauvegarder la présentation en notes TIFF
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff);
}
```