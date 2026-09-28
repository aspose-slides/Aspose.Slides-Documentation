---
title: Požadavky na úroveň důvěry
type: docs
weight: 190
url: /cs/net/declaration/
keywords:
- úroveň důvěry
- oprávnění plné důvěry
- částečná důvěra
- střední důvěra
- bezpečnost přístupu k kódu
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Jakou úroveň důvěry bezpečnosti přístupu k kódu potřebuje Aspose.Slides pro .NET: plnou důvěru na .NET Framework a žádné nastavení důvěry na .NET 6 a novějších."
---
## **Přehled**

Bezpečnost přístupu k kódu (CAS) existuje jen v .NET Framework. Tento článek vysvětluje, co to znamená pro Aspose.Slides pro .NET: knihovna vyžaduje plnou důvěru na .NET Framework a v .NET 6 a novějších neexistuje úroveň důvěry, kterou lze konfigurovat.

## **.NET Framework**

Aspose.Slides vyžaduje plnou důvěru na .NET Framework. Není možné spustit ji v částečné důvěře, např. v ASP.NET aplikaci nastavené na Střední důvěru (`<trust level="Medium" />`): vytvoření objektu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) selže s `SecurityException`.

Microsoft již nepovažuje částečnou důvěru ASP.NET za způsob izolace aplikací a doporučuje spouštět aplikace v samostatných aplikačních fondech. Viz [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

Bezpečnost přístupu k kódu není v .NET 6 a novějších k dispozici, takže neexistuje úroveň důvěry, kterou by bylo třeba udělit. Aspose.Slides běží s oprávněními účtu, pod kterým je aplikace spuštěna. Pro omezení přístupu aplikace Microsoft doporučuje hranice operačního systému, např. uživatelské účty, kontejnery nebo virtuální stroje. Viz [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Mohu používat Aspose.Slides u poskytovatele hostingu, který spouští ASP.NET aplikace ve Střední důvěře?**

Ne ve Střední důvěře. V .NET Framework musí aplikace používající Aspose.Slides běžet s plnou důvěrou.