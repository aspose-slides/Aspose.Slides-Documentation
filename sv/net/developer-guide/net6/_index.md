---
title: .NET 6-stöd
type: docs
weight: 235
url: /sv/net/net6/
keywords:
- .NET 6-stöd
- Molnlösning
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Konfigurera Aspose.Slides för .NET 6 för att skapa, redigera och konvertera PowerPoint PPT-, PPTX- och ODP-presentationer i moderna, plattformsoberoende C#-applikationer."
---
## **Introduktion**

Från och med [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) implementerades stöd för .NET6. Särskildheten med detta stöd är att .NET6 inte längre stödjer System.Drawing.Common för Linux ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) och Slides implementerar detta grafiska undersystem själva som en C++-komponent.

Aspose.Slides för .NET fungerar nu utan beroenden på GDI/libgdiplus på:
* Windows
* Linux

_MacOS_-stödet är under utveckling.

## **Använda Slides för .NET 6 på AWS och Azure**

.NET6 är den föredragna versionen för Aspose.Slides som används i molnet (AWS, Azure eller andra molnlösningar).

Tidigare, när Aspose.Slides användes på en Linux-värd, var extra beroenden (libgdiplus) nödvändiga och detta var ofta besvärligt eller opraktiskt (till exempel när man använde [AWS Lambda](https://aws.amazon.com/lambda)). Med Slides för .NET6 behövs dessa beroenden inte längre, så distribution blir mycket enklare.

En annan aspekt är problem som uppstod när Aspose.Slides användes i en molnlösning med en Windows-värd. Till exempel har [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) begränsningar för processen och resulterar i problem under en PDF‑exportoperation (se [denna](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Användningen av Aspose.Slides för .NET6 löser detta problem.

## **Använda System.Drawing.Common‑paketet och Slides för .NET 6‑klasser (CS0433: Typen finns i både Slides och System.Drawing.Common‑fel)**

Ibland måste både System.Drawing och Slides för .NET6‑beroenden användas i ett projekt (till exempel när .NET6‑projektet beror på andra paket som i sin tur beror på System.Drawing). Detta kan leda till komplikationsfel som dessa:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

I detta fall kan du använda [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) för Aspose.Slides (version mindre än 24.8):
1) Välj Aspose.Slides‑assembly från projektets beroenden och klicka sedan på **Properties**.  
   ![Aspose Slides paketegenskaper](package_properties.png)
2) Ställ in ett alias (till exempel "Slides").  
   ![Aspose Slides alias](set_alias.png)

Nu kommer typerna från System.Drawing.Common att användas som standard. Extern assembly‑alias bör specificeras där Aspose.Slides‑typer behövs.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Fullständigt exempel:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

Från och med version 24.8 har den föråldrade offentliga API:n med beroenden på System.Drawing tagits bort. Med hänsyn till kodexemplet ovan kan du hämta bild för sliden enligt nedan.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
Den nya API:n beskrivs mer detaljerat i [Modern API](/slides/sv/net/modern-api/).