---
title: Schriftartauswahlsequenz in C++
linktitle: Schriftartauswahlsequenz in C++
type: docs
weight: 80
url: /cpp/font-selection-sequence/
keywords:
- schriftart
- schriftarteinschätzung
- schriftartsubstitution
- schriftartersetzung
- PowerPoint-Präsentation
- C++
- Aspose.Slides für C++
description: "PowerPoint Schriftartauswahlsequenz in C++"
---

## Schriftartauswahl

Es gelten bestimmte Regeln für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Wenn Sie beispielsweise versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriftarten der Präsentation überprüft, um zu bestätigen, dass die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt — siehe [**Schriftartersetzung**](https://docs.aspose.com/slides/cpp/font-replacement/) und [**Schriftartsubstitution**](https://docs.aspose.com/slides/cpp/font-substitution/).

Dies ist der Prozess, den Aspose.Slides beim Umgang mit Schriftarten verfolgt:

1. Aspose.Slides sucht nach Schriftarten im Betriebssystem, um die Schriftart zu finden, die der gewählten Schriftart der Präsentation entspricht.
2. Wenn die gewählte Schriftart gefunden wird, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an dem ist, was PowerPoint verwenden würde.
3. Wenn Schriftartersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) festgelegt wurden, werden diese angewendet.

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Laufzeit der Anwendung hinzuzufügen und dann diese Schriftarten zu verwenden. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/cpp/custom-font/).

Wenn zusätzliche Schriftarten in einer Präsentation enthalten sind, werden sie als [**Eingebettete Schriftarten**](https://docs.aspose.com/slides/cpp/embedded-font/) bezeichnet.

Aspose.Slides ermöglicht es Ihnen, Schriftarten hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die auf Ihrem System fehlen und eingebettete Schriftarten, können Sie die benötigten Schriftarten als **externe Schriftarten** hinzufügen oder laden.

{{% alert title="Hinweis" color="primary" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht es Ihnen, externe Schriftarten zu laden und in Dokumente einzubetten, aber Sie tun dies mit Schriftarten nach Ihrem Ermessen und Verantwortung.
{{% /alert %}}