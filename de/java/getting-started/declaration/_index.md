---
title: Deklaration
type: docs
weight: 60
url: /de/java/declaration/
keywords:
- Deklaration
- Komponenten
- Full Trust-Berechtigung
- Registrierungseinstellungen
- Systemdateien
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie mehr über die Vertrauensanforderungen, Berechtigungen und Hosting-Einschränkungen von Aspose.Slides für Java, damit Sie Apps, die PPT, PPTX und ODP verarbeiten, sicher auf Servern bereitstellen können."
---
{{% alert color="info" %}} 

Alle Aspose Java-Komponenten benötigen das Berechtigungssatz Full Trust. Der Grund ist, dass Aspose Java-Komponenten auf Registrierungseinstellungen, Systemdateien außerhalb des virtuellen Verzeichnisses für bestimmte Vorgänge wie das Parsen von Schriftarten usw. zugreifen müssen. Darüber hinaus basieren Aspose Java-Komponenten auf Kern-Java-Systemklassen, die in vielen Fällen ebenfalls den Berechtigungssatz Full Trust erfordern. 

{{% /alert %}} 

Internet-Service-Provider, die mehrere Anwendungen verschiedener Unternehmen hosten, setzen meist das Sicherheitsniveau Medium Trust durch: 

- OleDbPermission ist nicht verfügbar. Das bedeutet, dass Sie den verwalteten OLE DB-Datenprovider von ADO.NET nicht zum Zugriff auf Datenbanken verwenden können.
- EventLogPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf das Windows-Ereignisprotokoll zugreifen können.
- ReflectionPermission ist nicht verfügbar. Das bedeutet, dass Sie Reflection nicht verwenden können.
- RegistryPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf die Registrierung zugreifen können.
- WebPermission ist eingeschränkt. Das bedeutet, dass Ihre Anwendung nur mit einer Adresse oder einem Adressbereich kommunizieren kann, den Sie im <trust>-Element definieren.
- FileIOPermission ist eingeschränkt. Das bedeutet, dass Sie nur auf Dateien in der virtuellen Verzeichnisstruktur Ihrer Anwendung zugreifen können.

{{% alert color="info" %}} 

Aufgrund der oben genannten Gründe können Aspose Java-Komponenten nicht auf Servern verwendet werden, die einen anderen Berechtigungssatz als Full Trust gewähren. 

{{% /alert %}}