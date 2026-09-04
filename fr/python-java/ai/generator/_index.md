---
title: Générateur de diapositives multilingues alimenté par IA
linktitle: Générateur alimenté par IA
type: docs
weight: 40
url: /fr/python-java/ai/generator/
keywords:
- présentation multilingue
- diapositive multilingue
- générateur de présentation IA
- générateur de diapositives IA
- modèle de présentation
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Générez des présentations multilingues à partir de texte avec Aspose.Slides pour Python via Java. Choisissez le niveau de détail du contenu, appliquez un modèle et exportez vers PowerPoint ou PDF."
---
## **Introduction**

Le générateur de présentations IA dans Aspose.Slides pour Python via Java crée des présentations à partir de descriptions de sujet, résumés, citations ou puces. Indiquez la langue requise dans votre invite, choisissez la quantité de contenu, et fournissez éventuellement un modèle de présentation pour définir la mise en page et le design.

Le générateur organise le contenu à l'aide de blocs de texte, de listes à puces et de tableaux. Il ne génère pas d'images ; vous pouvez les ajouter à la présentation résultante ensuite. Vérifiez le contenu et la mise en page générés avant de partager la présentation.

## **How It Works**

[SlidesAIAgent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesaiagent/) utilise un client IA pour communiquer avec un modèle externe. Les exemples ci‑dessus utilisent le [OpenAIWebClient](https://reference.aspose.com/slides/fr/python-java/aspose.slides/openaiwebclient/) intégré. Aspose.Slides traite les réponses du modèle et crée une présentation que vous pouvez modifier ou exporter.

Utilisez [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesaiagent/#generatePresentation) avec une description textuelle et une valeur [PresentationContentAmountType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationcontentamounttype/). La surcharge avec un troisième argument accepte une présentation à utiliser comme modèle de conception.

## **Prerequisites**

Suivez [Installation](/slides/fr/python-java/installation/) pour configurer Python, Java, JPype et Aspose.Slides. Définissez les variables d’environnement `OPENAI_API_KEY` et `OPENAI_MODEL` avant d’exécuter les exemples. Choisissez un modèle pris en charge par le client intégré et disponible pour votre compte API.

{{% alert color="info" title="Note" %}}
Le service IA nécessite une connexion Internet et un accès API distinct. Les invites sont envoyées au service configuré, et ses frais d’utilisation s’appliquent indépendamment de votre licence Aspose.Slides.
{{% /alert %}}

Chaque exemple démarre la JVM uniquement si elle n’est pas déjà en cours d’exécution et la laisse disponible pour les opérations suivantes. Consultez [JVM lifecycle guidance](/slides/fr/python-java/limitations-and-api-differences/#import-the-library) lors de l’adaptation du code pour les notebooks.

## **Generate a Presentation from Text**

Cet exemple génère une présentation en anglais avec une quantité de contenu [Medium](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationcontentamounttype/#Medium) et l’enregistre sous forme de fichier PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Generate a Presentation Using a Template**

Placez `masterPresentation.pptx` dans le répertoire de travail. Cet exemple le charge avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), génère une présentation en espagnol avec un contenu [Detailed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationcontentamounttype/#Detailed) et l’exporte au format PDF. Le modèle et la présentation générée sont libérés, même si la génération ou l’enregistrement échoue.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Si vous devez configurer un proxy ou des délais d’attente de connexion, consultez [Configure the HTTP Connection](/slides/fr/python-java/ai/translator/#configure-the-http-connection). Vous pouvez également transmettre le client résultant au générateur.

## **Key Benefits**

La génération peut réduire le travail de rédaction initial pour les supports de formation, les présentations de produits, les rapports clients et les présentations internes. Les invites contrôlent le sujet et la langue, tandis qu’un modèle vous permet de réutiliser une mise en page de présentation existante.

## **FAQ**

**Comment contrôler la longueur de la présentation générée ?**

Choisissez [Brief](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationcontentamounttype/#Medium) ou [Detailed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Ces réglages influencent à la fois le nombre de diapositives et le niveau de détail de chaque diapositive ; ils ne spécifient pas un nombre exact de diapositives.

**Puis‑je générer des diapositives dans une autre langue ?**

Oui. Incluez la langue demandée dans la description textuelle. Le résultat dépend des capacités linguistiques du modèle sélectionné.

**Puis‑je conserver une version modifiable lors de l’exportation en PDF ?**

Oui. Avant de disposer de la présentation générée, enregistrez‑la également au format PPTX en suivant l’approche du premier exemple.