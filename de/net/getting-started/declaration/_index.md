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
description: "Erfahren Sie mehr über die Vertrauensanforderungen, Berechtigungen und Hosting-Einschränkungen von Aspose.Slides für .NET, damit Sie Apps, die PPT, PPTX und ODP verarbeiten, sicher auf Servern bereitstellen können."
---

{{% alert color="primary" %}} 

Alle Aspose .NET-Komponenten benötigen das Berechtigungssatz Full Trust, weil sie manchmal auf Registrierungseinstellungen, Systemdateien und in anderen Bereichen (außerhalb des virtuellen Verzeichnisses) gespeicherte Dateien zugreifen müssen, um bestimmte Vorgänge auszuführen (z. B. das Parsen von Schriftarten). Darüber hinaus basieren Aspose .NET-Komponenten auf Kern‑.NET-Systemklassen, die in vielen Fällen den Berechtigungssatz Full Trust erfordern. 

{{% /alert %}} 

Internet Service Provider, die mehrere Anwendungen verschiedener Unternehmen hosten, setzen in der Regel das Sicherheitsniveau Medium Trust durch. In einem .NET 2.0‑Fall gelten für ein solches Sicherheitsniveau folgende Beschränkungen: 

- OleDbPermission ist nicht verfügbar. Das bedeutet, dass Sie den verwalteten OLE DB-Datenprovider von ADO.NET nicht zum Zugriff auf Datenbanken verwenden können.
- EventLogPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf das Windows-Ereignisprotokoll zugreifen können.
- ReflectionPermission ist nicht verfügbar. Das bedeutet, dass Sie Reflection nicht verwenden können.
- RegistryPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf die Registrierung zugreifen können.
- WebPermission ist eingeschränkt. Das bedeutet, dass Ihre Anwendung nur mit einer Adresse oder einem Adressbereich kommunizieren kann, den Sie im <trust>-Element definiert haben.
- FileIOPermission ist eingeschränkt. Das bedeutet, dass Sie nur auf Dateien in der virtuellen Verzeichnis‑Hierarchie Ihrer Anwendung zugreifen können.

{{% alert color="primary" %}} 

Aufgrund der oben genannten Gründe können Aspose .NET‑Komponenten nur auf Servern verwendet werden, die den Berechtigungssatz Full Trust gewähren. 

{{% /alert %}}