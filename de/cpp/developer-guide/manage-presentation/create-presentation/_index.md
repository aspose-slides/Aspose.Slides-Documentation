---
title: Präsentation erstellen - C++ PowerPoint API
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /cpp/create-presentation/
description: Um eine PowerPoint-Präsentation in der C++ API zu erstellen, folgen Sie bitte den in diesem Artikel genannten Schritten. Der Code fügt eine Linie zur ersten Folie der Präsentation hinzu.
---

## **PowerPoint-Präsentation erstellen**
Um eine einfache Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ Linie mit der AddAutoShape-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}