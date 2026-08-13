---
title: Renderizzare presentazioni con font di fallback in C++
linktitle: Renderizzare Presentazioni
type: docs
weight: 30
url: /it/cpp/render-presentation-with-fallback-font/
keywords:
- font di fallback
- render PowerPoint
- renderizzare presentazione
- renderizzare diapositiva
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Renderizzare presentazioni con font di fallback in Aspose.Slides per C++ - mantenere il testo coerente tra PPT, PPTX e ODP con esempi di codice C++ passo-passo."
---
## **Panoramica**

Aspose.Slides consente di renderizzare presentazioni utilizzando regole di font di fallback. Questo articolo mostra come creare una raccolta di regole di font di fallback, modificare le sue regole rimuovendo o aggiungendo font di fallback e assegnare la raccolta utilizzando il metodo `FontsManager::set_FontFallBackRulesCollection`.

Una volta che la raccolta di regole di font di fallback è assegnata al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di una diapositiva e il salvataggio come immagine PNG.

## **Renderizzare una Diapositiva Utilizzando Regole di Font di Fallback**

L'esempio seguente include questi passaggi:

1. [Creiamo la raccolta di regole di font di fallback](/slides/it/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/remove/) una regola di font di fallback e [AddFallBackFonts()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) a un'altra regola.
3. Passiamo la raccolta di regole a [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) metodo.
4. Con il metodo [Presentation::Save()](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) possiamo salvare la presentazione nello stesso formato o in un altro. Dopo che la raccolta di regole di font di fallback è impostata su FontsManager, queste regole vengono applicate durante qualsiasi operazione sulla presentazione: salvataggio, rendering, conversione, ecc.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// Crea una nuova istanza di una raccolta di regole
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Crea un certo numero di regole
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Tentativo di rimuovere il font di fallback "Tahoma" dalle regole caricate
	fallBackRule->Remove(u"Tahoma");

	// E per aggiornare le regole per l'intervallo specificato
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) &&
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Possiamo anche rimuovere eventuali regole esistenti dalla lista
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assegnazione di una lista di regole preparata per l'uso
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering della miniatura usando la raccolta di regole inizializzata e salvando in PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
Leggi di più su come [Convertire le Diapositive PowerPoint in PNG in C++](/slides/it/cpp/convert-powerpoint-to-png/).
{{% /alert %}}