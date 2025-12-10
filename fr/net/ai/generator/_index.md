---
title: Générateur de diapositives multilingues alimenté par IA
linktitle: Générateur alimenté par IA
type: docs
weight: 40
url: /fr/net/ai/generator/
keywords:
- présentation multilingue
- diapositive multilingue
- générateur de présentation IA
- générateur de diapositives IA
- fonctionnalité alimentée par IA
- agent IA
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Générez des diapositives multilingues à partir de texte avec Aspose.Slides pour .NET. Appliquez votre modèle et exportez des présentations soignées vers PowerPoint et OpenDocument. En savoir plus."
---

## **API IA de Présentation Aspose.Slides : Générateur de Diapositives Alimenté par l'IA**

Aspose.Slides introduit une nouvelle fonctionnalité alimentée par l'IA, le Générateur de Présentation, qui permet aux développeurs de créer automatiquement des présentations PowerPoint bien structurées à partir d'entrées textuelles simples telles que des descriptions de sujet, des résumés, des citations ou des puces.

Les utilisateurs peuvent ajuster le niveau de détail du contenu et, éventuellement, appliquer un modèle de présentation personnalisé pour définir la conception visuelle.

Actuellement, le Générateur de Présentation IA structure le contenu en utilisant des blocs de texte, des listes à puces et des tableaux. La génération d'images n'est pas encore prise en charge ; toutefois, les images peuvent être ajoutées facilement par la suite à l'aide des outils Aspose.Slides ou manuellement.

La sortie est une présentation PowerPoint complète qui peut être utilisée telle quelle ou exportée dans n'importe quel format pris en charge par l'API Aspose.Slides. Bien que le générateur produise des résultats de haute qualité, une légère post-edition peut être nécessaire pour répondre à des exigences spécifiques.

## **Comment ça fonctionne**

Aspose.Slides ne comprend pas de modèles d'IA intégrés ; à la place, il s'intègre à des services d'IA externes via Internet. Cette intégration est gérée par la classe [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) qui utilise une implémentation de l'interface [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) pour communiquer avec le modèle d'IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) intégré, qui se connecte à l'API d'OpenAI, ou fournir une implémentation personnalisée de [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) pour travailler avec un autre fournisseur d'IA ou modèle linguistique. Aspose.Slides gère toute la communication avec le service d'IA et traite les réponses de l'IA pour générer les diapositives. Notez que l'API OpenAI est un service payant, ainsi un compte et une clé API sont requis lors de l'utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) intégré.

## **Passons au code**

### **Exemple 1**

Cet exemple montre comment générer une présentation sur le sujet Aspose.Slides en utilisant le [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) intégré.

```csharp
// Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Create an instance of SlidesAIAgent, which provides access to AI-powered features.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generate a presentation with a medium amount of content based on the instruction.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Exemple 2**

L'exemple suivant montre les surcharges de la méthode [GeneratePresentation](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/generatepresentation/). Dans ce cas, une instance de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) gérée en externe et le `master presentation` de l'utilisateur sont utilisées.

Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) intégré crée et gère sa propre instance interne de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), en gérant son cycle de vie et sa libération automatiquement. Cependant, si vous préférez gérer vous même le [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) - par exemple, en utilisant un [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) pour une meilleure gestion des ressources et des performances - vous pouvez fournir votre propre instance de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Create an externally managed HttpClient instance.
using var httpClient = new HttpClient();

// Pass the HttpClient to the OpenAIWebClient constructor.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Create an instance of SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Load a master presentation from the local disk to use as the design template.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Generate a detailed presentation using the instruction and master template.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Save the generated presentation as a PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Il convient de noter que de nombreux clients utilisent Aspose.Slides dans des contextes synchrones. Pour prendre en charge cela, la classe [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) propose à la fois des méthodes synchrones et asynchrones, vous permettant de choisir l'approche qui correspond le mieux au flux de travail de votre application.

## **Principaux avantages**

Le nouveau Générateur de Présentation IA dans Aspose.Slides offre un moyen rapide et flexible de produire des decks de diapositives structurés à partir d'invites textuelles simples. Avec la prise en charge des modèles personnalisés, des instances de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) gérées en externe, et des flux de travail synchrones et asynchrones, il peut être intégré de façon transparente dans un large éventail d'applications.

Les cas d'utilisation typiques comprennent la création de présentations marketing, de documents éducatifs, de rapports clients et de decks de diapositives internes. Bien que la génération d'images ne soit pas encore prise en charge, l'outil offre déjà une base solide pour automatiser la création de présentations, avec d'autres améliorations attendues à l'avenir.