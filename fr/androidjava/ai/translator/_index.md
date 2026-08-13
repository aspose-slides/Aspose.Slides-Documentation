---
title: Traducteur de présentation alimenté par l'IA
linktitle: Traducteur alimenté par l'IA
type: docs
weight: 20
url: /fr/androidjava/ai/translator/
keywords:
- traducteur de présentation IA
- traducteur de diapositive IA
- fonctionnalité alimentée par IA
- présentation multilingue
- diapositive multilingue
- traduction de présentation
- traduction de diapositive
- fonctionnalités pilotées par IA
- capacités d'IA
- agent IA
- client Web
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Traduisez les diapositives PowerPoint avec l'IA en utilisant Aspose.Slides pour Android via Java. Localisez PPT, PPTX et ODP tout en conservant la mise en page — rapide et convivial pour les développeurs. Essayez-le."
---
## **Introduction**

Aspose.Slides est une API puissante pour gérer programmétiquement les présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle offre des fonctionnalités pilotées par l’IA - comme l’API de traduction de présentation pour du contenu de diapositives multilingue.

## **Comment ça fonctionne**

Aspose.Slides ne comprend pas de capacités d'IA intégrées mais s'intègre à des modèles d'IA externes via Internet. Cette fonctionnalité est exposée via la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesaiagent/) qui utilise une implémentation de l'interface [IAIWebClient](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iaiwebclient/) pour communiquer avec les services d'IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/openaiwebclient/) intégré pour vous connecter à l'API d'OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iaiwebclient/) afin d'utiliser un autre fournisseur d'IA ou un modèle de langue différent.

Aspose.Slides gère la communication, analyse les réponses de l'IA et insère intelligemment le contenu traduit tout en conservant la mise en page et le formatage originaux des diapositives.

{{% alert color="info" %}}
Notez que l'API OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé d'API lors de l'utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/openaiwebclient/) intégré.
{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais en utilisant le [OpenAIWebClient](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/openaiwebclient/) intégré avec un [modèle](https://platform.openai.com/docs/models) OpenAI spécifié.

```java
import com.aspose.slides.*;

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

Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/openaiwebclient/) intégré crée et gère sa propre instance interne de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gérant son cycle de vie automatiquement. Toutefois, si vous préférez gérer vous-même le [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalement pour configurer des paramètres essentiels comme un proxy, ou pour utiliser un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) différent afin d'optimiser la gestion des ressources et les performances — vous pouvez fournir votre propre instance `HttpURLConnection` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Configurez une instance HttpURLConnection vous-même (par exemple, avec des délais d'attente personnalisés, des paramètres de proxy, etc.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Passez la connexion au constructeur OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Avantages clés**

L'API de traduction de présentation d'Aspose.Slides offre une solution alimentée par l'IA pour fournir des présentations PowerPoint multilingues. En automatisant la traduction tout en préservant la mise en page et le design, elle fait gagner du temps et minimise les erreurs par rapport aux flux de travail manuels. Que vous soyez développeur, éducateur ou professionnel du secteur, cette API vous permet de créer des présentations attrayantes et localisées pour des publics mondiaux - élargissant votre portée et améliorant la communication.