---
title: Traducteur de présentations alimenté par l'IA
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
- Fonctionnalités pilotées par l'IA
- Capacités IA
- Agent IA
- Client Web
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Traduisez les diapositives PowerPoint avec l'IA en utilisant Aspose.Slides pour Java. Localisez les fichiers PPT, PPTX et ODP tout en préservant la mise en page — rapide et convivial pour les développeurs. Essayez-le."
---
## **Introduction**

Aspose.Slides est une API puissante permettant de gérer programmatiquement les présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle offre des fonctionnalités alimentées par l'IA - telles que l'API de traduction de présentation pour un contenu de diapositive multilingue.

## **Comment cela fonctionne**

Aspose.Slides ne comprend pas de capacités d'IA intégrées, mais s'intègre aux modèles d'IA externes via Internet. Cette fonctionnalité est exposée via la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesaiagent/), qui utilise une implémentation de l'interface [IAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaiwebclient/) pour communiquer avec les services d'IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/) intégré pour vous connecter à l'API d'OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaiwebclient/) pour utiliser un autre fournisseur d'IA ou modèle de langue.

Aspose.Slides gère la communication, analyse les réponses d'IA et insère intelligemment le contenu traduit tout en préservant la mise en page et le formatage d'origine des diapositives.

{{% alert color="info" %}}
Notez que l'API OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé API lors de l'utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais en utilisant le [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/) intégré avec un [modèle](https://platform.openai.com/docs/models) OpenAI spécifié.

```java
import com.aspose.slides.*;

// Charger une présentation à traduire.
Presentation presentation = new Presentation("sample.pptx");

// Créer un client IA avec OpenAIWebClient, en spécifiant votre modèle et votre clé API.
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

Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/) intégré crée et gère sa propre instance interne de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gérant automatiquement son cycle de vie. Cependant, si vous préférez gérer vous-même la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalement pour configurer des paramètres essentiels comme un proxy, ou pour utiliser un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou un autre [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) afin d'améliorer la gestion des ressources et les performances — vous pouvez fournir votre propre instance `HttpURLConnection` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Configurer vous-même une instance HttpURLConnection (délais d'attente personnalisés, paramètres de proxy, etc.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Principaux avantages**

L'API de traduction de présentation d'Aspose.Slides offre une solution alimentée par l'IA pour fournir des présentations PowerPoint multilingues. En automatisant la traduction tout en préservant la mise en page et le design, elle fait gagner du temps et minimise les erreurs par rapport aux flux de travail manuels. Que vous soyez développeur, éducateur ou professionnel du business, cette API vous permet de créer des présentations attrayantes et localisées pour un public mondial - élargissant votre portée et améliorant la communication.