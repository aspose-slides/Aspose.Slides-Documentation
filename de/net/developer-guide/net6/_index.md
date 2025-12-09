---
title: .NET 6 Unterstützung
type: docs
weight: 235
url: /de/net/net6/
keywords:
- .NET 6 Unterstützung
- Cloud-Lösung
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Konfigurieren Sie Aspose.Slides für .NET 6, um PowerPoint‑Präsentationen im PPT-, PPTX- und ODP-Format in modernen, plattformübergreifenden C#‑Anwendungen zu erstellen, zu bearbeiten und zu konvertieren."
---

## Einführung

Ab [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) wurde die Unterstützung für .NET6 implementiert. Das Besondere an dieser Unterstützung ist, dass .NET6 System.Drawing.Common für Linux nicht mehr unterstützt ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) und Slides dieses Grafik‑Subsystem selbst als C++‑Komponente implementiert.

Aspose.Slides für .NET arbeitet jetzt ohne Abhängigkeiten von GDI/libgdiplus auf:
* Windows
* Linux

_MacOS_-Unterstützung ist in Arbeit.

## Verwendung von Slides für .NET6 auf AWS und Azure

.NET6 ist die empfohlene Version für Aspose.Slides, die in der Cloud (AWS, Azure oder anderen Cloud‑Lösungen) verwendet wird.

Früher mussten beim Einsatz von Aspose.Slides auf einem Linux‑Host zusätzliche Abhängigkeiten (libgdiplus) installiert werden, was häufig umständlich oder unpraktisch war (zum Beispiel beim Einsatz von [AWS Lambda](https://aws.amazon.com/lambda)). Mit Slides für .NET6 sind diese Abhängigkeiten nicht mehr erforderlich, sodass die Bereitstellung wesentlich einfacher ist.

Ein weiterer Aspekt sind Probleme, die beim Einsatz von Aspose.Slides in einer Cloud‑Lösung mit Windows‑Host auftraten. Zum Beispiel haben [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) Einschränkungen für den Prozess, was zu Problemen beim PDF‑Export führt (siehe [dies](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Der Einsatz von Aspose.Slides für .NET6 löst dieses Problem.

## Verwendung des System.Drawing.Common-Pakets und Slides‑Klassen für .NET6 (CS0433: Der Typ existiert sowohl in Slides als auch in System.Drawing.Common‑Fehler)

Manchmal müssen sowohl System.Drawing‑ als auch Slides‑Abhängigkeiten für .NET6 in einem Projekt verwendet werden (zum Beispiel, wenn das .NET6‑Projekt von anderen Paketen abhängt, die wiederum System.Drawing benötigen). Das kann zu Komplikationsfehlern wie diesen führen:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

In diesem Fall können Sie [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) für Aspose.Slides (Version kleiner als 24.8) verwenden:
1) Wählen Sie die Aspose.Slides‑Assembly aus den Projekt‑Abhängigkeiten aus und klicken Sie dann auf **Properties**.
  ![Aspose Slides Paket‑Eigenschaften](package_properties.png)
2) Legen Sie einen Alias fest (z. B. "Slides").
  ![Aspose Slides Alias](set_alias.png)

Jetzt werden die Typen aus System.Drawing.Common standardmäßig verwendet. Der externe Assembly‑Alias sollte dort angegeben werden, wo Aspose.Slides‑Typen benötigt werden.
```c#
extern alias Slides;
using Slides::Asprose.Slides;
```


Vollständiges Beispiel:
```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```


Ab Version 24.8 wurde die veraltete öffentliche API mit Abhängigkeiten von System.Drawing entfernt. In Bezug auf das obige Code‑Beispiel können Sie das Folien‑Bild wie folgt erhalten.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

Die neue API wird ausführlicher in [Modern API](/net/modern-api/) beschrieben.