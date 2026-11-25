---
title: Interrompre les opérations de présentation de longue durée en Python
linktitle: Interrompre les opérations de présentation
type: docs
weight: 150
url: /fr/python-net/support-for-interruptable-library/
keywords:
- opérations interrompables
- jeton d'interruption
- annuler l'export PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Apprenez comment annuler une conversion de présentation en Python et renvoyer la liste des diapositives qui ont terminé l'exportation avant l'annulation."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET prend en charge l’annulation coopérative lors d’opérations longues comme le chargement, l’enregistrement et le rendu de présentations. Lorsque vous exportez les diapositives individuellement, vous pouvez également vérifier l’annulation entre les diapositives et renvoyer les numéros des diapositives qui ont terminé l’exportation.

## **Annuler une conversion de présentation**

Créez un [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), assignez son [jeton](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) à [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), et transmettez les options au [constructeur Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Le jeton s’applique à la présentation pendant toute sa durée de vie. Pour demander l’annulation depuis votre application, appelez [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

L’exemple convertit `sample.pptx` en `sample.pdf`. Un [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) appelle `source.interrupt` après 20 secondes. Démarrer le minuteur avant d’ouvrir le fichier fait que le délai d’attente s’applique à la fois au chargement et à l’enregistrement. Une application avec un bouton Annuler peut appeler la même méthode depuis son gestionnaire d’événement.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

La vérification explicite après le chargement saute l’exportation si le délai d’attente est déjà écoulé. Si le chargement ou l’enregistrement observe la demande, l’exception d’annulation atteint l’appelant. Un enregistrement peut également se terminer avant d’observer la demande, auquel cas le PDF est complet.

## **Arrêter avant de traiter la diapositive suivante**

Vérifiez [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) avant chaque exportation. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) accepte une liste de numéros de diapositives commençant à 1. Ajoutez un numéro à la liste des terminées uniquement après que son PDF ait été enregistré avec succès.

Utilisez un fichier nommé `sample.pptx` contenant au moins deux diapositives. Pour rendre le résultat reproductible, l’exemple demande l’annulation dès que la diapositive 1 est terminée. Dans une application, la demande peut provenir d’un autre thread pendant qu’une diapositive est enregistrée.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

L’exemple écrit `slide-1.pdf` et affiche `Starting slide 1` suivi de `Completed: [1]`. L’itération suivante voit la demande avant de démarrer la diapositive 2. Si l’annulation interrompt un enregistrement, le gestionnaire d’exception renvoie les numéros enregistrés par les itérations précédentes. D’autres erreurs d’exportation atteignent l’appelant.

Si l’appelant doit gérer l’annulation comme une exception, remplacez la vérification et son `break` en haut de la boucle par [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Supprimez également le `try`/`except` autour de l’enregistrement. Avec les mêmes entrées, la diapositive 1 est enregistrée et la deuxième itération lève une exception d’annulation avant de démarrer la diapositive 2.

## **FAQ**

**Quand la demande d'annulation prend‑elle effet ?**

Une opération interrompable vérifie son jeton périodiquement. Elle s’arrête lorsqu’elle observe la demande. Une opération déjà terminée conserve son résultat.

**Quelle est la différence entre la source et le jeton ?**

La source permet à votre application de demander l’annulation. Le jeton permet à la fois à la présentation et à votre propre code de vérifier cette demande.

**Plusieurs opérations peuvent-elles partager une source ?**

Oui. Appeler `interrupt` demande l’annulation pour chaque opération utilisant un jeton provenant de cette source. Donnez à chaque opération sa propre source si vous devez l’annuler indépendamment.