---
title: Voorkom bewerking van presentaties met vormvergrendelingen
linktitle: Voorkom bewerking van presentaties
type: docs
weight: 10
url: /nl/cpp/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte vergrendelen
- groepering vergrendelen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for C++ vormen vergrendelt of ontgrendelt in PPT-, PPTX- en ODP-bestanden, presentaties beveiligt terwijl gecontroleerde bewerkingen mogelijk zijn en een snellere levering wordt gerealiseerd."
---
## **Achtergrond**

Een veelvoorkomende toepassing van Aspose.Slides is het maken, bijwerken en opslaan van Microsoft PowerPoint (PPTX)-presentaties als onderdeel van een geautomatiseerde workflow. Gebruikers van applicaties die Aspose.Slides op deze manier gebruiken, hebben toegang tot de gegenereerde presentaties, daarom is bescherming tegen bewerken een veelvoorkomend aandachtspunt. Het is belangrijk dat automatisch gegenereerde presentaties hun oorspronkelijke opmaak en inhoud behouden.

Dit artikel legt uit hoe presentaties en dia's zijn gestructureerd en hoe Aspose.Slides for C++ bescherming op een presentatie kan toepassen en later kan verwijderen. Het biedt ontwikkelaars een manier om te bepalen hoe de presentaties die hun applicaties genereren, worden gebruikt.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autosvormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingframes, videoframes, connectoren en andere elementen die gebruikt worden om een presentatie op te bouwen. In Aspose.Slides for C++ wordt elk element op een dia weergegeven door een object dat de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) interface implementeert of van een klasse erft die dat doet.

De structuur van PPTX is complex, dus in tegenstelling tot PPT, waar een generieke vergrendeling voor alle soorten vormen kan worden gebruikt, vereisen verschillende vormtypen verschillende vergrendelingen. De [IBaseShapeLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseshapelock/) interface is de generieke vergrendelingsklasse voor PPTX. De volgende typen vergrendelingen worden ondersteund in Aspose.Slides for C++ voor PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshapelock/) vergrendelt autosvormen.  
- [IConnectorLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iconnectorlock/) vergrendelt connectorvormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframelock/) vergrendelt afbeeldingframes.   

Elke actie die op alle vormobjecten in een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object wordt uitgevoerd, wordt toegepast op de gehele presentatie.

## **Bescherming toepassen en verwijderen**

Bescherming toepassen zorgt ervoor dat een presentatie niet kan worden bewerkt. Het is een nuttige techniek om de inhoud van de presentatie te beveiligen.

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for C++ biedt de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) interface om met vormen op een dia te werken.

Zoals eerder vermeld, heeft elke vormklasse een bijbehorende vorm‑vergrendelingsklasse voor bescherming. Dit artikel richt zich op de NoSelect-, NoMove- en NoResize‑vergrendelingen. Deze vergrendelingen zorgen ervoor dat vormen niet kunnen worden geselecteerd (via muisklikken of andere selectiemethoden) en dat ze niet kunnen worden verplaatst of van grootte veranderd.

De onderstaande codevoorbeelden passen bescherming toe op alle vormen in een presentatie.

```cpp
// Instantieer de Presentation‑klasse die een PPTX‑bestand representeert.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Doorloop alle dia's in de presentatie.
for (auto&& slide : presentation->get_Slides())	{

	// Doorloop alle vormen in de dia.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// De vorm casten naar een autosvorm en de vormvergrendeling ophalen.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// De vorm casten naar een groepsvorm en de vormvergrendeling ophalen.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// De vorm casten naar een connector en de vormvergrendeling ophalen.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// De vorm casten naar een afbeeldingframe en de vormvergrendeling ophalen.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Het presentatiedocument opslaan.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Bescherming verwijderen**

Om een vorm te ontgrendelen, stel je de toegepaste vergrendelingswaarde in op `false`. Het volgende codevoorbeeld laat zien hoe je vormen in een vergrendelde presentatie kunt ontgrendelen.

```cpp
// Instantieer de Presentation-klasse die een PPTX-bestand representeert.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Doorloop alle dia's in de presentatie.
for (auto&& slide : presentation->get_Slides())	{

	// Doorloop alle vormen in de dia.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// De vorm casten naar een autosvorm en de vormvergrendeling ophalen.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// De vorm casten naar een groepsvorm en de vormvergrendeling ophalen.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// De vorm casten naar een connector en de vormvergrendeling ophalen.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// De vorm casten naar een afbeeldingframe en de vormvergrendeling ophalen.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Het presentatiedocument opslaan.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Conclusie**

Aspose.Slides biedt verschillende opties om vormen in een presentatie te beveiligen. Je kunt een individuele vorm vergrendelen of door alle vormen in een presentatie itereren en elke vorm vergrendelen om het hele bestand effectief te beveiligen. Je kunt de bescherming verwijderen door de vergrendelingswaarde in te stellen op `false`.

## **Veelgestelde vragen**

**Kan ik vormvergrendelingen combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Vergrendelingen beperken het bewerken van objecten binnen het bestand, terwijl [password protection](/slides/nl/cpp/password-protected-presentation/) de toegang tot het openen en/of opslaan van wijzigingen regelt. Deze mechanismen vullen elkaar aan en werken samen.

**Kan ik het bewerken beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Breng vergrendelingen aan op de vormen van de geselecteerde dia's; de overige dia's blijven bewerkbaar.

**Zijn vormvergrendelingen van toepassing op gegroepeerde objecten en connectoren?**

Ja. Er zijn speciale vergrendelingssoorten beschikbaar voor groepen, connectoren, grafische objecten en andere vormcategorieën.