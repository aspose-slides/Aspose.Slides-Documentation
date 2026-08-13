---
title: Präsentationen mit Fallback‑Schriftarten in Java rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/java/render-presentation-with-fallback-font/
keywords:
- Fallback‑Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folie rendern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Präsentationen mit Fallback‑Schriftarten in Aspose.Slides für Java rendern – den Text über PPT, PPTX und ODP hinweg konsistent halten mit schrittweisen Java‑Code‑Beispielen."
---
## **Übersicht**

Aspose.Slides ermöglicht das Rendern von Präsentationen mit Fallback‑Schriftartregeln. Dieser Artikel zeigt, wie man eine Sammlung von Fallback‑Schriftartregeln erstellt, deren Regeln durch Entfernen oder Hinzufügen von Fallback‑Schriftarten ändert und die Sammlung mit der Methode `FontsManager.setFontFallBackRulesCollection` zuweist.

Sobald die Sammlung von Fallback‑Schriftartregeln dem `FontsManager` der Präsentation zugewiesen ist, werden die Regeln bei Vorgängen wie Speichern, Rendern und Konvertieren der Präsentation angewendet. Das Beispiel demonstriert, wie die konfigurierten Regeln beim Rendern einer Folien‑Miniatur und beim Speichern als JPEG‑Bild verwendet werden.

## **Folie mit Fallback‑Schriftartregeln rendern**

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback‑Schriftartregeln](/slides/de/java/create-fallback-fonts-collection/).
1. Wir [entfernen](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) eine Fallback‑Schriftartregel und [addFallBackFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel.
1. Wir setzen die Regel‑Sammlung via [getFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) Methode.
1. Mit der Methode [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#save-java.lang.String-int-) können wir die Präsentation im selben Format speichern oder in einem anderen Format. Nachdem die Fallback‑Schriftartregelsammlung dem [FontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsManager) zugewiesen wurde, werden diese Regeln bei allen Vorgängen an der Präsentation angewendet: speichern, rendern, konvertieren usw.

```java
import com.aspose.slides.*;

// Neue Instanz einer Regel-Sammlung erstellen
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Versuch, die Fallback‑Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
    fallBackRule.remove("Tahoma");

    // Und die Regeln für den angegebenen Bereich zu aktualisieren
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Außerdem können wir vorhandene Regeln aus der Liste entfernen, wobei mindestens eine Regel zum Rendern erhalten bleibt
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Zuweisen einer vorbereiteten Regel‑Liste zur Verwendung
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendern einer Miniatur unter Verwendung der initialisierten Regelsammlung und speichern als JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Bild im JPEG‑Format auf die Festplatte speichern
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Erfahren Sie mehr darüber, wie Sie [PPT und PPTX nach JPG in Java konvertieren](/slides/de/java/convert-powerpoint-to-jpg/).
{{% /alert %}}