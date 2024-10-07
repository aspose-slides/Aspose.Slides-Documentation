---
title: Aspose.Slides für .NET 6 Cross Platform
type: docs
weight: 237
url: /net/slides-for-net-6-cross-platform
keywords: Aspose.Slides, .NET, Cross platform
description: Aspose.Slides für .NET 6 Cross Platform
---

1. Die plattformübergreifende Aspose.Slides für .NET6 kann für .NET 7 und zukünftige .NET-Versionen verwendet werden.

2. **Voraussetzung**: Um die plattformübergreifende Version Aspose.Slides für .NET 6 verwenden zu können, müssen Sie das Aspose.Slides-Paket von der Produkt [Release-Seite](https://releases.aspose.com/slides/net/) herunterladen. Das Aspose.Slides NuGet-Paket ist nicht geeignet, da es plattformübergreifende Unterstützung nur für das .NET Standard bietet.

3. **Anforderungen**: [Systemanforderungen](https://docs.aspose.com/slides/net/system-requirements/). Bitte beachten Sie, dass Aspose.Slides für .NET 6 und .NET 7 Linux x86_x64 mit GLIBC 2.23 und höher erfordert. **CentOS** 7 (dessen GLIBC-Version 2.14 ist) wird nicht unterstützt. Um Slides unter CentOS 7 oder anderen Systemen (wie Alpine) zu verwenden, die die Anforderungen nicht erfüllen, laden Sie bitte Aspose.Slides für .NETStandard herunter.

## **Erhalten und Verwenden von plattformübergreifendem Aspose.Slides**

1. Laden Sie das ZIP-Paket von der neuesten Aspose.Slides von der [Release-Seite](https://releases.aspose.com/slides/net/) herunter. 

2. Entpacken Sie die Dateien aus *\Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* und legen Sie diese in den Ordner, der für Abhängigkeiten in Ihrem Projekt verwendet wird.

3. Fügen Sie eine Referenz zu Aspose.Slides.dll hinzu.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   In unserem Beispiel (unten) befinden sich die Bibliotheken im Projektordner entlang dieses Pfades: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Platzieren Sie die verbleibenden Dateien (von denen Aspose.Slides abhängt) im Ausgabeverzeichnis, indem Sie Anweisungen zur csproj-Projektdatei folgendermaßen hinzufügen:
```
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

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_appleclang.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Achten Sie auf den TargetPath. 

   Standardmäßig kopiert `<CopyToOutputDirectory>` Dateien und bewahrt ihren relativen Pfad, aber wir benötigen die abhängigen Bibliotheken, die in denselben Ordner gehen, in dem die Ausgabe generiert wird (Standort von Aspose.Slides.dll).

## Hinweise

### **System.Drawing.Common-Unterstützung nur für Windows**

Ab .NET 6 ist die Unterstützung für System.Drawing.Common (das GDI+ Unterstützung bot) [nur in Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) verfügbar. Aspose.Slides für .NET hängt von GDI+ ab. Darüber hinaus enthält die öffentliche API von Aspose.Slides Typen (Bitmap, Metafile, Graphics usw.) aus dem System.Drawing.Common-Paket.

### **Proprietäres Grafik-Subsystem**

Um das Problem der brechenden Änderungen (das die plattformübergreifende Unterstützung für System.Drawing.Common aufhebt) zu lösen, verwendet Aspose.Slides - beginnend mit Version 23.6 - seine eigene Implementierung des Grafik-Subsystems.

Diese System werden unterstützt: **Windows**, **Linux** und **macOS**.

Die plattformübergreifende Aspose.Slides ist eine Sammlung von Bibliotheken:

| Aspose.Slides.dll                                          | Haupt-.NET-Assembly, die für die gesamte Aspose.Slides-Logik verantwortlich ist    |
| ---------------------------------------------------------- | ------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | Abhängigkeit: Implementierung des Grafik-Subsystems für Win x64    |
| aspose.slides.drawing.capi_vc14x86.dll                     | Abhängigkeit: Implementierung des Grafik-Subsystems für Win x64    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Abhängigkeit: Implementierung des Grafik-Subsystems für Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang.dylib             | Abhängigkeit: Implementierung des Grafik-Subsystems für macOS      |

Aspose.Slides.dll verwendet die Bibliothek, die das System, auf dem es läuft, benötigt. Die Bibliotheken befinden sich normalerweise am gleichen Ort wie Aspose.Slides.dll in jedem Dateisystem.

### **Aspose.Slides öffentliche API und Typen aus System.Drawing.Common. Lösung für das Klassenkonfliktproblem**

Die öffentliche API von Aspose.Slides verwendet Typen aus System.Drawing.Common (Bitmap, Metafile, Graphics und viele andere). Um einen reibungslosen Übergang zum neuen plattformübergreifenden Aspose.Slides-Produkt zu erleichtern und um zu vermeiden, dass viele brechende Änderungen in die öffentliche API von Slides eingeführt werden, **dupliziert** die proprietäre Implementierung des Grafik-Subsystems die Typen und Namensräume aus System.Drawing.Common.

Daher müssen Sie, wenn Sie in einer Linux-Umgebung entwickeln oder arbeiten, Aspose.Slides einfach als Abhängigkeit verwenden - und die gesamte API bleibt die gleiche.

**Möglicherweise auftretendes Problem**: Die beschriebene Einrichtung hat ihre Nachteile. Beispielsweise können Sie, wenn Sie in Windows entwickeln und Projekte haben, die das Original System.Drawing.Common verwenden, auf Konflikte mit Aspose.Slides-Typen stoßen.

**Lösung**: Sie können externen Alias verwenden, um das Problem zu lösen. Siehe [**Verwendung des System.Drawing.Common-Pakets und Slides für .NET6-Klassen (CS0433: Der Typ existiert sowohl in Slides als auch in System.Drawing.Common-Fehler)**](https://docs.aspose.com/slides/net/net6/#using-the-systemdrawingcommon-package-and-slides-for-net6-classes-cs0433-the-type-exists-in-both-slides-and-systemdrawingcommon-error).

Das Slides-Team arbeitet an Aufgaben, die zu einer vereinfachten und einheitlichen öffentlichen API führen werden.

### **NuGet- und ZIP-Pakete**

* Das NuGet-Paket Aspose.Slides für .NET unterstützt derzeit nicht die plattformübergreifende Aspose.Slides für .NET 6.

* Das NuGet-Paket Aspose.Slides für .NET unterstützt plattformübergreifend das .NET Standard, jedoch nicht .NET 6.

* Die plattformübergreifende Version von Aspose.Slides ist als ZIP-Pakete auf der [Release-Seite](https://releases.aspose.com/slides/net/) verfügbar.

* Das ZIP-Paket enthält diese Ordnerstruktur:

  ├───net2.0

  ├───net3.5

  ├───net3.5_ClientProfile

  ├───net4.0

  ├───net4.0_ClientProfile

  ├───net6.0

  │  ├───crossplatform

  │  └───win

  ├───netstandard2.0

  └───netstandard2.1

* Jeder Ordner enthält Assemblies für die entsprechende .NET-Version. Es gibt zwei Versionen für net6.0: win und crossplatform. Letzterer enthält die plattformübergreifende Aspose.Slides.dll und alle ihre Abhängigkeiten. Der entpackte Inhalt dieses Ordners kann als Abhängigkeitsaddition in einem Projekt für plattformübergreifende Entwicklung und andere Verwendung von Aspose.Slides-Instanzen verwendet werden.