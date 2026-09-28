---
title: Wymagania dotyczące poziomu zaufania
type: docs
weight: 190
url: /pl/net/declaration/
keywords:
- poziom zaufania
- uprawnienie Pełnego Zaufania
- częściowe zaufanie
- Zaufanie Średnie
- zabezpieczenia dostępu do kodu
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Jakiego poziomu zaufania w zabezpieczeniach dostępu do kodu wymaga Aspose.Slides dla .NET: pełne zaufanie w .NET Framework oraz brak ustawienia zaufania w .NET 6 i nowszych."
---
## **Omówienie**

Poziomy zaufania Code Access Security (CAS) istnieją wyłącznie w .NET Framework. Ten artykuł wyjaśnia, co oznaczają dla Aspose.Slides dla .NET: biblioteka wymaga pełnego zaufania w .NET Framework, a w .NET 6 i nowszych nie ma poziomu zaufania do skonfigurowania.

## **.NET Framework**

Aspose.Slides wymaga pełnego zaufania w .NET Framework. Nie działa w trybie częściowego zaufania, takim jak aplikacja ASP.NET skonfigurowana na Medium Trust (`<trust level="Medium" />`): tworzenie obiektu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) powoduje błąd `SecurityException`.

Microsoft nie traktuje już częściowego zaufania w ASP.NET jako sposobu izolacji aplikacji od siebie i zaleca uruchamianie aplikacji w oddzielnych pulach aplikacji. Zobacz [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 i nowsze**

Code Access Security nie jest dostępny w .NET 6 i nowszych, więc nie ma poziomu zaufania do przyznania. Aspose.Slides działa z uprawnieniami konta, które uruchamia aplikację. Aby ograniczyć dostęp aplikacji, Microsoft zaleca granice systemu operacyjnego, takie jak konta użytkowników, kontenery lub maszyny wirtualne. Zobacz [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Czy mogę używać Aspose.Slides u dostawcy hostingu, który uruchamia aplikacje ASP.NET w Medium Trust?**

Nie w Medium Trust. W .NET Framework aplikacja korzystająca z Aspose.Slides musi działać z pełnym zaufaniem.