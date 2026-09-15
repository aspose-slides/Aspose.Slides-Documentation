---
title: Traducteur de présentation alimenté par l'IA
linktitle: Traducteur alimenté par l'IA
type: docs
weight: 20
url: /fr/net/ai/translator/
keywords:
- Traducteur de présentation IA
- Traducteur de diapositives IA
- Fonctionnalité alimentée par l'IA
- Présentation multilingue
- Diapositive multilingue
- Traduction de présentation
- Traduction de diapositive
- Fonctions pilotées par l'IA
- Capacités d'IA
- Agent IA
- Client Web
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Traduisez les diapositives PowerPoint avec l'IA en utilisant Aspose.Slides pour .NET. Localisez les fichiers PPT, PPTX et ODP tout en conservant la mise en page, rapide et convivial pour les développeurs. Essayez-le."
---
## **Introduction**

Aspose.Slides est une API puissante pour gérer programmétiquement des présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle propose des fonctionnalités basées sur l'IA, telles que l'[Presentation Translation API](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/) pour le contenu multilingue des diapositives.

## **How It Works**

Aspose.Slides ne comprend pas de capacités d'IA intégrées mais s'intègre à des modèles d'IA externes via Internet. Cette fonctionnalité est exposée via la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/slidesaiagent) qui utilise une implémentation de l'interface [IAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/iaiwebclient/) pour communiquer avec les services d'IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/) intégré pour vous connecter à l'API d'OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/iaiwebclient/) afin d'utiliser un autre fournisseur d'IA ou modèle linguistique.

Aspose.Slides gère la communication, analyse les réponses de l'IA et insère intelligemment le contenu traduit tout en préservant la mise en page et le formatage d'origine des diapositives.

{{% alert color="info" title="Note" %}}
Notez que l'API OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé API lors de l'utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Example**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais en utilisant le [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/) intégré avec un [model](https://platform.openai.com/docs/models) OpenAI spécifié.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Charger une présentation à traduire.
using var presentation = new Presentation("sample.pptx");

// Créer un client IA avec OpenAIWebClient, en spécifiant votre modèle et votre clé API.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialiser SlidesAIAgent avec le client IA.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Traduire la présentation en japonais.
await aiAgent.TranslateAsync(presentation, "japanese");

// Enregistrer la présentation traduite en PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/) intégré crée et gère sa propre instance interne de `HttpClient`, en gérant automatiquement son cycle de vie et sa libération. Cependant, si vous préférez gérer vous-même le `HttpClient` – par exemple en utilisant un [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) pour une meilleure gestion des ressources et des performances – vous pouvez fournir votre propre instance `HttpClient` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Utilisez un HttpClient que vous gérez vous-même - par exemple, un créé par un IHttpClientFactory
// injecté via l'injection de dépendances.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides est couramment utilisé dans des environnements synchrones. Pour le prendre en charge, la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/slidesaiagent/) propose à la fois des méthodes synchrones et asynchrones, vous permettant de choisir l'approche qui correspond le mieux au flux de travail de votre application.

### **Azure OpenAI Example**

Aspose.Slides for .NET prend en charge les fournisseurs compatibles OpenAI, y compris Azure OpenAI. Vous pouvez configurer le traducteur pour utiliser votre déploiement Azure interne avec le [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Ce fragment montre comment traduire une présentation en utilisant votre point de terminaison Azure OpenAI. Remplacez les valeurs d'espace réservé par le nom de votre déploiement, votre clé API et l'URL du point de terminaison.

## **Key Benefits**

L'API de traduction de présentations d'Aspose.Slides offre une solution alimentée par l'IA pour diffuser des présentations PowerPoint multilingues. En automatisant la traduction tout en préservant la mise en page et le design, elle fait gagner du temps et minimise les erreurs par rapport aux flux de travail manuels. Que vous soyez développeur, enseignant ou professionnel du business, cette API vous permet de créer des présentations attrayantes et localisées pour un public mondial – élargissant votre portée et améliorant la communication.