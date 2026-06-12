---
title: "Pochopení rozdílu: PPT vs PPTX"
linktitle: PPT vs PPTX
type: docs
weight: 10
url: /cs/python-net/ppt-vs-pptx/
keywords:
- PPT vs PPTX
- PPT nebo PPTX
- starý formát
- moderní formát
- binární formát
- moderní standard
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Porovnejte PPT a PPTX pro PowerPoint s Aspose.Slides Python pomocí .NET, zkoumejte rozdíly formátů, výhody, kompatibilitu a tipy na konverzi."
---
## **Přehled**

Tento článek vysvětluje rozdíly mezi formáty PPT a PPTX. Popisuje PPT jako starší binární formát používaný v PowerPoint 97–2003, zatímco PPTX je představen jako moderní formát založený na Office Open XML, který nabízí větší flexibilitu a je lépe přizpůsoben pro rozšíření možností prezentací. Článek také shrnuje klíčové aspekty konverze mezi těmito formáty, včetně úvah o kompatibilitě, a ukazuje, jak lze použít Aspose.Slides k provedení takových konverzí. Obecně se doporučuje používat PPTX, kdykoli je to možné.

## **Co je PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) je binární souborový formát, tj. jeho obsah nelze zobrazit bez speciálních nástrojů. První verze PowerPoint 97‑2003 pracovaly s formátem PPT, avšak jeho rozšiřitelnost je omezená.

## **Co je PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) je nový formát prezentačních souborů, založený na standardu Office Open XML (ISO 29500:2008‑2016, ECMA‑376). PPTX je archivovaný soubor XML a mediálních souborů. Formát PPTX je snadno rozšiřitelný. Například je snadné přidat podporu pro nový typ grafu nebo tvaru, aniž by bylo nutné měnit formát PPTX v každé nové verzi PowerPointu. Formát PPTX se používá od PowerPointu 2007.

## **PPT vs PPTX**
Ačkoli PPTX poskytuje mnohem širší funkčnost, PPT zůstává poměrně populární. Potřeba konverze z PPT na PPTX a naopak je vysoce žádaná.

Nicméně konverze mezi starým PPT a novým PPTX formátem je nejnáročnější výzvou mezi ostatními formáty Microsoft Office. Přestože je specifikace formátu PPT otevřená, je s ní obtížně pracovat. PowerPoint může v souborech PPT vytvořit speciální části (MetroBlob) pro uložení informací z PPTX, které nejsou podporovány formátem PPT a nemohou být zobrazeny ve starých verzích PowerPointu. Tyto informace lze obnovit, když je soubor PPT načten v moderní verzi PowerPointu nebo převeden do formátu PPTX.

Aspose.Slides poskytuje jednotné rozhraní pro práci se všemi formáty prezentací. Umožňuje konvertovat z PPT na PPTX a z PPTX na PPT velmi jednoduše. Aspose.Slides plně podporuje konverzi z PPT na PPTX a také podporuje konverzi z PPTX na PPT s určitými omezeními. Doporučujeme používat formát PPTX, kdykoli je to možné.

{{% alert color="primary" %}} 
Zkontrolujte kvalitu konverzí PPT na PPTX a PPTX na PPT pomocí online [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/cs/conversion/).
{{% /alert %}} 

```py
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor PPTX
pres = slides.Presentation("PPTtoPPTX.ppt")

# Uložení prezentace PPTX do formátu PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Přečtěte si více [**Jak převést prezentace PPT na PPTX**](/slides/cs/python-net/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**Má smysl uchovávat staré prezentace ve formátu PPT, pokud se otevírají bez chyb?**

Pokud se prezentace otevírá spolehlivě a nepotřebuje spolupráci ani novější funkce, můžete ji zachovat ve formátu PPT. Pro budoucí kompatibilitu a rozšiřitelnost je však lepší [převést na PPTX](/slides/cs/python-net/convert-ppt-to-pptx/): formát je založen na otevřeném standardu OOXML a je lépe podporován moderními nástroji.

**Jak mohu rozhodnout, které soubory je třeba nejdříve převést na PPTX?**

Nejprve převádějte prezentace, které: jsou editovány více lidmi; obsahují složité [grafy](/slides/cs/python-net/create-chart/)/[tvary](/slides/cs/python-net/shape-manipulations/); jsou používány v externí komunikaci; nebo vyvolávají varování při [otevření](/slides/cs/python-net/open-presentation/).

**Zůstane ochrana heslem zachována při konverzi z PPT na PPTX a zpět?**

Existence hesla přetrvá pouze při správné konverzi a podpoře šifrování v použitém nástroji. Je spolehlivější [odstranit ochranu](/slides/cs/python-net/password-protected-presentation/), [převést](/slides/cs/python-net/convert-ppt-to-pptx/), a poté znovu aplikovat ochranu podle vaší bezpečnostní politiky.

**Proč některé efekty zmizí nebo jsou zjednodušeny při konverzi PPTX zpět na PPT?**

Protože PPT nepodporuje některé novější objekty/vlastnosti. PowerPoint a nástroje mohou tuto informaci uložit jako „stopy“ ve speciálních blocích pro pozdější obnovení, ale starší verze PowerPointu je nezobrazí.