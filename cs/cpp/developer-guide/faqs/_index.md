---
title: "Často kladené otázky"
type: docs
weight: 340
url: /cs/cpp/faqs/
keywords:
- "Často kladené otázky"
- "formát prezentace"
- "chyba nedostatku paměti"
- "velikost snímku"
- "extrahovat text"
- "získat text"
- "velikost odstavce"
- "formátování tabulek"
- "písmo"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "C++"
- "Aspose.Slides"
description: "Získáte odpovědi na často kladené otázky o Aspose.Slides pro C++, které zahrnují podporu PowerPoint a OpenDocument, pokyny k instalaci, licencování a řešení problémů."
---
## **Přehled**

Tento FAQ poskytuje odpovědi na časté otázky týkající se Aspose.Slides. Pokrývá podporované formáty souborů, zpracování výjimek při práci s velkými prezentacemi, změnu velikosti snímků, náhled snímků, získávání textu z prezentací, formátování ohraničení tabulek, umisťování obrázků a řešení problémů s fonty při převodu prezentací do PDF nebo obrázků.

## **Podporované formáty souborů**

**Q: Jaké formáty souborů podporuje Aspose.Slides pro C++?**

**A**: Aspose.Slides pro C++ podporuje formáty souborů popsané v [Supported File Formats](/slides/cs/cpp/supported-file-formats/).

## **Výjimky**

**Q: Při načítání velkého souboru PPT s obrázky dostávám výjimku `out of memory`. Existuje omezení velikosti souboru v Aspose.Slides?**

**A**: Neexistuje konkrétní vzorec pro výpočet velikosti prezentace podporované Aspose.Slides. Musí být k dispozici dostatek paměti pro uložení celé struktury prezentace a obrázků v paměti. Obvykle obrázky v paměti zabírají více místa než na pevném disku, zejména pokud mají dodatečné efekty.

Obecně Aspose.Slides pro C++ snadno zvládne soubory prezentací o velikosti okolo 300 MB na serveru s 4 GB RAM.

## **Práce se snímky**

**Q: Mohu v prezentaci změnit velikost snímků?**

**A**: K definování velikosti snímků v prezentaci můžete použít metodu `get_SlideSize` exposovanou třídou [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).

**Q: Existuje způsob, jak mít v jedné prezentaci snímky různých velikostí?**

**A**: Velikost snímků je v dokumentech Microsoft PowerPoint definována na úrovni celé prezentace, takže to není možné.

**Q: Podporuje Aspose.Slides pro C++ náhled snímku před uložením?**

**A**: Prezentaci můžete vykreslit do obrázků a tyto obrázky použít pro náhled snímků.

## **Práce s textem**

**Q: Je možné získat veškerý text z prezentace?**

**A**: Aspose.Slides pro C++ poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/) v namespace `Aspose::Slides::Util`, která obsahuje různé metody pro získání kompletního textu z prezentací.

**Q: Proč se velikosti odstavců liší ve Windows a Linuxu?**

**A**: Výpočet velikosti odstavců vychází z výpočtu velikosti textu představujícího daný odstavec. Velikost textu je založena na metrice písma uvedeného v PowerPoint prezentaci. Pokud požadované písmo chybí, je nahrazeno nejpodobnějším písmem, jehož metrika se liší od původní. Výsledkem je, že výpočet velikostí odstavců na různých systémech vede k odlišným výsledkům v závislosti na sady nainstalovaných písem. Pro dosažení stejných výsledků na různých operačních systémech musíte nainstalovat stejná písma nebo je načíst za běhu jako [external fonts](/slides/cs/cpp/custom-font/).

## **Formátování a obrázky**

**Q: Jak mohu nastavit barvu ohraničení tabulky?**

**A**: Barvu můžete změnit u všech ohraničení tabulky nebo jen u ohraničení celého tabulky. Pro změnu všech ohraničení použijte metodu `get_CellFormat` z rozhraní [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/). Pro ohraničení celého tabulky iterujte přes buňky a změňte barvu vnějších okrajů.

**Q: Jakou jednotku používá Aspose.Slides pro C++ při umisťování obrázků?**

**A**: Souřadnice a velikosti všech tvarů na snímcích jsou měřeny v bodech (72 dpi).

## **Práce s písmy**

**Q: Při převodu PPT do PDF nebo obrázků se v výstupních dokumentech liší písma, proč?**

**A**: Tento problém může naznačovat, že písma použitá v prezentaci chybí v operačním systému, na kterém byl kód spuštěn. Písma byste měli nainstalovat do operačního systému nebo je načíst jako externí písma pomocí třídy [FontsLoader](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/) podle níže uvedeného příkladu:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```