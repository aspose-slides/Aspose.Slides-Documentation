---
title: "Pochopení rozdílu: PPT vs PPTX"
linktitle: "PPT vs PPTX"
type: docs
weight: 10
url: /cs/nodejs-java/ppt-vs-pptx/
keywords:
- PPT vs PPTX
- PPT nebo PPTX
- zastaralý formát
- moderní formát
- binární formát
- moderní standard
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Porovnejte PPT a PPTX pro PowerPoint s Aspose.Slides pro Node.js pomocí Javy, prozkoumejte rozdíly formátů, výhody, kompatibilitu a tipy na konverzi."
---
## **Přehled**

Tento článek vysvětluje rozdíly mezi formáty PPT a PPTX. Popisuje PPT jako starý binární formát používaný v PowerPointu 97–2003, zatímco PPTX je představen jako moderní formát založený na Office Open XML, který nabízí větší flexibilitu a je vhodnější pro rozšiřování možností prezentací. Článek také uvádí klíčové aspekty konverze mezi těmito formáty, včetně úvah o kompatibilitě, a ukazuje, jak lze k provedení takových konverzí použít Aspose.Slides. Obecně se doporučuje používat PPTX, kdykoli je to možné.

## **Co je PPT?**

[**PPT**](https://docs.fileformat.com/presentation/ppt/) je binární formát souboru, tj. jeho obsah nelze zobrazit bez speciálních nástrojů. První verze PowerPointu 97‑2003 pracovaly s formátem PPT, avšak jeho rozšiřitelnost je omezená.

## **Co je PPTX?**

[**PPTX**](https://docs.fileformat.com/presentation/pptx/) je nový formát souboru prezentace, založený na standardu Office Open XML (ISO 29500:2008‑2016, ECMA‑376). PPTX je archivovaný soubor XML a mediálních souborů. Formát PPTX se snadno rozšiřuje. Například je jednoduché přidat podporu pro nový typ grafu nebo tvaru, bez změny formátu PPTX v každé nové verzi PowerPointu. Formát PPTX se používá od PowerPointu 2007.

## **PPT vs PPTX**

I když PPTX poskytuje mnohem širší funkčnost, PPT zůstává poměrně populární. Potřeba konverze z PPT na PPTX a naopak je velmi požadovaná.

Nicméně konverze mezi starým PPT a novým PPTX formátem je nejnáročnější výzvou mezi ostatními formáty Microsoft Office. Ačkoli je specifikace formátu PPT otevřená, je obtížné s ním pracovat. PowerPoint může v souborech PPT vytvářet speciální části (MetroBlob), aby uložit informace z PPTX, které nejsou podporovány formátem PPT a nelze je zobrazit ve starých verzích PowerPointu. Tyto informace lze obnovit, když je soubor PPT načten v moderní verzi PowerPointu nebo převeden do formátu PPTX.

Aspose.Slides poskytuje společnou třídu pro práci se všemi formáty prezentací. Umožňuje konverzi z PPT na PPTX i z PPTX na PPT velmi jednoduše. Aspose.Slides plně podporuje konverzi z PPT na PPTX a také podporuje konverzi z PPTX na PPT s jistými omezeními. Doporučujeme používat formát PPTX, kdykoli je to možné.

{{% alert color="primary" %}} 
Zkontrolujte kvalitu konverzí PPT na PPTX a PPTX na PPT pomocí online [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/cs/conversion/).
{{% /alert %}} 

```javascript
// Vytvořte objekt Presentation, který reprezentuje soubor PPT
var pres = new aspose.slides.Presentation("PPTtoPPTX.ppt");
try {
    // Ukládání prezentace PPT do formátu PPTX
    pres.save("PPTtoPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Přečtěte si více [**Jak převést prezentace PPT na PPTX**.](/slides/cs/nodejs-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**Je nějaký smysl uchovávat staré prezentace ve formátu PPT, pokud se otevírají bez chyb?**

Pokud se prezentace spolehlivě otevírá a nepotřebuje spolupráci ani novější funkce, můžete ji ponechat ve formátu PPT. Pro budoucí kompatibilitu a rozšiřitelnost je však lepší [převést na PPTX](/slides/cs/nodejs-java/convert-ppt-to-pptx/): formát je založen na otevřeném standardu OOXML a je snadněji podporován moderními nástroji.

**Jak rozhodnout, které soubory je nejdříve nutné převést na PPTX?**

Nejprve převádějte prezentace, které: editují více lidí; obsahují složité [grafy](/slides/cs/nodejs-java/create-chart/)/[tvary](/slides/cs/nodejs-java/shape-manipulations/); jsou používány v externí komunikaci; nebo při [otevření](/slides/cs/nodejs-java/open-presentation/) vyvolávají varování.

**Zachová se ochrana heslem při převodu z PPT na PPTX a zpět?**

Přítomnost hesla se přenese jen při správné konverzi a podpoře šifrování v použitém nástroji. Je spolehlivější [odstranit ochranu](/slides/cs/nodejs-java/password-protected-presentation/), [převést](/slides/cs/nodejs-java/convert-ppt-to-pptx/), a pak znovu aplikovat ochranu podle vaší bezpečnostní politiky.

**Proč některé efekty při převodu PPTX zpět na PPT zmizí nebo se zjednoduší?**

Protože PPT nepodporuje některé novější objekty/vlastnosti. PowerPoint a nástroje mohou uchovávat „stopy“ těchto informací ve speciálních blocích pro pozdější obnovu, ale starší verze PowerPointu je nebudou renderovat.