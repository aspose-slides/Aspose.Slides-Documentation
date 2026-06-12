---
title: "Často kladené otázky"
type: docs
weight: 340
url: /cs/php-java/faqs/
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
- "PHP"
- "Aspose.Slides"
description: "Získejte odpovědi na FAQ o Aspose.Slides pro PHP přes Java, zahrnující podporu PowerPoint a OpenDocument, pokyny k instalaci, licencování, řešení problémů."
---
## **Přehled**

Tyto často kladené otázky poskytují odpovědi na běžné dotazy týkající se Aspose.Slides. Pokrývají podporované formáty souborů, zpracování výjimek při práci s velkými prezentacemi, změnu velikosti snímků, náhled snímků, získávání textu z prezentací, formátování okrajů tabulek, vkládání obrázků a řešení problémů s fonty při převodu prezentací do PDF nebo obrázků.

## **Podporované formáty souborů**

**Q: Jaké formáty souborů podporuje Aspose.Slides pro PHP přes Java?**

**A**: Aspose.Slides pro PHP přes Java podporuje formáty souborů popsané v [Supported File Formats](/slides/cs/php-java/supported-file-formats/).

## **Výjimky**

**Q: Dostávám výjimku out of memory při načítání velkého souboru PPT s obrázky. Existuje v Aspose.Slides omezení velikosti souboru?**

**A**: Neexistuje žádná konkrétní formule pro výpočet velikosti prezentace podporované Aspose.Slides. Měla by být k dispozici dostatečná paměť pro uložení celé struktury prezentace a obrázků v paměti. Normálně obrázky v paměti zabírají více místa než na pevném disku, zejména pokud mají další efekty.

Obecně může Aspose.Slides pro PHP přes Java snadno zpracovat soubory prezentací o velikosti přibližně 300 MB na serveru s 4 GB RAM.

## **Práce se snímky**

**Q: Můžu změnit velikost snímků v prezentaci?**

**A**: Můžete použít metodu `getSlideSize` vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), abyste definovali velikost snímků v prezentaci.

**Q: Existuje způsob, jak definovat snímky různých velikostí v jedné prezentaci?**

**A**: Protože je velikost snímků definována na úrovni celé prezentace v dokumentech Microsoft PowerPoint, neexistuje způsob, jak to provést.

**Q: Podporuje Aspose.Slides pro PHP přes Java náhled snímku před uložením?**

**A**: Můžete vykreslit snímky prezentace do obrázků a tyto obrázky použít pro náhled snímků.

## **Práce s textem**

**Q: Je možné získat veškerý text z prezentace?**

**A**: Aspose.Slides pro PHP přes Java poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/), která nabízí různé metody pro získání celého textu z prezentací.

**Q: Proč jsou velikosti odstavců odlišné ve Windows a Linuxu?**

**A**: Výpočet velikostí odstavců je založen na výpočtu velikosti textu reprezentujícího daný odstavec. Výpočet velikosti textu vychází z metrik fontu uvedeného v PowerPoint prezentaci. Pokud požadovaný font chybí, je nahrazen nejpodobnějším fontem, který má jiné metriky než originál. V důsledku toho výpočet velikostí odstavců v různých systémech vede k odlišným výsledkům v závislosti na sadě nainstalovaných fontů. Pro dosažení stejných výsledků na různých operačních systémech je nutné nainstalovat stejné fonty na všech systémech nebo je načíst za běhu jako [external fonts](/slides/cs/php-java/custom-font/).

## **Formátování a obrázky**

**Q: Jak mohu nastavit barvu okraje tabulky?**

**A**: Můžete změnit barvu všech okrajů tabulky nebo jen okraje kolem celé tabulky. Pro změnu všech okrajů použijte metodu `getCellFormat` ze třídy [Cell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cell/). Pro okraj celé tabulky byste měli iterovat buňky a změnit barvu vnějších okrajů.

**Q: Jaké jednotky používá Aspose.Slides pro PHP přes Java pro umisťování obrázků?**

**A**: Souřadnice a velikosti všech tvarů na snímcích jsou měřeny v bodech (72 dpi).

## **Práce s fonty**

**Q: Při konverzi PPT do PDF nebo obrázků, proč jsou fonty odlišné ve výstupních dokumentech?**

**A**: Tento problém může naznačovat, že fonty použité v prezentaci chybí v operačním systému, na kterém byl kód spuštěn. Měli byste fonty nainstalovat do operačního systému nebo je načíst jako externí fonty pomocí třídy [FontsLoader](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/), jak je ukázáno níže:
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```