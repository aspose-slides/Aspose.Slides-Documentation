---
title: "Často kladené otázky"
type: docs
weight: 340
url: /cs/python-java/faqs/
keywords:
- "Často kladené otázky"
- "formát prezentace"
- "chyba nedostatku paměti"
- "velikost snímku"
- "extrakce textu"
- "velikost odstavce"
- "okraje tabulky"
- "font"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Najděte odpovědi na časté dotazy o Aspose.Slides pro Python via Java, včetně formátů souborů, využití paměti, velikostí snímků, textu, tabulek, obrázků a fontů."
---
## **Přehled**

Tato FAQ pokrývá podporované formáty souborů, využití paměti u velkých prezentací, velikosti snímků a náhledy, extrakci textu, okraje tabulek, umístění obrázků a rozdíly ve fontách při převodu prezentací do PDF nebo obrázků.

## **Často kladené otázky**

### **Podporované formáty souborů**

**Jaké formáty souborů podporuje Aspose.Slides for Python via Java?**

Podívejte se na [Podporované formáty souborů](/slides/cs/python-java/supported-file-formats/) pro seznam podporovaných formátů prezentací, dokumentů a obrázků a jejich možnosti importu a exportu.

### **Výjimky**

**Proč při načítání velké prezentace s obrázky dostanu chybu nedostatku paměti? Existuje omezení velikosti souboru?**

Neexistuje jediné prahové číslo velikosti souboru, které by určovalo, zda se prezentace vejde do paměti. Požadavky na paměť závisí na struktuře prezentace, dekomprimovaných obrázcích, efektech a prováděných operacích. Obrázky mohou zabírat mnohem více paměti než jejich komprimovaná velikost na disku.

Aspose.Slides for Python via Java používá Java engine přes JPype, takže halda JVM musí mít dostatek místa pro zpracování. Pouze dostupná systémová RAM neukazuje, kolik paměti může JVM využít. Po dokončení práce uvolněte prezentace pomocí [Presentation.dispose](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#dispose). Pro nastavení prostředí viz [Požadavky na systém](/slides/cs/python-java/system-requirements/) a [Instalace](/slides/cs/python-java/installation/).

### **Práce se snímky**

**Mohu změnit velikost snímků v prezentaci?**

Ano. Použijte [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getslidesize) k získání nastavení velikosti snímků prezentace a následně [SlideSize.setSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesize/#setsize) k nastavení rozměrů a volbě, jak se stávající obsah přizpůsobí.

**Mohou mít snímky ve stejné prezentaci různé velikosti?**

Ne. Dokumenty Microsoft PowerPoint definují velikost snímku na úrovni celé prezentace, takže všechny snímky sdílejí stejné rozměry.

**Mohu zobrazit náhled snímku před uložením prezentace?**

Ano. Vykreslete snímek do obrázku a zobrazte tento obrázek ve své aplikaci. Není nutné nejprve prezentaci uložit.

### **Práce s textem**

**Mohu získat celý text z prezentace?**

Ano. Třída [SlideUtil](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/) poskytuje metody pro získání textu z prezentací i jednotlivých snímků.

**Proč se velikosti odstavců liší ve Windows a Linuxu?**

Rozměry odstavců závisí na metrikách fontů použitého při vykreslování textu. Pokud chybí font, může být použitý náhradní mít jiné šířky znaků a výšky řádků, což mění zalamování řádků a rozměry odstavců. Nainstalujte stejné fonty na oba systémy nebo načtěte stejné soubory fontů pomocí [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#loadexternalfonts) před vytvořením či načtením prezentací.

### **Formátování a obrázky**

**Jak mohu nastavit barvu okraje tabulky?**

Použijte [Cell.getCellFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cell/#getcellformat) k získání formátování okraje každé buňky a nastavte barvu výplně pro odpovídající okraje. Pro změnu všech okrajů projděte všechny buňky. Pro změnu pouze obrysu tabulky aktualizujte jen vnější okraje buněk podél jejích hran.

**Jaké jednotky se používají pro umístění a velikost obrázků?**

Souřadnice a rozměry tvarů jsou měřeny v bodech. Jeden palec se rovná 72 bodům; tyto hodnoty nejsou pixelové souřadnice.

### **Práce s fonty**

**Proč se fonty mění, když převádím prezentaci do PDF nebo obrázků?**

Požadované fonty mohou na stroji, který provádí převod, chybět. Nainstalujte původní fonty nebo použijte [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#loadexternalfonts) k přidání složek, které je obsahují. Načtěte externí fonty před vytvořením nebo otevřením prezentací.

Následující příklad registruje složku s fonty. Nahraďte cestu existující složkou obsahující vaše soubory fontů. Předpokládá se prostředí popsané v [Instalaci](/slides/cs/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

Příklad ponechává JVM běžící pro následné operace s prezentacemi. Pro použití v notebooku a omezení životnosti JVM viz [Omezení a rozdíly API](/slides/cs/python-java/limitations-and-api-differences/).