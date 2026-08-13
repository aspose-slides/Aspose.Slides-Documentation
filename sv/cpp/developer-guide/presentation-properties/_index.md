---
title: Hantera presentationsegenskaper i C++
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/cpp/presentation-properties/
keywords:
- PowerPoint egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrigeringsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för C++ och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_document_properties). En instans av detta gränssnitt returneras av metoden [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_documentproperties/) . Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" %}} 
Observera att du inte kan ange värden för fälten **Application** och **Producer**, eftersom Aspose Ltd. och Aspose.Slides for C++ x.x.x kommer att visas i dessa fält.
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till vissa egenskaper i presentationsfilerna. Dessa dokumentegenskaper gör det möjligt att lagra användbar information tillsammans med dokumenten (presentationsfilerna). Det finns två typer av dokumentegenskaper som följer

- Systemdefinierade (Inbyggda) egenskaper
- Användardefinierade (Anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet såsom dokumenttitel, författarens namn, dokumentstatistik osv. **Anpassade** egenskaper är de som definieras av användarna som **Name/Value**-par, där både namn och värde definieras av användaren. Med Aspose.Slides för C++ kan utvecklare komma åt och ändra värdena för inbyggda egenskaper såväl som anpassade egenskaper. Microsoft PowerPoint 2007 tillåter hantering av dokumentegenskaperna för presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan **Prepare | Properties | Advanced Properties** menyalternativet i Microsoft PowerPoint 2007. Efter att du har valt **Advanced Properties**‑menyalternativet visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen. I **Properties Dialog** kan du se att det finns många flikar som **General, Summary, Statistics, Contents och Custom**. Alla dessa flikar låter dig konfigurera olika typer av information relaterad till PowerPoint‑filerna. **Custom**‑fliken används för att hantera anpassade egenskaper i PowerPoint‑filerna.

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper som exponeras av objektet **IDocumentProperties** inkluderar: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Skapelsedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Ändra inbyggda egenskaper**

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap så blir egenskapsvärdet ändrat. I exemplen nedan har vi visat hur vi kan ändra de inbyggda dokumentegenskaperna i presentationsfilen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Lägg till anpassade presentationsegenskaper**

Aspose.Slides för C++ låter också utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Ett exempel ges nedan som visar hur man ställer in de anpassade egenskaperna för en presentation.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Skapa en instans av Presentation-klassen
auto presentation = System::MakeObject<Presentation>();

// Hämtar dokumentegenskaper
auto documentProperties = presentation->get_DocumentProperties();

// Lägger till anpassade egenskaper
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Hämtar egenskapsnamn på ett specifikt index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Tar bort vald egenskap
documentProperties->RemoveCustomProperty(getPropertyName);

// Sparar presentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Åtkomst till och ändra anpassade egenskaper**

Aspose.Slides för C++ låter även utvecklare komma åt värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Ange korrekturspråk**

Aspose.Slides tillhandahåller egenskapen [LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides.baseportionformat/set_languageid/) (exponerad av klassen [PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portionformat/)) för att låta dig ange korrekturspråket för ett PowerPoint‑dokument. Korrekturspråket är det språk för vilket stavning och grammatik i PowerPoint kontrolleras.

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// ange Id för ett korrekturspråk

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Ange standardspråk**

Denna C++‑kod visar hur du ställer in standardspråket för en hel PowerPoint‑presentation:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Lägger till en ny rektangelform med text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Kontrollerar språk för den första delen
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑exempel**

Prova den online‑appen [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur du arbetar med dokumentegenskaper via Aspose.Slides API:

[![Visa och redigera PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***Vanliga frågor**

### Hur kan jag ta bort en inbyggd egenskap från en presentation?

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller, om den specifika egenskapen tillåter det, sätta dem till tomma.

### Vad händer om jag lägger till en anpassad egenskap som redan finns?

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

### Kan jag komma åt presentationsegenskaper utan att helt ladda presentationen?

Ja, du kan komma åt presentationsegenskaper utan att helt ladda presentationen genom att använda metoden `GetPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationfactory/). Använd sedan metoden `ReadDocumentProperties` som tillhandahålls av gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/) för att läsa egenskaperna på ett effektivt sätt, vilket sparar minne och förbättrar prestanda.