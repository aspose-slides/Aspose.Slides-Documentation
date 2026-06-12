---
title: "Často kladené otázky"
type: docs
weight: 340
url: /cs/python-net/faq/
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
- "Python"
- "Aspose.Slides"
description: "Získáte odpovědi na často kladené otázky o Aspose.Slides for Python via .NET, zahrnující podporu PowerPoint a OpenDocument, pokyny k instalaci, licencování a řešení problémů."
---
## **Přehled**

Tento FAQ poskytuje odpovědi na časté otázky týkající se Aspose.Slides. Pokrývá podporované formáty souborů, zpracování výjimek při práci s velkými prezentacemi, změnu velikosti snímků, náhled snímků, získávání textu z prezentací, formátování ohraničení tabulek, vkládání obrázků a řešení problémů s fonty při převodu prezentací do PDF nebo obrázků.

## **Podporované formáty souborů**

**Q: Jaké formáty souborů Aspose.Slides for Python via .NET podporuje?**

**A**: Aspose.Slides for Python via .NET podporuje formáty souborů popsané v [Podporované formáty souborů](/slides/cs/python-net/supported-file-formats/).

## **Výjimky**

**Q: Při načítání velkého PPT souboru s obrázky dostávám výjimku nedostatku paměti. Existuje v Aspose.Slides omezení velikosti souboru?**

**A**: Neexistuje konkrétní vzorec pro výpočet velikosti prezentace podporované Aspose.Slides. Musí být k dispozici dostatek paměti pro uložení celé struktury prezentace a obrázků v paměti. Obvykle obrázky v paměti zabírají více místa než na pevném disku, zejména pokud mají další efekty.

Obecně Aspose.Slides for Python via .NET dokáže snadno zpracovat soubory prezentací o velikosti přibližně 300 MB na serveru s 4 GB RAM.

## **Práce se snímky**

**Q: Mohu změnit velikost snímků v prezentaci?**

**A**: Můžete použít vlastnost `slide_size` poskytovanou třídou [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro definování velikosti snímků v prezentaci.

**Q: Existuje způsob, jak definovat snímky různých velikostí v jedné prezentaci?**

**A**: Protože velikost snímků je definována na úrovni celé prezentace v dokumentech Microsoft PowerPoint, není to možné.

**Q: Podporuje Aspose.Slides for Python via .NET náhled snímku před uložením?**

**A**: Můžete vykreslit snímky prezentace do obrázků a použít tyto obrázky k náhledu snímků.

## **Práce s textem**

**Q: Je možné získat veškerý text z prezentace?**

**A**: Aspose.Slides for Python via .NET poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/) v namespace `aspose.slides.util`, která nabízí různé metody pro získání celého textu z prezentací.

**Q: Proč se velikosti odstavců liší mezi operačními systémy Windows a Linux?**

**A**: Výpočet velikosti odstavců vychází z výpočtu velikosti textu představujícího daný odstavec. Velikost textu se odvozuje od metrik fontu specifikovaného v prezentaci PowerPoint. Pokud požadovaný font chybí, je nahrazen nejbližším fontem, který má jiné metriky než originál. Výsledkem je, že výpočet velikosti odstavců v různých systémech přinese odlišné výsledky v závislosti na sadě nainstalovaných fontů. Pro dosažení stejných výsledků na různých operačních systémech musíte nainstalovat stejné fonty na všech systémech nebo je načíst za běhu jako [externí fonty](/slides/cs/python-net/custom-font/).

## **Formátování a obrázky**

**Q: Jak mohu nastavit barvu okraje tabulky?**

**A**: Můžete změnit barvu všech okrajů tabulky nebo pouze okraje kolem celé tabulky. Pro změnu všech okrajů použijte vlastnost `cell_format` z třídy [Cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides/cell/). Pro okraj celé tabulky byste měli iterovat buňky a změnit barvu vnějších okrajů.

**Q: Jakou jednotku používá Aspose.Slides for Python via .NET pro umisťování obrázků?**

**A**: Souřadnice a velikosti všech tvarů na snímcích jsou měřeny v bodech (72 dpi).

## **Práce s fonty**

**Q: Při konverzi PPT do PDF nebo obrázků jsou ve výstupních dokumentech jiné fonty. Proč?**

**A**: Tento problém může naznačovat, že fonty použité v prezentaci chybí v operačním systému, na kterém byl kód spuštěn. Měli byste fonty na operační systém nainstalovat nebo je načíst jako externí fonty pomocí třídy [FontsLoader](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/) podle níže uvedeného příkladu:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```