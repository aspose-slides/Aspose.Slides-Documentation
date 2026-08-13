---
title: Deklaration
type: docs
weight: 110
url: /de/net/declaration/
keywords:
- Deklaration
- Komponenten
- Full Trust-Berechtigung
- Registrierungseinstellungen
- Systemdateien
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie mehr über die Trust-Anforderungen, Berechtigungen und Hosting-Beschränkungen von Aspose.Slides für .NET, damit Sie Anwendungen, die PPT, PPTX und ODP verarbeiten, sicher auf Servern bereitstellen können."
---
{{% alert color="info" %}} 

Alle Aspose .NET-Komponenten benötigen das Berechtigungssatz Full Trust, weil sie gelegentlich auf Registrierungseinstellungen, Systemdateien und in anderen Speicherorten (außerhalb des virtuellen Verzeichnisses) gespeicherte Dateien für bestimmte Vorgänge (zum Beispiel das Parsen von Schriftarten) zugreifen müssen. Außerdem basieren Aspose .NET-Komponenten auf Kern-.NET-Systemklassen, die in vielen Fällen das Berechtigungssatz Full Trust erfordern. 

{{% /alert %}} 

Internet Service Provider, die mehrere Anwendungen verschiedener Unternehmen hosten, setzen meist das Sicherheitsniveau Medium Trust durch. In einem .NET 2.0-Fall wendet dieses Sicherheitsniveau folgende Einschränkungen an: 

- OleDbPermission ist nicht verfügbar. Das bedeutet, dass Sie den verwalteten OLE DB-Datenprovider von ADO.NET nicht zum Zugriff auf Datenbanken verwenden können.
- EventLogPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf das Windows-Ereignisprotokoll zugreifen können.
- ReflectionPermission ist nicht verfügbar. Das bedeutet, dass Sie keine Reflexion verwenden können.
- RegistryPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf die Registrierung zugreifen können.
- WebPermission ist eingeschränkt. Das bedeutet, dass Ihre Anwendung nur mit einer Adresse oder einem Adressbereich kommunizieren kann, den Sie im <trust>-Element definiert haben.
- FileIOPermission ist eingeschränkt. Das bedeutet, dass Sie nur auf Dateien in der virtuellen Verzeichnisstruktur Ihrer Anwendung zugreifen können.

{{% alert color="info" %}} 

Aus den oben genannten Gründen können Aspose .NET-Komponenten nur auf Servern verwendet werden, die das Berechtigungssatz Full Trust gewähren. 

{{% /alert %}}