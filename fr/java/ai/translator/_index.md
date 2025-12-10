---
title: Traducteur de présentation alimenté par l'IA
linktitle: Traducteur alimenté par l'IA
type: docs
weight: 20
url: /fr/java/ai/translator/
keywords:
- Traducteur de présentation IA
- Traducteur de diapositive IA
- Fonctionnalité alimentée par l'IA
- Présentation multilingue
- Diapositive multilingue
- Traduction de présentation
- Traduction de diapositive
- Fonctions guidées par l'IA
- Capacités IA
- Agent IA
- Client Web
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Traduisez les diapositives PowerPoint avec l'IA en utilisant Aspose.Slides pour Java. Localisez les fichiers PPT, PPTX et ODP tout en préservant la mise en page—rapide et convivial pour les développeurs. Essayez-le."
---

## **Aspose.Slides API de traduction de présentation : traduction multilingue des diapositives alimentée par l’IA**

Aspose.Slides est une API puissante pour gérer programmatique des présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle propose des fonctionnalités basées sur l’IA — notamment l’API de traduction de présentation pour du contenu multilingue.

## **Comment ça fonctionne**

Aspose.Slides n’inclut pas de capacités d’IA intégrées, mais s’intègre à des modèles d’IA externes via Internet. Cette fonctionnalité est exposée via la classe [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/) qui utilise une implémentation de l’interface [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) pour communiquer avec les services d’IA.

Vous pouvez utiliser le client intégré [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) pour vous connecter à l’API d’OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) afin d’utiliser un autre fournisseur d’IA ou modèle de langage.

Aspose.Slides gère la communication, analyse les réponses de l’IA et insère intelligemment le contenu traduit tout en préservant la mise en page et le formatage d’origine des diapositives.

{{% alert color="primary" %}}
Notez que l’API d’OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé d’API lors de l’utilisation du client intégré [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais en utilisant le client intégré [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) avec un [model](https://platform.openai.com/docs/models) OpenAI spécifié.
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


Par défaut, le client intégré [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) crée et gère sa propre instance interne de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), en gérant automatiquement son cycle de vie. Cependant, si vous préférez gérer vous‑même la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — notamment pour configurer des paramètres essentiels comme un proxy, ou pour utiliser un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou un autre [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) afin d’optimiser la gestion des ressources et les performances — vous pouvez fournir votre propre instance `HttpURLConnection` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
```java
// Supposons que vous disposez d'une instance HttpURLConnection préconfigurée (par ex., avec des délais d'attente personnalisés, des paramètres de proxy, etc.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Principaux avantages**

L’API de traduction de présentation Aspose.Slides offre une solution alimentée par l’IA pour créer des présentations PowerPoint multilingues. En automatisant la traduction tout en préservant la mise en page et le design, elle fait gagner du temps et réduit les erreurs par rapport aux flux de travail manuels. Que vous soyez développeur, éducateur ou professionnel, cette API vous permet de créer des présentations engageantes et localisées pour un public mondial — élargissant votre portée et améliorant la communication.