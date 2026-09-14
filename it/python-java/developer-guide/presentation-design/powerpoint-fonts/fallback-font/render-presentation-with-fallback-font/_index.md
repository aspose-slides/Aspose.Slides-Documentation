---
title: Renderizzare presentazioni con font di riserva in Python tramite Java
linktitle: Renderizzare presentazioni
type: docs
weight: 30
url: /it/python-java/render-presentation-with-fallback-font/
keywords:
- font di riserva
- renderizzare PowerPoint
- renderizzare presentazione
- renderizzare diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Renderizza presentazioni con font di riserva in Aspose.Slides per Python tramite Java – mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice Python passo-passo."
---
## **Panoramica**

Aspose.Slides consente di rendere presentazioni utilizzando le regole di font di riserva. Questo articolo mostra come creare una raccolta di regole di font di riserva, modificare le sue regole rimuovendo o aggiungendo font di riserva e assegnare la raccolta utilizzando il metodo [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Una volta che la raccolta di regole di font di riserva è assegnata al [FontsManager] della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di diapositiva e il salvataggio come immagine JPEG.

## **Render di una diapositiva con regole di font di riserva**

L'esempio seguente comprende questi passaggi:

1. [Crea una raccolta di regole di font di riserva](/slides/it/python-java/create-fallback-fonts-collection/).
1. [Rimuovi](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/#remove) un font di riserva da una regola e [aggiungi font di riserva](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) a un'altra regola.
1. Assegna la raccolta di regole utilizzando [setFontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) sul gestore dei font restituito da [getFontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getFontsManager).
1. Usa il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per salvare la presentazione nello stesso formato o in un altro formato. Dopo che la raccolta di regole di font di riserva è assegnata a [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/), queste regole vengono applicate durante le operazioni sulla presentazione: salvataggio, rendering, conversione e così via.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Crea una nuova raccolta di regole.
fallback_rules = FontFallBackRulesCollection()

# Crea diverse regole.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Prova a rimuovere il font di riserva "Tahoma" dalle regole.
    fallback_rule.remove("Tahoma")

    # Aggiorna le regole per l'intervallo specificato.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Rimuovi una regola esistente, mantenendo almeno una regola per il rendering.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Assegna la raccolta di regole preparata.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Renderizza una miniatura usando la raccolta di regole configurata.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Salva l'immagine su disco in formato JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Leggi di più su come [convertire PPT e PPTX in JPG in Python tramite Java](/slides/it/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}