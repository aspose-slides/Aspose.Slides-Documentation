---
title: Convertir des présentations PowerPoint en PDF avec notes en C++
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

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur à l'aide d'Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à réaliser cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en conservant les notes du présentateur.
- Personnaliser le PDF de sortie afin de garantir que les notes du présentateur sont incluses et formatées selon vos exigences.

Pour définir les dimensions et l'orientation de la page des notes avant l'exportation, consultez [Taille de la page des notes](/slides/fr/cpp/notes-size/).

## **Convertir PowerPoint en PDF avec notes**

La méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, il suffit de charger la présentation, de configurer les options de mise en page à l'aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis d'enregistrer le fichier au format PDF. L'extrait de code suivant montre comment convertir une présentation d'exemple en PDF en mode vue des notes de diapositive.

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
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Rendre les notes du présentateur sous la diapositive.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Vous souhaiterez peut‑être consulter le [Convertisseur PowerPoint en PDF en ligne d'Aspose](https://products.aspose.app/slides/fr/conversion).
{{% /alert %}}