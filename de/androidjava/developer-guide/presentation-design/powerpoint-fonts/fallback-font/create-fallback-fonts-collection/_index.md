---
title: Erstellen einer Fallback-Schriftarten-Sammlung
type: docs
weight: 20
url: /de/androidjava/create-fallback-fonts-collection/
---

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) Klasse können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection) Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Diese Sammlung kann dann der [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) Methode der [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) Klasse zugewiesen werden. FontsManager steuert die Schriftarten in der Präsentation. Erfahren Sie mehr [Über FontsManager und FontsLoader](/slides/de/androidjava/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) hat eine [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) Methode mit ihrer eigenen Instanz der [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback-Schriftartenregeln erstellt und sie in den [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweist:  

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

Nachdem der FontsManager mit der Sammlung von Fallback-Schriftarten initialisiert wurde, werden die Fallback-Schriftarten während der Präsentationsdarstellung angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr darüber, wie man eine [Präsentation mit Fallback-Schriftart rendern](/slides/de/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}