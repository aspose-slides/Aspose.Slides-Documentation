---
title: Často kladené otázky
type: docs
weight: 340
url: /cs/nodejs-java/faqs/
keywords:
- FAQ
- formát prezentace
- chyba nedostatku paměti
- velikost snímku
- extrahovat text
- získat text
- velikost odstavce
- formátování tabulek
- písmo
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Získejte odpovědi na často kladené otázky k Aspose.Slides pro Node.js prostřednictvím Javy, zahrnující podporu PowerPoint a OpenDocument, pokyny k instalaci, licencování a řešení problémů."
---
## **Přehled**

Tento FAQ poskytuje odpovědi na běžné otázky týkající se Aspose.Slides. Pokrývá podporované formáty souborů, zacházení s výjimkami při práci s velkými prezentacemi, změnu velikosti snímků, náhled snímků, získávání textu z prezentací, formátování ohraničení tabulek, vkládání obrázků a řešení problémů s fonty při převodu prezentací do PDF nebo obrázků.

## **Podporované formáty souborů**

**Q: Jaké formáty souborů podporuje Aspose.Slides pro Node.js prostřednictvím Javy?**

**A**: Aspose.Slides pro Node.js prostřednictvím Javy podporuje formáty souborů popsané v [Supported File Formats](/slides/cs/nodejs-java/supported-file-formats/).

## **Výjimky**

**Q: Při načítání velkého souboru PPT s obrázky dostávám výjimku nedostatku paměti. Existuje v Aspose.Slides omezení velikosti souboru?**

**A**: Neexistuje konkrétní vzorec pro výpočet velikosti prezentace podporované Aspose.Slides. Měla by být k dispozici dostatečná paměť pro uložení celé struktury prezentace a obrázků v paměti. Obvykle obrázky v paměti zabírají více místa než na disku, zejména pokud mají další efekty.

Obecně Aspose.Slides pro Node.js prostřednictvím Javy snadno zvládne soubory prezentací o velikosti přibližně 300 MB na serveru s 4 GB RAM.

## **Práce se snímky**

**Q: Mohu změnit velikost snímků v prezentaci?**

**A**: Můžete použít metodu `getSlideSize` vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) pro definování velikosti snímků v prezentaci.

**Q: Existuje způsob, jak v prezentaci definovat snímky různých velikostí?**

**A**: Protože velikost snímků je v dokumentech Microsoft PowerPoint definována na úrovni celé prezentace, není to možné.

**Q: Podporuje Aspose.Slides pro Node.js prostřednictvím Javy náhled snímku před uložením?**

**A**: Můžete vykreslit snímky prezentace do obrázků a použít tyto obrázky pro náhled snímků.

## **Práce s textem**

**Q: Je možné získat celý text z prezentace?**

**A**: Aspose.Slides pro Node.js prostřednictvím Javy poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/), která nabízí různé metody pro získání celého textu z prezentací.

**Q: Proč se velikosti odstavců liší mezi operačními systémy Windows a Linux?**

**A**: Výpočet velikostí odstavců vychází z výpočtu velikosti textu představujícího daný odstavec. Výpočet velikosti textu je založen na metrikách fontu specifikovaného v prezentaci PowerPoint. Pokud požadovaný font chybí, je nahrazen nejpodobnějším fontem, ale tento font má jiné metriky než originál. Výsledkem je, že výpočet velikostí odstavců v různých systémech vede k odlišným výsledkům v závislosti na sadě nainstalovaných fontů. Pro dosažení stejného výsledku na různých operačních systémech je nutné nainstalovat stejné fonty na všech systémech nebo je načíst za běhu jako [external fonts](/slides/cs/nodejs-java/custom-font/).

## **Formátování a obrázky**

**Q: Jak mohu nastavit barvu ohraničení tabulky?**

**A**: Můžete změnit barvu všech ohraničení tabulky nebo pouze ohraničení kolem celé tabulky. Pro změnu všech ohraničení použijte metodu `getCellFormat` z třídy [Cell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/). Pro ohraničení celé tabulky byste měli iterovat buňky a změnit barvu vnějších ohraničení.

**Q: Jaké jednotky používá Aspose.Slides pro Node.js prostřednictvím Javy pro umisťování obrázků?**

**A**: Souřadnice a velikosti všech tvarů na snímcích jsou měřeny v bodech (72 dpi).

## **Práce s fonty**

**Q: Při konverzi PPT do PDF nebo obrázků, proč jsou ve výstupních dokumentech fonty odlišné?**

**A**: Tento problém může naznačovat, že fonty použité v prezentaci chybí v operačním systému, na kterém byl kód spuštěn. Měli byste nainstalovat fonty do operačního systému nebo je načíst jako externí fonty pomocí třídy [FontsLoader](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/) podle níže uvedeného příkladu:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```