---
title: Traducteur de présentation alimenté par l'IA
linktitle: Traducteur alimenté par l'IA
type: docs
weight: 20
url: /fr/python-net/ai/translator/
keywords:
- traducteur de présentation IA
- traducteur de diapositive IA
- fonctionnalité alimentée par l'IA
- présentation multilingue
- diapositive multilingue
- traduction de présentation
- traduction de diapositive
- fonctionnalités pilotées par l'IA
- capacités d'IA
- agent IA
- client Web
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Traduisez les diapositives PowerPoint avec l'IA en utilisant Aspose.Slides pour Python. Localisez PPT, PPTX et ODP tout en conservant la mise en page—rapide et convivial pour les développeurs. Essayez-le."
---
## **Introduction**

Aspose.Slides est une API puissante pour gérer programmétiquement les présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle offre des fonctionnalités basées sur l'IA - comme l'[Presentation Translation API](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/) pour du contenu de diapositives multilingue.

## **Comment ça fonctionne**

Aspose.Slides ne comprend pas de capacités d'IA intégrées, mais s'intègre à des modèles d'IA externes via Internet. Cette fonctionnalité est exposée via la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/slidesaiagent/), qui utilise les sous‑classes [IAIWebClient](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/iaiwebclient/) pour communiquer avec les services d'IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/openaiwebclient/) intégré pour vous connecter à l'API d'OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/iaiwebclient/) afin d’utiliser un autre fournisseur d'IA ou modèle de langage.

Aspose.Slides gère la communication, analyse les réponses de l'IA et insère intelligemment le contenu traduit tout en préservant la mise en page et le formatage originaux de la diapositive.

{{% alert color="info" %}}
Notez que l'API OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé API lors de l’utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/openaiwebclient/) intégré.
{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais en utilisant le [OpenAIWebClient](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/openaiwebclient/) intégré avec un OpenAI [model](https://platform.openai.com/docs/models) spécifié.

```py
import aspose.slides as slides

# Charger une présentation à traduire.
with slides.Presentation("sample.pptx") as presentation:

    # Créer un client IA avec OpenAIWebClient, en spécifiant votre modèle et la clé API.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Initialiser SlidesAIAgent avec le client IA.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Traduire la présentation en japonais.
        ai_agent.translate(presentation, "japanese")

        # Enregistrer la présentation traduite en PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Exemple Azure OpenAI**

Depuis la version **26.7.0**, Aspose.Slides pour Python via .NET prend en charge les fournisseurs compatibles OpenAI, y compris Azure OpenAI. Vous pouvez configurer le traducteur pour utiliser votre déploiement Azure interne avec le [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Cet extrait montre comment traduire une présentation en utilisant votre point de terminaison Azure OpenAI. Remplacez les valeurs d’espace réservé par le nom de votre déploiement, votre clé API et l'URL du point de terminaison.

## **Avantages clés**

[Presentation Translation API](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ai/) d'Aspose.Slides offre une solution alimentée par l'IA pour créer des présentations PowerPoint multilingues. En automatisant la traduction tout en conservant la mise en page et le design, elle fait gagner du temps et minimise les erreurs par rapport aux processus manuels. Que vous soyez développeur, éducateur ou professionnel du business, cette API vous permet de créer des présentations attrayantes et localisées pour un public mondial – élargissant votre portée et améliorant la communication.