---
title: Esegui il rendering delle presentazioni con font di fallback in С++
linktitle: Esegui il rendering delle presentazioni
type: docs
weight: 30
url: /it/cpp/render-presentation-with-fallback-font/
keywords:
- font di fallback
- render PowerPoint
- render presentazione
- render diapositiva
- PowerPoint
- OpenDocument
- presentazione
- С++
- Aspose.Slides
description: "Esegui il rendering delle presentazioni con font di fallback in Aspose.Slides per С++ – mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice С++ passo-passo."
---
## **Panoramica**

Aspose.Slides consente di rendere le presentazioni utilizzando regole di font di fallback. Questo articolo mostra come creare una raccolta di regole di font di fallback, modificare le sue regole rimuovendo o aggiungendo font di fallback, e assegnare la raccolta usando il metodo `FontsManager::set_FontFallBackRulesCollection`.

Una volta che la raccolta di regole di font di fallback è assegnata al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura della diapositiva e il salvataggio come immagine PNG.

## **Eseguire il rendering di una diapositiva utilizzando regole di font di fallback**

L'esempio seguente include questi passaggi:

1. Creiamo [crea raccolta di regole di font di fallback](/slides/it/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/remove/) una regola di font di fallback e [AddFallBackFonts()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) a un'altra regola.
1. Passare la raccolta di regole al metodo [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Con il metodo [Presentation::Save()](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save()) possiamo salvare la presentazione nello stesso formato o salvarla in un altro. Dopo che la raccolta di regole di font di fallback è impostata su FontsManager, queste regole vengono applicate durante qualsiasi operazione sulla presentazione: salvataggio, rendering, conversione, ecc.

``` cpp
// Crea una nuova istanza di una raccolta di regole
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Crea diverse regole
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Tentativo di rimuovere il font FallBack "Tahoma" dalle regole caricate
	fallBackRule->Remove(u"Tahoma");

	// E aggiornare le regole per l'intervallo specificato
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Possiamo anche rimuovere tutte le regole esistenti dall'elenco
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Leggi di più su come [Converti le diapositive PowerPoint in PNG in C++](/slides/it/cpp/convert-powerpoint-to-png/).
{{% /alert %}}