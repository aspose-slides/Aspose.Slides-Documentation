---
title: Warnungs-Callbacks für Schriftartenersatz in Aspose.Slides erhalten
type: docs
weight: 90
url: /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides für Java ermöglicht es, Warnungs-Callbacks für den Schriftartenersatz zu erhalten, falls die verwendete Schriftart während des Rendering-Prozesses auf dem Rechner nicht verfügbar ist. Die Warnungs-Callbacks sind hilfreich beim Debuggen von Problemen mit fehlenden oder unzugänglichen Schriften während des Rendering-Prozesses.

{{% /alert %}} 

Aspose.Slides für Java bietet einfache API-Methoden, um Warnungs-Callbacks während des Rendering-Prozesses zu erhalten. Befolgen Sie die folgenden Schritte, um die Warnungs-Callbacks zu konfigurieren:

1. Erstellen Sie eine benutzerdefinierte Callback-Klasse, um die Callbacks zu empfangen.
1. Setzen Sie die Warnungs-Callbacks unter Verwendung der LoadOptions-Klasse
1. Laden Sie die Präsentationsdatei, die eine Schriftart für den darin enthaltenen Text verwendet, die auf Ihrem Zielrechner nicht verfügbar ist.
1. Generieren Sie das Folienminiaturbild, um den Effekt zu sehen.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}