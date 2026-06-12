---
title: "Porozumění rozdílu: PPT vs PPTX"
linktitle: PPT vs PPTX
type: docs
weight: 10
url: /cs/androidjava/ppt-vs-pptx/
keywords:
- PPT vs PPTX
- PPT nebo PPTX
- starý formát
- moderní formát
- binární formát
- moderní standard
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Porovnejte PPT a PPTX pro PowerPoint s Aspose.Slides pro Android pomocí Javy, zkoumejte rozdíly formátů, výhody, kompatibilitu a tipy na převod."
---
## **Přehled**

Tento článek vysvětluje rozdíly mezi formáty PPT a PPTX. Popisuje PPT jako starý binární formát používaný v PowerPointu 97–2003, zatímco PPTX je prezentován jako moderní formát založený na Office Open XML, který nabízí větší flexibilitu a je lépe vhodný pro rozšiřování možností prezentací. Článek také popisuje klíčové aspekty převodu mezi těmito formáty, včetně úvah o kompatibilitě, a ukazuje, jak lze pomocí Aspose.Slides provádět takové převody. Obecně je PPTX doporučován, kdykoli je to možné.

## **Co je PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) je binární formát souboru, tzn. není možné zobrazit jeho obsah bez speciálních nástrojů. První verze PowerPointu 97‑2003 pracovaly s formátem PPT, avšak jeho rozšiřitelnost je omezená.

## **Co je PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) je nový formát souboru prezentace, založený na standardu Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX je archivovaný soubor XML a mediálních souborů. Formát PPTX se snadno rozšiřuje. Například je snadné přidat podporu nového typu grafu nebo tvaru, aniž by se měnil formát PPTX v každé nové verzi PowerPointu. Formát PPTX se používá od PowerPointu 2007.

## **PPT vs PPTX**
I když PPTX poskytuje mnohem širší funkcionalitu, PPT zůstává poměrně populární. Potřeba převodu z PPT na PPTX a naopak je vysoce požadovaná.

Převod mezi starým formátem PPT a novým formátem PPTX je nejnáročnější výzvou mezi ostatními formáty Microsoft Office. Přestože je specifikace formátu PPT otevřená, je obtížné s ním pracovat. PowerPoint může v souborech PPT vytvářet speciální části (MetroBlob) k ukládání informací z PPTX, které nejsou podporovány formátem PPT a nelze je zobrazit ve starých verzích PowerPointu. Tyto informace lze obnovit, když je soubor PPT načten v moderní verzi PowerPointu nebo převeden do formátu PPTX.

Aspose.Slides poskytuje jednotné rozhraní pro práci se všemi formáty prezentací. Umožňuje převádět z PPT na PPTX a z PPTX na PPT velmi jednoduše. Aspose.Slides plně podporuje převod z PPT na PPTX a také podporuje převod z PPTX na PPT s některými omezeními. Doporučujeme používat formát PPTX, kdekoli je to možné.

{{% alert color="primary" %}} 
Zkontrolujte kvalitu převodů PPT na PPTX a PPTX na PPT pomocí online [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/cs/conversion/).
{{% /alert %}} 

```java
// Vytvořte objekt Presentation, který představuje soubor PPT
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// Ukládání PPT prezentace do formátu PPTX
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Přečtěte si více [**Jak převést prezentace PPT na PPTX**.](/slides/cs/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 

## **Často kladené otázky**

**Má smysl uchovávat staré prezentace ve formátu PPT, pokud se otevírají bez chyb?**

Pokud se prezentace spolehlivě otevírá a nepotřebuje spolupráci ani novější funkce, můžete ji ponechat v PPT. Pro budoucí kompatibilitu a rozšiřitelnost je však lepší [převést na PPTX](/slides/cs/androidjava/convert-ppt-to-pptx/): formát je založen na otevřeném standardu OOXML a je snadněji podporován moderními nástroji.

**Jak mohu rozhodnout, které soubory je nejdříve kritické převést na PPTX?**

Nejprve převádějte prezentace, které: jsou editovány více lidmi; obsahují složité [grafy](/slides/cs/androidjava/create-chart/)/[tvary](/slides/cs/androidjava/shape-manipulations/); jsou použity v externí komunikaci; nebo při [otevření](/slides/cs/androidjava/open-presentation/) vyvolávají varování.

**Zůstane ochrana heslem zachována při převodu z PPT na PPTX a zpět?**

Přítomnost hesla se přenese pouze při správném převodu a podpoře šifrování v použitém nástroji. Je spolehlivější [odstranit ochranu](/slides/cs/androidjava/password-protected-presentation/), [převést](/slides/cs/androidjava/convert-ppt-to-pptx/), a pak znovu aplikovat ochranu podle vaší bezpečnostní politiky.

**Proč některé efekty při převodu PPTX zpět na PPT zmizí nebo se zjednoduší?**

Protože PPT nepodporuje některé novější objekty/vlastnosti. PowerPoint a nástroje mohou ukládat „stopy“ těchto informací ve speciálních blocích pro pozdější obnovení, ale starší verze PowerPointu je nevykreslí.