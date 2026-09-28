---
title: Bizalmi szint követelmények
type: docs
weight: 190
url: /hu/net/declaration/
keywords:
- bizalmi szint
- Teljes megbízhatási engedély
- részleges megbízhatás
- Közepes megbízhatás
- kódfoglaló biztonság
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Milyen kódfoglaló biztonsági bizalmi szintet igényel az Aspose.Slides for .NET: teljes megbízhatást a .NET Framework alatt, és nincs beállított bizalmi szint a .NET 6 és újabb verzióknál."
---
## **Áttekintés**

A kódfoglaló biztonság (CAS) bizalmi szintek csak a .NET Framework-ben léteznek. Ez a cikk elmagyarázza, mit jelentenek az Aspose.Slides for .NET esetében: a könyvtárnak teljes megbízhatással kell rendelkeznie a .NET Framework alatt, míg a .NET 6 és újabb verziókban nincs beállítható bizalmi szint.

## **.NET Framework**

Az Aspose.Slides teljes megbízhatást igényel a .NET Framework alatt. Nem fut részleges megbízhatással, például egy Medium Trust‑re (`<trust level="Medium" />`) konfigurált ASP.NET alkalmazásban: egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) objektum létrehozása `SecurityException` hibát eredményez.

A Microsoft már nem tekinti az ASP.NET részleges megbízhatást az alkalmazások egymástól való elszigetelésének módjának, és helyette azt javasolja, hogy az alkalmazásokat külön alkalmazáskészletekben futtassuk. Lásd [Az ASP.NET részleges megbízhatása nem garantálja az alkalmazások elszigetelését](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

A kódfoglaló biztonság nem érhető el a .NET 6 és újabb verziókban, így nincs megadandó bizalmi szint. Az Aspose.Slides a felhasználói fiók jogosultságaival fut, amely a programot üzemelteti. Az alkalmazás hozzáférhetőségének korlátozása érdekében a Microsoft operációs rendszer szintű határokat javasol, például felhasználói fiókokat, konténereket vagy virtuális gépeket. Lásd [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Használhatom az Aspose.Slides‑t olyan tárhelyszolgáltatónál, amely ASP.NET alkalmazásokat Medium Trust‑ben futtat?**

Nem Medium Trust‑ben. .NET Framework esetén az Aspose.Slides‑t használó alkalmazásnak teljes megbízhatással kell futnia.