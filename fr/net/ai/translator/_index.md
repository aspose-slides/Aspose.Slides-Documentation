---
title: Traducteur de présentation alimenté par l'IA
linktitle: Traducteur alimenté par l'IA
type: docs
weight: 20
url: /fr/net/ai/translator/
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
- .NET
- C#
- Aspose.Slides
description: "Traduis les diapositives PowerPoint avec l'IA grâce à Aspose.Slides pour .NET. Localise PPT, PPTX et ODP tout en conservant la mise en page—rapide et convivial pour les développeurs. Essayez-le."
---

## **Aspose.Slides API de traduction de présentation : traduction de diapositives multilingue alimentée par l’IA**

Aspose.Slides est une API puissante pour gérer programmatiquement les présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle offre des fonctionnalités basées sur l’IA – comme l’[API de traduction de présentation](https://reference.aspose.com/slides/net/aspose.slides.ai/) pour du contenu de diapositive multilingue.

## **Comment cela fonctionne**

Aspose.Slides ne contient pas de capacités d’IA intégrées mais s’intègre à des modèles d’IA externes via Internet. Cette fonctionnalité est exposée par la classe [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent) qui utilise une implémentation de l’interface [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) pour communiquer avec les services d’IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) fourni pour vous connecter à l’API OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) afin d’utiliser un autre fournisseur d’IA ou modèle linguistique.

Aspose.Slides gère la communication, analyse les réponses d’IA et insère intelligemment le contenu traduit tout en préservant la mise en page et le formatage d’origine de chaque diapositive.

{{% alert color="primary" %}}
Notez que l’API OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé d’API lors de l’utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais en utilisant le [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) intégré avec un modèle OpenAI spécifié.

```csharp
// Charger une présentation à traduire.
using var presentation = new Presentation("sample.pptx");

// Créer un client IA avec OpenAIWebClient, en précisant votre modèle et votre clé d'API.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialiser SlidesAIAgent avec le client IA.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Traduire la présentation en japonais.
await aiAgent.TranslateAsync(presentation, "japanese");

// Enregistrer la présentation traduite au format PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) crée et gère sa propre instance interne de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), en s’occupant automatiquement de son cycle de vie et de sa suppression. Cependant, si vous préférez gérer vous‑même le [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) – par exemple en utilisant un [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) pour une meilleure gestion des ressources et des performances – vous pouvez fournir votre propre instance `HttpClient` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Supposons que vous disposiez d'une instance IHttpClientFactory (par ex., injectée via l'injection de dépendances).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides est couramment utilisé dans des environnements synchrones. Pour prendre en charge cela, la classe [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) propose à la fois des méthodes synchrones et asynchrones – vous permettant de choisir l’approche qui correspond le mieux au flux de travail de votre application.

## **Principaux avantages**

L’[API de traduction de présentation](https://reference.aspose.com/slides/net/aspose.slides.ai/) d’Aspose.Slides offre une solution alimentée par l’IA pour créer des présentations PowerPoint multilingues. En automatisant la traduction tout en conservant la mise en page et le design, elle fait gagner du temps et réduit les erreurs par rapport aux processus manuels. Que vous soyez développeur, enseignant ou professionnel en entreprise, cette API vous permet de créer des présentations localisées et attrayantes pour des publics mondiaux – élargissant votre portée et améliorant la communication.