---
title: Convertir PowerPoint en TIFF avec notes
type: docs
weight: 100
url: /cpp/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint en TIFF avec des notes"
description: "Convertir PowerPoint en TIFF avec des notes dans Aspose.Slides."
---

TIFF est l'un des plusieurs formats d'image largement utilisés que Aspose.Slides pour C++ prend en charge pour convertir des présentations PowerPoint PPT et PPTX avec des notes en images. Vous pouvez également générer des vignettes de diapositives dans la vue de diapositives avec notes. La méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) exposée par la classe Presentation peut être utilisée pour convertir l'ensemble de la présentation en vue de diapositives avec notes en TIFF. Enregistrer une présentation Microsoft PowerPoint en TIFF avec des notes à l'aide d'Aspose.Slides pour C++ est un processus en deux lignes. Il vous suffit d'ouvrir la présentation et de l'enregistrer en tant que notes TIFF. Vous pouvez également générer une vignette de diapositive dans la vue de diapositives avec notes pour des diapositives individuelles. Les extraits de code ci-dessous mettent à jour la présentation d'exemple en images TIFF dans la vue de diapositives avec notes, comme indiqué ci-dessous :

``` cpp
// Le chemin vers le répertoire des documents.
System::String dataDir = GetDataPath();

// Instancier un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

// Enregistrement de la présentation en notes TIFF
presentation->Save(dataDir + u"Notes_In_Tiff_out.tiff", SaveFormat::Tiff);
```

{{% alert title="Astuce" color="primary" %}}

Vous voudrez peut-être consulter le [convertisseur gratuit de PowerPoint en poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.

{{% /alert %}}