---
title: .NET6 Unterstützung
type: docs
weight: 235
url: /de/net/net6/
keywords: 
- .NET 6
- Cloud
- AWS
- Azure
description: ".NET6 Unterstützung"
---

## Einführung

Ab [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) wurde die Unterstützung für .NET6 implementiert. Die Besonderheit dieser Unterstützung ist, dass .NET6 System.Drawing.Common für Linux nicht mehr unterstützt ([Breaking Change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) und Slides dieses grafische Subsystem selbst als C++-Komponente implementiert.

Aspose.Slides für .NET funktioniert jetzt ohne Abhängigkeiten von GDI/libgdiplus auf:
* Windows
* Linux

_Die Unterstützung für MacOS_ ist in Arbeit.

## Verwendung von Slides für .NET6 auf AWS und Azure

.NET6 ist die bevorzugte Version für Aspose.Slides, die in der Cloud (AWS, Azure oder anderen Cloud-Lösungen) verwendet wird.

Früher mussten bei der Verwendung von Aspose.Slides auf einem Linux-Host zusätzliche Abhängigkeiten (libgdiplus) installiert werden, was oft unpraktisch oder unkomfortabel war (zum Beispiel bei der Verwendung von [AWS Lambda](https://aws.amazon.com/lambda)). Mit Slides für .NET6 sind diese Abhängigkeiten nicht mehr erforderlich, sodass das Deployment viel einfacher ist.

Ein weiterer Aspekt sind Probleme, die auftraten, als Aspose.Slides in einer Cloud-Lösung mit einem Windows-Host verwendet wurde. Zum Beispiel haben [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) Einschränkungen für den Prozess, was während eines PDF-Exportvorgangs zu Problemen führt (siehe [dieses](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Die Verwendung von Aspose.Slides für .NET6 löst dieses Problem.

## Verwendung des Pakets System.Drawing.Common und der Klassen von Slides für .NET6 (CS0433: Der Typ existiert sowohl in Slides als auch in System.Drawing.Common)

Manchmal müssen sowohl Abhängigkeiten von System.Drawing als auch von Slides für .NET6 in einem Projekt verwendet werden (zum Beispiel, wenn das .NET6-Projekt von anderen Paketen abhängt, die wiederum von System.Drawing abhängen). Dies kann zu Komplikationsfehlern wie diesen führen:

* CS0433: Der Typ 'Image' existiert sowohl in 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' als auch in 'System.Drawing.Common, Version=6.0.0.0
* CS0433: Der Typ 'Graphics' existiert sowohl in 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' als auch in 'System.Drawing.Common, Version=6.0.0.0

In diesem Fall können Sie [externen Alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) für Aspose.Slides (Version kleiner als 24.8) verwenden:
1) Wählen Sie die Aspose.Slides-Assembly aus den Abhängigkeiten des Projekts aus und klicken Sie dann auf **Eigenschaften**.
  ![Aspose Slides-Paketeigenschaften](package_properties.png)
2) Legen Sie einen Alias fest (zum Beispiel "Slides").
  ![Aspose Slides-Alias](set_alias.png)

Jetzt werden die Typen von System.Drawing.Common standardmäßig verwendet. Der externe Assembly-Alias sollte dort angegeben werden, wo Typen von Aspose.Slides benötigt werden.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
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

Ab Version 24.8 wurde die veraltete öffentliche API mit Abhängigkeiten von System.Drawing entfernt. In Bezug auf das obige Codebeispiel können Sie das Folienbild wie folgt erhalten.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
Die neue API wird ausführlicher in [Moderne API](/net/modern-api/) beschrieben.