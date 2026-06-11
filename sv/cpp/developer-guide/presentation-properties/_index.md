---
title: Hantera presentationsegenskaper i C++
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/cpp/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- ändra egenskaper
- dokumentmetadata
- redigera metadata
- korrekturspråk
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

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_document_properties). En instans av detta gränssnitt returneras av metoden [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_documentproperties/). Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="primary" %}} 
Observera att du inte kan ange värden för fälten **Application** och **Producer**, eftersom Aspose Ltd. och Aspose.Slides för C++ x.x.x kommer att visas för dessa fält.
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till vissa egenskaper i presentationsfilerna. Dessa dokumentegenskaper möjliggör lagring av användbar information tillsammans med dokumenten (presentationsfiler). Det finns två typer av dokumentegenskaper enligt följande

- Systemdefinierade (inbyggda) egenskaper
- Användardefinierade (anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet såsom dokumenttitel, författarens namn, dokumentstatistik med mera. **Anpassade** egenskaper är de som definieras av användarna som **Namn/Värde**‑par, där både namn och värde anges av användaren. Med Aspose.Slides för C++ kan utvecklare komma åt och ändra värdena för inbyggda egenskaper såväl som anpassade egenskaper. Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaperna i presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyobjektet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007. Efter att du har valt menyobjektet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna i PowerPoint‑filen. I **Properties Dialog** kan du se att det finns många flikar såsom **General, Summary, Statistics, Contents och Custom**. Alla dessa flikar tillåter konfiguration av olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera anpassade egenskaper i PowerPoint‑filerna.

## **Kom åt inbyggda egenskaper**

Dessa egenskaper som exponeras av **IDocumentProperties**‑objektet inkluderar: **Creator(Author)**, **Description**, **KeyWords**, **Created** (skapningsdatum), **Modified** (ändringsdatum), **Printed** (senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (delad mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Ändra inbyggda egenskaper**

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till valfri egenskap så att egenskapens värde ändras. I exemplet nedan har vi demonstrerat hur vi kan ändra de inbyggda dokumentegenskaperna i presentationsfilen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Lägg till anpassade presentationsegenskaper**

Aspose.Slides för C++ låter även utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Ett exempel ges nedan som visar hur man anger anpassade egenskaper för en presentation.

``` cpp
// Instansiera Presentation-klassen
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

## **Kom åt och ändra anpassade egenskaper**

Aspose.Slides för C++ låter även utvecklare komma åt värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Ställ in korrekturspråk**

Aspose.Slides tillhandahåller egenskapen [LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_languageid/) (exponerad av klassen [PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portionformat/)) för att låta dig ange korrekturspråket för ett PowerPoint-dokument. Korrekturspråket är det språk för vilket stavning och grammatik i PowerPoint kontrolleras.

Denna C++-kod visar hur du anger korrekturspråket för en PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Ställ in standardspråk**

Denna C++-kod visar hur du anger standardspråket för en hel PowerPoint-presentation:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Lägger till en ny rektangelform med text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Kontrollerar det första portionsspråket
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑exempel**

Prova den online‑app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur man arbetar med dokumentegenskaper via Aspose.Slides API:

[![Visa & redigera PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***Vanliga frågor**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Däremot kan du ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja, du kan komma åt presentationsegenskaper utan att ladda hela presentationen genom att använda metoden `GetPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationfactory/). Använd sedan metoden `ReadDocumentProperties` som tillhandahålls av gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/) för att läsa egenskaperna effektivt, spara minne och förbättra prestanda.