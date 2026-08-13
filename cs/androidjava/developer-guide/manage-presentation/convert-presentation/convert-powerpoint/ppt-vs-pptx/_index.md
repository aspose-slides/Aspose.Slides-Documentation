---
title: "Pochopení rozdílu: PPT vs PPTX"
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
description: "Porovnejte PPT a PPTX pro PowerPoint s Aspose.Slides pro Android pomocí Javy, prozkoumejte rozdíly formátů, výhody, kompatibilitu a tipy na konverzi."
---
## **Přehled**

Tento článek vysvětluje rozdíly mezi formáty PPT a PPTX. Popisuje PPT jako starší binární formát používaný v PowerPointu 97–2003, zatímco PPTX je představován jako moderní formát založený na Office Open XML, který nabízí větší flexibilitu a lépe se hodí pro rozšiřování možností prezentací. Článek také popisuje klíčové aspekty konverze mezi těmito formáty, včetně úvah o kompatibilitě, a ukazuje, jak lze k provedení takových konverzí použít Aspose.Slides. Obecně je doporučeno používat PPTX, kdykoli je to možné.

## **Co je PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) je binární formát souboru, tj. jeho obsah nelze zobrazit bez speciálních nástrojů. První verze PowerPointu 97‑2003 pracovaly s formátem PPT, avšak jeho rozšiřitelnost je omezená.

## **Co je PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) je nový formát souboru prezentace, založený na standardu Office Open XML (ISO 29500:2008‑2016, ECMA‑376). PPTX je archivovaný soubor XML a multimediálních souborů. Formát PPTX se snadno rozšiřuje. Například je snadné přidat podporu nového typu grafu nebo tvaru, aniž by bylo nutné měnit formát PPTX v každé nové verzi PowerPointu. Formát PPTX se používá od PowerPointu 2007.

## **PPT vs PPTX**
Ačkoliv PPTX poskytuje mnohem širší funkčnost, PPT zůstává poměrně populární. Požadavek na konverzi z PPT na PPTX a zpět je vysoký.

Konverze mezi starým PPT a novým PPTX je nejnáročnější výzvou mezi ostatními formáty Microsoft Office. I když je specifikace formátu PPT otevřená, je obtížné s ní pracovat. PowerPoint může v souborech PPT vytvářet speciální části (MetroBlob) pro uložení informací z PPTX, které nejsou podporovány formátem PPT a nemohou být zobrazeny ve starých verzích PowerPointu. Tyto informace lze obnovit, když je soubor PPT načten v moderní verzi PowerPointu nebo konvertován do formátu PPTX.

Aspose.Slides poskytuje jednotné rozhraní pro práci se všemi formáty prezentací. Umožňuje konvertovat z PPT na PPTX i z PPTX na PPT velmi jednoduše. Aspose.Slides plně podporuje konverzi z PPT na PPTX a také podporuje konverzi z PPTX na PPT s některými omezeními. Doporučujeme používat formát PPTX, kdekoli je to možné.

{{% alert color="info" %}} 
Zkontrolujte kvalitu konverzí PPT na PPTX a PPTX na PPT pomocí online [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/cs/conversion/).
{{% /alert %}} 

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor PPT
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// Ukládání PPT prezentace do formátu PPTX
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Přečtěte si více [**Jak převést prezentace PPT na PPTX**.](/slides/cs/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

### Má smysl uchovávat staré prezentace ve formátu PPT, pokud se otevírají bez chyb?
Pokud se prezentace otevírá spolehlivě a nepotřebuje spolupráci ani novější funkce, můžete ji ponechat ve formátu PPT. Pro budoucí kompatibilitu a rozšiřitelnost je však lepší [převést na PPTX](/slides/cs/androidjava/convert-ppt-to-pptx/): formát je založen na otevřeném standardu OOXML a je snadněji podporován moderními nástroji.

### Jak rozhodnout, které soubory jsou nejdůležitější pro první převod na PPTX?
Nejprve převádějte prezentace, které: upravuje více lidí; obsahují složité [grafy](/slides/cs/androidjava/create-chart/)/[tvary](/slides/cs/androidjava/shape-manipulations/); jsou použity v externí komunikaci; nebo při [otevírání](/slides/cs/androidjava/open-presentation/) vyvolávají varování.

### Zachová se ochrana heslem při konverzi z PPT na PPTX a zpět?
Ochrana heslem se přenese pouze při správné konverzi a podpoře šifrování v použitém nástroji. Je spolehlivější [odstranit ochranu](/slides/cs/androidjava/password-protected-presentation/), [převést](/slides/cs/androidjava/convert-ppt-to-pptx/), a pak znovu aplikovat ochranu podle vaší bezpečnostní politiky.

### Proč některé efekty při konverzi PPTX zpět na PPT zmizí nebo se zjednoduší?
Protože PPT nepodporuje některé novější objekty/vlastnosti. PowerPoint a nástroje mohou tyto informace uložit jako „stopy“ v speciálních blocích pro pozdější obnovení, ale starší verze PowerPointu je nebudou zobrazovat.