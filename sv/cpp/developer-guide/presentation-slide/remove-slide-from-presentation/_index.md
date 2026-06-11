---
title: Ta bort bilder från presentationer i C++
linktitle: Ta bort bild
type: docs
weight: 30
url: /sv/cpp/remove-slide-from-presentation/
keywords:
- ta bort bild
- radera bild
- ta bort oanvänd bild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Ta enkelt bort bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Få tydliga kodexempel och förbättra ditt arbetsflöde."
---
## **Introduktion**

Om en bild (eller dess innehåll) blir överflödig kan du ta bort den. Aspose.Slides tillhandahåller klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) som kapslar in [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/), vilket är ett arkiv för alla bilder i en presentation. Genom att använda pekare (referens eller index) för ett känt [ISlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/)-objekt kan du ange vilken bild du vill ta bort. 

## **Ta bort en bild med referens**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta en referens till bilden du vill ta bort via dess ID eller index.
3. Ta bort den refererade bilden från presentationen.
4. Spara den ändrade presentationen. 

Den här C++-koden visar hur du tar bort en bild via dess referens: 

```c++
	// Sökvägen till dokumentkatalogen
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Instansierar ett Presentation-objekt som representerar en presentationsfil
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Kommer åt en bild via dess index i bildsamlingen
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Tar bort en bild via dess referens
	pres->get_Slides()->Remove(slide);

	// Sparar den ändrade presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Ta bort en bild med index**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Ta bort bilden från presentationen via dess positionsindex.
3. Spara den ändrade presentationen. 

Den här C++-koden visar hur du tar bort en bild via dess index: 

```c++
	// Sökvägen till dokumentkatalogen
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instansierar ett Presentation-objekt som representerar en presentationsfil
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Tar bort en bild via dess bildindex
	pres->get_Slides()->RemoveAt(0);

	// Sparar den ändrade presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (från klassen [Compress](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/)) för att låta dig ta bort oönskade och oanvända layoutbilder. Den här C++-koden visar hur du tar bort en layoutbild från en PowerPoint-presentation:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Ta bort oanvända maste­rbilder**

Aspose.Slides tillhandahåller metoden [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (från klassen [Compress](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/)) för att låta dig ta bort oönskade och oanvända maste­rbilder. Den här C++-koden visar hur du tar bort en maste­rbild från en PowerPoint-presentation:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Vanliga frågor**

**Vad händer med bildindex efter att jag har raderat en bild?**

Efter raderingen omindexerar [collection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidecollection/) sig: varje efterföljande bild flyttas ett steg åt vänster, så tidigare indexnummer blir föråldrade. Om du behöver en stabil referens, använd varje bilds beständiga ID istället för dess index.

**Är en bilds ID annorlunda än dess index, och ändras det när närliggande bilder raderas?**

Ja. Indexet är bildens position och ändras när bilder läggs till eller tas bort. Bild‑ID är en beständig identifierare och ändras inte när andra bilder raderas.

**Hur påverkar radering av en bild bildsektioner?**

Om bilden tillhörde en sektion kommer den sektionen helt enkelt att ha en bild mindre. Sektionens struktur förblir; om en sektion blir tom kan du [ta bort eller omorganisera sektioner](/slides/sv/cpp/slide-section/) vid behov.

**Vad händer med anteckningar och kommentarer som är knutna till en bild när den raderas?**

[Notes](/slides/sv/cpp/presentation-notes/) och [comments](/slides/sv/cpp/presentation-comments/) är knutna till den specifika bilden och tas bort tillsammans med den. Innehållet i övriga bilder påverkas inte.

**Hur skiljer sig radering av bilder från att rensa oanvända layouter/mastrar?**

Radering tar bort specifika vanliga bilder från presentationen. Rensning av oanvända layouter/mastrar tar bort layout‑ eller maste­rbilder som inget refererar till, vilket minskar filstorleken utan att ändra återstående bildinnehåll. Dessa åtgärder är komplementära: vanligtvis raderas först, sedan rensas.