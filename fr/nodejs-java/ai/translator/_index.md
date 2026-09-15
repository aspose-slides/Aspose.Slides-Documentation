---
title: Traducteur de présentation alimenté par l'IA
linktitle: Traducteur alimenté par l'IA
type: docs
weight: 20
url: /fr/nodejs-java/ai/translator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Traduisez les diapositives PowerPoint avec l'IA en utilisant Aspose.Slides pour Node.js. Localisez les fichiers PPT, PPTX et ODP tout en préservant la mise en page — rapide et convivial pour les développeurs. Essayez-le."
---
## **Introduction**

Aspose.Slides est une API puissante pour gérer programmétiquement les présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle offre des fonctionnalités pilotées par l’IA – comme l’API de traduction de présentation pour un contenu multilingue.

## **Comment ça fonctionne**

Aspose.Slides n’inclut pas de capacités d’IA intégrées mais s’intègre à des modèles d’IA externes via Internet. Cette fonctionnalité est exposée via la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesaiagent/) pour communiquer avec les services d’IA.

Vous pouvez utiliser le client intégré [OpenAIWebClient](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/openaiwebclient/) pour vous connecter à l’API d’OpenAI.

Aspose.Slides gère la communication, analyse les réponses de l’IA et insère intelligemment le contenu traduit tout en préservant la mise en page et le formatage d’origine des diapositives.

{{% alert color="info" title="Remarque" %}}

Notez que l’API OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé API lors de l’utilisation du client intégré [OpenAIWebClient](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais en utilisant le client intégré [OpenAIWebClient](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/openaiwebclient/) avec un [modèle](https://platform.openai.com/docs/models) OpenAI spécifié.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Charger une présentation à traduire.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Créer un client IA avec OpenAIWebClient, en spécifiant votre modèle et votre clé API.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiser SlidesAIAgent avec le client IA.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Traduire la présentation en japonais.
    aiAgent.translate(presentation, "japanese");

    // Enregistrer la présentation traduite au format PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Par défaut, le client intégré [OpenAIWebClient](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/openaiwebclient/) crée et gère sa propre instance interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), en gérant automatiquement son cycle de vie. Cependant, si vous préférez gérer vous‑même la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalement pour configurer des paramètres essentiels comme un proxy, ou pour utiliser un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) différent afin d’optimiser la gestion des ressources et les performances — vous pouvez fournir votre propre instance `HttpURLConnection` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Créer et préconfigurer une instance HttpURLConnection (par ex., avec des délais d'attente personnalisés, des paramètres de proxy, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Exemple Azure OpenAI**

Vous pouvez configurer le traducteur pour utiliser votre déploiement Azure OpenAI avec le [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Cet extrait montre comment traduire une présentation en utilisant votre point de terminaison Azure OpenAI. Remplacez les valeurs fictives par le nom de votre déploiement, votre clé API et l’URL du point de terminaison.

## **Principaux avantages**

L’API de traduction de présentation Aspose.Slides propose une solution alimentée par l’IA pour fournir des présentations PowerPoint multilingues. En automatisant la traduction tout en préservant la mise en page et le design, elle fait gagner du temps et réduit les erreurs comparé aux processus manuels. Que vous soyez développeur, enseignant ou professionnel, cette API vous permet de créer des présentations attrayantes et localisées pour un public mondial – élargissant votre portée et améliorant la communication.