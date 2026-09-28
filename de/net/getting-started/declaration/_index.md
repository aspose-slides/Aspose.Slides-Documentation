---
title: Anforderungen an die Vertrauensstufe
type: docs
weight: 190
url: /de/net/declaration/
keywords:
- Vertrauensstufe
- Vollvertrauen-Berechtigung
- Teilvertrauen
- Medium Trust
- Codezugriffssicherheit
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Welcher Codezugriffssicherheits-Vertrauensstufe Aspose.Slides für .NET benötigt: Vollvertrauen im .NET Framework und keine Vertrauenseinstellung in .NET 6 und später."
---
## **Übersicht**

Codezugriffssicherheit (CAS)-Vertrauensstufen existieren nur im .NET Framework. Dieser Artikel erklärt, was sie für Aspose.Slides für .NET bedeuten: Die Bibliothek benötigt Vollvertrauen im .NET Framework, und in .NET 6 und später gibt es keine Vertrauensstufe, die konfiguriert werden kann.

## **.NET Framework**

Aspose.Slides erfordert Vollvertrauen im .NET Framework. Es läuft nicht unter Teilvertrauen, wie z. B. einer ASP.NET‑Anwendung, die für Medium Trust (`<trust level="Medium" />`) konfiguriert ist: Das Erstellen eines [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Objekts schlägt mit einer `SecurityException` fehl.

Microsoft betrachtet Teilvertrauen von ASP.NET nicht mehr als Möglichkeit, Anwendungen voneinander zu isolieren, und empfiehlt stattdessen, Anwendungen in separaten Anwendungspools auszuführen. Siehe [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 und später**

Codezugriffssicherheit ist in .NET 6 und später nicht verfügbar, daher gibt es keine Vertrauensstufe, die vergeben werden kann. Aspose.Slides läuft mit den Berechtigungen des Kontos, das Ihre Anwendung ausführt. Um zu beschränken, worauf eine Anwendung zugreifen kann, empfiehlt Microsoft Betriebssystem‑Grenzen wie Benutzerkonten, Container oder virtuelle Maschinen. Siehe [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Kann ich Aspose.Slides bei einem Hosting‑Provider verwenden, der ASP.NET‑Anwendungen im Medium Trust ausführt?**

Nicht im Medium Trust. Im .NET Framework muss die Anwendung, die Aspose.Slides verwendet, mit Vollvertrauen ausgeführt werden.