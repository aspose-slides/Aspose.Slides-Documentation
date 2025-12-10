---
title: Wie man Beispiele ausführt
type: docs
weight: 130
url: /de/net/how-to-run-examples/
keywords:
- Beispiele
- Softwareanforderungen
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Führen Sie Aspose.Slides für .NET-Beispiele schnell aus: Klonen Sie das Repository, stellen Sie die Pakete wieder her und bauen Sie anschließend, um Funktionen für PPT, PPTX und ODP zu testen."
---

## **Softwareanforderungen**
Bevor Sie die Beispiele herunterladen und ausführen, überprüfen Sie bitte, ob Ihre Umgebung diese Anforderungen erfüllt: 

- Visual Studio 2010 oder höher.
- NuGet Package Manager in Visual Studio installiert. Vergewissern Sie sich, dass die neueste NuGet‑API‑Version in Visual Studio installiert ist. 

Anweisungen zur Installation des NuGet Package Managers finden Sie auf dieser Seite: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Gehen Sie zu **Tools** > **Options** > **NuGet Package Manager**.

1. Erweitern Sie **NuGet Package Manager** (durch Doppelklick) und wählen Sie dann **Package Sources**. 

1. Stellen Sie sicher, dass der Parameter nuget.org ausgewählt ist. 

   Das Beispielprojekt verwendet die NuGet‑Funktion zum automatischen Wiederherstellen von Paketen, daher benötigen Sie eine aktive Internetverbindung. 

   Falls Sie auf dem Rechner, auf dem Sie die Beispiele ausführen möchten, keine aktive Internetverbindung haben, prüfen Sie bitte die [Installation](https://docs.aspose.com/slides/net/installation/) und fügen Sie (manuell) eine Referenz zu Aspose.Slides.dll im Beispielprojekt hinzu.
## **Aspose.Slides von GitHub herunterladen**
Alle Aspose.Slides‑Beispiele für .NET werden auf [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET) gehostet.

Sie können das Repository entweder mit Ihrem bevorzugten GitHub‑Client klonen oder die ZIP‑Datei [hier](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip) herunterladen.

1. Wenn Sie die ZIP‑Datei herunterladen, müssen Sie deren Inhalt in einen Ordner auf Ihrem Computer extrahieren. 

Alle Beispiele befinden sich im Ordner **Examples**.

Es gibt eine C#‑Visual‑Studio‑Lösungsdatei. Die Projekte wurden in Visual Studio 2013 erstellt, die Lösungsdateien sind jedoch mit Visual Studio 2010 SP1 und höher kompatibel.

2. Öffnen Sie die Lösungsdatei in Visual Studio und bauen Sie das Projekt.

   Beim ersten Ausführen werden die Abhängigkeiten automatisch über NuGet heruntergeladen.

Der Ordner **Data** im Stammverzeichnis von **Examples** enthält Eingabedateien, die in den C#‑Beispielen verwendet werden. Sie müssen den Ordner **Data** zusammen mit dem Beispielprojekt herunterladen.

3. Öffnen Sie die Datei RunExamples.cs. Alle Beispiele werden von dort aus aufgerufen.

4. Kommentieren Sie die Beispiele, die Sie im Projekt ausführen möchten, aus.

Bei Problemen mit der Einrichtung oder dem Ausführen der Beispiele können Sie gerne über unser Forum Kontakt aufnehmen.
## **Beitragen**
Sie können zum Projekt beitragen, indem Sie ein Beispiel hinzufügen oder verbessern. Alle Beispiele und Demo‑Projekte im Repository sind Open‑Source, sodass Sie (und andere) sie frei in Anwendungen verwenden können.

Um beizutragen, können Sie das Repository forken, den Quellcode bearbeiten und einen Pull‑Request erstellen. Wir prüfen die Änderungen. Wenn wir sie nützlich finden, werden wir sie dem Repository hinzufügen.