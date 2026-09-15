---
title: Prise en charge d'une bibliothèque interrompable
type: docs
weight: 120
url: /fr/python-java/support-for-interruptable-library/
keywords:
- bibliothèque interrompable
- jeton d'interruption
- jeton d'annulation
- tâche de longue durée
- interrompre la tâche
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Rendez les tâches de longue durée annulables avec Aspose.Slides for Python via Java. Interrompez en toute sécurité le rendu et les conversions pour PowerPoint et OpenDocument, avec des exemples."
---
## **Vue d'ensemble**

Aspose.Slides fournit un mécanisme de traitement interrompable pour les tâches de présentation de longue durée, telles que la désérialisation, la sérialisation et le rendu. Ce mécanisme repose sur les classes [InterruptionToken](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/).

Un [InterruptionToken](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontoken/) peut être attribué à [LoadOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/) et passé au constructeur de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Lorsque [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/#interrupt) est appelé, la tâche longue associée est interrompue.

## **Bibliothèque interrompable**

Aspose.Slides for Python via Java fournit les classes [InterruptionToken](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/). Elles vous permettent d'interrompre des tâches de longue durée telles que la désérialisation, la sérialisation et le rendu.

- [InterruptionTokenSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/) est la source du ou des jetons transmis à [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Lorsque [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setInterruptionToken) est appelé et que l'instance [LoadOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/) est transmise au constructeur de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), l'appel à [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/#interrupt) interrompt toute tâche de longue durée associée à cette [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).

Le fragment de code suivant montre comment interrompre une tâche en cours :

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Exécuter l'action dans un thread séparé.
    time.sleep(10)  # Délai d'attente.
    token_source.interrupt()  # Arrêter la conversion.
    conversion_task.result()
```

## **FAQ**

**Quel est le but de la bibliothèque d’interruption Aspose.Slides ?**

Elle fournit un mécanisme pour interrompre les opérations longues—comme le chargement, l’enregistrement ou le rendu de présentations—avant qu’elles ne se terminent. Cela est utile lorsqu’il faut limiter le temps de traitement ou que la tâche n’est plus nécessaire.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontoken/) est transmis à l’API Aspose.Slides et vérifié pendant les opérations longues.
- [InterruptionTokenSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/) est utilisé dans votre code pour créer des jetons et déclencher des interruptions en appelant [interrupt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Quelles tâches peuvent être interrompues ?**

Toute tâche Aspose.Slides qui accepte un [InterruptionToken](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontoken/)—comme le chargement d’une présentation avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) ou l’enregistrement avec [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save)—peut être interrompue.

**L’interruption se produit-elle immédiatement ?**

Non. L’interruption est coopérative : l’opération vérifie périodiquement le jeton et s’arrête dès qu’elle détecte que [interrupt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/#interrupt) a été appelé.

**Que se passe-t-il si j’appelle [interrupt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/#interrupt) après qu’une tâche soit déjà terminée ?**

Rien—l’appel n’a aucun effet si la tâche correspondante est déjà terminée.

**Puis-je réutiliser le même [InterruptionTokenSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/) pour plusieurs tâches ?**

Oui—mais après avoir appelé [interrupt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/interruptiontokensource/#interrupt) sur cette source, toutes les tâches utilisant ses jetons seront interrompues. Utilisez des sources de jetons séparées pour gérer les tâches de manière indépendante.