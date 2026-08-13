---
title: Convertir les présentations PowerPoint en PDF avec notes en C++
linktitle: PowerPoint en PDF avec notes
type: docs
weight: 50
url: /fr/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PDF
- présentation en PDF
- diapositive en PDF
- PPT en PDF
- PPTX en PDF
- enregistrer la présentation au format PDF
- enregistrer le PPT au format PDF
- enregistrer le PPTX au format PDF
- exporter le PPT au format PDF
- exporter le PPTX au format PDF
- notes du présentateur
- PDF avec notes
- C++
- Aspose.Slides
description: "Convertir les formats PPT et PPTX en PDF avec notes à l'aide d'Aspose.Slides pour C++. Conserver les mises en page et les notes du présentateur pour des présentations professionnelles."
---
## **Vue d'ensemble**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur en utilisant Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à accomplir cette tâche de manière efficace. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en préservant les notes du présentateur.
- Personnaliser le PDF de sortie afin que les notes du présentateur soient incluses et formatées selon vos exigences.

## **Convertir PowerPoint en PDF avec les notes**

La méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, il vous suffit de charger la présentation, de configurer les options de mise en page à l’aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis d’enregistrer le fichier au format PDF. Le fragment de code suivant montre comment convertir une présentation d’exemple en PDF en mode diapositive de notes.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Rendu des notes du présentateur sous la diapositive.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Vous voudrez peut‑être consulter le convertisseur en ligne PowerPoint vers PDF d'Aspose[Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fr/conversion). 
{{% /alert %}}