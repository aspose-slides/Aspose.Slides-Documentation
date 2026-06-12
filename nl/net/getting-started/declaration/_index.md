---
title: Declaratie
type: docs
weight: 110
url: /nl/net/declaration/
keywords:
- declaratie
- componenten
- Full Trust-machtiging
- registerinstellingen
- systeembestanden
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer meer over de trust‑vereisten, machtigingen en host‑beperkingen van Aspose.Slides voor .NET, zodat u veilig toepassingen kunt implementeren die PPT, PPTX en ODP verwerken op servers."
---
{{% alert color="primary" %}} 

Alle Aspose .NET‑componenten vereisen de Full Trust‑machtigingenset omdat ze soms toegang moeten hebben tot registersleutels, systeembestanden en bestanden die op andere locaties zijn opgeslagen (naast de virtuele map) voor bepaalde bewerkingen (bijvoorbeeld het parseren van lettertypen). Bovendien zijn Aspose .NET‑componenten gebaseerd op de kern‑.NET‑systeemklassen, die in veel gevallen de Full Trust‑machtigingenset nodig hebben. 

{{% /alert %}} 

Internet‑serviceproviders die meerdere applicaties van verschillende bedrijven hosten, hanteren meestal het Medium Trust‑beveiligingsniveau. In een .NET 2.0‑situatie brengt dit beveiligingsniveau de volgende beperkingen met zich mee: 

- OleDbPermission is niet beschikbaar. Dit betekent dat je de ADO.NET‑beheerde OLE DB‑dataprovider niet kunt gebruiken om databases te benaderen.
- EventLogPermission is niet beschikbaar. Dit betekent dat je geen toegang hebt tot het Windows‑event‑logboek.
- ReflectionPermission is niet beschikbaar. Dit betekent dat je geen reflection kunt gebruiken.
- RegistryPermission is niet beschikbaar. Dit betekent dat je geen toegang hebt tot het register.
- WebPermission is beperkt. Dit betekent dat je applicatie alleen kan communiceren met een adres of een adresreeks die je hebt gedefinieerd in het <trust>‑element.
- FileIOPermission is beperkt. Dit betekent dat je alleen toegang hebt tot bestanden binnen de virtuele map‑hiërarchie van je applicatie.

{{% alert color="primary" %}} 

Om de bovenstaande redenen kunnen Aspose .NET‑componenten alleen worden gebruikt op servers die de Full Trust‑machtigingenset verlenen. 

{{% /alert %}}