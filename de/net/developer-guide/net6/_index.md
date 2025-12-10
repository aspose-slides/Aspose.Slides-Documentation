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
description: "Konfigurieren Sie Aspose.Slides für .NET 6, um PowerPoint-Präsentationen im Format PPT, PPTX und ODP in modernen, plattformübergreifenden C#-Anwendungen zu erstellen, zu bearbeiten und zu konvertieren."
---

## **Einleitung**

Ab [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) wurde die Unterstützung für .NET6 implementiert. Das Besondere an dieser Unterstützung ist, dass .NET6 System.Drawing.Common für Linux nicht mehr unterstützt ([Breaking Change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) und Slides dieses grafische Subsystem selbst als C++‑Komponente bereitstellt.

Aspose.Slides für .NET funktioniert nun ohne Abhängigkeiten von GDI/libgdiplus unter:
* Windows
* Linux

_MacOS_-Unterstützung ist in Arbeit.

## **Verwendung von Slides für .NET 6 auf AWS und Azure**

.NET6 ist die bevorzugte Version für Aspose.Slides in der Cloud (AWS, Azure oder andere Cloud‑Lösungen).

Früher mussten bei Verwendung von Aspose.Slides auf einem Linux‑Host zusätzliche Abhängigkeiten (libgdiplus) installiert werden, was oft umständlich oder unpraktisch war (z. B. bei der Nutzung von [AWS Lambda](https://aws.amazon.com/lambda)). Mit Slides für .NET6 entfallen diese Abhängigkeiten, sodass die Bereitstellung wesentlich einfacher ist.

Ein weiterer Aspekt sind Probleme, die beim Einsatz von Aspose.Slides auf einer Cloud‑Lösung mit Windows‑Host auftreten können. Beispielsweise haben [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) Einschränkungen für den Prozess, die zu Problemen bei einem PDF‑Export führen (siehe [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Die Verwendung von Aspose.Slides für .NET6 löst dieses Problem.

## **Verwendung des System.Drawing.Common‑Pakets und Slides für .NET 6‑Klassen (CS0433: Der Typ ist sowohl in Slides als auch in System.Drawing.Common vorhanden)**

Manchmal müssen sowohl System.Drawing als auch Slides für .NET6‑Abhängigkeiten in einem Projekt verwendet werden (z. B. wenn das .NET6‑Projekt von anderen Paketen abhängt, die wiederum System.Drawing benötigen). Dies kann zu Kompilierungsfehlern führen, wie z. B.:

* CS0433: Der Typ 'Image' ist sowohl in 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' als auch in 'System.Drawing.Common, Version=6.0.0.0' vorhanden
* CS0433: Der Typ 'Graphics' ist sowohl in 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' als auch in 'System.Drawing.Common, Version=6.0.0.0' vorhanden

In diesem Fall können Sie für Aspose.Slides (Version < 24.8) [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) verwenden:
1) Wählen Sie die Aspose.Slides‑Assembly aus den Projekt‑Abhängigkeiten und klicken Sie dann auf **Properties**.  
   ![Aspose Slides-Paket-Eigenschaften](package_properties.png)
2) Legen Sie ein Alias fest (z. B. „Slides“).  
   ![Aspose Slides-Alias](set_alias.png)

Jetzt werden die Typen aus System.Drawing.Common standardmäßig verwendet. Das externe Assembly‑Alias muss dort angegeben werden, wo Aspose.Slides‑Typen benötigt werden.
```c#
extern alias Slides;
using Slides::Aspify.Slides;
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


Ab Version 24.8 wurde die veraltete öffentliche API mit Abhängigkeiten von System.Drawing entfernt. Im Hinblick auf das obige Code‑Beispiel können Sie das Folien‑Bild wie folgt erhalten.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

Die neue API wird im Detail in [Modern API](/net/modern-api/) beschrieben.