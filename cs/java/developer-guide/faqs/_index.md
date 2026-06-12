---
title: "Často kladené otázky"
type: docs
weight: 340
url: /cs/java/faqs/
keywords:
- "FAQ"
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
- "Java"
- "Aspose.Slides"
description: "Získejte odpovědi na často kladené otázky o Aspose.Slides pro Java, zahrnující podporu PowerPoint a OpenDocument, návody k instalaci, licencování a řešení problémů."
---
## **Přehled**

Tento FAQ poskytuje odpovědi na časté otázky týkající se Aspose.Slides. Pokrývá podporované formáty souborů, zpracování výjimek při práci s velkými prezentacemi, změnu velikosti snímků, náhled snímků, získávání textu z prezentací, formátování ohraničení tabulek, vkládání obrázků a řešení problémů s fonty při převodu prezentací do PDF nebo obrázků.

## **Podporované formáty souborů**

**Q: Jaké formáty souborů podporuje Aspose.Slides pro Java?**

**A**: Aspose.Slides pro Java podporuje formáty souborů popsané v [Supported File Formats](/slides/cs/java/supported-file-formats/).

## **Výjimky**

**Q: Při načítání velkého PPT souboru s obrázky dostávám výjimku nedostatku paměti. Existuje v Aspose.Slides omezení velikosti souboru?**

**A**: Neexistuje žádný konkrétní vzorec pro výpočet velikosti prezentace podporované Aspose.Slides. Musí být k dispozici dostatek místa pro uložení celé struktury prezentace a obrázků v paměti. Obvykle obrázky v paměti zabírají více místa než na pevném disku, zejména když mají obrázky další efekty.

Obecně může Aspose.Slides pro Java snadno zpracovat soubory prezentací o velikosti přibližně 300 MB na serveru s 4 GB RAM.

## **Práce se snímky**

**Q: Mohu změnit velikost snímků v prezentaci?**

**A**: Můžete použít metodu `getSlideSize`, která je součástí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), k definování velikosti snímků v prezentaci.

**Q: Existuje způsob, jak definovat snímky různých velikostí v jedné prezentaci?**

**A**: Velikost snímků je v dokumentech Microsoft PowerPoint definována na úrovni celé prezentace, takže to není možné.

**Q: Podporuje Aspose.Slides pro Java náhled snímku před uložením?**

**A**: Můžete vykreslit snímky prezentace do obrázků a použít tyto obrázky k náhledu snímků.

## **Práce s textem**

**Q: Je možné získat veškerý text z prezentace?**

**A**: Aspose.Slides pro Java poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/), která nabízí různé metody pro získání celého textu z prezentací.

**Q: Proč jsou velikosti odstavců odlišné ve Windows a Linuxu?**

**A**: Výpočet velikostí odstavců vychází z výpočtu velikosti textu, který představuje daný odstavec. Výpočet velikosti textu se zakládá na metrikách fontu určeného v PowerPoint prezentaci. Pokud je požadovaný font chybějící, je nahrazen nejpodobnějším fontem, ale tento font má metriky odlišné od originálu. Výsledkem je, že výpočet velikostí odstavců na různých systémech vede k odlišným výsledkům v závislosti na sadě nainstalovaných fontů. Pro dosažení stejných výsledků na různých operačních systémech je třeba nainstalovat stejné fonty na všechny systémy nebo je načíst za běhu jako [external fonts](/slides/cs/java/custom-font/).

## **Formátování a obrázky**

**Q: Jak mohu nastavit barvu ohraničení tabulky?**

**A**: Můžete změnit barvu všech ohraničení tabulky nebo jen ohraničení celé tabulky. Pro změnu všech ohraničení použijte metodu `getCellFormat` z rozhraní [ICell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icell/). Pro ohraničení celé tabulky je potřeba iterovat buňky a změnit barvu vnějších ohraničení.

**Q: Jakou jednotku používá Aspose.Slides pro Java pro umisťování obrázků?**

**A**: Souřadnice a velikosti všech tvarů na snímcích jsou měřeny v bodech (72 dpi).

## **Práce s fonty**

**Q: Při převodu PPT do PDF nebo obrázků jsou fonty v výstupních dokumentech odlišné, proč?**

**A**: Tento problém může naznačovat, že fonty použité v prezentaci chybí v operačním systému, na kterém byl kód spuštěn. Měli byste fonty nainstalovat do operačního systému nebo je načíst jako externí fonty pomocí třídy [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/), jak je ukázáno níže:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```