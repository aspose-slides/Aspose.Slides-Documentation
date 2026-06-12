---
title: Renderizzare le presentazioni con font di fallback in Python
linktitle: Renderizzare le presentazioni
type: docs
weight: 30
url: /it/python-net/render-presentation-with-fallback-font/
keywords:
- font di fallback
- renderizzare PowerPoint
- renderizzare presentazione
- renderizzare diapositiva
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Renderizza le presentazioni con font di fallback in Aspose.Slides per Python tramite .NET - mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice passo-passo."
---
## **Panoramica**

Aspose.Slides consente di renderizzare le presentazioni utilizzando regole di font di fallback. Questo articolo mostra come creare una raccolta di regole di font di fallback, modificare le sue regole rimuovendo o aggiungendo font di fallback e assegnare la raccolta alla proprietà `FontsManager.font_fall_back_rules_collection`.

Una volta che la raccolta di regole di font di fallback è assegnata al `fonts_manager` della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di una diapositiva e il salvataggio come immagine PNG.

## **Renderizzare una Diapositiva Utilizzando Regole di Font di Fallback**

L'esempio seguente include questi passaggi:

1. Creiamo [creare la raccolta di regole di font di fallback](/slides/it/python-net/create-fallback-fonts-collection/).
1. [Rimuovere](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontfallbackrule/remove/) una regola di font di fallback e [add_fall_back_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) a un'altra regola.
1. Impostare la raccolta di regole nella proprietà [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
1. Con il metodo [Presentation.save()](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) possiamo salvare la presentazione nello stesso formato o salvarla in un altro. Dopo che la raccolta di regole di font di fallback è impostata su FontsManager, queste regole vengono applicate durante tutte le operazioni sulla presentazione: salvataggio, rendering, conversione, ecc.

```py
import aspose.slides as slides

# Crea una nuova istanza di una raccolta di regole
rulesList = slides.FontFallBackRulesCollection()

# crea un certo numero di regole
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Tentativo di rimuovere il font di fallback "Tahoma" dalle regole caricate
	fallBackRule.remove("Tahoma")

	# E per aggiornare le regole per l'intervallo specificato
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Possiamo anche rimuovere eventuali regole esistenti dalla lista
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Assegnazione di una lista di regole preparata per l'uso
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Renderizzazione della miniatura utilizzando la raccolta di regole inizializzata e salvataggio in PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Leggi di più su come [Convertire le diapositive PowerPoint in PNG con Python](/slides/it/python-net/convert-powerpoint-to-png/).
{{% /alert %}}