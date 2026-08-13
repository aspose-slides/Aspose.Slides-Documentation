---
title: Declaratie
type: docs
weight: 110
url: /nl/net/declaration/
keywords:
- declaratie
- componenten
- Full Trust-permissie
- registerinstellingen
- systeembestanden
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer meer over de trust-vereisten, permissies en hostingsbeperkingen van Aspose.Slides voor .NET, zodat u applicaties die PPT, PPTX en ODP verwerken veilig kunt inzetten op servers."
---
{{% alert color="info" %}} 

Alle Aspose .NET componenten vereisen de Full Trust‑permissieset omdat ze soms registerinstellingen, systeembestanden en bestanden die op andere locaties zijn opgeslagen (naast de virtuele directory) moeten benaderen voor bepaalde bewerkingen (bijvoorbeeld het parseren van lettertypen). Bovendien zijn Aspose .NET‑componenten gebaseerd op core .NET‑systeemklassen, die in veel gevallen de Full Trust‑permissieset vereisen. 

{{% /alert %}} 

Internet Service Providers die meerdere applicaties van verschillende bedrijven hosten, handhaven meestal het beveiligingsniveau Medium Trust. In een .NET 2.0‑situatie legt een dergelijk beveiligingsniveau deze beperkingen op: 

- OleDbPermission is niet beschikbaar. Dit betekent dat u de ADO.NET‑beheerde OLE DB‑dataprovider niet kunt gebruiken om databases te benaderen.  
- EventLogPermission is niet beschikbaar. Dit betekent dat u geen toegang heeft tot het Windows‑evenementlogboek.  
- ReflectionPermission is niet beschikbaar. Dit betekent dat u geen reflectie kunt gebruiken.  
- RegistryPermission is niet beschikbaar. Dit betekent dat u geen toegang heeft tot het register.  
- WebPermission is beperkt. Dit betekent dat uw applicatie alleen kan communiceren met een adres of een reeks adressen die u hebt gedefinieerd in het <trust>-element.  
- FileIOPermission is beperkt. Dit betekent dat u alleen toegang heeft tot bestanden in de virtuele directory‑hiërarchie van uw applicatie.  

{{% alert color="info" %}} 

Om de bovenstaande redenen kunnen Aspose .NET‑componenten alleen worden gebruikt op servers die de Full Trust‑permissieset verlenen. 

{{% /alert %}}