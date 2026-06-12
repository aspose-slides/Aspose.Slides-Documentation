---
title: Declaratie
type: docs
weight: 60
url: /nl/php-java/declaration/
keywords:
- declaratie
- componenten
- Full Trust-machtiging
- registerinstellingen
- systeembestanden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer over de trust‑vereisten, rechten en hostingsbeperkingen van Aspose.Slides voor PHP, zodat u veilig applicaties kunt inzetten die PPT, PPTX en ODP verwerken op servers."
---
{{% alert color="primary" %}} 

Alle Aspose Java‑componenten vereisen een Full Trust‑toestemmingsset. De reden is dat Aspose Java‑componenten registratiesettings, systeembestanden buiten de virtuele map moeten benaderen voor bepaalde bewerkingen, zoals het parseren van lettertypen, enzovoort. Bovendien zijn Aspose Java‑componenten gebaseerd op kern‑Java‑systeemklassen die in veel gevallen ook een Full Trust‑toestemmingsset vereisen. 

{{% /alert %}} 

Internet Service Providers die meerdere toepassingen van verschillende bedrijven hosten, handhaven meestal het beveiligingsniveau Medium Trust: 

- OleDbPermission is niet beschikbaar. Dit betekent dat u de ADO.NET beheerde OLE DB‑dataprovider niet kunt gebruiken om databases te benaderen.
- EventLogPermission is niet beschikbaar. Dit betekent dat u geen toegang heeft tot het Windows‑eventlog.
- ReflectionPermission is niet beschikbaar. Dit betekent dat u geen reflection kunt gebruiken.
- RegistryPermission is niet beschikbaar. Dit betekent dat u geen toegang heeft tot het register.
- WebPermission is beperkt. Dit betekent dat uw toepassing alleen kan communiceren met een adres of een reeks adressen die u definieert in het <trust>-element.
- FileIOPermission is beperkt. Dit betekent dat u alleen toegang heeft tot bestanden in de virtuele map‑hiërarchie van uw toepassing.

{{% alert color="primary" %}} 

Vanwege de hierboven genoemde redenen kunnen Aspose Java‑componenten niet worden gebruikt op servers die een andere toestemmingsset dan Full Trust toekennen. 

{{% /alert %}}