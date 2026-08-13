---
title: Declaratie
type: docs
weight: 60
url: /nl/java/declaration/
keywords:
- declaratie
- componenten
- Full Trust-permissie
- registerinstellingen
- systeembestanden
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer meer over de trust‑vereisten, permissies en hosting‑beperkingen van Aspose.Slides voor Java, zodat u veilig applicaties kunt inzetten die PPT, PPTX en ODP verwerken op servers."
---
{{% alert color="info" %}} 

Alle Aspose Java-componenten vereisen de Full Trust-permissieset. De reden is dat Aspose Java-componenten registerinstellingen, systeembestanden buiten de virtuele map moeten benaderen voor bepaalde bewerkingen, zoals het parseren van lettertypen, enz. Bovendien zijn Aspose Java-componenten gebaseerd op kern‑Java‑systeemklassen die in veel gevallen ook de Full Trust-permissieset vereisen. 

{{% /alert %}} 

Internet Service Providers die meerdere applicaties van verschillende bedrijven hosten, handhaven meestal het beveiligingsniveau Medium Trust: 

- OleDbPermission is niet beschikbaar. Dit betekent dat u de beheerste OLE DB‑dataprovider van ADO.NET niet kunt gebruiken om toegang te krijgen tot databases.
- EventLogPermission is niet beschikbaar. Dit betekent dat u geen toegang heeft tot de Windows‑eventlog.
- ReflectionPermission is niet beschikbaar. Dit betekent dat u geen reflectie kunt gebruiken.
- RegistryPermission is niet beschikbaar. Dit betekent dat u geen toegang heeft tot het register.
- WebPermission is beperkt. Dit betekent dat uw applicatie alleen kan communiceren met een adres of een bereik van adressen dat u definieert in het <trust>-element.
- FileIOPermission is beperkt. Dit betekent dat u alleen toegang heeft tot bestanden in de virtuele directory‑hiërarchie van uw applicatie.

{{% alert color="info" %}} 

Vanwege de hierboven genoemde redenen kunnen Aspose Java-componenten niet worden gebruikt op servers die een andere permissieset dan Full Trust verlenen. 

{{% /alert %}}