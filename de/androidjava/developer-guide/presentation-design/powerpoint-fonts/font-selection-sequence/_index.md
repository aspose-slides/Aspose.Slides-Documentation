---
title: Schriftartauswahlfolge in Java
linktitle: Schriftartauswahlfolge in Java
type: docs
weight: 80
url: /de/androidjava/font-selection-sequence/
keywords:
- schriftart
- schriftartauswahl
- schriftartsubstitution
- schriftartersatz
- PowerPoint-Präsentation
- Java
- Aspose.Slides für Android über Java
description: PowerPoint Schriftartauswahlfolge in Java
---

## Schriftartauswahl

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Zum Beispiel, wenn Sie versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriftarten der Präsentation überprüft, um sicherzustellen, dass die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt — siehe [**Schriftartersatz**](https://docs.aspose.com/slides/androidjava/font-replacement/) und [**Schriftartsubstitution**](https://docs.aspose.com/slides/androidjava/font-substitution/).

Das ist der Prozess, den Aspose.Slides beim Umgang mit Schriftarten verfolgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die mit der gewählten Schriftart der Präsentation übereinstimmt. 
2. Wenn die gewählte Schriftart gefunden wird, verwendet Aspose.Slides diese. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an dem ist, was PowerPoint verwenden würde.
3. Wenn Schriftartersatzregeln über [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) festgelegt wurden, werden diese angewendet.

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Laufzeit der Anwendung hinzuzufügen und diese Schriftarten dann zu verwenden. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/androidjava/custom-font/).

Wenn zusätzliche Schriftarten innerhalb einer Präsentation platziert werden, werden sie als [**Eingebettete Schriftarten**](https://docs.aspose.com/slides/androidjava/embedded-font/) bezeichnet.

Aspose.Slides ermöglicht es Ihnen, Schriftarten hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die auf Ihrem System fehlen, und eingebettete Schriftarten, können Sie die benötigten Schriftarten als **externe Schriftarten** hinzufügen oder laden. 

{{% alert title="Hinweis" color="primary" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unser API ermöglicht es Ihnen, externe Schriftarten zu laden und in Dokumente einzubetten, jedoch tun Sie dies nach eigenem Ermessen und Verantwortung.
{{% /alert %}}