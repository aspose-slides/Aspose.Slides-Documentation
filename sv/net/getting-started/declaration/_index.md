---
title: Krav på förtroendenivå
type: docs
weight: 190
url: /sv/net/declaration/
keywords:
- förtroendenivå
- Fullständigt förtroende
- partiellt förtroende
- Medium-förtroende
- kodåtkomstsäkerhet
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Vilken kodåtkomstsäkerhets‑förtroendenivå Aspose.Slides för .NET kräver: fullständigt förtroende på .NET Framework och ingen förtroendeinställning på .NET 6 och senare."
---
## **Översikt**

Code access security (CAS) förtroendenivåer finns endast i .NET Framework. Den här artikeln förklarar vad de betyder för Aspose.Slides för .NET: biblioteket kräver fullständigt förtroende på .NET Framework, och på .NET 6 och senare finns det ingen förtroendenivå att konfigurera.

## **.NET Framework**

Aspose.Slides kräver fullständigt förtroende på .NET Framework. Det körs inte under partiellt förtroende, såsom en ASP.NET-applikation konfigurerad för Medium Trust (`<trust level="Medium" />`): att skapa ett [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-objekt misslyckas med ett `SecurityException`.

Microsoft behandlar inte längre ASP.NET-partial trust som ett sätt att isolera applikationer från varandra och rekommenderar att köra applikationer i separata applikationspooler istället. Se [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 och senare**

Code access security är inte tillgängligt på .NET 6 och senare, så det finns ingen förtroendenivå att tilldela. Aspose.Slides körs med behörigheterna för det konto som kör din applikation. För att begränsa vad en applikation kan komma åt rekommenderar Microsoft operativsystemgränser, såsom användarkonton, containrar eller virtuella maskiner. Se [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **Vanliga frågor**

**Kan jag använda Aspose.Slides med en webbhotellleverantör som kör ASP.NET-applikationer i Medium Trust?**

Inte i Medium Trust. På .NET Framework måste applikationen som använder Aspose.Slides köras med fullständigt förtroende.