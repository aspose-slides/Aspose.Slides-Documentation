---
title: Aspose.Slides für .NET 6 Cross-Platform (ZIP-Paket)
type: docs
weight: 237
url: /de/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- plattformübergreifend
- .NET 6
- GLIBC
- csproj
- Zielpfad
- abhängige Bibliothek
- Aspose.Slides.dll
- System.Drawing.Common
- Namenskonflikt
- externer Alias
- CS0433
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für .NET 6, um plattformübergreifende C#‑Anwendungen unter Windows, Linux und macOS zu erstellen, die PowerPoint‑PPT, PPTX und ODP‑Dateien erzeugen, bearbeiten und konvertieren."
---

{{% alert title="Hinweis" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform ist ebenfalls über [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) verfügbar.

{{% /alert %}}

## **Verwendung von Aspose.Slides Cross-Platform aus einem ZIP‑Paket**

1. Laden Sie das ZIP‑Paket der neuesten Aspose.Slides von der [Release Page](https://releases.aspose.com/slides/net/) herunter. 

2. Entpacken Sie die Dateien aus *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* und legen Sie sie in den Ordner, der in Ihrem Projekt für Abhängigkeiten verwendet wird.

3. Fügen Sie eine Referenz zu Aspose.Slides.dll hinzu.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   In unserem Beispiel (nachfolgend) befinden sich die Bibliotheken im Projektordner unter folgendem Pfad: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Platzieren Sie die verbleibenden Dateien (von denen Aspose.Slides abhängt) im Ausgabeverzeichnis, indem Sie dem csproj‑Projektdatei auf diese Weise Anweisungen hinzufügen:
```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```


5. Achten Sie auf `TargetPath`. 

   Standardmäßig kopiert `<CopyToOutputDirectory>` Dateien und bewahrt dabei ihren relativen Pfad, aber wir benötigen, dass die abhängigen Bibliotheken in denselben Ordner wie die erzeugte Ausgabe (Aspose.Slides.dll‑Ort) kopiert werden.

## **Hinweise**

### **Proprietäres Grafik‑Subsystem**

Aspose.Slides Cross‑Platform ist eine Sammlung von Bibliotheken:

| Aspose.Slides.dll                                          | Haupt‑.NET‑Assembly, das für die gesamte Aspose.Slides‑Logik verantwortlich ist |
| ---------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Abhängigkeit: Implementierung des Grafik‑Subsystems für Win x64                     |
| aspose.slides.drawing.capi_vc14x86.dll                     | Abhängigkeit: Implementierung des Grafik‑Subsystems für Win x64                     |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Abhängigkeit: Implementierung des Grafik‑Subsystems für Linux (x86/x64)            |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Abhängigkeit: Implementierung des Grafik‑Subsystems für macOS AMD64 (x86-64/x64)   |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Abhängigkeit: Implementierung des Grafik‑Subsystems für macOS ARM64 (AArch64)      |

Aspose.Slides.dll verwendet die Bibliothek, die das jeweils laufende System erfordert. Die Bibliotheken befinden sich in der Regel am selben Speicherort wie Aspose.Slides.dll im jeweiligen Dateisystem.

### **ZIP‑Paketstruktur**

Das ZIP‑Paket enthält die folgende Ordnerstruktur:

```
Aspose.Slides
├─── net6.0
│   ├─── crossplatform
│   └─── default
├─── net20
├─── net462
└─── netstandard2.0
```

* Jeder Ordner enthält Assemblies für die jeweilige .NET‑Version. Für net6.0 gibt es zwei Varianten: default und crossplatform. Letztere enthält das plattformübergreifende Aspose.Slides.dll sowie alle zugehörigen Abhängigkeiten. Der entpackte Inhalt dieses Ordners kann als zusätzliche Abhängigkeit in einem Projekt für plattformübergreifende Entwicklung und andere Aspose.Slides‑Anwendungsfälle verwendet werden.

## **Siehe auch**

- [System Requirements](/slides/de/net/system-requirements/)