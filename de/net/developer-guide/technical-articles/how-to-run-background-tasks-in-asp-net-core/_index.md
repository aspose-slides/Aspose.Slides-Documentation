---
title: So führen Sie Hintergrundaufgaben in ASP.NET Core aus
type: docs
weight: 300
url: /net/how-to-run-background-tasks-in-asp-net-core/
---

## **Übersicht**
Dateiverarbeitung (z. B. das Exportieren von Präsentationen in PDF) ist eine typische serverseitige Aufgabe. Eine einfache Dateiverarbeitung innerhalb des Anforderungshandlers (wenn der Client wartet, während der Server die Arbeit verrichtet) hat die folgenden Nachteile:

- *Schlechte Benutzeroberfläche*. Die Seite friert ein und der Benutzer muss auf das Ergebnis warten. Ein Seitenneuladen würde die Aufgabe abbrechen.
- *Betriebsauszeit*. Wir können nicht sicherstellen, dass die Verarbeitung innerhalb eines festen Zeitraums abgeschlossen ist, was bedeutet, dass der Benutzer irgendwann "Betriebsauszeit" sehen wird.
- *Geringer Durchsatz und Skalierbarkeit*. ASP.NET Core ist so konzipiert, dass viele Anfragen asynchron verarbeitet werden. Lang laufende CPU-gebundene Aufgaben blockieren die Threads und verringern den Serverdurchsatz.
- *Schlechte Fehlertoleranz*. Wenn während einer lang laufenden Aufgabe etwas schiefgeht (z. B. ein Verbindungsproblem), schlägt die Verarbeitung einfach fehl und wir müssen die Verarbeitung erneut von vorne beginnen.

Ein [besserer Ansatz](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices#complete-long-running-tasks-outside-of-http-requests) besteht darin, die Aufgabe zunächst asynchron zu planen, sie dann im Hintergrund abzuschließen und schließlich das Ergebnis der Verarbeitung zurückzugeben.

In diesem Fall kann der Benutzer den aktuellen Status sehen (und sogar die Seite verlassen oder neu laden), die Serverressourcen können effizient skaliert und flexibel angepasst werden. Auch kann eine Wiederholungsstrategie genutzt werden.

Daher umfasst die typische Hintergrundverarbeitungslösung die folgenden Teile:
1. API zum Planen der Aufgabe.
2. API zum Verfolgen des Aufgabestatus.
3. Der Hintergrundarbeiter, der die geplanten Aufgaben verarbeitet.
4. API zum Speichern/Abfragen des Ergebnisses.


## **Beispiel für eine Hintergrundaufgabe**
Um diesen Ansatz zu demonstrieren, betrachten wir das [**Beispiel ASP.NET Core 3.1-Webanwendung**](https://wiki.lutsk.dynabic.com/download/Aspose%20Slides/slidesnet/Discussion%20on%20Russian/Issues/Platform%20specific/How%20to%20run%20Background%20Tasks%20in%20ASP.NET%20Core/WebHome/BackgroundJobDemo.zip?rev=1.1). Die Web-App enthält eine Webseite, auf der der Benutzer eine Präsentation hochladen und dann die Schaltfläche "Export nach PDF" drücken kann. Anschließend wird die Präsentation hochgeladen und von einem Hintergrundarbeiter in das PDF-Format konvertiert.
## **Webanwendung**
Die Beispiel-Webanwendung (*BackgroundJobDemo*-Projekt) umfasst:

- Hochladeseite (Razor-Seite Upload).
- Fortschrittsseite (Razor-Seite Fortschritt mit einigen JavaScript-Funktionen zur Überprüfung und Anzeige des Status).
- Controller (JobStatusController), der den Verarbeitungsstatus bereitstellt (api/status/{jobId}).
- Controller (JobResultController), der die exportierte PDF-Datei zurückgibt (api/result/{id}).
- Hintergrundarbeiter basierend auf dem ASP.NET Core-Hosting-Service (siehe WorkerService-Klasse).

Razor-Seiten, Controller und Hintergrundarbeiter delegieren die gesamte tatsächliche Arbeit über Schnittstellen, die im *BackgroundJobDemo.Common*-Projekt definiert sind. Die konkreten Implementierungen des Aufgabenmanagements und der Verarbeitung sind in separaten Projekten (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* usw.) definiert und können leicht in der Methode Startup.ConfigureServices wechseln.

Zu Demonstrationszwecken verwendet die "Upload"-Seite die gepufferte Modellbindung, aber für das Hochladen großer Dateien wird ungebufferter Stream [empfohlen](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Bei der Produktionsbereitstellung sollten die [ Sicherheitsaspekte](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations) berücksichtigt werden. Die "Progress"-Seite fragt den status der geplanten Aufgabe alle 2 Sekunden über JavaScript ab (der Zeitraum kann geändert werden). Statusabfragen sind ein typisches Verhalten, aber für fortgeschrittene Fälle können Echtzeitbenachrichtigungen (Echtzeitkommunikation fallen nicht in den Rahmen dieses Artikels) über WebSocket erforderlich sein. [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) ist ein einfaches, aber leistungsstarkes Werkzeug für Echtzeitkommunikationen.

Das Hosten des Hintergrundarbeiters im Serverprozess ist praktisch für einfache Anwendungen, hat jedoch [ Nachteile ](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Die robustere und skalierbare Lösung besteht darin, den Arbeiter in einem separaten Prozess bereitzustellen (siehe z. B. *BackgroundJobDemo.Worker*-Konsolenanwendung).
## **Grundlegende Implementierung**
Das *BackgroundJobDemo.Local*-Projekt enthält eine einfache Implementierung des Aufgabenmanagements mit einer SQLite-Datenbank (der Pfad zur Datenbankdatei wird über LocalConfig.DbFilePath angegeben, siehe in Startup.ConfigureServices). Die hochgeladenen und verarbeiteten Dateien werden im Dateisystem gespeichert (der Pfad zum Speicherordner wird über LocalConfig.FileStorageFolderPath angegeben, siehe in Startup.ConfigureServices). Für eine bessere Fehlertoleranz und Leistung in echten Anwendungen sollte die Aufgabenplanung über Nachrichtenwarteschlangen (z. B. RabbitMQ, AWS SQS, Azure Storage Queue) implementiert werden.
## **Verteilte Implementierung basierend auf Amazon Web Services**
Das *BackgroundJobDemo.Aws*-Projekt implementiert die Aufgabenverarbeitung über Amazon Web Services und demonstriert die verteilte Architektur, die horizontal skalierbar ist. Es umfasst folgende Komponenten:

- Webanwendung - interagiert mit dem Benutzer und plant die PPTX zu PDF-Exportaufgaben usw.
- Arbeiter - verarbeitet Exportaufgaben (im Prozess, außerhalb des Prozesses oder Amazon Lambda).
- Nachrichtenwarteschlange - speichert die zu verarbeitenden Aufgaben (Amazon SQS).
- Dateispeicher - speichert die hochgeladenen und verarbeiteten Dateien (Amazon S3).
- Schlüssel-Wert-Speicher - stellt den Status der Aufgabenverarbeitung bereit (Amazon DynamoDB).

Die typische verteilte Architektur basiert auf [Nachrichtenwarteschlangen](https://aws.amazon.com/message-queue/): Die Webanwendung stellt die Hintergrundaufgaben in die Warteschlange, der Hintergrundarbeiter holt die Aufgabe aus der Warteschlange und führt die erforderliche Arbeit aus. Somit sind die Systemkomponenten (Webanwendung und Hintergrundarbeiter) entkoppelt und die Verarbeitung ist asynchron und zuverlässig. Die Warteschlange garantiert, dass alle Nachrichten (Aufgaben) an die Arbeiter zugestellt werden. Die Warteschlangen-Nachrichten haben eine *Sichtbarkeitszeitüberschreitung* - wenn ein Arbeiter die Nachricht zur Verarbeitung erhält, wird die Nachricht für andere Arbeiter unsichtbar und nur der Arbeiter, der die Nachricht verarbeitet, entfernt sie aus der Warteschlange. Wenn die Verarbeitung während der Sichtbarkeitszeitüberschreitung nicht abgeschlossen ist (z. B. aufgrund eines Fehlers oder eines Netzwerkproblems), wird die nicht verarbeitete Nachricht wieder sichtbar für die Arbeiter.

Unsere Implementierung verwendet [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS) - vollständig verwaltete Nachrichtenwarteschlangen für Microservices, verteilte Systeme und serverlose Anwendungen.

Die Nachrichtenwarteschlangen sind für leichte Nachrichten konzipiert (z. B. das SQS-Nachrichtengröße-Limit beträgt 256 KB), daher sollten sie nur die Aufgabenbeschreibung enthalten. Alle schweren Daten (z. B. zu verarbeitende Dateien) sollten in einem separaten Speicher abgelegt und von der Nachricht referenziert werden. [Amazon S3](https://aws.amazon.com/s3/) ist ein Objektspeicher, der zum Speichern und Abrufen beliebiger Datenmengen von überall ausgelegt ist. Dieser Dienst wird zum Speichern von hochgeladenen und verarbeiteten Dateien verwendet.

Ein Schlüssel-Wert-Speicher ist erforderlich, um das Ergebnis der Aufgabenverarbeitung nach ID zu speichern und abzurufen. [Amazon DynamoDB](https://aws.amazon.com/dynamodb/) (ein schneller und flexibler NoSQL-Datenbankdienst für jede Skalierung) wurde in diesem Beispiel verwendet.

Um die Demoanwendung mit Amazon Web Services auszuführen:

1. Erstellen und konfigurieren Sie in derselben AWS-Region:
   1. SQS-Warteschlange,
   1. S3-Bucket,
   1. DynamoDB-Tabelle.
1. Verbinden Sie die Webanwendung mit den erstellten Diensten über die AddAws Erweiterungsmethode (SQS-Warteschlangen-URL, S3-Bucket-Name, DynamoDB-Tabellenname und AWS-Region) aus Startup.ConfigureServices. 
## **Referenzen**
- Leistungsbest Practices für ASP.NET Core <https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices>
- Dateien in ASP.NET Core hochladen <https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads>
- Echtzeit-ASP.NET mit SignalR <https://dotnet.microsoft.com/apps/aspnet/signalr>
- Nachrichtenwarteschlangen <https://aws.amazon.com/message-queue/>
- Amazon Simple Queue Service <https://aws.amazon.com/sqs/>
- Amazon S3 <https://aws.amazon.com/s3/>
- Amazon DynamoDB <https://aws.amazon.com/dynamodb/>
