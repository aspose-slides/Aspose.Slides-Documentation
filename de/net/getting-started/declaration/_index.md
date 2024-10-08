---
title: Deklaration
type: docs
weight: 110
url: /de/net/declaration/
---

{{% alert color="primary" %}} 

Alle Aspose .NET Komponenten erfordern das Full Trust Berechtigungsschema, da sie manchmal auf Registrierungseinstellungen, Systemdateien und Dateien in anderen Verzeichnissen (neben dem virtuellen Verzeichnis) für bestimmte Operationen (z.B. beim Parsen von Schriftarten) zugreifen müssen. Außerdem basieren Aspose .NET Komponenten auf den Kern .NET Systemklassen, die in vielen Fällen das Full Trust Berechtigungsschema erfordern.

{{% /alert %}} 

Internetdienstanbieter, die mehrere Anwendungen von verschiedenen Unternehmen hosten, setzen in der Regel das Medium Trust Sicherheitslevel durch. Im Falle von .NET 2.0 gelten für ein solches Sicherheitslevel folgende Einschränkungen:

- OleDbPermission ist nicht verfügbar. Das bedeutet, dass Sie den ADO.NET verwalteten OLE DB-Datenanbieter nicht verwenden können, um auf Datenbanken zuzugreifen.
- EventLogPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf das Windows-Ereignisprotokoll zugreifen können.
- ReflectionPermission ist nicht verfügbar. Das bedeutet, dass Sie Reflection nicht verwenden können.
- RegistryPermission ist nicht verfügbar. Das bedeutet, dass Sie nicht auf die Registrierung zugreifen können.
- WebPermission ist eingeschränkt. Das bedeutet, dass Ihre Anwendung nur mit einer Adresse oder dem Adressbereich kommunizieren kann, den Sie im <trust>-Element definiert haben.
- FileIOPermission ist eingeschränkt. Das bedeutet, dass Sie nur auf Dateien in der virtuellen Verzeichnisstruktur Ihrer Anwendung zugreifen können.

{{% alert color="primary" %}} 

Aus den oben genannten Gründen können Aspose .NET Komponenten nur auf Servern verwendet werden, die das Full Trust Berechtigungsschema gewähren.

{{% /alert %}}