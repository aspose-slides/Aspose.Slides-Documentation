---
title: Traducteur de présentation alimenté par l'IA
linktitle: Traducteur alimenté par l'IA
type: docs
weight: 20
url: /fr/net/ai/translator/
keywords:
- Traducteur de présentation IA
- Traducteur de diapositive IA
- Fonction alimentée par l'IA
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
description: "Traduisez les diapositives PowerPoint avec l'IA en utilisant Aspose.Slides pour .NET. Localisez PPT, PPTX et ODP tout en préservant la mise en page — rapide et convivial pour les développeurs. Essayez-le."
---
## **Introduction**

Aspose.Slides est une API puissante permettant de gérer programmatiquement des présentations PowerPoint. En plus de créer, modifier et convertir des diapositives, elle propose des fonctionnalités pilotées par l’IA, comme l’[API de traduction de présentation](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/) pour du contenu de diapositive multilingue.

## **Comment ça fonctionne**

Aspose.Slides n’inclut pas de capacités d’IA intégrées mais s’intègre à des modèles d’IA externes via Internet. Cette fonctionnalité est exposée par la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/slidesaiagent), qui utilise une implémentation de l’interface [IAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/iaiwebclient/) pour communiquer avec les services d’IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/) intégré pour vous connecter à l’API OpenAI ou implémenter votre propre [IAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/iaiwebclient/) afin d’utiliser un autre fournisseur d’IA ou modèle linguistique.

Aspose.Slides gère la communication, analyse les réponses de l’IA et insère intelligemment le contenu traduit tout en préservant la mise en page et le formatage originaux des diapositives.

{{% alert color="info" %}}
Notez que l’API OpenAI est un service payant, vous devrez donc créer un compte et fournir votre clé d’API lors de l’utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Exemple**

Dans cet exemple, nous traduisons une présentation PowerPoint en japonais à l’aide du [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/) intégré avec un [modèle](https://platform.openai.com/docs/models) OpenAI spécifié.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Chargez une présentation à traduire.
using var presentation = new Presentation("sample.pptx");

// Créez un client IA avec OpenAIWebClient, en spécifiant votre modèle et votre clé API.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialisez SlidesAIAgent avec le client IA.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Traduisez la présentation en japonais.
await aiAgent.TranslateAsync(presentation, "japanese");

// Enregistrez la présentation traduite au format PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/) intégré crée et gère sa propre instance interne de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), en gérant automatiquement son cycle de vie et sa libération. Cependant, si vous préférez gérer vous‑même le [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) — par exemple en utilisant un [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) pour une meilleure gestion des ressources et des performances — vous pouvez fournir votre propre instance `HttpClient` lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Utilisez un HttpClient que vous gérez vous-même - par exemple, un créé par un IHttpClientFactory
// injecté via l'injection de dépendances.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides est couramment utilisé dans des environnements synchrones. Pour prendre en charge cela, la classe [SlidesAIAgent](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/slidesaiagent/) propose à la fois des méthodes synchrones et asynchrones, vous permettant de choisir l’approche qui correspond le mieux au flux de travail de votre application.

## **Principaux avantages**

L’[API de traduction de présentation](https://reference.aspose.com/slides/fr/net/aspose.slides.ai/) d’Aspose.Slides offre une solution alimentée par l’IA pour fournir des présentations PowerPoint multilingues. En automatisant la traduction tout en préservant la mise en page et le design, elle fait gagner du temps et minimise les erreurs par rapport aux processus manuels. Que vous soyez développeur, enseignant ou professionnel, cette API vous permet de créer des présentations attrayantes et localisées pour un public mondial, élargissant ainsi votre portée et améliorant la communication.