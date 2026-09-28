---
title: Sicherheit
type: docs
weight: 160
url: /de/net/security/
keywords:
- Sicherheit
- Abhängigkeiten
- Drittanbieter‑Komponenten
- NuGet
- Schwachstellen‑Scanning
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie, wie Aspose.Slides für .NET Präsentationen verarbeitet, von welchen NuGet‑Paketen es für jedes Ziel‑Framework abhängt und welche Komponenten von Drittanbietern es enthält."
---
## **Sicherheit in Aspose.Slides**

Aspose wendet bewährte Verfahren bei der Entwicklung seiner Produkte an.

* Aspose.Slides für .NET wird verwendet, um Präsentationen zu bearbeiten und in andere Formate zu konvertieren. Es führt keine Skripts in Präsentationen aus. Aspose.Slides analysiert die Struktur der Präsentation und ermöglicht es dem Code des Endbenutzers, das Objektmodell auf bequeme Weise zu manipulieren.
* Aspose.Slides fungiert als Bibliothek, die Dokumente analysiert und interpretiert, ohne entfernten Code auszuführen. Alle Aspose‑Produkte laufen auf Ihren Rechnern. Sie übertragen keine Daten an Aspose. Die einzige Ausnahme ist eine [metered license](https://purchase.aspose.com/faqs/licensing/metered): Wenn Sie eine verwenden, werden nur Ihre API‑Nutzungsinformationen verarbeitet.
* Aspose‑Komponenten laufen im selben Benutzerkontext wie reguläre Anwendungen. Daher stellen Aspose‑Komponenten kein Risiko für kritische Systemressourcen dar. Außerdem werden beim Öffnen eines Dokuments durch eine Aspose‑Komponente Makros nicht automatisch ausgeführt.
* Die mit dem Microsoft‑Office‑Paket verbundenen Risiken gelten nicht für Aspose‑Komponenten, sodass Aspose‑Produkte sehr sicher sind.

## **NuGet‑Abhängigkeiten**

Aspose.Slides für .NET hängt von Paketen ab, die Microsoft auf NuGet veröffentlicht. Die Abhängigkeiten unterscheiden sich je nach Paket und Ziel‑Framework:

| Paket | Ziel‑Framework | Abhängigkeiten |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

Der Abschnitt **Dependencies** der [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) und [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) Seiten auf NuGet listet die minimale Version jeder Abhängigkeit für jede Veröffentlichung auf.

Wenn Sie Aspose.Slides zu einem Projekt hinzufügen, stellt NuGet auch die Abhängigkeiten dieser Pakete wieder her. Um jedes Paket aufzulisten, das Ihr Projekt wiederherstellt, einschließlich dieser transitiven Abhängigkeiten, führen Sie diesen Befehl im Projektordner aus:

```bash
dotnet list package --include-transitive
```

Um den gleichen Satz von Paketen auf bekannte Schwachstellen zu prüfen, führen Sie aus:

```bash
dotnet list package --vulnerable --include-transitive
```

Für weitere Möglichkeiten, NuGet‑Pakete zu prüfen, siehe [Überprüfung von Paketabhängigkeiten auf Sicherheitslücken](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Drittanbieter‑Komponenten**

Aspose.Slides enthält Code von Open‑Source‑Komponenten von Drittanbietern. Sie sind Teil des Produkts, nicht separate NuGet‑Pakete, sodass Werkzeuge, die nur NuGet‑Abhängigkeiten auslesen, sie nicht auflisten. Beide Pakete enthalten die Datei *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, die die Komponenten und deren Lizenzen auflistet:

| Komponente | Lizenz laut Hinweis |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**Welche Systeme werden verwendet, um Schwachstellen im Aspose‑Code zu überwachen?**

Wir führen für jede Aspose.Slides‑Veröffentlichung eine statische Code‑Analyse durch. Wir können Sicherheitsberichte bereitstellen, die belegen, dass der Aspose.Slides‑Code die OWASP Top 10 besteht.

**Verwendet Aspose.Slides externe Pakete?**

Ja. Es hängt von den Microsoft‑NuGet‑Paketen ab, die in [NuGet‑Abhängigkeiten](#nuget-dependencies) aufgeführt sind, und es enthält die in [Drittanbieter‑Komponenten](#third-party-components) aufgeführten Komponenten. Berücksichtigen Sie beide in Ihrer Sicherheitsüberprüfung und verwenden Sie `dotnet list package --vulnerable --include-transitive`, um die NuGet‑Pakete zu prüfen, die Ihr Projekt wiederherstellt.