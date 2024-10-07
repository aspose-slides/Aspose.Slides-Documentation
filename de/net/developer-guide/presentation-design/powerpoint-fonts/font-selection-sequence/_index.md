---
title: Schriftartauswahlsequenz in C#
linktitle: Schriftartauswahlsequenz in C#
type: docs
weight: 80
url: /net/font-selection-sequence/
keywords:
- schriftart
- schriftartauswahl
- schriftartsubstitution
- schriftartersetzung
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: PowerPoint Schriftartauswahlsequenz in C#
---

## Schriftartauswahl

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Wenn Sie beispielsweise versuchen, eine Präsentation (deren Folien) in Bilder zu konvertieren, werden die Schriftarten der Präsentation überprüft, um festzustellen, ob die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt — siehe [**Schriftartersetzung**](https://docs.aspose.com/slides/net/font-replacement/) und [**Schriftartsubstitution**](https://docs.aspose.com/slides/net/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides beim Umgang mit Schriftarten folgt:

1. Aspose.Slides durchsucht das Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der gewählten Schriftart der Präsentation entspricht. 
2. Wenn die gewählte Schriftart gefunden wird, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an dem ist, was PowerPoint verwenden würde.
3. Wenn Schriftartersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Anwendungslaufzeit hinzuzufügen und diese Schriftarten dann zu verwenden. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/net/custom-font/). 

Wenn zusätzliche Schriftarten in einer Präsentation platziert werden, werden sie [**eingebettete Schriftarten**](https://docs.aspose.com/slides/net/embedded-font/) genannt.

Aspose.Slides ermöglicht es Ihnen, Schriftarten hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Wenn eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die in Ihrem System fehlen und eingebettete Schriftarten, können Sie die benötigten Schriftarten als **externe Schriftarten** hinzufügen oder laden. 

{{% alert title="Hinweis" color="primary" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht es Ihnen, externe Schriftarten zu laden und in Dokumente einzubetten, aber Sie tun dies mit Schriftarten nach Ihrem Ermessen und Verantwortung.
{{% /alert %}}