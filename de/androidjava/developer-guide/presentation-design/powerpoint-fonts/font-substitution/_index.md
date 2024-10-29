---
title: Schriftartsubstitution - PowerPoint Java API
linktitle: Schriftartsubstitution
type: docs
weight: 70
url: /de/androidjava/font-substitution/
keywords: "Schriftart, Ersatzschriftart, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Ersatzschriftart in PowerPoint in Java"
---

Aspose.Slides ermöglicht es Ihnen, Regeln für Schriftarten festzulegen, die bestimmen, was unter bestimmten Bedingungen (zum Beispiel, wenn eine Schriftart nicht zugänglich ist) getan werden muss:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für den Ersatz hinzu.
5. Fügen Sie die Regel zur Sammlung der Schriftart-Ersatzregeln der Präsentation hinzu.
6. Generieren Sie das Folienbild, um die Wirkung zu beobachten.

Dieser Java-Code demonstriert den Prozess der Schriftartsubstitution:

```java
// Lädt eine Präsentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Lädt die Quellschriftart, die ersetzt werden soll
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Lädt die neue Schriftart
    IFontData destFont = new FontData("Arial");
    
    // Fügt eine Schriftartregel für den Schriftartenersatz hinzu
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Fügt die Regel der Sammlung der Schriftart-Ersatzregeln hinzu
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Fügt eine Schriftartregel-Sammlung zur Regel-Liste hinzu
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Die Arial-Schriftart wird anstelle von SomeRareFont verwendet, wenn Letztere nicht zugänglich ist
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Speichert das Bild auf der Festplatte im JPEG-Format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Möglicherweise möchten Sie [**Schriftartenersatz**](/slides/de/androidjava/font-replacement/) sehen.

{{% /alert %}}