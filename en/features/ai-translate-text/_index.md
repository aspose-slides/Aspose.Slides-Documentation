---
title: Translate slide text with AI
description: Translate text in slide shapes, groups and tables through an AI model.
type: docs
url: /features/ai-translate-text/
weight: 1520
feature_id: ai-translate-text
feature_group: ai
translationKey: slides-feature-ai-translate-text
feature_catalogue_version: 3
feature_guides:
- /slides/net/ai/translator/
---

## **Overview**

Use the library's AI translation workflow to rewrite presentation text in another language. The model client supplies the translation, while the library updates the relevant slide text. Use it within the supported presentation scope and keep a copy of the source for later editing.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/). Optionally set ASPOSE_SLIDES_LICENSE to your license file to avoid evaluation limits. Create separate shape, grouped-shape and table-cell text, then translate the deck to Spanish using the [default Aspose AI client](https://reference.aspose.com/slides/net/aspose.slides.ai/asposeaiwebclient/asposeaiwebclient/). Save the translated copy separately from the English original. This fixture has no charts or speaker notes.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var licensePath = Environment.GetEnvironmentVariable("ASPOSE_SLIDES_LICENSE");
if (!string.IsNullOrWhiteSpace(licensePath))
{
    var license = new License();
    license.SetLicense(licensePath);
}
using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
using var client = new AsposeAIWebClient(http);
var agent = new SlidesAIAgent(client);
using (var source = new Presentation())
{
    var shape = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    shape.AddTextFrame("Hello world");
    var group = source.Slides[0].Shapes.AddGroupShape();
    var groupedText = group.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 140, 500, 80);
    groupedText.AddTextFrame("Good morning");
    var table = source.Slides[0].Shapes.AddTable(40, 260, new double[] { 500 }, new double[] { 80 });
    table[0, 0].TextFrame.Text = "Thank you";
    source.Save("original.pptx", SaveFormat.Pptx);
}
using var presentation = new Presentation("original.pptx");
await agent.TranslateAsync(presentation, "Spanish");
presentation.Save("translated.pptx", SaveFormat.Pptx);
Console.WriteLine("Saved translated.pptx; original.pptx is unchanged.");
```

## **FAQ**

### **Does this translate every kind of presentation content?**

Speaker notes are outside this workflow, and translation can fail when a presentation contains charts. Handle those cases separately.

### **How do I choose the target language for a translation?**

Pass the target language name to the translation operation. Review the wording and layout after translation, especially when text grows.

### **How can I keep an untranslated original when translating a deck?**

Save the translated result under a new path. Keep the original deck unchanged for later editing or another translation.

## **Guides**

- [AI-Powered Presentation Translator (.NET)](/slides/net/ai/translator/)

Related feature: [Connect your own AI model provider](/slides/features/ai-model-provider/).

## Runnable .NET examples

- [Translate Presentation Text with AI](/slides/net/examples/ai/translate/)
