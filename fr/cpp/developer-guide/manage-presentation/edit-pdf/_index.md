---
title: Modifier des documents PDF en C++
linktitle: Modifier PDF
type: docs
weight: 65
url: /fr/cpp/edit-pdf/
keywords:
- modifier PDF
- remplacer texte PDF
- PDF en PPTX
- PPTX en PDF
- C++
- Aspose.Slides
description: "Modifiez les documents PDF en C++ en les important dans Aspose.Slides, en remplaçant le texte et en enregistrant la présentation modifiée au format PDF."
---
## **Aperçu**

Aspose.Slides for C++ vous permet de modifier le contenu PDF en important ses pages sous forme de diapositives, en modifiant la présentation, puis en l’exportant à nouveau au format PDF. Cet article montre un remplacement de texte simple. La présentation reste en mémoire, de sorte que l’enregistrement d’un fichier PPTX intermédiaire est facultatif.

## **Remplacer du texte dans un PDF**

Utilisez [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidecollection/addfrompdf/) pour importer les pages, [Presentation::ReplaceText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/replacetext/) pour mettre à jour le texte, et [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) pour exporter le résultat.

L’exemple suivant suppose que `input.pdf` contient le mot « Draft » en texte modifiable après l’importation. Il remplace ce mot par « Final » et écrit `edited.pdf`. La suppression de la diapositive initiale avant l’importation évite une page blanche supplémentaire dans le résultat. La recherche correspond aux mots entiers avec la même casse ; `nullptr` indique qu’aucun rappel de résultat n’est nécessaire.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Pour plus d’options, consultez [Search and Replace Text](/slides/fr/cpp/search-and-replace-text/) et [Convert PowerPoint to PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Le remplacement de texte fonctionne sur le texte importé, pas sur le texte contenu dans des images numérisées. La conversion peut affecter la mise en page et le formatage, il faut donc examiner le résultat, surtout lorsque le texte de remplacement est plus long que l’original.
{{% /alert %}}

## **FAQ**

**Do I need to save a PPTX file before exporting the PDF?**

Non. Vous pouvez modifier et exporter la même présentation en mémoire. Enregistrez une copie PPTX uniquement si vous souhaitez également la continuer à éditer dans PowerPoint ; consultez [Save Presentations](/slides/fr/cpp/save-presentation/).

**Why might some text remain unchanged?**

L’exemple recherche le mot entier « Draft » avec la casse exacte. Le texte importé sous forme d’image ou réparti sur plusieurs zones de texte ne correspondra pas forcément à la recherche. Vérifiez le contenu importé et adaptez la recherche à votre document.