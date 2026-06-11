---
title: Förhindra redigering av presentation med formlås
linktitle: Förhindra redigering av presentation
type: docs
weight: 10
url: /sv/cpp/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- lås form
- lås position
- lås val
- lås storlek
- lås gruppering
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för C++ låser eller låser upp former i PPT-, PPTX- och ODP-filer, säkrar presentationer samtidigt som kontrollerade redigeringar och snabbare leverans möjliggörs."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides är att skapa, uppdatera och spara Microsoft PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. Användare av applikationer som använder Aspose.Slides på detta sätt har tillgång till de genererade presentationerna, så att skydda dem mot redigering är en vanlig oro. Det är viktigt att automatiskt genererade presentationer behåller sin ursprungliga formatering och sitt innehåll.

Den här artikeln förklarar hur presentationer och bilder är strukturerade samt hur Aspose.Slides för C++ kan tillämpa skydd på en presentation och senare ta bort det. Den ger utvecklare ett sätt att kontrollera hur de presentationer som deras applikationer genererar används.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildrutor, videorutor, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides för C++ representeras varje element på en bild av ett objekt som implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) eller ärver från en klass som gör det.

Strukturen för PPTX är komplex, så till skillnad från PPT, där ett generiskt lås kan användas för alla typer av former, kräver olika formtyper olika lås. Gränssnittet [IBaseShapeLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseshapelock/) är den generiska låsklassen för PPTX. Följande typer av lås stöds i Aspose.Slides för C++ för PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshapelock/) låser autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iconnectorlock/) låser anslutningsformer.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/igraphicalobjectlock/) låser grafiska objekt.  
- [IGroupShapeLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/igroupshapelock/) låser gruppformer.  
- [IPictureFrameLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframelock/) låser bildrutor.   

Alla åtgärder som utförs på alla formobjekt i ett [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objekt tillämpas på hela presentationen.

## **Tillämpa och ta bort skydd**

Att tillämpa skydd säkerställer att en presentation inte kan redigeras. Det är en användbar teknik för att skydda presentationens innehåll.

### **Tillämpa skydd på PPTX‑former**

Aspose.Slides för C++ tillhandahåller gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) för att arbeta med former på en bild.

Som nämnts tidigare har varje formklass en associerad låsklass för skydd. Den här artikeln fokuserar på låsen NoSelect, NoMove och NoResize. Dessa lås säkerställer att former inte kan väljas (genom musklick eller andra urvalsmetoder) och att de inte kan flyttas eller ändra storlek.

Kodexemplen som följer tillämpar skydd på alla formtyper i en presentation.

```cpp
// Instansiera Presentation-klassen som representerar en PPTX-fil.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Gå igenom alla bilder i presentationen.
for (auto&& slide : presentation->get_Slides())	{

	// Gå igenom alla former i bilden.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Typomvandla formen till en autoshape och hämta dess formlås.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Typomvandla formen till en gruppform och hämta dess formlås.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Typomvandla formen till en anslutningsform och hämta dess formlås.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Typomvandla formen till en bildram och hämta dess formlås.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Sparar presentationsfilen.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Ta bort skydd**

För att låsa upp en form, sätt det tillämpade låsets värde till `false`. Följande kodexempel visar hur man låser upp former i en låst presentation.

```cpp
// Instansiera Presentation-klassen som representerar en PPTX-fil.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Går igenom alla bilder i presentationen.
for (auto&& slide : presentation->get_Slides())	{

	// Går igenom alla former i bilden.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Typomvandlar formen till en autoshape och hämtar dess formlås.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Typomvandlar formen till en gruppform och hämtar dess formlås.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Typomvandlar formen till en anslutningsform och hämtar dess formlås.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Typomvandlar formen till en bildram och hämtar dess formlås.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Sparar presentationsfilen.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Slutsats**

Aspose.Slides erbjuder flera alternativ för att skydda former i en presentation. Du kan låsa en enskild form eller iterera igenom alla former i en presentation och låsa var och en för att effektivt säkra hela filen. Du kan ta bort skyddet genom att sätta låsvärdet till `false`.

## **FAQ**

**Kan jag kombinera formlås och lösenordsskydd i samma presentation?**

Ja. Lås begränsar redigering av objekt i filen, medan [lösenordsskydd](/slides/sv/cpp/password-protected-presentation/) styr åtkomst för att öppna och/eller spara ändringar. Dessa mekanismer kompletterar varandra och fungerar tillsammans.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås på formerna på de valda bilderna; de återstående bilderna förblir redigerbara.

**Gäller formlås för grupperade objekt och anslutningar?**

Ja. Dedikerade låstyper stöds för grupper, anslutningar, grafiska objekt och andra formtyper.