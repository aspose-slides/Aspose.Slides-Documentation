---
title: Traducteur de présentation alimenté par l'IA
linktitle: Traducteur alimenté par l'IA
type: docs
weight: 20
url: /fr/java/ai/translator/
keywords:
- Traducteur de présentation IA
- Traducteur de diapositive IA
- Fonction alimentée par l'IA
- Présentation multilingue
- Diapositive multilingue
- Traduction de présentation
- Traduction de diapositive
- Fonctions pilotées par l'IA
- Capacités IA
- Agent IA
- Client Web
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Traduisez les diapositives PowerPoint avec l'IA utilisant Aspose.Slides pour Java. Localisez les fichiers PPT, PPTX et ODP tout en préservant la mise en page — rapide et adapté aux développeurs. Essayez-le."
---
## **Introduction**

Aspose.Slides est une API puissante pour gérer programmétiquement les présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle propose des fonctionnalités alimentées par l'IA — comme l'API de traduction de présentation pour un contenu de diapositive multilingue.

## **Fonctionnement**

Aspose.Slides n'inclut pas de capacités d'IA natives mais s'intègre à des modèles d'IA externes via Internet. Cette fonctionnalité est exposée via la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesaiagent/) qui utilise une implémentation de l'interface [IAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaiwebclient/) pour communiquer avec les services d'IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/) intégré pour vous connecter à l'API d'OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaiwebclient/) afin d’utiliser un autre fournisseur d'IA ou modèle de langue.

Aspose.Slides gère la communication, analyse les réponses de l'IA et insère intelligemment le contenu traduit tout en conservant la disposition et le formatage originaux des diapositives.

{{% alert color="info" title="Remarque" %}}
Notez que l'API OpenAI est un service payant, vous devez donc créer un compte et fournir votre clé d'API lors de l'utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais à l'aide du [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/) intégré avec un [modèle](https://platform.openai.com/docs/models) OpenAI spécifié.

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

Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/) intégré crée et gère sa propre instance interne de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), en gérant automatiquement son cycle de vie. Cependant, si vous préférez gérer vous‑même le [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalement pour configurer des paramètres essentiels comme un proxy, ou pour utiliser un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou un autre [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) afin d’optimiser la gestion des ressources et les performances — vous pouvez fournir votre propre instance `HttpURLConnection` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Configurez vous-même une instance HttpURLConnection (délais d'attente personnalisés, paramètres de proxy, etc.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Exemple Azure OpenAI**

Vous pouvez configurer le traducteur pour utiliser votre déploiement Azure OpenAI avec le [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Cet extrait montre comment traduire une présentation en utilisant votre point de terminaison Azure OpenAI. Remplacez les valeurs de l'espace réservé par le nom de votre déploiement, votre clé d'API et l'URL du point de terminaison.

## **Avantages clés**

L'API de traduction de présentation Aspose.Slides offre une solution alimentée par l'IA pour fournir des présentations PowerPoint multilingues. En automatisant la traduction tout en préservant la mise en page et le design, elle fait gagner du temps et réduit les erreurs par rapport aux flux de travail manuels. Que vous soyez développeur, éducateur ou professionnel du secteur, cette API vous permet de créer des présentations engageantes et localisées pour des audiences mondiales — élargissant votre portée et améliorant la communication.