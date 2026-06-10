---
title: .NET 6 támogatás
type: docs
weight: 235
url: /hu/net/net6/
keywords: 
- .NET 6 támogatás
- Felhőmegoldás
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Konfigurálja az Aspose.Slides for .NET 6-ot PowerPoint PPT, PPTX és ODP prezentációk létrehozásához, szerkesztéséhez és konvertálásához modern, többplatformos C# alkalmazásokban."
---
## **Bevezetés**

A [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) verziótól kezdve a .NET6 támogatása került bevezetésre. Ennek a támogatásnak a sajátossága, hogy a .NET6 már nem támogatja a System.Drawing.Common csomagot Linuxon ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), és a Slides saját maga valósítja meg ezt a grafikus alrendszert C++ komponensként.

Az Aspose.Slides for .NET most már GDI/libgdiplus függőségek nélkül működik:
* Windows
* Linux

_MacOS_ támogatás folyamatban.

## **A Slides for .NET 6 használata AWS-en és Azure-on**

A .NET6 a preferált verzió az Aspose.Slides felhőben (AWS, Azure vagy más felhőmegoldások) történő használatához.

Korábban, amikor az Aspose.Slides-t Linux hoston használták, további függőségeket (libgdiplus) kellett telepíteni, ami gyakran kényelmetlen vagy nem praktikus volt (például az [AWS Lambda](https://aws.amazon.com/lambda) használatakor). A Slides for .NET6 esetében ezek a függőségek már nem szükségesek, így a telepítés sokkal egyszerűbb.

Egy másik szempont a problémák, amelyek akkor jelentkeztek, amikor az Aspose.Slides-t egy Windows hosttal rendelkező felhőmegoldásban használták. Például az [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) korlátozásokkal rendelkeznek a folyamatra, ami PDF exportálás közben hibákat okoz (lásd [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Az Aspose.Slides for .NET6 használata megoldja ezt a problémát.

## **A System.Drawing.Common csomag és a Slides for .NET 6 osztályok használata (CS0433: A típus mind a Slides, mind a System.Drawing.Common névtérben létezik hiba)**

Néha egy projektben egyszerre kell használni a System.Drawing és a Slides for .NET6 függőségeket (például amikor a .NET6 projekt más csomagokra támaszkodik, amelyek viszont a System.Drawing-et igénylik). Ez az alábbi hibákhoz vezethet:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

Ebben az esetben használhatja az [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) kulcsot az Aspose.Slides (24.8-nál kisebb verzió) számára:
1) Válassza ki az Aspose.Slides összeállítást a projekt függőségei közül, majd kattintson a **Properties** gombra.  
   ![Aspose Slides package properties](package_properties.png)
2) Állítson be egy álnevet (például „Slides”).  
   ![Aspose Slides alias](set_alias.png)

Most alapértelmezés szerint a System.Drawing.Common típusai lesznek használva. Az Aspose.Slides típusokhoz szükséges külső összeállító álnevet a megfelelő helyen kell megadni.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Teljes példa:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

A 24.8-as verziótól kezdve a System.Drawing-re támaszkodó elavult nyilvános API eltávolításra került. A fenti kódrészlet kapcsán a dia képét az alábbi módon nyerhetjük ki.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
Az új API részletesebb leírása a [Modern API](/slides/hu/net/modern-api/) oldalon található.