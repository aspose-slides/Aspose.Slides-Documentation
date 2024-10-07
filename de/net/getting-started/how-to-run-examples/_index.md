---
title: So führen Sie Beispiele aus
type: docs
weight: 130
url: /net/how-to-run-examples/
---

## **Softwareanforderungen**
Bevor Sie die Beispiele herunterladen und ausführen, überprüfen Sie bitte, ob Ihre Umgebung diese Anforderungen erfüllt:

- Visual Studio 2010 oder höher.
- NuGet-Paket-Manager in Visual Studio installiert. Überprüfen Sie, ob die neueste NuGet-API-Version in Visual Studio installiert ist.

Für Anweisungen zur Installation des NuGet-Paketmanagers gehen Sie zu dieser Seite: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Gehen Sie zu **Extras** > **Optionen** > **NuGet-Paket-Manager**.

1. Erweitern Sie **NuGet-Paket-Manager** (indem Sie darauf doppelklicken) und wählen Sie dann **Paketquellen** aus.

1. Überprüfen und bestätigen Sie, dass der Parameter nuget.org ausgewählt ist.

   Das Beispielprojekt verwendet die Funktion zur automatischen Paketwiederherstellung von NuGet, daher benötigen Sie eine aktive Internetverbindung.

   Wenn Sie keine aktive Internetverbindung auf dem Computer haben, auf dem Sie die Beispiele ausführen möchten, überprüfen Sie bitte [Installation](https://docs.aspose.com/slides/net/installation/) und fügen Sie manuell einen Verweis auf Aspose.Slides.dll im Beispielprojekt hinzu.
## **Herunterladen von GitHub**
Alle Aspose.Slides für .NET Beispiele sind auf [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET) gehostet.

Sie können das Repository entweder mit Ihrem bevorzugten GitHub-Client klonen oder die ZIP-Datei [hier](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip) herunterladen.

1. Wenn Sie die ZIP-Datei herunterladen, müssen Sie deren Inhalte in einen Ordner auf Ihrem Computer extrahieren.

Alle Beispiele befinden sich im Ordner **Beispiele**.

Es gibt eine C# Visual Studio-Lösungsdatei. Die Projekte wurden in Visual Studio 2013 erstellt, aber die Lösungsdateien sind mit Visual Studio 2010 SP1 und höher kompatibel.

2. Öffnen Sie die Lösungsdatei in Visual Studio und erstellen Sie das Projekt.

   Beim ersten Ausführen werden die Abhängigkeiten automatisch über NuGet heruntergeladen.

Der Ordner **Daten** im Hauptordner **Beispiele** enthält Eingabedateien, die in den C#-Beispielen verwendet werden. Sie müssen den Ordner **Daten** zusammen mit dem Beispielprojekt herunterladen.

3. Öffnen Sie die Datei RunExamples.cs. Alle Beispiele werden von hier aus aufgerufen.

4. Kommentieren Sie die Beispiele aus, die Sie im Projekt ausführen möchten.

Bitte zögern Sie nicht, uns über unsere Foren zu kontaktieren, wenn Sie Probleme beim Einrichten oder Ausführen der Beispiele haben.
## **Mitwirken**
Sie können zum Projekt beitragen, indem Sie ein Beispiel hinzufügen oder verbessern. Alle Beispiele und Showcase-Projekte im Repository sind Open Source, sodass Sie (und andere Personen) sie frei in Anwendungen verwenden können.

Um mitzuarbeiten, können Sie das Repository forken, den Quellcode bearbeiten und einen Pull-Request erstellen. Wir werden die Änderungen überprüfen. Wenn wir sie nützlich finden, werden wir sie im Repository hinzufügen.