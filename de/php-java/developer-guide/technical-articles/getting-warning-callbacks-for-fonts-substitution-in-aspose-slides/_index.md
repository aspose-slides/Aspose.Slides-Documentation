---
title: Warnungsrückrufe für Schriftartenersetzung in Aspose.Slides erhalten
type: docs
weight: 90
url: /de/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java ermöglicht es, Warnungsrückrufe für die Schriftartenersetzung zu erhalten, falls die verwendete Schriftart während des Rendering-Prozesses nicht auf der Maschine verfügbar ist. Die Warnungsrückrufe sind hilfreich beim Debuggen von Problemen mit fehlenden oder nicht zugänglichen Schriftarten während des Rendering-Prozesses.

{{% /alert %}} 

Aspose.Slides für PHP über Java bietet einfache API-Methoden, um Warnungsrückrufe während des Rendering-Prozesses zu empfangen. Folgen Sie den untenstehenden Schritten, um die Warnungsrückrufe zu konfigurieren:

1. Erstellen Sie eine benutzerdefinierte Rückrufklasse, um die Rückrufe zu empfangen.
1. Setzen Sie die Warnungsrückrufe mit der LoadOptions-Klasse.
1. Laden Sie die Präsentationsdatei, die eine Schriftart für den darin enthaltenen Text verwendet, die auf Ihrer Zielmaschine nicht verfügbar ist.
1. Generieren Sie das Folienminiaturbild, um den Effekt zu sehen.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}