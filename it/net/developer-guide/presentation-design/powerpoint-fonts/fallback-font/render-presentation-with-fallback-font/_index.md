---
title: Renderizza presentazioni con font di fallback in .NET
linktitle: Renderizza presentazioni
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
description: "Renderizza le presentazioni con font di fallback in Aspose.Slides per .NET – mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice C# passo-passo."
---
## **Panoramica**

Aspose.Slides consente di rendere le presentazioni utilizzando regole di caratteri di fallback. Questo articolo mostra come creare una raccolta di regole di caratteri di fallback, modificarne le regole rimuovendo o aggiungendo caratteri di fallback e assegnare la raccolta alla proprietà `FontsManager.FontFallBackRulesCollection`.

Una volta che la raccolta di regole di caratteri di fallback è assegnata al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di diapositiva e il salvataggio come immagine PNG.

## **Renderizzare una diapositiva usando regole di caratteri di fallback**

L'esempio seguente comprende questi passaggi:

1. Creiamo una [raccolta di regole di caratteri di fallback](/slides/it/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrule/methods/remove) una regola di caratteri di fallback e [AddFallBackFonts()](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) a un'altra regola.
1. Impostiamo la raccolta di regole su [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) property.
1. Con il metodo [Presentation.Save()](https://reference.aspose.com/slides/it/net/aspose.slides.presentation/save/methods/4) possiamo salvare la presentazione nello stesso formato o in un altro. Dopo che la raccolta di regole di fallback è impostata su FontsManager, queste regole vengono applicate durante qualsiasi operazione sulla presentazione: salvataggio, rendering, conversione, ecc.

```c#
using Aspose.Slides;

// Crea una nuova istanza di una raccolta di regole
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// crea un certo numero di regole
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Tentativo di rimuovere il font di fallback "Tahoma" dalle regole caricate
	fallBackRule.Remove("Tahoma");

	// E per aggiornare le regole per l'intervallo specificato
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Possiamo anche rimuovere tutte le regole esistenti dalla lista, mantenendo almeno una regola con cui renderizzare
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Assegnazione di una lista di regole preparata per l'uso
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendering della miniatura usando la raccolta di regole inizializzate e salvataggio in PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Leggi di più su [Salvataggio e conversione nella presentazione](/slides/it/net/convert-powerpoint-to-png/).
{{% /alert %}}