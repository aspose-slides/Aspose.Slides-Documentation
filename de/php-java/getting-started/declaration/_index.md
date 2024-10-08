---
title: Deklaration
type: docs
weight: 60
url: /de/php-java/declaration/
---

{{% alert color="primary" %}} 

Alle Aspose Java-Komponenten erfordern das Full Trust-Berechtigungsset. Der Grund dafür ist, dass Aspose Java-Komponenten auf Registrierungseinstellungen und Systemdateien, die nicht in einem virtuellen Verzeichnis enthalten sind, für bestimmte Operationen wie das Parsen von Schriftarten zugreifen müssen. Darüber hinaus basieren Aspose Java-Komponenten auf Kern-Java-Systemklassen, die in vielen Fällen ebenfalls das Full Trust-Berechtigungsset erfordern. 

{{% /alert %}} 

Internetdienstanbieter, die mehrere Anwendungen von verschiedenen Unternehmen hosten, setzen meistens das Medium Trust-Sicherheitsniveau durch: 

- OleDbPermission ist nicht verfügbar. Das bedeutet, dass Sie den verwalteten OLE DB-Datenanbieter ADO.NET nicht verwenden können, um auf Datenbanken zuzugreifen.
- EventLogPermission ist nicht verfügbar. Das bedeutet, dass Sie keinen Zugriff auf das Windows-Ereignisprotokoll haben.
- ReflectionPermission ist nicht verfügbar. Das bedeutet, dass Sie keine Reflexion verwenden können.
- RegistryPermission ist nicht verfügbar. Das bedeutet, dass Sie keinen Zugriff auf die Registrierung haben.
- WebPermission ist eingeschränkt. Das bedeutet, dass Ihre Anwendung nur mit einer Adresse oder einem Adressbereich kommunizieren kann, den Sie im <trust>-Element definieren.
- FileIOPermission ist eingeschränkt. Das bedeutet, dass Sie nur auf Dateien in der virtuellen Verzeichnisstruktur Ihrer Anwendung zugreifen können.

{{% alert color="primary" %}} 

Aufgrund der oben genannten Gründe können Aspose Java-Komponenten nicht auf Servern verwendet werden, die ein anderes Berechtigungsset als Full Trust gewähren. 

{{% /alert %}}