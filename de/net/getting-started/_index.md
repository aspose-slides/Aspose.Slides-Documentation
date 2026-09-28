---
title: Erste Schritte
type: docs
weight: 10
url: /de/net/getting-started/
keywords:
- Erste Schritte
- Systemanforderungen
- Installation
- Erste Präsentation
- NuGet
- PPT-Verarbeitung
- PPTX-Verarbeitung
- ODP-Verarbeitung
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Der Weg von einem neuen .NET‑Projekt zu einer zuerst gespeicherten Präsentation mit Aspose.Slides: prüfen Sie die Anforderungen, installieren Sie das Paket, führen Sie ein erstes Programm aus und setzen Sie die gängigen Aufgaben fort."
---
## **Übersicht**

Bearbeiten Sie die vier nachstehenden Schritte nacheinander. Jeder Schritt benennt, was zu tun ist, und verlinkt den Artikel mit den Details. Bewertung, Lizenzierung und Support werden nach den Schritten behandelt.

## **Schritt 1: Systemanforderungen prüfen**

Aspose.Slides für .NET läuft unter Windows, Linux und macOS. [Systemanforderungen](/slides/de/net/system-requirements/) listet die unterstützten Betriebssysteme und .NET‑Versionen für jedes Paket sowie die zusätzlichen Bibliotheken, die Linux benötigt.

## **Schritt 2: Paket installieren**

Aspose.Slides für .NET wird über NuGet als zwei Pakete verteilt, die dieselben Klassen bereitstellen. Fügen Sie eines davon zu Ihrem Projekt hinzu:

- Unter Windows: `dotnet add package Aspose.Slides.NET`
- Unter Linux und macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Unter Linux installieren Sie zuerst die Bibliothek `fontconfig`.
- Unter Alpine Linux und auf Linux‑Systemen, deren glibc älter ist als 2.23 (x64) oder 2.39 (ARM64): Aspose.Slides.NET mit installierter Bibliothek `libgdiplus`.

[Installation](/slides/de/net/installation/) enthält die Linux‑Befehle, die zusätzliche Start‑Einstellung, die Aspose.Slides.NET unter Linux benötigt, und die Schritte für Visual Studio.

## **Schritt 3: Ihre erste Präsentation erstellen**

Der [quick start on the Aspose.Slides for .NET home page](/slides/de/net/#your-first-presentation) ist ein komplettes Konsolenprogramm: Es fügt einer Folie ein Textfeld hinzu und speichert die Präsentation als PPTX‑Datei. [Create Presentations](/slides/de/net/create-presentation/) erklärt dieselben Schritte detaillierter und zeigt, wie man eine vorhandene Präsentation öffnet und in ein anderes Format speichert.

## **Schritt 4: Mit gängigen Aufgaben fortfahren**

- [Präsentation öffnen](/slides/de/net/open-presentation/)
- [Präsentation speichern](/slides/de/net/save-presentation/)
- [Präsentation in PDF konvertieren](/slides/de/net/convert-powerpoint-to-pdf/)
- [Folien als Bilder rendern](/slides/de/net/convert-slide/)
- [Präsentationstext bearbeiten](/slides/de/net/manage-text/)
- [Beispiele nach Folienelement](/slides/de/net/examples/)

## **Bewerten und Lizenzieren**

Ohne Lizenz läuft Aspose.Slides im Evaluierungsmodus: Es fügt jedem gespeicherten Folienbild ein Wasserzeichen hinzu und kürzt Text, der aus Präsentationen gelesen wird.

- [Evaluate Aspose.Slides](/slides/de/net/evaluate-aspose-slides/) beschreibt die Evaluierungsbeschränkungen und wie man eine temporäre Lizenz anfordert.
- [Licensing](/slides/de/net/licensing/) zeigt, wie man eine Lizenz aus einer Datei, einem Stream oder einer eingebetteten Ressource anwendet.
- [Metered Licensing](/slides/de/net/metered-licensing/) behandelt Lizenzierung, die nach Nutzung abgerechnet wird.
- [Supported File Formats](/slides/de/net/supported-file-formats/) listet die Formate auf, die Aspose.Slides laden und speichern kann.

## **Hilfe erhalten**

[Produktunterstützung](/slides/de/net/product-support/) erklärt, wie man eine Frage im [kostenloses Support‑Forum](https://forum.aspose.com/c/slides/de/11) stellt und welche Informationen man bei der Meldung eines Problems angeben sollte.

## **FAQ**

**Muss ich Microsoft PowerPoint installiert haben?**

Nein. Aspose.Slides liest und schreibt Präsentationsdateien selbst und verwendet PowerPoint nicht, sodass es auch auf Servern und unter Linux läuft.

**Welches Paket sollte ich für eine .NET Framework‑Anwendung verwenden?**

Aspose.Slides.NET. Es enthält Builds für .NET Framework 4.6.2 und höher, .NET 6 und höher sowie .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform erfordert .NET 6 oder höher.