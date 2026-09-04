---
title: Traducteur de Présentations Alimenté par IA
linktitle: Traducteur Alimenté par IA
type: docs
weight: 20
url: /fr/python-java/ai/translator/
keywords:
- Traducteur de présentation IA
- Traducteur de diapositive IA
- Présentation multilingue
- Traduction de présentation
- Traduction de diapositive
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Traduisez des présentations avec l'IA en utilisant Aspose.Slides pour Python via Java. Localisez le texte des diapositives et enregistrez la présentation traduite au format PowerPoint ou PDF."
---
## **Introduction**

Aspose.Slides for Python via Java fournit une API de traduction de présentation IA pour localiser le contenu des diapositives. Traduisez une présentation existante vers une langue spécifiée, puis enregistrez la version traduite dans le format requis par votre public.

## **Comment ça fonctionne**

[SlidesAIAgent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesaiagent/) communique avec un service IA externe via un client IA. Les exemples utilisent le [OpenAIWebClient](https://reference.aspose.com/slides/fr/python-java/aspose.slides/openaiwebclient/) intégré.

[SlidesAIAgent.translate](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesaiagent/#translate) met à jour la présentation qui lui est transmise. Aspose.Slides traite les réponses IA et remplace le texte des diapositives tout en conservant la mise en page et le formatage existants. Examinez le résultat : le texte traduit peut être plus long que l'original et nécessiter des ajustements de mise en page.

## **Prérequis**

Suivez [Installation](/slides/fr/python-java/installation/) pour configurer la bibliothèque et son environnement d'exécution. Définissez les variables d'environnement `OPENAI_API_KEY` et `OPENAI_MODEL` avant d'exécuter les exemples. Choisissez un modèle pris en charge par le client intégré et disponible pour votre compte API.

{{% alert color="info" title="Note" %}}
La traduction nécessite une connexion Internet et envoie le texte de la présentation au service IA configuré. L'accès à l'API et les frais d'utilisation sont séparés de votre licence Aspose.Slides.
{{% /alert %}}

Les exemples réutilisent une JVM active ou la démarrent si nécessaire. Consultez [JVM lifecycle guidance](/slides/fr/python-java/limitations-and-api-differences/#import-the-library) pour l'utilisation dans les notebooks.

## **Traduire une présentation**

Placez `sample.pptx` dans le répertoire de travail. Cet exemple le charge avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), traduit son texte en japonais et enregistre le résultat au format PDF. Il libère la présentation et ferme le client IA même si une opération échoue.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Configurer la connexion HTTP**

Par défaut, [OpenAIWebClient](https://reference.aspose.com/slides/fr/python-java/aspose.slides/openaiwebclient/) gère sa connexion HTTP en interne. Son constructeur à quatre arguments accepte également un [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) Java géré externement. Utilisez cette surcharge lorsque vous devez configurer un proxy ou des délais d'attente de connexion.

L'exemple suivant crée un proxy HTTP Java avec [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) et ouvre une connexion via [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Remplacez `proxy.example.com` et le port par vos paramètres de proxy. La connexion est transmise directement via JPype ; une session HTTP Python ne peut pas être utilisée à sa place.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **Avantages clés**

La traduction automatisée aide à préparer du matériel de formation multilingue, des présentations de produits et des rapports clients tout en réutilisant la conception des diapositives existante. Enregistrez une présentation modifiable pour une révision ultérieure ou exportez un PDF pour la distribution.

## **FAQ**

**La traduction crée‑t‑elle un objet présentation distinct ?**

Non. [SlidesAIAgent.translate](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesaiagent/#translate) modifie la présentation fournie. Enregistrez‑la sous un nouveau nom de fichier pour conserver le fichier original inchangé.

**Comment spécifier la langue cible ?**

Passez le nom de la langue, comme `"Japanese"` ou `"Spanish"`, en tant que deuxième argument. La qualité de la traduction et la couverture linguistique dépendent du modèle sélectionné.

**Puis‑je traduire sans utiliser de proxy ?**

Oui. Utilisez le constructeur client à trois arguments présenté dans le premier exemple. L'exemple de connexion personnalisée n'est requis que lorsque votre application nécessite des paramètres de connexion explicites.