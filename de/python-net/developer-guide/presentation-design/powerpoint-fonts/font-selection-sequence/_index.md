---
title: Schriftarten-Auswahlsequenz in Python
linktitle: Schriftarten-Auswahlsequenz in Python
type: docs
weight: 80
url: /python-net/font-selection-sequence/
keywords:
- schriftart
- schriftauswahl
- schriftartersetzung
- schriftartwechsel
- PowerPoint-Präsentation
- Python
- Aspose.Slides für Python
description: "PowerPoint-Schriftauswahlsequenz in Python"
---

## Schriftauswahl

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Zum Beispiel, wenn Sie versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriftarten der Präsentation überprüft, um zu verifizieren, dass die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt — siehe [**Schriftartwechsel**](https://docs.aspose.com/slides/python-net/font-replacement/) und [**Schriftartersetzung**](https://docs.aspose.com/slides/python-net/font-substitution/).

Dies ist der Prozess, den Aspose.Slides beim Umgang mit Schriftarten verfolgt:

1. Aspose.Slides sucht nach Schriftarten im Betriebssystem, um die Schriftart zu finden, die mit der gewählten Schriftart der Präsentation übereinstimmt.
2. Wenn die gewählte Schriftart gefunden wird, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an dem ist, was PowerPoint verwenden würde.
3. Wenn Schriftartwechselregeln über [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Anwendungszeit hinzuzufügen und diese Schriftarten dann zu verwenden. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/python-net/custom-font/). 

Wenn zusätzliche Schriftarten in einer Präsentation platziert werden, werden sie als [**Eingebettete Schriftarten**](https://docs.aspose.com/slides/python-net/embedded-font/) bezeichnet.

Aspose.Slides erlaubt es Ihnen, Schriftarten hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Zum Beispiel, wenn eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die auf Ihrem System fehlen, und eingebettete Schriftarten, können Sie die benötigten Schriftarten als **externe Schriftarten** hinzufügen oder laden. 

{{% alert title="Hinweis" color="primary" %}} 
Wir vertreiben keine Schriftarten, weder kostenpflichtig noch kostenlos. Unsere API ermöglicht es Ihnen, externe Schriftarten zu laden und in Dokumente einzubetten, aber Sie tun dies mit Schriftarten nach Ihrem Ermessen und auf Ihre Verantwortung.
{{% /alert %}}