---
title: Convertir PowerPoint en PDF avec des notes
type: docs
weight: 50
url: /fr/cpp/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir powerpoint en pdf avec des notes"
description: "Convertir PowerPoint en PDF avec des notes. Convertir PPT et PPTX en PDF avec des notes dans Aspose.Slides."
---

La méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) exposée par la classe Presentation peut être utilisée pour convertir une présentation PowerPoint PPT ou PPTX en PDF avec des notes. Enregistrer une présentation Microsoft PowerPoint en PDF avec des notes à l'aide d'Aspose.Slides pour C++ est un processus en deux lignes. Vous ouvrez simplement la présentation et l'enregistrez au format PDF avec des notes. Les extraits de code ci-dessous mettent à jour la présentation d'exemple au format PDF en mode Notes Slide :

``` cpp
// Le chemin vers le répertoire des documents.
String dataDir = GetDataPath();

// Instancier un objet Presentation qui représente un fichier de présentation 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Définir le type et la taille de la diapositive 
//auxPresentation->get_SlideSize()->SetSize(presentation->get_SlideSize()->get_Size().get_Width(), presentation->get_SlideSize()->get_Size().get_Height(), SlideSizeScaleType::EnsureFit);
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
pdfOptions->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```



{{% alert color="primary" %}} 

Vous voudrez peut-être consulter Aspose [PowerPoint to PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) ou [PPT to PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) convertisseur. 

{{% /alert %}} 