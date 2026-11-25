---
title: Interrompre les opérations de présentation de longue durée en Python
linktitle: Interrompre les opérations de présentation
type: docs
weight: 120
url: /fr/python-java/support-for-interruptable-library/
keywords:
- opérations interrompables
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
description: "Apprenez comment annuler les opérations de présentation de longue durée dans Aspose.Slides pour Python via Java et retourner un résultat partiel lors de l'exportation des diapositives dans une boucle."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java peut interrompre les opérations de longue durée telles que le chargement, l'enregistrement et le rendu des présentations. Votre application peut utiliser le même jeton d'interruption pour arrêter une boucle avant qu'elle ne commence à traiter la diapositive suivante.

## **Interrompre une opération de présentation**

Créez un [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), obtenez son jeton avec [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), et transmettez le jeton à [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Transmettez les options de chargement au [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Pour demander l'annulation, appelez [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) sur la source. Une opération interrompable s'arrête lorsqu'elle constate la demande. Utilisez `jpype.JClass` pour intercepter l'exception Java `com.aspose.slides.exceptions.OperationCanceledException` en Python.

L'exemple convertit `sample.pptx` en `sample.ppt` sur un thread d'arriere-plan. Le thread appelant attend jusqu'à 10 secondes que la conversion se termine. Si la conversion est toujours en cours, il demande l'annulation et attend que le travailleur se termine.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Connecter un délai d'attente Python à Aspose.Slides**

Pour définir une limite de temps sur une opération de présentation, utilisez un [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) pour appeler [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) lorsque le délai d'attente expire. L'exemple autorise 20 secondes pour charger `sample.pptx` et l'exporter vers `sample.pdf`. Si l'exportation se termine rapidement, l'application annule la requête planifiée.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Arrêter avant de traiter la diapositive suivante**

Utilisez le même [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) pour la présentation et la boucle qui exporte ses diapositives. Vérifiez [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) avant chaque exportation. Si l'appelant peut utiliser un résultat partiel, renvoyez les numéros de diapositive pour les exportations qui se sont terminées avec succès.

Utilisez une présentation nommée `sample.pptx` contenant au moins deux diapositives. La surcharge [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) qui accepte un tableau Java `int[]` utilise des numéros de diapositive à partir de 1. Utilisez `jpype.JArray(jpype.JInt)` pour créer ce tableau en Python. L'exemple enregistre chaque diapositive dans un PDF distinct et demande l'annulation immédiatement après avoir enregistré la première exportation réussie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

L'exemple écrit `slide-1.pdf` et affiche `Starting slide 1` suivi de `Completed: [1]`. La boucle constate la demande avant de démarrer la diapositive 2. Si l'annulation intervient pendant un enregistrement, la boucle se termine avant d'enregistrer cette diapositive comme terminée.

Si l'appelant doit gérer l'annulation, remplacez la vérification et son `break` en haut de la boucle par `token.throwIfInterruptionRequested()`. Supprimez le `try`/`except` autour de l'enregistrement afin que l'annulation pendant une exportation atteigne également l'appelant. Avec les mêmes paramètres, l'exemple n'affiche que `Starting slide 1` et écrit `slide-1.pdf`. Au début de la deuxième itération, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) lève `com.aspose.slides.exceptions.OperationCanceledException` avant que l'exportation suivante ne commence. L'exception remonte à l'appelant avant que la fonction ne puisse retourner la liste.

## **FAQ**

**Quand devrais-je demander l'annulation ?**

Demandez l'annulation lorsqu'une opération dépasse votre limite de temps ou lorsque votre application n'a plus besoin du résultat.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

La source permet à votre application de demander l'annulation. Le jeton permet à Aspose.Slides et à votre application de vérifier cette demande.

**Puis-je annuler une opération depuis un minuteur Python ?**

Oui. Planifiez un appel à [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) sur la source associée à la présentation.

**Quelles opérations puis-je interrompre ?**

Vous pouvez interrompre le chargement, l'enregistrement et le rendu. Transmettez le jeton au [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). La présentation pourra alors détecter l'annulation lors d'opérations ultérieures comme l'enregistrement en PDF.

**Une opération s'arrête-t-elle immédiatement ?**

L'annulation est coopérative. Une opération vérifie le jeton périodiquement et s'arrête lorsqu'elle constate la demande.

**Que se passe-t-il si j'appelle [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) après la fin d'une opération ?**

L'opération terminée conserve son résultat.

**Plusieurs opérations peuvent-elles partager un [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Oui. Appeler [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) demande l'annulation de chaque opération qui utilise un jeton de cette source. Utilisez une source distincte pour chaque opération que vous souhaitez annuler indépendamment.