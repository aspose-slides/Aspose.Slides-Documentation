---
title: "Často kladené otázky"
type: docs
weight: 340
url: /cs/androidjava/faqs/
keywords:
- "Často kladené otázky"
- "formát prezentace"
- "chyba nedostatku paměti"
- "velikost snímku"
- "extrahovat text"
- "získat text"
- "velikost odstavce"
- "formátování tabulek"
- "font"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Získejte odpovědi na často kladené otázky o Aspose.Slides pro Android pomocí Javy, zahrnující podporu PowerPointu a OpenDocumentu, návod na instalaci, licencování a řešení problémů."
---
## **Přehled**

Tento FAQ poskytuje odpovědi na časté otázky týkající se Aspose.Slides. Pokrývá podporované formáty souborů, zacházení s výjimkami při práci s velkými prezentacemi, změnu velikosti snímků, náhled snímků, získávání textu z prezentací, formátování okrajů tabulek, umisťování obrázků a řešení problémů s fonty při převodu prezentací do PDF nebo obrázků.

## **Podporované formáty souborů**

**Q: Jaké formáty souborů podporuje Aspose.Slides for Android via Java?**

**A**: Aspose.Slides for Android via Java podporuje formáty souborů popsané v [Podporované formáty souborů](/slides/cs/androidjava/supported-file-formats/).

## **Výjimky**

**Q: Při načítání velkého souboru PPT s obrázky dostávám výjimku nedostatku paměti. Existuje omezení v Aspose.Slides ohledně velikosti souboru?**

**A**: Neexistuje žádný konkrétní vzorec pro výpočet velikosti prezentace podporované Aspose.Slides. Měla by být k dispozici dostatečná paměť pro uložení celé struktury prezentace a obrázků v paměti. Normálně obrázky v paměti zabírají více místa než na pevném disku, zejména pokud mají další efekty.

Obecně Aspose.Slides for Android via Java může snadno zpracovat soubory prezentací o velikosti přibližně 300 MB na serveru s 4 GB RAM.

## **Práce se snímky**

**Q: Mohu změnit velikost snímků v prezentaci?**

**A**: Můžete použít metodu `getSlideSize` vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) k definování velikosti snímků v prezentaci.

**Q: Je možné definovat snímky různých velikostí v jedné prezentaci?**

**A**: Protože velikost snímků je v dokumentech Microsoft PowerPoint definována na úrovni celé prezentace, neexistuje způsob, jak to provést.

**Q: Podporuje Aspose.Slides for Android via Java náhled snímku před uložením?**

**A**: Můžete vykreslit snímky prezentace do obrázků a tyto obrázky použít pro náhled snímků.

## **Práce s textem**

**Q: Je možné získat veškerý text z prezentace?**

**A**: Aspose.Slides for Android via Java poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/), která nabízí různé metody pro získání celého textu z prezentací.

**Q: Proč jsou velikosti odstavců odlišné na PC a Androidu?**

**A**: Výpočet velikostí odstavců je založen na výpočtu velikosti textu představujícího daný odstavec. Velikost textu se počítá podle metrických parametrů fontu uvedeného v prezentaci PowerPoint. Pokud je požadovaný font chybějící, je nahrazen nejpodobnějším fontem, ale tento font má metriky odlišné od originálu. Výsledkem je, že výpočet velikosti odstavců v různých systémech vede k odlišným výsledkům v závislosti na sadě nainstalovaných fontů. Pro dosažení stejných výsledků na různých operačních systémech je nutné nainstalovat stejné fonty na všech systémech nebo je načíst za běhu jako [externí fonty](/slides/cs/androidjava/custom-font/).

## **Formátování a obrázky**

**Q: Jak mohu nastavit barvu okraje tabulky?**

**A**: Můžete změnit barvu všech okrajů tabulky nebo pouze okraj okolo celé tabulky. Pro změnu všech okrajů použijte metodu `getCellFormat` z rozhraní [ICell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icell/). Pro okraj celé tabulky byste měli iterovat buňky a změnit barvu vnějších okrajů.

**Q: Jakou jednotku používá Aspose.Slides for Android via Java při umisťování obrázků?**

**A**: Souřadnice a rozměry všech tvarů na snímcích jsou měřeny v bodech (72 dpi).

## **Práce s fonty**

**Q: Při převodu PPT do PDF nebo obrázků, proč jsou fonty ve výstupních dokumentech odlišné?**

**A**: Tento problém může naznačovat, že fonty použité v prezentaci chybí v operačním systému, na kterém byl kód spuštěn. Měli byste fonty nainstalovat v operačním systému nebo je načíst jako externí fonty pomocí třídy [FontsLoader](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/), jak je ukázáno níže:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```