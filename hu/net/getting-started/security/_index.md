---
title: Biztonság
type: docs
weight: 160
url: /hu/net/security/
keywords:
- biztonság
- függőségek
- harmadik féltől származó komponensek
- NuGet
- sebezhetőség-ellenőrzés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Nézze meg, hogyan dolgozza fel az Aspose.Slides for .NET a prezentációkat, mely NuGet csomagoktól függ minden célkeretrendszer esetén, és mely harmadik féltől származó komponenseket tartalmaz."
---
## **Biztonság az Aspose.Slides-ben**

Aspose a legjobb gyakorlatokat alkalmazza termékei fejlesztése során.

* Az Aspose.Slides for .NET-et prezentációk manipulálására és más formátumokra történő konvertálására használják. Nem futtat szkripteket a prezentációkban. Az Aspose.Slides feldolgozza a prezentáció szerkezetét, és lehetővé teszi a végfelhasználó kódja számára, hogy kényelmes módon manipulálja az objektummodellt.
* Az Aspose.Slides könyvtárként működik, amely dokumentumokat elemez és értelmez anélkül, hogy távoli kódot hajtana végre. Minden Aspose termék az Ön gépén fut. Nem továbbítanak adatot az Aspose felé. Az egyetlen kivétel egy [méteres licenc](https://purchase.aspose.com/faqs/licensing/metered): ha ilyet használ, csak az API használati adatait dolgozzák fel.
* Az Aspose komponensek ugyanabban a felhasználói környezetben futnak, mint a szokásos alkalmazások. Ennek következtében az Aspose komponensek nem jelentenek kockázatot a létfontosságú rendszererőforrásokra. Továbbá, amikor egy Aspose komponens dokumentumot nyit meg, a makrók nem indulnak el automatikusan.
* A Microsoft Office csomaghoz kapcsolódó vagy abból eredő kockázatok nem vonatkoznak az Aspose komponensekre, ezért az Aspose termékek nagyon biztonságosak.

## **NuGet függőségek**

Az Aspose.Slides for .NET a Microsoft által a NuGet-en közzétett csomagoktól függ. A függőségek csomagonként és célkeretrendszerenként eltérnek:

| Csomag | Célkeretrendszer | Függőségek |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

Az [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) és az [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) NuGet-oldalainak **Dependencies** szekciója felsorolja minden kiadás esetén az egyes függőségek legkisebb verzióját.

Amikor az Aspose.Slides-et egy projekthez adja, a NuGet visszaállítja ezen csomagok függőségeit is. Ahhoz, hogy felsorolja minden csomagot, amelyet a projekt visszaállít, beleértve a transzitív függőségeket is, futtassa ezt a parancsot a projekt mappájában:

```bash
dotnet list package --include-transitive
```

Azonos csomagkészlet ismert sebezhetőségekkel szemben való ellenőrzéséhez futtassa:

```bash
dotnet list package --vulnerable --include-transitive
```

A NuGet csomagok auditálásának egyéb módjaiért lásd a [Csomagfüggőségek ellenőrzése biztonsági sebezhetőségek szempontjából](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Harmadik féltől származó komponensek**

Az Aspose.Slides harmadik féltől származó nyílt forráskódú komponensek kódját is tartalmazza. Ezek a termék részei, nem különálló NuGet csomagok, ezért csak a NuGet függőségeket olvasó eszközök nem sorolják fel őket. Mindkét csomag tartalmazza a *thirdpartylicenses.Aspose.Slides.for.NET.pdf* fájlt, amely felsorolja a komponenseket és azok licenceit:

| Komponens | Az értesítményben megadott licenc |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **GYIK**

**Milyen rendszereket használnak a sebezhetőségek monitorozására az Aspose kódban?**

Az Aspose.Slides minden kiadása esetén statikus kódelemzést végzünk. Biztonsági jelentéseket tudunk biztosítani, amelyek bizonyítják, hogy az Aspose.Slides kódja megfelel az OWASP Top 10‑nek.

**Használ-e az Aspose.Slides külső csomagokat?**

Igen. A Microsoft által a [NuGet Dependencies](#nuget-dependencies) szakaszban felsorolt NuGet csomagoktól függ, és tartalmazza a [Third-Party Components](#third-party-components) szakaszban felsorolt harmadik féltől származó komponenseket is. Mindkettőt vegye figyelembe a biztonsági felülvizsgálat során, és használja a `dotnet list package --vulnerable --include-transitive` parancsot a projekt által visszaállított NuGet csomagok ellenőrzéséhez.