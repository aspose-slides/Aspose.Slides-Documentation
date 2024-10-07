---
title: Erstellen einer Fallback-Schriftarten-Sammlung
type: docs
weight: 20
url: /java/create-fallback-fonts-collection/
---

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) Klasse können in eine [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) organisiert werden, die die [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) Schnittstelle implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung der [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) Methode der [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) Klasse zugewiesen werden. FontsManager steuert die Schriftarten in der Präsentation. Erfahren Sie mehr [Über FontsManager und FontsLoader](/slides/java/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) hat eine [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) Methode mit ihrer eigenen Instanz der [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback-Schriftartenregeln erstellt und in das [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweist:  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Nachdem der FontsManager mit der Fallback-Schriftarten-Sammlung initialisiert wurde, werden die Fallback-Schriftarten während der Präsentationsdarstellung angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr, wie Sie eine [Präsentation mit Fallback-Schriftart rendern](/slides/java/render-presentation-with-fallback-font/).
{{% /alert %}}