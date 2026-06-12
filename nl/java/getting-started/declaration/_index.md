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
description: "Leer over de vertrouwenseisen, permissies en hostingsbeperkingen van Aspose.Slides voor Java, zodat u veilig applicaties kunt implementeren die PPT, PPTX en ODP op servers verwerken."
---
{{% alert color="primary" %}} 

Alle Aspose Java‑componenten vereisen de permissieset Full Trust. De reden is dat Aspose Java‑componenten registerinstellingen, systeembestanden buiten de virtuele directory moeten benaderen voor bepaalde bewerkingen, zoals het parseren van lettertypen, enz. Bovendien zijn Aspose Java‑componenten gebaseerd op kern‑Java‑systeemklassen die in veel gevallen ook de permissieset Full Trust vereisen. 

{{% /alert %}} 

Internet Service Providers die meerdere applicaties van verschillende bedrijven hosten, handhaven meestal het beveiligingsniveau Medium Trust: 

- OleDbPermission is niet beschikbaar. Dit betekent dat je de ADO.NET managed OLE DB‑dataprovider niet kunt gebruiken om databases te benaderen.  
- EventLogPermission is niet beschikbaar. Dit betekent dat je geen toegang hebt tot het Windows‑evenementenlogboek.  
- ReflectionPermission is niet beschikbaar. Dit betekent dat je geen reflection kunt gebruiken.  
- RegistryPermission is niet beschikbaar. Dit betekent dat je geen toegang hebt tot het register.  
- WebPermission is beperkt. Dit betekent dat je applicatie alleen kan communiceren met een adres of een reeks adressen die je definieert in het <trust>-element.  
- FileIOPermission is beperkt. Dit betekent dat je alleen toegang hebt tot bestanden in de virtuele directory‑hiërarchie van je applicatie.  

{{% alert color="primary" %}} 

Vanwege de bovenstaande redenen kunnen Aspose Java‑componenten niet worden gebruikt op servers die een andere permissieset dan Full Trust toekennen. 

{{% /alert %}}