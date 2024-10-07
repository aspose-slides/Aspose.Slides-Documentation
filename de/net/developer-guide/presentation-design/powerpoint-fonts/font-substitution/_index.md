---
title: Schriftartenersetzung - PowerPoint C# API
linktitle: Schriftartenersetzung
type: docs
weight: 70
url: /net/font-substitution/
keywords: 
- schriftart
- ersatzschriftart
- PowerPoint
- präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: C# PowerPoint API ermöglicht das Ersetzen von Schriftarten in Präsentationen
---

## **Schriftartenersetzung Abrufen**

Um herauszufinden, welche Schriftarten während des Renderings einer Präsentation ersetzt werden, bietet Aspose.Slides die [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) Methode aus der [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) Schnittstelle an.

Der C#-Code zeigt, wie Sie alle Schriftartenersetzungen abrufen, die beim Rendern einer Präsentation durchgeführt werden:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Regeln für Schriftartenersetzung Festlegen**

Aspose.Slides ermöglicht es Ihnen, Regeln für Schriftarten festzulegen, die bestimmen, was unter bestimmten Bedingungen (zum Beispiel, wenn auf eine Schriftart nicht zugegriffen werden kann) zu tun ist:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für die Ersetzung hinzu.
5. Fügen Sie die Regel zur Sammlung von Schriftartenersetzungsregeln der Präsentation hinzu.
6. Erzeugen Sie das Folienbild, um den Effekt zu beobachten.

Dieser C#-Code demonstriert den Prozess der Schriftartenersetzung:

```c#
// Lädt eine Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt werden soll
IFontData sourceFont = new FontData("SomeRareFont");

// Lädt die neue Schriftart
IFontData destFont = new FontData("Arial");

// Fügt eine Schriftartregel für die Schriftartenersetzung hinzu
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Fügen Sie die Regel zur Sammlung der Schriftartenersetzungsregeln hinzu
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Fügt die Sammlung der Schriftartenregeln zur Regel-Liste hinzu
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Speichert das Bild auf der Festplatte im JPEG-Format
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Sie möchten möglicherweise [**Schriftartenersetzung**](/slides/net/font-replacement/) sehen. 

{{% /alert %}}