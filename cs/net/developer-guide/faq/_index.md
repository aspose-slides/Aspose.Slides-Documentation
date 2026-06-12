---
title: Často kladené dotazy
type: docs
weight: 340
url: /cs/net/faqs/
keywords:
- FAQ
- PowerPoint
- formát prezentace
- chyba nedostatku paměti
- velikost snímku
- extrahovat text
- získat text
- velikost odstavce
- formátování tabulek
- font
- .NET
- C#
- Aspose.Slides
description: "Získejte odpovědi na FAQ o Aspose.Slides pro .NET, zahrnující podporu PowerPoint a OpenDocument, pokyny k instalaci, licencování a řešení problémů."
---
## **Přehled**

Tento FAQ poskytuje odpovědi na běžné otázky o Aspose.Slides. Pokrývá podporované formáty souborů, zacházení s výjimkami při práci s velkými prezentacemi, změnu velikosti snímků, náhled snímků, získávání textu z prezentací, formátování ohraničení tabulek, umisťování obrázků a řešení problémů s fonty při převodu prezentací do PDF nebo obrázků.

## **Podporované formáty souborů**

**Q: Jaké formáty souborů podporuje Aspose.Slides pro .NET?**

**A**: Aspose.Slides pro .NET podporuje formáty souborů popsané v [Supported File Formats](/slides/cs/net/supported-file-formats/).

## **Výjimky**

**Q: Při načítání velkého PPT souboru s obrázky dostávám OutOfMemoryException. Existuje omezení velikosti souboru v Aspose.Slides?**

**A**: Neexistuje žádný specifický vzorec pro výpočet velikosti prezentace podporované Aspose.Slides. Musí být dostatek paměti k uložení celé struktury prezentace a obrázků v paměti. Normálně obrázky v paměti zabírají více místa než na pevném disku, zejména pokud mají další efekty.

Obecně Aspose.Slides pro .NET dokáže snadno zpracovat soubory prezentací o velikosti přibližně 300 MB na serveru s 4 GB RAM.

## **Práce se snímky**

**Q: Mohu změnit velikost snímků v prezentaci?**

**A**: Můžete použít vlastnost `SlideSize` vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) k definování velikosti snímků v prezentaci.

**Q: Existuje způsob, jak definovat snímky různých velikostí v jedné prezentaci?**

**A**: Protože velikost snímků je definována na úrovni celé prezentace v dokumentech Microsoft PowerPoint, není to možné.

**Q: Podporuje Aspose.Slides pro .NET náhled snímku před uložením?**

**A**: Můžete vykreslit snímky prezentace do obrázků a použít tyto obrázky k náhledu snímků.

## **Práce s textem**

**Q: Je možné získat celý text z prezentace?**

**A**: Aspose.Slides pro .NET poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/) v názvovém prostoru `Aspose.Slides.Util`, která nabízí různé metody pro získání veškerého textu z prezentací.

**Q: Proč jsou velikosti odstavců odlišné ve Windows a Linux?**

**A**: Výpočet velikosti odstavců je založen na výpočtu velikosti textu představujícího daný odstavec. Velikost textu se počítá podle metrik fontu specifikovaného v PowerPoint prezentaci. Pokud je požadovaný font chybějící, je nahrazen nejpodobnějším fontem, jehož metriky se liší od původních. Výsledkem je, že výpočet velikosti odstavců v různých systémech vede k odlišným výsledkům v závislosti na sadě nainstalovaných fontů. Pro dosažení stejných výsledků na různých operačních systémech je třeba nainstalovat stejné fonty na všechny systémy nebo je načíst za běhu jako [external fonts](/slides/cs/net/custom-font/).

## **Formátování a obrázky**

**Q: Jak mohu nastavit barvu ohraničení tabulky?**

**A**: Můžete změnit barvu všech ohraničení tabulky nebo jen ohraničení kolem celé tabulky. Pro změnu všech ohraničení použijte vlastnost `CellFormat` z rozhraní [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/). Pro ohraničení celé tabulky byste měli projít buňky a změnit barvu vnějších ohraničení.

**Q: Jakou jednotku používá Aspose.Slides pro .NET při umisťování obrázků?**

**A**: Souřadnice a velikosti všech tvarů na snímcích jsou měřeny v bodech (72 dpi).

## **Práce s fonty**

**Q: Proč jsou po převodu PPT do PDF nebo obrázků fonty v výstupních dokumentech odlišné?**

**A**: Tento problém může naznačovat, že fonty použité v prezentaci chybí v operačním systému, na kterém byl kód spuštěn. Měli byste fonty nainstalovat v operačním systému nebo je načíst jako externí fonty pomocí třídy [FontsLoader](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/) podle níže uvedeného příkladu:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```