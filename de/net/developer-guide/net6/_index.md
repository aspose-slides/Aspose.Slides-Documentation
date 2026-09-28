---
title: "Plattformübergreifendes Paket für .NET 6 und höher"
linktitle: "Plattformübergreifendes Paket"
type: docs
weight: 235
url: /de/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- plattformübergreifend
- .NET 6 Unterstützung
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wann Sie das Aspose.Slides.NET6.CrossPlatform‑Paket verwenden sollten: warum es existiert, auf welchen Plattformen es läuft und was es unter Linux anstelle von libgdiplus benötigt."
---
## **Einleitung**

Aspose.Slides für .NET wird als zwei NuGet‑Pakete veröffentlicht. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) rendert Folien über die Microsoft‑Bibliothek System.Drawing.Common. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) rendert sie stattdessen mit einer eigenen Grafik‑Engine. Dieser Artikel erklärt, warum das zweite Paket existiert, wo es läuft, was es unter Linux benötigt und wie es zusammen mit System.Drawing.Common in einem Projekt koexistiert.

## **Warum ein separates Paket**

Ab .NET 6 unterstützt Microsoft System.Drawing.Common **nur unter Windows**(https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Das hat zur Folge, dass Aspose.Slides.NET unter Linux den Schalter `System.Drawing.EnableUnixSupport` zusätzlich zur Bibliothek `libgdiplus` benötigt und dort fehlschlägt, wenn das Projekt System.Drawing.Common 7 oder höher referenziert. [System Requirements](/slides/de/net/system-requirements/) beschreibt diese Bedingungen.

Aspose.Slides.NET6.CrossPlatform verwendet weder System.Drawing.Common noch `libgdiplus`. Seine Grafik‑Engine ist eine native Bibliothek, die das Paket in einem Build pro unterstützter Plattform enthält. Beide Pakete stellen dieselben Aspose.Slides‑Namespaces und -Klassen bereit, sodass ein Wechsel nur die Paket‑Referenz ändert, nicht Ihren Code.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafik | System.Drawing.Common | Native Grafik‑Engine, die im Paket enthalten ist |
| Ziel‑Frameworks | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux‑Voraussetzungen | `libgdiplus` und der Schalter `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Unterstützt | Nicht unterstützt |

## **Unterstützte Plattformen**

Aspose.Slides.NET6.CrossPlatform funktioniert mit .NET 6 und neueren Versionen auf folgenden Plattformen:

- **Windows**: x86 und x64. Die native Bibliothek nutzt die Microsoft Visual C++‑Runtime; siehe [System Requirements](/slides/de/net/system-requirements/).
- **Linux**: x64 mit glibc 2.23 oder neuer und ARM64 mit glibc 2.39 oder neuer.
- **macOS**: x64 (Intel) und ARM64 (Apple‑Silicon).

Es läuft nicht unter Windows auf ARM64, nicht unter Alpine Linux oder anderen Distributionen, die auf musl statt glibc basieren, und nicht unter Distributionen mit einer älteren glibc, etwa CentOS 7. Verwenden Sie in diesen Fällen Aspose.Slides.NET.

## **Installation unter Linux**

Unter Linux benötigt das Paket die Bibliothek `fontconfig`, jedoch nicht `libgdiplus`. Auf Debian und Ubuntu installieren Sie `fontconfig` und fügen dann das Paket zu Ihrem Projekt hinzu:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Unter Debian und Ubuntu installiert `libfontconfig1` zudem die DejaVu‑Schriften, sodass Texte ohne weitere Schriftpakete gerendert werden. Ohne `fontconfig` schlägt das Erstellen einer [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) mit einer `TypeInitializationException` fehl, deren innere `DllNotFoundException` meldet, dass `libfontconfig.so.1` nicht geöffnet werden kann. [System Requirements](/slides/de/net/system-requirements/) enthält ein kurzes Programm, das die Einrichtung prüft.

## **Cloud‑ und Container‑Hosts**

Da `libgdiplus` nicht benötigt wird, ist Aspose.Slides.NET6.CrossPlatform das zu verwendende Paket auf Linux‑Hosts, bei denen Sie `libgdiplus` nicht installieren können. Es benötigt jedoch weiterhin `fontconfig` und Schriftarten, die in minimalen Base‑Images eventuell fehlen. Das AWS Lambda‑Base‑Image für .NET 8 enthält beispielsweise beides nicht. In einem darauf aufbauenden Container‑Image führen Sie `dnf install -y fontconfig` aus, wodurch auch die Noto‑Sans‑Schriften installiert werden.

Für Anleitungen zu konkreten Cloud‑Plattformen siehe [Aspose.Slides on Cloud Platforms](/slides/de/net/slides-on-cloud-platforms/).

## **System.Drawing.Common im selben Projekt verwenden (CS0433)**

Ein Projekt, das Aspose.Slides.NET6.CrossPlatform verwendet, kann gleichzeitig System.Drawing.Common referenzieren, direkt oder über ein anderes Paket. Die aktuelle Version von Aspose.Slides enthält keine öffentlichen Typen in `System`‑Namespaces, sodass die beiden Bibliotheken nicht in Konflikt geraten und Sie die Namespaces `Aspose.Slides` und `System.Drawing` in derselben Datei importieren können.

Meldet der Compiler den Fehler CS0433, weil ein Typ wie `Image` oder `Graphics` sowohl in Aspose.Slides als auch in System.Drawing.Common existiert, verwendet Ihr Projekt eine ältere Version von Aspose.Slides. Aktualisieren Sie das Paket auf die neueste Version. Aspose.Slides liefert gerenderte Bilder als [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)-Objekte zurück, die in [Modern API](/slides/de/net/modern-api/) beschrieben sind.

## **FAQ**

**Muss ich meinen Code ändern, wenn ich von Aspose.Slides.NET zu Aspose.Slides.NET6.CrossPlatform wechsle?**

Nein. Beide Pakete stellen dieselben Aspose.Slides‑Namespaces und -Klassen bereit, sodass Sie nur die Paket‑Referenz austauschen. Aspose.Slides.NET6.CrossPlatform benötigt den Schalter `System.Drawing.EnableUnixSupport` nicht. Fügen Sie nur eines der beiden Pakete zu einem Projekt hinzu.

**Kann ich Aspose.Slides.NET6.CrossPlatform in einem .NET‑Framework‑Projekt verwenden?**

Nein. Das Paket richtet sich ausschließlich an .NET 6 und neuere Versionen. Für .NET Framework 4.6.2 und höher verwenden Sie Aspose.Slides.NET.