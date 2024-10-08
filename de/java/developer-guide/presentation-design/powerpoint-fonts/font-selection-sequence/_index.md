---
title: Auswahl der Schriftarten in Java
linktitle: Auswahl der Schriftarten in Java
type: docs
weight: 80
url: /de/java/font-selection-sequence/
keywords:
- schriftart
- schriftauswahl
- schriftartersetzung
- schriftartwechsel
- PowerPoint-Präsentation
- Java
- Aspose.Slides für Java
description: Reihenfolge der Schriftauswahl in PowerPoint-Präsentationen in Java
---

## Schriftauswahl

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Wenn Sie beispielsweise versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriftarten der Präsentation überprüft, um sicherzustellen, dass die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt — siehe [**Schriftartwechsel**](https://docs.aspose.com/slides/java/font-replacement/) und [**Schriftartersetzung**](https://docs.aspose.com/slides/java/font-substitution/).

Dies ist der Prozess, den Aspose.Slides bei der Verarbeitung von Schriftarten verfolgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die mit der gewählten Schriftart der Präsentation übereinstimmt.
2. Wenn die gewählte Schriftart gefunden wird, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an dem ist, was PowerPoint verwenden würde.
3. Wenn Schriftartwechselregeln über [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) festgelegt wurden, werden diese angewendet.

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Anwendungs-runtime hinzuzufügen und diese Schriftarten dann zu verwenden. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/java/custom-font/).

Wenn zusätzliche Schriftarten innerhalb einer Präsentation platziert werden, werden sie als [**Eingebettete Schriftarten**](https://docs.aspose.com/slides/java/embedded-font/) bezeichnet.

Aspose.Slides ermöglicht es Ihnen, Schriftarten hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Wenn sich beispielsweise in einer Präsentation, die Sie in PDF konvertieren möchten, Schriftarten befinden, die auf Ihrem System fehlen und eingebettete Schriftarten, können Sie die benötigten Schriftarten als **externe Schriftarten** hinzufügen oder laden.

{{% alert title="Hinweis" color="primary" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht es Ihnen, externe Schriftarten zu laden und sie in Dokumente einzubetten, jedoch geschieht dies nach Ihrem Ermessen und Ihrer Verantwortung.
{{% /alert %}}