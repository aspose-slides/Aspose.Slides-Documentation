---
title: Vertrouwensniveauvereisten
type: docs
weight: 190
url: /nl/net/declaration/
keywords:
- vertrouwensniveau
- Volledig vertrouwen
- gedeeltelijk vertrouwen
- Medium Trust
- code-toegangsbeveiliging
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Welk code-toegangsbeveiligingsvertrouwensniveau Aspose.Slides voor .NET vereist: volledig vertrouwen op .NET Framework, en geen vertrouwensinstelling op .NET 6 en later."
---
## **Overzicht**

Code‑toegangsbeveiliging (CAS) vertrouwensniveaus bestaan alleen in .NET Framework. Dit artikel legt uit wat ze betekenen voor Aspose.Slides voor .NET: de bibliotheek vereist volledige vertrouwen op .NET Framework, en op .NET 6 en later is er geen vertrouwensniveau om te configureren.

## **.NET Framework**

Aspose.Slides vereist volledige vertrouwen op .NET Framework. Het werkt niet onder gedeeltelijk vertrouwen, zoals een ASP.NET‑applicatie die is geconfigureerd voor Medium Trust (`<trust level="Medium" />`): het aanmaken van een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑object mislukt met een `SecurityException`.

Microsoft beschouwt ASP.NET‑gedeeld vertrouwen niet langer als een manier om applicaties van elkaar te isoleren en raadt aan om applicaties in afzonderlijke application pools uit te voeren. Zie [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

Code‑toegangsbeveiliging is niet beschikbaar op .NET 6 en later, dus er is geen vertrouwensniveau om toe te kennen. Aspose.Slides draait met de rechten van het account dat uw applicatie uitvoert. Om te beperken waartoe een applicatie toegang heeft, beveelt Microsoft grenzen op besturingssysteemniveau aan, zoals gebruikersaccounts, containers of virtuele machines. Zie [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Kan ik Aspose.Slides gebruiken bij een hostingprovider die ASP.NET‑applicaties uitvoert in Medium Trust?**

Niet in Medium Trust. Op .NET Framework moet de applicatie die Aspose.Slides gebruikt draaien met volledige vertrouwen.