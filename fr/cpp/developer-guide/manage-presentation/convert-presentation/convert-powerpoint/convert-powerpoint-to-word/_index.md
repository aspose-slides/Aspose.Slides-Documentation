---
title: Convertir des présentations PowerPoint en documents Word en C++
linktitle: PowerPoint vers Word
type: docs
weight: 110
url: /fr/cpp/convert-powerpoint-to-word/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers Word
- présentation vers Word
- diapositive vers Word
- PPT vers Word
- PPTX vers Word
- PowerPoint vers DOCX
- présentation vers DOCX
- diapositive vers DOCX
- PPT vers DOCX
- PPTX vers DOCX
- PowerPoint vers DOC
- présentation vers DOC
- diapositive vers DOC
- PPT vers DOC
- PPTX vers DOC
- enregistrer PPT en DOCX
- enregistrer PPTX en DOCX
- exporter PPT en DOCX
- exporter PPTX en DOCX
- C++
- Aspose.Slides
description: "Convertir les diapositives PowerPoint PPT et PPTX en documents Word modifiables en C++ à l'aide d'Aspose.Slides, en conservant la mise en page, les images et le formatage précis."
---
## **Introduction**

Si vous prévoyez d'utiliser le contenu textuel ou les informations d'une présentation (PPT ou PPTX) de nouvelles manières, vous pourriez bénéficier de la conversion de la présentation en Word (DOC ou DOCX).

* Comparé à Microsoft PowerPoint, l'application Microsoft Word offre davantage d'outils ou de fonctionnalités pour le contenu.
* En plus des fonctions d'édition dans Word, vous pouvez également profiter de fonctionnalités améliorées de collaboration, d'impression et de partage.

{{% alert color="info" %}} 
Vous pourriez vouloir essayer notre [**Convertisseur en ligne de présentation vers Word**](https://products.aspose.app/slides/fr/conversion/ppt-to-word) pour voir ce que vous pourriez gagner en travaillant avec le contenu textuel des diapositives. 
{{% /alert %}} 

## **Aspose.Slides et Aspose.Words**

Pour convertir un fichier PowerPoint (PPTX ou PPT) en Word (DOC ou DOCX), vous avez besoin à la fois de [Aspose.Slides for C++](https://products.aspose.com/slides/fr/cpp/) et de [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

En tant qu'API autonome, [Aspose.Slides](https://products.aspose.app/slides) for C++ fournit des fonctions qui vous permettent d'extraire le texte des présentations. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) est une API avancée de traitement de documents qui permet aux applications de générer, modifier, convertir, rendre, imprimer des fichiers et d'effectuer d'autres tâches avec des documents sans utiliser Microsoft Word.

## **Convertir une présentation PowerPoint en document Word**

Utilisez cet extrait de code pour convertir le PowerPoint en Word :
```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // génère une image de diapositive sous forme de flux de tableau d'octets
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // insère le texte des diapositives
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### Quels composants doivent être installés pour convertir les présentations PowerPoint et OpenDocument en documents Word ?

Vous n'avez besoin d'ajouter que les packages respectifs pour [Aspose.Slides for C++](https://releases.aspose.com/slides/fr/cpp/) et [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) à votre projet. Les deux bibliothèques fonctionnent comme des API autonomes, et il n'est pas nécessaire d'installer Microsoft Office.

### Tous les formats de présentations PowerPoint et OpenDocument sont-ils pris en charge ?

Aspose.Slides [prend en charge tous les formats de présentation](/slides/fr/cpp/supported-file-formats/), y compris PPT, PPTX, ODP et d'autres types de fichiers courants. Cela garantit que vous pouvez travailler avec des présentations créées dans différentes versions de Microsoft PowerPoint.