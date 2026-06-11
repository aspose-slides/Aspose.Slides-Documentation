---
title: Åtkomst till presentationsbilder i C++
linktitle: Åtkomst till bild
type: docs
weight: 20
url: /sv/cpp/access-slide-in-presentation/
keywords:
- åtkomst till bild
- bildindex
- bild-id
- bildposition
- ändra position
- bildegenskaper
- bildnummer
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du får åtkomst till och hanterar bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Öka produktiviteten med kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur man kommer åt och hanterar bilder i en presentation med Aspose.Slides. Den visar hur man hämtar bilder via deras nollbaserade index i bilder‑samlingen och hur man kommer åt en bild via dess unika ID med metoden `GetSlideById`.

Du kommer också att lära dig hur du ändrar en bilds position med metoden `set_SlideNumber` och hur du definierar startbildnumret för en presentation med metoden `set_FirstSlideNumber`. Exemplen demonstrerar hur man laddar en presentation, hämtar bildreferenser, uppdaterar bildordning eller numrering samt sparar den modifierade presentationen.

## **Kom åt en bild via index**

Alla bilder i en presentation är ordnade numeriskt baserat på bildens position med start från 0. Den första bilden är åtkomlig via index 0; den andra bilden via index 1; osv.

Klassen Presentation, som representerar en presentationsfil, exponerar alla bilder som en [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/) samling (samling av [ISlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/) objekt). Denna C++‑kod visar hur du kommer åt en bild via dess index:

```c++
	// Sökvägen till dokumentkatalogen.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instansierar Presentation-klassen
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Hämta en bilds referens via dess index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Kom åt en bild via ID**

Varje bild i en presentation har ett unikt ID kopplat till sig. Du kan använda metoden [GetSlideById()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/getslidebyid/) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)) för att rikta in dig på det ID:t. Denna C++‑kod visar hur du anger ett giltigt bild‑ID och kommer åt den bilden via metoden [GetSlideById()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// Sökvägen till dokumentkatalogen.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instansierar Presentation-klassen
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Hämtar ett bild-ID
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Kommer åt bilden via dess ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Ändra bildposition**

Aspose.Slides låter dig ändra en bilds position. Till exempel kan du ange att den första bilden ska bli den andra bilden.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) klassen.  
1. Hämta bildens referens (vars position du vill ändra) via dess index.  
1. Ange en ny position för bilden via egenskapen [set_SlideNumber()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/set_slidenumber/).  
1. Spara den modifierade presentationen.

Denna C++‑kod demonstrerar en operation där bilden i position 1 flyttas till position 2:

```c++
	// Sökvägen till dokumentkatalogen.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instansierar Presentation-klassen
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Hämtar bilden vars position kommer att ändras
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Anger den nya positionen för bilden
	slide->set_SlideNumber(2);

	// Sparar den modifierade presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Den första bilden blev den andra; den andra bilden blev den första. När du ändrar en bilds position justeras de andra bilderna automatiskt.

## **Ställ in bildnummer**

Genom att använda egenskapen [set_FirstSlideNumber()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/set_firstslidenumber/) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)) kan du ange ett nytt nummer för den första bilden i en presentation. Denna operation får de andra bildnumren att beräknas om.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) klassen.  
1. Hämta bildnumret.  
1. Ange bildnumret.  
1. Spara den modifierade presentationen.

Denna C++‑kod demonstrerar en operation där det första bildnumret sätts till 10:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instansierar Presentation-klassen
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Hämtar bildnumret
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Anger bildnumret
	pres->set_FirstSlideNumber(2);
	
	// Sparar den modifierade presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Om du föredrar att hoppa över den första bilden kan du starta numreringen från den andra bilden (och dölja numreringen för den första bilden) på detta sätt:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Anger numret för den första presentationsbilden
presentation->set_FirstSlideNumber(0);

// Visar bildnummer för alla bilder
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Döljer bildnumret för den första bilden
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Sparar den modifierade presentationen
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Vanliga frågor**

**Stämmer bildnumret som en användare ser överens med samlingens nollbaserade index?**

Numret som visas på en bild kan börja från ett godtyckligt värde (t.ex. 10) och måste inte matcha indexet; förhållandet styrs av presentationens [första bildnummer](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/set_firstslidenumber/) inställning.

**Påverkar dolda bilder indexeringen?**

Ja. En dold bild förblir i samlingen och räknas med i indexeringen; "dold" avser visning, inte dess position i samlingen.

**Ändras en bilds index när andra bilder läggs till eller tas bort?**

Ja. Indexen speglar alltid den aktuella ordningen i bilder och beräknas om vid insättnings-, raderings- och flyttoperationer.