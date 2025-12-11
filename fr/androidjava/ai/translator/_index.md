---
title: Traducteur de présentation alimenté par IA
linktitle: Traducteur alimenté par IA
type: docs
weight: 20
url: /fr/androidjava/ai/translator/
keywords:
- Traducteur de présentation IA
- Traducteur de diapositive IA
- Fonctionnalité alimentée par IA
- Présentation multilingue
- Diapositive multilingue
- Traduction de présentation
- Traduction de diapositive
- Fonctionnalités pilotées par IA
- Capacités IA
- Agent IA
- Client Web
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Traduisez les diapositives PowerPoint avec l'IA en utilisant Aspose.Slides pour Android via Java. Localisez les fichiers PPT, PPTX et ODP tout en conservant la mise en page—rapide et convivial pour les développeurs. Essayez-le."
---

## **API de traduction de présentation Aspose.Slides : traduction de diapositives multilingue propulsée par l'IA**

Aspose.Slides est une API puissante permettant de gérer programmétiquement les présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle propose des fonctionnalités basées sur l'IA – telles que l'API de traduction de présentation pour le contenu multilingue des diapositives.

## **Comment cela fonctionne**

Aspose.Slides ne comprend pas de capacités d'IA intégrées mais s'intègre à des modèles d'IA externes via Internet. Cette fonctionnalité est exposée via la classe [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) qui utilise une implémentation de l'interface [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) pour communiquer avec les services d'IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) intégré pour vous connecter à l'API d'OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) afin d'utiliser un autre fournisseur d'IA ou modèle linguistique.

Aspose.Slides gère la communication, analyse les réponses de l'IA et insère intelligemment le contenu traduit tout en préservant la mise en page et le formatage d'origine de la diapositive.

{{% alert color="primary" %}}
Notez que l'API OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé API lors de l'utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) intégré.
{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais en utilisant le [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) intégré avec un [modèle](https://platform.openai.com/docs/models) OpenAI spécifié.
```java
// Charger une présentation à traduire.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiser SlidesAIAgent avec le client IA.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Traduire la présentation en japonais.
    aiAgent.translate(presentation, "japanese");

    // Enregistrer la présentation traduite au format PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) intégré crée et gère sa propre instance interne de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gérant son cycle de vie automatiquement. Cependant, si vous préférez gérer vous‑même le [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), principalement pour configurer des paramètres essentiels tels qu'un proxy, ou pour utiliser un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) différent pour une meilleure gestion des ressources et des performances, vous pouvez fournir votre propre instance `HttpURLConnection` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
```java
// Supposons que vous avez une instance HttpURLConnection préconfigurée (par exemple, avec des délais d'attente personnalisés, des paramètres de proxy, etc.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Avantages clés**

L'API de traduction de présentation Aspose.Slides offre une solution alimentée par l'IA pour fournir des présentations PowerPoint multilingues. En automatisant la traduction tout en préservant la mise en page et le design, elle permet de gagner du temps et de réduire les erreurs par rapport aux flux de travail manuels. Que vous soyez développeur, éducateur ou professionnel du business, cette API vous permet de créer des présentations attrayantes et localisées pour un public mondial – élargissant votre portée et améliorant la communication.