---
title: Générateur de diapositives multilingues alimenté par IA
linktitle: Générateur alimenté par IA
type: docs
weight: 40
url: /fr/java/ai/generator/
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
- Java
- Aspose.Slides
description: "Générez des diapositives multilingues à partir de texte avec Aspose.Slides pour Java. Appliquez votre modèle et exportez des présentations soignées vers PowerPoint et OpenDocument. En savoir plus."
---

## **Aspose.Slides Presentation AI API: Générateur de diapositives alimenté par l'IA**

Aspose.Slides introduit une nouvelle fonctionnalité alimentée par l'IA, le Générateur de présentation, qui permet aux développeurs de créer automatiquement des présentations PowerPoint bien structurées à partir d'entrées texte simples telles que des descriptions de sujet, des résumés, des citations ou des puces.

Les utilisateurs peuvent ajuster le niveau de détail du contenu et, éventuellement, appliquer un modèle de présentation personnalisé pour définir le design visuel.

Actuellement, le Générateur de présentation IA structure le contenu à l'aide de blocs de texte, de listes à puces et de tableaux. La génération d'images n'est pas encore prise en charge; toutefois, les images peuvent être ajoutées facilement par la suite en utilisant les outils Aspose.Slides ou manuellement.

Le résultat est une présentation PowerPoint complète qui peut être utilisée telle quelle ou exportée vers n'importe quel format pris en charge par l'API Aspose.Slides. Bien que le générateur produise des résultats de haute qualité, une légère post-edition peut être nécessaire pour répondre à des exigences spécifiques.

## **Comment ça fonctionne**

Aspose.Slides n'inclut pas de modèles d'IA intégrés; à la place, il s'intègre à des services d'IA externes via Internet. Cette intégration est gérée par la classe [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/), qui utilise une implémentation de l'interface [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) pour communiquer avec le modèle d'IA.

Vous pouvez utiliser le [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) intégré, qui se connecte à l'API d'OpenAI, ou fournir une implémentation personnalisée de [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) pour travailler avec un autre fournisseur d'IA ou modèle de langue. Aspose.Slides gère toute la communication avec le service d'IA et traite les réponses de l'IA pour générer les diapositives. Notez que l'API OpenAI est un service payant, ainsi un compte et une clé API sont requis lors de l'utilisation du [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) intégré.

## **Passons au code**

### **Exemple 1**

Cet exemple montre comment générer une présentation sur le sujet Aspose.Slides en utilisant le [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) intégré.
```java
// Créez une instance d'OpenAIWebClient, l'implémentation intégrée du client web OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Créez une instance de SlidesAIAgent, qui fournit l'accès aux fonctionnalités alimentées par l'IA.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Définissez l'instruction pour générer la présentation.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Générez une présentation avec une quantité moyenne de contenu basée sur l'instruction.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Enregistrez la présentation générée sur le disque local au format PowerPoint (.pptx) file.
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


### **Exemple 2**

L'exemple suivant montre les surcharges de la méthode [generatePresentation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). Dans ce cas, une instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gérée en externe et la `présentation maître` de l'utilisateur sont utilisées.

Par défaut, le [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) intégré crée et gère sa propre instance interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gérant son cycle de vie automatiquement. Cependant, si vous préférez gérer vous-même la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) - par exemple en utilisant un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pour améliorer la gestion des ressources et les performances - vous pouvez fournir votre propre instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) lors de la construction du [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
```java
// Passez le HttpURLConnection au constructeur d'OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Créez une instance de SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Définissez l'instruction pour générer la présentation.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Chargez une présentation maître depuis le disque local pour l'utiliser comme modèle de conception.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Générez une présentation détaillée en utilisant l'instruction et le modèle maître.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Enregistrez la présentation générée au format PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


## **Principaux avantages**

Le nouveau Générateur de présentation IA dans Aspose.Slides offre une méthode rapide et flexible pour créer des ensembles de diapositives structurés à partir de simples invites texte. Avec la prise en charge de modèles personnalisés et d'instances [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gérées en externe, il peut être intégré de manière transparente dans un large éventail d'applications.

Les cas d'utilisation typiques incluent la création de présentations marketing, de documents pédagogiques, de rapports clients et de présentations internes. Bien que la génération d'images ne soit pas encore prise en charge, l'outil offre déjà une base solide pour automatiser la création de présentations, avec d'autres améliorations prévues à l'avenir.