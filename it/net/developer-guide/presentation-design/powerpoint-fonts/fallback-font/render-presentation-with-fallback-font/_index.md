---
title: Renderizzare presentazioni con font di fallback in .NET
linktitle: Renderizzare presentazioni
type: docs
weight: 30
url: /it/net/render-presentation-with-fallback-font/
keywords:
- font di fallback
- renderizzare PowerPoint
- renderizzare presentazione
- renderizzare diapositiva
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Renderizza presentazioni con font di fallback in Aspose.Slides per .NET – mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice C# passo passo."
---
## **Panoramica**

Aspose.Slides consente di rendere presentazioni utilizzando regole di font di fallback. Questo articolo mostra come creare una raccolta di regole di font di fallback, modificare le sue regole rimuovendo o aggiungendo font di fallback e assegnare la raccolta alla proprietà `FontsManager.FontFallBackRulesCollection`.

Una volta che la raccolta di regole di font di fallback è assegnata al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di diapositiva e il suo salvataggio come immagine PNG.

## **Esegui il rendering di una diapositiva usando regole di font di fallback**

1. Creiamo una [collezione di regole di font di fallback](/slides/it/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrule/methods/remove) una regola di font di fallback e [AddFallBackFonts()](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) a un'altra regola.
3. Impostare la raccolta di regole sulla proprietà [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
4. Con il metodo [Presentation.Save()](https://reference.aspose.com/slides/it/net/aspose.slides.presentation/save/methods/4) possiamo salvare la presentazione nello stesso formato o in un altro. Dopo che la raccolta di regole di font di fallback è impostata su FontsManager, queste regole vengono applicate durante qualsiasi operazione sulla presentazione: salvataggio, rendering, conversione, ecc.

```c#
// Crea una nuova istanza di una raccolta di regole
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// crea un numero di regole
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Tentativo di rimuovere il font FallBack "Tahoma" dalle regole caricate
	fallBackRule.Remove("Tahoma");

	// E per aggiornare le regole per l'intervallo specificato
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// In questo modo possiamo rimuovere qualsiasi regola esistente dall'elenco
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Assegnazione di un elenco di regole preparato per l'uso
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendering della miniatura utilizzando la raccolta di regole inizializzate e salvataggio in PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
Leggi di più su [Salvataggio e conversione nella presentazione](/slides/it/net/convert-powerpoint-to-png/).
{{% /alert %}}