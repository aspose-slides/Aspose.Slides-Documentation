---
title: Schriftart-Auswahlsequenz
linktitle: Schriftart-Auswahlsequenz
type: docs
weight: 80
url: /php-java/schriftart-auswahlsequenz/
keywords: "Schriftart, Schriftartauswahl, Schriftartsubstitution, Schriftartersatz, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: PowerPoint Schriftart-Auswahlsequenz
---

## Schriftart-Auswahl

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Zum Beispiel, wenn Sie versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriftarten der Präsentation überprüft, um zu verifizieren, dass die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt – siehe [**Schriftartersatz**](https://docs.aspose.com/slides/php-java/font-replacement/) und [**Schriftartsubstitution**](https://docs.aspose.com/slides/php-java/font-substitution/).

Dies ist der Prozess, den Aspose.Slides beim Umgang mit Schriftarten verfolgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der gewählten Schriftart der Präsentation entspricht.
2. Wenn die gewählte Schriftart gefunden wird, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an dem ist, was PowerPoint verwenden würde.
3. Wenn Schriftartersatzregeln über [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet.

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Aspose-Laufzeit hinzuzufügen und diese Schriftarten dann zu verwenden. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/php-java/custom-font/).

Wenn zusätzliche Schriftarten innerhalb einer Präsentation platziert werden, werden sie als [**Eingebettete Schriftarten**](https://docs.aspose.com/slides/php-java/embedded-font/) bezeichnet.

Aspose.Slides ermöglicht Ihnen, Schriftarten hinzuzufügen, die *nur* auf Ausgabe-Dokumente angewendet werden. Zum Beispiel, wenn eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die auf Ihrem System fehlen, und eingebettete Schriftarten, können Sie die benötigten Schriftarten als **Externe Schriftarten** hinzufügen oder laden.