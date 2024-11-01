---
title: Deklaration
type: docs
weight: 60
url: /de/java/declaration/
---

{{% alert color="primary" %}} 

Alle Aspose Java-Komponenten erfordern das Berechtigungs-Set "Vollständiges Vertrauen". Der Grund dafür ist, dass Aspose Java-Komponenten auf Registrierungseinstellungen und Systemdateien außerhalb des virtuellen Verzeichnisses für bestimmte Operationen wie das Parsen von Schriftarten usw. zugreifen müssen. Darüber hinaus basieren Aspose Java-Komponenten auf den Kerntypen des Java-Systems, die in vielen Fällen ebenfalls ein Berechtigungs-Set "Vollständiges Vertrauen" erfordern. 

{{% /alert %}} 

Internetdienstanbieter, die mehrere Anwendungen von verschiedenen Unternehmen hosten, setzen in der Regel das Sicherheitsniveau "Mittleres Vertrauen" durch: 

- OleDbPermission ist nicht verfügbar. Das bedeutet, dass Sie den verwalteten OLE DB-Datenanbieter von ADO.NET nicht verwenden können, um auf Datenbanken zuzugreifen.
- EventLogPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf das Windows-Ereignisprotokoll zugreifen können.
- ReflectionPermission ist nicht verfügbar. Das bedeutet, dass Sie keine Reflexion verwenden können.
- RegistryPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf die Registrierung zugreifen können.
- WebPermission ist eingeschränkt. Das bedeutet, dass Ihre Anwendung nur mit einer Adresse oder einem Adressbereich kommunizieren kann, den Sie im <trust>-Element definieren.
- FileIOPermission ist eingeschränkt. Das bedeutet, dass Sie nur auf Dateien im virtuellen Verzeichnis-Hierarchie Ihrer Anwendung zugreifen können.

{{% alert color="primary" %}} 

Aufgrund der oben angegebenen Gründe können Aspose Java-Komponenten nicht auf Servern verwendet werden, die ein Berechtigungs-Set gewähren, das nicht "Vollständiges Vertrauen" ist. 

{{% /alert %}}