---
title: Redigera PDF-dokument i C++
linktitle: Redigera PDF
type: docs
weight: 65
url: /sv/cpp/edit-pdf/
keywords:
- redigera PDF
- ersätta PDF-text
- PDF till PPTX
- PPTX till PDF
- C++
- Aspose.Slides
description: "Redigera PDF-dokument i C++ genom att importera dem till Aspose.Slides, ersätta text och spara den modifierade presentationen tillbaka till PDF."
---
## **Översikt**

Aspose.Slides för C++ låter dig redigera PDF‑innehåll genom att importera dess sidor som bilder, ändra presentationen och exportera den tillbaka till PDF. Denna artikel visar ett enkelt textutbyte. Presentationen finns kvar i minnet, så att spara en mellanliggande PPTX‑fil är valfritt.

## **Ersätt text i en PDF**

Använd [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidecollection/addfrompdf/) för att importera sidorna, [Presentation::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/replacetext/) för att uppdatera texten och [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) för att exportera resultatet.

Följande exempel förutsätter att `input.pdf` innehåller ordet "Draft" som redigerbar text efter import. Det ersätter det ordet med "Final" och skriver `edited.pdf`. Att rensa den första bilden före import förhindrar en extra tom sida i resultatet. Sökningen matchar hela ord med samma skiftläge; `nullptr` betyder att ingen resultat‑callback behövs.

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

För fler alternativ, se [Search and Replace Text](/slides/sv/cpp/search-and-replace-text/) och [Convert PowerPoint to PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Textutbyte fungerar på importerad text, inte på text i skannade bilder. Konverteringen kan påverka layout och formatering, så granska utdata, särskilt när den ersatta texten är längre än originalet.
{{% /alert %}}

## **FAQ**

**Behöver jag spara en PPTX‑fil innan jag exporterar PDF‑filen?**

Nej. Du kan redigera och exportera samma presentation i minnet. Spara en PPTX‑kopi endast om du också vill fortsätta redigera den i PowerPoint; se [Save Presentations](/slides/sv/cpp/save-presentation/).

**Varför kan vissa texter förbli oförändrade?**

Exemplet matchar hela ordet "Draft" med exakt skiftläge. Text som importeras som en bild eller delas upp i separata textramar matchar inte nödvändigtvis sökningen. Kontrollera det importerade innehållet och justera sökningen för ditt dokument.